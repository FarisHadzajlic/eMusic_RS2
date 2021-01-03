using AutoMapper;
using eMusic.Database;
using eMusic.Exceptions;
using eMusic.Interface;
using eMusic.Model;
using eMusic.Model.Request;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eMusic.Service
{
    public class ArtistService : CRUDService<MArtist, ArtistSearchRequest, Artist, ArtistUpsertRequest, ArtistUpsertRequest>, IArtistService
    {
        private readonly eMusicContext _context;
        private readonly IMapper _mapper;

        public ArtistService(eMusicContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public override async Task<List<MArtist>> Get(ArtistSearchRequest request)
        {
            var query = _context.Artists.AsQueryable();

            if (!string.IsNullOrWhiteSpace(request.Name))
            {
                query = query.Where(x => x.Name.StartsWith(request.Name));
            }

            var list = await query.ToListAsync();

            return _mapper.Map<List<MArtist>>(list);
        }
        public override async Task<MArtist> GetById(int ID)
        {
            var entity = await _context.Artists
                .Include(i => i.Albums)
                .Where(i => i.ArtistID == ID)
                .SingleOrDefaultAsync();

            return _mapper.Map<MArtist>(entity);
        }
        public override async Task<MArtist> Insert(ArtistUpsertRequest request)
        {
            if (await _context.Artists.AnyAsync(i => i.Name == request.Name))
            {
                throw new UserException("Artist already exists!");
            }

            var entity = _mapper.Map<Artist>(request);
            _context.Set<Artist>().Add(entity);
            await _context.SaveChangesAsync();

            return _mapper.Map<MArtist>(entity);
        }
        public override async Task<MArtist> Update(int id, ArtistUpsertRequest request)
        {
            var genre = await _context.Artists.FindAsync(id);
            if (await _context.Artists.AnyAsync(i => i.Name == request.Name) && request.Name != genre.Name)
            {
                throw new UserException("Artist already exists!");
            }

            var entity = _context.Set<Artist>().Find(id);
            _context.Set<Artist>().Attach(entity);
            _context.Set<Artist>().Update(entity);

            _mapper.Map(request, entity);

            await _context.SaveChangesAsync();

            return _mapper.Map<MArtist>(entity);
        }
        public async Task<List<MAlbum>> GetAlbums(int ID, AlbumSearchRequest request)
        {
            var query = _context.Albums
                .Include(i => i.AlbumTracks)
                .Include(i => i.Artist)
                .Where(i => i.ArtistID == ID)                
                .AsQueryable();

            var list = await query.ToListAsync();

            return _mapper.Map<List<MAlbum>>(list);
        }
        public override async Task<bool> Delete(int ID)
        {
            var artist = await _context.Artists.Where(i => i.ArtistID == ID).FirstOrDefaultAsync();
            var album = await _context.Albums.Where(i => i.ArtistID == ID).Include(i => i.AlbumTracks).ToListAsync();
            var albumTracks = await _context.AlbumTracks.Where(i => i.Album.ArtistID == ID).ToListAsync();
            var Buyalbum = await _context.BuyAlbums.Where(i => i.Album.ArtistID == ID).ToListAsync();
            if (album.Count > 0)
            {
                _context.AlbumTracks.RemoveRange(albumTracks);
                if (Buyalbum.Count > 0)
                    _context.BuyAlbums.RemoveRange(Buyalbum);
                _context.Albums.RemoveRange(album);
                await _context.SaveChangesAsync();
            }
            if(artist != null) { 
                var playlistTracks = await _context.PlaylistTracks.Where(i => i.Track.ArtistID == ID).ToListAsync();
                _context.PlaylistTracks.RemoveRange(playlistTracks);
                var tracks = await _context.Tracks.Where(i => i.ArtistID == ID).ToListAsync();
                _context.Tracks.RemoveRange(tracks);
                var userTracks = await _context.UserLikedTracks.Where(i => i.Track.ArtistID == ID).ToListAsync();
                _context.UserLikedTracks.RemoveRange(userTracks);
                var userArtist = await _context.UserLikedArtists.Where(i => i.ArtistID == ID).ToListAsync();
                _context.UserLikedTracks.RemoveRange(userTracks);
                var userReview = await _context.UserTrackReviews.Where(i => i.Track.ArtistID == ID).ToListAsync();
                await _context.SaveChangesAsync();
                var entity = await _context.Artists.Where(i => i.ArtistID == ID).FirstOrDefaultAsync();
                _context.Artists.Remove(entity);
                await _context.SaveChangesAsync();
            }

            return true;
        }
    }
}

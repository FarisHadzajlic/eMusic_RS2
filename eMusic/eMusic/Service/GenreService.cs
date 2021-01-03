using AutoMapper;
using eMusic.Database;
using eMusic.Exceptions;
using eMusic.Model;
using eMusic.Model.Request;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eMusic.Service
{
    public class GenreService : CRUDService<MGenre, GenreSearchRequest, Genre, GenreUpsertRequest, GenreUpsertRequest>
    {
        private readonly eMusicContext _context;
        private readonly IMapper _mapper;
        public GenreService(eMusicContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public override async Task<List<MGenre>> Get(GenreSearchRequest request)
        {
            var query = _context.Genres.AsQueryable();

            if (!string.IsNullOrWhiteSpace(request?.Name))
            {
                query = query.Where(x => x.Name.StartsWith(request.Name));
            }
            var list = await query.ToListAsync();

            return _mapper.Map<List<MGenre>>(list);
        }
        public override async Task<MGenre> GetById(int ID)
        {
            var entity = await _context.Genres
                .Where(i => i.GenreID == ID)
                .SingleOrDefaultAsync();

            return _mapper.Map<MGenre>(entity);
        }
        public override async Task<MGenre> Insert(GenreUpsertRequest request)
        {
            if (await _context.Genres.AnyAsync(i => i.Name == request.Name))
            {
                throw new UserException("Genre already exists!");
            }
            var entity = _mapper.Map<Genre>(request);

            _context.Set<Genre>().Add(entity);
            await _context.SaveChangesAsync();

            return _mapper.Map<MGenre>(entity);
        }
        public override async Task<MGenre> Update(int ID, GenreUpsertRequest request)
        {
            var genre = await _context.Genres.FindAsync(ID);
            if (await _context.Genres.AnyAsync(i => i.Name == request.Name) && request.Name != genre.Name)
            {
                throw new UserException("Genre already exists!");
            }

            var entity = _context.Set<Genre>().Find(ID);
            _context.Set<Genre>().Attach(entity);
            _context.Set<Genre>().Update(entity);

            _mapper.Map(request, entity);

            await _context.SaveChangesAsync();

            return _mapper.Map<MGenre>(entity);
        }
        public override async Task<bool> Delete(int ID)
        {
            var genre = await _context.Genres.Where(i => i.GenreID == ID).FirstOrDefaultAsync();
            var album = await _context.Albums.Where(i => i.GenreID == ID).Include(i => i.AlbumTracks).ToListAsync();
            var albumTracks = await _context.AlbumTracks.Where(i => i.Album.GenreID == ID).ToListAsync();
            var Buyalbum = await _context.BuyAlbums.Where(i => i.Album.GenreID == ID).ToListAsync();
            if (album.Count > 0)
            {
                _context.AlbumTracks.RemoveRange(albumTracks);
                if (Buyalbum.Count > 0)
                    _context.BuyAlbums.RemoveRange(Buyalbum);
                _context.Albums.RemoveRange(album);
                await _context.SaveChangesAsync();
            }
            if (genre != null)
            {      
                var playlistTracks = await _context.PlaylistTracks.Where(i => i.Track.GenreID == ID).ToListAsync();
                _context.PlaylistTracks.RemoveRange(playlistTracks);
                var tracks = await _context.Tracks.Where(i => i.GenreID == ID).ToListAsync();
                _context.Tracks.RemoveRange(tracks);
                var userTracks = await _context.UserLikedTracks.Where(i => i.Track.GenreID == ID).ToListAsync();
                _context.UserLikedTracks.RemoveRange(userTracks);
                var userReview = await _context.UserTrackReviews.Where(i => i.Track.GenreID == ID).ToListAsync();
                await _context.SaveChangesAsync();

                _context.Genres.Remove(genre);
                await _context.SaveChangesAsync();

                return true;
            }
            return false;
        }
    }
}

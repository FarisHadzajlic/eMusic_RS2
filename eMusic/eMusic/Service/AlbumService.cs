using AutoMapper;
using eMusic.Database;
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
    public class AlbumService : CRUDService<MAlbum, AlbumSearchRequest, Album, AlbumUpsertRequest, AlbumUpsertRequest>, IAlbumService
    {
        private readonly eMusicContext _context;
        private readonly IMapper _mapper;
        public AlbumService(eMusicContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public override async Task<List<MAlbum>> Get(AlbumSearchRequest request)
        {
            var query = _context.Albums.Include(i => i.Artist).Include(i => i.AlbumTracks).AsQueryable();

            if (request?.GenreID.HasValue == true)
            {
                query = query.Where(x => x.GenreID == request.GenreID);
            }          

            if (!string.IsNullOrWhiteSpace(request?.Name))
            {
                query = query.Where(x => x.Name.StartsWith(request.Name));
            }

            var list = await query.ToListAsync();

            return _mapper.Map<List<MAlbum>>(list);
        }
        public override async Task<MAlbum> GetById(int ID)
        {
            var entity = await _context.Albums
                .Include(i => i.AlbumTracks)
                .Where(i => i.AlbumID == ID)
                .SingleOrDefaultAsync();

            return _mapper.Map<MAlbum>(entity);
        }
        public override async Task<MAlbum> Insert(AlbumUpsertRequest request)
        {
            var entity = _mapper.Map<Album>(request);

            await _context.Albums.AddAsync(entity);
            await _context.SaveChangesAsync();

            foreach (var trackID in request.Tracks)
            {
                var albumTrack = new AlbumTrack()
                {
                    AlbumID = entity.AlbumID,
                    TrackID = trackID
                };
                _context.AlbumTracks.Add(albumTrack);
            }
            await _context.SaveChangesAsync();

            return _mapper.Map<MAlbum>(entity);
        }
        public override async Task<MAlbum> Update(int id, AlbumUpsertRequest request)
        {
            var entity = _context.Albums.Find(id);
            _context.Albums.Attach(entity);
            _context.Albums.Update(entity);

            foreach (var TrackID in request.Tracks)
            {
                var albumTrack = await _context.AlbumTracks
                    .Where(i => i.TrackID == TrackID && i.AlbumID == id)
                    .SingleOrDefaultAsync();

                if (albumTrack == null)
                {
                    var newAlbumTrack = new AlbumTrack()
                    {
                        AlbumID = id,
                        TrackID = TrackID
                    };
                    await _context.Set<AlbumTrack>().AddAsync(newAlbumTrack);
                }
            }

            foreach (var TrackID in request.TracksToDelete)
            {
                var albumTrack = await _context.AlbumTracks
                    .Where(i => i.TrackID == TrackID && i.AlbumID == id)
                    .SingleOrDefaultAsync();

                if (albumTrack != null)
                {
                    _context.Set<AlbumTrack>().Remove(albumTrack);
                }
            }

            _mapper.Map(request, entity);
            await _context.SaveChangesAsync();

            return _mapper.Map<MAlbum>(entity);
        }
        public async Task<List<MTrack>> GetTracks(int ID, TrackSearchRequest request)
        {
            var query = _context.AlbumTracks
                .Include(i => i.Track)
                .ThenInclude(i => i.Artist)
                .Where(i => i.AlbumID == ID)
                .Select(i => i.Track)
                .AsQueryable();

            var list = await query.ToListAsync();

            return _mapper.Map<List<MTrack>>(list);
        }
        public override async Task<bool> Delete(int ID)
        {
            var album = await _context.Albums.Where(i => i.AlbumID == ID).Include(i => i.AlbumTracks).FirstOrDefaultAsync();
            var Buyalbum = await _context.BuyAlbums.Where(i => i.AlbumID == ID).ToListAsync();
            if (album != null)
            {
                if (Buyalbum.Count > 0)
                    _context.BuyAlbums.RemoveRange(Buyalbum);

                _context.AlbumTracks.RemoveRange(album.AlbumTracks);
                _context.Albums.Remove(album);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}

using AutoMapper;
using eMusic.Database;
using eMusic.Model;
using eMusic.Model.Request;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eMusic.Service
{
    public class TrackService : CRUDService<MTrack, TrackSearchRequest, Track, TrackUpsertRequest, TrackUpsertRequest>
    {
        private readonly eMusicContext _context;
        private readonly IMapper _mapper;
        public TrackService(eMusicContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public override async Task<List<MTrack>> Get(TrackSearchRequest request)
        {
            var query = _context.Tracks
                .Include(i => i.Artist)
                .AsQueryable();

            if (request?.GenreID.HasValue == true)
            {
                query = query.Where(x => x.GenreID == request.GenreID);
            }

            if (!string.IsNullOrWhiteSpace(request?.Name))
            {
                query = query.Where(x => x.Name.StartsWith(request.Name));
            }

            var list = await query.ToListAsync();

            return _mapper.Map<List<MTrack>>(list);
        }
        public override async Task<MTrack> Insert(TrackUpsertRequest request)
        {
            var entity = _mapper.Map<Track>(request);

            await _context.Tracks.AddAsync(entity);
            await _context.SaveChangesAsync();

            return _mapper.Map<MTrack>(entity);
        }
        public override async Task<MTrack> GetById(int ID)
        {
            var entity = await _context.Tracks
                .SingleOrDefaultAsync(i => i.TrackID == ID);

            return _mapper.Map<MTrack>(entity);
        }
        public override async Task<bool> Delete(int ID)
        {
            var albumTracks = await _context.AlbumTracks.Where(i => i.TrackID == ID).ToListAsync();
            if (albumTracks != null)
                _context.AlbumTracks.RemoveRange(albumTracks);

            var trackPlaylist = await _context.PlaylistTracks.Where(i => i.TrackID == ID).FirstOrDefaultAsync();
            if (trackPlaylist != null)
                _context.PlaylistTracks.RemoveRange(trackPlaylist);

            await _context.SaveChangesAsync();

            var track = await _context.Tracks.FindAsync(ID);
            _context.Tracks.Remove(track);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}

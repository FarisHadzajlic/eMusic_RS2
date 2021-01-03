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
    public class PlaylistService : CRUDService<MPlaylist, PlaylistSearchRequest, Playlist, PlaylistUpsertRequest, PlaylistUpsertRequest>, IPlaylistService
    {
        private readonly eMusicContext _context;
        private readonly IMapper _mapper;
        public PlaylistService(eMusicContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public override async Task<MPlaylist> GetById(int id)
        {
            var entity = await _context.Playlists
                .Include(i => i.PlaylistTracks)
                .Include(i => i.User)
                .Where(i => i.PlaylistID == id)
                .SingleOrDefaultAsync();

            return _mapper.Map<MPlaylist>(entity);
        }
        public override async Task<List<MPlaylist>> Get(PlaylistSearchRequest request)
        {
            var query = _context.Playlists.Include(i => i.User).Include(i => i.PlaylistTracks).AsQueryable();

            if (request.UserID != 0)
            {
                query = query.Where(i => i.UserID == request.UserID);
            }

            if (!string.IsNullOrWhiteSpace(request?.Name))
            {
                query = query.Where(x => x.Name.StartsWith(request.Name));
            }

            var list = await query.ToListAsync();

            return _mapper.Map<List<MPlaylist>>(list);
        }
        public override async Task<MPlaylist> Insert(PlaylistUpsertRequest request)
        {
            var entity = _mapper.Map<Playlist>(request);

            await _context.Playlists.AddAsync(entity);
            await _context.SaveChangesAsync();

            foreach (var trackID in request.Tracks)
            {
                var playlistTrack = new PlaylistTrack()
                {
                    PlaylistID = entity.PlaylistID,
                    TrackID = trackID
                };
                await _context.PlaylistTracks.AddAsync(playlistTrack);
            }
            await _context.SaveChangesAsync();

            return _mapper.Map<MPlaylist>(entity);
        }
        public override async Task<MPlaylist> Update(int ID, PlaylistUpsertRequest request)
        {
            var entity = _context.Playlists.Find(ID);
            _context.Playlists.Attach(entity);
            _context.Playlists.Update(entity);

            foreach (var TrackID in request.Tracks)
            {
                var playlistTrack = await _context.PlaylistTracks
                    .Where(i => i.TrackID == TrackID && i.PlaylistID == ID)
                    .SingleOrDefaultAsync();

                if (playlistTrack == null)
                {
                    var newPlaylistTrack = new PlaylistTrack()
                    {
                        PlaylistID = ID,
                        TrackID = TrackID
                    };
                    await _context.Set<PlaylistTrack>().AddAsync(newPlaylistTrack);
                }
            }

            foreach (var TrackID in request.TracksToDelete)
            {
                var playlistTrack = await _context.PlaylistTracks
                    .Where(i => i.TrackID == TrackID && i.PlaylistID == ID)
                    .SingleOrDefaultAsync();

                if (playlistTrack != null)
                {
                    _context.Set<PlaylistTrack>().Remove(playlistTrack);
                }
            }

            _mapper.Map(request, entity);
            await _context.SaveChangesAsync();

            return _mapper.Map<MPlaylist>(entity);
        }
        public async Task<List<MTrack>> GetTracks(int ID, TrackSearchRequest request)
        {
            var query = _context.PlaylistTracks
                .Include(i => i.Track)
                .ThenInclude(i => i.Artist)
                .Where(i => i.PlaylistID == ID)
                .Select(i => i.Track)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(request?.Name))
            {
                query = query.Where(x => x.Name.StartsWith(request.Name));
            }

            var list = await query.ToListAsync();

            return _mapper.Map<List<MTrack>>(list);
        }
        public override async Task<bool> Delete(int ID)
        {
            var playlist = await _context.Playlists.Where(i => i.PlaylistID == ID).Include(i => i.PlaylistTracks).FirstOrDefaultAsync();
            _context.PlaylistTracks.RemoveRange(playlist.PlaylistTracks);
            await _context.SaveChangesAsync();
            _context.Playlists.Remove(playlist);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}

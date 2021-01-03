using eMusic.Model;
using eMusic.Model.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eMusic.Interface
{
    public interface IPlaylistService : ICRUDService<MPlaylist, PlaylistSearchRequest, PlaylistUpsertRequest, PlaylistUpsertRequest>
    {
        Task<List<MTrack>> GetTracks(int ID, TrackSearchRequest request);
    }
}

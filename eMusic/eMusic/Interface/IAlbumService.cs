using eMusic.Model;
using eMusic.Model.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eMusic.Interface
{
    public interface IAlbumService : ICRUDService<MAlbum, AlbumSearchRequest, AlbumUpsertRequest, AlbumUpsertRequest>
    {
        Task<List<MTrack>> GetTracks(int ID, TrackSearchRequest request);
    }
}

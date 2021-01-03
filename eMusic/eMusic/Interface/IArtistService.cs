using eMusic.Model;
using eMusic.Model.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eMusic.Interface
{
    public interface IArtistService : ICRUDService<MArtist, ArtistSearchRequest, ArtistUpsertRequest, ArtistUpsertRequest>
    {
        Task<List<MAlbum>> GetAlbums(int ID, AlbumSearchRequest request);
    }
}

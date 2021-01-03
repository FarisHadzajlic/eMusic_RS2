using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eMusic.Interface;
using eMusic.Model;
using eMusic.Model.Request;
using Microsoft.AspNetCore.Mvc;

namespace eMusic.Controllers
{
    public class ArtistController : CRUDController<MArtist, ArtistSearchRequest, ArtistUpsertRequest, ArtistUpsertRequest>
    {
        private readonly IArtistService _service;
        public ArtistController(IArtistService service) : base(service)
        {
            _service = service;
        }
        [HttpGet("{ID}/Albums")]
        public async Task<List<MAlbum>> GetAlbums(int id, [FromQuery] AlbumSearchRequest request)
        {
            return await _service.GetAlbums(id, request);
        }
    }
}

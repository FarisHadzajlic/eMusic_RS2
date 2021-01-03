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
    public class AlbumController : CRUDController<MAlbum, AlbumSearchRequest, AlbumUpsertRequest, AlbumUpsertRequest>
    {
        private readonly IAlbumService _service;
        public AlbumController(IAlbumService service) : base(service)
        {
            _service = service;
        }
        [HttpGet("{ID}/Tracks")]
        public async Task<List<MTrack>> GetTracks(int ID, [FromQuery] TrackSearchRequest request)
        {
            return await _service.GetTracks(ID, request);
        }
    }
}

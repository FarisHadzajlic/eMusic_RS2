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
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : CRUDController<MUser, UserSearchRequest, UserUpsertRequest, UserUpsertRequest>
    {
        private readonly IUserService _service;
        public UserController(IUserService service) : base(service)
        {
            _service = service;
        }
        [HttpPost("Authenticate")]
        public async Task<MUser> Authenticate(UserAuthenticationRequest request)
        {
            return await _service.Authenticate(request);
        }
        [HttpPost("Register")]
        public async Task<MUser> Register(UserUpsertRequest request)
        {
            return await _service.Insert(request);
        }
        [HttpGet("{ID}/LikedTracks")]
        public async Task<List<MTrack>> GetLikedTracks(int ID, [FromQuery] TrackSearchRequest request)
        {
            return await _service.GetLikedTracks(ID, request);
        }
        [HttpPost("{ID}/LikedTrack/{trackID}")]
        public async Task<MTrack> InsertLikedTrack(int ID, int trackId)
        {
            return await _service.InsertLikedTrack(ID, trackId);
        }
        [HttpDelete("{ID}/LikedTrack/{trackID}")]
        public async Task<MTrack> DeleteLikedTrack(int ID, int trackId)
        {
            return await _service.DeleteLikedTrack(ID, trackId);
        }
        [HttpGet("{ID}/LikedArtists")]
        public async Task<List<MArtist>> GetLikedArtists(int ID, [FromQuery] ArtistSearchRequest request)
        {
            return await _service.GetLikedArtists(ID, request);
        }
        [HttpPost("{ID}/LikedArtist/{artistId}")]
        public async Task<MArtist> InsertLikedArtist(int ID, int artistId)
        {
            return await _service.InsertLikedArtist(ID, artistId);
        }
        [HttpDelete("{ID}/LikedArtist/{artistId}")]
        public async Task<MArtist> DeleteFavouriteArtist(int ID, int artistId)
        {
            return await _service.DeleteLikedArtist(ID, artistId);
        }
        [HttpGet("{ID}/UserAlbum")]
        public async Task<List<MBuyAlbum>> GetUserAlbum(int ID)
        {
            return await _service.GetUserAlbum(ID);
        }
    }
}

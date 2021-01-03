using eMusic.Model;
using eMusic.Model.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eMusic.Interface
{
    public interface IUserService : ICRUDService<MUser, UserSearchRequest, UserUpsertRequest, UserUpsertRequest>
    {
        Task<MUser> Authenticate(UserAuthenticationRequest request);
        Task<MUser> Register(UserUpsertRequest request);
        Task<List<MTrack>> GetLikedTracks(int ID, TrackSearchRequest request);
        Task<MTrack> InsertLikedTrack(int ID, int TrackID);
        Task<MTrack> DeleteLikedTrack(int ID, int TrackID);
        Task<List<MArtist>> GetLikedArtists(int ID, ArtistSearchRequest request);
        Task<MArtist> InsertLikedArtist(int ID, int ArtistID);
        Task<MArtist> DeleteLikedArtist(int ID, int ArtistID);
        Task<List<MBuyAlbum>> GetUserAlbum(int ID);
    }
}

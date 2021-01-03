using AutoMapper;
using eMusic.Database;
using eMusic.Model;
using eMusic.Model.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eMusic.Mapper
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<User, MUser>();
            CreateMap<User, UserUpsertRequest>().ReverseMap();

            CreateMap<Role, MRole>();
            CreateMap<UserRole, MUserRole>();

            CreateMap<Genre, MGenre>();
            CreateMap<Genre, GenreUpsertRequest>().ReverseMap();

            CreateMap<Artist, MArtist>();
            CreateMap<Artist, ArtistUpsertRequest>().ReverseMap();

            CreateMap<Track, MTrack>();
            CreateMap<Track, TrackUpsertRequest>().ReverseMap();

            CreateMap<Album, MAlbum>();
            CreateMap<AlbumTrack, MAlbumTrack>();
            CreateMap<Album, AlbumUpsertRequest>().ReverseMap();

            CreateMap<Playlist, MPlaylist>();
            CreateMap<PlaylistTrack, MPlaylistTrack>();
            CreateMap<Playlist, PlaylistUpsertRequest>().ReverseMap();

            CreateMap<BuyAlbum, Album>().ReverseMap();
            CreateMap<BuyAlbum, MBuyAlbum>().ReverseMap();
            CreateMap<BuyAlbum, BuyAlbumRequest>().ReverseMap();

            CreateMap<UserLikedTrack, MTrack>().ReverseMap();
            CreateMap<UserLikedArtist, MArtist>().ReverseMap();

            CreateMap<UserTrackReview, MTrackReview>().ReverseMap();
            CreateMap<UserTrackReview, ReviewUpsertRequest>().ReverseMap();

            CreateMap<Comment, MComment>().ReverseMap();
            CreateMap<Comment, CommentUpsertRequest>().ReverseMap();
        }
    }
}

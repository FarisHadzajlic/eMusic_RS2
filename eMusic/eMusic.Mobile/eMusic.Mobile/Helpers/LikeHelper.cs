using eMusic.Mobile.Helper;
using eMusic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMusic.Mobile.Helpers
{
    public class LikeHelper
    {
        private readonly APIService userService = new APIService("User");
        public static List<MTrack> LikedTracks { get; set; }
        public static List<MArtist> LikedArtists { get; set; }

        public LikeHelper()
        {
            Init();
        }
        private async Task Init()
        {
            LikedTracks = await userService.GetLikedTracks(SignedInUser.User.UserID, null);
            LikedArtists = await userService.GetLikedArtists(SignedInUser.User.UserID, null);
        }
        public static bool Remove(MTrack item)
        {
            var itemToRemove = LikedTracks.Where(i => i.TrackID == item.TrackID).FirstOrDefault();
            return LikedTracks.Remove(itemToRemove);
        }
        public static bool Remove(MArtist item)
        {
            var itemToRemove = LikedArtists.Where(i => i.ArtistID == item.ArtistID).FirstOrDefault();
            return LikedArtists.Remove(itemToRemove);
        }
    }
}

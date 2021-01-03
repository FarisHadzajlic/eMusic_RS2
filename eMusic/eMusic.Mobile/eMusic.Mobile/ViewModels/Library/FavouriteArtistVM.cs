using eMusic.Mobile.Helper;
using eMusic.Mobile.ViewModels.SearchMusic;
using eMusic.Model.Request;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace eMusic.Mobile.ViewModels.Library
{
    public class FavouriteArtistVM : BaseVM
    {
        private readonly APIService artistService = new APIService("Artist");
        public ObservableCollection<ArtistVM> artistList { get; set; } = new ObservableCollection<ArtistVM>();
        public async Task Init(ArtistSearchRequest request = null)
        {
            try
            {
                var userId = SignedInUser.User.UserID;
                artistList.Clear();
                var artists = await artistService.GetLikedArtists(userId, request);
                foreach (var artist in artists)
                {
                    artistList.Add(new ArtistVM(artist));
                }
            }
            catch
            {

            }
        }
    }
}

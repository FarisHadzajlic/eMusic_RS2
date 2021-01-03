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
    public class FavouriteTrackVM : BaseVM
    {
        private readonly APIService trackService = new APIService("Track");
        public ObservableCollection<TrackVM> tracksList { get; set; } = new ObservableCollection<TrackVM>();
        public async Task Init(TrackSearchRequest request = null)
        {
            try
            {
                var userId = SignedInUser.User.UserID;
                tracksList.Clear();
                var tracks = await trackService.GetLikedTracks(userId, request);
                foreach (var track in tracks)
                {
                    tracksList.Add(new TrackVM(track));
                }
            }
            catch(Exception)
            {

            }
        }
    }
}

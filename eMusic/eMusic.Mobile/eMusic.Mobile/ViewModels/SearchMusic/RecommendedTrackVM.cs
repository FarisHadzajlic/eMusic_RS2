using eMusic.Mobile.Helper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace eMusic.Mobile.ViewModels.SearchMusic
{
    public class RecommendedTrackVM : BaseVM
    {
        private readonly APIService recommendService = new APIService("Recommendation");
        public ObservableCollection<TrackVM> recommendedTracksList { get; set; } = new ObservableCollection<TrackVM>();
        public async Task Init()
        {
            try
            {
                int userId = SignedInUser.User.UserID;
                recommendedTracksList.Clear();
                var recommendTracks = await recommendService.GetRecommandedTracks(userId);
                foreach (var track in recommendTracks)
                {
                    recommendedTracksList.Add(new TrackVM(track));
                }
            }
            catch
            {

            }
        }
    }
}

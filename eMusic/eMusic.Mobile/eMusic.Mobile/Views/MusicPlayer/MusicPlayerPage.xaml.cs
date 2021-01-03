using eMusic.Mobile.Helper;
using eMusic.Mobile.ViewModels.MusicPlayer;
using eMusic.Model;
using eMusic.Model.Request;
using MediaManager;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eMusic.Mobile.Views.MusicPlayer
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MusicPlayerPage : ContentPage
    {
        private readonly APIService reviewService = new APIService("Review");
        private MusicPlayerVM model = null;       
        public MusicPlayerPage(MTrack track, IEnumerable<MTrack> tracks, Image coverImage)
        {
            InitializeComponent();            
            ObservableCollection<MTrack> queue = null;
            if (tracks != null)
            {
                queue = new ObservableCollection<MTrack>(tracks);
            }
            BindingContext = model = new MusicPlayerVM(track, queue, coverImage);
        }
        private void Myslider_DragCompleted(object sender, EventArgs e)
        {
            var slider = sender as Slider;
            CrossMediaManager.Current.SeekTo(TimeSpan.FromSeconds(slider.Value));
        }
        private async void Track_RatingChanged(object sender, Syncfusion.SfRating.XForms.ValueEventArgs e)
        {
            int Rate = Convert.ToInt32(e.Value);
            var request = new ReviewUpsertRequest()
            {
                UserID = SignedInUser.User.UserID,
                TrackID = model.SelectedTrack.TrackID,
                Rating = Rate
            };

            if (model.TrackReview == null)
            {
                model.TrackReview = await reviewService.Insert<MTrackReview>(request);
            }
            else if (model.TrackReview != null && model.Rating == 0)
            {
                await reviewService.Delete<MTrackReview>(model.TrackReview.UserTrackReviewID);
            }
            else
            {
                await reviewService.Update<MTrackReview>(model.TrackReview.UserTrackReviewID, request);
            }
        }
        protected override async void OnDisappearing()
        {
            FileHelper.DeleteFile(model.filename);
            await CrossMediaManager.Current.Pause();
        }
    }
}
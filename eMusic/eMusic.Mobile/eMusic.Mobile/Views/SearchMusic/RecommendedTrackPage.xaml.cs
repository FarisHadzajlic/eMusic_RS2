using eMusic.Mobile.Helper;
using eMusic.Mobile.ViewModels.SearchMusic;
using eMusic.Mobile.Views.MusicPlayer;
using eMusic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eMusic.Mobile.Views.SearchMusic
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RecommendedTrackPage : ContentPage
    {
        private readonly APIService recommendService = new APIService("Recommendation");
        private RecommendedTrackVM model = null;
        public RecommendedTrackPage()
        {
            InitializeComponent();
            BindingContext = model = new RecommendedTrackVM();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
            int userId = SignedInUser.User.UserID;
            var recommendTracks = await recommendService.GetRecommandedTracks(userId);
            if (recommendTracks.Count < 1)
            {
                noReviews.IsVisible = true;
                Review.IsVisible = false;
                Textt.IsVisible = false;
                Textt2.IsVisible = false;
            }         
            else
            {
                noReviews.IsVisible = false;
                Textt.IsVisible = true;
                Review.IsVisible = true;
                Textt2.IsVisible = true;
            }
        }
        private async void Track_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var trackVM = e.SelectedItem as TrackVM;
            await Navigation.PushAsync(new MusicPlayerPage(trackVM.Track, null, null));
        }
    }
}
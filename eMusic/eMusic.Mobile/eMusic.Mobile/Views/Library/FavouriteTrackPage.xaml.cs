using eMusic.Mobile.Helper;
using eMusic.Mobile.ViewModels.Library;
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

namespace eMusic.Mobile.Views.Library
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FavouriteTrackPage : ContentPage
    {
        private readonly APIService userService = new APIService("User");
        private FavouriteTrackVM model = null;
        public FavouriteTrackPage()
        {
            InitializeComponent();
            BindingContext = model = new FavouriteTrackVM();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
            var userId = SignedInUser.User.UserID;
            var tracks = await userService.GetLikedTracks(userId, null);
            if(tracks.Count > 0)
            {
                Track.IsVisible = false;
                TrackList.IsVisible = true;
            }
            else
            {
                Track.IsVisible = true;
                TrackList.IsVisible = false;
            }            
        }
        private async void Track_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var trackVM = (e.SelectedItem as TrackVM);
            await Navigation.PushAsync(new MusicPlayerPage(trackVM.Track, null, null));
        }
    }
}
using eMusic.Mobile.Helper;
using eMusic.Mobile.ViewModels.Library;
using eMusic.Mobile.ViewModels.SearchMusic;
using eMusic.Mobile.Views.SearchMusic;
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
    public partial class FavouriteArtistPage : ContentPage
    {
        private readonly APIService userService = new APIService("User");
        private FavouriteArtistVM model = null;
        public FavouriteArtistPage()
        {
            InitializeComponent();
            BindingContext = model = new FavouriteArtistVM();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
            var userId = SignedInUser.User.UserID;
            var artists = await userService.GetLikedArtists(userId, null);
            if (artists.Count > 0)
            {
                Artist.IsVisible = false;
                ArtistList.IsVisible = true;
            }
            else
            {
                Artist.IsVisible = true;
                ArtistList.IsVisible = false;
            }
        }
        private async void Artist_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var artistVM = (e.SelectedItem as ArtistVM);
            await Navigation.PushAsync(new ArtistDetailPage(artistVM.Artist));
        }
    }
}
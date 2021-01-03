using eMusic.Mobile.Helper;
using eMusic.Mobile.ViewModels.Library;
using eMusic.Model;
using eMusic.Model.Request;
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
    public partial class PlaylistPage : ContentPage
    {
        private PlaylistVM model = null;
        private readonly APIService playlistService = new APIService("Playlist");
        private readonly APIService userServce = new APIService("User");
        public PlaylistPage()
        {
            InitializeComponent();
            BindingContext = model = new PlaylistVM();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
        }
        async void OnTapped(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new CreatePlaylistPage());
        }
        private async void Playlist_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedPlaylist = (e.SelectedItem as MPlaylist);
            await Navigation.PushAsync(new PlaylistDetailPage(selectedPlaylist));

            var request = new PlaylistSearchRequest()
            {
                UserID = SignedInUser.User.UserID
            };
            await userServce.Get<List<MPlaylist>>(request);
        }     
    }
}
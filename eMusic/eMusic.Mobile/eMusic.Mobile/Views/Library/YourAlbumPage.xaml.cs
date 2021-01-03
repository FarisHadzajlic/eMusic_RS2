using eMusic.Mobile.Helper;
using eMusic.Mobile.ViewModels.Library;
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
    public partial class YourAlbumsPage : ContentPage
    {
        private readonly APIService userService = new APIService("User");
        private YourAlbumVM model = null;
        public YourAlbumsPage()
        {
            InitializeComponent();
            BindingContext = model = new YourAlbumVM();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
            var userId = SignedInUser.User.UserID;
            var albums = await userService.GetUserAlbum(userId);
            if (albums.Count > 0)
            {
                YourAlbums.IsVisible = false;
                AlbumList.IsVisible = true;
            }
            else
            {
                YourAlbums.IsVisible = true;
                AlbumList.IsVisible = false;
            }
        }
        private async void Album_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var album = (e.SelectedItem as MBuyAlbum);
            await Navigation.PushAsync(new YourAlbumDetailPage(album.Album));
        }
    }
}
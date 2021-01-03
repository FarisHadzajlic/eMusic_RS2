using eMusic.Mobile.ViewModels.Album;
using eMusic.Mobile.ViewModels.SearchMusic;
using eMusic.Mobile.Views.Album;
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
    public partial class ArtistDetailPage : ContentPage
    {
        private ArtistDetailVM model = null;
        public ArtistDetailPage(MArtist artist)
        {
            InitializeComponent();
            BindingContext = model = new ArtistDetailVM(artist);
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
        }
        private async void Album_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var album = e.SelectedItem as AlbumVM;
            await Navigation.PushAsync(new ArtistAlbumPage(album.Album));
        }
    }
}
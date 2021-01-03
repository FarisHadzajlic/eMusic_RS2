using eMusic.Mobile.ViewModels.Album;
using eMusic.Mobile.ViewModels.SearchMusic;
using eMusic.Mobile.Views.MusicPlayer;
using eMusic.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eMusic.Mobile.Views.SearchMusic
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ArtistAlbumPage : ContentPage
    {
        private readonly APIService _service = new APIService("Album");
        private AlbumDetailVM model = null;
        public ArtistAlbumPage(MAlbum album)
        {
            InitializeComponent();
            BindingContext = model = new AlbumDetailVM(album);
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.InitTrack();
        }
        private async void Track_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var track = e.SelectedItem as MTrack;
            var queue = await _service.GetTracks<List<MTrack>>(model.Album.AlbumID, null);
            Image coverImage = new Image()
            {
                Source = ImageSource.FromStream(() => new MemoryStream(model.Album.Image))
            };

            await Navigation.PushAsync(new MusicPlayerPage(track, queue, coverImage));
        }
    }
}
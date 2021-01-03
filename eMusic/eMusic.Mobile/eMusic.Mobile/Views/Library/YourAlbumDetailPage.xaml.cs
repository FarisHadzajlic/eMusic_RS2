using eMusic.Mobile.ViewModels.Library;
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

namespace eMusic.Mobile.Views.Library
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class YourAlbumDetailPage : ContentPage
    {
        private readonly APIService albumService = new APIService("Album");
        private YourAlbumDetailVM model = null;
        public YourAlbumDetailPage(MAlbum album)
        {
            InitializeComponent();
            BindingContext = model = new YourAlbumDetailVM(album);
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
        }
        private async void Track_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var trackVM = (e.SelectedItem as TrackVM);
            var queue = await albumService.GetTracks<List<MTrack>>(model.Album.AlbumID, null);
            Image coverImage = new Image()
            {
                Source = ImageSource.FromStream(() => new MemoryStream(model.Album.Image))
            };

            await Navigation.PushAsync(new MusicPlayerPage(trackVM.Track, queue, coverImage));
        }
    }
}
using eMusic.Mobile.Helper;
using eMusic.Mobile.ViewModels.Library;
using eMusic.Mobile.ViewModels.SearchMusic;
using eMusic.Mobile.Views.MusicPlayer;
using eMusic.Model;
using eMusic.Model.Request;
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
    public partial class PlaylistDetailPage : ContentPage
    {
        private readonly APIService playlistService = new APIService("Playlist");
        private PlaylistDetailVM model = null;
        public PlaylistDetailPage(MPlaylist playlist)
        {
            InitializeComponent();
            BindingContext = model = new PlaylistDetailVM(playlist);
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
            var playlist = await playlistService.GetTracks<List<MTrack>>(model.Playlist.PlaylistID, null);
            if (playlist.Count > 0)
            {
                Playlist.IsVisible = true;
                Songs.IsVisible = false;
            }
            else
            {
                Playlist.IsVisible = false;
                Songs.IsVisible = true;
            }
        }
        private async void Track_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var trackVM = (e.SelectedItem as TrackVM);
            var queue = await playlistService.GetTracks<List<MTrack>>(model.Playlist.PlaylistID, null);
            Image coverImage = new Image()
            {
                Source = ImageSource.FromStream(() => new MemoryStream(model.Playlist.Image))
            };
            await Navigation.PushAsync(new MusicPlayerPage(trackVM.Track, queue, coverImage));
        }
        private async void RemoveTrack_Clicked(object sender, EventArgs e)
        {
            var button = sender as ImageButton;
            var trackVM = button.BindingContext as TrackVM;

            var request = new PlaylistUpsertRequest()
            {
                Name = model.Playlist.Name,
                Image = model.Playlist.Image,
                UserID = model.Playlist.UserID,
                CreatedAt = model.Playlist.CreatedAt,
                TracksToDelete = new List<int>() { trackVM.Track.TrackID }
            };

            await playlistService.Update<MPlaylist>(model.Playlist.PlaylistID, request);
            model.tracksList.Remove(trackVM);
        }
    }
}
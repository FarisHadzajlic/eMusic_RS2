using eMusic.Mobile.ViewModels.SearchMusic;
using eMusic.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace eMusic.Mobile.ViewModels.Library
{
    public class PlaylistDetailVM : BaseVM
    {
        private readonly APIService playlistService = new APIService("Playlist");
        public ObservableCollection<TrackVM> tracksList { get; set; } = new ObservableCollection<TrackVM>();

        private MPlaylist playlist;
        public MPlaylist Playlist
        {
            get { return playlist; }
            set { SetProperty(ref playlist, value); }
        }

        private byte[] image;
        public byte[] Image
        {
            get { return image; }
            set { SetProperty(ref image, value); }
        }
        public PlaylistDetailVM()
        {

        }
        public PlaylistDetailVM(MPlaylist playlist)
        {
            Playlist = playlist;
            Image = playlist.Image;
        }
        public async Task Init()
        {
            tracksList.Clear();
            try
            {
                var tracks = await playlistService.GetTracks<List<MTrack>>(Playlist.PlaylistID, null);
                foreach (var track in tracks)
                {
                    tracksList.Add(new TrackVM(track));
                }
            }
            catch(Exception)
            {

            }
        }
    }
}

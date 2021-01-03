using eMusic.Mobile.Helper;
using eMusic.Model;
using eMusic.Model.Request;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace eMusic.Mobile.ViewModels.Library
{
    public class PlaylistVM : BaseVM
    {
        private readonly APIService playlistService = new APIService("Playlist");
        public ObservableCollection<MPlaylist> playlistsList { get; set; } = new ObservableCollection<MPlaylist>();

        private MPlaylist playlist;
        public MPlaylist Playlist
        {
            get { return playlist; }
            set { SetProperty(ref playlist, value); }
        }
        public async Task Init(PlaylistSearchRequest request = null)
        {
            playlistsList.Clear();
            try
            {
                if (request == null)
                {
                    request = new PlaylistSearchRequest()
                    {
                        UserID = SignedInUser.User.UserID
                    };
                }
                var playlists = await playlistService.Get<List<MPlaylist>>(request);
                foreach (var playlist in playlists)
                {
                    playlistsList.Add(playlist);
                }
            }
            catch(Exception)
            {

            }
        }
    }
}

using Acr.UserDialogs;
using eMusic.Mobile.Helper;
using eMusic.Mobile.Helpers;
using eMusic.Model;
using eMusic.Model.Request;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace eMusic.Mobile.ViewModels.SearchMusic
{
    public class TrackVM : BaseVM
    {
        private readonly APIService userService = new APIService("User");
        private readonly APIService playlistService = new APIService("Playlist");
        public ICommand LikeCommand { get; set; }
        public ICommand PlaylistsCommand { get; set; }

        private bool _isLiked;
        public bool IsLiked
        {
            get { return _isLiked; }
            set
            {
                _isLiked = value;
                OnPropertyChanged(nameof(IsLikedImage));
            }
        }
        public string IsLikedImage
        {
            get => IsLiked ? "heart.png" : "heart-empty.png";
        }

        private MTrack _track;
        public MTrack Track
        {
            get { return _track; }
            set { SetProperty(ref _track, value); }
        }
        public ImageSource AddImage
        {
            get => "add.png";
        }  
        public TrackVM()
        {

        }
        public TrackVM(MTrack track)
        {
            Track = track;
            if(LikeHelper.LikedTracks != null)
               IsLiked = LikeHelper.LikedTracks.Find(i => i.TrackID == Track.TrackID) != null;
            PlaylistsCommand = new Command(async () => await ShowPlaylists());
            LikeCommand = new Command(async () => await ToggleLike());
        }
        private async Task ShowPlaylists()
        {
            var request = new PlaylistSearchRequest()
            {
                UserID = SignedInUser.User.UserID
            };
            var playlists = await playlistService.Get<List<MPlaylist>>(request);

            var cfg = new ActionSheetConfig()
               .SetTitle("Add to Playlist")
               .SetCancel();

            foreach (var playlist in playlists)
            {
                cfg.Add(
                    playlist.Name,
                    async () => await AddToPlaylist(playlist.PlaylistID, Track.TrackID));
            }

            UserDialogs.Instance.ActionSheet(cfg);
        }

        private async Task AddToPlaylist(int PlaylistID, int TrackID)
        {
            try
            {
                var playlist = await playlistService.GetById<MPlaylist>(PlaylistID);
                var request = new PlaylistUpsertRequest()
                {
                    Name = playlist.Name,
                    Image = playlist.Image,
                    CreatedAt = playlist.CreatedAt,
                    UserID = playlist.UserID,
                    Tracks = new List<int>() { TrackID }
                };

                await playlistService.Update<MPlaylist>(PlaylistID, request);
            }
            catch
            {

            }
        }
        private async Task ToggleLike()
        {
            try
            {
                if (IsLiked)
                {
                    await userService.DeleteLikedTrack(SignedInUser.User.UserID, Track.TrackID);
                    IsLiked = false;
                    LikeHelper.Remove(Track);
                }
                else
                {
                    await userService.InsertLikedTrack(SignedInUser.User.UserID, Track.TrackID);
                    IsLiked = true;
                    LikeHelper.LikedTracks.Add(Track);
                }
            }
            catch
            {

            }
        }
    }
}

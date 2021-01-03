using eMusic.Mobile.Helper;
using eMusic.Mobile.Helpers;
using eMusic.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace eMusic.Mobile.ViewModels.SearchMusic
{
    public class ArtistVM : BaseVM
    {
        private readonly APIService userService = new APIService("User");
        public ICommand LikeCommand { get; set; }
        private MArtist _artist;
        public MArtist Artist
        {
            get { return _artist; }
            set { SetProperty(ref _artist, value); }
        }
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
        public ArtistVM(MArtist artist)
        {
            Artist = artist;
            if(LikeHelper.LikedArtists != null)
                IsLiked = LikeHelper.LikedArtists.Find(i => i.ArtistID == Artist.ArtistID) != null;
            LikeCommand = new Command(async () => await ToggleLike());
        }
        private async Task ToggleLike()
        {
            try
            {
                if (IsLiked)
                {
                    await userService.DeleteLikedArtist(SignedInUser.User.UserID, Artist.ArtistID);
                    IsLiked = false;
                    LikeHelper.Remove(Artist);
                }
                else
                {
                    await userService.InsertLikedArtist(SignedInUser.User.UserID, Artist.ArtistID);
                    IsLiked = true;
                    LikeHelper.LikedArtists.Add(Artist);
                }
            }
            catch(Exception)
            {

            }
        }
    }
}

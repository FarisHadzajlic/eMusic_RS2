using eMusic.Mobile.Helper;
using eMusic.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace eMusic.Mobile.ViewModels.Library
{
    public class YourAlbumVM : BaseVM
    {
        private readonly APIService albumService = new APIService("Album");
        public ObservableCollection<MBuyAlbum> albumsList { get; set; } = new ObservableCollection<MBuyAlbum>();
        private MAlbum _album;
        public MAlbum Album
        {
            get { return _album; }
            set { SetProperty(ref _album, value); }
        }              
        public async Task Init()
        {
            var UserId = SignedInUser.User.UserID;
            albumsList.Clear();
            var yourAlbums = await albumService.GetUserAlbum(UserId);
            foreach(var albums in yourAlbums)
            {
                albumsList.Add(albums);
            }
        }
    }
}

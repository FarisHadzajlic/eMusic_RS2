using eMusic.Mobile.Helper;
using eMusic.Mobile.Helpers;
using eMusic.Model;
using eMusic.Model.Request;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace eMusic.Mobile.ViewModels.Library
{
    public class CreatePlaylistVM : BaseVM
    {
        private readonly APIService playlistService = new APIService("Playlist");
        private string name;
        public string Name
        {
            get { return name; }
            set { SetProperty(ref name, value); }
        }

        byte[] image;
        public byte[] Image
        {
            get { return image; }
            set { SetProperty(ref image, value); }
        }
        public ICommand SaveCommand { get; set; }
        public ICommand ChangeImage { get; set; }
        public CreatePlaylistVM()
        {
            SaveCommand = new Command(async () => await SavePlaylist());
            ChangeImage = new Command(async () => await OnTapped());
        }

        private async Task OnTapped()
        {
            Image = await ImageHelper.UploadImage(Image);
        }

        private async Task SavePlaylist()
        {
            try
            {
                var playlist = new PlaylistUpsertRequest()
                {
                    UserID = SignedInUser.User.UserID,
                    Name = name,
                    Image = image,
                    CreatedAt = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss")
                };

                await playlistService.Insert<MPlaylist>(playlist);

                await Application.Current.MainPage.DisplayAlert("Success", "Playlist Created Successfully.", "OK");
            }
            catch
            {

            }
        }
    }
}

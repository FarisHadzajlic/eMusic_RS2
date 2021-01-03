using eMusic.Mobile.ViewModels.Album;
using eMusic.Model;
using eMusic.Model.Request;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace eMusic.Mobile.ViewModels.SearchMusic
{
    public class ArtistDetailVM : BaseVM
    {
        private readonly APIService artistService = new APIService("Artist");
        public ObservableCollection<AlbumVM> albumsList { get; set; } = new ObservableCollection<AlbumVM>();
        public ArtistDetailVM()
        {
            
        }
        public ArtistDetailVM(MArtist artist)
        {
            Artist = artist;
        }

        private MArtist artist;
        public MArtist Artist
        {
            get { return artist; }
            set { SetProperty(ref artist, value); }
        }
        public async Task Init()
        {
            albumsList.Clear();
            try
            {
                var albums = await artistService.GetAlbums<List<MAlbum>>(Artist.ArtistID, null);
                foreach (var album in albums)
                {
                    if (album.Price == 0)
                        albumsList.Add(new AlbumVM(album));
                }
            }
            catch
            {

            }
        }
    }
}

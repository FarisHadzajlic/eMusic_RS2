using eMusic.Mobile.ViewModels.SearchMusic;
using eMusic.Model;
using eMusic.Model.Request;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace eMusic.Mobile.ViewModels.Library
{
    public class YourAlbumDetailVM : BaseVM
    {
        private readonly APIService albumService = new APIService("Album");
        public ObservableCollection<TrackVM> tracksList { get; set; } = new ObservableCollection<TrackVM>();

        private MAlbum album;
        public MAlbum Album
        {
            get { return album; }
            set { SetProperty(ref album, value); }
        }
        public YourAlbumDetailVM()
        {

        }
        public YourAlbumDetailVM(MAlbum album)
        {
            Album = album;
        }
        public async Task Init(TrackSearchRequest request = null)
        {
            tracksList.Clear();
            try
            {
                var tracks = await albumService.GetTracks<List<MTrack>>(Album.AlbumID, request);
                foreach (var track in tracks)
                {
                    tracksList.Add(new TrackVM(track));
                }
            }
            catch
            {

            }
        }
    }
}

using eMusic.Mobile.Helper;
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
    public class MusicTrackVM : BaseVM
    {
        private readonly APIService trackService = new APIService("Track");
        private readonly APIService genreService = new APIService("Genre");
        private readonly APIService albumService = new APIService("Album");
        public ObservableCollection<TrackVM> tracksList { get; set; } = new ObservableCollection<TrackVM>();
        public ObservableCollection<MGenre> genreList { get; set; } = new ObservableCollection<MGenre>();
        public ICommand InitCommand { get; set; }   
        public MusicTrackVM()
        {
            InitCommand = new Command(async () => await Init());
        }
        MGenre _selectedGenre = null;
        public MGenre SelectedGenre
        {
            get { return _selectedGenre; }
            set
            {
                SetProperty(ref _selectedGenre, value);
                if (value != null)
                    InitCommand.Execute(null);
            }
        }
        public async Task Init()
        {
            try
            {                
                if (genreList.Count == 0)
                {                          
                    var genres = await genreService.Get<List<MGenre>>(null);
                    foreach (var genre in genres)
                    {
                        genreList.Add(genre);
                    }
                }
                if (SelectedGenre != null)
                {
                    TrackSearchRequest search = new TrackSearchRequest
                    {
                        GenreID = SelectedGenre.GenreID
                    };
                    tracksList.Clear();
                    var tracks = await trackService.Get<List<MTrack>>(search);
                    var albums = await albumService.Get<List<MAlbum>>(search);
                    foreach(var album in albums)
                    {
                        if(album.Price == 0)
                        {
                            foreach(var track in album.AlbumTracks)
                            {
                                foreach(var x in tracks)
                                {
                                    if(x.TrackID == track.TrackID)
                                    {
                                        tracksList.Add(new TrackVM(x));
                                    }
                                }
                            }
                        }
                    }                 
                }
            }
            catch (Exception)
            {

            }
        }
    }
}

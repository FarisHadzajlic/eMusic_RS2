using eMusic.Mobile.Models;
using eMusic.Model;
using eMusic.Model.Request;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace eMusic.Mobile.ViewModels.Album
{
    public class AlbumVM : BaseVM
    {
        private readonly APIService albumService = new APIService("Album");
        private readonly APIService genreService = new APIService("Genre");
        public ObservableCollection<MAlbum> albumsList { get; set; } = new ObservableCollection<MAlbum>();
        public ObservableCollection<MGenre> genresList { get; set; } = new ObservableCollection<MGenre>();
       
        MGenre _selectedGenre = null;
        public MGenre SelectedGenre
        {
            get { return _selectedGenre; }
            set
            {
                SetProperty(ref _selectedGenre, value);
                if (value != null)
                {
                    InitCommand.Execute(null);
                }
            }
        }
        private MAlbum _album;
        public MAlbum Album
        {
            get { return _album; }
            set { SetProperty(ref _album, value); }
        }
        public ICommand InitCommand { get; set; }
        public AlbumVM()
        {
            InitCommand = new Command(async () => await Init());
        }
        public AlbumVM(MAlbum album)
        {
            Album = album;
        }
        public async Task Init()
        {
            try
            {
                if(genresList.Count == 0)
                {
                    var genres = await genreService.Get<List<MGenre>>(null);
                    foreach (var genre in genres)
                    {
                        genresList.Add(genre);
                    }
                }
                if(SelectedGenre != null)
                {
                    AlbumSearchRequest search = new AlbumSearchRequest
                    {
                        GenreID = SelectedGenre.GenreID
                    };
                    albumsList.Clear();
                    var albumsGenre = await albumService.Get<List<MAlbum>>(search);
                    foreach (var album in albumsGenre)
                    {
                        if(album.Price > 0)
                            albumsList.Add(album);
                    }
                }                
            }
            catch(Exception)
            {

            }
        }
    }
}

using eMusic.Mobile.Helper;
using eMusic.Mobile.Models;
using eMusic.Mobile.Views.Album;
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
    public class AlbumDetailVM : BaseVM
    {
        private readonly APIService albumService = new APIService("Album");
        private readonly APIService commentService = new APIService("Comment");
        public ObservableCollection<MTrack> tracksList { get; set; } = new ObservableCollection<MTrack>();
        public ObservableCollection<MComment> commentList { get; set; } = new ObservableCollection<MComment>();
        public AlbumDetailVM()
        {
            BuyCommand = new Command(async () => await Buy());
        }
        private MAlbum album;
        public MAlbum Album
        {
            get { return album; }
            set { SetProperty(ref album, value); }
        }
        string comment = null;
        public string Comment
        {
            get { return comment; }
            set
            {
                SetProperty(ref comment, value);
            }
        }
        public AlbumDetailVM(MAlbum album)
        {
            Album = album;
            InitCommand = new Command(async () => await InitTrack());
            DeleteCommand = new Command<MComment>(async (comment) => await Delete(comment));
            AddCommand = new Command(async () => await Add());
        }
        public AlbumDetailVM(INavigation nav)
        {
            this.Navigation = nav;
            InitCommand = new Command(async () => await InitTrack());
            BuyCommand = new Command(async () => await Buy());
            DeleteCommand = new Command<MComment>(async (comment) => await Delete(comment));
            AddCommand = new Command(async () => await Add());
        }
        private readonly INavigation Navigation;       
        public ICommand BuyCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand InitCommand { get; set; }
        public ICommand AddCommand { get; set; }
        public async Task Buy()
        {
            await Navigation.PushAsync(new PaymentPage(Album));
        }
        public async Task Add()
        {
            var request = new CommentUpsertRequest()
            {
                DateOfComment = DateTime.Now,
                AlbumID = Album.AlbumID,
                UserID = SignedInUser.User.UserID,
                CommentContent = Comment
            };

            await commentService.Insert<MComment>(request);

            commentList.Clear();
            Comment = null;
            await InitComment();
        }

        public async Task Delete(MComment c)
        {
            var ID = c.CommentID;
            if (c.UserID == SignedInUser.User.UserID)
            {
                await commentService.Remove(ID);
                await InitComment();
            }
        }
        public async Task InitComment()
        {
            commentList.Clear();
            try
            {
                var comments = await commentService.Get<List<MComment>>(null); 
                foreach (var comment in comments)
                {
                    commentList.Add(comment);
                }
            }
            catch
            {

            }
        }
        public async Task InitTrack()
        {
            tracksList.Clear();           
            try
            {
                var tracks = await albumService.GetTracks<List<MTrack>>(Album.AlbumID, null);
                foreach (var track in tracks)
                {
                    tracksList.Add(track);
                }               
            }
            catch
            {

            }
        }
    }
}

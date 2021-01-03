using eMusic.Mobile.Helper;
using eMusic.Mobile.Models;
using eMusic.Mobile.ViewModels.Album;
using eMusic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eMusic.Mobile.Views.Album
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AlbumDetailPage : ContentPage
    {
        private readonly APIService commentService = new APIService("Comment");

        private AlbumDetailVM model = null;
        public AlbumDetailPage(MAlbum album)
        {
            InitializeComponent();
            BindingContext = model = new AlbumDetailVM(this.Navigation)
            {
                Album = album
            };
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.InitTrack();
            await model.InitComment();           
            //var comments = await commentService.Get<List<MComment>>(null);
            //foreach(var comment in comments)
            //{
            //    if (SignedInUser.User.UserID != comment.UserID)
            //    {

            //    }                    
            //}            
        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var comment = button?.BindingContext as MComment;

            await model.Delete(comment);
        }
    }
}
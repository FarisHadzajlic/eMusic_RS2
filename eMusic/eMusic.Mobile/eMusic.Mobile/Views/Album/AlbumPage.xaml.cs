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
    public partial class AlbumPage : ContentPage
    {
        private AlbumVM model = null;
        public AlbumPage()
        {
            InitializeComponent();
            BindingContext = model = new AlbumVM();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
        }
        private async void Album_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var album = (e.SelectedItem as MAlbum);
            await Navigation.PushAsync(new AlbumDetailPage(album));
        }
    }
}
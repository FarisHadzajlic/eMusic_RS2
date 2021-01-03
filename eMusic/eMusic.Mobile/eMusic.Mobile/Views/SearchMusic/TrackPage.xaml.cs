using eMusic.Mobile.ViewModels.SearchMusic;
using eMusic.Mobile.Views.MusicPlayer;
using eMusic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eMusic.Mobile.Views.SearchMusic
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TrackPage : ContentPage
    {
        public APIService trackService = new APIService("Track");
        private MusicTrackVM model = null;
        public TrackPage()
        {
            InitializeComponent();
            BindingContext = model = new MusicTrackVM();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
        }
        private async void Track_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var track = e.SelectedItem as TrackVM;
            await Navigation.PushAsync(new MusicPlayerPage(track.Track, null, null));
        }
    }
}
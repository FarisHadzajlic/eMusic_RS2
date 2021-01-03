using eMusic.Mobile.ViewModels.SearchMusic;
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
    public partial class ArtistPage : ContentPage
    {
        private MusicArtistVM model = null;
        public ArtistPage()
        {
            InitializeComponent();
            BindingContext = model = new MusicArtistVM();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
        }
        private async void Artist_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var artistVM = (e.SelectedItem as ArtistVM);
            await Navigation.PushAsync(new ArtistDetailPage(artistVM.Artist));
        }
    }
}
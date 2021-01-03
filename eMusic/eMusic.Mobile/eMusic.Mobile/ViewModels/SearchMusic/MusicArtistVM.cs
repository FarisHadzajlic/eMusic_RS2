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
    public class MusicArtistVM : BaseVM
    {
        private readonly APIService artistService = new APIService("Artist");
        public ObservableCollection<ArtistVM> artistsList { get; set; } = new ObservableCollection<ArtistVM>();
        public ICommand SearchArtist { get; set; }
        public MusicArtistVM()
        {
            SearchArtist = new Command(async (object query) => await Search(query));
        }
        private async Task Search(object query)
        {
            var request = new ArtistSearchRequest()
            {
                Name = query as string
            };

            await Init(request);
        }
        public async Task Init(ArtistSearchRequest request = null)
        {
            artistsList.Clear();
            try
            {
                var artists = await artistService.Get<List<MArtist>>(request);
                foreach (var artist in artists)
                {
                    artistsList.Add(new ArtistVM(artist));
                }
            }
            catch(Exception)
            {

            }
        }
    }
}

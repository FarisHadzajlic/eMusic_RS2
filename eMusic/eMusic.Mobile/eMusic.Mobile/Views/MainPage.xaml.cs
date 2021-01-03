using eMusic.Mobile.Models;
using eMusic.Mobile.Views.Account;
using eMusic.Mobile.Views.Album;
using eMusic.Mobile.Views.Library;
using eMusic.Mobile.Views.SearchMusic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eMusic.Mobile.Views.Main
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : MasterDetailPage
    {
        Dictionary<int, NavigationPage> MenuPages = new Dictionary<int, NavigationPage>();
        public MainPage()
        {
            InitializeComponent();
            MasterBehavior = MasterBehavior.Popover;
        }
        public async Task NavigateFromMenu(int ID)
        {
            if (!MenuPages.ContainsKey(ID))
            {
                switch (ID)
                {
                    case (int)MenuType.BuyAlbum:
                        MenuPages.Add(ID, new NavigationPage(new AlbumPage()));
                        break;   
                    case (int)MenuType.SearchMusic:
                        MenuPages.Add(ID, new NavigationPage(new SearchMusicPage()));
                        break;                    
                    case (int)MenuType.YourLibrary:
                        MenuPages.Add(ID, new NavigationPage(new LibraryPage()));
                        break;
                    case (int)MenuType.Settings:
                        MenuPages.Add(ID, new NavigationPage(new EditUserInfoPage()));
                        break;
                    case (int)MenuType.Logout:
                        MenuPages.Add(ID, new NavigationPage(new LogoutPage()));
                        break;
                }
            }

            var newPage = MenuPages[ID];

            if (newPage != null && Detail != newPage)
            {
                Detail = newPage;

                if (Device.RuntimePlatform == Device.Android)
                    await Task.Delay(100);

                IsPresented = false;
            }
        }
    }
}
using eMusic.Mobile.Models;
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
    public partial class MenuPage : ContentPage
    {
        MainPage RootPage { get => Application.Current.MainPage as MainPage; }
        List<MeniItems> menuItems;
        public MenuPage()
        {
            InitializeComponent();
            menuItems = new List<MeniItems>
            {
                new MeniItems {ID = MenuType.YourLibrary, Title="Your Library" },
                new MeniItems {ID = MenuType.SearchMusic, Title="Search Music" },
                new MeniItems {ID = MenuType.BuyAlbum, Title="Buy Album" },     
                new MeniItems {ID = MenuType.Settings, Title="Settings" },
                new MeniItems {ID = MenuType.Logout, Title="Logout" }
            };
            ListViewMenu.ItemsSource = menuItems;

            ListViewMenu.SelectedItem = menuItems[0];
            ListViewMenu.ItemSelected += async (sender, e) =>
            {
                if (e.SelectedItem == null)
                    return;

                var ID = (int)((MeniItems)e.SelectedItem).ID;
                await RootPage.NavigateFromMenu(ID);
            };
        }
    }
}
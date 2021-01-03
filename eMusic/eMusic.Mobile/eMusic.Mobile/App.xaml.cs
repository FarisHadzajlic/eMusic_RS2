using eMusic.Mobile.Views.Account;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eMusic.Mobile
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MzU2NTQ5QDMxMzgyZTMzMmUzMGFqelpBUTUwV3NTUVgxQXhHWE9KWXk5N0kwMm5udFNqV085eS92T3piTEE9");
            MainPage = new LoginPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}

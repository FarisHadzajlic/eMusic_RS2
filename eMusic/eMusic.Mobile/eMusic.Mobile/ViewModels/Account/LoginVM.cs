using eMusic.Mobile.Helper;
using eMusic.Mobile.Helpers;
using eMusic.Mobile.Views.Account;
using eMusic.Mobile.Views.Main;
using eMusic.Model.Request;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace eMusic.Mobile.ViewModels.Account
{
    public class LoginVM : BaseVM
    {
        private readonly APIService userService = new APIService("User");

        string username;
        public string Username
        {
            get { return username; }
            set { SetProperty(ref username, value); }
        }

        string password;
        public string Password
        {
            get { return password; }
            set { SetProperty(ref password, value); }
        }
        public ICommand LoginCommand { get; set; }
        public ICommand RegisterCommand { get; set; }
        public LoginVM()
        {
            LoginCommand = new Command(async () => await Login());
            RegisterCommand = new Command(() => RegisterLoad());
        }
        void RegisterLoad()
        {
            Application.Current.MainPage = new RegisterPage();
        }
        async Task Login()
        {
            IsBusy = true;
            APIService.Username = Username;
            APIService.Password = Password;

            var request = new UserAuthenticationRequest()
            {
                Username = APIService.Username,
                Password = APIService.Password
            };

            var user = await userService.Authenticate(request);

            if (user != null)
            {
                Application.Current.MainPage = new MainPage();
                SignedInUser.User = user;
                new LikeHelper();
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Enter a Valid Username and Password!", "OK");
            }
        }
    }
}

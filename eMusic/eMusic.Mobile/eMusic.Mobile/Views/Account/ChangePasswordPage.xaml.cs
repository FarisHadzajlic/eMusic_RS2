using eMusic.Mobile.Helper;
using eMusic.Model;
using eMusic.Model.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eMusic.Mobile.Views.Account
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChangePasswordPage : ContentPage
    {
        private readonly APIService userService = new APIService("User");       
        public ChangePasswordPage()
        {
            InitializeComponent();
        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                var hasNumber = new Regex(@"[0-9]+");
                var hasUpperChar = new Regex(@"[A-Z]+");
                var hasMinimum8Chars = new Regex(@".{8,}");
                if (OldPassword.Text != APIService.Password)
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Wrong old password.", "Try again");
                    return;
                }

                if (ConfirmPassword.Text != NewPassword.Text)
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Passwords are not matched.", "Try again");
                    return;
                }

                if (NewPassword.Text.Length < 8)
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Password must have minimum 8 characthers.", "Try again");
                    return;
                }

                if (!hasNumber.IsMatch(NewPassword.Text) || !hasUpperChar.IsMatch(NewPassword.Text) || !hasMinimum8Chars.IsMatch(NewPassword.Text))
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Password must contain number, uppercase, lowercase and minimum 8 characters!", "Try again");
                    return;
                }


                if (!hasNumber.IsMatch(ConfirmPassword.Text) || !hasUpperChar.IsMatch(ConfirmPassword.Text) || !hasMinimum8Chars.IsMatch(ConfirmPassword.Text))
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Password must contain number, uppercase, lowercase and minimum 8 characters!", "Try again");
                    return;
                }

                await userService.Update<MUser>(SignedInUser.User.UserID, new UserUpsertRequest
                {
                    FirstName = SignedInUser.User.FirstName,
                    LastName = SignedInUser.User.LastName,
                    Email = SignedInUser.User.Email,
                    PhoneNumber = SignedInUser.User.PhoneNumber,
                    Username = SignedInUser.User.Username,
                    Password = NewPassword.Text,
                    PasswordConfirmation = ConfirmPassword.Text
                });

                await Application.Current.MainPage.DisplayAlert("Success", "Succesfully changed, please log in to confirm changes.", "OK");
                await Navigation.PushAsync(new LoginPage());
            }
            catch 
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Something went wrong.", "Try again");
            }
        }
    }
}
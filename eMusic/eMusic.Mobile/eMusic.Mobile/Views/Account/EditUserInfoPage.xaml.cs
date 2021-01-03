using eMusic.Mobile.Helper;
using eMusic.Mobile.Helpers;
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
    public partial class EditUserInfoPage : ContentPage
    {
        private readonly APIService userService = new APIService("User");
        string emailPattern = @"^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$";
        bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }
            return true;
        }
        public EditUserInfoPage()
        {
            InitializeComponent();
            FirstName.Text = SignedInUser.User.FirstName;
            LastName.Text = SignedInUser.User.LastName;
            Email.Text = SignedInUser.User.Email;
            Phone.Text = SignedInUser.User.PhoneNumber;
            Username.Text = SignedInUser.User.Username;
        }
        private async void Button_ChangePw(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ChangePasswordPage());
        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(FirstName.Text) || string.IsNullOrWhiteSpace(LastName.Text) ||
                   string.IsNullOrWhiteSpace(Email.Text) || string.IsNullOrWhiteSpace(Phone.Text)
                   || string.IsNullOrWhiteSpace(Username.Text))
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "All fields are required.", "Try again");
                    return;
                }

                if (Username.Text.Length < 3)
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Username must have minimum 3 characthers.", "Try again");
                    return;
                }
                bool isValid = Regex.IsMatch(Email.Text, emailPattern);
                if (!isValid)
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Please enter email in a valid format.", "Try again");
                    return;
                }

                var listUsers = await userService.Get<List<MUser>>(null);
                foreach (var item in listUsers)
                {
                    if (Username.Text == item.Username && APIService.Username != item.Username)
                    {
                        await Application.Current.MainPage.DisplayAlert("Error", "Username already exist.", "Try again");
                        return;
                    }
                }

                if (IsDigitsOnly(Phone.Text) == false)
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "You cant use letters as a phone number.", "Try again");
                    return;
                }

                var newUser = await userService.Update<MUser>(SignedInUser.User.UserID, new UserUpsertRequest
                {
                    Username = Username.Text,
                    FirstName = FirstName.Text,
                    LastName = LastName.Text,
                    Email = Email.Text,
                    PhoneNumber = Phone.Text,
                    Roles = new List<int> { 2 }
                });

                if (newUser == default(MUser))
                    return;

                await Application.Current.MainPage.DisplayAlert("Success", "Succesfully changed, please log in to confirm changes.", "OK");
                await Navigation.PushAsync(new LoginPage());
            }
            catch
            {

            }
        }
    }
}
using eMusic.Mobile.Views.Account;
using eMusic.Model;
using eMusic.Model.Request;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace eMusic.Mobile.ViewModels.Account
{
    public class RegisterVM : BaseVM
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

        string firstName;
        public string FirstName
        {
            get { return firstName; }
            set { SetProperty(ref firstName, value); }
        }

        string lastName;
        public string LastName
        {
            get { return lastName; }
            set { SetProperty(ref lastName, value); }
        }

        string email;
        public string Email
        {
            get { return email; }
            set { SetProperty(ref email, value); }
        }

        string phone;
        public string Phone
        {
            get { return phone; }
            set { SetProperty(ref phone, value); }
        }

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

        string passwordConfirmation;
        public string PasswordConfirmation
        {
            get { return passwordConfirmation; }
            set { SetProperty(ref passwordConfirmation, value); }
        }
        public ICommand RegisterCommand { get; set; }
        public ICommand LoginCommand { get; set; }

        public RegisterVM()
        {
            RegisterCommand = new Command(async () => await Register());
            LoginCommand = new Command(() => LoginLoad());
        }
        public async Task Register()
        {
            try
            {
                UserUpsertRequest request = null;
                bool req = true;
                if (Email == null || FirstName == null || LastName == null || Username == null || Password == null || PasswordConfirmation == null || Phone == null ||
                    Email == "" || FirstName == "" || LastName == "" || Username == "" || Password == "" || PasswordConfirmation == "" || Phone == "")
                {
                    await App.Current.MainPage.DisplayAlert("Information", "You have to fill all fields!", "OK");
                    req = false;
                }

                request = new UserUpsertRequest()
                {
                    FirstName = FirstName,
                    LastName = LastName,
                    Email = Email,
                    PhoneNumber = Phone,
                    Username = Username,
                    Password = Password,
                    PasswordConfirmation = PasswordConfirmation,
                    Roles = new List<int> { 2 }
                };
                if(request != null)
                {
                    bool err = false;
                    bool isValid = Regex.IsMatch(Email, emailPattern); ;
                    var hasNumber = new Regex(@"[0-9]+");
                    var hasUpperChar = new Regex(@"[A-Z]+");
                    var hasMinimum8Chars = new Regex(@".{8,}");
                    if (!hasNumber.IsMatch(request.Password) || !hasUpperChar.IsMatch(request.Password) || !hasMinimum8Chars.IsMatch(request.Password))
                    {
                        await App.Current.MainPage.DisplayAlert("Information", "Password should have numbers, uppercase, lowercase and minimum 8 characters!", "OK");
                        err = true;
                    }
                    if (request.Password != request.PasswordConfirmation)
                    {
                        await App.Current.MainPage.DisplayAlert("Information", "Passwords do not match!", "OK");
                        err = true;
                    }
                    if (!IsDigitsOnly(request.PhoneNumber))
                    {
                        await App.Current.MainPage.DisplayAlert("Information", "You can't use letters as a phone number!", "OK");
                        err = true;
                    }
                    var users = await userService.Get<List<MUser>>(null);
                    foreach (var k in users)
                    {
                        if (k.Username == request.Username)
                        {
                            await App.Current.MainPage.DisplayAlert("Information", "Username already exist!", "OK");
                            err = true;
                            break;
                        }
                        else if(request.Username.Length < 3)
                        {
                            await App.Current.MainPage.DisplayAlert("Information", "Username Needs to contain at least 3 letters!", "OK");
                            err = true;
                            break;
                        }
                    }

                    foreach (var k in users)
                    {
                        if (k.Email == request.Email)
                        {
                            await App.Current.MainPage.DisplayAlert("Information", "Email already used!", "OK");
                            err = true;
                            break;
                        }
                    }
                    //if (!isValid)
                    //{
                    //    await App.Current.MainPage.DisplayAlert("Information", "Enter email in a valid format!", "OK");
                    //    err = true;
                    //}
                    if (err != true) { 
                        await userService.Register(request);
                        await Application.Current.MainPage.DisplayAlert("Success", "You have successfully registred", "OK");
                        Application.Current.MainPage = new LoginPage();
                    }
                }                   
            }
            catch
            {
                //await Application.Current.MainPage.DisplayAlert("Error", "An error has accured", "OK");
            }
        }
        void LoginLoad()
        {
            Application.Current.MainPage = new LoginPage();
        }
    }
}

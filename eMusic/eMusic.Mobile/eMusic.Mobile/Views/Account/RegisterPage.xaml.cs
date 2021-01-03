using eMusic.Mobile.ViewModels.Account;
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
    public partial class RegisterPage : ContentPage
    {
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
        public RegisterPage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            ErrorLabel_FirstName.IsVisible = false;
            ErrorLabel_LastName.IsVisible = false;
            ErrorLabel_Username.IsVisible = false;
            ErrorLabel_Email.IsVisible = false;
            ErrorLabel_Phone.IsVisible = false;
            ErrorLabel_Password.IsVisible = false;
            ErrorLabel_PasswordConfirmation.IsVisible = false;
        }
        private void firstname_changed(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(FirstName.Text))
            {
                ErrorLabel_FirstName.IsVisible = true;
                ErrorLabel_FirstName.Text = "First Name field is required!";
            }            
            else
            {
                ErrorLabel_FirstName.IsVisible = false;
            }
        }

        private void firstname_unfocused(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(FirstName.Text))
            {
                ErrorLabel_FirstName.IsVisible = true;
                ErrorLabel_FirstName.Text = "First Name field is required!";
            }            
            else
            {
                ErrorLabel_FirstName.IsVisible = false;

            }     
        }
        private void lastname_changed(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(LastName.Text))
            {
                ErrorLabel_LastName.IsVisible = true;
                ErrorLabel_LastName.Text = "Last Name field is required!";
            }            
            else
            {
                ErrorLabel_LastName.IsVisible = false;
            }
        }
        private void lastname_unfocused(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(LastName.Text))
            {
                ErrorLabel_LastName.IsVisible = true;
                ErrorLabel_LastName.Text = "Last Name field is required!";
            }            
            else
            {
                ErrorLabel_LastName.IsVisible = false;
            }     
        }                    

        private void email_unfocused(object sender, System.EventArgs e)
        {
            if (string.IsNullOrEmpty(Email.Text))
            {
                ErrorLabel_Email.IsVisible = true;
                ErrorLabel_Email.Text = "Email field is required!";
            }
            else
            {
                ErrorLabel_Email.IsVisible = false;
            }
            if(Email.Text != null)
            { 
                bool isValid = Regex.IsMatch(Email.Text, emailPattern);
                if (!isValid)
                {
                    ErrorLabel_Email.IsVisible = true;
                    ErrorLabel_Email.Text = "Enter email in a valid format!";
                }
                else
                {
                    ErrorLabel_Email.IsVisible = false;
                }
            }
        }
        private void email_changed(object sender, System.EventArgs e)
        {
            if (string.IsNullOrEmpty(Email.Text))
            {
                ErrorLabel_Email.IsVisible = true;
                ErrorLabel_Email.Text = "Email field is required!";
            }            
            else
            {
                ErrorLabel_Email.IsVisible = false;
            }
            if (Email.Text != null)
            {
                bool isValid = Regex.IsMatch(Email.Text, emailPattern);
                if (!isValid)
                {
                    ErrorLabel_Email.IsVisible = true;
                    ErrorLabel_Email.Text = "Enter email in a valid format!";
                }
                else
                {
                    ErrorLabel_Email.IsVisible = false;
                }
            }
        }
     
        private void username_unfocused(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Username.Text))
            {
                ErrorLabel_Username.IsVisible = true;
                ErrorLabel_Username.Text = "Username field is required!";
            }
            else if (Username.Text.Count() < 3)
            {
                ErrorLabel_Username.IsVisible = true;
                ErrorLabel_Username.Text = "Username need to contain at least 3 letters!";
            }
            else
            {
                ErrorLabel_Username.IsVisible = false;                
            }
        }
        private void username_changed(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Username.Text))
            {
                ErrorLabel_Username.IsVisible = true;
                ErrorLabel_Username.Text = "Username field is required!";
            }
            else if(Username.Text.Count() < 3)
            {
                ErrorLabel_Username.IsVisible = true;
                ErrorLabel_Username.Text = "Username need to contain at least 3 letters!";
            }
            else
            {
                ErrorLabel_Username.IsVisible = false;
            }
        }
        private void phone_unfocused(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Phone.Text))
            {
                ErrorLabel_Phone.IsVisible = true;
                ErrorLabel_Phone.Text = "Phone field is required!";
            }
            else
            {
                ErrorLabel_Phone.IsVisible = false;
            }
            if(Phone.Text != null)
            {
                if(IsDigitsOnly(Phone.Text) == false)
                {
                    ErrorLabel_Phone.IsVisible = true;
                    ErrorLabel_Phone.Text = "You Can't Use Letters!";
                }
                else
                {
                    ErrorLabel_Phone.IsVisible = false;
                }
            }
        }
        private void phone_changed(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Phone.Text))
            {
                ErrorLabel_Phone.IsVisible = true;
                ErrorLabel_Phone.Text = "Phone field is required!";
            }
            else
            {
                ErrorLabel_Phone.IsVisible = false;
            }
            if (Phone.Text != null)
            {
                if (IsDigitsOnly(Phone.Text) == false)
                {
                    ErrorLabel_Phone.IsVisible = true;
                    ErrorLabel_Phone.Text = "You Can't Use Letters!";
                }
                else
                {
                    ErrorLabel_Phone.IsVisible = false;
                }
            }
        }
        private void password_changed(object sender, EventArgs e)
        {
            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasMinimum8Chars = new Regex(@".{8,}");

            if (string.IsNullOrEmpty(Password.Text))
            {
                ErrorLabel_Password.IsVisible = true;
                ErrorLabel_Password.Text = "Password Confirmation field is required!";
            }
            else if (!hasNumber.IsMatch(Password.Text) || !hasUpperChar.IsMatch(Password.Text) || !hasMinimum8Chars.IsMatch(Password.Text))
            {
                ErrorLabel_Password.IsVisible = true;
                ErrorLabel_Password.Text = "Password must contain number, uppercase, lowercase and minimum 8 characters!";
            }
            else
            {
                ErrorLabel_PasswordConfirmation.IsVisible = false;
            }
        }
        private void password_unfocused(object sender, EventArgs e)
        {
            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasMinimum8Chars = new Regex(@".{8,}");
            if (string.IsNullOrEmpty(Password.Text))
            {
                ErrorLabel_Password.IsVisible = true;
                ErrorLabel_Password.Text = "Password field is required!";
            }
            else if (!hasNumber.IsMatch(Password.Text) || !hasUpperChar.IsMatch(Password.Text) || !hasMinimum8Chars.IsMatch(Password.Text))
            {
                ErrorLabel_Password.IsVisible = true;
                ErrorLabel_Password.Text = "Password must contain number, uppercase, lowercase and minimum 8 characters!";
            }
            else
            {
                ErrorLabel_Password.IsVisible = false;
            }
        }
        private void passwordconfirmation_unfocused(object sender, EventArgs e)
        {
            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasMinimum8Chars = new Regex(@".{8,}");
            if (string.IsNullOrEmpty(PasswordConfirmation.Text))
            {
                ErrorLabel_PasswordConfirmation.IsVisible = true;
                ErrorLabel_PasswordConfirmation.Text = "Password Confirmation field is required!";
            }
            else if (!hasNumber.IsMatch(PasswordConfirmation.Text) || !hasUpperChar.IsMatch(PasswordConfirmation.Text) || !hasMinimum8Chars.IsMatch(PasswordConfirmation.Text))
            {
                ErrorLabel_PasswordConfirmation.IsVisible = true;
                ErrorLabel_PasswordConfirmation.Text = "Password must contain have number, uppercase, lowercase and minimum 8 characters!";
            }
            else
            {
                ErrorLabel_PasswordConfirmation.IsVisible = false;
            }

        }
        private void passwordconfirmation_changed(object sender, EventArgs e)
        {
            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasMinimum8Chars = new Regex(@".{8,}");

            if (string.IsNullOrEmpty(PasswordConfirmation.Text))
            {
                ErrorLabel_PasswordConfirmation.IsVisible = true;
                ErrorLabel_PasswordConfirmation.Text = "Password Confirmation field is required!";
            }
            else if (!hasNumber.IsMatch(PasswordConfirmation.Text) || !hasUpperChar.IsMatch(PasswordConfirmation.Text) || !hasMinimum8Chars.IsMatch(PasswordConfirmation.Text))
            {
                ErrorLabel_PasswordConfirmation.IsVisible = true;
                ErrorLabel_PasswordConfirmation.Text = "Password must contain have number, uppercase, lowercase and minimum 8 characters!";
            }
            else
            {
                ErrorLabel_PasswordConfirmation.IsVisible = false;
            }
        }
    }
}
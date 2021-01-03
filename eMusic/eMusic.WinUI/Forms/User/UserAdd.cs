using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using eMusic.Model;
using eMusic.Model.Request;
using eMusic.WinUI.Helper;
using eMusic.WinUI.Properties;
using System.Text.RegularExpressions;

namespace eMusic.WinUI.Forms.User
{
    public partial class UserAdd : UserControl
    {
        private readonly APIService userService = new APIService("User");
        private readonly APIService roleService = new APIService("Role");
        string emailPattern = @"^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$";
        public UserAdd()
        {
            InitializeComponent();
        }

        private async void UserAdd_Load(object sender, EventArgs e)
        {
            var roles = await roleService.Get<List<MRole>>(null);
            clbRoles.DataSource = roles;
            clbRoles.ValueMember = "RoleID";
            clbRoles.DisplayMember = "Name";
        }

        private void txtUploadPicture_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfd = new OpenFileDialog
            {
                Filter = "Image Files (*.jpg;*.jpeg;.*.gif;)|*.jpg;*.jpeg;.*.gif"
            };
            if (openfd.ShowDialog() == DialogResult.OK)
            {
                pbUserImage.SizeMode = PictureBoxSizeMode.StretchImage;
                pbUserImage.Image = new Bitmap(openfd.FileName);
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                try
                {
                    var roleList = clbRoles.CheckedItems.Cast<MRole>().Select(i => i.RoleID).ToList();

                    var request = new UserUpsertRequest
                    {
                        FirstName = txtFirstName.Text,
                        LastName = txtLastName.Text,
                        Username = txtUsername.Text,
                        Email = txtEmail.Text,
                        PhoneNumber = txtPhone.Text,
                        Password = txtPassword.Text,
                        PasswordConfirmation = txtPasswordConfirm.Text,
                        Image = pbUserImage.Image != null ? ImageHelper.SystemDrawingToByteArray(pbUserImage.Image) : null,
                        Roles = roleList
                    };

                    await userService.Insert<MUser>(request);

                    MessageBox.Show("User Added Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    PanelHelper.SwapPanels(this.Parent, this, new UserList());
                }
                catch
                {
                    MessageBox.Show("You Dont Have Permission to do That!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtFirstName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFirstName, Resources.Validation_RequiredField);
            }
            else
            {
                errorProvider1.SetError(txtFirstName, null);
            }
        }

        private void txtLastName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtLastName, Resources.Validation_RequiredField);
            }
            else
            {
                errorProvider1.SetError(txtLastName, null);
            }
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtEmail, Resources.Validation_RequiredField);
            }
            else
            {
                errorProvider1.SetError(txtEmail, null);
                bool isEmailValid = Regex.IsMatch(txtEmail.Text, emailPattern);
                if (isEmailValid == false)
                {
                    e.Cancel = true;
                    errorProvider1.SetError(txtEmail, "Enter Email in a Valid Format!");
                }
            }
        }
        bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }
        private void txtPhone_Validating(object sender, CancelEventArgs e)
        {
            string phone = txtPhone.Text.ToString();
            if (string.IsNullOrWhiteSpace(txtPhone.Text) || txtPhone.Text.Length < 9 || txtPhone.Text.Length > 9)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtPhone, "Phone number needs to contain 9 digits!");
            }
            else
            {
                errorProvider1.SetError(txtPhone, null);
                if (IsDigitsOnly(phone) == false)
                {
                    e.Cancel = true;
                    errorProvider1.SetError(txtPhone, "You Can't Use Letters!");
                }
                else
                {
                    errorProvider1.SetError(txtPhone, null);
                }
            }
        }

        private void txtUsername_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text) || txtUsername.Text.Length < 3)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtUsername, "This Field Need To Contain At Least 3 Letters");
            }
            else
            {
                errorProvider1.SetError(txtUsername, null);
            }
        }

        private void clbRoles_Validating(object sender, CancelEventArgs e)
        {
            var roleList = clbRoles.CheckedItems.Cast<MRole>().Select(x => x.RoleID).ToList();
            if (roleList.Count() == 0)
            {
                e.Cancel = true;
                errorProvider1.SetError(clbRoles, "You Must Choose At Least One Role!");
            }
            else
            {
                errorProvider1.SetError(clbRoles, null);
            }
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasMinimum8Chars = new Regex(@".{8,}");
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                errorProvider1.SetError(txtPassword, Resources.Validation_RequiredField);
                e.Cancel = true;
            }
            else
            {
                if (hasNumber.IsMatch(txtPassword.Text) && hasUpperChar.IsMatch(txtPassword.Text) && hasMinimum8Chars.IsMatch(txtPassword.Text))
                {
                    errorProvider1.SetError(txtPassword, null);
                }
                else
                {
                    errorProvider1.SetError(txtPassword, "Password should have number, uppercase, lowercase and minimum 8 characters!");
                    e.Cancel = true;

                }
            }
        }

        private void txtPasswordConfirm_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPasswordConfirm.Text))
            {
                errorProvider1.SetError(txtPasswordConfirm, Resources.Validation_RequiredField);
                e.Cancel = true;
            }
            else
            {
                if (txtPassword.Text == txtPasswordConfirm.Text)
                {
                    errorProvider1.SetError(txtPasswordConfirm, null);
                }
                else
                {
                    errorProvider1.SetError(txtPasswordConfirm, "Passwords do not match!");
                    e.Cancel = true;
                }
            }
        }
    }
}

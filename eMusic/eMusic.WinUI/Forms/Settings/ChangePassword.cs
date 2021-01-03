using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using eMusic.Model.Request;
using eMusic.WinUI.Helper;
using eMusic.Model;
using System.Text.RegularExpressions;
using eMusic.WinUI.Properties;

namespace eMusic.WinUI.Forms.Settings
{
    public partial class ChangePassword : UserControl
    {
        private readonly APIService userService = new APIService("User");
        private readonly int _ID;
        public ChangePassword(int ID)
        {
            _ID = ID;
            InitializeComponent();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var user = await userService.GetById<MUser>(_ID);
                UserUpsertRequest request = null;
                if (txtOldPassword.Text == APIService.Password) {
                    request = new UserUpsertRequest
                    {
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Username = user.Username,
                        Email = user.Email,
                        PhoneNumber = user.PhoneNumber,
                        Image = user.Image,
                        Password = txtNewPassword.Text,
                        PasswordConfirmation = txtNewPasswordConfirm.Text
                    };
                }
                else
                {
                    MessageBox.Show("Old password is not correct!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (txtNewPassword.Text != txtNewPasswordConfirm.Text)
                {
                    MessageBox.Show("Passwords do not match!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }               

                await userService.Update<MUser>(_ID, request);

                MessageBox.Show("Succesfully changed, please log in to confirm changes.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                var form = new frmLogin();
                form.Show();
                ParentForm.Close();                
            }
            catch
            {
                MessageBox.Show("Ups, something went wrong!");
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            PanelHelper.SwapPanels(this.Parent, this, new EditInfo(_ID));
        }

        private void txtNewPassword_Validating(object sender, CancelEventArgs e)
        {
            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasMinimum8Chars = new Regex(@".{8,}");
            if (string.IsNullOrWhiteSpace(txtNewPassword.Text))
            {
                errorProvider1.SetError(txtNewPassword, Resources.Validation_RequiredField);
                e.Cancel = true;
            }
            else
            {
                if (hasNumber.IsMatch(txtNewPassword.Text) && hasUpperChar.IsMatch(txtNewPassword.Text) && hasMinimum8Chars.IsMatch(txtNewPassword.Text))
                {
                    errorProvider1.SetError(txtNewPassword, null);
                }
                else
                {
                    errorProvider1.SetError(txtNewPassword, "Password should have numbers, uppercase, lowercase and minimum 8 characters!");
                    e.Cancel = true;

                }
            }
        }

        private void txtNewPasswordConfirm_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNewPasswordConfirm.Text))
            {
                errorProvider1.SetError(txtNewPasswordConfirm, Resources.Validation_RequiredField);
                e.Cancel = true;
            }
            else
            {
                if (txtNewPasswordConfirm.Text == txtNewPasswordConfirm.Text)
                {
                    errorProvider1.SetError(txtNewPasswordConfirm, null);
                }
                else
                {
                    errorProvider1.SetError(txtNewPasswordConfirm, "Passwords do not match!");
                    e.Cancel = true;
                }
            }
        }
    }
}

using eMusic.Model;
using eMusic.Model.Request;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eMusic.WinUI
{
    public partial class frmLogin : Form
    {
        private readonly APIService userService = new APIService("User");
        bool moving;
        Point offset;
        Point original;
        public frmLogin()
        {
            InitializeComponent();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            APIService.Username = txtUsername.Text;
            APIService.Password = txtPassword.Text;

            var request = new UserAuthenticationRequest()
            {
                Username = APIService.Username,
                Password = APIService.Password
            };

            var user = await userService.Authenticate(request);

            if (user != null)
            {
                LoadPanel(user);
                this.Hide();
            }
            else
            {
                MessageBox.Show("Wrong Username Or Password!");
            }
        }
        private void LoadPanel(MUser user)
        {
            var admin = user.UserRoles.Select(i => i.Role.Name).FirstOrDefault();
            if(admin == "Admin") { 
               var form = new frmIndex(user);
               form.Show();
            }
            else
            {
                MessageBox.Show("Use Admin Credentials to Login!");
                frmLogin frm = new frmLogin();
                frm.Show();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (!moving)
                return;

            int x = original.X + MousePosition.X - offset.X;
            int y = original.Y + MousePosition.Y - offset.Y;

            this.Location = new Point(x, y);
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            moving = true;
            pictureBox1.Capture = true;
            offset = MousePosition;
            original = this.Location;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            moving = false;
            pictureBox1.Capture = false;
        }
    }
}

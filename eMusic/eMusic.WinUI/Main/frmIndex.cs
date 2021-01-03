using eMusic.Model;
using eMusic.WinUI.Forms.Album;
using eMusic.WinUI.Forms.Artist;
using eMusic.WinUI.Forms.Genre;
using eMusic.WinUI.Forms.Playlist;
using eMusic.WinUI.Forms.Settings;
using eMusic.WinUI.Forms.Track;
using eMusic.WinUI.Forms.User;
using eMusic.WinUI.Helper;
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
    public partial class frmIndex : Form
    {
        private static MUser _user;
        bool moving;
        Point offset;
        Point original;
        public frmIndex(MUser user)
        {
            _user = user;
            SignedInUser.User = _user;
            InitializeComponent();
        }

        private void frmIndex_Load(object sender, EventArgs e)
        {
            lUsername.Text = _user.Username;
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            var form = new frmLogin();
            form.Show();
            Hide();
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            PanelHelper.RemovePanels(Content);
            PanelHelper.AddPanel(Content, new UserList());
        }

        private void btnGenre_Click(object sender, EventArgs e)
        {
            PanelHelper.RemovePanels(Content);
            PanelHelper.AddPanel(Content, new GenreList());
        }

        private void btnArtist_Click(object sender, EventArgs e)
        {
            PanelHelper.RemovePanels(Content);
            PanelHelper.AddPanel(Content, new ArtistList());
        }

        private void btnTrack_Click(object sender, EventArgs e)
        {
            PanelHelper.RemovePanels(Content);
            PanelHelper.AddPanel(Content, new TrackList());
        }

        private void btnAlbum_Click(object sender, EventArgs e)
        {
            PanelHelper.RemovePanels(Content);
            PanelHelper.AddPanel(Content, new AlbumList());
        }      

        private void btnPlaylist_Click(object sender, EventArgs e)
        {
            PanelHelper.RemovePanels(Content);
            PanelHelper.AddPanel(Content, new PlaylistList());
        }
        private void btnSettings_Click(object sender, EventArgs e)
        {
            PanelHelper.RemovePanels(Content);
            PanelHelper.AddPanel(Content, new EditInfo(_user.UserID));
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

        private void Navbar_MouseMove(object sender, MouseEventArgs e)
        {
            if (!moving)
                return;

            int x = original.X + MousePosition.X - offset.X;
            int y = original.Y + MousePosition.Y - offset.Y;

            this.Location = new Point(x, y);
        }

        private void Navbar_MouseUp(object sender, MouseEventArgs e)
        {
            moving = false;
            Navbar.Capture = false;
        }

        private void Navbar_MouseDown(object sender, MouseEventArgs e)
        {
            moving = true;
            Navbar.Capture = true;
            offset = MousePosition;
            original = this.Location;
        }       
    }
}

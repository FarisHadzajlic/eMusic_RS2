using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio.Wave;
using eMusic.WinUI.Helper;
using eMusic.Model.Request;
using System.IO;
using eMusic.Model;

namespace eMusic.WinUI.Forms.Track
{
    public partial class TrackUpsert : UserControl
    {
        private readonly APIService trackService = new APIService("Track");
        private readonly APIService genreService = new APIService("Genre");
        private readonly APIService artistService = new APIService("Artist");
        public TrackUpsert()
        {
            InitializeComponent();
        }

        private async void TrackUpsert_Load(object sender, EventArgs e)
        {
            var genres = await genreService.Get<List<MGenre>>(null);
            cbGenres.DataSource = genres;
            cbGenres.ValueMember = "GenreID";
            cbGenres.DisplayMember = "Name";

            var artists = await artistService.Get<List<MArtist>>(null);
            cbArtist.DataSource = artists;
            cbArtist.ValueMember = "ArtistID";
            cbArtist.DisplayMember = "Name";
        }

        private void btnUploadSong_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfd = new OpenFileDialog
            {
                Filter = "All Supported Audio | *.mp3;"
            };
            if (openfd.ShowDialog() == DialogResult.OK)
            {
                axWindowsMediaPlayer1.URL = openfd.FileName;
                axWindowsMediaPlayer1.Ctlcontrols.stop();

                Mp3FileReader reader = new Mp3FileReader(openfd.FileName);
                TimeSpan duration = reader.TotalTime;
                txtLength.Text = duration.ToString(@"mm\:ss");

                if (string.IsNullOrEmpty(txtName.Text))
                {
                    txtName.Text = openfd.SafeFileName.Replace(".mp3", "");
                }
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.stop();

            byte[] MP3File = File.ReadAllBytes(axWindowsMediaPlayer1.URL);
            var trackGenres = Convert.ToInt32(cbGenres.SelectedValue);
            int trackArtist = Convert.ToInt32(cbArtist.SelectedValue);
            var request = new TrackUpsertRequest()
            {
                Name = txtName.Text,
                Length = txtLength.Text,
                MP3File = MP3File,
                GenreID = trackGenres,
                ArtistID = trackArtist
            };

            await trackService.Insert<MTrack>(request);
            MessageBox.Show("Track added successfully", "Success", MessageBoxButtons.OK);
            PanelHelper.SwapPanels(this.Parent, this, new TrackList());
        }
    }
}

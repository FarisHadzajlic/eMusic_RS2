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
using eMusic.WinUI.Helper;
using eMusic.Model.Request;

namespace eMusic.WinUI.Forms.Track
{
    public partial class TrackList : UserControl
    {
        private readonly APIService trackService = new APIService("Track");
        private readonly APIService genreService = new APIService("Genre");
        public TrackList()
        {
            InitializeComponent();
        }

        private async void TrackList_Load(object sender, EventArgs e)
        {
            await LoadList();
        }
        private async Task LoadList()
        {
            var result = await trackService.Get<List<MTrack>>(null);
            var genres = await genreService.Get<List<MGenre>>(null);

            genres.Insert(0, new MGenre { Name = "All Genres" });
            cbGenreList.DataSource = genres;
            cbGenreList.DisplayMember = "Name";
            cbGenreList.ValueMember = "GenreID";

            dgvTracks.AutoGenerateColumns = false;
            dgvTracks.ReadOnly = true;
            dgvTracks.DataSource = result;
        }
        private async Task LoadList(TrackSearchRequest request)
        {
            var result = await trackService.Get<List<MTrack>>(request);
            dgvTracks.AutoGenerateColumns = false;
            dgvTracks.ReadOnly = true;
            dgvTracks.DataSource = result;
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            PanelHelper.SwapPanels(this.Parent, this, new TrackUpsert());
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvTracks.CurrentRow != null)
            {
                var result = false;
                int ID = Convert.ToInt32(dgvTracks.CurrentRow.Cells["TrackID"].Value);
                if (MessageBox.Show("Do you really want to delete this track?", "Success", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    result = await trackService.Delete<dynamic>(ID);
                }
                if (result == true)
                {
                    MessageBox.Show("You have deleted track successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                PanelHelper.SwapPanels(this.Parent, this, new TrackList());
            }
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            var search = txtSearch.Text;
            var request = new TrackSearchRequest()
            {
                Name = search
            };
            await LoadList(request);
        }

        private async void cbGenreList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var genre = cbGenreList.SelectedItem as MGenre;
            var genreID = genre.GenreID;
            if (genre.Name == "All Genres")
            {
                await LoadList(null);
            }
            else
            {
                var request = new TrackSearchRequest()
                {
                    GenreID = genreID
                };
                await LoadList(request);
            }
        }
    }
}

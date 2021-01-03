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

namespace eMusic.WinUI.Forms.Album
{
    public partial class AlbumList : UserControl
    {
        private readonly APIService albumService = new APIService("Album");
        private readonly APIService genreService = new APIService("Genre");
        private readonly int? _ID;
        public AlbumList(int? ID = null)
        {
            _ID = ID;
            InitializeComponent();
        }

        private async void AlbumList_Load(object sender, EventArgs e)
        {
            await LoadList();
        }
        private async Task LoadList()
        {
            var albums = await albumService.Get<List<MAlbum>>(null);
            var genres = await genreService.Get<List<MGenre>>(null);
            genres.Insert(0, new MGenre { Name = "All Genres" });
            cbGenreList.DataSource = genres;
            cbGenreList.DisplayMember = "Name";
            cbGenreList.ValueMember = "GenreID";

            dgvAlbums.AutoGenerateColumns = false;
            dgvAlbums.ReadOnly = true;
            dgvAlbums.DataSource = albums;
        }
        private async Task LoadList(AlbumSearchRequest request)
        {
            var result = await albumService.Get<List<MAlbum>>(request);

            dgvAlbums.AutoGenerateColumns = false;
            dgvAlbums.ReadOnly = true;
            dgvAlbums.DataSource = result;
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            var search = txtSearch.Text;
            var request = new AlbumSearchRequest()
            {
                Name = search
            };
            await LoadList(request);
        }

        private void btnAddAlbum_Click(object sender, EventArgs e)
        {
            PanelHelper.SwapPanels(this.Parent, this, new AlbumUpsert());
        }

        private void btnDetails_Click(object sender, EventArgs e)
        {
            if (dgvAlbums.CurrentRow != null)
            {
                int ID = Convert.ToInt32(dgvAlbums.CurrentRow.Cells["AlbumID"].Value);
                PanelHelper.SwapPanels(this.Parent, this, new AlbumUpsert(ID));
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvAlbums.CurrentRow != null)
            {
                var result = false;
                int ID = Convert.ToInt32(dgvAlbums.CurrentRow.Cells["AlbumID"].Value);
                if (MessageBox.Show("Do you really want to delete this album?", "Success", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    result = await albumService.Delete<dynamic>(ID);
                }
                if (result == true)
                {
                    MessageBox.Show("You have deleted album successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                PanelHelper.SwapPanels(this.Parent, this, new AlbumList());
            }
        }             

        private async void cbGenreList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var genre = cbGenreList.SelectedItem as MGenre;
            var genreID = genre.GenreID;
            if(genre.Name == "All Genres")
            {
                await LoadList(null);
            }
            else
            {
                var request = new AlbumSearchRequest()
                {
                    GenreID = genreID
                };
                await LoadList(request);
            }            
        }

        private void btnSeller_Click(object sender, EventArgs e)
        {
            PanelHelper.SwapPanels(this.Parent, this, new AlbumSaleList());
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            PanelHelper.SwapPanels(this.Parent, this, new AlbumReport(dgvAlbums.DataSource as List<MAlbum>));
        }
    }
}

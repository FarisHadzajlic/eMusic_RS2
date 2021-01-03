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

namespace eMusic.WinUI.Forms.Artist
{
    public partial class ArtistList : UserControl
    {
        private readonly APIService artistService = new APIService("Artist");
        public ArtistList()
        {
            InitializeComponent();
        }

        private async void ArtistUpsert_Load(object sender, EventArgs e)
        {
            await LoadList();
        }
        private async Task LoadList()
        {
            var result = await artistService.Get<List<MArtist>>(null);

            dgvArtists.AutoGenerateColumns = false;
            dgvArtists.ReadOnly = true;
            dgvArtists.DataSource = result;
        }
        private async Task LoadList(ArtistSearchRequest request)
        {
            var result = await artistService.Get<List<MArtist>>(request);

            dgvArtists.AutoGenerateColumns = false;
            dgvArtists.ReadOnly = true;
            dgvArtists.DataSource = result;
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            var search = txtSearch.Text;
            var request = new ArtistSearchRequest()
            {
                Name = search
            };
            await LoadList(request);
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            PanelHelper.SwapPanels(this.Parent, this, new ArtistUpsert());
        }
        private void btnDetails_Click(object sender, EventArgs e)
        {
            if (dgvArtists.CurrentRow != null)
            {
                int ID = Convert.ToInt32(dgvArtists.CurrentRow.Cells["ArtistID"].Value);
                PanelHelper.SwapPanels(this.Parent, this, new ArtistUpsert(ID));
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvArtists.CurrentRow != null)
            {
                var result = false;
                int ID = Convert.ToInt32(dgvArtists.CurrentRow.Cells["ArtistID"].Value);
                if (MessageBox.Show("Do you really want to delete this artist?", "Success", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    result = await artistService.Delete<dynamic>(ID);
                }
                if (result == true)
                {
                    MessageBox.Show("You have deleted artist successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                PanelHelper.SwapPanels(this.Parent, this, new ArtistList());
            }
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            PanelHelper.SwapPanels(this.Parent, this, new ArtistReport(dgvArtists.DataSource as List<MArtist>));
        }
       
    }
}

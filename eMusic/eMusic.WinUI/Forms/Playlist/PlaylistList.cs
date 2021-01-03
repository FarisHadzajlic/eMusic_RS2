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

namespace eMusic.WinUI.Forms.Playlist
{
    public partial class PlaylistList : UserControl
    {
        private readonly APIService playlistService = new APIService("Playlist");
        public PlaylistList()
        {
            InitializeComponent();
        }

        private async void PlaylistList_Load(object sender, EventArgs e)
        {
            var result = await playlistService.Get<List<MPlaylist>>(null);
            for (var x = 0; x < result.Count(); x++) 
            {
                result[x].Username = result[x].User.Username;
            }
          
            dgvPlaylist.AutoGenerateColumns = false;
            dgvPlaylist.ReadOnly = true;
            dgvPlaylist.DataSource = result;
        }     

        private void btnDetails_Click(object sender, EventArgs e)
        {
            if (dgvPlaylist.CurrentRow != null)
            {
                int ID = Convert.ToInt32(dgvPlaylist.CurrentRow.Cells["PlaylistID"].Value);
                PanelHelper.SwapPanels(this.Parent, this, new PlaylistUpsert(ID));
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvPlaylist.CurrentRow != null)
            {
                var result = false;
                int ID = Convert.ToInt32(dgvPlaylist.CurrentRow.Cells["PlaylistID"].Value);
                if (MessageBox.Show("Do you really want to delete this playlist?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    result = await playlistService.Delete<dynamic>(ID);
                }
                if (result == true)
                {
                    MessageBox.Show("You have deleted playlist successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                PanelHelper.SwapPanels(this.Parent, this, new PlaylistList());
            }
        }
    }
}

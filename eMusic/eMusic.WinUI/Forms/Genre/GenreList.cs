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

namespace eMusic.WinUI.Forms.Genre
{
    public partial class GenreList : UserControl
    {
        private readonly APIService genreService = new APIService("Genre");
        public GenreList()
        {
            InitializeComponent();
        }

        private async void GenreList_Load(object sender, EventArgs e)
        {
            await LoadList();
        }
        private async Task LoadList()
        {
            var result = await genreService.Get<List<MGenre>>(null);
            dgvGenres.AutoGenerateColumns = false;
            dgvGenres.ReadOnly = true;
            dgvGenres.DataSource = result;
        }

        private void btnAddGenre_Click(object sender, EventArgs e)
        {
            PanelHelper.SwapPanels(this.Parent, this, new GenreUpsert());
        }

        private void btnDetails_Click(object sender, EventArgs e)
        {
            if (dgvGenres.CurrentRow != null)
            {
                int ID = Convert.ToInt32(dgvGenres.CurrentRow.Cells["GenreID"].Value);
                PanelHelper.SwapPanels(this.Parent, this, new GenreUpsert(ID));
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvGenres.CurrentRow != null)
            {
                var result = false;
                int ID = Convert.ToInt32(dgvGenres.CurrentRow.Cells["GenreID"].Value);
                if (MessageBox.Show("Do you really want to delete this genre?", "Success", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    result = await genreService.Delete<dynamic>(ID);
                }
                if (result == true)
                {
                    MessageBox.Show("You have deleted genre successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                PanelHelper.SwapPanels(this.Parent, this, new GenreList());
            }
        }
    }
}

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

namespace eMusic.WinUI.Forms.Genre
{
    public partial class GenreUpsert : UserControl
    {
        private readonly APIService genreService = new APIService("Genre");
        private readonly int? _ID;
        public GenreUpsert(int? ID = null)
        {
            _ID = ID;
            InitializeComponent();
        }

        private async void GenreUpsert_Load(object sender, EventArgs e)
        {
            if (_ID.HasValue)
            {
                var artist = await genreService.GetById<MGenre>(_ID.Value);
                txtName.Text = artist.Name;
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                var request = new GenreUpsertRequest
                {
                    Name = txtName.Text
                };
                if (_ID.HasValue)
                {
                    await genreService.Update<MGenre>(_ID.Value, request);
                    MessageBox.Show("Genre updated successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    await genreService.Insert<MGenre>(request);
                    MessageBox.Show("Genre added successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                PanelHelper.SwapPanels(this.Parent, this, new GenreList());
            }
        }

        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtName, Resources.Validation_RequiredField);
            }
            else
            {
                errorProvider1.SetError(txtName, null);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            PanelHelper.SwapPanels(this.Parent, this, new GenreList());
        }
    }
}

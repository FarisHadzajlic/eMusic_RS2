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
using eMusic.WinUI.Properties;

namespace eMusic.WinUI.Forms.Artist
{
    public partial class ArtistUpsert : UserControl
    {
        private readonly APIService artistService = new APIService("Artist");
        private readonly int? _ID;
        public ArtistUpsert(int? ID = null)
        {
            _ID = ID;
            InitializeComponent();
        }

        private async void ArtistUpsert_Load(object sender, EventArgs e)
        {
            if (_ID.HasValue)
            {
                var artist = await artistService.GetById<MArtist>(_ID.Value);
                txtName.Text = artist.Name;
                txtOrigin.Text = artist.Origin;
                txtFounded.Text = artist.Founded;
                if (artist.Image.Length > 3)
                {
                    pbArtistImage.Image = ImageHelper.ByteArrayToSystemDrawing(artist.Image);
                    pbArtistImage.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
        }

        private void btnUploadPicture_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfd = new OpenFileDialog
            {
                Filter = "Image Files (*.jpg;*.jpeg;.*.gif;)|*.jpg;*.jpeg;.*.gif"
            };
            if (openfd.ShowDialog() == DialogResult.OK)
            {
                pbArtistImage.SizeMode = PictureBoxSizeMode.StretchImage;
                pbArtistImage.Image = new Bitmap(openfd.FileName);
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                var request = new ArtistUpsertRequest
                {
                    Name = txtName.Text,
                    Founded = txtFounded.Text,
                    Origin = txtOrigin.Text,
                    Image = pbArtistImage.Image != null ? ImageHelper.SystemDrawingToByteArray(pbArtistImage.Image) : null
                };
                if (_ID.HasValue)
                {
                    await artistService.Update<MArtist>(_ID.Value, request);
                    MessageBox.Show("Artist updated successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    await artistService.Insert<MArtist>(request);
                    MessageBox.Show("Artist added successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                PanelHelper.SwapPanels(this.Parent, this, new ArtistList());
            }
        }
        bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
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

        private void txtFounded_Validating(object sender, CancelEventArgs e)
        {
            if (IsDigitsOnly(txtFounded.Text) == false)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFounded, "You Can't Use Letters!");
                return;
            }
            else
            {
                errorProvider1.SetError(txtFounded, null);
            }
            if(txtFounded.Text != "") { 
                var founded = Convert.ToInt32(txtFounded.Text);
                if(founded < 1900 || founded > 2020)
                {
                    e.Cancel = true;
                    errorProvider1.SetError(txtFounded, "Enter a year between 1900 and 2020!");
                }
                else
                {
                    errorProvider1.SetError(txtFounded, null);
                }
            }
        }
    }
}

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
using eMusic.WinUI.Forms.Artist;
using eMusic.WinUI.Forms.Genre;
using eMusic.WinUI.Forms.Track;
using eMusic.WinUI.Properties;

namespace eMusic.WinUI.Forms.Album
{
    public partial class AlbumUpsert : UserControl
    {
        private static MAlbum _album = null;
        private readonly int? _ID;
        private readonly APIService albumService = new APIService("Album");
        private readonly APIService trackService = new APIService("Track");
        private readonly APIService artistService = new APIService("Artist");
        private readonly APIService genreService = new APIService("Genre");
        private List<MTrack> albumTracks = new List<MTrack>();
        private List<string> temp = new List<string> { "TrackID", "Name", "Length" };
        public AlbumUpsert(int? ID = null)
        {
            _ID = ID;
            InitializeComponent();
        }
        private async void AlbumUpsert_Load(object sender, EventArgs e)
        {
            var artists = await artistService.Get<List<MArtist>>(null);
            var genres = await genreService.Get<List<MGenre>>(null);

            cbArtist.DataSource = artists;
            cbArtist.ValueMember = "ArtistID";
            cbArtist.DisplayMember = "Name";

            cbGenre.DataSource = genres;
            cbGenre.ValueMember = "GenreID";
            cbGenre.DisplayMember = "Name";

            await LoadListAllTracks();

            if (_ID.HasValue)
            {
                _album = await albumService.GetById<MAlbum>(_ID.Value);

                txtName.Text = _album.Name;
                txtReleaseYear.Text = _album.YearOfRelease.ToString();
                txtPrice.Text = _album.Price.ToString();
                txtAbout.Text = _album.About;

                if (_album.Image.Length > 3)
                {
                    pbAlbumPicture.Image = ImageHelper.ByteArrayToSystemDrawing(_album.Image);
                    pbAlbumPicture.SizeMode = PictureBoxSizeMode.StretchImage;
                }

                cbArtist.SelectedItem = artists.Where(i => i.ArtistID == _album.ArtistID).SingleOrDefault();
                cbGenre.SelectedItem = genres.Where(i => i.GenreID == _album.GenreID).SingleOrDefault();

                albumTracks = await albumService.GetTracks<List<MTrack>>(_ID.Value, null);

                LoadListAlbumTracks();
            }
            else
            {
                DGVHelper.PopulateWithList(dgvAlbumSongs, albumTracks, temp);
            }
        }
        private void LoadListAlbumTracks()
        {
            var list = albumTracks;
            if (list.Count > 0)
            {
                dgvAlbumSongs.ColumnCount = 0;
                dgvAlbumSongs.ReadOnly = true;
                DGVHelper.PopulateWithList(dgvAlbumSongs, list, temp);
            }
        }

        private async Task LoadListAllTracks()
        {
            var list = await trackService.Get<List<MTrack>>(null);
            dgvAllSongs.ReadOnly = true;
            DGVHelper.PopulateWithList(dgvAllSongs, list, temp);
        }
        private async Task LoadListAllTracks(TrackSearchRequest request)
        {
            var list = await trackService.Get<List<MTrack>>(request);
            dgvAllSongs.AutoGenerateColumns = false;
            dgvAllSongs.DataSource = list;
        }

        private void btnUploadPicture_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfd = new OpenFileDialog
            {
                Filter = "Image Files (*.jpg;*.jpeg;.*.gif;)|*.jpg;*.jpeg;.*.gif"
            };
            if (openfd.ShowDialog() == DialogResult.OK)
            {
                pbAlbumPicture.SizeMode = PictureBoxSizeMode.StretchImage;
                pbAlbumPicture.Image = new Bitmap(openfd.FileName);
            }
        }
        private void btnAddSong_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedRow = dgvAllSongs.CurrentRow;
                if (!albumTracks.Select(i => i.TrackID).ToList().Contains(Convert.ToInt32(selectedRow.Cells["TrackID"].Value)))
                {
                    var track = new MTrack()
                    {
                        TrackID = Convert.ToInt32(selectedRow.Cells["TrackID"].Value),
                        Name = Convert.ToString(selectedRow.Cells["Name"].Value),
                        Length = Convert.ToString(selectedRow.Cells["Length"].Value)
                    };
                    albumTracks.Add(track);
                }
                LoadListAlbumTracks();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void btnRemoveSong_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedRow = dgvAlbumSongs.CurrentRow;
                var track = albumTracks.Single(i => i.TrackID == Convert.ToInt32(selectedRow.Cells["TrackID"].Value));
                albumTracks.Remove(track);

                LoadListAlbumTracks();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                var albumTrack = albumTracks.Select(i => i.TrackID).ToList();

                var request = new AlbumUpsertRequest()
                {
                    Name = txtName.Text,
                    YearOfRelease = Convert.ToInt32(txtReleaseYear.Text),
                    ArtistID = Convert.ToInt32(cbArtist.SelectedValue),
                    GenreID = Convert.ToInt32(cbGenre.SelectedValue),
                    Image = ImageHelper.SystemDrawingToByteArray(pbAlbumPicture.Image),
                    NumberOfTracks = albumTrack.Count(),
                    Price = Convert.ToInt32(txtPrice.Text),
                    About = txtAbout.Text,
                    Tracks = albumTrack
                };

                if (_ID.HasValue)
                {
                    var tracksToDelete = _album.AlbumTracks
                        .Where(i => !albumTracks.Any(id => id.TrackID == i.TrackID))
                        .Select(i => i.TrackID)
                        .ToList();

                    request.TracksToDelete = tracksToDelete;

                    await albumService.Update<MAlbum>(_ID.Value, request);

                    MessageBox.Show("Album updated succesfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    PanelHelper.SwapPanels(this.Parent, this, new AlbumList());
                }
                else
                {
                    await albumService.Insert<MAlbum>(request);                                      

                    MessageBox.Show("Album added succesfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    PanelHelper.SwapPanels(this.Parent, this, new AlbumList());
                }                
            }
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            var search = txtSearchAllTracks.Text;

            var request = new TrackSearchRequest()
            {
                Name = search
            };

            await LoadListAllTracks(request);
        }
        private void btnAddArtist_Click(object sender, EventArgs e)
        {
            PanelHelper.SwapPanels(this.Parent, this, new ArtistUpsert());
        }

        private void btnAddGenre_Click(object sender, EventArgs e)
        {
            PanelHelper.SwapPanels(this.Parent, this, new GenreUpsert());
        }

        private void btnAddTrack_Click(object sender, EventArgs e)
        {
            PanelHelper.SwapPanels(this.Parent, this, new TrackUpsert());
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
        bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }
        private void txtReleaseYear_Validating(object sender, CancelEventArgs e)
        {
            string year = txtReleaseYear.Text.ToString();
            if (string.IsNullOrWhiteSpace(txtReleaseYear.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtReleaseYear, Resources.Validation_RequiredField);
            }
            else
            {
                errorProvider1.SetError(txtReleaseYear, null);
                if (IsDigitsOnly(year) == false)
                {
                    e.Cancel = true;
                    errorProvider1.SetError(txtReleaseYear, "You Can't Use Letters!");
                    return;
                }
                else
                {
                    errorProvider1.SetError(txtReleaseYear, null);
                }
            }
            if (txtReleaseYear.Text != "")
            {
                var founded = Convert.ToInt32(txtReleaseYear.Text);
                if (founded < 1900 || founded > 2020)
                {
                    e.Cancel = true;
                    errorProvider1.SetError(txtReleaseYear, "Enter a year between 1900 and 2020!");
                }
                else
                {
                    errorProvider1.SetError(txtReleaseYear, null);
                }
            }
        }

        private void txtPrice_Validating(object sender, CancelEventArgs e)
        {
            string price = txtPrice.Text.ToString();
            if (string.IsNullOrWhiteSpace(txtPrice.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtPrice, Resources.Validation_RequiredField);
            }
            else
            {
                errorProvider1.SetError(txtPrice, null);
                if (IsDigitsOnly(price) == false)
                {
                    e.Cancel = true;
                    errorProvider1.SetError(txtPrice, "You Can't Use Letters as a Price!");
                }
                else
                {
                    errorProvider1.SetError(txtPrice, null);
                }
            }
        }       
    }
}

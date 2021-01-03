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

namespace eMusic.WinUI.Forms.Playlist
{
    public partial class PlaylistUpsert : UserControl
    {
        private static MPlaylist _playlist = null;
        private readonly int? ID;
        private readonly APIService playlistService = new APIService("Playlist");
        private readonly APIService trackService = new APIService("Track");
        private readonly List<string> temp = new List<string> { "TrackID", "Name", "Length" };
        private List<MTrack> playlistTracks = new List<MTrack>();
        public PlaylistUpsert(int? _ID = null)
        {
            ID = _ID;
            InitializeComponent();
        }

        private async void PlaylistUpsert_Load(object sender, EventArgs e)
        {
            await LoadListTracks();

            if (ID.HasValue)
            {
                _playlist = await playlistService.GetById<MPlaylist>(ID.Value);

                txtName.Text = _playlist.Name;
                txtUser.Text = _playlist.User.Username;

                if (_playlist.Image.Length > 3)
                {
                    pbPlaylistPicture.Image = ImageHelper.ByteArrayToSystemDrawing(_playlist.Image);
                    pbPlaylistPicture.SizeMode = PictureBoxSizeMode.StretchImage;
                }

                playlistTracks = await playlistService.GetTracks<List<MTrack>>(ID.Value, null);

                LoadListPlaylistTracks();
            }
            else
            {
                DGVHelper.PopulateWithList(dgvPlaylistTracks, playlistTracks, temp);
            }
        }
        private void LoadListPlaylistTracks()
        {
            var list = playlistTracks;
            if (list.Count > 0)
            {
                dgvPlaylistTracks.ColumnCount = 0;
                dgvPlaylistTracks.ReadOnly = true;
                DGVHelper.PopulateWithList(dgvPlaylistTracks, list, temp);
            }
        }
        private async Task LoadListTracks()
        {
            var list = await trackService.Get<List<MTrack>>(null);
            dgvAllTracks.ReadOnly = true;
            DGVHelper.PopulateWithList(dgvAllTracks, list, temp);
        }
        private async Task LoadListTracks(TrackSearchRequest request)
        {
            var list = await trackService.Get<List<MTrack>>(request);
            dgvAllTracks.AutoGenerateColumns = false;
            dgvAllTracks.DataSource = list;
        }

        private void btnUploadPicture_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfd = new OpenFileDialog
            {
                Filter = "Image Files (*.jpg;*.jpeg;.*.gif;)|*.jpg;*.jpeg;.*.gif"
            };
            if (openfd.ShowDialog() == DialogResult.OK)
            {
                pbPlaylistPicture.SizeMode = PictureBoxSizeMode.StretchImage;
                pbPlaylistPicture.Image = new Bitmap(openfd.FileName);
            }
        }

        private void btnAddTrack_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedRow = dgvAllTracks.CurrentRow;
                if (!playlistTracks.Select(i => i.TrackID).ToList().Contains(Convert.ToInt32(selectedRow.Cells["TrackID"].Value)))
                {
                    var track = new MTrack()
                    {
                        TrackID = Convert.ToInt32(selectedRow.Cells["TrackID"].Value),
                        Name = Convert.ToString(selectedRow.Cells["Name"].Value),
                        Length = Convert.ToString(selectedRow.Cells["Length"].Value)
                    };
                    playlistTracks.Add(track);

                    LoadListPlaylistTracks();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void btnRemoveTrack_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedRow = dgvPlaylistTracks.CurrentRow;

                var track = playlistTracks.Single(i => i.TrackID == Convert.ToInt32(selectedRow.Cells["TrackID"].Value));
                playlistTracks.Remove(track);

                LoadListPlaylistTracks();
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
                var playlistTrack = playlistTracks.Select(i => i.TrackID).ToList();

                var request = new PlaylistUpsertRequest
                {
                    Name = txtName.Text,
                    Image = ImageHelper.SystemDrawingToByteArray(pbPlaylistPicture.Image),
                    Tracks = playlistTrack,
                };

                if (ID.HasValue)
                {
                    var tracksToDelete = _playlist.PlaylistTracks
                        .Where(i => !playlistTracks.Any(id => id.TrackID == i.TrackID))
                        .Select(i => i.TrackID)
                        .ToList();

                    request.TracksToDelete = tracksToDelete;
                    request.UserID = _playlist.UserID;
                    request.Username = _playlist.User.Username;
                    request.CreatedAt = _playlist.CreatedAt;

                    await playlistService.Update<MPlaylist>(ID.Value, request);
                    MessageBox.Show("Playlist Updated Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    PanelHelper.SwapPanels(this.Parent, this, new PlaylistList());
                }
                else
                {
                    request.CreatedAt = DateTime.Now.ToString();
                    request.UserID = SignedInUser.User.UserID;
                    request.Username = SignedInUser.User.Username;
                    await playlistService.Insert<MPlaylist>(request);
                    MessageBox.Show("Playlist Added Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    PanelHelper.SwapPanels(this.Parent, this, new PlaylistList());
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

            await LoadListTracks(request);
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
    }
}

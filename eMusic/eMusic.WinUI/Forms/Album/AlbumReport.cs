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

namespace eMusic.WinUI.Forms.Album
{
    public partial class AlbumReport : UserControl
    {
        private List<MAlbum> _source;
        public AlbumReport(List<MAlbum> source)
        {
            _source = source;
            InitializeComponent();
        }

        private void AlbumReport_Load(object sender, EventArgs e)
        {
            albumListVMBindingSource.DataSource = _source;
            this.rptAlbum.RefreshReport();
        }
    }
}

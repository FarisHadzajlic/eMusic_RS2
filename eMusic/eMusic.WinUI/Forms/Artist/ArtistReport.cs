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

namespace eMusic.WinUI.Forms.Artist
{
    public partial class ArtistReport : UserControl
    {
        private List<MArtist> _source;
        public ArtistReport(List<MArtist> source)
        {
            _source = source;
            InitializeComponent();
        }

        private void ArtistReport_Load(object sender, EventArgs e)
        {
            artistListVMBindingSource.DataSource = _source;
            this.rptArtist.RefreshReport();
        }
    }
}

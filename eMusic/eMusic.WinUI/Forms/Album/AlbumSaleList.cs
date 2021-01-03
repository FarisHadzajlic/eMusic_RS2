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
using System.Data.SqlClient;
using System.Data.SqlServerCe;

namespace eMusic.WinUI.Forms.Album
{
    public partial class AlbumSaleList : UserControl
    {
        private readonly APIService buyalbumService = new APIService("BuyAlbum");
        SqlConnection con = new SqlConnection("Server=.;Database=150140;Trusted_Connection=true;MultipleActiveResultSets=true;");
        public AlbumSaleList()
        {
            InitializeComponent();
        }

        private async void AlbumSaleList_Load(object sender, EventArgs e)
        {
            await LoadAlbums();
        }
        async Task LoadAlbums()
        {
            var albums = await buyalbumService.Get<List<MBuyAlbum>>(null);

            dgvAlbumSale.AutoGenerateColumns = false;
            dgvAlbumSale.ReadOnly = true;
            dgvAlbumSale.DataSource = albums; 
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {            
            SqlDataAdapter search = new SqlDataAdapter("SELECT * FROM BuyAlbums where DateOfBuying between '" + dtpFrom.Value.ToString("MM/dd/yyyy") + "' And '" + dtpTo.Value.ToString("MM/dd/yyyy") + "'", con);
            DataTable dt = new DataTable();
            search.Fill(dt);
            dgvAlbumSale.DataSource = dt;
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            var datefrom = Convert.ToDateTime(dtpFrom.Value);
            var dateto = Convert.ToDateTime(dtpTo.Value);         
            PanelHelper.SwapPanels(this.Parent, this, new AlbumSaleByDateReport(datefrom, dateto));
        }
    }
}

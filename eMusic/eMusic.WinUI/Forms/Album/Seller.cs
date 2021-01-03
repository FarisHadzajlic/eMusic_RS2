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

namespace eMusic.WinUI.Forms.Album
{
    public partial class Seller : UserControl
    {
        private readonly APIService buyalbumService = new APIService("BuyAlbum");
        public Seller()
        {
            InitializeComponent();
        }

        private async void Seller_Load(object sender, EventArgs e)
        {
            await LoadAlbums();
        }

        async Task LoadAlbums()
        {
            var albums = await buyalbumService.Get<List<MBuyAlbum>>(null);
            
            dgvSeller.AutoGenerateColumns = false;
            dgvSeller.ReadOnly = true;
            dgvSeller.DataSource = albums;

        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            PanelHelper.SwapPanels(this.Parent, this, new BestSellerReport());
        }
    }
}

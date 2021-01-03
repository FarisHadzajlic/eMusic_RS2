using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using eMusic.Model.Request;
using eMusic.Model;
using Microsoft.Reporting.WinForms;

namespace eMusic.WinUI.Forms.Album
{
    public partial class AlbumSaleByDateReport : UserControl
    {
        private DateTime _datefrom;
        private DateTime _dateto;
        private readonly APIService albumbuyService = new APIService("BuyAlbum");
        public AlbumSaleByDateReport(DateTime datefrom, DateTime dateto)
        {
            _datefrom = datefrom;
            _dateto = dateto;
            InitializeComponent();
        }

        private async void AlbumSaleByDateReport_Load(object sender, EventArgs e)
        {
            var request = new BuyAlbumSearchRequest
            {
                From = _datefrom,
                To = _dateto
            };

            var albums = await albumbuyService.Get<List<MBuyAlbum>>(request);     
            this.rptSale.LocalReport.SetParameters(new ReportParameter("From", _datefrom.ToString("dd/MM/yyyy")));
            this.rptSale.LocalReport.SetParameters(new ReportParameter("To", _dateto.ToString("dd/MM/yyyy")));

            sellerVMBindingSource.DataSource = albums;
            this.rptSale.RefreshReport();
        }
    }
}

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

namespace eMusic.WinUI.Forms.User
{
    public partial class UserReport : UserControl
    {
        private List<MUser> _source;
        public UserReport(List<MUser> source)
        {
            _source = source;
            InitializeComponent();
        }

        private void UserReport_Load(object sender, EventArgs e)
        {
            userListVMBindingSource1.DataSource = _source;
            this.rptUsers.RefreshReport();
        }
    }
}

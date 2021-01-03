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

namespace eMusic.WinUI.Forms.User
{
    public partial class UserList : UserControl
    {
        private readonly APIService userService = new APIService("User");
        public UserList()
        {
            InitializeComponent();
        }

        private async void UserList_Load(object sender, EventArgs e)
        {
            await LoadList();
        }
        private async Task LoadList()
        {
            var result = await userService.Get<List<MUser>>(null);

            dgvUsers.AutoGenerateColumns = false;
            dgvUsers.ReadOnly = true;
            dgvUsers.DataSource = result;
        }
        private async Task LoadList(UserSearchRequest request)
        {
            var result = await userService.Get<List<MUser>>(request);

            dgvUsers.AutoGenerateColumns = false;
            dgvUsers.ReadOnly = true;
            dgvUsers.DataSource = result;
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            var search = txtSearch.Text;
            if (search.StartsWith("Enter"))
            {
                search = "";
            }
            var request = new UserSearchRequest()
            {
                Username = search
            };
            await LoadList(request);
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            txtSearch.Clear();
            txtSearch.ForeColor = Color.Black;
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (txtSearch.Text == "")
            {
                txtSearch.Text = "Enter Username";
                txtSearch.ForeColor = Color.Silver;
            }
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            PanelHelper.SwapPanels(this.Parent, this, new UserAdd());
        }

        private void btnDetails_Click(object sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow != null)
            {
                int ID = Convert.ToInt32(dgvUsers.CurrentRow.Cells["UserID"].Value);
                PanelHelper.SwapPanels(this.Parent, this, new UserEdit(ID));
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow != null)
            {
                bool result = false;
                int ID = Convert.ToInt32(dgvUsers.CurrentRow.Cells["UserID"].Value);
                
                if (MessageBox.Show("Do you really want to delete this user?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (SignedInUser.User.UserID == ID)
                    {
                        MessageBox.Show("You can't delete yourself :-)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    result = await userService.Delete<dynamic>(ID);
                }
                if (result == true)
                {
                    MessageBox.Show("You have deleted user successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                PanelHelper.SwapPanels(this.Parent, this, new UserList());
            }
        }

        private void btnUserReport_Click(object sender, EventArgs e)
        {
            PanelHelper.SwapPanels(this.Parent, this, new UserReport(dgvUsers.DataSource as List<MUser>));
        }
    }
}

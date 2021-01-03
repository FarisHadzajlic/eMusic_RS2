namespace eMusic.WinUI.Forms.User
{
    partial class UserReport
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.userListVMBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rptUsers = new Microsoft.Reporting.WinForms.ReportViewer();
            this.mUserBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.userListVMBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.userListVMBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mUserBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userListVMBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // rptUsers
            // 
            reportDataSource1.Name = "DataSetUser";
            reportDataSource1.Value = this.userListVMBindingSource1;
            this.rptUsers.LocalReport.DataSources.Add(reportDataSource1);
            this.rptUsers.LocalReport.ReportEmbeddedResource = "eMusic.WinUI.Reports.UserReport.rdlc";
            this.rptUsers.Location = new System.Drawing.Point(28, 17);
            this.rptUsers.Name = "rptUsers";
            this.rptUsers.ServerReport.BearerToken = null;
            this.rptUsers.Size = new System.Drawing.Size(630, 382);
            this.rptUsers.TabIndex = 0;
            // 
            // mUserBindingSource
            // 
            this.mUserBindingSource.DataSource = typeof(eMusic.Model.MUser);
            // 
            // userListVMBindingSource1
            // 
            this.userListVMBindingSource1.DataSource = typeof(eMusic.Model.ViewModels.UserListVM);
            // 
            // UserReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.rptUsers);
            this.Name = "UserReport";
            this.Size = new System.Drawing.Size(714, 439);
            this.Load += new System.EventHandler(this.UserReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.userListVMBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mUserBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userListVMBindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rptUsers;
        private System.Windows.Forms.BindingSource userListVMBindingSource;
        private System.Windows.Forms.BindingSource mUserBindingSource;
        private System.Windows.Forms.BindingSource userListVMBindingSource1;
    }
}

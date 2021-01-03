namespace eMusic.WinUI.Forms.Album
{
    partial class AlbumReport
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
            this.albumListVMBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rptAlbum = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.albumListVMBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // albumListVMBindingSource
            // 
            this.albumListVMBindingSource.DataSource = typeof(eMusic.Model.ViewModels.AlbumListVM);
            // 
            // rptAlbum
            // 
            reportDataSource1.Name = "DataSetAlbum";
            reportDataSource1.Value = this.albumListVMBindingSource;
            this.rptAlbum.LocalReport.DataSources.Add(reportDataSource1);
            this.rptAlbum.LocalReport.ReportEmbeddedResource = "eMusic.WinUI.Reports.AlbumReport.rdlc";
            this.rptAlbum.Location = new System.Drawing.Point(24, 80);
            this.rptAlbum.Name = "rptAlbum";
            this.rptAlbum.ServerReport.BearerToken = null;
            this.rptAlbum.Size = new System.Drawing.Size(641, 299);
            this.rptAlbum.TabIndex = 0;
            // 
            // AlbumReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.rptAlbum);
            this.Name = "AlbumReport";
            this.Size = new System.Drawing.Size(701, 403);
            this.Load += new System.EventHandler(this.AlbumReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.albumListVMBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rptAlbum;
        private System.Windows.Forms.BindingSource albumListVMBindingSource;
    }
}

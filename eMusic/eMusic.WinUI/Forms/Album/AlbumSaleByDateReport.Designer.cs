namespace eMusic.WinUI.Forms.Album
{
    partial class AlbumSaleByDateReport
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
            this.sellerVMBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rptSale = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.sellerVMBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // sellerVMBindingSource
            // 
            this.sellerVMBindingSource.DataSource = typeof(eMusic.Model.ViewModels.SellerVM);
            // 
            // rptSale
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.sellerVMBindingSource;
            this.rptSale.LocalReport.DataSources.Add(reportDataSource1);
            this.rptSale.LocalReport.ReportEmbeddedResource = "eMusic.WinUI.Reports.AlbumSaleReport.rdlc";
            this.rptSale.Location = new System.Drawing.Point(13, 49);
            this.rptSale.Name = "rptSale";
            this.rptSale.ServerReport.BearerToken = null;
            this.rptSale.Size = new System.Drawing.Size(638, 289);
            this.rptSale.TabIndex = 0;
            // 
            // AlbumSaleByDateReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.rptSale);
            this.Name = "AlbumSaleByDateReport";
            this.Size = new System.Drawing.Size(699, 407);
            this.Load += new System.EventHandler(this.AlbumSaleByDateReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sellerVMBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rptSale;
        private System.Windows.Forms.BindingSource sellerVMBindingSource;
    }
}

namespace eMusic.WinUI.Forms.Album
{
    partial class BestSellerReport
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
            this.rptBestSeller = new Microsoft.Reporting.WinForms.ReportViewer();
            this.bestSellerVMBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.bestSellerVMBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // rptBestSeller
            // 
            reportDataSource1.Name = "DataSetBestSeller";
            reportDataSource1.Value = this.bestSellerVMBindingSource;
            this.rptBestSeller.LocalReport.DataSources.Add(reportDataSource1);
            this.rptBestSeller.LocalReport.ReportEmbeddedResource = "eMusic.WinUI.Reports.BestSellerReport.rdlc";
            this.rptBestSeller.Location = new System.Drawing.Point(20, 61);
            this.rptBestSeller.Name = "rptBestSeller";
            this.rptBestSeller.ServerReport.BearerToken = null;
            this.rptBestSeller.Size = new System.Drawing.Size(640, 259);
            this.rptBestSeller.TabIndex = 0;
            // 
          
            // 
            // BestSellerReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.rptBestSeller);
            this.Name = "BestSellerReport";
            this.Size = new System.Drawing.Size(685, 381);
            this.Load += new System.EventHandler(this.BestSellerReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bestSellerVMBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rptBestSeller;
        private System.Windows.Forms.BindingSource bestSellerVMBindingSource;
    }
}

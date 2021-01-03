namespace eMusic.WinUI.Forms.Artist
{
    partial class ArtistReport
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
            this.artistListVMBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rptArtist = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.artistListVMBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // artistListVMBindingSource
            // 
            this.artistListVMBindingSource.DataSource = typeof(eMusic.Model.ViewModels.ArtistListVM);
            // 
            // rptArtist
            // 
            reportDataSource1.Name = "DataSetArtist";
            reportDataSource1.Value = this.artistListVMBindingSource;
            this.rptArtist.LocalReport.DataSources.Add(reportDataSource1);
            this.rptArtist.LocalReport.ReportEmbeddedResource = "eMusic.WinUI.Reports.ArtistReport.rdlc";
            this.rptArtist.Location = new System.Drawing.Point(23, 37);
            this.rptArtist.Name = "rptArtist";
            this.rptArtist.ServerReport.BearerToken = null;
            this.rptArtist.Size = new System.Drawing.Size(641, 331);
            this.rptArtist.TabIndex = 0;
            // 
            // ArtistReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.rptArtist);
            this.Name = "ArtistReport";
            this.Size = new System.Drawing.Size(682, 400);
            this.Load += new System.EventHandler(this.ArtistReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.artistListVMBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rptArtist;
        private System.Windows.Forms.BindingSource artistListVMBindingSource;
    }
}

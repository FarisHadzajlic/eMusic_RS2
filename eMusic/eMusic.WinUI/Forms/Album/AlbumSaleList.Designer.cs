namespace eMusic.WinUI.Forms.Album
{
    partial class AlbumSaleList
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
            this.dgvAlbumSale = new System.Windows.Forms.DataGridView();
            this.AlbumName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Username = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateOfBuying = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.btnSearch = new System.Windows.Forms.Button();
            this.From = new System.Windows.Forms.Label();
            this.To = new System.Windows.Forms.Label();
            this.btnReport = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlbumSale)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvAlbumSale
            // 
            this.dgvAlbumSale.AllowUserToAddRows = false;
            this.dgvAlbumSale.AllowUserToDeleteRows = false;
            this.dgvAlbumSale.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAlbumSale.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvAlbumSale.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAlbumSale.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AlbumName,
            this.Username,
            this.DateOfBuying,
            this.Price});
            this.dgvAlbumSale.Location = new System.Drawing.Point(53, 118);
            this.dgvAlbumSale.Name = "dgvAlbumSale";
            this.dgvAlbumSale.ReadOnly = true;
            this.dgvAlbumSale.RowTemplate.Height = 30;
            this.dgvAlbumSale.Size = new System.Drawing.Size(575, 254);
            this.dgvAlbumSale.TabIndex = 0;
            // 
            // AlbumName
            // 
            this.AlbumName.DataPropertyName = "AlbumName";
            this.AlbumName.HeaderText = "Album";
            this.AlbumName.Name = "AlbumName";
            this.AlbumName.ReadOnly = true;
            // 
            // Username
            // 
            this.Username.DataPropertyName = "Username";
            this.Username.HeaderText = "Buyer";
            this.Username.Name = "Username";
            this.Username.ReadOnly = true;
            // 
            // DateOfBuying
            // 
            this.DateOfBuying.DataPropertyName = "DateOfBuying";
            this.DateOfBuying.HeaderText = "Date Of Buy";
            this.DateOfBuying.Name = "DateOfBuying";
            this.DateOfBuying.ReadOnly = true;
            // 
            // Price
            // 
            this.Price.DataPropertyName = "Price";
            this.Price.HeaderText = "Price";
            this.Price.Name = "Price";
            this.Price.ReadOnly = true;
            // 
            // dtpFrom
            // 
            this.dtpFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFrom.Location = new System.Drawing.Point(53, 50);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(235, 26);
            this.dtpFrom.TabIndex = 2;
            // 
            // dtpTo
            // 
            this.dtpTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTo.Location = new System.Drawing.Point(386, 50);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(242, 26);
            this.dtpTo.TabIndex = 3;
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(524, 82);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(104, 30);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // From
            // 
            this.From.AutoSize = true;
            this.From.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.From.Location = new System.Drawing.Point(50, 29);
            this.From.Name = "From";
            this.From.Size = new System.Drawing.Size(44, 18);
            this.From.TabIndex = 5;
            this.From.Text = "From";
            // 
            // To
            // 
            this.To.AutoSize = true;
            this.To.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.To.Location = new System.Drawing.Point(383, 29);
            this.To.Name = "To";
            this.To.Size = new System.Drawing.Size(26, 18);
            this.To.TabIndex = 6;
            this.To.Text = "To";
            // 
            // btnReport
            // 
            this.btnReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReport.Location = new System.Drawing.Point(502, 378);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(126, 27);
            this.btnReport.TabIndex = 7;
            this.btnReport.Text = "Create Report";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // AlbumSaleList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.To);
            this.Controls.Add(this.From);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.dtpTo);
            this.Controls.Add(this.dtpFrom);
            this.Controls.Add(this.dgvAlbumSale);
            this.Name = "AlbumSaleList";
            this.Size = new System.Drawing.Size(699, 495);
            this.Load += new System.EventHandler(this.AlbumSaleList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlbumSale)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvAlbumSale;
        private System.Windows.Forms.DataGridViewTextBoxColumn AlbumName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Username;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateOfBuying;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label From;
        private System.Windows.Forms.Label To;
        private System.Windows.Forms.Button btnReport;
    }
}

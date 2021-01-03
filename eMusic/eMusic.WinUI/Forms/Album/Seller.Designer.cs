namespace eMusic.WinUI.Forms.Album
{
    partial class Seller
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
            this.dgvSeller = new System.Windows.Forms.DataGridView();
            this.AlbumName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateOfBuying = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Username = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnReport = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSeller)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvSeller
            // 
            this.dgvSeller.AllowUserToAddRows = false;
            this.dgvSeller.AllowUserToDeleteRows = false;
            this.dgvSeller.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSeller.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSeller.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AlbumName,
            this.DateOfBuying,
            this.Username,
            this.Price});
            this.dgvSeller.Location = new System.Drawing.Point(39, 69);
            this.dgvSeller.Name = "dgvSeller";
            this.dgvSeller.ReadOnly = true;
            this.dgvSeller.Size = new System.Drawing.Size(494, 227);
            this.dgvSeller.TabIndex = 0;
            // 
            // AlbumName
            // 
            this.AlbumName.DataPropertyName = "AlbumName";
            this.AlbumName.HeaderText = "Album ";
            this.AlbumName.Name = "AlbumName";
            this.AlbumName.ReadOnly = true;
            // 
            // DateOfBuying
            // 
            this.DateOfBuying.DataPropertyName = "DateOfBuying";
            this.DateOfBuying.HeaderText = "Date of Buy";
            this.DateOfBuying.Name = "DateOfBuying";
            this.DateOfBuying.ReadOnly = true;
            // 
            // Username
            // 
            this.Username.DataPropertyName = "Username";
            this.Username.HeaderText = "Buyer";
            this.Username.Name = "Username";
            this.Username.ReadOnly = true;
            // 
            // Price
            // 
            this.Price.DataPropertyName = "Price";
            this.Price.HeaderText = "Price";
            this.Price.Name = "Price";
            this.Price.ReadOnly = true;
            // 
            // btnReport
            // 
            this.btnReport.Location = new System.Drawing.Point(417, 302);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(116, 28);
            this.btnReport.TabIndex = 1;
            this.btnReport.Text = "Create Report";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // Seller
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.dgvSeller);
            this.Name = "Seller";
            this.Size = new System.Drawing.Size(567, 379);
            this.Load += new System.EventHandler(this.Seller_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSeller)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvSeller;
        private System.Windows.Forms.DataGridViewTextBoxColumn AlbumName;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateOfBuying;
        private System.Windows.Forms.DataGridViewTextBoxColumn Username;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.Button btnReport;
    }
}

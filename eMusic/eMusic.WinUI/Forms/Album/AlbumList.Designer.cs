namespace eMusic.WinUI.Forms.Album
{
    partial class AlbumList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AlbumList));
            this.dgvAlbums = new System.Windows.Forms.DataGridView();
            this.AlbumId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.YearOfRelease = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumberOfTracks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAddAlbum = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnDetails = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnReport = new System.Windows.Forms.Button();
            this.cbGenreList = new System.Windows.Forms.ComboBox();
            this.btnSeller = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlbums)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvAlbums
            // 
            this.dgvAlbums.AllowUserToAddRows = false;
            this.dgvAlbums.AllowUserToDeleteRows = false;
            this.dgvAlbums.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAlbums.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvAlbums.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAlbums.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AlbumId,
            this.Name,
            this.YearOfRelease,
            this.NumberOfTracks,
            this.Price});
            this.dgvAlbums.Location = new System.Drawing.Point(78, 108);
            this.dgvAlbums.Name = "dgvAlbums";
            this.dgvAlbums.ReadOnly = true;
            this.dgvAlbums.RowTemplate.Height = 30;
            this.dgvAlbums.Size = new System.Drawing.Size(556, 237);
            this.dgvAlbums.TabIndex = 21;
            // 
            // AlbumId
            // 
            this.AlbumId.DataPropertyName = "AlbumId";
            this.AlbumId.HeaderText = "AlbumId";
            this.AlbumId.Name = "AlbumId";
            this.AlbumId.ReadOnly = true;
            this.AlbumId.Visible = false;
            // 
            // Name
            // 
            this.Name.DataPropertyName = "Name";
            this.Name.HeaderText = "Name";
            this.Name.Name = "Name";
            this.Name.ReadOnly = true;
            // 
            // YearOfRelease
            // 
            this.YearOfRelease.DataPropertyName = "YearOfRelease";
            this.YearOfRelease.HeaderText = "Release Year";
            this.YearOfRelease.Name = "YearOfRelease";
            this.YearOfRelease.ReadOnly = true;
            // 
            // NumberOfTracks
            // 
            this.NumberOfTracks.DataPropertyName = "NumberOfTracks";
            this.NumberOfTracks.HeaderText = "Tracks";
            this.NumberOfTracks.Name = "NumberOfTracks";
            this.NumberOfTracks.ReadOnly = true;
            // 
            // Price
            // 
            this.Price.DataPropertyName = "Price";
            this.Price.HeaderText = "Price $";
            this.Price.Name = "Price";
            this.Price.ReadOnly = true;
            // 
            // btnAddAlbum
            // 
            this.btnAddAlbum.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddAlbum.Image = ((System.Drawing.Image)(resources.GetObject("btnAddAlbum.Image")));
            this.btnAddAlbum.Location = new System.Drawing.Point(496, 67);
            this.btnAddAlbum.Name = "btnAddAlbum";
            this.btnAddAlbum.Size = new System.Drawing.Size(42, 36);
            this.btnAddAlbum.TabIndex = 20;
            this.btnAddAlbum.UseVisualStyleBackColor = true;
            this.btnAddAlbum.Click += new System.EventHandler(this.btnAddAlbum_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.Location = new System.Drawing.Point(592, 67);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(42, 36);
            this.btnDelete.TabIndex = 19;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnDetails
            // 
            this.btnDetails.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDetails.Image = ((System.Drawing.Image)(resources.GetObject("btnDetails.Image")));
            this.btnDetails.Location = new System.Drawing.Point(544, 67);
            this.btnDetails.Name = "btnDetails";
            this.btnDetails.Size = new System.Drawing.Size(42, 36);
            this.btnDetails.TabIndex = 18;
            this.btnDetails.UseVisualStyleBackColor = true;
            this.btnDetails.Click += new System.EventHandler(this.btnDetails_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.Location = new System.Drawing.Point(301, 72);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(30, 26);
            this.btnSearch.TabIndex = 17;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(78, 72);
            this.txtSearch.Multiline = true;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(217, 25);
            this.txtSearch.TabIndex = 16;
            // 
            // btnReport
            // 
            this.btnReport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReport.Location = new System.Drawing.Point(512, 351);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(122, 33);
            this.btnReport.TabIndex = 22;
            this.btnReport.Text = "Create Report";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // cbGenreList
            // 
            this.cbGenreList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGenreList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbGenreList.FormattingEnabled = true;
            this.cbGenreList.Location = new System.Drawing.Point(337, 71);
            this.cbGenreList.Name = "cbGenreList";
            this.cbGenreList.Size = new System.Drawing.Size(153, 28);
            this.cbGenreList.TabIndex = 23;
            this.cbGenreList.SelectedIndexChanged += new System.EventHandler(this.cbGenreList_SelectedIndexChanged);
            // 
            // btnSeller
            // 
            this.btnSeller.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSeller.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSeller.Location = new System.Drawing.Point(78, 351);
            this.btnSeller.Name = "btnSeller";
            this.btnSeller.Size = new System.Drawing.Size(428, 33);
            this.btnSeller.TabIndex = 24;
            this.btnSeller.Text = "Sales";
            this.btnSeller.UseVisualStyleBackColor = true;
            this.btnSeller.Click += new System.EventHandler(this.btnSeller_Click);
            // 
            // AlbumList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnSeller);
            this.Controls.Add(this.cbGenreList);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.dgvAlbums);
            this.Controls.Add(this.btnAddAlbum);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnDetails);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearch);
            this.Size = new System.Drawing.Size(687, 418);
            this.Load += new System.EventHandler(this.AlbumList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlbums)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvAlbums;
        private System.Windows.Forms.DataGridViewTextBoxColumn AlbumId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn YearOfRelease;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumberOfTracks;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.Button btnAddAlbum;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnDetails;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.ComboBox cbGenreList;
        private System.Windows.Forms.Button btnSeller;
    }
}

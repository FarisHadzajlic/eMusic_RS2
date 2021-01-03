namespace eMusic.WinUI.Forms.Artist
{
    partial class ArtistList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ArtistList));
            this.dgvArtists = new System.Windows.Forms.DataGridView();
            this.ArtistID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Founded = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Origin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAddUser = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnReport = new System.Windows.Forms.Button();
            this.btnDetails = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArtists)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvArtists
            // 
            this.dgvArtists.AllowUserToAddRows = false;
            this.dgvArtists.AllowUserToDeleteRows = false;
            this.dgvArtists.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvArtists.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvArtists.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvArtists.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ArtistID,
            this.Name,
            this.Founded,
            this.Origin});
            this.dgvArtists.Location = new System.Drawing.Point(91, 103);
            this.dgvArtists.Name = "dgvArtists";
            this.dgvArtists.ReadOnly = true;
            this.dgvArtists.RowTemplate.Height = 30;
            this.dgvArtists.Size = new System.Drawing.Size(484, 221);
            this.dgvArtists.TabIndex = 10;
            // 
            // ArtistID
            // 
            this.ArtistID.DataPropertyName = "ArtistID";
            this.ArtistID.HeaderText = "ArtistID";
            this.ArtistID.Name = "ArtistID";
            this.ArtistID.ReadOnly = true;
            this.ArtistID.Visible = false;
            // 
            // Name
            // 
            this.Name.DataPropertyName = "Name";
            this.Name.HeaderText = "Name";
            this.Name.Name = "Name";
            this.Name.ReadOnly = true;
            // 
            // Founded
            // 
            this.Founded.DataPropertyName = "Founded";
            this.Founded.HeaderText = "Founded";
            this.Founded.Name = "Founded";
            this.Founded.ReadOnly = true;
            // 
            // Origin
            // 
            this.Origin.DataPropertyName = "Origin";
            this.Origin.HeaderText = "Origin";
            this.Origin.Name = "Origin";
            this.Origin.ReadOnly = true;
            // 
            // btnAddUser
            // 
            this.btnAddUser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddUser.Image = ((System.Drawing.Image)(resources.GetObject("btnAddUser.Image")));
            this.btnAddUser.Location = new System.Drawing.Point(438, 60);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(42, 37);
            this.btnAddUser.TabIndex = 15;
            this.btnAddUser.UseVisualStyleBackColor = true;
            this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(91, 64);
            this.txtSearch.Multiline = true;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(190, 25);
            this.txtSearch.TabIndex = 11;
            // 
            // btnDelete
            // 
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.Location = new System.Drawing.Point(533, 60);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(42, 37);
            this.btnDelete.TabIndex = 14;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.Location = new System.Drawing.Point(287, 64);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(30, 25);
            this.btnSearch.TabIndex = 12;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnReport
            // 
            this.btnReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReport.Location = new System.Drawing.Point(460, 330);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(115, 28);
            this.btnReport.TabIndex = 16;
            this.btnReport.Text = "Create Report";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // btnDetails
            // 
            this.btnDetails.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDetails.Image = ((System.Drawing.Image)(resources.GetObject("btnDetails.Image")));
            this.btnDetails.Location = new System.Drawing.Point(486, 60);
            this.btnDetails.Name = "btnDetails";
            this.btnDetails.Size = new System.Drawing.Size(41, 37);
            this.btnDetails.TabIndex = 17;
            this.btnDetails.UseVisualStyleBackColor = true;
            this.btnDetails.Click += new System.EventHandler(this.btnDetails_Click);
            // 
            // ArtistList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnDetails);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.dgvArtists);
            this.Controls.Add(this.btnAddUser);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSearch);
            this.Size = new System.Drawing.Size(634, 414);
            this.Load += new System.EventHandler(this.ArtistUpsert_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvArtists)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvArtists;
        private System.Windows.Forms.Button btnAddUser;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Button btnDetails;
        private System.Windows.Forms.DataGridViewTextBoxColumn ArtistID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Founded;
        private System.Windows.Forms.DataGridViewTextBoxColumn Origin;
    }
}

namespace eMusic.WinUI.Forms.Playlist
{
    partial class PlaylistList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlaylistList));
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnDetails = new System.Windows.Forms.Button();
            this.dgvPlaylist = new System.Windows.Forms.DataGridView();
            this.PlaylistId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Username = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlaylist)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDelete
            // 
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.Location = new System.Drawing.Point(536, 63);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(46, 36);
            this.btnDelete.TabIndex = 12;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnDetails
            // 
            this.btnDetails.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDetails.Image = ((System.Drawing.Image)(resources.GetObject("btnDetails.Image")));
            this.btnDetails.Location = new System.Drawing.Point(484, 63);
            this.btnDetails.Name = "btnDetails";
            this.btnDetails.Size = new System.Drawing.Size(46, 36);
            this.btnDetails.TabIndex = 11;
            this.btnDetails.UseVisualStyleBackColor = true;
            this.btnDetails.Click += new System.EventHandler(this.btnDetails_Click);
            // 
            // dgvPlaylist
            // 
            this.dgvPlaylist.AllowUserToAddRows = false;
            this.dgvPlaylist.AllowUserToDeleteRows = false;
            this.dgvPlaylist.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPlaylist.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvPlaylist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPlaylist.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PlaylistId,
            this.Name,
            this.Username});
            this.dgvPlaylist.Location = new System.Drawing.Point(133, 105);
            this.dgvPlaylist.Name = "dgvPlaylist";
            this.dgvPlaylist.ReadOnly = true;
            this.dgvPlaylist.RowTemplate.Height = 30;
            this.dgvPlaylist.Size = new System.Drawing.Size(449, 225);
            this.dgvPlaylist.TabIndex = 10;
            // 
            // PlaylistId
            // 
            this.PlaylistId.DataPropertyName = "PlaylistId";
            this.PlaylistId.HeaderText = "PlaylistId";
            this.PlaylistId.Name = "PlaylistId";
            this.PlaylistId.ReadOnly = true;
            this.PlaylistId.Visible = false;
            // 
            // Name
            // 
            this.Name.DataPropertyName = "Name";
            this.Name.HeaderText = "Name";
            this.Name.Name = "Name";
            this.Name.ReadOnly = true;
            // 
            // Username
            // 
            this.Username.DataPropertyName = "Username";
            this.Username.HeaderText = "Username";
            this.Username.Name = "Username";
            this.Username.ReadOnly = true;
            // 
            // PlaylistList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnDetails);
            this.Controls.Add(this.dgvPlaylist);
            this.Size = new System.Drawing.Size(674, 390);
            this.Load += new System.EventHandler(this.PlaylistList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlaylist)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnDetails;
        private System.Windows.Forms.DataGridView dgvPlaylist;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlaylistId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Username;
    }
}

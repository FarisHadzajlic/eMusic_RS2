namespace eMusic.WinUI.Forms.Playlist
{
    partial class PlaylistUpsert
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlaylistUpsert));
            this.label5 = new System.Windows.Forms.Label();
            this.btnRemoveTrack = new System.Windows.Forms.Button();
            this.btnAddTrack = new System.Windows.Forms.Button();
            this.txtSearchAllTracks = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvAllTracks = new System.Windows.Forms.DataGridView();
            this.TrackID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Length = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.btnUploadPicture = new System.Windows.Forms.Button();
            this.pbPlaylistPicture = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvPlaylistTracks = new System.Windows.Forms.DataGridView();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllTracks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlaylistPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlaylistTracks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(36, 183);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 16);
            this.label5.TabIndex = 36;
            this.label5.Text = "Playlist";
            // 
            // btnRemoveTrack
            // 
            this.btnRemoveTrack.Image = ((System.Drawing.Image)(resources.GetObject("btnRemoveTrack.Image")));
            this.btnRemoveTrack.Location = new System.Drawing.Point(327, 300);
            this.btnRemoveTrack.Name = "btnRemoveTrack";
            this.btnRemoveTrack.Size = new System.Drawing.Size(42, 36);
            this.btnRemoveTrack.TabIndex = 35;
            this.btnRemoveTrack.UseVisualStyleBackColor = true;
            this.btnRemoveTrack.Click += new System.EventHandler(this.btnRemoveTrack_Click);
            // 
            // btnAddTrack
            // 
            this.btnAddTrack.Image = ((System.Drawing.Image)(resources.GetObject("btnAddTrack.Image")));
            this.btnAddTrack.Location = new System.Drawing.Point(327, 244);
            this.btnAddTrack.Name = "btnAddTrack";
            this.btnAddTrack.Size = new System.Drawing.Size(42, 36);
            this.btnAddTrack.TabIndex = 34;
            this.btnAddTrack.UseVisualStyleBackColor = true;
            this.btnAddTrack.Click += new System.EventHandler(this.btnAddTrack_Click);
            // 
            // txtSearchAllTracks
            // 
            this.txtSearchAllTracks.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchAllTracks.Location = new System.Drawing.Point(470, 180);
            this.txtSearchAllTracks.Name = "txtSearchAllTracks";
            this.txtSearchAllTracks.Size = new System.Drawing.Size(146, 22);
            this.txtSearchAllTracks.TabIndex = 33;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(560, 383);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(92, 29);
            this.btnSave.TabIndex = 32;
            this.btnSave.Text = "Save ";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.Location = new System.Drawing.Point(622, 180);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(30, 23);
            this.btnSearch.TabIndex = 31;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(391, 183);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 16);
            this.label4.TabIndex = 30;
            this.label4.Text = "All Songs";
            // 
            // dgvAllTracks
            // 
            this.dgvAllTracks.AllowUserToAddRows = false;
            this.dgvAllTracks.AllowUserToDeleteRows = false;
            this.dgvAllTracks.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAllTracks.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvAllTracks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAllTracks.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TrackID,
            this.Name,
            this.Length});
            this.dgvAllTracks.Location = new System.Drawing.Point(394, 206);
            this.dgvAllTracks.Name = "dgvAllTracks";
            this.dgvAllTracks.ReadOnly = true;
            this.dgvAllTracks.RowTemplate.Height = 26;
            this.dgvAllTracks.Size = new System.Drawing.Size(258, 171);
            this.dgvAllTracks.TabIndex = 29;
            // 
            // TrackID
            // 
            this.TrackID.DataPropertyName = "TrackID";
            this.TrackID.HeaderText = "TrackID";
            this.TrackID.Name = "TrackID";
            this.TrackID.ReadOnly = true;
            this.TrackID.Visible = false;
            // 
            // Name
            // 
            this.Name.DataPropertyName = "Name";
            this.Name.HeaderText = "Name";
            this.Name.Name = "Name";
            this.Name.ReadOnly = true;
            // 
            // Length
            // 
            this.Length.DataPropertyName = "Length";
            this.Length.HeaderText = "Length";
            this.Length.Name = "Length";
            this.Length.ReadOnly = true;
            // 
            // txtUser
            // 
            this.txtUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUser.Location = new System.Drawing.Point(88, 41);
            this.txtUser.Name = "txtUser";
            this.txtUser.ReadOnly = true;
            this.txtUser.Size = new System.Drawing.Size(194, 26);
            this.txtUser.TabIndex = 27;
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(88, 107);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(194, 26);
            this.txtName.TabIndex = 26;
            this.txtName.Validating += new System.ComponentModel.CancelEventHandler(this.txtName_Validating);
            // 
            // btnUploadPicture
            // 
            this.btnUploadPicture.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUploadPicture.Location = new System.Drawing.Point(394, 139);
            this.btnUploadPicture.Name = "btnUploadPicture";
            this.btnUploadPicture.Size = new System.Drawing.Size(258, 23);
            this.btnUploadPicture.TabIndex = 25;
            this.btnUploadPicture.Text = "Upload Picture";
            this.btnUploadPicture.UseVisualStyleBackColor = true;
            this.btnUploadPicture.Click += new System.EventHandler(this.btnUploadPicture_Click);
            // 
            // pbPlaylistPicture
            // 
            this.pbPlaylistPicture.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbPlaylistPicture.BackgroundImage")));
            this.pbPlaylistPicture.Location = new System.Drawing.Point(394, 12);
            this.pbPlaylistPicture.Name = "pbPlaylistPicture";
            this.pbPlaylistPicture.Size = new System.Drawing.Size(258, 121);
            this.pbPlaylistPicture.TabIndex = 24;
            this.pbPlaylistPicture.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(36, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 16);
            this.label2.TabIndex = 23;
            this.label2.Text = "User";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(36, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 16);
            this.label1.TabIndex = 22;
            this.label1.Text = "Name";
            // 
            // dgvPlaylistTracks
            // 
            this.dgvPlaylistTracks.AllowUserToAddRows = false;
            this.dgvPlaylistTracks.AllowUserToDeleteRows = false;
            this.dgvPlaylistTracks.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPlaylistTracks.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvPlaylistTracks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPlaylistTracks.Location = new System.Drawing.Point(39, 206);
            this.dgvPlaylistTracks.Name = "dgvPlaylistTracks";
            this.dgvPlaylistTracks.ReadOnly = true;
            this.dgvPlaylistTracks.RowTemplate.Height = 26;
            this.dgvPlaylistTracks.Size = new System.Drawing.Size(258, 171);
            this.dgvPlaylistTracks.TabIndex = 37;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // PlaylistUpsert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvPlaylistTracks);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnRemoveTrack);
            this.Controls.Add(this.btnAddTrack);
            this.Controls.Add(this.txtSearchAllTracks);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dgvAllTracks);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.btnUploadPicture);
            this.Controls.Add(this.pbPlaylistPicture);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Size = new System.Drawing.Size(721, 444);
            this.Load += new System.EventHandler(this.PlaylistUpsert_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllTracks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlaylistPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlaylistTracks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnRemoveTrack;
        private System.Windows.Forms.Button btnAddTrack;
        private System.Windows.Forms.TextBox txtSearchAllTracks;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvAllTracks;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button btnUploadPicture;
        private System.Windows.Forms.PictureBox pbPlaylistPicture;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvPlaylistTracks;
        private System.Windows.Forms.DataGridViewTextBoxColumn TrackID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Length;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}

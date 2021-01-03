namespace eMusic.WinUI.Forms.Album
{
    partial class AlbumUpsert
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AlbumUpsert));
            this.txtAbout = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dgvAllSongs = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAddTrack = new System.Windows.Forms.Button();
            this.dgvAlbumSongs = new System.Windows.Forms.DataGridView();
            this.TrackID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAddGenre = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cbGenre = new System.Windows.Forms.ComboBox();
            this.btnAddArtist = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cbArtist = new System.Windows.Forms.ComboBox();
            this.btnRemoveSong = new System.Windows.Forms.Button();
            this.btnAddSong = new System.Windows.Forms.Button();
            this.btnUploadPicture = new System.Windows.Forms.Button();
            this.pbAlbumPicture = new System.Windows.Forms.PictureBox();
            this.txtReleaseYear = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtSearchAllTracks = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllSongs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlbumSongs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAlbumPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtAbout
            // 
            this.txtAbout.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAbout.Location = new System.Drawing.Point(513, 28);
            this.txtAbout.Multiline = true;
            this.txtAbout.Name = "txtAbout";
            this.txtAbout.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtAbout.Size = new System.Drawing.Size(119, 169);
            this.txtAbout.TabIndex = 45;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(510, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 16);
            this.label6.TabIndex = 44;
            this.label6.Text = "About";
            // 
            // txtPrice
            // 
            this.txtPrice.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrice.Location = new System.Drawing.Point(49, 118);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(244, 23);
            this.txtPrice.TabIndex = 43;
            this.txtPrice.Validating += new System.ComponentModel.CancelEventHandler(this.txtPrice_Validating);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(46, 99);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 16);
            this.label5.TabIndex = 42;
            this.label5.Text = "Price";
            // 
            // dgvAllSongs
            // 
            this.dgvAllSongs.AllowUserToAddRows = false;
            this.dgvAllSongs.AllowUserToDeleteRows = false;
            this.dgvAllSongs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAllSongs.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvAllSongs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAllSongs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5});
            this.dgvAllSongs.Location = new System.Drawing.Point(388, 259);
            this.dgvAllSongs.Name = "dgvAllSongs";
            this.dgvAllSongs.ReadOnly = true;
            this.dgvAllSongs.RowTemplate.Height = 26;
            this.dgvAllSongs.Size = new System.Drawing.Size(244, 140);
            this.dgvAllSongs.TabIndex = 41;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "TrackID";
            this.dataGridViewTextBoxColumn1.HeaderText = "TrackID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Name";
            this.dataGridViewTextBoxColumn4.HeaderText = "Name";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Length";
            this.dataGridViewTextBoxColumn5.HeaderText = "Length";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // btnAddTrack
            // 
            this.btnAddTrack.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddTrack.Location = new System.Drawing.Point(388, 405);
            this.btnAddTrack.Name = "btnAddTrack";
            this.btnAddTrack.Size = new System.Drawing.Size(90, 31);
            this.btnAddTrack.TabIndex = 40;
            this.btnAddTrack.Text = "Add Song";
            this.btnAddTrack.UseVisualStyleBackColor = true;
            this.btnAddTrack.Click += new System.EventHandler(this.btnAddTrack_Click);
            // 
            // dgvAlbumSongs
            // 
            this.dgvAlbumSongs.AllowUserToAddRows = false;
            this.dgvAlbumSongs.AllowUserToDeleteRows = false;
            this.dgvAlbumSongs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAlbumSongs.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvAlbumSongs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAlbumSongs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TrackID,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
            this.dgvAlbumSongs.Location = new System.Drawing.Point(49, 259);
            this.dgvAlbumSongs.Name = "dgvAlbumSongs";
            this.dgvAlbumSongs.ReadOnly = true;
            this.dgvAlbumSongs.RowTemplate.Height = 26;
            this.dgvAlbumSongs.Size = new System.Drawing.Size(244, 140);
            this.dgvAlbumSongs.TabIndex = 39;
            // 
            // TrackID
            // 
            this.TrackID.DataPropertyName = "TrackID";
            this.TrackID.HeaderText = "TrackID";
            this.TrackID.Name = "TrackID";
            this.TrackID.ReadOnly = true;
            this.TrackID.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Name";
            this.dataGridViewTextBoxColumn2.HeaderText = "Name";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Length";
            this.dataGridViewTextBoxColumn3.HeaderText = "Length";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // btnAddGenre
            // 
            this.btnAddGenre.Image = ((System.Drawing.Image)(resources.GetObject("btnAddGenre.Image")));
            this.btnAddGenre.Location = new System.Drawing.Point(264, 209);
            this.btnAddGenre.Name = "btnAddGenre";
            this.btnAddGenre.Size = new System.Drawing.Size(29, 24);
            this.btnAddGenre.TabIndex = 38;
            this.btnAddGenre.UseVisualStyleBackColor = true;
            this.btnAddGenre.Click += new System.EventHandler(this.btnAddGenre_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(46, 190);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 16);
            this.label4.TabIndex = 37;
            this.label4.Text = "Genre";
            // 
            // cbGenre
            // 
            this.cbGenre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGenre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbGenre.FormattingEnabled = true;
            this.cbGenre.Location = new System.Drawing.Point(49, 209);
            this.cbGenre.Name = "cbGenre";
            this.cbGenre.Size = new System.Drawing.Size(209, 24);
            this.cbGenre.TabIndex = 36;
            // 
            // btnAddArtist
            // 
            this.btnAddArtist.Image = ((System.Drawing.Image)(resources.GetObject("btnAddArtist.Image")));
            this.btnAddArtist.Location = new System.Drawing.Point(264, 162);
            this.btnAddArtist.Name = "btnAddArtist";
            this.btnAddArtist.Size = new System.Drawing.Size(29, 25);
            this.btnAddArtist.TabIndex = 35;
            this.btnAddArtist.UseVisualStyleBackColor = true;
            this.btnAddArtist.Click += new System.EventHandler(this.btnAddArtist_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(542, 405);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 31);
            this.btnSave.TabIndex = 34;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(46, 144);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 16);
            this.label3.TabIndex = 33;
            this.label3.Text = "Artist";
            // 
            // cbArtist
            // 
            this.cbArtist.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbArtist.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbArtist.FormattingEnabled = true;
            this.cbArtist.Location = new System.Drawing.Point(49, 163);
            this.cbArtist.Name = "cbArtist";
            this.cbArtist.Size = new System.Drawing.Size(209, 24);
            this.cbArtist.TabIndex = 32;
            // 
            // btnRemoveSong
            // 
            this.btnRemoveSong.Image = ((System.Drawing.Image)(resources.GetObject("btnRemoveSong.Image")));
            this.btnRemoveSong.Location = new System.Drawing.Point(316, 347);
            this.btnRemoveSong.Name = "btnRemoveSong";
            this.btnRemoveSong.Size = new System.Drawing.Size(48, 33);
            this.btnRemoveSong.TabIndex = 31;
            this.btnRemoveSong.UseVisualStyleBackColor = true;
            this.btnRemoveSong.Click += new System.EventHandler(this.btnRemoveSong_Click);
            // 
            // btnAddSong
            // 
            this.btnAddSong.Image = ((System.Drawing.Image)(resources.GetObject("btnAddSong.Image")));
            this.btnAddSong.Location = new System.Drawing.Point(316, 293);
            this.btnAddSong.Name = "btnAddSong";
            this.btnAddSong.Size = new System.Drawing.Size(48, 33);
            this.btnAddSong.TabIndex = 30;
            this.btnAddSong.UseVisualStyleBackColor = true;
            this.btnAddSong.Click += new System.EventHandler(this.btnAddSong_Click);
            // 
            // btnUploadPicture
            // 
            this.btnUploadPicture.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUploadPicture.Location = new System.Drawing.Point(377, 173);
            this.btnUploadPicture.Name = "btnUploadPicture";
            this.btnUploadPicture.Size = new System.Drawing.Size(130, 24);
            this.btnUploadPicture.TabIndex = 29;
            this.btnUploadPicture.Text = "Upload Picture";
            this.btnUploadPicture.UseVisualStyleBackColor = true;
            this.btnUploadPicture.Click += new System.EventHandler(this.btnUploadPicture_Click);
            // 
            // pbAlbumPicture
            // 
            this.pbAlbumPicture.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbAlbumPicture.BackgroundImage")));
            this.pbAlbumPicture.InitialImage = null;
            this.pbAlbumPicture.Location = new System.Drawing.Point(377, 28);
            this.pbAlbumPicture.Name = "pbAlbumPicture";
            this.pbAlbumPicture.Size = new System.Drawing.Size(130, 139);
            this.pbAlbumPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbAlbumPicture.TabIndex = 28;
            this.pbAlbumPicture.TabStop = false;
            // 
            // txtReleaseYear
            // 
            this.txtReleaseYear.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReleaseYear.Location = new System.Drawing.Point(49, 73);
            this.txtReleaseYear.Name = "txtReleaseYear";
            this.txtReleaseYear.Size = new System.Drawing.Size(244, 23);
            this.txtReleaseYear.TabIndex = 27;
            this.txtReleaseYear.Validating += new System.ComponentModel.CancelEventHandler(this.txtReleaseYear_Validating);
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(49, 28);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(244, 23);
            this.txtName.TabIndex = 26;
            this.txtName.Validating += new System.ComponentModel.CancelEventHandler(this.txtName_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(46, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 16);
            this.label2.TabIndex = 25;
            this.label2.Text = "Year Of Release";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(46, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 16);
            this.label1.TabIndex = 24;
            this.label1.Text = "Name";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(46, 240);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 16);
            this.label7.TabIndex = 46;
            this.label7.Text = "Album Songs";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(385, 240);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 16);
            this.label8.TabIndex = 47;
            this.label8.Text = "Your Songs";
            // 
            // txtSearchAllTracks
            // 
            this.txtSearchAllTracks.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchAllTracks.Location = new System.Drawing.Point(464, 236);
            this.txtSearchAllTracks.Name = "txtSearchAllTracks";
            this.txtSearchAllTracks.Size = new System.Drawing.Size(132, 21);
            this.txtSearchAllTracks.TabIndex = 49;
            // 
            // btnSearch
            // 
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.Location = new System.Drawing.Point(600, 236);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(32, 23);
            this.btnSearch.TabIndex = 48;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Maroon;
            this.label9.Location = new System.Drawing.Point(46, 414);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(243, 13);
            this.label9.TabIndex = 50;
            this.label9.Text = "Price album with zero (0) so it can be free to listen.";
            // 
            // AlbumUpsert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtSearchAllTracks);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtAbout);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dgvAllSongs);
            this.Controls.Add(this.btnAddTrack);
            this.Controls.Add(this.dgvAlbumSongs);
            this.Controls.Add(this.btnAddGenre);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbGenre);
            this.Controls.Add(this.btnAddArtist);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbArtist);
            this.Controls.Add(this.btnRemoveSong);
            this.Controls.Add(this.btnAddSong);
            this.Controls.Add(this.btnUploadPicture);
            this.Controls.Add(this.pbAlbumPicture);
            this.Controls.Add(this.txtReleaseYear);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AlbumUpsert";
            this.Size = new System.Drawing.Size(683, 477);
            this.Load += new System.EventHandler(this.AlbumUpsert_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllSongs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlbumSongs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAlbumPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtAbout;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgvAllSongs;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.Button btnAddTrack;
        private System.Windows.Forms.DataGridView dgvAlbumSongs;
        private System.Windows.Forms.DataGridViewTextBoxColumn TrackID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.Button btnAddGenre;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbGenre;
        private System.Windows.Forms.Button btnAddArtist;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbArtist;
        private System.Windows.Forms.Button btnRemoveSong;
        private System.Windows.Forms.Button btnAddSong;
        private System.Windows.Forms.Button btnUploadPicture;
        private System.Windows.Forms.PictureBox pbAlbumPicture;
        private System.Windows.Forms.TextBox txtReleaseYear;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtSearchAllTracks;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label9;
    }
}

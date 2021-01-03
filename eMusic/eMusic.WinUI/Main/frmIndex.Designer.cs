namespace eMusic.WinUI
{
    partial class frmIndex
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmIndex));
            this.Content = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnSettings = new System.Windows.Forms.Button();
            this.btnTrack = new System.Windows.Forms.Button();
            this.btnPlaylist = new System.Windows.Forms.Button();
            this.btnGenre = new System.Windows.Forms.Button();
            this.btnAlbum = new System.Windows.Forms.Button();
            this.btnArtist = new System.Windows.Forms.Button();
            this.btnUser = new System.Windows.Forms.Button();
            this.Navbar = new System.Windows.Forms.Panel();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lUsername = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.Navbar.SuspendLayout();
            this.SuspendLayout();
            // 
            // Content
            // 
            this.Content.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Content.Location = new System.Drawing.Point(158, 47);
            this.Content.Name = "Content";
            this.Content.Size = new System.Drawing.Size(690, 446);
            this.Content.TabIndex = 3;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.pictureBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnSettings, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.btnTrack, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.btnPlaylist, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.btnGenre, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.btnAlbum, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnArtist, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnUser, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(158, 493);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(152, 151);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // btnSettings
            // 
            this.btnSettings.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnSettings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSettings.FlatAppearance.BorderSize = 0;
            this.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSettings.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSettings.Image = ((System.Drawing.Image)(resources.GetObject("btnSettings.Image")));
            this.btnSettings.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSettings.Location = new System.Drawing.Point(3, 448);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(152, 42);
            this.btnSettings.TabIndex = 8;
            this.btnSettings.Text = "         Settings";
            this.btnSettings.UseVisualStyleBackColor = false;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnTrack
            // 
            this.btnTrack.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnTrack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTrack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnTrack.FlatAppearance.BorderSize = 0;
            this.btnTrack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTrack.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTrack.Image = ((System.Drawing.Image)(resources.GetObject("btnTrack.Image")));
            this.btnTrack.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTrack.Location = new System.Drawing.Point(3, 400);
            this.btnTrack.Name = "btnTrack";
            this.btnTrack.Size = new System.Drawing.Size(152, 42);
            this.btnTrack.TabIndex = 6;
            this.btnTrack.Text = "     Track";
            this.btnTrack.UseVisualStyleBackColor = false;
            this.btnTrack.Click += new System.EventHandler(this.btnTrack_Click);
            // 
            // btnPlaylist
            // 
            this.btnPlaylist.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnPlaylist.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPlaylist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPlaylist.FlatAppearance.BorderSize = 0;
            this.btnPlaylist.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlaylist.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlaylist.Image = ((System.Drawing.Image)(resources.GetObject("btnPlaylist.Image")));
            this.btnPlaylist.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPlaylist.Location = new System.Drawing.Point(3, 352);
            this.btnPlaylist.Name = "btnPlaylist";
            this.btnPlaylist.Size = new System.Drawing.Size(152, 42);
            this.btnPlaylist.TabIndex = 5;
            this.btnPlaylist.Text = "        Playlist";
            this.btnPlaylist.UseVisualStyleBackColor = false;
            this.btnPlaylist.Click += new System.EventHandler(this.btnPlaylist_Click);
            // 
            // btnGenre
            // 
            this.btnGenre.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnGenre.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGenre.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnGenre.FlatAppearance.BorderSize = 0;
            this.btnGenre.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenre.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenre.Image = ((System.Drawing.Image)(resources.GetObject("btnGenre.Image")));
            this.btnGenre.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGenre.Location = new System.Drawing.Point(3, 304);
            this.btnGenre.Name = "btnGenre";
            this.btnGenre.Size = new System.Drawing.Size(152, 42);
            this.btnGenre.TabIndex = 4;
            this.btnGenre.Text = "       Genre";
            this.btnGenre.UseVisualStyleBackColor = false;
            this.btnGenre.Click += new System.EventHandler(this.btnGenre_Click);
            // 
            // btnAlbum
            // 
            this.btnAlbum.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnAlbum.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAlbum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAlbum.FlatAppearance.BorderSize = 0;
            this.btnAlbum.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAlbum.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAlbum.Image = ((System.Drawing.Image)(resources.GetObject("btnAlbum.Image")));
            this.btnAlbum.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAlbum.Location = new System.Drawing.Point(3, 256);
            this.btnAlbum.Name = "btnAlbum";
            this.btnAlbum.Size = new System.Drawing.Size(152, 42);
            this.btnAlbum.TabIndex = 3;
            this.btnAlbum.Text = "        Album";
            this.btnAlbum.UseVisualStyleBackColor = false;
            this.btnAlbum.Click += new System.EventHandler(this.btnAlbum_Click);
            // 
            // btnArtist
            // 
            this.btnArtist.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnArtist.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnArtist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnArtist.FlatAppearance.BorderSize = 0;
            this.btnArtist.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnArtist.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnArtist.Image = ((System.Drawing.Image)(resources.GetObject("btnArtist.Image")));
            this.btnArtist.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnArtist.Location = new System.Drawing.Point(3, 208);
            this.btnArtist.Name = "btnArtist";
            this.btnArtist.Size = new System.Drawing.Size(152, 42);
            this.btnArtist.TabIndex = 2;
            this.btnArtist.Text = "      Artist";
            this.btnArtist.UseVisualStyleBackColor = false;
            this.btnArtist.Click += new System.EventHandler(this.btnArtist_Click);
            // 
            // btnUser
            // 
            this.btnUser.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnUser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnUser.FlatAppearance.BorderSize = 0;
            this.btnUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUser.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUser.Image = ((System.Drawing.Image)(resources.GetObject("btnUser.Image")));
            this.btnUser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUser.Location = new System.Drawing.Point(3, 160);
            this.btnUser.Name = "btnUser";
            this.btnUser.Size = new System.Drawing.Size(152, 42);
            this.btnUser.TabIndex = 1;
            this.btnUser.Text = "     User";
            this.btnUser.UseVisualStyleBackColor = false;
            this.btnUser.Click += new System.EventHandler(this.btnUser_Click);
            // 
            // Navbar
            // 
            this.Navbar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Navbar.Controls.Add(this.btnMinimize);
            this.Navbar.Controls.Add(this.label2);
            this.Navbar.Controls.Add(this.lUsername);
            this.Navbar.Controls.Add(this.btnBack);
            this.Navbar.Controls.Add(this.btnClose);
            this.Navbar.Controls.Add(this.label1);
            this.Navbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.Navbar.Location = new System.Drawing.Point(158, 0);
            this.Navbar.Name = "Navbar";
            this.Navbar.Size = new System.Drawing.Size(690, 45);
            this.Navbar.TabIndex = 5;
            this.Navbar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Navbar_MouseDown);
            this.Navbar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Navbar_MouseMove);
            this.Navbar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Navbar_MouseUp);
            // 
            // btnMinimize
            // 
            this.btnMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMinimize.FlatAppearance.BorderSize = 0;
            this.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimize.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMinimize.ForeColor = System.Drawing.Color.Maroon;
            this.btnMinimize.Location = new System.Drawing.Point(608, 6);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(32, 31);
            this.btnMinimize.TabIndex = 4;
            this.btnMinimize.Text = "—";
            this.btnMinimize.UseVisualStyleBackColor = true;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(266, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "Welcome";
            // 
            // lUsername
            // 
            this.lUsername.AutoSize = true;
            this.lUsername.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lUsername.Location = new System.Drawing.Point(345, 12);
            this.lUsername.Name = "lUsername";
            this.lUsername.Size = new System.Drawing.Size(119, 19);
            this.lUsername.TabIndex = 2;
            this.lUsername.Text = "[Placeholder]";
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.Gainsboro;
            this.btnBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.Image = ((System.Drawing.Image)(resources.GetObject("btnBack.Image")));
            this.btnBack.Location = new System.Drawing.Point(6, 3);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(37, 38);
            this.btnBack.TabIndex = 0;
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnClose
            // 
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.Maroon;
            this.btnClose.Location = new System.Drawing.Point(646, 6);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(32, 31);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(49, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Admin Dashboard";
            // 
            // frmIndex
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(848, 493);
            this.Controls.Add(this.Navbar);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.Content);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmIndex";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmIndex";
            this.Load += new System.EventHandler(this.frmIndex_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.Navbar.ResumeLayout(false);
            this.Navbar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Content;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnTrack;
        private System.Windows.Forms.Button btnPlaylist;
        private System.Windows.Forms.Button btnGenre;
        private System.Windows.Forms.Button btnAlbum;
        private System.Windows.Forms.Button btnArtist;
        private System.Windows.Forms.Button btnUser;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel Navbar;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lUsername;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSettings;
    }
}
namespace eMusic.WinUI.Forms.Genre
{
    partial class GenreList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GenreList));
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnDetails = new System.Windows.Forms.Button();
            this.btnAddGenre = new System.Windows.Forms.Button();
            this.dgvGenres = new System.Windows.Forms.DataGridView();
            this.GenreId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGenres)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDelete
            // 
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.Location = new System.Drawing.Point(498, 61);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(48, 40);
            this.btnDelete.TabIndex = 19;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnDetails
            // 
            this.btnDetails.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDetails.Image = ((System.Drawing.Image)(resources.GetObject("btnDetails.Image")));
            this.btnDetails.Location = new System.Drawing.Point(444, 61);
            this.btnDetails.Name = "btnDetails";
            this.btnDetails.Size = new System.Drawing.Size(48, 40);
            this.btnDetails.TabIndex = 18;
            this.btnDetails.UseVisualStyleBackColor = true;
            this.btnDetails.Click += new System.EventHandler(this.btnDetails_Click);
            // 
            // btnAddGenre
            // 
            this.btnAddGenre.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddGenre.Image = ((System.Drawing.Image)(resources.GetObject("btnAddGenre.Image")));
            this.btnAddGenre.Location = new System.Drawing.Point(390, 61);
            this.btnAddGenre.Name = "btnAddGenre";
            this.btnAddGenre.Size = new System.Drawing.Size(48, 40);
            this.btnAddGenre.TabIndex = 17;
            this.btnAddGenre.UseVisualStyleBackColor = true;
            this.btnAddGenre.Click += new System.EventHandler(this.btnAddGenre_Click);
            // 
            // dgvGenres
            // 
            this.dgvGenres.AllowUserToAddRows = false;
            this.dgvGenres.AllowUserToDeleteRows = false;
            this.dgvGenres.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvGenres.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvGenres.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGenres.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.GenreId,
            this.Name});
            this.dgvGenres.Location = new System.Drawing.Point(141, 107);
            this.dgvGenres.Name = "dgvGenres";
            this.dgvGenres.ReadOnly = true;
            this.dgvGenres.RowTemplate.Height = 30;
            this.dgvGenres.Size = new System.Drawing.Size(405, 197);
            this.dgvGenres.TabIndex = 16;
            // 
            // GenreId
            // 
            this.GenreId.DataPropertyName = "GenreId";
            this.GenreId.HeaderText = "GenreId";
            this.GenreId.Name = "GenreId";
            this.GenreId.ReadOnly = true;
            this.GenreId.Visible = false;
            // 
            // Name
            // 
            this.Name.DataPropertyName = "Name";
            this.Name.HeaderText = "Name";
            this.Name.Name = "Name";
            this.Name.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.DarkRed;
            this.label1.Location = new System.Drawing.Point(3, 426);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(373, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Once you delete a genre, all songs and albums within are going to be deleted!";
            // 
            // GenreList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnDetails);
            this.Controls.Add(this.btnAddGenre);
            this.Controls.Add(this.dgvGenres);
            this.Size = new System.Drawing.Size(573, 450);
            this.Load += new System.EventHandler(this.GenreList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGenres)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnDetails;
        private System.Windows.Forms.Button btnAddGenre;
        private System.Windows.Forms.DataGridView dgvGenres;
        private System.Windows.Forms.DataGridViewTextBoxColumn GenreId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name;
        private System.Windows.Forms.Label label1;
    }
}

namespace WindowsFormsApp1
{
    partial class Manage_bookings
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
            this.user_background = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.Search_Users = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Logout_btn = new System.Windows.Forms.Button();
            this.Manage_bookings_btn = new System.Windows.Forms.Button();
            this.Manage_users = new System.Windows.Forms.Button();
            this.Upload_files = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.user_background.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // user_background
            // 
            this.user_background.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.user_background.BackColor = System.Drawing.Color.Silver;
            this.user_background.Controls.Add(this.dataGridView2);
            this.user_background.Controls.Add(this.panel4);
            this.user_background.Controls.Add(this.panel1);
            this.user_background.Location = new System.Drawing.Point(-1, -1);
            this.user_background.Name = "user_background";
            this.user_background.Size = new System.Drawing.Size(741, 484);
            this.user_background.TabIndex = 2;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.AutoSize = true;
            this.panel4.Controls.Add(this.Search_Users);
            this.panel4.Location = new System.Drawing.Point(280, 13);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(437, 76);
            this.panel4.TabIndex = 9;
            // 
            // Search_Users
            // 
            this.Search_Users.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Search_Users.AutoSize = true;
            this.Search_Users.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.Search_Users.Location = new System.Drawing.Point(112, 19);
            this.Search_Users.Name = "Search_Users";
            this.Search_Users.Size = new System.Drawing.Size(247, 37);
            this.Search_Users.TabIndex = 7;
            this.Search_Users.Text = "Manage Bookings";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(48)))), ((int)(((byte)(65)))));
            this.panel1.Controls.Add(this.Logout_btn);
            this.panel1.Controls.Add(this.Manage_bookings_btn);
            this.panel1.Controls.Add(this.Manage_users);
            this.panel1.Controls.Add(this.Upload_files);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(257, 484);
            this.panel1.TabIndex = 0;
            // 
            // Logout_btn
            // 
            this.Logout_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(79)))), ((int)(((byte)(95)))));
            this.Logout_btn.FlatAppearance.BorderSize = 0;
            this.Logout_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CadetBlue;
            this.Logout_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Logout_btn.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.Logout_btn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Logout_btn.Location = new System.Drawing.Point(58, 402);
            this.Logout_btn.Name = "Logout_btn";
            this.Logout_btn.Size = new System.Drawing.Size(134, 46);
            this.Logout_btn.TabIndex = 2;
            this.Logout_btn.Text = "Log Out";
            this.Logout_btn.UseVisualStyleBackColor = false;
            // 
            // Manage_bookings_btn
            // 
            this.Manage_bookings_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.Manage_bookings_btn.FlatAppearance.BorderSize = 0;
            this.Manage_bookings_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.Manage_bookings_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CadetBlue;
            this.Manage_bookings_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Manage_bookings_btn.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.Manage_bookings_btn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Manage_bookings_btn.Location = new System.Drawing.Point(58, 324);
            this.Manage_bookings_btn.Name = "Manage_bookings_btn";
            this.Manage_bookings_btn.Size = new System.Drawing.Size(134, 46);
            this.Manage_bookings_btn.TabIndex = 1;
            this.Manage_bookings_btn.Text = "Manage Bookings";
            this.Manage_bookings_btn.UseVisualStyleBackColor = false;
            // 
            // Manage_users
            // 
            this.Manage_users.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(79)))), ((int)(((byte)(95)))));
            this.Manage_users.FlatAppearance.BorderSize = 0;
            this.Manage_users.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CadetBlue;
            this.Manage_users.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Manage_users.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Manage_users.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Manage_users.Location = new System.Drawing.Point(58, 185);
            this.Manage_users.Name = "Manage_users";
            this.Manage_users.Size = new System.Drawing.Size(134, 45);
            this.Manage_users.TabIndex = 1;
            this.Manage_users.Text = "Manage Users";
            this.Manage_users.UseVisualStyleBackColor = false;
            this.Manage_users.Click += new System.EventHandler(this.Manage_users_Click);
            // 
            // Upload_files
            // 
            this.Upload_files.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(79)))), ((int)(((byte)(95)))));
            this.Upload_files.FlatAppearance.BorderSize = 0;
            this.Upload_files.FlatAppearance.MouseDownBackColor = System.Drawing.Color.CadetBlue;
            this.Upload_files.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.Upload_files.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Upload_files.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Upload_files.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Upload_files.Location = new System.Drawing.Point(58, 252);
            this.Upload_files.Margin = new System.Windows.Forms.Padding(0);
            this.Upload_files.Name = "Upload_files";
            this.Upload_files.Size = new System.Drawing.Size(134, 45);
            this.Upload_files.TabIndex = 1;
            this.Upload_files.Text = "Upload Files";
            this.Upload_files.UseVisualStyleBackColor = false;
            this.Upload_files.Click += new System.EventHandler(this.Upload_Cars_btn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.ErrorImage = null;
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(47, 29);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(155, 140);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AllowUserToResizeColumns = false;
            this.dataGridView2.AllowUserToResizeRows = false;
            this.dataGridView2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView2.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView2.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(316, 116);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowTemplate.Height = 30;
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.Size = new System.Drawing.Size(376, 332);
            this.dataGridView2.TabIndex = 11;
            // 
            // Manage_bookings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(739, 483);
            this.Controls.Add(this.user_background);
            this.Name = "Manage_bookings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage_bookings";
            this.user_background.ResumeLayout(false);
            this.user_background.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel user_background;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label Search_Users;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button Logout_btn;
        private System.Windows.Forms.Button Manage_bookings_btn;
        private System.Windows.Forms.Button Manage_users;
        private System.Windows.Forms.Button Upload_files;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView dataGridView2;
    }
}
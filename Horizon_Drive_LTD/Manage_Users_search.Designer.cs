namespace Manage_user_search_page
{
    partial class Manage_User_Page
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
            System.Windows.Forms.TextBox search_box;
            this.user_background = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.Search_Users = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.Managing_users_click_btn = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.CustomerID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Logout_btn = new System.Windows.Forms.Button();
            this.Manage_bookings_btn = new System.Windows.Forms.Button();
            this.Manage_Users = new System.Windows.Forms.Button();
            this.Manage_Cars_btn = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            search_box = new System.Windows.Forms.TextBox();
            this.user_background.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // search_box
            // 
            search_box.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            search_box.Location = new System.Drawing.Point(319, 88);
            search_box.Name = "search_box";
            search_box.Size = new System.Drawing.Size(367, 20);
            search_box.TabIndex = 5;
            search_box.Text = "Search";
            search_box.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            search_box.TextChanged += new System.EventHandler(this.Manage_users_search_user);
            // 
            // user_background
            // 
            this.user_background.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.user_background.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.user_background.Controls.Add(this.panel4);
            this.user_background.Controls.Add(this.panel3);
            this.user_background.Controls.Add(search_box);
            this.user_background.Controls.Add(this.panel2);
            this.user_background.Controls.Add(this.vScrollBar1);
            this.user_background.Controls.Add(this.panel1);
            this.user_background.Location = new System.Drawing.Point(0, -1);
            this.user_background.Name = "user_background";
            this.user_background.Size = new System.Drawing.Size(740, 485);
            this.user_background.TabIndex = 0;
            this.user_background.Paint += new System.Windows.Forms.PaintEventHandler(this.user_background_Paint);
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.AutoSize = true;
            this.panel4.Controls.Add(this.Search_Users);
            this.panel4.Location = new System.Drawing.Point(319, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(367, 66);
            this.panel4.TabIndex = 9;
            // 
            // Search_Users
            // 
            this.Search_Users.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Search_Users.AutoSize = true;
            this.Search_Users.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.Search_Users.Location = new System.Drawing.Point(76, 7);
            this.Search_Users.Name = "Search_Users";
            this.Search_Users.Size = new System.Drawing.Size(210, 37);
            this.Search_Users.TabIndex = 7;
            this.Search_Users.Text = "SEARCH USERS";
            this.Search_Users.Click += new System.EventHandler(this.Search_Users_Click);
            // 
            // panel3
            // 
            this.panel3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel3.AutoSize = true;
            this.panel3.Controls.Add(this.Managing_users_click_btn);
            this.panel3.Location = new System.Drawing.Point(319, 372);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(367, 100);
            this.panel3.TabIndex = 8;
            // 
            // Managing_users_click_btn
            // 
            this.Managing_users_click_btn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Managing_users_click_btn.AutoEllipsis = true;
            this.Managing_users_click_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(79)))), ((int)(((byte)(95)))));
            this.Managing_users_click_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Managing_users_click_btn.FlatAppearance.BorderSize = 0;
            this.Managing_users_click_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CadetBlue;
            this.Managing_users_click_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Managing_users_click_btn.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.Managing_users_click_btn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Managing_users_click_btn.Location = new System.Drawing.Point(43, 19);
            this.Managing_users_click_btn.Name = "Managing_users_click_btn";
            this.Managing_users_click_btn.Padding = new System.Windows.Forms.Padding(1);
            this.Managing_users_click_btn.Size = new System.Drawing.Size(286, 69);
            this.Managing_users_click_btn.TabIndex = 3;
            this.Managing_users_click_btn.Text = "Click to manage users";
            this.Managing_users_click_btn.UseVisualStyleBackColor = false;
            this.Managing_users_click_btn.Click += new System.EventHandler(this.Manage_users_click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Location = new System.Drawing.Point(319, 114);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(367, 236);
            this.panel2.TabIndex = 6;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CustomerID,
            this.Column1});
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 30;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(367, 234);
            this.dataGridView1.TabIndex = 4;
            // 
            // CustomerID
            // 
            this.CustomerID.HeaderText = "CustomerID";
            this.CustomerID.Name = "CustomerID";
            // 
            // Column1
            // 
            this.Column1.HeaderText = "contents";
            this.Column1.Name = "Column1";
            this.Column1.Width = 224;
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.vScrollBar1.Location = new System.Drawing.Point(689, 152);
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(17, 198);
            this.vScrollBar1.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(48)))), ((int)(((byte)(65)))));
            this.panel1.Controls.Add(this.Logout_btn);
            this.panel1.Controls.Add(this.Manage_bookings_btn);
            this.panel1.Controls.Add(this.Manage_Users);
            this.panel1.Controls.Add(this.Manage_Cars_btn);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(257, 485);
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
            this.Logout_btn.Click += new System.EventHandler(this.Logout_click_btn);
            // 
            // Manage_bookings_btn
            // 
            this.Manage_bookings_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(79)))), ((int)(((byte)(95)))));
            this.Manage_bookings_btn.FlatAppearance.BorderSize = 0;
            this.Manage_bookings_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CadetBlue;
            this.Manage_bookings_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Manage_bookings_btn.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.Manage_bookings_btn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Manage_bookings_btn.Location = new System.Drawing.Point(58, 324);
            this.Manage_bookings_btn.Name = "Manage_bookings_btn";
            this.Manage_bookings_btn.Size = new System.Drawing.Size(134, 46);
            this.Manage_bookings_btn.TabIndex = 1;
            this.Manage_bookings_btn.Text = "Manage Bookings";
            this.Manage_bookings_btn.UseVisualStyleBackColor = false;
            this.Manage_bookings_btn.Click += new System.EventHandler(this.Manage_bookings_click_btn);
            // 
            // Manage_Users
            // 
            this.Manage_Users.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.Manage_Users.FlatAppearance.BorderSize = 0;
            this.Manage_Users.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Manage_Users.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Manage_Users.Location = new System.Drawing.Point(58, 185);
            this.Manage_Users.Name = "Manage_Users";
            this.Manage_Users.Size = new System.Drawing.Size(134, 45);
            this.Manage_Users.TabIndex = 1;
            this.Manage_Users.Text = "Manage Users";
            this.Manage_Users.UseVisualStyleBackColor = false;
            this.Manage_Users.Click += new System.EventHandler(this.Manage_Users_menu_Click_btn);
            // 
            // Manage_Cars_btn
            // 
            this.Manage_Cars_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(79)))), ((int)(((byte)(95)))));
            this.Manage_Cars_btn.FlatAppearance.BorderSize = 0;
            this.Manage_Cars_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.CadetBlue;
            this.Manage_Cars_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.Manage_Cars_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Manage_Cars_btn.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Manage_Cars_btn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Manage_Cars_btn.Location = new System.Drawing.Point(58, 252);
            this.Manage_Cars_btn.Margin = new System.Windows.Forms.Padding(0);
            this.Manage_Cars_btn.Name = "Manage_Cars_btn";
            this.Manage_Cars_btn.Size = new System.Drawing.Size(134, 45);
            this.Manage_Cars_btn.TabIndex = 1;
            this.Manage_Cars_btn.Text = "Upload Files";
            this.Manage_Cars_btn.UseVisualStyleBackColor = false;
            this.Manage_Cars_btn.Click += new System.EventHandler(this.Upload_Cars_click_btn);
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
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Manage_User_Page
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(739, 483);
            this.Controls.Add(this.user_background);
            this.Name = "Manage_User_Page";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Search Users";
            this.user_background.ResumeLayout(false);
            this.user_background.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel user_background;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button Manage_Cars_btn;
        private System.Windows.Forms.Button Manage_Users;
        private System.Windows.Forms.Button Logout_btn;
        private System.Windows.Forms.Button Manage_bookings_btn;
        private System.Windows.Forms.VScrollBar vScrollBar1;
        private System.Windows.Forms.Button Managing_users_click_btn;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label Search_Users;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
    }
}


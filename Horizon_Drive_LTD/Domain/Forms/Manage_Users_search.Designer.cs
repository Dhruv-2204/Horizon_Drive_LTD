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
            TextBox search_box;
            user_background = new Panel();
            panel4 = new Panel();
            Search_Users = new Label();
            panel3 = new Panel();
            Managing_users_click_btn = new Button();
            panel2 = new Panel();
            dataGridView1 = new DataGridView();
            vScrollBar1 = new VScrollBar();
            panel1 = new Panel();
            Logout_btn = new Button();
            Manage_bookings_btn = new Button();
            Manage_Users = new Button();
            Manage_Cars_btn = new Button();
            pictureBox1 = new PictureBox();
            search_box = new TextBox();
            user_background.SuspendLayout();
            panel4.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // search_box
            // 
            search_box.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            search_box.Location = new Point(372, 102);
            search_box.Margin = new Padding(4, 3, 4, 3);
            search_box.Name = "search_box";
            search_box.Size = new Size(428, 23);
            search_box.TabIndex = 5;
            search_box.Text = "Search";
            search_box.TextAlign = HorizontalAlignment.Center;
            search_box.TextChanged += Manage_users_search_user;
            // 
            // user_background
            // 
            user_background.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            user_background.BackColor = Color.FromArgb(224, 224, 224);
            user_background.Controls.Add(panel4);
            user_background.Controls.Add(panel3);
            user_background.Controls.Add(search_box);
            user_background.Controls.Add(panel2);
            user_background.Controls.Add(vScrollBar1);
            user_background.Controls.Add(panel1);
            user_background.Location = new Point(0, -1);
            user_background.Margin = new Padding(4, 3, 4, 3);
            user_background.Name = "user_background";
            user_background.Size = new Size(863, 560);
            user_background.TabIndex = 0;
            user_background.Paint += user_background_Paint;
            // 
            // panel4
            // 
            panel4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel4.AutoSize = true;
            panel4.Controls.Add(Search_Users);
            panel4.Location = new Point(372, 3);
            panel4.Margin = new Padding(4, 3, 4, 3);
            panel4.Name = "panel4";
            panel4.Size = new Size(428, 76);
            panel4.TabIndex = 9;
            // 
            // Search_Users
            // 
            Search_Users.Anchor = AnchorStyles.None;
            Search_Users.AutoSize = true;
            Search_Users.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            Search_Users.Location = new Point(89, 8);
            Search_Users.Margin = new Padding(4, 0, 4, 0);
            Search_Users.Name = "Search_Users";
            Search_Users.Size = new Size(210, 37);
            Search_Users.TabIndex = 7;
            Search_Users.Text = "SEARCH USERS";
            Search_Users.Click += Search_Users_Click;
            // 
            // panel3
            // 
            panel3.Anchor = AnchorStyles.None;
            panel3.AutoSize = true;
            panel3.Controls.Add(Managing_users_click_btn);
            panel3.Location = new Point(372, 429);
            panel3.Margin = new Padding(4, 3, 4, 3);
            panel3.Name = "panel3";
            panel3.Size = new Size(428, 115);
            panel3.TabIndex = 8;
            // 
            // Managing_users_click_btn
            // 
            Managing_users_click_btn.Anchor = AnchorStyles.None;
            Managing_users_click_btn.AutoEllipsis = true;
            Managing_users_click_btn.BackColor = Color.FromArgb(33, 79, 95);
            Managing_users_click_btn.Cursor = Cursors.Hand;
            Managing_users_click_btn.FlatAppearance.BorderSize = 0;
            Managing_users_click_btn.FlatAppearance.MouseOverBackColor = Color.CadetBlue;
            Managing_users_click_btn.FlatStyle = FlatStyle.Flat;
            Managing_users_click_btn.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            Managing_users_click_btn.ForeColor = SystemColors.ButtonHighlight;
            Managing_users_click_btn.Location = new Point(50, 22);
            Managing_users_click_btn.Margin = new Padding(4, 3, 4, 3);
            Managing_users_click_btn.Name = "Managing_users_click_btn";
            Managing_users_click_btn.Padding = new Padding(1);
            Managing_users_click_btn.Size = new Size(334, 80);
            Managing_users_click_btn.TabIndex = 3;
            Managing_users_click_btn.Text = "Click to manage users";
            Managing_users_click_btn.UseVisualStyleBackColor = false;
            Managing_users_click_btn.Click += Manage_users_click;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel2.Controls.Add(dataGridView1);
            panel2.Location = new Point(372, 132);
            panel2.Margin = new Padding(4, 3, 4, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(428, 272);
            panel2.TabIndex = 6;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(0, 0);
            dataGridView1.Margin = new Padding(4, 3, 4, 3);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 30;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(428, 270);
            dataGridView1.TabIndex = 4;
            // 
            // vScrollBar1
            // 
            vScrollBar1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            vScrollBar1.Location = new Point(804, 175);
            vScrollBar1.Name = "vScrollBar1";
            vScrollBar1.Size = new Size(17, 228);
            vScrollBar1.TabIndex = 2;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            panel1.BackColor = Color.FromArgb(20, 48, 65);
            panel1.Controls.Add(Logout_btn);
            panel1.Controls.Add(Manage_bookings_btn);
            panel1.Controls.Add(Manage_Users);
            panel1.Controls.Add(Manage_Cars_btn);
            panel1.Controls.Add(pictureBox1);
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(4, 3, 4, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(300, 560);
            panel1.TabIndex = 0;
            // 
            // Logout_btn
            // 
            Logout_btn.BackColor = Color.FromArgb(33, 79, 95);
            Logout_btn.FlatAppearance.BorderSize = 0;
            Logout_btn.FlatAppearance.MouseOverBackColor = Color.CadetBlue;
            Logout_btn.FlatStyle = FlatStyle.Flat;
            Logout_btn.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            Logout_btn.ForeColor = SystemColors.ButtonHighlight;
            Logout_btn.Location = new Point(68, 464);
            Logout_btn.Margin = new Padding(4, 3, 4, 3);
            Logout_btn.Name = "Logout_btn";
            Logout_btn.Size = new Size(156, 53);
            Logout_btn.TabIndex = 2;
            Logout_btn.Text = "Log Out";
            Logout_btn.UseVisualStyleBackColor = false;
            Logout_btn.Click += Logout_click_btn;
            // 
            // Manage_bookings_btn
            // 
            Manage_bookings_btn.BackColor = Color.FromArgb(33, 79, 95);
            Manage_bookings_btn.FlatAppearance.BorderSize = 0;
            Manage_bookings_btn.FlatAppearance.MouseOverBackColor = Color.CadetBlue;
            Manage_bookings_btn.FlatStyle = FlatStyle.Flat;
            Manage_bookings_btn.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            Manage_bookings_btn.ForeColor = SystemColors.ButtonHighlight;
            Manage_bookings_btn.Location = new Point(68, 374);
            Manage_bookings_btn.Margin = new Padding(4, 3, 4, 3);
            Manage_bookings_btn.Name = "Manage_bookings_btn";
            Manage_bookings_btn.Size = new Size(156, 53);
            Manage_bookings_btn.TabIndex = 1;
            Manage_bookings_btn.Text = "Manage Bookings";
            Manage_bookings_btn.UseVisualStyleBackColor = false;
            Manage_bookings_btn.Click += Manage_bookings_click_btn;
            // 
            // Manage_Users
            // 
            Manage_Users.BackColor = Color.FromArgb(194, 229, 255);
            Manage_Users.FlatAppearance.BorderSize = 0;
            Manage_Users.FlatStyle = FlatStyle.Popup;
            Manage_Users.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Manage_Users.Location = new Point(68, 213);
            Manage_Users.Margin = new Padding(4, 3, 4, 3);
            Manage_Users.Name = "Manage_Users";
            Manage_Users.Size = new Size(156, 52);
            Manage_Users.TabIndex = 1;
            Manage_Users.Text = "Manage Users";
            Manage_Users.UseVisualStyleBackColor = false;
            Manage_Users.Click += Manage_Users_menu_Click_btn;
            // 
            // Manage_Cars_btn
            // 
            Manage_Cars_btn.BackColor = Color.FromArgb(33, 79, 95);
            Manage_Cars_btn.FlatAppearance.BorderSize = 0;
            Manage_Cars_btn.FlatAppearance.MouseDownBackColor = Color.CadetBlue;
            Manage_Cars_btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(194, 220, 255);
            Manage_Cars_btn.FlatStyle = FlatStyle.Flat;
            Manage_Cars_btn.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Manage_Cars_btn.ForeColor = SystemColors.ButtonHighlight;
            Manage_Cars_btn.Location = new Point(68, 291);
            Manage_Cars_btn.Margin = new Padding(0);
            Manage_Cars_btn.Name = "Manage_Cars_btn";
            Manage_Cars_btn.Size = new Size(156, 52);
            Manage_Cars_btn.TabIndex = 1;
            Manage_Cars_btn.Text = "Upload Files";
            Manage_Cars_btn.UseVisualStyleBackColor = false;
            Manage_Cars_btn.Click += Upload_Cars_click_btn;
            // 
            // pictureBox1
            // 
            pictureBox1.ErrorImage = null;
            pictureBox1.InitialImage = null;
            pictureBox1.Location = new Point(55, 33);
            pictureBox1.Margin = new Padding(4, 3, 4, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(181, 162);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // Manage_User_Page
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(862, 557);
            Controls.Add(user_background);
            Margin = new Padding(4, 3, 4, 3);
            Name = "Manage_User_Page";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Search Users";
            user_background.ResumeLayout(false);
            user_background.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel3.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);

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
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label Search_Users;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
    }
}


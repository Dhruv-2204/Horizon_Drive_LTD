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
            user_background = new Panel();
            dataGridView2 = new DataGridView();
            panel4 = new Panel();
            Search_Users = new Label();
            panel1 = new Panel();
            Logout_btn = new Button();
            Manage_bookings_btn = new Button();
            Manage_users = new Button();
            Upload_files = new Button();
            pictureBox1 = new PictureBox();
            user_background.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            panel4.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // user_background
            // 
            user_background.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            user_background.BackColor = Color.Silver;
            user_background.Controls.Add(dataGridView2);
            user_background.Controls.Add(panel4);
            user_background.Controls.Add(panel1);
            user_background.Location = new Point(-1, -1);
            user_background.Margin = new Padding(4, 3, 4, 3);
            user_background.Name = "user_background";
            user_background.Size = new Size(864, 558);
            user_background.TabIndex = 2;
            // 
            // dataGridView2
            // 
            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.AllowUserToDeleteRows = false;
            dataGridView2.AllowUserToResizeColumns = false;
            dataGridView2.AllowUserToResizeRows = false;
            dataGridView2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView2.BackgroundColor = Color.White;
            dataGridView2.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(369, 134);
            dataGridView2.Margin = new Padding(4, 3, 4, 3);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowTemplate.Height = 30;
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.Size = new Size(439, 383);
            dataGridView2.TabIndex = 11;
            // 
            // panel4
            // 
            panel4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel4.AutoSize = true;
            panel4.Controls.Add(Search_Users);
            panel4.Location = new Point(327, 15);
            panel4.Margin = new Padding(4, 3, 4, 3);
            panel4.Name = "panel4";
            panel4.Size = new Size(510, 88);
            panel4.TabIndex = 9;
            // 
            // Search_Users
            // 
            Search_Users.Anchor = AnchorStyles.None;
            Search_Users.AutoSize = true;
            Search_Users.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            Search_Users.Location = new Point(131, 22);
            Search_Users.Margin = new Padding(4, 0, 4, 0);
            Search_Users.Name = "Search_Users";
            Search_Users.Size = new Size(247, 37);
            Search_Users.TabIndex = 7;
            Search_Users.Text = "Manage Bookings";
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            panel1.BackColor = Color.FromArgb(20, 48, 65);
            panel1.Controls.Add(Logout_btn);
            panel1.Controls.Add(Manage_bookings_btn);
            panel1.Controls.Add(Manage_users);
            panel1.Controls.Add(Upload_files);
            panel1.Controls.Add(pictureBox1);
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(4, 3, 4, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(300, 558);
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
            // 
            // Manage_bookings_btn
            // 
            Manage_bookings_btn.BackColor = Color.FromArgb(194, 229, 255);
            Manage_bookings_btn.FlatAppearance.BorderSize = 0;
            Manage_bookings_btn.FlatAppearance.MouseDownBackColor = Color.Transparent;
            Manage_bookings_btn.FlatAppearance.MouseOverBackColor = Color.CadetBlue;
            Manage_bookings_btn.FlatStyle = FlatStyle.Flat;
            Manage_bookings_btn.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            Manage_bookings_btn.ForeColor = SystemColors.ControlText;
            Manage_bookings_btn.Location = new Point(68, 374);
            Manage_bookings_btn.Margin = new Padding(4, 3, 4, 3);
            Manage_bookings_btn.Name = "Manage_bookings_btn";
            Manage_bookings_btn.Size = new Size(156, 53);
            Manage_bookings_btn.TabIndex = 1;
            Manage_bookings_btn.Text = "Manage Bookings";
            Manage_bookings_btn.UseVisualStyleBackColor = false;
            // 
            // Manage_users
            // 
            Manage_users.BackColor = Color.FromArgb(33, 79, 95);
            Manage_users.FlatAppearance.BorderSize = 0;
            Manage_users.FlatAppearance.MouseOverBackColor = Color.CadetBlue;
            Manage_users.FlatStyle = FlatStyle.Flat;
            Manage_users.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Manage_users.ForeColor = SystemColors.ControlLightLight;
            Manage_users.Location = new Point(68, 213);
            Manage_users.Margin = new Padding(4, 3, 4, 3);
            Manage_users.Name = "Manage_users";
            Manage_users.Size = new Size(156, 52);
            Manage_users.TabIndex = 1;
            Manage_users.Text = "Manage Users";
            Manage_users.UseVisualStyleBackColor = false;
            Manage_users.Click += Manage_users_Click;
            // 
            // Upload_files
            // 
            Upload_files.BackColor = Color.FromArgb(33, 79, 95);
            Upload_files.FlatAppearance.BorderSize = 0;
            Upload_files.FlatAppearance.MouseDownBackColor = Color.CadetBlue;
            Upload_files.FlatAppearance.MouseOverBackColor = Color.FromArgb(194, 220, 255);
            Upload_files.FlatStyle = FlatStyle.Flat;
            Upload_files.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Upload_files.ForeColor = SystemColors.ControlLightLight;
            Upload_files.Location = new Point(68, 291);
            Upload_files.Margin = new Padding(0);
            Upload_files.Name = "Upload_files";
            Upload_files.Size = new Size(156, 52);
            Upload_files.TabIndex = 1;
            Upload_files.Text = "Upload Files";
            Upload_files.UseVisualStyleBackColor = false;
            Upload_files.Click += Upload_Cars_btn_Click;
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
            // Manage_bookings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(862, 557);
            Controls.Add(user_background);
            Margin = new Padding(4, 3, 4, 3);
            Name = "Manage_bookings";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Manage_bookings";
            user_background.ResumeLayout(false);
            user_background.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);

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
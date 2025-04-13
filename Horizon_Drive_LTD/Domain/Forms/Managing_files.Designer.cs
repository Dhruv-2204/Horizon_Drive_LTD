namespace Upload_cars
{
    partial class Managing_files
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
            panel1 = new Panel();
            Logout_btn = new Button();
            Manage_bookings_btn = new Button();
            Manage_users = new Button();
            Upload_Cars_btn = new Button();
            pictureBox1 = new PictureBox();
            panel4 = new Panel();
            Search_Users = new Label();
            Save_button = new Button();
            user_background = new Panel();
            DragDropListBox = new ListBox();
            UploadButton = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel4.SuspendLayout();
            user_background.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            panel1.BackColor = Color.FromArgb(20, 48, 65);
            panel1.Controls.Add(Logout_btn);
            panel1.Controls.Add(Manage_bookings_btn);
            panel1.Controls.Add(Manage_users);
            panel1.Controls.Add(Upload_Cars_btn);
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
            Logout_btn.Cursor = Cursors.Hand;
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
            Logout_btn.Click += Logout_btn_Click;
            // 
            // Manage_bookings_btn
            // 
            Manage_bookings_btn.BackColor = Color.FromArgb(33, 79, 95);
            Manage_bookings_btn.Cursor = Cursors.Hand;
            Manage_bookings_btn.FlatAppearance.BorderSize = 0;
            Manage_bookings_btn.FlatAppearance.MouseDownBackColor = Color.Transparent;
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
            Manage_bookings_btn.Click += Manage_bookings_btn_Click;
            // 
            // Manage_users
            // 
            Manage_users.BackColor = Color.FromArgb(33, 79, 95);
            Manage_users.Cursor = Cursors.Hand;
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
            Manage_users.Click += Manage_Users_Click;
            // 
            // Upload_Cars_btn
            // 
            Upload_Cars_btn.BackColor = Color.FromArgb(194, 229, 255);
            Upload_Cars_btn.Cursor = Cursors.Hand;
            Upload_Cars_btn.FlatAppearance.BorderSize = 0;
            Upload_Cars_btn.FlatAppearance.MouseDownBackColor = Color.Transparent;
            Upload_Cars_btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(194, 220, 255);
            Upload_Cars_btn.FlatStyle = FlatStyle.Flat;
            Upload_Cars_btn.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Upload_Cars_btn.ForeColor = SystemColors.ControlText;
            Upload_Cars_btn.Location = new Point(68, 291);
            Upload_Cars_btn.Margin = new Padding(0);
            Upload_Cars_btn.Name = "Upload_Cars_btn";
            Upload_Cars_btn.Size = new Size(156, 52);
            Upload_Cars_btn.TabIndex = 1;
            Upload_Cars_btn.Text = "Upload Files";
            Upload_Cars_btn.UseVisualStyleBackColor = false;
            Upload_Cars_btn.Click += Upload_Cars_btn_Click;
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
            // panel4
            // 
            panel4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel4.AutoSize = true;
            panel4.Controls.Add(Search_Users);
            panel4.Location = new Point(341, 3);
            panel4.Margin = new Padding(4, 3, 4, 3);
            panel4.Name = "panel4";
            panel4.Size = new Size(510, 152);
            panel4.TabIndex = 9;
            // 
            // Search_Users
            // 
            Search_Users.Anchor = AnchorStyles.None;
            Search_Users.AutoSize = true;
            Search_Users.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            Search_Users.Location = new Point(130, 17);
            Search_Users.Margin = new Padding(4, 0, 4, 0);
            Search_Users.Name = "Search_Users";
            Search_Users.Size = new Size(199, 37);
            Search_Users.TabIndex = 7;
            Search_Users.Text = "UPLOAD FILES";
            Search_Users.Click += Search_Users_Click;
            // 
            // Save_button
            // 
            Save_button.Anchor = AnchorStyles.Top;
            Save_button.BackColor = Color.FromArgb(33, 79, 95);
            Save_button.Cursor = Cursors.Hand;
            Save_button.FlatAppearance.MouseOverBackColor = Color.FromArgb(108, 129, 255);
            Save_button.FlatStyle = FlatStyle.Popup;
            Save_button.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Save_button.ForeColor = SystemColors.ControlLightLight;
            Save_button.Location = new Point(626, 108);
            Save_button.Margin = new Padding(4, 3, 4, 3);
            Save_button.Name = "Save_button";
            Save_button.Size = new Size(150, 44);
            Save_button.TabIndex = 10;
            Save_button.Text = "Save File To Database";
            Save_button.UseVisualStyleBackColor = false;
            Save_button.Click += Save_button_clicked;
            // 
            // user_background
            // 
            user_background.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            user_background.BackColor = Color.Silver;
            user_background.Controls.Add(DragDropListBox);
            user_background.Controls.Add(UploadButton);
            user_background.Controls.Add(Save_button);
            user_background.Controls.Add(panel4);
            user_background.Controls.Add(panel1);
            user_background.Location = new Point(-2, 0);
            user_background.Margin = new Padding(4, 3, 4, 3);
            user_background.Name = "user_background";
            user_background.Size = new Size(864, 558);
            user_background.TabIndex = 1;
            // 
            // DragDropListBox
            // 
            DragDropListBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            DragDropListBox.Font = new Font("Times New Roman", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            DragDropListBox.FormattingEnabled = true;
            DragDropListBox.Location = new Point(364, 182);
            DragDropListBox.Margin = new Padding(4, 3, 4, 3);
            DragDropListBox.Name = "DragDropListBox";
            DragDropListBox.Size = new Size(452, 319);
            DragDropListBox.TabIndex = 12;
            // 
            // UploadButton
            // 
            UploadButton.Anchor = AnchorStyles.Top;
            UploadButton.BackColor = Color.FromArgb(33, 79, 95);
            UploadButton.Cursor = Cursors.Hand;
            UploadButton.FlatAppearance.BorderSize = 0;
            UploadButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(108, 129, 255);
            UploadButton.FlatStyle = FlatStyle.Popup;
            UploadButton.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            UploadButton.ForeColor = SystemColors.ControlLightLight;
            UploadButton.Location = new Point(393, 108);
            UploadButton.Margin = new Padding(4, 3, 4, 3);
            UploadButton.Name = "UploadButton";
            UploadButton.Size = new Size(150, 44);
            UploadButton.TabIndex = 11;
            UploadButton.Text = "Upload File";
            UploadButton.UseVisualStyleBackColor = false;
            UploadButton.Click += UploadButton_Click;
            // 
            // Managing_files
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(862, 557);
            Controls.Add(user_background);
            Margin = new Padding(4, 3, 4, 3);
            Name = "Managing_files";
            StartPosition = FormStartPosition.CenterScreen;
            Text = ".";
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            user_background.ResumeLayout(false);
            user_background.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button Logout_btn;
        private System.Windows.Forms.Button Manage_bookings_btn;
        private System.Windows.Forms.Button Manage_users;
        private System.Windows.Forms.Button Upload_Cars_btn;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label Search_Users;
        private System.Windows.Forms.Button Save_button;
        private System.Windows.Forms.Panel user_background;
        private System.Windows.Forms.Button UploadButton;
        private System.Windows.Forms.ListBox DragDropListBox;
    }
}
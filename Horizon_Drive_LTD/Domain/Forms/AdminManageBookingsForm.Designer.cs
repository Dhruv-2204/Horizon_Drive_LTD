// AdminManageBookingsForm.Designer.cs
namespace WindowsFormsApp1
{
    partial class AdminManageBookingsForm
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
            filterPanel = new Panel();
            dtpEndDate = new DateTimePicker();
            dtpStartDate = new DateTimePicker();
            lblDateRange = new Label();
            cmbStatus = new ComboBox();
            lblStatus = new Label();
            txtSearch = new TextBox();
            btnSearch = new Button();
            lblSearch = new Label();
            dataGridView2 = new DataGridView();
            panel4 = new Panel();
            Search_Users = new Label();
            panel1 = new Panel();
            Maintenance_btn = new Button();
            Logout_btn = new Button();
            Manage_bookings_btn = new Button();
            Manage_users = new Button();
            Upload_files = new Button();
            pictureBox1 = new PictureBox();
            user_background.SuspendLayout();
            filterPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            panel4.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // user_background
            // 
            user_background.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            user_background.BackColor = Color.FromArgb(224, 224, 224);
            user_background.Controls.Add(filterPanel);
            user_background.Controls.Add(dataGridView2);
            user_background.Controls.Add(panel4);
            user_background.Controls.Add(panel1);
            user_background.Location = new Point(-1, -1);
            user_background.Margin = new Padding(5, 4, 5, 4);
            user_background.Name = "user_background";
            user_background.Size = new Size(1216, 877);
            user_background.TabIndex = 2;
            // 
            // filterPanel
            // 
            filterPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            filterPanel.BackColor = Color.WhiteSmoke;
            filterPanel.BorderStyle = BorderStyle.FixedSingle;
            filterPanel.Controls.Add(dtpEndDate);
            filterPanel.Controls.Add(dtpStartDate);
            filterPanel.Controls.Add(lblDateRange);
            filterPanel.Controls.Add(cmbStatus);
            filterPanel.Controls.Add(lblStatus);
            filterPanel.Controls.Add(txtSearch);
            filterPanel.Controls.Add(btnSearch);
            filterPanel.Controls.Add(lblSearch);
            filterPanel.Location = new Point(396, 105);
            filterPanel.Margin = new Padding(3, 4, 3, 4);
            filterPanel.Name = "filterPanel";
            filterPanel.Size = new Size(768, 60);
            filterPanel.TabIndex = 12;
            // 
            // dtpEndDate
            // 
            dtpEndDate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            dtpEndDate.Format = DateTimePickerFormat.Short;
            dtpEndDate.Location = new Point(650, 16);
            dtpEndDate.Margin = new Padding(3, 4, 3, 4);
            dtpEndDate.Name = "dtpEndDate";
            dtpEndDate.Size = new Size(108, 27);
            dtpEndDate.TabIndex = 7;
            dtpEndDate.ValueChanged += dtpEndDate_ValueChanged;
            // 
            // dtpStartDate
            // 
            dtpStartDate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            dtpStartDate.Format = DateTimePickerFormat.Short;
            dtpStartDate.Location = new Point(534, 16);
            dtpStartDate.Margin = new Padding(3, 4, 3, 4);
            dtpStartDate.Name = "dtpStartDate";
            dtpStartDate.Size = new Size(108, 27);
            dtpStartDate.TabIndex = 6;
            dtpStartDate.ValueChanged += dtpStartDate_ValueChanged;
            // 
            // lblDateRange
            // 
            lblDateRange.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblDateRange.AutoSize = true;
            lblDateRange.Location = new Point(445, 21);
            lblDateRange.Name = "lblDateRange";
            lblDateRange.Size = new Size(90, 20);
            lblDateRange.TabIndex = 5;
            lblDateRange.Text = "Date Range:";
            // 
            // cmbStatus
            // 
            cmbStatus.FormattingEnabled = true;
            cmbStatus.Items.AddRange(new object[] { "All", "Confirmed", "Canceled", "Completed" });
            cmbStatus.Location = new Point(330, 16);
            cmbStatus.Margin = new Padding(3, 4, 3, 4);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(113, 28);
            cmbStatus.TabIndex = 4;
            cmbStatus.Text = "All";
            cmbStatus.SelectedIndexChanged += cmbStatus_SelectedIndexChanged;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(279, 21);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(52, 20);
            lblStatus.TabIndex = 3;
            lblStatus.Text = "Status:";
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(63, 16);
            txtSearch.Margin = new Padding(3, 4, 3, 4);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(153, 27);
            txtSearch.TabIndex = 2;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(223, 15);
            btnSearch.Margin = new Padding(3, 4, 3, 4);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(49, 33);
            btnSearch.TabIndex = 1;
            btnSearch.Text = "Go";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Location = new Point(7, 21);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(56, 20);
            lblSearch.TabIndex = 0;
            lblSearch.Text = "Search:";
            // 
            // dataGridView2
            // 
            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.AllowUserToDeleteRows = false;
            dataGridView2.AllowUserToResizeColumns = false;
            dataGridView2.AllowUserToResizeRows = false;
            dataGridView2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView2.BackgroundColor = Color.White;
            dataGridView2.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(396, 173);
            dataGridView2.Margin = new Padding(5, 4, 5, 4);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.ReadOnly = true;
            dataGridView2.RowHeadersWidth = 51;
            dataGridView2.RowTemplate.Height = 30;
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.Size = new Size(768, 671);
            dataGridView2.TabIndex = 11;
            dataGridView2.CellClick += DataGridView2_CellClick;
            // 
            // panel4
            // 
            panel4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel4.AutoSize = true;
            panel4.Controls.Add(Search_Users);
            panel4.Location = new Point(396, 14);
            panel4.Margin = new Padding(5, 4, 5, 4);
            panel4.Name = "panel4";
            panel4.Size = new Size(763, 91);
            panel4.TabIndex = 9;
            // 
            // Search_Users
            // 
            Search_Users.Anchor = AnchorStyles.None;
            Search_Users.AutoSize = true;
            Search_Users.Font = new Font("Segoe UI", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Search_Users.Location = new Point(180, 14);
            Search_Users.Margin = new Padding(5, 0, 5, 0);
            Search_Users.Name = "Search_Users";
            Search_Users.Size = new Size(464, 62);
            Search_Users.TabIndex = 7;
            Search_Users.Text = "MANAGE BOOKING";
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            panel1.BackColor = Color.FromArgb(20, 48, 65);
            panel1.Controls.Add(Maintenance_btn);
            panel1.Controls.Add(Logout_btn);
            panel1.Controls.Add(Manage_bookings_btn);
            panel1.Controls.Add(Manage_users);
            panel1.Controls.Add(Upload_files);
            panel1.Controls.Add(pictureBox1);
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(5, 4, 5, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(343, 877);
            panel1.TabIndex = 0;
            // 
            // Maintenance_btn
            // 
            Maintenance_btn.BackColor = Color.FromArgb(33, 79, 95);
            Maintenance_btn.Cursor = Cursors.Hand;
            Maintenance_btn.FlatAppearance.BorderSize = 0;
            Maintenance_btn.FlatAppearance.MouseOverBackColor = Color.CadetBlue;
            Maintenance_btn.FlatStyle = FlatStyle.Flat;
            Maintenance_btn.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            Maintenance_btn.ForeColor = SystemColors.ButtonHighlight;
            Maintenance_btn.Location = new Point(78, 559);
            Maintenance_btn.Margin = new Padding(5, 4, 5, 4);
            Maintenance_btn.Name = "Maintenance_btn";
            Maintenance_btn.Size = new Size(178, 71);
            Maintenance_btn.TabIndex = 3;
            Maintenance_btn.Text = "Maintenance";
            Maintenance_btn.UseVisualStyleBackColor = false;
            Maintenance_btn.Click += Maintenance_btn_Click;
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
            Logout_btn.Location = new Point(78, 657);
            Logout_btn.Margin = new Padding(5, 4, 5, 4);
            Logout_btn.Name = "Logout_btn";
            Logout_btn.Size = new Size(178, 71);
            Logout_btn.TabIndex = 2;
            Logout_btn.Text = "Log Out";
            Logout_btn.UseVisualStyleBackColor = false;
            Logout_btn.Click += Logout_btn_Click;
            // 
            // Manage_bookings_btn
            // 
            Manage_bookings_btn.BackColor = Color.FromArgb(194, 229, 255);
            Manage_bookings_btn.Cursor = Cursors.Hand;
            Manage_bookings_btn.FlatAppearance.BorderSize = 0;
            Manage_bookings_btn.FlatAppearance.MouseDownBackColor = Color.Transparent;
            Manage_bookings_btn.FlatAppearance.MouseOverBackColor = Color.CadetBlue;
            Manage_bookings_btn.FlatStyle = FlatStyle.Flat;
            Manage_bookings_btn.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            Manage_bookings_btn.ForeColor = SystemColors.ControlText;
            Manage_bookings_btn.Location = new Point(78, 460);
            Manage_bookings_btn.Margin = new Padding(5, 4, 5, 4);
            Manage_bookings_btn.Name = "Manage_bookings_btn";
            Manage_bookings_btn.Size = new Size(178, 71);
            Manage_bookings_btn.TabIndex = 1;
            Manage_bookings_btn.Text = "Manage Bookings";
            Manage_bookings_btn.UseVisualStyleBackColor = false;
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
            Manage_users.Location = new Point(78, 268);
            Manage_users.Margin = new Padding(5, 4, 5, 4);
            Manage_users.Name = "Manage_users";
            Manage_users.Size = new Size(178, 69);
            Manage_users.TabIndex = 1;
            Manage_users.Text = "Manage Users";
            Manage_users.UseVisualStyleBackColor = false;
            Manage_users.Click += Manage_users_Click;
            // 
            // Upload_files
            // 
            Upload_files.BackColor = Color.FromArgb(33, 79, 95);
            Upload_files.Cursor = Cursors.Hand;
            Upload_files.FlatAppearance.BorderSize = 0;
            Upload_files.FlatAppearance.MouseDownBackColor = Color.CadetBlue;
            Upload_files.FlatAppearance.MouseOverBackColor = Color.FromArgb(194, 220, 255);
            Upload_files.FlatStyle = FlatStyle.Flat;
            Upload_files.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Upload_files.ForeColor = SystemColors.ControlLightLight;
            Upload_files.Location = new Point(78, 363);
            Upload_files.Margin = new Padding(0);
            Upload_files.Name = "Upload_files";
            Upload_files.Size = new Size(178, 69);
            Upload_files.TabIndex = 1;
            Upload_files.Text = "Upload Files";
            Upload_files.UseVisualStyleBackColor = false;
            Upload_files.Click += Upload_Cars_btn_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.ErrorImage = null;
            pictureBox1.InitialImage = null;
            pictureBox1.Location = new Point(63, 44);
            pictureBox1.Margin = new Padding(5, 4, 5, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(207, 216);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // AdminManageBookingsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1214, 876);
            Controls.Add(user_background);
            Margin = new Padding(5, 4, 5, 4);
            Name = "AdminManageBookingsForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Manage Bookings - Horizon Drive LTD";
            Load += ManageBookingsForm_Load;
            user_background.ResumeLayout(false);
            user_background.PerformLayout();
            filterPanel.ResumeLayout(false);
            filterPanel.PerformLayout();
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
        private Button Maintenance_btn;
        private Panel filterPanel;
        private DateTimePicker dtpEndDate;
        private DateTimePicker dtpStartDate;
        private Label lblDateRange;
        private ComboBox cmbStatus;
        private Label lblStatus;
        private TextBox txtSearch;
        private Button btnSearch;
        private Label lblSearch;
    }
}
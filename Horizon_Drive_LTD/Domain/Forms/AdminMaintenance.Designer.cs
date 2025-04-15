namespace Horizon_Drive_LTD.Domain.Forms
{
    partial class AdminMaintenance
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
            addMaintenanceBtn = new Button();
            panel4 = new Panel();
            label1 = new Label();
            panel2 = new Panel();
            dataGridView1 = new DataGridView();
            panel1 = new Panel();
            Maintenance_btn = new Button();
            Logout_btn = new Button();
            Manage_bookings_btn = new Button();
            Manage_Users = new Button();
            Manage_files_btn = new Button();
            pictureBox1 = new PictureBox();
            user_background.SuspendLayout();
            panel4.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // user_background
            // 
            user_background.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            user_background.BackColor = Color.FromArgb(224, 224, 224);
            user_background.Controls.Add(addMaintenanceBtn);
            user_background.Controls.Add(panel4);
            user_background.Controls.Add(panel2);
            user_background.Controls.Add(panel1);
            user_background.Location = new Point(0, -3);
            user_background.Margin = new Padding(5, 4, 5, 4);
            user_background.Name = "user_background";
            user_background.Size = new Size(986, 747);
            user_background.TabIndex = 1;
           
            // 
            // addMaintenanceBtn
            // 
            addMaintenanceBtn.BackColor = Color.FromArgb(33, 79, 95);
            addMaintenanceBtn.Cursor = Cursors.Hand;
            addMaintenanceBtn.FlatAppearance.BorderSize = 0;
            addMaintenanceBtn.FlatStyle = FlatStyle.Flat;
            addMaintenanceBtn.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            addMaintenanceBtn.ForeColor = Color.White;
            addMaintenanceBtn.Location = new Point(557, 680);
            addMaintenanceBtn.Name = "addMaintenanceBtn";
            addMaintenanceBtn.Size = new Size(200, 40);
            addMaintenanceBtn.TabIndex = 11;
            addMaintenanceBtn.Text = "Add New Maintenance";
            addMaintenanceBtn.UseVisualStyleBackColor = false;
            addMaintenanceBtn.Click += AddMaintenanceButton_Click;
            // 
            // panel4
            // 
            panel4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel4.AutoSize = true;
            panel4.Controls.Add(label1);
            panel4.Location = new Point(388, 79);
            panel4.Margin = new Padding(3, 4, 3, 4);
            panel4.Name = "panel4";
            panel4.Size = new Size(558, 112);
            panel4.TabIndex = 10;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(3, 27);
            label1.Name = "label1";
            label1.Size = new Size(559, 62);
            label1.TabIndex = 9;
            label1.Text = "Cars under Maintenance";
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel2.Controls.Add(dataGridView1);
            panel2.Location = new Point(376, 199);
            panel2.Margin = new Padding(5, 4, 5, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(579, 467);
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
            dataGridView1.Margin = new Padding(5, 4, 5, 4);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 30;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(579, 467);
            dataGridView1.TabIndex = 4;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            panel1.BackColor = Color.FromArgb(20, 48, 65);
            panel1.Controls.Add(Maintenance_btn);
            panel1.Controls.Add(Logout_btn);
            panel1.Controls.Add(Manage_bookings_btn);
            panel1.Controls.Add(Manage_Users);
            panel1.Controls.Add(Manage_files_btn);
            panel1.Controls.Add(pictureBox1);
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(5, 4, 5, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(343, 747);
            panel1.TabIndex = 0;
            // 
            // Maintenance_btn
            // 
            Maintenance_btn.BackColor = Color.FromArgb(194, 229, 255);
            Maintenance_btn.Cursor = Cursors.Hand;
            Maintenance_btn.FlatAppearance.BorderSize = 0;
            Maintenance_btn.FlatAppearance.MouseDownBackColor = Color.CadetBlue;
            Maintenance_btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(194, 220, 255);
            Maintenance_btn.FlatStyle = FlatStyle.Flat;
            Maintenance_btn.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Maintenance_btn.ForeColor = SystemColors.ActiveCaptionText;
            Maintenance_btn.Location = new Point(78, 543);
            Maintenance_btn.Margin = new Padding(0);
            Maintenance_btn.Name = "Maintenance_btn";
            Maintenance_btn.Size = new Size(178, 69);
            Maintenance_btn.TabIndex = 3;
            Maintenance_btn.Text = "Maintenance";
            Maintenance_btn.UseVisualStyleBackColor = false;
            //
            // Manage_bookings_btn
            // 
            Manage_bookings_btn.BackColor = Color.FromArgb(33, 79, 95);
            Manage_bookings_btn.Cursor = Cursors.Hand;
            Manage_bookings_btn.FlatAppearance.BorderSize = 0;
            Manage_bookings_btn.FlatAppearance.MouseOverBackColor = Color.CadetBlue;
            Manage_bookings_btn.FlatStyle = FlatStyle.Flat;
            Manage_bookings_btn.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            Manage_bookings_btn.ForeColor = SystemColors.ButtonHighlight;
            Manage_bookings_btn.Location = new Point(78, 451);
            Manage_bookings_btn.Margin = new Padding(5, 4, 5, 4);
            Manage_bookings_btn.Name = "Manage_bookings_btn";
            Manage_bookings_btn.Size = new Size(178, 71);
            Manage_bookings_btn.TabIndex = 1;
            Manage_bookings_btn.Text = "Manage Bookings";
            Manage_bookings_btn.UseVisualStyleBackColor = false;
            Manage_bookings_btn.Click += Manage_bookings_btn_Click;
            // 
            // Manage_Users
            // 
            Manage_Users.BackColor = Color.FromArgb(33, 79, 95);
            Manage_Users.Cursor = Cursors.Hand;
            Manage_Users.FlatAppearance.BorderSize = 0;
            Manage_Users.FlatStyle = FlatStyle.Popup;
            Manage_Users.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Manage_Users.ForeColor = SystemColors.ControlLightLight;
            Manage_Users.Location = new Point(78, 268);
            Manage_Users.Margin = new Padding(5, 4, 5, 4);
            Manage_Users.Name = "Manage_Users";
            Manage_Users.Size = new Size(178, 69);
            Manage_Users.TabIndex = 1;
            Manage_Users.Text = "Manage Users";
            Manage_Users.UseVisualStyleBackColor = false;
            Manage_Users.Click += Manage_Users_Click;
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
            Logout_btn.Location = new Point(78, 637);
            Logout_btn.Margin = new Padding(5, 4, 5, 4);
            Logout_btn.Name = "Logout_btn";
            Logout_btn.Size = new Size(178, 71);
            Logout_btn.TabIndex = 2;
            Logout_btn.Text = "Log Out";
            Logout_btn.UseVisualStyleBackColor = false;
            // 
            // Manage_files_btn
            // 
            Manage_files_btn.BackColor = Color.FromArgb(33, 79, 95);
            Manage_files_btn.Cursor = Cursors.Hand;
            Manage_files_btn.FlatAppearance.BorderSize = 0;
            Manage_files_btn.FlatAppearance.MouseDownBackColor = Color.CadetBlue;
            Manage_files_btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(194, 220, 255);
            Manage_files_btn.FlatStyle = FlatStyle.Flat;
            Manage_files_btn.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Manage_files_btn.ForeColor = SystemColors.ButtonHighlight;
            Manage_files_btn.Location = new Point(78, 359);
            Manage_files_btn.Margin = new Padding(0);
            Manage_files_btn.Name = "Manage_files_btn";
            Manage_files_btn.Size = new Size(178, 69);
            Manage_files_btn.TabIndex = 1;
            Manage_files_btn.Text = "Upload Files";
            Manage_files_btn.UseVisualStyleBackColor = false;
            Manage_files_btn.Click += Manage_files_btn_Click;
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
            // 
            // AdminMaintenance
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(985, 743);
            Controls.Add(user_background);
            Margin = new Padding(3, 4, 3, 4);
            Name = "AdminMaintenance";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Maintenance";
            user_background.ResumeLayout(false);
            user_background.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel user_background;
        private Panel panel2;
        private Panel panel1;
        private Button Maintenance_btn;
        private Button Logout_btn;
        private Button Manage_bookings_btn;
        private Button Manage_Users;
        private Button Manage_files_btn;
        private PictureBox pictureBox1;
        private Panel panel4;
        private Label label1;
        private DataGridView dataGridView1;
        private Button addMaintenanceBtn;
    }
}
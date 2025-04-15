namespace Horizon_Drive_LTD
{
    partial class ManageBookings
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
            panelSidebar = new Panel();
            btnManageBooking = new RoundedButton();
            btnManageYourListings = new RoundedButton();
            btnOptions = new RoundedButton();
            btnListCar = new RoundedButton();
            btnBrowseListings = new RoundedButton();
            pictureBoxLogo = new PictureBox();
            btnLogout = new RoundedButton();
            panelMain = new Panel();
            panelContent = new Panel();
            bookingsFlowPanel = new FlowLayoutPanel();
            panelHeader = new Panel();
            labelUsername = new Label();
            filterPanel = new Panel();
            btnCancelled = new Button();
            btnCompleted = new Button();
            btnUpcoming = new Button();
            panelSearch = new Panel();
            buttonSearch = new Button();
            textBoxSearch = new TextBox();
            labelManageBookings = new Label();
            buttonProfile = new Button();
            panelSidebar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).BeginInit();
            panelMain.SuspendLayout();
            panelContent.SuspendLayout();
            panelHeader.SuspendLayout();
            filterPanel.SuspendLayout();
            panelSearch.SuspendLayout();
            SuspendLayout();
            // 
            // panelSidebar
            // 
            panelSidebar.BackColor = Color.FromArgb(15, 30, 45);
            panelSidebar.Controls.Add(btnManageBooking);
            panelSidebar.Controls.Add(btnManageYourListings);
            panelSidebar.Controls.Add(btnOptions);
            panelSidebar.Controls.Add(btnListCar);
            panelSidebar.Controls.Add(btnBrowseListings);
            panelSidebar.Controls.Add(pictureBoxLogo);
            panelSidebar.Controls.Add(btnLogout);
            panelSidebar.Dock = DockStyle.Left;
            panelSidebar.Location = new Point(0, 0);
            panelSidebar.Margin = new Padding(5, 4, 5, 4);
            panelSidebar.Name = "panelSidebar";
            panelSidebar.Size = new Size(333, 960);
            panelSidebar.TabIndex = 0;
            // 
            // btnManageBooking
            // 
            btnManageBooking.BackColor = Color.FromArgb(173, 216, 230);
            btnManageBooking.FlatAppearance.BorderSize = 0;
            btnManageBooking.FlatStyle = FlatStyle.Flat;
            btnManageBooking.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnManageBooking.ForeColor = Color.Black;
            btnManageBooking.Location = new Point(72, 421);
            btnManageBooking.Margin = new Padding(5, 4, 5, 4);
            btnManageBooking.Name = "btnManageBooking";
            btnManageBooking.Size = new Size(195, 65);
            btnManageBooking.TabIndex = 8;
            btnManageBooking.Text = "Manage Booking";
            btnManageBooking.UseVisualStyleBackColor = false;
            btnManageBooking.Click += btnManageBooking_Click;
            // 
            // btnManageYourListings
            // 
            btnManageYourListings.BackColor = Color.FromArgb(30, 85, 110);
            btnManageYourListings.FlatAppearance.BorderSize = 0;
            btnManageYourListings.FlatStyle = FlatStyle.Flat;
            btnManageYourListings.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnManageYourListings.ForeColor = Color.White;
            btnManageYourListings.Location = new Point(72, 597);
            btnManageYourListings.Margin = new Padding(5, 4, 5, 4);
            btnManageYourListings.Name = "btnManageYourListings";
            btnManageYourListings.Size = new Size(195, 65);
            btnManageYourListings.TabIndex = 7;
            btnManageYourListings.Text = "Manage your Listings";
            btnManageYourListings.UseVisualStyleBackColor = false;
            btnManageYourListings.Click += btnManageYourListings_Click;
            // 
            // btnOptions
            // 
            btnOptions.BackColor = Color.FromArgb(30, 85, 110);
            btnOptions.FlatAppearance.BorderSize = 0;
            btnOptions.FlatStyle = FlatStyle.Flat;
            btnOptions.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnOptions.ForeColor = Color.White;
            btnOptions.Location = new Point(72, 687);
            btnOptions.Margin = new Padding(5, 4, 5, 4);
            btnOptions.Name = "btnOptions";
            btnOptions.Size = new Size(195, 65);
            btnOptions.TabIndex = 4;
            btnOptions.Text = "Options";
            btnOptions.UseVisualStyleBackColor = false;
            btnOptions.Click += btnOptions_Click;
            // 
            // btnListCar
            // 
            btnListCar.BackColor = Color.FromArgb(30, 85, 110);
            btnListCar.FlatAppearance.BorderSize = 0;
            btnListCar.FlatStyle = FlatStyle.Flat;
            btnListCar.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnListCar.ForeColor = Color.White;
            btnListCar.Location = new Point(72, 509);
            btnListCar.Margin = new Padding(5, 4, 5, 4);
            btnListCar.Name = "btnListCar";
            btnListCar.Size = new Size(195, 65);
            btnListCar.TabIndex = 2;
            btnListCar.Text = "List a car";
            btnListCar.UseVisualStyleBackColor = false;
            btnListCar.Click += btnListCar_Click;
            // 
            // btnBrowseListings
            // 
            btnBrowseListings.BackColor = Color.FromArgb(30, 85, 110);
            btnBrowseListings.FlatAppearance.BorderSize = 0;
            btnBrowseListings.FlatStyle = FlatStyle.Flat;
            btnBrowseListings.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnBrowseListings.ForeColor = Color.White;
            btnBrowseListings.Location = new Point(72, 332);
            btnBrowseListings.Margin = new Padding(5, 4, 5, 4);
            btnBrowseListings.Name = "btnBrowseListings";
            btnBrowseListings.Size = new Size(195, 65);
            btnBrowseListings.TabIndex = 1;
            btnBrowseListings.Text = "Browse listings";
            btnBrowseListings.UseVisualStyleBackColor = false;
            btnBrowseListings.Click += btnBrowseListings_Click;
            // 
            // pictureBoxLogo
            // 
            pictureBoxLogo.Location = new Point(62, 63);
            pictureBoxLogo.Margin = new Padding(5, 4, 5, 4);
            pictureBoxLogo.Name = "pictureBoxLogo";
            pictureBoxLogo.Size = new Size(215, 245);
            pictureBoxLogo.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxLogo.TabIndex = 0;
            pictureBoxLogo.TabStop = false;
            pictureBoxLogo.Image = Horizon_Drive_LTD.Properties.Resources.Logo;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.FromArgb(30, 85, 110);
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnLogout.ForeColor = Color.White;
            btnLogout.Location = new Point(72, 775);
            btnLogout.Margin = new Padding(5, 4, 5, 4);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(195, 65);
            btnLogout.TabIndex = 6;
            btnLogout.Text = "Log out";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click;
            // 
            // panelMain
            // 
            panelMain.BackColor = Color.White;
            panelMain.Controls.Add(panelContent);
            panelMain.Controls.Add(panelHeader);
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(333, 0);
            panelMain.Margin = new Padding(5, 4, 5, 4);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(1130, 960);
            panelMain.TabIndex = 1;
            // 
            // panelContent
            // 
            panelContent.Controls.Add(bookingsFlowPanel);
            panelContent.Dock = DockStyle.Fill;
            panelContent.Location = new Point(0, 193);
            panelContent.Margin = new Padding(5, 4, 5, 4);
            panelContent.Name = "panelContent";
            panelContent.Padding = new Padding(27, 31, 27, 31);
            panelContent.Size = new Size(1130, 767);
            panelContent.TabIndex = 1;
            // 
            // bookingsFlowPanel
            // 
            bookingsFlowPanel.AutoScroll = true;
            bookingsFlowPanel.Dock = DockStyle.Fill;
            bookingsFlowPanel.FlowDirection = FlowDirection.TopDown;
            bookingsFlowPanel.Location = new Point(27, 31);
            bookingsFlowPanel.Margin = new Padding(5, 4, 5, 4);
            bookingsFlowPanel.Name = "bookingsFlowPanel";
            bookingsFlowPanel.Size = new Size(1076, 705);
            bookingsFlowPanel.TabIndex = 0;
            bookingsFlowPanel.WrapContents = false;
            // 
            // panelHeader
            // 
            panelHeader.Controls.Add(labelUsername);
            panelHeader.Controls.Add(filterPanel);
            panelHeader.Controls.Add(panelSearch);
            panelHeader.Controls.Add(labelManageBookings);
            panelHeader.Controls.Add(buttonProfile);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Margin = new Padding(5, 4, 5, 4);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1130, 193);
            panelHeader.TabIndex = 0;
            // 
            // labelUsername
            // 
            labelUsername.AutoSize = true;
            labelUsername.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelUsername.ForeColor = Color.FromArgb(15, 30, 45);
            labelUsername.Location = new Point(893, 78);
            labelUsername.Name = "labelUsername";
            labelUsername.Size = new Size(152, 23);
            labelUsername.TabIndex = 6;
            labelUsername.Text = "User not logged in";
            // 
            // filterPanel
            // 
            filterPanel.Controls.Add(btnCancelled);
            filterPanel.Controls.Add(btnCompleted);
            filterPanel.Controls.Add(btnUpcoming);
            filterPanel.Location = new Point(27, 127);
            filterPanel.Margin = new Padding(3, 4, 3, 4);
            filterPanel.Name = "filterPanel";
            filterPanel.Size = new Size(446, 53);
            filterPanel.TabIndex = 5;
            // 
            // btnCancelled
            // 
            btnCancelled.BackColor = Color.FromArgb(30, 85, 110);
            btnCancelled.FlatAppearance.BorderSize = 0;
            btnCancelled.FlatStyle = FlatStyle.Flat;
            btnCancelled.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCancelled.ForeColor = Color.White;
            btnCancelled.Location = new Point(297, 0);
            btnCancelled.Margin = new Padding(3, 4, 3, 4);
            btnCancelled.Name = "btnCancelled";
            btnCancelled.Size = new Size(126, 47);
            btnCancelled.TabIndex = 2;
            btnCancelled.Text = "Cancelled";
            btnCancelled.UseVisualStyleBackColor = false;
            btnCancelled.Click += btnCancelled_Click;
            // 
            // btnCompleted
            // 
            btnCompleted.BackColor = Color.FromArgb(30, 85, 110);
            btnCompleted.FlatAppearance.BorderSize = 0;
            btnCompleted.FlatStyle = FlatStyle.Flat;
            btnCompleted.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCompleted.ForeColor = Color.White;
            btnCompleted.Location = new Point(149, 0);
            btnCompleted.Margin = new Padding(3, 4, 3, 4);
            btnCompleted.Name = "btnCompleted";
            btnCompleted.Size = new Size(126, 47);
            btnCompleted.TabIndex = 1;
            btnCompleted.Text = "Completed";
            btnCompleted.UseVisualStyleBackColor = false;
            btnCompleted.Click += btnCompleted_Click;
            // 
            // btnUpcoming
            // 
            btnUpcoming.BackColor = Color.FromArgb(173, 216, 230);
            btnUpcoming.FlatAppearance.BorderSize = 0;
            btnUpcoming.FlatStyle = FlatStyle.Flat;
            btnUpcoming.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnUpcoming.ForeColor = Color.Black;
            btnUpcoming.Location = new Point(0, 0);
            btnUpcoming.Margin = new Padding(3, 4, 3, 4);
            btnUpcoming.Name = "btnUpcoming";
            btnUpcoming.Size = new Size(126, 47);
            btnUpcoming.TabIndex = 0;
            btnUpcoming.Text = "Upcoming";
            btnUpcoming.UseVisualStyleBackColor = false;
            btnUpcoming.Click += btnUpcoming_Click;
            // 
            // panelSearch
            // 
            panelSearch.AutoSize = true;
            panelSearch.BackColor = Color.White;
            panelSearch.BorderStyle = BorderStyle.FixedSingle;
            panelSearch.Controls.Add(buttonSearch);
            panelSearch.Controls.Add(textBoxSearch);
            panelSearch.Location = new Point(832, 121);
            panelSearch.Margin = new Padding(5, 4, 5, 4);
            panelSearch.Name = "panelSearch";
            panelSearch.Size = new Size(271, 50);
            panelSearch.TabIndex = 1;
            // 
            // buttonSearch
            // 
            buttonSearch.BackColor = Color.White;
            buttonSearch.FlatAppearance.BorderSize = 0;
            buttonSearch.FlatStyle = FlatStyle.Flat;
            buttonSearch.Font = new Font("Segoe MDL2 Assets", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonSearch.Location = new Point(224, 0);
            buttonSearch.Margin = new Padding(5, 4, 5, 4);
            buttonSearch.Name = "buttonSearch";
            buttonSearch.Size = new Size(40, 43);
            buttonSearch.TabIndex = 1;
            buttonSearch.Text = "🔍";
            buttonSearch.UseVisualStyleBackColor = false;
            // 
            // textBoxSearch
            // 
            textBoxSearch.BorderStyle = BorderStyle.None;
            textBoxSearch.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxSearch.Location = new Point(7, 8);
            textBoxSearch.Margin = new Padding(5, 4, 5, 4);
            textBoxSearch.Name = "textBoxSearch";
            textBoxSearch.Size = new Size(213, 22);
            textBoxSearch.TabIndex = 0;
            textBoxSearch.TextChanged += textBoxSearch_TextChanged;
            // 
            // labelManageBookings
            // 
            labelManageBookings.AutoSize = true;
            labelManageBookings.Font = new Font("Bahnschrift SemiCondensed", 28.1454544F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelManageBookings.ForeColor = Color.FromArgb(15, 30, 45);
            labelManageBookings.Location = new Point(27, 49);
            labelManageBookings.Margin = new Padding(5, 0, 5, 0);
            labelManageBookings.Name = "labelManageBookings";
            labelManageBookings.Size = new Size(435, 57);
            labelManageBookings.TabIndex = 0;
            labelManageBookings.Text = "Manage Your Bookings";
            // 
            // buttonProfile
            // 
            buttonProfile.AutoSize = true;
            buttonProfile.BackColor = Color.White;
            buttonProfile.FlatAppearance.BorderColor = Color.FromArgb(192, 192, 192);
            buttonProfile.FlatStyle = FlatStyle.Flat;
            buttonProfile.Font = new Font("Segoe UI Symbol", 12F);
            buttonProfile.Location = new Point(1053, 61);
            buttonProfile.Margin = new Padding(5, 4, 5, 4);
            buttonProfile.Name = "buttonProfile";
            buttonProfile.Size = new Size(50, 53);
            buttonProfile.TabIndex = 4;
            buttonProfile.Text = "👤";
            buttonProfile.UseVisualStyleBackColor = false;
            buttonProfile.Click += buttonProfile_Click;
            // 
            // ManageBookings
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1463, 960);
            Controls.Add(panelMain);
            Controls.Add(panelSidebar);
            Margin = new Padding(5, 4, 5, 4);
            Name = "ManageBookings";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Horizon Drive - Manage Bookings";
            Load += ManageBookings_Load;
            panelSidebar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).EndInit();
            panelMain.ResumeLayout(false);
            panelContent.ResumeLayout(false);
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            filterPanel.ResumeLayout(false);
            panelSearch.ResumeLayout(false);
            panelSearch.PerformLayout();
            ResumeLayout(false);


        }

        #endregion

        private System.Windows.Forms.Panel panelSidebar;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private RoundedButton btnOptions;
        private RoundedButton btnListCar;
        private RoundedButton btnBrowseListings;
        private RoundedButton btnLogout;
        private Button buttonProfile;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label labelManageBookings;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.FlowLayoutPanel bookingsFlowPanel;
        private System.Windows.Forms.Panel panelSearch;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Button buttonSearch;
        private RoundedButton btnManageYourListings;
        private RoundedButton btnManageBooking;
        private Panel filterPanel;
        private Button btnCancelled;
        private Button btnCompleted;
        private Button btnUpcoming;
        private Label labelUsername;
    }
}
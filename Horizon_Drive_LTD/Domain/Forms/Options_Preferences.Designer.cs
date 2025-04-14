namespace Horizon_Drive_LTD

//Options_Preferences.Designer.cs
{
    partial class Options_Preferences
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
            btnLogout = new RoundedButton();
            btnOptions = new RoundedButton();
            btnManageYourListings = new RoundedButton();
            btnListCar = new RoundedButton();
            btnManageBooking = new RoundedButton();
            btnBrowseListings = new RoundedButton();
            pictureBoxLogo = new PictureBox();
            mainScrollPanel = new Panel();
            panelMain = new Panel();
            btnSaveChanges = new RoundedButton();
            textBoxLicenseExpiry = new TextBox();
            labelLicenseExpiry = new Label();
            textBoxLicenseNumber = new TextBox();
            labelLicenseNumber = new Label();
            panelUploadLicense = new Panel();
            buttonUploadLicense = new Button();
            labelUploadLicense = new Label();
            panelTabs = new Panel();
            btnPreferences = new RoundedButton();
            btnPersonal = new RoundedButton();
            labelAccountSettings = new Label();
            panelSidebar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).BeginInit();
            mainScrollPanel.SuspendLayout();
            panelMain.SuspendLayout();
            panelUploadLicense.SuspendLayout();
            panelTabs.SuspendLayout();
            SuspendLayout();
            // 
            // panelSidebar
            // 
            panelSidebar.BackColor = Color.FromArgb(15, 30, 45);
            panelSidebar.Controls.Add(btnLogout);
            panelSidebar.Controls.Add(btnOptions);
            panelSidebar.Controls.Add(btnManageYourListings);
            panelSidebar.Controls.Add(btnListCar);
            panelSidebar.Controls.Add(btnManageBooking);
            panelSidebar.Controls.Add(btnBrowseListings);
            panelSidebar.Controls.Add(pictureBoxLogo);
            panelSidebar.Dock = DockStyle.Left;
            panelSidebar.Location = new Point(0, 0);
            panelSidebar.Margin = new Padding(3, 4, 3, 4);
            panelSidebar.Name = "panelSidebar";
            panelSidebar.Size = new Size(291, 953);
            panelSidebar.TabIndex = 0;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.FromArgb(30, 85, 110);
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnLogout.ForeColor = Color.White;
            btnLogout.Location = new Point(63, 727);
            btnLogout.Margin = new Padding(3, 4, 3, 4);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(171, 61);
            btnLogout.TabIndex = 6;
            btnLogout.Text = "Log out";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click;
            // 
            // btnOptions
            // 
            btnOptions.BackColor = Color.FromArgb(173, 216, 230);
            btnOptions.FlatAppearance.BorderSize = 0;
            btnOptions.FlatStyle = FlatStyle.Flat;
            btnOptions.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnOptions.ForeColor = Color.Black;
            btnOptions.Location = new Point(63, 644);
            btnOptions.Margin = new Padding(3, 4, 3, 4);
            btnOptions.Name = "btnOptions";
            btnOptions.Size = new Size(171, 61);
            btnOptions.TabIndex = 4;
            btnOptions.Text = "Options";
            btnOptions.UseVisualStyleBackColor = false;
            btnOptions.Click += btnOptions_Click;
            // 
            // btnManageYourListings
            // 
            btnManageYourListings.BackColor = Color.FromArgb(30, 85, 110);
            btnManageYourListings.FlatAppearance.BorderSize = 0;
            btnManageYourListings.FlatStyle = FlatStyle.Flat;
            btnManageYourListings.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnManageYourListings.ForeColor = Color.White;
            btnManageYourListings.Location = new Point(63, 560);
            btnManageYourListings.Margin = new Padding(3, 4, 3, 4);
            btnManageYourListings.Name = "btnManageYourListings";
            btnManageYourListings.Size = new Size(171, 61);
            btnManageYourListings.TabIndex = 7;
            btnManageYourListings.Text = "Manage your Listings";
            btnManageYourListings.UseVisualStyleBackColor = false;
            btnManageYourListings.Click += btnManageYourListings_Click;
            // 
            // btnListCar
            // 
            btnListCar.BackColor = Color.FromArgb(30, 85, 110);
            btnListCar.FlatAppearance.BorderSize = 0;
            btnListCar.FlatStyle = FlatStyle.Flat;
            btnListCar.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnListCar.ForeColor = Color.White;
            btnListCar.Location = new Point(63, 477);
            btnListCar.Margin = new Padding(3, 4, 3, 4);
            btnListCar.Name = "btnListCar";
            btnListCar.Size = new Size(171, 61);
            btnListCar.TabIndex = 2;
            btnListCar.Text = "List a car";
            btnListCar.UseVisualStyleBackColor = false;
            btnListCar.Click += btnListCar_Click;
            // 
            // btnManageBooking
            // 
            btnManageBooking.BackColor = Color.FromArgb(30, 85, 110);
            btnManageBooking.FlatAppearance.BorderSize = 0;
            btnManageBooking.FlatStyle = FlatStyle.Flat;
            btnManageBooking.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnManageBooking.ForeColor = Color.White;
            btnManageBooking.Location = new Point(63, 395);
            btnManageBooking.Margin = new Padding(3, 4, 3, 4);
            btnManageBooking.Name = "btnManageBooking";
            btnManageBooking.Size = new Size(171, 61);
            btnManageBooking.TabIndex = 8;
            btnManageBooking.Text = "Manage Booking";
            btnManageBooking.UseVisualStyleBackColor = false;
            btnManageBooking.Click += btnManageBooking_Click;
            // 
            // btnBrowseListings
            // 
            btnBrowseListings.BackColor = Color.FromArgb(30, 85, 110);
            btnBrowseListings.FlatAppearance.BorderSize = 0;
            btnBrowseListings.FlatStyle = FlatStyle.Flat;
            btnBrowseListings.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnBrowseListings.ForeColor = Color.White;
            btnBrowseListings.Location = new Point(63, 312);
            btnBrowseListings.Margin = new Padding(3, 4, 3, 4);
            btnBrowseListings.Name = "btnBrowseListings";
            btnBrowseListings.Size = new Size(171, 61);
            btnBrowseListings.TabIndex = 1;
            btnBrowseListings.Text = "Browse listings";
            btnBrowseListings.UseVisualStyleBackColor = false;
            btnBrowseListings.Click += btnBrowseListings_Click;
            // 
            // pictureBoxLogo
            // 
            // Load the logo image from the Images folder
            pictureBoxLogo.Image = Image.FromFile(Path.Combine("Images", "Logo.png"));
            pictureBoxLogo.Location = new Point(54, 59);
            pictureBoxLogo.Margin = new Padding(3, 4, 3, 4);
            pictureBoxLogo.Name = "pictureBoxLogo";
            pictureBoxLogo.Size = new Size(187, 229);
            pictureBoxLogo.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxLogo.TabIndex = 0;
            pictureBoxLogo.TabStop = false;
            pictureBoxLogo.Click += pictureBoxLogo_Click;
            // 
            // mainScrollPanel
            // 
            mainScrollPanel.AutoScroll = true;
            mainScrollPanel.Controls.Add(panelMain);
            mainScrollPanel.Dock = DockStyle.Fill;
            mainScrollPanel.Location = new Point(291, 0);
            mainScrollPanel.Margin = new Padding(3, 4, 3, 4);
            mainScrollPanel.Name = "mainScrollPanel";
            mainScrollPanel.Size = new Size(890, 953);
            mainScrollPanel.TabIndex = 2;
            // 
            // panelMain
            // 
            panelMain.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panelMain.AutoSize = true;
            panelMain.BackColor = Color.White;
            panelMain.Controls.Add(btnSaveChanges);
            panelMain.Controls.Add(textBoxLicenseExpiry);
            panelMain.Controls.Add(labelLicenseExpiry);
            panelMain.Controls.Add(textBoxLicenseNumber);
            panelMain.Controls.Add(labelLicenseNumber);
            panelMain.Controls.Add(panelUploadLicense);
            panelMain.Controls.Add(labelUploadLicense);
            panelMain.Controls.Add(panelTabs);
            panelMain.Controls.Add(labelAccountSettings);
            panelMain.Location = new Point(0, 0);
            panelMain.Margin = new Padding(3, 4, 3, 4);
            panelMain.Name = "panelMain";
            panelMain.Padding = new Padding(40, 51, 40, 51);
            panelMain.Size = new Size(890, 953);
            panelMain.TabIndex = 1;
            // 
            // btnSaveChanges
            // 
            btnSaveChanges.Anchor = AnchorStyles.Bottom;
            btnSaveChanges.BackColor = Color.FromArgb(30, 85, 110);
            btnSaveChanges.FlatAppearance.BorderSize = 0;
            btnSaveChanges.FlatStyle = FlatStyle.Flat;
            btnSaveChanges.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSaveChanges.ForeColor = Color.White;
            btnSaveChanges.Location = new Point(347, 514);
            btnSaveChanges.Margin = new Padding(3, 4, 3, 4);
            btnSaveChanges.Name = "btnSaveChanges";
            btnSaveChanges.Size = new Size(171, 61);
            btnSaveChanges.TabIndex = 9;
            btnSaveChanges.Text = "Save Changes";
            btnSaveChanges.UseVisualStyleBackColor = false;
            btnSaveChanges.Click += btnSaveChanges_Click;
            // 
            // textBoxLicenseExpiry
            // 
            textBoxLicenseExpiry.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxLicenseExpiry.BorderStyle = BorderStyle.FixedSingle;
            textBoxLicenseExpiry.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxLicenseExpiry.Location = new Point(66, 452);
            textBoxLicenseExpiry.Margin = new Padding(3, 4, 3, 4);
            textBoxLicenseExpiry.MinimumSize = new Size(754, 43);
            textBoxLicenseExpiry.Name = "textBoxLicenseExpiry";
            textBoxLicenseExpiry.Size = new Size(758, 43);
            textBoxLicenseExpiry.TabIndex = 17;
            // 
            // labelLicenseExpiry
            // 
            labelLicenseExpiry.AutoSize = true;
            labelLicenseExpiry.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelLicenseExpiry.Location = new Point(66, 422);
            labelLicenseExpiry.Name = "labelLicenseExpiry";
            labelLicenseExpiry.Size = new Size(178, 25);
            labelLicenseExpiry.TabIndex = 16;
            labelLicenseExpiry.Text = "License Expiry Date:";
            // 
            // textBoxLicenseNumber
            // 
            textBoxLicenseNumber.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxLicenseNumber.BorderStyle = BorderStyle.FixedSingle;
            textBoxLicenseNumber.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxLicenseNumber.Location = new Point(66, 352);
            textBoxLicenseNumber.Margin = new Padding(3, 4, 3, 4);
            textBoxLicenseNumber.MinimumSize = new Size(754, 43);
            textBoxLicenseNumber.Name = "textBoxLicenseNumber";
            textBoxLicenseNumber.Size = new Size(758, 43);
            textBoxLicenseNumber.TabIndex = 15;
            // 
            // labelLicenseNumber
            // 
            labelLicenseNumber.AutoSize = true;
            labelLicenseNumber.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelLicenseNumber.Location = new Point(66, 322);
            labelLicenseNumber.Name = "labelLicenseNumber";
            labelLicenseNumber.Size = new Size(220, 25);
            labelLicenseNumber.TabIndex = 14;
            labelLicenseNumber.Text = "Driver's License Number:";
            // 
            // panelUploadLicense
            // 
            panelUploadLicense.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panelUploadLicense.BorderStyle = BorderStyle.FixedSingle;
            panelUploadLicense.Controls.Add(buttonUploadLicense);
            panelUploadLicense.Location = new Point(66, 252);
            panelUploadLicense.Margin = new Padding(3, 4, 3, 4);
            panelUploadLicense.Name = "panelUploadLicense";
            panelUploadLicense.Size = new Size(758, 50);
            panelUploadLicense.TabIndex = 13;
            // 
            // buttonUploadLicense
            // 
            buttonUploadLicense.BackColor = Color.White;
            buttonUploadLicense.Dock = DockStyle.Left;
            buttonUploadLicense.FlatAppearance.BorderSize = 0;
            buttonUploadLicense.FlatStyle = FlatStyle.Flat;
            buttonUploadLicense.Font = new Font("Segoe UI Symbol", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonUploadLicense.Location = new Point(0, 0);
            buttonUploadLicense.Margin = new Padding(3, 4, 3, 4);
            buttonUploadLicense.Name = "buttonUploadLicense";
            buttonUploadLicense.Size = new Size(37, 48);
            buttonUploadLicense.TabIndex = 1;
            buttonUploadLicense.Text = "📄";
            buttonUploadLicense.UseVisualStyleBackColor = false;
            buttonUploadLicense.Click += buttonUploadLicense_Click;
            // 
            // labelUploadLicense
            // 
            labelUploadLicense.AutoSize = true;
            labelUploadLicense.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelUploadLicense.Location = new Point(66, 222);
            labelUploadLicense.Name = "labelUploadLicense";
            labelUploadLicense.Size = new Size(267, 25);
            labelUploadLicense.TabIndex = 12;
            labelUploadLicense.Text = "Upload Driver's License Photo:";
            // 
            // panelTabs
            // 
            panelTabs.Controls.Add(btnPreferences);
            panelTabs.Controls.Add(btnPersonal);
            panelTabs.Location = new Point(66, 116);
            panelTabs.Margin = new Padding(3, 4, 3, 4);
            panelTabs.Name = "panelTabs";
            panelTabs.Size = new Size(315, 75);
            panelTabs.TabIndex = 2;
            // 
            // btnPreferences
            // 
            btnPreferences.BackColor = Color.FromArgb(173, 216, 230);
            btnPreferences.FlatAppearance.BorderSize = 0;
            btnPreferences.FlatStyle = FlatStyle.Flat;
            btnPreferences.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnPreferences.ForeColor = Color.Black;
            btnPreferences.Location = new Point(159, 4);
            btnPreferences.Margin = new Padding(3, 4, 3, 4);
            btnPreferences.Name = "btnPreferences";
            btnPreferences.Size = new Size(139, 56);
            btnPreferences.TabIndex = 1;
            btnPreferences.Text = "Preferences";
            btnPreferences.UseVisualStyleBackColor = false;
            btnPreferences.Click += btnPreferences_Click;
            // 
            // btnPersonal
            // 
            btnPersonal.BackColor = Color.FromArgb(30, 85, 110);
            btnPersonal.FlatAppearance.BorderSize = 0;
            btnPersonal.FlatStyle = FlatStyle.Flat;
            btnPersonal.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnPersonal.ForeColor = Color.White;
            btnPersonal.Location = new Point(3, 4);
            btnPersonal.Margin = new Padding(3, 4, 3, 4);
            btnPersonal.Name = "btnPersonal";
            btnPersonal.Size = new Size(139, 56);
            btnPersonal.TabIndex = 0;
            btnPersonal.Text = "Personal";
            btnPersonal.UseVisualStyleBackColor = false;
            btnPersonal.Click += btnPersonal_Click;
            // 
            // labelAccountSettings
            // 
            labelAccountSettings.AutoSize = true;
            labelAccountSettings.Font = new Font("Bahnschrift SemiCondensed", 22F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelAccountSettings.ForeColor = Color.FromArgb(33, 79, 95);
            labelAccountSettings.Location = new Point(58, 59);
            labelAccountSettings.Name = "labelAccountSettings";
            labelAccountSettings.Size = new Size(262, 45);
            labelAccountSettings.TabIndex = 1;
            labelAccountSettings.Text = "Account Settings";
            // 
            // Options_Preferences
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1181, 953);
            Controls.Add(mainScrollPanel);
            Controls.Add(panelSidebar);
            Margin = new Padding(3, 4, 3, 4);
            MinimumSize = new Size(1000, 700);
            Name = "Options_Preferences";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Horizon Drive - Account Settings";
            panelSidebar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).EndInit();
            mainScrollPanel.ResumeLayout(false);
            mainScrollPanel.PerformLayout();
            panelMain.ResumeLayout(false);
            panelMain.PerformLayout();
            panelUploadLicense.ResumeLayout(false);
            panelTabs.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelSidebar;
        private RoundedButton btnManageBooking;
        private RoundedButton btnManageYourListings;
        private RoundedButton btnOptions;
        private RoundedButton btnListCar;
        private RoundedButton btnBrowseListings;
        private PictureBox pictureBoxLogo;
        private RoundedButton btnLogout;
        private Panel mainScrollPanel;
        private Panel panelMain;
        private Label labelAccountSettings;
        private Panel panelTabs;
        private RoundedButton btnPreferences;
        private RoundedButton btnPersonal;
        private Label labelUploadLicense;
        private Panel panelUploadLicense;
        private Button buttonUploadLicense;
        private TextBox textBoxLicenseNumber;
        private Label labelLicenseNumber;
        private TextBox textBoxLicenseExpiry;
        private Label labelLicenseExpiry;
        private RoundedButton btnSaveChanges;
    }
}
using System.Drawing;
using System.Windows.Forms;

namespace Horizon_Drive_LTD
{
    partial class ListCarForm
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
            openFileDialogPhotos = new OpenFileDialog();
            panelHeader = new Panel();
            UsernameLabel = new Label();
            buttonProfile = new Button();
            lblListYourCar = new Label();
            panelMain = new Panel();
            panelContent = new Panel();
            cboSeatNumber = new ComboBox();
            lblSeatNumber = new Label();
            txtPower = new TextBox();
            lblPower = new Label();
            txtEngineCapacity = new TextBox();
            lblEngineCapacity = new Label();
            cboDrivetrain = new ComboBox();
            lblDrivetrain = new Label();
            cboTransmission = new ComboBox();
            lblTransmission = new Label();
            cboFuelType = new ComboBox();
            lblFuelType = new Label();
            panelPhoto5 = new Panel();
            lblPlus5 = new Label();
            panelPhoto4 = new Panel();
            lblPlus4 = new Label();
            btnListMyCar = new Button();
            panelPhoto3 = new Panel();
            lblPlus3 = new Label();
            btnCancel = new Button();
            panelPhoto2 = new Panel();
            lblPlus2 = new Label();
            panelPhoto1 = new Panel();
            lblPlus1 = new Label();
            txtCarFeatures = new TextBox();
            lblCarFeatures = new Label();
            dateTimePickerEnd = new DateTimePicker();
            lblAvailabilityEnd = new Label();
            dateTimePickerStart = new DateTimePicker();
            lblAvailabilityStart = new Label();
            panelPhotoContainer = new Panel();
            panelUploadPhotos = new Panel();
            lblUploadInstructions = new Label();
            pictureBoxUpload = new PictureBox();
            lblUploadPhotos = new Label();
            lblUploadHint = new Label();
            txtDailyRate = new TextBox();
            lblDailyRate = new Label();
            lblRateHint = new Label();
            txtDescription = new TextBox();
            lblDescription = new Label();
            txtLicensePlate = new TextBox();
            lblLicensePlate = new Label();
            cboColor = new ComboBox();
            lblColor = new Label();
            cboType = new ComboBox();
            lblType = new Label();
            cboYear = new ComboBox();
            lblYear = new Label();
            cboModel = new ComboBox();
            lblModel = new Label();
            cboMake = new ComboBox();
            lblMake = new Label();
            panelSidebar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).BeginInit();
            panelHeader.SuspendLayout();
            panelMain.SuspendLayout();
            panelContent.SuspendLayout();
            panelPhoto5.SuspendLayout();
            panelPhoto4.SuspendLayout();
            panelPhoto3.SuspendLayout();
            panelPhoto2.SuspendLayout();
            panelPhoto1.SuspendLayout();
            panelUploadPhotos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxUpload).BeginInit();
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
            panelSidebar.Name = "panelSidebar";
            panelSidebar.Size = new Size(333, 900);
            panelSidebar.TabIndex = 0;
            // 
            // btnManageBooking
            // 
            btnManageBooking.BackColor = Color.FromArgb(30, 85, 110);
            btnManageBooking.FlatAppearance.BorderSize = 0;
            btnManageBooking.FlatStyle = FlatStyle.Flat;
            btnManageBooking.Font = new Font("Segoe UI", 12F);
            btnManageBooking.ForeColor = Color.White;
            btnManageBooking.Location = new Point(72, 421);
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
            btnManageYourListings.Font = new Font("Segoe UI", 12F);
            btnManageYourListings.ForeColor = Color.White;
            btnManageYourListings.Location = new Point(72, 597);
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
            btnOptions.Font = new Font("Segoe UI", 12F);
            btnOptions.ForeColor = Color.White;
            btnOptions.Location = new Point(72, 687);
            btnOptions.Name = "btnOptions";
            btnOptions.Size = new Size(195, 65);
            btnOptions.TabIndex = 4;
            btnOptions.Text = "Options";
            btnOptions.UseVisualStyleBackColor = false;
            btnOptions.Click += btnOptions_Click;
            // 
            // btnListCar
            // 
            btnListCar.BackColor = Color.FromArgb(173, 216, 230);
            btnListCar.FlatAppearance.BorderSize = 0;
            btnListCar.FlatStyle = FlatStyle.Flat;
            btnListCar.Font = new Font("Segoe UI", 12F);
            btnListCar.ForeColor = Color.Black;
            btnListCar.Location = new Point(72, 509);
            btnListCar.Name = "btnListCar";
            btnListCar.Size = new Size(195, 65);
            btnListCar.TabIndex = 2;
            btnListCar.Text = "List a car";
            btnListCar.UseVisualStyleBackColor = false;
            // 
            // btnBrowseListings
            // 
            btnBrowseListings.BackColor = Color.FromArgb(30, 85, 110);
            btnBrowseListings.FlatAppearance.BorderSize = 0;
            btnBrowseListings.FlatStyle = FlatStyle.Flat;
            btnBrowseListings.Font = new Font("Segoe UI", 12F);
            btnBrowseListings.ForeColor = Color.White;
            btnBrowseListings.Location = new Point(72, 332);
            btnBrowseListings.Name = "btnBrowseListings";
            btnBrowseListings.Size = new Size(195, 65);
            btnBrowseListings.TabIndex = 1;
            btnBrowseListings.Text = "Browse listings";
            btnBrowseListings.UseVisualStyleBackColor = false;
            btnBrowseListings.Click += btnBrowseListings_Click;
            // 
            // pictureBoxLogo
            // 
            pictureBoxLogo.Location = new Point(72, 63);
            pictureBoxLogo.Name = "pictureBoxLogo";
            pictureBoxLogo.Size = new Size(195, 245);
            pictureBoxLogo.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxLogo.TabIndex = 0;
            pictureBoxLogo.TabStop = false;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.FromArgb(30, 85, 110);
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Segoe UI", 12F);
            btnLogout.ForeColor = Color.White;
            btnLogout.Location = new Point(72, 775);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(195, 65);
            btnLogout.TabIndex = 6;
            btnLogout.Text = "Log out";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click;
            // 
            // openFileDialogPhotos
            // 
            openFileDialogPhotos.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialogPhotos.Multiselect = true;
            openFileDialogPhotos.Title = "Select Car Photos";
            // 
            // panelHeader
            // 
            panelHeader.BorderStyle = BorderStyle.FixedSingle;
            panelHeader.Controls.Add(UsernameLabel);
            panelHeader.Controls.Add(buttonProfile);
            panelHeader.Controls.Add(lblListYourCar);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.ForeColor = Color.MidnightBlue;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1267, 123);
            panelHeader.TabIndex = 1;
            // 
            // UsernameLabel
            // 
            UsernameLabel.AutoSize = true;
            UsernameLabel.Font = new Font("Segoe UI", 13.2000008F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            UsernameLabel.Location = new Point(1080, 54);
            UsernameLabel.Name = "UsernameLabel";
            UsernameLabel.Size = new Size(94, 31);
            UsernameLabel.TabIndex = 5;
            UsernameLabel.Text = "You -->";
            // 
            // buttonProfile
            // 
            buttonProfile.AutoSize = true;
            buttonProfile.BackColor = Color.White;
            buttonProfile.FlatAppearance.BorderColor = Color.FromArgb(192, 192, 192);
            buttonProfile.FlatStyle = FlatStyle.Flat;
            buttonProfile.Font = new Font("Segoe UI Symbol", 12F);
            buttonProfile.ForeColor = Color.FromArgb(30, 85, 110);
            buttonProfile.Location = new Point(1190, 43);
            buttonProfile.Name = "buttonProfile";
            buttonProfile.Size = new Size(50, 53);
            buttonProfile.TabIndex = 4;
            buttonProfile.Text = "👤";
            buttonProfile.UseVisualStyleBackColor = false;
            // 
            // lblListYourCar
            // 
            lblListYourCar.AutoSize = true;
            lblListYourCar.Font = new Font("Bahnschrift SemiCondensed", 28F, FontStyle.Bold);
            lblListYourCar.ForeColor = Color.FromArgb(15, 30, 45);
            lblListYourCar.Location = new Point(54, 48);
            lblListYourCar.Name = "lblListYourCar";
            lblListYourCar.Size = new Size(256, 57);
            lblListYourCar.TabIndex = 0;
            lblListYourCar.Text = "List Your Car";
            // 
            // panelMain
            // 
            panelMain.BackColor = Color.White;
            panelMain.Controls.Add(panelContent);
            panelMain.Controls.Add(panelHeader);
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(333, 0);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(1267, 900);
            panelMain.TabIndex = 1;
            // 
            // panelContent
            // 
            panelContent.AutoScroll = true;
            panelContent.BackColor = Color.FromArgb(240, 240, 240);
            panelContent.BorderStyle = BorderStyle.Fixed3D;
            panelContent.Controls.Add(cboSeatNumber);
            panelContent.Controls.Add(lblSeatNumber);
            panelContent.Controls.Add(txtPower);
            panelContent.Controls.Add(lblPower);
            panelContent.Controls.Add(txtEngineCapacity);
            panelContent.Controls.Add(lblEngineCapacity);
            panelContent.Controls.Add(cboDrivetrain);
            panelContent.Controls.Add(lblDrivetrain);
            panelContent.Controls.Add(cboTransmission);
            panelContent.Controls.Add(lblTransmission);
            panelContent.Controls.Add(cboFuelType);
            panelContent.Controls.Add(lblFuelType);
            panelContent.Controls.Add(panelPhoto5);
            panelContent.Controls.Add(panelPhoto4);
            panelContent.Controls.Add(btnListMyCar);
            panelContent.Controls.Add(panelPhoto3);
            panelContent.Controls.Add(btnCancel);
            panelContent.Controls.Add(panelPhoto2);
            panelContent.Controls.Add(panelPhoto1);
            panelContent.Controls.Add(txtCarFeatures);
            panelContent.Controls.Add(lblCarFeatures);
            panelContent.Controls.Add(dateTimePickerEnd);
            panelContent.Controls.Add(lblAvailabilityEnd);
            panelContent.Controls.Add(dateTimePickerStart);
            panelContent.Controls.Add(lblAvailabilityStart);
            panelContent.Controls.Add(panelPhotoContainer);
            panelContent.Controls.Add(panelUploadPhotos);
            panelContent.Controls.Add(lblUploadPhotos);
            panelContent.Controls.Add(lblUploadHint);
            panelContent.Controls.Add(txtDailyRate);
            panelContent.Controls.Add(lblDailyRate);
            panelContent.Controls.Add(lblRateHint);
            panelContent.Controls.Add(txtDescription);
            panelContent.Controls.Add(lblDescription);
            panelContent.Controls.Add(txtLicensePlate);
            panelContent.Controls.Add(lblLicensePlate);
            panelContent.Controls.Add(cboColor);
            panelContent.Controls.Add(lblColor);
            panelContent.Controls.Add(cboType);
            panelContent.Controls.Add(lblType);
            panelContent.Controls.Add(cboYear);
            panelContent.Controls.Add(lblYear);
            panelContent.Controls.Add(cboModel);
            panelContent.Controls.Add(lblModel);
            panelContent.Controls.Add(cboMake);
            panelContent.Controls.Add(lblMake);
            panelContent.Dock = DockStyle.Fill;
            panelContent.Location = new Point(0, 123);
            panelContent.Name = "panelContent";
            panelContent.Padding = new Padding(40);
            panelContent.Size = new Size(1267, 777);
            panelContent.TabIndex = 1;
            // 
            // cboSeatNumber
            // 
            cboSeatNumber.Font = new Font("Segoe UI", 11F);
            cboSeatNumber.FormattingEnabled = true;
            cboSeatNumber.Location = new Point(850, 270);
            cboSeatNumber.Margin = new Padding(3, 15, 3, 25);
            cboSeatNumber.Name = "cboSeatNumber";
            cboSeatNumber.Size = new Size(300, 33);
            cboSeatNumber.TabIndex = 80;
            cboSeatNumber.Text = "Select Seat Number";
            // 
            // lblSeatNumber
            // 
            lblSeatNumber.AutoSize = true;
            lblSeatNumber.Font = new Font("Segoe UI", 11F);
            lblSeatNumber.Location = new Point(850, 243);
            lblSeatNumber.Margin = new Padding(3, 25, 3, 5);
            lblSeatNumber.Name = "lblSeatNumber";
            lblSeatNumber.Size = new Size(135, 25);
            lblSeatNumber.TabIndex = 79;
            lblSeatNumber.Text = "Seat Number *";
            // 
            // txtPower
            // 
            txtPower.Font = new Font("Segoe UI", 11F);
            txtPower.Location = new Point(443, 270);
            txtPower.Margin = new Padding(3, 15, 3, 25);
            txtPower.Name = "txtPower";
            txtPower.PlaceholderText = "e.g. 150 HP";
            txtPower.Size = new Size(364, 32);
            txtPower.TabIndex = 78;
            // 
            // lblPower
            // 
            lblPower.AutoSize = true;
            lblPower.Font = new Font("Segoe UI", 11F);
            lblPower.Location = new Point(443, 243);
            lblPower.Margin = new Padding(3, 25, 3, 5);
            lblPower.Name = "lblPower";
            lblPower.Size = new Size(77, 25);
            lblPower.TabIndex = 77;
            lblPower.Text = "Power *";
            // 
            // txtEngineCapacity
            // 
            txtEngineCapacity.Font = new Font("Segoe UI", 11F);
            txtEngineCapacity.Location = new Point(36, 270);
            txtEngineCapacity.Margin = new Padding(3, 15, 3, 25);
            txtEngineCapacity.Name = "txtEngineCapacity";
            txtEngineCapacity.PlaceholderText = "e.g. 2.0L";
            txtEngineCapacity.Size = new Size(364, 32);
            txtEngineCapacity.TabIndex = 76;
            // 
            // lblEngineCapacity
            // 
            lblEngineCapacity.AutoSize = true;
            lblEngineCapacity.Font = new Font("Segoe UI", 11F);
            lblEngineCapacity.Location = new Point(36, 243);
            lblEngineCapacity.Margin = new Padding(3, 25, 3, 5);
            lblEngineCapacity.Name = "lblEngineCapacity";
            lblEngineCapacity.Size = new Size(160, 25);
            lblEngineCapacity.TabIndex = 75;
            lblEngineCapacity.Text = "Engine Capacity *";
            // 
            // cboDrivetrain
            // 
            cboDrivetrain.Font = new Font("Segoe UI", 11F);
            cboDrivetrain.FormattingEnabled = true;
            cboDrivetrain.Location = new Point(850, 197);
            cboDrivetrain.Margin = new Padding(3, 15, 3, 25);
            cboDrivetrain.Name = "cboDrivetrain";
            cboDrivetrain.Size = new Size(300, 33);
            cboDrivetrain.TabIndex = 74;
            cboDrivetrain.Text = "Select Drivetrain";
            // 
            // lblDrivetrain
            // 
            lblDrivetrain.AutoSize = true;
            lblDrivetrain.Font = new Font("Segoe UI", 11F);
            lblDrivetrain.Location = new Point(850, 167);
            lblDrivetrain.Margin = new Padding(3, 25, 3, 5);
            lblDrivetrain.Name = "lblDrivetrain";
            lblDrivetrain.Size = new Size(108, 25);
            lblDrivetrain.TabIndex = 73;
            lblDrivetrain.Text = "Drivetrain *";
            // 
            // cboTransmission
            // 
            cboTransmission.Font = new Font("Segoe UI", 11F);
            cboTransmission.FormattingEnabled = true;
            cboTransmission.Location = new Point(443, 197);
            cboTransmission.Margin = new Padding(3, 15, 3, 25);
            cboTransmission.Name = "cboTransmission";
            cboTransmission.Size = new Size(364, 33);
            cboTransmission.TabIndex = 72;
            cboTransmission.Text = "Select Transmission";
            // 
            // lblTransmission
            // 
            lblTransmission.AutoSize = true;
            lblTransmission.Font = new Font("Segoe UI", 11F);
            lblTransmission.Location = new Point(443, 167);
            lblTransmission.Margin = new Padding(3, 25, 3, 5);
            lblTransmission.Name = "lblTransmission";
            lblTransmission.Size = new Size(133, 25);
            lblTransmission.TabIndex = 71;
            lblTransmission.Text = "Transmission *";
            // 
            // cboFuelType
            // 
            cboFuelType.Font = new Font("Segoe UI", 11F);
            cboFuelType.FormattingEnabled = true;
            cboFuelType.Location = new Point(36, 197);
            cboFuelType.Margin = new Padding(3, 15, 3, 25);
            cboFuelType.Name = "cboFuelType";
            cboFuelType.Size = new Size(364, 33);
            cboFuelType.TabIndex = 70;
            cboFuelType.Text = "Select Fuel Type";
            // 
            // lblFuelType
            // 
            lblFuelType.AutoSize = true;
            lblFuelType.Font = new Font("Segoe UI", 11F);
            lblFuelType.Location = new Point(36, 167);
            lblFuelType.Margin = new Padding(3, 25, 3, 5);
            lblFuelType.Name = "lblFuelType";
            lblFuelType.Size = new Size(104, 25);
            lblFuelType.TabIndex = 69;
            lblFuelType.Text = "Fuel Type *";
            // 
            // panelPhoto5
            // 
            panelPhoto5.BackColor = Color.LightGray;
            panelPhoto5.Controls.Add(lblPlus5);
            panelPhoto5.Location = new Point(773, 835);
            panelPhoto5.Name = "panelPhoto5";
            panelPhoto5.Size = new Size(91, 124);
            panelPhoto5.TabIndex = 42;
            panelPhoto5.Visible = false;
            // 
            // lblPlus5
            // 
            lblPlus5.AutoSize = true;
            lblPlus5.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblPlus5.ForeColor = Color.Gray;
            lblPlus5.Location = new Point(26, 27);
            lblPlus5.Name = "lblPlus5";
            lblPlus5.Size = new Size(44, 46);
            lblPlus5.TabIndex = 0;
            lblPlus5.Text = "+";
            lblPlus5.Click += lblPlus5_Click;
            // 
            // panelPhoto4
            // 
            panelPhoto4.BackColor = Color.LightGray;
            panelPhoto4.Controls.Add(lblPlus4);
            panelPhoto4.Location = new Point(668, 835);
            panelPhoto4.Name = "panelPhoto4";
            panelPhoto4.Size = new Size(91, 124);
            panelPhoto4.TabIndex = 39;
            panelPhoto4.Visible = false;
            // 
            // lblPlus4
            // 
            lblPlus4.AutoSize = true;
            lblPlus4.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblPlus4.ForeColor = Color.Gray;
            lblPlus4.Location = new Point(26, 27);
            lblPlus4.Name = "lblPlus4";
            lblPlus4.Size = new Size(44, 46);
            lblPlus4.TabIndex = 0;
            lblPlus4.Text = "+";
            lblPlus4.Click += lblPlus4_Click;
            // 
            // btnListMyCar
            // 
            btnListMyCar.BackColor = Color.FromArgb(15, 30, 45);
            btnListMyCar.Font = new Font("Segoe UI", 11F);
            btnListMyCar.ForeColor = Color.White;
            btnListMyCar.Location = new Point(1011, 1052);
            btnListMyCar.Margin = new Padding(25, 15, 3, 3);
            btnListMyCar.Name = "btnListMyCar";
            btnListMyCar.Size = new Size(136, 56);
            btnListMyCar.TabIndex = 71;
            btnListMyCar.Text = "List My Car";
            btnListMyCar.UseVisualStyleBackColor = false;
            btnListMyCar.Click += btnListMyCar_Click;
            // 
            // panelPhoto3
            // 
            panelPhoto3.BackColor = Color.LightGray;
            panelPhoto3.Controls.Add(lblPlus3);
            panelPhoto3.Location = new Point(564, 835);
            panelPhoto3.Name = "panelPhoto3";
            panelPhoto3.Size = new Size(91, 124);
            panelPhoto3.TabIndex = 37;
            panelPhoto3.Visible = false;
            // 
            // lblPlus3
            // 
            lblPlus3.AutoSize = true;
            lblPlus3.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblPlus3.ForeColor = Color.Gray;
            lblPlus3.Location = new Point(26, 27);
            lblPlus3.Name = "lblPlus3";
            lblPlus3.Size = new Size(44, 46);
            lblPlus3.TabIndex = 0;
            lblPlus3.Text = "+";
            lblPlus3.Click += lblPlus3_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.LightGray;
            btnCancel.Font = new Font("Segoe UI", 11F);
            btnCancel.ForeColor = Color.Black;
            btnCancel.Location = new Point(871, 1052);
            btnCancel.Margin = new Padding(30, 15, 15, 3);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(128, 56);
            btnCancel.TabIndex = 70;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // panelPhoto2
            // 
            panelPhoto2.BackColor = Color.LightGray;
            panelPhoto2.Controls.Add(lblPlus2);
            panelPhoto2.Location = new Point(459, 835);
            panelPhoto2.Name = "panelPhoto2";
            panelPhoto2.Size = new Size(91, 124);
            panelPhoto2.TabIndex = 36;
            panelPhoto2.Visible = false;
            // 
            // lblPlus2
            // 
            lblPlus2.AutoSize = true;
            lblPlus2.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblPlus2.ForeColor = Color.Gray;
            lblPlus2.Location = new Point(26, 27);
            lblPlus2.Name = "lblPlus2";
            lblPlus2.Size = new Size(44, 46);
            lblPlus2.TabIndex = 0;
            lblPlus2.Text = "+";
            lblPlus2.Click += lblPlus2_Click;
            // 
            // panelPhoto1
            // 
            panelPhoto1.BackColor = Color.LightGray;
            panelPhoto1.Controls.Add(lblPlus1);
            panelPhoto1.Location = new Point(355, 835);
            panelPhoto1.Name = "panelPhoto1";
            panelPhoto1.Size = new Size(91, 124);
            panelPhoto1.TabIndex = 34;
            panelPhoto1.Visible = false;
            // 
            // lblPlus1
            // 
            lblPlus1.AutoSize = true;
            lblPlus1.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblPlus1.ForeColor = Color.Gray;
            lblPlus1.Location = new Point(25, 27);
            lblPlus1.Name = "lblPlus1";
            lblPlus1.Size = new Size(44, 46);
            lblPlus1.TabIndex = 0;
            lblPlus1.Text = "+";
            lblPlus1.Click += lblPlus1_Click;
            // 
            // txtCarFeatures
            // 
            txtCarFeatures.Font = new Font("Segoe UI", 11F);
            txtCarFeatures.Location = new Point(36, 463);
            txtCarFeatures.Margin = new Padding(3, 15, 3, 30);
            txtCarFeatures.Multiline = true;
            txtCarFeatures.Name = "txtCarFeatures";
            txtCarFeatures.PlaceholderText = "Describe what features your car have, Bluetooth, 360 Camera, etc...";
            txtCarFeatures.Size = new Size(1190, 72);
            txtCarFeatures.TabIndex = 68;
            // 
            // lblCarFeatures
            // 
            lblCarFeatures.AutoSize = true;
            lblCarFeatures.Font = new Font("Segoe UI", 11F);
            lblCarFeatures.Location = new Point(36, 437);
            lblCarFeatures.Margin = new Padding(3, 25, 3, 5);
            lblCarFeatures.Name = "lblCarFeatures";
            lblCarFeatures.Size = new Size(130, 25);
            lblCarFeatures.TabIndex = 67;
            lblCarFeatures.Text = "Car Features *";
            // 
            // dateTimePickerEnd
            // 
            dateTimePickerEnd.CalendarFont = new Font("Segoe UI", 11F);
            dateTimePickerEnd.Font = new Font("Segoe UI", 11F);
            dateTimePickerEnd.Format = DateTimePickerFormat.Short;
            dateTimePickerEnd.Location = new Point(580, 1010);
            dateTimePickerEnd.Margin = new Padding(25, 15, 3, 25);
            dateTimePickerEnd.Name = "dateTimePickerEnd";
            dateTimePickerEnd.Size = new Size(364, 32);
            dateTimePickerEnd.TabIndex = 63;
            // 
            // lblAvailabilityEnd
            // 
            lblAvailabilityEnd.AutoSize = true;
            lblAvailabilityEnd.Font = new Font("Segoe UI", 11F);
            lblAvailabilityEnd.Location = new Point(580, 975);
            lblAvailabilityEnd.Margin = new Padding(3, 25, 3, 5);
            lblAvailabilityEnd.Name = "lblAvailabilityEnd";
            lblAvailabilityEnd.Size = new Size(154, 25);
            lblAvailabilityEnd.TabIndex = 62;
            lblAvailabilityEnd.Text = "Availability End *";
            // 
            // dateTimePickerStart
            // 
            dateTimePickerStart.CalendarFont = new Font("Segoe UI", 11F);
            dateTimePickerStart.Font = new Font("Segoe UI", 11F);
            dateTimePickerStart.Format = DateTimePickerFormat.Short;
            dateTimePickerStart.Location = new Point(140, 1010);
            dateTimePickerStart.Margin = new Padding(3, 15, 3, 25);
            dateTimePickerStart.Name = "dateTimePickerStart";
            dateTimePickerStart.Size = new Size(364, 32);
            dateTimePickerStart.TabIndex = 61;
            // 
            // lblAvailabilityStart
            // 
            lblAvailabilityStart.AutoSize = true;
            lblAvailabilityStart.Font = new Font("Segoe UI", 11F);
            lblAvailabilityStart.Location = new Point(140, 975);
            lblAvailabilityStart.Margin = new Padding(3, 25, 3, 5);
            lblAvailabilityStart.Name = "lblAvailabilityStart";
            lblAvailabilityStart.Size = new Size(160, 25);
            lblAvailabilityStart.TabIndex = 60;
            lblAvailabilityStart.Text = "Availability Start *";
            // 
            // panelPhotoContainer
            // 
            panelPhotoContainer.BorderStyle = BorderStyle.FixedSingle;
            panelPhotoContainer.Location = new Point(36, 835);
            panelPhotoContainer.Margin = new Padding(3, 15, 3, 25);
            panelPhotoContainer.Name = "panelPhotoContainer";
            panelPhotoContainer.Size = new Size(1114, 124);
            panelPhotoContainer.TabIndex = 59;
            // 
            // panelUploadPhotos
            // 
            panelUploadPhotos.BorderStyle = BorderStyle.FixedSingle;
            panelUploadPhotos.Controls.Add(lblUploadInstructions);
            panelUploadPhotos.Controls.Add(pictureBoxUpload);
            panelUploadPhotos.Location = new Point(36, 685);
            panelUploadPhotos.Margin = new Padding(3, 15, 3, 15);
            panelUploadPhotos.Name = "panelUploadPhotos";
            panelUploadPhotos.Size = new Size(1114, 123);
            panelUploadPhotos.TabIndex = 58;
            panelUploadPhotos.Click += panelUploadPhotos_Click;
            panelUploadPhotos.Paint += PanelUploadPhotos_Paint;
            // 
            // lblUploadInstructions
            // 
            lblUploadInstructions.AutoSize = true;
            lblUploadInstructions.Font = new Font("Segoe UI", 10F);
            lblUploadInstructions.Location = new Point(355, 71);
            lblUploadInstructions.Name = "lblUploadInstructions";
            lblUploadInstructions.Size = new Size(415, 23);
            lblUploadInstructions.TabIndex = 1;
            lblUploadInstructions.Text = "Drag and drop photos here or double click to browse";
            // 
            // pictureBoxUpload
            // 
            pictureBoxUpload.Location = new Point(530, 18);
            pictureBoxUpload.Name = "pictureBoxUpload";
            pictureBoxUpload.Size = new Size(39, 53);
            pictureBoxUpload.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxUpload.TabIndex = 0;
            pictureBoxUpload.TabStop = false;
            // 
            // lblUploadPhotos
            // 
            lblUploadPhotos.AutoSize = true;
            lblUploadPhotos.Font = new Font("Segoe UI", 11F);
            lblUploadPhotos.Location = new Point(36, 650);
            lblUploadPhotos.Margin = new Padding(3, 25, 3, 5);
            lblUploadPhotos.Name = "lblUploadPhotos";
            lblUploadPhotos.Size = new Size(265, 25);
            lblUploadPhotos.TabIndex = 56;
            lblUploadPhotos.Text = "Upload Photos (Maximum 5) *";
            // 
            // lblUploadHint
            // 
            lblUploadHint.AutoSize = true;
            lblUploadHint.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            lblUploadHint.ForeColor = Color.Gray;
            lblUploadHint.Location = new Point(34, 813);
            lblUploadHint.Margin = new Padding(3, 5, 3, 5);
            lblUploadHint.Name = "lblUploadHint";
            lblUploadHint.Size = new Size(432, 20);
            lblUploadHint.TabIndex = 57;
            lblUploadHint.Text = "Photos must be 1:1 ratio (square), JPG/JPEG/PNG under 5MB each";
            // 
            // txtDailyRate
            // 
            txtDailyRate.Font = new Font("Segoe UI", 11F);
            txtDailyRate.Location = new Point(36, 578);
            txtDailyRate.Margin = new Padding(3, 15, 3, 5);
            txtDailyRate.Name = "txtDailyRate";
            txtDailyRate.PlaceholderText = "e.g. 7500.00";
            txtDailyRate.Size = new Size(1190, 32);
            txtDailyRate.TabIndex = 54;
            // 
            // lblDailyRate
            // 
            lblDailyRate.AutoSize = true;
            lblDailyRate.Font = new Font("Segoe UI", 11F);
            lblDailyRate.Location = new Point(36, 548);
            lblDailyRate.Margin = new Padding(3, 25, 3, 5);
            lblDailyRate.Name = "lblDailyRate";
            lblDailyRate.Size = new Size(167, 25);
            lblDailyRate.TabIndex = 53;
            lblDailyRate.Text = "Daily Rate (MUR) *";
            // 
            // lblRateHint
            // 
            lblRateHint.AutoSize = true;
            lblRateHint.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            lblRateHint.ForeColor = Color.Gray;
            lblRateHint.Location = new Point(34, 611);
            lblRateHint.Margin = new Padding(3, 5, 3, 25);
            lblRateHint.Name = "lblRateHint";
            lblRateHint.Size = new Size(294, 20);
            lblRateHint.TabIndex = 55;
            lblRateHint.Text = "Set a competitive daily rate to attract renters";
            // 
            // txtDescription
            // 
            txtDescription.Font = new Font("Segoe UI", 11F);
            txtDescription.Location = new Point(36, 358);
            txtDescription.Margin = new Padding(3, 15, 3, 25);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.PlaceholderText = "Describe your car, including condition, special features, etc.";
            txtDescription.Size = new Size(1190, 65);
            txtDescription.TabIndex = 52;
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Font = new Font("Segoe UI", 11F);
            lblDescription.Location = new Point(36, 328);
            lblDescription.Margin = new Padding(3, 25, 3, 5);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(155, 25);
            lblDescription.TabIndex = 51;
            lblDescription.Text = "Car Description *";
            // 
            // txtLicensePlate
            // 
            txtLicensePlate.Font = new Font("Segoe UI", 11F);
            txtLicensePlate.Location = new Point(850, 125);
            txtLicensePlate.Margin = new Padding(3, 15, 3, 25);
            txtLicensePlate.Name = "txtLicensePlate";
            txtLicensePlate.PlaceholderText = "Enter license plate";
            txtLicensePlate.Size = new Size(300, 32);
            txtLicensePlate.TabIndex = 50;
            // 
            // lblLicensePlate
            // 
            lblLicensePlate.AutoSize = true;
            lblLicensePlate.Font = new Font("Segoe UI", 11F);
            lblLicensePlate.Location = new Point(850, 95);
            lblLicensePlate.Margin = new Padding(3, 25, 3, 5);
            lblLicensePlate.Name = "lblLicensePlate";
            lblLicensePlate.Size = new Size(134, 25);
            lblLicensePlate.TabIndex = 49;
            lblLicensePlate.Text = "License Plate *";
            // 
            // cboColor
            // 
            cboColor.Font = new Font("Segoe UI", 11F);
            cboColor.FormattingEnabled = true;
            cboColor.Location = new Point(443, 125);
            cboColor.Margin = new Padding(3, 15, 3, 25);
            cboColor.Name = "cboColor";
            cboColor.Size = new Size(364, 33);
            cboColor.TabIndex = 48;
            cboColor.Text = "Select Color";
            // 
            // lblColor
            // 
            lblColor.AutoSize = true;
            lblColor.Font = new Font("Segoe UI", 11F);
            lblColor.Location = new Point(443, 95);
            lblColor.Margin = new Padding(3, 25, 3, 5);
            lblColor.Name = "lblColor";
            lblColor.Size = new Size(71, 25);
            lblColor.TabIndex = 47;
            lblColor.Text = "Color *";
            // 
            // cboType
            // 
            cboType.Font = new Font("Segoe UI", 11F);
            cboType.FormattingEnabled = true;
            cboType.Location = new Point(36, 125);
            cboType.Margin = new Padding(3, 15, 3, 25);
            cboType.Name = "cboType";
            cboType.Size = new Size(364, 33);
            cboType.TabIndex = 46;
            cboType.Text = "Select type";
            // 
            // lblType
            // 
            lblType.AutoSize = true;
            lblType.Font = new Font("Segoe UI", 11F);
            lblType.Location = new Point(36, 95);
            lblType.Margin = new Padding(3, 25, 3, 5);
            lblType.Name = "lblType";
            lblType.Size = new Size(64, 25);
            lblType.TabIndex = 45;
            lblType.Text = "Type *";
            // 
            // cboYear
            // 
            cboYear.Font = new Font("Segoe UI", 11F);
            cboYear.FormattingEnabled = true;
            cboYear.Location = new Point(850, 50);
            cboYear.Margin = new Padding(3, 15, 3, 25);
            cboYear.Name = "cboYear";
            cboYear.Size = new Size(300, 33);
            cboYear.TabIndex = 44;
            cboYear.Text = "Select Year";
            // 
            // lblYear
            // 
            lblYear.AutoSize = true;
            lblYear.Font = new Font("Segoe UI", 11F);
            lblYear.Location = new Point(850, 20);
            lblYear.Margin = new Padding(3, 20, 3, 5);
            lblYear.Name = "lblYear";
            lblYear.Size = new Size(61, 25);
            lblYear.TabIndex = 43;
            lblYear.Text = "Year *";
            // 
            // cboModel
            // 
            cboModel.Font = new Font("Segoe UI", 11F);
            cboModel.FormattingEnabled = true;
            cboModel.Location = new Point(443, 50);
            cboModel.Margin = new Padding(3, 15, 3, 25);
            cboModel.Name = "cboModel";
            cboModel.Size = new Size(364, 33);
            cboModel.TabIndex = 41;
            cboModel.Text = "Select Model";
            // 
            // lblModel
            // 
            lblModel.AutoSize = true;
            lblModel.Font = new Font("Segoe UI", 11F);
            lblModel.Location = new Point(443, 20);
            lblModel.Margin = new Padding(3, 20, 3, 5);
            lblModel.Name = "lblModel";
            lblModel.Size = new Size(79, 25);
            lblModel.TabIndex = 40;
            lblModel.Text = "Model *";
            // 
            // cboMake
            // 
            cboMake.Font = new Font("Segoe UI", 11F);
            cboMake.FormattingEnabled = true;
            cboMake.Location = new Point(36, 50);
            cboMake.Margin = new Padding(3, 15, 3, 25);
            cboMake.Name = "cboMake";
            cboMake.Size = new Size(364, 33);
            cboMake.TabIndex = 38;
            cboMake.Text = "Select Make";
            // 
            // lblMake
            // 
            lblMake.AutoSize = true;
            lblMake.Font = new Font("Segoe UI", 11F);
            lblMake.Location = new Point(36, 20);
            lblMake.Margin = new Padding(3, 20, 3, 5);
            lblMake.Name = "lblMake";
            lblMake.Size = new Size(71, 25);
            lblMake.TabIndex = 35;
            lblMake.Text = "Make *";
            // 
            // ListCarForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1600, 900);
            Controls.Add(panelMain);
            Controls.Add(panelSidebar);
            MinimumSize = new Size(1000, 700);
            Name = "ListCarForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Horizon Drive - List Your Car";
            Load += ListCarForm_Load;
            panelSidebar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).EndInit();
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelMain.ResumeLayout(false);
            panelContent.ResumeLayout(false);
            panelContent.PerformLayout();
            panelPhoto5.ResumeLayout(false);
            panelPhoto5.PerformLayout();
            panelPhoto4.ResumeLayout(false);
            panelPhoto4.PerformLayout();
            panelPhoto3.ResumeLayout(false);
            panelPhoto3.PerformLayout();
            panelPhoto2.ResumeLayout(false);
            panelPhoto2.PerformLayout();
            panelPhoto1.ResumeLayout(false);
            panelPhoto1.PerformLayout();
            panelUploadPhotos.ResumeLayout(false);
            panelUploadPhotos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxUpload).EndInit();
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
        private OpenFileDialog openFileDialogPhotos;
        private Panel panelHeader;
        private Button buttonProfile;
        private Label lblListYourCar;
        private Panel panelMain;
        private Panel panelContent;
        private Panel panelPhoto5;
        private Label lblPlus5;
        private Panel panelPhoto4;
        private Label lblPlus4;
        private Button btnListMyCar;
        private Panel panelPhoto3;
        private Label lblPlus3;
        private Button btnCancel;
        private Panel panelPhoto2;
        private Label lblPlus2;
        private Panel panelPhoto1;
        private Label lblPlus1;
        private TextBox txtCarFeatures;
        private Label lblCarFeatures;
        private DateTimePicker dateTimePickerEnd;
        private Label lblAvailabilityEnd;
        private DateTimePicker dateTimePickerStart;
        private Label lblAvailabilityStart;
        private Panel panelPhotoContainer;
        private Panel panelUploadPhotos;
        private Label lblUploadInstructions;
        private PictureBox pictureBoxUpload;
        private Label lblUploadPhotos;
        private Label lblUploadHint;
        private TextBox txtDailyRate;
        private Label lblDailyRate;
        private Label lblRateHint;
        private TextBox txtDescription;
        private Label lblDescription;
        private TextBox txtLicensePlate;
        private Label lblLicensePlate;
        private ComboBox cboColor;
        private Label lblColor;
        private ComboBox cboType;
        private Label lblType;
        private ComboBox cboYear;
        private Label lblYear;
        private ComboBox cboModel;
        private Label lblModel;
        private ComboBox cboMake;
        private Label lblMake;
        private ComboBox cboFuelType;
        private Label lblFuelType;
        private ComboBox cboTransmission;
        private Label lblTransmission;
        private ComboBox cboDrivetrain;
        private Label lblDrivetrain;
        private TextBox txtEngineCapacity;
        private Label lblEngineCapacity;
        private TextBox txtPower;
        private Label lblPower;
        private ComboBox cboSeatNumber;
        private Label lblSeatNumber;
        private Label UsernameLabel;
    }
}
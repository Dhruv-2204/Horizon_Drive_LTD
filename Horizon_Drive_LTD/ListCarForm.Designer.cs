using System.Data;
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
            buttonProfile = new Button();
            buttonCart = new Button();
            buttonFilter = new Button();
            lblListYourCar = new Label();
            panelMain = new Panel();
            panelContent = new Panel();
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
            checkBoxChildSeat = new CheckBox();
            panelPhoto1 = new Panel();
            lblPlus1 = new Label();
            checkBoxSunroof = new CheckBox();
            checkBoxLeatherSeat = new CheckBox();
            checkBoxBluetooth = new CheckBox();
            checkBoxGPS = new CheckBox();
            lblAdditionalFeatures = new Label();
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
            panelSidebar.Margin = new Padding(5, 4, 5, 4);
            panelSidebar.Name = "panelSidebar";
            panelSidebar.Size = new Size(250, 900);
            panelSidebar.TabIndex = 0;
            // 
            // btnManageBooking
            // 
            btnManageBooking.BackColor = Color.FromArgb(30, 85, 110);
            btnManageBooking.FlatAppearance.BorderSize = 0;
            btnManageBooking.FlatStyle = FlatStyle.Flat;
            btnManageBooking.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnManageBooking.ForeColor = Color.White;
            btnManageBooking.Location = new Point(27, 421);
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
            btnManageYourListings.Location = new Point(27, 597);
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
            btnOptions.Location = new Point(27, 687);
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
            btnListCar.BackColor = Color.FromArgb(173, 216, 230);
            btnListCar.FlatAppearance.BorderSize = 0;
            btnListCar.FlatStyle = FlatStyle.Flat;
            btnListCar.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnListCar.ForeColor = Color.Black;
            btnListCar.Location = new Point(27, 509);
            btnListCar.Margin = new Padding(5, 4, 5, 4);
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
            btnBrowseListings.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnBrowseListings.ForeColor = Color.White;
            btnBrowseListings.Location = new Point(27, 332);
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
            pictureBoxLogo.Image = Properties.Resources.Logo;
            pictureBoxLogo.Location = new Point(27, 63);
            pictureBoxLogo.Margin = new Padding(5, 4, 5, 4);
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
            btnLogout.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnLogout.ForeColor = Color.White;
            btnLogout.Location = new Point(27, 775);
            btnLogout.Margin = new Padding(5, 4, 5, 4);
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
            panelHeader.Controls.Add(buttonProfile);
            panelHeader.Controls.Add(buttonCart);
            panelHeader.Controls.Add(buttonFilter);
            panelHeader.Controls.Add(lblListYourCar);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Margin = new Padding(3, 5, 3, 5);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1350, 123);
            panelHeader.TabIndex = 1;
            // 
            // buttonProfile
            // 
            buttonProfile.AutoSize = true;
            buttonProfile.BackColor = Color.White;
            buttonProfile.FlatAppearance.BorderColor = Color.FromArgb(192, 192, 192);
            buttonProfile.FlatStyle = FlatStyle.Flat;
            buttonProfile.Font = new Font("Segoe UI Symbol", 12F);
            buttonProfile.Location = new Point(1250, 60);
            buttonProfile.Margin = new Padding(5, 4, 5, 4);
            buttonProfile.Name = "buttonProfile";
            buttonProfile.Size = new Size(50, 53);
            buttonProfile.TabIndex = 4;
            buttonProfile.Text = "👤";
            buttonProfile.UseVisualStyleBackColor = false;
            // 
            // buttonCart
            // 
            buttonCart.AutoSize = true;
            buttonCart.BackColor = Color.White;
            buttonCart.FlatAppearance.BorderColor = Color.FromArgb(192, 192, 192);
            buttonCart.FlatStyle = FlatStyle.Flat;
            buttonCart.Font = new Font("Segoe UI Symbol", 12F);
            buttonCart.Location = new Point(1190, 60);
            buttonCart.Margin = new Padding(5, 4, 5, 4);
            buttonCart.Name = "buttonCart";
            buttonCart.Size = new Size(50, 53);
            buttonCart.TabIndex = 3;
            buttonCart.Text = "\U0001f6d2";
            buttonCart.UseVisualStyleBackColor = false;
            // 
            // buttonFilter
            // 
            buttonFilter.AutoSize = true;
            buttonFilter.BackColor = Color.White;
            buttonFilter.FlatAppearance.BorderColor = Color.FromArgb(192, 192, 192);
            buttonFilter.FlatStyle = FlatStyle.Flat;
            buttonFilter.Font = new Font("Segoe UI Symbol", 12F);
            buttonFilter.Location = new Point(1130, 60);
            buttonFilter.Margin = new Padding(5, 4, 5, 4);
            buttonFilter.Name = "buttonFilter";
            buttonFilter.Size = new Size(50, 53);
            buttonFilter.TabIndex = 2;
            buttonFilter.Text = "🔍";
            buttonFilter.UseVisualStyleBackColor = false;
            // 
            // lblListYourCar
            // 
            lblListYourCar.AutoSize = true;
            lblListYourCar.Font = new Font("Bahnschrift SemiCondensed", 28.1454544F, FontStyle.Bold, GraphicsUnit.Point, 0);
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
            panelMain.Location = new Point(250, 0);
            panelMain.Margin = new Padding(5, 4, 5, 4);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(1350, 900);
            panelMain.TabIndex = 1;
            // 
            // panelContent
            // 
            panelContent.AutoScroll = true;
            panelContent.AutoSize = false;
            panelContent.BackColor = Color.FromArgb(240, 240, 240);
            panelContent.BorderStyle = BorderStyle.Fixed3D;
            panelContent.Controls.Add(panelPhoto5);
            panelContent.Controls.Add(panelPhoto4);
            panelContent.Controls.Add(btnListMyCar);
            panelContent.Controls.Add(panelPhoto3);
            panelContent.Controls.Add(btnCancel);
            panelContent.Controls.Add(panelPhoto2);
            panelContent.Controls.Add(checkBoxChildSeat);
            panelContent.Controls.Add(panelPhoto1);
            panelContent.Controls.Add(checkBoxSunroof);
            panelContent.Controls.Add(checkBoxLeatherSeat);
            panelContent.Controls.Add(checkBoxBluetooth);
            panelContent.Controls.Add(checkBoxGPS);
            panelContent.Controls.Add(lblAdditionalFeatures);
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
            panelContent.Location = new Point(20, 127);
            panelContent.Margin = new Padding(10);
            panelContent.Name = "panelContent";
            panelContent.Padding = new Padding(27, 31, 27, 31);
            panelContent.Size = new Size(1310, 750);
            panelContent.TabIndex = 1;
            // 
            // panelPhoto5
            // 
            panelPhoto5.BackColor = Color.LightGray;
            panelPhoto5.Controls.Add(lblPlus5);
            panelPhoto5.Location = new Point(773, 749);
            panelPhoto5.Margin = new Padding(3, 5, 3, 5);
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
            panelPhoto4.Location = new Point(668, 749);
            panelPhoto4.Margin = new Padding(3, 5, 3, 5);
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
            btnListMyCar.Location = new Point(1060, 1129);
            btnListMyCar.Margin = new Padding(3, 5, 3, 5);
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
            panelPhoto3.Location = new Point(564, 749);
            panelPhoto3.Margin = new Padding(3, 5, 3, 5);
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
            btnCancel.Location = new Point(920, 1129);
            btnCancel.Margin = new Padding(3, 5, 3, 5);
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
            panelPhoto2.Location = new Point(459, 749);
            panelPhoto2.Margin = new Padding(3, 5, 3, 5);
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
            // checkBoxChildSeat
            // 
            checkBoxChildSeat.AutoSize = true;
            checkBoxChildSeat.Font = new Font("Segoe UI", 11F);
            checkBoxChildSeat.Location = new Point(597, 1080);
            checkBoxChildSeat.Margin = new Padding(3, 5, 3, 5);
            checkBoxChildSeat.Name = "checkBoxChildSeat";
            checkBoxChildSeat.Size = new Size(119, 29);
            checkBoxChildSeat.TabIndex = 69;
            checkBoxChildSeat.Text = "Child Seat";
            checkBoxChildSeat.UseVisualStyleBackColor = true;
            // 
            // panelPhoto1
            // 
            panelPhoto1.BackColor = Color.LightGray;
            panelPhoto1.Controls.Add(lblPlus1);
            panelPhoto1.Location = new Point(355, 749);
            panelPhoto1.Margin = new Padding(3, 5, 3, 5);
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
            // checkBoxSunroof
            // 
            checkBoxSunroof.AutoSize = true;
            checkBoxSunroof.Font = new Font("Segoe UI", 11F);
            checkBoxSunroof.Location = new Point(467, 1080);
            checkBoxSunroof.Margin = new Padding(3, 5, 3, 5);
            checkBoxSunroof.Name = "checkBoxSunroof";
            checkBoxSunroof.Size = new Size(101, 29);
            checkBoxSunroof.TabIndex = 68;
            checkBoxSunroof.Text = "Sunroof";
            checkBoxSunroof.UseVisualStyleBackColor = true;
            // 
            // checkBoxLeatherSeat
            // 
            checkBoxLeatherSeat.AutoSize = true;
            checkBoxLeatherSeat.Font = new Font("Segoe UI", 11F);
            checkBoxLeatherSeat.Location = new Point(311, 1080);
            checkBoxLeatherSeat.Margin = new Padding(3, 5, 3, 5);
            checkBoxLeatherSeat.Name = "checkBoxLeatherSeat";
            checkBoxLeatherSeat.Size = new Size(138, 29);
            checkBoxLeatherSeat.TabIndex = 67;
            checkBoxLeatherSeat.Text = "Leather Seat";
            checkBoxLeatherSeat.UseVisualStyleBackColor = true;
            // 
            // checkBoxBluetooth
            // 
            checkBoxBluetooth.AutoSize = true;
            checkBoxBluetooth.Font = new Font("Segoe UI", 11F);
            checkBoxBluetooth.Location = new Point(154, 1080);
            checkBoxBluetooth.Margin = new Padding(3, 5, 3, 5);
            checkBoxBluetooth.Name = "checkBoxBluetooth";
            checkBoxBluetooth.Size = new Size(116, 29);
            checkBoxBluetooth.TabIndex = 66;
            checkBoxBluetooth.Text = "Bluetooth";
            checkBoxBluetooth.UseVisualStyleBackColor = true;
            // 
            // checkBoxGPS
            // 
            checkBoxGPS.AutoSize = true;
            checkBoxGPS.Font = new Font("Segoe UI", 11F);
            checkBoxGPS.Location = new Point(36, 1080);
            checkBoxGPS.Margin = new Padding(3, 5, 3, 5);
            checkBoxGPS.Name = "checkBoxGPS";
            checkBoxGPS.Size = new Size(68, 29);
            checkBoxGPS.TabIndex = 65;
            checkBoxGPS.Text = "GPS";
            checkBoxGPS.UseVisualStyleBackColor = true;
            // 
            // lblAdditionalFeatures
            // 
            lblAdditionalFeatures.AutoSize = true;
            lblAdditionalFeatures.Font = new Font("Segoe UI", 11F);
            lblAdditionalFeatures.Location = new Point(36, 1035);
            lblAdditionalFeatures.Name = "lblAdditionalFeatures";
            lblAdditionalFeatures.Size = new Size(188, 25);
            lblAdditionalFeatures.TabIndex = 64;
            lblAdditionalFeatures.Text = "Additional Features *";
            // 
            // dateTimePickerEnd
            // 
            dateTimePickerEnd.CalendarFont = new Font("Segoe UI", 11F);
            dateTimePickerEnd.Font = new Font("Segoe UI", 11F);
            dateTimePickerEnd.Format = DateTimePickerFormat.Short;
            dateTimePickerEnd.Location = new Point(441, 969);
            dateTimePickerEnd.Margin = new Padding(3, 5, 3, 5);
            dateTimePickerEnd.Name = "dateTimePickerEnd";
            dateTimePickerEnd.Size = new Size(364, 32);
            dateTimePickerEnd.TabIndex = 63;
            // 
            // lblAvailabilityEnd
            // 
            lblAvailabilityEnd.AutoSize = true;
            lblAvailabilityEnd.Font = new Font("Segoe UI", 11F);
            lblAvailabilityEnd.Location = new Point(441, 925);
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
            dateTimePickerStart.Location = new Point(36, 969);
            dateTimePickerStart.Margin = new Padding(3, 5, 3, 5);
            dateTimePickerStart.Name = "dateTimePickerStart";
            dateTimePickerStart.Size = new Size(364, 32);
            dateTimePickerStart.TabIndex = 61;
            // 
            // lblAvailabilityStart
            // 
            lblAvailabilityStart.AutoSize = true;
            lblAvailabilityStart.Font = new Font("Segoe UI", 11F);
            lblAvailabilityStart.Location = new Point(36, 925);
            lblAvailabilityStart.Name = "lblAvailabilityStart";
            lblAvailabilityStart.Size = new Size(160, 25);
            lblAvailabilityStart.TabIndex = 60;
            lblAvailabilityStart.Text = "Availability Start *";
            // 
            // panelPhotoContainer
            // 
            panelPhotoContainer.Location = new Point(36, 749);
            panelPhotoContainer.Margin = new Padding(3, 5, 3, 5);
            panelPhotoContainer.Name = "panelPhotoContainer";
            panelPhotoContainer.Size = new Size(1000, 124);
            panelPhotoContainer.TabIndex = 59;
            // 
            // panelUploadPhotos
            // 
            panelUploadPhotos.BorderStyle = BorderStyle.FixedSingle;
            panelUploadPhotos.Controls.Add(lblUploadInstructions);
            panelUploadPhotos.Controls.Add(pictureBoxUpload);
            panelUploadPhotos.Location = new Point(36, 616);
            panelUploadPhotos.Margin = new Padding(3, 5, 3, 5);
            panelUploadPhotos.Name = "panelUploadPhotos";
            panelUploadPhotos.Size = new Size(1000, 123);
            panelUploadPhotos.TabIndex = 58;
            panelUploadPhotos.Paint += PanelUploadPhotos_Paint;
            panelUploadPhotos.Click += panelUploadPhotos_Click;
            // 
            // lblUploadInstructions
            // 
            lblUploadInstructions.AutoSize = true;
            lblUploadInstructions.Font = new Font("Segoe UI", 10F);
            lblUploadInstructions.Location = new Point(445, 71);
            lblUploadInstructions.Name = "lblUploadInstructions";
            lblUploadInstructions.Size = new Size(357, 23);
            lblUploadInstructions.TabIndex = 1;
            lblUploadInstructions.Text = "Drag and drop photos here or click to browse";
            // 
            // pictureBoxUpload
            // 
            pictureBoxUpload.Location = new Point(555, 17);
            pictureBoxUpload.Margin = new Padding(3, 5, 3, 5);
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
            lblUploadPhotos.Location = new Point(36, 577);
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
            lblUploadHint.Location = new Point(36, 878);
            lblUploadHint.Name = "lblUploadHint";
            lblUploadHint.Size = new Size(432, 20);
            lblUploadHint.TabIndex = 57;
            lblUploadHint.Text = "Photos must be 1:1 ratio (square), JPG/JPEG/PNG under 5MB each";
            // 
            // txtDailyRate
            // 
            txtDailyRate.Font = new Font("Segoe UI", 11F);
            txtDailyRate.Location = new Point(36, 492);
            txtDailyRate.Margin = new Padding(3, 5, 3, 5);
            txtDailyRate.Name = "txtDailyRate";
            txtDailyRate.PlaceholderText = "e.g. 7500.00";
            txtDailyRate.Size = new Size(1000, 32);
            txtDailyRate.TabIndex = 54;
            // 
            // lblDailyRate
            // 
            lblDailyRate.AutoSize = true;
            lblDailyRate.Font = new Font("Segoe UI", 11F);
            lblDailyRate.Location = new Point(36, 448);
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
            lblRateHint.Location = new Point(30, 529);
            lblRateHint.Name = "lblRateHint";
            lblRateHint.Size = new Size(294, 20);
            lblRateHint.TabIndex = 55;
            lblRateHint.Text = "Set a competitive daily rate to attract renters";
            // 
            // txtDescription
            // 
            txtDescription.Font = new Font("Segoe UI", 11F);
            txtDescription.Location = new Point(36, 291);
            txtDescription.Margin = new Padding(3, 5, 3, 5);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.PlaceholderText = "Describe your car, including condition, special features, etc.";
            txtDescription.Size = new Size(1000, 139);
            txtDescription.TabIndex = 52;
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Font = new Font("Segoe UI", 11F);
            lblDescription.Location = new Point(36, 253);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(155, 25);
            lblDescription.TabIndex = 51;
            lblDescription.Text = "Car Description *";
            // 
            // txtLicensePlate
            // 
            txtLicensePlate.Font = new Font("Segoe UI", 11F);
            txtLicensePlate.Location = new Point(850, 186);
            txtLicensePlate.Margin = new Padding(3, 5, 3, 5);
            txtLicensePlate.Name = "txtLicensePlate";
            txtLicensePlate.PlaceholderText = "Enter license plate";
            txtLicensePlate.Size = new Size(300, 32);
            txtLicensePlate.TabIndex = 50;
            // 
            // lblLicensePlate
            // 
            lblLicensePlate.AutoSize = true;
            lblLicensePlate.Font = new Font("Segoe UI", 11F);
            lblLicensePlate.Location = new Point(850, 142);
            lblLicensePlate.Name = "lblLicensePlate";
            lblLicensePlate.Size = new Size(134, 25);
            lblLicensePlate.TabIndex = 49;
            lblLicensePlate.Text = "License Plate *";
            // 
            // cboColor
            // 
            cboColor.Font = new Font("Segoe UI", 11F);
            cboColor.FormattingEnabled = true;
            cboColor.Location = new Point(443, 186);
            cboColor.Margin = new Padding(3, 5, 3, 5);
            cboColor.Name = "cboColor";
            cboColor.Size = new Size(364, 33);
            cboColor.TabIndex = 48;
            cboColor.Text = "Select Color";
            // 
            // lblColor
            // 
            lblColor.AutoSize = true;
            lblColor.Font = new Font("Segoe UI", 11F);
            lblColor.Location = new Point(443, 142);
            lblColor.Name = "lblColor";
            lblColor.Size = new Size(71, 25);
            lblColor.TabIndex = 47;
            lblColor.Text = "Color *";
            // 
            // cboType
            // 
            cboType.Font = new Font("Segoe UI", 11F);
            cboType.FormattingEnabled = true;
            cboType.Location = new Point(36, 186);
            cboType.Margin = new Padding(3, 5, 3, 5);
            cboType.Name = "cboType";
            cboType.Size = new Size(364, 33);
            cboType.TabIndex = 46;
            cboType.Text = "Select type";
            // 
            // lblType
            // 
            lblType.AutoSize = true;
            lblType.Font = new Font("Segoe UI", 11F);
            lblType.Location = new Point(36, 142);
            lblType.Name = "lblType";
            lblType.Size = new Size(64, 25);
            lblType.TabIndex = 45;
            lblType.Text = "Type *";
            // 
            // cboYear
            // 
            cboYear.Font = new Font("Segoe UI", 11F);
            cboYear.FormattingEnabled = true;
            cboYear.Location = new Point(850, 62);
            cboYear.Margin = new Padding(3, 5, 3, 5);
            cboYear.Name = "cboYear";
            cboYear.Size = new Size(300, 33);
            cboYear.TabIndex = 44;
            cboYear.Text = "Select Year";
            // 
            // lblYear
            // 
            lblYear.AutoSize = true;
            lblYear.Font = new Font("Segoe UI", 11F);
            lblYear.Location = new Point(850, 17);
            lblYear.Name = "lblYear";
            lblYear.Size = new Size(61, 25);
            lblYear.TabIndex = 43;
            lblYear.Text = "Year *";
            // 
            // cboModel
            // 
            cboModel.Font = new Font("Segoe UI", 11F);
            cboModel.FormattingEnabled = true;
            cboModel.Location = new Point(443, 62);
            cboModel.Margin = new Padding(3, 5, 3, 5);
            cboModel.Name = "cboModel";
            cboModel.Size = new Size(364, 33);
            cboModel.TabIndex = 41;
            cboModel.Text = "Select Model";
            // 
            // lblModel
            // 
            lblModel.AutoSize = true;
            lblModel.Font = new Font("Segoe UI", 11F);
            lblModel.Location = new Point(443, 17);
            lblModel.Name = "lblModel";
            lblModel.Size = new Size(79, 25);
            lblModel.TabIndex = 40;
            lblModel.Text = "Model *";
            // 
            // cboMake
            // 
            cboMake.Font = new Font("Segoe UI", 11F);
            cboMake.FormattingEnabled = true;
            cboMake.Location = new Point(36, 62);
            cboMake.Margin = new Padding(3, 5, 3, 5);
            cboMake.Name = "cboMake";
            cboMake.Size = new Size(364, 33);
            cboMake.TabIndex = 38;
            cboMake.Text = "Select Make";
            // 
            // lblMake
            // 
            lblMake.AutoSize = true;
            lblMake.Font = new Font("Segoe UI", 11F);
            lblMake.Location = new Point(36, 17);
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
            Margin = new Padding(3, 5, 3, 5);
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
        private Button buttonCart;
        private Button buttonFilter;
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
        private CheckBox checkBoxChildSeat;
        private Panel panelPhoto1;
        private Label lblPlus1;
        private CheckBox checkBoxSunroof;
        private CheckBox checkBoxLeatherSeat;
        private CheckBox checkBoxBluetooth;
        private CheckBox checkBoxGPS;
        private Label lblAdditionalFeatures;
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
    }
}
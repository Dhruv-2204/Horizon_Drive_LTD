using System;
using System.Drawing;
using System.Windows.Forms;

namespace Horizon_Drive_LTD
{
    partial class List_A_Car_Page
    {
        private System.ComponentModel.IContainer components = null;

        // Sidebar components
        private Panel sidebar;
        private RoundedButton btnOptions;
        private RoundedButton btnManageBooking;
        private RoundedButton btnListCar;
        private RoundedButton btnBrowseListings;

        // Main panel components
        private Panel panelMain;
        private Panel panelContent;
        private Panel contentPanel; // New content panel
        private FlowLayoutPanel flowLayoutPanelListings;
        private Panel panelHeader;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            sidebar = new Panel();
            pictureBoxLogo = new PictureBox();
            btnBrowseListings = new RoundedButton();
            btnListCar = new RoundedButton();
            btnManageBooking = new RoundedButton();
            btnOptions = new RoundedButton();
            panelMain = new Panel();
            panelContent = new Panel();
            contentPanel = new Panel();
            lblMake = new Label();
            cmbMake = new ComboBox();
            lblModel = new Label();
            cmbModel = new ComboBox();
            lblYear = new Label();
            cmbYear = new ComboBox();
            lblType = new Label();
            cmbType = new ComboBox();
            lblColor = new Label();
            cmbColor = new ComboBox();
            lblLicensePlate = new Label();
            txtLicensePlate = new TextBox();
            lblDescription = new Label();
            txtCarDescription = new TextBox();
            lblDailyRate = new Label();
            txtDailyRate = new TextBox();
            lblDailyRateInfo = new Label();
            lblPhotos = new Label();
            pbCarImage = new PictureBox();
            btnUploadImage = new Button();
            panelHeader = new Panel();
            sidebar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).BeginInit();
            panelMain.SuspendLayout();
            panelContent.SuspendLayout();
            contentPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbCarImage).BeginInit();
            SuspendLayout();
            // 
            // sidebar
            // 
            sidebar.BackColor = Color.FromArgb(15, 30, 45);
            sidebar.Controls.Add(pictureBoxLogo);
            sidebar.Controls.Add(btnBrowseListings);
            sidebar.Controls.Add(btnListCar);
            sidebar.Controls.Add(btnManageBooking);
            sidebar.Controls.Add(btnOptions);
            sidebar.Dock = DockStyle.Left;
            sidebar.Location = new Point(0, 0);
            sidebar.Name = "sidebar";
            sidebar.Size = new Size(250, 760);
            sidebar.TabIndex = 0;
            // 
            // pictureBoxLogo
            // 
           
            pictureBoxLogo.Location = new Point(25, 13);
            pictureBoxLogo.Name = "pictureBoxLogo";
            pictureBoxLogo.Size = new Size(200, 156);
            pictureBoxLogo.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxLogo.TabIndex = 0;
            pictureBoxLogo.TabStop = false;
            // 
            // btnBrowseListings
            // 
            btnBrowseListings.BackColor = Color.FromArgb(30, 85, 110);
            btnBrowseListings.FlatStyle = FlatStyle.Flat;
            btnBrowseListings.Font = new Font("Segoe UI", 12F);
            btnBrowseListings.ForeColor = Color.White;
            btnBrowseListings.Location = new Point(25, 191);
            btnBrowseListings.Name = "btnBrowseListings";
            btnBrowseListings.Size = new Size(200, 50);
            btnBrowseListings.TabIndex = 1;
            btnBrowseListings.Text = "Browse Listings";
            btnBrowseListings.UseVisualStyleBackColor = false;
            // 
            // btnListCar
            // 
            btnListCar.BackColor = Color.FromArgb(173, 216, 230);
            btnListCar.FlatStyle = FlatStyle.Flat;
            btnListCar.Font = new Font("Segoe UI", 12F);
            btnListCar.ForeColor = Color.Black;
            btnListCar.Location = new Point(25, 271);
            btnListCar.Name = "btnListCar";
            btnListCar.Size = new Size(200, 50);
            btnListCar.TabIndex = 2;
            btnListCar.Text = "List a Car";
            btnListCar.UseVisualStyleBackColor = false;
            // 
            // btnManageBooking
            // 
            btnManageBooking.BackColor = Color.FromArgb(30, 85, 110);
            btnManageBooking.FlatStyle = FlatStyle.Flat;
            btnManageBooking.Font = new Font("Segoe UI", 12F);
            btnManageBooking.ForeColor = Color.White;
            btnManageBooking.Location = new Point(25, 355);
            btnManageBooking.Name = "btnManageBooking";
            btnManageBooking.Size = new Size(200, 50);
            btnManageBooking.TabIndex = 3;
            btnManageBooking.Text = "Manage Booking";
            btnManageBooking.UseVisualStyleBackColor = false;
            // 
            // btnOptions
            // 
            btnOptions.BackColor = Color.FromArgb(30, 85, 110);
            btnOptions.FlatStyle = FlatStyle.Flat;
            btnOptions.Font = new Font("Segoe UI", 12F);
            btnOptions.ForeColor = Color.White;
            btnOptions.Location = new Point(25, 436);
            btnOptions.Name = "btnOptions";
            btnOptions.Size = new Size(200, 50);
            btnOptions.TabIndex = 4;
            btnOptions.Text = "Options";
            btnOptions.UseVisualStyleBackColor = false;
            // 
            // panelMain
            // 
            panelMain.BackColor = Color.White;
            panelMain.Controls.Add(panelContent);
            panelMain.Controls.Add(panelHeader);
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(0, 0);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(1924, 760);
            panelMain.TabIndex = 1;
            // 
            // panelContent
            // 
            panelContent.BackColor = Color.WhiteSmoke;
            panelContent.Controls.Add(contentPanel);
            panelContent.Dock = DockStyle.Fill;
            panelContent.Location = new Point(0, 100);
            panelContent.Name = "panelContent";
            panelContent.Size = new Size(1924, 660);
            panelContent.TabIndex = 0;
            // 
            // contentPanel
            // 
            contentPanel.BackColor = Color.White;
            contentPanel.BorderStyle = BorderStyle.FixedSingle;
            contentPanel.Controls.Add(lblMake);
            contentPanel.Controls.Add(cmbMake);
            contentPanel.Controls.Add(lblModel);
            contentPanel.Controls.Add(cmbModel);
            contentPanel.Controls.Add(lblYear);
            contentPanel.Controls.Add(cmbYear);
            contentPanel.Controls.Add(lblType);
            contentPanel.Controls.Add(cmbType);
            contentPanel.Controls.Add(lblColor);
            contentPanel.Controls.Add(cmbColor);
            contentPanel.Controls.Add(lblLicensePlate);
            contentPanel.Controls.Add(txtLicensePlate);
            contentPanel.Controls.Add(lblDescription);
            contentPanel.Controls.Add(txtCarDescription);
            contentPanel.Controls.Add(lblDailyRate);
            contentPanel.Controls.Add(txtDailyRate);
            contentPanel.Controls.Add(lblDailyRateInfo);
            contentPanel.Controls.Add(lblPhotos);
            contentPanel.Controls.Add(pbCarImage);
            contentPanel.Controls.Add(btnUploadImage);
            contentPanel.Location = new Point(311, 48);
            contentPanel.Name = "contentPanel";
            contentPanel.Size = new Size(1498, 724);
            contentPanel.TabIndex = 0;
            contentPanel.Paint += contentPanel_Paint;
            // 
            // lblMake
            // 
            lblMake.AutoSize = true;
            lblMake.Font = new Font("Segoe UI", 10F);
            lblMake.Location = new Point(30, 30);
            lblMake.Name = "lblMake";
            lblMake.Size = new Size(86, 23);
            lblMake.TabIndex = 0;
            lblMake.Text = "Car Make:";
            // 
            // cmbMake
            // 
            cmbMake.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMake.Items.AddRange(new object[] { "Toyota", "Honda", "BMW", "Mercedes", "Ford" });
            cmbMake.Location = new Point(30, 56);
            cmbMake.Name = "cmbMake";
            cmbMake.Size = new Size(200, 28);
            cmbMake.TabIndex = 1;
            // 
            // lblModel
            // 
            lblModel.AutoSize = true;
            lblModel.Font = new Font("Segoe UI", 10F);
            lblModel.Location = new Point(310, 30);
            lblModel.Name = "lblModel";
            lblModel.Size = new Size(62, 23);
            lblModel.TabIndex = 2;
            lblModel.Text = "Model:";
            // 
            // cmbModel
            // 
            cmbModel.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbModel.Location = new Point(310, 56);
            cmbModel.Name = "cmbModel";
            cmbModel.Size = new Size(200, 28);
            cmbModel.TabIndex = 3;
            // 
            // lblYear
            // 
            lblYear.AutoSize = true;
            lblYear.Font = new Font("Segoe UI", 10F);
            lblYear.Location = new Point(564, 30);
            lblYear.Name = "lblYear";
            lblYear.Size = new Size(53, 23);
            lblYear.TabIndex = 4;
            lblYear.Text = "Year*:";
            // 
            // cmbYear
            // 
            cmbYear.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbYear.Items.AddRange(new object[] { "2023", "2022", "2021", "2020", "2019" });
            cmbYear.Location = new Point(564, 57);
            cmbYear.Name = "cmbYear";
            cmbYear.Size = new Size(200, 28);
            cmbYear.TabIndex = 5;
            // 
            // lblType
            // 
            lblType.AutoSize = true;
            lblType.Font = new Font("Segoe UI", 10F);
            lblType.Location = new Point(30, 122);
            lblType.Name = "lblType";
            lblType.Size = new Size(56, 23);
            lblType.TabIndex = 6;
            lblType.Text = "Type*:";
            // 
            // cmbType
            // 
            cmbType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbType.Items.AddRange(new object[] { "Sedan", "SUV", "Truck", "Coupe", "Hatchback" });
            cmbType.Location = new Point(30, 161);
            cmbType.Name = "cmbType";
            cmbType.Size = new Size(200, 28);
            cmbType.TabIndex = 7;
            // 
            // lblColor
            // 
            lblColor.AutoSize = true;
            lblColor.Font = new Font("Segoe UI", 10F);
            lblColor.Location = new Point(310, 122);
            lblColor.Name = "lblColor";
            lblColor.Size = new Size(62, 23);
            lblColor.TabIndex = 8;
            lblColor.Text = "Color*:";
            // 
            // cmbColor
            // 
            cmbColor.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbColor.Items.AddRange(new object[] { "Black", "White", "Red", "Blue", "Silver" });
            cmbColor.Location = new Point(310, 161);
            cmbColor.Name = "cmbColor";
            cmbColor.Size = new Size(200, 28);
            cmbColor.TabIndex = 9;
            // 
            // lblLicensePlate
            // 
            lblLicensePlate.AutoSize = true;
            lblLicensePlate.Font = new Font("Segoe UI", 10F);
            lblLicensePlate.Location = new Point(564, 122);
            lblLicensePlate.Name = "lblLicensePlate";
            lblLicensePlate.Size = new Size(119, 23);
            lblLicensePlate.TabIndex = 10;
            lblLicensePlate.Text = "License Plate*:";
            // 
            // txtLicensePlate
            // 
            txtLicensePlate.Location = new Point(564, 161);
            txtLicensePlate.Name = "txtLicensePlate";
            txtLicensePlate.Size = new Size(200, 27);
            txtLicensePlate.TabIndex = 11;
            txtLicensePlate.TextChanged += txtLicensePlate_TextChanged;
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Font = new Font("Segoe UI", 10F);
            lblDescription.Location = new Point(30, 233);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(107, 23);
            lblDescription.TabIndex = 4;
            lblDescription.Text = "Description*:";
            // 
            // txtCarDescription
            // 
            txtCarDescription.Location = new Point(30, 278);
            txtCarDescription.Multiline = true;
            txtCarDescription.Name = "txtCarDescription";
            txtCarDescription.Size = new Size(700, 100);
            txtCarDescription.TabIndex = 5;
            txtCarDescription.Text = "Describe your car, including condition, special features, etc.";
            // 
            // lblDailyRate
            // 
            lblDailyRate.AutoSize = true;
            lblDailyRate.Font = new Font("Segoe UI", 10F);
            lblDailyRate.Location = new Point(30, 421);
            lblDailyRate.Name = "lblDailyRate";
            lblDailyRate.Size = new Size(149, 23);
            lblDailyRate.TabIndex = 6;
            lblDailyRate.Text = "Daily Rate (MUR)*:";
            // 
            // txtDailyRate
            // 
            txtDailyRate.Location = new Point(30, 461);
            txtDailyRate.Name = "txtDailyRate";
            txtDailyRate.Size = new Size(700, 27);
            txtDailyRate.TabIndex = 7;
            txtDailyRate.Text = "7500.00";
            // 
            // lblDailyRateInfo
            // 
            lblDailyRateInfo.AutoSize = true;
            lblDailyRateInfo.Font = new Font("Segoe UI", 8.5F);
            lblDailyRateInfo.ForeColor = Color.Gray;
            lblDailyRateInfo.Location = new Point(30, 511);
            lblDailyRateInfo.Name = "lblDailyRateInfo";
            lblDailyRateInfo.Size = new Size(305, 20);
            lblDailyRateInfo.TabIndex = 8;
            lblDailyRateInfo.Text = "Set a competitive daily rate to attract renters";
            // 
            // lblPhotos
            // 
            lblPhotos.AutoSize = true;
            lblPhotos.Location = new Point(964, 32);
            lblPhotos.Name = "lblPhotos";
            lblPhotos.Size = new Size(110, 20);
            lblPhotos.TabIndex = 12;
            lblPhotos.Text = "Upload Photo*:";
            // 
            // pbCarImage
            // 
            pbCarImage.BackColor = Color.LightGray;
            pbCarImage.BorderStyle = BorderStyle.FixedSingle;
            pbCarImage.Location = new Point(843, 65);
            pbCarImage.Name = "pbCarImage";
            pbCarImage.Size = new Size(366, 423);
            pbCarImage.SizeMode = PictureBoxSizeMode.StretchImage;
            pbCarImage.TabIndex = 13;
            pbCarImage.TabStop = false;
            // 
            // btnUploadImage
            // 
            btnUploadImage.Location = new Point(939, 511);
            btnUploadImage.Name = "btnUploadImage";
            btnUploadImage.Size = new Size(200, 30);
            btnUploadImage.TabIndex = 14;
            btnUploadImage.Text = "Upload Image";
            btnUploadImage.Click += BtnUploadImage_Click;
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(240, 240, 240);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1924, 100);
            panelHeader.TabIndex = 1;
            // 
            // List_A_Car_Page
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1924, 760);
            Controls.Add(sidebar);
            Controls.Add(panelMain);
            Name = "List_A_Car_Page";
            Text = "List A Car - Horizon Drive LTD";
            sidebar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).EndInit();
            panelMain.ResumeLayout(false);
            panelContent.ResumeLayout(false);
            contentPanel.ResumeLayout(false);
            contentPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbCarImage).EndInit();
            ResumeLayout(false);
        }

        // Sidebar components
        private PictureBox pictureBoxLogo;

        // Content panel labels
        private Label contentLabel;
        private Label lblMake;
        private Label lblModel;
        private Label lblYear;
        private Label lblColor;
        private Label lblLicensePlate;
        private Label lblType;
        private Label lblDescription;
        private Label lblDailyRate;
        private Label lblDailyRateInfo;
        private Label lblPhotos;

        // Content panel ComboBoxes
        private ComboBox cmbMake;
        private ComboBox cmbModel;
        private ComboBox cmbYear;
        private ComboBox cmbColor;
        private ComboBox cmbType;

        // Content panel TextBoxes
        private TextBox txtLicensePlate;
        private TextBox txtCarDescription;
        private TextBox txtDailyRate;

        // Content panel additional controls
        private PictureBox pbCarImage;
        private Button btnUploadImage;

        private void BtnUploadImage_Click(object sender, EventArgs e)
        {
            UploadCarImage(pbCarImage);
        }

        private void UploadCarImage(PictureBox pictureBox)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    pictureBox.Image = Image.FromFile(openFileDialog.FileName);
                }
            }
        }
    }
}
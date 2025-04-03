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
        private PictureBox pictureBoxLogo;
        private RoundedButton btnBrowseListings;
        private RoundedButton btnListCar;
        private RoundedButton btnManageBooking;
        private RoundedButton btnOptions;

        // Main panel components
        private Panel panelMain;
        private Panel panelContent;
        private Panel contentPanel;
        private Panel panelHeader;
        private Panel panelImageUpload;

        // Content components
        private Label lblMake, lblModel, lblYear, lblType, lblColor,
                     lblLicensePlate, lblDescription, lblDailyRate,
                     lblDailyRateInfo, lblPhotos, lblDragDrop;

        private ComboBox cmbMake, cmbModel, cmbYear, cmbType, cmbColor;
        private TextBox txtLicensePlate, txtCarDescription, txtDailyRate;
        private PictureBox pictureBox1, pictureBox2, pictureBox3, pictureBox4, pictureBox5;
        private Button btnListMyCar;

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
            // Main Form Setup
            this.Size = new Size(1024, 768);
            this.Text = "List a Car - Horizon Drive";

            // Sidebar Setup
            sidebar = new Panel
            {
                Dock = DockStyle.Left,
                Width = 250,
                BackColor = Color.FromArgb(15, 30, 45)
            };

            pictureBoxLogo = new PictureBox
            {
                Location = new Point(25, 20),
                Size = new Size(200, 150),
                SizeMode = PictureBoxSizeMode.StretchImage
                // Set logo image if available
            };

            // Create Navigation Buttons
            btnBrowseListings = CreateRoundedButton("Browse Listings", 200, Color.FromArgb(30, 85, 110), Color.White);
            btnListCar = CreateRoundedButton("List a Car", 270, Color.FromArgb(173, 216, 230), Color.Black);
            btnManageBooking = CreateRoundedButton("Manage Booking", 340, Color.FromArgb(30, 85, 110), Color.White);
            btnOptions = CreateRoundedButton("Options", 410, Color.FromArgb(30, 85, 110), Color.White);

            sidebar.Controls.AddRange(new Control[] {
                pictureBoxLogo,
                btnBrowseListings,
                btnListCar,
                btnManageBooking,
                btnOptions
            });

            // Content Panel Setup
            contentPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                Padding = new Padding(50)
            };

            // Make Dropdown
            lblMake = CreateLabel("Car Make:", new Point(30, 30));
            cmbMake = CreateComboBox(new Point(30, 60), new[] { "Toyota", "Honda", "BMW", "Mercedes", "Ford" });
            cmbMake.SelectedIndexChanged += cmbMake_SelectedIndexChanged;

            // Model Dropdown
            lblModel = CreateLabel("Model*:", new Point(350, 30));
            cmbModel = CreateComboBox(new Point(350, 60));

            // Year Dropdown
            lblYear = CreateLabel("Year*:", new Point(670, 30));
            cmbYear = CreateComboBox(new Point(670, 60),
                new[] { "2023", "2022", "2021", "2020", "2019", "2018" });

            // Type Dropdown
            lblType = CreateLabel("Car Type*:", new Point(30, 120));
            cmbType = CreateComboBox(new Point(30, 150),
                new[] { "Sedan", "SUV", "Truck", "Coupe", "Hatchback" });

            // Color Dropdown
            lblColor = CreateLabel("Color*:", new Point(350, 120));
            cmbColor = CreateComboBox(new Point(350, 150),
                new[] { "Black", "White", "Red", "Blue", "Silver", "Gray" });

            // License Plate
            lblLicensePlate = CreateLabel("License Plate*:", new Point(670, 120));
            txtLicensePlate = new TextBox
            {
                Location = new Point(670, 150),
                Size = new Size(250, 30)
            };

            // Description
            lblDescription = CreateLabel("Description*:", new Point(30, 220));
            txtCarDescription = new TextBox
            {
                Location = new Point(30, 250),
                Size = new Size(890, 100),
                Multiline = true,
                Text = "Describe your car, including condition, special features, etc."
            };

            // Daily Rate
            lblDailyRate = CreateLabel("Daily Rate (MUR)*:", new Point(30, 380));
            txtDailyRate = new TextBox
            {
                Location = new Point(30, 410),
                Size = new Size(250, 30),
                Text = "7500.00"
            };

            // Image Upload Panel
            panelImageUpload = new Panel
            {
                Location = new Point(30, 470),
                Size = new Size(890, 150),
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.WhiteSmoke
            };

            // Image Preview PictureBoxes
            pictureBox1 = CreateImagePreview(10);
            pictureBox2 = CreateImagePreview(150);
            pictureBox3 = CreateImagePreview(290);
            pictureBox4 = CreateImagePreview(430);
            pictureBox5 = CreateImagePreview(570);

            panelImageUpload.Controls.AddRange(new Control[] {
                pictureBox1, pictureBox2, pictureBox3, pictureBox4, pictureBox5
            });

            // Drag Drop Label
            lblDragDrop = new Label
            {
                Text = "Drag and drop photos here or click to browse",
                Font = new Font("Segoe UI", 10),
                ForeColor = Color.Gray,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill
            };
            panelImageUpload.Controls.Add(lblDragDrop);

            // List My Car Button
            btnListMyCar = new Button
            {
                Text = "List My Car",
                Location = new Point(30, 640),
                Size = new Size(890, 40),
                BackColor = Color.FromArgb(30, 85, 110),
                ForeColor = Color.White
            };
            btnListMyCar.Click += btnListMyCar_Click;

            // Add controls to content panel
            contentPanel.Controls.AddRange(new Control[] {
                lblMake, cmbMake,
                lblModel, cmbModel,
                lblYear, cmbYear,
                lblType, cmbType,
                lblColor, cmbColor,
                lblLicensePlate, txtLicensePlate,
                lblDescription, txtCarDescription,
                lblDailyRate, txtDailyRate,
                panelImageUpload,
                btnListMyCar
            });

            // Main Panel Setup
            panelMain = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White
            };
            panelMain.Controls.Add(contentPanel);

            // Add panels to form
            this.Controls.AddRange(new Control[] { panelMain, sidebar });
        }

        // Helper method to create labels
        private Label CreateLabel(string text, Point location)
        {
            return new Label
            {
                Text = text,
                Location = location,
                AutoSize = true,
                Font = new Font("Segoe UI", 10)
            };
        }

        // Helper method to create comboboxes
        private ComboBox CreateComboBox(Point location, string[] items = null)
        {
            var comboBox = new ComboBox
            {
                Location = location,
                Size = new Size(250, 30),
                DropDownStyle = ComboBoxStyle.DropDownList
            };

            if (items != null)
            {
                comboBox.Items.AddRange(items);
            }

            return comboBox;
        }

        // Helper method to create image preview PictureBoxes
        private PictureBox CreateImagePreview(int xLocation)
        {
            return new PictureBox
            {
                Location = new Point(xLocation, 10),
                Size = new Size(130, 130),
                SizeMode = PictureBoxSizeMode.StretchImage,
                BorderStyle = BorderStyle.FixedSingle
            };
        }

        // Helper method to create rounded buttons
        private RoundedButton CreateRoundedButton(string text, int yPosition, Color backColor, Color textColor)
        {
            return new RoundedButton
            {
                Size = new Size(200, 50),
                Location = new Point(25, yPosition),
                Text = text,
                BackColor = backColor,
                ForeColor = textColor,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 12, FontStyle.Regular)
            };
        }
    }
}
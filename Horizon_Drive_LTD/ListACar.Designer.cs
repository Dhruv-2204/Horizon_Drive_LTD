using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace list_your_car_page
{
    partial class ListACar : Form
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.SuspendLayout();

            // Form1
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 800);
            this.BackColor = Color.White;
            this.Name = "Form1";
            this.Text = "List Your Car";
            this.Load += new System.EventHandler(this.Form1_Load);

            // Adding UI components
            CreateSidebar();
            CreateFormContainer();

            this.ResumeLayout(false);
        }

        private void CreateSidebar()
        {
            // Sidebar Panel
            RoundedPanel sidebar = new RoundedPanel()
            {
                Size = new Size(250, this.ClientSize.Height),
                BackColor = ColorTranslator.FromHtml("#142F3A"),
                Dock = DockStyle.Left,
                CornerRadius = 20
            };

            // Create and configure the PictureBox
            PictureBox circleLogo = new PictureBox()
            {
                Size = new Size(125, 125), // Dimensions for the circular logo
                Location = new Point((sidebar.Width - 125) / 2, 20), // Centered horizontally, 20px from the top
                BackColor = Color.Transparent,
                SizeMode = PictureBoxSizeMode.StretchImage // Ensures the image fits in the PictureBox
            };

            // Load the logo from the project Pictures folder
            try
            {
                string projectDirectory = Path.GetDirectoryName(Application.ExecutablePath);
                // Go up three levels from bin\Debug\net9.0-windows to the project root
                string rootDirectory = Directory.GetParent(Directory.GetParent(Directory.GetParent(projectDirectory).FullName).FullName).FullName;
                string logoPath = Path.Combine(rootDirectory, "Pictures", "Logo.png");

                if (File.Exists(logoPath))
                {
                    circleLogo.Image = Image.FromFile(logoPath);
                }
                else
                {
                    MessageBox.Show("Logo file not found: " + logoPath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not load logo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Make the PictureBox circular
            circleLogo.Paint += (s, e) =>
            {
                GraphicsPath path = new GraphicsPath();
                path.AddEllipse(0, 0, circleLogo.Width, circleLogo.Height); // Creates a circular region
                circleLogo.Region = new Region(path); // Apply the circular region
            };

            sidebar.Controls.Add(circleLogo);

            // Add Buttons
            string[] buttonLabels = { "Browse Listings", "List a Car", "Manage Booking", "Options" };
            Color[] buttonColors = { ColorTranslator.FromHtml("#2C6B7F"), Color.FromArgb(173, 216, 230), ColorTranslator.FromHtml("#2C6B7F"), ColorTranslator.FromHtml("#2C6B7F") };

            for (int i = 0; i < buttonLabels.Length; i++)
            {
                RoundedButton button = new RoundedButton()
                {
                    Text = buttonLabels[i],
                    Size = new Size(200, 50),
                    Location = new Point(25, 180 + (i * 60)), // Adjusted Y position to account for the logo
                    BackColor = buttonColors[i],
                    CornerRadius = 15,
                    Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
                };
                sidebar.Controls.Add(button);
            }

            this.Controls.Add(sidebar);
        }


        private void CreateFormContainer()
        {
            RoundedPanel formContainer = new RoundedPanel()
            {
                Size = new Size(this.ClientSize.Width - 270, this.ClientSize.Height - 40),
                Location = new Point(260, 10),
                BackColor = ColorTranslator.FromHtml("#D3D3D3"),  // Paler grey color
                CornerRadius = 20,
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Right
            };

            CreateFormElements(formContainer);
            this.Controls.Add(formContainer);
        }

        private void CreateFormElements(Panel parent)
        {
            int paddingX = 30, paddingY = 20;

            ComboBox cmbMake = CreateComboBox(new Point(paddingX, paddingY + 30), 200, new string[] { "Toyota", "Honda", "BMW", "Mercedes", "Ford" });
            cmbMake.Text = "Select Make";
            parent.Controls.Add(AddLabel("Make*", paddingX, paddingY, parent));
            parent.Controls.Add(cmbMake);

            ComboBox cmbModel = CreateComboBox(new Point(paddingX + 250, paddingY + 30), 200, null);
            cmbModel.Text = "Select Model";
            parent.Controls.Add(AddLabel("Model*", paddingX + 250, paddingY, parent));
            parent.Controls.Add(cmbModel);

            ComboBox cmbYear = CreateComboBox(new Point(paddingX + 500, paddingY + 30), 200, GetYears());
            cmbYear.Text = "Select Year";
            parent.Controls.Add(AddLabel("Year*", paddingX + 500, paddingY, parent));
            parent.Controls.Add(cmbYear);

            ComboBox cmbType = CreateComboBox(new Point(paddingX, paddingY + 100), 200, new string[] { "Sedan", "SUV", "Truck", "Coupe", "Hatchback" });
            cmbType.Text = "Select Type";
            parent.Controls.Add(AddLabel("Type*", paddingX, paddingY + 80, parent));
            parent.Controls.Add(cmbType);

            ComboBox cmbColor = CreateComboBox(new Point(paddingX + 250, paddingY + 100), 200, new string[] { "Black", "White", "Red", "Blue", "Silver" });
            cmbColor.Text = "Select Color";
            parent.Controls.Add(AddLabel("Color*", paddingX + 250, paddingY + 80, parent));
            parent.Controls.Add(cmbColor);

            TextBox txtLicensePlate = CreateTextBox(new Point(paddingX + 500, paddingY + 100), new Size(200, 30), false);
            parent.Controls.Add(AddLabel("License Plate*", paddingX + 500, paddingY + 80, parent));
            parent.Controls.Add(txtLicensePlate);

            TextBox txtCarDescription = CreateTextBox(new Point(paddingX, paddingY + 180), new Size(700, 100), true);
            txtCarDescription.Text = "Describe your car, including condition, special features, etc."; // Set initial text in description
            parent.Controls.Add(AddLabel("Description*", paddingX, paddingY + 160, parent));
            parent.Controls.Add(txtCarDescription);

            TextBox txtDailyRate = CreateTextBox(new Point(paddingX, paddingY + 310), new Size(200, 30), false);
            txtDailyRate.Text = "7500.00"; // Set example value for daily rate
            parent.Controls.Add(AddLabel("Daily Rate (MUR)*", paddingX, paddingY + 290, parent));
            parent.Controls.Add(txtDailyRate);

            Label dailyRateInfoLabel = AddLabel("Set a competitive daily rate to attract renters", paddingX, paddingY + 343, parent);
            dailyRateInfoLabel.ForeColor = Color.Gray;
            dailyRateInfoLabel.Font = new Font(dailyRateInfoLabel.Font.FontFamily, 8.5f);
            parent.Controls.Add(dailyRateInfoLabel);

            TextBox txtLocation = CreateTextBox(new Point(paddingX + 350, paddingY + 310), new Size(200, 30), false);
            parent.Controls.Add(AddLabel("Location*", paddingX + 350, paddingY + 290, parent));
            parent.Controls.Add(txtLocation);

            // Add Car Image Section
            Label lblPhotos = new Label()
            {
                Text = "Upload Photo*",
                Location = new Point(paddingX, paddingY + 360),
                AutoSize = true,
                Font = new Font("Arial", 10, FontStyle.Bold),
                Anchor = AnchorStyles.Top | AnchorStyles.Left
            };
            parent.Controls.Add(lblPhotos);

            PictureBox pbCarImage = new PictureBox()
            {
                Size = new Size(200, 150),
                Location = new Point(paddingX, paddingY + 400),
                BorderStyle = BorderStyle.FixedSingle,
                SizeMode = PictureBoxSizeMode.StretchImage,
                BackColor = Color.LightGray
            };
            parent.Controls.Add(pbCarImage);

            Button btnUploadImage = new Button()
            {
                Text = "Upload Image",
                Location = new Point(paddingX, paddingY + 570),
                Size = new Size(200, 30),
                BackColor = Color.LightBlue,
                FlatStyle = FlatStyle.Flat
            };
            btnUploadImage.Click += (sender, e) => UploadCarImage(pbCarImage);
            parent.Controls.Add(btnUploadImage);

            Label lblAvailability = new Label()
            {
                Text = "Availability*",
                Location = new Point(paddingX, paddingY + 620),
                AutoSize = true,
                Font = new Font("Arial", 10, FontStyle.Bold),
                Anchor = AnchorStyles.Top | AnchorStyles.Left
            };
            parent.Controls.Add(lblAvailability);

            DateTimePicker dpStartDate = new DateTimePicker()
            {
                Location = new Point(paddingX, paddingY + 650),
                Format = DateTimePickerFormat.Short,
                Anchor = AnchorStyles.Top | AnchorStyles.Left
            };
            parent.Controls.Add(dpStartDate);

            DateTimePicker dpEndDate = new DateTimePicker()
            {
                Location = new Point(paddingX + 250, paddingY + 650),
                Format = DateTimePickerFormat.Short,
                Anchor = AnchorStyles.Top | AnchorStyles.Left
            };
            parent.Controls.Add(dpEndDate);

            Label lblFeatures = new Label()
            {
                Text = "Additional Features*",
                Location = new Point(paddingX, paddingY + 700),
                AutoSize = true,
                Font = new Font("Arial", 10, FontStyle.Bold),
                Anchor = AnchorStyles.Top | AnchorStyles.Left
            };
            parent.Controls.Add(lblFeatures);

            CheckBox chkGPS = new CheckBox()
            {
                Text = "GPS",
                Location = new Point(paddingX, paddingY + 730),
                AutoSize = true,
                Anchor = AnchorStyles.Top | AnchorStyles.Left
            };
            parent.Controls.Add(chkGPS);

            CheckBox chkBluetooth = new CheckBox()
            {
                Text = "Bluetooth",
                Location = new Point(paddingX + 100, paddingY + 730),
                AutoSize = true,
                Anchor = AnchorStyles.Top | AnchorStyles.Left
            };
            parent.Controls.Add(chkBluetooth);

            CheckBox chkLeatherSeats = new CheckBox()
            {
                Text = "Leather Seats",
                Location = new Point(paddingX + 250, paddingY + 730),
                AutoSize = true,
                Anchor = AnchorStyles.Top | AnchorStyles.Left
            };
            parent.Controls.Add(chkLeatherSeats);

            CheckBox chkSunroof = new CheckBox()
            {
                Text = "Sunroof",
                Location = new Point(paddingX + 400, paddingY + 730),
                AutoSize = true,
                Anchor = AnchorStyles.Top | AnchorStyles.Left
            };
            parent.Controls.Add(chkSunroof);

            CheckBox chkChildSeat = new CheckBox()
            {
                Text = "Child Seat",
                Location = new Point(paddingX + 550, paddingY + 730),
                AutoSize = true,
                Anchor = AnchorStyles.Top | AnchorStyles.Left
            };
            parent.Controls.Add(chkChildSeat);

            RoundedButton btnListCar = new RoundedButton()
            {
                Location = new Point(parent.Width - 350 - paddingX, paddingY + 800),
                Width = 350,
                Height = 60,
                Text = "List My Car",
                CornerRadius = 15,
                Anchor = AnchorStyles.Bottom | AnchorStyles.Right,
                BackColor = ColorTranslator.FromHtml("#142F3A"),
                ForeColor = Color.White
            };
            btnListCar.Click += BtnListCar_Click;
            parent.Controls.Add(btnListCar);
        }


        private Label AddLabel(string text, int x, int y, Panel parent)
        {
            return new Label()
            {
                Text = text,
                Location = new Point(x, y),
                AutoSize = true,
                Font = new Font("Arial", 10, FontStyle.Bold),
                Anchor = AnchorStyles.Top | AnchorStyles.Left
            };
        }


        private ComboBox CreateComboBox(Point location, int width, string[] items)
        {
            ComboBox comboBox = new ComboBox()
            {
                Location = location,
                Width = width,
                Anchor = AnchorStyles.Top | AnchorStyles.Left
            };

            if (items != null)
                comboBox.Items.AddRange(items);

            return comboBox;
        }

        private TextBox CreateTextBox(Point location, Size size, bool isMultiline)
        {
            return new TextBox()
            {
                Location = location,
                Size = size,
                Multiline = isMultiline,
                Anchor = isMultiline ? (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right) : AnchorStyles.Top | AnchorStyles.Left
            };
        }

        private void UploadCarImage(PictureBox pb)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    pb.Image = Image.FromFile(ofd.FileName);
                }
            }
        }

        private string[] GetYears()
        {
            int currentYear = DateTime.Now.Year;
            string[] years = new string[currentYear - 1999];
            for (int i = 2000; i <= currentYear; i++)
            {
                years[i - 2000] = i.ToString();
            }
            return years;
        }

        #endregion
    }

    public class RoundedPanel : Panel
    {
        public int CornerRadius { get; set; }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            GraphicsPath path = new GraphicsPath();
            path.AddArc(new Rectangle(0, 0, CornerRadius, CornerRadius), 180, 90);
            path.AddArc(new Rectangle(Width - CornerRadius, 0, CornerRadius, CornerRadius), 270, 90);
            path.AddArc(new Rectangle(Width - CornerRadius, Height - CornerRadius, CornerRadius, CornerRadius), 0, 90);
            path.AddArc(new Rectangle(0, Height - CornerRadius, CornerRadius, CornerRadius), 90, 90);
            path.CloseAllFigures();
            this.Region = new Region(path);
        }
    }

    public class RoundedButton : Button
    {
        public int CornerRadius { get; set; }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            GraphicsPath path = new GraphicsPath();
            path.AddArc(new Rectangle(0, 0, CornerRadius, CornerRadius), 180, 90);
            path.AddArc(new Rectangle(Width - CornerRadius, 0, CornerRadius, CornerRadius), 270, 90);
            path.AddArc(new Rectangle(Width - CornerRadius, Height - CornerRadius, CornerRadius, CornerRadius), 0, 90);
            path.AddArc(new Rectangle(0, Height - CornerRadius, CornerRadius, CornerRadius), 90, 90);
            path.CloseAllFigures();
            this.Region = new Region(path);
        }
    }
}

using System;
using System.Drawing;
using System.Windows.Forms;

namespace Horizon_Drive_LTD
{
    public partial class CarBookingForm : Form
    {
        private CarListing car;

        public CarBookingForm(CarListing selectedCar)
        {
            InitializeComponent();
            car = selectedCar;
            PopulateCarDetails();
        }

        private void InitializeComponent()
        {
            this.ClientSize = new Size(800, 750);
            this.MinimumSize = new Size(800, 750);
            this.Text = "Horizon Drive - Car Booking";
            this.StartPosition = FormStartPosition.CenterParent;
            this.BackColor = Color.White;

            // Main panel
            Panel mainPanel = new Panel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                Padding = new Padding(20)
            };
            this.Controls.Add(mainPanel);

            // Car Image and Details Section
            Panel carDetailsPanel = new Panel
            {
                Width = 760,
                Height = 300,
                Dock = DockStyle.Top
            };
            mainPanel.Controls.Add(carDetailsPanel);

            // Car Image
            pictureBoxCar = new PictureBox
            {
                Size = new Size(240, 180),
                Location = new Point(10, 10),
                SizeMode = PictureBoxSizeMode.Zoom,
                BorderStyle = BorderStyle.FixedSingle
            };
            carDetailsPanel.Controls.Add(pictureBoxCar);

            // Car Title
            labelCarTitle = new Label
            {
                AutoSize = false,
                Size = new Size(490, 30),
                Location = new Point(260, 10),
                Font = new Font("Segoe UI", 14, FontStyle.Bold)
            };
            carDetailsPanel.Controls.Add(labelCarTitle);

            // Location
            labelLocation = new Label
            {
                AutoSize = false,
                Size = new Size(490, 20),
                Location = new Point(260, 45),
                Font = new Font("Segoe UI", 9)
            };
            carDetailsPanel.Controls.Add(labelLocation);

            // Price
            labelPrice = new Label
            {
                AutoSize = false,
                Size = new Size(490, 20),
                Location = new Point(260, 70),
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };
            carDetailsPanel.Controls.Add(labelPrice);

            // Book Now Button at the top
            labelBookNow = new Label
            {
                AutoSize = false,
                Size = new Size(490, 20),
                Location = new Point(260, 95),
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                Text = "Book now"
            };
            carDetailsPanel.Controls.Add(labelBookNow);

            // Car Specifications
            AddSpecification(carDetailsPanel, "Transmission: Automatic", new Point(260, 120));
            AddSpecification(carDetailsPanel, "Passengers: 5 Seats", new Point(260, 140));
            AddSpecification(carDetailsPanel, "Storage Capacity: 1000kgs", new Point(260, 160));
            AddSpecification(carDetailsPanel, "Power: 450hp", new Point(260, 180));
            AddSpecification(carDetailsPanel, "Drivetrain: 4WD (Four-Wheel Drive)", new Point(260, 200));

            // Star Rating
            Panel ratingPanel = new Panel
            {
                Size = new Size(490, 30),
                Location = new Point(260, 225)
            };
            carDetailsPanel.Controls.Add(ratingPanel);

            for (int i = 0; i < 5; i++)
            {
                PictureBox star = new PictureBox
                {
                    Size = new Size(20, 20),
                    Location = new Point(i * 25, 0),
                    BackColor = i < 4 ? Color.Gold : Color.LightGray
                };
                ratingPanel.Controls.Add(star);
            }

            Label ratingCount = new Label
            {
                AutoSize = true,
                Location = new Point(130, 2),
                Font = new Font("Segoe UI", 8),
                Text = "(4.0/5)"
            };
            ratingPanel.Controls.Add(ratingCount);

            // Features Section
            Label featuresLabel = new Label
            {
                AutoSize = false,
                Size = new Size(760, 20),
                Location = new Point(10, 290),
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                Text = "Features:"
            };
            mainPanel.Controls.Add(featuresLabel);

            Label featuresDetails = new Label
            {
                AutoSize = false,
                Size = new Size(760, 30),
                Location = new Point(10, 310),
                Font = new Font("Segoe UI", 9),
                Text = "ABS, Airbags, Alloy Wheels, Auto Start-Stop, AUX, Bluetooth, Central Locking, Keyless Engine Start, Parking Sensors, Power Mirrors, Power Windows, Reverse Camera, USB"
            };
            mainPanel.Controls.Add(featuresDetails);

            // Vehicle Description
            Label descLabel = new Label
            {
                AutoSize = false,
                Size = new Size(760, 20),
                Location = new Point(10, 350),
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                Text = "Vehicle Description"
            };
            mainPanel.Controls.Add(descLabel);

            textBoxDescription = new TextBox
            {
                Multiline = true,
                ReadOnly = true,
                BorderStyle = BorderStyle.None,
                BackColor = Color.White,
                Size = new Size(760, 80),
                Location = new Point(10, 370),
                Font = new Font("Segoe UI", 9)
            };
            mainPanel.Controls.Add(textBoxDescription);

            // Booking Details Section
            // Date Selection
            int currentY = 460;

            // Start Date
            Label startDateLabel = new Label
            {
                AutoSize = true,
                Location = new Point(10, currentY),
                Text = "Start Date:",
                Font = new Font("Segoe UI", 9)
            };
            mainPanel.Controls.Add(startDateLabel);

            dateTimePickerStart = new DateTimePicker
            {
                Size = new Size(230, 25),
                Location = new Point(10, currentY + 20),
                Format = DateTimePickerFormat.Short,
                Value = DateTime.Now.AddDays(1)
            };
            mainPanel.Controls.Add(dateTimePickerStart);

            // End Date
            Label endDateLabel = new Label
            {
                AutoSize = true,
                Location = new Point(310, currentY),
                Text = "End Date:",
                Font = new Font("Segoe UI", 9)
            };
            mainPanel.Controls.Add(endDateLabel);

            dateTimePickerEnd = new DateTimePicker
            {
                Size = new Size(230, 25),
                Location = new Point(310, currentY + 20),
                Format = DateTimePickerFormat.Short,
                Value = DateTime.Now.AddDays(3)
            };
            mainPanel.Controls.Add(dateTimePickerEnd);

            currentY += 60;

            // Pickup Location
            Label pickupLabel = new Label
            {
                AutoSize = true,
                Location = new Point(10, currentY),
                Text = "Pick-Up Location:",
                Font = new Font("Segoe UI", 9)
            };
            mainPanel.Controls.Add(pickupLabel);

            comboBoxPickup = new ComboBox
            {
                Size = new Size(230, 25),
                Location = new Point(10, currentY + 20),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            comboBoxPickup.Items.AddRange(new object[] { "Port Louis City Center", "SSR International Airport", "Grand Baie", "Flic en Flac", "Quatre Bornes" });
            comboBoxPickup.SelectedIndex = 0;
            mainPanel.Controls.Add(comboBoxPickup);

            // Drop-off Location
            Label dropoffLabel = new Label
            {
                AutoSize = true,
                Location = new Point(310, currentY),
                Text = "Drop-off Location:",
                Font = new Font("Segoe UI", 9)
            };
            mainPanel.Controls.Add(dropoffLabel);

            comboBoxDropoff = new ComboBox
            {
                Size = new Size(230, 25),
                Location = new Point(310, currentY + 20),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            comboBoxDropoff.Items.AddRange(new object[] { "Port Louis City Center", "SSR International Airport", "Grand Baie", "Flic en Flac", "Quatre Bornes" });
            comboBoxDropoff.SelectedIndex = 0;
            mainPanel.Controls.Add(comboBoxDropoff);

            currentY += 60;

            // Interests/Add-ons
            Label interestsLabel = new Label
            {
                AutoSize = true,
                Location = new Point(10, currentY),
                Text = "Interest:",
                Font = new Font("Segoe UI", 9)
            };
            mainPanel.Controls.Add(interestsLabel);

            currentY += 25;

            // Add-on panel
            Panel addonsPanel = new Panel
            {
                Size = new Size(530, 130),
                Location = new Point(10, currentY),
                BorderStyle = BorderStyle.FixedSingle
            };
            mainPanel.Controls.Add(addonsPanel);

            // Add-on checkboxes
            int checkboxY = 10;
            string[] addons = new string[]
            {
                "Include a driver (+ MUR 1000/day)",
                "Include a baby car seat (+ MUR 500/rental)",
                "Full Insurance Coverage (+ MUR 1500/rental)",
                "Roof Rack (+ MUR 400/rental)",
                "Airport Pickup & Drop-off (+ MUR 1000/trip)"
            };

            foreach (string addon in addons)
            {
                CheckBox checkbox = new CheckBox
                {
                    AutoSize = true,
                    Location = new Point(10, checkboxY),
                    Text = addon,
                    Font = new Font("Segoe UI", 9)
                };
                addonsPanel.Controls.Add(checkbox);
                checkboxY += 25;
            }

            currentY += 145;

            // Book Now Button
            btnBookCar = new Button
            {
                Size = new Size(100, 40),
                Location = new Point(335, currentY),
                Text = "Book Car",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                BackColor = Color.FromArgb(23, 107, 135),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnBookCar.FlatAppearance.BorderSize = 0;
            btnBookCar.Click += BtnBookCar_Click;
            mainPanel.Controls.Add(btnBookCar);
        }

        private void AddSpecification(Panel panel, string text, Point location)
        {
            // Create an icon for the specification
            Label icon = new Label
            {
                AutoSize = false,
                Size = new Size(20, 20),
                Location = location,
                Font = new Font("Segoe UI Symbol", 9),
                Text = "•"
            };
            panel.Controls.Add(icon);

            // Create a label for the specification text
            Label label = new Label
            {
                AutoSize = false,
                Size = new Size(450, 20),
                Location = new Point(location.X + 20, location.Y),
                Font = new Font("Segoe UI", 9),
                Text = text
            };
            panel.Controls.Add(label);
        }

        private void PopulateCarDetails()
        {
            // Set car image
            try
            {
                pictureBoxCar.Image = Image.FromFile(Path.Combine("Images", car.ImagePath));
            }
            catch
            {
                pictureBoxCar.BackColor = Color.LightGray;
            }

            // Set car title
            labelCarTitle.Text = $"{car.Make} {car.Model} for Rent";

            // Set location
            labelLocation.Text = "At from Horizon Drive Ltd, Mauritius";

            // Set price
            labelPrice.Text = $"MUR {car.PricePerDay}/day";

            // Set description
            string description = $"Off-Road Pickup Rental in Mauritius – Conquer Any Terrain!\n" +
                $"Looking for a rugged and powerful pickup rental in Mauritius? The {car.Make} {car.Model} at Horizon Drive Ltd is built for " +
                $"adventure, offering unmatched off-road capability, superior comfort, and cutting-edge features. Whether " +
                $"you're exploring rough trails, heading to a work mission, or cruising through the city in style, the Raptor " +
                $"ensures a thrilling and confident drive.\n\n" +
                $"Book now and experience the power of the {car.Make} {car.Model}!";

            textBoxDescription.Text = description;
        }

        private void BtnBookCar_Click(object sender, EventArgs e)
        {
            // Calculate rental days
            TimeSpan rentalPeriod = dateTimePickerEnd.Value - dateTimePickerStart.Value;
            int days = (int)Math.Ceiling(rentalPeriod.TotalDays);

            if (days <= 0)
            {
                MessageBox.Show("Please select a valid rental period.", "Invalid Dates",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Calculate base price
            decimal basePrice = days * car.PricePerDay;

            // Show booking confirmation
            MessageBox.Show($"Booking Confirmed!\n\n" +
                $"Vehicle: {car.Make} {car.Model} {car.Year}\n" +
                $"Rental Period: {days} days\n" +
                $"Pick-up: {comboBoxPickup.SelectedItem}\n" +
                $"Drop-off: {comboBoxDropoff.SelectedItem}\n" +
                $"Base Price: MUR {basePrice:N0}\n\n" +
                $"An email confirmation will be sent to you shortly.",
                "Booking Confirmation",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            this.Close();
        }

        // Form controls
        private PictureBox pictureBoxCar;
        private Label labelCarTitle;
        private Label labelLocation;
        private Label labelPrice;
        private Label labelBookNow;
        private TextBox textBoxDescription;
        private DateTimePicker dateTimePickerStart;
        private DateTimePicker dateTimePickerEnd;
        private ComboBox comboBoxPickup;
        private ComboBox comboBoxDropoff;
        private Button btnBookCar;
    }
}
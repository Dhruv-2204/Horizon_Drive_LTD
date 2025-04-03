using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Horizon_Drive_LTD
{
    public partial class CarBookingForm : Form
    {
        private CarListing car;
        private List<string> carImages = new List<string>();
        private int currentImageIndex = 0;
        private System.Windows.Forms.Timer slideshowTimer;
        private Button btnNextImage;
        private Button btnPrevImage;

        public CarBookingForm(CarListing selectedCar)
        {
            InitializeComponent();
            car = selectedCar;

            // Initialize slideshow controls
            InitializeSlideshowControls();

            // Initialize slideshow images
            InitializeSlideshow();

            // Set default dates
            dateTimePickerStart.Value = DateTime.Now.AddDays(1);
            dateTimePickerEnd.Value = DateTime.Now.AddDays(3);

            // Set default pickup/dropoff locations
            if (comboBoxPickup.Items.Count > 0)
                comboBoxPickup.SelectedIndex = 0;

            if (comboBoxDropoff.Items.Count > 0)
                comboBoxDropoff.SelectedIndex = 0;

            PopulateCarDetails();
        }

        private void InitializeSlideshowControls()
        {
            // Create next image button
            btnNextImage = new Button();
            btnNextImage.Size = new Size(30, 30);
            btnNextImage.Location = new Point(pictureBoxCar.Right - 30, pictureBoxCar.Top + (pictureBoxCar.Height / 2) - 15);
            btnNextImage.Text = ">";
            btnNextImage.BackColor = Color.FromArgb(200, 200, 200);
            btnNextImage.ForeColor = Color.Black;
            btnNextImage.FlatStyle = FlatStyle.Flat;
            btnNextImage.FlatAppearance.BorderSize = 0;
            btnNextImage.Click += btnNextImage_Click;
            carDetailsPanel.Controls.Add(btnNextImage);
            btnNextImage.BringToFront();

            // Create previous image button
            btnPrevImage = new Button();
            btnPrevImage.Size = new Size(30, 30);
            btnPrevImage.Location = new Point(pictureBoxCar.Left, pictureBoxCar.Top + (pictureBoxCar.Height / 2) - 15);
            btnPrevImage.Text = "<";
            btnPrevImage.BackColor = Color.FromArgb(200, 200, 200);
            btnPrevImage.ForeColor = Color.Black;
            btnPrevImage.FlatStyle = FlatStyle.Flat;
            btnPrevImage.FlatAppearance.BorderSize = 0;
            btnPrevImage.Click += btnPrevImage_Click;
            carDetailsPanel.Controls.Add(btnPrevImage);
            btnPrevImage.BringToFront();

            // Create slideshow timer - explicitly use System.Windows.Forms.Timer
            slideshowTimer = new System.Windows.Forms.Timer();
            slideshowTimer.Interval = 3000; // 3 seconds
            slideshowTimer.Tick += SlideshowTimer_Tick;
        }

        private void InitializeSlideshow()
        {
            // Clear any existing images
            carImages.Clear();

            // Add the main image
            if (!string.IsNullOrEmpty(car.ImagePath))
            {
                carImages.Add(car.ImagePath);
            }

            // Add any additional images from the car listing
            if (car.AdditionalImages != null && car.AdditionalImages.Count > 0)
            {
                carImages.AddRange(car.AdditionalImages);
            }
        }

        private void LoadImage(int index)
        {
            if (carImages.Count > 0)
            {
                try
                {
                    // Make sure index is valid
                    if (index < 0) index = carImages.Count - 1;
                    if (index >= carImages.Count) index = 0;

                    currentImageIndex = index;

                    string imagePath = Path.Combine("Images", carImages[currentImageIndex]);

                    if (File.Exists(imagePath))
                    {
                        pictureBoxCar.Image = Image.FromFile(imagePath);
                    }
                    else
                    {
                        // If file doesn't exist, show placeholder
                        pictureBoxCar.BackColor = Color.LightGray;
                        pictureBoxCar.Image = null;
                    }
                }
                catch (Exception ex)
                {
                    // If there's any error loading the image, use placeholder
                    pictureBoxCar.BackColor = Color.LightGray;
                    pictureBoxCar.Image = null;
                    Console.WriteLine($"Error loading image: {ex.Message}");
                }
            }
        }

        private void SlideshowTimer_Tick(object sender, EventArgs e)
        {
            // Show next image
            LoadImage(currentImageIndex + 1);
        }

        private void btnNextImage_Click(object sender, EventArgs e)
        {
            // Show next image
            LoadImage(currentImageIndex + 1);
        }

        private void btnPrevImage_Click(object sender, EventArgs e)
        {
            // Show previous image
            LoadImage(currentImageIndex - 1);
        }

        private void pictureBoxCar_Click(object sender, EventArgs e)
        {
            // Toggle slideshow
            if (slideshowTimer.Enabled)
            {
                slideshowTimer.Stop();
            }
            else
            {
                slideshowTimer.Start();
            }
        }

        private void PopulateCarDetails()
        {
            // Load the first image
            LoadImage(0);

            // Set car title
            labelCarTitle.Text = $"{car.Make} {car.Model} ({car.Year}) for Rent";

            // Set location
            labelLocation.Text = "From Horizon Drive Ltd, Mauritius";

            // Set price
            labelPrice.Text = $"MUR {car.PricePerDay}/day";

            // Set description
            string description = $"Premium Vehicle Rental in Mauritius – Experience Luxury and Performance!\n" +
                $"Looking for a high-quality {car.Make} {car.Model} rental in Mauritius? This vehicle at Horizon Drive Ltd offers " +
                $"exceptional comfort, performance, and cutting-edge features. Whether " +
                $"you're exploring the island, heading to business meetings, or enjoying a relaxing vacation, " +
                $"this {car.Make} {car.Model} ensures a memorable driving experience.\n\n" +
                $"Book now and experience the power and elegance of the {car.Make} {car.Model}!";

            textBoxDescription.Text = description;

            // Customize specifications based on car type
            CustomizeSpecifications();
        }

        private void CustomizeSpecifications()
        {
            // Customize specifications based on car make/model
            // This is just an example - you would typically load this from a database
            switch (car.Model.ToLower())
            {
                case "raptor":
                    transmissionSpec.Text = "Transmission: Automatic";
                    passengersSpec.Text = "Passengers: 5 Seats";
                    storageSpec.Text = "Storage Capacity: 1000kg";
                    powerSpec.Text = "Power: 450hp";
                    drivetrainSpec.Text = "Drivetrain: 4WD (Four-Wheel Drive)";
                    break;

                case "x4":
                    transmissionSpec.Text = "Transmission: Automatic";
                    passengersSpec.Text = "Passengers: 5 Seats";
                    storageSpec.Text = "Storage Capacity: 650kg";
                    powerSpec.Text = "Power: 382hp";
                    drivetrainSpec.Text = "Drivetrain: AWD (All-Wheel Drive)";
                    break;

                case "c8":
                    transmissionSpec.Text = "Transmission: Automatic";
                    passengersSpec.Text = "Passengers: 2 Seats";
                    storageSpec.Text = "Storage Capacity: 357L";
                    powerSpec.Text = "Power: 490hp";
                    drivetrainSpec.Text = "Drivetrain: RWD (Rear-Wheel Drive)";
                    break;

                case "mustang":
                    transmissionSpec.Text = "Transmission: Automatic";
                    passengersSpec.Text = "Passengers: 4 Seats";
                    storageSpec.Text = "Storage Capacity: 382L";
                    powerSpec.Text = "Power: 460hp";
                    drivetrainSpec.Text = "Drivetrain: RWD (Rear-Wheel Drive)";
                    break;

                case "amg":
                case "amg gt":
                    transmissionSpec.Text = "Transmission: Automatic";
                    passengersSpec.Text = "Passengers: 2 Seats";
                    storageSpec.Text = "Storage Capacity: 350L";
                    powerSpec.Text = "Power: 503hp";
                    drivetrainSpec.Text = "Drivetrain: RWD (Rear-Wheel Drive)";
                    break;

                case "civic":
                    transmissionSpec.Text = "Transmission: Automatic";
                    passengersSpec.Text = "Passengers: 5 Seats";
                    storageSpec.Text = "Storage Capacity: 428L";
                    powerSpec.Text = "Power: 180hp";
                    drivetrainSpec.Text = "Drivetrain: FWD (Front-Wheel Drive)";
                    break;

                case "gle coupe":
                    transmissionSpec.Text = "Transmission: Automatic";
                    passengersSpec.Text = "Passengers: 5 Seats";
                    storageSpec.Text = "Storage Capacity: 600L";
                    powerSpec.Text = "Power: 429hp";
                    drivetrainSpec.Text = "Drivetrain: AWD (All-Wheel Drive)";
                    break;

                default:
                    // Default specifications
                    transmissionSpec.Text = "Transmission: Automatic";
                    passengersSpec.Text = "Passengers: 5 Seats";
                    storageSpec.Text = "Storage Capacity: 500L";
                    powerSpec.Text = "Power: 300hp";
                    drivetrainSpec.Text = "Drivetrain: FWD (Front-Wheel Drive)";
                    break;
            }
        }

        private void btnBookCar_Click(object sender, EventArgs e)
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

            // Get pickup and dropoff locations
            string pickupLocation = comboBoxPickup.SelectedItem?.ToString() ?? string.Empty;
            string dropoffLocation = comboBoxDropoff.SelectedItem?.ToString() ?? string.Empty;

            // Show booking confirmation dialog
            BookingConfirmationForm confirmationForm = new BookingConfirmationForm(
                car,
                dateTimePickerStart.Value,
                dateTimePickerEnd.Value,
                pickupLocation,
                dropoffLocation,
                checkBoxDriver.Checked,
                checkBoxBabyCarSeat.Checked,
                checkBoxInsurance.Checked,
                checkBoxRoofRack.Checked,
                checkBoxAirportPickup.Checked
            );

            if (confirmationForm.ShowDialog() == DialogResult.OK)
            {
                // Booking was confirmed - you could save to database here
                this.Close();
            }
            // If user cancelled, they stay on the booking form
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                // Stop and dispose the timer
                if (slideshowTimer != null)
                {
                    slideshowTimer.Stop();
                    slideshowTimer.Dispose();
                }

                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }
    }
}
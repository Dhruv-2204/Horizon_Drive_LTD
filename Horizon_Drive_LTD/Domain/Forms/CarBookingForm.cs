//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Drawing;
//using System.IO;
//using System.Windows.Forms;
//using Horizon_Drive_LTD.BusinessLogic.Repositories;
//using Horizon_Drive_LTD.BusinessLogic;
//using Horizon_Drive_LTD.DataStructure;
//using Horizon_Drive_LTD.Domain.Entities;

//namespace Horizon_Drive_LTD
//{
//    public partial class CarBookingForm : Form
//    {
//        private Cars car;
//        private List<string> carImages = new List<string>();
//        private int currentImageIndex = 0;
//        private System.Windows.Forms.Timer slideshowTimer;

//        private Button btnNextImage;
//        private Button btnPrevImage;


//        public CarBookingForm(Cars selectedCar)
//        {
//            InitializeComponent();
//            car = selectedCar;

//            // Initialize slideshow controls
//            InitializeSlideshowControls();

//            // Initialize slideshow images
//            InitializeSlideshow();

//            // Set default dates
//            dateTimePickerStart.Value = DateTime.Now.AddDays(1);
//            dateTimePickerEnd.Value = DateTime.Now.AddDays(3);

//            // Set default pickup/dropoff locations
//            if (comboBoxPickup.Items.Count > 0)
//                comboBoxPickup.SelectedIndex = 0;

//            if (comboBoxDropoff.Items.Count > 0)
//                comboBoxDropoff.SelectedIndex = 0;

//            PopulateCarDetails();
//        }

//        private void InitializeSlideshowControls()
//        {
//            // Create next image button
//            btnNextImage = new Button();
//            btnNextImage.Size = new Size(30, 30);
//            btnNextImage.Location = new Point(pictureBoxCar.Right - 30, pictureBoxCar.Top + (pictureBoxCar.Height / 2) - 15);
//            btnNextImage.Text = ">";
//            btnNextImage.BackColor = Color.FromArgb(200, 200, 200);
//            btnNextImage.ForeColor = Color.Black;
//            btnNextImage.FlatStyle = FlatStyle.Flat;
//            btnNextImage.FlatAppearance.BorderSize = 0;
//            btnNextImage.Click += btnNextImage_Click;
//            carDetailsPanel.Controls.Add(btnNextImage);
//            btnNextImage.BringToFront();

//            // Create previous image button
//            btnPrevImage = new Button();
//            btnPrevImage.Size = new Size(30, 30);
//            btnPrevImage.Location = new Point(pictureBoxCar.Left, pictureBoxCar.Top + (pictureBoxCar.Height / 2) - 15);
//            btnPrevImage.Text = "<";
//            btnPrevImage.BackColor = Color.FromArgb(200, 200, 200);
//            btnPrevImage.ForeColor = Color.Black;
//            btnPrevImage.FlatStyle = FlatStyle.Flat;
//            btnPrevImage.FlatAppearance.BorderSize = 0;
//            btnPrevImage.Click += btnPrevImage_Click;
//            carDetailsPanel.Controls.Add(btnPrevImage);
//            btnPrevImage.BringToFront();


//            slideshowTimer = new System.Windows.Forms.Timer();
//            slideshowTimer.Interval = 3000; // 3 seconds
//            slideshowTimer.Tick += SlideshowTimer_Tick;
//        }


//        private void InitializeSlideshow()
//        {
//            carImages.Clear();

//            try
//            {
//                // Set the image folder path: Images/BrowseListings/Brand_Model
//                string baseFolder = Path.Combine(Application.StartupPath, "Images", "BrowseListings");
//                string carFolderName = $"{car.CarBrand}_{car.Model}";
//                string carFolderPath = Path.Combine(baseFolder, carFolderName);

//                if (Directory.Exists(carFolderPath))
//                {
//                    string[] imageFiles = Directory.GetFiles(carFolderPath, "*.*")
//                                                   .Where(file => file.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase)
//                                                               || file.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase)
//                                                               || file.EndsWith(".png", StringComparison.OrdinalIgnoreCase))
//                                                   .ToArray();

//                    if (imageFiles.Length > 0)
//                    {
//                        carImages.AddRange(imageFiles);
//                    }
//                }

//                if (carImages.Count == 0)
//                {
//                    MessageBox.Show("No images found for this car.");
//                }
//                else
//                {
//                    LoadImage(0); // Load the first image
//                }
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show("Slideshow initialization error: " + ex.Message);
//            }
//        }

//        private void LoadImage(int index)
//        {
//            if (carImages.Count > 0)
//            {
//                try
//                {
//                    // Loop the index around
//                    if (index < 0) index = carImages.Count - 1;
//                    if (index >= carImages.Count) index = 0;

//                    currentImageIndex = index;
//                    string imagePath = carImages[currentImageIndex];

//                    if (File.Exists(imagePath))
//                    {
//                        // Avoid file lock by creating a Bitmap copy
//                        using (var tempImg = Image.FromFile(imagePath))
//                        {
//                            pictureBoxCar.Image = new Bitmap(tempImg);
//                        }
//                    }
//                    else
//                    {
//                        pictureBoxCar.BackColor = Color.LightGray;
//                        pictureBoxCar.Image = null;
//                    }
//                }
//                catch (Exception ex)
//                {
//                    pictureBoxCar.BackColor = Color.LightGray;
//                    pictureBoxCar.Image = null;
//                    Console.WriteLine($"Error loading image: {ex.Message}");
//                }
//            }
//        }

//        private void SlideshowTimer_Tick(object sender, EventArgs e)
//        {
//            LoadImage(currentImageIndex + 1);
//        }

//        private void btnNextImage_Click(object sender, EventArgs e)
//        {
//            LoadImage(currentImageIndex + 1);
//        }

//        private void btnPrevImage_Click(object sender, EventArgs e)
//        {
//            LoadImage(currentImageIndex - 1);
//        }


//        private void pictureBoxCar_Click(object sender, EventArgs e)
//        {
//            // Toggle slideshow
//            if (slideshowTimer.Enabled)
//            {
//                slideshowTimer.Stop();
//            }
//            else
//            {
//                slideshowTimer.Start();
//            }
//        }

//        private void PopulateCarDetails()
//        {
//            // Load the first image
//            LoadImage(0);

//            // Set car title
//            labelCarTitle.Text = $"{car.CarBrand} {car.Model} ({car.Year}) for Rent";

//            // Set price
//            labelPrice.Text = $"MUR {car.CarPrice}/day";

//            string description = car.VehicleDescription;
//            string features = car.Features;

//            textBoxDescription.Text = description;
//            featuresDetails.Text = features;
//            transmissionSpec.Text = $"Transmission Type: {car.TransmissionType}";
//            passengersSpec.Text = $"Passengers: {car.SeatNo}";
//            powerSpec.Text = $"Power: {car.Power}";
//            drivetrainSpec.Text = $"Drivetrain: {car.DriveTrain}";
//            ratingCount.Text = $"Rating: {car.Ratings}";


//        }



//        private void btnBookCar_Click(object sender, EventArgs e)
//        {
//            BookingsRepository bookingRepo = new BookingsRepository(new DatabaseConnection());
//            HashTable<string, Booking> bookingHashTable = bookingRepo.LoadBookingsFromDatabase();

//            // Calculate rental days
//            TimeSpan rentalPeriod = dateTimePickerEnd.Value - dateTimePickerStart.Value;
//            int days = (int)Math.Ceiling(rentalPeriod.TotalDays);

//            if (days <= 0)
//            {
//                MessageBox.Show("Please select a valid rental period.", "Invalid Dates",
//                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
//                return;
//            }

//            // Get pickup and dropoff locations
//            string pickupLocation = comboBoxPickup.SelectedItem?.ToString() ?? string.Empty;
//            string dropoffLocation = comboBoxDropoff.SelectedItem?.ToString() ?? string.Empty;

//            bool isAvailable = bookingRepo.IsCarAvailable(car.CarID, dateTimePickerStart.Value, dateTimePickerEnd.Value, bookingHashTable);

//            if (!isAvailable)
//            {
//                MessageBox.Show("This car is already booked for the selected dates.");
//            }
//            else
//            {
//                // Show booking confirmation dialog
//                BookingConfirmationForm confirmationForm = new BookingConfirmationForm(
//                    car,
//                    dateTimePickerStart.Value,
//                    dateTimePickerEnd.Value,
//                    pickupLocation,
//                    dropoffLocation,
//                    checkBoxDriver.Checked,
//                    checkBoxBabyCarSeat.Checked,
//                    checkBoxInsurance.Checked,
//                    checkBoxRoofRack.Checked,
//                    checkBoxAirportPickup.Checked
//                );

//                if (confirmationForm.ShowDialog() == DialogResult.OK)
//                {
//                    // Booking was confirmed - you could save to database here
//                    this.Close();
//                }

//            }



//        }

//        protected override void Dispose(bool disposing)
//        {
//            if (disposing)
//            {
//                // Stop and dispose the timer
//                if (slideshowTimer != null)
//                {
//                    slideshowTimer.Stop();
//                    slideshowTimer.Dispose();
//                }

//                if (components != null)
//                {
//                    components.Dispose();
//                }
//            }
//            base.Dispose(disposing);
//        }


//    }

//}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Horizon_Drive_LTD.BusinessLogic.Repositories;
using Horizon_Drive_LTD.BusinessLogic;
using Horizon_Drive_LTD.DataStructure;
using Horizon_Drive_LTD.Domain.Entities;
using Microsoft.Data.SqlClient;

namespace Horizon_Drive_LTD
{
    public partial class CarBookingForm : Form
    {
        private Cars car;
        private List<string> carImages = new List<string>();
        private int currentImageIndex = 0;
        private System.Windows.Forms.Timer slideshowTimer;
        private Button btnNextImage;
        private Button btnPrevImage;
        private DatabaseConnection _dbConnection = new DatabaseConnection();

        public CarBookingForm(Cars selectedCar)
        {
            InitializeComponent();
            car = selectedCar;

            // Initialize slideshow controls
            InitializeSlideshowControls();

            // Load car images from database
            LoadCarImagesFromDatabase();

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

            slideshowTimer = new System.Windows.Forms.Timer();
            slideshowTimer.Interval = 3000; // 3 seconds
            slideshowTimer.Tick += SlideshowTimer_Tick;
        }

        private void LoadCarImagesFromDatabase()
        {
            carImages.Clear();

            try
            {
                // Get all images for this car from the database
                using (SqlConnection conn = _dbConnection.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT ImagePath FROM CarImages WHERE CarId = @CarId";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@CarId", car.CarID);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string relativePath = reader["ImagePath"].ToString();
                                string projectRoot = Path.GetFullPath(Path.Combine(Application.StartupPath, @"..\..\.."));
                                string fullPath = Path.Combine(projectRoot, relativePath.Replace("/", "\\"));

                                if (File.Exists(fullPath))
                                {
                                    carImages.Add(fullPath);
                                }
                            }
                        }
                    }
                }

                if (carImages.Count == 0)
                {
                    // Fallback to default image if no images found
                    pictureBoxCar.Image = Properties.Resources.Logo;
                    MessageBox.Show("No images found for this car.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    LoadImage(0); // Load the first image
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading car images: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                pictureBoxCar.Image = Properties.Resources.Logo;
            }
        }

        private void LoadImage(int index)
        {
            if (carImages.Count > 0)
            {
                try
                {
                    // Loop the index around
                    if (index < 0) index = carImages.Count - 1;
                    if (index >= carImages.Count) index = 0;

                    currentImageIndex = index;
                    string imagePath = carImages[currentImageIndex];

                    if (File.Exists(imagePath))
                    {
                        // Avoid file lock by creating a Bitmap copy
                        using (var tempImg = Image.FromFile(imagePath))
                        {
                            pictureBoxCar.Image = new Bitmap(tempImg);
                        }
                    }
                    else
                    {
                        pictureBoxCar.Image = Properties.Resources.Logo;
                    }
                }
                catch (Exception ex)
                {
                    pictureBoxCar.Image = Properties.Resources.Logo;
                    Console.WriteLine($"Error loading image: {ex.Message}");
                }
            }
        }

        private void SlideshowTimer_Tick(object sender, EventArgs e)
        {
            LoadImage(currentImageIndex + 1);
        }

        private void btnNextImage_Click(object sender, EventArgs e)
        {
            LoadImage(currentImageIndex + 1);
        }

        private void btnPrevImage_Click(object sender, EventArgs e)
        {
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
            // Set car title
            labelCarTitle.Text = $"{car.CarBrand} {car.Model} ({car.Year}) for Rent";

            // Set price
            labelPrice.Text = $"MUR {car.CarPrice}/day";

            string description = car.VehicleDescription;
            string features = car.Features;

            textBoxDescription.Text = description;
            featuresDetails.Text = features;
            transmissionSpec.Text = $"Transmission Type: {car.TransmissionType}";
            passengersSpec.Text = $"Passengers: {car.SeatNo}";
            powerSpec.Text = $"Power: {car.Power}";
            drivetrainSpec.Text = $"Drivetrain: {car.DriveTrain}";
            ratingCount.Text = $"Rating: {car.Ratings}";
        }

        private void btnBookCar_Click(object sender, EventArgs e)
        {
            BookingsRepository bookingRepo = new BookingsRepository(new DatabaseConnection());
            HashTable<string, Booking> bookingHashTable = bookingRepo.LoadBookingsFromDatabase();

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

            bool isAvailable = bookingRepo.IsCarAvailable(car.CarID, dateTimePickerStart.Value, dateTimePickerEnd.Value, bookingHashTable);

            if (!isAvailable)
            {
                MessageBox.Show("This car is already booked for the selected dates.");
            }
            else
            {
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
                    this.Close();
                }
            }
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
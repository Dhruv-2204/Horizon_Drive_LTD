using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Horizon_Drive_LTD
{
    public partial class BrowseListings : Form
    {
        // List to store car listings
        private List<CarListing> carListings = new List<CarListing>();

        public BrowseListings()
        {
            InitializeComponent();
            this.Size = new Size(1600, 900);

            // Load the logo from the project Pictures folder
            try
            {
                string projectDirectory = Path.GetDirectoryName(Application.ExecutablePath);
                // Go up three levels from bin\Debug\net9.0-windows to the project root
                string rootDirectory = Directory.GetParent(Directory.GetParent(Directory.GetParent(projectDirectory).FullName).FullName).FullName;
                string logoPath = Path.Combine(rootDirectory, "Pictures", "Logo.png");

                pictureBoxLogo.Image = Image.FromFile(logoPath);
            }
            catch (Exception ex)
            {
                // Handle error if image can't be loaded
                MessageBox.Show("Could not load logo: " + ex.Message);
            }

            LoadCarListings();
            PopulateCarListings();
        }

        private void LoadCarListings()
        {
            // Sample car data - in a real app, this would come from a database
            carListings.Add(new CarListing
            {
                Id = 1,
                Make = "Ford",
                Model = "Raptor",
                Year = 2023,
                Description = "A powerful off-road pickup built for performance and adventure. Rent now for a rugged and thrilling ride!",
                PricePerDay = 15000,
                ImagePath = "ford_raptor.jpg"
            });

            carListings.Add(new CarListing
            {
                Id = 2,
                Make = "BMW",
                Model = "X4",
                Year = 2023,
                Description = "A luxury high-performance SUV with bold design and powerful hybrid technology. Rent now for an elite driving experience!",
                PricePerDay = 30000,
                ImagePath = "bmw_x4.jpg"
            });

            carListings.Add(new CarListing
            {
                Id = 3,
                Make = "Corvette",
                Model = "C8",
                Year = 2023,
                Description = "A sleek, mid-engine sports car with thrilling performance and sharp handling. Rent now for an unforgettable drive!",
                PricePerDay = 20000,
                ImagePath = "corvette_c8.jpg"
            });

            carListings.Add(new CarListing
            {
                Id = 4,
                Make = "Ford",
                Model = "Mustang",
                Year = 2023,
                Description = "A modern muscle car with bold design and powerful performance. Rent now for an exhilarating ride!",
                PricePerDay = 25000,
                ImagePath = "ford_mustang.jpg"
            });

            // Add more cars for the bottom row
            carListings.Add(new CarListing
            {
                Id = 5,
                Make = "Mercedes",
                Model = "AMG",
                Year = 2023,
                Description = "Performance luxury at its finest with distinctive styling and remarkable power.",
                PricePerDay = 28000,
                ImagePath = "mercedes_amg.jpg"
            });

            carListings.Add(new CarListing
            {
                Id = 6,
                Make = "Honda",
                Model = "Civic",
                Year = 2022,
                Description = "Reliable, efficient and perfect for city driving with excellent fuel economy.",
                PricePerDay = 8000,
                ImagePath = "honda_civic.jpg"
            });

            carListings.Add(new CarListing
            {
                Id = 7,
                Make = "Mercedes",
                Model = "GLE Coupe",
                Year = 2023,
                Description = "Elegance meets performance in this luxury SUV coupe with cutting-edge technology.",
                PricePerDay = 32000,
                ImagePath = "mercedes_gle.jpg"
            });

            carListings.Add(new CarListing
            {
                Id = 8,
                Make = "Mercedes",
                Model = "AMG GT",
                Year = 2023,
                Description = "The pinnacle of Mercedes performance with breathtaking design and power.",
                PricePerDay = 35000,
                ImagePath = "mercedes_amg_gt.jpg"
            });
        }

        private void PopulateCarListings()
        {
            // Clear the flowLayoutPanel first
            flowLayoutPanelListings.Controls.Clear();

            // Add car listing panels to the flow layout panel
            foreach (var car in carListings)
            {
                // Create a car listing panel
                Panel carPanel = CreateCarListingPanel(car);
                flowLayoutPanelListings.Controls.Add(carPanel);
            }
        }

        private Panel CreateCarListingPanel(CarListing car)
        {
            // Main panel
            Panel panel = new Panel();
            panel.Size = new Size(250, 310);
            panel.BorderStyle = BorderStyle.FixedSingle;
            panel.Margin = new Padding(10);
            panel.BackColor = Color.White;

            // Car image
            PictureBox pictureBox = new PictureBox();
            pictureBox.Size = new Size(230, 150);
            pictureBox.Location = new Point(10, 10);
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            try
            {
                pictureBox.Image = Image.FromFile(Path.Combine("Images", car.ImagePath));
            }
            catch
            {
                // Use placeholder if image not found
                pictureBox.BackColor = Color.LightGray;
            }

            // Car title (Make and Model)
            Label lblTitle = new Label();
            lblTitle.AutoSize = false;
            lblTitle.Size = new Size(230, 20);
            lblTitle.Location = new Point(10, 170);
            lblTitle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            lblTitle.Text = $"{car.Make} {car.Model} - {car.Year}";

            // Car description
            Label lblDescription = new Label();
            lblDescription.AutoSize = false;
            lblDescription.Size = new Size(230, 60);
            lblDescription.Location = new Point(10, 190);
            lblDescription.Font = new Font("Segoe UI", 8);
            lblDescription.Text = car.Description;

            // Price label
            Label lblPrice = new Label();
            lblPrice.AutoSize = false;
            lblPrice.Size = new Size(100, 20);
            lblPrice.Location = new Point(10, 255);
            lblPrice.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            lblPrice.Text = $"Rs {car.PricePerDay}/day";

            // View deal button
            Button btnViewDeal = new Button();
            btnViewDeal.Size = new Size(80, 30);
            btnViewDeal.Location = new Point(160, 250);
            btnViewDeal.Text = "View Deal";
            btnViewDeal.BackColor = Color.FromArgb(30, 85, 110);
            btnViewDeal.ForeColor = Color.White;
            btnViewDeal.FlatStyle = FlatStyle.Flat;
            btnViewDeal.Tag = car.Id;
            btnViewDeal.Click += BtnViewDeal_Click;

            // Add controls to panel
            panel.Controls.Add(pictureBox);
            panel.Controls.Add(lblTitle);
            panel.Controls.Add(lblDescription);
            panel.Controls.Add(lblPrice);
            panel.Controls.Add(btnViewDeal);

            return panel;
        }

        private void BtnViewDeal_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int carId = (int)btn.Tag;

            // Find the car
            CarListing selectedCar = carListings.FirstOrDefault(c => c.Id == carId);

            if (selectedCar != null)
            {
                // Open the booking form or show details
                MessageBox.Show($"You selected: {selectedCar.Make} {selectedCar.Model}\n" +
                               $"Price: Rs {selectedCar.PricePerDay}/day",
                               "View Deal",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Information);

                // In a real application, you would open a booking form here
                // BookingForm bookingForm = new BookingForm(selectedCar);
                // bookingForm.ShowDialog();
            }
        }

        private void btnBrowseListings_Click(object sender, EventArgs e)
        {
            // Already on the listings page, could refresh or apply filters
            PopulateCarListings();
        }

        private void btnListCar_Click(object sender, EventArgs e)
        {
            // Open form to list a new car
            MessageBox.Show("List a Car functionality would open a form to add a new listing.",
                           "List a Car",
                           MessageBoxButtons.OK,
                           MessageBoxIcon.Information);

            // In a real application, you would open a form here
            // ListCarForm listCarForm = new ListCarForm();
            // if (listCarForm.ShowDialog() == DialogResult.OK)
            // {
            //     LoadCarListings();
            //     PopulateCarListings();
            // }
        }

        private void btnManageBooking_Click(object sender, EventArgs e)
        {
            // Open form to manage bookings
            MessageBox.Show("Manage Booking functionality would open a form to view and manage bookings.",
                           "Manage Bookings",
                           MessageBoxButtons.OK,
                           MessageBoxIcon.Information);

            // In a real application, you would open a form here
            // ManageBookingsForm manageBookingsForm = new ManageBookingsForm();
            // manageBookingsForm.ShowDialog();
        }

        private void btnOptions_Click(object sender, EventArgs e)
        {
            // Open options/settings
            MessageBox.Show("Options functionality would open settings for the application.",
                           "Options",
                           MessageBoxButtons.OK,
                           MessageBoxIcon.Information);

            // In a real application, you would open a form here
            // OptionsForm optionsForm = new OptionsForm();
            // optionsForm.ShowDialog();
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            // Filter cars based on search text
            string searchText = textBoxSearch.Text.ToLower();

            if (string.IsNullOrWhiteSpace(searchText))
            {
                PopulateCarListings(); // Show all if search is empty
                return;
            }

            var filteredCars = carListings.Where(c =>
                c.Make.ToLower().Contains(searchText) ||
                c.Model.ToLower().Contains(searchText) ||
                c.Description.ToLower().Contains(searchText)).ToList();

            // Clear and repopulate with filtered results
            flowLayoutPanelListings.Controls.Clear();
            foreach (var car in filteredCars)
            {
                Panel carPanel = CreateCarListingPanel(car);
                flowLayoutPanelListings.Controls.Add(carPanel);
            }
        }
    }

    public class CarListing
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Description { get; set; }
        public decimal PricePerDay { get; set; }
        public string ImagePath { get; set; }
    }
}
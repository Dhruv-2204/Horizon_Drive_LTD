using System.Data;
using System.Drawing.Drawing2D;

//BrowseListings.cs

namespace Horizon_Drive_LTD
{
    public partial class BrowseListings : Form
    {
        // List to store car listings
        private List<CarListing> carListings = new List<CarListing>();

        public BrowseListings()
        {
            InitializeComponent();
            this.ClientSize = new Size(1600, 900);
            this.MinimumSize = new Size(1000, 700);


            // Display the username
            DisplayUsername();

            LoadCarListings();
            PopulateCarListings();
        }

        // Method to fetch and display username
        private void DisplayUsername()
        {
            string username = GetLoggedInUsername();

            if (string.IsNullOrEmpty(username))
            {
                labelUsername.Text = "User not logged in";
                // style the label differently (RED) for non-logged in users
                labelUsername.ForeColor = Color.Red;
            }
            else
            {
                labelUsername.Text = username;
                labelUsername.ForeColor = Color.FromArgb(15, 30, 45); // Colour of logged in users
            }
        }

        // Method to get the username from your database
        private string GetLoggedInUsername()
        {
            // Replace this with database fetch logic
            
            return null;
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
                ImagePath = "Fordraptor.jpg",
                AdditionalImages = new List<string>
        {
            "Fordraptor1.jpg",
            "Fordraptor2.jpg",
            "Fordraptor3.jpg"
        }
            });

            carListings.Add(new CarListing
            {
                Id = 2,
                Make = "BMW",
                Model = "X4",
                Year = 2023,
                Description = "A luxury high-performance SUV with bold design and powerful hybrid technology. Rent now for an elite driving experience!",
                PricePerDay = 30000,
                ImagePath = "bmw_x4.jpg",
                AdditionalImages = new List<string>
        {
            "bmw_x4_1.jpg",
            "bmw_x4_2.jpg",
            "bmw_x4_3.jpg"
        }
            });

            carListings.Add(new CarListing
            {
                Id = 3,
                Make = "Corvette",
                Model = "C8",
                Year = 2023,
                Description = "A sleek, mid-engine sports car with thrilling performance and sharp handling. Rent now for an unforgettable drive!",
                PricePerDay = 20000,
                ImagePath = "corvette_c8.jpg",
                AdditionalImages = new List<string>
        {
            "corvette_c8_1.jpg",
            "corvette_c8_2.jpg",
            "corvette_c8_3.jpg"
        }
            });

            carListings.Add(new CarListing
            {
                Id = 4,
                Make = "Ford",
                Model = "Mustang",
                Year = 2023,
                Description = "A modern muscle car with bold design and powerful performance. Rent now for an exhilarating ride!",
                PricePerDay = 25000,
                ImagePath = "ford_mustang.jpg",
                AdditionalImages = new List<string>
        {
            "ford_mustang_1.jpg",
            "ford_mustang_2.jpg",
            "ford_mustang_3.jpg"
        }
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
                ImagePath = "mercedes_amg.jpg",
                AdditionalImages = new List<string>
        {
            "mercedes_amg_1.jpg",
            "mercedes_amg_2.jpg",
            "mercedes_amg_3.jpg"
        }
            });

            carListings.Add(new CarListing
            {
                Id = 6,
                Make = "Honda",
                Model = "Civic",
                Year = 2022,
                Description = "Reliable, efficient and perfect for city driving with excellent fuel economy.",
                PricePerDay = 8000,
                ImagePath = "honda_civic.jpg",
                AdditionalImages = new List<string>
        {
            "honda_civic_1.jpg",
            "honda_civic_2.jpg",
            "honda_civic_3.jpg"
        }
            });

            carListings.Add(new CarListing
            {
                Id = 7,
                Make = "Mercedes",
                Model = "GLE Coupe",
                Year = 2023,
                Description = "Elegance meets performance in this luxury SUV coupe with cutting-edge technology.",
                PricePerDay = 32000,
                ImagePath = "mercedes_gle.jpg",
                AdditionalImages = new List<string>
        {
            "mercedes_gle_1.jpg",
            "mercedes_gle_2.jpg",
            "mercedes_gle_3.jpg"
        }
            });

            carListings.Add(new CarListing
            {
                Id = 8,
                Make = "Mercedes",
                Model = "AMG GT",
                Year = 2023,
                Description = "The pinnacle of Mercedes performance with breathtaking design and power.",
                PricePerDay = 35000,
                ImagePath = "mercedes_amg_gt.jpg",
                AdditionalImages = new List<string>
        {
            "mercedes_amg_gt_1.jpg",
            "mercedes_amg_gt_2.jpg",
            "mercedes_amg_gt_3.jpg"
        }
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
                // Open the booking form
                CarBookingForm bookingForm = new CarBookingForm(selectedCar);
                bookingForm.ShowDialog();
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
            ListCarForm listCarForm = new ListCarForm();
            listCarForm.Show();
            this.Hide();
        }

        private void btnManageYourListings_Click(object sender, EventArgs e)
        {
            // Open form to manage user's listings
            MessageBox.Show("Manage Your Listings functionality would open a form to view and manage your car listings.",
                           "Manage Your Listings",
                           MessageBoxButtons.OK,
                           MessageBoxIcon.Information);

            // In a real application, you would open a form here
            // ManageYourListingsForm manageYourListingsForm = new ManageYourListingsForm();
            // manageYourListingsForm.ShowDialog();
        }

        private void btnManageBooking_Click(object sender, EventArgs e)
        {
            // Open the Manage Bookings form
            ManageBookings manageBookingsForm = new ManageBookings();
            manageBookingsForm.Show();
            this.Hide();
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
        private void btnLogout_Click(object sender, EventArgs e)
        {
            // Log out functionality
            DialogResult result = MessageBox.Show("Are you sure you want to log out?",
                           "Log Out",
                           MessageBoxButtons.YesNo,
                           MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // In a real application, you would handle logout here
                // Example: Reset authentication state, close the form, show login form
                MessageBox.Show("You have been logged out successfully.",
                               "Log Out",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Information);

                // After logout, update the username display
                DisplayUsername();

                // Application.Restart(); // Uncomment to restart application
                // this.Close(); // Uncomment to close current form
            }
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

        private void pictureBoxLogo_Click(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanelListings_Paint(object sender, PaintEventArgs e)
        {

        }

        private void buttonFilter_Click(object sender, EventArgs e)
        {
            // Filter functionality
            MessageBox.Show("Filter functionality would open filter options for car listings.",
                           "Filter Cars",
                           MessageBoxButtons.OK,
                           MessageBoxIcon.Information);
        }

        private void buttonCart_Click(object sender, EventArgs e)
        {
            // Shopping cart functionality
            MessageBox.Show("Shopping cart functionality would display selected cars and reservation details.",
                           "Shopping Cart",
                           MessageBoxButtons.OK,
                           MessageBoxIcon.Information);
        }

        private void buttonProfile_Click(object sender, EventArgs e)
        {
            // Open the Options_Personal form
            Options_Personal optionsPersonalForm = new Options_Personal();
            optionsPersonalForm.Show();
            this.Hide();
        }

        private void labelBrowseListings_Click(object sender, EventArgs e)
        {

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
    public List<string> AdditionalImages { get; set; } = new List<string>();
}
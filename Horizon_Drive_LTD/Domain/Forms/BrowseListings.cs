using System.Data;
using Horizon_Drive_LTD.BusinessLogic.Repositories;
using Horizon_Drive_LTD.BusinessLogic;
using Horizon_Drive_LTD.Domain.Entities;
using Horizon_Drive_LTD.DataStructure;
using Microsoft.Data.SqlClient;
using Horizon_Drive_LTD.BusinessLogic.Services;
using System.Diagnostics;
using splashscreen;

//BrowseListings.cs

namespace Horizon_Drive_LTD
{

    
    public partial class BrowseListings : Form
    {

        private bool isClosing = false;
        DatabaseConnection _dbConnection = new DatabaseConnection();


        private HashTable<string, Cars> carHashTable;

        //  Constructor
        public BrowseListings()
        {
            InitializeComponent();
            this.ClientSize = new Size(1600, 900);
            this.MinimumSize = new Size(1000, 700);


            LoadCarListings();
            PopulateCarListings();
            DisplayUsername();

        }

        // Method to load car listings from the database
        private void LoadCarListings()
        {
            DatabaseConnection dbConnection = new DatabaseConnection();
            CarRepository carRepo = new CarRepository(dbConnection);

            carHashTable = carRepo.LoadCarsFromDatabase();


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
            using (SqlConnection conn = _dbConnection.GetConnection())
            {
                conn.Open();
                string query = "SELECT UserName FROM ActiveUser";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    var result = cmd.ExecuteScalar();
                    return result?.ToString();
                }
            }
        }

        //  Method to populate car listings in the UI
        private void PopulateCarListings()
        {
            flowLayoutPanelListings.Controls.Clear();

            foreach (var carEntry in carHashTable.GetAllItems())
            {
                Panel carPanel = CreateCarListingPanel(carEntry.Value);
                flowLayoutPanelListings.Controls.Add(carPanel);
            }
        }


        // Method to create a panel for each car listing
        private Panel CreateCarListingPanel(Cars car)
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
                // Get the directory where images are stored for this car
                string projectRoot = Path.GetFullPath(Path.Combine(Application.StartupPath, @"..\..\.."));
                //string carImageDir = Path.Combine(projectRoot, "Media", "Images", "CarTable", car.CarBrand, car.CarID);

                string carImageDir = Path.Combine(projectRoot, "Media", "Images", car.CarBrand, car.CarID);


                // Get all image files in the directory
                var imageFiles = Directory.GetFiles(carImageDir)
                    .Where(f => f.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) ||
                                f.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase) ||
                                f.EndsWith(".png", StringComparison.OrdinalIgnoreCase) ||
                                f.EndsWith(".bmp", StringComparison.OrdinalIgnoreCase))
                    .ToList();

                if (imageFiles.Any())
                {
                    pictureBox.Image = Image.FromFile(imageFiles.First());
                }
                else
                {
                    pictureBox.Image = Properties.Resources.Logo;
                }
            }
            catch (Exception ex)
            {
                pictureBox.Image = Properties.Resources.Logo;
                Debug.WriteLine($"Image load error: {ex.Message}");
            }


            panel.Controls.Add(pictureBox);

            // Car title (Make and Model)
            Label lblTitle = new Label();
            lblTitle.AutoSize = false;
            lblTitle.Size = new Size(230, 20);
            lblTitle.Location = new Point(10, 170);
            lblTitle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            lblTitle.Text = $"{car.CarBrand} {car.Model} - {car.Year}";

            // Car description
            Label lblDescription = new Label();
            lblDescription.AutoSize = false;
            lblDescription.Size = new Size(230, 60);
            lblDescription.Location = new Point(10, 200);
            lblDescription.Font = new Font("Segoe UI", 8);
            lblDescription.Text = car.VehicleDescription;

            // Price label
            Label lblPrice = new Label();
            lblPrice.AutoSize = false;
            lblPrice.Size = new Size(100, 20);
            lblPrice.Location = new Point(10, 255);
            lblPrice.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            lblPrice.Text = $"Rs{car.CarPrice}";


            // View deal button
            Button btnViewDeal = new Button();
            btnViewDeal.Size = new Size(80, 30);
            btnViewDeal.Location = new Point(160, 250);
            btnViewDeal.Text = "View Deal";
            btnViewDeal.BackColor = Color.FromArgb(30, 85, 110);
            btnViewDeal.ForeColor = Color.White;
            btnViewDeal.FlatStyle = FlatStyle.Flat;
            btnViewDeal.Tag = car.CarID;
            btnViewDeal.Click += BtnViewDeal_Click;

            // Add controls to panel

            panel.Controls.Add(lblTitle);
            panel.Controls.Add(lblDescription);
            panel.Controls.Add(lblPrice);
            panel.Controls.Add(btnViewDeal);

            return panel;

        }

        // Event handler for the "View Deal" button
        private void BtnViewDeal_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string carId = btn.Tag.ToString(); // Make sure the Tag stores the CarID (e.g., "C00001")

            // Retrieve the car from the hash table
            Cars selectedCar = carHashTable.Search(carId);

            if (selectedCar != null)
            {
                // Open the booking form with the selected car
                CarBookingForm bookingForm = new CarBookingForm(selectedCar);
                bookingForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Car details could not be found.");
            }
        }

        // Event handler for the "Browse Listings" button
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
            this.Dispose();
        }

        private void btnManageYourListings_Click(object sender, EventArgs e)
        {
            // Open form to manage user's listings

            ManageYourListings manageYourListingsForm = new ManageYourListings();

            manageYourListingsForm.Show();

            this.Dispose();

        }

        private void btnManageBooking_Click(object sender, EventArgs e)
        {
            // Open the Manage Bookings form
            ManageBookings manageBookingsForm = new ManageBookings();
            manageBookingsForm.Show();
            this.Dispose();
        }

        private void btnOptions_Click(object sender, EventArgs e)
        {
            // Open options/settings

            Options_Personal optionsForm = new Options_Personal();
            optionsForm.Show();
            this.Dispose();

        }

        // Event handler for the "Log Out" button
        private void btnLogout_Click(object sender, EventArgs e)
        {
            // Log out functionality
            DialogResult result = MessageBox.Show("Are you sure you want to log out?",
                           "Log Out",
                           MessageBoxButtons.YesNo,
                           MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {

                MessageBox.Show("You have been logged out successfully.",
                               "Log Out",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Information);
                // Clear the active user session
                using (SqlConnection conn = _dbConnection.GetConnection())
                {
                    conn.Open();
                    string dropTableQuery = "DROP TABLE IF EXISTS ActiveUser;";
                    using (SqlCommand cmd = new SqlCommand(dropTableQuery, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
                

                // how to stop running the code
                OpenLoginUp();


            }
            else
            {
                // User chose not to log out
                return;
            }
        }

        // Method to open the login form
        private void OpenLoginUp()
        {

            var userRepo = new UserRepository(new DatabaseConnection());
            var userHashTable = userRepo.LoadUsersIntoHashTable();
            var authService = new AuthenticationService(userHashTable, userRepo);
            //var dbConnection = new DatabaseConnection();

            // Show the Login form with injected authService
            Login loginForm = new Login(authService);
            loginForm.Show();

            this.Dispose();
        }

        // Event handler for the search text box
        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = textBoxSearch.Text.ToLower();
            flowLayoutPanelListings.Controls.Clear();

            IEnumerable<KeyValuePair<string, Cars>> allCars = carHashTable.GetAllItems();

            foreach (var carEntry in allCars)
            {
                Cars car = carEntry.Value;

                if (string.IsNullOrWhiteSpace(searchText) ||
                    car.CarBrand.ToLower().Contains(searchText) ||
                    car.Model.ToLower().Contains(searchText) ||
                    car.Category.ToLower().Contains(searchText))
                {
                    Panel carPanel = CreateCarListingPanel(car);
                    flowLayoutPanelListings.Controls.Add(carPanel);
                }
            }
        }


        // Event handler for the "Profile" button
        private void buttonProfile_Click(object sender, EventArgs e)
        {


            Options_Personal optionsForm = new Options_Personal();
            optionsForm.Show();
            this.Dispose();

        }

        // Event handler for the "Home" button
        private void Form2_Load(object sender, EventArgs e)
        {
            this.FormClosing += new FormClosingEventHandler(MyForm_FormClosing);
        }

        // Event handler for the form closing event
        private void MyForm_FormClosing(object? sender, FormClosingEventArgs e)
        {
            if (isClosing) return;
            isClosing = true;

            DialogResult result = MessageBox.Show("Do you want to close the Car Hire Application?", "Confirm Exit",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                e.Cancel = true; // Prevent closing
                isClosing = false;
            }
            else
            {
                using (SqlConnection conn = _dbConnection.GetConnection())
                {
                    conn.Open();
                    string dropTableQuery = "DROP TABLE IF EXISTS ActiveUser;";
                    using (SqlCommand cmd = new SqlCommand(dropTableQuery, conn))
                                           cmd.ExecuteNonQuery();
 {
                    }
                }

                Application.Exit(); // Properly terminates the application without triggering FormClosing again
            }
        }

        private void BrowseListings_Load(object sender, EventArgs e)
        {
            this.FormClosing += new FormClosingEventHandler(MyForm_FormClosing);
        }

        private void btnBrowseListings_Click_1(object sender, EventArgs e)
        {
            BrowseListings browseListings = new BrowseListings();
            browseListings.ShowDialog();
            this.Dispose();

            // Hide the current form (Browse Listings form)

        }
    }


}




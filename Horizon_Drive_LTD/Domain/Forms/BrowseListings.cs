
using System.Data;
using System.Drawing.Drawing2D;
using Horizon_Drive_LTD.BusinessLogic.Repositories;
using Horizon_Drive_LTD.BusinessLogic;
using Horizon_Drive_LTD.Domain.Entities;
using Horizon_Drive_LTD.DataStructure;

using Microsoft.Data.SqlClient;


//BrowseListings.cs

namespace Horizon_Drive_LTD
{

    public partial class BrowseListings : Form
    {

        private bool isClosing = false;
        DatabaseConnection _dbConnection = new DatabaseConnection();

        private HashTable<string, Cars> carHashTable;

        public BrowseListings()
        {
            InitializeComponent();
            this.ClientSize = new Size(1600, 900);
            this.MinimumSize = new Size(1000, 700);

            LoadCarListings();
            PopulateCarListings();

        }


        private void LoadCarListings()
        {
            DatabaseConnection dbConnection = new DatabaseConnection();
            CarRepository carRepo = new CarRepository(dbConnection);

            carHashTable = carRepo.LoadCarsFromDatabase();

          
        }

        private void PopulateCarListings()
        {
            flowLayoutPanelListings.Controls.Clear();

            foreach (var carEntry in carHashTable.GetAllItems())
            {
                Panel carPanel = CreateCarListingPanel(carEntry.Value);
                flowLayoutPanelListings.Controls.Add(carPanel);
            }
        }



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

                string brand = car.CarBrand.Replace(" ", "");
                string model = car.Model.Replace(" ", "");
                // Navigate to the specific folder for the car
                string carFolder = Path.Combine(Application.StartupPath, "Images", "BrowseListings", $"{brand}_{model}");

                // Make sure the folder exists
                if (Directory.Exists(carFolder))
                {
                    // Get all valid image files inside the folder
                    string[] matchingFiles = Directory.GetFiles(carFolder, "*.*")
                        .Where(file => file.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase)
                                    || file.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase)
                                    || file.EndsWith(".png", StringComparison.OrdinalIgnoreCase)
                                    || file.EndsWith(".bmp", StringComparison.OrdinalIgnoreCase))
                        .ToArray();

                    if (matchingFiles.Length > 0)
                    {
                        pictureBox.Image = Image.FromFile(matchingFiles[0]);
                    }
                    else
                    {
                        pictureBox.BackColor = Color.LightGray;
                        MessageBox.Show("No images found in folder: " + carFolder);
                    }
                }
                else
                {
                    pictureBox.BackColor = Color.LightGray;
                    MessageBox.Show("Folder not found: " + carFolder);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Image load error: " + ex.Message);
                pictureBox.BackColor = Color.LightGray;
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


            ManageYourListings manageYourListingsForm = new ManageYourListings();
         
            manageYourListingsForm.Show();

            this.Hide();

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
                MessageBox.Show("You have been logged out successfully.",
                               "Log Out",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Information);

            }
        }


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


        private void buttonProfile_Click(object sender, EventArgs e)
        {
            // Profile functionality
            MessageBox.Show("Profile functionality would display user information and settings.",
                           "User Profile",
                           MessageBoxButtons.OK,
                           MessageBoxIcon.Information);
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.FormClosing += new FormClosingEventHandler(MyForm_FormClosing);
        }
        private void MyForm_FormClosing(object sender, FormClosingEventArgs e)
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
                    {
                        cmd.ExecuteNonQuery();
                    }
                }

                Application.Exit(); // Properly terminates the application without triggering FormClosing again
            }
        }


    }


}




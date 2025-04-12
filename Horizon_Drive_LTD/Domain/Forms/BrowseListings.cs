
using System.Data;
using System.Drawing.Drawing2D;
using Horizon_Drive_LTD.BusinessLogic.Repositories;
using Horizon_Drive_LTD.BusinessLogic;
using Horizon_Drive_LTD.Domain.Entities;
using Horizon_Drive_LTD.DataStructure;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml;
using System.Web;
using System.Windows.Forms;

//BrowseListings.cs

namespace Horizon_Drive_LTD
{
    public partial class BrowseListings : Form
    {
     
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

            foreach (var kvp in carHashTable.GetAllItems())
            {
                Cars car = kvp.Value;

                Panel carPanel = CreateCarListingPanel(car); 
                flowLayoutPanelListings.Controls.Add(carPanel);
            }
        }

        private async void LoadImageFromAPI(string brand, string model, PictureBox pictureBox)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string query = $"{brand} {model}";
                    string requestUrl = $"http://www.carimagery.com/api.asmx/GetImageUrl?searchTerm={Uri.EscapeDataString(query)}";

                    Console.WriteLine($"Requesting image URL for: {query}");

                    HttpResponseMessage response = await client.GetAsync(requestUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string xmlContent = await response.Content.ReadAsStringAsync();
                        string imageUrl = ExtractImageUrlFromXml(xmlContent);

                        Console.WriteLine($"Image URL: {imageUrl}");

                        if (!string.IsNullOrEmpty(imageUrl))
                        {
                            pictureBox.LoadAsync(imageUrl);
                        }
                        else
                        {
                            Console.WriteLine("No image URL found");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Failed to fetch image for {brand} {model}. Status Code: {response.StatusCode}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error loading image: {ex.Message}");
                }
            }
        }

        private string ExtractImageUrlFromXml(string xml)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xml);
                return doc.InnerText;
            }
            catch
            {
                return null;
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
                LoadImageFromAPI(car.CarBrand, car.Model, pictureBox); ;
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
            lblTitle.Text = $"{car.CarBrand} {car.Model} - {car.Year}";

            // Car description
            Label lblDescription = new Label();
            lblDescription.AutoSize = false;
            lblDescription.Size = new Size(230, 60);
            lblDescription.Location = new Point(10, 190);
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
        /*
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
        */

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

                // Application.Restart(); // Uncomment to restart application
                // this.Close(); // Uncomment to close current form
            }
        }

        /*
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
        */

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
            // Profile functionality
            MessageBox.Show("Profile functionality would display user information and settings.",
                           "User Profile",
                           MessageBoxButtons.OK,
                           MessageBoxIcon.Information);
        }

        private void labelBrowseListings_Click(object sender, EventArgs e)
        {

        }
    }

    /*
    public class RoundedButton : Button
    {
        private int borderRadius = 26;

        public RoundedButton()
        {
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            // Enable anti-aliasing for smooth edges
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            GraphicsPath path = new GraphicsPath();
            Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);

            // Create rounded rectangle with the specified corner radius
            int diameter = borderRadius * 2;
            path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90);
            path.AddArc(rect.Width - diameter, rect.Y, diameter, diameter, 270, 90);
            path.AddArc(rect.Width - diameter, rect.Height - diameter, diameter, diameter, 0, 90);
            path.AddArc(rect.X, rect.Height - diameter, diameter, diameter, 90, 90);
            path.CloseAllFigures();

            // Set the button's region to our rounded rectangle
            this.Region = new Region(path);

            // Draw the button
            base.OnPaint(e);
        }



    }
    */
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

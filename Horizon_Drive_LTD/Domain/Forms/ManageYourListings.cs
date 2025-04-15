using System.Data;
using System.Diagnostics;
using System.Globalization;
using Horizon_Drive_LTD.BusinessLogic;
using Horizon_Drive_LTD.BusinessLogic.Repositories;
using Horizon_Drive_LTD.DataStructure;
using Horizon_Drive_LTD.Domain.Entities;
using Microsoft.Data.SqlClient;


namespace Horizon_Drive_LTD
{
    
    public partial class ManageYourListings : Form
    {

        /// Flag to prevent multiple closing messages
        private bool isClosing = false;

        DatabaseConnection _dbConnection = new DatabaseConnection();
        private HashTable<string, Cars> carHashTable;
       

        public ManageYourListings()
        {
            InitializeComponent();

            // Set client size and minimum size
            this.ClientSize = new Size(1600, 900);
            this.MinimumSize = new Size(1000, 700);

            string userId = CurrentUser.CurrentUserId;

            // Load data dynamically
            LoadCarListingsFromDatabase();

            // Initially hide the "no more cars" label since we'll show it conditionally
            labelNoMoreListings.Visible = false;

        }

        // Method to load car listings into the car hash table
        private void LoadCarListingsFromDatabase()
        {
            // Clear existing dynamic car listing panels
            panelContent.Controls.Clear();

            
            CarRepository carRepo = new CarRepository(new DatabaseConnection());
            carHashTable = carRepo.LoadCarsFromDatabase();

            BookingsRepository bookingsRepo = new BookingsRepository(new DatabaseConnection());

            string currentUserId = CurrentUser.CurrentUserId;
            // Get the current user's active reservations
            int currentReservations = bookingsRepo.GetActiveReservationCountForUser(currentUserId);

            // Set the reservation count label
            lblReservationsCount.Text = currentReservations.ToString();


            // get the current user id
            string userid = CurrentUser.CurrentUserId;

            int verticalPosition = 31;
            int listingsCount = 0;

            // look for the current userid in the car hash table to get all the car they own
            foreach (var kvp in carHashTable.GetAllItems())
            {
                Cars car = kvp.Value;

                if (car.UserID == userid)
                {
                    Panel carPanel = CreateCarListingPanelFromCar(car, verticalPosition);
                    panelContent.Controls.Add(carPanel);
                    verticalPosition += carPanel.Height + 10;

                    listingsCount++;
                   
                }
            }

            // Show "no more listings" message
            if (listingsCount == 0)
            {
                labelNoMoreListings.Location = new Point(27, verticalPosition);
                labelNoMoreListings.Visible = true;
            }
            else
            {
                labelNoMoreListings.Visible = false;
            }

            labelTransactionHistory.Location = new Point(27, verticalPosition + 20);
            lblListingsCount.Text = listingsCount.ToString();

            int transactionStartY = verticalPosition + 40;
            LoadTransactionsFromDatabase(transactionStartY);
            
        }
       

        // Method to create a car listing panel
        private Panel CreateCarListingPanelFromCar(Cars car, int yPosition)
        {
            // Create main panel
            Panel panel = new Panel
            {
                BorderStyle = BorderStyle.FixedSingle,
                Location = new Point(27, yPosition),
                Size = new Size(1100, 133),
                Name = $"panelCarListing{car.CarID}"
            };

            // Create and add car image
            PictureBox pictureBox = new PictureBox
            {
                BackColor = Color.LightGray,
                Location = new Point(11, 13),
                Size = new Size(126, 110),
                SizeMode = PictureBoxSizeMode.Zoom,
                Name = $"pictureBoxCar{car.CarID}"
            };

            try
            {
                // Get the directory where images are stored for this car
                string projectRoot = Path.GetFullPath(Path.Combine(Application.StartupPath, @"..\..\.."));
                string cleanedBrand = car.CarBrand.Replace(" ", "");
                string carImageDir = Path.Combine(projectRoot, "Media", "Images", cleanedBrand, car.CarID);


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


            // Create title label
            Label titleLabel = new Label
            {
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                Location = new Point(149, 13),
                Size = new Size(343, 27),
                Text = $"{car.CarBrand} {car.Model} {car.Year}",
                Name = $"lblCar{car.CarID}Title"
            };

            // Create price label
            Label priceLabel = new Label
            {
                Font = new Font("Segoe UI", 9F),
                Location = new Point(149, 47),
                Size = new Size(343, 27),
                Text = $"MUR {car.CarPrice} per day",
                Name = $"lblCar{car.CarID}Price"
            };

            // Create status label
            Label statusLabel = new Label
            {
                BackColor = car.Status == "Available" ? Color.LimeGreen : Color.LightBlue,
                Font = new Font("Segoe UI", 9F),
                Location = new Point(941, 13),
                Size = new Size(130, 35),
                Text = car.Status,
                TextAlign = ContentAlignment.MiddleCenter,
                Name = $"lblCar{car.CarID}Status"
            };

            // Create features panel
            Panel featuresPanel = new Panel
            {
                Location = new Point(149, 80),
                Size = new Size(343, 40),
                Name = $"panelCar{car.CarID}Features"
            };

            // Add feature labels to the panel
            int featureX = 0;

            Label featureLabel = new Label
            {
                AutoSize = true,
                BackColor = Color.LightGray,
                BorderStyle = BorderStyle.FixedSingle,
                Font = new Font("Segoe UI", 8F),
                Location = new Point(featureX, 7),
                Padding = new Padding(6, 3, 6, 3),
                Text = car.Features,
                Name = $"lblCar{car.CarID}Feature"
            };
            

            featuresPanel.Controls.Add(featureLabel);

            if (car.Status == "Available")
            {

                // Create delete button
                Button deleteButton = new Button
                {
                    BackColor = Color.OrangeRed,
                    FlatStyle = FlatStyle.Flat,
                    ForeColor = Color.White,
                    Location = new Point(941, 80),
                    Size = new Size(130, 40),
                    Text = "Delete",
                    Name = $"btnDeleteCar{car.CarID}"
                };

                // Add event handler to the delete button
                deleteButton.Click += BtnDelete_Click;
                deleteButton.FlatAppearance.BorderSize = 0;
                panel.Controls.Add(deleteButton);
            }
 
          
            // Add all controls to the panel
            panel.Controls.Add(pictureBox);
            panel.Controls.Add(titleLabel);
            panel.Controls.Add(priceLabel);
            panel.Controls.Add(statusLabel);
            panel.Controls.Add(featuresPanel);
           
            return panel;
        }
        // Method to handle delete button clicks to delete car listing of the user
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string buttonName = btn.Name;
            string carId = buttonName.Substring("btnDeleteCar".Length);


            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this car listing?",
                "Confirm Deletion",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    // Remove related bookings and payments from database
                    BookingsRepository bookingRepo = new BookingsRepository(new DatabaseConnection());
                    var bookingsForCar = bookingRepo.GetBookingsByCarId(carId);
                    var bookingHashTable = bookingRepo.LoadBookingsFromDatabase();

                    PaymentRepository paymentRepo = new PaymentRepository(new DatabaseConnection());
                    foreach (var booking in bookingsForCar)
                    {
                        // Remove from booking hash table if exists
                        if (bookingHashTable.ContainsKey(booking.BookingID))
                        {
                            bookingHashTable.Remove(booking.BookingID);
                        }

                        // Delete related payment
                        paymentRepo.DeletePaymentByBookingId(booking.BookingID);

                        // Delete the booking itself
                        bookingRepo.DeleteBookingById(booking.BookingID);
                    }

                    // Remove car from car hash table
                    if (carHashTable.ContainsKey(carId))
                    {
                        carHashTable.Remove(carId);
                    }

                    // Delete the car from the Car table
                    CarRepository carRepo = new CarRepository(new DatabaseConnection());
                    carRepo.DeleteCarById(carId);

                    // Remove car panel from UI
                    Panel panelToHide = (Panel)panelContent.Controls.Find($"panelCarListing{carId}", true)[0];
                    panelContent.Controls.Remove(panelToHide);
                    panelToHide.Dispose();

                    // Update listings count
                    int visibleCars = panelContent.Controls
                        .OfType<Panel>()
                        .Count(p => p.Name.StartsWith("panelCarListing") && p.Visible);

                    lblListingsCount.Text = visibleCars.ToString();

                    // Update reservation count if needed
                    Label statusLabel = panelToHide.Controls.Find($"lblCar{carId}Status", true).FirstOrDefault() as Label;
                    if (statusLabel != null && statusLabel.Text == "Reserved")
                    {
                        int currentReservations = int.Parse(lblReservationsCount.Text);
                        lblReservationsCount.Text = (currentReservations - 1).ToString();
                    }

                    // Show "no listings" message
                    labelNoMoreListings.Visible = (visibleCars == 0);
                    if (labelNoMoreListings.Visible)
                        labelNoMoreListings.Location = new Point(27, 31);

                    // Reposition transaction header and panels
                    int newTransactionY = 31;
                    foreach (Control control in panelContent.Controls)
                    {
                        if (control is Panel panel && panel.Name.StartsWith("panelCarListing") && panel.Visible)
                        {
                            newTransactionY = Math.Max(newTransactionY, panel.Location.Y + panel.Height + 10);
                        }
                    }

                    if (visibleCars == 0)
                        newTransactionY += labelNoMoreListings.Height + 10;

                    labelTransactionHistory.Location = new Point(27, newTransactionY);

                    // Reposition transaction panels
                    int transactionY = labelTransactionHistory.Location.Y + labelTransactionHistory.Height + 20;
                    foreach (Control control in panelContent.Controls)
                    {
                        if (control is Panel panel && panel.Name.StartsWith("panelTransaction") && panel.Visible)
                        {
                            panel.Location = new Point(27, transactionY);
                            transactionY += panel.Height + 10;
                        }
                    }

                    // Reposition "no history" label
                    if (labelNoMoreHistory.Visible)
                    {
                        labelNoMoreHistory.Location = new Point(27, transactionY);
                        panelContent.Controls.Add(labelNoMoreHistory);

                    }

                    MessageBox.Show("Your Car will be no longer be listed in our database");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error while deleting the car: " + ex.Message);
                }
            }
        }


        // Method to load transactions from database
        private void LoadTransactionsFromDatabase(int transactionStartY)
        {
            
            BookingsRepository bookingRepo = new BookingsRepository(new DatabaseConnection());
            PaymentRepository paymentRepo = new PaymentRepository(new DatabaseConnection());
            List<string> bookingIds = new List<string>();

            // Clear existing static transaction panels
            if (panelContent.Controls.Contains(panelTransaction1))
                panelContent.Controls.Remove(panelTransaction1);

            if (panelContent.Controls.Contains(panelTransaction2))
                panelContent.Controls.Remove(panelTransaction2);


            // Load bookings for the current user
            var bookings = bookingRepo.GetBookingsForUserWithCarDetails(CurrentUser.CurrentUserId);

            int listingsCount = 0;
            int reservedCount = 0;

            // Create label for transaction history
            labelTransactionHistory.Location = new Point(27, transactionStartY);
            labelTransactionHistory.Visible = true;
            panelContent.Controls.Add(labelTransactionHistory);

            transactionStartY += labelTransactionHistory.Height + 25;

            // Iterate through bookings and create panels for the cars to be displayed on the screen
            foreach (var (booking, carBrand,model, carid, year, price, status) in bookings)
            {
                Panel carPanel = CreateTransactionPanel(booking, carBrand, model, carid, year, price, status, transactionStartY);
                panelContent.Controls.Add(carPanel);

                transactionStartY += carPanel.Height + 10;
                listingsCount++;

                // Check status of whether the car is booked or not to display number of reservations
                if (status.Equals("Available", StringComparison.OrdinalIgnoreCase))
                {
                    reservedCount++;
                }

                bookingIds.Add(booking.BookingID);
            }

            // Set label for "No more history" if no bookings
            if (listingsCount == 0)
            {
                labelNoMoreHistory.Visible = true;
                labelNoMoreHistory.Location = new Point(27, transactionStartY);
                panelContent.Controls.Add(labelNoMoreHistory);
            }
            else
            {
                labelNoMoreHistory.Visible = false;
            }

            // Calculate total earnings and display it
            decimal totalEarnings = paymentRepo.GetTotalEarningsByBookingIds(bookingIds);
            lblEarningsAmount.Text = $"MUR {totalEarnings:F2}";
        }
        

        // Method to create a transaction panel
        private Panel CreateTransactionPanel(Booking booking, string brand, string model ,string carid, int year, decimal price, string status, int yPosition)
        {

            // Create main panel
            Panel panel = new Panel
            {
                BorderStyle = BorderStyle.FixedSingle,
                Location = new Point(27, yPosition),
                Size = new Size(1100, 159),
                Name = $"panelTransaction{booking.CarID}"
            };

            // Create and add car image
            PictureBox pictureBox = new PictureBox
            {
                BackColor = Color.LightGray,
                Location = new Point(11, 13),
                Size = new Size(126, 107),
                SizeMode = PictureBoxSizeMode.Zoom,
                Name = $"pictureBoxTransaction{booking.BookingID}"
            };



            try
            {
                // Get the directory where images are stored for this car
                string projectRoot = Path.GetFullPath(Path.Combine(Application.StartupPath, @"..\..\.."));
                //string carImageDir = Path.Combine(projectRoot, "Media", "Images", "CarTable", car.CarBrand, car.CarID);
                string cleanedBrand = brand.Replace(" ", "");
                string carImageDir = Path.Combine(projectRoot, "Media", "Images", cleanedBrand, carid);


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
           
           

            // Create title label
            Label titleLabel = new Label
            {
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                Location = new Point(149, 13),
                Size = new Size(343, 27),
                Text = $"{brand} {model} {year}",
                Name = $"lblTransaction{booking.BookingID}Title"
            };

            // Create price label
            Label priceLabel = new Label
            {
                Font = new Font("Segoe UI", 9F),
                Location = new Point(149, 47),
                Size = new Size(343, 27),
                Text = $"MUR {price} per day",
                Name = $"lblTransaction{booking.BookingID}Price"
            };

            // Create date range label
            DateTime pickup = DateTime.ParseExact(booking.PickupDate, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
            DateTime dropoff = DateTime.ParseExact(booking.DropoffDate, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);

            string dateText = $"Booking Period: {pickup:dd/MM/yyyy} - {dropoff:dd/MM/yyyy}";

            Label dateRangeLabel = new Label
            {
                Font = new Font("Segoe UI", 9F),
                Location = new Point(149, 80),
                Size = new Size(500, 27),
                Text = dateText,
                Name = $"lblTransaction{booking.CarID}DateRange"
            };

            // Create status label
            Label statusLabel = new Label
            {
                BackColor = Color.LimeGreen,
                Font = new Font("Segoe UI", 9F),
                Location = new Point(941, 13),
                Size = new Size(130, 35),
                Text = status,
                TextAlign = ContentAlignment.MiddleCenter,
                Name = $"lblTransaction{booking.BookingID}Status"
            };

            // Add all controls
            panel.Controls.Add(pictureBox);
            panel.Controls.Add(titleLabel);
            panel.Controls.Add(priceLabel);
            panel.Controls.Add(dateRangeLabel);
            panel.Controls.Add(statusLabel);
         
            return panel;
           
        }
        // Method to handle browse listings button clicks
        private void btnBrowseListings_Click(object sender, EventArgs e)
        {
            BrowseListings browseListings = new BrowseListings();
            browseListings.Show();
            this.Dispose();
        }
        // Method to handle manage booking button clicks
        private void btnManageBooking_Click(object sender, EventArgs e)
        {
            ManageBookings manageBookings = new ManageBookings();
            manageBookings.Show();
            this.Dispose();
        }

        private void btnListCar_Click(object sender, EventArgs e)
        {
            ListCarForm listCarForm = new ListCarForm();
            listCarForm.Show();
            this.Dispose();
        }

        private void btnManageYourListings_Click(object sender, EventArgs e)
        {
            ManageYourListings manageYourListings = new ManageYourListings();
            manageYourListings.Show();
            this.Dispose();
        }

        private void btnOptions_Click(object sender, EventArgs e)
        {
            Options_Personal options = new Options_Personal();
            options.Show();
            this.Dispose();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
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

        // Method to handle form closing event
        private void Form2_Load(object sender, EventArgs e)
        {
            this.FormClosing += new FormClosingEventHandler(ManageListing_FormClosing);
        }

        private void ManageListing_FormClosing(object sender, FormClosingEventArgs e)
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
using Horizon_Drive_LTD.BusinessLogic;
using Horizon_Drive_LTD.BusinessLogic.Repositories;
using Horizon_Drive_LTD.BusinessLogic.Services;
using Horizon_Drive_LTD.DataStructure;
using Horizon_Drive_LTD.Domain.Entities;
using Microsoft.Data.SqlClient;
using splashscreen;



namespace Horizon_Drive_LTD
{
    public partial class ManageBookings : Form
    {
        DatabaseConnection _dbConnection = new DatabaseConnection();


        // List to store booking information
        private List<BookingInfo> bookings = new List<BookingInfo>();
        private string currentFilter = "Upcoming"; // Default filter


        private HashTable<string, Cars> carHashTable;  // Added to store car data

        public ManageBookings()
        {
            InitializeComponent();
            this.ClientSize = new Size(1600, 900);
            this.MinimumSize = new Size(1000, 700);

            // Load car data - NEW
            LoadCarData();

            DisplayUsername();
            LoadBookingData();  // Now loads from database instead of sample data
            ApplyFilter("Upcoming");
        }

        private void LoadCarData()
        {
            var carRepo = new CarRepository(_dbConnection);
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

        private void LoadBookingData()
        {
            bookings.Clear();

            using (SqlConnection conn = _dbConnection.GetConnection())
            {
                conn.Open();
                string query = @"SELECT b.BookingID, b.CustomerID, b.CarID, b.BookingDate, 
                       b.PickupDate, b.DropoffDate, b.PickupLocation, b.DropoffLocation
                       , b.BabyCarSeat, b.FullInsuranceCoverage, 
                       b.RoofRack, b.AirportPickupDropoff, b.BookingStatus
                       FROM Booking b
                       JOIN ActiveUser a ON b.CustomerID = a.CustomerID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var booking = new BookingInfo
                            {
                                BookingID = reader["BookingID"].ToString(), // potential customerId
                                CarID = reader["CarID"].ToString(),
                                PickupDate = Convert.ToDateTime(reader["PickupDate"]),
                                DropoffDate = Convert.ToDateTime(reader["DropoffDate"]),
                                PickupLocation = reader["PickupLocation"].ToString(),
                                DropoffLocation = reader["DropoffLocation"].ToString(),
                                
                                BookingStatus = reader["BookingStatus"].ToString()
                            };
                            bookings.Add(booking);
                        }
                    }
                }
            }
        }

        private void ApplyFilter(string filter)
        {
            currentFilter = filter;

            // Highlight the selected filter button
            foreach (Control control in filterPanel.Controls)
            {
                if (control is Button btn)
                {
                    if (btn.Text == filter)
                    {
                        btn.BackColor = Color.FromArgb(173, 216, 230); // Light blue for selected
                        btn.ForeColor = Color.Black;
                    }
                    else
                    {
                        btn.BackColor = Color.FromArgb(30, 85, 110); // Dark blue for unselected
                        btn.ForeColor = Color.White;
                    }
                }
            }

            // Filter bookings based on selected status
            var filteredBookings = bookings.FindAll(b => b.BookingStatus == filter);
            DisplayBookings(filteredBookings);
        }

        private void DisplayBookings(List<BookingInfo> bookingsToDisplay)
        {
            // Clear existing bookings
            bookingsFlowPanel.Controls.Clear();

            // Add booking panels to flow layout
            foreach (var booking in bookingsToDisplay)
            {
                Panel bookingPanel = CreateBookingPanel(booking);
                bookingsFlowPanel.Controls.Add(bookingPanel);
            }
        }

        private Panel CreateBookingPanel(BookingInfo booking)
        {
            var car = carHashTable.Search(booking.CarID);
            string make = car?.CarBrand ?? "Unknown";
            string model = car?.Model ?? "Unknown";
            string imagePath = GetCarImagePath(booking.CarID);

            // Main booking panel with increased size
            Panel panel = new()
            {
                Size = new Size(650, 200),  // Wider panel to accommodate larger image
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(10),
                BackColor = Color.White,
                Padding = new Padding(5)
            };

            // Larger car image on the left (1/3 of panel width)
            PictureBox carImage = new PictureBox
            {
                Size = new Size(200, 150),  // Increased image size
                Location = new Point(10, 22),
                SizeMode = PictureBoxSizeMode.Zoom,
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.LightGray
            };

            // Load image with fallback
            if (!string.IsNullOrEmpty(imagePath) && File.Exists(imagePath))
            {
                try
                {
                    carImage.Image = Image.FromFile(imagePath);
                }
                catch
                {
                    carImage.Image = Properties.Resources.Logo;
                }
            }
            else
            {
                carImage.Image = Properties.Resources.Logo;
            }

            // Right side container for details (2/3 of panel width)
            Panel detailsPanel = new Panel
            {
                Location = new Point(220, 10),  // Right of the image with proper spacing
                Size = new Size(panel.Width - 240, panel.Height - 20),
                BackColor = Color.Transparent
            };

            // Car title and booking ID
            Label lblCarTitle = new()
            {
                Text = $"{make} {model}",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                AutoSize = false,
                Size = new Size(detailsPanel.Width - 20, 25),
                Location = new Point(0, 0)
            };

            Label lblBookingID = new()
            {
                Text = $"Booking #: {booking.BookingID}",
                Font = new Font("Segoe UI", 9),
                AutoSize = true,
                Location = new Point(0, 30),
                ForeColor = Color.Gray
            };

            // Booking details section
            int detailsTop = 60;
            int labelWidth = 80;

            // Pickup details
            Label lblPickupTitle = new()
            {
                Text = "Pickup:",
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                AutoSize = false,
                Size = new Size(labelWidth, 20),
                Location = new Point(0, detailsTop)
            };

            Label lblPickupLocation = new()
            {
                Text = booking.PickupLocation,
                Font = new Font("Segoe UI", 9),
                AutoSize = false,
                Size = new Size(detailsPanel.Width - labelWidth - 10, 20),
                Location = new Point(labelWidth, detailsTop)
            };

            Label lblPickupDate = new()
            {
                Text = booking.PickupDate.ToString("ddd, MMM d, yyyy"),
                Font = new Font("Segoe UI", 9),
                AutoSize = false,
                Size = new Size(detailsPanel.Width - labelWidth - 10, 20),
                Location = new Point(labelWidth, detailsTop + 20)
            };

            // Drop-off details
            int dropoffTop = detailsTop + 45;

            Label lblDropOffTitle = new()
            {
                Text = "Drop-off:",
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                AutoSize = false,
                Size = new Size(labelWidth, 20),
                Location = new Point(0, dropoffTop)
            };

            Label lblDropOffLocation = new()
            {
                Text = booking.DropoffLocation,
                Font = new Font("Segoe UI", 9),
                AutoSize = false,
                Size = new Size(detailsPanel.Width - labelWidth - 10, 20),
                Location = new Point(labelWidth, dropoffTop)
            };

            Label lblDropOffDate = new()
            {
                Text = booking.DropoffDate.ToString("ddd, MMM d, yyyy"),
                Font = new Font("Segoe UI", 9),
                AutoSize = false,
                Size = new Size(detailsPanel.Width - labelWidth - 10, 20),
                Location = new Point(labelWidth, dropoffTop + 20)
            };

            // Status and action buttons
            int actionTop = dropoffTop + 45;

            Label lblStatus = new()
            {
                Text = $"Status: {booking.BookingStatus}",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(0, actionTop),
                ForeColor = booking.BookingStatus == "Upcoming" ? Color.Green :
                           booking.BookingStatus == "Completed" ? Color.Blue :
                           Color.Red
            };

            Button btnCancelBooking = new()
            {
                Text = "Cancel Booking",
                Size = new Size(120, 30),
                Location = new Point(detailsPanel.Width - 120, actionTop),
                BackColor = Color.OrangeRed,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnCancelBooking.FlatAppearance.BorderSize = 0;
            btnCancelBooking.Tag = booking.BookingID;
            btnCancelBooking.Click += BtnCancelBooking_Click;

            if (booking.BookingStatus != "Upcoming")
            {
                btnCancelBooking.Visible = false;
            }

            // Add controls to details panel
            detailsPanel.Controls.Add(lblCarTitle);
            detailsPanel.Controls.Add(lblBookingID);
            detailsPanel.Controls.Add(lblPickupTitle);
            detailsPanel.Controls.Add(lblPickupLocation);
            detailsPanel.Controls.Add(lblPickupDate);
            detailsPanel.Controls.Add(lblDropOffTitle);
            detailsPanel.Controls.Add(lblDropOffLocation);
            detailsPanel.Controls.Add(lblDropOffDate);
            detailsPanel.Controls.Add(lblStatus);
            detailsPanel.Controls.Add(btnCancelBooking);

            // Add main controls to panel
            panel.Controls.Add(carImage);
            panel.Controls.Add(detailsPanel);

            return panel;
        }

        // NEW - Gets first image path for a car
        //private string GetCarImagePath(string carId)
        //{
        //    string imagePath = string.Empty;
        //    try
        //    {
        //        using (SqlConnection conn = _dbConnection.GetConnection())
        //        {
        //            conn.Open();
        //            string query = "SELECT TOP 1 ImagePath FROM CarImages WHERE CarId = @CarId";
        //            using (SqlCommand cmd = new SqlCommand(query, conn))
        //            {
        //                cmd.Parameters.AddWithValue("@CarId", carId);
        //                var result = cmd.ExecuteScalar();
        //                if (result != null)
        //                {
        //                    string relativePath = result.ToString();
        //                    string projectRoot = Path.GetFullPath(Path.Combine(Application.StartupPath, @"..\..\.."));
        //                    imagePath = Path.Combine(projectRoot, relativePath.Replace("/", "\\"));
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Error loading car image: {ex.Message}");
        //    }
        //    return imagePath;
        //}

        private string GetCarImagePath(string carId)
        {
            string imagePath = string.Empty;
            try
            {
                // 1. First check if we have a valid car ID
                if (string.IsNullOrWhiteSpace(carId))
                {
                    MessageBox.Show("Invalid Car ID provided", "Image Loading Error",
                                 MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return imagePath;
                }

                using (SqlConnection conn = _dbConnection.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT TOP 1 ImagePath FROM CarImages WHERE CarId = @CarId";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@CarId", carId);
                        var result = cmd.ExecuteScalar();

                        // 2. Check if we got any result from the database
                        if (result == null)
                        {
                            MessageBox.Show($"No image found for Car ID: {carId}", "Image Loading Warning",
                                         MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return imagePath;
                        }

                        string relativePath = result.ToString();

                        // 3. Check if the path is not empty
                        if (string.IsNullOrWhiteSpace(relativePath))
                        {
                            MessageBox.Show($"Empty image path for Car ID: {carId}", "Image Loading Warning",
                                         MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return imagePath;
                        }

                        // 4. Build the full path and verify it
                        string projectRoot = Path.GetFullPath(Path.Combine(Application.StartupPath, @"..\..\.."));
                        imagePath = Path.Combine(projectRoot, relativePath.Replace("/", "\\"));

                        // 5. Check if file exists
                        if (!File.Exists(imagePath))
                        {
                            MessageBox.Show($"Image file not found at: {imagePath}", "Image Loading Error",
                                         MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return string.Empty;
                        }

                        // 6. Verify the file is a valid image
                        try
                        {
                            using (var img = Image.FromFile(imagePath))
                            {
                                // Just testing if we can load it
                            }
                        }
                        catch (Exception imgEx)
                        {
                            MessageBox.Show($"Invalid image file: {imgEx.Message}", "Image Loading Error",
                                         MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return string.Empty;
                        }

                        return imagePath;
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show($"Database error loading image: {sqlEx.Message}", "Database Error",
                             MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"General error loading image: {ex.Message}", "Error",
                             MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return imagePath;
        }



        // NEW - Safely loads image with fallback
        private Image LoadImageSafely(string path)
        {
            try { return File.Exists(path) ? Image.FromFile(path) : Properties.Resources.Logo; }
            catch { return Properties.Resources.Logo; }
        }

        private void BtnCancelBooking_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string bookingId = btn.Tag as string;

            if (bookingId == null)
            {
                MessageBox.Show("Invalid booking ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = MessageBox.Show("Are you sure you want to cancel this booking?",
                                "Cancel Booking",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection conn = _dbConnection.GetConnection())
                    {
                        conn.Open();
                        string query = "UPDATE Booking SET BookingStatus = 'Cancelled' WHERE BookingID = @BookingID";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@BookingID", bookingId);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    // Update local list
                    var booking = bookings.Find(b => b.BookingID == bookingId);
                    if (booking != null)
                    {
                        booking.BookingStatus = "Cancelled";
                        MessageBox.Show("Booking has been cancelled successfully.",
                                       "Booking Cancelled",
                                       MessageBoxButtons.OK,
                                       MessageBoxIcon.Information);
                        ApplyFilter(currentFilter);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error cancelling booking: {ex.Message}",
                                   "Error",
                                   MessageBoxButtons.OK,
                                   MessageBoxIcon.Error);
                }
            }
        }

        // Event handlers for filter buttons
        private void btnUpcoming_Click(object sender, EventArgs e)
        {
            ApplyFilter("Upcoming");
        }

        private void btnCompleted_Click(object sender, EventArgs e)
        {
            ApplyFilter("Completed");
        }

        private void btnCancelled_Click(object sender, EventArgs e)
        {
            ApplyFilter("Cancelled");
        }

        // Navigation event handlers
        private void btnBrowseListings_Click(object sender, EventArgs e)
        {
            // Navigate to browse listings form
            BrowseListings browseListingsForm = new BrowseListings();
            browseListingsForm.Show();
            this.Dispose();
        }

        private void btnManageBooking_Click(object sender, EventArgs e)
        {
            // Already on this page - refresh data
            LoadBookingData();
            ApplyFilter(currentFilter);
        }

        private void btnListCar_Click(object sender, EventArgs e)
        {
            ListCarForm listCarForm = new ListCarForm();
            listCarForm.Show();
            this.Dispose();
        }

        private void btnManageYourListings_Click(object sender, EventArgs e)
        {
            ManageYourListings manageYourListingsForm = new ManageYourListings();
            manageYourListingsForm.Show();
            this.Dispose();
        }

        private void btnOptions_Click(object sender, EventArgs e)
        {
            Options_Personal optionsForm = new Options_Personal();
            optionsForm.Show();
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

                // After logout, update the username display
                DisplayUsername();
                // Optionally, you can redirect to a login form or main menu

                using (SqlConnection conn = _dbConnection.GetConnection())
                {
                    conn.Open();
                    string dropTableQuery = "DROP TABLE IF EXISTS ActiveUser;";
                    using (SqlCommand cmd = new SqlCommand(dropTableQuery, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }

                OpenLoginUp();
            }
        }

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

        private void buttonProfile_Click(object sender, EventArgs e)
        {
            // Open the Options_Personal form
            Options_Personal optionsPersonalForm = new Options_Personal();
            optionsPersonalForm.Show();
            this.Dispose();
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = textBoxSearch.Text.ToLower();

            if (string.IsNullOrWhiteSpace(searchText))
            {
                ApplyFilter(currentFilter); // Show all if search is empty
                return;
            }

            // Filter based on current filter and search text
            var filteredBookings = bookings.FindAll(b =>
                b.BookingStatus == currentFilter && (
                b.Make.ToLower().Contains(searchText) ||
                b.Model.ToLower().Contains(searchText) ||
                b.PickupLocation.ToLower().Contains(searchText) ||
                b.DropoffLocation.ToLower().Contains(searchText))
            );

            DisplayBookings(filteredBookings);
        }

        private bool isClosing = false;
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

        private void ManageBookings_Load(object sender, EventArgs e)
        {
            this.FormClosing += new FormClosingEventHandler(MyForm_FormClosing);
        }

        private void labelUsername_Click(object sender, EventArgs e)
        {

        }
    }

    // Add the missing property 'CarID' to the BookingInfo class to resolve the CS1061 error.
    public class BookingInfo
    {
        public string BookingID { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string PickupLocation { get; set; }
        public DateTime PickupDate { get; set; }
        public string DropoffLocation { get; set; }
        public DateTime DropoffDate { get; set; }
        public string BookingStatus { get; set; }
        public string CarID { get; set; } // Added property
    }
}





//using Horizon_Drive_LTD.BusinessLogic;
//using Horizon_Drive_LTD.BusinessLogic.Repositories;
//using Horizon_Drive_LTD.BusinessLogic.Services;
//using Microsoft.Data.SqlClient;
//using splashscreen;


////ManageBookings.cs
//namespace Horizon_Drive_LTD
//{
//    public partial class ManageBookings : Form
//    {
//        DatabaseConnection _dbConnection = new DatabaseConnection();


//        // List to store booking information
//        private List<BookingInfo> bookings = new List<BookingInfo>();
//        private string currentFilter = "Upcoming"; // Default filter


//        public ManageBookings()
//        {
//            InitializeComponent();
//            this.ClientSize = new Size(1600, 900);
//            this.MinimumSize = new Size(1000, 700);

//            // Display the username
//            DisplayUsername();

//            // Load sample booking data
//            LoadBookingData();

//            // Set the default filter to Upcoming
//            ApplyFilter("Upcoming");
//        }

//        // Method to fetch and display username
//        private void DisplayUsername()
//        {
//            string username = GetLoggedInUsername();

//            if (string.IsNullOrEmpty(username))
//            {
//                labelUsername.Text = "User not logged in";
//                // style the label differently (RED) for non-logged in users
//                labelUsername.ForeColor = Color.Red;
//            }
//            else
//            {
//                labelUsername.Text = username;
//                labelUsername.ForeColor = Color.FromArgb(15, 30, 45); // Colour of logged in users
//            }
//        }


//        // Method to get the username from your database
//        private string GetLoggedInUsername()
//        {
//            using (SqlConnection conn = _dbConnection.GetConnection())
//            {
//                conn.Open();
//                string query = "SELECT Username FROM ActiveUser";

//                using (SqlCommand cmd = new SqlCommand(query, conn))
//                {
//                    var result = cmd.ExecuteScalar();
//                    return result?.ToString();
//                }
//            }

//        }

//        private void LoadBookingData()
//        {
//            // Sample data - in a real app, this would come from a database
//            bookings.Add(new BookingInfo
//            {
//                BookingID = "1",
//                Make = "FORD",
//                Model = "RAPTOR",
//                PickupLocation = "Downtown Station",
//                PickupDate = new DateTime(2025, 1, 10),
//                DropoffLocation = "Airport Terminal 2",
//                DropoffDate = new DateTime(2025, 1, 15),
//                BookingStatus = "Upcoming"
//            });

//            bookings.Add(new BookingInfo
//            {
//                BookingID = "2",
//                Make = "NISSAN",
//                Model = "GTR",
//                PickupLocation = "Rose Belle Station",
//                PickupDate = new DateTime(2025, 3, 2),
//                DropoffLocation = "Airport Terminal 5",
//                DropoffDate = new DateTime(2025, 3, 7),
//                BookingStatus = "Upcoming"
//            });

//            bookings.Add(new BookingInfo
//            {
//                BookingID = "3",
//                Make = "BMW",
//                Model = "X4",
//                PickupLocation = "Downtown Station",
//                PickupDate = new DateTime(2024, 12, 10),
//                DropoffLocation = "Rose Belle Station",
//                DropoffDate = new DateTime(2024, 12, 15),
//                BookingStatus = "Completed"
//            });

//            bookings.Add(new BookingInfo
//            {
//                BookingID = "4",
//                Make = "Mercedes",
//                Model = "AMG",
//                PickupLocation = "Airport Terminal 3",
//                PickupDate = new DateTime(2024, 11, 20),
//                DropoffLocation = "Downtown Station",
//                DropoffDate = new DateTime(2024, 11, 22),
//                BookingStatus = "Cancelled"
//            });
//        }

//        private void ApplyFilter(string filter)
//        {
//            currentFilter = filter;

//            // Highlight the selected filter button
//            foreach (Control control in filterPanel.Controls)
//            {
//                if (control is Button btn)
//                {
//                    if (btn.Text == filter)
//                    {
//                        btn.BackColor = Color.FromArgb(173, 216, 230); // Light blue for selected
//                        btn.ForeColor = Color.Black;
//                    }
//                    else
//                    {
//                        btn.BackColor = Color.FromArgb(30, 85, 110); // Dark blue for unselected
//                        btn.ForeColor = Color.White;
//                    }
//                }
//            }

//            // Filter bookings based on selected status
//            var filteredBookings = bookings.FindAll(b => b.BookingStatus == filter);
//            DisplayBookings(filteredBookings);
//        }

//        private void DisplayBookings(List<BookingInfo> bookingsToDisplay)
//        {
//            // Clear existing bookings
//            bookingsFlowPanel.Controls.Clear();

//            // Add booking panels to flow layout
//            foreach (var booking in bookingsToDisplay)
//            {
//                Panel bookingPanel = CreateBookingPanel(booking);
//                bookingsFlowPanel.Controls.Add(bookingPanel);
//            }
//        }

//        private Panel CreateBookingPanel(BookingInfo booking)
//        {
//            // Main booking panel
//            Panel panel = new Panel
//            {
//                Size = new Size(560, 170),
//                BorderStyle = BorderStyle.FixedSingle,
//                Margin = new Padding(10),
//                BackColor = Color.White
//            };

//            // Car icon
//            Label carIcon = new Label
//            {
//                Text = "🚗",
//                Font = new Font("Segoe UI Symbol", 16),
//                Size = new Size(40, 40),
//                Location = new Point(15, 15),
//                TextAlign = ContentAlignment.MiddleCenter,
//                BorderStyle = BorderStyle.FixedSingle
//            };

//            // Car title
//            Label lblCarTitle = new Label
//            {
//                Text = $"{booking.Make} {booking.Model}",
//                Font = new Font("Segoe UI", 12, FontStyle.Bold),
//                AutoSize = false,
//                Size = new Size(300, 25),
//                Location = new Point(70, 15)
//            };

//            // Pickup details
//            Label lblPickupTitle = new Label
//            {
//                Text = "Pickup:",
//                Font = new Font("Segoe UI", 9, FontStyle.Bold),
//                AutoSize = true,
//                Location = new Point(15, 60)
//            };

//            Label lblPickupLocation = new Label
//            {
//                Text = booking.PickupLocation,
//                Font = new Font("Segoe UI", 9),
//                AutoSize = true,
//                Location = new Point(70, 60)
//            };

//            Label lblPickupDate = new Label
//            {
//                Text = booking.PickupDate.ToString("MMM d, yyyy"),
//                Font = new Font("Segoe UI", 9),
//                AutoSize = true,
//                Location = new Point(70, 80)
//            };

//            // Drop-off details - ADJUSTED POSITIONS
//            Label lblDropOffTitle = new Label
//            {
//                Text = "Drop-off:",
//                Font = new Font("Segoe UI", 9, FontStyle.Bold),
//                AutoSize = true,
//                Location = new Point(280, 60)
//            };

//            Label lblDropOffLocation = new Label
//            {
//                Text = booking.DropoffLocation,
//                Font = new Font("Segoe UI", 9),
//                AutoSize = true,
//                Location = new Point(352, 60)
//            };

//            Label lblDropOffDate = new Label
//            {
//                Text = booking.DropoffDate.ToString("MMM d, yyyy"),
//                Font = new Font("Segoe UI", 9),
//                AutoSize = true,
//                Location = new Point(352, 80) // Adjusted to match the location label
//            };

//            // Status label
//            Label lblStatus = new Label
//            {
//                Text = $"Status: {booking.BookingStatus}",
//                Font = new Font("Segoe UI", 9, FontStyle.Bold),
//                AutoSize = true,
//                Location = new Point(15, 130)
//            };

//            // Cancel Booking button
//            Button btnCancelBooking = new Button
//            {
//                Text = "Cancel Booking",
//                Size = new Size(120, 35),
//                Location = new Point(420, 120),
//                BackColor = Color.OrangeRed,
//                ForeColor = Color.White,
//                FlatStyle = FlatStyle.Flat
//            };
//            btnCancelBooking.FlatAppearance.BorderSize = 0;
//            btnCancelBooking.Tag = booking.BookingID;
//            btnCancelBooking.Click += BtnCancelBooking_Click;

//            // Only show cancel button for upcoming bookings
//            if (booking.BookingStatus != "Upcoming")
//            {
//                btnCancelBooking.Visible = false;
//            }

//            // Add all controls to the panel
//            panel.Controls.Add(carIcon);
//            panel.Controls.Add(lblCarTitle);
//            panel.Controls.Add(lblPickupTitle);
//            panel.Controls.Add(lblPickupLocation);
//            panel.Controls.Add(lblPickupDate);
//            panel.Controls.Add(lblDropOffTitle);
//            panel.Controls.Add(lblDropOffLocation);
//            panel.Controls.Add(lblDropOffDate);
//            panel.Controls.Add(lblStatus);
//            panel.Controls.Add(btnCancelBooking);

//            return panel;
//        }

//        private void BtnCancelBooking_Click(object sender, EventArgs e)
//        {
//            Button btn = (Button)sender;
//            string bookingId = btn.Tag as string; // Explicitly cast to string and handle nullability

//            if (bookingId == null)
//            {
//                MessageBox.Show("Invalid booking ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                return;
//            }

//            // Confirm cancellation with dialog
//            DialogResult result = MessageBox.Show("Are you sure you want to cancel this booking?",
//                                "Cancel Booking",
//                                MessageBoxButtons.YesNo,
//                                MessageBoxIcon.Question);

//            if (result == DialogResult.Yes)
//            {
//                // Find and update the booking
//                var booking = bookings.Find(b => b.BookingID == bookingId);
//                if (booking != null)
//                {
//                    booking.BookingStatus = "Cancelled";
//                    MessageBox.Show("Booking has been cancelled successfully.",
//                                   "Booking Cancelled",
//                                   MessageBoxButtons.OK,
//                                   MessageBoxIcon.Information);

//                    // Refresh the current filter view
//                    ApplyFilter(currentFilter);
//                }
//                else
//                {
//                    MessageBox.Show("Booking not found.",
//                                   "Error",
//                                   MessageBoxButtons.OK,
//                                   MessageBoxIcon.Error);
//                }
//            }
//        }

//        // Event handlers for filter buttons
//        private void btnUpcoming_Click(object sender, EventArgs e)
//        {
//            ApplyFilter("Upcoming");
//        }

//        private void btnCompleted_Click(object sender, EventArgs e)
//        {
//            ApplyFilter("Completed");
//        }

//        private void btnCancelled_Click(object sender, EventArgs e)
//        {
//            ApplyFilter("Cancelled");
//        }

//        // Navigation event handlers
//        private void btnBrowseListings_Click(object sender, EventArgs e)
//        {
//            // Navigate to browse listings form
//            BrowseListings browseListingsForm = new BrowseListings();
//            browseListingsForm.Show();
//            this.Dispose();
//        }

//        private void btnManageBooking_Click(object sender, EventArgs e)
//        {
//            // Already on this page - refresh data
//            LoadBookingData();
//            ApplyFilter(currentFilter);
//        }

//        private void btnListCar_Click(object sender, EventArgs e)
//        {
//            ListCarForm listCarForm = new ListCarForm();
//            listCarForm.Show();
//            this.Dispose();
//        }

//        private void btnManageYourListings_Click(object sender, EventArgs e)
//        {
//            ManageYourListings manageYourListingsForm = new ManageYourListings();
//            manageYourListingsForm.Show();
//            this.Dispose();
//        }

//        private void btnOptions_Click(object sender, EventArgs e)
//        {
//            Options_Personal optionsForm = new Options_Personal();
//            optionsForm.Show();
//            this.Dispose();
//        }

//        private void btnLogout_Click(object sender, EventArgs e)
//        {
//            DialogResult result = MessageBox.Show("Are you sure you want to log out?",
//                           "Log Out",
//                           MessageBoxButtons.YesNo,
//                           MessageBoxIcon.Question);

//            if (result == DialogResult.Yes)
//            {
//                MessageBox.Show("You have been logged out successfully.",
//                               "Log Out",
//                               MessageBoxButtons.OK,
//                               MessageBoxIcon.Information);

//                // After logout, update the username display
//                DisplayUsername();
//                // Optionally, you can redirect to a login form or main menu

//                using (SqlConnection conn = _dbConnection.GetConnection())
//                {
//                    conn.Open();
//                    string dropTableQuery = "DROP TABLE IF EXISTS ActiveUser;";
//                    using (SqlCommand cmd = new SqlCommand(dropTableQuery, conn))
//                    {
//                        cmd.ExecuteNonQuery();
//                    }
//                }

//                OpenLoginUp();
//            }
//        }

//        private void OpenLoginUp()
//        {

//            var userRepo = new UserRepository(new DatabaseConnection());
//            var userHashTable = userRepo.LoadUsersIntoHashTable();
//            var authService = new AuthenticationService(userHashTable, userRepo);
//            //var dbConnection = new DatabaseConnection();

//            // Show the Login form with injected authService
//            Login loginForm = new Login(authService);
//            loginForm.Show();

//            this.Dispose();
//        }

//        private void buttonProfile_Click(object sender, EventArgs e)
//        {
//            // Open the Options_Personal form
//            Options_Personal optionsPersonalForm = new Options_Personal();
//            optionsPersonalForm.Show();
//            this.Dispose();
//        }

//        private void textBoxSearch_TextChanged(object sender, EventArgs e)
//        {
//            string searchText = textBoxSearch.Text.ToLower();

//            if (string.IsNullOrWhiteSpace(searchText))
//            {
//                ApplyFilter(currentFilter); // Show all if search is empty
//                return;
//            }

//            // Filter based on current filter and search text
//            var filteredBookings = bookings.FindAll(b =>
//                b.BookingStatus == currentFilter && (
//                b.Make.ToLower().Contains(searchText) ||
//                b.Model.ToLower().Contains(searchText) ||
//                b.PickupLocation.ToLower().Contains(searchText) ||
//                b.DropoffLocation.ToLower().Contains(searchText))
//            );

//            DisplayBookings(filteredBookings);
//        }

//        private bool isClosing = false;
//        private void MyForm_FormClosing(object sender, FormClosingEventArgs e)
//        {
//            if (isClosing) return;
//            isClosing = true;

//            DialogResult result = MessageBox.Show("Do you want to close the Car Hire Application?", "Confirm Exit",
//                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

//            if (result == DialogResult.No)
//            {
//                e.Cancel = true; // Prevent closing
//                isClosing = false;
//            }
//            else
//            {
//                using (SqlConnection conn = _dbConnection.GetConnection())
//                {
//                    conn.Open();
//                    string dropTableQuery = "DROP TABLE IF EXISTS ActiveUser;";
//                    using (SqlCommand cmd = new SqlCommand(dropTableQuery, conn))
//                    {
//                        cmd.ExecuteNonQuery();
//                    }
//                }

//                Application.Exit(); // Properly terminates the application without triggering FormClosing again
//            }
//        }

//        private void ManageBookings_Load(object sender, EventArgs e)
//        {
//            this.FormClosing += new FormClosingEventHandler(MyForm_FormClosing);
//        }

//        private void labelUsername_Click(object sender, EventArgs e)
//        {

//        }
//    }

//    public class BookingInfo
//    {
//        public string BookingID { get; set; }
//        public string Make { get; set; } // found in car class
//        public string Model { get; set; } // found in car class
//        public string PickupLocation { get; set; }
//        public DateTime PickupDate { get; set; }
//        public string DropoffLocation { get; set; }
//        public DateTime DropoffDate { get; set; }
//        public string BookingStatus { get; set; }
//    }
//}
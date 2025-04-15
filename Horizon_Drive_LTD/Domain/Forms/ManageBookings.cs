using Horizon_Drive_LTD.BusinessLogic;
using Horizon_Drive_LTD.BusinessLogic.Repositories;
using Horizon_Drive_LTD.BusinessLogic.Services;
using Microsoft.Data.SqlClient;
using splashscreen;


//ManageBookings.cs
namespace Horizon_Drive_LTD
{
    public partial class ManageBookings : Form
    {
        DatabaseConnection _dbConnection = new DatabaseConnection();


        // List to store booking information
        private List<BookingInfo> bookings = new List<BookingInfo>();
        private string currentFilter = "Upcoming"; // Default filter

        public ManageBookings()
        {
            InitializeComponent();
            this.ClientSize = new Size(1600, 900);
            this.MinimumSize = new Size(1000, 700);

            // Display the username
            DisplayUsername();

            // Load sample booking data
            LoadBookingData();

            // Set the default filter to Upcoming
            ApplyFilter("Upcoming");
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
            // For testing purposes, return null to show "not logged in"
            return null;
        }

        private void LoadBookingData()
        {
            // Sample data - in a real app, this would come from a database
            bookings.Add(new BookingInfo
            {
                Id = 1,
                CarMake = "FORD",
                CarModel = "RAPTOR",
                PickupLocation = "Downtown Station",
                PickupDate = new DateTime(2025, 1, 10),
                DropoffLocation = "Airport Terminal 2",
                DropoffDate = new DateTime(2025, 1, 15),
                Status = "Upcoming"
            });

            bookings.Add(new BookingInfo
            {
                Id = 2,
                CarMake = "NISSAN",
                CarModel = "GTR",
                PickupLocation = "Rose Belle Station",
                PickupDate = new DateTime(2025, 3, 2),
                DropoffLocation = "Airport Terminal 5",
                DropoffDate = new DateTime(2025, 3, 7),
                Status = "Upcoming"
            });

            bookings.Add(new BookingInfo
            {
                Id = 3,
                CarMake = "BMW",
                CarModel = "X4",
                PickupLocation = "Downtown Station",
                PickupDate = new DateTime(2024, 12, 10),
                DropoffLocation = "Rose Belle Station",
                DropoffDate = new DateTime(2024, 12, 15),
                Status = "Completed"
            });

            bookings.Add(new BookingInfo
            {
                Id = 4,
                CarMake = "Mercedes",
                CarModel = "AMG",
                PickupLocation = "Airport Terminal 3",
                PickupDate = new DateTime(2024, 11, 20),
                DropoffLocation = "Downtown Station",
                DropoffDate = new DateTime(2024, 11, 22),
                Status = "Cancelled"
            });
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
            var filteredBookings = bookings.FindAll(b => b.Status == filter);
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
            // Main booking panel
            Panel panel = new Panel
            {
                Size = new Size(560, 170),
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(10),
                BackColor = Color.White
            };

            // Car icon
            Label carIcon = new Label
            {
                Text = "🚗",
                Font = new Font("Segoe UI Symbol", 16),
                Size = new Size(40, 40),
                Location = new Point(15, 15),
                TextAlign = ContentAlignment.MiddleCenter,
                BorderStyle = BorderStyle.FixedSingle
            };

            // Car title
            Label lblCarTitle = new Label
            {
                Text = $"{booking.CarMake} {booking.CarModel}",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                AutoSize = false,
                Size = new Size(300, 25),
                Location = new Point(70, 15)
            };

            // Pickup details
            Label lblPickupTitle = new Label
            {
                Text = "Pickup:",
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(15, 60)
            };

            Label lblPickupLocation = new Label
            {
                Text = booking.PickupLocation,
                Font = new Font("Segoe UI", 9),
                AutoSize = true,
                Location = new Point(70, 60)
            };

            Label lblPickupDate = new Label
            {
                Text = booking.PickupDate.ToString("MMM d, yyyy"),
                Font = new Font("Segoe UI", 9),
                AutoSize = true,
                Location = new Point(70, 80)
            };

            // Drop-off details - ADJUSTED POSITIONS
            Label lblDropOffTitle = new Label
            {
                Text = "Drop-off:",
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(280, 60)
            };

            Label lblDropOffLocation = new Label
            {
                Text = booking.DropoffLocation,
                Font = new Font("Segoe UI", 9),
                AutoSize = true,
                Location = new Point(352, 60)
            };

            Label lblDropOffDate = new Label
            {
                Text = booking.DropoffDate.ToString("MMM d, yyyy"),
                Font = new Font("Segoe UI", 9),
                AutoSize = true,
                Location = new Point(352, 80) // Adjusted to match the location label
            };

            // Status label
            Label lblStatus = new Label
            {
                Text = $"Status: {booking.Status}",
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(15, 130)
            };

            // Cancel Booking button
            Button btnCancelBooking = new Button
            {
                Text = "Cancel Booking",
                Size = new Size(120, 35),
                Location = new Point(420, 120),
                BackColor = Color.OrangeRed,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnCancelBooking.FlatAppearance.BorderSize = 0;
            btnCancelBooking.Tag = booking.Id;
            btnCancelBooking.Click += BtnCancelBooking_Click;

            // Only show cancel button for upcoming bookings
            if (booking.Status != "Upcoming")
            {
                btnCancelBooking.Visible = false;
            }

            // Add all controls to the panel
            panel.Controls.Add(carIcon);
            panel.Controls.Add(lblCarTitle);
            panel.Controls.Add(lblPickupTitle);
            panel.Controls.Add(lblPickupLocation);
            panel.Controls.Add(lblPickupDate);
            panel.Controls.Add(lblDropOffTitle);
            panel.Controls.Add(lblDropOffLocation);
            panel.Controls.Add(lblDropOffDate);
            panel.Controls.Add(lblStatus);
            panel.Controls.Add(btnCancelBooking);

            return panel;
        }

        private void BtnCancelBooking_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int bookingId = (int)btn.Tag;

            // Confirm cancellation with dialog
            DialogResult result = MessageBox.Show("Are you sure you want to cancel this booking?",
                                "Cancel Booking",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Find and update the booking
                var booking = bookings.Find(b => b.Id == bookingId);
                if (booking != null)
                {
                    booking.Status = "Cancelled";
                    MessageBox.Show("Booking has been cancelled successfully.",
                                   "Booking Cancelled",
                                   MessageBoxButtons.OK,
                                   MessageBoxIcon.Information);

                    // Refresh the current filter view
                    ApplyFilter(currentFilter);
                }
                else
                {
                    MessageBox.Show("Booking not found.",
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
                b.Status == currentFilter && (
                b.CarMake.ToLower().Contains(searchText) ||
                b.CarModel.ToLower().Contains(searchText) ||
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
    }

    public class BookingInfo
    {
        public int Id { get; set; }
        public string CarMake { get; set; }
        public string CarModel { get; set; }
        public string PickupLocation { get; set; }
        public DateTime PickupDate { get; set; }
        public string DropoffLocation { get; set; }
        public DateTime DropoffDate { get; set; }
        public string Status { get; set; }
    }
}
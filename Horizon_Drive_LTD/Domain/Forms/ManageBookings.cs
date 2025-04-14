using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

//ManageBookings.cs
namespace Horizon_Drive_LTD
{
    public partial class ManageBookings : Form
    {
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
            this.Hide();
        }

        private void btnManageBooking_Click(object sender, EventArgs e)
        {
            // Already on this page - refresh data
            LoadBookingData();
            ApplyFilter(currentFilter);
        }

        private void btnListCar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("List a Car functionality would open a form to add a new listing.",
                           "List a Car",
                           MessageBoxButtons.OK,
                           MessageBoxIcon.Information);
        }

        private void btnManageYourListings_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Manage Your Listings functionality would open a form to view and manage your car listings.",
                           "Manage Your Listings",
                           MessageBoxButtons.OK,
                           MessageBoxIcon.Information);
        }

        private void btnOptions_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Options functionality would open settings for the application.",
                           "Options",
                           MessageBoxButtons.OK,
                           MessageBoxIcon.Information);
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
            }
        }

        private void buttonProfile_Click(object sender, EventArgs e)
        {
            // Open the Options_Personal form
            Options_Personal optionsPersonalForm = new Options_Personal();
            optionsPersonalForm.Show();
            this.Hide();
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
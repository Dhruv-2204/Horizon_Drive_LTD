using Horizon_Drive_LTD.BusinessLogic;
using Horizon_Drive_LTD.BusinessLogic.Repositories;
using Horizon_Drive_LTD.Domain.Entities;
using Horizon_Drive_LTD.DataStructure;
using Manage_user_search_page;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Upload_cars;
using User_managing;
using Horizon_Drive_LTD.Domain.Forms;
using Microsoft.Data.SqlClient;
using splashscreen;

namespace WindowsFormsApp1
{
    public partial class AdminManageBookingsForm : Form
    {
        private BookingsRepository _bookingRepository;
        private List<BookingViewModel> _allBookings;
        private List<BookingViewModel> _filteredBookings;
        private DatabaseConnection _dbConnection;

        // View model to help with display and conversion
        private class BookingViewModel
        {
            
            public string BookingId { get; set; }
            public string UserId { get; set; }
            public string CarId { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
            public decimal TotalCost { get; set; } // This is calculated
            public string Status { get; set; }
            public string UserName { get; set; } // This might need to be fetched separately
            public string CarModel { get; set; } // This might need to be fetched separately

            // Additional properties from the original Booking
            public bool IncludeDriver { get; set; }
            public bool BabyCarSeat { get; set; }
            public bool FullInsuranceCoverage { get; set; }
            public bool RoofRack { get; set; }
            public bool AirportPickupDropoff { get; set; }
            public string PickupLocation { get; set; }
            public string DropoffLocation { get; set; }

            // Helper method to create from original Booking
            public static BookingViewModel FromBooking(Booking booking, string userName, string carModel)
            {
                // Calculate a simple total cost (you may want to make this more sophisticated)
                decimal baseCost = 50.0m; // Example base cost per day
                int days = (DateTime.Parse(booking.DropoffDate) - DateTime.Parse(booking.PickupDate)).Days;
                if (days < 1) days = 1;

                decimal totalCost = baseCost * days;

                // Add costs for additional services
                if (booking.IncludeDriver) totalCost += 25.0m * days;
                if (booking.BabyCarSeat) totalCost += 5.0m * days;
                if (booking.FullInsuranceCoverage) totalCost += 15.0m * days;
                if (booking.RoofRack) totalCost += 10.0m * days;
                if (booking.AirportPickupDropoff) totalCost += 30.0m;

                return new BookingViewModel
                {
                    BookingId = booking.BookingID,
                    UserId = booking.CustomerID,
                    CarId = booking.CarID,
                    StartDate = DateTime.Parse(booking.PickupDate),
                    EndDate = DateTime.Parse(booking.DropoffDate),
                    TotalCost = totalCost,
                    Status = booking.Status,
                    UserName = userName,
                    CarModel = carModel,
                    IncludeDriver = booking.IncludeDriver,
                    BabyCarSeat = booking.BabyCarSeat,
                    FullInsuranceCoverage = booking.FullInsuranceCoverage,
                    RoofRack = booking.RoofRack,
                    AirportPickupDropoff = booking.AirportPickupDropoff,
                    PickupLocation = booking.PickupLocation,
                    DropoffLocation = booking.DropoffLocation
                };
            }
        }

        public AdminManageBookingsForm()

        {
            InitializeComponent();
            this.FormClosing += Manage_User_Page_FormClosing;

            // Initialize repositories
            _dbConnection = new DatabaseConnection();
            _bookingRepository = new BookingsRepository(_dbConnection);
        }
        private bool isClosing = false;
        private void Manage_User_Page_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isClosing) return; // Prevent duplicate message box
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
                Application.Exit(); // Properly terminates the application without triggering FormClosing again
            }
        }

        private void ManageBookingsForm_Load(object sender, EventArgs e)
        {
            // Load the logo image
            LoadImage();

            // Set rounded corners for buttons
            SetRoundedCorner(Manage_users, 25);
            SetRoundedCorner(Upload_files, 25);
            SetRoundedCorner(Manage_bookings_btn, 25);
            SetRoundedCorner(Logout_btn, 25);
            SetRoundedCorner(Maintenance_btn, 25);
            SetRoundedCorner(btnSearch, 10);

            // Initialize date pickers
            dtpStartDate.Value = DateTime.Now.AddDays(-30);
            dtpEndDate.Value = DateTime.Now.AddDays(30);

            // Set up the DataGridView columns
            SetupDataGridView();

            // Initialize status dropdown
            cmbStatus.Items.Clear();
            cmbStatus.Items.Add("All");
            cmbStatus.Items.Add("Confirmed");
            cmbStatus.Items.Add("Canceled");
            cmbStatus.Items.Add("Completed");
            cmbStatus.SelectedIndex = 0;

            // Load all bookings
            LoadAllBookings();
        }


        private void SetupDataGridView()
        {
            // Configure the DataGridView
            dataGridView2.AutoGenerateColumns = false;
            dataGridView2.ReadOnly = true;
            dataGridView2.RowHeadersVisible = false;
            dataGridView2.MultiSelect = false;
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.RowTemplate.Height = 40;
            dataGridView2.BackgroundColor = Color.White;

            // Clear existing columns
            dataGridView2.Columns.Clear();

            // Add columns
            DataGridViewTextBoxColumn bookingIdColumn = new DataGridViewTextBoxColumn();
            bookingIdColumn.Name = "BookingId";
            bookingIdColumn.HeaderText = "Booking ID";
            bookingIdColumn.Width = 80;
            dataGridView2.Columns.Add(bookingIdColumn);

            DataGridViewTextBoxColumn userNameColumn = new DataGridViewTextBoxColumn();
            userNameColumn.Name = "UserName";
            userNameColumn.HeaderText = "User";
            userNameColumn.Width = 100;
            dataGridView2.Columns.Add(userNameColumn);

            DataGridViewTextBoxColumn carModelColumn = new DataGridViewTextBoxColumn();
            carModelColumn.Name = "CarModel";
            carModelColumn.HeaderText = "Car";
            carModelColumn.Width = 100;
            dataGridView2.Columns.Add(carModelColumn);

            DataGridViewTextBoxColumn startDateColumn = new DataGridViewTextBoxColumn();
            startDateColumn.Name = "StartDate";
            startDateColumn.HeaderText = "Pickup Date";
            startDateColumn.Width = 100;
            dataGridView2.Columns.Add(startDateColumn);

            DataGridViewTextBoxColumn endDateColumn = new DataGridViewTextBoxColumn();
            endDateColumn.Name = "EndDate";
            endDateColumn.HeaderText = "Dropoff Date";
            endDateColumn.Width = 100;
            dataGridView2.Columns.Add(endDateColumn);

            DataGridViewTextBoxColumn totalCostColumn = new DataGridViewTextBoxColumn();
            totalCostColumn.Name = "TotalCost";
            totalCostColumn.HeaderText = "Total Cost";
            totalCostColumn.Width = 80;
            dataGridView2.Columns.Add(totalCostColumn);

            DataGridViewTextBoxColumn statusColumn = new DataGridViewTextBoxColumn();
            statusColumn.Name = "Status";
            statusColumn.HeaderText = "Status";
            statusColumn.Width = 80;
            dataGridView2.Columns.Add(statusColumn);

            // Add a cancel button column
            DataGridViewButtonColumn cancelButtonColumn = new DataGridViewButtonColumn();
            cancelButtonColumn.Name = "CancelButton";
            cancelButtonColumn.HeaderText = "Actions";
            cancelButtonColumn.Text = "Cancel";
            cancelButtonColumn.UseColumnTextForButtonValue = true;
            cancelButtonColumn.Width = 70;
            dataGridView2.Columns.Add(cancelButtonColumn);

            // Apply styling
            dataGridView2.RowsDefaultCellStyle.BackColor = Color.White;
            dataGridView2.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
            dataGridView2.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView2.DefaultCellStyle.SelectionBackColor = Color.FromArgb(45, 68, 135);
            dataGridView2.DefaultCellStyle.SelectionForeColor = Color.White;

            // Apply dark blue color to table headers (matching user management page)
            dataGridView2.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 48, 65);
            dataGridView2.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView2.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dataGridView2.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView2.ColumnHeadersHeight = 40;
            dataGridView2.EnableHeadersVisualStyles = false;
        }

        private void LoadAllBookings()
        {
            try
            {
                // Load bookings from the hash table
                HashTable<string, Booking> bookingHashTable = _bookingRepository.LoadBookingsFromDatabase();

                // Convert to a list of BookingViewModel
                _allBookings = new List<BookingViewModel>();

                foreach (var booking in bookingHashTable.Values())
                {
                    // Here you would ideally fetch user and car details from the appropriate repositories
                    // For now, we'll use placeholder values or data from the booking
                    string userName = "User " + booking.CustomerID; // Replace with actual user name lookup
                    string carModel = "Car " + booking.CarID; // Replace with actual car model lookup

                    _allBookings.Add(BookingViewModel.FromBooking(booking, userName, carModel));
                }

                ApplyFilters();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading bookings: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ApplyFilters()
        {
            if (_allBookings == null)
                return;

            // Apply filters
            _filteredBookings = _allBookings.ToList(); // Start with all bookings

            // Filter by status
            if (cmbStatus.SelectedItem != null && cmbStatus.SelectedItem.ToString() != "All")
            {
                string status = cmbStatus.SelectedItem.ToString();
                _filteredBookings = _filteredBookings.Where(b => b.Status == status).ToList();
            }

            // Filter by date range
            DateTime startDate = dtpStartDate.Value.Date;
            DateTime endDate = dtpEndDate.Value.Date.AddDays(1).AddSeconds(-1); // End of the selected day
            _filteredBookings = _filteredBookings.Where(b =>
                (b.StartDate >= startDate && b.StartDate <= endDate) ||
                (b.EndDate >= startDate && b.EndDate <= endDate) ||
                (b.StartDate <= startDate && b.EndDate >= endDate)).ToList();

            // Filter by search text
            if (!string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                string searchTerm = txtSearch.Text.ToLower();
                _filteredBookings = _filteredBookings.Where(b =>
                    b.BookingId.ToLower().Contains(searchTerm) ||
                    b.UserName.ToLower().Contains(searchTerm) ||
                    b.CarModel.ToLower().Contains(searchTerm)).ToList();
            }

            // Display filtered bookings
            DisplayBookings(_filteredBookings);
        }

        private void DisplayBookings(List<BookingViewModel> bookings)
        {
            // Clear existing rows
            dataGridView2.Rows.Clear();

            // Add each booking to the DataGridView
            foreach (var booking in bookings)
            {
                int rowIndex = dataGridView2.Rows.Add(
                    booking.BookingId,
                    booking.UserName,
                    booking.CarModel,
                    booking.StartDate.ToShortDateString(),
                    booking.EndDate.ToShortDateString(),
                    $"£{booking.TotalCost:F2}",
                    booking.Status
                );

                // Set button text based on booking status
                DataGridViewButtonCell buttonCell = dataGridView2.Rows[rowIndex].Cells["CancelButton"] as DataGridViewButtonCell;
                if (booking.Status == "Canceled" || booking.Status == "Completed")
                {
                    buttonCell.Value = "View";
                    buttonCell.FlatStyle = FlatStyle.Flat;
                    dataGridView2.Rows[rowIndex].DefaultCellStyle.BackColor =
                        booking.Status == "Canceled" ? Color.LightPink : Color.LightGreen;
                }
                else
                {
                    buttonCell.Value = "Cancel";
                    buttonCell.FlatStyle = FlatStyle.Flat;
                }
            }

            // Update UI to show number of bookings
            Search_Users.Text = $"Manage Bookings ({bookings.Count})";
        }

        // Method to update booking status directly in the database
        private bool UpdateBookingStatus(string bookingId, string newStatus)
        {
            try
            {
                using (SqlConnection conn = _dbConnection.GetConnection())
                {
                    conn.Open();
                    string query = "UPDATE Booking SET BookingStatus = @Status WHERE BookingID = @BookingID";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@BookingID", bookingId);
                        cmd.Parameters.AddWithValue("@Status", newStatus);
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception)
            {
                throw; // Re-throw to be handled by caller
            }
        }

        private void DataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if the clicked cell is in the button column and not the header
            if (e.ColumnIndex == dataGridView2.Columns["CancelButton"].Index && e.RowIndex >= 0)
            {
                // Get the booking ID from the selected row
                string bookingId = dataGridView2.Rows[e.RowIndex].Cells["BookingId"].Value.ToString();
                string status = dataGridView2.Rows[e.RowIndex].Cells["Status"].Value.ToString();

                if (status == "Canceled" || status == "Completed")
                {
                    // Show booking details
                    ShowBookingDetails(bookingId);
                }
                else
                {
                    // Ask for confirmation
                    DialogResult result = MessageBox.Show(
                        "Are you sure you want to cancel this booking?",
                        "Confirm Cancellation",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );

                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            // Update the booking status directly in the database
                            bool success = UpdateBookingStatus(bookingId, "Canceled");

                            if (success)
                            {
                                MessageBox.Show(
                                    "Booking has been canceled successfully.",
                                    "Success",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information
                                );

                                // Refresh the bookings list
                                LoadAllBookings();
                            }
                            else
                            {
                                MessageBox.Show(
                                    "Failed to cancel the booking. No records were updated.",
                                    "Error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error
                                );
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(
                                "Failed to cancel the booking: " + ex.Message,
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error
                            );
                        }
                    }
                }
            }
        }

        private void ShowBookingDetails(string bookingId)
        {
            // Find the booking
            BookingViewModel booking = _allBookings.FirstOrDefault(b => b.BookingId == bookingId);

            if (booking != null)
            {
                // Build a detailed message with all booking information
                string message = $"Booking ID: {booking.BookingId}\n" +
                                $"User: {booking.UserName} (ID: {booking.UserId})\n" +
                                $"Car: {booking.CarModel} (ID: {booking.CarId})\n" +
                                $"Pickup Date: {booking.StartDate}\n" +
                                $"Dropoff Date: {booking.EndDate}\n" +
                                $"Duration: {(booking.EndDate - booking.StartDate).TotalDays} days\n" +
                                $"Pickup Location: {booking.PickupLocation}\n" +
                                $"Dropoff Location: {booking.DropoffLocation}\n" +
                                $"Total Cost: £{booking.TotalCost:F2}\n" +
                                $"Status: {booking.Status}\n\n" +
                                $"Additional Services:\n" +
                                $"- Driver Included: {(booking.IncludeDriver ? "Yes" : "No")}\n" +
                                $"- Baby Car Seat: {(booking.BabyCarSeat ? "Yes" : "No")}\n" +
                                $"- Full Insurance: {(booking.FullInsuranceCoverage ? "Yes" : "No")}\n" +
                                $"- Roof Rack: {(booking.RoofRack ? "Yes" : "No")}\n" +
                                $"- Airport Pickup/Dropoff: {(booking.AirportPickupDropoff ? "Yes" : "No")}";

                MessageBox.Show(
                    message,
                    "Booking Details",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void dtpStartDate_ValueChanged(object sender, EventArgs e)
        {
            if (dtpStartDate.Value > dtpEndDate.Value)
            {
                MessageBox.Show("Start date cannot be later than end date.", "Invalid Date Range",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpStartDate.Value = dtpEndDate.Value.AddDays(-1);
                return;
            }

            ApplyFilters();
        }

        private void dtpEndDate_ValueChanged(object sender, EventArgs e)
        {
            if (dtpEndDate.Value < dtpStartDate.Value)
            {
                MessageBox.Show("End date cannot be earlier than start date.", "Invalid Date Range",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpEndDate.Value = dtpStartDate.Value.AddDays(1);
                return;
            }

            ApplyFilters();
        }

        // Your existing methods
        private void Upload_Cars_btn_Click(object sender, EventArgs e)
        {
            var manage_files_Page = new Admin_Managing_files();
            manage_files_Page.Show();
            this.Dispose();
        }

        private void SetRoundedCorner(Button button, int radius)
        {
            Rectangle bounds = button.ClientRectangle;
            int diameter = radius * 2;
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(bounds.X, bounds.Y, diameter, diameter, 180, 90);
            path.AddArc(bounds.Right - diameter, bounds.Y, diameter, diameter, 270, 90);
            path.AddArc(bounds.Right - diameter, bounds.Bottom - diameter, diameter, diameter, 0, 90);
            path.AddArc(bounds.X, bounds.Bottom - diameter, diameter, diameter, 90, 90);
            path.CloseFigure();
            button.Region = new Region(path);
        }

        private void LoadImage()
        {
            string imagePath = Path.Combine(Application.StartupPath, "Media", "Images", "HORIZONDRIVE_LOGO.png");
            if (File.Exists(imagePath))
            {
                pictureBox1.Image = Image.FromFile(imagePath);
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            }
            else
            {
                MessageBox.Show("Image not found at: " + imagePath);
            }
        }

        private void Manage_users_Click(object sender, EventArgs e)
        {
            var manage_user_Page = new Manage_User_Page();
            manage_user_Page.Show();
            this.Dispose();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // Navigate to dashboard or home page if implemented
        }

        private void Logout_btn_Click(object sender, EventArgs e)
        {
            // Implement logout functionality
            DialogResult result = MessageBox.Show(
                "Are you sure you want to log out?",
                "Confirm Logout",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                var login = new Login();
                login.Show();
                this.Hide();
                
            }
        }

        private void Maintenance_btn_Click(object sender, EventArgs e)
        {
            var maintenance_Page = new AdminMaintenance();
            maintenance_Page.Show();
            this.Dispose();
        }
    }
}
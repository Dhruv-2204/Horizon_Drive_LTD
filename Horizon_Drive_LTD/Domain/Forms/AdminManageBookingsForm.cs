using Horizon_Drive_LTD.BusinessLogic;
using Horizon_Drive_LTD.BusinessLogic.Repositories;
using Horizon_Drive_LTD.Domain.Entities;
using Horizon_Drive_LTD.Domain.Forms;
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

namespace WindowsFormsApp1
{
    public partial class AdminManageBookingsForm : Form
    {
        private BookingRepository _bookingRepository;
        private List<Booking> _allBookings;
        private List<Booking> _filteredBookings;

        public AdminManageBookingsForm()
        {
            InitializeComponent();

            // Initialize repositories
            DatabaseConnection dbConnection = new DatabaseConnection(); // You'll need to pass the connection string
            _bookingRepository = new BookingRepository(dbConnection);
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
    startDateColumn.HeaderText = "Start Date";
    startDateColumn.Width = 100;
    dataGridView2.Columns.Add(startDateColumn);

    DataGridViewTextBoxColumn endDateColumn = new DataGridViewTextBoxColumn();
    endDateColumn.Name = "EndDate";
    endDateColumn.HeaderText = "End Date";
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
                _allBookings = _bookingRepository.GetAllBookings();
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

        private void DisplayBookings(List<Booking> bookings)
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
                        // Cancel the booking
                        bool success = _bookingRepository.CancelBooking(bookingId);

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
                                "Failed to cancel the booking. Please try again.",
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
            Booking booking = _allBookings.FirstOrDefault(b => b.BookingId == bookingId);

            if (booking != null)
            {
                // Create a message with all booking details
                string message = $"Booking ID: {booking.BookingId}\n" +
                                $"User: {booking.UserName} (ID: {booking.UserId})\n" +
                                $"Car: {booking.CarModel} (ID: {booking.CarId})\n" +
                                $"Start Date: {booking.StartDate}\n" +
                                $"End Date: {booking.EndDate}\n" +
                                $"Duration: {(booking.EndDate - booking.StartDate).TotalDays} days\n" +
                                $"Total Cost: £{booking.TotalCost:F2}\n" +
                                $"Status: {booking.Status}";

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
            var manage_car_Page = new Managing_files();
            manage_car_Page.Show();
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
                // Navigate to login form
                // LoginForm loginForm = new LoginForm();
                // loginForm.Show();
                this.Close();
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
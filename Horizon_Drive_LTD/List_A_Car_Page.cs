using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace Horizon_Drive_LTD
{
    public partial class List_A_Car_Page : Form
    {
        // Assuming CarListing is a model class for car listings
        private List<CarListing> carListings;

        public List_A_Car_Page()
        {
            InitializeComponent();
            this.Size = new Size(1920, 1080);

            // Create buttons dynamically and add them to the form
            var btnViewDeal = CreateRoundedButton("View Deal", 20, Color.Blue, Color.White);
            btnViewDeal.Click += BtnViewDeal_Click;
            btnViewDeal.Tag = 1;  // Example carId
            this.Controls.Add(btnViewDeal);

            var btnBrowseListings = CreateRoundedButton("Browse Listings", 80, Color.Green, Color.White);
            btnBrowseListings.Click += btnBrowseListings_Click;
            this.Controls.Add(btnBrowseListings);

            var btnListCar = CreateRoundedButton("List a Car", 140, Color.Orange, Color.White);
            btnListCar.Click += btnListCar_Click;
            this.Controls.Add(btnListCar);

            var btnManageBooking = CreateRoundedButton("Manage Booking", 200, Color.Purple, Color.White);
            btnManageBooking.Click += btnManageBooking_Click;
            this.Controls.Add(btnManageBooking);

            var btnOptions = CreateRoundedButton("Options", 260, Color.Gray, Color.White);
            btnOptions.Click += btnOptions_Click;
            this.Controls.Add(btnOptions);
        }

        private RoundedButton CreateRoundedButton(string text, int yPosition, Color backColor, Color textColor)
        {
            return new RoundedButton
            {
                Size = new Size(200, 50),
                Location = new Point(25, yPosition),
                Text = text,
                BackColor = backColor,
                ForeColor = textColor,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 12, FontStyle.Regular)
            };
        }

        // Event handler for the "View Deal" button
        private void BtnViewDeal_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int carId = (int)btn.Tag;

            // Find the car
            CarListing selectedCar = carListings.FirstOrDefault(c => c.Id == carId);

            if (selectedCar != null)
            {
                // Open the booking form or show details
                MessageBox.Show($"You selected: {selectedCar.Make} {selectedCar.Model}\n" +
                               $"Price: Rs {selectedCar.PricePerDay}/day",
                               "View Deal",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Information);
            }
        }

        // Event handler for browsing listings
        private void btnBrowseListings_Click(object sender, EventArgs e)
        {
            // Already on the listings page, could refresh or apply filters
            PopulateCarListings();
        }

        // Event handler for listing a new car
        private void btnListCar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("List a Car functionality would open a form to add a new listing.",
                            "List a Car",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
        }

        // Event handler for managing bookings
        private void btnManageBooking_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Manage Booking functionality would open a form to view and manage bookings.",
                            "Manage Bookings",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
        }

        // Event handler for options/settings
        private void btnOptions_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Options functionality would open settings for the application.",
                            "Options",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
        }

        // Method to populate car listings (example placeholder)
        private void PopulateCarListings()
        {
            // Logic to populate car listings goes here
        }

        private void txtLicensePlate_TextChanged(object sender, EventArgs e)
        {

        }

        private void contentPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }

    // Sample CarListing class, adjust according to your model
    public class CarListing
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public decimal PricePerDay { get; set; }
    }

    // Custom button class with rounded corners
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
}
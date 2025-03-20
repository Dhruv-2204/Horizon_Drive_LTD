using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace Horizon_Drive_LTD
{
    public partial class Manage_Listings : Form
    {
        private List<CarListing> carListings;

        public Manage_Listings()
        {
            InitializeComponent();
            this.Size = new Size(1920, 1080);

            var btnBrowseListings = CreateRoundedButton("Browse Listings", 80, Color.Green, Color.White);
            btnBrowseListings.Click += BtnBrowseListings_Click;
            this.Controls.Add(btnBrowseListings);

            var btnManageBooking = CreateRoundedButton("Manage Booking", 200, Color.Purple, Color.White);
            btnManageBooking.Click += BtnManageBooking_Click;
            this.Controls.Add(btnManageBooking);

            var btnListCar = CreateRoundedButton("List a Car", 140, Color.Orange, Color.White);
            btnListCar.Click += BtnListCar_Click;
            this.Controls.Add(btnListCar);

            var btnManageYourListings = CreateRoundedButton("Manage Your Listings", 320, Color.Red, Color.White);
            btnManageYourListings.Click += BtnManageYourListings_Click;
            this.Controls.Add(btnManageYourListings);

            var btnOptions = CreateRoundedButton("Options", 260, Color.Gray, Color.White);
            btnOptions.Click += BtnOptions_Click;
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

        private void BtnBrowseListings_Click(object sender, EventArgs e) => PopulateCarListings();
        private void BtnManageBooking_Click(object sender, EventArgs e) => MessageBox.Show("Open booking management form.", "Manage Bookings", MessageBoxButtons.OK, MessageBoxIcon.Information);
        private void BtnListCar_Click(object sender, EventArgs e) => MessageBox.Show("Open form to add a new listing.", "List a Car", MessageBoxButtons.OK, MessageBoxIcon.Information);
        private void BtnManageYourListings_Click(object sender, EventArgs e) => MessageBox.Show("Open your listings management form.", "Manage Your Listings", MessageBoxButtons.OK, MessageBoxIcon.Information);
        private void BtnOptions_Click(object sender, EventArgs e) => MessageBox.Show("Open settings.", "Options", MessageBoxButtons.OK, MessageBoxIcon.Information);
        private void PopulateCarListings() { }

        private void btnManageYourListings_Click_1(object sender, EventArgs e)
        {

        }
    }

    public class CarListing
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public decimal PricePerDay { get; set; }
    }

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
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            GraphicsPath path = new GraphicsPath();
            Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);
            int diameter = borderRadius * 2;
            path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90);
            path.AddArc(rect.Width - diameter, rect.Y, diameter, diameter, 270, 90);
            path.AddArc(rect.Width - diameter, rect.Height - diameter, diameter, diameter, 0, 90);
            path.AddArc(rect.X, rect.Height - diameter, diameter, diameter, 90, 90);
            path.CloseAllFigures();
            this.Region = new Region(path);
            base.OnPaint(e);
        }
    }
}

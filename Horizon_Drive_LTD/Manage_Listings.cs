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

            // Dynamic boxes for displaying information
            CreateDynamicBox("Your Listings", "2", new Point(30, 80), Color.LightBlue);
            CreateDynamicBox("Current Reservations", "1", new Point(360, 80), Color.LightBlue);
            CreateDynamicBox("Total Earnings", "MUR 150000", new Point(690, 80), Color.LightBlue);

            // Sidebar buttons
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
                Font = new Font("Segoe UI", 12, FontStyle.Regular),
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
            };
        }

        private void CreateDynamicBox(string title, string value, Point location, Color backColor)
        {
            Panel panel = new Panel
            {
                Location = location,
                Size = new Size(300, 150),
                BackColor = backColor,
                BorderStyle = BorderStyle.FixedSingle,
                Anchor = AnchorStyles.Top | AnchorStyles.Left
            };

            Label titleLabel = new Label
            {
                Text = title,
                Font = new Font("Segoe UI", 12F, FontStyle.Regular),
                Location = new Point(20, 20),
                Size = new Size(260, 30),
                ForeColor = Color.Black
            };

            Label valueLabel = new Label
            {
                Text = value,
                Font = new Font("Segoe UI", 24F, FontStyle.Bold),
                Location = new Point(20, 60),
                Size = new Size(260, 50),
                ForeColor = Color.Black
            };

            panel.Controls.Add(titleLabel);
            panel.Controls.Add(valueLabel);
            this.Controls.Add(panel);
        }

        private void BtnBrowseListings_Click(object sender, EventArgs e) => PopulateCarListings();
        private void BtnManageBooking_Click(object sender, EventArgs e) => MessageBox.Show("Open booking management form.", "Manage Bookings", MessageBoxButtons.OK, MessageBoxIcon.Information);
        private void BtnListCar_Click(object sender, EventArgs e) => MessageBox.Show("Open form to add a new listing.", "List a Car", MessageBoxButtons.OK, MessageBoxIcon.Information);
        private void BtnManageYourListings_Click(object sender, EventArgs e) => MessageBox.Show("Open your listings management form.", "Manage Your Listings", MessageBoxButtons.OK, MessageBoxIcon.Information);
        private void BtnOptions_Click(object sender, EventArgs e) => MessageBox.Show("Open settings.", "Options", MessageBoxButtons.OK, MessageBoxIcon.Information);
        private void PopulateCarListings() { }

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
}

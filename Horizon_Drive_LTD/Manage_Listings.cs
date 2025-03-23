using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Horizon_Drive_LTD
{
    public partial class Manage_Listings : Form
    {
        private List<CarListing> carListings; // List of cars to display

        public Manage_Listings()
        {
            InitializeComponent();

            // Sample car data
            carListings = new List<CarListing>
            {
                new CarListing { Id = 1, Make = "Ford", Model = "Raptor (2023)", PricePerDay = 15000, Status = "Active" },
                new CarListing { Id = 2, Make = "BMW", Model = "XM (2025)", PricePerDay = 20000, Status = "Reserved" }
            };

            // Create the dynamic car list under the summary boxes
            CreateDynamicCarList();
        }

        private void CreateDynamicCarList()
        {
            // Set up the FlowLayoutPanel for vertical stacking
            flowLayoutPanelListings.FlowDirection = FlowDirection.TopDown; // Ensure vertical stacking
            flowLayoutPanelListings.WrapContents = false; // Prevent horizontal wrapping
            flowLayoutPanelListings.AutoScroll = true; // Allow scrolling

            foreach (var car in carListings)
            {
                // Create a panel for each car
                Panel carPanel = new Panel
                {
                    Size = new Size(400, 100),
                    Margin = new Padding(10),
                    BackColor = Color.LightGray,
                    BorderStyle = BorderStyle.FixedSingle
                };

                // Create the status square box
                Panel statusBox = new Panel
                {
                    Size = new Size(70, 20),
                    Location = new Point(320, 5), // Top-right corner
                    BackColor = car.Status == "Active" ? Color.LightGreen : Color.LightBlue // Pastel colors
                };

                // Add status text inside the box
                Label statusLabel = new Label
                {
                    Text = car.Status == "Active" ? "Active" : "Reserved",
                    Font = new Font("Segoe UI", 7F, FontStyle.Regular),
                    ForeColor = Color.Black,
                    Location = new Point(2, 2), // Center the text inside the box
                    AutoSize = true,
                    TextAlign = ContentAlignment.MiddleCenter
                };

                statusBox.Controls.Add(statusLabel);

                // Add car title label
                Label carTitleLabel = new Label
                {
                    Text = $"{car.Make} {car.Model}",
                    Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                    Location = new Point(10, 10),
                    Size = new Size(360, 30)
                };

                // Add car price per day
                Label carPriceLabel = new Label
                {
                    Text = $"MUR {car.PricePerDay}/day",
                    Font = new Font("Segoe UI", 10F, FontStyle.Regular),
                    Location = new Point(10, 40),
                    Size = new Size(180, 30)
                };

                // Add "Delete" button if status is "Active"
                if (car.Status == "Active")
                {
                    Button deleteButton = new Button
                    {
                        Text = "Delete",
                        Font = new Font("Segoe UI", 8F, FontStyle.Bold),
                        BackColor = Color.Red,
                        ForeColor = Color.White,
                        Location = new Point(300, 60), // Bottom-right corner
                        Size = new Size(80, 30),
                        FlatStyle = FlatStyle.Flat
                    };

                    deleteButton.Click += (sender, e) => DeleteCar(car, carPanel);

                    carPanel.Controls.Add(deleteButton);
                }

                // Add components to the car panel
                carPanel.Controls.Add(statusBox);
                carPanel.Controls.Add(carTitleLabel);
                carPanel.Controls.Add(carPriceLabel);

                // Add car panel to the FlowLayoutPanel
                flowLayoutPanelListings.Controls.Add(carPanel);
            }
        }

        // Method to handle car deletion
        private void DeleteCar(CarListing car, Panel carPanel)
        {
            // Confirm deletion
            var confirmResult = MessageBox.Show(
                $"Are you sure you want to delete {car.Make} {car.Model}?",
                "Confirm Deletion",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (confirmResult == DialogResult.Yes)
            {
                // Remove the car from the list and panel
                carListings.Remove(car);
                flowLayoutPanelListings.Controls.Remove(carPanel);

                MessageBox.Show($"{car.Make} {car.Model} has been deleted.", "Car Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public class CarListing
        {
            public int Id { get; set; }
            public string Make { get; set; }
            public string Model { get; set; }
            public decimal PricePerDay { get; set; }
            public string Status { get; set; }
        }
    }
}

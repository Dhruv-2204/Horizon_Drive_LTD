using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Horizon_Drive_LTD
{
    public partial class ManageYourListings : Form
    {
        // TransactionHistory class to store transaction data
        public class TransactionHistory
        {
            public int Id { get; set; }
            public int CarId { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
            public decimal RentalPrice { get; set; }
            public string Status { get; set; }
        }

        // Model class for car listings
        public class CarListing
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public decimal Price { get; set; }
            public string Status { get; set; }
            public string[] Features { get; set; }
            public string ImagePath { get; set; }
        }

        public ManageYourListings()
        {
            InitializeComponent();

            // Set client size and minimum size
            this.ClientSize = new Size(1600, 900);
            this.MinimumSize = new Size(1000, 700);

            // Load data dynamically
            LoadCarListingsFromDatabase();
            LoadTransactionsFromDatabase();

            // Initially hide the "no more cars" label since we'll show it conditionally
            labelNoMoreListings.Visible = false;
        }

        // Method to load car listings from database
        private void LoadCarListingsFromDatabase()
        {
            // Clear existing static car listings
            if (panelContent.Controls.Contains(panelCarListing1))
                panelContent.Controls.Remove(panelCarListing1);

            if (panelContent.Controls.Contains(panelCarListing2))
                panelContent.Controls.Remove(panelCarListing2);

            // In a real implementation, you would fetch data from the database
            // For example:
            // var carListings = _carListingService.GetCarListingsByUserId(currentUserId);

            // For demo purposes, we'll create a sample list
            var sampleCarListings = new List<CarListing>
            {
                new CarListing {
                    Id = 1,
                    Title = "Ford Raptor (2023)",
                    Price = 15000,
                    Status = "Active",
                    Features = new[] { "GPS", "Bluetooth", "Leather Seat", "Sunroof" },
                    ImagePath = "Fordraptor.jpg"
                },
                new CarListing {
                    Id = 2,
                    Title = "BMW XM (2025)",
                    Price = 30000,
                    Status = "Reserved",
                    Features = new[] { "GPS", "Bluetooth", "Leather Seat", "Sunroof" },
                    ImagePath = "bmw_xm.jpg"
                }
                // Add more sample cars as needed
            };

            // Keep track of vertical position for dynamic placement
            int verticalPosition = 31; // Initial padding

            // Create and add car listing panels dynamically
            foreach (var car in sampleCarListings)
            {
                Panel carPanel = CreateCarListingPanel(car, verticalPosition);
                panelContent.Controls.Add(carPanel);
                verticalPosition += carPanel.Height + 10; // Add some spacing between panels
            }

            // Show "no more listings" message if no cars are available
            if (sampleCarListings.Count == 0)
            {
                labelNoMoreListings.Location = new Point(27, verticalPosition);
                labelNoMoreListings.Visible = true;
            }
            else
            {
                labelNoMoreListings.Visible = false;
            }

            // Update the transaction history section starting position
            labelTransactionHistory.Location = new Point(27, verticalPosition + 20);

            // Update counts in the header
            lblListingsCount.Text = sampleCarListings.Count.ToString();
            lblReservationsCount.Text = sampleCarListings.Count(c => c.Status == "Reserved").ToString();
        }

        // Method to create a car listing panel
        private Panel CreateCarListingPanel(CarListing car, int yPosition)
        {
            // Create main panel
            Panel panel = new Panel
            {
                BorderStyle = BorderStyle.FixedSingle,
                Location = new Point(27, yPosition),
                Size = new Size(1055, 133),
                Name = $"panelCarListing{car.Id}"
            };

            // Create and add car image
            PictureBox pictureBox = new PictureBox
            {
                BackColor = Color.LightGray,
                Location = new Point(11, 13),
                Size = new Size(126, 107),
                SizeMode = PictureBoxSizeMode.Zoom,
                Name = $"pictureBoxCar{car.Id}"
            };

            // Try to load the image if it exists
            try
            {
                if (File.Exists(Path.Combine("Images", car.ImagePath)))
                {
                    pictureBox.Image = Image.FromFile(Path.Combine("Images", car.ImagePath));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading image: {ex.Message}");
            }

            // Create title label
            Label titleLabel = new Label
            {
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                Location = new Point(149, 13),
                Size = new Size(343, 27),
                Text = car.Title,
                Name = $"lblCar{car.Id}Title"
            };

            // Create price label
            Label priceLabel = new Label
            {
                Font = new Font("Segoe UI", 9F),
                Location = new Point(149, 47),
                Size = new Size(343, 27),
                Text = $"MUR {car.Price} / day",
                Name = $"lblCar{car.Id}Price"
            };

            // Create status label
            Label statusLabel = new Label
            {
                BackColor = car.Status == "Active" ? Color.LimeGreen : Color.LightBlue,
                Font = new Font("Segoe UI", 9F),
                Location = new Point(941, 13),
                Size = new Size(91, 27),
                Text = car.Status,
                TextAlign = ContentAlignment.MiddleCenter,
                Name = $"lblCar{car.Id}Status"
            };

            // Create features panel
            Panel featuresPanel = new Panel
            {
                Location = new Point(149, 80),
                Size = new Size(343, 40),
                Name = $"panelCar{car.Id}Features"
            };

            // Add feature labels to the panel
            int featureX = 0;
            for (int i = 0; i < car.Features.Length && i < 4; i++)
            {
                Label featureLabel = new Label
                {
                    AutoSize = true,
                    BackColor = Color.LightGray,
                    BorderStyle = BorderStyle.FixedSingle,
                    Font = new Font("Segoe UI", 8F),
                    Location = new Point(featureX, 7),
                    Padding = new Padding(6, 3, 6, 3),
                    Text = car.Features[i],
                    Name = $"lblCar{car.Id}Feature{i + 1}"
                };

                featuresPanel.Controls.Add(featureLabel);
                featureX += featureLabel.Width + 6;
            }

            // Create delete button
            Button deleteButton = new Button
            {
                BackColor = Color.OrangeRed,
                FlatStyle = FlatStyle.Flat,
                ForeColor = Color.White,
                Location = new Point(941, 80),
                Size = new Size(91, 40),
                Text = "Delete",
                Name = $"btnDeleteCar{car.Id}"
            };

            // Add event handler to the delete button
            deleteButton.Click += BtnDelete_Click;
            deleteButton.FlatAppearance.BorderSize = 0;

            // Add all controls to the panel
            panel.Controls.Add(pictureBox);
            panel.Controls.Add(titleLabel);
            panel.Controls.Add(priceLabel);
            panel.Controls.Add(statusLabel);
            panel.Controls.Add(featuresPanel);
            panel.Controls.Add(deleteButton);

            return panel;
        }

        // Method to load transactions from database
        private void LoadTransactionsFromDatabase()
        {
            // Clear existing static transaction panels
            if (panelContent.Controls.Contains(panelTransaction1))
                panelContent.Controls.Remove(panelTransaction1);

            if (panelContent.Controls.Contains(panelTransaction2))
                panelContent.Controls.Remove(panelTransaction2);

            // In a real implementation, you would fetch data from the database
            // For example:
            // var transactions = _transactionService.GetTransactionsByUserId(currentUserId);

            // For demo purposes, we'll create a sample list
            var sampleTransactions = new List<TransactionHistory>
            {
                new TransactionHistory {
                    Id = 1,
                    CarId = 1,
                    StartDate = new DateTime(2025, 3, 15),
                    EndDate = new DateTime(2025, 6, 15),
                    RentalPrice = 15000,
                    Status = "Finished"
                },
                new TransactionHistory {
                    Id = 2,
                    CarId = 2,
                    StartDate = new DateTime(2025, 2, 15),
                    EndDate = new DateTime(2025, 2, 22),
                    RentalPrice = 30000,
                    Status = "Finished"
                }
                // Add more sample transactions as needed
            };

            // Find the position after the transaction history label
            int verticalPosition = labelTransactionHistory.Location.Y + labelTransactionHistory.Height + 20;

            // Create and add transaction panels dynamically
            foreach (var transaction in sampleTransactions)
            {
                Panel transactionPanel = CreateTransactionPanel(transaction, verticalPosition);
                panelContent.Controls.Add(transactionPanel);
                verticalPosition += transactionPanel.Height + 10; // Add some spacing between panels
            }

            // Show "no more history" message if no transactions are available, otherwise position it correctly
            if (sampleTransactions.Count == 0)
            {
                labelNoMoreHistory.Visible = false;
            }
            else
            {
                labelNoMoreHistory.Location = new Point(27, verticalPosition);
                labelNoMoreHistory.Visible = true;
            }

            // Update total earnings
            decimal totalEarnings = sampleTransactions.Sum(t => t.RentalPrice);
            lblEarningsAmount.Text = $"MUR {totalEarnings}";
        }

        // Method to create a transaction panel
        private Panel CreateTransactionPanel(TransactionHistory transaction, int yPosition)
        {
            // Create main panel
            Panel panel = new Panel
            {
                BorderStyle = BorderStyle.FixedSingle,
                Location = new Point(27, yPosition),
                Size = new Size(1057, 159),
                Name = $"panelTransaction{transaction.Id}"
            };

            // Create and add car image
            PictureBox pictureBox = new PictureBox
            {
                BackColor = Color.LightGray,
                Location = new Point(11, 13),
                Size = new Size(126, 107),
                SizeMode = PictureBoxSizeMode.Zoom,
                Name = $"pictureBoxTransaction{transaction.Id}"
            };

            // Try to load the image if it exists - in a real app, you'd look up the car details
            try
            {
                string imagePath = transaction.CarId == 1 ? "Fordraptor.jpg" : "bmw_xm.jpg";
                if (File.Exists(Path.Combine("Images", imagePath)))
                {
                    pictureBox.Image = Image.FromFile(Path.Combine("Images", imagePath));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading image: {ex.Message}");
            }

            // Create title label - in a real app, you'd look up the car details
            string carTitle = transaction.CarId == 1 ? "Ford Raptor (2023)" : "BMW XM (2025)";
            Label titleLabel = new Label
            {
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                Location = new Point(149, 13),
                Size = new Size(343, 27),
                Text = carTitle,
                Name = $"lblTransaction{transaction.Id}Title"
            };

            // Create price label
            Label priceLabel = new Label
            {
                Font = new Font("Segoe UI", 9F),
                Location = new Point(149, 47),
                Size = new Size(343, 27),
                Text = $"MUR {transaction.RentalPrice} / day",
                Name = $"lblTransaction{transaction.Id}Price"
            };

            // Create date range label
            string dateText = transaction.CarId == 1
                ? $"Booking Period: {transaction.StartDate:MMM dd, yyyy} - {transaction.EndDate:MMM dd, yyyy}"
                : $"Booked on: {transaction.StartDate:MMM dd, yyyy} - {transaction.EndDate:MMM dd, yyyy}";

            Label dateRangeLabel = new Label
            {
                Font = new Font("Segoe UI", 9F),
                Location = new Point(149, 80),
                Size = new Size(343, 27),
                Text = dateText,
                Name = $"lblTransaction{transaction.Id}DateRange"
            };

            // Create status label
            Label statusLabel = new Label
            {
                BackColor = Color.LimeGreen,
                Font = new Font("Segoe UI", 9F),
                Location = new Point(941, 13),
                Size = new Size(91, 27),
                Text = transaction.Status,
                TextAlign = ContentAlignment.MiddleCenter,
                Name = $"lblTransaction{transaction.Id}Status"
            };

            // Create delete button
            Button deleteButton = new Button
            {
                BackColor = Color.OrangeRed,
                FlatStyle = FlatStyle.Flat,
                ForeColor = Color.White,
                Location = new Point(941, 99),
                Size = new Size(91, 40),
                Text = "Delete",
                Name = $"btnDeleteTransaction{transaction.Id}"
            };

            // Add event handler to the delete button
            deleteButton.Click += BtnDeleteTransaction_Click;
            deleteButton.FlatAppearance.BorderSize = 0;

            // Add all controls to the panel
            panel.Controls.Add(pictureBox);
            panel.Controls.Add(titleLabel);
            panel.Controls.Add(priceLabel);
            panel.Controls.Add(dateRangeLabel);
            panel.Controls.Add(statusLabel);
            panel.Controls.Add(deleteButton);

            return panel;
        }

        #region Event Handlers
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            // Extract ID from button name (format: btnDeleteCar{ID})
            string buttonName = btn.Name;
            int carId = int.Parse(buttonName.Substring("btnDeleteCar".Length));

            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this listing?",
                "Confirm Deletion",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // In a real application, you would remove the car from a database
                // For this demo, just hide the panel
                Panel panelToHide = (Panel)panelContent.Controls.Find($"panelCarListing{carId}", true)[0];
                panelToHide.Visible = false;

                // Count visible car panels
                int visibleCars = 0;
                foreach (Control control in panelContent.Controls)
                {
                    if (control is Panel panel && panel.Name.StartsWith("panelCarListing") && panel.Visible)
                    {
                        visibleCars++;
                    }
                }

                // Update the listing count
                lblListingsCount.Text = visibleCars.ToString();

                // If the car was reserved, update reservation count
                Label statusLabel = (Label)panelToHide.Controls.Find($"lblCar{carId}Status", true)[0];
                if (statusLabel.Text == "Reserved")
                {
                    int currentReservations = int.Parse(lblReservationsCount.Text);
                    lblReservationsCount.Text = (currentReservations - 1).ToString();
                }

                // Show "no more cars" message if all are hidden
                if (visibleCars == 0)
                {
                    labelNoMoreListings.Visible = true;
                    // Position it correctly
                    labelNoMoreListings.Location = new Point(27, 31);
                }

                // Reposition the transaction history section
                int newTransactionY = 31;
                foreach (Control control in panelContent.Controls)
                {
                    if (control is Panel panel && panel.Name.StartsWith("panelCarListing") && panel.Visible)
                    {
                        newTransactionY = Math.Max(newTransactionY, panel.Location.Y + panel.Height + 10);
                    }
                }

                if (visibleCars == 0)
                {
                    newTransactionY += labelNoMoreListings.Height + 10;
                }

                labelTransactionHistory.Location = new Point(27, newTransactionY);

                // Reposition all transaction panels
                int transactionY = labelTransactionHistory.Location.Y + labelTransactionHistory.Height + 20;
                foreach (Control control in panelContent.Controls)
                {
                    if (control is Panel panel && panel.Name.StartsWith("panelTransaction") && panel.Visible)
                    {
                        panel.Location = new Point(27, transactionY);
                        transactionY += panel.Height + 10;
                    }
                }

                // Reposition the "no more history" label
                if (labelNoMoreHistory.Visible)
                {
                    labelNoMoreHistory.Location = new Point(27, transactionY);
                }
            }
        }

        private void BtnDeleteTransaction_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            // Extract ID from button name (format: btnDeleteTransaction{ID})
            string buttonName = btn.Name;
            int transactionId = int.Parse(buttonName.Substring("btnDeleteTransaction".Length));

            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this transaction record?",
                "Confirm Deletion",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // In a real application, you would remove the transaction from a database
                // For this demo, just hide the panel
                Panel panelToHide = (Panel)panelContent.Controls.Find($"panelTransaction{transactionId}", true)[0];
                panelToHide.Visible = false;

                // Reposition remaining transaction panels
                int transactionY = labelTransactionHistory.Location.Y + labelTransactionHistory.Height + 20;
                bool anyTransactionsVisible = false;

                foreach (Control control in panelContent.Controls)
                {
                    if (control is Panel panel && panel.Name.StartsWith("panelTransaction") && panel.Visible)
                    {
                        panel.Location = new Point(27, transactionY);
                        transactionY += panel.Height + 10;
                        anyTransactionsVisible = true;
                    }
                }

                // Update the "no more history" label
                if (!anyTransactionsVisible)
                {
                    labelNoMoreHistory.Visible = false;
                }
                else
                {
                    labelNoMoreHistory.Location = new Point(27, transactionY);
                    labelNoMoreHistory.Visible = true;
                }
            }
        }

        private void btnBrowseListings_Click(object sender, EventArgs e)
        {
            BrowseListings browseListings = new BrowseListings();
            browseListings.Show();
            this.Hide();
        }

        private void btnManageBooking_Click(object sender, EventArgs e)
        {
            ManageBookings manageBookings = new ManageBookings();
            manageBookings.Show();
            this.Hide();
        }

        private void btnListCar_Click(object sender, EventArgs e)
        {
            ListCarForm listCarForm = new ListCarForm();
            listCarForm.Show();
            this.Hide();
        }

        private void btnManageYourListings_Click(object sender, EventArgs e)
        {
            // Already on this form, no action needed
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

                // In a real application, you would handle logout here
                // Application.Restart(); // Uncomment to restart application
                // this.Close(); // Uncomment to close current form
            }
        }
        #endregion
    }
}
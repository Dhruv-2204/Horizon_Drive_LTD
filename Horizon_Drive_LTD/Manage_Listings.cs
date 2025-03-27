using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Horizon_Drive_LTD
{
    public partial class Manage_Listings : Form
    {
        private List<CarListing> carListings; // List of cars to display
        private List<Transaction> transactions;

        public Manage_Listings()
        {
            InitializeComponent();

            // Sample car data
            carListings = new List<CarListing>
            {
                new CarListing { Id = 1, Make = "Ford", Model = "Raptor (2023)", PricePerDay = 15000, Status = "Active" },
                new CarListing { Id = 2, Make = "BMW", Model = "XM (2025)", PricePerDay = 20000, Status = "Reserved" }
            };

            // Sample car transactions data
            transactions = new List<Transaction>
            {
                new Transaction { CarModel = "Ford Raptor (2023)", RatePerDay = 15000, BookingPeriod = "Mar 15, 2025 - Jun 15, 2025", Status = "Finished" },
                new Transaction { CarModel = "BMW XM (2025)", RatePerDay = 30000, BookingPeriod = "Feb 15, 2025 - Feb 22, 2025", Status = "Finished" }
            };

            // Create the dynamic car list under the summary boxes
            CreateDynamicCarList();
            CreateDynamicTransactionList();
        }

        private void CreateDynamicCarList()
        {
            flowLayoutPanelListings.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanelListings.WrapContents = false;
            flowLayoutPanelListings.AutoScroll = true;

            foreach (var car in carListings)
            {
                Panel carPanel = new Panel
                {
                    Size = new Size(420, 120), // Adjusted size for PictureBox
                    Margin = new Padding(10),
                    BackColor = Color.LightGray,
                    BorderStyle = BorderStyle.FixedSingle
                };

                PictureBox carPictureBox = new PictureBox
                {
                    Size = new Size(80, 80),
                    Location = new Point(10, 20),
                    BorderStyle = BorderStyle.FixedSingle,
                    SizeMode = PictureBoxSizeMode.StretchImage
                };

                // Load image or use placeholder
                try
                {
                    string imagePath = $"Images/{car.Id}.jpg"; // Assuming images are named by car ID
                    if (System.IO.File.Exists(imagePath))
                    {
                        carPictureBox.Image = Image.FromFile(imagePath);
                    }
                    else
                    {
                        string placeholderPath = "Images/placeholder.jpg"; // Path to a default placeholder image
                        if (System.IO.File.Exists(placeholderPath))
                        {
                            carPictureBox.Image = Image.FromFile(placeholderPath);
                        }
                        else
                        {
                            // Optional: Set a background color or display a default UI if no placeholder is found
                            carPictureBox.BackColor = Color.Gray;
                            carPictureBox.BorderStyle = BorderStyle.FixedSingle;
                        }
                    }
                }
                catch
                {
                    // Handle any unforeseen exceptions by providing a default setup
                    carPictureBox.BackColor = Color.Gray;
                    carPictureBox.BorderStyle = BorderStyle.FixedSingle;
                }


                Panel statusBox = new Panel
                {
                    Size = new Size(70, 20),
                    Location = new Point(320, 5),
                    BackColor = car.Status == "Active" ? Color.LightGreen : Color.LightBlue
                };

                Label statusLabel = new Label
                {
                    Text = car.Status,
                    Font = new Font("Segoe UI", 7F, FontStyle.Regular),
                    ForeColor = Color.Black,
                    Location = new Point(2, 2),
                    AutoSize = true,
                    TextAlign = ContentAlignment.MiddleCenter
                };
                statusBox.Controls.Add(statusLabel);

                Label carTitleLabel = new Label
                {
                    Text = $"{car.Make} {car.Model}",
                    Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                    Location = new Point(100, 10),
                    Size = new Size(310, 30)
                };

                Label carPriceLabel = new Label
                {
                    Text = $"MUR {car.PricePerDay}/day",
                    Font = new Font("Segoe UI", 10F, FontStyle.Regular),
                    Location = new Point(100, 50),
                    Size = new Size(180, 30)
                };

                if (car.Status == "Active")
                {
                    Button deleteButton = new Button
                    {
                        Text = "Delete",
                        Font = new Font("Segoe UI", 8F, FontStyle.Bold),
                        BackColor = Color.Red,
                        ForeColor = Color.White,
                        Location = new Point(300, 80),
                        Size = new Size(80, 30),
                        FlatStyle = FlatStyle.Flat
                    };

                    deleteButton.Click += (sender, e) => DeleteCar(car, carPanel);
                    carPanel.Controls.Add(deleteButton);
                }

                carPanel.Controls.Add(carPictureBox);
                carPanel.Controls.Add(statusBox);
                carPanel.Controls.Add(carTitleLabel);
                carPanel.Controls.Add(carPriceLabel);
                flowLayoutPanelListings.Controls.Add(carPanel);
            }
        }

        private void CreateDynamicTransactionList()
        {
            foreach (var transaction in transactions)
            {
                Panel transactionPanel = new Panel
                {
                    Size = new Size(1140, 100),
                    Margin = new Padding(10),
                    BackColor = Color.LightGray,
                    BorderStyle = BorderStyle.FixedSingle
                };

                Label carModelLabel = new Label
                {
                    Text = transaction.CarModel,
                    Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                    Location = new Point(10, 10),
                    Size = new Size(400, 30)
                };

                Label ratePerDayLabel = new Label
                {
                    Text = $"MUR {transaction.RatePerDay} / day",
                    Font = new Font("Segoe UI", 10F, FontStyle.Regular),
                    Location = new Point(10, 40),
                    Size = new Size(200, 30)
                };

                Label bookingPeriodLabel = new Label
                {
                    Text = $"Booking Period: {transaction.BookingPeriod}",
                    Font = new Font("Segoe UI", 10F, FontStyle.Regular),
                    Location = new Point(10, 70),
                    Size = new Size(400, 30)
                };

                Label statusLabel = new Label
                {
                    Text = transaction.Status,
                    Font = new Font("Segoe UI", 10F, FontStyle.Regular),
                    ForeColor = Color.Blue,
                    Location = new Point(900, 10),
                    Size = new Size(100, 30)
                };

                Button deleteButton = new Button
                {
                    Text = "Delete",
                    Font = new Font("Segoe UI", 8F, FontStyle.Bold),
                    BackColor = Color.Red,
                    ForeColor = Color.White,
                    Location = new Point(900, 60),
                    Size = new Size(80, 30),
                    FlatStyle = FlatStyle.Flat
                };

                deleteButton.Click += (sender, e) => DeleteTransaction(transaction, transactionPanel);

                transactionPanel.Controls.Add(carModelLabel);
                transactionPanel.Controls.Add(ratePerDayLabel);
                transactionPanel.Controls.Add(bookingPeriodLabel);
                transactionPanel.Controls.Add(statusLabel);
                transactionPanel.Controls.Add(deleteButton);

                flowLayoutPanelTransactions.Controls.Add(transactionPanel);
            }
        }

        private void DeleteCar(CarListing car, Panel carPanel)
        {
            carListings.Remove(car);
            flowLayoutPanelListings.Controls.Remove(carPanel);
        }

        private void DeleteTransaction(Transaction transaction, Panel transactionPanel)
        {
            transactions.Remove(transaction);
            flowLayoutPanelTransactions.Controls.Remove(transactionPanel);
        }

        public class CarListing
        {
            public int Id { get; set; }
            public string Make { get; set; }
            public string Model { get; set; }
            public decimal PricePerDay { get; set; }
            public string Status { get; set; }
        }

        public class Transaction
        {
            public string CarModel { get; set; }
            public int RatePerDay { get; set; }
            public string BookingPeriod { get; set; }
            public string Status { get; set; }
        }
    }
}

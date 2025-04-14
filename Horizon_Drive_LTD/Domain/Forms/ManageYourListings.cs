using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using Horizon_Drive_LTD.BusinessLogic;
using Horizon_Drive_LTD.BusinessLogic.Repositories;
using Horizon_Drive_LTD.BusinessLogic.Services;
using Horizon_Drive_LTD.DataStructure;
using Horizon_Drive_LTD.Domain.Entities;
using Microsoft.Data.SqlClient;

namespace Horizon_Drive_LTD
{
    public partial class ManageYourListings : Form
    {
        private bool isClosing = false;
        DatabaseConnection _dbConnection = new DatabaseConnection();
        private HashTable<string, Cars> carHashTable;
        private HashTable<string, Booking> bookingHashTable;

        public ManageYourListings()
        {
            InitializeComponent();

            // Set client size and minimum size
            this.ClientSize = new Size(1600, 900);
            this.MinimumSize = new Size(1000, 700);

            string userId = CurrentUser.CurrentUserId;

            // Load data dynamically
            LoadCarListingsFromDatabase();


          

            // Initially hide the "no more cars" label since we'll show it conditionally
            labelNoMoreListings.Visible = false;

        }

        private void LoadCarListingsFromDatabase()
        {
            // Clear existing dynamic car listing panels
            panelContent.Controls.Clear();

            CarRepository carRepo = new CarRepository(new DatabaseConnection());
            carHashTable = carRepo.LoadCarsFromDatabase(); 

          
            string userid = CurrentUser.CurrentUserId;

            int verticalPosition = 31;
            int listingsCount = 0;
            int reservedCount = 0;

            foreach (var kvp in carHashTable.GetAllItems())
            {
                Cars car = kvp.Value;

                if (car.UserID == userid)
                {
                    Panel carPanel = CreateCarListingPanelFromCar(car, verticalPosition);
                    panelContent.Controls.Add(carPanel);
                    verticalPosition += carPanel.Height + 10;

                    listingsCount++;
                    if (car.Status == "booked")
                        reservedCount++;
                }
            }

            // Show "no more listings" message
            if (listingsCount == 0)
            {
                labelNoMoreListings.Location = new Point(27, verticalPosition);
                labelNoMoreListings.Visible = true;
            }
            else
            {
                labelNoMoreListings.Visible = false;
            }

            labelTransactionHistory.Location = new Point(27, verticalPosition + 20);
            lblListingsCount.Text = listingsCount.ToString();
            lblReservationsCount.Text = reservedCount.ToString();

            int transactionStartY = verticalPosition + 40;
            LoadTransactionsFromDatabase(transactionStartY);
            

        }
       
        // Method to create a car listing panel
      
        private Panel CreateCarListingPanelFromCar(Cars car, int yPosition)
        {
            // Create main panel
            Panel panel = new Panel
            {
                BorderStyle = BorderStyle.FixedSingle,
                Location = new Point(27, yPosition),
                Size = new Size(1100, 133),
                Name = $"panelCarListing{car.CarID}"
            };

            // Create and add car image
            PictureBox pictureBox = new PictureBox
            {
                BackColor = Color.LightGray,
                Location = new Point(11, 13),
                Size = new Size(126, 110),
                SizeMode = PictureBoxSizeMode.Zoom,
                Name = $"pictureBoxCar{car.CarID}"
            };

            try
            {

                string brand = car.CarBrand.Replace(" ", "");
                string model = car.Model.Replace(" ", "");
                // Navigate to the specific folder for the car
                string carFolder = Path.Combine(Application.StartupPath, "Images", "BrowseListings", $"{brand}_{model}");

                // Make sure the folder exists
                if (Directory.Exists(carFolder))
                {
                    // Get all valid image files inside the folder
                    string[] matchingFiles = Directory.GetFiles(carFolder, "*.*")
                        .Where(file => file.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase)
                                    || file.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase)
                                    || file.EndsWith(".png", StringComparison.OrdinalIgnoreCase)
                                    || file.EndsWith(".bmp", StringComparison.OrdinalIgnoreCase))
                        .ToArray();

                    if (matchingFiles.Length > 0)
                    {
                        pictureBox.Image = Image.FromFile(matchingFiles[0]);
                    }
                    else
                    {
                        pictureBox.BackColor = Color.LightGray;
                        MessageBox.Show("No images found in folder: " + carFolder);
                    }
                }
                else
                {
                    pictureBox.BackColor = Color.LightGray;
                    MessageBox.Show("Folder not found: " + carFolder);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Image load error: " + ex.Message);
                pictureBox.BackColor = Color.LightGray;
            }


            // Create title label
            Label titleLabel = new Label
            {
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                Location = new Point(149, 13),
                Size = new Size(343, 27),
                Text = $"{car.CarBrand} {car.Model} {car.Year}",
                Name = $"lblCar{car.CarID}Title"
            };

            // Create price label
            Label priceLabel = new Label
            {
                Font = new Font("Segoe UI", 9F),
                Location = new Point(149, 47),
                Size = new Size(343, 27),
                Text = $"MUR {car.CarPrice} per day",
                Name = $"lblCar{car.CarID}Price"
            };

            // Create status label
            Label statusLabel = new Label
            {
                BackColor = car.Status == "unbooked" ? Color.LimeGreen : Color.LightBlue,
                Font = new Font("Segoe UI", 9F),
                Location = new Point(941, 13),
                Size = new Size(130, 27),
                Text = car.Status,
                TextAlign = ContentAlignment.MiddleCenter,
                Name = $"lblCar{car.CarID}Status"
            };

            // Create features panel
            Panel featuresPanel = new Panel
            {
                Location = new Point(149, 80),
                Size = new Size(343, 40),
                Name = $"panelCar{car.CarID}Features"
            };

            // Add feature labels to the panel
            int featureX = 0;

            Label featureLabel = new Label
            {
                AutoSize = true,
                BackColor = Color.LightGray,
                BorderStyle = BorderStyle.FixedSingle,
                Font = new Font("Segoe UI", 8F),
                Location = new Point(featureX, 7),
                Padding = new Padding(6, 3, 6, 3),
                Text = car.Features,
                Name = $"lblCar{car.CarID}Feature"
            };

            featuresPanel.Controls.Add(featureLabel);

            if (car.Status == "unbooked")
            {

                // Create delete button
                Button deleteButton = new Button
                {
                    BackColor = Color.OrangeRed,
                    FlatStyle = FlatStyle.Flat,
                    ForeColor = Color.White,
                    Location = new Point(941, 80),
                    Size = new Size(130, 40),
                    Text = "Delete",
                    Name = $"btnDeleteCar{car.CarID}"
                };

                // Add event handler to the delete button
                deleteButton.Click += BtnDelete_Click;
                deleteButton.FlatAppearance.BorderSize = 0;
                panel.Controls.Add(deleteButton);
            }
 
          
            // Add all controls to the panel
            panel.Controls.Add(pictureBox);
            panel.Controls.Add(titleLabel);
            panel.Controls.Add(priceLabel);
            panel.Controls.Add(statusLabel);
            panel.Controls.Add(featuresPanel);
           

            return panel;
        }




        private void LoadTransactionsFromDatabase(int transactionStartY)
        {

            // Clear existing static transaction panels
            if (panelContent.Controls.Contains(panelTransaction1))
                panelContent.Controls.Remove(panelTransaction1);

            if (panelContent.Controls.Contains(panelTransaction2))
                panelContent.Controls.Remove(panelTransaction2);

            BookingsRepository bookingRepo = new BookingsRepository(new DatabaseConnection());

            // Fetch all (Booking booking, string brand, string model, DateTime year, decimal price, string status) tuples
            var bookings = bookingRepo.GetBookingsForUserWithCarDetails(CurrentUser.CurrentUserId);

          //  int verticalPosition = 31;
            int listingsCount = 0;
            int reservedCount = 0;

            foreach (var (booking, carBrand, model, year, price, status) in bookings)
            {
                Panel carPanel = CreateTransactionPanel(booking, carBrand, model, year, price, status, transactionStartY);

                panelContent.Controls.Add(carPanel);
                transactionStartY += carPanel.Height + 10;

                listingsCount++;

                if (status.Equals("booked", StringComparison.OrdinalIgnoreCase))
                {
                    reservedCount++;
                }
            }

            // Position after transaction history label
            transactionStartY = labelTransactionHistory.Location.Y + labelTransactionHistory.Height + 20;

            if (listingsCount == 0)
            {
                labelNoMoreHistory.Visible = true;
                labelNoMoreHistory.Location = new Point(27, transactionStartY);
            }
            else
            {
                labelNoMoreHistory.Visible = false;
            }

            // Optionally update earnings if needed later
            // lblEarningsAmount.Text = $"MUR {totalEarnings}";
        }
        

        // Method to load transactions from database
        /*
        private void LoadTransactionsFromDatabase()
        {
            // Clear existing static transaction panels
            if (panelContent.Controls.Contains(panelTransaction1))
                panelContent.Controls.Remove(panelTransaction1);

            if (panelContent.Controls.Contains(panelTransaction2))
                panelContent.Controls.Remove(panelTransaction2);

            string currentuserid = CurrentUser.CurrentUserId;

            BookingsRepository bookingRepo = new BookingsRepository(new DatabaseConnection());
            bookingHashTable = bookingRepo.LoadBookingsFromDatabase();

            CarRepository carRepo = new CarRepository(new DatabaseConnection());
            List<int> userCarIds = carRepo.GetCarIdsByUserId(currentuserid);


            MessageBox.Show("User car IDs: " + string.Join(",", userCarIds));

            int verticalPosition = 31; 
            int listingsCount = 0;
            int reservedCount = 0;

            
            foreach (var kvp in bookingHashTable.GetAllItems())
            {
                Booking booking = kvp.Value;

                if (userCarIds.Select(id => id.ToString()).Contains(booking.CarID))

                {
                    Cars cardetails = carHashTable.Search(booking.CarID);
                    Panel carPanel = CreateTransactionPanel(booking, cardetails, verticalPosition);

                    panelContent.Controls.Add(carPanel);
                    verticalPosition += carPanel.Height + 10;

                    listingsCount++;

                    // Check status from carHashTable using booking.CarID
                    if (carHashTable.ContainsKey(booking.CarID))
                    {
                        Cars car = carHashTable.Search(booking.CarID);
                        if (car.Status == "booked")
                            reservedCount++;
                    }
                }
            }

            
            // Find the position after the transaction history label
            verticalPosition = labelTransactionHistory.Location.Y + labelTransactionHistory.Height + 20;

            if (listingsCount == 0)
            {
                labelNoMoreHistory.Visible = true;
                labelNoMoreHistory.Location = new Point(27, verticalPosition);
            }
            else
            {
                labelNoMoreHistory.Visible = false;
            }


            // Update total earnings
          //  lblEarningsAmount.Text = $"MUR {totalEarnings}";
        }
        */

        // Method to create a transaction panel
        private Panel CreateTransactionPanel(Booking booking, string brand, string model, int year, decimal price, string status, int yPosition)
        {

            // Create main panel
            Panel panel = new Panel
            {
                BorderStyle = BorderStyle.FixedSingle,
                Location = new Point(27, yPosition),
                Size = new Size(1057, 159),
                Name = $"panelTransaction{booking.CarID}"
            };

            // Create and add car image
            PictureBox pictureBox = new PictureBox
            {
                BackColor = Color.LightGray,
                Location = new Point(11, 13),
                Size = new Size(126, 107),
                SizeMode = PictureBoxSizeMode.Zoom,
                Name = $"pictureBoxTransaction{booking.BookingID}"
            };

            try
            {
                string cleanedBrand = brand.Replace(" ", "");
                string cleanedModel = model.Replace(" ", "");
                string carFolder = Path.Combine(Application.StartupPath, "Images", "BrowseListings", $"{cleanedBrand}_{cleanedModel}");

                if (Directory.Exists(carFolder))
                {
                    string[] matchingFiles = Directory.GetFiles(carFolder, "*.*")
                        .Where(file => file.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase)
                                    || file.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase)
                                    || file.EndsWith(".png", StringComparison.OrdinalIgnoreCase)
                                    || file.EndsWith(".bmp", StringComparison.OrdinalIgnoreCase))
                        .ToArray();

                    if (matchingFiles.Length > 0)
                    {
                        pictureBox.Image = Image.FromFile(matchingFiles[0]);
                    }
                    else
                    {
                        MessageBox.Show("No images found in folder: " + carFolder);
                    }
                }
                else
                {
                    MessageBox.Show("Folder not found: " + carFolder);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Image load error: " + ex.Message);
            }

            // Create title label
            Label titleLabel = new Label
            {
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                Location = new Point(149, 13),
                Size = new Size(343, 27),
                Text = $"{brand} {model} {year}",
                Name = $"lblTransaction{booking.BookingID}Title"
            };

            // Create price label
            Label priceLabel = new Label
            {
                Font = new Font("Segoe UI", 9F),
                Location = new Point(149, 47),
                Size = new Size(343, 27),
                Text = $"MUR {price} / day",
                Name = $"lblTransaction{booking.BookingID}Price"
            };

            // Create date range label
            string dateText = $"Booking Period: {booking.PickupDate:MMM dd, yyyy} - {booking.DropoffDate:MMM dd, yyyy}";
            Label dateRangeLabel = new Label
            {
                Font = new Font("Segoe UI", 9F),
                Location = new Point(149, 80),
                Size = new Size(343, 27),
                Text = dateText,
                Name = $"lblTransaction{booking.CarID}DateRange"
            };

            // Create status label
            Label statusLabel = new Label
            {
                BackColor = Color.LimeGreen,
                Font = new Font("Segoe UI", 9F),
                Location = new Point(941, 13),
                Size = new Size(91, 27),
                Text = status,
                TextAlign = ContentAlignment.MiddleCenter,
                Name = $"lblTransaction{booking.BookingID}Status"
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
                Name = $"btnDeleteTransaction{booking.BookingID}"
            };

            deleteButton.Click += BtnDeleteTransaction_Click;
            deleteButton.FlatAppearance.BorderSize = 0;

            // Add all controls
            panel.Controls.Add(pictureBox);
            panel.Controls.Add(titleLabel);
            panel.Controls.Add(priceLabel);
            panel.Controls.Add(dateRangeLabel);
            panel.Controls.Add(statusLabel);
            panel.Controls.Add(deleteButton);

            return panel;
        }


        private void BtnDelete_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string buttonName = btn.Name;
            string carId = buttonName.Substring("btnDeleteCar".Length);

            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this car listing?",
                "Confirm Deletion",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    //Remove from hash table
                    if (carHashTable.ContainsKey(carId))
                    {
                        carHashTable.Remove(carId);
                    }

                    // Remove from Car table
                    CarRepository carRepo = new CarRepository(new DatabaseConnection());
                    carRepo.DeleteCarById(carId);

                    //Remove the panel from UI
                    Panel panelToHide = (Panel)panelContent.Controls.Find($"panelCarListing{carId}", true)[0];
                    panelContent.Controls.Remove(panelToHide);
                    panelToHide.Dispose();

                    // Recalculate visible cars
                    int visibleCars = panelContent.Controls
                        .OfType<Panel>()
                        .Count(p => p.Name.StartsWith("panelCarListing") && p.Visible);

                    lblListingsCount.Text = visibleCars.ToString();

                    // Update reservation count if needed
                    Label statusLabel = panelToHide.Controls.Find($"lblCar{carId}Status", true).FirstOrDefault() as Label;
                    if (statusLabel != null && statusLabel.Text == "Reserved")
                    {
                        int currentReservations = int.Parse(lblReservationsCount.Text);
                        lblReservationsCount.Text = (currentReservations - 1).ToString();
                    }

                    // Show "no listings" message
                    labelNoMoreListings.Visible = (visibleCars == 0);
                    if (labelNoMoreListings.Visible)
                        labelNoMoreListings.Location = new Point(27, 31);

                    // Reposition transaction history
                    int newTransactionY = 31;
                    foreach (Control control in panelContent.Controls)
                    {
                        if (control is Panel panel && panel.Name.StartsWith("panelCarListing") && panel.Visible)
                        {
                            newTransactionY = Math.Max(newTransactionY, panel.Location.Y + panel.Height + 10);
                        }
                    }

                    if (visibleCars == 0)
                        newTransactionY += labelNoMoreListings.Height + 10;

                    labelTransactionHistory.Location = new Point(27, newTransactionY);

                    // Reposition transaction panels
                    int transactionY = labelTransactionHistory.Location.Y + labelTransactionHistory.Height + 20;
                    foreach (Control control in panelContent.Controls)
                    {
                        if (control is Panel panel && panel.Name.StartsWith("panelTransaction") && panel.Visible)
                        {
                            panel.Location = new Point(27, transactionY);
                            transactionY += panel.Height + 10;
                        }
                    }

                    //  Reposition "no history" label
                    if (labelNoMoreHistory.Visible)
                    {
                        labelNoMoreHistory.Location = new Point(27, transactionY);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error while deleting the car: " + ex.Message);
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
        

        private void Form2_Load(object sender, EventArgs e)
        {
            this.FormClosing += new FormClosingEventHandler(ManageListing_FormClosing);
        }
        private void ManageListing_FormClosing(object sender, FormClosingEventArgs e)
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
    }
}
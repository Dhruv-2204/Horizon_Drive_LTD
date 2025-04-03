using Horizon_Drive_LTD.DataStructure;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace Horizon_Drive_LTD
{
    public partial class List_A_Car_Page : Form
    {
        // Assuming CarListing is a model class for car listings
        private List<CarListing> carListings;

        private string connectionString = "Data Source=LAPTOP-VKDU1VH3\\SQLEXPRESS;Initial Catalog=DummyCars;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";


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



        private void SaveImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            //{
            //    Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp",
            //    Title = "Select a Car Image"
            //};

            //if (openFileDialog.ShowDialog() == DialogResult.OK)
            //{
            //    try
            //    {
            //        // Load image into PictureBox
            //        pbCarImage.Image = new Bitmap(openFileDialog.FileName);

            //        // Convert image to byte array for database storage
            //        byte[] imageData = File.ReadAllBytes(openFileDialog.FileName);

            //        // Store the byte array in your Car object
            //        // (You'll need to add a byte[] property to your Car class)
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show($"Error loading image: {ex.Message}", "Error",
            //                      MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //}

            //openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";

            //if(openFileDialog.ShowDialog() == DialogResult.OK) {
            //    openFileDialog.Filter = openFileDialog.FileName; 
            //    pbCarImage.Image = new Bitmap(openFileDialog.FileName);

            //}
            string FileName1 = openFileDialog.FileName;
            pbCarImage.Image = new Bitmap(openFileDialog.FileName);
            File.Copy(FileName1, Path.Combine("C:\\Users\\HP\\Source\\Repos\\Horizon_Drive_LTD\\Horizon_Drive_LTD\\Pictures\\img\\", Path.GetFileName(FileName1)), true);
            MessageBox.Show("Image saved");
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            var car = new Car
            {
                RegistrationNumber = txtLicensePlate.Text,
                Make = cmbMake.Text,
                Model = cmbModel.Text,
                Year = int.Parse(cmbYear.Text),
                Type = cmbType.Text,
                Color = cmbColor.Text,
                Price = decimal.Parse(txtDailyRate.Text),
                picture = pbCarImage.Text,
                Description = txtCarDescription.Text
                //IsAvailable = checkBox1.Checked
            };

            InsertCarIntoDatabase(car);
            MessageBox.Show("Car added successfully!");
        }

        private void InsertCarIntoDatabase(Car car)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO CARS2 (CarID, LicensePlate, Make, Model, Year, Type, Color, Description, DailyRate) " +
                                "VALUES (@CarID, @LicensePlate, @Make, @Model, @Year, @Type, @Color, @Description, @DailyRate)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CarID", car.RegistrationNumber);
                    command.Parameters.AddWithValue("@LicensePlate", car.RegistrationNumber);
                    command.Parameters.AddWithValue("@Make", car.Make);
                    command.Parameters.AddWithValue("@Model", car.Model);
                    command.Parameters.AddWithValue("@Year", car.Year);
                    command.Parameters.AddWithValue("@Type", car.Type);
                    command.Parameters.AddWithValue("@Color", car.Color);
                    command.Parameters.AddWithValue("@Description", car.Description);
                    command.Parameters.AddWithValue("@DailyRate", car.Price);
                    //command.Parameters.AddWithValue("@Photo", car.picture);
                    //command.Parameters.AddWithValue("@IsAvailable", car.IsAvailable);

                    command.ExecuteNonQuery();
                }
            }
        }

        private HashTable<string, Car> RetrieveCarsFromDatabase()
        {
            var carTable = new HashTable<string, Car>(7);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Cars";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var car = new Car
                            {
                                RegistrationNumber = reader["RegistrationNumber"].ToString(),
                                Make = reader["Make"].ToString(),
                                Model = reader["Model"].ToString(),
                                Year = Convert.ToInt32(reader["Year"]),
                                //IsAvailable = Convert.ToBoolean(reader["IsAvailable"])
                            };

                            carTable.Insert(car.RegistrationNumber, car);
                        }
                    }
                }
            }

            return carTable;
        }

        private void pbCarImage_Click(object sender, EventArgs e)
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


    public class Car
    {
        public string RegistrationNumber { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Type { get; set; }
        public string Color { get; set; }
        public int Year { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string picture { get; set; }
        public byte[] actualPicture { get; set; }


        
    }
}
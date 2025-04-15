using Horizon_Drive_LTD.DataStructure;
using Horizon_Drive_LTD.Domain.Entities;
using Horizon_Drive_LTD.Domain.Forms;
using Manage_user_search_page;
using Microsoft.Data.SqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using WindowsFormsApp1;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Upload_cars
{
    public partial class Managing_files : Form
    {
        public Managing_files()
        {
            InitializeComponent();
            LoadImage();
            SetRoundedCorner(Manage_users, 25);
            SetRoundedCorner(Upload_Cars_btn, 25);
            SetRoundedCorner(Manage_bookings_btn, 25);
            SetRoundedCorner(Logout_btn, 25);
            SetRoundedCorner(Maintenance_btn, 25);
           

        }

        private void DropBox_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        private void DropBox_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files.Length > 0)
            {
                string filePath = files[0];
                string extension = Path.GetExtension(filePath).ToLower();

                // Validate only accept only .txt or .csv
                if (extension == ".txt" || extension == ".csv")
                {
                    ProcessFile(filePath);  // Proceed if valid
                }
                else
                {
                    MessageBox.Show("Only .txt or .csv files are allowed to be entered.", "Invalid File", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void ProcessFile(string filePath)
        {
            foreach (var line in File.ReadLines(filePath))
            {
                var words = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (words.Length != 21)
                {
                    MessageBox.Show("Invalid line format. Expected 22 fields.");
                    continue;
                }

                try
                {
                    var car = new Cars(
                        carid: words[0],
                        userid: words[1],
                        carBrand: words[2],
                        category: words[3],
                        registrationNo: words[4],
                        model: words[5],
                        years: int.Parse(words[6]),
                        colour: words[7],
                        features: words[8],
                        desc: words[9],
                        price: decimal.Parse(words[10]),
                        seat: int.Parse(words[11]),
                        engine: words[12],
                        rating: decimal.Parse(words[13]),
                        power: words[14],
                        drive: words[15],
                        fuel: words[16],
                        transmission: words[17],
                        status: words[18],
                        availabilitystart: DateTime.Parse(words[19]),
                        availabilityend: DateTime.Parse(words[20])
                    );

                    Hashtable carData = new Hashtable
                    {
                        ["CarID"] = car.CarID,
                        ["UserID"] = car.UserID,
                        ["CarBrand"] = car.CarBrand,
                        ["Category"] = car.Category,
                        ["RegistrationNo"] = car.RegistrationNo,
                        ["Model"] = car.Model,
                        ["Years"] = car.Year,
                        ["Colour"] = car.Colour,
                        ["Features"] = car.Features,
                        ["VehicleDescription"] = car.VehicleDescription,
                        ["CarPrice"] = car.CarPrice,
                        ["SeatNo"] = car.SeatNo,
                        ["EngineCapacity"] = car.EngineCapacity,
                        ["Ratings"] = car.Ratings,
                        ["Power"] = car.Power,
                        ["DriveTrain"] = car.DriveTrain,
                        ["FuelType"] = car.FuelType,
                        ["TransmissionType"] = car.TransmissionType,
                        ["Status"] = car.Status,
                        ["AvailabilityStart"] = car.AvailabilityStart,
                        ["AvailabilityEnd"] = car.AvailabilityEnd
                    };

                    SaveCarToDatabase(carData);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error processing line:\n" + line + "\n\nDetails:\n" + ex.Message);
                }
            }
        }



        private void SaveCarToDatabase(Hashtable data)
        {
            string connStr = "Data Source=LAPTOP-6P9HT3IB\\SQLEXPRESS;Initial Catalog=CarDBMS;Integrated Security=True;Trust Server Certificate=True";

            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();

                    string query = @"INSERT INTO Car 
                (CarID, UserID, CarBrand, Category, RegistrationNo, Model, Years, Colour, Features, VehicleDescription, CarPrice, SeatNo, EngineCapacity, Ratings, Power, DriveTrain, FuelType, TransmissionType, Status, AvailabilityStart, AvailabilityEnd) 
                VALUES 
                (@carid, @userid, @carBrand, @category, @registrationNo, @model, @years, @colour, @features, @desc, @price, @seat, @engine, @rating, @power, @drive, @fuel, @transmission, @status, @availabilityStart, @availabilityEnd)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@carid", data["CarID"]);
                        cmd.Parameters.AddWithValue("@userid", data["UserID"]);
                        cmd.Parameters.AddWithValue("@carBrand", data["CarBrand"]);
                        cmd.Parameters.AddWithValue("@category", data["Category"]);
                        cmd.Parameters.AddWithValue("@registrationNo", data["RegistrationNo"]);
                        cmd.Parameters.AddWithValue("@model", data["Model"]);
                        cmd.Parameters.AddWithValue("@years", data["Years"]);
                        cmd.Parameters.AddWithValue("@colour", data["Colour"]);
                        cmd.Parameters.AddWithValue("@features", data["Features"]);
                        cmd.Parameters.AddWithValue("@desc", data["VehicleDescription"]);
                        cmd.Parameters.AddWithValue("@price", data["CarPrice"]);
                        cmd.Parameters.AddWithValue("@seat", data["SeatNo"]);
                        cmd.Parameters.AddWithValue("@engine", data["EngineCapacity"]);
                        cmd.Parameters.AddWithValue("@rating", data["Ratings"]);
                        cmd.Parameters.AddWithValue("@power", data["Power"]);
                        cmd.Parameters.AddWithValue("@drive", data["DriveTrain"]);
                        cmd.Parameters.AddWithValue("@fuel", data["FuelType"]);
                        cmd.Parameters.AddWithValue("@transmission", data["TransmissionType"]);
                        cmd.Parameters.AddWithValue("@status", data["Status"]);
                        cmd.Parameters.AddWithValue("@availabilityStart", data["AvailabilityStart"]);
                        cmd.Parameters.AddWithValue("@availabilityEnd", data["AvailabilityEnd"]);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving to database: " + ex.Message);
            }


        }



        private void SetRoundedCorner(Button button, int radius)
        {
            // Code to round the corners of the button

            Rectangle bounds = button.ClientRectangle;
            int diameter = radius * 2;

            GraphicsPath path1 = new GraphicsPath();
            path1.StartFigure();
            path1.AddArc(bounds.X, bounds.Y, diameter, diameter, 180, 90);
            path1.AddArc(bounds.Right - diameter, bounds.Y, diameter, diameter, 270, 90);
            path1.AddArc(bounds.Right - diameter, bounds.Bottom - diameter, diameter, diameter, 0, 90);
            path1.AddArc(bounds.X, bounds.Bottom - diameter, diameter, diameter, 90, 90);
            path1.CloseFigure();
            button.Region = new Region(path1);
        }


       

        private void Manage_Users_Click(object sender, EventArgs e)
        {
            var manage_user_Page = new Manage_User_Page(); // Replace with your actual form name
            manage_user_Page.Show();                  // Shows the new form
            this.Hide();
        }


        private void LoadImage()
        {
            //Combining folder name and image name to get the full path to display the image
            string imagePath = Path.Combine(System.Windows.Forms.Application.StartupPath, "Media", "Images", "HORIZONDRIVE_LOGO.png");

            // condition to check if the image exists
            if (File.Exists(imagePath))
            {
                pictureBox1.Image = Image.FromFile(imagePath);
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            }
            else
            {
                MessageBox.Show("Image not found at: " + imagePath);
                //error message window pops up if image is not found
            }
        }

        private void Upload_Cars_btn_Click(object sender, EventArgs e)
        {

        }

        private void Logout_btn_Click(object sender, EventArgs e)
        {

        }


        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Search_Users_Click(object sender, EventArgs e)
        {

        }

        private void Save_button_clicked(object sender, EventArgs e)
        {

        }

        private void Manage_bookings_btn_Click(object sender, EventArgs e)
        {
            var manage_car_Page = new Manage_bookings(); // gets form Managing_cars
            manage_car_Page.Show();                  // Shows the new form manage_cars
            this.Dispose();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }





        private void Mainteance_click(object sender, EventArgs e)
        {
            var manage_car_Page = new Maintenance(); // gets form Managing_cars
            manage_car_Page.Show();                  // Shows the new form manage_cars
            this.Dispose();
        }

        private void Save_Customer_Click(object sender, EventArgs e)
        {

        }

        private void Save_File_Click(object sender, EventArgs e)
        {
            string filePath = labelfilepath.Text;

            if (string.IsNullOrWhiteSpace(filePath) || !File.Exists(filePath))
            {
                MessageBox.Show("Please select a valid file first.(.txt or .csv");
                return;
            }

            ProcessFile(filePath);
            MessageBox.Show("Cars saved to database successfully.");
        }

        private void Upload_File_btn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt;*.csv)|*.txt;*.csv";
            openFileDialog.Title = "Select a Car Data File";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedFile = openFileDialog.FileName;
                labelfilepath.Text = selectedFile; // Temporarily store the path

                // Clear previous items and load new lines
                DragDropListBox.Items.Clear();

                foreach (var line in File.ReadLines(selectedFile))
                {
                    DragDropListBox.Items.Add(line);
                }

                MessageBox.Show("File selected: " + Path.GetFileName(selectedFile));
            }
        }

    }
}

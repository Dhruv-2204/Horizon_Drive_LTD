using Horizon_Drive_LTD;
using Horizon_Drive_LTD.BusinessLogic;
using Horizon_Drive_LTD.DataStructure;
using Horizon_Drive_LTD.Domain.Entities;
using Horizon_Drive_LTD.Domain.Forms;
using Manage_user_search_page;
using Microsoft.Data.SqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using WindowsFormsApp1;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Upload_cars
{
    
    public partial class Admin_Managing_files : Form
    {
        
        
        public Admin_Managing_files()
        {
            InitializeComponent();
            LoadImage();
            SetRoundedCorner(Manage_users, 25);
            SetRoundedCorner(Upload_Cars_btn, 25);
            SetRoundedCorner(Manage_bookings_btn, 25);
            SetRoundedCorner(Logout_btn, 25);
            SetRoundedCorner(Maintenance_btn, 25);


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


        private void Manage_Users_Click(object sender, EventArgs e)
        {
            var manage_user_Page = new Manage_User_Page(); // Replace with manage user page
            manage_user_Page.Show();                  // Shows the new form manage users
            this.Hide();
        }

        private void Manage_bookings_btn_Click(object sender, EventArgs e)
        {
            var manage_car_Page = new Manage_bookings(); // gets form Manage_bookings
            manage_car_Page.Show();                  // Shows the new form manage_cars
            this.Dispose();
        }

        private void Maintenance_click(object sender, EventArgs e)
        {
            var manage_car_Page = new Maintenance(); // gets form  Maintenance 
            manage_car_Page.Show();                  // Shows the new form manage_cars
            this.Dispose();
        }


        private void SaveCars(string filePath)
        {
            var carHashTable = new HashTable<string, Cars>(10000); // Initialize with a large size with user limit of 10 thousand cars

            Admin_managing_files_repo admin_Managing_files = new Admin_managing_files_repo(new DatabaseConnection());

          

            foreach (var line in File.ReadLines(filePath))
            {
                var words = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                try
                {
                    Cars car = new Cars(
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
                        availabilityend: DateTime.Parse(words[20]),
                        carimagepath: words[21]

                    );

                    carHashTable.Insert(car.CarID, car);
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error processing line:\n" + line + "\n\nDetails:\n" + ex.Message);
                }
            }

            admin_Managing_files.SaveCarToDatabase(carHashTable);
        }

       


        private void SaveUsers(string filePath)
        {
            var userHashTable = new HashTable<string, User>(10000); // Initialize with a large size with user limit of 10 thousand users

            Admin_managing_files_repo admin_Managing_files = new Admin_managing_files_repo(new DatabaseConnection());

            foreach (var line in File.ReadLines(filePath))
            {
                var words = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                try
                {
                  

                    User user = new User(
                        userid: words[0],
                        username: words[1],
                        firstname: words[2],
                        lastname: words[3],
                        email: words[4],
                        phonenum: int.Parse(words[5]),
                        address: words[6],
                        password: words[7],
                        dob: DateOnly.Parse(words[8]),
                        profilepic: words[9]
                    );

                    userHashTable.Insert(user.UserId, user);
                }
                catch (Exception ex)
                {
                    
                }
            }

            admin_Managing_files.SaveUsersToDatabase(userHashTable);
        }


       




        private void SaveCustomers(string filePath)
        {
            var CustomerHashTable = new HashTable<string, Customer>(10000); // Initialize with a large size with user limit of 10 thousand users

            Admin_managing_files_repo admin_Managing_files = new Admin_managing_files_repo(new DatabaseConnection());



            foreach (var line in File.ReadLines(filePath))
            {
                var words = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                try
                {
                    
                   

                    Customer customer = new Customer(
                        customerID: words[0],
                        userID: words[1],
                        licenseNo: words[2],
                        licenseExpiryDate: DateOnly.Parse(words[3]),
                        licensePhoto: words[4]
                      
                    );

                    CustomerHashTable.Insert(customer.CustomerID, customer );
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error processing line:\n" + line + "\n\nDetails:\n" + ex.Message);
                }
            }

            admin_Managing_files.SaveCustomerToDatabase(CustomerHashTable);
        }


       







        private void Save_File_Click(object sender, EventArgs e)
        {
            string filePath = labelfilepath.Text;

            if (string.IsNullOrWhiteSpace(filePath) || !File.Exists(filePath))
            {
                MessageBox.Show("Please select a valid file first.(.txt or .csv");
                return;
            }

            string fileName = Path.GetFileName(filePath).ToLower();

            if (fileName == "car.txt" || fileName == "car.csv")
            {
                SaveCars(filePath);
                MessageBox.Show("Cars saved to database successfully.");
            }
            else if (fileName == "user.txt" || fileName == "user.csv")
            {
                SaveUsers(filePath);
                MessageBox.Show("Cars saved to database successfully.");
            }
            else if (fileName == "customer.txt" || fileName == "customer.csv")
            {
                SaveCustomers(filePath);
                MessageBox.Show("Cars saved to database successfully.");
            }
            else
            {
                MessageBox.Show("Unsupported file. Please upload Car.txt, Customer.txt, or User.txt only.");
            }
            //MessageBox.Show("Cars saved to database successfully.");

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

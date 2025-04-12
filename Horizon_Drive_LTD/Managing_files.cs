using Manage_user_search_page;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using WindowsFormsApp1;

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
            string imagePath = Path.Combine(System.Windows.Forms.Application.StartupPath, "Images", "HORIZONDRIVE_LOGO.png");

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

       


        private void UploadButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\"; // or set to Application.StartupPath
                openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Getting the file path
                    string filePath = openFileDialog.FileName;

                    // Example: Read and show contents in a ListBox or TextBox
                    string[] lines = File.ReadAllLines(filePath);
                    foreach (string line in lines)
                    {
                        DragDropListBox.Items.Add(line); // if you're using a ListBox
                    }

                    
                }
            }
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
            this.Hide();
        }
    }
}

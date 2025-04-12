using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;
using Upload_cars;
using User_managing;
using WindowsFormsApp1;

namespace Manage_user_search_page
{
    public partial class Manage_User_Page : Form
    {
        public Manage_User_Page()
        {
            InitializeComponent();
            //loads the image from the folder Images
            LoadImage();
            //Calls the button with radius 25
            SetRoundedCorner(Manage_Users, 25);
            SetRoundedCorner(Manage_Cars_btn, 25);
            SetRoundedCorner(Manage_bookings_btn, 25);
            SetRoundedCorner(Logout_btn, 25);
            SetRoundedCorner(Managing_users_click_btn, 25);
        }

        private void user_background_Paint(object sender, PaintEventArgs e)
        {

        }

        private void SetRoundedCorner(Button button, int radius)
        {
            // Code to round the corners of the button

            Rectangle bounds = button.ClientRectangle;
            int diameter = radius * 2;

            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(bounds.X, bounds.Y, diameter, diameter, 180, 90);
            path.AddArc(bounds.Right - diameter, bounds.Y, diameter, diameter, 270, 90);
            path.AddArc(bounds.Right - diameter, bounds.Bottom - diameter, diameter, diameter, 0, 90);
            path.AddArc(bounds.X, bounds.Bottom - diameter, diameter, diameter, 90, 90);
            path.CloseFigure();

            button.Region = new Region(path);
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Manage_users_click(object sender, EventArgs e)
        {
            var manage_user = new Manage_users(); // gets form Manage_users
            manage_user.Show();                  // Shows the new form manage users
            this.Hide();
        }

        private void Manage_Users_menu_Click_btn(object sender, EventArgs e)
        {
            
        }

        private void Upload_Cars_click_btn(object sender, EventArgs e)
        {
            var manage_car_Page = new Managing_files(); // gets form Managing_cars
            manage_car_Page.Show();                  // Shows the new form manage_cars
            this.Hide();
        }

        private void Manage_bookings_click_btn(object sender, EventArgs e)
        {
            var manage_user_Page = new Manage_bookings(); // Replace with your actual form name manage booking
            manage_user_Page.Show();                  // Shows the new form manage user
            this.Hide();
        }

        private void Logout_click_btn(object sender, EventArgs e)
        {

        }

        private void Search_Users_Click(object sender, EventArgs e)
        {

        }

        private void Manage_users_search_user(object sender, EventArgs e)
        {

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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
           

        }

        
    }
}

using Horizon_Drive_LTD.Domain.Forms;
using Manage_user_search_page;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Upload_cars;
using User_managing;

namespace WindowsFormsApp1
{
    public partial class Manage_bookings : Form
    {
        public Manage_bookings()
        {
            InitializeComponent();
            //loads the image from the folder Images
            LoadImage();
            SetRoundedCorner(Manage_users, 25);
            SetRoundedCorner(Upload_files, 25);
            SetRoundedCorner(Manage_bookings_btn, 25);
            SetRoundedCorner(Logout_btn, 25);
            SetRoundedCorner(Maintenance_btn, 25);
            //SetRoundedCorner(Managing_users_click_btn, 25);

        }

        private void Upload_Cars_btn_Click(object sender, EventArgs e)
        {
            var manage_car_Page = new Admin_Managing_files(); // gets form Managing_cars
            manage_car_Page.Show();                  // Shows the new form manage_cars
            this.Dispose();
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

        private void Manage_users_Click(object sender, EventArgs e)
        {
            var manage_user_Page = new Manage_User_Page(); // Replace with your actual form name
            manage_user_Page.Show();                  // Shows the new form
            this.Dispose();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Logout_btn_Click(object sender, EventArgs e)
        {

        }

        private void Maintenance_btn_Click(object sender, EventArgs e)
        {
            var manage_car_Page = new Maintenance(); // gets form Managing_cars
            manage_car_Page.Show();                  // Shows the new form manage_cars
            this.Dispose();
        }
    }
}

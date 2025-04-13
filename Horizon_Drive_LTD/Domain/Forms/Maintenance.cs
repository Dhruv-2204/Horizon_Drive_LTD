using Manage_user_search_page;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Upload_cars;
using User_managing;
using WindowsFormsApp1;

namespace Horizon_Drive_LTD.Domain.Forms
{
    public partial class Maintenance : Form
    {
        public Maintenance()
        {
            InitializeComponent();
            LoadImage();
            SetRoundedCorner(Manage_Users, 25);
            SetRoundedCorner(Manage_files_btn, 25);
            SetRoundedCorner(Manage_bookings_btn, 25);
            SetRoundedCorner(Logout_btn, 25);
            SetRoundedCorner(Maintenance_btn, 25);

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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Manage_Users_Click(object sender, EventArgs e)
        {
            var manage_car_Page = new Manage_User_Page(); // gets form Managing_cars
            manage_car_Page.Show();                  // Shows the new form manage_cars
            this.Dispose();
        }

        private void Manage_files_btn_Click(object sender, EventArgs e)
        {
            var manage_car_Page = new Managing_files(); // gets form Managing_cars
            manage_car_Page.Show();                  // Shows the new form manage_cars
            this.Dispose();
        }

        private void Manage_bookings_btn_Click(object sender, EventArgs e)
        {
            var manage_car_Page = new Manage_bookings(); // gets form Managing_cars
            manage_car_Page.Show();                  // Shows the new form manage_cars
            this.Dispose();
        }
    }
}

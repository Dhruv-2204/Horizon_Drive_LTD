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

namespace WindowsFormsApp1
{
    public partial class Manage_User_Page : Form
    {
        public Manage_User_Page()
        {
            InitializeComponent();
            SetRoundedCorners(Manage_Users, 25);
            SetRoundedCorners(Manage_Cars_btn, 25);
            SetRoundedCorners(Manage_bookings_btn, 25);
            SetRoundedCorners(Logout_btn, 25);
            SetRoundedCorners(Managing_users_click_btn, 25);
        }

        private void user_background_Paint(object sender, PaintEventArgs e)
        {

        }

        private void SetRoundedCorners(Button button, int radius)
        {
          

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

        }

        private void Manage_Users_menu_Click_btn(object sender, EventArgs e)
        {

        }

        private void Manage_Cars_click_btn(object sender, EventArgs e)
        {

        }

        private void Manage_bookings_click_btn(object sender, EventArgs e)
        {

        }

        private void Logout_click_btn(object sender, EventArgs e)
        {

        }
    }
}

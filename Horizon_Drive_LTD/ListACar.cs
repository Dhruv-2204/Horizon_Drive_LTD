using System;
using System.Drawing;
using System.Windows.Forms;

namespace list_your_car_page
{
    public partial class ListACar : Form
    {
        public ListACar()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Any initialization code can go here
        }

        private void BtnListCar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Car listed successfully!");
        }
    }
}

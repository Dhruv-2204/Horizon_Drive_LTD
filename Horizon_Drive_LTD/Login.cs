using Horizon_Drive_LTD;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace splashscreen
{
    public partial class Login : Form
    {
        private bool isClosing = false;
        public Login()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.FormClosing += new FormClosingEventHandler(MyForm_FormClosing);
        }
        private void MyForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isClosing) return; // Prevent duplicate message box
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
                Application.Exit(); // Properly terminates the application without triggering FormClosing again
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                Password.UseSystemPasswordChar = false;
            }
            else
            {
                Password.UseSystemPasswordChar = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Signup signup = new Signup();// Calls signup constructor
            signup.Show();//Shows the signup window
            this.Dispose();//closes the login window
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void username(object sender, EventArgs e)
        {

        }

        private void password(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Login_btn(object sender, EventArgs e)
        {

        }

        private void signup_btn(object sender, EventArgs e)
        {
            Signup signup = new Signup();// Calls signup constructor
            signup.Show();//Shows the signup window
            this.Dispose();//closes the login window
        }
    }
}

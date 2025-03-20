using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Horizon_Drive_LTD
{
    //Using the splashcreen namespace to summon the Login window
    using splashscreen;
    public partial class Signup : Form
    {
        private bool isClosing = false;
        public Signup()
        {
            InitializeComponent();
        }

        private void Closing_form(object sender, FormClosingEventArgs e)
        {
            if (isClosing) return; // Prevent duplicate message box
            isClosing = true;

            DialogResult result = MessageBox.Show("Do you want to close the window?", "Confirm Exit",
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

        private void button2_Click(object sender, EventArgs e)
        {

            Login login = new Login(); // Calls login constructor
            login.Show(); //Shows the login window
            this.Dispose();//closes the signup window
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                textBox7.UseSystemPasswordChar = false;
            }
            else
            {
                textBox7.UseSystemPasswordChar = true;
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Signup_Load(object sender, EventArgs e)
        {
            this.FormClosing += new FormClosingEventHandler(Closing_form);
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

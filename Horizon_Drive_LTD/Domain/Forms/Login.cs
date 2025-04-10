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
using Horizon_Drive_LTD.BusinessLogic.Services;
using Horizon_Drive_LTD.Domain.Entities;
namespace splashscreen
{
    public partial class Login : Form
    {
        private bool isClosing = false;
        private AuthenticationService _authService;

        public Login(AuthenticationService authService)
        {
            InitializeComponent();
           _authService = authService ?? throw new ArgumentNullException(nameof(authService));
        }

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

        private void LOGIN_btn_Click(object sender, EventArgs e)
        {
            string enteredUsername = Username.Text.Trim();
            string enteredPassword = Password.Text;

            if (_authService.Login(enteredUsername, enteredPassword, out User loggedInUser))
            {
                MessageBox.Show($"Welcome, {loggedInUser.Username}!", "Login Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Proceed to next form/dashboard
                // e.g. new DashboardForm(loggedInUser).Show(); this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void Signup_btn_Click(object sender, EventArgs e)
        {
            Signup signup = new Signup(); // Calls signup constructor
            signup.Show(); //Shows the signup window
            this.Dispose(); //closes the login window
        }

       
    }
}

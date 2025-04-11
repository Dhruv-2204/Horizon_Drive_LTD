using Horizon_Drive_LTD;
using Horizon_Drive_LTD.BusinessLogic.Repositories;
using Horizon_Drive_LTD.BusinessLogic;
using Horizon_Drive_LTD.BusinessLogic.Services;
using Horizon_Drive_LTD.Domain.Entities;
using System.Text;
using System.Security.Cryptography;
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
            if (isClosing) return; 
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

        public static string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (var b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }

        private void LOGIN_btn_Click(object sender, EventArgs e)
        {
            string enteredUsername = Username.Text.Trim();
            string enteredPassword = Password.Text;

            enteredPassword = HashPassword(enteredPassword); // Hash the entered password



            if (_authService.Login(enteredUsername, enteredPassword, out User loggedInUser))
            {
                DialogResult result = MessageBox.Show(
                    $"Welcome, {loggedInUser.UserName}!",
                    "Login Successful",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                if (result == DialogResult.OK)
                {
                    Options_Personal dashboard = new Options_Personal();
                    dashboard.FormClosed += (s, args) => this.Close(); // Close the login form when the dashboard is closed
                    dashboard.Show();

                    // Hide the current form (Login form)
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void Signup_btn_Click(object sender, EventArgs e)
        {
            var userRepo = new UserRepository(new DatabaseConnection());
            var userHashTable = userRepo.LoadUsersIntoHashTable();
            var authService = new AuthenticationService(userHashTable, userRepo);

            Signup signup = new Signup(authService); // Calls signup constructor
            signup.Show(); //Shows the signup window
            this.Dispose(); //closes the login window
        }


    }
}

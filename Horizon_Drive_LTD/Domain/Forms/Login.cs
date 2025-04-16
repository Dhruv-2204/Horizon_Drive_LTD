using Horizon_Drive_LTD;
using Horizon_Drive_LTD.BusinessLogic.Repositories;
using Horizon_Drive_LTD.BusinessLogic;
using Horizon_Drive_LTD.BusinessLogic.Services;
using Horizon_Drive_LTD.Domain.Entities;
using Microsoft.Data.SqlClient;
using System.Text;
using System.Security.Cryptography;
using Manage_user_search_page;

namespace splashscreen
{
    public partial class Login : Form
    {
        private bool isClosing = false;
        private AuthenticationService _authService;
        private DatabaseConnection _dbConnection;

        public Login(AuthenticationService authService)
        {
            InitializeComponent();
            _authService = authService ?? throw new ArgumentNullException(nameof(authService));
            _dbConnection = new DatabaseConnection();
        }

        public Login()
        {
            InitializeComponent();
            _dbConnection = new DatabaseConnection();
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
                using (SqlConnection conn = _dbConnection.GetConnection())
                {
                    conn.Open();
                    string dropTableQuery = "DROP TABLE IF EXISTS ActiveUser;";
                    using (SqlCommand cmd = new SqlCommand(dropTableQuery, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }

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

        // Hash the password using SHA256
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

        // Event handler for the "Login" button
        private void LOGIN_btn_Click(object sender, EventArgs e)
        {
            string enteredUsername = Username.Text.Trim();
            string enteredPassword = Password.Text;

            // Check for hardcoded admin credentials
            if (enteredUsername == "Admin" && enteredPassword == "Adminpassword!") 
            {
                // Admin login successful
                DialogResult result = MessageBox.Show(
                    "Welcome, Admin!",
                    "Admin Login Successful",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                if (result == DialogResult.OK)
                {
                    // Open the admin management page
                    var adminPage = new Manage_User_Page();
                    adminPage.FormClosed += (s, args) => this.Close();
                    adminPage.Show();

                    // Hide the current form (Login form)
                    this.Dispose();
                }
                return; // Exit the method after handling admin login
            }

            // Regular user login process
            enteredPassword = HashPassword(enteredPassword); // Hash the password before sending it to the authentication service

            // Initialize _authService if it's null (for the parameterless constructor)
            if (_authService == null)
            {
                var userRepo = new UserRepository(new DatabaseConnection());
                var userHashTable = userRepo.LoadUsersIntoHashTable();
                _authService = new AuthenticationService(userHashTable, userRepo);
            }

            if (_authService.Login(enteredUsername, enteredPassword, out User loggedInUser))
            {
                UserRepository userRepo = new UserRepository(new DatabaseConnection());
                CustomerRepository customerRepo = new CustomerRepository(new DatabaseConnection());
                LessorRepository lessorRepo = new LessorRepository(new DatabaseConnection());

                string userId = userRepo.GetUserIdByUsername(enteredUsername);
                string customerid = customerRepo.GetCustomerIdByUserId(userId);
                string lessorid = lessorRepo.GetLessorIdByUserId(userId);

                if (!string.IsNullOrEmpty(userId))
                {
                    userRepo.StoreActiveUser(enteredUsername, userId, customerid, lessorid);
                    CurrentUser.CurrentUserId = userId;
                    CurrentUser.Currentuser = loggedInUser;
                }
                else
                {
                    MessageBox.Show("User ID not found.");
                }

                DialogResult result = MessageBox.Show(
                    $"Welcome, {loggedInUser.UserName}!",
                    "Login Successful",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                if (result == DialogResult.OK)
                {
                    BrowseListings browseListing = new BrowseListings();
                    browseListing.FormClosed += (s, args) => this.Close();
                    browseListing.Show();

                    // Hide the current form (Login form)
                    this.Dispose();
                }
            }
            else
            {
                MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Event handler for the "Sign Up" button
        private void Signup_btn_Click(object sender, EventArgs e)
        {
            var userRepo = new UserRepository(new DatabaseConnection());
            var userHashTable = userRepo.LoadUsersIntoHashTable();
            var authService = new AuthenticationService(userHashTable, userRepo);

            Signup signup = new Signup(authService); // Calls signup constructor
            signup.Show(); // Shows the signup window
            this.Dispose(); // Closes the login window
        }
    }
}
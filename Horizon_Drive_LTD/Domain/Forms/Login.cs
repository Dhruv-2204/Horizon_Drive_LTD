using Horizon_Drive_LTD;
using Horizon_Drive_LTD.BusinessLogic.Repositories;
using Horizon_Drive_LTD.BusinessLogic;
using Horizon_Drive_LTD.BusinessLogic.Services;
using Horizon_Drive_LTD.Domain.Entities;
using System.Text;
using System.Security.Cryptography;
using Microsoft.Data.SqlClient;
namespace splashscreen
{
    public partial class Login : Form
    {
        private bool isClosing = false;
        private AuthenticationService _authService;
        private DatabaseConnection _dbConnection;

        public Login(AuthenticationService authService, DatabaseConnection dbConnection)
        {
            InitializeComponent();
           _authService = authService ?? throw new ArgumentNullException(nameof(authService));
           _dbConnection = dbConnection ?? throw new ArgumentNullException(nameof(dbConnection));
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

            enteredPassword = HashPassword(enteredPassword); // Hash the entered password  // M@he2025



            if (_authService.Login(enteredUsername, enteredPassword, out User loggedInUser))
            {

                using (SqlConnection conn = _dbConnection.GetConnection())
                {
                    conn.Open();

                    // Create the ActiveUser table if it does not exist
                    string createTableQuery = @"
                                IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='ActiveUser' AND xtype='U')
                                CREATE TABLE ActiveUser (
                                UserName Varchar(100) NOT NULL
                                );";
                    using (SqlCommand cmd = new SqlCommand(createTableQuery, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    // Insert the current user's username into the ActiveUser table
                    string insertUserQuery = @"
                    INSERT INTO ActiveUser (UserName)
                    VALUES (@UserName);";
                    using (SqlCommand cmd = new SqlCommand(insertUserQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserName", loggedInUser.UserName);
                        //cmd.Parameters.AddWithValue("@UserId", loggedInUser.UserId);
                        cmd.ExecuteNonQuery();
                    }
                }



                DialogResult result = MessageBox.Show(
                    $"Welcome, {loggedInUser.UserName}!",
                    "Login Successful",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                if (result == DialogResult.OK)
                {
                    Options_Personal dashboard = new Options_Personal();
                    dashboard.FormClosed += (s, args) =>
                    {
                        // Delete the ActiveUser table when the dashboard is closed
                        using (SqlConnection conn = _dbConnection.GetConnection())
                        {
                            conn.Open();
                            string dropTableQuery = "DROP TABLE IF EXISTS ActiveUser;";
                            using (SqlCommand cmd = new SqlCommand(dropTableQuery, conn))
                            {
                                cmd.ExecuteNonQuery();
                            }
                        }

                        this.Close(); // Close the login form
                    };

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


        // dummy code to find lost password

        //private void LOGIN_btn_Click(object sender, EventArgs e)
        //{
        //    string enteredUsername = Username.Text.Trim();
        //    string enteredPassword = Password.Text;

        //    string actualPasswordFromDB = null;
        //    //enteredPassword = HashPassword(enteredPassword);

        //    using (SqlConnection conn = _dbConnection.GetConnection())
        //    {
        //        conn.Open();

        //        // Step 1: Retrieve actual password for the entered username
        //        string query = "SELECT Password FROM [User] WHERE UserName = @UserName";
        //        using (SqlCommand cmd = new SqlCommand(query, conn))
        //        {
        //            cmd.Parameters.AddWithValue("@UserName", enteredUsername);
        //            var result = cmd.ExecuteScalar();

        //            if (result == null)
        //            {
        //                MessageBox.Show("Username not found.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //                return;
        //            }

        //            actualPasswordFromDB = result.ToString();
        //        }
        //    }

        //    // Step 2: Display the actual password to the user (for testing only)
        //    MessageBox.Show($"Password for {enteredUsername} is: {actualPasswordFromDB}", "Debug Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

        //    // Step 3: Check if user typed the correct password (plaintext comparison)
        //    if (enteredPassword == actualPasswordFromDB)
        //    {
        //        // OPTIONAL: proceed to track ActiveUser (same as before)
        //        using (SqlConnection conn = _dbConnection.GetConnection())
        //        {
        //            conn.Open();

        //            string createTableQuery = @"
        //        IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='ActiveUser' AND xtype='U')
        //        CREATE TABLE ActiveUser (
        //            UserName Varchar(100) NOT NULL
        //        );";
        //            using (SqlCommand cmd = new SqlCommand(createTableQuery, conn))
        //            {
        //                cmd.ExecuteNonQuery();
        //            }

        //            string insertUserQuery = "INSERT INTO ActiveUser (UserName) VALUES (@UserName);";
        //            using (SqlCommand cmd = new SqlCommand(insertUserQuery, conn))
        //            {
        //                cmd.Parameters.AddWithValue("@UserName", enteredUsername);
        //                cmd.ExecuteNonQuery();
        //            }
        //        }

        //        DialogResult result = MessageBox.Show(
        //            $"Welcome, {enteredUsername}!",
        //            "Login Successful",
        //            MessageBoxButtons.OK,
        //            MessageBoxIcon.Information
        //        );

        //        if (result == DialogResult.OK)
        //        {
        //            Options_Personal dashboard = new Options_Personal();
        //            dashboard.FormClosed += (s, args) =>
        //            {
        //                using (SqlConnection conn = _dbConnection.GetConnection())
        //                {
        //                    conn.Open();
        //                    string dropTableQuery = "DROP TABLE IF EXISTS ActiveUser;";
        //                    using (SqlCommand cmd = new SqlCommand(dropTableQuery, conn))
        //                    {
        //                        cmd.ExecuteNonQuery();
        //                    }
        //                }
        //                this.Close();
        //            };

        //            dashboard.Show();
        //            this.Hide();
        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("Incorrect password entered.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}



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

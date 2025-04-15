using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using Horizon_Drive_LTD.BusinessLogic.Repositories;
using Horizon_Drive_LTD.BusinessLogic;
using Horizon_Drive_LTD.BusinessLogic.Services;
using Horizon_Drive_LTD.Domain.Entities;
using splashscreen;
using Microsoft.Data.SqlClient;


namespace Horizon_Drive_LTD
{
    

    public partial class Signup : Form
    {
        private bool isClosing = false;

        private AuthenticationService _authService;
       // private readonly DatabaseConnection _dbConnection;
       DatabaseConnection _dbConnection = new DatabaseConnection();

        public Signup(AuthenticationService authService)
        {
            InitializeComponent();
            _authService = authService ?? throw new ArgumentNullException(nameof(authService));
        }

        public Signup()
        {
            InitializeComponent();
        }

        /// Event handler for the form closing event
        private void Closing_form(object sender, FormClosingEventArgs e)
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

        private void Login_button(object sender, EventArgs e)
        {

            Login login = new Login(_authService); 
            login.Show();
            this.Dispose();
        }

        private void sign_btn(object sender, EventArgs e)
        {
            
            BrowseListings browseListing = new BrowseListings();
            browseListing.Show();

            this.Dispose();
        }

        /// Event handler for the "Show Password" checkbox
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

        /// Hashes the password using SHA256
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


        private void Signup_Load(object sender, EventArgs e)
        {
            this.FormClosing += new FormClosingEventHandler(Closing_form);
        }

        /// Event handler for the "Sign Up" button
        private void signup_btn_Click(object sender, EventArgs e)
        {
            Guid guid = Guid.NewGuid();
            int numericPart = Math.Abs(guid.GetHashCode()) % 100000;
            string userId = "U" + numericPart.ToString("D5");

            string customerid = "CU" + numericPart.ToString("D5");
            string lessorid = "L" + numericPart.ToString("D5");


            string firstName = First_Name.Text.Trim();
            string lastName = Last_Name.Text.Trim();
            string username = Username.Text.Trim();
            string email = Email.Text.Trim();
            DateTime dob = DOB_date.Value;
            string phoneInput = Phone_Number.Text.Trim();
            string address = Address.Text.Trim();
            string password = Password.Text;

            //Check for empty fields
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(username) ||
                string.IsNullOrEmpty(email) || string.IsNullOrEmpty(phoneInput) || string.IsNullOrEmpty(address) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please fill in all the fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validate email format
            if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Please enter a valid email address.", "Invalid Email", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validate date of birth
            int age = DateTime.Today.Year - dob.Year;
            if (dob > DateTime.Today.AddYears(-age)) age--;
            if (age < 18)
            {
                MessageBox.Show("You must be at least 18 years old to sign up.", "Invalid Age", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validate phone number (numeric and reasonable length)
            if (!long.TryParse(phoneInput, out long phoneNumber) || phoneInput.Length < 8 || phoneInput.Length > 8)
            {
                MessageBox.Show("Please enter a valid phone number.", "Invalid Phone Number", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // At least one uppercase letter one lowercase letter one digit one special character
            if (password.Length < 8 ||
               !password.Any(char.IsUpper) ||
               !password.Any(char.IsLower) ||
               !password.Any(char.IsDigit) ||
               !password.Any(ch => !char.IsLetterOrDigit(ch)))
            {
                MessageBox.Show("Password must be at least 8 characters long and include:\n- At least 1 uppercase letter\n- At least 1 lowercase letter\n- At least 1 number\n- At least 1 special character",
                                "Weak Password", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // If all validation passes, create the user object
            User newUser = new(
                            userId,
                            username,
                            firstName,
                            lastName,
                             email,
                            (int)phoneNumber,
                            address,
                            HashPassword(password),
                            DateOnly.FromDateTime(dob),
                            string.Empty 
                        );

          
            bool result = _authService.SignUp(newUser);
            if (result)
            {
                MessageBox.Show("Account created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Store the user in the database
                UserRepository userRepo = new UserRepository(new DatabaseConnection());


                using (SqlConnection conn = _dbConnection.GetConnection())
                {
                    conn.Open();

                    string query = @"INSERT INTO Customer
                                      (CustomerId, UserId)
                                      VALUES 
                                      (@CustomerId, @UserId)";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@CustomerId", customerid);
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    cmd.ExecuteNonQuery();


                }

                using (SqlConnection conn = _dbConnection.GetConnection())
                {
                    conn.Open();
                    string query = @"INSERT INTO Lessor
                                    (LessorId, UserId)
                                    VALUES 
                                    (@LessorId, @UserId)";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@LessorId", lessorid);
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    cmd.ExecuteNonQuery();
                }


                userRepo.StoreActiveUser(username, userId , customerid, lessorid);

                BrowseListings browseListing = new BrowseListings();
                browseListing.Show();
                this.Dispose();

            }
            else
            {
                MessageBox.Show("Username already exists. Please choose a different one.", "Signup Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
    }



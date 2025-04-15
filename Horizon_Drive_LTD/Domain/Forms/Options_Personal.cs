using System.Drawing.Drawing2D;
using Microsoft.Data.SqlClient;
using Horizon_Drive_LTD.BusinessLogic;
using System.Text;
using System.Security.Cryptography;
using Horizon_Drive_LTD.BusinessLogic.Repositories;
using Horizon_Drive_LTD.BusinessLogic.Services;
using splashscreen;

namespace Horizon_Drive_LTD
{
    public partial class Options_Personal : Form
    {
        private string profileImagePath = string.Empty;
        private FormWindowState lastWindowState;
        private Size originalSize;
        private bool isInitializing = true;
        DatabaseConnection _dbConnection = new DatabaseConnection();


        public Options_Personal()
        {
            InitializeComponent();
            this.ClientSize = new Size(1280, 800);
            this.MinimumSize = new Size(1000, 700);

            // Store original form size to help with restore
            originalSize = this.Size;
            lastWindowState = this.WindowState;

            SetupTabButtons();
            SetupControlAnchoring();

            // Handle resize and state change events
            this.Resize += Options_Resize;
            this.SizeChanged += Options_SizeChanged;

            // Initialize control positions
            PerformLayout();
            isInitializing = false;
            AdjustControlPositions();
        }

        private void Options_SizeChanged(object sender, EventArgs e)
        {
            // Check if we're going from maximized to normal state
            if (lastWindowState == FormWindowState.Maximized && this.WindowState == FormWindowState.Normal)
            {
                // Force a complete relayout using the original form size as reference
                this.SuspendLayout();
                AdjustControlPositions();
                this.ResumeLayout(true);
            }

            lastWindowState = this.WindowState;
        }

        private void SetupTabButtons()
        {
            // Highlight the Personal button as it's the default view
            btnPersonal.BackColor = Color.FromArgb(173, 216, 230);
            btnPersonal.ForeColor = Color.Black;

            btnPreferences.BackColor = Color.FromArgb(30, 85, 110);
            btnPreferences.ForeColor = Color.White;
        }

        private void SetupControlAnchoring()
        {
            // Main container panel
            mainScrollPanel.Dock = DockStyle.Fill;

            // Main content panel - anchor to top, left, right but NOT bottom
            // This allows it to scroll when content is larger than the visible area
            panelMain.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            // Profile section - only anchor to top (center horizontally)
            panelProfileImage.Anchor = AnchorStyles.Top;

            // Form fields - stretch horizontally
            panelNameFields.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxEmail.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panelPhone.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxPassword.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxAddress.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            // First name field - anchor left side only, width adjusted programmatically
            textBoxFirstName.Anchor = AnchorStyles.Top | AnchorStyles.Left;

            // Last name field - remove right anchor, position/width adjusted programmatically
            labelLastName.Anchor = AnchorStyles.Top;
            textBoxLastName.Anchor = AnchorStyles.Top;

            // Save button - anchor to bottom
            btnSaveChanges.Anchor = AnchorStyles.Bottom;

            // NO anchoring for camera button - positioned programmatically
            buttonCamera.Anchor = AnchorStyles.None;

            // Store the name fields split ratio
            panelNameFields.Tag = 0.5; // 50% split
        }

        private void Options_Resize(object sender, EventArgs e)
        {
            if (!isInitializing && this.IsHandleCreated && !this.Disposing && this.Visible)
            {
                AdjustControlPositions();
            }
        }

        private void AdjustControlPositions()
        {
            try
            {
                this.SuspendLayout();

                AdjustProfileImagePosition();
                CenterSaveButton();
                AdjustNameFields();

                this.ResumeLayout(true);
            }
            catch (Exception ex)
            {
                // Error handling for layout adjustments
                Console.WriteLine($"Layout adjustment error: {ex.Message}");
            }
        }

        private void AdjustProfileImagePosition()
        {
            // Center the profile image panel horizontally
            if (panelMain.Width > 0)
            {
                // Use client area for positioning to avoid layout issues
                int centerX = panelMain.ClientSize.Width / 2;
                int profileCenterX = panelProfileImage.Width / 2;

                panelProfileImage.Left = centerX - profileCenterX;

                // Position the camera button relative to the profile image
                buttonCamera.Left = panelProfileImage.Left + panelProfileImage.Width - 32;
                buttonCamera.Top = panelProfileImage.Top + panelProfileImage.Height - 34;
            }
        }

        private bool isClosing = false;
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

        private void CenterSaveButton()
        {
            // Center the save button horizontally
            if (panelMain.Width > 0)
            {
                int centerX = panelMain.ClientSize.Width / 2;
                int buttonCenterX = btnSaveChanges.Width / 2;

                btnSaveChanges.Left = centerX - buttonCenterX;
            }
        }

        private void AdjustNameFields()
        {
            if (panelNameFields.Width > 0)
            {
                // Get available width
                int totalWidth = panelNameFields.Width;
                int gap = 40;

                // Split based on stored ratio or default to 50%
                double splitRatio = panelNameFields.Tag != null ?
                    Convert.ToDouble(panelNameFields.Tag) : 0.5;

                // Calculate widths
                int firstNameWidth = (int)((totalWidth - gap) * splitRatio);
                int lastNameWidth = totalWidth - gap - firstNameWidth;

                // Prevent negative or tiny widths
                if (firstNameWidth < 50) firstNameWidth = 50;
                if (lastNameWidth < 50) lastNameWidth = 50;

                // Apply calculated dimensions
                textBoxFirstName.Width = firstNameWidth;

                // Position and size last name field
                textBoxLastName.Left = firstNameWidth + gap;
                textBoxLastName.Width = lastNameWidth;

                // Ensure label is aligned with text box
                labelLastName.Left = textBoxLastName.Left;
            }
        }

        // Original event handlers remain unchanged
        private void pictureBoxProfile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Select Profile Image";
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string username = string.Empty;

                        // Get the active username from the database
                        using (SqlConnection conn = _dbConnection.GetConnection())
                        {
                            conn.Open();
                            string query = "SELECT UserName FROM ActiveUser";
                            using (SqlCommand cmd = new SqlCommand(query, conn))
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    username = reader.GetString(0).Trim();
                                    Username_Label.Text = username;
                                }
                                else
                                {
                                    throw new Exception("No active user found.");
                                }
                            }
                        }

                        // SBuild relative and full image paths
                        string imageName = Path.GetFileName(openFileDialog.FileName);
                        string relativePath = Path.Combine("Media", "Images", username, imageName);
                        string absolutePath = Path.Combine(Application.StartupPath, relativePath);
                        string userImageDir = Path.GetDirectoryName(absolutePath);

                        // Create user folder if it doesn't exist
                        Directory.CreateDirectory(userImageDir);

                        // Copy the file to the target folder
                        File.Copy(openFileDialog.FileName, absolutePath, overwrite: true);

                        // Update database with image path
                        using (SqlConnection conn2 = _dbConnection.GetConnection())
                        {
                            conn2.Open();
                            string updateQuery = "UPDATE [User] SET ProfilePicture = @ProfilePicture WHERE UserName = @UserName";
                            using (SqlCommand cmd = new SqlCommand(updateQuery, conn2))
                            {
                                cmd.Parameters.AddWithValue("@ProfilePicture", relativePath);
                                cmd.Parameters.AddWithValue("@UserName", username);
                                //cmd.Parameters.AddWithValue("@Password", HashPassword("M@he2025"));
                                cmd.ExecuteNonQuery();
                            }
                        }

                        //  Load the image safely without locking the file
                        using (var img = new Bitmap(absolutePath))
                        {
                            pictureBoxProfile.Image = new Bitmap(img);
                        }

                        profileImagePath = relativePath;

                        MessageBox.Show("Profile picture updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error uploading image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }


        private void buttonCamera_Click(object sender, EventArgs e)
        {
            // Same functionality as clicking the profile picture
            pictureBoxProfile_Click(sender, e);
        }

        private void LoadProfilePicture(string username)
        {
            try
            {
                using (SqlConnection conn = _dbConnection.GetConnection())
                {
                    conn.Open();

                    string query = "SELECT ProfilePicture FROM [User] WHERE UserName = @UserName";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserName", username);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read() && !reader.IsDBNull(0))
                            {
                                string imagePath = reader.GetString(0);

                                if (File.Exists(imagePath)) // Ensure the file exists
                                {
                                    pictureBoxProfile.Image = Image.FromFile(imagePath);
                                }
                                else
                                {
                                    MessageBox.Show("Profile picture not found on disk.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading profile picture: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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


        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxFirstName.Text) ||
                string.IsNullOrWhiteSpace(textBoxLastName.Text) ||
                string.IsNullOrWhiteSpace(textBoxEmail.Text) ||
                string.IsNullOrWhiteSpace(textBoxAddress.Text))
            {
                MessageBox.Show("Please fill in all fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection sqlConnection = _dbConnection.GetConnection())
                {
                    sqlConnection.Open();

                    string currentPasswordHash = string.Empty;

                    //  Fetch current password hash from the database
                    string fetchQuery = "SELECT Password FROM [User] WHERE UserName = @UserName";
                    using (SqlCommand fetchCommand = new SqlCommand(fetchQuery, sqlConnection))
                    {
                        fetchCommand.Parameters.AddWithValue("@UserName", Username_Label.Text);
                        var result = fetchCommand.ExecuteScalar();
                        if (result != null)
                            currentPasswordHash = result.ToString();
                    }

                    //  Determine whether the password needs re-hashing
                    string enteredPassword = textBoxPassword.Text.Trim();
                    string finalPassword = currentPasswordHash;

                    if (!string.IsNullOrEmpty(enteredPassword) && HashPassword(enteredPassword) != currentPasswordHash)
                    {
                        // User entered a new password, so hash it
                        finalPassword = HashPassword(enteredPassword);
                    }

                    //  Perform update
                    string updateQuery = @"UPDATE [User]
                                           SET FirstName = @FirstName,
                                               LastName = @LastName,
                                               Email = @Email,
                                               TelephoneNo = @TelephoneNo,
                                               Address = @Address,
                                               Password = @Password,
                                               ProfilePicture = @ProfilePicture
                                           WHERE UserName = @UserName";

                    using (SqlCommand sqlCommand = new SqlCommand(updateQuery, sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@FirstName", textBoxFirstName.Text);
                        sqlCommand.Parameters.AddWithValue("@LastName", textBoxLastName.Text);
                        sqlCommand.Parameters.AddWithValue("@Email", textBoxEmail.Text);
                        sqlCommand.Parameters.AddWithValue("@TelephoneNo", textBoxPhone.Text);
                        sqlCommand.Parameters.AddWithValue("@Address", textBoxAddress.Text);
                        sqlCommand.Parameters.AddWithValue("@UserName", Username_Label.Text);
                        sqlCommand.Parameters.AddWithValue("@Password", finalPassword);
                        sqlCommand.Parameters.AddWithValue("@ProfilePicture", profileImagePath);

                        int rowsAffected = sqlCommand.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Profile updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("No changes made or user not found.", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show($"Database error: {sqlEx.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnPersonal_Click(object sender, EventArgs e)
        {
            btnPersonal.BackColor = Color.FromArgb(173, 216, 230);
            btnPersonal.ForeColor = Color.Black;

            btnPreferences.BackColor = Color.FromArgb(30, 85, 110);
            btnPreferences.ForeColor = Color.White;

            // In a real application, you might switch panels or load different content
        }

        private void btnPreferences_Click(object sender, EventArgs e)
        {
            // Update button colors for visual feedback
            btnPreferences.BackColor = Color.FromArgb(173, 216, 230);
            btnPreferences.ForeColor = Color.Black;

            btnPersonal.BackColor = Color.FromArgb(30, 85, 110);
            btnPersonal.ForeColor = Color.White;

            // Create and show the Preferences form
            Options_Preferences preferencesForm = new Options_Preferences();
            preferencesForm.Show();

            // Hide the current Personal form
            this.Dispose();
        }

        private void btnManageBooking_Click(object sender, EventArgs e)
        {
            ManageBookings manageBookings = new ManageBookings();
            manageBookings.Show();
            this.Dispose();
        }

        private void btnListCar_Click(object sender, EventArgs e)
        {
            ListCarForm listCarForm = new ListCarForm();
            listCarForm.Show();
            this.Dispose();
        }

        private void btnManageYourListings_Click(object sender, EventArgs e)
        {
            ManageYourListings manageYourListings = new ManageYourListings();
            manageYourListings.Show();
            this.Dispose();
        }

        private void btnOptions_Click(object sender, EventArgs e)
        {
            // Already on the options form, so do nothing or refresh
            Options_Personal optionsForm = new Options_Personal();
            optionsForm.Show();
            this.Dispose();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to log out?",
                           "Log Out",
                           MessageBoxButtons.YesNo,
                           MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // In a real application, you would handle logout here
                MessageBox.Show("You have been logged out successfully.",
                               "Log Out",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Information);

                using (SqlConnection conn = _dbConnection.GetConnection())
                {
                    conn.Open();
                    string dropTableQuery = "DROP TABLE IF EXISTS ActiveUser;";
                    using (SqlCommand cmd = new SqlCommand(dropTableQuery, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }

                OpenLoginUp();

                // Application.Restart(); // Uncomment to restart application
                this.Close(); // Uncomment to close current form
            }
            else
            {
                return; // User chose not to log out, do nothing
            }
        }

        private void OpenLoginUp()
        {

            var userRepo = new UserRepository(new DatabaseConnection());
            var userHashTable = userRepo.LoadUsersIntoHashTable();
            var authService = new AuthenticationService(userHashTable, userRepo);
            //var dbConnection = new DatabaseConnection();

            // Show the Login form with injected authService
            Login loginForm = new Login(authService);
            loginForm.Show();

            this.Dispose();
        }

        private void pictureBoxLogo_Click(object sender, EventArgs e)
        {
            // Logo click functionality
        }

        private void buttonCountryCode_Click(object sender, EventArgs e)
        {
            // This would open a popup with country codes to select from
            MessageBox.Show("Country code selection would appear here.", "Select Country Code", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnBrowseListings_Click(object sender, EventArgs e)
        {
            BrowseListings browseListings = new BrowseListings();
            browseListings.Show();
            this.Dispose();
        }

        private void panelTabs_Paint(object sender, PaintEventArgs e)
        {
            // Panel tabs paint event
        }

        private void textBoxPhone_TextChanged(object sender, EventArgs e)
        {
            // Phone text changed event
        }

        private void panelMain_Paint(object sender, PaintEventArgs e)
        {
            // Panel main paint event
        }

        private void textBoxEmail_TextChanged(object sender, EventArgs e)
        {
            // Email text changed event
        }

        private void labelPassword_Click(object sender, EventArgs e)
        {
            // Password label click event
        }

        private void textBoxLastName_TextChanged(object sender, EventArgs e)
        {
            // Last name text changed event
        }

        private void textBoxLastName_TextChanged_1(object sender, EventArgs e)
        {
            // Duplicate last name text changed event
        }



        private void Username_Label_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = _dbConnection.GetConnection())
                {
                    conn.Open();

                    string query = "SELECT UserName FROM ActiveUser;";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Username_Label.Text = reader.GetString(0);
                            LoadProfilePicture(Username_Label.Text); // Load the profile picture
                        }
                        else
                        {
                            Username_Label.Text = "No active user found.";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Display an error message or log the exception
                //MessageBox.Show($"Error fetching active user: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Options_Personal_Load(object sender, EventArgs e)
        {
            this.FormClosing += new FormClosingEventHandler(MyForm_FormClosing);

            try
            {
                using (SqlConnection conn = _dbConnection.GetConnection())
                {
                    conn.Open();

                    string query = "SELECT UserName FROM ActiveUser;";
                    
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Username_Label.Text = reader.GetString(0); // Update label automatically
                            
                        }
                        else
                        {
                            Username_Label.Text = "No active user found."; // Handle empty table
                        }
                    }

                    string additionalDataQuery = "SELECT FirstName, LastName, Email,TelephoneNo, Address,ProfilePicture,Password " +
                                                 "FROM [User], ActiveUser " +
                                                 "WHERE [User].UserName = ActiveUser.UserName;";

                    using (SqlCommand additionalDataCmd = new SqlCommand(additionalDataQuery, conn))
                    {
                        // Use the username from the ActiveUser table to filter data
                        //additionalDataCmd.Parameters.AddWithValue("@UserName", Username_Label.Text);

                        using (SqlDataReader additionalDataReader = additionalDataCmd.ExecuteReader())
                        {
                            if (additionalDataReader.Read())
                            {
                                // Insert data into respective labels
                                textBoxFirstName.Text = additionalDataReader.GetString(0); // FirstName
                                textBoxLastName.Text = additionalDataReader.GetString(1);  // LastName
                                textBoxEmail.Text = additionalDataReader.GetString(2);     // Email
                                textBoxAddress.Text = additionalDataReader.GetString(4); 
                                pictureBoxProfile.Image = Image.FromFile(additionalDataReader.GetString(5)); // ProfilePicture
                                //textBoxPassword.Text = additionalDataReader.GetString(3); // Password
                                textBoxPhone.Text = additionalDataReader.GetString(3); // TelephoneNo
                                //text
                                textBoxPassword.Text = additionalDataReader.GetString(6);

                            }
                            else
                            {
                                labelFirstName.Text = ""; // FirstName
                                labelLastName.Text = "";  // LastName
                                labelEmail.Text = "";     // Email
                                labelAddress.Text = "";   //Address
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                // Display an error message or log the exception
                //MessageBox.Show($"Error fetching active user: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }

}
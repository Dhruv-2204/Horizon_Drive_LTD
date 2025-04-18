﻿

//Options_Preferences.cs
using Horizon_Drive_LTD.BusinessLogic;
using Horizon_Drive_LTD.BusinessLogic.Repositories;
using Horizon_Drive_LTD.BusinessLogic.Services;
using Microsoft.Data.SqlClient;
using splashscreen;

namespace Horizon_Drive_LTD
{
    public partial class Options_Preferences : Form
    {
        private string licenseImagePath = string.Empty;
        private FormWindowState lastWindowState;
        private Size originalSize;
        private bool isInitializing = true;

        DatabaseConnection _dbConnection = new DatabaseConnection();


        public Options_Preferences()
        {
            InitializeComponent();
            this.ClientSize = new Size(1280, 800);
            this.MinimumSize = new Size(1000, 700);

            // Store original form size to help with restore
            originalSize = this.Size;
            lastWindowState = this.WindowState;

            SetupTabButtons();
            SetupControlAnchoring();

            // Load logo image
            try
            {
                pictureBoxLogo.Image = Properties.Resources.Logo;
            }
            catch
            {
                // Handle case where logo resource might not be available
                MessageBox.Show("Logo resource could not be loaded.", "Resource Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            // Handle resize and state change events
            this.Resize += Options_Preferences_Resize;
            this.SizeChanged += Options_Preferences_SizeChanged;

            // Initialize control positions
            PerformLayout();
            isInitializing = false;
            AdjustControlPositions();
        }

        private void Options_Preferences_SizeChanged(object sender, EventArgs e)
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
            // Highlight the Preferences button as it's the current view
            btnPreferences.BackColor = Color.FromArgb(173, 216, 230);
            btnPreferences.ForeColor = Color.Black;

            btnPersonal.BackColor = Color.FromArgb(30, 85, 110);
            btnPersonal.ForeColor = Color.White;
        }

        private void SetupControlAnchoring()
        {
            // Main container panel
            mainScrollPanel.Dock = DockStyle.Fill;

            // Main content panel - anchor to top, left, right but NOT bottom
            // This allows it to scroll when content is larger than the visible area
            panelMain.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            // Form fields - stretch horizontally
            panelUploadLicense.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxLicenseNumber.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxLicenseExpiry.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            // Save button - anchor to bottom
            btnSaveChanges.Anchor = AnchorStyles.Bottom;
        }

        private void Options_Preferences_Resize(object sender, EventArgs e)
        {
            if (!isInitializing && this.IsHandleCreated && !this.Disposing && this.Visible)
            {
                AdjustControlPositions();
            }
        }

        /// Adjust control positions based on the current form size
        private void AdjustControlPositions()
        {
            try
            {
                this.SuspendLayout();
                CenterSaveButton();
                this.ResumeLayout(true);
            }
            catch (Exception ex)
            {
                // Error handling for layout adjustments
                Console.WriteLine($"Layout adjustment error: {ex.Message}");
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

        private void buttonUploadLicense_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Select Driver's License Photo";
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp|PDF Files|*.pdf|All Files|*.*";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        licenseImagePath = openFileDialog.FileName;

                        // Display the file name in the upload panel
                        string fileName = Path.GetFileName(licenseImagePath);
                        if (fileName.Length > 30)
                        {
                            fileName = fileName.Substring(0, 27) + "...";
                        }

                        buttonUploadLicense.Text = "📄 " + fileName;
                        buttonUploadLicense.TextAlign = ContentAlignment.MiddleLeft;
                        buttonUploadLicense.Width = Math.Min(panelUploadLicense.Width - 10, TextRenderer.MeasureText(buttonUploadLicense.Text, buttonUploadLicense.Font).Width + 20);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error loading file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        /// Event handler for the Save Changes button
        private void btnSaveChanges_Click(object sender, EventArgs e)
        {

            // Validate inputs
            if (string.IsNullOrWhiteSpace(licenseImagePath) ||
                string.IsNullOrWhiteSpace(textBoxLicenseNumber.Text) ||
                string.IsNullOrWhiteSpace(textBoxLicenseExpiry.Text))
            {
                MessageBox.Show("Please fill in all fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string username = string.Empty;
                string userId = "";

                using (SqlConnection conn = _dbConnection.GetConnection())
                {
                    conn.Open();

                    // Get active username
                    string getUserQuery = "SELECT UserName FROM ActiveUser";
                    using (SqlCommand cmd = new SqlCommand(getUserQuery, conn))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            username = reader.GetString(0);
                        }
                        reader.Close();
                    }

                    // Get corresponding UserID from User table
                    string getUserIdQuery = "SELECT UserId FROM [User] WHERE UserName = @UserName";
                    using (SqlCommand cmd = new SqlCommand(getUserIdQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserName", username);
                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            //userId = Convert.ToInt32(result);
                            userId = result.ToString();
                        }
                        else
                        {
                            MessageBox.Show("User not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    // Store license image file to Media/LicenseImages/{UserID}
                    string relativeFolder = Path.Combine("Media", "LicenseImages", userId.ToString());
                    string fullFolder = Path.Combine(Application.StartupPath, relativeFolder);
                    Directory.CreateDirectory(fullFolder);

                    string fileName = Path.GetFileName(licenseImagePath);
                    string destinationPath = Path.Combine(fullFolder, fileName);
                    File.Copy(licenseImagePath, destinationPath, overwrite: true);

                    string relativeImagePath = Path.Combine(relativeFolder, fileName);

                    // Update the Customer table
                    string updateCustomerQuery = @" UPDATE Customer 
                                                    SET LicenseNo = @LicenseNo, 
                                                        LicenseExpiryDate = @LicenseExpiryDate, 
                                                        LicensePhoto = @LicensePhoto
                                                    WHERE UserId = @UserId";

                    using (SqlCommand cmd = new SqlCommand(updateCustomerQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@LicenseNo", textBoxLicenseNumber.Text.Trim());
                        cmd.Parameters.AddWithValue("@LicenseExpiryDate", textBoxLicenseExpiry.Text.Trim());
                        cmd.Parameters.AddWithValue("@LicensePhoto", relativeImagePath);
                        cmd.Parameters.AddWithValue("@UserId", userId);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Your license information has been saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("No records were updated. Please check if the user is registered as a customer.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Database error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnPersonal_Click(object sender, EventArgs e)
        {
            // Switch to the Personal tab form
            Options_Personal personalForm = new Options_Personal();
            personalForm.FormClosed += (s, args) =>
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
                // Handle any cleanup or state reset if needed
                this.Close();
            };

            personalForm.Show();
            this.Dispose();
        }

        private void btnPreferences_Click(object sender, EventArgs e)
        {
            // Already on the preferences form, so do nothing or refresh
        }

        private void btnBrowseListings_Click(object sender, EventArgs e)
        {
            // Browse listings functionality
            BrowseListings browseListingsForm = new BrowseListings();
            browseListingsForm.Show();
            this.Dispose();
        }

        private void btnManageBooking_Click(object sender, EventArgs e)
        {
            ManageBookings manageBookingsForm = new ManageBookings();
            manageBookingsForm.Show();
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
            ManageYourListings manageYourListingsForm = new ManageYourListings();
            manageYourListingsForm.Show();
            this.Dispose();
        }

        private void btnOptions_Click(object sender, EventArgs e)
        {
            // Already on the options form, so do nothing or refresh
            Options_Preferences optionsForm = new Options_Preferences();
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

                // Clear the ActiveUser table
                using (SqlConnection conn = _dbConnection.GetConnection())
                {
                    conn.Open();
                    string dropTableQuery = "DROP TABLE IF EXISTS ActiveUser;";
                    using (SqlCommand cmd = new SqlCommand(dropTableQuery, conn))
                    {
                        cmd.ExecuteNonQuery(); // Drop the ActiveUser table
                    }
                }

                // Application.Restart(); // Uncomment to restart application
                this.Close(); // Close current form
                OpenLoginUp(); // Open login form
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
            // Logo click functionality - could navigate to main page
            MessageBox.Show("Logo clicked - would typically navigate to home page.",
                "Navigation",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
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

        private void Options_Preferences_Load(object sender, EventArgs e)
        {
            this.FormClosing += new FormClosingEventHandler(MyForm_FormClosing);

            try
            {
                using (SqlConnection conn = _dbConnection.GetConnection())
                {
                    conn.Open();
                    // Get active username
                    string getUserQuery = "SELECT UserName FROM ActiveUser";
                    using (SqlCommand cmd = new SqlCommand(getUserQuery, conn))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            string username = reader.GetString(0);
                            Username_Label.Text = username;
                        }
                        reader.Close();
                    }

                    //string additionalInfoQuery = "SELECT LicenseNo, LicenseExpiryDate, LicensePhoto FROM Customer WHERE UserId = (SELECT UserId FROM ActiveUser)";

                    string getUserDataQuery1 = "SELECT " +
                           "Customer.LicenseNo, " +
                           "Customer.LicenseExpiryDate, " +
                           "Customer.LicensePhoto " +
                           "FROM Customer " +
                           "INNER JOIN [User] ON Customer.UserId = [User].UserId " +
                           "INNER JOIN ActiveUser ON [User].UserName = ActiveUser.UserName;";

                    using (SqlCommand cmd = new SqlCommand(getUserDataQuery1, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                textBoxLicenseNumber.Text = reader["LicenseNo"].ToString();
                                textBoxLicenseExpiry.Text = reader["LicenseExpiryDate"].ToString();
                                
                                string licensePhotoPath = reader["LicensePhoto"].ToString();
                                if (!string.IsNullOrEmpty(licensePhotoPath))
                                {
                                    // Load the image from the path
                                    string fullPath = Path.Combine(Application.StartupPath, licensePhotoPath);
                                    if (File.Exists(fullPath))
                                    {
                                        panelUploadLicense.Visible = true; // Show the upload panel
                                    }
                                    
                                }
                            }
                            else
                            {
                                MessageBox.Show("No user data found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }

                    }

                }
            }
            catch
            {
                Username_Label.Text = "Loading..";
            }

            


        }

        private void Username_Label_Click(object sender, EventArgs e)
        {

        }
    }
}
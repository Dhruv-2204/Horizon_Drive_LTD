using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

//Options_Preferences.cs
namespace Horizon_Drive_LTD
{
    public partial class Options_Preferences : Form
    {
        private string licenseImagePath = string.Empty;
        private FormWindowState lastWindowState;
        private Size originalSize;
        private bool isInitializing = true;

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

            // Here you would save the user's information to a database or file
            // For now, we'll just show a success message
            MessageBox.Show("Your license information has been saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnPersonal_Click(object sender, EventArgs e)
        {
            // Switch to the Personal tab form
            Options_Personal personalForm = new Options_Personal();
            personalForm.Show();
            this.Hide();
        }

        private void btnPreferences_Click(object sender, EventArgs e)
        {
            // Already on the preferences form, so do nothing or refresh
        }

        private void btnBrowseListings_Click(object sender, EventArgs e)
        {
            // Browse listings functionality
            MessageBox.Show("Browse Listings functionality would open a form to view available car listings.",
                           "Browse Listings",
                           MessageBoxButtons.OK,
                           MessageBoxIcon.Information);
        }

        private void btnManageBooking_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Manage Booking functionality would open a form to view and manage bookings.",
                           "Manage Bookings",
                           MessageBoxButtons.OK,
                           MessageBoxIcon.Information);
        }

        private void btnListCar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("List a Car functionality would open a form to add a new listing.",
                           "List a Car",
                           MessageBoxButtons.OK,
                           MessageBoxIcon.Information);
        }

        private void btnManageYourListings_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Manage Your Listings functionality would open a form to view and manage your car listings.",
                           "Manage Your Listings",
                           MessageBoxButtons.OK,
                           MessageBoxIcon.Information);
        }

        private void btnOptions_Click(object sender, EventArgs e)
        {
            // Already on the options form, so do nothing or refresh
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

                // Application.Restart(); // Uncomment to restart application
                this.Close(); // Close current form
            }
        }

        private void pictureBoxLogo_Click(object sender, EventArgs e)
        {
            // Logo click functionality - could navigate to main page
            MessageBox.Show("Logo clicked - would typically navigate to home page.",
                "Navigation",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
    }
}
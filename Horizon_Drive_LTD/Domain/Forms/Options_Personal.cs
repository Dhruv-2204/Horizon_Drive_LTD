using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Horizon_Drive_LTD
{
    public partial class Options_Personal : Form
    {
        private string profileImagePath = string.Empty;
        private FormWindowState lastWindowState;
        private Size originalSize;
        private bool isInitializing = true;

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
                        profileImagePath = openFileDialog.FileName;
                        pictureBoxProfile.Image = Image.FromFile(profileImagePath);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error loading image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void buttonCamera_Click(object sender, EventArgs e)
        {
            // Same functionality as clicking the profile picture
            pictureBoxProfile_Click(sender, e);
        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            // Validate inputs
            if (string.IsNullOrWhiteSpace(textBoxFirstName.Text) ||
                string.IsNullOrWhiteSpace(textBoxLastName.Text) ||
                string.IsNullOrWhiteSpace(textBoxEmail.Text) ||
                string.IsNullOrWhiteSpace(textBoxPhone.Text) ||
                string.IsNullOrWhiteSpace(textBoxPassword.Text) ||
                string.IsNullOrWhiteSpace(textBoxAddress.Text))
            {
                MessageBox.Show("Please fill in all fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Here you would save the user's information to a database or file
            // For now, we'll just show a success message
            MessageBox.Show("Your information has been saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            this.Hide();
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
                // this.Close(); // Uncomment to close current form
            }
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
            // Browse listings functionality
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
    }

    //public class RoundedButton : Button
    //{
    //    // Ensure there's only one declaration of borderRadius
    //    private int borderRadius = 26;

    //    public RoundedButton()
    //    {
    //        this.FlatStyle = FlatStyle.Flat;
    //        this.FlatAppearance.BorderSize = 0;
    //    }

    //    protected override void OnPaint(PaintEventArgs e)
    //    {
    //        // Enable anti-aliasing for smooth edges
    //        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

    //        GraphicsPath path = new GraphicsPath();
    //        Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);

    //        // Create rounded rectangle with the specified corner radius
    //        int diameter = borderRadius * 2;
    //        path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90);
    //        path.AddArc(rect.Width - diameter, rect.Y, diameter, diameter, 270, 90);
    //        path.AddArc(rect.Width - diameter, rect.Height - diameter, diameter, diameter, 0, 90);
    //        path.AddArc(rect.X, rect.Height - diameter, diameter, diameter, 90, 90);
    //        path.CloseAllFigures();

    //        // Set the button's region to our rounded rectangle
    //        this.Region = new Region(path);

    //        // Draw the button
    //        base.OnPaint(e);
    //    }
    //}
}
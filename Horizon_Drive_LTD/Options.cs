using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Horizon_Drive_LTD
{
    public partial class Options : Form
    {
        private string profileImagePath = string.Empty;

        public Options()
        {
            InitializeComponent();
            this.ClientSize = new Size(1280, 800);
            this.MinimumSize = new Size(1000, 700);
            SetupTabButtons();
            //AdjustControlPositions();
        }



        private void SetupTabButtons()
        {
            // Highlight the Personal button as it's the default view
            btnPersonal.BackColor = Color.FromArgb(173, 216, 230);
            btnPersonal.ForeColor = Color.Black;

            btnPreferences.BackColor = Color.FromArgb(30, 85, 110);
            btnPreferences.ForeColor = Color.White;
        }

        //private void Options_Resize(object sender, EventArgs e)
        //{
        //    AdjustControlPositions();
        //}

        //private void AdjustControlPositions()
        //{
        //    // Center the profile image panel
        //    int mainWidth = mainScrollPanel.ClientSize.Width;
        //    panelProfileImage.Left = (mainWidth - panelProfileImage.Width) / 2;

        //    // Reposition camera button
        //    buttonCamera.Left = panelProfileImage.Left + panelProfileImage.Width - 32;
        //    buttonCamera.Top = panelProfileImage.Top + panelProfileImage.Height - 34;

        //    // Center the Save Changes button
        //    btnSaveChanges.Left = (mainWidth - btnSaveChanges.Width) / 2;

        //    // Make text boxes fill available width with proper margins
        //    int textBoxWidth = mainWidth - 120; // 60px margin on each side

        //    // Adjust the width of text boxes and panels
        //    textBoxEmail.Width = textBoxWidth;
        //    textBoxPassword.Width = textBoxWidth;
        //    textBoxAddress.Width = textBoxWidth;
        //    panelPhone.Width = textBoxWidth;
        //    panelNameFields.Width = textBoxWidth;

        //    // Update the first and last name text box widths
        //    int halfWidth = (textBoxWidth - 40) / 2; // 40px gap between fields
        //    textBoxFirstName.Width = halfWidth;
        //    textBoxLastName.Width = halfWidth;
        //    textBoxLastName.Left = halfWidth + 40;
        //    labelLastName.Left = textBoxLastName.Left;
        //}

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
            btnPreferences.BackColor = Color.FromArgb(173, 216, 230);
            btnPreferences.ForeColor = Color.Black;

            btnPersonal.BackColor = Color.FromArgb(30, 85, 110);
            btnPersonal.ForeColor = Color.White;

            // In a real application, you would show the preferences panel/content here
            MessageBox.Show("Preferences panel would be shown here.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        }

        private void panelTabs_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBoxPhone_TextChanged(object sender, EventArgs e)
        {

        }

        private void panelMain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBoxEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelPassword_Click(object sender, EventArgs e)
        {

        }

        private void textBoxLastName_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxLastName_TextChanged_1(object sender, EventArgs e)
        {

        }
    }

    // Include the RoundedButton class in the same file
    public class RoundedButton : Button
    {
        private int borderRadius = 26;

        public RoundedButton()
        {
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            // Enable anti-aliasing for smooth edges
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            GraphicsPath path = new GraphicsPath();
            Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);

            // Create rounded rectangle with the specified corner radius
            int diameter = borderRadius * 2;
            path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90);
            path.AddArc(rect.Width - diameter, rect.Y, diameter, diameter, 270, 90);
            path.AddArc(rect.Width - diameter, rect.Height - diameter, diameter, diameter, 0, 90);
            path.AddArc(rect.X, rect.Height - diameter, diameter, diameter, 90, 90);
            path.CloseAllFigures();

            // Set the button's region to our rounded rectangle
            this.Region = new Region(path);

            // Draw the button
            base.OnPaint(e);
        }
    }
}
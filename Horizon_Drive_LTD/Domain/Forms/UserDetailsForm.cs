using Horizon_Drive_LTD.Domain.Entities;
using Horizon_Drive_LTD.BusinessLogic;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace User_managing
{
    public partial class UserDetailsForm : Form
    {
        private User _user;
        private readonly DatabaseConnection _dbConnection;
        private bool _isEditMode = false;
        private bool _dataChanged = false;

        public UserDetailsForm(User user, DatabaseConnection dbConnection)
        {
            InitializeComponent();

            _user = user;
            _dbConnection = dbConnection;

            LoadUserData();
            SetRoundedButtons();
        }

        private void LoadUserData()
        {
            // Populate the form fields with user data
            txtUserId.Text = _user.UserId;
            txtUsername.Text = _user.UserName;
            txtFirstName.Text = _user.FirstName;
            txtLastName.Text = _user.LastName;
            txtEmail.Text = _user.Email;
            txtPhone.Text = _user.TelephoneNo.ToString();
            txtAddress.Text = _user.Address;

            // Set the date of birth
            DateTime dob = new DateTime(_user.DOB.Year, _user.DOB.Month, _user.DOB.Day);
            dtpDOB.Value = dob;

            // Load profile picture if available
            LoadProfilePicture();
        }

        private void LoadProfilePicture()
        {
            try
            {
                if (!string.IsNullOrEmpty(_user.ProfilePicture))
                {
                    string imagePath = Path.Combine(Application.StartupPath, "Media", "ProfilePictures", _user.ProfilePicture);
                    if (File.Exists(imagePath))
                    {
                        picProfile.Image = Image.FromFile(imagePath);
                    }
                    else
                    {
                        // Load default profile picture
                        string defaultImagePath = Path.Combine(Application.StartupPath, "Media", "Images", "default_profile.png");
                        if (File.Exists(defaultImagePath))
                        {
                            picProfile.Image = Image.FromFile(defaultImagePath);
                        }
                    }
                }
                else
                {
                    // Load default profile picture
                    string defaultImagePath = Path.Combine(Application.StartupPath, "Media", "Images", "default_profile.png");
                    if (File.Exists(defaultImagePath))
                    {
                        picProfile.Image = Image.FromFile(defaultImagePath);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading profile picture: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetRoundedButtons()
        {
            // Apply rounded corners to buttons
            SetRoundedCorner(btnEdit, 25);
            SetRoundedCorner(btnSave, 25);
            SetRoundedCorner(btnClose, 25);
            SetRoundedCorner(btnChangeImage, 15);
        }

        private void SetRoundedCorner(Button button, int radius)
        {
            // Code to round the corners of the button
            Rectangle bounds = button.ClientRectangle;
            int diameter = radius * 2;
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(bounds.X, bounds.Y, diameter, diameter, 180, 90);
            path.AddArc(bounds.Right - diameter, bounds.Y, diameter, diameter, 270, 90);
            path.AddArc(bounds.Right - diameter, bounds.Bottom - diameter, diameter, diameter, 0, 90);
            path.AddArc(bounds.X, bounds.Bottom - diameter, diameter, diameter, 90, 90);
            path.CloseFigure();
            button.Region = new Region(path);
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            // Enable editing of fields
            _isEditMode = true;

            // Enable editable fields
            txtFirstName.ReadOnly = false;
            txtLastName.ReadOnly = false;
            txtEmail.ReadOnly = false;
            txtPhone.ReadOnly = false;
            txtAddress.ReadOnly = false;
            dtpDOB.Enabled = true;
            btnChangeImage.Enabled = true;

            // Update buttons
            btnEdit.Enabled = false;
            btnSave.Enabled = true;

            // Change background color of editable fields
            txtFirstName.BackColor = Color.FromArgb(255, 255, 220);
            txtLastName.BackColor = Color.FromArgb(255, 255, 220);
            txtEmail.BackColor = Color.FromArgb(255, 255, 220);
            txtPhone.BackColor = Color.FromArgb(255, 255, 220);
            txtAddress.BackColor = Color.FromArgb(255, 255, 220);

            // Focus on first editable field
            txtFirstName.Focus();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate input
                if (string.IsNullOrWhiteSpace(txtFirstName.Text) ||
                    string.IsNullOrWhiteSpace(txtLastName.Text) ||
                    string.IsNullOrWhiteSpace(txtEmail.Text) ||
                    string.IsNullOrWhiteSpace(txtPhone.Text) ||
                    string.IsNullOrWhiteSpace(txtAddress.Text))
                {
                    MessageBox.Show("Please fill in all required fields.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validate email format
                if (!IsValidEmail(txtEmail.Text))
                {
                    MessageBox.Show("Please enter a valid email address.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEmail.Focus();
                    return;
                }

                // Validate phone number
                if (!int.TryParse(txtPhone.Text, out int phoneNumber))
                {
                    MessageBox.Show("Please enter a valid phone number.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPhone.Focus();
                    return;
                }

                // Update user object with form data
                _user.FirstName = txtFirstName.Text;
                _user.LastName = txtLastName.Text;
                _user.Email = txtEmail.Text;
                _user.TelephoneNo = phoneNumber;
                _user.Address = txtAddress.Text;
                _user.DOB = new DateOnly(dtpDOB.Value.Year, dtpDOB.Value.Month, dtpDOB.Value.Day);

                // Save changes to database
                SaveUserChanges();

                // Disable editing mode
                DisableEditMode();

                // Set flag that data has changed
                _dataChanged = true;

                MessageBox.Show("User information updated successfully.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving user data: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void SaveUserChanges()
        {
            try
            {
                using (SqlConnection connection = _dbConnection.GetConnection())
                {
                    connection.Open();

                    string query = @"UPDATE [User] 
                                 SET FirstName = @FirstName,
                                     LastName = @LastName,
                                     Email = @Email,
                                     TelephoneNo = @TelephoneNo,
                                     Address = @Address,
                                     DOB = @DOB,
                                     ProfilePicture = @ProfilePicture
                                 WHERE UserId = @UserId";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@FirstName", _user.FirstName);
                        command.Parameters.AddWithValue("@LastName", _user.LastName);
                        command.Parameters.AddWithValue("@Email", _user.Email);
                        command.Parameters.AddWithValue("@TelephoneNo", _user.TelephoneNo);
                        command.Parameters.AddWithValue("@Address", _user.Address);
                        command.Parameters.AddWithValue("@DOB", new DateTime(_user.DOB.Year, _user.DOB.Month, _user.DOB.Day));
                        command.Parameters.AddWithValue("@ProfilePicture",
                            string.IsNullOrEmpty(_user.ProfilePicture) ? DBNull.Value : (object)_user.ProfilePicture);
                        command.Parameters.AddWithValue("@UserId", _user.UserId);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected <= 0)
                        {
                            throw new Exception("No records were updated.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating user in database: " + ex.Message);
            }
        }

        private void DisableEditMode()
        {
            _isEditMode = false;

            // Disable editable fields
            txtFirstName.ReadOnly = true;
            txtLastName.ReadOnly = true;
            txtEmail.ReadOnly = true;
            txtPhone.ReadOnly = true;
            txtAddress.ReadOnly = true;
            dtpDOB.Enabled = false;
            btnChangeImage.Enabled = false;

            // Update buttons
            btnEdit.Enabled = true;
            btnSave.Enabled = false;

            // Reset background color
            txtFirstName.BackColor = SystemColors.Window;
            txtLastName.BackColor = SystemColors.Window;
            txtEmail.BackColor = SystemColors.Window;
            txtPhone.BackColor = SystemColors.Window;
            txtAddress.BackColor = SystemColors.Window;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            // Check if there are unsaved changes
            if (_isEditMode)
            {
                DialogResult result = MessageBox.Show("You have unsaved changes. Are you sure you want to close?",
                    "Unsaved Changes", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.No)
                {
                    return;
                }
            }

            // Set DialogResult to OK if data has changed
            if (_dataChanged)
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                this.DialogResult = DialogResult.Cancel;
            }

            // Close the form
            this.Close();
        }

        private void BtnChangeImage_Click(object sender, EventArgs e)
        {
            // Open file dialog to select a new profile picture
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Title = "Select Profile Picture",
                Filter = "Image Files (*.jpg; *.jpeg; *.png)|*.jpg;*.jpeg;*.png",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Generate a unique filename for the new image
                    string fileName = $"{_user.UserId}_{DateTime.Now.Ticks}{Path.GetExtension(openFileDialog.FileName)}";
                    string profilePicturePath = Path.Combine(Application.StartupPath, "Media", "ProfilePictures");

                    // Create directory if it doesn't exist
                    if (!Directory.Exists(profilePicturePath))
                    {
                        Directory.CreateDirectory(profilePicturePath);
                    }

                    // Full path for the new image
                    string newImagePath = Path.Combine(profilePicturePath, fileName);

                    // Copy the selected image to the profile pictures folder
                    File.Copy(openFileDialog.FileName, newImagePath);

                    // If there's an existing image and it's different from the default, delete it
                    if (!string.IsNullOrEmpty(_user.ProfilePicture))
                    {
                        string oldImagePath = Path.Combine(profilePicturePath, _user.ProfilePicture);
                        if (File.Exists(oldImagePath))
                        {
                            // Try to delete the old image, but don't throw an exception if it fails
                            try { File.Delete(oldImagePath); } catch { }
                        }
                    }

                    // Update picturebox with new image
                    if (picProfile.Image != null)
                    {
                        picProfile.Image.Dispose();
                    }
                    picProfile.Image = Image.FromFile(newImagePath);

                    // Update the user object with the new profile picture filename
                    _user.ProfilePicture = fileName;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error changing profile picture: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
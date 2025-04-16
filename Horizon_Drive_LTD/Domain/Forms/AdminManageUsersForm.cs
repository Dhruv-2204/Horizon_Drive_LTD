using Horizon_Drive_LTD.Domain.Forms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Upload_cars;
using User_managing;
using WindowsFormsApp1;
using Horizon_Drive_LTD.BusinessLogic;
using Horizon_Drive_LTD.BusinessLogic.Repositories;
using Horizon_Drive_LTD.Domain.Entities;
using splashscreen;

namespace Manage_user_search_page
{
    public partial class Manage_User_Page : Form
    {
        private bool isClosing = false;
        private bool userConfirmedExit = false;
        private readonly DatabaseConnection _dbConnection;
        private readonly UserRepository _userRepository;
        private List<User> _allUsers;

        public Manage_User_Page()
        {
            InitializeComponent();
            this.FormClosing += Manage_User_Page_FormClosing;
            // Initialize database connection and repository
            _dbConnection = new DatabaseConnection();
            _userRepository = new UserRepository(_dbConnection);

            // Load the image from the folder Images
            LoadImage();

            // Set rounded corners for buttons
            SetRoundedCorner(Manage_Users, 25);
            SetRoundedCorner(Manage_Cars_btn, 25);
            SetRoundedCorner(Manage_bookings_btn, 25);
            SetRoundedCorner(Logout_btn, 25);
            SetRoundedCorner(Managing_users_click_btn, 25);
            SetRoundedCorner(Maintenance_btn, 25);

            // Configure DataGridView
            ConfigureDataGridView();

            // Load users into DataGridView
            LoadUsers();

           
        }

        private void Manage_User_Page_FormClosing(object sender, FormClosingEventArgs e)
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



        private void ConfigureDataGridView()
        {
            // Configure the DataGridView
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.MultiSelect = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.RowTemplate.Height = 40;
            dataGridView1.BackgroundColor = Color.White;

            // Clear existing columns and add our own
            dataGridView1.Columns.Clear();

            // UserId column
            DataGridViewTextBoxColumn idColumn = new DataGridViewTextBoxColumn();
            idColumn.DataPropertyName = "UserId";
            idColumn.HeaderText = "User ID";
            idColumn.Width = 80;
            dataGridView1.Columns.Add(idColumn);

            // UserName column
            DataGridViewTextBoxColumn usernameColumn = new DataGridViewTextBoxColumn();
            usernameColumn.DataPropertyName = "UserName";
            usernameColumn.HeaderText = "Username";
            usernameColumn.Width = 120;
            dataGridView1.Columns.Add(usernameColumn);

            // FullName column (combination of FirstName and LastName)
            DataGridViewTextBoxColumn fullNameColumn = new DataGridViewTextBoxColumn();
            fullNameColumn.HeaderText = "Full Name";
            fullNameColumn.Width = 150;
            fullNameColumn.Name = "FullName";
            dataGridView1.Columns.Add(fullNameColumn);

            // Email column
            DataGridViewTextBoxColumn emailColumn = new DataGridViewTextBoxColumn();
            emailColumn.DataPropertyName = "Email";
            emailColumn.HeaderText = "Email";
            emailColumn.Width = 200;
            dataGridView1.Columns.Add(emailColumn);

            // Add row styling and double click event
            dataGridView1.CellFormatting += DataGridView1_CellFormatting;
            dataGridView1.DoubleClick += DataGridView1_DoubleClick;

            // Custom row styling
            dataGridView1.RowsDefaultCellStyle.BackColor = Color.White;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(45, 68, 135);
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 48, 65);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.ColumnHeadersHeight = 40;
            dataGridView1.EnableHeadersVisualStyles = false;
        }

        private void LoadUsers()
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                // Get all users from repository
                _allUsers = _userRepository.GetAllUsers();

                // Bind users to DataGridView
                BindUsersToDataGridView(_allUsers);

                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show("Error loading users: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BindUsersToDataGridView(List<User> users)
        {
            // Create binding source
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = users;
            dataGridView1.DataSource = bindingSource;

            // Refresh DataGridView
            dataGridView1.Refresh();
        }

        private void DataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Format the FullName column by combining FirstName and LastName
            if (dataGridView1.Columns[e.ColumnIndex].Name == "FullName" && e.RowIndex >= 0 &&
                dataGridView1.DataSource != null)
            {
                try
                {
                    User user = (User)((BindingSource)dataGridView1.DataSource)[e.RowIndex];
                    e.Value = $"{user.FirstName} {user.LastName}";
                    e.FormattingApplied = true;
                }
                catch (Exception)
                {
                    // Handle any exceptions in getting the data
                    e.Value = "N/A";
                    e.FormattingApplied = true;
                }
            }
        }

        private void DataGridView1_DoubleClick(object sender, EventArgs e)
        {
            ShowSelectedUserDetails();
        }

        private void ShowSelectedUserDetails()
        {
            if (dataGridView1.SelectedRows.Count > 0 && dataGridView1.DataSource != null)
            {
                try
                {
                    int selectedIndex = dataGridView1.SelectedRows[0].Index;
                    User selectedUser = (User)((BindingSource)dataGridView1.DataSource)[selectedIndex];

                    // Create and show user details dialog
                    using (var detailsForm = new AdminUserDetailsForm(selectedUser, _dbConnection))
                    {
                        if (detailsForm.ShowDialog() == DialogResult.OK)
                        {
                            // Reload data if changes were made
                            LoadUsers();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error displaying user details: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a user from the list", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Manage_users_search_user(object sender, EventArgs e)
        {
            // Get the search text
            string searchText = "";
            if (sender is TextBox textBox)
            {
                searchText = textBox.Text.Trim().ToLower();
            }

            try
            {
                if (string.IsNullOrEmpty(searchText))
                {
                    // Show all users
                    BindUsersToDataGridView(_allUsers);
                }
                else
                {
                    // Filter users based on search text
                    List<User> filteredUsers = _allUsers.Where(u =>
                        u.UserId.ToLower().Contains(searchText) ||
                        u.UserName.ToLower().Contains(searchText) ||
                        u.FirstName.ToLower().Contains(searchText) ||
                        u.LastName.ToLower().Contains(searchText) ||
                        u.Email.ToLower().Contains(searchText)
                    ).ToList();

                    BindUsersToDataGridView(filteredUsers);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error searching users: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void Manage_users_click(object sender, EventArgs e)
        {
            // Now this button directly opens the details of the selected user
            ShowSelectedUserDetails();
        }

        private void Upload_Cars_click_btn(object sender, EventArgs e)
        {
            var manage_files_Page = new Admin_Managing_files();
            manage_files_Page.Show();
            this.Dispose();
        }

        private void Manage_bookings_click_btn(object sender, EventArgs e)
        {
            var manage_user_Page = new AdminManageBookingsForm();
            manage_user_Page.Show();
            this.Dispose();
        }

        private void LoadImage()
        {
            //Combining folder name and image name to get the full path to display the image
            string imagePath = Path.Combine(System.Windows.Forms.Application.StartupPath, "Media", "Images", "HORIZONDRIVE_LOGO.png");

            // condition to check if the image exists
            if (File.Exists(imagePath))
            {
                pictureBox1.Image = Image.FromFile(imagePath);
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            }
            else
            {
                MessageBox.Show("Image not found at: " + imagePath);
                //error message window pops up if image is not found
            }
        }

        private void Maintenance_btn_click(object sender, EventArgs e)
        {
            var manage_car_Page = new AdminMaintenance(); // gets form Managing_cars
            manage_car_Page.Show();                  // Shows the new form manage_cars
            this.Dispose();
        }

        private void Logout_click_btn(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
               "Are you sure you want to log out?",
               "Confirm Logout",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Question
           );

            if (result == DialogResult.Yes)
            {
                var login = new Login();
                login.Show();
                this.Hide();

            }
        }

        private void Search_Users_Click(object sender, EventArgs e)
        {

        }

        private void Manage_Users_menu_Click_btn(object sender, EventArgs e)
        {

            LoadUsers();
        }

        private void user_background_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Manage_User_Page_Load(object sender, EventArgs e)
        {

        }
    }
}
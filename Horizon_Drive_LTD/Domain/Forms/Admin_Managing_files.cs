using Horizon_Drive_LTD.BusinessLogic;
using Horizon_Drive_LTD.BusinessLogic.Repositories;
using Horizon_Drive_LTD.DataStructure;
using Horizon_Drive_LTD.Domain.Entities;
using Horizon_Drive_LTD.Domain.Forms;
using Manage_user_search_page;
using Microsoft.Data.SqlClient;
using splashscreen;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WindowsFormsApp1;

namespace Upload_cars
{
    public partial class Admin_Managing_files : Form
    {
        private readonly DatabaseConnection _dbConnection;
        private readonly Admin_managing_files_repo _adminManagingFiles;
        private readonly string[] _validFileTypes = { "car.txt", "car.csv", "user.txt", "user.csv", "customer.txt", "customer.csv" };

        public Admin_Managing_files()
        {
            InitializeComponent();
            LoadImage();
            SetRoundedCorner(Manage_users, 25);
            SetRoundedCorner(Upload_Cars_btn, 25);
            SetRoundedCorner(Manage_bookings_btn, 25);
            SetRoundedCorner(Logout_btn, 25);
            SetRoundedCorner(Maintenance_btn, 25);
            _dbConnection = new DatabaseConnection();
            _adminManagingFiles = new Admin_managing_files_repo(_dbConnection);

            // Initialize the file path label
            labelfilepath.Text = "";
            labelfilepath.Visible = false;

            // Set up event handlers
            Logout_btn.Click += Logout_btn_Click;
        }

        private void SetRoundedCorner(Button button, int radius)
        {
            Rectangle bounds = button.ClientRectangle;
            int diameter = radius * 2;

            GraphicsPath path1 = new GraphicsPath();
            path1.StartFigure();
            path1.AddArc(bounds.X, bounds.Y, diameter, diameter, 180, 90);
            path1.AddArc(bounds.Right - diameter, bounds.Y, diameter, diameter, 270, 90);
            path1.AddArc(bounds.Right - diameter, bounds.Bottom - diameter, diameter, diameter, 0, 90);
            path1.AddArc(bounds.X, bounds.Bottom - diameter, diameter, diameter, 90, 90);
            path1.CloseFigure();
            button.Region = new Region(path1);
        }

        private void LoadImage()
        {
            string imagePath = Path.Combine(Application.StartupPath, "Media", "Images", "HORIZONDRIVE_LOGO.png");

            if (File.Exists(imagePath))
            {
                pictureBox1.Image = Image.FromFile(imagePath);
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            }
            else
            {
                MessageBox.Show("Image not found at: " + imagePath);
            }
        }

        private void Manage_Users_Click(object sender, EventArgs e)
        {
            var manage_user_Page = new Manage_User_Page();
            manage_user_Page.Show();
            this.Hide();
        }

        private void Manage_bookings_btn_Click(object sender, EventArgs e)
        {
            var manage_car_Page = new Manage_bookings();
            manage_car_Page.Show();
            this.Dispose();
        }

        private void Maintenance_click(object sender, EventArgs e)
        {
            var manage_car_Page = new Maintenance();
            manage_car_Page.Show();
            this.Dispose();
        }

        private void Logout_btn_Click(object sender, EventArgs e)
        {
            var loginForm = new Login();
            loginForm.Show();
            this.Dispose();
        }

        private void Upload_File_btn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Text files (*.txt;*.csv)|*.txt;*.csv";
                openFileDialog.Title = "Select a Data File";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedFile = openFileDialog.FileName;
                    string fileName = Path.GetFileName(selectedFile).ToLower();

                    // Validate if it's a supported file type
                    if (!_validFileTypes.Contains(fileName))
                    {
                        MessageBox.Show("Unsupported file type. Please upload one of the following files:\n" +
                                       "- car.txt/car.csv\n" +
                                       "- user.txt/user.csv\n" +
                                       "- customer.txt/customer.csv",
                                       "Invalid File", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    labelfilepath.Text = selectedFile;
                    labelfilepath.Visible = true;

                    // Update UI to show file selected
                    DragDropListBox.Items.Clear();
                    DragDropListBox.Items.Add($"Selected file: {fileName}");
                    DragDropListBox.Items.Add(""); // Empty line

                    try
                    {
                        // Preview the file contents (limited to first 50 lines)
                        int lineCount = 0;
                        DragDropListBox.Items.Add("File Preview:");
                        foreach (var line in File.ReadLines(selectedFile))
                        {
                            if (string.IsNullOrWhiteSpace(line)) continue;

                            DragDropListBox.Items.Add(line);
                            lineCount++;

                            if (lineCount >= 20)
                            {
                                DragDropListBox.Items.Add("...");
                                DragDropListBox.Items.Add($"(Showing first {lineCount} of {File.ReadLines(selectedFile).Count()} lines)");
                                break;
                            }
                        }

                        // Provide guidance based on file type
                        DragDropListBox.Items.Add("");
                        if (fileName.StartsWith("user"))
                        {
                            DragDropListBox.Items.Add("Ready to process user data. Click 'Save File To Database' to continue.");
                        }
                        else if (fileName.StartsWith("car"))
                        {
                            DragDropListBox.Items.Add("Ready to process car data. Make sure users are imported first.");

                            // Check if users exist in the database
                            int userCount = GetUserCount();
                            if (userCount == 0)
                            {
                                DragDropListBox.Items.Add("WARNING: No users found in database. Please import users first.");
                            }
                            else
                            {
                                DragDropListBox.Items.Add($"Found {userCount} users in the database.");
                            }
                        }
                        else if (fileName.StartsWith("customer"))
                        {
                            DragDropListBox.Items.Add("Ready to process customer data. Make sure users are imported first.");

                            // Check if users exist in the database
                            int userCount = GetUserCount();
                            if (userCount == 0)
                            {
                                DragDropListBox.Items.Add("WARNING: No users found in database. Please import users first.");
                            }
                            else
                            {
                                DragDropListBox.Items.Add($"Found {userCount} users in the database.");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error reading file: " + ex.Message, "File Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private int GetUserCount()
        {
            try
            {
                using (SqlConnection conn = _dbConnection.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM [User]";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        return (int)cmd.ExecuteScalar();
                    }
                }
            }
            catch
            {
                return 0; // Return 0 on error, which will trigger a warning
            }
        }

        private void Save_File_Click(object sender, EventArgs e)
        {
            string filePath = labelfilepath.Text;

            if (string.IsNullOrWhiteSpace(filePath) || !File.Exists(filePath))
            {
                MessageBox.Show("Please select a valid file first.", "No File Selected",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string fileName = Path.GetFileName(filePath).ToLower();
            Cursor = Cursors.WaitCursor; // Change cursor to indicate processing

            try
            {
                if (fileName.StartsWith("car"))
                {
                    // Check if users exist before processing cars
                    int userCount = GetUserCount();
                    if (userCount == 0)
                    {
                        DialogResult result = MessageBox.Show(
                            "No users found in the database. Cars must be associated with existing users.\n\n" +
                            "Please import user data first before importing cars.\n\n" +
                            "Do you want to continue anyway?",
                            "No Users Found",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Warning);

                        if (result == DialogResult.No)
                        {
                            Cursor = Cursors.Default;
                            return;
                        }
                    }

                    ProcessCarFile(filePath);
                }
                else if (fileName.StartsWith("user"))
                {
                    ProcessUserFile(filePath);
                }
                else if (fileName.StartsWith("customer"))
                {
                    // Check if users exist before processing customers
                    int userCount = GetUserCount();
                    if (userCount == 0)
                    {
                        DialogResult result = MessageBox.Show(
                            "No users found in the database. Customers must be associated with existing users.\n\n" +
                            "Please import user data first before importing customers.\n\n" +
                            "Do you want to continue anyway?",
                            "No Users Found",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Warning);

                        if (result == DialogResult.No)
                        {
                            Cursor = Cursors.Default;
                            return;
                        }
                    }

                    ProcessCustomerFile(filePath);
                }
                else
                {
                    MessageBox.Show("Unsupported file. Please upload car.txt, customer.txt, or user.txt only.",
                        "Invalid File", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error processing file: " + ex.Message, "Processing Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default; // Restore cursor
            }
        }

        private void ProcessCarFile(string filePath)
        {
            var carHashTable = new HashTable<string, Cars>(10000);
            int totalLines = 0;
            int validLines = 0;
            int errorLines = 0;
            StringBuilder errorLog = new StringBuilder();

            foreach (var line in File.ReadLines(filePath))
            {
                totalLines++;
                if (string.IsNullOrWhiteSpace(line)) continue;

                var words = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (words.Length < 22)
                {
                    errorLines++;
                    errorLog.AppendLine($"Line {totalLines}: Insufficient data columns ({words.Length}/22)");
                    continue;
                }

                try
                {
                    Cars car = new Cars(
                        carid: words[0],
                        userid: words[1],
                        carBrand: words[2],
                        category: words[3],
                        registrationNo: words[4],
                        model: words[5],
                        years: int.Parse(words[6]),
                        colour: words[7],
                        features: words[8],
                        desc: words[9],
                        price: decimal.Parse(words[10]),
                        seat: int.Parse(words[11]),
                        engine: words[12],
                        rating: decimal.Parse(words[13]),
                        power: words[14],
                        drive: words[15],
                        fuel: words[16],
                        transmission: words[17],
                        status: words[18],
                        availabilitystart: DateTime.Parse(words[19]),
                        availabilityend: DateTime.Parse(words[20]),
                        carimagepath: words[21]
                    );

                    carHashTable.Insert(car.CarID, car);
                    validLines++;
                }
                catch (Exception ex)
                {
                    errorLines++;
                    errorLog.AppendLine($"Line {totalLines}: {ex.Message}");
                }
            }

            // Only proceed if we have valid data
            if (validLines > 0)
            {
                _adminManagingFiles.SaveCarToDatabase(carHashTable);
            }
            else
            {
                MessageBox.Show("No valid car data was found in the file.", "No Valid Data",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            // Show error log if needed
            if (errorLines > 0)
            {
                // Only show first 15 errors to avoid huge message box
                string errors = errorLog.ToString();
                if (errors.Split('\n').Length > 15)
                {
                    var firstErrors = string.Join("\n", errors.Split('\n').Take(15));
                    errors = firstErrors + $"\n\n...and {errorLines - 15} more errors.";
                }

                using (var form = new Form())
                {
                    form.Text = "Import Errors";
                    form.Size = new Size(600, 400);
                    form.StartPosition = FormStartPosition.CenterParent;

                    var textBox = new TextBox
                    {
                        Multiline = true,
                        ReadOnly = true,
                        ScrollBars = ScrollBars.Vertical,
                        Dock = DockStyle.Fill,
                        Text = $"Import Summary:\n" +
                               $"Total lines: {totalLines}\n" +
                               $"Valid entries: {validLines}\n" +
                               $"Error entries: {errorLines}\n\n" +
                               $"Error Details:\n{errors}"
                    };

                    form.Controls.Add(textBox);
                    form.ShowDialog();
                }
            }
        }

        private void ProcessUserFile(string filePath)
        {
            var userHashTable = new HashTable<string, User>(10000);
            int totalLines = 0;
            int validLines = 0;
            int errorLines = 0;
            StringBuilder errorLog = new StringBuilder();

            foreach (var line in File.ReadLines(filePath))
            {
                totalLines++;
                if (string.IsNullOrWhiteSpace(line)) continue;

                var words = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (words.Length < 10)
                {
                    errorLines++;
                    errorLog.AppendLine($"Line {totalLines}: Insufficient data columns ({words.Length}/10)");
                    continue;
                }

                try
                {
                    User user = new User(
                        userid: words[0],
                        username: words[1],
                        firstname: words[2],
                        lastname: words[3],
                        email: words[4],
                        phonenum: int.Parse(words[5]),
                        address: words[6],
                        password: words[7],
                        dob: DateOnly.Parse(words[8]),
                        profilepic: words[9]
                    );

                    userHashTable.Insert(user.UserId, user);
                    validLines++;
                }
                catch (Exception ex)
                {
                    errorLines++;
                    errorLog.AppendLine($"Line {totalLines}: {ex.Message}");
                }
            }

            // Only proceed if we have valid data
            if (validLines > 0)
            {
                _adminManagingFiles.SaveUsersToDatabase(userHashTable);
            }
            else
            {
                MessageBox.Show("No valid user data was found in the file.", "No Valid Data",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            // Show error log if needed
            if (errorLines > 0)
            {
                ShowErrorLog(errorLog.ToString(), totalLines, validLines, errorLines);
            }
        }

        private void ProcessCustomerFile(string filePath)
        {
            var customerHashTable = new HashTable<string, Customer>(10000);
            int totalLines = 0;
            int validLines = 0;
            int errorLines = 0;
            StringBuilder errorLog = new StringBuilder();

            foreach (var line in File.ReadLines(filePath))
            {
                totalLines++;
                if (string.IsNullOrWhiteSpace(line)) continue;

                var words = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (words.Length < 5)
                {
                    errorLines++;
                    errorLog.AppendLine($"Line {totalLines}: Insufficient data columns ({words.Length}/5)");
                    continue;
                }

                try
                {
                    Customer customer = new Customer(
                        customerID: words[0],
                        userID: words[1],
                        licenseNo: words[2],
                        licenseExpiryDate: DateOnly.Parse(words[3]),
                        licensePhoto: words[4]
                    );

                    customerHashTable.Insert(customer.CustomerID, customer);
                    validLines++;
                }
                catch (Exception ex)
                {
                    errorLines++;
                    errorLog.AppendLine($"Line {totalLines}: {ex.Message}");
                }
            }

            // Only proceed if we have valid data
            if (validLines > 0)
            {
                _adminManagingFiles.SaveCustomerToDatabase(customerHashTable);
            }
            else
            {
                MessageBox.Show("No valid customer data was found in the file.", "No Valid Data",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            // Show error log if needed
            if (errorLines > 0)
            {
                ShowErrorLog(errorLog.ToString(), totalLines, validLines, errorLines);
            }
        }

        private void ShowErrorLog(string errors, int totalLines, int validLines, int errorLines)
        {
            // Only show first 15 errors to avoid huge message box
            if (errors.Split('\n').Length > 15)
            {
                var firstErrors = string.Join("\n", errors.Split('\n').Take(15));
                errors = firstErrors + $"\n\n...and {errorLines - 15} more errors.";
            }

            using (var form = new Form())
            {
                form.Text = "Import Errors";
                form.Size = new Size(600, 400);
                form.StartPosition = FormStartPosition.CenterParent;
                form.Icon = this.Icon;

                var textBox = new TextBox
                {
                    Multiline = true,
                    ReadOnly = true,
                    ScrollBars = ScrollBars.Vertical,
                    Dock = DockStyle.Fill,
                    Text = $"Import Summary:\n" +
                           $"Total lines: {totalLines}\n" +
                           $"Valid entries: {validLines}\n" +
                           $"Error entries: {errorLines}\n\n" +
                           $"Error Details:\n{errors}"
                };

                form.Controls.Add(textBox);
                form.ShowDialog();
            }
        }
    }
}
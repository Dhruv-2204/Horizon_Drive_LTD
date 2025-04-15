using Microsoft.Data.SqlClient;
using Horizon_Drive_LTD.BusinessLogic;
using Horizon_Drive_LTD.DataStructure;
using Horizon_Drive_LTD.BusinessLogic.Repositories;
using Horizon_Drive_LTD.BusinessLogic.Services;
using splashscreen;

namespace Horizon_Drive_LTD
{
    public partial class ListCarForm : Form
    {

        private HashTable<string, CarListing> carHashTable;



        // Database connection
        DatabaseConnection _dbConnection = new DatabaseConnection();

        // List to keep track of uploaded photos
        private List<string> uploadedPhotoPaths = new List<string>();
        private List<PictureBox> photoPictureBoxes = new List<PictureBox>();

        public ListCarForm()
        {
            InitializeComponent();

            //
            carHashTable = new HashTable<string, CarListing>(1000);

            // Initialize photo placeholders
            InitializePhotoPlaceholders();

            // Set the plus icon for upload
            pictureBoxUpload.Image = CreatePlusIcon(30, 30);

            // Set date pickers to current date + 1 day and + 30 days
            dateTimePickerStart.Value = DateTime.Today.AddDays(1);
            dateTimePickerEnd.Value = DateTime.Today.AddDays(30);

            // Set up drag and drop functionality
            SetupDragAndDrop();
        }

        private void ListCarForm_Load(object sender, EventArgs e)
        {
            // Display the username
            DisplayUsername();

            // Populate dropdown lists
            PopulateMakes();
            PopulateYears();
            PopulateTypes();
            PopulateColors();
            PopulateFuelTypes();
            PopulateTransmissions();
            PopulateDrivetrains();
            PopulateSeatNumbers();
        }

        // Method to fetch and display username
        private void DisplayUsername()
        {
            string username = GetLoggedInUsername();
            if (string.IsNullOrEmpty(username))
            {
                UsernameLabel.Text = "User not logged in";
                // Style the label differently (RED) for non-logged in users
                UsernameLabel.ForeColor = Color.Red;
            }
            else
            {
                UsernameLabel.Text = username;
                UsernameLabel.ForeColor = Color.FromArgb(15, 30, 45); // Color of logged in users
            }
        }

        // Method to get the username from the database
        private string GetLoggedInUsername()
        {
            try
            {
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
                            return reader.GetString(0).Trim();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error retrieving username: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return null;
        }

        private void SetupDragAndDrop()
        {
            // Enable drag and drop on the upload panel
            panelUploadPhotos.AllowDrop = true;

            // Add drag and drop event handlers
            panelUploadPhotos.DragEnter += PanelUploadPhotos_DragEnter;
            panelUploadPhotos.DragDrop += PanelUploadPhotos_DragDrop;

            // Also enable drag and drop on the photo container
            panelPhotoContainer.AllowDrop = true;
            panelPhotoContainer.DragEnter += PanelUploadPhotos_DragEnter;
            panelPhotoContainer.DragDrop += PanelUploadPhotos_DragDrop;
        }

        private void PanelUploadPhotos_DragEnter(object sender, DragEventArgs e)
        {
            // Check if the dragged data contains file paths
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

                // Only allow drag if all files are valid image files
                bool allImagesValid = true;

                foreach (string file in files)
                {
                    string extension = Path.GetExtension(file).ToLower();
                    if (extension != ".jpg" && extension != ".jpeg" && extension != ".png" && extension != ".gif" && extension != ".bmp")
                    {
                        allImagesValid = false;
                        break;
                    }
                }

                // Set the drag effect to copy if all images are valid
                e.Effect = allImagesValid ? DragDropEffects.Copy : DragDropEffects.None;
            }
            else
            {
                // If not file paths, don't allow drop
                e.Effect = DragDropEffects.None;
            }
        }

        private void PanelUploadPhotos_DragDrop(object sender, DragEventArgs e)
        {
            // Get the file paths that were dragged onto the control
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            // Handle each dropped file
            foreach (string filePath in files)
            {
                // Check if the file is an image
                string extension = Path.GetExtension(filePath).ToLower();
                if (extension == ".jpg" || extension == ".jpeg" || extension == ".png" || extension == ".gif" || extension == ".bmp")
                {
                    // Check if we've reached the maximum of 5 photos
                    if (uploadedPhotoPaths.Count >= 5)
                    {
                        MessageBox.Show("You can only upload a maximum of 5 photos.",
                                      "Maximum Photos Reached",
                                      MessageBoxButtons.OK,
                                      MessageBoxIcon.Information);
                        break;
                    }

                    // Check file size (10MB limit)
                    FileInfo fileInfo = new FileInfo(filePath);
                    if (fileInfo.Length > 10 * 1024 * 1024) // 10MB in bytes
                    {
                        MessageBox.Show($"The file {Path.GetFileName(filePath)} exceeds the 10MB size limit.",
                                      "File Too Large",
                                      MessageBoxButtons.OK,
                                      MessageBoxIcon.Warning);
                        continue;
                    }

                    // Add the photo path to our list
                    uploadedPhotoPaths.Add(filePath);
                }
                else
                {
                    MessageBox.Show($"The file {Path.GetFileName(filePath)} is not a supported image format.\nPlease use JPG, JPEG, PNG, GIF, or BMP files.",
                                  "Invalid File Format",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Warning);
                }
            }

            // Update the UI to display the uploaded photos
            UpdatePhotoUI();
        }

        #region Data Population Methods

        private void PopulateMakes()
        {
            string[] makes = { "Toyota", "Honda", "Ford", "BMW", "Mercedes", "Audi", "Hyundai", "Kia", "Mazda", "Nissan", "Chevrolet", "Volkswagen" };
            cboMake.Items.Clear();
            cboMake.Items.AddRange(makes);

            // Add event handler for make selection
            cboMake.SelectedIndexChanged += cboMake_SelectedIndexChanged;
        }

        private void PopulateYears()
        {
            cboYear.Items.Clear();
            int currentYear = DateTime.Now.Year;

            for (int year = currentYear; year >= currentYear - 20; year--)
            {
                cboYear.Items.Add(year.ToString());
            }
        }

        private void PopulateTypes()
        {
            string[] types = { "Sedan", "SUV", "Hatchback", "Coupe", "Convertible", "Pickup", "Van", "Minivan", "Wagon" };
            cboType.Items.Clear();
            cboType.Items.AddRange(types);
        }

        private void PopulateColors()
        {
            string[] colors = { "Black", "White", "Silver", "Gray", "Red", "Blue", "Green", "Yellow", "Orange", "Brown", "Purple", "Gold", "Other" };
            cboColor.Items.Clear();
            cboColor.Items.AddRange(colors);
        }

        private void PopulateFuelTypes()
        {
            string[] fuelTypes = { "Gasoline", "Diesel", "Hybrid", "Electric", "Natural Gas", "Flex-Fuel", "Hydrogen" };
            cboFuelType.Items.Clear();
            cboFuelType.Items.AddRange(fuelTypes);
        }

        private void PopulateTransmissions()
        {
            string[] transmissions = { "Automatic", "Manual", "Semi-Automatic", "CVT", "Dual-Clutch" };
            cboTransmission.Items.Clear();
            cboTransmission.Items.AddRange(transmissions);
        }

        private void PopulateDrivetrains()
        {
            string[] drivetrains = { "FWD", "RWD", "AWD", "4WD" };
            cboDrivetrain.Items.Clear();
            cboDrivetrain.Items.AddRange(drivetrains);
        }

        private void PopulateSeatNumbers()
        {
            string[] seatNumbers = { "2", "4", "5", "6", "7", "8", "9+" };
            cboSeatNumber.Items.Clear();
            cboSeatNumber.Items.AddRange(seatNumbers);
        }

        private void PopulateModels(string make)
        {
            cboModel.Items.Clear();

            // Add models based on selected make
            switch (make)
            {
                case "Toyota":
                    cboModel.Items.AddRange(new string[] { "Corolla", "Camry", "RAV4", "Highlander", "Prius", "Tacoma", "Tundra", "Avalon" });
                    break;
                case "Honda":
                    cboModel.Items.AddRange(new string[] { "Civic", "Accord", "CR-V", "Pilot", "Fit", "HR-V", "Odyssey", "Ridgeline" });
                    break;
                case "Ford":
                    cboModel.Items.AddRange(new string[] { "Mustang", "F-150", "Explorer", "Escape", "Edge", "Ranger", "Focus", "Fusion" });
                    break;
                case "BMW":
                    cboModel.Items.AddRange(new string[] { "3 Series", "5 Series", "7 Series", "X3", "X5", "X7", "M3", "M5" });
                    break;
                case "Mercedes":
                    cboModel.Items.AddRange(new string[] { "C-Class", "E-Class", "S-Class", "GLC", "GLE", "GLS", "AMG GT", "EQS" });
                    break;
                case "Audi":
                    cboModel.Items.AddRange(new string[] { "A3", "A4", "A6", "Q3", "Q5", "Q7", "R8", "TT" });
                    break;
                case "Hyundai":
                    cboModel.Items.AddRange(new string[] { "Elantra", "Sonata", "Tucson", "Santa Fe", "Kona", "Palisade", "Veloster", "Ioniq" });
                    break;
                case "Kia":
                    cboModel.Items.AddRange(new string[] { "Forte", "Optima", "Sportage", "Sorento", "Soul", "Telluride", "Stinger", "Seltos" });
                    break;
                case "Mazda":
                    cboModel.Items.AddRange(new string[] { "Mazda3", "Mazda6", "CX-3", "CX-5", "CX-9", "MX-5 Miata", "CX-30" });
                    break;
                case "Nissan":
                    cboModel.Items.AddRange(new string[] { "Altima", "Maxima", "Sentra", "Rogue", "Pathfinder", "Murano", "Frontier", "Titan" });
                    break;
                case "Chevrolet":
                    cboModel.Items.AddRange(new string[] { "Malibu", "Impala", "Equinox", "Traverse", "Silverado", "Camaro", "Corvette", "Suburban" });
                    break;
                case "Volkswagen":
                    cboModel.Items.AddRange(new string[] { "Jetta", "Passat", "Golf", "Tiguan", "Atlas", "Arteon", "ID.4", "Taos" });
                    break;
                default:
                    break;
            }
        }

        #endregion

        #region Event Handlers

        private void cboMake_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMake.SelectedItem != null)
            {
                PopulateModels(cboMake.SelectedItem.ToString());
            }
        }

        private void btnBrowseListings_Click(object sender, EventArgs e)
        {
            // Navigate to browse listings form
            BrowseListings browseListings = new BrowseListings();
            browseListings.Show();
            this.Dispose();
        }

        private void btnManageBooking_Click(object sender, EventArgs e)
        {
            // Open the Manage Bookings form
            ManageBookings manageBookingsForm = new ManageBookings();
            manageBookingsForm.Show();
            this.Dispose();
        }

        private void btnManageYourListings_Click(object sender, EventArgs e)
        {
            // Open form to manage user's listings


            ManageYourListings manageYourListingsForm = new ManageYourListings();
            manageYourListingsForm.Show();
            this.Dispose();

        }

        private void btnOptions_Click(object sender, EventArgs e)
        {
            // Open options/settings
            Options_Personal optionsForm = new Options_Personal();
            optionsForm.Show();
            this.Dispose();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            // Log out functionality
            DialogResult result = MessageBox.Show("Are you sure you want to log out?",
                           "Log Out",
                           MessageBoxButtons.YesNo,
                           MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                MessageBox.Show("You have been logged out successfully.",
                               "Log Out",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Information);

                // In a real application, you would handle logout here
                // Application.Restart();
                // For this example, we'll just close the form
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

            }
            else
            {                 // User chose not to log out
                return;
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

        private void panelUploadPhotos_Click(object sender, EventArgs e)
        {
            // Show file open dialog to select photos
            BrowseForPhotos();
        }

        private void lblPlus1_Click(object sender, EventArgs e)
        {
            RemovePhoto(0);
        }

        private void lblPlus2_Click(object sender, EventArgs e)
        {
            RemovePhoto(1);
        }

        private void lblPlus3_Click(object sender, EventArgs e)
        {
            RemovePhoto(2);
        }

        private void lblPlus4_Click(object sender, EventArgs e)
        {
            RemovePhoto(3);
        }

        private void lblPlus5_Click(object sender, EventArgs e)
        {
            RemovePhoto(4);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Confirm cancellation
            DialogResult result = MessageBox.Show("Are you sure you want to cancel? All entered data will be lost.",
                           "Cancel Listing",
                           MessageBoxButtons.YesNo,
                           MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Return to browse listings
                BrowseListings browseListings = new BrowseListings();
                browseListings.Show();
                this.Close();
            }
        }




        private void btnListMyCar_Click(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;

            // Generate IDs
            string carId = "C" + (Math.Abs(Guid.NewGuid().GetHashCode()) % 100000).ToString("D5");
            string carBrand = cboMake.SelectedItem.ToString();

            try
            {
                // 1. Save images to project directory
                List<string> imagePaths = SaveCarImages(uploadedPhotoPaths, carBrand, carId);

                // 2. Save to database
                using (SqlConnection conn = _dbConnection.GetConnection())
                {
                    conn.Open();

                    // Insert car data
                    string carQuery = @" INSERT INTO Car (
                                            CarId, UserId, CarBrand, Model, Years, Category, Colour, 
                                            RegistrationNo, FuelType, TransmissionType, Drivetrain, 
                                            EngineCapacity, Power, SeatNo, VehicleDescription, 
                                            Features, CarPrice, AvailabilityStart, AvailabilityEnd
                                        ) VALUES (
                                            @CarId, @UserId, @CarBrand, @Model, @Year, @Category, @Colour,
                                            @RegNo, @FuelType, @Transmission, @Drivetrain,
                                            @EngineCap, @Power, @Seats, @Description,
                                            @Features, @Price, @StartDate, @EndDate
                                        )";

                    using (SqlCommand cmd = new SqlCommand(carQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@CarId", carId);
                        cmd.Parameters.AddWithValue("@UserId", GetUserIdByUsername(UsernameLabel.Text));
                        cmd.Parameters.AddWithValue("@CarBrand", carBrand);
                        cmd.Parameters.AddWithValue("@Model", cboModel.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@Year", int.Parse(cboYear.SelectedItem.ToString()));
                        cmd.Parameters.AddWithValue("@Category", cboType.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@Colour", cboColor.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@RegNo", txtLicensePlate.Text);
                        cmd.Parameters.AddWithValue("@FuelType", cboFuelType.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@Transmission", cboTransmission.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@Drivetrain", cboDrivetrain.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@EngineCap", txtEngineCapacity.Text);
                        cmd.Parameters.AddWithValue("@Power", txtPower.Text);
                        cmd.Parameters.AddWithValue("@Seats", cboSeatNumber.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@Description", txtDescription.Text);
                        cmd.Parameters.AddWithValue("@Features", txtCarFeatures.Text);
                        cmd.Parameters.AddWithValue("@Price", decimal.Parse(txtDailyRate.Text));
                        cmd.Parameters.AddWithValue("@StartDate", dateTimePickerStart.Value);
                        cmd.Parameters.AddWithValue("@EndDate", dateTimePickerEnd.Value);
                        // Add any other parameters as needed


                        cmd.ExecuteNonQuery();
                    }

                    // Insert image references
                    foreach (string path in imagePaths)
                    {

                        // using GUID
                        string imageId = "IMG" + (Math.Abs(Guid.NewGuid().GetHashCode()) % 100000).ToString("D5");

                        string imageQuery = "INSERT INTO CarImages (ImageId, CarId, ImagePath) VALUES (@ImageId, @CarId, @Path)";

                        using (SqlCommand imgCmd = new SqlCommand(imageQuery, conn))
                        {
                            imgCmd.Parameters.AddWithValue("@ImageId", imageId);
                            imgCmd.Parameters.AddWithValue("@CarId", carId);
                            imgCmd.Parameters.AddWithValue("@Path", path);
                            imgCmd.ExecuteNonQuery();
                        }
                    }
                }

                MessageBox.Show("Car listed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                ListCarForm listCarForm = new ListCarForm();
                listCarForm.Show();
                this.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Save car listing to database
        private object GetUserIdByUsername(string text)
        {
            using (SqlConnection conn = _dbConnection.GetConnection())
            {
                conn.Open();
                string query = "SELECT UserId FROM [User] WHERE UserName = @UserName";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserName", text);
                    // Execute the command and return the result
                    // result = the first column of the first row
                    return cmd.ExecuteScalar();
                }
            }
        }

        // Get the project's Media/Images directory
        private string GetProjectImageDirectory()
        {
            string projectRoot = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\.."));
            return Path.Combine(projectRoot, "Media", "Images");
        }

        // Create a subdirectory for the car's images
        private string CreateCarImageDirectory(string carBrand, string carId)
        {
            string targetDir = Path.Combine(GetProjectImageDirectory(), carBrand, carId);
            Directory.CreateDirectory(targetDir);
            return targetDir;
        }

        // Save images to project directory and return relative paths
        private List<string> SaveCarImages(List<string> sourcePaths, string carBrand, string carId)
        {
            List<string> savedPaths = new List<string>();
            string targetDir = CreateCarImageDirectory(carBrand, carId);

            foreach (string sourcePath in sourcePaths)
            {
                string extension = Path.GetExtension(sourcePath);
                string fileName = $"{Guid.NewGuid()}{extension}"; // Unique filename
                string destPath = Path.Combine(targetDir, fileName);

                File.Copy(sourcePath, destPath);
                savedPaths.Add($"Media/Images/{carBrand}/{carId}/{fileName}");
            }

            return savedPaths;
        }

        private void PanelUploadPhotos_Paint(object sender, PaintEventArgs e)
        {
            Panel panel = (Panel)sender;

            // Create dashed pen
            using (System.Drawing.Pen dashedPen = new System.Drawing.Pen(Color.Gray, 1))
            {
                dashedPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;

                // Draw dashed rectangle
                e.Graphics.DrawRectangle(dashedPen, 0, 0, panel.Width - 1, panel.Height - 1);
            }
        }

        #endregion

        #region Helper Methods

        private void InitializePhotoPlaceholders()
        {
            // Add panels to list for easy management
            var photoPanels = new List<Panel>
    {
        panelPhoto1,
        panelPhoto2,
        panelPhoto3,
        panelPhoto4,
        panelPhoto5
    };

            // Calculate total width needed for all panels with spacing
            int panelWidth = panelPhoto1.Width;
            int spacing = 10;
            int totalPanelsWidth = (panelWidth * photoPanels.Count) + (spacing * (photoPanels.Count - 1));

            // Calculate starting X position to center the panels
            int startX = (panelPhotoContainer.Width - totalPanelsWidth) / 2;

            // Add the photo panels to the container
            for (int i = 0; i < photoPanels.Count; i++)
            {
                var panel = photoPanels[i];

                // Add panels to the container
                panelPhotoContainer.Controls.Add(panel);

                // Position panels centered in the container with proper spacing
                panel.Location = new Point(
                    startX + (i * (panelWidth + spacing)),
                    (panelPhotoContainer.Height - panel.Height) / 2); // Center vertically as well

                // Reposition the existing remove label (×) to the top-right corner
                if (panel.Controls.Count > 0 && panel.Controls[0] is Label removeLabel)
                {
                    removeLabel.AutoSize = true;
                    removeLabel.Text = "×";
                    removeLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
                    removeLabel.ForeColor = Color.Red;
                    removeLabel.Cursor = Cursors.Hand;
                    removeLabel.Location = new Point(panel.Width - 20, 0); // Top-right position
                    removeLabel.BackColor = Color.Transparent;
                    removeLabel.BringToFront(); // Ensure it's on top
                }
            }

            // Initialize picture boxes for uploaded photos
            foreach (var panel in photoPanels)
            {
                var pictureBox = new PictureBox
                {
                    Size = new Size(70, 70),
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Dock = DockStyle.Fill,
                    Visible = false,
                    Cursor = Cursors.Hand // Change cursor to indicate it's clickable
                };

                // Add click event to open the image
                pictureBox.Click += PictureBox_Click;

                panel.Controls.Add(pictureBox);
                // Move the pictureBox to the back so the remove label stays on top
                pictureBox.SendToBack();
                photoPictureBoxes.Add(pictureBox);
            }
        }

        // Event handler for PictureBox click
        private void PictureBox_Click(object sender, EventArgs e)
        {
            PictureBox clickedPictureBox = (PictureBox)sender;
            int index = photoPictureBoxes.IndexOf(clickedPictureBox);

            if (index >= 0 && index < uploadedPhotoPaths.Count)
            {
                // Get the path of the clicked photo
                string imagePath = uploadedPhotoPaths[index];

                // Create and show a form to display the image in full size
                ShowFullSizeImage(imagePath);
            }
        }

        // Method to show full-size image in a new form
        private void ShowFullSizeImage(string imagePath)
        {
            try
            {
                // Create a new form to display the image
                Form imageForm = new Form
                {
                    Text = "Uploaded Image",
                    StartPosition = FormStartPosition.CenterScreen,
                    MinimizeBox = false,
                    MaximizeBox = true,
                    FormBorderStyle = FormBorderStyle.Sizable,
                    Size = new Size(800, 600)
                };

                // Create a PictureBox to hold the image
                PictureBox pb = new PictureBox
                {
                    Image = Image.FromFile(imagePath),
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Dock = DockStyle.Fill,
                    Cursor = Cursors.Hand
                };

                // Add click handler to close the form when the image is clicked
                pb.Click += (s, e) => { imageForm.Close(); };

                // Add a label with instructions
                Label instructionLabel = new Label
                {
                    Text = "Click anywhere to close",
                    AutoSize = true,
                    BackColor = Color.FromArgb(200, 255, 255, 255),
                    Padding = new Padding(5),
                    Font = new Font("Segoe UI", 9F),
                    Dock = DockStyle.Bottom
                };

                // Add controls to the form
                imageForm.Controls.Add(pb);
                imageForm.Controls.Add(instructionLabel);

                // Show the form
                imageForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error displaying image: {ex.Message}",
                               "Error",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
            }
        }

        private Image CreatePlusIcon(int width, int height)
        {
            Bitmap bitmap = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.Clear(Color.Transparent);
                using (System.Drawing.Pen pen = new System.Drawing.Pen(Color.Gray, 2))
                {
                    // Draw a plus sign
                    g.DrawLine(pen, width / 2, 5, width / 2, height - 5);
                    g.DrawLine(pen, 5, height / 2, width - 5, height / 2);
                }
            }
            return bitmap;
        }

        private void BrowseForPhotos()
        {
            if (openFileDialogPhotos.ShowDialog() == DialogResult.OK)
            {
                foreach (string fileName in openFileDialogPhotos.FileNames)
                {
                    // Check if we've reached the maximum of 5 photos
                    if (uploadedPhotoPaths.Count >= 5)
                    {
                        MessageBox.Show("You can only upload a maximum of 5 photos.",
                                       "Maximum Photos Reached",
                                       MessageBoxButtons.OK,
                                       MessageBoxIcon.Information);
                        break;
                    }

                    // Check file size (10MB limit)
                    FileInfo fileInfo = new FileInfo(fileName);
                    if (fileInfo.Length > 10 * 1024 * 1024) // 10MB in bytes
                    {
                        MessageBox.Show($"The file {Path.GetFileName(fileName)} exceeds the 10MB size limit.",
                                      "File Too Large",
                                      MessageBoxButtons.OK,
                                      MessageBoxIcon.Warning);
                        continue;
                    }


                    // Add the photo path to our list
                    uploadedPhotoPaths.Add(fileName);

                    // Update UI to show the photo
                    UpdatePhotoUI();
                }
            }
        }

        private void UpdatePhotoUI()
        {
            // Clear existing photos from UI
            for (int i = 0; i < photoPictureBoxes.Count; i++)
            {
                var pictureBox = photoPictureBoxes[i];
                var panel = (Panel)pictureBox.Parent;
                var plusLabel = panel.Controls[0];

                pictureBox.Visible = false;
                panel.Visible = false;
                plusLabel.Text = "×";
            }

            // Add photos to UI
            for (int i = 0; i < uploadedPhotoPaths.Count; i++)
            {
                try
                {
                    var pictureBox = photoPictureBoxes[i];
                    var panel = (Panel)pictureBox.Parent;
                    var plusLabel = panel.Controls[0];

                    pictureBox.Image = Image.FromFile(uploadedPhotoPaths[i]);
                    pictureBox.Visible = true;
                    panel.Visible = true;
                    plusLabel.Text = "×";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading image: {ex.Message}",
                                   "Error",
                                   MessageBoxButtons.OK,
                                   MessageBoxIcon.Error);
                }
            }

            // Add a simple instruction label when photos are present
            if (uploadedPhotoPaths.Count > 0)
            {
                // Check if the label already exists
                Label instructionLabel = panelPhotoContainer.Controls.OfType<Label>().FirstOrDefault();

                if (instructionLabel == null)
                {
                    // Create new label if it doesn't exist
                    instructionLabel = new Label();
                    instructionLabel.Text = "Click image to view full size";
                    instructionLabel.AutoSize = true;
                    instructionLabel.ForeColor = Color.Black;
                    instructionLabel.Location = new Point(5, 5);
                    panelPhotoContainer.Controls.Add(instructionLabel);
                }

                instructionLabel.Visible = true;
            }
        }

        private void RemovePhoto(int index)
        {
            if (index < uploadedPhotoPaths.Count)
            {
                // Remove the photo from our list
                uploadedPhotoPaths.RemoveAt(index);

                // Update UI
                UpdatePhotoUI();
            }
        }

        private bool ValidateForm()
        {
            // Check required fields
            if (cboMake.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a make for your car.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboMake.Focus();
                return false;
            }

            if (cboModel.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a model for your car.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboModel.Focus();
                return false;
            }

            if (cboYear.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a year for your car.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboYear.Focus();
                return false;
            }

            if (cboType.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a type for your car.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboType.Focus();
                return false;
            }

            if (cboColor.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a color for your car.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboColor.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtLicensePlate.Text))
            {
                MessageBox.Show("Please enter the license plate number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLicensePlate.Focus();
                return false;
            }

            // Validate new required fields
            if (cboFuelType.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a fuel type for your car.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboFuelType.Focus();
                return false;
            }

            if (cboTransmission.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a transmission type for your car.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboTransmission.Focus();
                return false;
            }

            if (cboDrivetrain.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a drivetrain for your car.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboDrivetrain.Focus();
                return false;
            }

            if (cboSeatNumber.SelectedIndex == -1)
            {
                MessageBox.Show("Please select the number of seats in your car.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboSeatNumber.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtEngineCapacity.Text))
            {
                MessageBox.Show("Please enter the engine capacity.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEngineCapacity.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPower.Text))
            {
                MessageBox.Show("Please enter the power output.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPower.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                MessageBox.Show("Please enter a description for your car.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDescription.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtCarFeatures.Text))
            {
                MessageBox.Show("Please enter features for your car.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCarFeatures.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDailyRate.Text))
            {
                MessageBox.Show("Please enter a daily rate for your car.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDailyRate.Focus();
                return false;
            }

            // Validate daily rate is a valid number
            decimal rate;
            if (!decimal.TryParse(txtDailyRate.Text, out rate) || rate <= 0)
            {
                MessageBox.Show("Please enter a valid daily rate (greater than 0).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDailyRate.Focus();
                return false;
            }

            // Validate at least one photo
            if (uploadedPhotoPaths.Count == 0)
            {
                MessageBox.Show("Please upload at least one photo of your car.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Validate dates
            if (dateTimePickerStart.Value < DateTime.Today)
            {
                MessageBox.Show("Availability start date cannot be in the past.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dateTimePickerStart.Focus();
                return false;
            }

            if (dateTimePickerEnd.Value <= dateTimePickerStart.Value)
            {
                MessageBox.Show("Availability end date must be after the start date.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dateTimePickerEnd.Focus();
                return false;
            }

            return true;
        }




        #endregion

        private void btnListCar_Click(object sender, EventArgs e)
        {
            ListCarForm_Load(sender, e);
            // Call the method to list the car
            btnListMyCar_Click(sender, e);

        }

        private void buttonProfile_Click(object sender, EventArgs e)
        {
            Options_Personal optionsForm = new Options_Personal();
            optionsForm.Show();
            this.Dispose();
        }
    }

    // CarListing class embedded in this file as requested

    public class CarListing
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Type { get; set; }
        public string Color { get; set; }
        public string LicensePlate { get; set; }
        public string FuelType { get; set; }
        public string Transmission { get; set; }
        public string Drivetrain { get; set; }
        public string EngineCapacity { get; set; }
        public string Power { get; set; }
        public string SeatNumber { get; set; }
        public string Description { get; set; }
        public string Features { get; set; }
        public decimal PricePerDay { get; set; }
        public DateTime AvailabilityStart { get; set; }
        public DateTime AvailabilityEnd { get; set; }
        public string ImagePath { get; set; }
        public List<string> AdditionalImages { get; set; } = new List<string>();
        public int PhotoCount { get; set; }
    }
}
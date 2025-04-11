using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;

namespace Horizon_Drive_LTD
{
    public partial class ListCarForm : Form
    {
        // List to keep track of uploaded photos
        private List<string> uploadedPhotoPaths = new List<string>();
        private List<PictureBox> photoPictureBoxes = new List<PictureBox>();

        public ListCarForm()
        {
            InitializeComponent();

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
            // Populate dropdown lists
            PopulateMakes();
            PopulateYears();
            PopulateTypes();
            PopulateColors();
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
            this.Hide();
        }

        private void btnManageBooking_Click(object sender, EventArgs e)
        {
            // Open the Manage Bookings form
            ManageBookings manageBookingsForm = new ManageBookings();
            manageBookingsForm.Show();
            this.Hide();
        }

        private void btnManageYourListings_Click(object sender, EventArgs e)
        {
            // Open form to manage user's listings
            MessageBox.Show("Manage Your Listings functionality would open a form to view and manage your car listings.",
                           "Manage Your Listings",
                           MessageBoxButtons.OK,
                           MessageBoxIcon.Information);
        }

        private void btnOptions_Click(object sender, EventArgs e)
        {
            // Open options/settings
            MessageBox.Show("Options functionality would open settings for the application.",
                           "Options",
                           MessageBoxButtons.OK,
                           MessageBoxIcon.Information);
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
            }
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
            if (ValidateForm())
            {
                // In a real application, save data to database
                SaveCarListing();

                // Show success message
                MessageBox.Show("Your car has been listed successfully!",
                               "Success",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Information);

                // Return to browse listings
                BrowseListings browseListings = new BrowseListings();
                browseListings.Show();
                this.Close();
            }
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

            // Initialize picture boxes for uploaded photos
            foreach (var panel in photoPanels)
            {
                var pictureBox = new PictureBox
                {
                    Size = new Size(70, 70),
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Dock = DockStyle.Fill,
                    Visible = false
                };

                panel.Controls.Add(pictureBox);
                photoPictureBoxes.Add(pictureBox);
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
                plusLabel.Text = "+";
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
                    plusLabel.Text = "×"; // Use × as remove icon
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading image: {ex.Message}",
                                   "Error",
                                   MessageBoxButtons.OK,
                                   MessageBoxIcon.Error);
                }
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

            if (string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                MessageBox.Show("Please enter a description for your car.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDescription.Focus();
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

        private void SaveCarListing()
        {
            // In a real application, this would save to a database
            // For now, we'll just create a CarListing object that could be saved

            CarListing carListing = new CarListing
            {
                Make = cboMake.SelectedItem.ToString(),
                Model = cboModel.SelectedItem.ToString(),
                Year = int.Parse(cboYear.SelectedItem.ToString()),
                Description = txtDescription.Text,
                PricePerDay = decimal.Parse(txtDailyRate.Text)
            };

            // Properties that would be added to an extended CarListing class
            string carType = cboType.SelectedItem.ToString();
            string color = cboColor.SelectedItem.ToString();
            string licensePlate = txtLicensePlate.Text;
            DateTime availabilityStart = dateTimePickerStart.Value;
            DateTime availabilityEnd = dateTimePickerEnd.Value;

            // Additional features
            bool hasGPS = checkBoxGPS.Checked;
            bool hasBluetooth = checkBoxBluetooth.Checked;
            bool hasLeatherSeat = checkBoxLeatherSeat.Checked;
            bool hasSunroof = checkBoxSunroof.Checked;
            bool hasChildSeat = checkBoxChildSeat.Checked;

            // Photos would be processed here:
            // 1. Copy to application's image directory
            // 2. Save paths in database

            // For demo purposes, just log to console
            Console.WriteLine($"Car Listed: {carListing.Year} {carListing.Make} {carListing.Model}");
            Console.WriteLine($"Type: {carType}, Color: {color}, License: {licensePlate}");
            Console.WriteLine($"Daily Rate: {carListing.PricePerDay:C}");
            Console.WriteLine($"Available: {availabilityStart.ToShortDateString()} to {availabilityEnd.ToShortDateString()}");
            Console.WriteLine($"Features: GPS={hasGPS}, Bluetooth={hasBluetooth}, Leather={hasLeatherSeat}, Sunroof={hasSunroof}, ChildSeat={hasChildSeat}");
            Console.WriteLine($"Photos: {uploadedPhotoPaths.Count} images uploaded");
        }

        #endregion
    }

    // CarListing class embedded in this file as requested
    public class CarListing
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Description { get; set; }
        public decimal PricePerDay { get; set; }
        public string ImagePath { get; set; }
        public List<string> AdditionalImages { get; set; } = new List<string>();
    }
}
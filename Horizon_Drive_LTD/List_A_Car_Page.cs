using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Horizon_Drive_LTD
{
    public partial class List_A_Car_Page : Form
    {
        private List<string> uploadedImagePaths = new List<string>();
        private PictureBox[] imagePreviews;

        public List_A_Car_Page()
        {
            InitializeComponent();
            SetupImageUploadArea();
        }

        private void SetupImageUploadArea()
        {
            // Create array of PictureBoxes for image previews
            imagePreviews = new PictureBox[]
            {
                pictureBox1, pictureBox2, pictureBox3, pictureBox4, pictureBox5
            };

            // Setup drag and drop for the upload area
            panelImageUpload.AllowDrop = true;
            panelImageUpload.DragEnter += PanelImageUpload_DragEnter;
            panelImageUpload.DragDrop += PanelImageUpload_DragDrop;
            panelImageUpload.Click += PanelImageUpload_Click;

            // Reset image previews
            foreach (var preview in imagePreviews)
            {
                preview.Image = null;
                preview.Tag = null;
                preview.Click += ImagePreview_Click;
            }
        }

        private void PanelImageUpload_DragEnter(object sender, DragEventArgs e)
        {
            // Check if the dragged data contains file drops
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void PanelImageUpload_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            ProcessImageFiles(files);
        }

        private void PanelImageUpload_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                openFileDialog.Multiselect = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    ProcessImageFiles(openFileDialog.FileNames);
                }
            }
        }

        private void ProcessImageFiles(string[] files)
        {
            // Limit to 5 images
            int availableSlots = imagePreviews.Length - uploadedImagePaths.Count;
            int filesToProcess = Math.Min(files.Length, availableSlots);

            for (int i = 0; i < filesToProcess; i++)
            {
                string file = files[i];
                // Find first empty preview slot
                for (int j = 0; j < imagePreviews.Length; j++)
                {
                    if (imagePreviews[j].Image == null)
                    {
                        try
                        {
                            using (Image img = Image.FromFile(file))
                            {
                                imagePreviews[j].Image = new Bitmap(img, imagePreviews[j].Size);
                                imagePreviews[j].Tag = file;
                                uploadedImagePaths.Add(file);
                            }
                            break;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error loading image: {ex.Message}", "Image Upload Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }

            UpdateUploadButtonVisibility();
        }

        private void ImagePreview_Click(object sender, EventArgs e)
        {
            PictureBox clickedPictureBox = (PictureBox)sender;

            // If image exists, allow removal
            if (clickedPictureBox.Image != null)
            {
                DialogResult result = MessageBox.Show("Remove this image?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Remove the image path from the list
                    if (clickedPictureBox.Tag != null)
                    {
                        uploadedImagePaths.Remove(clickedPictureBox.Tag.ToString());
                    }

                    // Clear the image and tag
                    clickedPictureBox.Image = null;
                    clickedPictureBox.Tag = null;

                    UpdateUploadButtonVisibility();
                }
            }
        }

        private void UpdateUploadButtonVisibility()
        {
            // Hide upload area if 5 images are uploaded
            panelImageUpload.Visible = uploadedImagePaths.Count < 5;
        }

        private void btnListMyCar_Click(object sender, EventArgs e)
        {
            // Validate form inputs before submission
            if (ValidateForm())
            {
                // Collect and process car listing data
                CarListing newListing = new CarListing
                {
                    Make = cmbMake.SelectedItem?.ToString(),
                    Model = cmbModel.SelectedItem?.ToString(),
                    Year = cmbYear.SelectedItem?.ToString(),
                    Type = cmbType.SelectedItem?.ToString(),
                    Color = cmbColor.SelectedItem?.ToString(),
                    LicensePlate = txtLicensePlate.Text,
                    Description = txtCarDescription.Text,
                    DailyRate = decimal.Parse(txtDailyRate.Text),
                    ImagePaths = uploadedImagePaths
                };

                // Save or process the listing
                SaveCarListing(newListing);
            }
        }

        private bool ValidateForm()
        {
            // Add comprehensive form validation
            List<string> errors = new List<string>();

            if (cmbMake.SelectedItem == null) errors.Add("Please select a car make.");
            if (cmbModel.SelectedItem == null) errors.Add("Please select a model.");
            if (cmbYear.SelectedItem == null) errors.Add("Please select a year.");
            if (cmbType.SelectedItem == null) errors.Add("Please select a car type.");
            if (cmbColor.SelectedItem == null) errors.Add("Please select a color.");
            if (string.IsNullOrWhiteSpace(txtLicensePlate.Text)) errors.Add("Please enter a license plate.");
            if (string.IsNullOrWhiteSpace(txtCarDescription.Text)) errors.Add("Please provide a car description.");
            if (!decimal.TryParse(txtDailyRate.Text, out _)) errors.Add("Please enter a valid daily rate.");
            if (uploadedImagePaths.Count == 0) errors.Add("Please upload at least one car image.");

            if (errors.Count > 0)
            {
                MessageBox.Show(string.Join("\n", errors), "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void SaveCarListing(CarListing listing)
        {
            // Implement actual save logic - could be database, file, API call, etc.
            MessageBox.Show("Car listing saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Optional: Clear form after successful submission
            ResetForm();
        }

        private void ResetForm()
        {
            // Reset all form controls
            cmbMake.SelectedIndex = -1;
            cmbModel.SelectedIndex = -1;
            cmbYear.SelectedIndex = -1;
            cmbType.SelectedIndex = -1;
            cmbColor.SelectedIndex = -1;
            txtLicensePlate.Clear();
            txtCarDescription.Clear();
            txtDailyRate.Text = "7500.00";

            // Clear image previews
            foreach (var preview in imagePreviews)
            {
                preview.Image = null;
                preview.Tag = null;
            }
            uploadedImagePaths.Clear();
            UpdateUploadButtonVisibility();
        }

        // Populate Models based on selected Make
        private void cmbMake_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbModel.Items.Clear();
            switch (cmbMake.SelectedItem?.ToString())
            {
                case "Toyota":
                    cmbModel.Items.AddRange(new string[] { "Corolla", "Camry", "RAV4", "Highlander" });
                    break;
                case "Honda":
                    cmbModel.Items.AddRange(new string[] { "Civic", "Accord", "CR-V", "Pilot" });
                    break;
                case "BMW":
                    cmbModel.Items.AddRange(new string[] { "3 Series", "5 Series", "X3", "X5" });
                    break;
                case "Mercedes":
                    cmbModel.Items.AddRange(new string[] { "C-Class", "E-Class", "GLC", "GLE" });
                    break;
                case "Ford":
                    cmbModel.Items.AddRange(new string[] { "Mustang", "F-150", "Explorer", "Escape" });
                    break;
            }
        }
    }

    // Extended CarListing class to include image paths
    public class CarListing
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public string Year { get; set; }
        public string Type { get; set; }
        public string Color { get; set; }
        public string LicensePlate { get; set; }
        public string Description { get; set; }
        public decimal DailyRate { get; set; }
        public List<string> ImagePaths { get; set; } = new List<string>();
    }

    // Added RoundedButton Class
    public class RoundedButton : Button
    {
        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
            // Create rounded edges
            var graphicsPath = new System.Drawing.Drawing2D.GraphicsPath();
            graphicsPath.AddEllipse(0, 0, this.Width, this.Height);
            this.Region = new Region(graphicsPath);
        }
    }
}

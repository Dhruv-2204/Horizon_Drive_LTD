using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;
using Horizon_Drive_LTD.BusinessLogic;
using Horizon_Drive_LTD.BusinessLogic.Repositories;
using Horizon_Drive_LTD.Domain.Entities;
using Manage_user_search_page;
using Upload_cars;
using User_managing;
using WindowsFormsApp1;

namespace Horizon_Drive_LTD.Domain.Forms
{
    public partial class Maintenance : Form
    {
        private readonly DatabaseConnection _dbConnection;
        private readonly MaintenanceRepository _maintenanceRepository;
        private List<MaintenanceRecord> _allMaintenanceRecords;

        public Maintenance()
        {
            InitializeComponent();

            // Initialize database connection and repository
            _dbConnection = new DatabaseConnection();
            _maintenanceRepository = new MaintenanceRepository(_dbConnection);

            LoadImage();
            SetRoundedCorner(Manage_Users, 25);
            SetRoundedCorner(Manage_files_btn, 25);
            SetRoundedCorner(Manage_bookings_btn, 25);
            SetRoundedCorner(Logout_btn, 25);
            SetRoundedCorner(Maintenance_btn, 25);
            SetRoundedCorner(addMaintenanceBtn, 20);

            // Set up DataGridView
            ConfigureDataGridView();

            // Load maintenance records
            LoadMaintenanceRecords();
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

            // MaintenanceID column
            DataGridViewTextBoxColumn idColumn = new DataGridViewTextBoxColumn();
            idColumn.DataPropertyName = "MaintenanceID";
            idColumn.HeaderText = "Maintenance ID";
            idColumn.Width = 100;
            dataGridView1.Columns.Add(idColumn);

            // CarID column
            DataGridViewTextBoxColumn carIdColumn = new DataGridViewTextBoxColumn();
            carIdColumn.DataPropertyName = "CarID";
            carIdColumn.HeaderText = "Car ID";
            carIdColumn.Width = 80;
            dataGridView1.Columns.Add(carIdColumn);

            // MaintenanceDate column
            DataGridViewTextBoxColumn dateColumn = new DataGridViewTextBoxColumn();
            dateColumn.DataPropertyName = "MaintenanceDate";
            dateColumn.HeaderText = "Date";
            dateColumn.Width = 100;
            dateColumn.DefaultCellStyle.Format = "dd/MM/yyyy";
            dataGridView1.Columns.Add(dateColumn);

            // MaintenanceStatus column
            DataGridViewTextBoxColumn statusColumn = new DataGridViewTextBoxColumn();
            statusColumn.DataPropertyName = "MaintenanceStatus";
            statusColumn.HeaderText = "Status";
            statusColumn.Width = 100;
            dataGridView1.Columns.Add(statusColumn);

            // MaintenanceDescription column
            DataGridViewTextBoxColumn descriptionColumn = new DataGridViewTextBoxColumn();
            descriptionColumn.DataPropertyName = "MaintenanceDescription";
            descriptionColumn.HeaderText = "Description";
            descriptionColumn.Width = 200;
            dataGridView1.Columns.Add(descriptionColumn);

            // Add Edit button column
            DataGridViewButtonColumn editColumn = new DataGridViewButtonColumn();
            editColumn.HeaderText = "Edit";
            editColumn.Text = "Edit";
            editColumn.UseColumnTextForButtonValue = true;
            editColumn.Width = 60;
            dataGridView1.Columns.Add(editColumn);

            // Add Delete button column
            DataGridViewButtonColumn deleteColumn = new DataGridViewButtonColumn();
            deleteColumn.HeaderText = "Delete";
            deleteColumn.Text = "Delete";
            deleteColumn.UseColumnTextForButtonValue = true;
            deleteColumn.Width = 60;
            dataGridView1.Columns.Add(deleteColumn);

            // Custom styling for the DataGridView
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

        private void LoadMaintenanceRecords()
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                // Get all maintenance records from repository
                _allMaintenanceRecords = _maintenanceRepository.GetAllMaintenanceRecords();

                // Bind records to DataGridView
                BindRecordsToDataGridView(_allMaintenanceRecords);

                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show("Error loading maintenance records: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BindRecordsToDataGridView(List<MaintenanceRecord> records)
        {
            // Create binding source
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = records;
            dataGridView1.DataSource = bindingSource;

            // Refresh DataGridView
            dataGridView1.Refresh();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if click is on a button column and a valid row
            if (e.RowIndex >= 0 && _allMaintenanceRecords != null && _allMaintenanceRecords.Count > e.RowIndex)
            {
                // Check if Edit button clicked (second to last column)
                if (e.ColumnIndex == dataGridView1.Columns.Count - 2)
                {
                    // Get the selected maintenance record
                    MaintenanceRecord selectedRecord = _allMaintenanceRecords[e.RowIndex];

                    // Show edit form/dialog
                    ShowMaintenanceDetailsForm(selectedRecord, false);
                }
                // Check if Delete button clicked (last column)
                else if (e.ColumnIndex == dataGridView1.Columns.Count - 1)
                {
                    // Get the selected maintenance record
                    MaintenanceRecord selectedRecord = _allMaintenanceRecords[e.RowIndex];

                    // Confirm deletion
                    if (MessageBox.Show("Are you sure you want to delete this maintenance record?", "Confirm Delete",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        DeleteMaintenanceRecord(selectedRecord.MaintenanceID);
                    }
                }
            }
        }

        private void DeleteMaintenanceRecord(string maintenanceID)
        {
            try
            {
                bool success = _maintenanceRepository.DeleteMaintenanceRecord(maintenanceID);
                if (success)
                {
                    MessageBox.Show("Maintenance record deleted successfully.", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadMaintenanceRecords(); // Reload the data
                }
                else
                {
                    MessageBox.Show("Failed to delete maintenance record.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting maintenance record: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowMaintenanceDetailsForm(MaintenanceRecord record, bool isNew)
        {
            // Create and show a dialog to edit the maintenance record
            using (MaintenanceDetailsForm detailsForm = new MaintenanceDetailsForm(record, _dbConnection, isNew))
            {
                if (detailsForm.ShowDialog() == DialogResult.OK)
                {
                    // Reload data if changes were made
                    LoadMaintenanceRecords();
                }
            }
        }

        private void AddMaintenanceButton_Click(object sender, EventArgs e)
        {
            // Show the maintenance details form with a new record
            ShowMaintenanceDetailsForm(new MaintenanceRecord
            {
                MaintenanceID = GenerateNewMaintenanceID(),
                MaintenanceDate = DateTime.Now,
                MaintenanceStatus = "Pending"
            }, true);
        }

        private string GenerateNewMaintenanceID()
        {
            // You can implement your own ID generation logic here
            // For example, a prefix followed by a timestamp
            return "M" + DateTime.Now.ToString("yyMMddHHmm");
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

        private void Manage_Users_Click(object sender, EventArgs e)
        {
            var manage_user_Page = new Manage_User_Page();
            manage_user_Page.Show();
            this.Dispose();
        }

        private void Manage_files_btn_Click(object sender, EventArgs e)
        {
            var manage_car_Page = new Managing_files();
            manage_car_Page.Show();
            this.Dispose();
        }

        private void Manage_bookings_btn_Click(object sender, EventArgs e)
        {
            var manage_booking_Page = new Manage_bookings();
            manage_booking_Page.Show();
            this.Dispose();
        }
    }
}
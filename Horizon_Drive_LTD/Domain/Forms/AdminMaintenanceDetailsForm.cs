using System;
using System.Drawing;
using System.Windows.Forms;
using Horizon_Drive_LTD.BusinessLogic;
using Horizon_Drive_LTD.BusinessLogic.Repositories;
using Horizon_Drive_LTD.Domain.Entities;
using Horizon_Drive_LTD.DataStructure;

namespace Horizon_Drive_LTD.Domain.Forms
{
    public partial class AdminMaintenanceDetailsForm : Form
    {
        private readonly MaintenanceRecord _record;
        private readonly DatabaseConnection _dbConnection;
        private readonly MaintenanceRepository _maintenanceRepository;
        private readonly CarRepository _carRepository;
        private readonly bool _isNewRecord;
        private HashTable<string, Cars> _carsHashTable;

        public AdminMaintenanceDetailsForm(MaintenanceRecord record, DatabaseConnection dbConnection, bool isNew)
        {
            InitializeComponent();
            _record = record;
            _dbConnection = dbConnection;
            _maintenanceRepository = new MaintenanceRepository(_dbConnection);
            _carRepository = new CarRepository(_dbConnection);
            _isNewRecord = isNew;

            // Load cars from the database
            _carsHashTable = _carRepository.LoadCarsFromDatabase();

            // Set the form title
            this.Text = _isNewRecord ? "Add New Maintenance" : "Edit Maintenance";

            // Set readonly for ID field if editing existing record
            textBoxMaintenanceID.ReadOnly = !_isNewRecord;

            // Setup the status dropdown
            SetupStatusDropdown();

            // Populate the car dropdown
            PopulateCarDropdown();

            // Load the form with the record details
            LoadFormData();
        }

        private void SetupStatusDropdown()
        {
            // Clear existing items
            comboBoxStatus.Items.Clear();

            // Add status options
            comboBoxStatus.Items.Add("Pending");
            comboBoxStatus.Items.Add("In Progress");
            comboBoxStatus.Items.Add("Completed");
        }

        private void PopulateCarDropdown()
        {
            // Clear existing items
            comboBoxCarID.Items.Clear();

            // Loop through all cars and add them to the dropdown
            foreach (var car in _carsHashTable.Values())
            {
                if (car != null)
                {
                    string displayText = $"{car.CarID} - {car.CarBrand} {car.Model} ({car.RegistrationNo})";
                    comboBoxCarID.Items.Add(displayText);
                }
            }

            // Select the first item if available
            if (comboBoxCarID.Items.Count > 0)
            {
                comboBoxCarID.SelectedIndex = 0;
            }
        }

        private void LoadFormData()
        {
            textBoxMaintenanceID.Text = _record.MaintenanceID;

            // Set the selected car in the dropdown
            if (!string.IsNullOrEmpty(_record.CarID))
            {
                for (int i = 0; i < comboBoxCarID.Items.Count; i++)
                {
                    string item = comboBoxCarID.Items[i].ToString();
                    if (item.StartsWith(_record.CarID))
                    {
                        comboBoxCarID.SelectedIndex = i;
                        break;
                    }
                }
            }

            if (_record.MaintenanceDate != DateTime.MinValue)
                dateTimePickerMaintenance.Value = _record.MaintenanceDate;
            else
                dateTimePickerMaintenance.Value = DateTime.Now;

            if (!string.IsNullOrEmpty(_record.MaintenanceStatus))
            {
                if (comboBoxStatus.Items.Contains(_record.MaintenanceStatus))
                    comboBoxStatus.SelectedItem = _record.MaintenanceStatus;
                else
                    comboBoxStatus.SelectedItem = "Pending";
            }
            else
                comboBoxStatus.SelectedItem = "Pending";

            textBoxDescription.Text = _record.MaintenanceDescription;
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateForm())
                {
                    // Update the record with form values
                    _record.MaintenanceID = textBoxMaintenanceID.Text;

                    // Extract the car ID from the selected dropdown item
                    string selectedCarItem = comboBoxCarID.SelectedItem.ToString();
                    string carID = selectedCarItem.Split('-')[0].Trim();
                    _record.CarID = carID;

                    _record.MaintenanceDate = dateTimePickerMaintenance.Value;
                    _record.MaintenanceStatus = comboBoxStatus.SelectedItem.ToString();
                    _record.MaintenanceDescription = textBoxDescription.Text;

                    // Debug - show the values being saved
                    string recordDetails = $"ID: {_record.MaintenanceID}, CarID: {_record.CarID}, Date: {_record.MaintenanceDate}, Status: {_record.MaintenanceStatus}";
                    Console.WriteLine("Saving record: " + recordDetails);

                    bool success = false;
                    if (_isNewRecord)
                    {
                        // Add new record
                        success = _maintenanceRepository.AddMaintenanceRecord(_record);
                    }
                    else
                    {
                        // Update existing record
                        success = _maintenanceRepository.UpdateMaintenanceRecord(_record);
                    }

                    if (success)
                    {
                        MessageBox.Show("Maintenance record saved successfully.", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DialogResult = DialogResult.OK;
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Failed to save maintenance record.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving maintenance record: {ex.Message}\n\n{ex.StackTrace}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateForm()
        {
            // Perform validation
            if (string.IsNullOrWhiteSpace(textBoxMaintenanceID.Text))
            {
                MessageBox.Show("Maintenance ID is required.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Check if a car is selected
            if (comboBoxCarID.SelectedItem == null)
            {
                MessageBox.Show("Please select a Car.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (comboBoxStatus.SelectedItem == null)
            {
                MessageBox.Show("Please select a maintenance status.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
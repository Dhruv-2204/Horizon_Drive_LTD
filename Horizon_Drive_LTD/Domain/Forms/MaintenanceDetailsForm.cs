using System;
using System.Drawing;
using System.Windows.Forms;
using Horizon_Drive_LTD.BusinessLogic;
using Horizon_Drive_LTD.BusinessLogic.Repositories;
using Horizon_Drive_LTD.Domain.Entities;

namespace Horizon_Drive_LTD.Domain.Forms
{
    public partial class MaintenanceDetailsForm : Form
    {
        private readonly MaintenanceRecord _record;
        private readonly DatabaseConnection _dbConnection;
        private readonly MaintenanceRepository _maintenanceRepository;
        private readonly bool _isNewRecord;

        public MaintenanceDetailsForm(MaintenanceRecord record, DatabaseConnection dbConnection, bool isNew)
        {
            InitializeComponent();
            _record = record;
            _dbConnection = dbConnection;
            _maintenanceRepository = new MaintenanceRepository(_dbConnection);
            _isNewRecord = isNew;

            // Set the form title
            this.Text = _isNewRecord ? "Add New Maintenance" : "Edit Maintenance";

            // Set readonly for ID field if editing existing record
            textBoxMaintenanceID.ReadOnly = !_isNewRecord;

            // Load the form with the record details
            LoadFormData();
        }

        private void LoadFormData()
        {
            textBoxMaintenanceID.Text = _record.MaintenanceID;
            textBoxCarID.Text = _record.CarID;

            if (_record.MaintenanceDate != DateTime.MinValue)
                dateTimePickerMaintenance.Value = _record.MaintenanceDate;
            else
                dateTimePickerMaintenance.Value = DateTime.Now;

            if (!string.IsNullOrEmpty(_record.MaintenanceStatus))
                comboBoxStatus.SelectedItem = _record.MaintenanceStatus;
            else
                comboBoxStatus.SelectedItem = "Pending";

            textBoxDescription.Text = _record.MaintenanceDescription;
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                // Update the record with form values
                _record.MaintenanceID = textBoxMaintenanceID.Text;
                _record.CarID = textBoxCarID.Text;
                _record.MaintenanceDate = dateTimePickerMaintenance.Value;
                _record.MaintenanceStatus = comboBoxStatus.SelectedItem.ToString();
                _record.MaintenanceDescription = textBoxDescription.Text;

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

        private bool ValidateForm()
        {
            // Perform validation
            if (string.IsNullOrWhiteSpace(textBoxMaintenanceID.Text))
            {
                MessageBox.Show("Maintenance ID is required.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(textBoxCarID.Text))
            {
                MessageBox.Show("Car ID is required.", "Validation Error",
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
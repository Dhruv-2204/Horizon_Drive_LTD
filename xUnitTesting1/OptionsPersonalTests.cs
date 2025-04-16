using System;
using Xunit;

namespace xUnitTesting1
{
    public class OptionsPersonalTests
    {
        [Fact]
        public void BtnSaveChanges_ShouldShowValidationError_WhenFieldsAreEmpty()
        {
            // Act
            bool validationErrorShown = ValidateFields("", "", "", "");

            // Assert
            Assert.True(validationErrorShown, "Validation error should occur when fields are empty.");
        }

        private bool ValidateFields(string firstName, string lastName, string email, string address)
        {
            // Simulate the validation logic
            if (string.IsNullOrWhiteSpace(firstName) ||
                string.IsNullOrWhiteSpace(lastName) ||
                string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(address))
            {
                return true; // Represents the validation error being shown
            }
            return false;
        }
    }
}

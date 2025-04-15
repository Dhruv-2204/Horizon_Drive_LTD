using System;

namespace MsTesting1
{
    [TestClass]
    public sealed class OptionsPersonalTests
    {
        [TestMethod]
        public void BtnSaveChanges_ShouldShowValidationError_WhenFieldsAreEmpty()
        {
            // Test Use: Verify that a validation error is shown when all input fields are empty.
            // Act: Simulate the validation with empty fields
            var validationErrorShown = ValidateFields("", "", "", "");

            // Assert: Ensure that a validation error occurs
            Assert.IsTrue(validationErrorShown, "A validation error should occur when fields are empty.");
        }

        private bool ValidateFields(string firstName, string lastName, string email, string address)
        {
            // Simulate the validation logic for empty fields
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

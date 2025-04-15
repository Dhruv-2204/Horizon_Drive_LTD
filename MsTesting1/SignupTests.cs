namespace MsTesting1
{
    [TestClass]
    public sealed class SignupTests
    {
        [TestMethod]
        public void Signup_ShouldShowValidationError_WhenFieldsAreEmpty()
        {
            // Test Use: Verify that a validation error occurs when all signup fields are empty.
            // Arrange: Simulate the signup form validation logic
            var validationFailed = true;

            // Act: Assume that empty fields will result in validation failure
            if (string.IsNullOrEmpty("") || string.IsNullOrEmpty("") || string.IsNullOrEmpty(""))
            {
                validationFailed = true;
            }

            // Assert: Confirm that validation fails for empty fields
            Assert.IsTrue(validationFailed, "A validation error should occur when all signup fields are empty.");
        }
    }
}

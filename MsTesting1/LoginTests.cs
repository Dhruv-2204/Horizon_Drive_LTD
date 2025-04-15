using Horizon_Drive_LTD.BusinessLogic.Services;
using Horizon_Drive_LTD.Domain.Entities;
using splashscreen;

namespace MsTesting1
{
    [TestClass]
    public sealed class LoginTests
    {
        [TestMethod]
        public void HashPassword_Should_ReturnSameHash_ForSameInput()
        {
            // Test Use: Verify that the same input password produces the same hash.
            // Arrange: Define the password
            var password = "Secure123!";

            // Act: Generate hashes for the same password
            var hash1 = Login.HashPassword(password);
            var hash2 = Login.HashPassword(password);

            // Assert: Confirm both hashes are identical
            Assert.AreEqual(hash1, hash2, "The same password should produce identical hashes.");
        }

        [TestMethod]
        public void HashPassword_Should_ReturnDifferentHash_ForDifferentInput()
        {
            // Test Use: Verify that different input passwords produce different hashes.
            // Arrange: Define two distinct passwords
            var password1 = "Password123";
            var password2 = "Password456";

            // Act: Generate hashes for both passwords
            var hash1 = Login.HashPassword(password1);
            var hash2 = Login.HashPassword(password2);

            // Assert: Confirm the hashes are distinct
            Assert.AreNotEqual(hash1, hash2, "Different passwords should produce unique hashes.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_Should_ThrowArgumentNullException_When_DbConnectionIsNull()
        {
            // Test Use: Verify that the constructor throws an exception when the database connection is null.
            // Arrange: Initialize the authentication service with null values
            var authService = new AuthenticationService(null, null);

            // Act: Attempt to create a Login instance with a null database connection
            new Login(authService, null);

            // Assert: ExpectedException handles the assertion
        }
    }
}

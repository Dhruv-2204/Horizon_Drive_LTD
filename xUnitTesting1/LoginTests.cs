using System; // For system-level utilities
using System.Collections.Generic; // For collections
using System.Linq; // For LINQ operations
using System.Text; // For string manipulation
using System.Threading.Tasks; // For asynchronous operations
using Xunit; // For xUnit testing framework
using Horizon_Drive_LTD.BusinessLogic.Services; // For business logic services
using Horizon_Drive_LTD.Domain.Entities; // For domain entities
using splashscreen; // Assuming this is part of your solution

namespace Horizon_Drive_LTD.Tests
{
    public class LoginTests
    {
        [Fact]
        public void HashPassword_Should_ReturnSameHash_ForSameInput()
        {
            // Arrange
            string password = "Secure123!";

            // Act
            string hash1 = Login.HashPassword(password);
            string hash2 = Login.HashPassword(password);

            // Assert
            Assert.Equal(hash1, hash2);
        }

        [Fact]
        public void HashPassword_Should_ReturnDifferentHash_ForDifferentInput()
        {
            // Arrange
            string password1 = "Password123";
            string password2 = "Password456";

            // Act
            string hash1 = Login.HashPassword(password1);
            string hash2 = Login.HashPassword(password2);

            // Assert
            Assert.NotEqual(hash1, hash2);
        }

        [Fact]
        public void Constructor_Should_ThrowArgumentNullException_When_DbConnectionIsNull()
        {
            // Arrange
            var authService = new AuthenticationService(null, null);

            // Act & Assert
            var ex = Assert.Throws<ArgumentNullException>(() =>
                new Login(authService, null)
            );

            // Assert
            Assert.Equal("dbConnection", ex.ParamName);
        }
    }
}

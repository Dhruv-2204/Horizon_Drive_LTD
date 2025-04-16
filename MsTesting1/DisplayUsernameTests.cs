using System;
using System.Drawing; // For Color structure
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MsTesting1
{
    internal class DisplayUsernameTests
    {
        // A mock label class to simulate the UI behavior of the label
        public class MockLabel
        {
            public string Text { get; set; } = string.Empty;
            public Color ForeColor { get; set; } = Color.Black;
        }

        public class UserInterface
        {
            private readonly MockLabel _labelUsername;

            public UserInterface(MockLabel labelUsername)
            {
                _labelUsername = labelUsername;
            }

            public void DisplayUsername(string username)
            {
                if (string.IsNullOrEmpty(username))
                {
                    _labelUsername.Text = "User not logged in";
                    _labelUsername.ForeColor = Color.Red;
                }
                else
                {
                    _labelUsername.Text = username;
                    _labelUsername.ForeColor = Color.FromArgb(15, 30, 45);
                }
            }
        }

        [TestClass]
        public sealed class Tests
        {
            [TestMethod]
            public void ShouldShowMessageWhenUserNotLoggedIn()
            {
                // Test Use: Verify that the label shows "User not logged in" and is styled in red.

                // Arrange
                var label = new MockLabel();
                var userInterface = new UserInterface(label);

                // Act
                userInterface.DisplayUsername(null);

                // Assert
                Assert.AreEqual("User not logged in", label.Text);
                Assert.AreEqual(Color.Red, label.ForeColor);
            }

            [TestMethod]
            public void ShouldShowUsernameWhenUserIsLoggedIn()
            {
                // Test Use: Verify that the label shows the username and is styled with the correct color.

                // Arrange
                var label = new MockLabel();
                var userInterface = new UserInterface(label);

                // Act
                userInterface.DisplayUsername("TestUser");

                // Assert
                Assert.AreEqual("TestUser", label.Text);
                Assert.AreEqual(Color.FromArgb(15, 30, 45), label.ForeColor);
            }
        }
    }
}

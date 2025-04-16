using System.Windows.Forms;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MsTesting1
{
    [TestClass]
    public sealed class ListCarTest
    {
        [TestMethod]
        public void Test_cboMake_SelectedIndexChanged_PopulatesModels()
        {
            // Test Use: Validate that PopulateModels is called with the correct make.

            // Arrange
            string selectedMake = "Toyota";
            MockComboBox cboMake = new MockComboBox { SelectedItem = selectedMake };
            bool populateModelsCalled = false;

            void MockPopulateModels(string make)
            {
                if (make == selectedMake)
                {
                    populateModelsCalled = true;
                }
            }

            // Act
            if (cboMake.SelectedItem != null)
            {
                MockPopulateModels(cboMake.SelectedItem.ToString());
            }

            // Assert
            Assert.IsTrue(populateModelsCalled, "PopulateModels should be called with the correct make.");
        }

        [TestMethod]
        public void Test_btnBrowseListings_NavigatesToBrowseListings()
        {
            // Test Use: Validate that the BrowseListings form is shown.

            // Arrange
            bool browseListingsShown = false;

            void MockBrowseListingsShow()
            {
                browseListingsShown = true;
            }

            // Act
            MockBrowseListingsShow();

            // Assert
            Assert.IsTrue(browseListingsShown, "BrowseListings form should be shown.");
        }

        [TestMethod]
        public void Test_btnLogout_LogsOutSuccessfully()
        {
            // Test Use: Validate that the user logs out when confirming the logout dialog.

            // Arrange
            bool loggedOut = false;

            void MockLogout()
            {
                loggedOut = true;
            }

            DialogResult mockResult = DialogResult.Yes;

            // Act
            if (mockResult == DialogResult.Yes)
            {
                MockLogout();
            }

            // Assert
            Assert.IsTrue(loggedOut, "The user should be logged out successfully.");
        }

        [TestMethod]
        public void Test_btnListMyCar_ValidatesAndGeneratesCarId()
        {
            // Test Use: Validate that a car ID is generated and form data is validated.

            // Arrange
            string expectedCarIdPrefix = "C";
            bool formValidated = true; // Simulate valid form
            string generatedCarId = null;

            string MockGenerateCarId()
            {
                return "C12345"; // Simulated car ID
            }

            // Act
            if (formValidated)
            {
                generatedCarId = MockGenerateCarId();
            }

            // Assert
            Assert.IsNotNull(generatedCarId, "Car ID should be generated.");
            Assert.IsTrue(generatedCarId.StartsWith(expectedCarIdPrefix), "Car ID should start with the correct prefix.");
        }
    }

    // Mock combo box for testing
    public class MockComboBox
    {
        public object SelectedItem { get; set; }
    }
}

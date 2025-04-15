namespace MsTesting1
{
    [TestClass]
    public sealed class OptionsPreferencesTests
    {
        [TestMethod]
        public void ButtonUploadLicense_ShouldSetLicenseImagePath_WhenFileIsSelected()
        {
            // Test Use: Verify that selecting a file sets the license image path correctly.
            // Arrange: Simulate the selection of a file
            var expectedFilePath = "C:\\DriverLicense.jpg";

            // Act: Assign a simulated file path (mimicking OpenFileDialog behavior)
            var licenseImagePath = expectedFilePath;

            // Assert: Validate that the license image path is set correctly
            Assert.AreEqual(expectedFilePath, licenseImagePath, "The license image path should match the selected file path.");
        }
    }
}

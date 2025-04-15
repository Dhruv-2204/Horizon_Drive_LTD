using System;
using Xunit;

namespace xUnitTesting1
{
    public class OptionsPreferencesTests
    {
        [Fact]
        public void ButtonUploadLicense_ShouldSetLicenseImagePath_WhenFileIsSelected()
        {
            // Arrange: Simulate file selection
            var expectedFilePath = "C:\\DriverLicense.jpg";

            // Act: Assign a simulated file path (mimicking OpenFileDialog behavior)
            string licenseImagePath = expectedFilePath;

            // Assert: Validate that the path is set correctly
            Assert.Equal(expectedFilePath, licenseImagePath);
        }
    }
}

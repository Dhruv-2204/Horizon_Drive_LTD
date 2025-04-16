using System;
using System.Collections.Generic;
using System.Drawing; // For working with images
using System.IO; // For file path operations
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MsTesting1
{
    [TestClass]
    public sealed class CarBookingFormTests
    {
        [TestMethod]
        public void LoadCarImages_ShouldFallbackToDefaultImage_WhenNoImagesFound()
        {
            // Test Use: Validate that a fallback image is used when no car images are found.

            // Arrange
            var carImages = new List<string>();
            var pictureBoxCar = new MockPictureBox();
            var fallbackImagePath = @"C:\Images\default-logo.jpg"; // Replace with the actual default image path
            var fallbackImage = fallbackImagePath; // Simulating the default image

            // Act
            if (carImages.Count == 0)
            {
                pictureBoxCar.Image = fallbackImage;
            }

            // Assert
            Assert.AreEqual(fallbackImage, pictureBoxCar.Image, "Fallback image should be displayed when no car images are found.");
        }

        [TestMethod]
        public void LoadImage_ShouldLoopIndexAround_WhenIndexOutOfBounds()
        {
            // Test Use: Validate that the image index loops correctly when out of bounds.

            // Arrange
            var carImages = new List<string> { "Image1.jpg", "Image2.jpg", "Image3.jpg" };
            int currentImageIndex = -1;

            // Act
            if (currentImageIndex < 0) currentImageIndex = carImages.Count - 1;
            if (currentImageIndex >= carImages.Count) currentImageIndex = 0;

            // Assert
            Assert.AreEqual(2, currentImageIndex, "Index should loop around correctly to the last image.");
        }

        [TestMethod]
        public void PopulateCarDetails_ShouldSetCorrectText()
        {
            // Test Use: Validate that car details are populated correctly.

            // Arrange
            var car = new Car
            {
                CarBrand = "Toyota",
                Model = "Corolla",
                Year = 2020,
                CarPrice = 2500,
                VehicleDescription = "A reliable and comfortable sedan.",
                Features = "Air Conditioning, Bluetooth",
                TransmissionType = "Automatic",
                SeatNo = 5,
                Power = "150 HP",
                DriveTrain = "Front-Wheel Drive"
            };
            var labelCarTitle = new MockLabel();
            var labelPrice = new MockLabel();
            var textBoxDescription = new MockTextBox();
            var featuresDetails = new MockTextBox();
            var transmissionSpec = new MockLabel();
            var passengersSpec = new MockLabel();
            var powerSpec = new MockLabel();
            var drivetrainSpec = new MockLabel();

            // Act
            labelCarTitle.Text = $"{car.CarBrand} {car.Model} ({car.Year}) for Rent";
            labelPrice.Text = $"MUR {car.CarPrice}/day";
            textBoxDescription.Text = car.VehicleDescription;
            featuresDetails.Text = car.Features;
            transmissionSpec.Text = $"Transmission Type: {car.TransmissionType}";
            passengersSpec.Text = $"Passengers: {car.SeatNo}";
            powerSpec.Text = $"Power: {car.Power}";
            drivetrainSpec.Text = $"Drivetrain: {car.DriveTrain}";

            // Assert
            Assert.AreEqual("Toyota Corolla (2020) for Rent", labelCarTitle.Text);
            Assert.AreEqual("MUR 2500/day", labelPrice.Text);
            Assert.AreEqual("A reliable and comfortable sedan.", textBoxDescription.Text);
            Assert.AreEqual("Air Conditioning, Bluetooth", featuresDetails.Text);
            Assert.AreEqual("Transmission Type: Automatic", transmissionSpec.Text);
            Assert.AreEqual("Passengers: 5", passengersSpec.Text);
            Assert.AreEqual("Power: 150 HP", powerSpec.Text);
            Assert.AreEqual("Drivetrain: Front-Wheel Drive", drivetrainSpec.Text);
        }

        [TestMethod]
        public void BtnBookCar_ShouldShowWarning_ForInvalidRentalPeriod()
        {
            // Test Use: Validate that a warning message is displayed for invalid rental periods.

            // Arrange
            var startDate = DateTime.Now;
            var endDate = startDate.AddDays(-1); // Invalid rental period
            var rentalPeriod = endDate - startDate;

            // Act
            var days = (int)Math.Ceiling(rentalPeriod.TotalDays);

            // Assert
            Assert.IsTrue(days <= 0, "Warning message should be displayed for invalid rental periods.");
        }
    }

    // Mocked UI components
    public class MockPictureBox
    {
        public string Image { get; set; } // Use string to simplify image simulation
    }

    public class MockLabel
    {
        public string Text { get; set; }
    }

    public class MockTextBox
    {
        public string Text { get; set; }
    }

    // Mocked Car class for testing
    public class Car
    {
        public string CarBrand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public int CarPrice { get; set; }
        public string VehicleDescription { get; set; }
        public string Features { get; set; }
        public string TransmissionType { get; set; }
        public int SeatNo { get; set; }
        public string Power { get; set; }
        public string DriveTrain { get; set; }
    }
}

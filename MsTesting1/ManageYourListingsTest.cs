using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace MsTesting1
{
    [TestClass]
    public sealed class ManageYourListingsTest
    {
        [TestMethod]
        public void Test_RemoveCarAndBookings_ShouldRemoveCarAndAssociatedBookings()
        {
            // Arrange
            var carId = "C001";
            var bookingId1 = "B001";
            var bookingId2 = "B002";
            var carHashTable = new Dictionary<string, Cars>
            {
                { carId, new Cars { CarID = carId, UserID = "U123" } }
            };
            var bookingHashTable = new Dictionary<string, Booking>
            {
                { bookingId1, new Booking { BookingID = bookingId1, CarID = carId } },
                { bookingId2, new Booking { BookingID = bookingId2, CarID = carId } }
            };

            // Act
            bookingHashTable.Remove(bookingId1);
            bookingHashTable.Remove(bookingId2);
            carHashTable.Remove(carId);

            // Assert
            Assert.IsFalse(carHashTable.ContainsKey(carId), "Car should be removed from the car hash table.");
            Assert.IsFalse(bookingHashTable.ContainsKey(bookingId1), "Booking B001 should be removed from the booking hash table.");
            Assert.IsFalse(bookingHashTable.ContainsKey(bookingId2), "Booking B002 should be removed from the booking hash table.");
        }

        [TestMethod]
        public void Test_RemoveCarPanel_ShouldUpdateListingsCount()
        {
            // Arrange
            var panelContent = new List<Panel>
            {
                new Panel { Name = "panelCarListingC001", Visible = true },
                new Panel { Name = "panelCarListingC002", Visible = true }
            };
            var carId = "C001";

            // Act
            var panelToRemove = panelContent.FirstOrDefault(p => p.Name == $"panelCarListing{carId}");
            if (panelToRemove != null)
            {
                panelContent.Remove(panelToRemove);
            }
            var visiblePanels = panelContent.Count(p => p.Visible);

            // Assert
            Assert.AreEqual(1, visiblePanels, "Visible car panels count should decrease after removal.");
        }

        // Simulated Cars class
        private class Cars
        {
            public string CarID { get; set; }
            public string UserID { get; set; }
        }

        // Simulated Booking class
        private class Booking
        {
            public string BookingID { get; set; }
            public string CarID { get; set; }
        }

        // Simulated Panel class
        private class Panel
        {
            public string Name { get; set; }
            public bool Visible { get; set; }
        }
    }
}

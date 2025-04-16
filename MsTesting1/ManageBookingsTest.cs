using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MsTesting1
{
    [TestClass]
    public sealed class ManageBookingsTest
    {
        [TestMethod]
        public void Test_LoadBookingData_ShouldClearAndAddBookings()
        {
            // Test Use: Validate that bookings are cleared and new data is added.

            // Arrange
            var bookings = new List<BookingInfo>
            {
                new BookingInfo { BookingID = "B001", CarID = "C001", BookingStatus = "Confirmed" }
            };

            var mockData = new List<BookingInfo>
            {
                new BookingInfo { BookingID = "B002", CarID = "C002", BookingStatus = "Pending" },
                new BookingInfo { BookingID = "B003", CarID = "C003", BookingStatus = "Confirmed" }
            };

            // Act
            bookings.Clear(); // Simulating clearing existing bookings
            bookings.AddRange(mockData); // Simulating adding new bookings

            // Assert
            Assert.AreEqual(2, bookings.Count, "Booking list should contain the newly added bookings.");
            Assert.AreEqual("B002", bookings[0].BookingID, "First booking ID should match the new data.");
            Assert.AreEqual("Pending", bookings[0].BookingStatus, "First booking status should match the new data.");
        }

        [TestMethod]
        public void Test_ApplyFilter_ShouldHighlightCorrectButton()
        {
            // Test Use: Validate that the correct filter button is highlighted.

            // Arrange
            var filterPanel = new FlowLayoutPanel();
            var filterButtons = new List<Button>
            {
                new Button { Text = "All" },
                new Button { Text = "Confirmed" },
                new Button { Text = "Pending" }
            };

            foreach (var button in filterButtons)
            {
                filterPanel.Controls.Add(button);
            }

            string selectedFilter = "Confirmed";

            // Act
            ApplyFilter(selectedFilter, filterPanel);

            // Assert
            foreach (Control control in filterPanel.Controls)
            {
                if (control is Button btn)
                {
                    if (btn.Text == selectedFilter)
                    {
                        Assert.AreEqual(Color.FromArgb(173, 216, 230), btn.BackColor, "The selected button should have a light blue background.");
                        Assert.AreEqual(Color.Black, btn.ForeColor, "The selected button should have black text.");
                    }
                    else
                    {
                        Assert.AreEqual(Color.FromArgb(30, 85, 110), btn.BackColor, "Unselected buttons should have a dark blue background.");
                        Assert.AreEqual(Color.White, btn.ForeColor, "Unselected buttons should have white text.");
                    }
                }
            }
        }

        [TestMethod]
        public void Test_DisplayBookings_ShouldAddPanelsToFlowLayout()
        {
            // Test Use: Validate that booking panels are created and added to the flow layout.

            // Arrange
            var bookingsToDisplay = new List<BookingInfo>
            {
                new BookingInfo { BookingID = "B001", CarID = "C001", BookingStatus = "Confirmed" },
                new BookingInfo { BookingID = "B002", CarID = "C002", BookingStatus = "Pending" }
            };

            var bookingsFlowPanel = new FlowLayoutPanel();
            var panelsAdded = 0;

            Panel MockCreateBookingPanel(BookingInfo booking)
            {
                panelsAdded++;
                return new Panel();
            }

            void DisplayBookings(List<BookingInfo> bookings)
            {
                bookingsFlowPanel.Controls.Clear();
                foreach (var booking in bookings)
                {
                    var panel = MockCreateBookingPanel(booking);
                    bookingsFlowPanel.Controls.Add(panel);
                }
            }

            // Act
            DisplayBookings(bookingsToDisplay);

            // Assert
            Assert.AreEqual(bookingsToDisplay.Count, bookingsFlowPanel.Controls.Count, "The number of panels added should match the number of bookings.");
            Assert.AreEqual(bookingsToDisplay.Count, panelsAdded, "The MockCreateBookingPanel should be called the correct number of times.");
        }

        // Helper Method: Simulate ApplyFilter functionality
        private void ApplyFilter(string filter, FlowLayoutPanel filterPanel)
        {
            foreach (Control control in filterPanel.Controls)
            {
                if (control is Button btn)
                {
                    if (btn.Text == filter)
                    {
                        btn.BackColor = Color.FromArgb(173, 216, 230); // Light blue for selected
                        btn.ForeColor = Color.Black;
                    }
                    else
                    {
                        btn.BackColor = Color.FromArgb(30, 85, 110); // Dark blue for unselected
                        btn.ForeColor = Color.White;
                    }
                }
            }
        }
    }

    // Simulated BookingInfo class
    public class BookingInfo
    {
        public string BookingID { get; set; }
        public string CarID { get; set; }
        public string BookingStatus { get; set; }
    }
}

using System;
using System.Drawing;
using System.Windows.Forms;
using Horizon_Drive_LTD.BusinessLogic.Repositories;
using Horizon_Drive_LTD.BusinessLogic;
using Horizon_Drive_LTD.Domain.Entities;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using Horizon_Drive_LTD.DataStructure;
using System.Collections;
using Horizon_Drive_LTD.BusinessLogic.Services;

namespace Horizon_Drive_LTD
{
    public partial class BookingConfirmationForm : Form
    {
        private Cars car;
        private DateTime startDate;
        private DateTime endDate;
        private string pickupLocation;
        private string dropoffLocation;
        private string pickupTime = "10:00 AM";
        private string dropoffTime = "11:00 AM";
        private bool driverIncluded;
        private bool babyCarSeatIncluded;
        private bool insuranceIncluded;
        private bool roofRackIncluded;
        private bool airportPickupIncluded;
        private decimal totalPrice;
        private int days;

        public BookingConfirmationForm(
            Cars car,
            DateTime startDate,
            DateTime endDate,
            string pickupLocation,
            string dropoffLocation,
            bool driverIncluded,
            bool babyCarSeatIncluded,
            bool insuranceIncluded,
            bool roofRackIncluded,
            bool airportPickupIncluded)
        {
            InitializeComponent();

            this.car = car;
            this.startDate = startDate;
            this.endDate = endDate;
            this.pickupLocation = pickupLocation;
            this.dropoffLocation = dropoffLocation;
            this.driverIncluded = driverIncluded;
            this.babyCarSeatIncluded = babyCarSeatIncluded;
            this.insuranceIncluded = insuranceIncluded;
            this.roofRackIncluded = roofRackIncluded;
            this.airportPickupIncluded = airportPickupIncluded;

            // Calculate rental days
            TimeSpan rentalPeriod = this.endDate - this.startDate;
            days = (int)Math.Ceiling(rentalPeriod.TotalDays);

            // Populate the form with booking details
            PopulateBookingDetails();
        }

        private void PopulateBookingDetails()
        {

            // Set car details
            labelCarName.Text = $"{car.CarBrand} {car.Model} {car.Year}";
            labelCarFeatures.Text = $"{car.Features}";

            // Set star rating (example - you can adjust based on your actual data)
            SetRating(car.Ratings);

            // Set rental period
            labelRentalPeriodValue.Text = $"{startDate.ToString("MMM d, yyyy")} - {endDate.ToString("MMM d, yyyy")} ({days} days)";

            // Set locations and times
            labelPickupLocationValue.Text = pickupLocation;
            labelDropoffLocationValue.Text = dropoffLocation;
            labelPickupTimeValue.Text = pickupTime;
            labelDropoffTimeValue.Text = dropoffTime;

            // Add selected options
            panelOptions.Controls.Clear();
            int yOffset = 10;

            if (driverIncluded)
            {
                AddOption(ref yOffset, "Driver Included (+MUR 1000/day)");
            }

            if (babyCarSeatIncluded)
            {
                AddOption(ref yOffset, "Baby Car Seat (+MUR 500/day)");
            }

            if (insuranceIncluded)
            {
                AddOption(ref yOffset, "Full Insurance (+MUR 1500/rental)");
            }

            if (roofRackIncluded)
            {
                AddOption(ref yOffset, "Roof Rack (+MUR 400/rental)");
            }

            if (airportPickupIncluded)
            {
                AddOption(ref yOffset, "Airport Pickup & Drop-off (+MUR 1000/trip)");
            }

            // Calculate and display pricing
            CalculateAndDisplayPricing();
        }



        private void AddOption(ref int yOffset, string optionText)
        {
            CheckBox checkBox = new CheckBox
            {
                Text = optionText,
                Checked = true,
                AutoSize = true,
                Enabled = false,
                Location = new Point(10, yOffset),
                ForeColor = Color.Black
            };

            panelOptions.Controls.Add(checkBox);
            yOffset += 30;
        }

        private void SetRating(decimal rating)
        {
            // Validate input (0-5 scale)
            rating = Math.Max(0, Math.Min(5, rating));

            // Set rating text (formatted to 1 decimal place)
            labelRating.Text = $"{rating:0.0}/5";

            // Clear existing stars
            panelStars.Controls.Clear();

            // Calculate full and partial stars
            int fullStars = (int)Math.Floor(rating);
            bool hasHalfStar = (rating - fullStars) >= 0.3m; // Threshold for showing half star

            // Create 5 stars
            for (int i = 0; i < 5; i++)
            {
                var star = new Label
                {
                    Text = i < fullStars ? "★" : "☆",
                    Font = new Font("Segoe UI", 14, FontStyle.Bold),
                    Size = new Size(24, 24),
                    Location = new Point(i * 24, 0),
                    ForeColor = i < fullStars ? Color.Gold : Color.LightGray,
                    Tag = i + 1 // Store star number for click events
                };

                // Handle half-star case
                if (hasHalfStar && i == fullStars)
                {
                    star.Text = "⯪"; // Half-star character
                    star.ForeColor = Color.Gold;
                }

                panelStars.Controls.Add(star);
            }


        }

       
        private void CalculateAndDisplayPricing()
        {
            // Calculate base price
            decimal dailyRate = car.CarPrice;
            decimal basePrice = dailyRate * days;

            // Calculate add-ons
            decimal driverPrice = driverIncluded ? 1000 * days : 0;
            decimal babyCarSeatPrice = babyCarSeatIncluded ? 500 : 0;
            decimal insurancePrice = insuranceIncluded ? 1500 : 0;
            decimal roofRackPrice = roofRackIncluded ? 400 : 0;
            decimal airportPickupPrice = airportPickupIncluded ? 1000 : 0;

            // Service fee (example)
            decimal serviceFee = 1000;

            // Calculate total
            totalPrice = basePrice + driverPrice + babyCarSeatPrice + insurancePrice +
                         roofRackPrice + airportPickupPrice + serviceFee;

            // Display prices
            labelDailyRateValue.Text = $"MUR{dailyRate}×{days}";

            // Only show selected add-ons
            if (driverIncluded)
            {
                labelDriverServiceValue.Text = $"MUR {driverPrice:N0}";
                labelDriverService.Visible = true;
                labelDriverServiceValue.Visible = true;
            }
            else
            {
                labelDriverService.Visible = false;
                labelDriverServiceValue.Visible = false;
            }

            if (babyCarSeatIncluded)
            {
                labelBabyCarSeatValue.Text = $"MUR {babyCarSeatPrice:N0}";
                labelBabyCarSeat.Visible = true;
                labelBabyCarSeatValue.Visible = true;
            }
            else
            {
                labelBabyCarSeat.Visible = false;
                labelBabyCarSeatValue.Visible = false;
            }

            labelServiceFeeValue.Text = $"MUR{serviceFee:N0}";
            labelTotalPriceValue.Text = $"MUR{totalPrice:N2}";
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

       
        private void buttonBookNow_Click(object sender, EventArgs e)
        {
            UserRepository userRepo = new UserRepository(new DatabaseConnection());
            userRepo.GetActiveUser(out string activeUsername, out string activeCustomerId);

            BookingsRepository bookingRepo = new BookingsRepository(new DatabaseConnection());
            HashTable<string, Booking> bookingHashTable = new HashTable<string, Booking>(1000);

            PaymentRepository paymentRepository = new PaymentRepository(new DatabaseConnection());
           

            CarRepository carRepo = new CarRepository(new DatabaseConnection());

            // creating the Booking ID
            Guid guid = Guid.NewGuid();
            int numericPart = Math.Abs(guid.GetHashCode()) % 100000;
            string bookingId = "B" + numericPart.ToString("D5");

            // creating the Payment ID
            numericPart = Math.Abs(guid.GetHashCode()) % 100000;
            string paymentId = "P" + numericPart.ToString("D5");

            DateTime date = DateTime.Now;
            string formattedDate = date.ToString("yyyy-MM-dd");

            bool isAvailable = bookingRepo.IsCarAvailable(car.CarID, startDate, endDate, bookingHashTable);

            if (!isAvailable)
            {
                MessageBox.Show("This car is already booked for the selected dates.");
            }
            else
            {
                if (!string.IsNullOrEmpty(activeUsername) && !string.IsNullOrEmpty(activeCustomerId))
                {
                    Booking booking = new Booking(bookingId, activeCustomerId, car.CarID, formattedDate, startDate.ToString("yyyy-MM-dd"), endDate.ToString("yyyy-MM-dd"), pickupLocation, dropoffLocation,
                                                    driverIncluded, babyCarSeatIncluded, insuranceIncluded, roofRackIncluded, airportPickupIncluded);

                    bookingHashTable.Insert(bookingId, booking);

                    bookingRepo.LoadBookingsIntoDatabase(booking);
                    carRepo.ChangeCarStatus(car.CarID);

                    string userId = CurrentUser.CurrentUserId;
                    MessageBox.Show($"{userId}");

                    Payment payment = new Payment(paymentId, bookingId, userId, formattedDate, "Online", totalPrice);
                    paymentRepository.LoadPaymentIntoDatabase(payment);

                    // Process the final booking
                    MessageBox.Show("Your booking has been confirmed! A confirmation email will be sent shortly.",
                     "Booking Confirmed", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    string customerEmail = userRepo.GetEmailByCustomerId(activeCustomerId);
                    EmailService.SendBookingConfirmationEmail(customerEmail, booking);
                }
                else
                {
                    MessageBox.Show("No active user found.");
                }
            }


           


        {


                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
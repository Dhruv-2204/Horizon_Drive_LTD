using System;
using System.Drawing;
using System.Windows.Forms;

namespace Horizon_Drive_LTD
{
    public partial class BookingConfirmationForm : Form
    {
        private CarListing car;
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
            CarListing car,
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
            TimeSpan rentalPeriod = endDate - startDate;
            days = (int)Math.Ceiling(rentalPeriod.TotalDays);

            // Populate the form with booking details
            PopulateBookingDetails();
        }

        private void PopulateBookingDetails()
        {
            // Set car image
            try
            {
                string imagePath = System.IO.Path.Combine("Images", car.ImagePath);
                if (System.IO.File.Exists(imagePath))
                {
                    pictureBoxCar.Image = Image.FromFile(imagePath);
                }
            }
            catch { /* If image load fails, just show empty */ }

            // Set car details
            labelCarName.Text = $"{car.Make} {car.Model} {car.Year}";
            labelCarFeatures.Text = $"4×4 • Automatic • 5 Seats";

            // Set star rating (example - you can adjust based on your actual data)
            SetRating(4.8);

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

        private void SetRating(double rating)
        {
            // Set rating text
            labelRating.Text = $"({rating}/5)";

            // Clear existing stars
            panelStars.Controls.Clear();

            // Create star shapes - in a real app you would use star images
            int fullStars = (int)Math.Floor(rating);

            for (int i = 0; i < 5; i++)
            {
                Label star = new Label
                {
                    Text = "★",
                    Font = new Font("Arial", 12),
                    Size = new Size(20, 20),
                    Location = new Point(i * 20, 0),
                    ForeColor = i < fullStars ? Color.Gold : Color.LightGray
                };

                panelStars.Controls.Add(star);
            }
        }

        private void CalculateAndDisplayPricing()
        {
            // Calculate base price
            decimal dailyRate = car.PricePerDay;
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
            labelDailyRateValue.Text = $"MUR {dailyRate:N2} × {days} days";

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

            labelServiceFeeValue.Text = $"MUR {serviceFee:N0}";
            labelTotalPriceValue.Text = $"MUR {totalPrice:N2}";
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void buttonBookNow_Click(object sender, EventArgs e)
        {
            // Process the final booking
            MessageBox.Show("Your booking has been confirmed! A confirmation email will be sent shortly.",
                "Booking Confirmed", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
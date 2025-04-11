namespace Horizon_Drive_LTD
{
    partial class BookingConfirmationForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            // Main form container
            this.ClientSize = new System.Drawing.Size(450, 690);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Booking Confirmation";

            // Title panel
            this.panelTitle = new System.Windows.Forms.Panel();
            this.panelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitle.BackColor = System.Drawing.Color.White;
            this.panelTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTitle.Height = 50;
            this.Controls.Add(this.panelTitle);

            // Logo
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.pictureBoxLogo.Location = new System.Drawing.Point(10, 10);
            this.pictureBoxLogo.Size = new System.Drawing.Size(30, 30);
            this.pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.panelTitle.Controls.Add(this.pictureBoxLogo);

            // Title label
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelTitle.AutoSize = true;
            this.labelTitle.Location = new System.Drawing.Point(50, 15);
            this.labelTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.labelTitle.Text = "Booking Confirmation";
            this.panelTitle.Controls.Add(this.labelTitle);

            // Main panel
            this.panelMain = new System.Windows.Forms.Panel();
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.AutoScroll = true;
            this.panelMain.Padding = new System.Windows.Forms.Padding(20);
            this.Controls.Add(this.panelMain);

            // Car image
            this.pictureBoxCar = new System.Windows.Forms.PictureBox();
            this.pictureBoxCar.Location = new System.Drawing.Point(20, 70);
            this.pictureBoxCar.Size = new System.Drawing.Size(150, 100);
            this.pictureBoxCar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxCar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMain.Controls.Add(this.pictureBoxCar);

            // Car name
            this.labelCarName = new System.Windows.Forms.Label();
            this.labelCarName.Location = new System.Drawing.Point(180, 70);
            this.labelCarName.Size = new System.Drawing.Size(250, 25);
            this.labelCarName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.labelCarName.Text = "Ford Raptor 2025";
            this.panelMain.Controls.Add(this.labelCarName);

            // Car features
            this.labelCarFeatures = new System.Windows.Forms.Label();
            this.labelCarFeatures.Location = new System.Drawing.Point(180, 95);
            this.labelCarFeatures.Size = new System.Drawing.Size(250, 20);
            this.labelCarFeatures.Text = "4×4 • Automatic • 5 Seats";
            this.panelMain.Controls.Add(this.labelCarFeatures);

            // Stars panel
            this.panelStars = new System.Windows.Forms.Panel();
            this.panelStars.Location = new System.Drawing.Point(180, 115);
            this.panelStars.Size = new System.Drawing.Size(100, 20);
            this.panelMain.Controls.Add(this.panelStars);

            // Rating label
            this.labelRating = new System.Windows.Forms.Label();
            this.labelRating.Location = new System.Drawing.Point(290, 115);
            this.labelRating.Size = new System.Drawing.Size(50, 20);
            this.labelRating.Text = "(4.8/5)";
            this.panelMain.Controls.Add(this.labelRating);

            // Detail labels - left column (titles)
            int topPosition = 190;

            this.labelRentalPeriod = new System.Windows.Forms.Label();
            this.labelRentalPeriod.Location = new System.Drawing.Point(20, topPosition);
            this.labelRentalPeriod.AutoSize = true;
            this.labelRentalPeriod.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.labelRentalPeriod.Text = "Rental Period:";
            this.panelMain.Controls.Add(this.labelRentalPeriod);

            topPosition += 25;
            this.labelPickupLocation = new System.Windows.Forms.Label();
            this.labelPickupLocation.Location = new System.Drawing.Point(20, topPosition);
            this.labelPickupLocation.AutoSize = true;
            this.labelPickupLocation.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.labelPickupLocation.Text = "Pickup Location:";
            this.panelMain.Controls.Add(this.labelPickupLocation);

            topPosition += 25;
            this.labelDropoffLocation = new System.Windows.Forms.Label();
            this.labelDropoffLocation.Location = new System.Drawing.Point(20, topPosition);
            this.labelDropoffLocation.AutoSize = true;
            this.labelDropoffLocation.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.labelDropoffLocation.Text = "Drop-off Location:";
            this.panelMain.Controls.Add(this.labelDropoffLocation);

            topPosition += 25;
            this.labelPickupTime = new System.Windows.Forms.Label();
            this.labelPickupTime.Location = new System.Drawing.Point(20, topPosition);
            this.labelPickupTime.AutoSize = true;
            this.labelPickupTime.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.labelPickupTime.Text = "Pickup Time:";
            this.panelMain.Controls.Add(this.labelPickupTime);

            topPosition += 25;
            this.labelDropoffTime = new System.Windows.Forms.Label();
            this.labelDropoffTime.Location = new System.Drawing.Point(20, topPosition);
            this.labelDropoffTime.AutoSize = true;
            this.labelDropoffTime.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.labelDropoffTime.Text = "Drop-off Time:";
            this.panelMain.Controls.Add(this.labelDropoffTime);

            // Detail labels - right column (values)
            topPosition = 190;

            this.labelRentalPeriodValue = new System.Windows.Forms.Label();
            this.labelRentalPeriodValue.Location = new System.Drawing.Point(150, topPosition);
            this.labelRentalPeriodValue.Size = new System.Drawing.Size(280, 20);
            this.labelRentalPeriodValue.Text = "Mar 5, 2025 - Mar 10, 2025 (5 days)";
            this.panelMain.Controls.Add(this.labelRentalPeriodValue);

            topPosition += 25;
            this.labelPickupLocationValue = new System.Windows.Forms.Label();
            this.labelPickupLocationValue.Location = new System.Drawing.Point(150, topPosition);
            this.labelPickupLocationValue.Size = new System.Drawing.Size(280, 20);
            this.labelPickupLocationValue.Text = "123 Main Street, Boston, MA 02108";
            this.panelMain.Controls.Add(this.labelPickupLocationValue);

            topPosition += 25;
            this.labelDropoffLocationValue = new System.Windows.Forms.Label();
            this.labelDropoffLocationValue.Location = new System.Drawing.Point(150, topPosition);
            this.labelDropoffLocationValue.Size = new System.Drawing.Size(280, 20);
            this.labelDropoffLocationValue.Text = "123 Main Street, Boston, MA 02108";
            this.panelMain.Controls.Add(this.labelDropoffLocationValue);

            topPosition += 25;
            this.labelPickupTimeValue = new System.Windows.Forms.Label();
            this.labelPickupTimeValue.Location = new System.Drawing.Point(150, topPosition);
            this.labelPickupTimeValue.Size = new System.Drawing.Size(280, 20);
            this.labelPickupTimeValue.Text = "10:00 AM";
            this.panelMain.Controls.Add(this.labelPickupTimeValue);

            topPosition += 25;
            this.labelDropoffTimeValue = new System.Windows.Forms.Label();
            this.labelDropoffTimeValue.Location = new System.Drawing.Point(150, topPosition);
            this.labelDropoffTimeValue.Size = new System.Drawing.Size(280, 20);
            this.labelDropoffTimeValue.Text = "11:00 AM";
            this.panelMain.Controls.Add(this.labelDropoffTimeValue);

            // Options panel
            topPosition += 40;
            this.labelOptions = new System.Windows.Forms.Label();
            this.labelOptions.Location = new System.Drawing.Point(20, topPosition);
            this.labelOptions.AutoSize = true;
            this.labelOptions.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.labelOptions.Text = "Selected Options";
            this.panelMain.Controls.Add(this.labelOptions);

            topPosition += 25;
            this.panelOptions = new System.Windows.Forms.Panel();
            this.panelOptions.Location = new System.Drawing.Point(20, topPosition);
            this.panelOptions.Size = new System.Drawing.Size(410, 90);
            this.panelOptions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelOptions.BackColor = System.Drawing.Color.LightGray;
            this.panelMain.Controls.Add(this.panelOptions);

            // Pricing panel
            topPosition += 100;
            this.panelPricing = new System.Windows.Forms.Panel();
            this.panelPricing.Location = new System.Drawing.Point(20, topPosition);
            this.panelPricing.Size = new System.Drawing.Size(410, 150);
            this.panelPricing.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelPricing.BackColor = System.Drawing.Color.LightBlue;
            this.panelMain.Controls.Add(this.panelPricing);

            // Pricing details
            int pricingTop = 10;

            this.labelDailyRate = new System.Windows.Forms.Label();
            this.labelDailyRate.Location = new System.Drawing.Point(10, pricingTop);
            this.labelDailyRate.AutoSize = true;
            this.labelDailyRate.Text = "Daily Rate:";
            this.panelPricing.Controls.Add(this.labelDailyRate);

            this.labelDailyRateValue = new System.Windows.Forms.Label();
            this.labelDailyRateValue.Location = new System.Drawing.Point(270, pricingTop);
            this.labelDailyRateValue.Size = new System.Drawing.Size(130, 20);
            this.labelDailyRateValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.labelDailyRateValue.Text = "MUR 15000.00 × 5 days";
            this.panelPricing.Controls.Add(this.labelDailyRateValue);

            pricingTop += 25;
            this.labelDriverService = new System.Windows.Forms.Label();
            this.labelDriverService.Location = new System.Drawing.Point(10, pricingTop);
            this.labelDriverService.AutoSize = true;
            this.labelDriverService.Text = "Driver Service:";
            this.panelPricing.Controls.Add(this.labelDriverService);

            this.labelDriverServiceValue = new System.Windows.Forms.Label();
            this.labelDriverServiceValue.Location = new System.Drawing.Point(270, pricingTop);
            this.labelDriverServiceValue.Size = new System.Drawing.Size(130, 20);
            this.labelDriverServiceValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.labelDriverServiceValue.Text = "MUR 1000";
            this.panelPricing.Controls.Add(this.labelDriverServiceValue);

            pricingTop += 25;
            this.labelBabyCarSeat = new System.Windows.Forms.Label();
            this.labelBabyCarSeat.Location = new System.Drawing.Point(10, pricingTop);
            this.labelBabyCarSeat.AutoSize = true;
            this.labelBabyCarSeat.Text = "Baby Car Seat:";
            this.panelPricing.Controls.Add(this.labelBabyCarSeat);

            this.labelBabyCarSeatValue = new System.Windows.Forms.Label();
            this.labelBabyCarSeatValue.Location = new System.Drawing.Point(270, pricingTop);
            this.labelBabyCarSeatValue.Size = new System.Drawing.Size(130, 20);
            this.labelBabyCarSeatValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.labelBabyCarSeatValue.Text = "MUR 500";
            this.panelPricing.Controls.Add(this.labelBabyCarSeatValue);

            pricingTop += 25;
            this.labelServiceFee = new System.Windows.Forms.Label();
            this.labelServiceFee.Location = new System.Drawing.Point(10, pricingTop);
            this.labelServiceFee.AutoSize = true;
            this.labelServiceFee.Text = "Service Fee:";
            this.panelPricing.Controls.Add(this.labelServiceFee);

            this.labelServiceFeeValue = new System.Windows.Forms.Label();
            this.labelServiceFeeValue.Location = new System.Drawing.Point(270, pricingTop);
            this.labelServiceFeeValue.Size = new System.Drawing.Size(130, 20);
            this.labelServiceFeeValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.labelServiceFeeValue.Text = "MUR 1000";
            this.panelPricing.Controls.Add(this.labelServiceFeeValue);

            // Add separator line
            pricingTop += 25;
            this.panelSeparator = new System.Windows.Forms.Panel();
            this.panelSeparator.Location = new System.Drawing.Point(10, pricingTop);
            this.panelSeparator.Size = new System.Drawing.Size(390, 1);
            this.panelSeparator.BackColor = System.Drawing.Color.Black;
            this.panelPricing.Controls.Add(this.panelSeparator);

            pricingTop += 10;
            this.labelTotalPrice = new System.Windows.Forms.Label();
            this.labelTotalPrice.Location = new System.Drawing.Point(10, pricingTop);
            this.labelTotalPrice.AutoSize = true;
            this.labelTotalPrice.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.labelTotalPrice.Text = "Total Price:";
            this.panelPricing.Controls.Add(this.labelTotalPrice);

            this.labelTotalPriceValue = new System.Windows.Forms.Label();
            this.labelTotalPriceValue.Location = new System.Drawing.Point(270, pricingTop);
            this.labelTotalPriceValue.Size = new System.Drawing.Size(130, 20);
            this.labelTotalPriceValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.labelTotalPriceValue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.labelTotalPriceValue.Text = "MUR 77500.00";
            this.panelPricing.Controls.Add(this.labelTotalPriceValue);

            // Terms and conditions
            topPosition += 160;
            this.labelTerms = new System.Windows.Forms.Label();
            this.labelTerms.Location = new System.Drawing.Point(20, topPosition);
            this.labelTerms.Size = new System.Drawing.Size(410, 20);
            this.labelTerms.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.labelTerms.Text = "By clicking \"Book Now\", you agree to our Terms and Conditions and Cancellation Policy.";
            this.panelMain.Controls.Add(this.labelTerms);

            // Buttons
            topPosition += 30;
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonCancel.Location = new System.Drawing.Point(120, topPosition);
            this.buttonCancel.Size = new System.Drawing.Size(100, 35);
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.BackColor = System.Drawing.Color.LightGray;
            this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            this.panelMain.Controls.Add(this.buttonCancel);

            this.buttonBookNow = new System.Windows.Forms.Button();
            this.buttonBookNow.Location = new System.Drawing.Point(230, topPosition);
            this.buttonBookNow.Size = new System.Drawing.Size(100, 35);
            this.buttonBookNow.Text = "Book Car";
            this.buttonBookNow.BackColor = System.Drawing.Color.FromArgb(23, 107, 135);
            this.buttonBookNow.ForeColor = System.Drawing.Color.White;
            this.buttonBookNow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBookNow.Click += new System.EventHandler(this.buttonBookNow_Click);
            this.panelMain.Controls.Add(this.buttonBookNow);

            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelTitle;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.PictureBox pictureBoxCar;
        private System.Windows.Forms.Label labelCarName;
        private System.Windows.Forms.Label labelCarFeatures;
        private System.Windows.Forms.Panel panelStars;
        private System.Windows.Forms.Label labelRating;
        private System.Windows.Forms.Label labelRentalPeriod;
        private System.Windows.Forms.Label labelRentalPeriodValue;
        private System.Windows.Forms.Label labelPickupLocation;
        private System.Windows.Forms.Label labelPickupLocationValue;
        private System.Windows.Forms.Label labelDropoffLocation;
        private System.Windows.Forms.Label labelDropoffLocationValue;
        private System.Windows.Forms.Label labelPickupTime;
        private System.Windows.Forms.Label labelPickupTimeValue;
        private System.Windows.Forms.Label labelDropoffTime;
        private System.Windows.Forms.Label labelDropoffTimeValue;
        private System.Windows.Forms.Label labelOptions;
        private System.Windows.Forms.Panel panelOptions;
        private System.Windows.Forms.Panel panelPricing;
        private System.Windows.Forms.Label labelDailyRate;
        private System.Windows.Forms.Label labelDailyRateValue;
        private System.Windows.Forms.Label labelDriverService;
        private System.Windows.Forms.Label labelDriverServiceValue;
        private System.Windows.Forms.Label labelBabyCarSeat;
        private System.Windows.Forms.Label labelBabyCarSeatValue;
        private System.Windows.Forms.Label labelServiceFee;
        private System.Windows.Forms.Label labelServiceFeeValue;
        private System.Windows.Forms.Panel panelSeparator;
        private System.Windows.Forms.Label labelTotalPrice;
        private System.Windows.Forms.Label labelTotalPriceValue;
        private System.Windows.Forms.Label labelTerms;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonBookNow;
    }
}
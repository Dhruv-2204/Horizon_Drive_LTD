using System;
using System.Drawing;
using System.Windows.Forms;

namespace Horizon_Drive_LTD
{
    partial class Manage_Listings
    {
        private System.ComponentModel.IContainer components = null;

        // UI Components
        private Panel panelMainContainer; // Main container with scrollable content
        private Panel panelContent; // Top content panel where all components reside
        private Panel panelNavigation; // Left-side navigation menu
        private Label lblNavTitle;
        private Button btnBrowseListings;
        private Button btnManageBookings;
        private Button btnListACar;
        private Button btnManageListings;
        private Button btnOptions;

        private Panel panelHeader; // Top header section
        private Label lblTitle;

        private Panel panelYourListings; // Section for "Your Listings"
        private Panel panelCurrentReservations;
        private Panel panelTotalEarnings;
        private FlowLayoutPanel flowLayoutPanelListings; // Listings content with PictureBox

        private Label lblTransactionHistory;
        private FlowLayoutPanel flowLayoutPanelTransactions; // Transactions content

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelMainContainer = new Panel();
            this.panelContent = new Panel();
            this.panelNavigation = new Panel();
            this.lblNavTitle = new Label();
            this.btnBrowseListings = new Button();
            this.btnManageBookings = new Button();
            this.btnListACar = new Button();
            this.btnManageListings = new Button();
            this.btnOptions = new Button();

            this.panelHeader = new Panel();
            this.lblTitle = new Label();

            this.panelYourListings = new Panel();
            this.panelCurrentReservations = new Panel();
            this.panelTotalEarnings = new Panel();
            this.flowLayoutPanelListings = new FlowLayoutPanel();

            this.lblTransactionHistory = new Label();
            this.flowLayoutPanelTransactions = new FlowLayoutPanel();

            this.SuspendLayout();

            // 
            // panelMainContainer
            // 
            this.panelMainContainer.Dock = DockStyle.Fill;
            this.panelMainContainer.AutoScroll = true;
            this.panelMainContainer.BackColor = Color.White;

            // 
            // panelContent
            // 
            this.panelContent.Size = new Size(1200, 1500); // Sufficient size to include all elements
            this.panelContent.Location = new Point(0, 0); // Positioned inside the main container
            this.panelContent.BackColor = Color.White;

            // 
            // panelNavigation
            // 
            this.panelNavigation.BackColor = Color.FromArgb(20, 50, 80);
            this.panelNavigation.Dock = DockStyle.Left;
            this.panelNavigation.Width = 200;
            this.panelNavigation.Controls.Add(this.lblNavTitle);
            this.panelNavigation.Controls.Add(this.btnBrowseListings);
            this.panelNavigation.Controls.Add(this.btnManageBookings);
            this.panelNavigation.Controls.Add(this.btnListACar);
            this.panelNavigation.Controls.Add(this.btnManageListings);
            this.panelNavigation.Controls.Add(this.btnOptions);

            // 
            // lblNavTitle
            // 
            this.lblNavTitle.Text = "Navigation";
            this.lblNavTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.lblNavTitle.ForeColor = Color.White;
            this.lblNavTitle.Location = new Point(20, 20);
            this.lblNavTitle.Size = new Size(260, 50);

            // 
            // Navigation Buttons
            // 
            ConfigureButton(this.btnBrowseListings, "Browse Listings", new Point(20, 60));
            ConfigureButton(this.btnManageBookings, "Manage Bookings", new Point(20, 110));
            ConfigureButton(this.btnListACar, "List a Car", new Point(20, 160));
            ConfigureButton(this.btnManageListings, "Manage Listings", new Point(20, 210));
            ConfigureButton(this.btnOptions, "Options", new Point(20, 260));

            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = Color.FromArgb(30, 85, 110);
            this.panelHeader.Dock = DockStyle.Top;
            this.panelHeader.Height = 100;
            this.panelHeader.Controls.Add(this.lblTitle);

            // 
            // lblTitle
            // 
            this.lblTitle.Text = "Manage Listings";
            this.lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.White;
            this.lblTitle.Location = new Point(220, 30);

            // 
            // panelYourListings
            // 
            this.panelYourListings.Size = new Size(300, 100);
            this.panelYourListings.Location = new Point(220, 120);
            this.panelYourListings.BackColor = Color.LightBlue;
            CreateDynamicBox(this.panelYourListings, "Your Listings", "2");

            // 
            // panelCurrentReservations
            // 
            this.panelCurrentReservations.Size = new Size(300, 100);
            this.panelCurrentReservations.Location = new Point(540, 120);
            this.panelCurrentReservations.BackColor = Color.LightGreen;
            CreateDynamicBox(this.panelCurrentReservations, "Reservations", "1");

            // 
            // panelTotalEarnings
            // 
            this.panelTotalEarnings.Size = new Size(300, 100);
            this.panelTotalEarnings.Location = new Point(860, 120);
            this.panelTotalEarnings.BackColor = Color.LightPink;
            CreateDynamicBox(this.panelTotalEarnings, "Total Earnings", "MUR 150000");

            // 
            // flowLayoutPanelListings
            // 
            this.flowLayoutPanelListings.Size = new Size(980, 400);
            this.flowLayoutPanelListings.Location = new Point(220, 240);
            this.flowLayoutPanelListings.FlowDirection = FlowDirection.TopDown;
            this.flowLayoutPanelListings.BackColor = Color.White;
            this.flowLayoutPanelListings.WrapContents = false;

            // 
            // lblTransactionHistory
            // 
            this.lblTransactionHistory.Text = "Transaction History";
            this.lblTransactionHistory.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.lblTransactionHistory.Location = new Point(220, 660);
            this.lblTransactionHistory.Size = new Size(200, 30);

            // 
            // flowLayoutPanelTransactions
            // 
            this.flowLayoutPanelTransactions.Size = new Size(980, 300);
            this.flowLayoutPanelTransactions.Location = new Point(220, 700);
            this.flowLayoutPanelTransactions.FlowDirection = FlowDirection.TopDown;
            this.flowLayoutPanelTransactions.BackColor = Color.White;
            this.flowLayoutPanelTransactions.WrapContents = false;

            // 
            // Add controls to panelContent
            // 
            this.panelContent.Controls.Add(this.panelHeader);
            this.panelContent.Controls.Add(this.panelYourListings);
            this.panelContent.Controls.Add(this.panelCurrentReservations);
            this.panelContent.Controls.Add(this.panelTotalEarnings);
            this.panelContent.Controls.Add(this.flowLayoutPanelListings);
            this.panelContent.Controls.Add(this.lblTransactionHistory);
            this.panelContent.Controls.Add(this.flowLayoutPanelTransactions);

            // 
            // Add panelContent to panelMainContainer
            // 
            this.panelMainContainer.Controls.Add(this.panelContent);

            // 
            // Add to Form
            // 
            this.Controls.Add(this.panelNavigation);
            this.Controls.Add(this.panelMainContainer);
            this.ClientSize = new Size(1200, 900);
            this.ResumeLayout(false);
        }

        private void ConfigureButton(Button btn, string text, Point location)
        {
            btn.Text = text;
            btn.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            btn.ForeColor = Color.White;
            btn.BackColor = Color.FromArgb(40, 100, 140);
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Location = location;
            btn.Size = new Size(160, 40);
        }

        private void CreateDynamicBox(Panel panel, string title, string value)
        {
            Label titleLabel = new Label
            {
                Text = title,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                Location = new Point(10, 10),
                Size = new Size(280, 20)
            };

            Label valueLabel = new Label
            {
                Text = value,
                Font = new Font("Segoe UI", 16F, FontStyle.Bold),
                Location = new Point(10, 40),
                Size = new Size(280, 40)
            };

            panel.Controls.Add(titleLabel);
            panel.Controls.Add(valueLabel);
        }
    }
}

using System;
using System.Drawing;
using System.Windows.Forms;

namespace Horizon_Drive_LTD
{
    partial class Manage_Listings
    {
        private System.ComponentModel.IContainer components = null;

        // UI Components
        private Panel panelHeader;
        private Label lblTitle;
        private Panel panelYourListings;
        private Panel panelCurrentReservations;
        private Panel panelTotalEarnings;
        private FlowLayoutPanel flowLayoutPanelListings;

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
            this.panelHeader = new Panel();
            this.lblTitle = new Label();
            this.panelYourListings = new Panel();
            this.panelCurrentReservations = new Panel();
            this.panelTotalEarnings = new Panel();
            this.flowLayoutPanelListings = new FlowLayoutPanel();

            this.SuspendLayout();

            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = Color.FromArgb(30, 85, 110);
            this.panelHeader.Dock = DockStyle.Top;
            this.panelHeader.Size = new Size(1200, 100);

            // 
            // lblTitle
            // 
            this.lblTitle.Text = "Manage Listings";
            this.lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.White;
            this.lblTitle.Location = new Point(20, 30);

            this.panelHeader.Controls.Add(this.lblTitle);

            // 
            // panelYourListings
            // 
            this.panelYourListings.Size = new Size(300, 100);
            this.panelYourListings.Location = new Point(20, 120);
            this.panelYourListings.BackColor = Color.LightBlue;
            CreateDynamicBox(this.panelYourListings, "Your Listings", "2");

            // 
            // panelCurrentReservations
            // 
            this.panelCurrentReservations.Size = new Size(300, 100);
            this.panelCurrentReservations.Location = new Point(340, 120);
            this.panelCurrentReservations.BackColor = Color.LightGreen;
            CreateDynamicBox(this.panelCurrentReservations, "Current Reservations", "1");

            // 
            // panelTotalEarnings
            // 
            this.panelTotalEarnings.Size = new Size(300, 100);
            this.panelTotalEarnings.Location = new Point(660, 120);
            this.panelTotalEarnings.BackColor = Color.LightPink;
            CreateDynamicBox(this.panelTotalEarnings, "Total Earnings", "MUR 150000");

            // 
            // flowLayoutPanelListings
            // 
            this.flowLayoutPanelListings.Size = new Size(1140, 400);
            this.flowLayoutPanelListings.Location = new Point(20, 240);
            this.flowLayoutPanelListings.AutoScroll = true;
            this.flowLayoutPanelListings.BackColor = Color.White;
            this.flowLayoutPanelListings.FlowDirection = FlowDirection.TopDown; // Ensures vertical stacking
            this.flowLayoutPanelListings.WrapContents = false; // Prevent horizontal wrapping

            // 
            // Manage_Listings
            // 
            this.ClientSize = new Size(1200, 700);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.panelYourListings);
            this.Controls.Add(this.panelCurrentReservations);
            this.Controls.Add(this.panelTotalEarnings);
            this.Controls.Add(this.flowLayoutPanelListings);

            this.ResumeLayout(false);
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

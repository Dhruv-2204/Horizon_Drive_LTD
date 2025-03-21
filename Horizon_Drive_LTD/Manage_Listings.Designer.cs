using System;
using System.Drawing;
using System.Windows.Forms;

namespace Horizon_Drive_LTD
{
    partial class Manage_Listings
    {
        private System.ComponentModel.IContainer components = null;

        // Sidebar components
        private Panel sidebar;
        private RoundedButton btnOptions;
        private RoundedButton btnManageBooking;
        private RoundedButton btnListCar;
        private RoundedButton btnBrowseListings;
        private RoundedButton btnManageYourListings;

        // Main panel components
        private Panel panelMain;
        private Panel panelContent;
        private Panel contentPanel;
        private FlowLayoutPanel flowLayoutPanelListings;
        private Panel panelHeader;
        private Label lblTitle; // Title label
        private Panel panelYourListings;
        private Panel panelCurrentReservations;
        private Panel panelTotalEarnings;

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
            sidebar = new Panel();
            btnBrowseListings = new RoundedButton();
            btnListCar = new RoundedButton();
            btnManageBooking = new RoundedButton();
            btnOptions = new RoundedButton();
            btnManageYourListings = new RoundedButton();
            panelMain = new Panel();
            panelContent = new Panel();
            contentPanel = new Panel();
            flowLayoutPanelListings = new FlowLayoutPanel();
            panelHeader = new Panel();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            pictureBox3 = new PictureBox();
            lblTitle = new Label(); // Title Label
            panelYourListings = new Panel(); // Dynamic Box 1
            panelCurrentReservations = new Panel(); // Dynamic Box 2
            panelTotalEarnings = new Panel(); // Dynamic Box 3
            sidebar.SuspendLayout();
            panelMain.SuspendLayout();
            panelContent.SuspendLayout();
            contentPanel.SuspendLayout();
            panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
            // 
            // sidebar
            // 
            sidebar.BackColor = Color.FromArgb(15, 30, 45);
            sidebar.Controls.Add(pictureBox1);
            sidebar.Controls.Add(btnBrowseListings);
            sidebar.Controls.Add(btnListCar);
            sidebar.Controls.Add(btnManageBooking);
            sidebar.Controls.Add(btnOptions);
            sidebar.Controls.Add(btnManageYourListings);
            sidebar.Dock = DockStyle.Left;
            sidebar.Location = new Point(0, 0);
            sidebar.Name = "sidebar";
            sidebar.Size = new Size(250, 662);
            sidebar.TabIndex = 1;
            // 
            // Title Label
            // 
            lblTitle.Text = "Manage Listings";
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.Location = new Point(30, 20);
            lblTitle.Size = new Size(300, 40);
            lblTitle.ForeColor = Color.Black;
            contentPanel.Controls.Add(lblTitle);

            // 
            // panelYourListings
            // 
            panelYourListings.BackColor = Color.LightBlue;
            panelYourListings.Location = new Point(30, 80);
            panelYourListings.Size = new Size(300, 150);
            contentPanel.Controls.Add(CreateDynamicBox("Your Listings", "2", panelYourListings));

            // 
            // panelCurrentReservations
            // 
            panelCurrentReservations.BackColor = Color.LightGreen;
            panelCurrentReservations.Location = new Point(360, 80);
            panelCurrentReservations.Size = new Size(300, 150);
            contentPanel.Controls.Add(CreateDynamicBox("Current Reservations", "1", panelCurrentReservations));

            // 
            // panelTotalEarnings
            // 
            panelTotalEarnings.BackColor = Color.LightPink;
            panelTotalEarnings.Location = new Point(690, 80);
            panelTotalEarnings.Size = new Size(300, 150);
            contentPanel.Controls.Add(CreateDynamicBox("Total Earnings", "MUR 150000", panelTotalEarnings));

            // 
            // panelMain
            // 
            panelMain.BackColor = Color.White;
            panelMain.Controls.Add(panelContent);
            panelMain.Controls.Add(panelHeader);
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(250, 0);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(1197, 662);
            panelMain.TabIndex = 0;
            // 
            // panelContent
            // 
            panelContent.BackColor = Color.WhiteSmoke;
            panelContent.Controls.Add(contentPanel);
            panelContent.Dock = DockStyle.Fill;
            panelContent.Location = new Point(0, 100);
            panelContent.Name = "panelContent";
            panelContent.Size = new Size(1197, 562);
            panelContent.TabIndex = 0;
            // 
            // contentPanel
            // 
            contentPanel.BackColor = Color.White;
            contentPanel.BorderStyle = BorderStyle.FixedSingle;
            contentPanel.Location = new Point(42, 24);
            contentPanel.Name = "contentPanel";
            contentPanel.Size = new Size(1767, 748);
            contentPanel.TabIndex = 0;
            // 
            // CreateDynamicBox Method
            // 
            Panel CreateDynamicBox(string title, string value, Panel panel)
            {
                Label titleLabel = new Label
                {
                    Text = title,
                    Font = new Font("Segoe UI", 12F, FontStyle.Regular),
                    Location = new Point(20, 20),
                    Size = new Size(260, 30),
                    ForeColor = Color.Black
                };

                Label valueLabel = new Label
                {
                    Text = value,
                    Font = new Font("Segoe UI", 24F, FontStyle.Bold),
                    Location = new Point(20, 60),
                    Size = new Size(260, 50),
                    ForeColor = Color.Black
                };

                panel.Controls.Add(titleLabel);
                panel.Controls.Add(valueLabel);
                return panel;
            }

            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(30, 85, 110);
            panelHeader.Controls.Add(pictureBox3);
            panelHeader.Controls.Add(pictureBox2);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1197, 100);
            panelHeader.TabIndex = 1;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Logo__1_;
            pictureBox1.Location = new Point(25, 27);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(213, 130);
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.shop_removebg_preview;
            pictureBox2.Location = new Point(908, 27);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(125, 62);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 4;
            pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Properties.Resources.icon_removebg_preview;
            pictureBox3.Location = new Point(1060, 27);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(125, 62);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 5;
            pictureBox3.TabStop = false;
            // 
            // Manage_Listings
            // 
            ClientSize = new Size(1447, 662);
            Controls.Add(panelMain);
            Controls.Add(sidebar);
            Name = "Manage_Listings";
            sidebar.ResumeLayout(false);
            panelMain.ResumeLayout(false);
            panelContent.ResumeLayout(false);
            contentPanel.ResumeLayout(false);
            panelHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ResumeLayout(false);
        }

        private PictureBox pictureBox1;
        private PictureBox pictureBox3;
        private PictureBox pictureBox2;
    }
}

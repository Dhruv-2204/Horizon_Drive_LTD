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
            // btnBrowseListings
            // 
            btnBrowseListings.BackColor = Color.FromArgb(30, 85, 110);
            btnBrowseListings.FlatStyle = FlatStyle.Flat;
            btnBrowseListings.Font = new Font("Segoe UI", 12F);
            btnBrowseListings.ForeColor = Color.White;
            btnBrowseListings.Location = new Point(25, 191);
            btnBrowseListings.Name = "btnBrowseListings";
            btnBrowseListings.Size = new Size(200, 50);
            btnBrowseListings.TabIndex = 0;
            btnBrowseListings.Text = "Browse Listings";
            btnBrowseListings.UseVisualStyleBackColor = false;
            // 
            // btnListCar
            // 
            btnListCar.BackColor = Color.FromArgb(30, 85, 110);
            btnListCar.FlatStyle = FlatStyle.Flat;
            btnListCar.Font = new Font("Segoe UI", 12F);
            btnListCar.ForeColor = Color.White;
            btnListCar.Location = new Point(25, 265);
            btnListCar.Name = "btnListCar";
            btnListCar.Size = new Size(200, 50);
            btnListCar.TabIndex = 1;
            btnListCar.Text = "List a Car";
            btnListCar.UseVisualStyleBackColor = false;
            // 
            // btnManageBooking
            // 
            btnManageBooking.BackColor = Color.FromArgb(30, 85, 110);
            btnManageBooking.FlatStyle = FlatStyle.Flat;
            btnManageBooking.Font = new Font("Segoe UI", 12F);
            btnManageBooking.ForeColor = Color.White;
            btnManageBooking.Location = new Point(25, 353);
            btnManageBooking.Name = "btnManageBooking";
            btnManageBooking.Size = new Size(200, 50);
            btnManageBooking.TabIndex = 2;
            btnManageBooking.Text = "Manage Booking";
            btnManageBooking.UseVisualStyleBackColor = false;
            // 
            // btnOptions
            // 
            btnOptions.BackColor = Color.FromArgb(30, 85, 110);
            btnOptions.FlatStyle = FlatStyle.Flat;
            btnOptions.Font = new Font("Segoe UI", 12F);
            btnOptions.ForeColor = Color.White;
            btnOptions.Location = new Point(25, 514);
            btnOptions.Name = "btnOptions";
            btnOptions.Size = new Size(200, 50);
            btnOptions.TabIndex = 3;
            btnOptions.Text = "Options";
            btnOptions.UseVisualStyleBackColor = false;
            // 
            // btnManageYourListings
            // 
            btnManageYourListings.BackColor = Color.FromArgb(30, 85, 110);
            btnManageYourListings.FlatStyle = FlatStyle.Flat;
            btnManageYourListings.Font = new Font("Segoe UI", 10F);
            btnManageYourListings.ForeColor = Color.White;
            btnManageYourListings.Location = new Point(25, 439);
            btnManageYourListings.Name = "btnManageYourListings";
            btnManageYourListings.Size = new Size(200, 50);
            btnManageYourListings.TabIndex = 4;
            btnManageYourListings.Text = "Manage Your Listings";
            btnManageYourListings.UseVisualStyleBackColor = false;
            btnManageYourListings.Click += btnManageYourListings_Click_1;
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
            contentPanel.Controls.Add(flowLayoutPanelListings);
            contentPanel.Location = new Point(42, 24);
            contentPanel.Name = "contentPanel";
            contentPanel.Size = new Size(1767, 748);
            contentPanel.TabIndex = 0;
            // 
            // flowLayoutPanelListings
            // 
            flowLayoutPanelListings.AutoScroll = true;
            flowLayoutPanelListings.Dock = DockStyle.Fill;
            flowLayoutPanelListings.Location = new Point(0, 0);
            flowLayoutPanelListings.Name = "flowLayoutPanelListings";
            flowLayoutPanelListings.Size = new Size(1765, 746);
            flowLayoutPanelListings.TabIndex = 0;
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

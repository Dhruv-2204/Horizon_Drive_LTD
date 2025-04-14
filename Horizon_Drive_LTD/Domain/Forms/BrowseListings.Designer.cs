namespace Horizon_Drive_LTD

//BrowseListings.Designer.cs
{
    partial class BrowseListings
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
            panelSidebar = new Panel();
            btnManageBooking = new RoundedButton();
            btnManageYourListings = new RoundedButton();
            btnOptions = new RoundedButton();
            btnListCar = new RoundedButton();
            btnBrowseListings = new RoundedButton();
            pictureBoxLogo = new PictureBox();
            btnLogout = new RoundedButton();
            panelMain = new Panel();
            panelContent = new Panel();
            flowLayoutPanelListings = new FlowLayoutPanel();
            panelHeader = new Panel();
            panelSearch = new Panel();
            buttonSearch = new Button();
            textBoxSearch = new TextBox();
            labelBrowseListings = new Label();
            buttonProfile = new Button();
            panelSidebar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).BeginInit();
            panelMain.SuspendLayout();
            panelContent.SuspendLayout();
            panelHeader.SuspendLayout();
            panelSearch.SuspendLayout();
            SuspendLayout();
            // 
            // panelSidebar
            // 
            panelSidebar.BackColor = Color.FromArgb(15, 30, 45);
            panelSidebar.Controls.Add(btnManageBooking);
            panelSidebar.Controls.Add(btnManageYourListings);
            panelSidebar.Controls.Add(btnOptions);
            panelSidebar.Controls.Add(btnListCar);
            panelSidebar.Controls.Add(btnBrowseListings);
            panelSidebar.Controls.Add(pictureBoxLogo);
            panelSidebar.Controls.Add(btnLogout);
            panelSidebar.Dock = DockStyle.Left;
            panelSidebar.Location = new Point(0, 0);
            panelSidebar.Margin = new Padding(6, 5, 6, 5);
            panelSidebar.Name = "panelSidebar";
            panelSidebar.Size = new Size(416, 1200);
            panelSidebar.TabIndex = 0;
            // 
            // btnManageBooking
            // 
            btnManageBooking.BackColor = Color.FromArgb(30, 85, 110);
            btnManageBooking.FlatAppearance.BorderSize = 0;
            btnManageBooking.FlatStyle = FlatStyle.Flat;
            btnManageBooking.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnManageBooking.ForeColor = Color.White;
            btnManageBooking.Location = new Point(90, 527);
            btnManageBooking.Margin = new Padding(6, 5, 6, 5);
            btnManageBooking.Name = "btnManageBooking";
            btnManageBooking.Size = new Size(244, 82);
            btnManageBooking.TabIndex = 8;
            btnManageBooking.Text = "Manage Booking";
            btnManageBooking.UseVisualStyleBackColor = false;
            btnManageBooking.Click += btnManageBooking_Click;
            // 
            // btnManageYourListings
            // 
            btnManageYourListings.BackColor = Color.FromArgb(30, 85, 110);
            btnManageYourListings.FlatAppearance.BorderSize = 0;
            btnManageYourListings.FlatStyle = FlatStyle.Flat;
            btnManageYourListings.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnManageYourListings.ForeColor = Color.White;
            btnManageYourListings.Location = new Point(90, 747);
            btnManageYourListings.Margin = new Padding(6, 5, 6, 5);
            btnManageYourListings.Name = "btnManageYourListings";
            btnManageYourListings.Size = new Size(244, 82);
            btnManageYourListings.TabIndex = 7;
            btnManageYourListings.Text = "Manage your Listings";
            btnManageYourListings.UseVisualStyleBackColor = false;
            btnManageYourListings.Click += btnManageYourListings_Click;
            // 
            // btnOptions
            // 
            btnOptions.BackColor = Color.FromArgb(30, 85, 110);
            btnOptions.FlatAppearance.BorderSize = 0;
            btnOptions.FlatStyle = FlatStyle.Flat;
            btnOptions.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnOptions.ForeColor = Color.White;
            btnOptions.Location = new Point(90, 858);
            btnOptions.Margin = new Padding(6, 5, 6, 5);
            btnOptions.Name = "btnOptions";
            btnOptions.Size = new Size(244, 82);
            btnOptions.TabIndex = 4;
            btnOptions.Text = "Options";
            btnOptions.UseVisualStyleBackColor = false;
            btnOptions.Click += btnOptions_Click;
            // 
            // btnListCar
            // 
            btnListCar.BackColor = Color.FromArgb(30, 85, 110);
            btnListCar.FlatAppearance.BorderSize = 0;
            btnListCar.FlatStyle = FlatStyle.Flat;
            btnListCar.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnListCar.ForeColor = Color.White;
            btnListCar.Location = new Point(90, 637);
            btnListCar.Margin = new Padding(6, 5, 6, 5);
            btnListCar.Name = "btnListCar";
            btnListCar.Size = new Size(244, 82);
            btnListCar.TabIndex = 2;
            btnListCar.Text = "List a car";
            btnListCar.UseVisualStyleBackColor = false;
            btnListCar.Click += btnListCar_Click;
            // 
            // btnBrowseListings
            // 
            btnBrowseListings.BackColor = Color.FromArgb(173, 216, 230);
            btnBrowseListings.FlatAppearance.BorderSize = 0;
            btnBrowseListings.FlatStyle = FlatStyle.Flat;
            btnBrowseListings.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnBrowseListings.ForeColor = Color.Black;
            btnBrowseListings.Location = new Point(90, 415);
            btnBrowseListings.Margin = new Padding(6, 5, 6, 5);
            btnBrowseListings.Name = "btnBrowseListings";
            btnBrowseListings.Size = new Size(244, 82);
            btnBrowseListings.TabIndex = 1;
            btnBrowseListings.Text = "Browse listings";
            btnBrowseListings.UseVisualStyleBackColor = false;
            // 
            // pictureBoxLogo
            // 
            pictureBoxLogo.Image = Properties.Resources.Logo;
            pictureBoxLogo.Location = new Point(77, 78);
            pictureBoxLogo.Margin = new Padding(6, 5, 6, 5);
            pictureBoxLogo.Name = "pictureBoxLogo";
            pictureBoxLogo.Size = new Size(269, 307);
            pictureBoxLogo.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxLogo.TabIndex = 0;
            pictureBoxLogo.TabStop = false;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.FromArgb(30, 85, 110);
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnLogout.ForeColor = Color.White;
            btnLogout.Location = new Point(90, 968);
            btnLogout.Margin = new Padding(6, 5, 6, 5);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(244, 82);
            btnLogout.TabIndex = 6;
            btnLogout.Text = "Log out";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click;
            // 
            // panelMain
            // 
            panelMain.BackColor = Color.White;
            panelMain.Controls.Add(panelContent);
            panelMain.Controls.Add(panelHeader);
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(416, 0);
            panelMain.Margin = new Padding(6, 5, 6, 5);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(1413, 1200);
            panelMain.TabIndex = 1;
            // 
            // panelContent
            // 
            panelContent.Controls.Add(flowLayoutPanelListings);
            panelContent.Dock = DockStyle.Fill;
            panelContent.Location = new Point(0, 192);
            panelContent.Margin = new Padding(6, 5, 6, 5);
            panelContent.Name = "panelContent";
            panelContent.Padding = new Padding(34, 38, 34, 38);
            panelContent.Size = new Size(1413, 1008);
            panelContent.TabIndex = 1;
            // 
            // flowLayoutPanelListings
            // 
            flowLayoutPanelListings.AutoScroll = true;
            flowLayoutPanelListings.Dock = DockStyle.Fill;
            flowLayoutPanelListings.ForeColor = Color.FromArgb(15, 30, 45);
            flowLayoutPanelListings.Location = new Point(34, 38);
            flowLayoutPanelListings.Margin = new Padding(6, 5, 6, 5);
            flowLayoutPanelListings.Name = "flowLayoutPanelListings";
            flowLayoutPanelListings.Size = new Size(1345, 932);
            flowLayoutPanelListings.TabIndex = 0;
            // 
            // panelHeader
            // 
            panelHeader.Controls.Add(panelSearch);
            panelHeader.Controls.Add(labelBrowseListings);
            panelHeader.Controls.Add(buttonProfile);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Margin = new Padding(6, 5, 6, 5);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1413, 192);
            panelHeader.TabIndex = 0;
            // 
            // panelSearch
            // 
            panelSearch.AutoSize = true;
            panelSearch.BackColor = Color.White;
            panelSearch.BorderStyle = BorderStyle.FixedSingle;
            panelSearch.Controls.Add(buttonSearch);
            panelSearch.Controls.Add(textBoxSearch);
            panelSearch.Location = new Point(779, 77);
            panelSearch.Margin = new Padding(6, 5, 6, 5);
            panelSearch.Name = "panelSearch";
            panelSearch.Size = new Size(338, 71);
            panelSearch.TabIndex = 1;
            // 
            // buttonSearch
            // 
            buttonSearch.BackColor = Color.White;
            buttonSearch.FlatAppearance.BorderSize = 0;
            buttonSearch.FlatStyle = FlatStyle.Flat;
            buttonSearch.Font = new Font("Segoe MDL2 Assets", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonSearch.Location = new Point(280, 0);
            buttonSearch.Margin = new Padding(6, 5, 6, 5);
            buttonSearch.Name = "buttonSearch";
            buttonSearch.Size = new Size(50, 53);
            buttonSearch.TabIndex = 1;
            buttonSearch.Text = "🔍";
            buttonSearch.UseVisualStyleBackColor = false;
            // 
            // textBoxSearch
            // 
            textBoxSearch.Location = new Point(4, 17);
            textBoxSearch.Margin = new Padding(4, 5, 4, 5);
            textBoxSearch.Name = "textBoxSearch";
            textBoxSearch.Size = new Size(290, 31);
            textBoxSearch.TabIndex = 2;
            textBoxSearch.TextChanged += textBoxSearch_TextChanged;
            // 
            // labelBrowseListings
            // 
            labelBrowseListings.AutoSize = true;
            labelBrowseListings.Font = new Font("Bahnschrift SemiCondensed", 28.1454544F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelBrowseListings.ForeColor = Color.FromArgb(15, 30, 45);
            labelBrowseListings.Location = new Point(34, 62);
            labelBrowseListings.Margin = new Padding(6, 0, 6, 0);
            labelBrowseListings.Name = "labelBrowseListings";
            labelBrowseListings.Size = new Size(379, 69);
            labelBrowseListings.TabIndex = 0;
            labelBrowseListings.Text = "Browse Listings";
            // 
            // buttonProfile
            // 
            buttonProfile.AutoSize = true;
            buttonProfile.BackColor = Color.White;
            buttonProfile.FlatAppearance.BorderColor = Color.FromArgb(192, 192, 192);
            buttonProfile.FlatStyle = FlatStyle.Flat;
            buttonProfile.Font = new Font("Segoe UI Symbol", 12F);
            buttonProfile.Location = new Point(1140, 77);
            buttonProfile.Margin = new Padding(6, 5, 6, 5);
            buttonProfile.Name = "buttonProfile";
            buttonProfile.Size = new Size(71, 73);
            buttonProfile.TabIndex = 4;
            buttonProfile.Text = "👤";
            buttonProfile.UseVisualStyleBackColor = false;
            buttonProfile.Click += buttonProfile_Click;
            // 
            // BrowseListings
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1829, 1200);
            Controls.Add(panelMain);
            Controls.Add(panelSidebar);
            Margin = new Padding(6, 5, 6, 5);
            Name = "BrowseListings";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Horizon Drive - Car Rental";
            panelSidebar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).EndInit();
            panelMain.ResumeLayout(false);
            panelContent.ResumeLayout(false);
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelSearch.ResumeLayout(false);
            panelSearch.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelSidebar;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private RoundedButton btnOptions;
        private RoundedButton btnListCar;
        private RoundedButton btnBrowseListings;
        private RoundedButton btnLogout;
        private Button buttonProfile;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label labelBrowseListings;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelListings;
        private System.Windows.Forms.Panel panelSearch;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Button buttonSearch;
        private RoundedButton btnManageYourListings;
        private RoundedButton btnManageBooking;
    }

}
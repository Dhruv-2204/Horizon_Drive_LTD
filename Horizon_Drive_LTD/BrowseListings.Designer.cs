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
            buttonFilter = new Button();
            buttonCart = new Button();
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
            panelSidebar.Margin = new Padding(4, 3, 4, 3);
            panelSidebar.Name = "panelSidebar";
            panelSidebar.Size = new Size(291, 387);
            panelSidebar.TabIndex = 0;
            // 
            // btnManageBooking
            // 
            btnManageBooking.BackColor = Color.FromArgb(30, 85, 110);
            btnManageBooking.FlatAppearance.BorderSize = 0;
            btnManageBooking.FlatStyle = FlatStyle.Flat;
            btnManageBooking.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnManageBooking.ForeColor = Color.White;
            btnManageBooking.Location = new Point(63, 316);
            btnManageBooking.Margin = new Padding(4, 3, 4, 3);
            btnManageBooking.Name = "btnManageBooking";
            btnManageBooking.Size = new Size(171, 49);
            btnManageBooking.TabIndex = 8;
            btnManageBooking.Text = "Manage Booking";
            btnManageBooking.UseVisualStyleBackColor = false;
            // 
            // btnManageYourListings
            // 
            btnManageYourListings.BackColor = Color.FromArgb(30, 85, 110);
            btnManageYourListings.FlatAppearance.BorderSize = 0;
            btnManageYourListings.FlatStyle = FlatStyle.Flat;
            btnManageYourListings.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnManageYourListings.ForeColor = Color.White;
            btnManageYourListings.Location = new Point(63, 448);
            btnManageYourListings.Margin = new Padding(4, 3, 4, 3);
            btnManageYourListings.Name = "btnManageYourListings";
            btnManageYourListings.Size = new Size(171, 49);
            btnManageYourListings.TabIndex = 7;
            btnManageYourListings.Text = "Manage your Listings";
            btnManageYourListings.UseVisualStyleBackColor = false;
            // 
            // btnOptions
            // 
            btnOptions.BackColor = Color.FromArgb(30, 85, 110);
            btnOptions.FlatAppearance.BorderSize = 0;
            btnOptions.FlatStyle = FlatStyle.Flat;
            btnOptions.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnOptions.ForeColor = Color.White;
            btnOptions.Location = new Point(63, 515);
            btnOptions.Margin = new Padding(4, 3, 4, 3);
            btnOptions.Name = "btnOptions";
            btnOptions.Size = new Size(171, 49);
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
            btnListCar.Location = new Point(63, 382);
            btnListCar.Margin = new Padding(4, 3, 4, 3);
            btnListCar.Name = "btnListCar";
            btnListCar.Size = new Size(171, 49);
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
            btnBrowseListings.Location = new Point(63, 249);
            btnBrowseListings.Margin = new Padding(4, 3, 4, 3);
            btnBrowseListings.Name = "btnBrowseListings";
            btnBrowseListings.Size = new Size(171, 49);
            btnBrowseListings.TabIndex = 1;
            btnBrowseListings.Text = "Browse listings";
            btnBrowseListings.UseVisualStyleBackColor = false;
            btnBrowseListings.Click += btnBrowseListings_Click;
            // 
            // pictureBoxLogo
            // 
            pictureBoxLogo.Image = Properties.Resources.Logo;
            pictureBoxLogo.Location = new Point(54, 47);
            pictureBoxLogo.Margin = new Padding(4, 3, 4, 3);
            pictureBoxLogo.Name = "pictureBoxLogo";
            pictureBoxLogo.Size = new Size(188, 184);
            pictureBoxLogo.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxLogo.TabIndex = 0;
            pictureBoxLogo.TabStop = false;
            pictureBoxLogo.Click += pictureBoxLogo_Click;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.FromArgb(30, 85, 110);
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnLogout.ForeColor = Color.White;
            btnLogout.Location = new Point(63, 581);
            btnLogout.Margin = new Padding(4, 3, 4, 3);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(171, 49);
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
            panelMain.Location = new Point(291, 0);
            panelMain.Margin = new Padding(4, 3, 4, 3);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(782, 387);
            panelMain.TabIndex = 1;
            // 
            // panelContent
            // 
            panelContent.Controls.Add(flowLayoutPanelListings);
            panelContent.Dock = DockStyle.Fill;
            panelContent.Location = new Point(0, 115);
            panelContent.Margin = new Padding(4, 3, 4, 3);
            panelContent.Name = "panelContent";
            panelContent.Padding = new Padding(24, 23, 24, 23);
            panelContent.Size = new Size(782, 272);
            panelContent.TabIndex = 1;
            // 
            // flowLayoutPanelListings
            // 
            flowLayoutPanelListings.AutoScroll = true;
            flowLayoutPanelListings.Dock = DockStyle.Fill;
            flowLayoutPanelListings.ForeColor = Color.FromArgb(15, 30, 45);
            flowLayoutPanelListings.Location = new Point(24, 23);
            flowLayoutPanelListings.Margin = new Padding(4, 3, 4, 3);
            flowLayoutPanelListings.Name = "flowLayoutPanelListings";
            flowLayoutPanelListings.Size = new Size(734, 226);
            flowLayoutPanelListings.TabIndex = 0;
            flowLayoutPanelListings.Paint += flowLayoutPanelListings_Paint;
            // 
            // panelHeader
            // 
            panelHeader.Controls.Add(panelSearch);
            panelHeader.Controls.Add(labelBrowseListings);
            panelHeader.Controls.Add(buttonFilter);
            panelHeader.Controls.Add(buttonCart);
            panelHeader.Controls.Add(buttonProfile);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Margin = new Padding(4, 3, 4, 3);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(782, 115);
            panelHeader.TabIndex = 0;
            // 
            // panelSearch
            // 
            panelSearch.AutoSize = true;
            panelSearch.BackColor = Color.White;
            panelSearch.BorderStyle = BorderStyle.FixedSingle;
            panelSearch.Controls.Add(buttonSearch);
            panelSearch.Controls.Add(textBoxSearch);
            panelSearch.Location = new Point(545, 46);
            panelSearch.Margin = new Padding(4, 3, 4, 3);
            panelSearch.Name = "panelSearch";
            panelSearch.Size = new Size(237, 38);
            panelSearch.TabIndex = 1;
            // 
            // buttonSearch
            // 
            buttonSearch.BackColor = Color.White;
            buttonSearch.FlatAppearance.BorderSize = 0;
            buttonSearch.FlatStyle = FlatStyle.Flat;
            buttonSearch.Font = new Font("Segoe MDL2 Assets", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonSearch.Location = new Point(196, 0);
            buttonSearch.Margin = new Padding(4, 3, 4, 3);
            buttonSearch.Name = "buttonSearch";
            buttonSearch.Size = new Size(35, 32);
            buttonSearch.TabIndex = 1;
            buttonSearch.Text = "🔍";
            buttonSearch.UseVisualStyleBackColor = false;
            // 
            // textBoxSearch
            // 
            textBoxSearch.BorderStyle = BorderStyle.None;
            textBoxSearch.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxSearch.Location = new Point(6, 6);
            textBoxSearch.Margin = new Padding(4, 3, 4, 3);
            textBoxSearch.Name = "textBoxSearch";
            textBoxSearch.Size = new Size(186, 18);
            textBoxSearch.TabIndex = 0;
            textBoxSearch.TextChanged += textBoxSearch_TextChanged;
            // 
            // labelBrowseListings
            // 
            labelBrowseListings.AutoSize = true;
            labelBrowseListings.Font = new Font("Bahnschrift SemiCondensed", 28.1454544F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelBrowseListings.ForeColor = Color.FromArgb(15, 30, 45);
            labelBrowseListings.Location = new Point(24, 37);
            labelBrowseListings.Margin = new Padding(4, 0, 4, 0);
            labelBrowseListings.Name = "labelBrowseListings";
            labelBrowseListings.Size = new Size(255, 46);
            labelBrowseListings.TabIndex = 0;
            labelBrowseListings.Text = "Browse Listings";
            labelBrowseListings.Click += labelBrowseListings_Click;
            // 
            // buttonFilter
            // 
            buttonFilter.AutoSize = true;
            buttonFilter.BackColor = Color.White;
            buttonFilter.FlatAppearance.BorderColor = Color.FromArgb(192, 192, 192);
            buttonFilter.FlatStyle = FlatStyle.Flat;
            buttonFilter.Font = new Font("Segoe UI Symbol", 12F);
            buttonFilter.Location = new Point(797, 45);
            buttonFilter.Margin = new Padding(4, 3, 4, 3);
            buttonFilter.Name = "buttonFilter";
            buttonFilter.Size = new Size(38, 35);
            buttonFilter.TabIndex = 2;
            buttonFilter.Text = "🔍";
            buttonFilter.UseVisualStyleBackColor = false;
            buttonFilter.Click += buttonFilter_Click;
            // 
            // buttonCart
            // 
            buttonCart.AutoSize = true;
            buttonCart.BackColor = Color.White;
            buttonCart.FlatAppearance.BorderColor = Color.FromArgb(192, 192, 192);
            buttonCart.FlatStyle = FlatStyle.Flat;
            buttonCart.Font = new Font("Segoe UI Symbol", 12F);
            buttonCart.Location = new Point(843, 45);
            buttonCart.Margin = new Padding(4, 3, 4, 3);
            buttonCart.Name = "buttonCart";
            buttonCart.Size = new Size(38, 35);
            buttonCart.TabIndex = 3;
            buttonCart.Text = "\U0001f6d2";
            buttonCart.UseVisualStyleBackColor = false;
            buttonCart.Click += buttonCart_Click;
            // 
            // buttonProfile
            // 
            buttonProfile.AutoSize = true;
            buttonProfile.BackColor = Color.White;
            buttonProfile.FlatAppearance.BorderColor = Color.FromArgb(192, 192, 192);
            buttonProfile.FlatStyle = FlatStyle.Flat;
            buttonProfile.Font = new Font("Segoe UI Symbol", 12F);
            buttonProfile.Location = new Point(886, 45);
            buttonProfile.Margin = new Padding(4, 3, 4, 3);
            buttonProfile.Name = "buttonProfile";
            buttonProfile.Size = new Size(38, 35);
            buttonProfile.TabIndex = 4;
            buttonProfile.Text = "👤";
            buttonProfile.UseVisualStyleBackColor = false;
            buttonProfile.Click += buttonProfile_Click;
            // 
            // BrowseListings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new Size(1280, 720);
            Controls.Add(panelMain);
            Controls.Add(panelSidebar);
            Margin = new Padding(4, 3, 4, 3);
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
        private Button buttonFilter;
        private Button buttonCart;
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
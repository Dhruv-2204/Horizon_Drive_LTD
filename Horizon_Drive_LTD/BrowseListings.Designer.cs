namespace Horizon_Drive_LTD
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
            btnOptions = new RoundedButton();
            btnManageBooking = new RoundedButton();
            btnListCar = new RoundedButton();
            btnBrowseListings = new RoundedButton();
            pictureBoxLogo = new PictureBox();
            panelMain = new Panel();
            panelContent = new Panel();
            flowLayoutPanelListings = new FlowLayoutPanel();
            panelHeader = new Panel();
            buttonFilters = new Button();
            panelSearch = new Panel();
            buttonSearch = new Button();
            textBoxSearch = new TextBox();
            labelBrowseListings = new Label();
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
            panelSidebar.Controls.Add(btnOptions);
            panelSidebar.Controls.Add(btnManageBooking);
            panelSidebar.Controls.Add(btnListCar);
            panelSidebar.Controls.Add(btnBrowseListings);
            panelSidebar.Controls.Add(pictureBoxLogo);
            panelSidebar.Dock = DockStyle.Left;
            panelSidebar.Location = new Point(0, 0);
            panelSidebar.Margin = new Padding(4);
            panelSidebar.Name = "panelSidebar";
            panelSidebar.Size = new Size(333, 1023);
            panelSidebar.TabIndex = 0;
            // 
            // btnOptions
            // 
            btnOptions.BackColor = Color.FromArgb(30, 85, 110);
            btnOptions.FlatAppearance.BorderSize = 0;
            btnOptions.FlatStyle = FlatStyle.Flat;
            btnOptions.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnOptions.ForeColor = Color.White;
            btnOptions.Location = new Point(53, 631);
            btnOptions.Margin = new Padding(4);
            btnOptions.Name = "btnOptions";
            btnOptions.Size = new Size(227, 73);
            btnOptions.TabIndex = 4;
            btnOptions.Text = "Options";
            btnOptions.UseVisualStyleBackColor = false;
            btnOptions.Click += btnOptions_Click;
            // 
            // btnManageBooking
            // 
            btnManageBooking.BackColor = Color.FromArgb(30, 85, 110);
            btnManageBooking.FlatAppearance.BorderSize = 0;
            btnManageBooking.FlatStyle = FlatStyle.Flat;
            btnManageBooking.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnManageBooking.ForeColor = Color.White;
            btnManageBooking.Location = new Point(53, 529);
            btnManageBooking.Margin = new Padding(4);
            btnManageBooking.Name = "btnManageBooking";
            btnManageBooking.Size = new Size(227, 73);
            btnManageBooking.TabIndex = 3;
            btnManageBooking.Text = "Manage Booking";
            btnManageBooking.UseVisualStyleBackColor = false;
            btnManageBooking.Click += btnManageBooking_Click;
            // 
            // btnListCar
            // 
            btnListCar.BackColor = Color.FromArgb(30, 85, 110);
            btnListCar.FlatAppearance.BorderSize = 0;
            btnListCar.FlatStyle = FlatStyle.Flat;
            btnListCar.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnListCar.ForeColor = Color.White;
            btnListCar.Location = new Point(53, 427);
            btnListCar.Margin = new Padding(4);
            btnListCar.Name = "btnListCar";
            btnListCar.Size = new Size(227, 73);
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
            btnBrowseListings.Location = new Point(53, 324);
            btnBrowseListings.Margin = new Padding(4);
            btnBrowseListings.Name = "btnBrowseListings";
            btnBrowseListings.Size = new Size(227, 73);
            btnBrowseListings.TabIndex = 1;
            btnBrowseListings.Text = "Browse listings";
            btnBrowseListings.UseVisualStyleBackColor = false;
            btnBrowseListings.Click += btnBrowseListings_Click;
            // 
            // pictureBoxLogo
            // 
            pictureBoxLogo.Image = Properties.Resources.Logo;
            pictureBoxLogo.Location = new Point(67, 73);
            pictureBoxLogo.Margin = new Padding(4);
            pictureBoxLogo.Name = "pictureBoxLogo";
            pictureBoxLogo.Size = new Size(200, 219);
            pictureBoxLogo.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxLogo.TabIndex = 0;
            pictureBoxLogo.TabStop = false;
            pictureBoxLogo.Click += pictureBoxLogo_Click;
            // 
            // panelMain
            // 
            panelMain.BackColor = Color.White;
            panelMain.Controls.Add(panelContent);
            panelMain.Controls.Add(panelHeader);
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(333, 0);
            panelMain.Margin = new Padding(4);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(1267, 1023);
            panelMain.TabIndex = 1;
            // 
            // panelContent
            // 
            panelContent.Controls.Add(flowLayoutPanelListings);
            panelContent.Dock = DockStyle.Fill;
            panelContent.Location = new Point(0, 146);
            panelContent.Margin = new Padding(4);
            panelContent.Name = "panelContent";
            panelContent.Padding = new Padding(27, 29, 27, 29);
            panelContent.Size = new Size(1267, 877);
            panelContent.TabIndex = 1;
            // 
            // flowLayoutPanelListings
            // 
            flowLayoutPanelListings.AutoScroll = true;
            flowLayoutPanelListings.Dock = DockStyle.Fill;
            flowLayoutPanelListings.Location = new Point(27, 29);
            flowLayoutPanelListings.Margin = new Padding(4);
            flowLayoutPanelListings.Name = "flowLayoutPanelListings";
            flowLayoutPanelListings.Size = new Size(1213, 819);
            flowLayoutPanelListings.TabIndex = 0;
            flowLayoutPanelListings.Paint += flowLayoutPanelListings_Paint;
            // 
            // panelHeader
            // 
            panelHeader.Controls.Add(buttonFilters);
            panelHeader.Controls.Add(panelSearch);
            panelHeader.Controls.Add(labelBrowseListings);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Margin = new Padding(4);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1267, 146);
            panelHeader.TabIndex = 0;
            // 
            // buttonFilters
            // 
            buttonFilters.BackColor = Color.White;
            buttonFilters.FlatAppearance.BorderColor = Color.FromArgb(192, 192, 192);
            buttonFilters.FlatStyle = FlatStyle.Flat;
            buttonFilters.Location = new Point(1101, 51);
            buttonFilters.Margin = new Padding(4);
            buttonFilters.Name = "buttonFilters";
            buttonFilters.Size = new Size(53, 44);
            buttonFilters.TabIndex = 2;
            buttonFilters.Text = "≡";
            buttonFilters.UseVisualStyleBackColor = false;
            buttonFilters.Click += buttonFilters_Click;
            // 
            // panelSearch
            // 
            panelSearch.BackColor = Color.White;
            panelSearch.BorderStyle = BorderStyle.FixedSingle;
            panelSearch.Controls.Add(buttonSearch);
            panelSearch.Controls.Add(textBoxSearch);
            panelSearch.Location = new Point(828, 51);
            panelSearch.Margin = new Padding(4);
            panelSearch.Name = "panelSearch";
            panelSearch.Size = new Size(266, 43);
            panelSearch.TabIndex = 1;
            // 
            // buttonSearch
            // 
            buttonSearch.BackColor = Color.White;
            buttonSearch.FlatAppearance.BorderSize = 0;
            buttonSearch.FlatStyle = FlatStyle.Flat;
            buttonSearch.Font = new Font("Segoe MDL2 Assets", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonSearch.Location = new Point(224, 0);
            buttonSearch.Margin = new Padding(4);
            buttonSearch.Name = "buttonSearch";
            buttonSearch.Size = new Size(40, 41);
            buttonSearch.TabIndex = 1;
            buttonSearch.Text = "🔍";
            buttonSearch.UseVisualStyleBackColor = false;
            // 
            // textBoxSearch
            // 
            textBoxSearch.BorderStyle = BorderStyle.None;
            textBoxSearch.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxSearch.Location = new Point(7, 7);
            textBoxSearch.Margin = new Padding(4);
            textBoxSearch.Name = "textBoxSearch";
            textBoxSearch.Size = new Size(213, 20);
            textBoxSearch.TabIndex = 0;
            textBoxSearch.TextChanged += textBoxSearch_TextChanged;
            // 
            // labelBrowseListings
            // 
            labelBrowseListings.AutoSize = true;
            labelBrowseListings.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelBrowseListings.Location = new Point(47, 51);
            labelBrowseListings.Margin = new Padding(4, 0, 4, 0);
            labelBrowseListings.Name = "labelBrowseListings";
            labelBrowseListings.Size = new Size(212, 38);
            labelBrowseListings.TabIndex = 0;
            labelBrowseListings.Text = "Browse Listings";
            // 
            // BrowseListings
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1600, 1023);
            Controls.Add(panelMain);
            Controls.Add(panelSidebar);
            Margin = new Padding(4);
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
        private RoundedButton btnManageBooking;
        private RoundedButton btnListCar;
        private RoundedButton btnBrowseListings;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label labelBrowseListings;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelListings;
        private System.Windows.Forms.Panel panelSearch;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.Button buttonFilters;
    }
}
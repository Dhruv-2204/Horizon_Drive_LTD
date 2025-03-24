namespace Horizon_Drive_LTD
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            splitContainer1 = new SplitContainer();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            RetriveButton = new Button();
            buuton1 = new Button();
            dataGridView1 = new DataGridView();
            Price = new TextBox();
            Make = new TextBox();
            Model = new TextBox();
            Year = new TextBox();
            CarRegistor = new TextBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.AccessibleName = "";
            splitContainer1.Panel1.BackColor = Color.DarkCyan;
            splitContainer1.Panel1.Controls.Add(button3);
            splitContainer1.Panel1.Controls.Add(button2);
            splitContainer1.Panel1.Controls.Add(button1);
            splitContainer1.Panel1.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            splitContainer1.Panel1.ForeColor = Color.Coral;
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.BackColor = SystemColors.ActiveCaptionText;
            splitContainer1.Panel2.BackgroundImage = (Image)resources.GetObject("splitContainer1.Panel2.BackgroundImage");
            splitContainer1.Panel2.BackgroundImageLayout = ImageLayout.Zoom;
            splitContainer1.Panel2.Controls.Add(RetriveButton);
            splitContainer1.Panel2.Controls.Add(buuton1);
            splitContainer1.Panel2.Controls.Add(dataGridView1);
            splitContainer1.Panel2.Controls.Add(Price);
            splitContainer1.Panel2.Controls.Add(Make);
            splitContainer1.Panel2.Controls.Add(Model);
            splitContainer1.Panel2.Controls.Add(Year);
            splitContainer1.Panel2.Controls.Add(CarRegistor);
            splitContainer1.Panel2.Controls.Add(label5);
            splitContainer1.Panel2.Controls.Add(label4);
            splitContainer1.Panel2.Controls.Add(label3);
            splitContainer1.Panel2.Controls.Add(label2);
            splitContainer1.Panel2.Controls.Add(label1);
            splitContainer1.Size = new Size(1218, 606);
            splitContainer1.SplitterDistance = 290;
            splitContainer1.TabIndex = 0;
            // 
            // button3
            // 
            button3.BackColor = Color.PaleTurquoise;
            button3.Location = new Point(51, 192);
            button3.Name = "button3";
            button3.Size = new Size(186, 87);
            button3.TabIndex = 2;
            button3.Text = "Profile";
            button3.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            button2.BackColor = Color.LightPink;
            button2.Location = new Point(51, 60);
            button2.Name = "button2";
            button2.Size = new Size(186, 87);
            button2.TabIndex = 1;
            button2.Text = "Search ";
            button2.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            button1.BackColor = Color.PaleTurquoise;
            button1.Location = new Point(51, 330);
            button1.Name = "button1";
            button1.Size = new Size(186, 87);
            button1.TabIndex = 0;
            button1.Text = "Home";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // RetriveButton
            // 
            RetriveButton.Font = new Font("Verdana", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            RetriveButton.Location = new Point(552, 461);
            RetriveButton.Name = "RetriveButton";
            RetriveButton.Size = new Size(229, 92);
            RetriveButton.TabIndex = 12;
            RetriveButton.Text = "RETRIEVE";
            RetriveButton.UseVisualStyleBackColor = true;
            RetriveButton.Click += RetriveButton_Click;
            // 
            // buuton1
            // 
            buuton1.Font = new Font("Verdana", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buuton1.Location = new Point(164, 461);
            buuton1.Name = "buuton1";
            buuton1.Size = new Size(165, 92);
            buuton1.TabIndex = 11;
            buuton1.Text = "ADD";
            buuton1.UseVisualStyleBackColor = true;
            buuton1.Click += buuton1_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(53, 162);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(809, 267);
            dataGridView1.TabIndex = 10;
            // 
            // Price
            // 
            Price.Location = new Point(727, 111);
            Price.Name = "Price";
            Price.PlaceholderText = "Rs.";
            Price.Size = new Size(175, 27);
            Price.TabIndex = 9;
            // 
            // Make
            // 
            Make.Location = new Point(241, 111);
            Make.Name = "Make";
            Make.PlaceholderText = "Make";
            Make.Size = new Size(127, 27);
            Make.TabIndex = 8;
            // 
            // Model
            // 
            Model.Location = new Point(398, 111);
            Model.Name = "Model";
            Model.PlaceholderText = "Model";
            Model.Size = new Size(122, 27);
            Model.TabIndex = 7;
            // 
            // Year
            // 
            Year.Location = new Point(586, 111);
            Year.Name = "Year";
            Year.PlaceholderText = "Year";
            Year.Size = new Size(78, 27);
            Year.TabIndex = 6;
            // 
            // CarRegistor
            // 
            CarRegistor.Location = new Point(32, 111);
            CarRegistor.Name = "CarRegistor";
            CarRegistor.PlaceholderText = "Registration Number";
            CarRegistor.Size = new Size(175, 27);
            CarRegistor.TabIndex = 5;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = SystemColors.ActiveCaption;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(771, 51);
            label5.Name = "label5";
            label5.Size = new Size(91, 28);
            label5.TabIndex = 4;
            label5.Text = "Price (Rs)";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = SystemColors.ActiveCaption;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(269, 51);
            label4.Name = "label4";
            label4.Size = new Size(60, 28);
            label4.TabIndex = 3;
            label4.Text = "Make";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = SystemColors.ActiveCaption;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(442, 51);
            label3.Name = "label3";
            label3.Size = new Size(69, 28);
            label3.TabIndex = 2;
            label3.Text = "Model";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = SystemColors.ActiveCaption;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(598, 51);
            label2.Name = "label2";
            label2.Size = new Size(48, 28);
            label2.TabIndex = 1;
            label2.Text = "Year";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.ActiveCaption;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(32, 51);
            label1.Name = "label1";
            label1.Size = new Size(189, 28);
            label1.TabIndex = 0;
            label1.Text = "Car_Registration_No";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1218, 606);
            Controls.Add(splitContainer1);
            Cursor = Cursors.Cross;
            Name = "Form1";
            Text = "Horizon Drive LTD";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private Button button1;
        private Button button3;
        private Button button2;
        private Label label1;
        private TextBox CarRegistor;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private TextBox Make;
        private TextBox Model;
        private TextBox Year;
        private Button RetriveButton;
        private Button buuton1;
        private DataGridView dataGridView1;
        private TextBox Price;
    }
}

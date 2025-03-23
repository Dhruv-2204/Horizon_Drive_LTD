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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            textBox5 = new TextBox();
            dataGridView1 = new DataGridView();
            button4 = new Button();
            button5 = new Button();
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
            splitContainer1.Panel1.Paint += splitContainer1_Panel1_Paint;
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.BackColor = SystemColors.ActiveCaptionText;
            splitContainer1.Panel2.BackgroundImage = (Image)resources.GetObject("splitContainer1.Panel2.BackgroundImage");
            splitContainer1.Panel2.BackgroundImageLayout = ImageLayout.Zoom;
            splitContainer1.Panel2.Controls.Add(button5);
            splitContainer1.Panel2.Controls.Add(button4);
            splitContainer1.Panel2.Controls.Add(dataGridView1);
            splitContainer1.Panel2.Controls.Add(textBox5);
            splitContainer1.Panel2.Controls.Add(textBox4);
            splitContainer1.Panel2.Controls.Add(textBox3);
            splitContainer1.Panel2.Controls.Add(textBox2);
            splitContainer1.Panel2.Controls.Add(textBox1);
            splitContainer1.Panel2.Controls.Add(label5);
            splitContainer1.Panel2.Controls.Add(label4);
            splitContainer1.Panel2.Controls.Add(label3);
            splitContainer1.Panel2.Controls.Add(label2);
            splitContainer1.Panel2.Controls.Add(label1);
            splitContainer1.Panel2.Paint += splitContainer1_Panel2_Paint;
            splitContainer1.Size = new Size(1218, 606);
            splitContainer1.SplitterDistance = 290;
            splitContainer1.TabIndex = 0;
            splitContainer1.SplitterMoved += splitContainer1_SplitterMoved;
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
            label1.Click += label1_Click;
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
            // textBox1
            // 
            textBox1.Location = new Point(32, 111);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Registration Number";
            textBox1.Size = new Size(175, 27);
            textBox1.TabIndex = 5;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(586, 111);
            textBox2.Name = "textBox2";
            textBox2.PlaceholderText = "Year";
            textBox2.Size = new Size(78, 27);
            textBox2.TabIndex = 6;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(398, 111);
            textBox3.Name = "textBox3";
            textBox3.PlaceholderText = "Model";
            textBox3.Size = new Size(122, 27);
            textBox3.TabIndex = 7;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(241, 111);
            textBox4.Name = "textBox4";
            textBox4.PlaceholderText = "Make";
            textBox4.Size = new Size(127, 27);
            textBox4.TabIndex = 8;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(727, 111);
            textBox5.Name = "textBox5";
            textBox5.PlaceholderText = "Rs.";
            textBox5.Size = new Size(175, 27);
            textBox5.TabIndex = 9;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(131, 176);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(652, 188);
            dataGridView1.TabIndex = 10;
            // 
            // button4
            // 
            button4.Font = new Font("Verdana", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button4.Location = new Point(203, 435);
            button4.Name = "button4";
            button4.Size = new Size(165, 92);
            button4.TabIndex = 11;
            button4.Text = "ADD";
            button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.Font = new Font("Verdana", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button5.Location = new Point(571, 435);
            button5.Name = "button5";
            button5.Size = new Size(229, 92);
            button5.TabIndex = 12;
            button5.Text = "RETRIEVE";
            button5.UseVisualStyleBackColor = true;
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
            Load += Form1_Load;
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
        private TextBox textBox1;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private TextBox textBox4;
        private TextBox textBox3;
        private TextBox textBox2;
        private Button button5;
        private Button button4;
        private DataGridView dataGridView1;
        private TextBox textBox5;
    }
}

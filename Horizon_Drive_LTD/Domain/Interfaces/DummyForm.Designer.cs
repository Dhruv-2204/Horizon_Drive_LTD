namespace Horizon_Drive_LTD.Domain.Interfaces
{
    partial class DummyWindow
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
            label1 = new Label();
            Browse = new Button();
            label2 = new Label();
            textBox1 = new TextBox();
            Save = new Button();
            pictureBox1 = new PictureBox();
            label3 = new Label();
            pictureBox2 = new PictureBox();
            textBox2 = new TextBox();
            label4 = new Label();
            dataGridView1 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Elephant", 18F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            label1.Location = new Point(93, 74);
            label1.Margin = new Padding(8, 0, 8, 0);
            label1.Name = "label1";
            label1.Size = new Size(429, 38);
            label1.TabIndex = 0;
            label1.Text = "INSERT IMAGE HERE ";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Browse
            // 
            Browse.Font = new Font("Cooper Black", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Browse.Location = new Point(39, 175);
            Browse.Name = "Browse";
            Browse.Size = new Size(179, 78);
            Browse.TabIndex = 1;
            Browse.Text = "Browse";
            Browse.UseVisualStyleBackColor = true;
            Browse.Click += Browse_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Elephant", 8F);
            label2.Location = new Point(305, 407);
            label2.Margin = new Padding(8, 0, 8, 0);
            label2.Name = "label2";
            label2.Size = new Size(108, 18);
            label2.TabIndex = 2;
            label2.Text = "FILE PATH :";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Elephant", 6F);
            textBox1.Location = new Point(305, 428);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(386, 20);
            textBox1.TabIndex = 3;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // Save
            // 
            Save.Font = new Font("Cooper Black", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Save.Location = new Point(39, 349);
            Save.Name = "Save";
            Save.Size = new Size(94, 29);
            Save.TabIndex = 4;
            Save.Text = "SAVE";
            Save.UseVisualStyleBackColor = true;
            Save.Click += Save_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.InitialImage = Properties.Resources.Logo__1_;
            pictureBox1.Location = new Point(343, 175);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(298, 204);
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            pictureBox1.WaitOnLoad = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Elephant", 18F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            label3.Location = new Point(878, 74);
            label3.Margin = new Padding(8, 0, 8, 0);
            label3.Name = "label3";
            label3.Size = new Size(318, 38);
            label3.TabIndex = 6;
            label3.Text = "IMAGE DISPLAY";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBox2
            // 
            pictureBox2.Location = new Point(891, 384);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(337, 162);
            pictureBox2.TabIndex = 7;
            pictureBox2.TabStop = false;
            // 
            // textBox2
            // 
            textBox2.Font = new Font("Elephant", 6F);
            textBox2.Location = new Point(39, 314);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(234, 20);
            textBox2.TabIndex = 9;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Elephant", 8F);
            label4.Location = new Point(39, 293);
            label4.Margin = new Padding(8, 0, 8, 0);
            label4.Name = "label4";
            label4.Size = new Size(85, 18);
            label4.TabIndex = 8;
            label4.Text = "File Name:";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            label4.Click += label4_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Font = new Font("Tahoma", 8F);
            dataGridView1.Location = new Point(835, 147);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(393, 231);
            dataGridView1.TabIndex = 10;
            dataGridView1.CellBeginEdit += dataGridView1_CellBeginEdit;
            dataGridView1.CellDoubleClick += dataGridView1_CellDoubleClick;
            // 
            // DummyWindow
            // 
            AutoScaleDimensions = new SizeF(21F, 38F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1342, 637);
            Controls.Add(dataGridView1);
            Controls.Add(textBox2);
            Controls.Add(label4);
            Controls.Add(pictureBox2);
            Controls.Add(label3);
            Controls.Add(pictureBox1);
            Controls.Add(Save);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Controls.Add(Browse);
            Controls.Add(label1);
            Font = new Font("Elephant", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(8, 6, 8, 6);
            Name = "DummyWindow";
            Text = "TRIAAAAAL";
            Load += DummyWindow_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button Browse;
        private Label label2;
        private TextBox textBox1;
        private Button Save;
        private PictureBox pictureBox1;
        private Label label3;
        private PictureBox pictureBox2;
        private TextBox textBox2;
        private Label label4;
        private DataGridView dataGridView1;
    }
}
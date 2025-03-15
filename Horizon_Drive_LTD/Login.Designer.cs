namespace splashscreen
{
    partial class Login
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
            panel1 = new Panel();
            checkBox1 = new CheckBox();
            button1 = new Button();
            textBox2 = new TextBox();
            label2 = new Label();
            textBox1 = new TextBox();
            label4 = new Label();
            label3 = new Label();
            panel2 = new Panel();
            button2 = new Button();
            label5 = new Label();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.None;
            panel1.AutoSize = true;
            panel1.BackColor = Color.White;
            panel1.Controls.Add(checkBox1);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(textBox2);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(panel2);
            panel1.Font = new Font("Segoe UI Semilight", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            panel1.Location = new Point(-1, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(686, 483);
            panel1.TabIndex = 0;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.BackColor = Color.Transparent;
            checkBox1.Font = new Font("Segoe UI Light", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            checkBox1.ForeColor = SystemColors.GrayText;
            checkBox1.Location = new Point(535, 280);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(104, 19);
            checkBox1.TabIndex = 8;
            checkBox1.Text = "Show Password";
            checkBox1.UseVisualStyleBackColor = false;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(1, 24, 30);
            button1.Cursor = Cursors.Hand;
            button1.FlatAppearance.BorderColor = Color.Navy;
            button1.FlatAppearance.BorderSize = 9;
            button1.FlatAppearance.MouseOverBackColor = Color.FromArgb(128, 128, 255);
            button1.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.Location = new Point(414, 357);
            button1.Name = "button1";
            button1.Size = new Size(131, 37);
            button1.TabIndex = 7;
            button1.Text = "LOGIN";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // textBox2
            // 
            textBox2.AutoCompleteMode = AutoCompleteMode.Suggest;
            textBox2.BackColor = Color.Silver;
            textBox2.BorderStyle = BorderStyle.FixedSingle;
            textBox2.Font = new Font("Segoe UI Light", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox2.Location = new Point(312, 241);
            textBox2.Name = "textBox2";
            textBox2.PlaceholderText = "Enter Password";
            textBox2.Size = new Size(327, 33);
            textBox2.TabIndex = 6;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Bahnschrift", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(310, 211);
            label2.Name = "label2";
            label2.Size = new Size(78, 18);
            label2.TabIndex = 5;
            label2.Text = "Password:";
            label2.Click += label2_Click;
            // 
            // textBox1
            // 
            textBox1.AutoCompleteMode = AutoCompleteMode.Suggest;
            textBox1.BackColor = Color.Silver;
            textBox1.BorderStyle = BorderStyle.FixedSingle;
            textBox1.Font = new Font("Segoe UI Light", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(312, 146);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Enter Username";
            textBox1.Size = new Size(327, 33);
            textBox1.TabIndex = 4;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Bahnschrift", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(310, 115);
            label4.Name = "label4";
            label4.Size = new Size(80, 18);
            label4.TabIndex = 3;
            label4.Text = "Username:";
            label4.Click += label4_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft YaHei UI", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(1, 24, 100);
            label3.Location = new Point(442, 19);
            label3.Name = "label3";
            label3.Size = new Size(75, 27);
            label3.TabIndex = 2;
            label3.Text = "Log In";
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(1, 24, 30);
            panel2.Controls.Add(button2);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(pictureBox1);
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(288, 480);
            panel2.TabIndex = 0;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(128, 255, 255);
            button2.Cursor = Cursors.Hand;
            button2.FlatAppearance.BorderSize = 9;
            button2.FlatAppearance.MouseOverBackColor = Color.FromArgb(192, 192, 255);
            button2.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.ForeColor = SystemColors.ControlText;
            button2.Location = new Point(88, 401);
            button2.Name = "button2";
            button2.Size = new Size(107, 29);
            button2.TabIndex = 3;
            button2.Text = "SIGN UP";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = Color.FromArgb(255, 128, 0);
            label5.Location = new Point(79, 433);
            label5.Name = "label5";
            label5.Size = new Size(128, 15);
            label5.TabIndex = 2;
            label5.Text = "Don't have an account?";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Book Antiqua", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(255, 128, 0);
            label1.Location = new Point(55, 193);
            label1.Name = "label1";
            label1.Size = new Size(184, 23);
            label1.TabIndex = 1;
            label1.Text = "Horizon Drive LTD";
            label1.Click += label1_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Left;
            pictureBox1.Image = Horizon_Drive_LTD.Properties.Resources.HORIZONDRIVE_LOGO;
            pictureBox1.Location = new Point(51, 31);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(184, 159);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(684, 479);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4, 3, 4, 3);
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login Page";
            Load += Form2_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private PictureBox pictureBox1;
        private Label label1;
        private Label label3;
        private Label label2;
        private Label label4;
        private TextBox textBox1;
        private TextBox textBox2;
        private Button button1;
        private CheckBox checkBox1;
        private Label label5;
        private Button button2;
    }
}
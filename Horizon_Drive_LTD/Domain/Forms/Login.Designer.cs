using Horizon_Drive_LTD.Properties;

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
            label3 = new Label();
            checkBox1 = new CheckBox();
            LOGIN_btn = new Button();
            Password = new TextBox();
            label2 = new Label();
            Username = new TextBox();
            label4 = new Label();
            panel2 = new Panel();
            Signup_btn = new Button();
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
            panel1.AutoSize = true;
            panel1.BackColor = Color.White;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(label3);
            panel1.Controls.Add(checkBox1);
            panel1.Controls.Add(LOGIN_btn);
            panel1.Controls.Add(Password);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(Username);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Fill;
            panel1.Font = new Font("Segoe UI Semilight", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(750, 583);
            panel1.TabIndex = 0;
            // 
            // label3
            // 
            label3.Font = new Font("Microsoft YaHei UI", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(1, 24, 100);
            label3.Location = new Point(457, 18);
            label3.Name = "label3";
            label3.Size = new Size(170, 71);
            label3.TabIndex = 2;
            label3.Text = "Log In";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // checkBox1
            // 
            checkBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            checkBox1.AutoSize = true;
            checkBox1.BackColor = Color.Transparent;
            checkBox1.Font = new Font("Segoe UI Light", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            checkBox1.ForeColor = SystemColors.GrayText;
            checkBox1.Location = new Point(574, 373);
            checkBox1.Margin = new Padding(3, 4, 3, 4);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(125, 24);
            checkBox1.TabIndex = 8;
            checkBox1.Text = "Show Password";
            checkBox1.UseVisualStyleBackColor = false;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // LOGIN_btn
            // 
            LOGIN_btn.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            LOGIN_btn.BackColor = Color.FromArgb(1, 24, 30);
            LOGIN_btn.Cursor = Cursors.Hand;
            LOGIN_btn.FlatAppearance.BorderColor = Color.Navy;
            LOGIN_btn.FlatAppearance.BorderSize = 9;
            LOGIN_btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(128, 128, 255);
            LOGIN_btn.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LOGIN_btn.ForeColor = Color.White;
            LOGIN_btn.Location = new Point(475, 419);
            LOGIN_btn.Margin = new Padding(3, 4, 3, 4);
            LOGIN_btn.Name = "LOGIN_btn";
            LOGIN_btn.Size = new Size(119, 49);
            LOGIN_btn.TabIndex = 7;
            LOGIN_btn.Text = "LOGIN";
            LOGIN_btn.UseVisualStyleBackColor = false;
            LOGIN_btn.Click += LOGIN_btn_Click;
            // 
            // Password
            // 
            Password.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            Password.AutoCompleteMode = AutoCompleteMode.Suggest;
            Password.BackColor = Color.Silver;
            Password.BorderStyle = BorderStyle.FixedSingle;
            Password.Font = new Font("Segoe UI Light", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Password.Location = new Point(354, 309);
            Password.Margin = new Padding(3, 4, 3, 4);
            Password.Name = "Password";
            Password.PlaceholderText = "Enter Password";
            Password.Size = new Size(354, 39);
            Password.TabIndex = 6;
            Password.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Bahnschrift", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(354, 259);
            label2.Name = "label2";
            label2.Size = new Size(99, 23);
            label2.TabIndex = 5;
            label2.Text = "Password:";
            // 
            // Username
            // 
            Username.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            Username.BackColor = Color.Silver;
            Username.BorderStyle = BorderStyle.FixedSingle;
            Username.Font = new Font("Segoe UI Light", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Username.Location = new Point(354, 173);
            Username.Margin = new Padding(3, 4, 3, 4);
            Username.Name = "Username";
            Username.PlaceholderText = "Enter Username";
            Username.Size = new Size(354, 39);
            Username.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Bahnschrift", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(354, 124);
            label4.Name = "label4";
            label4.Size = new Size(101, 23);
            label4.TabIndex = 3;
            label4.Text = "Username:";
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            panel2.AutoSize = true;
            panel2.BackColor = Color.FromArgb(1, 24, 30);
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(Signup_btn);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(pictureBox1);
            panel2.Location = new Point(0, -1);
            panel2.Margin = new Padding(3, 4, 3, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(329, 581);
            panel2.TabIndex = 0;
            // 
            // Signup_btn
            // 
            Signup_btn.BackColor = Color.FromArgb(128, 255, 255);
            Signup_btn.Cursor = Cursors.Hand;
            Signup_btn.FlatAppearance.BorderSize = 9;
            Signup_btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(192, 192, 255);
            Signup_btn.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Signup_btn.ForeColor = SystemColors.ControlText;
            Signup_btn.Location = new Point(88, 419);
            Signup_btn.Margin = new Padding(3, 4, 3, 4);
            Signup_btn.Name = "Signup_btn";
            Signup_btn.Size = new Size(122, 47);
            Signup_btn.TabIndex = 3;
            Signup_btn.Text = "SIGN UP";
            Signup_btn.UseVisualStyleBackColor = false;
            Signup_btn.Click += Signup_btn_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = Color.FromArgb(255, 128, 0);
            label5.Location = new Point(75, 475);
            label5.Name = "label5";
            label5.Size = new Size(161, 20);
            label5.TabIndex = 2;
            label5.Text = "Don't have an account?";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Book Antiqua", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(255, 128, 0);
            label1.Location = new Point(63, 257);
            label1.Name = "label1";
            label1.Size = new Size(227, 28);
            label1.TabIndex = 1;
            label1.Text = "Horizon Drive LTD";
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Left;
            pictureBox1.Image = Resources.Logo;
            pictureBox1.Location = new Point(58, 11);
            pictureBox1.Margin = new Padding(3, 4, 3, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(210, 212);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(750, 583);
            Controls.Add(panel1);
            Margin = new Padding(5, 4, 5, 4);
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
        private TextBox Username;
        private TextBox Password;
        private Button LOGIN_btn;
        private CheckBox checkBox1;
        private Label label5;
        private Button Signup_btn;
    }
}
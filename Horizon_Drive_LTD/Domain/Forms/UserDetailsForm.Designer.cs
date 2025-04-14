using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace User_managing
{
    partial class UserDetailsForm
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
            lblTitle = new Label();
            txtUserId = new TextBox();
            lblUserId = new Label();
            txtUsername = new TextBox();
            lblUsername = new Label();
            txtFirstName = new TextBox();
            lblFirstName = new Label();
            txtLastName = new TextBox();
            lblLastName = new Label();
            txtEmail = new TextBox();
            lblEmail = new Label();
            txtPhone = new TextBox();
            lblPhone = new Label();
            txtAddress = new TextBox();
            lblAddress = new Label();
            dtpDOB = new DateTimePicker();
            lblDOB = new Label();
            picProfile = new PictureBox();
            btnEdit = new Button();
            btnSave = new Button();
            btnClose = new Button();
            btnChangeImage = new Button();
            ((System.ComponentModel.ISupportInitialize)picProfile).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(20, 48, 65);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 600);
            panel1.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.BackColor = Color.FromArgb(20, 48, 65);
            lblTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(300, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(245, 46);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "USER DETAILS";
            // 
            // txtUserId
            // 
            txtUserId.BorderStyle = BorderStyle.FixedSingle;
            txtUserId.Font = new Font("Segoe UI", 12F);
            txtUserId.Location = new Point(200, 90);
            txtUserId.Name = "txtUserId";
            txtUserId.ReadOnly = true;
            txtUserId.Size = new Size(250, 34);
            txtUserId.TabIndex = 1;
            // 
            // lblUserId
            // 
            lblUserId.AutoSize = true;
            lblUserId.BackColor = Color.FromArgb(20, 48, 65);
            lblUserId.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblUserId.ForeColor = Color.White;
            lblUserId.Location = new Point(50, 90);
            lblUserId.Name = "lblUserId";
            lblUserId.Size = new Size(84, 28);
            lblUserId.TabIndex = 21;
            lblUserId.Text = "User ID:";
            // 
            // txtUsername
            // 
            txtUsername.BorderStyle = BorderStyle.FixedSingle;
            txtUsername.Font = new Font("Segoe UI", 12F);
            txtUsername.Location = new Point(200, 130);
            txtUsername.Name = "txtUsername";
            txtUsername.ReadOnly = true;
            txtUsername.Size = new Size(250, 34);
            txtUsername.TabIndex = 2;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.BackColor = Color.FromArgb(20, 48, 65);
            lblUsername.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblUsername.ForeColor = Color.White;
            lblUsername.Location = new Point(50, 130);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(109, 28);
            lblUsername.TabIndex = 20;
            lblUsername.Text = "Username:";
            // 
            // txtFirstName
            // 
            txtFirstName.BorderStyle = BorderStyle.FixedSingle;
            txtFirstName.Font = new Font("Segoe UI", 12F);
            txtFirstName.Location = new Point(200, 170);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.ReadOnly = true;
            txtFirstName.Size = new Size(250, 34);
            txtFirstName.TabIndex = 3;
            // 
            // lblFirstName
            // 
            lblFirstName.AutoSize = true;
            lblFirstName.BackColor = Color.FromArgb(20, 48, 65);
            lblFirstName.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblFirstName.ForeColor = Color.White;
            lblFirstName.Location = new Point(50, 170);
            lblFirstName.Name = "lblFirstName";
            lblFirstName.Size = new Size(115, 28);
            lblFirstName.TabIndex = 19;
            lblFirstName.Text = "First Name:";
            // 
            // txtLastName
            // 
            txtLastName.BorderStyle = BorderStyle.FixedSingle;
            txtLastName.Font = new Font("Segoe UI", 12F);
            txtLastName.Location = new Point(200, 210);
            txtLastName.Name = "txtLastName";
            txtLastName.ReadOnly = true;
            txtLastName.Size = new Size(250, 34);
            txtLastName.TabIndex = 4;
            // 
            // lblLastName
            // 
            lblLastName.AutoSize = true;
            lblLastName.BackColor = Color.FromArgb(20, 48, 65);
            lblLastName.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblLastName.ForeColor = Color.White;
            lblLastName.Location = new Point(50, 210);
            lblLastName.Name = "lblLastName";
            lblLastName.Size = new Size(113, 28);
            lblLastName.TabIndex = 18;
            lblLastName.Text = "Last Name:";
            // 
            // txtEmail
            // 
            txtEmail.BorderStyle = BorderStyle.FixedSingle;
            txtEmail.Font = new Font("Segoe UI", 12F);
            txtEmail.Location = new Point(200, 250);
            txtEmail.Name = "txtEmail";
            txtEmail.ReadOnly = true;
            txtEmail.Size = new Size(250, 34);
            txtEmail.TabIndex = 5;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.BackColor = Color.FromArgb(20, 48, 65);
            lblEmail.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblEmail.ForeColor = Color.White;
            lblEmail.Location = new Point(50, 250);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(65, 28);
            lblEmail.TabIndex = 17;
            lblEmail.Text = "Email:";
            // 
            // txtPhone
            // 
            txtPhone.BorderStyle = BorderStyle.FixedSingle;
            txtPhone.Font = new Font("Segoe UI", 12F);
            txtPhone.Location = new Point(200, 290);
            txtPhone.Name = "txtPhone";
            txtPhone.ReadOnly = true;
            txtPhone.Size = new Size(250, 34);
            txtPhone.TabIndex = 6;
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.BackColor = Color.FromArgb(20, 48, 65);
            lblPhone.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblPhone.ForeColor = Color.White;
            lblPhone.Location = new Point(50, 290);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(76, 28);
            lblPhone.TabIndex = 16;
            lblPhone.Text = "Phone:";
            // 
            // txtAddress
            // 
            txtAddress.BorderStyle = BorderStyle.FixedSingle;
            txtAddress.Font = new Font("Segoe UI", 12F);
            txtAddress.Location = new Point(200, 330);
            txtAddress.Multiline = true;
            txtAddress.Name = "txtAddress";
            txtAddress.ReadOnly = true;
            txtAddress.Size = new Size(250, 60);
            txtAddress.TabIndex = 7;
            // 
            // lblAddress
            // 
            lblAddress.AutoSize = true;
            lblAddress.BackColor = Color.FromArgb(20, 48, 65);
            lblAddress.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblAddress.ForeColor = Color.White;
            lblAddress.Location = new Point(50, 330);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(90, 28);
            lblAddress.TabIndex = 15;
            lblAddress.Text = "Address:";
            // 
            // dtpDOB
            // 
            dtpDOB.Enabled = false;
            dtpDOB.Font = new Font("Segoe UI", 12F);
            dtpDOB.Format = DateTimePickerFormat.Short;
            dtpDOB.Location = new Point(200, 400);
            dtpDOB.Name = "dtpDOB";
            dtpDOB.Size = new Size(250, 34);
            dtpDOB.TabIndex = 8;
            // 
            // lblDOB
            // 
            lblDOB.AutoSize = true;
            lblDOB.BackColor = Color.FromArgb(20, 48, 65);
            lblDOB.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblDOB.ForeColor = Color.White;
            lblDOB.Location = new Point(50, 400);
            lblDOB.Name = "lblDOB";
            lblDOB.Size = new Size(134, 28);
            lblDOB.TabIndex = 14;
            lblDOB.Text = "Date of Birth:";
            // 
            // picProfile
            // 
            picProfile.BackColor = Color.White;
            picProfile.BorderStyle = BorderStyle.FixedSingle;
            picProfile.Location = new Point(500, 90);
            picProfile.Name = "picProfile";
            picProfile.Size = new Size(200, 200);
            picProfile.SizeMode = PictureBoxSizeMode.Zoom;
            picProfile.TabIndex = 9;
            picProfile.TabStop = false;
            // 
            // btnEdit
            // 
            btnEdit.BackColor = Color.FromArgb(45, 68, 135);
            btnEdit.FlatAppearance.BorderSize = 0;
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnEdit.ForeColor = Color.White;
            btnEdit.Location = new Point(120, 500);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(150, 50);
            btnEdit.TabIndex = 11;
            btnEdit.Text = "EDIT";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += BtnEdit_Click;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(45, 68, 135);
            btnSave.Enabled = false;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(325, 500);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(150, 50);
            btnSave.TabIndex = 12;
            btnSave.Text = "SAVE";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += BtnSave_Click;
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.FromArgb(45, 68, 135);
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(530, 500);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(150, 50);
            btnClose.TabIndex = 13;
            btnClose.Text = "CLOSE";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += BtnClose_Click;
            // 
            // btnChangeImage
            // 
            btnChangeImage.BackColor = Color.FromArgb(45, 68, 135);
            btnChangeImage.Enabled = false;
            btnChangeImage.FlatAppearance.BorderSize = 0;
            btnChangeImage.FlatStyle = FlatStyle.Flat;
            btnChangeImage.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnChangeImage.ForeColor = Color.White;
            btnChangeImage.Location = new Point(500, 300);
            btnChangeImage.Name = "btnChangeImage";
            btnChangeImage.Size = new Size(200, 40);
            btnChangeImage.TabIndex = 10;
            btnChangeImage.Text = "Change Profile Picture";
            btnChangeImage.UseVisualStyleBackColor = false;
            btnChangeImage.Click += BtnChangeImage_Click;
            // 
            // UserDetailsForm
            // 
            ClientSize = new Size(800, 600);
            Controls.Add(btnClose);
            Controls.Add(btnSave);
            Controls.Add(btnEdit);
            Controls.Add(btnChangeImage);
            Controls.Add(picProfile);
            Controls.Add(dtpDOB);
            Controls.Add(lblDOB);
            Controls.Add(txtAddress);
            Controls.Add(lblAddress);
            Controls.Add(txtPhone);
            Controls.Add(lblPhone);
            Controls.Add(txtEmail);
            Controls.Add(lblEmail);
            Controls.Add(txtLastName);
            Controls.Add(lblLastName);
            Controls.Add(txtFirstName);
            Controls.Add(lblFirstName);
            Controls.Add(txtUsername);
            Controls.Add(lblUsername);
            Controls.Add(txtUserId);
            Controls.Add(lblUserId);
            Controls.Add(lblTitle);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "UserDetailsForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "User Details";
            ((System.ComponentModel.ISupportInitialize)picProfile).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        // Panel and controls
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtUserId;
        private System.Windows.Forms.Label lblUserId;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.DateTimePicker dtpDOB;
        private System.Windows.Forms.Label lblDOB;
        private System.Windows.Forms.PictureBox picProfile;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnChangeImage;
    }
}
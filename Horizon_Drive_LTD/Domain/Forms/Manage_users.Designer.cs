namespace User_managing
{
    partial class Manage_users
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
            dataGridView2 = new DataGridView();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            Go_back_btn = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.FromArgb(20, 48, 65);
            panel1.Controls.Add(dataGridView2);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(Go_back_btn);
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(4, 3, 4, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(863, 557);
            panel1.TabIndex = 0;
            // 
            // dataGridView2
            // 
            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.AllowUserToDeleteRows = false;
            dataGridView2.AllowUserToResizeColumns = false;
            dataGridView2.AllowUserToResizeRows = false;
            dataGridView2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView2.BackgroundColor = Color.White;
            dataGridView2.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(139, 69);
            dataGridView2.Margin = new Padding(4, 3, 4, 3);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowTemplate.Height = 30;
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.Size = new Size(578, 383);
            dataGridView2.TabIndex = 12;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(14, 14);
            pictureBox1.Margin = new Padding(4, 3, 4, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(84, 77);
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            label1.ForeColor = SystemColors.ControlLightLight;
            label1.Location = new Point(270, 23);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(265, 37);
            label1.TabIndex = 2;
            label1.Text = "Users Management";
            // 
            // Go_back_btn
            // 
            Go_back_btn.Anchor = AnchorStyles.None;
            Go_back_btn.BackColor = Color.FromArgb(45, 68, 135);
            Go_back_btn.Cursor = Cursors.Hand;
            Go_back_btn.FlatAppearance.BorderSize = 0;
            Go_back_btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(192, 192, 255);
            Go_back_btn.FlatStyle = FlatStyle.Flat;
            Go_back_btn.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            Go_back_btn.ForeColor = SystemColors.ControlLightLight;
            Go_back_btn.Location = new Point(288, 472);
            Go_back_btn.Margin = new Padding(4, 3, 4, 3);
            Go_back_btn.Name = "Go_back_btn";
            Go_back_btn.Size = new Size(267, 60);
            Go_back_btn.TabIndex = 1;
            Go_back_btn.Text = "GO BACK";
            Go_back_btn.UseVisualStyleBackColor = false;
            Go_back_btn.Click += button1_Click;
            // 
            // Manage_users
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(862, 557);
            Controls.Add(panel1);
            Margin = new Padding(4, 3, 4, 3);
            Name = "Manage_users";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Manage_customers";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button Go_back_btn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView dataGridView2;
    }
}
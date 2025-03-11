namespace WindowsFormsApp1
{
    partial class Form1
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
            this.Addbtn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.UsersTable = new System.Windows.Forms.DataGridView();
            this.Editbtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.UsersTable)).BeginInit();
            this.SuspendLayout();
            // 
            // Addbtn
            // 
            this.Addbtn.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Addbtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Addbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Addbtn.Location = new System.Drawing.Point(27, 98);
            this.Addbtn.Name = "Addbtn";
            this.Addbtn.Size = new System.Drawing.Size(135, 43);
            this.Addbtn.TabIndex = 6;
            this.Addbtn.Text = " Add";
            this.Addbtn.UseVisualStyleBackColor = false;
            this.Addbtn.Click += new System.EventHandler(this.Addbtn_Click);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label4.Location = new System.Drawing.Point(29, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(998, 49);
            this.label4.TabIndex = 7;
            this.label4.Text = "List of Users";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // UsersTable
            // 
            this.UsersTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UsersTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.UsersTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.UsersTable.Location = new System.Drawing.Point(27, 158);
            this.UsersTable.MultiSelect = false;
            this.UsersTable.Name = "UsersTable";
            this.UsersTable.RowHeadersVisible = false;
            this.UsersTable.RowHeadersWidth = 62;
            this.UsersTable.RowTemplate.Height = 28;
            this.UsersTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.UsersTable.Size = new System.Drawing.Size(1000, 358);
            this.UsersTable.TabIndex = 8;
            // 
            // Editbtn
            // 
            this.Editbtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Editbtn.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Editbtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Editbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Editbtn.Location = new System.Drawing.Point(929, 98);
            this.Editbtn.Name = "Editbtn";
            this.Editbtn.Size = new System.Drawing.Size(98, 43);
            this.Editbtn.TabIndex = 9;
            this.Editbtn.Text = "Edit \r\n";
            this.Editbtn.UseVisualStyleBackColor = false;
            this.Editbtn.Click += new System.EventHandler(this.Editbtn_Click);
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1050, 528);
            this.Controls.Add(this.Editbtn);
            this.Controls.Add(this.UsersTable);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Addbtn);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.UsersTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button Addbtn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView UsersTable;
        private System.Windows.Forms.Button Editbtn;
    }
}


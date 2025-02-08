namespace Homepageproject
{
    partial class AdminCustomeradd
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.Idtxt = new System.Windows.Forms.TextBox();
            this.Searchcustomerbtn = new System.Windows.Forms.Button();
            this.clearbtn = new System.Windows.Forms.Button();
            this.Rejectbtn = new System.Windows.Forms.Button();
            this.insertbtn = new System.Windows.Forms.Button();
            this.searchtxt = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.CustomerDataAdmnGrid = new System.Windows.Forms.DataGridView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerDataAdmnGrid)).BeginInit();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightCyan;
            this.panel1.Controls.Add(this.Idtxt);
            this.panel1.Controls.Add(this.Searchcustomerbtn);
            this.panel1.Controls.Add(this.clearbtn);
            this.panel1.Controls.Add(this.Rejectbtn);
            this.panel1.Controls.Add(this.insertbtn);
            this.panel1.Controls.Add(this.searchtxt);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.CustomerDataAdmnGrid);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(958, 753);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // Idtxt
            // 
            this.Idtxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Idtxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Idtxt.Location = new System.Drawing.Point(747, 101);
            this.Idtxt.Multiline = true;
            this.Idtxt.Name = "Idtxt";
            this.Idtxt.Size = new System.Drawing.Size(85, 33);
            this.Idtxt.TabIndex = 24;
            this.Idtxt.Enter += new System.EventHandler(this.Idtxt_Enter);
            this.Idtxt.Leave += new System.EventHandler(this.Idtxt_Leave);
            // 
            // Searchcustomerbtn
            // 
            this.Searchcustomerbtn.Image = global::Homepageproject.Properties.Resources.search1;
            this.Searchcustomerbtn.Location = new System.Drawing.Point(468, 97);
            this.Searchcustomerbtn.Name = "Searchcustomerbtn";
            this.Searchcustomerbtn.Size = new System.Drawing.Size(54, 42);
            this.Searchcustomerbtn.TabIndex = 36;
            this.Searchcustomerbtn.UseVisualStyleBackColor = true;
            this.Searchcustomerbtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // clearbtn
            // 
            this.clearbtn.BackColor = System.Drawing.Color.Orange;
            this.clearbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearbtn.ForeColor = System.Drawing.Color.Black;
            this.clearbtn.Location = new System.Drawing.Point(734, 591);
            this.clearbtn.Name = "clearbtn";
            this.clearbtn.Size = new System.Drawing.Size(163, 57);
            this.clearbtn.TabIndex = 22;
            this.clearbtn.Text = "Clear";
            this.clearbtn.UseVisualStyleBackColor = false;
            this.clearbtn.Click += new System.EventHandler(this.updatebtn_Click);
            // 
            // Rejectbtn
            // 
            this.Rejectbtn.BackColor = System.Drawing.Color.Red;
            this.Rejectbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Rejectbtn.ForeColor = System.Drawing.Color.White;
            this.Rejectbtn.Location = new System.Drawing.Point(425, 591);
            this.Rejectbtn.Name = "Rejectbtn";
            this.Rejectbtn.Size = new System.Drawing.Size(240, 57);
            this.Rejectbtn.TabIndex = 35;
            this.Rejectbtn.Text = "Reject Application";
            this.Rejectbtn.UseVisualStyleBackColor = false;
            this.Rejectbtn.Click += new System.EventHandler(this.Deletebtn_Click);
            // 
            // insertbtn
            // 
            this.insertbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.insertbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.insertbtn.ForeColor = System.Drawing.Color.Black;
            this.insertbtn.Location = new System.Drawing.Point(108, 591);
            this.insertbtn.Name = "insertbtn";
            this.insertbtn.Size = new System.Drawing.Size(236, 57);
            this.insertbtn.TabIndex = 23;
            this.insertbtn.Text = "Accepts Application";
            this.insertbtn.UseVisualStyleBackColor = false;
            this.insertbtn.Click += new System.EventHandler(this.insertbtn_Click);
            // 
            // searchtxt
            // 
            this.searchtxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchtxt.Location = new System.Drawing.Point(223, 98);
            this.searchtxt.Multiline = true;
            this.searchtxt.Name = "searchtxt";
            this.searchtxt.Size = new System.Drawing.Size(239, 41);
            this.searchtxt.TabIndex = 32;
            this.searchtxt.Enter += new System.EventHandler(this.searchtxt_Enter);
            this.searchtxt.Leave += new System.EventHandler(this.searchtxt_Leave);
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(86, 97);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(131, 42);
            this.label6.TabIndex = 33;
            this.label6.Text = "Search :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CustomerDataAdmnGrid
            // 
            this.CustomerDataAdmnGrid.AllowUserToAddRows = false;
            this.CustomerDataAdmnGrid.AllowUserToDeleteRows = false;
            this.CustomerDataAdmnGrid.AllowUserToResizeColumns = false;
            this.CustomerDataAdmnGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CustomerDataAdmnGrid.Location = new System.Drawing.Point(93, 150);
            this.CustomerDataAdmnGrid.Name = "CustomerDataAdmnGrid";
            this.CustomerDataAdmnGrid.RowHeadersWidth = 51;
            this.CustomerDataAdmnGrid.RowTemplate.Height = 24;
            this.CustomerDataAdmnGrid.Size = new System.Drawing.Size(739, 272);
            this.CustomerDataAdmnGrid.TabIndex = 31;
            this.CustomerDataAdmnGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.CustomerDataAdmnGrid_CellClick);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(87)))), ((int)(((byte)(122)))));
            this.panel4.Controls.Add(this.label2);
            this.panel4.Location = new System.Drawing.Point(-1, 0);
            this.panel4.MaximumSize = new System.Drawing.Size(972, 58);
            this.panel4.MinimumSize = new System.Drawing.Size(972, 58);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(972, 58);
            this.panel4.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Rockwell", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(271, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(441, 55);
            this.label2.TabIndex = 5;
            this.label2.Text = "Add Customers";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AdminCustomeradd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(958, 753);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(958, 753);
            this.MinimumSize = new System.Drawing.Size(958, 753);
            this.Name = "AdminCustomeradd";
            this.Text = "AdminCustomeradd";
            this.Load += new System.EventHandler(this.AdminCustomeradd_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerDataAdmnGrid)).EndInit();
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Searchcustomerbtn;
        private System.Windows.Forms.Button Rejectbtn;
        private System.Windows.Forms.TextBox searchtxt;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView CustomerDataAdmnGrid;
        private System.Windows.Forms.TextBox Idtxt;
        private System.Windows.Forms.Button clearbtn;
        private System.Windows.Forms.Button insertbtn;
    }
}
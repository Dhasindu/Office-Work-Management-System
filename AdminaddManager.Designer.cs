namespace Homepageproject
{
    partial class AdminaddManager
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
            this.mainpanel = new System.Windows.Forms.Panel();
            this.Idtxt = new System.Windows.Forms.TextBox();
            this.searchbtn = new System.Windows.Forms.Button();
            this.Deletebtn = new System.Windows.Forms.Button();
            this.searchtxt = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.viewbtn = new System.Windows.Forms.Button();
            this.datagrid1 = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.UserStatus = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.updatebtn = new System.Windows.Forms.Button();
            this.insertbtn = new System.Windows.Forms.Button();
            this.usertypeComBox = new System.Windows.Forms.ComboBox();
            this.paswdtxt = new System.Windows.Forms.TextBox();
            this.userNametxt = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.mainpanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagrid1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainpanel
            // 
            this.mainpanel.BackColor = System.Drawing.Color.LightCyan;
            this.mainpanel.Controls.Add(this.Idtxt);
            this.mainpanel.Controls.Add(this.searchbtn);
            this.mainpanel.Controls.Add(this.Deletebtn);
            this.mainpanel.Controls.Add(this.searchtxt);
            this.mainpanel.Controls.Add(this.label6);
            this.mainpanel.Controls.Add(this.viewbtn);
            this.mainpanel.Controls.Add(this.datagrid1);
            this.mainpanel.Controls.Add(this.panel2);
            this.mainpanel.Controls.Add(this.panel4);
            this.mainpanel.Location = new System.Drawing.Point(-1, 0);
            this.mainpanel.Name = "mainpanel";
            this.mainpanel.Size = new System.Drawing.Size(958, 753);
            this.mainpanel.TabIndex = 15;
            this.mainpanel.Paint += new System.Windows.Forms.PaintEventHandler(this.mainpanel_Paint);
            // 
            // Idtxt
            // 
            this.Idtxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Idtxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Idtxt.Location = new System.Drawing.Point(54, 448);
            this.Idtxt.Multiline = true;
            this.Idtxt.Name = "Idtxt";
            this.Idtxt.ReadOnly = true;
            this.Idtxt.Size = new System.Drawing.Size(150, 36);
            this.Idtxt.TabIndex = 24;
            this.Idtxt.TextChanged += new System.EventHandler(this.Idtxt_TextChanged);
            this.Idtxt.Enter += new System.EventHandler(this.Idtxt_Enter);
            this.Idtxt.Leave += new System.EventHandler(this.Idtxt_Leave);
            // 
            // searchbtn
            // 
            this.searchbtn.Image = global::Homepageproject.Properties.Resources.search1;
            this.searchbtn.Location = new System.Drawing.Point(436, 104);
            this.searchbtn.Name = "searchbtn";
            this.searchbtn.Size = new System.Drawing.Size(54, 42);
            this.searchbtn.TabIndex = 22;
            this.searchbtn.UseVisualStyleBackColor = true;
            this.searchbtn.Click += new System.EventHandler(this.searchbtn_Click);
            // 
            // Deletebtn
            // 
            this.Deletebtn.BackColor = System.Drawing.Color.Red;
            this.Deletebtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Deletebtn.ForeColor = System.Drawing.Color.White;
            this.Deletebtn.Location = new System.Drawing.Point(729, 315);
            this.Deletebtn.Name = "Deletebtn";
            this.Deletebtn.Size = new System.Drawing.Size(163, 57);
            this.Deletebtn.TabIndex = 21;
            this.Deletebtn.Text = "Delete";
            this.Deletebtn.UseVisualStyleBackColor = false;
            this.Deletebtn.Click += new System.EventHandler(this.Deletebtn_Click);
            // 
            // searchtxt
            // 
            this.searchtxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchtxt.Location = new System.Drawing.Point(191, 105);
            this.searchtxt.Multiline = true;
            this.searchtxt.Name = "searchtxt";
            this.searchtxt.Size = new System.Drawing.Size(239, 41);
            this.searchtxt.TabIndex = 20;
            this.searchtxt.Enter += new System.EventHandler(this.searchtxt_Enter);
            this.searchtxt.Leave += new System.EventHandler(this.searchtxt_Leave);
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(54, 104);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(131, 42);
            this.label6.TabIndex = 20;
            this.label6.Text = "Search :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // viewbtn
            // 
            this.viewbtn.BackColor = System.Drawing.Color.MediumPurple;
            this.viewbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewbtn.Location = new System.Drawing.Point(716, 188);
            this.viewbtn.Name = "viewbtn";
            this.viewbtn.Size = new System.Drawing.Size(197, 57);
            this.viewbtn.TabIndex = 20;
            this.viewbtn.Text = "Reset Password";
            this.viewbtn.UseVisualStyleBackColor = false;
            this.viewbtn.Click += new System.EventHandler(this.viewbtn_Click);
            // 
            // datagrid1
            // 
            this.datagrid1.AllowUserToAddRows = false;
            this.datagrid1.AllowUserToDeleteRows = false;
            this.datagrid1.AllowUserToResizeColumns = false;
            this.datagrid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagrid1.Location = new System.Drawing.Point(58, 162);
            this.datagrid1.Name = "datagrid1";
            this.datagrid1.RowHeadersWidth = 51;
            this.datagrid1.RowTemplate.Height = 24;
            this.datagrid1.Size = new System.Drawing.Size(628, 249);
            this.datagrid1.TabIndex = 19;
            this.datagrid1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datagrid1_CellClick);
            this.datagrid1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datagrid1_CellContentClick);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel2.Controls.Add(this.UserStatus);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.updatebtn);
            this.panel2.Controls.Add(this.insertbtn);
            this.panel2.Controls.Add(this.usertypeComBox);
            this.panel2.Controls.Add(this.paswdtxt);
            this.panel2.Controls.Add(this.userNametxt);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(55, 486);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(858, 243);
            this.panel2.TabIndex = 18;
            // 
            // UserStatus
            // 
            this.UserStatus.DropDownHeight = 362;
            this.UserStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserStatus.ForeColor = System.Drawing.Color.Black;
            this.UserStatus.FormattingEnabled = true;
            this.UserStatus.IntegralHeight = false;
            this.UserStatus.Items.AddRange(new object[] {
            "Active",
            "In-Active"});
            this.UserStatus.Location = new System.Drawing.Point(223, 134);
            this.UserStatus.Name = "UserStatus";
            this.UserStatus.Size = new System.Drawing.Size(239, 33);
            this.UserStatus.TabIndex = 25;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(64, 125);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 42);
            this.label1.TabIndex = 24;
            this.label1.Text = "User Status :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // updatebtn
            // 
            this.updatebtn.BackColor = System.Drawing.Color.Orange;
            this.updatebtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updatebtn.ForeColor = System.Drawing.Color.Black;
            this.updatebtn.Location = new System.Drawing.Point(650, 150);
            this.updatebtn.Name = "updatebtn";
            this.updatebtn.Size = new System.Drawing.Size(163, 57);
            this.updatebtn.TabIndex = 22;
            this.updatebtn.Text = "Update";
            this.updatebtn.UseVisualStyleBackColor = false;
            this.updatebtn.Click += new System.EventHandler(this.updatebtn_Click);
            // 
            // insertbtn
            // 
            this.insertbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.insertbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.insertbtn.ForeColor = System.Drawing.Color.Black;
            this.insertbtn.Location = new System.Drawing.Point(652, 26);
            this.insertbtn.Name = "insertbtn";
            this.insertbtn.Size = new System.Drawing.Size(163, 57);
            this.insertbtn.TabIndex = 23;
            this.insertbtn.Text = "Insert";
            this.insertbtn.UseVisualStyleBackColor = false;
            this.insertbtn.Click += new System.EventHandler(this.insertbtn_Click);
            // 
            // usertypeComBox
            // 
            this.usertypeComBox.DropDownHeight = 362;
            this.usertypeComBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usertypeComBox.ForeColor = System.Drawing.Color.Black;
            this.usertypeComBox.FormattingEnabled = true;
            this.usertypeComBox.IntegralHeight = false;
            this.usertypeComBox.Items.AddRange(new object[] {
            "manager"});
            this.usertypeComBox.Location = new System.Drawing.Point(223, 188);
            this.usertypeComBox.Name = "usertypeComBox";
            this.usertypeComBox.Size = new System.Drawing.Size(239, 33);
            this.usertypeComBox.TabIndex = 19;
            // 
            // paswdtxt
            // 
            this.paswdtxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paswdtxt.ForeColor = System.Drawing.Color.Black;
            this.paswdtxt.Location = new System.Drawing.Point(224, 74);
            this.paswdtxt.Multiline = true;
            this.paswdtxt.Name = "paswdtxt";
            this.paswdtxt.Size = new System.Drawing.Size(239, 41);
            this.paswdtxt.TabIndex = 5;
            // 
            // userNametxt
            // 
            this.userNametxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userNametxt.Location = new System.Drawing.Point(223, 14);
            this.userNametxt.Multiline = true;
            this.userNametxt.Name = "userNametxt";
            this.userNametxt.Size = new System.Drawing.Size(239, 41);
            this.userNametxt.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(65, 180);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(131, 42);
            this.label5.TabIndex = 3;
            this.label5.Text = "User Type :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(72, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(131, 42);
            this.label4.TabIndex = 2;
            this.label4.Text = "Password :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(65, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 42);
            this.label3.TabIndex = 1;
            this.label3.Text = "User Name :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(87)))), ((int)(((byte)(122)))));
            this.panel4.Controls.Add(this.label2);
            this.panel4.Location = new System.Drawing.Point(-7, 0);
            this.panel4.MaximumSize = new System.Drawing.Size(972, 58);
            this.panel4.MinimumSize = new System.Drawing.Size(972, 58);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(972, 58);
            this.panel4.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Rockwell", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(271, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(441, 55);
            this.label2.TabIndex = 5;
            this.label2.Text = "Add Managers";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AdminaddManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(958, 753);
            this.Controls.Add(this.mainpanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(958, 753);
            this.MinimumSize = new System.Drawing.Size(958, 753);
            this.Name = "AdminaddManager";
            this.Text = "AdminaddManager";
            this.Load += new System.EventHandler(this.AdminaddManager_Load);
            this.mainpanel.ResumeLayout(false);
            this.mainpanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagrid1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainpanel;
        private System.Windows.Forms.Button searchbtn;
        private System.Windows.Forms.Button Deletebtn;
        private System.Windows.Forms.TextBox searchtxt;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button viewbtn;
        private System.Windows.Forms.DataGridView datagrid1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox Idtxt;
        private System.Windows.Forms.Button updatebtn;
        private System.Windows.Forms.Button insertbtn;
        private System.Windows.Forms.ComboBox usertypeComBox;
        private System.Windows.Forms.TextBox paswdtxt;
        private System.Windows.Forms.TextBox userNametxt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox UserStatus;
    }
}
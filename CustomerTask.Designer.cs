namespace Homepageproject
{
    partial class CustomerTask
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
            this.panel4 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.taskDataview = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.taskDatetxt = new System.Windows.Forms.DateTimePicker();
            this.upload2btn = new System.Windows.Forms.Button();
            this.upload1btn = new System.Windows.Forms.Button();
            this.doctxtPath2 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.doctxtPath1 = new System.Windows.Forms.TextBox();
            this.tasknametxt = new System.Windows.Forms.TextBox();
            this.taskIdtxt = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Addbtn = new System.Windows.Forms.Button();
            this.Deletebtn = new System.Windows.Forms.Button();
            this.Updatebtn = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.clearbtn = new System.Windows.Forms.Button();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.taskDataview)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(87)))), ((int)(((byte)(122)))));
            this.panel4.Controls.Add(this.label2);
            this.panel4.Location = new System.Drawing.Point(-10, 0);
            this.panel4.MaximumSize = new System.Drawing.Size(972, 58);
            this.panel4.MinimumSize = new System.Drawing.Size(972, 58);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(972, 58);
            this.panel4.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Rockwell", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(271, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(441, 55);
            this.label2.TabIndex = 5;
            this.label2.Text = "Customer Task Managment";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // taskDataview
            // 
            this.taskDataview.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.taskDataview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.taskDataview.Location = new System.Drawing.Point(60, 459);
            this.taskDataview.Name = "taskDataview";
            this.taskDataview.RowHeadersWidth = 51;
            this.taskDataview.RowTemplate.Height = 24;
            this.taskDataview.Size = new System.Drawing.Size(785, 295);
            this.taskDataview.TabIndex = 20;
            this.taskDataview.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.taskDataview_CellClick);
            this.taskDataview.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.taskDataview_CellContentClick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel1.Controls.Add(this.taskDatetxt);
            this.panel1.Controls.Add(this.upload2btn);
            this.panel1.Controls.Add(this.upload1btn);
            this.panel1.Controls.Add(this.doctxtPath2);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.doctxtPath1);
            this.panel1.Controls.Add(this.tasknametxt);
            this.panel1.Controls.Add(this.taskIdtxt);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(61, 74);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(514, 333);
            this.panel1.TabIndex = 21;
            // 
            // taskDatetxt
            // 
            this.taskDatetxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.taskDatetxt.Location = new System.Drawing.Point(188, 160);
            this.taskDatetxt.Name = "taskDatetxt";
            this.taskDatetxt.Size = new System.Drawing.Size(317, 27);
            this.taskDatetxt.TabIndex = 12;
            // 
            // upload2btn
            // 
            this.upload2btn.BackColor = System.Drawing.Color.DodgerBlue;
            this.upload2btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.upload2btn.ForeColor = System.Drawing.Color.White;
            this.upload2btn.Location = new System.Drawing.Point(418, 264);
            this.upload2btn.Name = "upload2btn";
            this.upload2btn.Size = new System.Drawing.Size(86, 39);
            this.upload2btn.TabIndex = 11;
            this.upload2btn.Text = "Upload";
            this.upload2btn.UseVisualStyleBackColor = false;
            this.upload2btn.Click += new System.EventHandler(this.upload2btn_Click);
            // 
            // upload1btn
            // 
            this.upload1btn.BackColor = System.Drawing.Color.DodgerBlue;
            this.upload1btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.upload1btn.ForeColor = System.Drawing.Color.White;
            this.upload1btn.Location = new System.Drawing.Point(418, 214);
            this.upload1btn.Name = "upload1btn";
            this.upload1btn.Size = new System.Drawing.Size(88, 39);
            this.upload1btn.TabIndex = 10;
            this.upload1btn.Text = "Upload";
            this.upload1btn.UseVisualStyleBackColor = false;
            this.upload1btn.Click += new System.EventHandler(this.upload1btn_Click);
            // 
            // doctxtPath2
            // 
            this.doctxtPath2.Location = new System.Drawing.Point(188, 265);
            this.doctxtPath2.Multiline = true;
            this.doctxtPath2.Name = "doctxtPath2";
            this.doctxtPath2.Size = new System.Drawing.Size(317, 39);
            this.doctxtPath2.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(21, 271);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(143, 38);
            this.label6.TabIndex = 8;
            this.label6.Text = "Task Document 2 :\r\n    (optional)";
            // 
            // doctxtPath1
            // 
            this.doctxtPath1.Location = new System.Drawing.Point(191, 214);
            this.doctxtPath1.Multiline = true;
            this.doctxtPath1.Name = "doctxtPath1";
            this.doctxtPath1.Size = new System.Drawing.Size(317, 39);
            this.doctxtPath1.TabIndex = 7;
            // 
            // tasknametxt
            // 
            this.tasknametxt.Location = new System.Drawing.Point(191, 89);
            this.tasknametxt.Multiline = true;
            this.tasknametxt.Name = "tasknametxt";
            this.tasknametxt.Size = new System.Drawing.Size(315, 39);
            this.tasknametxt.TabIndex = 5;
            // 
            // taskIdtxt
            // 
            this.taskIdtxt.Location = new System.Drawing.Point(188, 26);
            this.taskIdtxt.Multiline = true;
            this.taskIdtxt.Name = "taskIdtxt";
            this.taskIdtxt.ReadOnly = true;
            this.taskIdtxt.Size = new System.Drawing.Size(87, 39);
            this.taskIdtxt.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(22, 220);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(143, 19);
            this.label5.TabIndex = 3;
            this.label5.Text = "Task Document 1 :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(73, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 19);
            this.label4.TabIndex = 2;
            this.label4.Text = "Task Name :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(42, 160);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 19);
            this.label3.TabIndex = 1;
            this.label3.Text = "Task DeadLine :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(102, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Task Id :";
            // 
            // Addbtn
            // 
            this.Addbtn.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.Addbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Addbtn.Location = new System.Drawing.Point(748, 83);
            this.Addbtn.Name = "Addbtn";
            this.Addbtn.Size = new System.Drawing.Size(150, 53);
            this.Addbtn.TabIndex = 22;
            this.Addbtn.Text = "Add";
            this.Addbtn.UseVisualStyleBackColor = false;
            this.Addbtn.Click += new System.EventHandler(this.Addbtn_Click);
            // 
            // Deletebtn
            // 
            this.Deletebtn.BackColor = System.Drawing.Color.Tomato;
            this.Deletebtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Deletebtn.Location = new System.Drawing.Point(748, 222);
            this.Deletebtn.Name = "Deletebtn";
            this.Deletebtn.Size = new System.Drawing.Size(150, 53);
            this.Deletebtn.TabIndex = 23;
            this.Deletebtn.Text = "Delete";
            this.Deletebtn.UseVisualStyleBackColor = false;
            this.Deletebtn.Click += new System.EventHandler(this.Deletebtn_Click);
            // 
            // Updatebtn
            // 
            this.Updatebtn.BackColor = System.Drawing.Color.MediumPurple;
            this.Updatebtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Updatebtn.Location = new System.Drawing.Point(748, 149);
            this.Updatebtn.Name = "Updatebtn";
            this.Updatebtn.Size = new System.Drawing.Size(150, 53);
            this.Updatebtn.TabIndex = 24;
            this.Updatebtn.Text = "Update";
            this.Updatebtn.UseVisualStyleBackColor = false;
            this.Updatebtn.Click += new System.EventHandler(this.Updatebtn_Click);
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.DarkGray;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Gold;
            this.label7.Location = new System.Drawing.Point(64, 426);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(188, 30);
            this.label7.TabIndex = 25;
            this.label7.Text = "Pending Task";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Orange;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(748, 288);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(150, 53);
            this.button1.TabIndex = 26;
            this.button1.Text = "View ";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // clearbtn
            // 
            this.clearbtn.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.clearbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearbtn.Location = new System.Drawing.Point(748, 363);
            this.clearbtn.Name = "clearbtn";
            this.clearbtn.Size = new System.Drawing.Size(150, 53);
            this.clearbtn.TabIndex = 27;
            this.clearbtn.Text = "Clear";
            this.clearbtn.UseVisualStyleBackColor = false;
            this.clearbtn.Click += new System.EventHandler(this.button2_Click);
            // 
            // CustomerTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightCyan;
            this.ClientSize = new System.Drawing.Size(953, 774);
            this.Controls.Add(this.clearbtn);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.Updatebtn);
            this.Controls.Add(this.Deletebtn);
            this.Controls.Add(this.Addbtn);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.taskDataview);
            this.Controls.Add(this.panel4);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(953, 774);
            this.MinimumSize = new System.Drawing.Size(953, 774);
            this.Name = "CustomerTask";
            this.Text = "CustomerTask";
            this.Load += new System.EventHandler(this.CustomerTask_Load);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.taskDataview)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView taskDataview;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tasknametxt;
        private System.Windows.Forms.TextBox taskIdtxt;
        private System.Windows.Forms.Button upload2btn;
        private System.Windows.Forms.Button upload1btn;
        private System.Windows.Forms.TextBox doctxtPath2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox doctxtPath1;
        private System.Windows.Forms.Button Addbtn;
        private System.Windows.Forms.Button Deletebtn;
        private System.Windows.Forms.Button Updatebtn;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker taskDatetxt;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button clearbtn;
    }
}
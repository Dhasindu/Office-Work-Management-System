namespace Homepageproject
{
    partial class DesignerTask
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
            this.DesignerDatagrid = new System.Windows.Forms.DataGridView();
            this.PdfViewbtn = new System.Windows.Forms.Button();
            this.Acceptnbtn = new System.Windows.Forms.Button();
            this.RejectTaskbtn = new System.Windows.Forms.Button();
            this.RejectReasonPanel = new System.Windows.Forms.Panel();
            this.reasontxt = new System.Windows.Forms.TextBox();
            this.taskidtxt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.RejectSubmissionbtn = new System.Windows.Forms.Button();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DesignerDatagrid)).BeginInit();
            this.RejectReasonPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(87)))), ((int)(((byte)(122)))));
            this.panel4.Controls.Add(this.label2);
            this.panel4.Location = new System.Drawing.Point(-10, -1);
            this.panel4.MaximumSize = new System.Drawing.Size(972, 58);
            this.panel4.MinimumSize = new System.Drawing.Size(972, 58);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(972, 58);
            this.panel4.TabIndex = 23;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Rockwell", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(271, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(441, 55);
            this.label2.TabIndex = 5;
            this.label2.Text = "Designer Task";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DesignerDatagrid
            // 
            this.DesignerDatagrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DesignerDatagrid.Location = new System.Drawing.Point(51, 86);
            this.DesignerDatagrid.Name = "DesignerDatagrid";
            this.DesignerDatagrid.RowHeadersWidth = 51;
            this.DesignerDatagrid.RowTemplate.Height = 24;
            this.DesignerDatagrid.Size = new System.Drawing.Size(840, 265);
            this.DesignerDatagrid.TabIndex = 24;
            this.DesignerDatagrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DesignerDatagrid_CellClick);
            this.DesignerDatagrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DesignerDatagrid_CellContentClick);
            this.DesignerDatagrid.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DesignerDatagrid_RowHeaderMouseClick);
            this.DesignerDatagrid.Click += new System.EventHandler(this.DesignerDatagrid_Click);
            // 
            // PdfViewbtn
            // 
            this.PdfViewbtn.BackColor = System.Drawing.Color.MediumPurple;
            this.PdfViewbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PdfViewbtn.Location = new System.Drawing.Point(719, 376);
            this.PdfViewbtn.Name = "PdfViewbtn";
            this.PdfViewbtn.Size = new System.Drawing.Size(177, 53);
            this.PdfViewbtn.TabIndex = 29;
            this.PdfViewbtn.Text = "View ";
            this.PdfViewbtn.UseVisualStyleBackColor = false;
            this.PdfViewbtn.Click += new System.EventHandler(this.PdfViewbtn_Click);
            // 
            // Acceptnbtn
            // 
            this.Acceptnbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.Acceptnbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Acceptnbtn.ForeColor = System.Drawing.Color.Black;
            this.Acceptnbtn.Location = new System.Drawing.Point(49, 370);
            this.Acceptnbtn.Name = "Acceptnbtn";
            this.Acceptnbtn.Size = new System.Drawing.Size(177, 57);
            this.Acceptnbtn.TabIndex = 30;
            this.Acceptnbtn.Text = "Task Accepts";
            this.Acceptnbtn.UseVisualStyleBackColor = false;
            this.Acceptnbtn.Click += new System.EventHandler(this.Acceptnbtn_Click);
            // 
            // RejectTaskbtn
            // 
            this.RejectTaskbtn.BackColor = System.Drawing.Color.Firebrick;
            this.RejectTaskbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RejectTaskbtn.ForeColor = System.Drawing.Color.Black;
            this.RejectTaskbtn.Location = new System.Drawing.Point(252, 371);
            this.RejectTaskbtn.Name = "RejectTaskbtn";
            this.RejectTaskbtn.Size = new System.Drawing.Size(177, 57);
            this.RejectTaskbtn.TabIndex = 31;
            this.RejectTaskbtn.Text = "Task Rejects";
            this.RejectTaskbtn.UseVisualStyleBackColor = false;
            this.RejectTaskbtn.Click += new System.EventHandler(this.RejectTaskbtn_Click);
            // 
            // RejectReasonPanel
            // 
            this.RejectReasonPanel.BackColor = System.Drawing.Color.Silver;
            this.RejectReasonPanel.Controls.Add(this.reasontxt);
            this.RejectReasonPanel.Controls.Add(this.taskidtxt);
            this.RejectReasonPanel.Controls.Add(this.label3);
            this.RejectReasonPanel.Controls.Add(this.label1);
            this.RejectReasonPanel.Location = new System.Drawing.Point(51, 473);
            this.RejectReasonPanel.Name = "RejectReasonPanel";
            this.RejectReasonPanel.Size = new System.Drawing.Size(572, 267);
            this.RejectReasonPanel.TabIndex = 32;
            // 
            // reasontxt
            // 
            this.reasontxt.Location = new System.Drawing.Point(83, 106);
            this.reasontxt.Multiline = true;
            this.reasontxt.Name = "reasontxt";
            this.reasontxt.Size = new System.Drawing.Size(476, 152);
            this.reasontxt.TabIndex = 3;
            // 
            // taskidtxt
            // 
            this.taskidtxt.Location = new System.Drawing.Point(102, 20);
            this.taskidtxt.Multiline = true;
            this.taskidtxt.Name = "taskidtxt";
            this.taskidtxt.Size = new System.Drawing.Size(96, 34);
            this.taskidtxt.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 22);
            this.label3.TabIndex = 1;
            this.label3.Text = "Reason :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "TaskId :";
            // 
            // RejectSubmissionbtn
            // 
            this.RejectSubmissionbtn.BackColor = System.Drawing.Color.Gold;
            this.RejectSubmissionbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RejectSubmissionbtn.Location = new System.Drawing.Point(719, 687);
            this.RejectSubmissionbtn.Name = "RejectSubmissionbtn";
            this.RejectSubmissionbtn.Size = new System.Drawing.Size(177, 53);
            this.RejectSubmissionbtn.TabIndex = 33;
            this.RejectSubmissionbtn.Text = "Submit";
            this.RejectSubmissionbtn.UseVisualStyleBackColor = false;
            this.RejectSubmissionbtn.Click += new System.EventHandler(this.RejectSubmissionbtn_Click);
            // 
            // DesignerTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightCyan;
            this.ClientSize = new System.Drawing.Size(953, 777);
            this.Controls.Add(this.RejectSubmissionbtn);
            this.Controls.Add(this.RejectReasonPanel);
            this.Controls.Add(this.RejectTaskbtn);
            this.Controls.Add(this.Acceptnbtn);
            this.Controls.Add(this.PdfViewbtn);
            this.Controls.Add(this.DesignerDatagrid);
            this.Controls.Add(this.panel4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(953, 777);
            this.MinimumSize = new System.Drawing.Size(953, 777);
            this.Name = "DesignerTask";
            this.Text = "DesignerTask";
            this.Load += new System.EventHandler(this.DesignerTask_Load);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DesignerDatagrid)).EndInit();
            this.RejectReasonPanel.ResumeLayout(false);
            this.RejectReasonPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView DesignerDatagrid;
        private System.Windows.Forms.Button PdfViewbtn;
        private System.Windows.Forms.Button Acceptnbtn;
        private System.Windows.Forms.Button RejectTaskbtn;
        private System.Windows.Forms.Panel RejectReasonPanel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox reasontxt;
        private System.Windows.Forms.TextBox taskidtxt;
        private System.Windows.Forms.Button RejectSubmissionbtn;
    }
}
namespace Homepageproject
{
    partial class Adminpage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Adminpage));
            this.panel1 = new System.Windows.Forms.Panel();
            this.DseignerTeambtn = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button7 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.mainpanel = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.mainpanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(87)))), ((int)(((byte)(122)))));
            this.panel1.Controls.Add(this.DseignerTeambtn);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.button7);
            this.panel1.Controls.Add(this.button9);
            this.panel1.Controls.Add(this.button10);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(363, 777);
            this.panel1.TabIndex = 13;
            // 
            // DseignerTeambtn
            // 
            this.DseignerTeambtn.Font = new System.Drawing.Font("Rockwell", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DseignerTeambtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.DseignerTeambtn.Location = new System.Drawing.Point(19, 465);
            this.DseignerTeambtn.Name = "DseignerTeambtn";
            this.DseignerTeambtn.Padding = new System.Windows.Forms.Padding(8, 4, 4, 4);
            this.DseignerTeambtn.Size = new System.Drawing.Size(309, 63);
            this.DseignerTeambtn.TabIndex = 14;
            this.DseignerTeambtn.Text = " Designer Team";
            this.DseignerTeambtn.UseVisualStyleBackColor = true;
            this.DseignerTeambtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Homepageproject.Properties.Resources.administrator;
            this.pictureBox1.Location = new System.Drawing.Point(63, 62);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(113, 99);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Rockwell", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(182, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 33);
            this.label1.TabIndex = 12;
            this.label1.Text = "Admin";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // button7
            // 
            this.button7.Font = new System.Drawing.Font("Rockwell", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button7.Image = ((System.Drawing.Image)(resources.GetObject("button7.Image")));
            this.button7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button7.Location = new System.Drawing.Point(20, 666);
            this.button7.Name = "button7";
            this.button7.Padding = new System.Windows.Forms.Padding(8, 4, 4, 4);
            this.button7.Size = new System.Drawing.Size(309, 63);
            this.button7.TabIndex = 4;
            this.button7.Text = "Log Out";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button9
            // 
            this.button9.Font = new System.Drawing.Font("Rockwell", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button9.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button9.Location = new System.Drawing.Point(20, 375);
            this.button9.Name = "button9";
            this.button9.Padding = new System.Windows.Forms.Padding(8, 4, 4, 4);
            this.button9.Size = new System.Drawing.Size(309, 63);
            this.button9.TabIndex = 2;
            this.button9.Text = " Managers";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button10
            // 
            this.button10.Font = new System.Drawing.Font("Rockwell", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button10.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button10.Location = new System.Drawing.Point(18, 281);
            this.button10.Name = "button10";
            this.button10.Padding = new System.Windows.Forms.Padding(8, 4, 4, 4);
            this.button10.Size = new System.Drawing.Size(309, 63);
            this.button10.TabIndex = 1;
            this.button10.Text = "Customers";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // mainpanel
            // 
            this.mainpanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.mainpanel.Controls.Add(this.label2);
            this.mainpanel.Controls.Add(this.panel4);
            this.mainpanel.Location = new System.Drawing.Point(360, 0);
            this.mainpanel.Name = "mainpanel";
            this.mainpanel.Size = new System.Drawing.Size(958, 753);
            this.mainpanel.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(269, 294);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(430, 79);
            this.label2.TabIndex = 18;
            this.label2.Text = "Welcome Admin";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(87)))), ((int)(((byte)(122)))));
            this.panel4.Location = new System.Drawing.Point(-7, 0);
            this.panel4.MaximumSize = new System.Drawing.Size(972, 58);
            this.panel4.MinimumSize = new System.Drawing.Size(972, 58);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(972, 58);
            this.panel4.TabIndex = 17;
            // 
            // Adminpage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(1318, 753);
            this.Controls.Add(this.mainpanel);
            this.Controls.Add(this.panel1);
            this.MaximumSize = new System.Drawing.Size(1336, 800);
            this.MinimumSize = new System.Drawing.Size(1336, 800);
            this.Name = "Adminpage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Adminpage";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.mainpanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Panel mainpanel;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button DseignerTeambtn;
    }
}
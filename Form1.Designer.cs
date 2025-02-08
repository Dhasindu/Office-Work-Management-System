namespace Homepageproject
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.UserNametext = new System.Windows.Forms.Label();
            this.Username = new System.Windows.Forms.TextBox();
            this.pswdtxt = new System.Windows.Forms.Label();
            this.passwordtxt = new System.Windows.Forms.TextBox();
            this.paswdshow = new System.Windows.Forms.CheckBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.textregister = new System.Windows.Forms.Label();
            this.btnlogreg = new System.Windows.Forms.Button();
            this.pawsdlogo = new System.Windows.Forms.Label();
            this.userLogo = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 2000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Rockwell", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Orange;
            this.label1.Location = new System.Drawing.Point(699, 154);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(411, 66);
            this.label1.TabIndex = 6;
            this.label1.Text = "Welcome Back!";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // UserNametext
            // 
            this.UserNametext.BackColor = System.Drawing.Color.Transparent;
            this.UserNametext.Font = new System.Drawing.Font("Microsoft YaHei", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserNametext.ForeColor = System.Drawing.Color.Orange;
            this.UserNametext.Location = new System.Drawing.Point(754, 262);
            this.UserNametext.Name = "UserNametext";
            this.UserNametext.Size = new System.Drawing.Size(200, 54);
            this.UserNametext.TabIndex = 7;
            this.UserNametext.Text = "Username\r\n";
            this.UserNametext.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.UserNametext.Click += new System.EventHandler(this.UserNametext_Click);
            // 
            // Username
            // 
            this.Username.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Username.Location = new System.Drawing.Point(840, 319);
            this.Username.Multiline = true;
            this.Username.Name = "Username";
            this.Username.Size = new System.Drawing.Size(362, 34);
            this.Username.TabIndex = 8;
            // 
            // pswdtxt
            // 
            this.pswdtxt.BackColor = System.Drawing.Color.Transparent;
            this.pswdtxt.Font = new System.Drawing.Font("Microsoft YaHei", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pswdtxt.ForeColor = System.Drawing.Color.Orange;
            this.pswdtxt.Location = new System.Drawing.Point(754, 389);
            this.pswdtxt.Name = "pswdtxt";
            this.pswdtxt.Size = new System.Drawing.Size(200, 41);
            this.pswdtxt.TabIndex = 9;
            this.pswdtxt.Text = "Password\r\n";
            this.pswdtxt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // passwordtxt
            // 
            this.passwordtxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordtxt.Location = new System.Drawing.Point(840, 443);
            this.passwordtxt.Name = "passwordtxt";
            this.passwordtxt.Size = new System.Drawing.Size(362, 30);
            this.passwordtxt.TabIndex = 10;
            this.passwordtxt.UseSystemPasswordChar = true;
            // 
            // paswdshow
            // 
            this.paswdshow.AutoSize = true;
            this.paswdshow.BackColor = System.Drawing.Color.Transparent;
            this.paswdshow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.paswdshow.Font = new System.Drawing.Font("Times New Roman", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paswdshow.ForeColor = System.Drawing.Color.White;
            this.paswdshow.Location = new System.Drawing.Point(1071, 478);
            this.paswdshow.Margin = new System.Windows.Forms.Padding(4);
            this.paswdshow.Name = "paswdshow";
            this.paswdshow.Size = new System.Drawing.Size(131, 22);
            this.paswdshow.TabIndex = 13;
            this.paswdshow.Text = " Show Password";
            this.paswdshow.UseVisualStyleBackColor = false;
            this.paswdshow.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // btnLogin
            // 
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogin.Font = new System.Drawing.Font("Rockwell", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.ForeColor = System.Drawing.Color.Orange;
            this.btnLogin.Location = new System.Drawing.Point(1024, 548);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(169, 43);
            this.btnLogin.TabIndex = 14;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // textregister
            // 
            this.textregister.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textregister.Location = new System.Drawing.Point(837, 654);
            this.textregister.Name = "textregister";
            this.textregister.Size = new System.Drawing.Size(203, 27);
            this.textregister.TabIndex = 16;
            this.textregister.Text = "Don\'t have an account?";
            this.textregister.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnlogreg
            // 
            this.btnlogreg.Font = new System.Drawing.Font("Rockwell", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnlogreg.Location = new System.Drawing.Point(1061, 654);
            this.btnlogreg.Name = "btnlogreg";
            this.btnlogreg.Size = new System.Drawing.Size(132, 27);
            this.btnlogreg.TabIndex = 17;
            this.btnlogreg.Text = "Register here";
            this.btnlogreg.UseVisualStyleBackColor = true;
            this.btnlogreg.Click += new System.EventHandler(this.btnlogreg_Click);
            // 
            // pawsdlogo
            // 
            this.pawsdlogo.BackColor = System.Drawing.Color.AliceBlue;
            this.pawsdlogo.Image = ((System.Drawing.Image)(resources.GetObject("pawsdlogo.Image")));
            this.pawsdlogo.Location = new System.Drawing.Point(783, 438);
            this.pawsdlogo.Name = "pawsdlogo";
            this.pawsdlogo.Size = new System.Drawing.Size(51, 34);
            this.pawsdlogo.TabIndex = 12;
            // 
            // userLogo
            // 
            this.userLogo.BackColor = System.Drawing.Color.AliceBlue;
            this.userLogo.Image = ((System.Drawing.Image)(resources.GetObject("userLogo.Image")));
            this.userLogo.Location = new System.Drawing.Point(783, 318);
            this.userLogo.Name = "userLogo";
            this.userLogo.Size = new System.Drawing.Size(51, 34);
            this.userLogo.TabIndex = 11;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1335, 797);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Homepageproject.Properties.Resources.pngtree_office_people_teamwork_image_2245594;
            this.pictureBox2.Location = new System.Drawing.Point(82, 112);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(597, 588);
            this.pictureBox2.TabIndex = 19;
            this.pictureBox2.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1335, 798);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.btnlogreg);
            this.Controls.Add(this.textregister);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.paswdshow);
            this.Controls.Add(this.pawsdlogo);
            this.Controls.Add(this.userLogo);
            this.Controls.Add(this.passwordtxt);
            this.Controls.Add(this.pswdtxt);
            this.Controls.Add(this.Username);
            this.Controls.Add(this.UserNametext);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.IsMdiContainer = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form02";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label UserNametext;
        private System.Windows.Forms.TextBox Username;
        private System.Windows.Forms.Label pswdtxt;
        private System.Windows.Forms.TextBox passwordtxt;
        private System.Windows.Forms.Label userLogo;
        private System.Windows.Forms.Label pawsdlogo;
        private System.Windows.Forms.CheckBox paswdshow;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label textregister;
        private System.Windows.Forms.Button btnlogreg;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}


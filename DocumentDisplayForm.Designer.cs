namespace Homepageproject
{
    partial class DocumentDisplayForm
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
            this.PdfReaderTitle = new System.Windows.Forms.Label();
            this.pdfViewer1 = new Spire.PdfViewer.Forms.PdfViewer();
            this.Backbtn = new System.Windows.Forms.Button();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(87)))), ((int)(((byte)(122)))));
            this.panel4.Controls.Add(this.Backbtn);
            this.panel4.Controls.Add(this.PdfReaderTitle);
            this.panel4.Location = new System.Drawing.Point(2, 0);
            this.panel4.MaximumSize = new System.Drawing.Size(950, 58);
            this.panel4.MinimumSize = new System.Drawing.Size(950, 58);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(950, 58);
            this.panel4.TabIndex = 20;
            // 
            // PdfReaderTitle
            // 
            this.PdfReaderTitle.Font = new System.Drawing.Font("Rockwell", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PdfReaderTitle.ForeColor = System.Drawing.Color.White;
            this.PdfReaderTitle.Location = new System.Drawing.Point(260, 3);
            this.PdfReaderTitle.Name = "PdfReaderTitle";
            this.PdfReaderTitle.Size = new System.Drawing.Size(441, 55);
            this.PdfReaderTitle.TabIndex = 5;
            this.PdfReaderTitle.Text = "Customer Task Managment";
            this.PdfReaderTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.PdfReaderTitle.Click += new System.EventHandler(this.PdfReaderTitle_Click);
            // 
            // pdfViewer1
            // 
            this.pdfViewer1.FindTextHighLightColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(153)))), ((int)(((byte)(193)))), ((int)(((byte)(218)))));
            this.pdfViewer1.FormFillEnabled = false;
            this.pdfViewer1.IgnoreCase = false;
            this.pdfViewer1.IsToolBarVisible = true;
            this.pdfViewer1.Location = new System.Drawing.Point(9, 66);
            this.pdfViewer1.MaximumSize = new System.Drawing.Size(930, 800);
            this.pdfViewer1.MinimumSize = new System.Drawing.Size(930, 800);
            this.pdfViewer1.MultiPagesThreshold = 60;
            this.pdfViewer1.Name = "pdfViewer1";
            this.pdfViewer1.OnRenderPageExceptionEvent = null;
            this.pdfViewer1.Size = new System.Drawing.Size(930, 800);
            this.pdfViewer1.TabIndex = 21;
            this.pdfViewer1.Text = "pdfViewer1";
            this.pdfViewer1.Threshold = 60;
            this.pdfViewer1.ViewerBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            // 
            // Backbtn
            // 
            this.Backbtn.Image = global::Homepageproject.Properties.Resources.close2;
            this.Backbtn.Location = new System.Drawing.Point(887, 12);
            this.Backbtn.Name = "Backbtn";
            this.Backbtn.Size = new System.Drawing.Size(41, 32);
            this.Backbtn.TabIndex = 6;
            this.Backbtn.UseVisualStyleBackColor = true;
            this.Backbtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // DocumentDisplayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(953, 800);
            this.Controls.Add(this.pdfViewer1);
            this.Controls.Add(this.panel4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(953, 800);
            this.MinimumSize = new System.Drawing.Size(953, 800);
            this.Name = "DocumentDisplayForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "DocumentDisplayForm";
            this.Load += new System.EventHandler(this.DocumentDisplayForm_Load);
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label PdfReaderTitle;
        private System.Windows.Forms.Button Backbtn;
        private Spire.PdfViewer.Forms.PdfViewer pdfViewer1;
    }
}
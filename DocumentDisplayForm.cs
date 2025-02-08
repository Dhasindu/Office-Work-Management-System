using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Homepageproject
{
    public partial class DocumentDisplayForm : Form
    {
        private SqlConnection connetion = DBclass.ConnDatabase();
        private int TaskId;
        private int DocId;

        public DocumentDisplayForm(int id, int docId)
        {
            InitializeComponent();
            TaskId = id;
            PdfReaderTitle.Text = "Customer Document Reader";//Initially this Title of the form Change
            this.Load += new System.EventHandler(this.DocumentDisplayForm_Load);
            DocId = docId;
        }

        private void PdfReaderTitle_Click(object sender, EventArgs e)
        {

        }

        private void DocumentDisplayForm_Load(object sender, EventArgs e)
        {
            Task.DisplayDocument(connetion, TaskId,DocId, pdfViewer1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
         
            this.Dispose();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Homepageproject
{
    public partial class CustomerTask : Form
    {
       private SqlConnection connetion = DBclass.ConnDatabase();
       private SqlDataAdapter adapter;
        private string Filenames1="", Filenames2="";
        public CustomerTask()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.CustomerTask_Load);
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Addbtn_Click(object sender, EventArgs e)
        {
            // Get Current date
             DateTime currentDate = DateTime.Now;

            if (!string.IsNullOrWhiteSpace(tasknametxt.Text) && !string.IsNullOrWhiteSpace(taskDatetxt.Text) && !string.IsNullOrWhiteSpace(doctxtPath1.Text))
            {
                DateTime.TryParse(taskDatetxt.Text, out DateTime UserDate);
                if (UserDate>currentDate)
                { 
                    bool vaild=Task.AddTask(connetion, tasknametxt, taskDatetxt, Customer.CurrentCustomer.id, Filenames1, Filenames2);
                    Task.LoadDate(connetion, adapter, taskDataview);
                    if (vaild)
                    {
                        MessageBox.Show("Data is Successfully Add", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        tasknametxt.Text = "";
                        taskDatetxt.Text = "";
                        doctxtPath1.Text = "";
                        doctxtPath2.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Data  Adding Unsuccessfully", "Fails", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Date is not Valid", "Warming", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Task Name , Task Date/Time && Task File  is Required","Warming",MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void CustomerTask_Load(object sender, EventArgs e)
        {
            Task.LoadDate(connetion, adapter, taskDataview);
        }

        private void upload1btn_Click(object sender, EventArgs e)
        {
           Filenames1= UploadFiles(doctxtPath1);
        }

        private void upload2btn_Click(object sender, EventArgs e)
        {
            Filenames2=UploadFiles(doctxtPath2);
        }

        private void Deletebtn_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrWhiteSpace(taskIdtxt.Text))
            {
                DialogResult DlgRsult = MessageBox.Show("Do you need Delete Following Data?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult.Yes == DlgRsult)
                {
                    bool vaild = Task.DeleteTask(connetion, taskIdtxt);
                    if (vaild)
                    {
                        MessageBox.Show("Data is Successfully Deleted", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Task.LoadDate(connetion, adapter, taskDataview);
                        taskIdtxt.Text = "";
                        tasknametxt.Text = "";
                        taskDatetxt.Text = "";
                        doctxtPath1.Text = "";
                        doctxtPath2.Text = "";
                    }
                    
                }
            }
            else
            {
                MessageBox.Show("Select the row to Delete", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (taskDataview.SelectedRows.Count != 0)
            {
                int num = 0;
               
                int id = (int)taskDataview.SelectedRows[0].Cells["TaskId"].Value;
                if (id != 0)
                { 
                    DialogResult response1 = MessageBox.Show($"Do you need to View File :{taskDataview.SelectedRows[0].Cells["Document1"].Value}?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (response1 == DialogResult.Yes)
                    {
                        num=1;
                        DocumentDisplayForm ReadView = new DocumentDisplayForm(id,num);
                        ReadView.Show();

                    }
                    else
                    {
                        object doc1 = taskDataview.SelectedRows[0].Cells["Document2"].Value;//Casting not suitable beacuse If the value is of a different type (e.g., int, DateTime, or DBNull), a InvalidCastException will occur.
                        if (!string.IsNullOrWhiteSpace(doc1.ToString()))
                        {
                            DialogResult response2 = MessageBox.Show($"Do you need to View File :{taskDataview.SelectedRows[0].Cells["Document2"].Value}?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (response2 == DialogResult.Yes)
                            {
                                num = 2;
                                DocumentDisplayForm ReadView = new DocumentDisplayForm(id, num);
                                ReadView.Show();

                            }
                        }
                     
                    }
                }
                else
                {
                    MessageBox.Show($"Select Particular Row Relalted to Document", "Failures", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Please select a row .", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void taskDataview_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewRow row = taskDataview.Rows[e.RowIndex];
                taskIdtxt.Text = row.Cells["TaskId"].FormattedValue.ToString();
                tasknametxt.Text= row.Cells["TaskName"].FormattedValue.ToString();
                taskDatetxt.Text = row.Cells["PublishedDate"].FormattedValue.ToString();
                doctxtPath1.Text = row.Cells["Document1"].FormattedValue.ToString();
                doctxtPath2.Text = row.Cells["Document2"].FormattedValue.ToString();
            }
        }

        private void Updatebtn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(tasknametxt.Text) && !string.IsNullOrWhiteSpace(taskDatetxt.Text) && !string.IsNullOrWhiteSpace(doctxtPath1.Text))
            {
                bool valid=Task.UpdateTask(connetion, tasknametxt, taskDatetxt, taskIdtxt, Filenames1, Filenames2);
                if (!valid)
                {
                    MessageBox.Show("Data is not Successfully update", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                Task.LoadDate(connetion, adapter, taskDataview);
                MessageBox.Show("Data is Successfully update", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                taskIdtxt.Text = "";
                tasknametxt.Text = "";
                taskDatetxt.Text = "";
                doctxtPath1.Text = "";
                doctxtPath2.Text = "";
            }
            else
            {
                MessageBox.Show("Select the row to Update", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult DlgRsult = MessageBox.Show("Do you need to clear all data in textfeild", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(DialogResult.Yes == DlgRsult)
            {
                taskIdtxt.Text = "";
                tasknametxt.Text = "";
                taskDatetxt.Text = "";
                doctxtPath1.Text = "";
                doctxtPath2.Text = "";
            }
            

        }

        private void taskDataview_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private static string UploadFiles(System.Windows.Forms.TextBox doctxtPath)
         {
            using (OpenFileDialog dlg = new OpenFileDialog
            {
                Filter = "Text Documents (*.pdf)|*.pdf",
                ValidateNames = true
            })
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    DialogResult dialog = MessageBox.Show("Are you sure you want to upload this file?",
                                                          "Upload",
                                                          MessageBoxButtons.OKCancel);
                    if (dialog == DialogResult.OK)
                    {
                        string fileName = Path.GetFileName(dlg.FileName); // Extracts only the file name
                        doctxtPath.Text = fileName;
                       // Filenames = dlg.FileName;// Display only the file name in the TextBox
                                                 // UploadFile(dlg.FileName); // Pass the full path for upload

                        MessageBox.Show("File uploaded successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return dlg.FileName;
                    }
                    else
                    {
                        MessageBox.Show("File upload canceled.", "Canceled", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
        }

    }
}

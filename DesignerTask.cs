using Microsoft.IdentityModel.Tokens;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Homepageproject
{
    public partial class DesignerTask : Form
    {
        SqlConnection connection = DBclass.ConnDatabase();
        private SqlDataAdapter adapter;
        private string CustomerNumber;
        private string CustomerName;
        private string status;
        private string TeamName;
        private string TaskName;
        private string DelveryDate;
        private string publishedDate;
        TaskWhatsAppNotification notfiy = new TaskWhatsAppNotification();
        public DesignerTask()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.DesignerTask_Load);
        }

        private void DesignerTask_Load(object sender, EventArgs e)
        {
            LoadDesignerData();
            RejectReasonPanel.Visible = false;
            RejectSubmissionbtn.Visible = false;

        }

        private void LoadDesignerData()
        {
            try
            {
                // Define the SQL query with the required conditions
                string query = @"SELECT 
                                    T.TaskId, 
                                    C.CompanyName, 
                                    T.TaskName,
                                    T.Document1, 
                                    T.Document2, 
                                    T.PublishedDate,
                                    T.EndDate,
                                    TP.TeamProjectStatus, 
                                    TM.TeamName,
                                    C.Phone,
                                    A.Username
                                FROM TaskTable T
                                JOIN Customer C ON T.CustId = C.AuthId
                                JOIN UserAuthDataTable A ON A.Id = C.AuthId
                                JOIN TeamProjectsTable TP ON T.TaskId = TP.TaskId
                                JOIN TeamTable TM ON TP.TeamId = TM.TeamId
                                WHERE TM.TeamId = (SELECT TeamId FROM DesinerTable WHERE AuthId = @id) 
                                AND TP.TeamProjectStatus = @Status";


                
                // Create the SqlDataAdapter
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                {
                    // Use parameters to prevent SQL injection
                    adapter.SelectCommand.Parameters.AddWithValue("@id",DesignerClass.CurrentDesigner.id);
                    adapter.SelectCommand.Parameters.AddWithValue("@Status", "proceeding");

                    // Create a DataTable to hold the query result
                    DataTable dt = new DataTable();

                    // Fill the DataTable with query result
                    adapter.Fill(dt);

                    // Bind the DataTable to the DataGridView
                    DesignerDatagrid.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error");
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        private void PdfViewbtn_Click(object sender, EventArgs e)
        {
            if (DesignerDatagrid.SelectedRows.Count != 0)
            {
                int num = 0;

                int id = (int)DesignerDatagrid.SelectedRows[0].Cells["TaskId"].Value;
                if (id != 0)
                {
                    DialogResult response1 = MessageBox.Show($"Do you need to View File :{DesignerDatagrid.SelectedRows[0].Cells["Document1"].Value}?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (response1 == DialogResult.Yes)
                    {
                        num = 1;
                        DocumentDisplayForm ReadView = new DocumentDisplayForm(id, num);
                        ReadView.Show();

                    }
                    else
                    {
                        object doc1 = DesignerDatagrid.SelectedRows[0].Cells["Document2"].Value;//Casting not suitable beacuse If the value is of a different type (e.g., int, DateTime, or DBNull), a InvalidCastException will occur.
                        if (!string.IsNullOrWhiteSpace(doc1.ToString()))
                        {
                            DialogResult response2 = MessageBox.Show($"Do you need to View File :{DesignerDatagrid.SelectedRows[0].Cells["Document2"].Value}?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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

        private void RejectTaskbtn_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Tasks" + CustomerNumber + CustomerName + status + TeamName + TaskName + DelveryDate + publishedDate);
            RejectReasonPanel.Visible = true; // Show the panel
            RejectSubmissionbtn.Visible = true;
        }

        private void Acceptnbtn_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(CustomerNumber) && string.IsNullOrEmpty(CustomerName) && string.IsNullOrEmpty(status) && string.IsNullOrEmpty(TeamName) && string.IsNullOrEmpty(DelveryDate) && string.IsNullOrEmpty(publishedDate))
            {
                MessageBox.Show("Fields Cannot be Empty,Select Row Content to Accept Task.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (DesignerDatagrid.SelectedRows.Count != 0)
            {
                int id = (int)DesignerDatagrid.SelectedRows[0].Cells["TaskId"].Value;
                if (id != 0)
                {
                    DialogResult response1 = MessageBox.Show($"Do you need to Accept this Task?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (response1 == DialogResult.Yes)
                    {
                        bool vaild=DesignerTaskAccept(id);
                        if (vaild)
                        {
                            MessageBox.Show($"Task is SuccessFully Accepted", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadDesignerData();
                            taskidtxt.Text = "";
                            

                            DialogResult response2 = MessageBox.Show($"Do you need to Send Notification to Customer?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (response2 == DialogResult.Yes)
                            {
                               notfiy.SendWhatsAppMessage("APPROVED", CustomerNumber, TaskName, CustomerName, TeamName, DelveryDate, publishedDate,"");
                            }
                        }
                        else
                        {
                            MessageBox.Show($"Task is  Accept Error", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            taskidtxt.Text = "";
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please select a Task row to Accept .", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Please select a Task row to Accept .", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private bool DesignerTaskAccept(int id)
        {
            

            string query1 = "UPDATE TeamProjectsTable SET TeamProjectStatus='Ongoing' WHERE TaskId=@id";
            string query2 = "UPDATE TaskTable SET TaskStatus='Ongoing' WHERE TaskId=@id";


           
                try
                {
                    connection.Open();

                    using (SqlCommand cmd1 = new SqlCommand(query1, connection))
                    using (SqlCommand cmd2 = new SqlCommand(query2, connection))
                   
                    {
                        // Add the parameter for all queries
                        cmd1.Parameters.AddWithValue("@id", id);
                        cmd2.Parameters.AddWithValue("@id", id);
                        

                      

                        // Check if updates were successful
                        if (cmd1.ExecuteNonQuery() > 0 && cmd2.ExecuteNonQuery() > 0)
                        {
                           return true;
                        }
                    }
                    return false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Database Update Error");
                    return false;   
                }
                finally
                {
                    connection.Close();
                }
            

            
        }

        private void DesignerDatagrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewRow row = DesignerDatagrid.Rows[e.RowIndex];
                taskidtxt.Text = row.Cells["TaskId"].FormattedValue.ToString();
                CustomerName= row.Cells["Username"].FormattedValue.ToString();
                CustomerNumber = row.Cells["Phone"].FormattedValue.ToString();
                TeamName = row.Cells["TeamName"].FormattedValue.ToString();
                TaskName = row.Cells["TaskName"].FormattedValue.ToString();
                status = row.Cells["TeamProjectStatus"].FormattedValue.ToString();
                DelveryDate = row.Cells["EndDate"].FormattedValue.ToString();
                publishedDate = row.Cells["PublishedDate"].FormattedValue.ToString();



            }
        }

        private void RejectSubmissionbtn_Click(object sender, EventArgs e)
        {
            if (DesignerDatagrid.SelectedRows.Count != 0)
            {
                int id = (int)DesignerDatagrid.SelectedRows[0].Cells["TaskId"].Value;
                if (id != 0 && !string.IsNullOrEmpty(taskidtxt.Text))
                {
                    if (string.IsNullOrEmpty(reasontxt.Text.Trim()))
                    {
                        MessageBox.Show("Task Rejection Reason is Required..", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    DialogResult response1 = MessageBox.Show($"Do you need to Reject this Task?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (response1 == DialogResult.Yes)
                    {
                        bool valid = RejectionReasonUpdate(id, reasontxt.Text);

                        if (valid)
                        {
                            MessageBox.Show($"Task is  Rejected", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadDesignerData();
                            taskidtxt.Text = "";
                            reasontxt.Text = "";
                        }
                        else
                        {
                            MessageBox.Show($"Task is  Rejection Error", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            taskidtxt.Text = "";
                            reasontxt.Text = "";
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please select a Task row to Reject .", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Please select a Task row to Reject .", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private bool RejectionReasonUpdate(int id,string reason)
        {
            string query = "UPDATE TeamProjectsTable SET TeamProjectStatus=@status ,RejectReason=@reason WHERE TaskId=@id";
            try
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    // Add parameters to prevent SQL injection
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@status", "Rejected");
                    cmd.Parameters.AddWithValue("@reason", reason);

                   
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Database Update Error");
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        private void DesignerDatagrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewRow row = DesignerDatagrid.Rows[e.RowIndex];
                taskidtxt.Text = row.Cells["TaskId"].FormattedValue.ToString();
                CustomerName = row.Cells["Username"].FormattedValue.ToString();
                CustomerNumber = row.Cells["Phone"].FormattedValue.ToString();
                TeamName = row.Cells["TeamName"].FormattedValue.ToString();
                TaskName = row.Cells["TaskName"].FormattedValue.ToString();
                status = row.Cells["TeamProjectStatus"].FormattedValue.ToString();
                DelveryDate = row.Cells["EndDate"].FormattedValue.ToString();
                publishedDate = row.Cells["PublishedDate"].FormattedValue.ToString();
            }

        }

        private void DesignerDatagrid_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
        }

        private void DesignerDatagrid_Click(object sender, EventArgs e)
        {

        }
    }
}

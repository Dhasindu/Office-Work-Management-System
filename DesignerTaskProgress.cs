using Microsoft.IdentityModel.Tokens;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Homepageproject
{
    
    public partial class DesignerTaskProgress : Form
    {

        SqlConnection connection = DBclass.ConnDatabase();
        private SqlDataAdapter adapter;
        TaskWhatsAppNotification notfiy = new TaskWhatsAppNotification();
        private string taskidtxt;
        private string deliveryDate;
        private string PublishedDate;
        private string UpdateDate;
        public DesignerTaskProgress()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.DesignerTaskProgress_Load);
        }

        private void OngoingtStatusbtn_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(taskidtxt) && string.IsNullOrEmpty(CustomerNametxt.Text) && string.IsNullOrEmpty(CusNumbertxt.Text) && string.IsNullOrEmpty(TaskNametxt.Text) && string.IsNullOrEmpty(TaskNametxt.Text))
            {
                MessageBox.Show("Fields Cannot be Empty,Select Row Content to Accept Task.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult response = MessageBox.Show($"Do you need to Send Notification to Customer?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (response == DialogResult.Yes)
            {
                if (!string.IsNullOrEmpty(UpdateDate))
                {
                    //notfiy.SendWhatsAppMessage("ONGOING", CusNumbertxt.Text, TaskNametxt.Text, CustomerNametxt.Text, TaskNametxt.Text, deliveryDate, UpdateDate, ongoingDatetxt.Text);
                    notfiy.SendWhatsAppMessage("ONGOING","0761576106", TaskNametxt.Text, CustomerNametxt.Text, TaskNametxt.Text, EndDatetxt.Text, UpdateDate, ongoingDatetxt.Text);
                }
                else
                {
                    // notfiy.SendWhatsAppMessage("ONGOING", CusNumbertxt.Text, TaskNametxt.Text, CustomerNametxt.Text, TaskNametxt.Text, deliveryDate, PublishedDate, ongoingDatetxt.Text);
                    notfiy.SendWhatsAppMessage("ONGOING","0761576106", TaskNametxt.Text, CustomerNametxt.Text, TaskNametxt.Text, EndDatetxt.Text, publisheddatetxt.Text, ongoingDatetxt.Text);

                }
                LoadDesignerData();
                TaskNametxt.Text = "";
                CustomerNametxt.Text = "";
                TaskNametxt.Text = "";
                EndDatetxt.Text = "";
                UpdateDate = "";
                ongoingDatetxt.Text = "";
                publisheddatetxt.Text = "";
            }
        }

        private void DesignerTaskProgress_Load(object sender, EventArgs e)
        {
            LoadDesignerData();
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
                                    A.Username,
                                    T.UpdatedDate
                                FROM TaskTable T
                                JOIN Customer C ON T.CustId = C.AuthId
                                JOIN UserAuthDataTable A ON A.Id = C.AuthId
                                JOIN TeamProjectsTable TP ON T.TaskId = TP.TaskId
                                JOIN TeamTable TM ON TP.TeamId = TM.TeamId
                                WHERE TM.TeamId = (SELECT TeamId FROM DesinerTable WHERE AuthId = @id) 
                                AND TP.TeamProjectStatus = @Status;
                                ";

                // Create the SqlDataAdapter
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                {
                    // Use parameters to prevent SQL injection
                    adapter.SelectCommand.Parameters.AddWithValue("@id", DesignerClass.CurrentDesigner.id);
                    adapter.SelectCommand.Parameters.AddWithValue("@Status", "Ongoing");

                    // Create a DataTable to hold the query result
                    DataTable dt = new DataTable();

                    // Fill the DataTable with query result
                    adapter.Fill(dt);

                    // Bind the DataTable to the DataGridView
                    AcceptsTaskGrid.DataSource = dt;
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

        private void AcceptsTaskGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewRow row = AcceptsTaskGrid.Rows[e.RowIndex];
                taskidtxt = row.Cells["TaskId"].FormattedValue.ToString();
                CustomerNametxt.Text = row.Cells["Username"].FormattedValue.ToString();
                CusNumbertxt.Text = row.Cells["Phone"].FormattedValue.ToString();
                //DesignerNametxt.Text = row.Cells["Phone"].FormattedValue.ToString();
                TaskTeamtxt.Text = row.Cells["TeamName"].FormattedValue.ToString();
                TaskNametxt.Text = row.Cells["TaskName"].FormattedValue.ToString();
                EndDatetxt.Text = row.Cells["EndDate"].FormattedValue.ToString();
                publisheddatetxt.Text = row.Cells["PublishedDate"].FormattedValue.ToString();
                UpdateDate = row.Cells["UpdatedDate"].FormattedValue.ToString();

            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void TaskCompleteBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(taskidtxt) && string.IsNullOrEmpty(CustomerNametxt.Text) && string.IsNullOrEmpty(CusNumbertxt.Text) && string.IsNullOrEmpty(TaskNametxt.Text) && string.IsNullOrEmpty(TaskNametxt.Text))
            {
                MessageBox.Show("Fields Cannot be Empty,Select Row Content to Accept Task.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string id = taskidtxt;
            if (id != "")
            {
                DialogResult response1 = MessageBox.Show($"Do you need to set this Task Complete?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (response1 == DialogResult.Yes)
                {
                    bool vaild = DesignerTaskAccept(id);
                    if (vaild)
                    {
                        MessageBox.Show($"Task is SuccessFully Accepted", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDesignerData();
                        DialogResult response2 = MessageBox.Show($"Do you need to Send Notification to Customer?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (response2 == DialogResult.Yes)
                        {

                            //notfiy.SendWhatsAppMessage("COMPLETED", CusNumbertxt.Text, TaskNametxt.Text, CustomerNametxt.Text, TaskNametxt.Text, deliveryDate, PublishedDate, ongoingDatetxt.Text);
                            notfiy.SendWhatsAppMessage("COMPLETED", "0761576106", TaskNametxt.Text, CustomerNametxt.Text, TaskNametxt.Text, EndDatetxt.Text, publisheddatetxt.Text, ongoingDatetxt.Text);
                            LoadDesignerData();
                            TaskNametxt.Text = "";
                            CustomerNametxt.Text = "";
                            TaskNametxt.Text = "";
                            EndDatetxt.Text = "";
                            UpdateDate = "";
                            ongoingDatetxt.Text = "";
                            publisheddatetxt.Text = "";


                        }

                    }
                    else
                    {
                        MessageBox.Show($"Task is  complete Error failure", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a Task row to Accept .", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

           
        }


        private bool DesignerTaskAccept(string id)
        {


            string query1 = "UPDATE TeamProjectsTable SET TeamProjectStatus='Complete' WHERE TaskId=@id";
            string query2 = "UPDATE TaskTable SET TaskStatus='Complete' WHERE TaskId=@id";



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
    }
}

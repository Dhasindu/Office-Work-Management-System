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
using System.Windows.Forms.DataVisualization.Charting;
using Twilio.TwiML.Voice;

namespace Homepageproject
{
    public partial class CustomerDashboard : Form
    {
        private SqlConnection connetion = DBclass.ConnDatabase();
        //  private SqlDataAdapter adapter;
        private int rejecttask;
        private int completetask;
        private int ongoingtask;
        private int AcceptedTask;
        public CustomerDashboard()
        {
            InitializeComponent();
            SetupDataGridView();
            TaskDetails();
            
        }

        private void TaskDetails()
        {
            int progress = 0;
            string query = "SELECT TaskName, PublishedDate, TaskStatus, EndDate, UpdatedDate FROM TaskTable WHERE CustId=@id AND (TaskStatus='Complete' OR TaskStatus='Ongoing' OR TaskStatus='Accepted')";

            

            try
            {
                // Ensure connection is closed before opening
                if (connetion.State == ConnectionState.Open)
                {
                    connetion.Close();
                }

                connetion.Open();
                SqlCommand cmd = new SqlCommand(query, connetion);
                cmd.Parameters.AddWithValue("@id", Customer.CurrentCustomer.id);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read()) // Iterate through all rows
                {
                    string taskName = reader["TaskName"] != DBNull.Value ? reader["TaskName"].ToString() : string.Empty;
                    string published = reader["PublishedDate"] != DBNull.Value ? Convert.ToDateTime(reader["PublishedDate"]).ToString() : string.Empty;
                    string taskStatus = reader["TaskStatus"] != DBNull.Value ? reader["TaskStatus"].ToString() : string.Empty;
                    string endDate = reader["EndDate"] != DBNull.Value ? Convert.ToDateTime(reader["EndDate"]).ToString() : string.Empty;
                    string updatedDate = reader["UpdatedDate"] != DBNull.Value ? Convert.ToDateTime(reader["UpdatedDate"]).ToString() : string.Empty;



                    // Assign progress based on status
                    if (taskStatus == "Complete")
                    {
                        progress = 100;
                    }
                    else if (taskStatus == "Ongoing")
                    {
                        progress = 45;
                    }
                    else if (taskStatus == "Accepted")
                    {
                        progress = 20;
                    }


                    // Add row to DataGridView
                    OngoingTaskgrid.Rows.Add(taskName, published, taskStatus, progress, endDate, updatedDate);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                

                // Ensure connection is closed before exiting
                if (connetion.State == ConnectionState.Open)
                {
                    connetion.Close();
                }
            }
        }


        private void SetupDataGridView( )
        {


            // Add columns
            OngoingTaskgrid.Columns.Add("TaskName", "Task Name");
            OngoingTaskgrid.Columns.Add("published", "Start Date");
            OngoingTaskgrid.Columns.Add("taskStatus", "Status");
 

            // Add progress bar column
            DataGridViewProgressColumn progressColumn = new DataGridViewProgressColumn();
            progressColumn.HeaderText = "Progress";
            progressColumn.Name = "Progress";
            OngoingTaskgrid.Columns.Add(progressColumn);

            OngoingTaskgrid.Columns.Add("endDate", "end Date");
            OngoingTaskgrid.Columns.Add("updatedDate", "updated Date");
            // Style the grid
            OngoingTaskgrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            OngoingTaskgrid.AllowUserToAddRows = false;
            OngoingTaskgrid.RowHeadersVisible = false;

   
        }


        private void LoadPieChartData()
        {
            try
            {
                string query = @"SELECT 
                        SUM(CASE WHEN TaskStatus = 'Complete' THEN 1 ELSE 0 END) AS CompleteTask, 
                        SUM(CASE WHEN TaskStatus = 'Ongoing' THEN 1 ELSE 0 END) AS OngoingTask,
                        SUM(CASE WHEN TaskStatus = 'Rejected' THEN 1 ELSE 0 END) AS RejectedTask ,
                        SUM(CASE WHEN TaskStatus = 'Accepted' THEN 1 ELSE 0 END) AS AcceptedTask 
                        FROM TaskTable 
                        WHERE CustId=@id AND (TaskStatus='Complete' OR TaskStatus='Ongoing' OR TaskStatus='Accepted')";

                connetion.Open();
                using (SqlCommand cmd = new SqlCommand(query, connetion)) {
                    cmd.Parameters.AddWithValue("@id", Customer.CurrentCustomer.id);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Fetching values from database
                            int completeTask = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                            int ongoingTask = reader.IsDBNull(1) ? 0 : reader.GetInt32(1);
                            int rejectedTask = reader.IsDBNull(2) ? 0 : reader.GetInt32(2);
                            int acceptedTask = reader.IsDBNull(3) ? 0 : reader.GetInt32(3);

                            // Initialize Chart
                            chart1.Series.Clear();
                            chart1.Titles.Clear();

                            // Set chart title
                            chart1.Titles.Add("Project Status");

                            // Create a new series
                            Series series = new System.Windows.Forms.DataVisualization.Charting.Series
                            {
                                Name = "Tasks",
                                ChartType = SeriesChartType.Pie
                            };

                            // Add data points
                            series.Points.AddXY("Complete", completeTask);
                            series.Points.AddXY("Ongoing", ongoingTask);
                            series.Points.AddXY("Rejected", rejectedTask);
                            series.Points.AddXY("Accepted", acceptedTask);

                            // Set Data Labels
                            series.IsValueShownAsLabel = true;

                            // Add Series to Chart
                            chart1.Series.Add(series);
                        }
                }
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connetion.Close();
            }
        }

        private void CustomerDashboard_Load(object sender, EventArgs e)
        {
            LoadTeamTaskdata();
            LoadPieChartData();
            LoadRejectedtask();
            label14.Text = "1. Open WhatsApp on your phone";
            label13.Text = "Stay Updated with Our Task Notification Service on Your Phone! 📲✨";
            label15.Text = "2. Tap Menu ⋮ or Settings ⚙ and select Linked Devices";
            label16.Text = "3. Point your phone to this screen to capture the code";
            UserWelcomeTxt.Text = $"✨ Welcome to Dashboard, {Customer.CurrentCustomer.name}";
            totaskbtn.Text = (completetask + ongoingtask + rejecttask+AcceptedTask).ToString();
            completetaskbtn.Text = completetask.ToString();
            ongoingtaskbtn.Text = ongoingtask.ToString();
            Rejectedtaskbtn.Text = rejecttask.ToString();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }


        private void LoadTeamTaskdata()
        {
            try
            {
                string query = @"SELECT 
                        SUM(CASE WHEN TaskStatus = 'Complete' THEN 1 ELSE 0 END) AS CompleteTask, 
                        SUM(CASE WHEN TaskStatus = 'Ongoing' THEN 1 ELSE 0 END) AS OngoingTask,
                        SUM(CASE WHEN TaskStatus = 'Rejected' THEN 1 ELSE 0 END) AS RejectedTask,
                        SUM(CASE WHEN TaskStatus = 'Accepted' THEN 1 ELSE 0 END) AS AcceptedTask, 
                        SUM(CASE WHEN TaskStatus = 'Pending' THEN 1 ELSE 0 END) AS PendingTask 
                 FROM TaskTable 
                 WHERE CustId = @id";
                

                DataTable dt = new DataTable();


                using (SqlCommand cmd = new SqlCommand(query, connetion)) {
                    cmd.Parameters.AddWithValue("@id", Customer.CurrentCustomer.id);
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
               }

                if (dt.Rows.Count > 0)
                {
                    int completeTask = dt.Rows[0].IsNull("CompleteTask") ? 0 : Convert.ToInt32(dt.Rows[0]["CompleteTask"]);
                    int ongoingTask = dt.Rows[0].IsNull("OngoingTask") ? 0 : Convert.ToInt32(dt.Rows[0]["OngoingTask"]);
                    int rejectedTask = dt.Rows[0].IsNull("RejectedTask") ? 0 : Convert.ToInt32(dt.Rows[0]["RejectedTask"]);
                    int acceptedTask = dt.Rows[0].IsNull("AcceptedTask") ? 0 : Convert.ToInt32(dt.Rows[0]["AcceptedTask"]);
                    int PendingTask = dt.Rows[0].IsNull("PendingTask") ? 0 : Convert.ToInt32(dt.Rows[0]["PendingTask"]);


                    completetask = completeTask;
                    ongoingtask = ongoingTask;
                    rejecttask = rejectedTask;
                    AcceptedTask = acceptedTask+ PendingTask;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void LoadRejectedtask()
        {
            try
            {
                // Define the SQL query with the required conditions
                string query = "SELECT T.TaskName, TP.RejectReason FROM TaskTable T JOIN TeamProjectsTable TP ON T.TaskId=TP.TaskId WHERE T.CustId=@id AND  TaskStatus= @Status";

                // Create the SqlDataAdapter
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connetion))
                {
                    // Use parameters to prevent SQL injection
                    adapter.SelectCommand.Parameters.AddWithValue("@id", Customer.CurrentCustomer.id);
                    adapter.SelectCommand.Parameters.AddWithValue("@Status", "Rejected");

                    // Create a DataTable to hold the query result
                    DataTable dt = new DataTable();

                    // Fill the DataTable with query result
                    adapter.Fill(dt);

                    // Bind the DataTable to the DataGridView
                    RejectedTaskgrid.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error");
            }
            finally
            {
                
                    connetion.Close();
                
            }
        }



        private void panel1_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.ScrollOrientation == ScrollOrientation.VerticalScroll)
            {
                panel1.VerticalScroll.Value = e.NewValue;
                panel1.Invalidate(); // Refresh the panel for smooth scrolling
            }
        }
    }
}

using LiveCharts.Wpf;
using LiveCharts;
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
using LiveCharts;
using LiveCharts.WinForms;
using LiveCharts.Wpf;
using System.Windows.Forms.DataVisualization.Charting;
using Series = System.Windows.Forms.DataVisualization.Charting.Series;
using System.ComponentModel.Design;

namespace Homepageproject
{
    public partial class DesignerDashboard : Form
    {
        SqlConnection connection = DBclass.ConnDatabase();
        private SqlDataAdapter adapter;
        private int rejecttask;
        private int completetask;
        private int ongoingtask;
        public DesignerDashboard()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.DesignerDashboard_Load);
        }

        private void OngoingTaskgrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void LoadOngoingtask()
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
                                    TP.TeamProjectStatus
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
                    adapter.SelectCommand.Parameters.AddWithValue("@id", DesignerClass.CurrentDesigner.id);
                    adapter.SelectCommand.Parameters.AddWithValue("@Status", "Ongoing");

                    // Create a DataTable to hold the query result
                    DataTable dt = new DataTable();

                    // Fill the DataTable with query result
                    adapter.Fill(dt);

                    // Bind the DataTable to the DataGridView
                    OngoingTaskgrid.DataSource = dt;
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


        private void LoadCompletedtask()
        {
            try
            {
                // Define the SQL query with the required conditions
                string query = @"SELECT 
                                    C.CompanyName, 
                                    T.TaskName,
                                    TP.TeamProjectStatus
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
                    adapter.SelectCommand.Parameters.AddWithValue("@id", DesignerClass.CurrentDesigner.id);
                    adapter.SelectCommand.Parameters.AddWithValue("@Status", "Complete");

                    // Create a DataTable to hold the query result
                    DataTable dt = new DataTable();

                    // Fill the DataTable with query result
                    adapter.Fill(dt);

                    // Bind the DataTable to the DataGridView
                    CompleteTaskGrid.DataSource = dt;
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


        private void LoadRejectedtask()
        {
            try
            {
                // Define the SQL query with the required conditions
                string query = @"SELECT 
                                    C.CompanyName, 
                                    T.TaskName,
                                    T.Document1,
                                    TP.RejectReason
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
                    adapter.SelectCommand.Parameters.AddWithValue("@id", DesignerClass.CurrentDesigner.id);
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
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }


        private void LoadTeamTaskdata()
        {
            try
            {
                string query = @"SELECT 
                        SUM(CASE WHEN P.TeamProjectStatus = 'Complete' THEN 1 ELSE 0 END) AS CompleteTask, 
                        SUM(CASE WHEN P.TeamProjectStatus = 'Ongoing' THEN 1 ELSE 0 END) AS OngoingTask,
                        SUM(CASE WHEN P.TeamProjectStatus = 'Rejected' THEN 1 ELSE 0 END) AS RejectedTask 
                    FROM TeamProjectsTable P 
                    JOIN TeamTable T ON P.TeamId = T.TeamId 
                    WHERE T.TeamId = (SELECT TeamId FROM DesinerTable WHERE AuthId = @AuthId)";

                DataTable dt = new DataTable();

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    // Use parameterized query to prevent SQL injection
                    cmd.Parameters.AddWithValue("@AuthId", DesignerClass.CurrentDesigner.id);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }

                if (dt.Rows.Count > 0)
                {
                    // Ensure values are not null before converting
                    int completeTask = dt.Rows[0]["CompleteTask"] != DBNull.Value ? Convert.ToInt32(dt.Rows[0]["CompleteTask"]) : 0;
                    int ongoingTask = dt.Rows[0]["OngoingTask"] != DBNull.Value ? Convert.ToInt32(dt.Rows[0]["OngoingTask"]) : 0;
                    int rejectedTask = dt.Rows[0]["RejectedTask"] != DBNull.Value ? Convert.ToInt32(dt.Rows[0]["RejectedTask"]) : 0;

                    // Assign values to class-level variables
                    completetask = completeTask;
                    ongoingtask = ongoingTask;
                    rejecttask = rejectedTask;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void LoadPieChartData()
        {
            try
            {
                string query = @"SELECT 
                SUM(CASE WHEN TeamProjectStatus = 'Complete' THEN 1 ELSE 0 END) AS CompleteTask, 
                SUM(CASE WHEN TeamProjectStatus = 'Ongoing' THEN 1 ELSE 0 END) AS OngoingTask,
                SUM(CASE WHEN TeamProjectStatus = 'Rejected' THEN 1 ELSE 0 END) AS RejectedTask 
                FROM TeamProjectsTable
                WHERE TeamId=(SELECT TeamId FROM DesinerTable WHERE AuthId=@id);";

                connection.Open();

                // Execute query and process results
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@id", DesignerClass.CurrentDesigner.id); // Bind AuthId for security
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Fetching values from database
                            int completeTask = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                            int ongoingTask = reader.IsDBNull(1) ? 0 : reader.GetInt32(1);
                            int rejectedTask = reader.IsDBNull(2) ? 0 : reader.GetInt32(2);

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

                            // Set Data Labels
                            series.IsValueShownAsLabel = true;

                            // Set Data Point Colors for Better Visualization
                            series.Points[0].Color = Color.Green;
                            series.Points[1].Color = Color.Orange;
                            series.Points[2].Color = Color.Red;

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
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }



        private void DesignerDashboard_Load(object sender, EventArgs e)
        {
            LoadOngoingtask();
            LoadCompletedtask();
            LoadRejectedtask();
            LoadTeamTaskdata();
            LoadPieChartData();
            UserWelcomeTxt.Text = $"✨ Welcome to Dashboard, {DesignerClass.CurrentDesigner.name}";

                 totaskbtn.Text = (completetask + ongoingtask + rejecttask).ToString();
                completetaskbtn.Text = completetask.ToString();
                ongoingtaskbtn.Text = ongoingtask.ToString();
                Rejectedtaskbtn.Text = rejecttask.ToString();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

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

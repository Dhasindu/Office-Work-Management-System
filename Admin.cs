
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Homepageproject
{
    internal class Admin:SystemUsers
    {
        public void DisplayDataTable(SqlConnection connection, DataGridView datagrid1)
        {
            try
            {
                if (connection.State != System.Data.ConnectionState.Open)
                {
                    connection.Open();
                }
                string query = "SELECT * FROM UserAuthDataTable WHERE UserType='manager'";
                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataReader reader = cmd.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(reader);

                datagrid1.DataSource = dt;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                connection.Close();
            }
        }

        public override void SearchData(SqlConnection connection,string word, DataGridView datagrid1)
        {
            string query="";
            try
            {
                if (connection.State != System.Data.ConnectionState.Open)
                {
                    connection.Open();
                }
                query = $"SELECT A.Id,A.Username,M.Phone,M.UserStatus ,A.UserType FROM ManageTable M JOIN UserAuthDataTable A ON M.AuthId = A.Id WHERE A.Username=@word";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@word", word);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    DataTable dt = new DataTable();
                    dt.Load(reader);

                    datagrid1.DataSource = dt;
                }
                else
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("Message"); // Add a single column for the message
                    dt.Columns.Add(" ");

                    DataRow row = dt.NewRow();
                    row["Message"] = "No records found...";
                    dt.Rows.Add(row);

                    datagrid1.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally { connection.Close(); }
        }

        public override bool AddUserData(SqlConnection connection, string name, string password, string usertype,string UserStatus)
        {
            // Define queries
            string query1 = "INSERT INTO UserAuthDataTable (Username, Password, UserType) VALUES (@Username, @Password, @UserType)";
            string query2 = "INSERT INTO ManageTable (UserStatus, Authid) VALUES (@status, @id)";

            // Initialize SQL commands
            SqlCommand cmd1 = new SqlCommand(query1, connection);
            SqlCommand cmd2 = new SqlCommand(query2, connection);

            // Validate input
            bool valid = DBclass.DataChecked(connection, name, password, usertype);

            try
            {
                if (!valid)
                {
                    // Open connection if not already open
                    if (connection.State != System.Data.ConnectionState.Open)
                    {
                        connection.Open();
                    }

                    // Add parameters and execute first query
                    cmd1.Parameters.AddWithValue("@Username", name);
                    cmd1.Parameters.AddWithValue("@Password", DBclass.HashPassword(password));
                    cmd1.Parameters.AddWithValue("@UserType", usertype);
                    cmd1.ExecuteNonQuery();
                    connection.Close();
                    // Retrieve AuthId for the new user
                    int Authid = GetsId(connection, name);

                    connection.Open();
                    // Add parameters and execute second query
                    cmd2.Parameters.AddWithValue("@status", UserStatus);
                    cmd2.Parameters.AddWithValue("@id", Authid);
                    cmd2.ExecuteNonQuery();

                    // Close connection after execution
                    connection.Close();

                    MessageBox.Show("Data is added correctly.");
                    return true;
                }
                else
                {
                    MessageBox.Show("User already exists.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions
                MessageBox.Show(ex.ToString(), "Error");
                return false;
            }
            finally
            {
                // Ensure connection is closed
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }

        }

        public override bool updateUserData(SqlConnection connection,int id, string name, string password, string usertype,string Status)
        {
            string query1 = "UPDATE UserAuthDataTable SET  UserType = @UserType , Username = @Username WHERE Id=@Id";
            string query2 = "UPDATE ManageTable SET UserStatus=@status WHERE AuthId=@id";
            SqlCommand cmd1 = new SqlCommand(query1, connection);
            SqlCommand cmd2 = new SqlCommand(query2, connection);
            try
            {
                
                if (connection.State != System.Data.ConnectionState.Open)
                    {
                        connection.Open();
                    }
                    cmd1.Parameters.AddWithValue("@Id", id);
                    cmd1.Parameters.AddWithValue("@Username", name);
                    cmd1.Parameters.AddWithValue("@UserType", usertype);
                    cmd1.ExecuteNonQuery();

                    cmd2.Parameters.AddWithValue("@status", Status);
                    cmd2.Parameters.AddWithValue("@id", id);
                    cmd2.ExecuteNonQuery();
                    return true;
                
              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error");
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        public override bool DeleteUserData(SqlConnection connection, int Id)
        {

            try
            {
                using (SqlCommand cmd1 = new SqlCommand("DELETE FROM ManageTable WHERE ManageId = @Id", connection))
                using (SqlCommand cmd2 = new SqlCommand("DELETE FROM UserAuthDataTable WHERE Id = @Id", connection))
                {
                    connection.Open();

                    // Start a transaction
                    using (SqlTransaction transaction = connection.BeginTransaction())
                    {
                        // Associate the transaction with the commands
                        cmd1.Transaction = transaction;
                        cmd2.Transaction = transaction;

                        // Step 1: Delete record from ManagerTable
                        cmd1.Parameters.AddWithValue("@Id", Id);
                        cmd1.ExecuteNonQuery();

                        // Step 2: Delete record from UserAuthDataTable
                        cmd2.Parameters.AddWithValue("@Id", Id);
                        cmd2.ExecuteNonQuery();

                        // Commit the transaction
                        transaction.Commit();
                    }

                    // Show success message
                    MessageBox.Show("Data is deleted successfully.");
                    return true;
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions
                MessageBox.Show($"Error: {ex.Message}", "Error");
                return false;
            }
            finally
            {
                // Ensure connection is closed
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }

        }


        public bool AddTeam(SqlConnection connection, TextBox teamName, TextBox teamLeader, TextBox teamEmail, TextBox teamPhone)
        {
            try
            {
                // Query 1: Insert into TeamTable
                string query1 = "INSERT INTO TeamTable(TeamName, TeamLeader, TeamEmail, TeamPhone) VALUES (@teamName, @teamLeader, @teamEmail, @teamPhone)";
                string query2 = "INSERT INTO TeamProjectsTable(TeamId) VALUES(@teamid)";

                // Open the connection if it is not already open
                if (connection.State != System.Data.ConnectionState.Open)
                {
                    connection.Open();
                }

                // Create the first SqlCommand for inserting into TeamTable
                SqlCommand cmd1 = new SqlCommand(query1, connection);

                // Add parameters for the first query
                cmd1.Parameters.AddWithValue("@teamName", teamName.Text);
                cmd1.Parameters.AddWithValue("@teamLeader", teamLeader.Text);
                cmd1.Parameters.AddWithValue("@teamEmail", teamEmail.Text);
                cmd1.Parameters.AddWithValue("@teamPhone", teamPhone.Text);

                // Execute the first query
                cmd1.ExecuteNonQuery();

                // Get the last inserted TeamId
                int id = GetTeamId(connection, teamName.Text);
                
                connection.Open();

                // Query 2: Insert into TeamProjectsTable using the last inserted TeamId
                SqlCommand cmd2 = new SqlCommand(query2, connection);
                cmd2.Parameters.AddWithValue("@teamid", id);

                // Execute the second query
                cmd2.ExecuteNonQuery();

                // Close the connection explicitly
                connection.Close();

                return true;
            }
            catch (Exception ex)
            {
                // Display the error message
                MessageBox.Show(ex.ToString(), "Error ");
                return false;
            }
            finally
            {
                // Ensure the connection is closed
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }


        public bool AddTeamData(SqlConnection connection, TextBox name, TextBox password, TextBox email, TextBox phoneNumber,Label TeamId)
        {
            int Authid = 0;
            string usertype = "Designer";
            string query1 = "INSERT INTO UserAuthDataTable (Username, Password, UserType) VALUES (@Username, @Password, @UserType)";
            bool valid = DBclass.DataChecked(connection, name.Text, password.Text, usertype);

            try
            {
                if (!valid)
                {
                    if (connection.State != System.Data.ConnectionState.Open)
                    {
                        connection.Open();
                    }

                    SqlCommand cmd = new SqlCommand(query1, connection);
                    cmd.Parameters.AddWithValue("@Username", name.Text);
                    cmd.Parameters.AddWithValue("@Password", DBclass.HashPassword(password.Text));
                    cmd.Parameters.AddWithValue("@UserType", usertype);
                    cmd.ExecuteNonQuery();

                    // Fetch AuthId after insertion
                    Authid = GetsId(connection, name.Text);

                    // Corrected the issue with cmd2
                    string query2 = "INSERT INTO DesinerTable (Phone,Email,AuthId,TeamId) VALUES (@Phone, @Email, @AuthId,@TeamId)";
                    SqlCommand cmd2 = new SqlCommand(query2, connection);
                    if (connection.State != System.Data.ConnectionState.Open)
                    {
                        connection.Open();
                    }
                    cmd2.Parameters.AddWithValue("@Phone", phoneNumber.Text);
                    cmd2.Parameters.AddWithValue("@Email", email.Text);
                    cmd2.Parameters.AddWithValue("@AuthId", Authid);
                    cmd2.Parameters.AddWithValue("@TeamId", TeamId.Text);
                    cmd2.ExecuteNonQuery();

                    MessageBox.Show("Data is added correctly.");
                    return true;
                }
                else
                {
                    MessageBox.Show("User already exists.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error");
                return false;
            }
            finally
            {

                connection.Close();

            }
        }

        public bool UpdateTeamMember(SqlConnection connection, TextBox name, TextBox email, TextBox phoneNumber,Label desinerId)
        {

            try
            {
                string query1 = "UPDATE DesinerTable SET phone=@phone,Email=@email WHERE  DesinerId=@id";
                SqlCommand cmd = new SqlCommand(query1, connection);
                connection.Open();
                cmd.Parameters.AddWithValue("@phone", phoneNumber.Text);
                cmd.Parameters.AddWithValue("@email", email.Text);
                cmd.Parameters.AddWithValue("@id", desinerId.Text);
                cmd.ExecuteNonQuery();

                string query2 = "UPDATE UserAuthDataTable SET Username=@name WHERE Id=(SELECT AuthId FROM DesinerTable WHERE DesinerId=@id)";
                SqlCommand cmd1 = new SqlCommand(query2, connection);
                cmd1.Parameters.AddWithValue("@name", name.Text);
                //cmd1.Parameters.AddWithValue("@password", DBclass.HashPassword(password.Text));
                cmd1.Parameters.AddWithValue("@id", desinerId.Text);
                cmd1.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
               return false;
            }
            finally 
            {
                connection.Close();
            }
        }

        public bool UpdateTeam(SqlConnection connection, TextBox teamName, TextBox teamLeader, TextBox teamEmail, TextBox teamPhone,Label id)
        {

            try
            {
                string query = "UPDATE TeamTable SET TeamName=@TeamName,TeamLeader=@TeamLeader , TeamEmail=@TeamEmail, TeamPhone=@TeamPhone WHERE  TeamId=@id";
                SqlCommand cmd = new SqlCommand(query, connection);
                connection.Open();
                cmd.Parameters.AddWithValue("@TeamName", teamName.Text);
                cmd.Parameters.AddWithValue("@TeamLeader", teamLeader.Text);
                cmd.Parameters.AddWithValue("@TeamEmail", teamEmail.Text);
                cmd.Parameters.AddWithValue("@TeamPhone", teamPhone.Text);
                cmd.Parameters.AddWithValue("@id", id.Text);
                cmd.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        public bool DeleteTeam(SqlConnection connection, string id)
        {
            try
            {
                using (SqlCommand cmd3 = new SqlCommand("DELETE FROM UserAuthDataTable WHERE Id=(SELECT AuthId FROM DesinerTable WHERE TeamId=@id)", connection))
                using (SqlCommand cmd1 = new SqlCommand("DELETE FROM DesinerTable WHERE TeamId=@id", connection))
                using (SqlCommand cmd2 = new SqlCommand("DELETE FROM TeamTable WHERE TeamId=@id", connection))
                using (SqlCommand cmd4 = new SqlCommand("DELETE FROM TeamProjectsTable WHERE TeamId=@id", connection))
                {
                    connection.Open();

                    using (SqlTransaction transaction = connection.BeginTransaction())
                    {
                        cmd3.Transaction = transaction;
                        cmd1.Transaction = transaction;
                        cmd2.Transaction = transaction;
                        cmd4.Transaction = transaction;

                        // Step 2: Delete records from UserAuthDataTable
                        cmd3.Parameters.AddWithValue("@id", id);
                        cmd3.ExecuteNonQuery();

                        // Step 1: Delete records from DesinerTable
                        cmd1.Parameters.AddWithValue("@id", id);
                        cmd1.ExecuteNonQuery();

                       

                        // Step 3: Delete record from TeamTable
                        cmd2.Parameters.AddWithValue("@id", id);
                        cmd2.ExecuteNonQuery();

                        // Step 4: Delete record from TeamProjectsTable
                        cmd4.Parameters.AddWithValue("@id", id);
                        cmd4.ExecuteNonQuery();

                        // Commit transaction
                        transaction.Commit();
                    }

                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                MessageBox.Show("An error occurred while deleting the team. Please try again.", "Error");
                return false;
            }
        }
        public bool DeleteTeamMember(SqlConnection connection, string id)
        {
            try
            {
                using (SqlCommand cmd2 = new SqlCommand("DELETE FROM UserAuthDataTable WHERE Id=(SELECT AuthId FROM DesinerTable WHERE DesinerId=@id)", connection))
                using (SqlCommand cmd1 = new SqlCommand("DELETE FROM DesinerTable WHERE DesinerId=@id", connection))
                {
                    connection.Open();

                    using (SqlTransaction transaction = connection.BeginTransaction())
                    {
                        // Associate the transaction with the commands
                        cmd2.Transaction = transaction;
                        cmd1.Transaction = transaction;

                        // Step 1: Delete record from UserAuthDataTable
                        cmd2.Parameters.AddWithValue("@id", id);
                        cmd2.ExecuteNonQuery();

                        // Step 2: Delete record from DesinerTable
                        cmd1.Parameters.AddWithValue("@id", id);
                        cmd1.ExecuteNonQuery();

                        // Commit the transaction
                        transaction.Commit();
                    }

                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                MessageBox.Show($"Error: {ex.Message}", "Error");
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        public void SearchCustomer(SqlConnection connection, string word, DataGridView datagrid1)
        {
            string query = " ";
            try
            {
                if (connection.State != System.Data.ConnectionState.Open)
                {
                    connection.Open();
                }

                if (!string.IsNullOrWhiteSpace(word))
                {
                    query = $"SELECT C.CusId, A.Username, C.CompanyName, C.Phone, C.CustomerStatus FROM Customer C JOIN UserAuthDataTable A ON C.AuthId = A.Id WHERE C.CustomerStatus = 'Pending' AND (A.Username = @word OR C.CompanyName = @compyname)";
                }
                else
                {
                    query = $"SELECT C.CusId, A.Username, C.CompanyName, C.Phone, C.CustomerStatus FROM Customer C JOIN UserAuthDataTable A ON C.AuthId = A.Id WHERE C.CustomerStatus = 'Pending'";
                }

                SqlCommand cmd = new SqlCommand(query, connection);

                cmd.Parameters.AddWithValue("@word", word);
                cmd.Parameters.AddWithValue("@compyname", word);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    DataTable dt = new DataTable();
                    dt.Load(reader);

                    datagrid1.DataSource = dt;
                }
                else
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("Message"); // Add a single column for the message
                    dt.Columns.Add(" ");

                    DataRow row = dt.NewRow();
                    row["Message"] = "No records found...";
                    dt.Rows.Add(row);

                    datagrid1.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally { connection.Close(); }
        }
   
        public bool AcceptsCustomers(SqlConnection connection,string id)
        {
            string query = "UPDATE Customer SET CustomerStatus='Approved' WHERE CusId=@Id";
            SqlCommand cmd = new SqlCommand(query, connection);
            try
            {

                if (connection.State != System.Data.ConnectionState.Open)
                {
                    connection.Open();
                }
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();
              
                return true;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        public bool RejectCustomers(SqlConnection connection, string id)
        {
            string query = "UPDATE Customer SET CustomerStatus='Rejected' WHERE CusId=@Id";
            SqlCommand cmd = new SqlCommand(query, connection);
            try
            {

                if (connection.State != System.Data.ConnectionState.Open)
                {
                    connection.Open();
                }
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();

                return true;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        public bool RestPassword(SqlConnection connection, int id,string password)
        {
            try
            {
                string query2 = "UPDATE UserAuthDataTable SET Password=@password WHERE Id=(SELECT AuthId FROM DesinerTable WHERE DesinerId=@id)";
                SqlCommand cmd1 = new SqlCommand(query2, connection);
                connection.Open();
                cmd1.Parameters.AddWithValue("@password", DBclass.HashPassword(password));
                cmd1.Parameters.AddWithValue("@id", id);
                cmd1.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}","Error");
                return false;
            }
            finally
            {
                connection.Close();
            }
        }


        public bool RestPasswordmanager(SqlConnection connection, string id, string password)
        {
            try
            {
                string query2 = "UPDATE UserAuthDataTable SET Password=@password WHERE Id=@id";
                SqlCommand cmd1 = new SqlCommand(query2, connection);
                connection.Open();
                cmd1.Parameters.AddWithValue("@password", DBclass.HashPassword(password));
                cmd1.Parameters.AddWithValue("@id", id);
                cmd1.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Error");
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        public int GetTeamId(SqlConnection connection, string name)
        {
            try
            {
                if (connection.State != System.Data.ConnectionState.Open)
                {
                    connection.Open();
                }
                string query = "SELECT TeamId FROM TeamTable WHERE TeamName=@name";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@name", name);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
                   
                    return reader.GetInt32(0);

                }
                else
                {
                    connection.Close();
                    return 0;
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return 0;
            }
            finally
            {
                connection.Close();

            }

        }

    }
}

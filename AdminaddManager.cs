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
    public partial class AdminaddManager : Form
    {
        Admin UserAdmin = new Admin();
        SqlConnection connection = DBclass.ConnDatabase();
        private SqlDataAdapter adapter;
        public AdminaddManager()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.AdminaddManager_Load);
        }

        private void searchbtn_Click(object sender, EventArgs e)
        {
            string word = searchtxt.Text.Trim();
            if (!string.IsNullOrWhiteSpace(word) && word != "-- Search --")
            {
                UserAdmin.SearchData(connection, word, datagrid1);
            }
            else
            {
                MessageBox.Show("Search Bar is Empty....", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDate();
            }
            
            
        }

        private void viewbtn_Click(object sender, EventArgs e)
        {
            //UserAdmin.DisplayDataTable(connection, datagrid1);

            if (string.IsNullOrWhiteSpace(Idtxt.Text))
            {
                MessageBox.Show("Please select a row .", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

           /* if (!int.TryParse(Idtxt.Text, out int id))
            {
                MessageBox.Show("Invalid ID format. Please ensure the ID is a valid number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }*/

            if (!string.IsNullOrWhiteSpace(paswdtxt.Text))
            {
                bool valid=UserAdmin.RestPasswordmanager(connection, Idtxt.Text, paswdtxt.Text);
                if (valid)
                {
                    MessageBox.Show("Password Reset is Sucessfully", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Clear form fields
                    Idtxt.Text = "";
                    paswdtxt.Text= "";
                    
                    LoadDate(); // Refresh data grid or view
                }
                else
                {
                    MessageBox.Show("Password Reset is Unsucessfully", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Password Field Cannot be empty...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void insertbtn_Click(object sender, EventArgs e)
        {
            string name = userNametxt.Text;
            string password = paswdtxt.Text;
            string userStatus = UserStatus.Text;
            string usertype = usertypeComBox.Text;
           
           
            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(password) && !string.IsNullOrEmpty(usertype) && !string.IsNullOrEmpty(userStatus))
            {
                // Validate username for invalid characters
                if (!System.Text.RegularExpressions.Regex.IsMatch(name, @"^[a-zA-Z0-9]+$"))
                {
                    MessageBox.Show("Username can only contain letters and numbers.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validate password length and complexity
                if (password.Length < 4)
                {
                    MessageBox.Show("Password must be at least 4 characters long.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                bool vaild = UserAdmin.AddUserData(connection, name, password, usertype, userStatus);
                if (vaild)
                {
                    userNametxt.Text = "";
                    paswdtxt.Text = "";
                    UserStatus.Text = "";
                    usertypeComBox.Text = "";
                }
            }
            else
            {
                MessageBox.Show("All fields Should be not null", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void datagrid1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0) // Ensure the click is on a valid cell
            {
                // Get the current row
                DataGridViewRow row = datagrid1.Rows[e.RowIndex];

                // Display the values in labels
                Idtxt.Text = row.Cells["Id"].FormattedValue.ToString();


            }
        }

        private void updatebtn_Click(object sender, EventArgs e)
        {
            
            string letterId = Idtxt.Text;

            if (string.IsNullOrEmpty(letterId))
            {
                MessageBox.Show("Please select a row to update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(letterId, out int id))
            {
                MessageBox.Show("Please select a row to update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string name = userNametxt.Text.Trim();
            string password = paswdtxt.Text.Trim();
            string status = UserStatus.Text.Trim();
            string usertype = usertypeComBox.Text.Trim();

            // Check if required fields are not empty
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(usertype) || string.IsNullOrEmpty(status))
            {
                MessageBox.Show("Username, User Type, and Status cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validate username
            if (!System.Text.RegularExpressions.Regex.IsMatch(name, @"^[a-zA-Z0-9]+$"))
            {
                MessageBox.Show("Username can only contain letters and numbers.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Handle password updates
            if (string.IsNullOrEmpty(password))
            {
                DialogResult result = MessageBox.Show("Are you sure you want to update the user details without changing the password?", "Confirm Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Call update function
                    bool valid = UserAdmin.updateUserData(connection, id, name, password, usertype, status);
                    if (valid)
                    {
                        MessageBox.Show("User details updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Clear form fields
                        Idtxt.Text = "";
                        userNametxt.Text = "";
                        UserStatus.SelectedIndex = -1;
                        usertypeComBox.SelectedIndex = -1;
                        LoadDate(); // Refresh data grid or view
                    }
                    else
                    {
                        MessageBox.Show("Failed to update user details. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Update operation canceled.", "Canceled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                // Disallow password update
                MessageBox.Show("You are not allowed to update the user's password.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

        }

        private void Deletebtn_Click(object sender, EventArgs e)
        {
            
            string leltterId = Idtxt.Text;
            if (string.IsNullOrWhiteSpace(leltterId))
            {
                MessageBox.Show("Select the Row to Delete..", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                if (!int.TryParse(leltterId, out int id))
                {
                    MessageBox.Show("Select the Row to Delete..", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                DialogResult result = MessageBox.Show("Are you sure you want to delete this user?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    bool valid = UserAdmin.DeleteUserData(connection, id);
                    if (valid)
                    {
                        MessageBox.Show("User deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Idtxt.Text = string.Empty;
                        userNametxt.Text = string.Empty;
                        paswdtxt.Text = string.Empty;
                        usertypeComBox.SelectedIndex = -1;
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete user. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Deletion operation canceled.", "Canceled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        
        
        
        
        
        
        private void datagrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           

            if (e.RowIndex >= 0 && e.ColumnIndex >= 0) // Ensure the click is on a valid cell
            {
                // Get the current row
                DataGridViewRow row = datagrid1.Rows[e.RowIndex];

                // Display the values in labels
                Idtxt.Text = row.Cells["Id"].FormattedValue.ToString();
                userNametxt.Text = row.Cells["Username"].FormattedValue.ToString(); // Replace "ID" with your column name
                UserStatus.Text = row.Cells["UserStatus"].FormattedValue.ToString(); // Replace "Name" with your column name
                usertypeComBox.Text = row.Cells["UserType"].FormattedValue.ToString(); // Replace "OtherColumn" as needed

            }
        }

        private void AdminaddManager_Load(object sender, EventArgs e)
        {
            LoadDate();
            searchtxt.Text = "-- Search --";
            searchtxt.ForeColor = Color.LightGray;
            searchtxt.TextAlign = HorizontalAlignment.Center;
            Idtxt.Text = "Manager ID";
            Idtxt.ForeColor = Color.LightGray;
            Idtxt.TextAlign = HorizontalAlignment.Center;
        }

        private void searchtxt_Enter(object sender, EventArgs e)
        {
            if (searchtxt.Text == "-- Search --")
            {
                searchtxt.Text = "";
                searchtxt.ForeColor = Color.Black;
                searchtxt.TextAlign = HorizontalAlignment.Left;
            }
        }

        private void searchtxt_Leave(object sender, EventArgs e)
        {
            if (searchtxt.Text == "")
            {
                searchtxt.Text = "-- Search --";
                searchtxt.ForeColor = Color.LightGray;
                searchtxt.TextAlign = HorizontalAlignment.Center;
            }
        }

        private void Idtxt_Enter(object sender, EventArgs e)
        {

            if (Idtxt.Text == "Manager ID")
            {
                Idtxt.Text = "";
                Idtxt.ForeColor = Color.Black;
                Idtxt.TextAlign = HorizontalAlignment.Left;
            }
        }

        private void Idtxt_Leave(object sender, EventArgs e)
        {

            if (Idtxt.Text == "")
            {
                Idtxt.Text = "Manager ID";
                Idtxt.ForeColor = Color.LightGray;
                Idtxt.TextAlign = HorizontalAlignment.Center;
            }
        }


        private void LoadDate()
        {
            try
            {
                string query = "SELECT A.Id,A.Username,M.Phone,M.UserStatus,A.UserType FROM ManageTable M JOIN UserAuthDataTable A ON M.AuthId = A.Id WHERE UserType='manager'";
                adapter = new SqlDataAdapter(query, connection);

                DataTable dt = new DataTable();

                adapter.Fill(dt);

                datagrid1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex, "Error");
            }
            finally { connection.Close(); }

        }

        private void Idtxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void mainpanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

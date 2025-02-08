using Homepageproject.Properties;
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
    public partial class AdminAddDesignTeam : Form
    {
        private SqlConnection connetion = DBclass.ConnDatabase();
        private SqlDataAdapter adapter;
         
        Admin admin= new Admin();
        public AdminAddDesignTeam()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.AdminAddDesignTeam_Load);
        }

        private void AdminAddDesignTeam_Load(object sender, EventArgs e)
        {
            LoadDate();
        }

        private void Submitteambtn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(teamNametxt.Text) && !string.IsNullOrWhiteSpace(teamLeadertxt.Text) && !string.IsNullOrWhiteSpace(teammailtxt.Text) && !string.IsNullOrWhiteSpace(phonetxt.Text))
            {
                if (string.IsNullOrEmpty(teammailtxt.Text) || !System.Text.RegularExpressions.Regex.IsMatch(teammailtxt.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                {
                    MessageBox.Show("Invalid email address. Please enter a valid email.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrEmpty(phonetxt.Text) || !System.Text.RegularExpressions.Regex.IsMatch(phonetxt.Text, @"^[0-9]{10}$"))
                {
                    MessageBox.Show("Invalid phone number. Please enter a 10-digit number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                DialogResult result = MessageBox.Show("Are you sure you want to add this team?", "Confirm Addition", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Attempt to add the team
                    bool valid = admin.AddTeam(connetion, teamNametxt, teamLeadertxt, teammailtxt, phonetxt);
                    if (valid)
                    {
                        MessageBox.Show("Team is added successfully!", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDate(); // Refresh or reload data
                        teamNametxt.Text = "";
                        teamLeadertxt.Text = "";
                        teammailtxt.Text = "";
                        phonetxt.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Failed to add the team. Please try again.", "Result", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Operation canceled.", "Canceled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Text Fields Cannot be empty", "warming", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private  void LoadDate()
        {
            try
            {
                adapter = new SqlDataAdapter("SELECT * FROM TeamTable", connetion);

                DataTable dt = new DataTable();

                adapter.Fill(dt);

                teamDataGrid.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex, "Error");
            }
            finally { connetion.Close(); }

        }

        private void Submitmemberbtn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(teamMembertxt.Text) && !string.IsNullOrWhiteSpace(passwordtxt.Text) && !string.IsNullOrWhiteSpace(memberemailtxt.Text) && !string.IsNullOrWhiteSpace(memberphonetxt.Text))
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(memberemailtxt.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                {
                    MessageBox.Show("Invalid email address. Please enter a valid email.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!System.Text.RegularExpressions.Regex.IsMatch(memberphonetxt.Text, @"^[0-9]{10}$"))
                {
                    MessageBox.Show("Invalid phone number. Please enter a 10-digit number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

               /* if (passwordtxt.Text.Length < 4)
                {
                    MessageBox.Show("Password must be at least 4 characters long.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }*/

                DialogResult result = MessageBox.Show("Are you sure you want to submit this member data?", "Confirm Submission", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Proceed with adding the team data if the user confirms
                    bool valid = admin.AddTeamData(connetion, teamMembertxt, passwordtxt, memberemailtxt, memberphonetxt, teamIdtxt);
                    if (valid)
                    {
                        MessageBox.Show("Member data is added successfully!", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDateClckid(teamIdtxt.Text);

                        // Clear input fields
                        teamIdtxt.Text = "";
                        passwordtxt.Text = "";
                        teamMembertxt.Text = "";
                        memberemailtxt.Text = "";
                        memberphonetxt.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Member data was not added successfully.", "Result", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    // If the user cancels, show a cancellation message
                    MessageBox.Show("Submission canceled.", "Canceled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Text Fields Cannot be empty", "warming", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void teamDataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewRow row = teamDataGrid.Rows[e.RowIndex];
                teamIdtxt.Text = row.Cells["TeamId"].FormattedValue.ToString();
                LoadDateClckid(teamIdtxt.Text);
            }
        }

        private void LoadDateClckid(string teamid)
        {
            try
            {
                adapter = new SqlDataAdapter($"SELECT D.DesinerId, A.Username,D.Email,D.Phone,D.TeamId FROM DesinerTable D JOIN UserAuthDataTable A ON D.AuthId = A.Id WHERE D.TeamId={teamid}", connetion);

                DataTable dt = new DataTable();

                adapter.Fill(dt);

                teamMembergrid.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex, "Error");
            }
            finally { connetion.Close(); }

        }

        public void ShowHide(Button btn, TextBox txt)
        {
            if (txt.UseSystemPasswordChar)
            {
                // Show password
                btn.Image = Resources.hidden ;
                txt.UseSystemPasswordChar = false;
            }
            else
            {
                // Hide password
                btn.Image = Resources.eye;
                txt.UseSystemPasswordChar = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ShowHide(showhidebtn, passwordtxt);
        }

        //update Team
        private void button3_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(teamNametxt.Text) && !string.IsNullOrWhiteSpace(teamLeadertxt.Text) && !string.IsNullOrWhiteSpace(teammailtxt.Text) && !string.IsNullOrWhiteSpace(phonetxt.Text))
            {

                DialogResult result = MessageBox.Show("Do you need to update this data?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    bool vaild = admin.UpdateTeam(connetion, teamNametxt, teamLeadertxt, teammailtxt, phonetxt, teamIdtxt);
                    if (vaild)
                    {
                        MessageBox.Show("Team Data is Updated Sucessfully", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDate();
                        teamIdtxt.Text = "";
                        teamNametxt.Text = "";
                        teamLeadertxt.Text = "";
                        teammailtxt.Text = "";
                        phonetxt.Text = "";
                    }
                    else
                    {

                        MessageBox.Show("Team Data is not Updated Sucessfully", "Result", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
            }
            else
            {
                MessageBox.Show("Fields are Empty no update Being done", "warming", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void teamDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you need Select Data For Updates", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(result == DialogResult.Yes)
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    DataGridViewRow row = teamDataGrid.Rows[e.RowIndex];
                    teamNametxt.Text = row.Cells["TeamName"].FormattedValue.ToString();
                    teamLeadertxt.Text = row.Cells["TeamLeader"].FormattedValue.ToString();
                    teammailtxt.Text = row.Cells["TeamEmail"].FormattedValue.ToString();
                    phonetxt.Text = row.Cells["TeamPhone"].FormattedValue.ToString();
                }
            }

        }

        private void teamMembergrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            

            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewRow row = teamMembergrid.Rows[e.RowIndex];
                memberidlbl.Text = row.Cells["DesinerId"]?.FormattedValue.ToString();

            }

        }

        private void updmenberbtn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(passwordtxt.Text))
            {
                MessageBox.Show("Password Field is not allow to update", "Result", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!string.IsNullOrWhiteSpace(teamMembertxt.Text)  || !string.IsNullOrWhiteSpace(memberemailtxt.Text) || !string.IsNullOrWhiteSpace(memberphonetxt.Text))
            {

                DialogResult result = MessageBox.Show("Do you need to update this data?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    bool vaild = admin.UpdateTeamMember(connetion, teamMembertxt, memberemailtxt, memberphonetxt, memberidlbl);
                    if (vaild)
                    {
                        MessageBox.Show("Member Data is Updated Sucessfully", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDateClckid(teamIdtxt.Text);
                        teamIdtxt.Text = "";
                        teamMembertxt.Text = "";
                        memberemailtxt.Text = "";
                        memberphonetxt.Text = "";
                    }
                    else
                    {

                        MessageBox.Show("Member Data is not Updated Sucessfully", "Result", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
            }
            else
            {
                MessageBox.Show("Fields are Empty no update Being done", "warming", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void Deltbtn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(teamIdtxt.Text))
            {
                DialogResult result1 = MessageBox.Show("Do you need to Delete this Group?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result1 == DialogResult.Yes)
                {
                    DialogResult result2 = MessageBox.Show("All Member Details Will Also be delete?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (result2 == DialogResult.OK)
                    {
                        bool vaild = admin.DeleteTeam(connetion, teamIdtxt.Text);
                        if (vaild)
                        {
                            MessageBox.Show("Team  is Deleted Sucessfully", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadDate();
                            LoadDateClckid(teamIdtxt.Text);
                            teamIdtxt.Text = "";
                            teamMembertxt.Text = "";
                            memberemailtxt.Text = "";
                            memberphonetxt.Text = "";
                        }
                        else
                        {

                            MessageBox.Show("Team  is not Deleted Sucessfully", "Result", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("No Row is Selected For Deletion", "warming", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void Deletebtn_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(memberidlbl.Text))
            {
                DialogResult result1 = MessageBox.Show("Do you need to Delete this Member?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result1 == DialogResult.Yes)
                {
                    MessageBox.Show(memberidlbl.Text);
                        bool vaild = admin.DeleteTeamMember(connetion, memberidlbl.Text);
                        if (vaild)
                        {
                            MessageBox.Show("Member  is Deleted Sucessfully", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadDate();
                            LoadDateClckid(teamIdtxt.Text);
                            teamIdtxt.Text = "";
                             memberidlbl.Text = "";
                            teamMembertxt.Text = "";
                            memberemailtxt.Text = "";
                            memberphonetxt.Text = "";
                        }
                        else
                        {

                            MessageBox.Show("Member  is not Deleted Sucessfully", "Result", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                    
                }
            }
            else
            {
                MessageBox.Show("No Row is Selected For Deletion", "warming", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void teamMembergrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DialogResult result = MessageBox.Show("Do you need to select data for updates?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    DataGridViewRow row = teamMembergrid.Rows[e.RowIndex];
                    memberidlbl.Text = row.Cells["DesinerId"]?.FormattedValue.ToString();
                    teamMembertxt.Text = row.Cells["Username"]?.FormattedValue.ToString();
                    memberemailtxt.Text = row.Cells["Email"]?.FormattedValue.ToString();
                    memberphonetxt.Text = row.Cells["Phone"]?.FormattedValue.ToString();
                }
            }
        }

        private void clearbtn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you need Clear All Data?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                teamIdtxt.Text = "";
                passwordtxt.Text = "";
                teamNametxt.Text = "";
                teamLeadertxt.Text = "";
                teammailtxt.Text = "";
                phonetxt.Text = "";
                memberidlbl.Text = "";
                teamMembertxt.Text = "";
                memberemailtxt.Text = "";
                memberphonetxt.Text = "";


            }
        }

        private void passwordtxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void memberphonetxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void pswdresetbtn_Click(object sender, EventArgs e)
        {
            string Id = memberidlbl.Text;

            if (string.IsNullOrWhiteSpace(passwordtxt.Text))
            {
                MessageBox.Show("Password Field cannot be Empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(Id, out int id))
            {
                MessageBox.Show("Invalid ID format. Please ensure the ID is a valid number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show("Do you need to reset the password.?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    bool valid = admin.RestPassword(connetion, id, passwordtxt.Text);
                    if (valid)
                    {
                        MessageBox.Show("Password Reset is Sucessfully", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDate();

                        passwordtxt.Text = "";
                        memberidlbl.Text = "";
                    }
                    else
                    {

                        MessageBox.Show("Password Reset is not  Sucessfully", "Result", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }

                }
                    

            
        }
    }
}

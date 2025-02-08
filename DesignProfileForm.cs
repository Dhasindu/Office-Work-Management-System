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
    public partial class DesignProfileForm : Form
    {
        SqlConnection connetion = DBclass.ConnDatabase();
        DesignProfile Designer = new DesignProfile();
        private int id = 0;
        public DesignProfileForm()
        {
            InitializeComponent();

        }

        private void profileSavebtn_Click(object sender, EventArgs e)
        {
            

            if (!System.Text.RegularExpressions.Regex.IsMatch(emailtxt.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Invalid email address. Please enter a valid email.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(phonenum.Text, @"^[0-9]{10}$"))
            {
                MessageBox.Show("Invalid phone number. Please enter a 10-digit number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string NewName = profileName.Text;
            string Email = emailtxt.Text;
            string NewPhone = phonenum.Text;

            Designer.ProfileUpdated(connetion, Email, NewPhone, NewName, profilebox);
            DesignerClass.CurrentDesigner.name = NewName;

            MessageBox.Show($"New name: {DesignerClass.CurrentDesigner.name}");
        }

        private void DesignProfileForm_Load(object sender, EventArgs e)
        {
            string query = "SELECT * FROM DesinerTable WHERE AuthId=(SELECT Id FROM UserAuthDataTable WHERE Username=@name)";
            SqlCommand cmd = new SqlCommand(query, connetion);
            cmd.Parameters.AddWithValue("@name", DesignerClass.CurrentDesigner.name); // Keeping your approach

            try
            {
                if (connetion.State != System.Data.ConnectionState.Open)
                {
                    connetion.Open(); // Ensuring the connection is open
                }

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        // Assuming proper mapping of columns
                        id = Convert.ToInt32(reader["AuthId"]);
                        profileName.Text = DesignerClass.CurrentDesigner.name; // Profile name from method parameter
                        emailtxt.Text = reader["Email"].ToString(); // Using column name
                        phonenum.Text = reader["Phone"].ToString();   // Using column name

                    }
                }
                else
                {
                    Console.WriteLine("No data found for the specified username.");
                }

                reader.Close(); // Ensure the reader is closed
                Designer.RetriveProfileImages(connetion, id, profilebox);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            finally
            {
                if (connetion.State == System.Data.ConnectionState.Open)
                {
                    connetion.Close(); // Ensure the connection is closed
                }
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfiledailog = new OpenFileDialog();
            if (openfiledailog.ShowDialog() == DialogResult.OK)
            {
                profilebox.Image = new Bitmap(openfiledailog.FileName);
            }
        }

        private void oldPasswordtxt_Click(object sender, EventArgs e)
        {
            ShowHide(oldPasswordtxt, oldpaswdtxt);
        }

        private void NewPasswordtxt_Click(object sender, EventArgs e)
        {

            ShowHide(NewPasswordtxt, newpaswdtxt);
        }

        private void Renewpasswordtxt_Click(object sender, EventArgs e)
        {
            ShowHide(Renewpasswordtxt, renewpawdrxt);
        }

        public void ShowHide(Button btn, TextBox txt)
        {
            if (txt.UseSystemPasswordChar)
            {
                // Show password
                btn.Image = Resources.hidden;
                txt.UseSystemPasswordChar = false;
            }
            else
            {
                // Hide password
                btn.Image = Resources.eye;
                txt.UseSystemPasswordChar = true;
            }
        }

        private void PaswdSavebtn_Click(object sender, EventArgs e)
        {
            bool valid = false;
            string oldpassword = oldpaswdtxt.Text.Trim();
            string Newpassword = newpaswdtxt.Text.Trim();
            string retypepswd = renewpawdrxt.Text.Trim();

            if (!string.IsNullOrWhiteSpace(oldpassword) && !string.IsNullOrWhiteSpace(Newpassword) && !string.IsNullOrWhiteSpace(retypepswd))
            {
                if (DesignerClass.CurrentDesigner != null && (DesignerClass.CurrentDesigner.userType == "Designer" || DesignerClass.CurrentDesigner.userType == null))
                {
                    valid = DBclass.DataChecked(connetion, DesignerClass.CurrentDesigner.name, oldpassword, DesignerClass.CurrentDesigner.userType);
                }
                else
                {
                    valid = false;
                }


                if (valid)
                {
                    if (Newpassword == retypepswd)
                    {
                        if (ProfileClass.ProfilePasswordUpdate(connetion, oldpassword, Newpassword) == true)
                        {
                            MessageBox.Show("Password is Updated Successfully", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            newpaswdtxt.Text = "";
                            renewpawdrxt.Text = "";
                            oldpaswdtxt.Text = "";

                        }
                        else
                        {
                            MessageBox.Show("Password Update Unsuccessful ...Try Again", "Password Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            newpaswdtxt.Text = "";
                            renewpawdrxt.Text = "";
                            oldpaswdtxt.Text = "";
                        }
                    }
                    else
                    {
                        MessageBox.Show("New Password Doesnt Match ...Try Again", "Password Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        newpaswdtxt.Text = "";
                        renewpawdrxt.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("Password Doesnt Match with Exsisting Password...Try Again", "Password Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    oldpaswdtxt.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Password Fields Cannot Be Empty", "Password Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

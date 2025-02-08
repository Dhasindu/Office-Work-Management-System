using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;//useto create image object 

namespace Homepageproject
{
    internal class CustomerProfile : ProfileClass
    {
        public override bool ProfileUpdated(SqlConnection connection, string cmpyname, string Phone, string name, PictureBox profilebox)
        {
            string query1 = "UPDATE Customer SET CompanyName = @cmpyname, Phone = @Phone, Image = @Image WHERE AuthId = (SELECT Id FROM UserAuthDataTable WHERE Username = @name)";
            string query2 = "UPDATE UserAuthDataTable SET Username = @Newname WHERE Username = @Oldname";
            SqlCommand cmd1 = new SqlCommand(query1, connection);
            SqlCommand cmd2 = new SqlCommand(query2, connection);
            try
            {
                if (connection.State != System.Data.ConnectionState.Open)
                {
                    connection.Open();
                }
                cmd1.Parameters.AddWithValue("@name", Customer.CurrentCustomer.name);
                cmd1.Parameters.AddWithValue("@cmpyname", cmpyname);
                cmd1.Parameters.AddWithValue("@Phone", Phone);
                cmd1.Parameters.AddWithValue("@Image", getImage(profilebox));
                cmd1.ExecuteNonQuery();

                cmd2.Parameters.AddWithValue("@Oldname", Customer.CurrentCustomer.name);
                cmd2.Parameters.AddWithValue("@Newname", name);
                cmd2.ExecuteNonQuery();

                MessageBox.Show("Data is Updated Successfully");
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

        public override void RetriveProfileImages(SqlConnection connection, int Id, PictureBox profilebox)
        {

            string query = "SELECT Image FROM Customer WHERE CusId=@Id";
            SqlCommand cmd = new SqlCommand(query, connection);
            try
            {
                if (connection.State != System.Data.ConnectionState.Open)
                {
                    connection.Open();
                }
                cmd.Parameters.AddWithValue("@Id", Id);
                byte[] imageData = (byte[])cmd.ExecuteScalar();
                if (imageData != null)
                {

                    MemoryStream ms = new MemoryStream(imageData);

                    profilebox.Image = Image.FromStream(ms);

                }
                else
                {
                    MessageBox.Show("No image found for the specified ID.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:Image " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

        }
    }
}

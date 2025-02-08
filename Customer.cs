using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Homepageproject
{
    internal class Customer : SystemUsers
    {
        public static Customer CurrentCustomer { get; set; } 
        public string companyName { get; set; }

        public string phoneNumber { get; set; }

        public Customer() { 
            companyName = "no company";
            phoneNumber = "no phone";
        }

        public Customer(string name, string password, string userType,string companyName, string phoneNumber):base( name,  password,  userType) 
        {
            
            this.companyName = companyName;
            this.phoneNumber = phoneNumber;
        }

        public Customer(int id, string name, string userType) : base(id,name, userType)
        {}

       

        public bool AddCustomerData(SqlConnection connection, string name, string password, string companyName, string phoneNumber)
        {
            int Authid = 0;
            string usertype = "Customer";
            string query1 = "INSERT INTO UserAuthDataTable (Username, Password, UserType) VALUES (@Username, @Password, @UserType)";
            bool valid = DBclass.DataChecked(connection, name, password, usertype);

            try
            {
                if (!valid)
                {
                    if (connection.State != System.Data.ConnectionState.Open)
                    {
                        connection.Open();
                    }

                    SqlCommand cmd = new SqlCommand(query1, connection);
                    cmd.Parameters.AddWithValue("@Username", name);
                    cmd.Parameters.AddWithValue("@Password", DBclass.HashPassword(password));
                    cmd.Parameters.AddWithValue("@UserType", usertype);
                    cmd.ExecuteNonQuery();

                    // Fetch AuthId after insertion
                    Authid =GetsId(connection, name);

                    // Corrected the issue with cmd2
                    string query2 = "INSERT INTO Customer (CompanyName, Phone, AuthId) VALUES (@CompanyName, @Phone, @AuthId)";
                    SqlCommand cmd2 = new SqlCommand(query2, connection);
                    if (connection.State != System.Data.ConnectionState.Open)
                    {
                        connection.Open();
                    }
                    cmd2.Parameters.AddWithValue("@CompanyName", companyName);
                    cmd2.Parameters.AddWithValue("@Phone", phoneNumber);
                    cmd2.Parameters.AddWithValue("@AuthId", Authid);
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

        //checked
        public static int GetId(SqlConnection connection, string name)
        {
            try
            {
                if (connection.State != System.Data.ConnectionState.Open)
                {
                    connection.Open();
                }
                string query = "SELECT Id FROM UserAuthDataTable WHERE Username=@name";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@name", name);
                SqlDataReader reader = cmd.ExecuteReader();

                if(reader.HasRows)
                {
                    reader.Read();
                    return reader.GetInt32(0);
                }
                else
                {
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



        public override bool AddUserData(SqlConnection connection, string name, string password, string usertype,string Userstatus)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteUserData(SqlConnection connection, int Id)
        {
            throw new NotImplementedException();
        }


        public override void SearchData(SqlConnection connection, string word, DataGridView datagrid1)
        {
            throw new NotImplementedException();
        }

        public override bool updateUserData(SqlConnection connection, int Id, string name, string password, string usertype, string status)
        {
            throw new NotImplementedException();
        }

       
    }
}

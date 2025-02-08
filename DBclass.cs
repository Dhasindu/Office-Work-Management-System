using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace Homepageproject
{
    internal class DBclass
    {
        public static string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));

                // Manually convert the byte array to a hexadecimal string
                StringBuilder hexString = new StringBuilder();
                foreach (byte b in hashBytes)
                {
                    hexString.Append(b.ToString("x2")); // Convert each byte to a hex string
                }

                return hexString.ToString();
            }
        }

        public static SqlConnection ConnDatabase()
        {
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\utente\\Desktop\\LNBTI\\SEMESTER03\\visualdesign\\Project\\Homepageproject\\Homepageproject\\oFFiceMangmentDB.mdf;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {


                conn.Open();
                Console.WriteLine("Database Connection is Sucessfull", "Databse connection");
                return conn;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Database Connection is Unsuccessful :{ex}", "Coonnection Error");
                return conn;
            }
        }

        public static bool DataChecked(SqlConnection connetion,string name,string password,string userType)
        {
            string query = "SELECT * FROM UserAuthDataTable";
            SqlCommand cmd = new SqlCommand(query, connetion);

            try
            {
                if (connetion.State != System.Data.ConnectionState.Open)
                {
                    connetion.Open();

                }
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {

                    while (reader.Read())
                    {
                        if (name == reader.GetString(1) && DBclass.HashPassword(password) == reader.GetString(2))
                        {
                            return true;
                        }

                    }

                }

                reader.Close();
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
            finally
            { 
                connetion.Close();
            }

        }

    }

}

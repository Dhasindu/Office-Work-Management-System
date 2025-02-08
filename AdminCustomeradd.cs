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
    public partial class AdminCustomeradd : Form
    {
        private SqlConnection connetion = DBclass.ConnDatabase();
        private SqlDataAdapter adapter;
        Admin UserAdmin = new Admin();
        public AdminCustomeradd()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.AdminCustomeradd_Load);
        }

        private void viewbtn_Click(object sender, EventArgs e)
        {

        }

        //Delete Customer Registration
        private void Deletebtn_Click(object sender, EventArgs e)
        {
            string id = Idtxt.Text.Trim();
            if (!string.IsNullOrWhiteSpace(id))
            {
                DialogResult result = MessageBox.Show("Do you need to Reject this Application?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    bool valid = UserAdmin.RejectCustomers(connetion, id);
                    if (valid)
                    {
                        MessageBox.Show("Customer Application is  Rejected", "Result", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        LoadDate();
                    }
                    else
                    {
                        MessageBox.Show("Customer Application is not  Rejected", "Result", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                
            }
            else
            {
                MessageBox.Show("No Customer being Selected.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
        }

        //Search Customer Data from Name and Company
        private void button1_Click(object sender, EventArgs e)
        {

            string word = searchtxt.Text.Trim();

            if (!string.IsNullOrEmpty(word))
            {
                UserAdmin.SearchCustomer(connetion, word, CustomerDataAdmnGrid);
            }
            else
            {

                LoadDate();
            }
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        //Admin Customer Addtion Load Form
        private void AdminCustomeradd_Load(object sender, EventArgs e)
        {
            LoadDate();
            searchtxt.Text = "-- Search --";
            searchtxt.ForeColor = Color.LightGray;
            searchtxt.TextAlign = HorizontalAlignment.Center;

            Idtxt.Text = "Cus ID";
            Idtxt.ForeColor = Color.LightGray;
            Idtxt.TextAlign = HorizontalAlignment.Center;
        }

        private void LoadDate()
        {
            try
            {
                adapter = new SqlDataAdapter("SELECT C.CusId,A.Username,C.CompanyName,C.Phone,C.CustomerStatus FROM Customer C JOIN UserAuthDataTable A ON C.AuthId=A.Id WHERE C.CustomerStatus='Pending'", connetion);

                DataTable dt = new DataTable();

                adapter.Fill(dt);

                CustomerDataAdmnGrid.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex, "Error");
            }
            finally { connetion.Close(); }

        }

        //Accepts button
        private void insertbtn_Click(object sender, EventArgs e)
        {
            string id = Idtxt.Text.Trim();
            if (!string.IsNullOrWhiteSpace(id))
            {
                bool valid= UserAdmin.AcceptsCustomers(connetion, id);
                if (valid)
                {
                    MessageBox.Show("Customer Application is  Approved", "Result", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    LoadDate();
                }
                else
                {
                    MessageBox.Show("Customer Application is not Approved", "Result", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }

            }
            
        }

        private void CustomerDataAdmnGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0) // Ensure the click is on a valid cell
            {
                // Get the current row
                DataGridViewRow row = CustomerDataAdmnGrid.Rows[e.RowIndex];

                // Display the values in labels
                Idtxt.Text = row.Cells["CusId"].FormattedValue.ToString();
                
            }
        }

        //clear button
        private void updatebtn_Click(object sender, EventArgs e)
        {
            Idtxt.Text="";
            searchtxt.Text = "";
            LoadDate();
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
            if (Idtxt.Text == "Cus ID")
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
                Idtxt.Text = "Cus ID";
                Idtxt.ForeColor = Color.LightGray;
                Idtxt.TextAlign = HorizontalAlignment.Left;
            }
        }
    }
}

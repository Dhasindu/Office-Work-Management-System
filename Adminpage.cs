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
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Homepageproject
{
    public partial class Adminpage : Form
    {
        

        Admin UserAdmin =new Admin();
        SqlConnection connection = DBclass.ConnDatabase();
        public Adminpage()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            
            SystemUsers.showform(new AdminaddManager(),mainpanel);
        }


       
        

        private void button10_Click(object sender, EventArgs e)
        {
            SystemUsers.showform(new AdminCustomeradd(), mainpanel);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SystemUsers.showform(new AdminAddDesignTeam(), mainpanel);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            // Show a confirmation message before logging out
            DialogResult result = MessageBox.Show("Are you sure you want to log out?", "Logout Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (result == DialogResult.OK)
            {
                // Show a success message (optional)
                MessageBox.Show("You have been logged out successfully.", "Logout", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Redirect to login form (assuming 'Form1' is the login form)
                Form1 loginForm = new Form1(); // Create a new instance of the login form
                loginForm.Show();  // Show login form
                this.Hide();  // Hide current form (assuming this is the main form)
            }
        }
    }
}

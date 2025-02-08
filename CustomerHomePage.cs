using Homepageproject.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Homepageproject
{
    public partial class CustomerHomePage : Form
    {
        bool check = false;
        public CustomerHomePage()
        {
            InitializeComponent();
            SystemUsers.showform(new CustomerDashboard(), Cusmainpanel);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SystemUsers.showform(new CustomerDashboard(), Cusmainpanel);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void btnArrowUpDown_Click(object sender, EventArgs e)
        {

        }

        bool checks = false;

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (checks)
            {
                // Expanding the panel
                panel3.Height += 10;

                // Stop expanding when maximum height is reached
                if (panel3.Size == panel3.MaximumSize)
                {
                    timer2.Stop();
                    checks = false; // Next action will be collapse
                    chtUpDownbtn.Image = Resources.downarrow; // Change button image to collapse icon
                }
            }
            else
            {
                // Collapsing the panel 
                panel3.Height -= 10;

                // Stop collapsing when minimum height is reached
                if (panel3.Size == panel3.MinimumSize)
                {
                    timer2.Stop();
                    checks = true; // Next action will be expand
                    chtUpDownbtn.Image = Resources.uparrow; // Change button image to expand icon
                }
            }
        }

        private void chtUpDownbtn_Click(object sender, EventArgs e)
        {
            timer2.Start();
        }

        //update Profilebtn
        private void button6_Click(object sender, EventArgs e)
        {



        }

        private void button7_Click(object sender, EventArgs e)
        {
            SystemUsers.showform(new PasswordUpdateprofile(), Cusmainpanel);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SystemUsers.showform(new CustomerTask(), Cusmainpanel);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SystemUsers.showform(new Profile(), Cusmainpanel);
        }

        private void Managerbtn_Click(object sender, EventArgs e)
        {
            SystemUsers.showform(new UserCommuncationForm(), Cusmainpanel);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            SystemUsers.showform(new UserCommuncationForm(), Cusmainpanel);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Show a confirmation message before logging out
            DialogResult result = MessageBox.Show("Are you sure you want to log out?", "Logout Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (result == DialogResult.OK)
            {
                // Clear the current customer session
                Customer.CurrentCustomer = null;

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

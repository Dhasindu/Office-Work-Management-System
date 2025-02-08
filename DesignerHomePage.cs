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
    public partial class DesignerHomePage : Form
    {
        public DesignerHomePage()
        {
            InitializeComponent();
            SystemUsers.showform(new DesignerDashboard(), DesignerPanel);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SystemUsers.showform(new DesignProfileForm(), DesignerPanel);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            SystemUsers.showform(new DesignerTask(), DesignerPanel);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SystemUsers.showform(new DesignerTaskProgress(), DesignerPanel);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            SystemUsers.showform(new DesignerDashboard(), DesignerPanel);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            SystemUsers.showform(new UserCommuncationForm(), DesignerPanel);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            // Show a confirmation message before logging out
            DialogResult result = MessageBox.Show("Are you sure you want to log out?", "Logout Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (result == DialogResult.OK)
            {
                // Clear the current customer session
                DesignerClass.CurrentDesigner = null;

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

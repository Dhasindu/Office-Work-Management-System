using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Deployment.Internal;

namespace Homepageproject
{
    public partial class Form1 : Form
    {
        Admin UserAdmin = new Admin();
        SqlConnection conn = DBclass.ConnDatabase();

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Parent = pictureBox1;
            label1.BackColor = Color.Transparent;
            UserNametext.Parent = pictureBox1;
            UserNametext.BackColor = Color.Transparent;

            pswdtxt.Parent = pictureBox1;
            pswdtxt.BackColor = Color.Transparent;



            userLogo.Parent = pictureBox1;
            userLogo.BackColor = Color.Transparent;

            pawsdlogo.Parent = pictureBox1;
            pawsdlogo.BackColor = Color.Transparent;

            paswdshow.Parent = pictureBox1;
            paswdshow.BackColor = Color.Transparent;

            
            textregister.Parent = pictureBox1;
            textregister.BackColor = Color.Transparent;

            btnlogreg.Parent = pictureBox1;
            btnlogreg.BackColor = Color.Transparent;

            
           
        }

       
        private int imagenum = 1;
        private void slideshow()
        {
            if (imagenum == 3)
            {
                imagenum = 0;
            }
            //slidebox.ImageLocation = string.Format(@"images\{0}.png", imagenum);
            imagenum++;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           // slideshow();
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(paswdshow.Checked == true)
            {
                passwordtxt.UseSystemPasswordChar = false;
            }
            else
            {
                passwordtxt.UseSystemPasswordChar = true;
            }
        }

        //Login Btn
        private void btnLogin_Click(object sender, EventArgs e)
        {


            //UserAdmin.AddUserData(conn, "admin123", "admin123", "Admin");
            int ids=0;
            string userStatuss = "";
            string name = Username.Text;
            string password = passwordtxt.Text;


            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(password))
            {
                (string userCheck,int id,string userStatus) = SystemUsers.UserLlogin(conn, name, password, ids, userStatuss);
                
                    Username.Text = "";
                    passwordtxt.Text = "";
                   

                if (!System.Text.RegularExpressions.Regex.IsMatch(name, @"^[a-zA-Z0-9]+$"))
                {
                    MessageBox.Show("Username can only contain letters and numbers.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validate password length and complexity
                if (password.Length <2 )
                {
                    MessageBox.Show("Password must be at least 8 characters long.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                //MessageBox.Show(userCheck);
                if (userCheck == "manager")
                {
                    MessageBox.Show("User Login Successful", "Login", MessageBoxButtons.OK, MessageBoxIcon.None);
                    ManagerClass.CurrentManager = new ManagerClass(id, name, "manager");
                    ManagerHomepg Managepg= new ManagerHomepg();
                    Username.Text = "";
                    passwordtxt.Text = "";
                    this.Hide();
                    Managepg.Show();

                 }
            else if (userCheck == "Designer")
            {
                    MessageBox.Show("User Login Successful", "Login", MessageBoxButtons.OK, MessageBoxIcon.None);
                    Username.Text = "";
                    passwordtxt.Text = "";
                    DesignerClass.CurrentDesigner = new DesignerClass(id, name, "Designer");
                  DesignerHomePage homepage= new DesignerHomePage();
                    this.Hide();
                    homepage.Show();

                }
            else if ((userCheck == "Customer") && (userStatus == "Approved"))
            {
                    MessageBox.Show("User Login Successful", "Login", MessageBoxButtons.OK, MessageBoxIcon.None);
                    Customer.CurrentCustomer = new Customer(id,name, "Customer");
                    Username.Text = "";
                    passwordtxt.Text = "";
                    CustomerHomePage customhome = new CustomerHomePage();
                    this.Hide();
                    customhome.Show();
            }
            else if (userCheck == "Admin")
            {
                    MessageBox.Show("User Login Successful", "Login", MessageBoxButtons.OK, MessageBoxIcon.None);
                    Username.Text = "";
                    passwordtxt.Text = "";
              
                    Adminpage adminpage = new Adminpage();
                    this.Hide();
                    adminpage.Show();
            }
            else if(userCheck == null)
            {
                
                Username.Text = "";
                passwordtxt.Text = "";
              
                MessageBox.Show("Incorrect Credentials Check Again...", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            }
            else
            {
                MessageBox.Show("All fields Should be not null", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        //Customer Register
        private void btnlogreg_Click(object sender, EventArgs e)
        {
            SignUpPage sgnup= new SignUpPage();
            this.Hide();
            sgnup.Show();
        }

        private void UserNametext_Click(object sender, EventArgs e)
        {

        }

        private void backbtn_Click(object sender, EventArgs e)
        {

        }

        private void slidebox_Click(object sender, EventArgs e)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Homepageproject
{
    internal class DesignerClass : SystemUsers
    {
        public static DesignerClass CurrentDesigner { get; set; }

        public string Email { get; set; }

        public string phoneNumber { get; set; }

        public DesignerClass()
        {
            Email = "no Email";
            phoneNumber = "no phone";
        }

        public DesignerClass(string name, string password, string userType, string Email, string phoneNumber) : base(name, password, userType)
        {

            this.Email = Email;
            this.phoneNumber = phoneNumber;
        }

        public DesignerClass(int id, string name, string userType) : base(id, name, userType)
        { }



        public override bool AddUserData(SqlConnection connection, string name, string password, string usertype, string UserStatus)
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

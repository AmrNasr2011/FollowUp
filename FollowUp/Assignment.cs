using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FollowUp
{
    public partial class Assignment : Form
    {
        public Assignment()
        {
            InitializeComponent();
        }

        private void Assignment_Load(object sender, EventArgs e)
        {
            //here should load all data related to client based on his role

            dataGridOffer.DataSource = loadOffer(FollowUpCore.UserRole, FollowUpCore.UserSESA, FollowUpCore.UserDepartment);
            dataGridOrders.DataSource = loadOrders(FollowUpCore.UserRole, FollowUpCore.UserSESA, FollowUpCore.UserDepartment);

        }
        DataTable loadOffer(string Role, string UserS,string Depart)
        {
            
            AccessDB a = new AccessDB();
            if (Role == "Planner")
            {//all opened
                
               return AccessDB.Read_DataSet(null, "AssginOffer", "*");

            }
            else if (Role == "Designer")
            {//open only Complexity , Due Date, Comment

               return a.Get_table_withFilter("SELECT * from  AssginOffer WHERE Designer='" + UserS + "'");
            }
            else if(Role == "Manager")
            {//all opened
                return a.Get_table_withFilter("SELECT * from  AssginOffer WHERE Department='" + Depart + "'");

            }
            else if (Role == "Team Leader")
            {
                //open all except teamleader tab
                return a.Get_table_withFilter("SELECT * from  AssginOffer WHERE Department='" + Depart + "' AND [Team Leader]="+UserS+ "' or [Team Leader] IS NULL  or [Team Leader]='' ");
            }
            else
            {
                return null;
            }
        }

        DataTable loadOrders(string Role, string UserS, string Depart)
        {
            AccessDB a = new AccessDB();
            if (Role == "Planner")
            {//all opened

                return AccessDB.Read_DataSet(null, "AssginOrder", "*");

            }
            else if (Role == "Designer")
            {//open only Complexity , Due Date, Comment
                return a.Get_table_withFilter("SELECT * from  AssginOrder WHERE Designer='" + UserS + "'");
            }
            else if (Role == "Manager")
            {//all opened
                return a.Get_table_withFilter("SELECT * from  AssginOrder WHERE Department='" + Depart + "'");

            }
            else if (Role == "Team Leader")
            {
                //open all except teamleader tab
                return a.Get_table_withFilter("SELECT * from  AssginOrder WHERE Department='" + Depart + "' AND [Team Leader]=" + UserS + "' or [Team Leader] IS NULL  or [Team Leader]='' ");
            }
            else
            {
                return null;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridOffer.DataSource = loadOffer(FollowUpCore.UserRole, FollowUpCore.UserSESA, FollowUpCore.UserDepartment);
            dataGridOrders.DataSource = loadOrders(FollowUpCore.UserRole, FollowUpCore.UserSESA, FollowUpCore.UserDepartment);
        }
    }
}

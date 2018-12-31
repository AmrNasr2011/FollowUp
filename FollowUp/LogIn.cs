using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FollowUp
{
    public partial class LogIn : Form
    {
    
        public LogIn()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AccessDB a = new AccessDB();
            DataTable pass;
            Dictionary<string, string> z = new Dictionary<string, string>();
            z.Add("sesa", tb_User.Text.ToUpper());
            z.Add("password", tb_Password.Text.ToUpper());

            try
            {
                pass = AccessDB.Read_DataSet(z, "general", "*");
                if (pass.Rows.Count > 0) //user exist
                {
                  
                    // here i need to read employee role in order to map him to correct screen
                    FollowUpCore.UserSESA = tb_User.Text.ToUpper(); //here i get user sesa
                    FollowUpCore.UserName = pass.Rows[0]["designer"].ToString();//return designer name
                    FollowUpCore.UserManager = pass.Rows[0]["Team Leader"].ToString();//return user manager or team leader
                    FollowUpCore.UserDepartment = pass.Rows[0]["Department"].ToString();//LV or MV or All
                    FollowUpCore.UserRole = pass.Rows[0]["role"].ToString();//posation 
                    tb_Password.Text = "";
                    //Open equevelent form based on user Role.
                    switch (FollowUpCore.UserRole)
                    {
                        case "Planner":
                            Main_TeamLeader q = new Main_TeamLeader();
                            this.Hide();
                            q.ShowDialog();
                            break;
                        case "designer":
                            Main_Designer b = new Main_Designer();
                            this.Hide();
                            b.ShowDialog();
                            break;
                        case "Manager":
                            Main_TeamLeader c = new Main_TeamLeader();
                            this.Hide();
                            c.ShowDialog();
                            break;
                        case "Team Leader":
                            Main_TeamLeader d = new Main_TeamLeader();
                            this.Hide();
                            d.ShowDialog();
                            break;
                        default:
                            break;
                    }
              
                    this.Close();
                }
                else
                {

                    tb_Password.Text = "";
                    MessageBox.Show("Wrong Password or user name");
                }



            }
                catch (Exception exp)
            {
                tb_Password.Text = "";
                 MessageBox.Show(exp.Message);
                //    MessageBox.Show(exp.Message);
            }

        }

        private void LogIn_Load(object sender, EventArgs e)
        {
       

            //check remote database existence.
            // string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Properties.Settings.Default.RemoteDBLOC + Properties.Settings.Default.password;
            //int remote_version = AccessDB.version_num(connectionString);
            //////@@@@#### in future bring table of passwords as check and check from it
            if (!AccessDB.check_DB_file_exist(Properties.Settings.Default.RemoteDBLOC))
            {
                DB_Location.app_close = 10;
                DB_Location loc = new DB_Location();
                this.Visible=false;
               
                loc.ShowDialog();
                if (DB_Location.app_close==10)
                {
                    this.Close();

                }
            }

        }

        private void LogIn_KeyDown(object sender, KeyEventArgs e)
        {
            {
                if (e.KeyCode == Keys.Enter)
                {
                    button1.PerformClick();
                }
            }
        }

        private void tb_Password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
            }
        }

        private void LogIn_Shown(object sender, EventArgs e)
        {
            if (UpdateTool.Update())
            {
                this.Close();
            }
        }
    }
}

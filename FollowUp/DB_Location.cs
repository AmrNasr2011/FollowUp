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
    public partial class DB_Location : Form
    {
        static public string status;
        static public string comment = "";
        static public int app_close = 0;
        static public int save_pressed = 0;
        public DB_Location()
        {
            InitializeComponent();
        }

        private void DB_Location_Load(object sender, EventArgs e)
        {
            URL_Link.Text = Properties.Settings.Default.RemoteDBLOC;
            URL_Note.Text = DB_Location.comment;
            DB_Location.comment = "";
            
        }

        private void URL_Link_TextChanged(object sender, EventArgs e)
        {
            URL_Link.Text = URL_Link.Text.Replace("\"", "");
        }

        private void URL_Test_Click(object sender, EventArgs e)
        {
            //link exist let's check if it works
           // string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + URL_Link.Text + Properties.Settings.Default.password;
            //check if we can access remote DB
            int remote_version = AccessDB.version_num(URL_Link.Text);

            if (remote_version < 0)
            {
                URL_Note.Text = "Not Valid Link to database";
            }
            else
            {
                URL_Note.Text = "Valid Link to database";
            }
        }

        private void URL_Save_Click(object sender, EventArgs e)
        {
            //here i will save blindly added link and change status of DB_location and close form
           // string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + URL_Link.Text + Properties.Settings.Default.password;
            Properties.Settings.Default.RemoteDBLOC = URL_Link.Text;
            Properties.Settings.Default.Save();
            int remote_version = AccessDB.version_num(Properties.Settings.Default.RemoteDBLOC);
            if (remote_version < 0)
            {
                DialogResult dialogResult =  MessageBox.Show("Used Database link is invalid or unreachable, kindly press OK to change remote database URL to valid location or Cancel to close application", "Warning", MessageBoxButtons.OKCancel);
                if (dialogResult == DialogResult.OK)
                {
                    app_close = 10;
                    
                    
                }
                else
                {
                    app_close = 10;//terminate app based on user request
                    this.Close();
                    
                }
            }
            else
            {
                app_close = 0;
                this.Close();
            }

            
        }

        private void URL_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DB_Location_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DB_Location.status == "close")
            {
                app_close = 1;
            }
        }
    }
}

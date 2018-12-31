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
    public partial class PasswordChange : Form
    {
        public PasswordChange()
        {
            InitializeComponent();
        }

        private void bt_submit_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "")
            {
                MessageBox.Show("Please enter Password");
                return;
            }
            if (textBox1.Text == textBox2.Text)
            {
                //upload new password
                AccessDB a = new AccessDB();
                Dictionary<string, string> set = new Dictionary<string, string>();
                Dictionary<string, string> where = new Dictionary<string, string>();
                set.Add("password", textBox2.Text);
                where.Add("sesa", FollowUpCore.UserSESA);
                a.Update_data(set, where, "general");
                this.Close();
            }
            else
            {
                
                MessageBox.Show("Please check your password");
                textBox2.Text = "";
            }
        }

        private void bt_cancel_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }
    }
}

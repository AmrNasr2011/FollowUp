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
    public partial class otherTask : Form
    {
        public int current = 0;
        public int counter;
        public bool lock_change = false;
        public static bool changed = false;
        DataTable Data_table = new DataTable();//this table will contain items till form close (all operations will done on it

        public otherTask()
        {
            InitializeComponent();
            Data_table.Columns.Add("designer");
            Data_table.Columns.Add("teamleader");
            Data_table.Columns.Add("task");
            Data_table.Columns.Add("description");
            Data_table.Columns.Add("Require date");
            Data_table.Columns.Add("Due Date");
            Data_table.Columns.Add("Actual Date");
            Data_table.Columns.Add("Work_hours");
            Data_table.Columns.Add("Comment");
            Data_table.Columns.Add("SESA");

        }

        private void otherTask_Load(object sender, EventArgs e)
        {
            DataSet data = new DataSet();
            AccessDB a = new AccessDB();
            if (a.connectionStringW == a.connectionStringR)
            {
                LBL_Access.Text = "Online";
            }
            else
            {
                LBL_Access.Text = "Offline";
            }
            AccessDB.data_Dic = new Dictionary<string, DataTable>();

            Dictionary<string, string> z = new Dictionary<string, string>();
            Employe_name.Text = FollowUpCore.UserName;

        }
        private bool validate()
        {
            if (TaskName.Text == "")
            {
                MessageBox.Show("Task Name  cannot be empty");
                return false;
            }
            else if (Description.Text == "")
            {
                MessageBox.Show("Description cannot be empty");
                return false;
            }
           
            else
            {
                return true;
            }
        }

        private void Apply_Click(object sender, EventArgs e)
        {
            //check basic required data added
            if (!validate())
            {
                return;
            }
            // here i will start to add data to Data_table using current curser as row index
            if (counter == current) //new entry
            {

                DataRow A_row = Data_table.NewRow();
                A_row["SESA"] = FollowUpCore.UserSESA.ToUpper();
                A_row["designer"] = FollowUpCore.UserName;
                A_row["teamleader"] = FollowUpCore.UserManager;
                A_row["task"] = TaskName.Text;
                A_row["description"] = Description.Text;
                A_row["Require date"] = RequestDatet.Text == "" ? null : RequestDatet.Text;

                A_row["Due Date"] = DueDatet.Text == "" ? null : DueDatet.Text;
                A_row["Work_hours"] = Hours.Text;

                A_row["Comment"] = Comment.Text;
                 Data_table.Rows.Add(A_row);

                current++;
                counter++;
                tb_current.Text = current.ToString();

            }
            else//modified entry
            {
                DataRow A_row;
                A_row = Data_table.Rows[current];
                tb_current.Text = current.ToString();
                A_row["SESA"] = FollowUpCore.UserSESA.ToUpper();
                A_row["designer"] = FollowUpCore.UserName;
                A_row["teamleader"] = FollowUpCore.UserManager;
                A_row["task"] = TaskName.Text;
                A_row["description"] = Description.Text;
                A_row["Require date"] = RequestDatet.Text == "" ? null : RequestDatet.Text;

                A_row["Due Date"] = DueDatet.Text == "" ? null : DueDatet.Text;
                A_row["Work_hours"] = Hours.Text;

                A_row["Comment"] = Comment.Text;

            }
           
        }
        private void Upload_data()
        {
            AccessDB a = new AccessDB();
            Dictionary<string, string> dic_where = new Dictionary<string, string>();
            dic_where.Add("SESA", FollowUpCore.UserSESA.ToUpper());
            a.Upload_table(Data_table, "other", dic_where);
        }
        private void RequestDatet_TextChanged(object sender, EventArgs e)
        {
            DateTime temp;
            if (DateTime.TryParse(RequestDatet.Text, out temp))
            {
                if (temp < RequestDate.MaxDate && temp > RequestDate.MinDate)//  && RequestDatet.Text.Length == 10)
                {
                    RequestDate.Value = temp;
                }

            }
        }

        private void RequestDate_ValueChanged(object sender, EventArgs e)
        {
            RequestDatet.Text = RequestDate.Text;
        }

        private void DueDatet_TextChanged(object sender, EventArgs e)
        {
            DateTime temp;
            if (DateTime.TryParse(DueDatet.Text, out temp))
            {
                if (temp < DueDate.MaxDate && temp > DueDate.MinDate)// && DueDatet.Text.Length == 10)
                {
                    DueDate.Value = temp;
                }

            }

        }

        private void DueDate_ValueChanged(object sender, EventArgs e)
        {
            DueDatet.Text = DueDate.Text;
        }

        private void Next_Click(object sender, EventArgs e)
        {
            if (current == counter)
            {
                tb_current.Text = current.ToString();//show current
            }
            else if (current == counter - 1)
            {
                current++;
                tb_current.Text = current.ToString();

            }

            else
            {
                current++;
                tb_current.Text = current.ToString();
                updateview();
            }
        }
        void updateview()
        {
            DataRow A_row;
            A_row = Data_table.Rows[current];
            tb_current.Text = current.ToString();
            TaskName.Text= A_row["task"].ToString() ;
            Description.Text = A_row["description"].ToString();
            RequestDatet.Text = A_row["Require date"].ToString();

            DueDatet.Text = A_row["Due Date"].ToString();
            Hours.Text=A_row["Work_hours"].ToString() ;

            Comment.Text = A_row["Comment"].ToString() ;
          

        }

        private void Prev_Click(object sender, EventArgs e)
        {
            if (current == 0)
            {
                tb_current.Text = current.ToString();//show current
            }
            else
            {
                current = current - 1;
                updateview();
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            Upload_data();
            if (counter>0)
            {
                changed = true;
            }
            
            this.Close();
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            if (counter == 0)
            {
                return;
            }
            else if (counter == current)
            {
                return;
            }
            else
            {
                DataRow A_row;
                A_row = Data_table.Rows[current];
                counter--;
                Data_table.Rows.Remove(A_row);

            }
        }

        private void Clear_Click(object sender, EventArgs e)
        {

            TaskName.Text = "";
            Description.Text = "";
            RequestDatet.Text = "";

            DueDatet.Text = "";
            Hours.Text = "";

            Comment.Text = "";
        }
    }
}

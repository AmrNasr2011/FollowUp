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
    public partial class spare : Form
    {
        public int current = 0;
        public int counter;
        public bool lock_change = false;
        public static bool changed = false;

        DataTable spare_table = new DataTable();
        public spare()
        {
            InitializeComponent();
            ////////////initialize spare table
            spare_table.Columns.Add("designer");
            spare_table.Columns.Add("teamleader");
            spare_table.Columns.Add("Spare Header");
            spare_table.Columns.Add("order name");
            spare_table.Columns.Add("Complexity");
            spare_table.Columns.Add("request by");
            spare_table.Columns.Add("Receive Date");
            spare_table.Columns.Add("Due Date");
            spare_table.Columns.Add("WBS");
            spare_table.Columns.Add("Celling Hours");
            spare_table.Columns.Add("TCR/TCO/PM");
            spare_table.Columns.Add("Actual Date");
            spare_table.Columns.Add("Comment");
            spare_table.Columns.Add("SESA");
            spare_table.Columns.Add("Working Hours");
        }

        private void spare_Load(object sender, EventArgs e)
        {
            DataSet data = new DataSet();
            AccessDB a = new AccessDB();
            lbl_status.Text = "new";
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
            DataTable asd = new DataTable();
            //load all dropboxes @@@@could be added in login form to enhance performance
            Complexity.Items.Add("SIMPLE");
            Complexity.Items.Add("MEDIUM");
            Complexity.Items.Add("COMPLEX");
            requestby.Items.Add("TCR");
            requestby.Items.Add("F.O");
        }

        private bool validate()
        {
            if (OrderName.Text == "")
            {
                MessageBox.Show("Order Name  cannot be empty");
                return false;
            }
            else if (SpareHeader.Text == "")
            {
                MessageBox.Show("Spare Header cannot be empty");
                return false;
            }

            else
            {
                return true;
            }
        }

        private void Apply_Click(object sender, EventArgs e)
        {
            if (!validate())
            {
                return;
            }
            // here i will start to add data to Data_table using current curser as row index
            if (counter == current) //new entry
            {

                DataRow A_row = spare_table.NewRow();
                lbl_status.Text = "new";
                A_row["designer"] = FollowUpCore.UserName;
                A_row["teamleader"] = FollowUpCore.UserManager;
                A_row["Spare Header"] = SpareHeader.Text;
                A_row["order name"] = OrderName.Text;
                A_row["Complexity"] = Complexity.Text;
                A_row["request by"] = whorequest.Text;
                A_row["Receive Date"] = RequestDatet.Text == "" ? null : RequestDatet.Text;
                A_row["Due Date"] = DueDatet.Text == "" ? null : DueDatet.Text;
                A_row["WBS"] = WBS.Text;
                A_row["Celling Hours"] = CellHours.Text;
                A_row["TCR/TCO/PM"] = requestby.Text;
                A_row["Comment"] = Comment.Text;
                A_row["SESA"] = FollowUpCore.UserSESA.ToUpper();
                A_row["Working Hours"] = Hours.Text;


                spare_table.Rows.Add(A_row);

                current++;
                counter++;
                tb_current.Text = current.ToString();
            }
            else//modified entry
            {
                DataRow A_row;
                A_row = spare_table.Rows[current];
                A_row["designer"] = FollowUpCore.UserName;
                A_row["teamleader"] = FollowUpCore.UserManager;
                A_row["Spare Header"] = SpareHeader.Text;
                A_row["order name"] = OrderName.Text;
                A_row["Complexity"] = Complexity.Text;
                A_row["request by"] = whorequest.Text;
                A_row["Receive Date"] = RequestDatet.Text == "" ? null : RequestDatet.Text;
                A_row["Due Date"] = DueDatet.Text == "" ? null : DueDatet.Text;
                A_row["WBS"] = WBS.Text;
                A_row["Celling Hours"] = CellHours.Text;
                A_row["TCR/TCO/PM"] = requestby.Text;
                A_row["Comment"] = Comment.Text;
                A_row["SESA"] = FollowUpCore.UserSESA.ToUpper();
                A_row["Working Hours"] = Hours.Text;
            }
        }

        void updateview()
        {
            DataRow A_row;
            A_row = spare_table.Rows[current];
            tb_current.Text = current.ToString();

            SpareHeader.Text =  A_row["Spare Header"].ToString();
            OrderName.Text= A_row["order name"].ToString()  ;
            Complexity.Text = A_row["Complexity"].ToString() ;
            whorequest.Text= A_row["request by"].ToString()  ;
            RequestDatet.Text = A_row["Receive Date"].ToString()  ;
            DueDatet.Text = A_row["Due Date"].ToString()  ;
            WBS.Text = A_row["WBS"].ToString()  ;
            CellHours.Text = A_row["Celling Hours"].ToString()  ;
            requestby.Text = A_row["TCR/TCO/PM"].ToString()  ;
            Comment.Text = A_row["Comment"].ToString() ;
            Hours.Text = A_row["Working Hours"].ToString()  ;

        }
        private void Upload_data()
        {
            AccessDB a = new AccessDB();
            Dictionary<string, string> dic_where = new Dictionary<string, string>();
            dic_where.Add("SESA", FollowUpCore.UserSESA.ToUpper());
           
            a.Upload_table(spare_table, "spare", dic_where);
        }

        private void Save_Click(object sender, EventArgs e)
        {
            Upload_data();
            if (counter > 0)
            {
                changed = true;
            }
            this.Close();
        }

        private void Next_Click(object sender, EventArgs e)
        {

            if (current == counter)
            {
                lbl_status.Text = "new";
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

        private void RequestDate_ValueChanged(object sender, EventArgs e)
        {
            RequestDatet.Text = RequestDate.Text;
        }

        private void RequestDatet_TextChanged(object sender, EventArgs e)
        {
            DateTime temp;
            if (DateTime.TryParse(RequestDatet.Text, out temp))
            {
                if (temp < RequestDate.MaxDate && temp > RequestDate.MinDate)// && RequestDatet.Text.Length == 10)
                {
                    RequestDate.Value = temp;
                }

            }
        }

        private void DueDate_ValueChanged(object sender, EventArgs e)
        {
            DueDatet.Text = DueDate.Text;
        }

        private void DueDatet_TextChanged(object sender, EventArgs e)
        {
            DateTime temp;
            if (DateTime.TryParse(DueDatet.Text, out temp))
            {
                if (temp < DueDate.MaxDate && temp > DueDate.MinDate)//  && DueDatet.Text.Length == 10)
                {
                    DueDate.Value = temp;
                }

            }
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
                A_row = spare_table.Rows[current];
                counter--;
                spare_table.Rows.Remove(A_row);

            }
        }

        private void Clear_Click(object sender, EventArgs e)
        {

            SpareHeader.Text = "";
            OrderName.Text = "";
            Complexity.Text = "";
            whorequest.Text = "";
            RequestDatet.Text = "";
            DueDatet.Text = "";
            WBS.Text = "";
            CellHours.Text = "";
            requestby.Text = "";
            Comment.Text = "";
            Hours.Text = "";
        }

        private void Prev_Click(object sender, EventArgs e)
        {
            if (current == 0)
            {

                tb_current.Text = current.ToString();//show current
                if (counter == 0)
                {
                    lbl_status.Text = "New";
                }
            }
            else
            {
                lbl_status.Text = "";
                current = current - 1;
                updateview();
            }
        }
    }
}

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
    public partial class drawingModif : Form
    {
        public int current = 0;
        public int counter;
        public bool lock_change = false;
        public static bool changed = false;
        DataTable Data_table = new DataTable();//this table will contain items till form close (all operations will done on it

        public drawingModif()
        {
            InitializeComponent();
            Data_table.Columns.Add("designer");
            Data_table.Columns.Add("teamleader");
            Data_table.Columns.Add("Drawing Name");
            Data_table.Columns.Add("Drawing No");
            Data_table.Columns.Add("Item No");
            Data_table.Columns.Add("No of Cells");
            Data_table.Columns.Add("Family");
            Data_table.Columns.Add("TCO/TCR/PM");
            Data_table.Columns.Add("Complexity");
            Data_table.Columns.Add("CLO Date");
            Data_table.Columns.Add("Due Date");
            Data_table.Columns.Add("Actual Date");
            Data_table.Columns.Add("Received Date");
            Data_table.Columns.Add("Comment");
            Data_table.Columns.Add("Type of Drawing");
            Data_table.Columns.Add("Work_Hours");
            Data_table.Columns.Add("SESA");
            Data_table.Columns.Add("RequestedBy");
            Data_table.Columns.Add("Modif");
            Data_table.Columns.Add("Task Type");
        }

        private void drawingModif_Load(object sender, EventArgs e)
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
            DataTable asd = new DataTable();
            if (FollowUpCore.UserDepartment == "LV")
            {
                Family.Items.Add("BK7");
                Family.Items.Add("OKKEN");
                Family.Items.Add("SPARE");
            }
            else if (FollowUpCore.UserDepartment == "MV")
            {
                Family.Items.Add("RONEX");
                Family.Items.Add("SM6");
                Family.Items.Add("MCSET123");
                Family.Items.Add("MCSET4");
                Family.Items.Add("VARBLOK");
                Family.Items.Add("PIXROF");
                Family.Items.Add("RETROFET");
            }
            //Complexity is fixed
            Complexity.Items.Add("SIMPLE");
            Complexity.Items.Add("MEDIUM");
            Complexity.Items.Add("COMPLEX");
        }
        private bool validate()
        {
            if (DrawingName.Text == "")
            {
                MessageBox.Show("Drawing Name  cannot be empty");
                return false;
            }
            else if (ItemNo.Text == "")
            {
                MessageBox.Show("Item No cannot be empty");
                return false;
            }
            else if (Family.Text == "")
            {
                MessageBox.Show("Family cannot be empty");
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
                A_row["Drawing Name"] = DrawingName.Text;
                A_row["Drawing No"] = DrawingNo.Text;
                A_row["Item No"] = ItemNo.Text;
                A_row["No of Cells"] = NoCells.Text;
                A_row["Family"] = Family.Text;
                A_row["TCO/TCR/PM"] = RequestBy.Text;
                A_row["Complexity"] = Complexity.Text;
                A_row["Due Date"] = DueDatet.Text == "" ? null : DueDatet.Text;
                A_row["RequestedBy"] = WhoRequest.Text;
                A_row["Received Date"] = ReceiveDatet.Text == "" ? null : ReceiveDatet.Text;
                A_row["Comment"] = Comment.Text;
                A_row["Modif"] = true;
                A_row["Type of Drawing"] = Schematics.Checked ? "Schematics" : "SLD";
                A_row["Task Type"] = isorder.Checked ? "Order" : "Offer";
                A_row["Work_Hours"] = WorkHours.Text;
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
                A_row["Drawing Name"] = DrawingName.Text;
                A_row["Drawing No"] = DrawingNo.Text;
                A_row["Item No"] = ItemNo.Text;
                A_row["No of Cells"] = NoCells.Text;
                A_row["Family"] = Family.Text;
                A_row["TCO/TCR/PM"] = RequestBy.Text;
                A_row["Complexity"] = Complexity.Text;
                A_row["Due Date"] = DueDatet.Text == "" ? null : DueDatet.Text;
                A_row["RequestedBy"] = WhoRequest.Text;            
                A_row["Received Date"] = ReceiveDatet.Text == "" ? null : ReceiveDatet.Text;
                A_row["Comment"] = Comment.Text;
                A_row["Modif"] = true;
                A_row["Type of Drawing"] = Schematics.Checked ? "Schematics" : "SLD";
                A_row["Work_Hours"] = WorkHours.Text;
                A_row["Task Type"] = isorder.Checked ? "Order" : "Offer";
            }

        }
        private void Upload_data()
        {
            AccessDB a = new AccessDB();
            Dictionary<string, string> dic_where = new Dictionary<string, string>();
            dic_where.Add("SESA", FollowUpCore.UserSESA.ToUpper());
            a.Upload_table(Data_table, "Drawing", dic_where);
        }

        private void Save_Click(object sender, EventArgs e)
        {
            Upload_data();
            changed = true;
            this.Close();
        }

        private void ReceiveDatet_TextChanged(object sender, EventArgs e)
        {
            DateTime temp;
            if (DateTime.TryParse(ReceiveDatet.Text, out temp))
            {
                if (temp < ReceiveDate.MaxDate && temp > ReceiveDate.MinDate && ReceiveDatet.Text.Length == 10)
                {
                    ReceiveDate.Value = temp;
                }

            }
        }

        private void DueDatet_TextChanged(object sender, EventArgs e)
        {
            DateTime temp;
            if (DateTime.TryParse(DueDatet.Text, out temp))
            {
                if (temp < DueDate.MaxDate && temp > DueDate.MinDate && DueDatet.Text.Length == 10)
                {
                    DueDate.Value = temp;
                }

            }
        }

        private void ReceiveDate_ValueChanged(object sender, EventArgs e)
        {
            ReceiveDatet.Text = ReceiveDate.Text;
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
            DrawingName.Text = A_row["Drawing Name"].ToString();
            DrawingNo.Text = A_row["Drawing No"].ToString();
            ItemNo.Text = A_row["Item No"].ToString();
            NoCells.Text = A_row["No of Cells"].ToString();
            Family.Text = A_row["Family"].ToString();
            RequestBy.Text = A_row["TCO/TCR/PM"].ToString();
            Complexity.Text = A_row["Complexity"].ToString();
            WhoRequest.Text = A_row["RequestedBy"].ToString();
            DueDatet.Text = A_row["Due Date"].ToString();
            ReceiveDatet.Text = A_row["Received Date"].ToString();
            Comment.Text = A_row["Comment"].ToString();
            if (A_row["Type of Drawing"].ToString() == "Schematics")
            {
                Schematics.Checked = true;
            }
            else
            {
                SLD.Checked = true;
            }

            WorkHours.Text = A_row["Work_Hours"].ToString();

            if (A_row["Task Type"].ToString() == "Order")
            {
                isorder.Checked = true;
            }
            else
            {
                isoffer.Checked = true;
            }
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

        private void button4_Click(object sender, EventArgs e)
        {
            DrawingName.Text = "";
            DrawingNo.Text = "";
            ItemNo.Text = "";
            NoCells.Text = "";
            Family.Text = "";
            RequestBy.Text = "";
            Complexity.Text = "";
            WhoRequest.Text = "";
            DueDatet.Text = "";
            ReceiveDatet.Text = "";
            Comment.Text = "";
            SLD.Checked = true;
            isoffer.Checked = true;
        }
    }
}

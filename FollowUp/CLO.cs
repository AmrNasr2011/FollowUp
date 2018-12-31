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
    public partial class CLO : Form
    {
        static public string CLODate;
        string _family;
        string _complexity;
        string _cells;
        string _startdate;
        string _type;
        public CLO(string family="",string complexity="", string cells="0", string startdate="",string type="")
        {
            InitializeComponent();
            _family = family;
            _complexity = complexity;
            _cells = cells;
            _startdate = startdate;
            _type = type;
        }
        private void CLO_Load(object sender, EventArgs e)
        {
            Complexity.DataSource = FollowUpCore.Complexity;
            Family.DataSource=FollowUpCore.DepartmentTodata(FollowUpCore.UserDepartment, "Family");
            StartDatet.Text = _startdate;
            NumberOfCells.Text = _cells;
            Complexity.Text = _complexity;
            Family.Text = _family;
            this.Text = string.Format("{0} CLO", _type);

        }
        private void StartDatet_TextChanged(object sender, EventArgs e)
        {
            FollowUpCore.TextBoxChange(ref StartDatet, ref StartDate);
        }

        private void StartDate_ValueChanged(object sender, EventArgs e)
        {
            FollowUpCore.DataTimeChange(ref StartDatet, ref StartDate);
        }

        private void CLOSLDButton_Click(object sender, EventArgs e)
        {
            int countdays;
            if (_type == "BBOM" || _type == "NSR")
            {
                _type = "ABOM";
            }
            List<string> str = AccessDB.GetData(new Dictionary<string, string> { { "Cells", NumberOfCells.Text } }, "CLO", string.Format("{0}{1}{2}", _type, Complexity.Text, Family.Text), false);
            if (str.Count==0)
            {
                SLDCLODate.Text = "Out of CLO";

            }
            else
            {
               
                countdays = int.Parse(str[0]);
                if (_type == "BBOM" || _type == "NSR")
                {
                    countdays = countdays + 5;
                }
              SLDCLODate.Text =  FollowUpCore.AddWorkingDayes(StartDate.Value, countdays , FollowUpCore.VacationsList ).ToShortDateString();
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (SLDCLODate.Text == "Out of CLO")
            {
                CLODate = "";
            }
            else
            {
                CLODate = SLDCLODate.Text;
            }
            this.Close();
        }
    }
}

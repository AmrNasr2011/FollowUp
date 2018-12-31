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
    public partial class DateForm : Form
    {
        static public DateTime time;
        static public bool work = false; 
        public DateForm()
        {
            InitializeComponent();
        }

        private void DateForm_Load(object sender, EventArgs e)
        {
            work = false;
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            work = true;
            time =e.Start.Date;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

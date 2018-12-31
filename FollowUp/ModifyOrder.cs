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
    public partial class ModifyOrder : Form
    {
        int RowIndex = -1;
        public ModifyOrder()
        {
            InitializeComponent();
        }

        private void ModifyOrder_Load(object sender, EventArgs e)
        {
            FollowUpCore.LoadOrder.DefaultView.RowFilter = "";
            DGV.DataSource = FollowUpCore.LoadOrder;
            FollowUpCore.adjustDGV(ref DGV, FollowUpCore.MODOrder, FollowUpCore.DetailOrderCols);
        }

        private void DGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //here need to get cell row and based on it get id and project and 
            if (e.RowIndex < 0)
            {
                return;
            }
            DGV.Rows[e.RowIndex].Selected = true;
            //  MessageBox.Show(DGV.Rows[e.RowIndex].Cells["ID"].Value.ToString());
            FollowUpCore.IDOrder = int.Parse(DGV.Rows[e.RowIndex].Cells["ID"].Value.ToString());
            RowIndex = e.RowIndex;
        }

        private void ModifyItem_Click(object sender, EventArgs e)
        {
            //check if Rowindex =-1;//show message nothing selected
            if (RowIndex < 0)
            {
                MessageBox.Show("Nothing Selected");
                return;
            }
            else
            {
                //i need to make filter on offers table and send it to add view
                string filter = string.Format("[Order Name] = '{0}' AND [Project Number] = '{1}'", DGV.Rows[RowIndex].Cells["Order Name"].Value.ToString(), DGV.Rows[RowIndex].Cells["Project Number"].Value.ToString());
                DataView view = new DataView(FollowUpCore.LoadOrder, filter, "", DataViewRowState.CurrentRows);
                DataTable table = view.ToTable();

                this.Visible = false;
                AddOrderDetail or = new AddOrderDetail(table);
                or.ShowDialog();
                this.Close();
            }
        }
    }
}

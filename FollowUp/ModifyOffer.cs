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
    public partial class ModifyOffer : Form
    {
        int RowIndex = -1;
        public ModifyOffer()
        {
            InitializeComponent();
        }

        private void ModifyOffer_Load(object sender, EventArgs e)
        {
            //DataView view = new DataView(FollowUpCore.LoadOffer,"", INsort, DataViewRowState.CurrentRows);
            // table = view.ToTable();
            FollowUpCore.LoadOffer.DefaultView.RowFilter = "";
            DGV.DataSource = FollowUpCore.LoadOffer; 
            FollowUpCore.adjustDGV(ref DGV, FollowUpCore.ModOffer, FollowUpCore.DetailOfferCols);
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
            FollowUpCore.IDOffer = int.Parse(DGV.Rows[e.RowIndex].Cells["ID"].Value.ToString());
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
                string filter = string.Format("[Offer Name] = '{0}' AND [Offer Number] = '{1}'", DGV.Rows[RowIndex].Cells["Offer Name"].Value.ToString(), DGV.Rows[RowIndex].Cells["Offer Number"].Value.ToString());
                DataView view = new DataView(FollowUpCore.LoadOffer, filter, "", DataViewRowState.CurrentRows);
               DataTable table = view.ToTable();
               
                this.Visible = false;
                AddOfferDetail of = new AddOfferDetail(table);
                of.ShowDialog();

                this.Close();
            }

        }
    }
}

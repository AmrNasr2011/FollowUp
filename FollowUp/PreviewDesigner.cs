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
    public partial class PreviewDesigner : Form
    {
        DataTable table;
        Prp[] INcoloms;
        string INrowfilter;
        string INsort;
        DataTable INSourceTable;
        string[] INcolomnheaders;
        string INtargetcol;
        string INDBTableName;
        string INFormName;
        public PreviewDesigner(Prp[] coloms, string rowfilter, string sort, ref DataTable SourceTable, string[] colomnheaders, string targetcol, string DBTableName, string FormName)
        {
            INcoloms = coloms;
            INrowfilter = rowfilter;
            INsort = sort;
            INSourceTable = SourceTable;
            INcolomnheaders = colomnheaders;
            INtargetcol = targetcol;
            INDBTableName = DBTableName;
            INFormName = FormName;
            InitializeComponent();
        }
        private void PreviewDesigner_Load(object sender, EventArgs e)
        {
            this.Text = INFormName;
            DataView view = new DataView(INSourceTable, INrowfilter, INsort, DataViewRowState.CurrentRows);
            table = view.ToTable();
            DGV.DataSource = table;
            FollowUpCore.adjustDGV(ref DGV, INcoloms, INcolomnheaders);
            int i = 0;
            foreach (Prp item in INcoloms)
            {
                i = i + item.width;
            }
            this.Width = i + 100;
        }
        private void DGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DGV.CurrentCell.OwningColumn.Name == INtargetcol)
            {
                if (DGV.CurrentCell.Value == DBNull.Value || DGV.CurrentCell.Value == null)
                {
                    DGV.CurrentCell.Value = DateTime.Today;
                }

            }
        }
        private void Submit_Click(object sender, EventArgs e)
        {
            if (validate())
            {
                FollowUpCore.updateTablebytable(ref INSourceTable, table, null);
                AccessDB.Modify_table(INSourceTable, INDBTableName, "SELECT * FROM " + INDBTableName + " WHERE [" + FollowUpCore.UserRole + "]='" + FollowUpCore.UserName + "'");
                MessageBox.Show("Update Succesfuly");

            }
            else
            {
                return;
            }
        }

        bool validate()
        {
            foreach (DataGridViewRow row in DGV.Rows)
            {
                if (!(DateTime.TryParse(row.Cells[INtargetcol].Value.ToString(), out DateTime x) || row.Cells[INtargetcol].Value == DBNull.Value || row.Cells[INtargetcol].Value == null))
                {
                    MessageBox.Show("Added Data in Row " + row.Index.ToString() + " is wrong", "Wrong Entered Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;

                }

                //More code here
            }
            return true;
        }

        private void DGV_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            string headerText =
          DGV.Columns[e.ColumnIndex].HeaderText;

            // Abort validation if cell is not in the CompanyName column.
            if (headerText.Equals(INtargetcol))
            {

                // Confirm that the cell is not empty.
                if (!string.IsNullOrEmpty(e.FormattedValue.ToString()) && !DateTime.TryParse(e.FormattedValue.ToString(), out DateTime x))
                {
                    DGV.Rows[e.RowIndex].ErrorText =
                        "Error in Date";

                    e.Cancel = true;
                }
            }
        }

        private void DGV_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DGV.Rows[e.RowIndex].ErrorText = String.Empty;
        }

        private void DGV_KeyUp(object sender, KeyEventArgs e)
        {
            //if user clicked Shift+Ins or Ctrl+V(paste from clipboard)

            if ((e.Shift && e.KeyCode == Keys.Insert) || (e.Control && e.KeyCode == Keys.V))

            {
                int loopcount = 0;
                char[] rowSplitter = { '\r', '\n' };

                char[] columnSplitter = { '\t' };

                //get the text from clipboard

                IDataObject dataInClipboard = Clipboard.GetDataObject();

                string stringInClipboard = (string)dataInClipboard.GetData(DataFormats.Text);

                //split it into lines

                string[] rowsInClipboard = stringInClipboard.Split(rowSplitter, StringSplitOptions.RemoveEmptyEntries);

                //get the row and column of selected cell in grid

                int r = DGV.SelectedCells[0].RowIndex;

                int c = DGV.SelectedCells[0].ColumnIndex;
                //check if number of cells in clipboard
                if (rowsInClipboard.Length == 1)
                {
                    Int32 selectedCellCount =   DGV.GetCellCount(DataGridViewElementStates.Selected);
                    string[] valuesInRow = rowsInClipboard[0].Split(columnSplitter);
                    for (int iRow = 0; iRow < selectedCellCount; iRow++)
                    {
                        //split row into cell values
                        //cycle through cell values
                        if (!DGV.Rows[DGV.SelectedCells[iRow].RowIndex].Cells[DGV.SelectedCells[iRow].ColumnIndex].ReadOnly)
                        {
                            DGV.Rows[DGV.SelectedCells[iRow].RowIndex].Cells[DGV.SelectedCells[iRow].ColumnIndex].Value = valuesInRow[0];
                        }

                    }

                    return;
                }


                //add rows into grid to fit clipboard lines
                
                if (DGV.Rows.Count < (r + rowsInClipboard.Length))

                {
                    loopcount = DGV.Rows.Count - r;
                    //not accepted to add lines to datagrid view
                    //  DGV.Rows.Add(r + rowsInClipboard.Length - DGV.Rows.Count);

                }
                else
                {
                    loopcount = rowsInClipboard.Length;
                }

                // loop through the lines, split them into cells and place the values in the corresponding cell.

                for (int iRow = 0; iRow < loopcount; iRow++)

                {

                    //split row into cell values

                    string[] valuesInRow = rowsInClipboard[iRow].Split(columnSplitter);

                    //cycle through cell values

                    for (int iCol = 0; iCol < valuesInRow.Length; iCol++)

                    {

                        //assign cell value, only if it within columns of the grid

                        if (DGV.ColumnCount - 1 >= c + iCol)

                        {
                            if (!DGV.Rows[r + iRow].Cells[c + iCol].ReadOnly)
                            {
                                DGV.Rows[r + iRow].Cells[c + iCol].Value = valuesInRow[iCol];
                            }
                           

                        }

                    }

                }

            }

        }
    }
}


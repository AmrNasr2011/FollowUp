using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace FollowUp
{
    public partial class ExtractTasksReport : Form
    {
        bool filterapplied = false;
        List<DataGridView> views;
        StringFormat strFormat; //Used to format the grid rows.
        int tablecount = 0;
        int Rowcount = 0;
        int wcount = 0;
        string itemstats = "";
        bool firstenter = true;
        ArrayList arrColumnLefts = new ArrayList();//Used to save left coordinates of columns
        ArrayList arrColumnWidths = new ArrayList();//Used to save column widths
        int iCellHeight = 0; //Used to get/set the datagridview cell height
        int iTotalWidth = 0; //
        int iRow = 0;//Used as counter
        bool isdesigner = false;
        bool bFirstPage = false; //Used to check whether we are printing first page
        bool bNewPage = false;// Used to check whether we are printing a new page
        int iHeaderHeight = 0; //Used for the header height
        DataSet tableset;
        public ExtractTasksReport(bool _isdesigner)
        {

            isdesigner = _isdesigner;
            InitializeComponent();
        }

        private void DueDateFromt_TextChanged(object sender, EventArgs e)
        {
            FollowUpCore.TextBoxChange(ref DueDateFromt, ref DueDateFrom);
        }

        private void DueDateFrom_ValueChanged(object sender, EventArgs e)
        {
            FollowUpCore.DataTimeChange(ref DueDateFromt, ref DueDateFrom);
        }

        private void DueDateTot_TextChanged(object sender, EventArgs e)
        {
            FollowUpCore.TextBoxChange(ref DueDateTot, ref DueDateTo);
        }

        private void DueDateTo_ValueChanged(object sender, EventArgs e)
        {
            FollowUpCore.DataTimeChange(ref DueDateTot, ref DueDateTo);
        }

        private void PrintTasks_Click(object sender, EventArgs e)
        {
            tableset.Tables.Clear();
            List<string> checkedlist = new List<string>();
            for (int i = 0; i < DesignersCB.CheckedItems.Count; i++)
            {
                checkedlist.Add(DesignersCB.CheckedItems[i].ToString());
            }
            if (String.IsNullOrEmpty(DueDateFromt.Text) || String.IsNullOrEmpty(DueDateTot.Text))
            {
                
                MessageBox.Show("Filteration Date Cannot be empty", "Missing Important Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //create  8 tables with above filter
            //  DataView view = new DataView(FollowUpCore.LoadOffer, "[Team Leader] = '" + FollowUpCore.UserName+"'", " AND  [Due Date SLD] >= #" + DueDateFromt.Text + "# AND  [Due Date SLD] <= #"+DueDateTot.Text + "#", DataViewRowState.CurrentRows);
            try
            {
                filterapplied = true;
                views = new List<DataGridView>();
                //  MessageBox.Show(FollowUpCore.FilterCommand("Due Date SLD", "Actual Date SLD", FollowUpCore.UserRole, FollowUpCore.UserName, DueDateFromt.Text, DueDateTot.Text, checkedlist, itemstats));
                DataView view1 = new DataView(FollowUpCore.LoadOffer, FollowUpCore.FilterCommand("Due Date SLD", "Actual Date SLD", FollowUpCore.UserName, DueDateFromt.Text, DueDateTot.Text, checkedlist, itemstats), "[Due Date SLD] ASC", DataViewRowState.CurrentRows);

                DataTable OfferSLD = view1.ToTable();
                OfferSLD.TableName = "Offer SLD";
                tableset.Tables.Add(FollowUpCore.RemoveColomn(OfferSLD, FollowUpCore.PrevOfferSLDstr, FollowUpCore.DetailOfferCols));
                DGVOfferSLD.DataSource = OfferSLD;
                FollowUpCore.adjustDGV(ref DGVOfferSLD, FollowUpCore.PrevOfferSLDstr, FollowUpCore.DetailOfferCols);
                views.Add(DGVOfferSLD);

                DataView view2 = new DataView(FollowUpCore.LoadOffer, FollowUpCore.FilterCommand("Due Date Schematics", "Actual Date Schematics", FollowUpCore.UserName, DueDateFromt.Text, DueDateTot.Text, checkedlist, itemstats), "[Due Date Schematics] ASC", DataViewRowState.CurrentRows);
                DataTable OfferSchematics = view2.ToTable();
                OfferSchematics.TableName = "Offer schematics";
                tableset.Tables.Add(FollowUpCore.RemoveColomn(OfferSchematics, FollowUpCore.PrevOfferSchematicsstr, FollowUpCore.DetailOfferCols));
                DGVOfferSchematics.DataSource = OfferSchematics;
                FollowUpCore.adjustDGV(ref DGVOfferSchematics, FollowUpCore.PrevOfferSchematicsstr, FollowUpCore.DetailOfferCols);
                views.Add(DGVOfferSchematics);

                DataView view3 = new DataView(FollowUpCore.LoadOrder, FollowUpCore.FilterCommand("Due Date SLD", "Actual Date SLD", FollowUpCore.UserName, DueDateFromt.Text, DueDateTot.Text, checkedlist, itemstats), "[Due Date SLD] ASC", DataViewRowState.CurrentRows);
                DataTable OrderSLD = view3.ToTable();
                DGVOrderSLD.DataSource = OrderSLD;
                OrderSLD.TableName = "OrderSLD";
                tableset.Tables.Add(FollowUpCore.RemoveColomn(OrderSLD, FollowUpCore.PrevOrderSLDstr, FollowUpCore.DetailOrderCols));
                FollowUpCore.adjustDGV(ref DGVOrderSLD, FollowUpCore.PrevOrderSLDstr, FollowUpCore.DetailOrderCols);
                views.Add(DGVOrderSLD);

                DataView view4 = new DataView(FollowUpCore.LoadOrder, FollowUpCore.FilterCommand("Due Date Schematics", "Actual Date Schematics", FollowUpCore.UserName, DueDateFromt.Text, DueDateTot.Text, checkedlist, itemstats), "[Due Date Schematics] ASC", DataViewRowState.CurrentRows);
                DataTable OrderShematics = view4.ToTable();
                DGVOrderSchematics.DataSource = OrderShematics;
                OrderShematics.TableName = "Order Schematics";
                tableset.Tables.Add(FollowUpCore.RemoveColomn(OrderShematics, FollowUpCore.PrevOrderSchematicsstr, FollowUpCore.DetailOrderCols));
                FollowUpCore.adjustDGV(ref DGVOrderSchematics, FollowUpCore.PrevOrderSchematicsstr, FollowUpCore.DetailOrderCols);
                views.Add(DGVOrderSchematics);

                DataView view5 = new DataView(FollowUpCore.LoadOrder, FollowUpCore.FilterCommand("ABOM Due Date", "Actual Date ABOM", FollowUpCore.UserName, DueDateFromt.Text, DueDateTot.Text, checkedlist, itemstats), "[ABOM Due Date] ASC", DataViewRowState.CurrentRows);
                DataTable ABOM = view5.ToTable();
                DGVABOM.DataSource = ABOM;////
                ABOM.TableName = "ABOM";
                tableset.Tables.Add(FollowUpCore.RemoveColomn(ABOM, FollowUpCore.PrevOrderABOM, FollowUpCore.DetailOrderCols));
                FollowUpCore.adjustDGV(ref DGVABOM, FollowUpCore.PrevOrderABOM, FollowUpCore.DetailOrderCols);
                views.Add(DGVABOM);//

                DataView view6 = new DataView(FollowUpCore.LoadOrder, FollowUpCore.FilterCommand("BBOM Due Date", "Actual Date BBOM", FollowUpCore.UserName, DueDateFromt.Text, DueDateTot.Text, checkedlist, itemstats), "[BBOM Due Date] ASC", DataViewRowState.CurrentRows);
                DataTable BBOM = view6.ToTable();
                DGVBBOM.DataSource = BBOM;
                BBOM.TableName = "BBOM";
                tableset.Tables.Add(FollowUpCore.RemoveColomn(BBOM, FollowUpCore.PrevOrderBBOM, FollowUpCore.DetailOrderCols));
                FollowUpCore.adjustDGV(ref DGVBBOM, FollowUpCore.PrevOrderBBOM, FollowUpCore.DetailOrderCols);
                views.Add(DGVBBOM);

                DataView view7 = new DataView(FollowUpCore.LoadOrder, FollowUpCore.FilterCommand("NSR Due Date", "Actual Date NSR", FollowUpCore.UserName, DueDateFromt.Text, DueDateTot.Text, checkedlist, itemstats), "[NSR Due Date] ASC", DataViewRowState.CurrentRows);
                DataTable NSR = view7.ToTable();
                DGVNSR.DataSource = NSR;
                NSR.TableName = "Non Standard Requests";
                tableset.Tables.Add(FollowUpCore.RemoveColomn(NSR, FollowUpCore.PrevOrderNSR, FollowUpCore.DetailOrderCols));
                views.Add(DGVNSR);
                FollowUpCore.adjustDGV(ref DGVNSR, FollowUpCore.PrevOrderNSR, FollowUpCore.DetailOrderCols);


                DataView view8 = new DataView(FollowUpCore.LoadOrder, FollowUpCore.FilterCommand("PF Due Date", "Actual Date PF", FollowUpCore.UserName, DueDateFromt.Text, DueDateTot.Text, checkedlist, itemstats), "[PF Due Date] ASC", DataViewRowState.CurrentRows);
                DataTable PF = view8.ToTable();
                DGVPF.DataSource = PF;
                PF.TableName = "Production File";
                tableset.Tables.Add(FollowUpCore.RemoveColomn(PF, FollowUpCore.PrevOrderPF, FollowUpCore.DetailOrderCols));
                FollowUpCore.adjustDGV(ref DGVPF, FollowUpCore.PrevOrderPF, FollowUpCore.DetailOrderCols);
                views.Add(DGVPF);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            //DataTable OfferSchematics;
            //DataTable OrderSLD;
            //DataTable OrderSchematics;
            //DataTable OrderABOM;
            //DataTable OrderBBOM;
            //DataTable OrderNSR;
            //DataTable OrderPF;
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                //Set the left margin
                int iLeftMargin = e.MarginBounds.Left;
                //Set the top margin
                int iTopMargin = e.MarginBounds.Top;
                //Whether more pages have to print or not
                bool bMorePagesToPrint = false;
                int iTmpWidth = 70;

                //For the first page to print set the cell width and header height
                iHeaderHeight = 25;

                //for first time entering this function


                //Loop till all the grid rows not get printed
                //first time it will show first table colomns and time and date
                for (int cnt = tablecount; cnt < views.Count; cnt++)
                {

                    if (cnt != tablecount)
                    {//enter to new datagrid view

                        tablecount = cnt;
                        foreach (DataGridViewColumn GridCol in views[cnt].Columns)
                        {
                            if (GridCol.Visible)
                            {
                                wcount++;
                            }
                        }
                        iTmpWidth = 70;
                        iLeftMargin = e.MarginBounds.Left;
                        arrColumnLefts.Clear();
                        arrColumnWidths.Clear();
                        foreach (DataGridViewColumn GridCol in views[cnt].Columns)
                        {
                            if (!GridCol.Visible)
                            {
                                continue;
                            }
                            // Save width and height of headres
                            arrColumnLefts.Add(iLeftMargin);
                            arrColumnWidths.Add(iTmpWidth);
                            iLeftMargin += iTmpWidth;
                        }

                        iRow = 0;//this represent row in current table
                        e.Graphics.DrawString(views[cnt].Tag.ToString() + " Tasks", new Font(views[cnt].Font, FontStyle.Bold),
                              Brushes.Black, e.MarginBounds.Left, iTopMargin + 10);

                        iTopMargin = iTopMargin + 35;
                        int iCount1 = 0;
                        //show only visible colomns
                        foreach (DataGridViewColumn GridCol in views[cnt].Columns)
                        {
                            if (!GridCol.Visible)
                            {
                                continue;
                            }
                            e.Graphics.FillRectangle(new SolidBrush(Color.LightGray),
                                new Rectangle((int)arrColumnLefts[iCount1], iTopMargin,
                                (int)arrColumnWidths[iCount1], iHeaderHeight));

                            e.Graphics.DrawRectangle(Pens.Black,
                                new Rectangle((int)arrColumnLefts[iCount1], iTopMargin,
                                (int)arrColumnWidths[iCount1], iHeaderHeight));

                            e.Graphics.DrawString(GridCol.HeaderText, GridCol.InheritedStyle.Font,
                                new SolidBrush(GridCol.InheritedStyle.ForeColor),
                                new RectangleF((int)arrColumnLefts[iCount1], iTopMargin,
                                (int)arrColumnWidths[iCount1], iHeaderHeight), strFormat);
                            iCount1++;
                        }
                        iTopMargin += iHeaderHeight;

                    }
                    //when this in first page after adding colomns
                    if (firstenter)
                    {
                        arrColumnLefts.Clear();
                        arrColumnWidths.Clear();
                        firstenter = false;
                        iTopMargin = e.MarginBounds.Top;
                        //calculate hight
                        foreach (DataGridViewColumn GridCol in views[cnt].Columns)
                        {
                            if (GridCol.Visible)
                            {
                                wcount++;
                            }

                        }
                        iTmpWidth = 70;
                        iLeftMargin = e.MarginBounds.Left;
                        //this to get spaces for width for colomns
                        foreach (DataGridViewColumn GridCol in views[cnt].Columns)
                        {
                            if (!GridCol.Visible)
                            {
                                continue;
                            }
                            // Save width and height of headres
                            arrColumnLefts.Add(iLeftMargin);
                            arrColumnWidths.Add(iTmpWidth);
                            iLeftMargin += iTmpWidth;
                        }
                        iRow = 0;
                        //Draw Header
                        e.Graphics.DrawString(views[cnt].Tag.ToString() + " Tasks", new Font(views[cnt].Font, FontStyle.Bold),
                                Brushes.Black, e.MarginBounds.Left, e.MarginBounds.Top -
                                e.Graphics.MeasureString("Task Summary", new Font(views[cnt].Font,
                                FontStyle.Bold), e.MarginBounds.Width).Height - 13);

                        String strDate1 = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToShortTimeString();
                        //Draw Date
                        e.Graphics.DrawString(strDate1, new Font(views[cnt].Font, FontStyle.Bold),
                                Brushes.Black, e.MarginBounds.Left + (e.MarginBounds.Width -
                                e.Graphics.MeasureString(strDate1, new Font(views[cnt].Font,
                                FontStyle.Bold), e.MarginBounds.Width).Width), e.MarginBounds.Top -
                                e.Graphics.MeasureString(views[cnt].Tag.ToString() + " Tasks", new Font(new Font(views[cnt].Font,
                                FontStyle.Bold), FontStyle.Bold), e.MarginBounds.Width).Height - 13);
                        iTopMargin = e.MarginBounds.Top;
                        int iCount1 = 0;

                        foreach (DataGridViewColumn GridCol in views[cnt].Columns)
                        {
                            if (!GridCol.Visible)
                            {
                                continue;
                            }
                            e.Graphics.FillRectangle(new SolidBrush(Color.LightGray),
                                new Rectangle((int)arrColumnLefts[iCount1], iTopMargin,
                                (int)arrColumnWidths[iCount1], iHeaderHeight));

                            e.Graphics.DrawRectangle(Pens.Black,
                                new Rectangle((int)arrColumnLefts[iCount1], iTopMargin,
                                (int)arrColumnWidths[iCount1], iHeaderHeight));

                            e.Graphics.DrawString(GridCol.HeaderText, GridCol.InheritedStyle.Font,
                                new SolidBrush(GridCol.InheritedStyle.ForeColor),
                                new RectangleF((int)arrColumnLefts[iCount1], iTopMargin,
                                (int)arrColumnWidths[iCount1], iHeaderHeight), strFormat);
                            iCount1++;
                        }
                        bNewPage = false;
                        iTopMargin += iHeaderHeight;
                    }

                    //now after check if new table or first time lets start loop over cells


                    int iCount;
                    for (iRow = Rowcount; iRow < views[cnt].Rows.Count; iRow++)
                    {
                        DataGridViewRow GridRow = views[cnt].Rows[iRow];
                        //Set the cell height
                        iCellHeight = GridRow.Height + 5;
                        iCount = 0;
                        //Check whether the current page settings allo more rows to print

                        if (iTopMargin + iCellHeight >= e.MarginBounds.Height + e.MarginBounds.Top)
                        {
                            bNewPage = true;
                            bFirstPage = false;
                            bMorePagesToPrint = true;
                            firstenter = true;
                            Rowcount = iRow;
                            break;
                        }
                        else
                        {
                            bMorePagesToPrint = false;
                            iCount = 0;
                            //Draw Columns Contents                
                            foreach (DataGridViewCell Cel in GridRow.Cells)
                            {
                                if (!Cel.Visible)
                                {
                                    continue;
                                }
                                if (Cel.Value != null)
                                {
                                    e.Graphics.DrawString(FollowUpCore.Shorten(Cel.Value), Cel.InheritedStyle.Font,
                                                new SolidBrush(Cel.InheritedStyle.ForeColor),
                                                new RectangleF((int)arrColumnLefts[iCount], (float)iTopMargin,
                                                (int)arrColumnWidths[iCount], (float)iCellHeight), strFormat);
                                }
                                //Drawing Cells Borders 
                                e.Graphics.DrawRectangle(Pens.Black, new Rectangle((int)arrColumnLefts[iCount],
                                        iTopMargin, (int)arrColumnWidths[iCount], iCellHeight));

                                iCount++;
                            }
                        }

                        iTopMargin += iCellHeight;
                    }
                    //If more lines exist, print another page.
                    if (bMorePagesToPrint)
                    {
                        e.HasMorePages = true;
                        break;
                    }

                    else
                        e.HasMorePages = false;
                }

            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       
        private void button1_Click(object sender, EventArgs e)
        {
            if (!filterapplied)
            {
                MessageBox.Show("You must apply filter first");
                return;
            }
            PrintDialog printDialog = new PrintDialog();
            //reset all printing parameters
            iRow = 0;
            Rowcount = 0;
            bFirstPage = false; //Used to check whether we are printing first page
            bNewPage = false;// Used to check whether we are printing a new page
            iHeaderHeight = 0; //Used for the header height
            wcount = 0;
            tablecount = 0;
            firstenter = true;
            printDocument1.DefaultPageSettings.Landscape = true;
            printDialog.Document = printDocument1;

            printDialog.UseEXDialog = true;

            //Get the document
            if (DialogResult.OK == printDialog.ShowDialog())
            {
                printDocument1.DocumentName = "Test Page Print";
                printDocument1.Print();
            }

        }

        private void printDocument1_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            try
            {
                strFormat = new StringFormat();
                strFormat.Alignment = StringAlignment.Near;
                strFormat.LineAlignment = StringAlignment.Center;
                strFormat.Trimming = StringTrimming.EllipsisCharacter;

                arrColumnLefts.Clear();
                arrColumnWidths.Clear();
                iCellHeight = 0;
                iRow = 0;
                bFirstPage = true;
                bNewPage = true;

                // Calculating Total Widths
                iTotalWidth = 0;
                foreach (DataGridViewColumn dgvGridCol in DGVOrderSchematics.Columns)
                {
                    iTotalWidth += dgvGridCol.Width;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExtractTasksReport_Load(object sender, EventArgs e)
        {
            tableset = new DataSet();
            //as we agreed this will be for teamleader and manager so i will get all general information for this user based on his Role
            if (isdesigner)
            {
                FollowUpCore.Team_Designers.Add(FollowUpCore.UserName);
            }
            else
            {
                FollowUpCore.GetTeamDesigners(FollowUpCore.UserName, "Relations", ref FollowUpCore.Team_Designers, ref FollowUpCore.DicTeam_Designers);
            }

            foreach (string item in FollowUpCore.Team_Designers)
            {
                DesignersCB.Items.Add(item);
            }
            if (isdesigner)
            {
                DesignersCB.SetItemChecked(0, true);
                groupBox3.Visible = false;
            }
        }

        private void ExtractXML_Click(object sender, EventArgs e)
        {
            if (!filterapplied)
            {
                MessageBox.Show("You must apply filter first");
                return;
            }
            SaveFileDialog savefile = new SaveFileDialog();
            // set a default file name
            savefile.FileName = "extract.XML";
            // set filters - this can be done in properties as well
            savefile.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";

            if (savefile.ShowDialog() == DialogResult.OK)
            {
                //SaveLocation.Text = savefile.FileName;
                //tableset.WriteXmlSchema(savefile.FileName);
                // tableset.WriteXml(savefile.FileName,XmlWriteMode.WriteSchema);


                FollowUpCore.ExportDSToExcel(tableset, savefile.FileName);
            }

        }

        private void SelectAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < DesignersCB.Items.Count; i++)
            {
                DesignersCB.SetItemChecked(i, true);
            }
        }

        private void SelectNone_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < DesignersCB.Items.Count; i++)
            {
                DesignersCB.SetItemChecked(i, false);
            }
        }

        private void RBAll_CheckedChanged(object sender, EventArgs e)
        {
            if (RBAll.Checked)
            {
                itemstats = "All";
            }
        }

        private void RBCompleted_CheckedChanged(object sender, EventArgs e)
        {
            if (RBCompleted.Checked)
            {
                itemstats = "Completed";
            }
        }

        private void RBNotCompleted_CheckedChanged(object sender, EventArgs e)
        {

            if (RBNotCompleted.Checked)
            {
                itemstats = "Not Completed";
            }
        }

        private void RBOverDue_CheckedChanged(object sender, EventArgs e)
        {

            if (RBOverDue.Checked)
            {
                itemstats = "Over Due Date";
            }
        }
    }
}

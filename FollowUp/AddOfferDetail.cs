using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FollowUp
{
    public partial class AddOfferDetail : Form
    {
        DataTable TDetails;
        List<string> ItemsName;
        List<string> RemoveIDs;
        public AddOfferDetail(DataTable TDetail)
        {
            InitializeComponent();
            //here we should make function that put TDetail in same schema of Orignal table taken from DB
            TDetails = TDetail;

        }

        private void AddOfferDetail_Load(object sender, EventArgs e)
        {
            RemoveIDs = new List<string>();
            ItemsName = new List<string>();
            TCO.DataSource = FollowUpCore.ListTCO;
            Segment.DataSource = FollowUpCore.Segment;
            Complexity.DataSource = FollowUpCore.Complexity;
            Family.DataSource = FollowUpCore.DepartmentTodata(FollowUpCore.UserDepartment, "Family");
            SLDModComplexity.DataSource = FollowUpCore.Complexity1;
            SchematicsModComplexity.DataSource = FollowUpCore.Complexity2;
            Designer.DataSource = FollowUpCore.Team_Designers;
            int i = 0;
            int c = 0;
            if (FollowUpCore.IDOffer > 0)
            {
                //this meen it's modification

                foreach (DataRow item in TDetails.Rows)
                {
                    if (item["ID"].ToString() == FollowUpCore.IDOffer.ToString())
                    {
                        c = i;
                        break;
                    }
                    else
                    {
                        i++;
                    }
                }
            }

            view(c, TDetails.Rows.Count);
        }

        private void FIReciveDatet_TextChanged(object sender, EventArgs e)
        {
            FollowUpCore.TextBoxChange(ref ReciveDatet, ref ReciveDate);
        }
        private void FIReciveDate_ValueChanged(object sender, EventArgs e)
        {
            FollowUpCore.DataTimeChange(ref ReciveDatet, ref ReciveDate);
        }
        private void SLDDueDatet_TextChanged(object sender, EventArgs e)
        {
            FollowUpCore.TextBoxChange(ref SLDDueDatet, ref SLDDueDate);
            if (!string.IsNullOrEmpty(SLDDueDatet.Text))
            {
                SLDDrawings.Checked = true;
            }
        }

        private void SLDDueDate_ValueChanged(object sender, EventArgs e)
        {
            FollowUpCore.DataTimeChange(ref SLDDueDatet, ref SLDDueDate);
        }

        private void SLDActualDatet_TextChanged(object sender, EventArgs e)
        {
            FollowUpCore.TextBoxChange(ref SLDActualDatet, ref SLDActualDate);

        }

        private void SLDActualDate_ValueChanged(object sender, EventArgs e)
        {
            FollowUpCore.DataTimeChange(ref SLDActualDatet, ref SLDActualDate);
        }

        private void SchematicsDueDatet_TextChanged(object sender, EventArgs e)
        {
            FollowUpCore.TextBoxChange(ref SchematicsDueDatet, ref SchematicsDueDate);
            if (!string.IsNullOrEmpty(SchematicsDueDatet.Text))
            {
                SchematicsDrawings.Checked = true;
            }
        }

        private void SchematicsDueDate_ValueChanged(object sender, EventArgs e)
        {
            FollowUpCore.DataTimeChange(ref SchematicsDueDatet, ref SchematicsDueDate);

        }

        private void SchematicsActualDatet_TextChanged(object sender, EventArgs e)
        {
            FollowUpCore.TextBoxChange(ref SchematicsActualDatet, ref SchematicsActualDate);
        }

        private void SchematicsActualDate_ValueChanged(object sender, EventArgs e)
        {
            FollowUpCore.DataTimeChange(ref SchematicsActualDatet, ref SchematicsActualDate);
        }
        bool Validation()
        {
            if (string.IsNullOrEmpty(OfferNamex.Text))
            {
                MessageBox.Show("Offer Name Cannot be empty", "Missing Important Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (string.IsNullOrEmpty(OfferNumber.Text))
            {
                MessageBox.Show("Offer Number Cannot be empty", "Missing Important Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (string.IsNullOrEmpty(ItemNumber.Text))
            {
                MessageBox.Show("Item Number Cannot be empty", "Missing Important Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (string.IsNullOrEmpty(Family.Text))
            {
                MessageBox.Show("Family Cannot be empty", "Missing Important Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (string.IsNullOrEmpty(NumberOfCells.Text))
            {
                MessageBox.Show("Number Of Cells Cannot be empty", "Missing Important Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;

            }
            else if (string.IsNullOrEmpty(Complexity.Text))
            {
                MessageBox.Show("Commlexity Cannot be empty", "Missing Important Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (!int.TryParse(NumberOfCells.Text, out int zz))
            {
                MessageBox.Show("Number of Cells must be number", "Wrong Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (string.IsNullOrEmpty(Designer.Text))
            {
                MessageBox.Show("Designer Cannot be empty", "Missing Important Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }


            return true;

        }
        /// <summary>
        /// usded to update view
        /// </summary>
        /// <param name="index">current row start from zero</param>
        /// <param name="count">total number of rows in table</param>
        void view(int index = 0, int count = 0)
        {
            if (index < 0)
            {
                index = 0;
            }
            else if (index >= count)
            {
                index = count - 1;

            }
            else if (count == 0)
            {
                return;//no data to show
            }

            Designer.Text = TDetails.Rows[index]["Designer"].ToString();
            OfferName.Text = TDetails.Rows[index]["Offer Name"].ToString();
            OfferNumber.Text = TDetails.Rows[index]["Offer Number"].ToString();
            TCO.Text = TDetails.Rows[index]["TCO"].ToString();
            Segment.Text = TDetails.Rows[index]["Segment"].ToString();
            ItemNumber.Text = TDetails.Rows[index]["Item Number"].ToString();
            NumberOfCells.Text = TDetails.Rows[index]["Total Cells"].ToString();
            Family.Text = TDetails.Rows[index]["Family"].ToString();
            Complexity.Text = TDetails.Rows[index]["Complexity"].ToString();
            PatchName.Text = TDetails.Rows[index]["Patch Name"].ToString();
            ReciveDatet.Text = FollowUpCore.Date_show(TDetails.Rows[index]["Receive Date"]);

            SLDModification.Checked = TDetails.Rows[index]["SLD Modification"].ToString() == "True" ? true : false;
            SLDDueDatet.Text = FollowUpCore.Date_show(TDetails.Rows[index]["Due Date SLD"]);
            SLDCLODate.Text = FollowUpCore.Date_show(TDetails.Rows[index]["Due Date CLO SLD"]);
            SLDActualDatet.Text = FollowUpCore.Date_show(TDetails.Rows[index]["Actual Date SLD"]);
            SLDModComplexity.Text = TDetails.Rows[index]["SLD Modification Complexity"].ToString();
            SLDModCells.Text = TDetails.Rows[index]["SLD Modification Impacted Cells"].ToString();
            SLDComment.Text = TDetails.Rows[index]["SLD Drawing Comment"].ToString();

            SchematicsModification.Checked = TDetails.Rows[index]["Schematics Modification"].ToString() == "True" ? true : false;
            SchematicsDueDatet.Text = FollowUpCore.Date_show(TDetails.Rows[index]["Due Date Schematics"]);
            SchematicsCLODate.Text = FollowUpCore.Date_show(TDetails.Rows[index]["Due Date CLO Schematics"]);
            SchematicsActualDatet.Text = FollowUpCore.Date_show(TDetails.Rows[index]["Actual Date Schematics"]);
            SchematicsModComplexity.Text = TDetails.Rows[index]["Schematics Modification Complexity"].ToString();
            SchematicsModCells.Text = TDetails.Rows[index]["Schematics Modification Impacted Cells"].ToString();
            SchematicsComment.Text = TDetails.Rows[index]["Schematics Drawing Comment"].ToString();
            tb_current.Text = index.ToString();

            SLDModComplexity.Visible = SLDModification.Checked;
            label7.Visible = SLDModification.Checked;
            label6.Visible = SLDModification.Checked;
            SLDModCells.Visible = SLDModification.Checked;
            label8.Visible = SchematicsModification.Checked;
            SchematicsModComplexity.Visible = SchematicsModification.Checked;
            label12.Visible = SchematicsModification.Checked;
            SchematicsModCells.Visible = SchematicsModification.Checked;
            SDLDrawingsGB.Visible = SLDDrawings.Checked;
            SchematicsDrawingGB.Visible = SchematicsDrawings.Checked;
        }
        /// <summary>
        /// modify existing items
        /// </summary>
        /// <param name="index"></param>
        /// <returns> false if validation fail</returns>
        bool ApplyModif(int index)
        {
            if (Validation())
            {

                TDetails.Rows[index]["Designer"] = Designer.Text;
                TDetails.Rows[index]["Offer Name"] = OfferName.Text;
                TDetails.Rows[index]["Offer Number"] = OfferNumber.Text;
                TDetails.Rows[index]["TCO"] = TCO.Text;
                TDetails.Rows[index]["Segment"] = Segment.Text;
                TDetails.Rows[index]["Item Number"] = ItemNumber.Text;
                TDetails.Rows[index]["Total Cells"] = NumberOfCells.Text;
                TDetails.Rows[index]["Family"] = Family.Text;
                TDetails.Rows[index]["Complexity"] = Complexity.Text;
                TDetails.Rows[index]["Patch Name"] = PatchName.Text;
                TDetails.Rows[index]["Receive Date"] = FollowUpCore.Date_validate(ReciveDatet.Text);
                TDetails.Rows[index]["SLD Modification"] = SLDModification.Checked;
                TDetails.Rows[index]["Due Date SLD"] = FollowUpCore.Date_validate(SLDDueDatet.Text);
                TDetails.Rows[index]["Due Date CLO SLD"] = FollowUpCore.Date_validate(SLDCLODate.Text);
                TDetails.Rows[index]["Actual Date SLD"] = FollowUpCore.Date_validate(SLDActualDatet.Text);
                // TDetails.Rows[index]["Actual Hours SLD"]
                // TDetails.Rows[index]["Standard Hours SLD"] = function return hours per complexity and number of cells and family
                TDetails.Rows[index]["SLD Modification Complexity"] = SLDModComplexity.Text;
                TDetails.Rows[index]["SLD Modification Impacted Cells"] = SLDModCells.Text;
                TDetails.Rows[index]["SLD Drawing Comment"] = SLDComment.Text;
                TDetails.Rows[index]["Schematics Modification"] = SchematicsModification.Checked;
                TDetails.Rows[index]["Due Date Schematics"] = FollowUpCore.Date_validate(SchematicsDueDatet.Text);
                TDetails.Rows[index]["Due Date CLO Schematics"] = FollowUpCore.Date_validate(SchematicsCLODate.Text);
                TDetails.Rows[index]["Actual Date Schematics"] = FollowUpCore.Date_validate(SchematicsActualDatet.Text);
                TDetails.Rows[index]["Schematics Modification Complexity"] = SchematicsModComplexity.Text;
                TDetails.Rows[index]["Schematics Modification Impacted Cells"] = SchematicsModCells.Text;
                TDetails.Rows[index]["Schematics Drawing Comment"] = SchematicsComment.Text;
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// add new row into table
        /// </summary>
        /// <param name="Count"></param>
        /// <returns></returns>
        bool AddNew(int Count, bool extended = false)
        {
            if (Validation())
            {
                DataRow row = TDetails.NewRow();
                row["Designer"] = Designer.Text;
                row["Team Leader"] = FollowUpCore.UserName;
                row["Department"] = FollowUpCore.UserDepartment;
                row["Offer Name"] = OfferName.Text;
                row["Offer Number"] = OfferNumber.Text;
                row["TCO"] = TCO.Text;
                row["Segment"] = Segment.Text;
                row["Item Number"] = ItemNumber.Text;
                row["Total Cells"] = NumberOfCells.Text;
                row["Family"] = Family.Text;
                row["Complexity"] = Complexity.Text;
                row["Patch Name"] = PatchName.Text;
                row["Receive Date"] = FollowUpCore.Date_validate(ReciveDatet.Text);
                row["SLD Modification"] = SLDModification.Checked;
                row["Due Date SLD"] = FollowUpCore.Date_validate(SLDDueDatet.Text);
                row["Due Date CLO SLD"] = FollowUpCore.Date_validate(SLDCLODate.Text);
                row["Actual Date SLD"] = FollowUpCore.Date_validate(SLDActualDatet.Text);
                // row["Actual Hours SLD"]
                // row["Standard Hours SLD"] = function return hours per complexity and number of cells and family
                row["SLD Modification Complexity"] = SLDModComplexity.Text;
                row["SLD Modification Impacted Cells"] = SLDModCells.Text;
                row["SLD Drawing Comment"] = SLDComment.Text;
                row["Schematics Modification"] = SchematicsModification.Checked;
                row["Due Date Schematics"] = FollowUpCore.Date_validate(SchematicsDueDatet.Text);
                row["Due Date CLO Schematics"] = FollowUpCore.Date_validate(SchematicsCLODate.Text);
                row["Actual Date Schematics"] = FollowUpCore.Date_validate(SchematicsActualDatet.Text);
                row["Schematics Modification Complexity"] = SchematicsModComplexity.Text;
                row["Schematics Modification Impacted Cells"] = SchematicsModCells.Text;
                row["Schematics Drawing Comment"] = SchematicsComment.Text;
                //Actual Hours Schematics
                if (extended)
                {
                    row["Index"] = "1";
                }
                else
                {
                    row["Index"] = "0";
                }
                TDetails.Rows.Add(row);
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// clear all data in form
        /// </summary>
        void clear()
        {
            Segment.Text = "";
            ItemNumber.Text = "";
            NumberOfCells.Text = "";
            Family.Text = "";
            Complexity.Text = "";
            PatchName.Text = "";
            ReciveDatet.Text = "";

            SLDModification.Checked = false;
            SLDDueDatet.Text = "";
            SLDCLODate.Text = "";
            SLDActualDatet.Text = "";
            SLDModComplexity.Text = "";
            SLDModCells.Text = "";
            SLDComment.Text = "";

            SchematicsModification.Checked = false;
            SchematicsDueDatet.Text = "";
            SchematicsCLODate.Text = "";
            SchematicsActualDatet.Text = "";
            SchematicsModComplexity.Text = "";
            SchematicsModCells.Text = "";
            SchematicsComment.Text = "";

        }
        /// <summary>
        /// delete row at specific index
        /// </summary>
        /// <param name="index"></param>
        /// <param name="count"></param>
        /// <returns>false if count = zero "Empty table"</returns>
        bool delete(int index, int count)
        {
            if (count == 0)
            {
                return false;
            }
            else if (index < 0)
            {
                index = 0;
            }
            else if (index >= count)
            {
                index = count - 1;
            }
            //here i add ids for rows that should be deleted
            if (!string.IsNullOrEmpty(TDetails.Rows[index]["ID"].ToString()))
            {
                RemoveIDs.Add(TDetails.Rows[index]["ID"].ToString());
            }

            TDetails.Rows.RemoveAt(index);


            return true;

        }

        bool SaveToDB(int count)
        {//i should send all table
            FollowUpCore.updateTablebytable(ref FollowUpCore.LoadOffer, TDetails, RemoveIDs);
            int i = AccessDB.Insert_table(FollowUpCore.LoadOffer, "OfferDetail", AccessDB.dic_to_string_Read1(FollowUpCore.DicTeam_Designers, "OfferDetail", "*"));
            if (i == -1)
            {
                MessageBox.Show("Cannot save Data to Database", "DataBase Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;

            }
            else if (i != count)
            {
                MessageBox.Show("Not All Data saved to Database", "DataBase Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;

            }
            else
            {
                return true;
            }


        }

        private void Prev_Click(object sender, EventArgs e)
        {
            int index;
            int count = TDetails.Rows.Count;
            //here i should first save current
            if (int.TryParse(tb_current.Text, out index))
            {
                if (index < count && index >= 0)
                {
                    if (ApplyModif(index))
                    {
                        //ok go to change index
                    }
                    else
                    {//validation issue
                        return;
                    }

                }
                else
                {
                    MessageBox.Show("Index out of boundry", "Index Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

            }
            else
            {
                MessageBox.Show("Index out of boundry", "Index Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            if (!int.TryParse(tb_current.Text, out index))
            {
                index = 0;

            }
            else if (index == 0)
            {
                index = 0;
            }
            else
            {
                index = index - 1;
            }


            view(index, count);
            tb_current.Text = index.ToString();
        }

        private void Next_Click(object sender, EventArgs e)
        {
            int index;
            int count = TDetails.Rows.Count;
            //here i should first save current
            if (int.TryParse(tb_current.Text, out index))
            {
                if (index < count && index >= 0)
                {
                    if (ApplyModif(index))
                    {
                        //ok go to change index
                    }
                    else
                    {//validation issue
                        return;
                    }

                }
                else
                {
                    MessageBox.Show("Index out of boundry", "Index Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

            }
            else
            {
                MessageBox.Show("Index out of boundry", "Index Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            //  tb_current.Text = index.ToString();

            //

            if (!int.TryParse(tb_current.Text, out index))
            {
                index = 0;

            }
            else if (index == count - 1)
            {
                index = count - 1;
            }
            else
            {
                index = index + 1;
            }
            view(index, count);
            tb_current.Text = index.ToString();
        }

        private void Apply_Click(object sender, EventArgs e)
        {
            int index;
            int count = TDetails.Rows.Count;

            if (int.TryParse(tb_current.Text, out index))
            {
                if (index < count && index >= 0)
                {
                    if (ApplyModif(index))
                    {
                        MessageBox.Show("Item Modified");
                    }

                }
                else
                {
                    MessageBox.Show("Index out of boundry", "Index Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    index = 0;
                }

            }
            else
            {
                MessageBox.Show("Index out of boundry", "Index Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                index = 0;

            }
            tb_current.Text = index.ToString();
        }

        private void NewItem_Click(object sender, EventArgs e)
        {

            //if item exist before prevent adding
            if (FollowUpCore.checkExistInTable(TDetails, "Item Number", ItemNumber.Text))
            {
                MessageBox.Show("Cannot used same item number twice, If you want to add adtional tasks use extend", "Duplicate Data", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            int count = TDetails.Rows.Count;
            if (AddNew(count))
            {
                tb_current.Text = count.ToString();
            }

        }

        private void Clear_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            int index;
            int count = TDetails.Rows.Count;
            if (count == 0)
            {
                MessageBox.Show("Al Deleted", "No Items exist to be removed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (int.TryParse(tb_current.Text, out index))
            {
                if (index < count && index >= 0)
                {
                    if (delete(index, count))
                    {
                        MessageBox.Show("Item Deleted");
                        if (index > 0)
                        {
                            index = index - 1;
                        }
                    }

                }
                else
                {
                    MessageBox.Show("Index out of boundry", "Index Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    index = 0;
                }

            }
            else
            {
                MessageBox.Show("Index out of boundry", "Index Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                index = 0;

            }
            if (TDetails.Rows.Count > 0)
            {
                view(index, TDetails.Rows.Count);
                tb_current.Text = index.ToString();
            }
            else
            {
                clear();
            }

        }

        private void SaveAndClose_Click(object sender, EventArgs e)
        {
            //TODO: loop over all items and check validation(loop over all and run validate)
            //loop and validate

            int index;
            int count = TDetails.Rows.Count;
            //here i should first save current
            if (int.TryParse(tb_current.Text, out index))
            {
                if (index < count && index >= 0)
                {
                    if (ApplyModif(index))
                    {
                        //ok go to change index
                    }

                }
                else
                {
                    MessageBox.Show("Index out of boundry", "Index Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

            }
            else
            {
                MessageBox.Show("Index out of boundry", "Index Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            for (int i = 0; i < TDetails.Rows.Count; i++)
            {
                view(i, TDetails.Rows.Count);
                if (!Validation())
                {
                    return;
                }
            }
            if (SaveToDB(TDetails.Rows.Count))
            {
                //must load data from databae to update ID colomns
                FollowUpCore.LoadOffer = AccessDB.Read_DataSet1(FollowUpCore.DicTeamLeaders, "OfferDetail", "*");
                MessageBox.Show("Saving Sucessfully");
                this.Close();
            }
            else
            {

            }
        }

        private void SLDModification_CheckedChanged(object sender, EventArgs e)
        {
            SLDModComplexity.Visible = SLDModification.Checked;
            label7.Visible = SLDModification.Checked;
            label6.Visible = SLDModification.Checked;
            SLDModCells.Visible = SLDModification.Checked;
        }

        private void SchematicsModification_CheckedChanged(object sender, EventArgs e)
        {
            label8.Visible = SchematicsModification.Checked;
            SchematicsModComplexity.Visible = SchematicsModification.Checked;
            label12.Visible = SchematicsModification.Checked;
            SchematicsModCells.Visible = SchematicsModification.Checked;
        }

        private void SLDDrawings_CheckedChanged(object sender, EventArgs e)
        {
            SDLDrawingsGB.Visible = SLDDrawings.Checked;
            if (!SLDDrawings.Checked)
            {
                FollowUpCore.ClearGroupBox(SDLDrawingsGB);
            }
        }

        private void SchematicsDrawings_CheckedChanged(object sender, EventArgs e)
        {
            SchematicsDrawingGB.Visible = SchematicsDrawings.Checked;
            if (!SchematicsDrawings.Checked)
            {
                FollowUpCore.ClearGroupBox(SchematicsDrawingGB);
            }
        }

        private void CLOSLDButton_Click(object sender, EventArgs e)
        {
            //TODO: Make Window form that take complexity&Cells&Family and receive date and return CLO date
            CLO clo = new CLO(Family.Text, Complexity.Text, NumberOfCells.Text, ReciveDatet.Text, CLOSLDButton.Tag.ToString());
            clo.ShowDialog();
            SLDCLODate.Text = CLO.CLODate;
        }

        private void CLOSchematicsButton_Click(object sender, EventArgs e)
        {
            //TODO: Make Window form that take complexity&Cells&Family and receive date and return CLO date
            CLO clo = new CLO(Family.Text, Complexity.Text, NumberOfCells.Text, ReciveDatet.Text, CLOSchematicsButton.Tag.ToString());
            clo.ShowDialog();
            SchematicsCLODate.Text = CLO.CLODate;
        }

        private void Extend_Click(object sender, EventArgs e)
        {
            //TODO: Fill Exrended click and make sure to show lable on new one contain extended
            int count = TDetails.Rows.Count;

            if (AddNew(count, true))
            {
                tb_current.Text = count.ToString();
                MessageBox.Show("Extending Done");
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            int oldIndex = 0;
            int index;
            int count = TDetails.Rows.Count;
            //here i should first save current
            if (int.TryParse(tb_current.Text, out index))
            {
                if (index < count && index >= 0)
                {
                    if (ApplyModif(index))
                    {
                        oldIndex = index;
                        //ok go to change index
                    }
                    else
                    {//validation issue
                        return;
                    }

                }
                else
                {
                    MessageBox.Show("Index out of boundry", "Index Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

            }
            else
            {
                MessageBox.Show("Index out of boundry", "Index Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            for (int i = 0; i < TDetails.Rows.Count; i++)
            {
                view(i, TDetails.Rows.Count);
                if (!Validation())
                {
                    return;
                }
            }
            if (SaveToDB(TDetails.Rows.Count))
            {
                //must load data from databae to update ID colomns
                FollowUpCore.LoadOffer = AccessDB.Read_DataSet1(FollowUpCore.DicTeamLeaders, "OfferDetail", "*");
                MessageBox.Show("Saving Sucessfully");
                view(oldIndex, TDetails.Rows.Count);
            }
            else
            {

            }

        }
    }
}

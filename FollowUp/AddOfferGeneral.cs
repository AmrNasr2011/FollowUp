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
    public partial class AddOfferGeneral : Form
    {
        DataTable table;
        DataRow row;
        public AddOfferGeneral()
        {
            InitializeComponent();
        }

        private void AddOfferGeneral_Load(object sender, EventArgs e)
        {
            TCO.DataSource = FollowUpCore.ListTCO;
            Segment.DataSource = FollowUpCore.Segment;
            CommonComplexity.DataSource = FollowUpCore.Complexity;
            SLDModComplexity.DataSource = FollowUpCore.Complexity1;
            SchematicsModComplexity.DataSource = FollowUpCore.Complexity2;
            Designer.DataSource = FollowUpCore.Team_Designers;
            //way to hide show mechanizm also change direction to be from up to down
            

            table = new DataTable();
            table = FollowUpCore.GeneralOffer_table.Clone();
            row = table.NewRow();

            
        }

      

        private void Generate_Click(object sender, EventArgs e)
        {//first validate
         
            if (Validation())
            {
                //fill table with current values
                row["Designer"] = Designer.Text;
                row["Team Leader"] = FollowUpCore.UserName;
                row["Department"] = FollowUpCore.UserDepartment;
                row["Offer Name"] = OfferName.Text;
                row["Offer Number"] = OfferNumber.Text;
                row["TCO"]=TCO.Text;
                row["Segment"]=Segment.Text;
                row["Items Numbers"]=ItemsNumbers.Text;
                row["Total Items"]=TotalItems.Text;
                row["Total Cells"]=TotalCells.Text;
                row["Patch Name"] = PatchName.Text;
                row["Common Complexity"] = CommonComplexity.Text;
                row["Receive Date"] = FollowUpCore.Date_validate(ReceiveDatet.Text);
                row["SLD Modification"] = CBSLDModification.Checked;
                row["Due Date SLD"] = FollowUpCore.Date_validate(SLDDueDatet.Text);
                row["Due Date CLO SLD"] = FollowUpCore.Date_validate(SLDCLODate.Text);
              //  row["Actual Date SLD"] = FollowUpCore.Date_validate(SLDActualDatet.Text);
                // row["Actual Hours SLD"]
                // row["Standard Hours SLD"] = function return hours per complexity and number of cells and family
                row["SLD Modification Complexity"] = SLDModComplexity.Text;
                row["SLD Modification Impacted Cells"] = SLDModCells.Text;
                row["SLD Drawing Comment"] = SLDComment.Text;
                row["Schematics Modification"] = SchematicsModification.Checked;
                row["Due Date Schematics"] = FollowUpCore.Date_validate(SchematicsDueDatet.Text);
                row["Due Date CLO Schematics"] = FollowUpCore.Date_validate(SchematicsCLODate.Text);
              //  row["Actual Date Schematics"] = FollowUpCore.Date_validate(SchematicsActualDatet.Text);
                //Actual Hours Schematics
                //row["Standard Hours Schematics"]
                row["Schematics Modification Complexity"] = SchematicsModComplexity.Text;
                row["Schematics Modification Impacted Cells"] = SchematicsModCells.Text;
                row["Schematics Drawing Comment"] = SchematicsComment.Text;
                table.Rows.Add(row);

                //uploadtable to database as insert //@@@@#### required to check if offer was added before

                //check if number of modified rows == 1 proceed other wise show error

                if (AccessDB.Insert_table(table, "OfferGeneral", "") == 1)
                {
                    //convert this table to list of tables and remove its content
                    AddOfferDetail detail = new AddOfferDetail(FollowUpCore.GeneralOffersToDetail(table));
                    this.Visible = false;
                    detail.ShowDialog();
                    this.Close();

                }
                
            }
            else
            {
                return;
            }
            //string aa = "";
            //foreach ( int a in FollowUpCore.PrintPages_to_list(ItemsNumbers.Text))
            //{
            //    aa = aa + " " +a.ToString();
            //}
            //MessageBox.Show(aa);
        }

      

        bool Validation()
        {
            if (string.IsNullOrEmpty(OfferNametx.Text))
            {
                MessageBox.Show("Offer Name Cannot be empty","Missing Important Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (string.IsNullOrEmpty(OfferNumber.Text))
            {
                MessageBox.Show("Offer Number Cannot be empty", "Missing Important Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (string.IsNullOrEmpty(TotalItems.Text))
            {
                MessageBox.Show("Total Number of Items Cannot be empty", "Missing Important Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (string.IsNullOrEmpty(TotalCells.Text))
            {
                MessageBox.Show("Offer Total number of Cells Cannot be empty", "Missing Important Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (string.IsNullOrEmpty(CommonComplexity.Text))
            {
                MessageBox.Show("Offer Common Complexity Cannot be empty", "Missing Important Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;

            }
            else if (!int.TryParse(TotalCells.Text,out int z))
            {
                MessageBox.Show("Total Number of Cells must be number", "Wrong Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (!int.TryParse(TotalItems.Text, out int zz))
            {
                MessageBox.Show("Total Number of Items must be number", "Wrong Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }else if (int.Parse(TotalItems.Text) < 1)
            {
                MessageBox.Show("Total Number of Items must be greater than zero", "Wrong Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            else if(!string.IsNullOrEmpty(ItemsNumbers.Text))
            {
                try
                {
                    int i = FollowUpCore.PrintPages_to_list(ItemsNumbers.Text).ElementAt<int>(0);
                }
                catch (Exception)
                {

                    MessageBox.Show("Kindly follow \"Items Numbers\" instructions", "Wrong input Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
               
            }
            else if (string.IsNullOrEmpty(Designer.Text))
            {
                MessageBox.Show("Designer Cannot be empty", "Missing Important Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
            
        }

        private void SLDDueDatet_TextChanged(object sender, EventArgs e)
        {
            FollowUpCore.TextBoxChange(ref SLDDueDatet, ref SLDDueDate);
            if (!string.IsNullOrEmpty( SLDDueDatet.Text))
            {
                CBSLDDrawing.Checked = true;
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
            if (string.IsNullOrEmpty(SchematicsDueDatet.Text))
            {
                CBSchematicsDrawings.Checked = true;
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

        private void ReceiveDatet_TextChanged(object sender, EventArgs e)
        {
            FollowUpCore.TextBoxChange(ref ReceiveDatet, ref ReceiveDate);
        }

        private void ReceiveDate_ValueChanged(object sender, EventArgs e)
        {
            FollowUpCore.DataTimeChange(ref ReceiveDatet, ref ReceiveDate);
        }

        private void CBSLDDrawing_CheckedChanged(object sender, EventArgs e)
        {
            
                GBSDLDrawings.Visible = CBSLDDrawing.Checked;
            if (!CBSLDDrawing.Checked)
            {
                FollowUpCore.ClearGroupBox(GBSDLDrawings);
            }
          
        }

        private void CBSchematicsDrawings_CheckedChanged(object sender, EventArgs e)
        {
            GBSchematicsDrawing.Visible = CBSchematicsDrawings.Checked;
            if (!CBSchematicsDrawings.Checked)
            {
                FollowUpCore.ClearGroupBox(GBSchematicsDrawing);
            }
        }

        private void CBSLDModification_CheckedChanged(object sender, EventArgs e)
        {
            SLDModCells.Visible = CBSLDModification.Checked;
            SLDModComplexity.Visible = CBSLDModification.Checked;
            SLDMODClesLB.Visible = CBSLDModification.Checked;
            SLDMODComplexLB.Visible = CBSLDModification.Checked;
        }

        private void SchematicsModification_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void CLOSLDButton_Click(object sender, EventArgs e)
        {
            //TODO: Make Window form that take complexity&Cells&Family and receive date and return CLO date
            CLO clo = new CLO("", "", TotalCells.Text, ReceiveDatet.Text, CLOSLDButton.Tag.ToString());
            clo.ShowDialog();
            SLDCLODate.Text = CLO.CLODate;
        }

        private void CLOSchematicsButton_Click(object sender, EventArgs e)
        {
            //TODO: Make Window form that take complexity&Cells&Family and receive date and return CLO date
            //TODO: Make Window form that take complexity&Cells&Family and receive date and return CLO date
            CLO clo = new CLO("", "", TotalCells.Text, ReceiveDatet.Text, CLOSLDButton.Tag.ToString());
            clo.ShowDialog();
            SchematicsCLODate.Text = CLO.CLODate;
        }
    }
}

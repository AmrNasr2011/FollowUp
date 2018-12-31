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
    public partial class AddOrderGeneral : Form
    {
        DataTable table;
        DataRow row;
        public AddOrderGeneral()
        {
            InitializeComponent();
        }

        private void AddOrderGeneral_Load(object sender, EventArgs e)
        {
            
            TCR.DataSource = FollowUpCore.ListTCR;
            Segment.DataSource = FollowUpCore.Segment;
            ItemsStatus.DataSource = FollowUpCore.ItemStatus;
            SLDModComplexity.DataSource = FollowUpCore.Complexity;
            SchematicsModComplexity.DataSource = FollowUpCore.Complexity2;
            CommonComplexity.DataSource = FollowUpCore.Complexity1;
            Designer.DataSource = FollowUpCore.Team_Designers;
            table = new DataTable();
            table = FollowUpCore.GeneralOrder_table.Clone();
            row = table.NewRow();
        }

        private void AApprovalDatet_TextChanged(object sender, EventArgs e)
        {
            FollowUpCore.TextBoxChange(ref ApprovalDatet, ref ApprovalDate);

        }

        private void AApprovalDate_ValueChanged(object sender, EventArgs e)
        {
            FollowUpCore.DataTimeChange(ref ApprovalDatet, ref ApprovalDate);
        }
     
       

  


        private void PFDueDatet_TextChanged(object sender, EventArgs e)
        {
            FollowUpCore.TextBoxChange(ref PFDueDatet, ref PFDueDate);
        }

        private void PFDueDate_ValueChanged(object sender, EventArgs e)
        {
            FollowUpCore.DataTimeChange(ref PFDueDatet, ref PFDueDate);
        }

        private void AApprovalDatet_TextChanged_1(object sender, EventArgs e)
        {
            FollowUpCore.TextBoxChange(ref ApprovalDatet, ref ApprovalDate);
        }
        private void AApprovalDate_ValueChanged_1(object sender, EventArgs e)
        {
            FollowUpCore.DataTimeChange(ref ApprovalDatet, ref ApprovalDate);
        }

        private void RecieveDatet_TextChanged(object sender, EventArgs e)
        {
            FollowUpCore.TextBoxChange(ref RecieveDatet, ref RecieveDate);
        }

        private void RecieveDate_ValueChanged(object sender, EventArgs e)
        {
            FollowUpCore.DataTimeChange(ref RecieveDatet, ref RecieveDate);
        }

        private void SLDDueDatet_TextChanged(object sender, EventArgs e)
        {
            FollowUpCore.TextBoxChange(ref SLDDueDatet, ref SLDDueDate);
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

        private void ABOMDueDatet_TextChanged(object sender, EventArgs e)
        {
            FollowUpCore.TextBoxChange(ref ABOMDueDatet, ref ABOMDueDate);
        }

        private void ABOMDueDate_ValueChanged(object sender, EventArgs e)
        {
            FollowUpCore.DataTimeChange(ref ABOMDueDatet, ref ABOMDueDate);
        }

        private void ABOMActualDatet_TextChanged(object sender, EventArgs e)
        {
            FollowUpCore.TextBoxChange(ref ABOMActualDatet, ref ABOMActualDate);
        }

        private void ABOMActualDate_ValueChanged(object sender, EventArgs e)
        {
            FollowUpCore.DataTimeChange(ref ABOMActualDatet, ref ABOMActualDate);
        }

        private void BBOMDueDatet_TextChanged(object sender, EventArgs e)
        {
            FollowUpCore.TextBoxChange(ref BBOMDueDatet, ref BBOMDueDate);
        }

        private void BBOMDueDate_ValueChanged(object sender, EventArgs e)
        {
            FollowUpCore.DataTimeChange(ref BBOMDueDatet, ref BBOMDueDate);
        }

        private void BBOMActualDatet_TextChanged(object sender, EventArgs e)
        {
            FollowUpCore.TextBoxChange(ref BBOMActualDatet, ref BBOMActualDate);
        }

        private void BBOMActualDate_ValueChanged(object sender, EventArgs e)
        {
            FollowUpCore.DataTimeChange(ref BBOMActualDatet, ref BBOMActualDate);
        }

        private void NSRDueDatet_TextChanged(object sender, EventArgs e)
        {
            FollowUpCore.TextBoxChange(ref NSRDueDatet, ref NSRDueDate);
        }

        private void NSRDueDate_ValueChanged(object sender, EventArgs e)
        {
            FollowUpCore.DataTimeChange(ref NSRDueDatet, ref NSRDueDate);
        }

        private void NSRActualDatet_TextChanged(object sender, EventArgs e)
        {
            FollowUpCore.TextBoxChange(ref NSRActualDatet, ref NSRActualDate);
        }

        private void NSRActualDate_ValueChanged(object sender, EventArgs e)
        {
            FollowUpCore.DataTimeChange(ref NSRActualDatet, ref NSRActualDate);
        }

        private void PFDueDatet_TextChanged_1(object sender, EventArgs e)
        {
            FollowUpCore.TextBoxChange(ref PFDueDatet, ref PFDueDate);
        }

        private void PFDueDate_ValueChanged_1(object sender, EventArgs e)
        {
            FollowUpCore.DataTimeChange(ref PFDueDatet, ref PFDueDate);
        }

        private void PFActualDatet_TextChanged(object sender, EventArgs e)
        {
            FollowUpCore.TextBoxChange(ref PFActualDatet, ref PFActualDate);
        }

        private void PFActualDate_ValueChanged(object sender, EventArgs e)
        {
            FollowUpCore.DataTimeChange(ref PFActualDatet, ref PFActualDate);
        }
        bool Validation()
        {
            if (string.IsNullOrEmpty(OrderName.Text))
            {
                MessageBox.Show("Order Name Cannot be empty", "Missing Important Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (string.IsNullOrEmpty(ProjectNumber.Text))
            {
                MessageBox.Show("Project Number Cannot be empty", "Missing Important Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (string.IsNullOrEmpty(TotalItems.Text))
            {
                MessageBox.Show("Total number of Items Cannot be empty", "Missing Important Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (string.IsNullOrEmpty(TotalCells.Text))
            {
                MessageBox.Show("Total Number of Cells Cannot be empty", "Missing Important Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (string.IsNullOrEmpty(CommonComplexity.Text))
            {
                MessageBox.Show("Common Complexity Cannot be empty", "Missing Important Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;

            }
            else if (!int.TryParse(TotalCells.Text, out int z))
            {
                MessageBox.Show("Number of Cells must be number", "Wrong Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (!int.TryParse(TotalItems.Text, out int zz))
            {
                MessageBox.Show("Number of Items must be number", "Wrong Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (int.Parse(TotalItems.Text)<1)
            {
                MessageBox.Show("Number of Items must be greater than Zero", "Wrong Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (!string.IsNullOrEmpty(ItemsNumbers.Text))
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

        private void Generate_Click(object sender, EventArgs e)
        {
            if (Validation())
            {
                //fill table with current values
                row["Designer"] = Designer.Text;
                row["Team Leader"] = FollowUpCore.UserName;
                row["Department"] = FollowUpCore.UserDepartment;
                row["Order Name"] = OrderName.Text;
                row["Project Number"] = ProjectNumber.Text;
                row["TCR"] = TCR.Text;
                row["Is PreBOM"] = ISPreBOM.Checked;
                row["Was Offer"] = WasOffer.Checked;
                row["Previous Offer Name"] = PreviousOfferName.Text;
                row["Previous Offer Number"] = PreviousOfferNumber.Text;
                row["Segment"] = Segment.Text;
                row["Items Numbers"] = ItemsNumbers.Text;
                row["Total Items"] = TotalItems.Text;
                row["Total Cells"] = TotalCells.Text;
                row["Patch Name"] = PatchName.Text;
                row["Item Status"] = ItemsStatus.Text;
                row["Approval Date"] = FollowUpCore.Date_validate(ApprovalDatet.Text);
                row["Common Complexity"] = CommonComplexity.Text;
                row["Receive Date"] = FollowUpCore.Date_validate(RecieveDatet.Text);
                row["SLD Modification"] = SLDModification.Checked;
                //TODO:change    "Common Complexity" To "Complexity" in here and database and update list in generation            
                row["Due Date SLD"] = FollowUpCore.Date_validate(SLDDueDatet.Text);
                row["Due Date CLO SLD"] = FollowUpCore.Date_validate(SLDCLODate.Text);
               // row["Actual Date SLD"] = FollowUpCore.Date_validate(SLDActualDatet.Text);
                // row["Actual Hours SLD"]
                // row["Standard Hours SLD"] = function return hours per complexity and number of cells and family
                row["SLD Modification Complexity"] = SLDModComplexity.Text;
                row["SLD Modification Impacted Cells"] = SLDModCells.Text;
                row["SLD Drawing Comment"] = SLDComment.Text;
                row["Schematics Modification"] = SchematicsModification.Checked;
                row["Due Date Schematics"] = FollowUpCore.Date_validate(SchematicsDueDatet.Text);
                row["Due Date CLO Schematics"] = FollowUpCore.Date_validate(SchematicsCLODate.Text);
               // row["Actual Date Schematics"] = FollowUpCore.Date_validate(SchematicsActualDatet.Text);
                //Actual Hours Schematics
                //row["Standard Hours Schematics"]
                row["Schematics Modification Complexity"] = SchematicsModComplexity.Text;
                row["Schematics Modification Impacted Cells"] = SchematicsModCells.Text;
                row["Schematics Drawing Comment"] = SchematicsComment.Text;

                row["ABOM Due Date"] = FollowUpCore.Date_validate(ABOMDueDatet.Text);
                row["ABOM CLO Date"] = FollowUpCore.Date_validate(ABOMCLODate.Text);
               // row["Actual Date ABOM"] = FollowUpCore.Date_validate(ABOMActualDatet.Text);
                // row["Actual Hours ABOM"] 
                // row["Standard Hours ABOM"]
                row["ABOM Comment"] = ABOMComment.Text;

                row["BBOM Due Date"] = FollowUpCore.Date_validate(BBOMDueDatet.Text);
                row["BBOM CLO Date"] = FollowUpCore.Date_validate(BBOMCLODate.Text);
               // row["Actual Date BBOM"] = FollowUpCore.Date_validate(BBOMActualDatet.Text);
                // row["Actual Hours BBOM"] 
                // row["Standard Hours BBOM"]
                row["BBOM Comment"] = BBOMComment.Text;

                row["NSR Due Date"] = FollowUpCore.Date_validate(NSRDueDatet.Text);
                row["NSR CLO Date"] = FollowUpCore.Date_validate(NSRCLODate.Text);
                //row["Actual Date NSR"] = FollowUpCore.Date_validate(NSRActualDatet.Text);
                // row["Actual Hours NSR"] 
                // row["Standard Hours NSR"]
                row["NSR Comment"] = NSRComment.Text;

                row["PF Due Date"] = FollowUpCore.Date_validate(PFDueDatet.Text);
                row["PF CLO Date"] = FollowUpCore.Date_validate(PFCLODate.Text);
               // row["Actual Date PF"] = FollowUpCore.Date_validate(PFActualDatet.Text);
                // row["Actual Hours PF"] 
                // row["Standard Hours PF"]
                row["PF Comment"] = PFComment.Text;
                //row["Standard Hours PF"]
                //row["Index"]

                table.Rows.Add(row);
                //uploadtable to database as insert //@@@@#### required to check if offer was added before

                //check if number of modified rows == 1 proceed other wise show error
                //A_row["Was Offer"].ToString() == "True" ? true : false;
                if (AccessDB.Insert_table(table, "OrderGeneral", "") == 1)
                {
                    //convert this table to list of tables and remove its content

                    AddOrderDetail detail = new AddOrderDetail(FollowUpCore.GeneralOrderToDetail(table));
                    this.Visible = false;
                    detail.ShowDialog();
                    this.Close();

                }

            }
            else
            {
                return;
            }
        }

        private void FirstIssueDrawing_CheckedChanged(object sender, EventArgs e)
        {
            SDLDrawingsGB.Visible = FirstIssueDrawing.Checked;
            if (!FirstIssueDrawing.Checked)
            {
                FollowUpCore.ClearGroupBox(SDLDrawingsGB);
            }

        }

        private void ModificationDrawing_CheckedChanged(object sender, EventArgs e)
        {
            SchematicsDrawingGB.Visible = ModificationDrawing.Checked;
            if (!ModificationDrawing.Checked)
            {
                FollowUpCore.ClearGroupBox(SchematicsDrawingGB);
            }
        }

        private void ABOM_CheckedChanged(object sender, EventArgs e)
        {
            ABOMGB.Visible = ABOM.Checked;
            if (!ABOM.Checked)
            {
                FollowUpCore.ClearGroupBox(ABOMGB);
            }
        }

        private void BBOM_CheckedChanged(object sender, EventArgs e)
        {
            BBOMGB.Visible = BBOM.Checked;
            if (!BBOM.Checked)
            {
                FollowUpCore.ClearGroupBox(BBOMGB);
            }
        }

        private void NSR_CheckedChanged(object sender, EventArgs e)
        {
            NSRGB.Visible = NSR.Checked;
            if (!NSR.Checked)
            {
                FollowUpCore.ClearGroupBox(NSRGB);
            }
        }

        private void ProductionBOM_CheckedChanged(object sender, EventArgs e)
        {
            ProductionFileGB.Visible = ProductionBOM.Checked;
            if (!ProductionBOM.Checked)
            {
                FollowUpCore.ClearGroupBox(ProductionFileGB);
            }
        }

        private void SLDModification_CheckedChanged(object sender, EventArgs e)
        {
            label7.Visible = SLDModification.Checked;
            SLDModComplexity.Visible= SLDModification.Checked;
            label6.Visible= SLDModification.Checked;
            SLDModCells.Visible= SLDModification.Checked;
        }

        private void SchematicsModification_CheckedChanged(object sender, EventArgs e)
        {
            label8.Visible = SchematicsModification.Checked;
            SchematicsModComplexity.Visible= SchematicsModification.Checked;
            label12.Visible= SchematicsModification.Checked;
            SchematicsModCells.Visible= SchematicsModification.Checked;
        }

        private void FirstIssueDrawing_SizeChanged(object sender, EventArgs e)
        {
            Height= 480 + flowLayoutPanel1.Size.Height;
        }

        private void CLOSLDButton_Click(object sender, EventArgs e)
        {
            //TODO: Make Window form that take complexity&Cells&Family and receive date and return CLO date
            CLO clo = new CLO("", CommonComplexity.Text, TotalCells.Text, ApprovalDatet.Text, CLOSLDButton.Tag.ToString());
            clo.ShowDialog();
            SLDCLODate.Text = CLO.CLODate;
        }

        private void CLOSchematicsButton_Click(object sender, EventArgs e)
        {
            //TODO: Make Window form that take complexity&Cells&Family and receive date and return CLO date
            CLO clo = new CLO("", CommonComplexity.Text, TotalCells.Text, ApprovalDatet.Text, CLOSchematicsButton.Tag.ToString());
            clo.ShowDialog();
            SchematicsCLODate.Text = CLO.CLODate;
        }

        private void CLOABOMButton_Click(object sender, EventArgs e)
        {
            //TODO: Make Window form that take complexity&Cells&Family and receive date and return CLO date
            CLO clo = new CLO("", CommonComplexity.Text, TotalCells.Text, ApprovalDatet.Text, CLOABOMButton.Tag.ToString());
            clo.ShowDialog();
            ABOMCLODate.Text = CLO.CLODate;
        }

        private void CLOBBOMButton_Click(object sender, EventArgs e)
        {
            //TODO: Make Window form that take complexity&Cells&Family and receive date and return CLO date
            CLO clo = new CLO("", CommonComplexity.Text, TotalCells.Text, ApprovalDatet.Text, CLOBBOMButton.Tag.ToString());
            clo.ShowDialog();
            BBOMCLODate.Text = CLO.CLODate;
        }

        private void CLONSRButton_Click(object sender, EventArgs e)
        {
            //TODO: Make Window form that take complexity&Cells&Family and receive date and return CLO date
            CLO clo = new CLO("", CommonComplexity.Text, TotalCells.Text, ApprovalDatet.Text, CLONSRButton.Tag.ToString());
            clo.ShowDialog();
            NSRCLODate.Text = CLO.CLODate;
        }

        private void CLOPFButton_Click(object sender, EventArgs e)
        {
            //TODO: Make Window form that take complexity&Cells&Family and receive date and return CLO date
            CLO clo = new CLO("", CommonComplexity.Text, TotalCells.Text, ApprovalDatet.Text, CLOPFButton.Tag.ToString());
            clo.ShowDialog();
            PFCLODate.Text = CLO.CLODate;
        }
    }
}

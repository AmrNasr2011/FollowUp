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
    public partial class AddOrderDetail : Form
    {
        List<string> RemoveIDs;
        DataTable TDetails;
        List<string> ItemsName;
        public AddOrderDetail(DataTable TDetail)
        {
            InitializeComponent();
            TDetails = TDetail;
        }

        private void AddOrderDetail_Load(object sender, EventArgs e)
        {
            RemoveIDs = new List<string>();
            ItemsName = new List<string>();
            TCR.DataSource = FollowUpCore.ListTCR;
            Segment.DataSource = FollowUpCore.Segment;
            Complexity.DataSource = FollowUpCore.Complexity;
            Family.DataSource = FollowUpCore.DepartmentTodata(FollowUpCore.UserDepartment, "Family");
            ItemStatus.DataSource = FollowUpCore.ItemStatus;
            SLDModComplexity.DataSource = FollowUpCore.Complexity2;
            SchematicsModComplexity.DataSource = FollowUpCore.Complexity1;
            Designer.DataSource = FollowUpCore.Team_Designers;
            tb_current.Text = "0";
            int i = 0;
            int c = 0;
            //add items names to list to be used in check
            if (FollowUpCore.IDOrder > 0)
            {
                //this meen it's modification

                foreach (DataRow item in TDetails.Rows)
                {
                    if (item["ID"].ToString() == FollowUpCore.IDOrder.ToString())
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
            //add check for BOM and Production file
            ABOM.Checked = true;
            ProductionBOM.Checked = true;
        }

        private void FIDueDateSLDt_TextChanged(object sender, EventArgs e)
        {
            FollowUpCore.TextBoxChange(ref SLDDueDatet, ref SLDDueDate);
        }

        private void FIDueDateSLD_ValueChanged(object sender, EventArgs e)
        {
            FollowUpCore.DataTimeChange(ref SLDDueDatet, ref SLDDueDate);
        }

        private void FIDueDateSchematicst_TextChanged(object sender, EventArgs e)
        {
            FollowUpCore.TextBoxChange(ref SLDActualDatet, ref SLDActualDate);
        }

        private void FIDueDateSchematics_ValueChanged(object sender, EventArgs e)
        {
            FollowUpCore.DataTimeChange(ref SLDActualDatet, ref SLDActualDate);
        }

        private void MDDueDateSLDt_TextChanged(object sender, EventArgs e)
        {
            FollowUpCore.TextBoxChange(ref SchematicsDueDatet, ref SchematicsDueDate);
        }

        private void MDDueDateSLD_ValueChanged(object sender, EventArgs e)
        {
            FollowUpCore.DataTimeChange(ref SchematicsDueDatet, ref SchematicsDueDate);
        }

        private void MDDueDateSchematicst_TextChanged(object sender, EventArgs e)
        {
            FollowUpCore.TextBoxChange(ref SchematicsActualDatet, ref SchematicsActualDate);
        }

        private void MDDueDateSchematics_ValueChanged(object sender, EventArgs e)
        {
            FollowUpCore.DataTimeChange(ref SchematicsActualDatet, ref SchematicsActualDate);
        }

        private void AApprovalDatet_TextChanged(object sender, EventArgs e)
        {
            FollowUpCore.TextBoxChange(ref ApprovalDatet, ref ApprovalDate);
        }

        private void AApprovalDate_ValueChanged(object sender, EventArgs e)
        {
            FollowUpCore.DataTimeChange(ref ApprovalDatet, ref ApprovalDate);
        }

        private void ADueDatet_TextChanged(object sender, EventArgs e)
        {
            FollowUpCore.TextBoxChange(ref ABOMDueDatet, ref ABOMDueDate);
            if (!string.IsNullOrEmpty(ABOMDueDatet.Text))
            {
                ABOM.Checked = true;
            }
        }

        private void ADueDate_ValueChanged(object sender, EventArgs e)
        {
            FollowUpCore.DataTimeChange(ref ABOMDueDatet, ref ABOMDueDate);
        }
    
        private void BDueDatet_TextChanged(object sender, EventArgs e)
        {
            FollowUpCore.TextBoxChange(ref BBOMDueDatet, ref BBOMDueDate);
            if (!string.IsNullOrEmpty(BBOMDueDatet.Text))
            {
                BBOM.Checked = true;
            }
        }

        private void BDueDate_ValueChanged(object sender, EventArgs e)
        {
            FollowUpCore.DataTimeChange(ref BBOMDueDatet, ref BBOMDueDate);
        }

   

        private void NDueDatet_TextChanged(object sender, EventArgs e)
        {
            FollowUpCore.TextBoxChange(ref NSRDueDatet, ref NSRDueDate);
            if (!string.IsNullOrEmpty(NSRDueDatet.Text))
            {
                NSR.Checked = true;
            }
        }

        private void NDueDate_ValueChanged(object sender, EventArgs e)
        {
            FollowUpCore.DataTimeChange(ref NSRDueDatet, ref NSRDueDate);
        }

  
        private void PFDueDatet_TextChanged(object sender, EventArgs e)
        {
            FollowUpCore.TextBoxChange(ref PFDueDatet, ref PFDueDate);
            if (!string.IsNullOrEmpty(PFDueDatet.Text))
            {
                ProductionBOM.Checked = true;
            }
        }

        private void PFDueDate_ValueChanged(object sender, EventArgs e)
        {
            FollowUpCore.DataTimeChange(ref PFDueDatet, ref PFDueDate);

        }
        private void AApprovalDatet_TextChanged_1(object sender, EventArgs e)//////
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
            if (!string.IsNullOrEmpty(SLDDueDatet.Text))
            {
                SLDDrawing.Checked = true;
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
                SchematicsDrawing.Checked = true;
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

        private void ABOMActualDatet_TextChanged(object sender, EventArgs e)
        {
            FollowUpCore.TextBoxChange(ref ABOMActualDatet, ref ABOMActualDate);
        }

        private void ABOMActualDate_ValueChanged(object sender, EventArgs e)
        {
            FollowUpCore.DataTimeChange(ref ABOMActualDatet, ref ABOMActualDate);
        }

        private void BBOMActualDatet_TextChanged(object sender, EventArgs e)
        {
            FollowUpCore.TextBoxChange(ref BBOMActualDatet, ref BBOMActualDate);
        }

        private void BBOMActualDate_ValueChanged(object sender, EventArgs e)
        {
            FollowUpCore.DataTimeChange(ref BBOMActualDatet, ref BBOMActualDate);
        }

        private void NSRActualDatet_TextChanged(object sender, EventArgs e)
        {
            FollowUpCore.TextBoxChange(ref NSRActualDatet, ref NSRActualDate);
        }

        private void NSRActualDate_ValueChanged(object sender, EventArgs e)
        {
            FollowUpCore.DataTimeChange(ref NSRActualDatet, ref NSRActualDate);
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
            else if (string.IsNullOrEmpty(Complexity.Text))
            {
                MessageBox.Show("Complexity Cannot be empty", "Missing Important Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (string.IsNullOrEmpty(NumberOfCells.Text))
            {
                MessageBox.Show("Total Number of Cells Cannot be empty", "Missing Important Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (string.IsNullOrEmpty(Family.Text))
            {
                MessageBox.Show("Family Cannot be empty", "Missing Important Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;

            }
            else if (!int.TryParse(NumberOfCells.Text, out int z))
            {
                MessageBox.Show("Number of Cells must be number", "Wrong Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (string.IsNullOrEmpty(Designer.Text))
            {
                MessageBox.Show("Designer Cannot be empty", "Missing Important Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            
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


            // TDetails.Rows[index]["Designer"]
            Designer.Text = TDetails.Rows[index]["Designer"].ToString();
            OrderName.Text = TDetails.Rows[index]["Order Name"].ToString();
            ProjectNumber.Text = TDetails.Rows[index]["Project Number"].ToString();
            TCR.Text = TDetails.Rows[index]["TCR"].ToString();
            ISPreBOM.Checked = TDetails.Rows[index]["Is PreBOM"].ToString() == "True" ? true : false;
            WasOffer.Checked = TDetails.Rows[index]["Was Offer"].ToString() == "True" ? true : false;
            PreviousOfferName.Text = TDetails.Rows[index]["Previous Offer Name"].ToString();
            PreviousOfferNumber.Text = TDetails.Rows[index]["Previous Offer Number"].ToString();
            Segment.Text = TDetails.Rows[index]["Segment"].ToString();
            ItemNumber.Text = TDetails.Rows[index]["Item Number"].ToString();
            NumberOfCells.Text = TDetails.Rows[index]["Total Cells"].ToString();
            Complexity.Text = TDetails.Rows[index]["Complexity"].ToString();
            NOTHasNSR.Checked = TDetails.Rows[index]["Not Has NSR"].ToString() == "True" ? true : false;
            PatchName.Text = TDetails.Rows[index]["Patch Name"].ToString();
            ApprovalDatet.Text = FollowUpCore.Date_show(TDetails.Rows[index]["Approval Date"]);
            ItemStatus.Text = TDetails.Rows[index]["Item Status"].ToString();
            Family.Text = TDetails.Rows[index]["Family"].ToString();
            WBS.Text = TDetails.Rows[index]["WBS"].ToString();
            CellingHours.Text = TDetails.Rows[index]["Celling Hours"].ToString();
            RecieveDatet.Text = FollowUpCore.Date_show(TDetails.Rows[index]["Receive Date"]);

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

            ABOMDueDatet.Text = FollowUpCore.Date_show(TDetails.Rows[index]["ABOM Due Date"]);
            ABOMCLODate.Text = FollowUpCore.Date_show(TDetails.Rows[index]["ABOM CLO Date"]);
            ABOMActualDatet.Text = FollowUpCore.Date_show(TDetails.Rows[index]["Actual Date ABOM"]);
            ABOMComment.Text = TDetails.Rows[index]["ABOM Comment"].ToString();

            BBOMDueDatet.Text = FollowUpCore.Date_show(TDetails.Rows[index]["BBOM Due Date"]);
            BBOMCLODate.Text = FollowUpCore.Date_show(TDetails.Rows[index]["BBOM CLO Date"]);
            BBOMActualDatet.Text = FollowUpCore.Date_show(TDetails.Rows[index]["Actual Date BBOM"]);
            BBOMComment.Text = TDetails.Rows[index]["BBOM Comment"].ToString();

            NSRDueDatet.Text = FollowUpCore.Date_show(TDetails.Rows[index]["NSR Due Date"]);
            NSRCLODate.Text = FollowUpCore.Date_show(TDetails.Rows[index]["NSR CLO Date"]);
            NSRActualDatet.Text = FollowUpCore.Date_show(TDetails.Rows[index]["Actual Date NSR"]);
            NSRComment.Text = TDetails.Rows[index]["NSR Comment"].ToString();

            PFDueDatet.Text = FollowUpCore.Date_show(TDetails.Rows[index]["PF Due Date"]);
            PFCLODate.Text = FollowUpCore.Date_show(TDetails.Rows[index]["PF CLO Date"]);
            PFActualDatet.Text = FollowUpCore.Date_show(TDetails.Rows[index]["Actual Date PF"]);
            PFComment.Text = TDetails.Rows[index]["PF Comment"].ToString();
            tb_current.Text = index.ToString();

            label7.Visible = SLDModification.Visible;
            SLDModComplexity.Visible = SLDModification.Visible;
            label6.Visible = SLDModification.Visible;
            SLDModCells.Visible = SLDModification.Visible;


            label8.Visible = SchematicsModification.Checked;
            SchematicsModComplexity.Visible = SchematicsModification.Checked;
            label12.Visible = SchematicsModification.Checked;
            SchematicsModCells.Visible = SchematicsModification.Checked;
            SDLDrawingsGB.Visible = SLDDrawing.Checked;
            SchematicsDrawingGB.Visible = SchematicsDrawing.Checked;
            ABOMGB.Visible = ABOM.Checked;
            BBOMGB.Visible = BBOM.Checked;
            NSRGB.Visible = NSR.Checked;
            ProductionFileGB.Visible = ProductionBOM.Checked;
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
                row["Order Name"] = OrderName.Text;
                row["Project Number"] = ProjectNumber.Text;
                row["TCR"] = TCR.Text;
                row["Is PreBOM"] = ISPreBOM.Checked;
                row["Was Offer"] = WasOffer.Checked;
                row["Previous Offer Name"] = PreviousOfferName.Text;
                row["Previous Offer Number"] = PreviousOfferNumber.Text;
                row["Segment"] = Segment.Text;
                row["Item Number"] = ItemNumber.Text;
                row["Total Cells"] = NumberOfCells.Text;
                row["Complexity"] = Complexity.Text;
                row["Not Has NSR"] = NOTHasNSR.Checked;
                row["Patch Name"] = PatchName.Text;
                row["Approval Date"] = FollowUpCore.Date_validate(ApprovalDatet.Text);
                row["Item Status"] = ItemStatus.Text;
                row["Family"] = Family.Text;
                row["WBS"] = WBS.Text;
                row["Celling Hours"] = CellingHours.Text;    
                row["Receive Date"] = FollowUpCore.Date_validate(RecieveDatet.Text);
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
                //Actual Hours Schematics
                //row["Standard Hours Schematics"]
                row["Schematics Modification Complexity"] = SchematicsModComplexity.Text;
                row["Schematics Modification Impacted Cells"] = SchematicsModCells.Text;
                row["Schematics Drawing Comment"] = SchematicsComment.Text;

                row["ABOM Due Date"] = FollowUpCore.Date_validate(ABOMDueDatet.Text);
                row["ABOM CLO Date"] = FollowUpCore.Date_validate(ABOMCLODate.Text);
                row["Actual Date ABOM"] = FollowUpCore.Date_validate(ABOMActualDatet.Text);
                // row["Actual Hours ABOM"] 
                // row["Standard Hours ABOM"]
                row["ABOM Comment"] = ABOMComment.Text;

                row["BBOM Due Date"] = FollowUpCore.Date_validate(BBOMDueDatet.Text);
                row["BBOM CLO Date"] = FollowUpCore.Date_validate(BBOMCLODate.Text);
                row["Actual Date BBOM"] = FollowUpCore.Date_validate(BBOMActualDatet.Text);
                // row["Actual Hours BBOM"] 
                // row["Standard Hours BBOM"]
                row["BBOM Comment"] = BBOMComment.Text;

                row["NSR Due Date"] = FollowUpCore.Date_validate(NSRDueDatet.Text);
                row["NSR CLO Date"] = FollowUpCore.Date_validate(NSRCLODate.Text);
                row["Actual Date NSR"] = FollowUpCore.Date_validate(NSRActualDatet.Text);
                // row["Actual Hours NSR"] 
                // row["Standard Hours NSR"]
                row["NSR Comment"] = NSRComment.Text;

                row["PF Due Date"] = FollowUpCore.Date_validate(PFDueDatet.Text);
                row["PF CLO Date"] = FollowUpCore.Date_validate(PFCLODate.Text);
                row["Actual Date PF"] = FollowUpCore.Date_validate(PFActualDatet.Text);
                // row["Actual Hours PF"] 
                // row["Standard Hours PF"]
                row["PF Comment"] = PFComment.Text;
                //row["Standard Hours PF"]
                if (extended)
                {
                    row["Index"] = "1";
                }
                else
                {
                    row["Index"] = "0";
                }
                //
                TDetails.Rows.Add(row);
                return true;
            }
            else
            {
                return false;
            }
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
                 TDetails.Rows[index]["Team Leader"] = FollowUpCore.UserName;
                 TDetails.Rows[index]["Department"] = FollowUpCore.UserDepartment;
                 TDetails.Rows[index]["Order Name"] = OrderName.Text;
                 TDetails.Rows[index]["Project Number"] = ProjectNumber.Text;
                 TDetails.Rows[index]["TCR"] = TCR.Text;
                 TDetails.Rows[index]["Is PreBOM"] = ISPreBOM.Checked;
                 TDetails.Rows[index]["Was Offer"] = WasOffer.Checked;
                 TDetails.Rows[index]["Previous Offer Name"] = PreviousOfferName.Text;
                 TDetails.Rows[index]["Previous Offer Number"] = PreviousOfferNumber.Text;
                 TDetails.Rows[index]["Segment"] = Segment.Text;
                 TDetails.Rows[index]["Item Number"] = ItemNumber.Text;
                 TDetails.Rows[index]["Total Cells"] = NumberOfCells.Text;
                 TDetails.Rows[index]["Complexity"] = Complexity.Text;
                 TDetails.Rows[index]["Not Has NSR"] = NOTHasNSR.Checked;
                 TDetails.Rows[index]["Patch Name"] = PatchName.Text;
                 TDetails.Rows[index]["Approval Date"] = FollowUpCore.Date_validate(ApprovalDatet.Text);
                 TDetails.Rows[index]["Item Status"] = ItemStatus.Text;
                 TDetails.Rows[index]["Family"] = Family.Text;
                 TDetails.Rows[index]["WBS"] = WBS.Text;
                 TDetails.Rows[index]["Celling Hours"] = CellingHours.Text;
                 TDetails.Rows[index]["Receive Date"] = FollowUpCore.Date_validate(RecieveDatet.Text);
                 TDetails.Rows[index]["SLD Modification"] = SLDModification.Checked;
                 TDetails.Rows[index]["Due Date SLD"] = FollowUpCore.Date_validate(SLDDueDatet.Text);
                 TDetails.Rows[index]["Due Date CLO SLD"] = FollowUpCore.Date_validate(SLDCLODate.Text);
                 TDetails.Rows[index]["Actual Date SLD"] = FollowUpCore.Date_validate(SLDActualDatet.Text);
                //  TDetails.Rows[index]["Actual Hours SLD"]
                //  TDetails.Rows[index]["Standard Hours SLD"] = function return hours per complexity and number of cells and family
                 TDetails.Rows[index]["SLD Modification Complexity"] = SLDModComplexity.Text;
                 TDetails.Rows[index]["SLD Modification Impacted Cells"] = SLDModCells.Text;
                 TDetails.Rows[index]["SLD Drawing Comment"] = SLDComment.Text;
                 TDetails.Rows[index]["Schematics Modification"] = SchematicsModification.Checked;
                 TDetails.Rows[index]["Due Date Schematics"] = FollowUpCore.Date_validate(SchematicsDueDatet.Text);
                 TDetails.Rows[index]["Due Date CLO Schematics"] = FollowUpCore.Date_validate(SchematicsCLODate.Text);
                 TDetails.Rows[index]["Actual Date Schematics"] = FollowUpCore.Date_validate(SchematicsActualDatet.Text);
                //Actual Hours Schematics
                // TDetails.Rows[index]["Standard Hours Schematics"]
                 TDetails.Rows[index]["Schematics Modification Complexity"] = SchematicsModComplexity.Text;
                 TDetails.Rows[index]["Schematics Modification Impacted Cells"] = SchematicsModCells.Text;
                 TDetails.Rows[index]["Schematics Drawing Comment"] = SchematicsComment.Text;

                 TDetails.Rows[index]["ABOM Due Date"] = FollowUpCore.Date_validate(ABOMDueDatet.Text);
                 TDetails.Rows[index]["ABOM CLO Date"] = FollowUpCore.Date_validate(ABOMCLODate.Text);
                 TDetails.Rows[index]["Actual Date ABOM"] = FollowUpCore.Date_validate(ABOMActualDatet.Text);
                //  TDetails.Rows[index]["Actual Hours ABOM"] 
                //  TDetails.Rows[index]["Standard Hours ABOM"]
                 TDetails.Rows[index]["ABOM Comment"] = ABOMComment.Text;

                 TDetails.Rows[index]["BBOM Due Date"] = FollowUpCore.Date_validate(BBOMDueDatet.Text);
                 TDetails.Rows[index]["BBOM CLO Date"] = FollowUpCore.Date_validate(BBOMCLODate.Text);
                 TDetails.Rows[index]["Actual Date BBOM"] = FollowUpCore.Date_validate(BBOMActualDatet.Text);
                //  TDetails.Rows[index]["Actual Hours BBOM"] 
                //  TDetails.Rows[index]["Standard Hours BBOM"]
                 TDetails.Rows[index]["BBOM Comment"] = BBOMComment.Text;

                 TDetails.Rows[index]["NSR Due Date"] = FollowUpCore.Date_validate(NSRDueDatet.Text);
                 TDetails.Rows[index]["NSR CLO Date"] = FollowUpCore.Date_validate(NSRCLODate.Text);
                 TDetails.Rows[index]["Actual Date NSR"] = FollowUpCore.Date_validate(NSRActualDatet.Text);
                //  TDetails.Rows[index]["Actual Hours NSR"] 
                //  TDetails.Rows[index]["Standard Hours NSR"]
                 TDetails.Rows[index]["NSR Comment"] = NSRComment.Text;

                 TDetails.Rows[index]["PF Due Date"] = FollowUpCore.Date_validate(PFDueDatet.Text);
                 TDetails.Rows[index]["PF CLO Date"] = FollowUpCore.Date_validate(PFCLODate.Text);
                 TDetails.Rows[index]["Actual Date PF"] = FollowUpCore.Date_validate(PFActualDatet.Text);
                //  TDetails.Rows[index]["Actual Hours PF"] 
                //  TDetails.Rows[index]["Standard Hours PF"]
                 TDetails.Rows[index]["PF Comment"] = PFComment.Text;

               
 
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
            ItemNumber.Text = "";
            NumberOfCells.Text = "";
            Complexity.Text = "";
            NOTHasNSR.Checked =  false;
           
            ApprovalDatet.Text = "";
            ItemStatus.Text = "";
            Family.Text = "";
            WBS.Text = "";
            CellingHours.Text = "";
            RecieveDatet.Text = "";

            SLDModification.Checked = false;
            SLDDueDatet.Text = "";
            SLDCLODate.Text = "";
            SLDActualDatet.Text = "";
            SLDModComplexity.Text = "";
            SLDModCells.Text = "";
            SLDComment.Text = "";

            SchematicsModification.Checked =  false;
            SchematicsDueDatet.Text = "";
            SchematicsCLODate.Text = "";
            SchematicsActualDatet.Text = "";
            SchematicsModComplexity.Text = "";
            SchematicsModCells.Text = "";
            SchematicsComment.Text = "";

            ABOMDueDatet.Text = "";
            ABOMCLODate.Text = "";
            ABOMActualDatet.Text = "";
            ABOMComment.Text = "";

            BBOMDueDatet.Text = "";
            BBOMCLODate.Text = "";
            BBOMActualDatet.Text = "";
            BBOMComment.Text = "";

            NSRDueDatet.Text = "";
            NSRCLODate.Text = "";
            NSRActualDatet.Text = "";
            NSRComment.Text = "";

            PFDueDatet.Text = "";
            PFCLODate.Text = "";
            PFActualDatet.Text = "";
            PFComment.Text = "";

            SLDDrawing.Checked = false;
            SchematicsDrawing.Checked = false;
            ABOM.Checked = false;
            BBOM.Checked = false;
            NSR.Checked = false;

            ProductionBOM.Checked = false;
            AsManufacture.Checked = false;
            Other.Checked = false;
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
                MessageBox.Show("No Items exist to be removed");
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
            if (!string.IsNullOrEmpty(TDetails.Rows[index]["ID"].ToString()))
            {
                RemoveIDs.Add(TDetails.Rows[index]["ID"].ToString());
            }
            TDetails.Rows.RemoveAt(index);
            return true;

        }

        bool SaveToDB(int count)
        {
            FollowUpCore.updateTablebytable(ref FollowUpCore.LoadOrder, TDetails,RemoveIDs);
            int i = AccessDB.Insert_table(FollowUpCore.LoadOrder, "OrderDetail", AccessDB.dic_to_string_Read1(FollowUpCore.DicTeam_Designers, "OrderDetail", "*"), RemoveIDs);
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

        private void NewItem_Click(object sender, EventArgs e)
        {
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

        private void Clear_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            int index;
            int count = TDetails.Rows.Count;
            if (count==0)
            {
                MessageBox.Show("Al Deleted", "No Items exist to be removed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tb_current.Text = "0";
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
                            tb_current.Text = index.ToString();
                        }
                    }

                }
                else
                {
                    MessageBox.Show("Index out of boundry", "Index Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    index = 0;
                    tb_current.Text = index.ToString();
                }

            }
            else
            {
                MessageBox.Show("Index out of boundry", "Index Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                index = 0;
                tb_current.Text = index.ToString();
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
            //TODO: loop over all items and check validation(loop over all and run validate)
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
                //after saving you must update your table(for detail )
                FollowUpCore.LoadOrder = AccessDB.Read_DataSet1(FollowUpCore.DicTeamLeaders, "OrderDetail", "*");
                MessageBox.Show("Saving Sucessfully, Closing Now");
                this.Close();
            }
            else
            {

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

        private void Extend_Click(object sender, EventArgs e)
        {
            //TODO: add Main Row ID in to index and show lable with extended
            int count = TDetails.Rows.Count;

            if (AddNew(count,true))
            {
                tb_current.Text = count.ToString();
                MessageBox.Show("Extending Done");
            }
        }

        private void SLDModification_CheckedChanged(object sender, EventArgs e)
        {
            label7.Visible = SLDModification.Visible;
            SLDModComplexity.Visible= SLDModification.Visible;
            label6.Visible = SLDModification.Visible;
            SLDModCells.Visible = SLDModification.Visible;
        }

        private void SchematicsModification_CheckedChanged(object sender, EventArgs e)
        {
            label8.Visible = SchematicsModification.Checked;
            SchematicsModComplexity.Visible = SchematicsModification.Checked;
            label12.Visible = SchematicsModification.Checked;
            SchematicsModCells.Visible = SchematicsModification.Checked;
        }

        private void SLDDrawing_CheckedChanged(object sender, EventArgs e)
        {
            SDLDrawingsGB.Visible = SLDDrawing.Checked;
            if (!SLDDrawing.Checked)
            {
                FollowUpCore.ClearGroupBox(SDLDrawingsGB);
            }
        }

        private void SchematicsDrawing_CheckedChanged(object sender, EventArgs e)
        {
            SchematicsDrawingGB.Visible = SchematicsDrawing.Checked;
            if (!SchematicsDrawing.Checked)
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

        private void CLOSLDButton_Click(object sender, EventArgs e)
        {
            //TODO: Make Window form that take complexity&Cells&Family and receive date and return CLO date
            CLO clo = new CLO(Family.Text,Complexity.Text, NumberOfCells.Text, ApprovalDatet.Text, CLOSLDButton.Tag.ToString());
            clo.ShowDialog();
            SLDCLODate.Text = CLO.CLODate;
        }

        private void CLOSchematicsButton_Click(object sender, EventArgs e)
        {
            //TODO: Make Window form that take complexity&Cells&Family and receive date and return CLO date
            CLO clo = new CLO(Family.Text, Complexity.Text, NumberOfCells.Text, ApprovalDatet.Text, CLOSchematicsButton.Tag.ToString());
            clo.ShowDialog();
            SchematicsCLODate.Text = CLO.CLODate;
        }

        private void CLOABOMButton_Click(object sender, EventArgs e)
        {
            //TODO: Make Window form that take complexity&Cells&Family and receive date and return CLO date
            CLO clo = new CLO(Family.Text, Complexity.Text, NumberOfCells.Text, ApprovalDatet.Text, CLOABOMButton.Tag.ToString());
            clo.ShowDialog();
            ABOMCLODate.Text = CLO.CLODate;
        }

        private void CLOBBOMButton_Click(object sender, EventArgs e)
        {
            //TODO: Make Window form that take complexity&Cells&Family and receive date and return CLO date
            CLO clo = new CLO(Family.Text, Complexity.Text, NumberOfCells.Text, ApprovalDatet.Text, CLOBBOMButton.Tag.ToString());
            clo.ShowDialog();
            BBOMCLODate.Text = CLO.CLODate;
        }

        private void CLONSRButton_Click(object sender, EventArgs e)
        {
            //TODO: Make Window form that take complexity&Cells&Family and receive date and return CLO date
            CLO clo = new CLO(Family.Text, Complexity.Text, NumberOfCells.Text, ApprovalDatet.Text, CLONSRButton.Tag.ToString());
            clo.ShowDialog();
           NSRCLODate.Text = CLO.CLODate;
        }

        private void CLOPFButton_Click(object sender, EventArgs e)
        {
            //TODO: Make Window form that take complexity&Cells&Family and receive date and return CLO date
            CLO clo = new CLO(Family.Text, Complexity.Text, NumberOfCells.Text, ApprovalDatet.Text, CLOPFButton.Tag.ToString());
            clo.ShowDialog();
            PFCLODate.Text = CLO.CLODate;
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
                        //ok go to change index
                        oldIndex = index;
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
            //TODO: loop over all items and check validation(loop over all and run validate)
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
                //after saving you must update your table(for detail )
                FollowUpCore.LoadOrder = AccessDB.Read_DataSet1(FollowUpCore.DicTeamLeaders, "OrderDetail", "*");
                MessageBox.Show("Saving Sucessfully");
                view(oldIndex, TDetails.Rows.Count);
            }
            else
            {

            }
        }

        private void HasNSR_CheckedChanged(object sender, EventArgs e)
        {
            if (NOTHasNSR.Checked)
            {
                NSR.Checked = !NOTHasNSR.Checked;
               
            }
           
            NSR.Enabled = !NOTHasNSR.Checked; 

        }
    }
}

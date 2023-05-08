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
    public partial class Main_TeamLeader : Form
    {

        public Main_TeamLeader()
        {
            InitializeComponent();
        }
        void loadAllStatus()
        {//this fillter for all tasks exist and count them and show them over icons
            FollowUpCore.LoadOffer.DefaultView.RowFilter = string.Format("[Due Date SLD] IS NOT NULL AND [Actual Date SLD] IS NULL");
            LblSLDOffer.Text = FollowUpCore.LoadOffer.DefaultView.Count.ToString();
            FollowUpCore.LoadOffer.DefaultView.RowFilter = string.Format("[Due Date Schematics] IS NOT NULL AND [Actual Date Schematics] IS NULL");
            LblSchematicsOffer.Text = FollowUpCore.LoadOffer.DefaultView.Count.ToString();
            FollowUpCore.LoadOrder.DefaultView.RowFilter = string.Format("[ABOM Due Date] IS NOT NULL AND [Actual Date ABOM] IS NULL");
            LblABOM.Text = FollowUpCore.LoadOrder.DefaultView.Count.ToString();
            FollowUpCore.LoadOrder.DefaultView.RowFilter = string.Format("[BBOM Due Date] IS NOT NULL AND [Actual Date BBOM] IS NULL");
          // LblBBOM.Text = FollowUpCore.LoadOrder.DefaultView.Count.ToString();
            FollowUpCore.LoadOrder.DefaultView.RowFilter = string.Format("[NSR Due Date] IS NOT NULL AND [Actual Date NSR] IS NULL");
            LblNSR.Text = FollowUpCore.LoadOrder.DefaultView.Count.ToString();
            FollowUpCore.LoadOrder.DefaultView.RowFilter = string.Format("[Due Date Schematics] IS NOT NULL AND [Actual Date Schematics] IS NULL");
            LblSchematicsOrder.Text = FollowUpCore.LoadOrder.DefaultView.Count.ToString();
            FollowUpCore.LoadOrder.DefaultView.RowFilter = string.Format("[Due Date SLD] IS NOT NULL AND [Actual Date SLD] IS NULL");
            LblSLDOrder.Text = FollowUpCore.LoadOrder.DefaultView.Count.ToString();
            FollowUpCore.LoadOrder.DefaultView.RowFilter = string.Format("[PF Due Date] IS NOT NULL AND [Actual Date PF] IS NULL");
            LblPF.Text = FollowUpCore.LoadOrder.DefaultView.Count.ToString();
        }
        private void OrderSLDPrev_Click(object sender, EventArgs e)
        {

            PreviewDesigner PreD = new PreviewDesigner(FollowUpCore.PrevOrderSLDstr, "[Due Date SLD] IS NOT NULL AND [Actual Date SLD] IS NULL", "[Due Date SLD] ASC", ref FollowUpCore.LoadOrder, FollowUpCore.DetailOrderCols, "Actual Date SLD", "OrderDetail", "Orders SLD");
            this.Visible = false;
            PreD.ShowDialog();
            this.Visible = true;
            loadAllStatus();

        }

        private void OrderSchematicsPrev_Click(object sender, EventArgs e)
        {

            PreviewDesigner PreD = new PreviewDesigner(FollowUpCore.PrevOrderSchematicsstr, "[Due Date Schematics] IS NOT NULL AND [Actual Date Schematics] IS NULL", "[Due Date Schematics] ASC", ref FollowUpCore.LoadOrder, FollowUpCore.DetailOrderCols, "Actual Date Schematics", "OrderDetail", "Orders Schematics");
            this.Visible = false;
            PreD.ShowDialog();
            this.Visible = true;
            loadAllStatus();
        }

        private void OrderABOMPrev_Click(object sender, EventArgs e)
        {
            PreviewDesigner PreD = new PreviewDesigner(FollowUpCore.PrevOrderABOM, "[ABOM Due Date] IS NOT NULL AND [Actual Date ABOM] IS NULL", "[ABOM Due Date] ASC", ref FollowUpCore.LoadOrder, FollowUpCore.DetailOrderCols, "Actual Date ABOM", "OrderDetail", "Orders ABOM");
            this.Visible = false;
            PreD.ShowDialog();
            this.Visible = true;
            loadAllStatus();

        }

        private void OrderBBOMPrev_Click(object sender, EventArgs e)
        {
            PreviewDesigner PreD = new PreviewDesigner(FollowUpCore.PrevOrderBBOM, "[BBOM Due Date] IS NOT NULL AND [Actual Date BBOM] IS NULL", "[BBOM Due Date] ASC", ref FollowUpCore.LoadOrder, FollowUpCore.DetailOrderCols, "Actual Date BBOM", "OrderDetail", "Orders BBOM");
            this.Visible = false;
            PreD.ShowDialog();
            this.Visible = true;
            loadAllStatus();
        }

        private void OrderNSRPrev_Click(object sender, EventArgs e)
        {
            PreviewDesigner PreD = new PreviewDesigner(FollowUpCore.PrevOrderNSR, "[NSR Due Date] IS NOT NULL AND [Actual Date NSR] IS NULL", "[NSR Due Date] ASC", ref FollowUpCore.LoadOrder, FollowUpCore.DetailOrderCols, "Actual Date NSR", "OrderDetail", "Orders NSR");
            this.Visible = false;
            PreD.ShowDialog();
            this.Visible = true;
            loadAllStatus();

        }

        private void OrderPFPrev_Click(object sender, EventArgs e)
        {
            PreviewDesigner PreD = new PreviewDesigner(FollowUpCore.PrevOrderPF, "[PF Due Date] IS NOT NULL AND [Actual Date PF] IS NULL", "[PF Due Date] ASC", ref FollowUpCore.LoadOrder, FollowUpCore.DetailOrderCols, "Actual Date PF", "OrderDetail", "Orders Production File");
            this.Visible = false;
            PreD.ShowDialog();
            this.Visible = true;
            loadAllStatus();

        }

        private void OfferSLDPrev_Click(object sender, EventArgs e)
        {
            PreviewDesigner PreD = new PreviewDesigner(FollowUpCore.PrevOfferSLDstr, "[Due Date SLD] IS NOT NULL AND [" + FollowUpCore.TargetPrevOfferSLD + "] IS NULL", "[Due Date SLD] ASC", ref FollowUpCore.LoadOffer, FollowUpCore.DetailOfferCols, FollowUpCore.TargetPrevOfferSLD, "OfferDetail", "Offer SLD");
            this.Visible = false;
            PreD.ShowDialog();
            this.Visible = true;
            loadAllStatus();
        }

        private void OfferSchematicPrev_Click(object sender, EventArgs e)
        {
            PreviewDesigner PreD = new PreviewDesigner(FollowUpCore.PrevOfferSchematicsstr, "[Due Date Schematics] IS NOT NULL AND [Actual Date Schematics] IS NULL", "[Due Date Schematics] ASC", ref FollowUpCore.LoadOffer, FollowUpCore.DetailOfferCols, "Actual Date Schematics", "OfferDetail", "Offer Schematics");
            this.Visible = false;
            PreD.ShowDialog();
            this.Visible = true;
            loadAllStatus();
        }

        private void NewOrder_Click(object sender, EventArgs e)
        {
            AddOrderGeneral AddOrderG = new AddOrderGeneral();
            this.Visible = false;
            AddOrderG.ShowDialog();
            this.Visible = true;
            loadAllStatus();
        }

        private void NewOffer_Click(object sender, EventArgs e)
        {
            AddOfferGeneral AddOfferG = new AddOfferGeneral();
            this.Visible = false;
            AddOfferG.ShowDialog();
            this.Visible = true;
            loadAllStatus();
        }

        private void Main_TeamLeader_Shown(object sender, EventArgs e)
        {//get designers that follow 
            FollowUpCore.VacationsList = FollowUpCore.vacations();
            FollowUpCore.GetTeamDesigners(FollowUpCore.UserName, "Relations", ref FollowUpCore.Team_Designers, ref FollowUpCore.DicTeam_Designers);
            FollowUpCore.LoadOffer = AccessDB.Read_DataSet1(FollowUpCore.DicTeam_Designers, "OfferDetail", "*");
            FollowUpCore.LoadOrder = AccessDB.Read_DataSet1(FollowUpCore.DicTeam_Designers, "OrderDetail", "*");
            loadAllStatus();
            LblName.Text = FollowUpCore.UserName;
            //load values in designers section
            FollowUpCore.Team_Designers = AccessDB.GetData(new Dictionary<string, string>() { { FollowUpCore.UserName, "x" } }, "Relations", "Employee");
        }

        private void PrintTaskReport_Click(object sender, EventArgs e)
        {
            ExtractTasksReport erp = new ExtractTasksReport(false);
            this.Visible = false;
            erp.ShowDialog();
            this.Visible = true;
        }

        private void Refresh_Click(object sender, EventArgs e)
        {
            FollowUpCore.GetTeamDesigners(FollowUpCore.UserName, "Relations", ref FollowUpCore.Team_Designers, ref FollowUpCore.DicTeam_Designers);
            FollowUpCore.LoadOffer = AccessDB.Read_DataSet1(FollowUpCore.DicTeam_Designers, "OfferDetail", "*");
            FollowUpCore.LoadOrder = AccessDB.Read_DataSet1(FollowUpCore.DicTeam_Designers, "OrderDetail", "*");
            loadAllStatus();
        }

        private void AddTaskOffer_Click(object sender, EventArgs e)
        {
            ModifyOffer modof = new ModifyOffer();
            this.Visible = false;
            modof.ShowDialog();
            this.Visible = true;
            FollowUpCore.LoadOffer = AccessDB.Read_DataSet1(FollowUpCore.DicTeam_Designers, "OfferDetail", "*");
            FollowUpCore.LoadOrder = AccessDB.Read_DataSet1(FollowUpCore.DicTeam_Designers, "OrderDetail", "*");
            loadAllStatus();
        }

        private void ModifyOrder_Click(object sender, EventArgs e)
        {
            ModifyOrder modor = new ModifyOrder();
            this.Visible = false;
            modor.ShowDialog();
            this.Visible = true;
           // FollowUpCore.GetTeamDesigners(FollowUpCore.UserName, "Relations", ref FollowUpCore.Team_Designers, ref FollowUpCore.DicTeam_Designers);
            FollowUpCore.LoadOffer = AccessDB.Read_DataSet1(FollowUpCore.DicTeam_Designers, "OfferDetail", "*");
            FollowUpCore.LoadOrder = AccessDB.Read_DataSet1(FollowUpCore.DicTeam_Designers, "OrderDetail", "*");
            loadAllStatus();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PasswordChange pc = new PasswordChange();
            pc.ShowDialog();
        }

        private void AddOtherTask_Click(object sender, EventArgs e)
        {

        }

        private void DrawingMod_Click(object sender, EventArgs e)
        {
            drawingModif Drmod = new drawingModif();
            this.Visible = false;
            Drmod.ShowDialog();
            this.Visible = true;
            FollowUpCore.LoadOffer = AccessDB.Read_DataSet1(FollowUpCore.DicTeam_Designers, "OfferDetail", "*");
            FollowUpCore.LoadOrder = AccessDB.Read_DataSet1(FollowUpCore.DicTeam_Designers, "OrderDetail", "*");
            loadAllStatus();
        }


    }
}

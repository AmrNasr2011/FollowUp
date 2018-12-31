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
    public partial class Main_Designer : Form
    {
        
        public Main_Designer()
        {
            InitializeComponent();
        }

        private void Main_Designer_Load(object sender, EventArgs e)
        {
            FollowUpCore.DicTeam_Designers = new Dictionary<string, string>();
            FollowUpCore.DicTeam_Designers.Add(FollowUpCore.UserName, "Designer");
        }

        private void NewOrder_Click(object sender, EventArgs e)
        {
            AddOrderGeneral aog = new AddOrderGeneral();
            this.Visible = false;
            aog.ShowDialog();
            this.Visible = true;
            loadAllStatus();
        }

        private void NewOffer_Click(object sender, EventArgs e)
        {
            AddOfferGeneral aog = new AddOfferGeneral();
            this.Visible = false;
            aog.ShowDialog();
            this.Visible = true;
            loadAllStatus();
        }

        private void Main_Designer_Shown(object sender, EventArgs e)
        {
            //here i will load both tables with required data
            FollowUpCore.LoadOffer = AccessDB.Read_DataSet1(FollowUpCore.DicTeam_Designers, "OfferDetail", "*");
            FollowUpCore.LoadOrder = AccessDB.Read_DataSet1(FollowUpCore.DicTeam_Designers, "OrderDetail", "*");
            loadAllStatus();
            LblName.Text = FollowUpCore.UserName;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PasswordChange pc = new PasswordChange();
            pc.ShowDialog();
        }

        private void OfferSLDPrev_Click(object sender, EventArgs e)
        {
           
            PreviewDesigner PreD = new PreviewDesigner(FollowUpCore.PrevOfferSLDstr, "[Due Date SLD] IS NOT NULL AND [" + FollowUpCore.TargetPrevOfferSLD + "] IS NULL", "[Due Date SLD] ASC", ref FollowUpCore.LoadOffer, FollowUpCore.DetailOfferCols, FollowUpCore.TargetPrevOfferSLD, "OfferDetail", "Offer SLD");
            this.Visible = false;
            PreD.ShowDialog();
            this.Visible = true;
            loadAllStatus();
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

        private void OfferSchematicPrev_Click(object sender, EventArgs e)
        {
          
            PreviewDesigner PreD = new PreviewDesigner(FollowUpCore.PrevOfferSchematicsstr, "[Due Date Schematics] IS NOT NULL AND [Actual Date Schematics] IS NULL", "[Due Date Schematics] ASC", ref FollowUpCore.LoadOffer, FollowUpCore.DetailOfferCols, "Actual Date Schematics", "OfferDetail", "Offer Schematics");
            this.Visible = false;
            PreD.ShowDialog();
            this.Visible = true;
            loadAllStatus();
        }

        void loadAllStatus()
        {
            FollowUpCore.LoadOffer.DefaultView.RowFilter = string.Format("[Due Date SLD] IS NOT NULL AND [Actual Date SLD] IS NULL");
            LblSLDOffer.Text = FollowUpCore.LoadOffer.DefaultView.Count.ToString();
            FollowUpCore.LoadOffer.DefaultView.RowFilter = string.Format("[Due Date Schematics] IS NOT NULL AND [Actual Date Schematics] IS NULL");
            LblSchematicsOffer.Text = FollowUpCore.LoadOffer.DefaultView.Count.ToString();
            FollowUpCore.LoadOrder.DefaultView.RowFilter = string.Format("[ABOM Due Date] IS NOT NULL AND [Actual Date ABOM] IS NULL");
            LblABOM.Text = FollowUpCore.LoadOrder.DefaultView.Count.ToString();
            FollowUpCore.LoadOrder.DefaultView.RowFilter = string.Format("[BBOM Due Date] IS NOT NULL AND [Actual Date BBOM] IS NULL");
            LblBBOM.Text = FollowUpCore.LoadOrder.DefaultView.Count.ToString();
            FollowUpCore.LoadOrder.DefaultView.RowFilter = string.Format("[NSR Due Date] IS NOT NULL AND [Actual Date NSR] IS NULL");
            LblNSR.Text = FollowUpCore.LoadOrder.DefaultView.Count.ToString();
            FollowUpCore.LoadOrder.DefaultView.RowFilter = string.Format("[Due Date Schematics] IS NOT NULL AND [Actual Date Schematics] IS NULL");
            LblSchematicsOrder.Text = FollowUpCore.LoadOrder.DefaultView.Count.ToString();
            FollowUpCore.LoadOrder.DefaultView.RowFilter = string.Format("[Due Date SLD] IS NOT NULL AND [Actual Date SLD] IS NULL");
            LblSLDOrder.Text = FollowUpCore.LoadOrder.DefaultView.Count.ToString();
            FollowUpCore.LoadOrder.DefaultView.RowFilter = string.Format("[PF Due Date] IS NOT NULL AND [Actual Date PF] IS NULL");
            LblPF.Text = FollowUpCore.LoadOrder.DefaultView.Count.ToString();
        }

        private void button16_Click(object sender, EventArgs e)
        {

        }

        private void Refresh_Click(object sender, EventArgs e)
        {
            FollowUpCore.LoadOffer = AccessDB.Read_DataSet1(FollowUpCore.DicTeam_Designers, "OfferDetail", "*");
            FollowUpCore.LoadOrder = AccessDB.Read_DataSet1(FollowUpCore.DicTeam_Designers, "OrderDetail", "*");
            loadAllStatus();
        }

        private void PrintTaskReport_Click(object sender, EventArgs e)
        {
            ExtractTasksReport erp = new ExtractTasksReport(true);
            this.Visible = false;
            erp.ShowDialog();
            this.Visible = true;
        }
    }

}

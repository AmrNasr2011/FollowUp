using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace FollowUp
{
    public struct Prp
    {
        public int id;
        public int width;
        public bool read;
    }
    class FollowUpCore
    {
        public static List<DateTime> VacationsList;
        //main data between forms
        //Data from Login form
        public static string UserSESA;
        public static string UserName;
        public static string UserDepartment;
        public static string UserManager;
        public static string UserRole;

        public static string[] DetailOfferCols;
        public static string[] DetailOrderCols;

        public static string[] GeneralOfferCols;
        public static string[] GeneralOrderCols;

        public static string[] CommonOffer;
        public static string[] CommonOrder;

        public static DataTable GeneralOrder_table;
        public static DataTable DetailOrder_table;
        public static DataTable GeneralOffer_table ;
        public static DataTable DetailOffer_table ;

        public static List<String> AssacDesigners;

        public static DataTable LoadOffer;
        public static DataTable LoadOrder;

        public static List<string> Team_Designers;
        public static List<string> Team_TeamLeaders;

        public static Dictionary<string, string> DicTeam_Designers;
        public static Dictionary<string, string> DicTeamLeaders;

        public static List<string> ListTCO;
        public static List<string> ListTCR;

        public static List<string> Segment;
        public static List<string> Complexity;
        public static List<string> Complexity1;
        public static List<string> Complexity2;
        public static List<string> RequiredBy;
        public static List<string> ItemStatus;

        //preview schema
        public static Prp[] PrevOfferSLDstr;
        public static string TargetPrevOfferSLD;
        public static Prp[] PrevOfferSchematicsstr;
        public static string TargetPrevOfferSchematics;
        public static Prp[] PrevOrderSLDstr;
        public static string TargetPrevOrderSLD;
        public static Prp[] PrevOrderSchematicsstr;
        public static string TargetPrevOrderSchematics;

        public static string TargetPrevOrderABOM;
        public static Prp[] PrevOrderABOM;
        public static string TargetPrevOrderBBOM;
        public static Prp[] PrevOrderBBOM;
        public static string TargetPrevOrderNSR;
        public static Prp[] PrevOrderNSR;
        public static string TargetPrevOrderPF;
        public static Prp[] PrevOrderPF;

        public static Prp[] ModOffer;
        public static Prp[] MODOrder;


        //ID for order and offers modification
        public static int IDOffer;
        public static int IDOrder;
        static   FollowUpCore()
        {

            IDOffer = -100;
            IDOrder = -100;

            GeneralOrder_table = new DataTable();
            DetailOrder_table = new DataTable();
            GeneralOffer_table = new DataTable();
            DetailOffer_table = new DataTable();


            LoadOffer = new DataTable();
            LoadOrder = new DataTable();

            ListTCO = new List<string>();
            ListTCR = new List<string>();

            Team_Designers = new List<string>();
            DicTeam_Designers = new Dictionary<string, string>();

            ListTCO = AccessDB.GetData(new Dictionary<string, string>() { { "Role", "TCO" } }, "Interfaces", "Employee");
            ListTCR = AccessDB.GetData(new Dictionary<string, string>() { { "Role", "TCR" } }, "Interfaces", "Employee");
//ToDo:need to import all those data to database and retrieve them.
            Segment = new List<string>() {"","Oil&Gas","Infrastructure","WWW","Utility","Export" ,"Building","Service"};
            Complexity = new List<string>() { "","Simple", "Medium", "Complex"};
            Complexity1 = new List<string>() { "", "Simple", "Medium", "Complex" };
            Complexity2 = new List<string>() { "", "Simple", "Medium", "Complex" };
            RequiredBy = new List<string>() { "","TCO", "TCR", "F.O" };
            ItemStatus = new List<string>() { "", "Approved", "Not Approved"};


            
            GeneralOfferCols = new string[]
           {
               "ID","Designer","Team Leader","Department","Offer Name","Offer Number","TCO","Segment","Items Numbers","Total Items","Total Cells","Patch Name","Common Complexity","Receive Date","SLD Modification","Due Date SLD","Due Date CLO SLD","SLD Modification Complexity","SLD Modification Impacted Cells","SLD Drawing Comment","Schematics Modification","Due Date Schematics","Due Date CLO Schematics","Schematics Modification Complexity","Schematics Modification Impacted Cells","Schematics Drawing Comment"

           };

            GeneralOrderCols = new string[]
            {
                "ID","Designer","Team Leader","Department","Order Name","Project Number","TCR","Is PreBOM","Was Offer","Previous Offer Name","Previous Offer Number","Segment","Items Numbers","Total Items","Total Cells","Patch Name","Item Status","Approval Date","Common Complexity","Receive Date","SLD Modification","Due Date SLD","Due Date CLO SLD","SLD Modification Complexity","SLD Modification Impacted Cells","SLD Drawing Comment","Schematics Modification","Due Date Schematics","Due Date CLO Schematics","Schematics Modification Complexity","Schematics Modification Impacted Cells","Schematics Drawing Comment","ABOM Due Date","ABOM CLO Date","ABOM Comment","BBOM Due Date","BBOM CLO Date","BBOM Comment","NSR Due Date","NSR CLO Date","NSR Comment","PF Due Date","PF CLO Date","PF Comment"
            };

            DetailOfferCols = new string[]
            {
                 "ID","Designer","Team Leader","Department","Offer Name","Offer Number","TCO","Segment","Item Number","Total Cells","Family","Complexity","Patch Name","Receive Date","SLD Modification","Due Date SLD","Due Date CLO SLD","Actual Date SLD","Actual Hours SLD","Standard Hours SLD","SLD Modification Complexity","SLD Modification Impacted Cells","SLD Drawing Comment","Schematics Modification","Due Date Schematics","Due Date CLO Schematics","Actual Date Schematics","Actual Hours Schematics","Standard Hours Schematics","Schematics Modification Complexity","Schematics Modification Impacted Cells","Schematics Drawing Comment","Index"
            };

            /////


            DetailOrderCols = new string[]
            {
            "ID","Designer","Team Leader","Department","Order Name","Project Number","TCR","Is PreBOM","Was Offer","Previous Offer Name","Previous Offer Number","Segment","Item Number","Total Cells","Complexity","Not Has NSR","Patch Name","Approval Date","Item Status","Family","WBS","Celling Hours","Receive Date","SLD Modification","Due Date SLD","Due Date CLO SLD","Actual Date SLD","Actual Hours SLD","Standard Hours SLD","SLD Modification Complexity","SLD Modification Impacted Cells","SLD Drawing Comment","Schematics Modification","Due Date Schematics","Due Date CLO Schematics","Actual Date Schematics","Actual Hours Schematics","Standard Hours Schematics","Schematics Modification Complexity","Schematics Modification Impacted Cells","Schematics Drawing Comment","ABOM Due Date","ABOM CLO Date","Actual Date ABOM","Actual Hours ABOM","Standard Hours ABOM","ABOM Comment","BBOM Due Date","BBOM CLO Date","Actual Date BBOM","Actual Hours BBOM","Standard Hours BBOM","BBOM Comment","NSR Due Date","NSR CLO Date","Actual Date NSR","Actual Hours NSR","Standard Hours NSR","NSR Comment","PF Due Date","PF CLO Date","Actual Date PF","Actual Hours PF","Standard Hours PF","PF Comment","Index"
            };


            CommonOffer = new string[] {"Designer","Team Leader","Department","Offer Name","Offer Number","TCO","Segment","Patch Name","Receive Date","SLD Modification","Due Date SLD","Due Date CLO SLD","SLD Modification Complexity","SLD Modification Impacted Cells","SLD Drawing Comment","Schematics Modification","Due Date Schematics","Due Date CLO Schematics","Schematics Modification Complexity","Schematics Modification Impacted Cells","Schematics Drawing Comment" };
            CommonOrder = new string[] {"Designer","Team Leader","Department","Order Name","Project Number","TCR","Is PreBOM","Was Offer","Previous Offer Name","Previous Offer Number","Segment","Patch Name","Approval Date","Item Status","Receive Date","SLD Modification","Due Date SLD","Due Date CLO SLD","SLD Modification Complexity","SLD Modification Impacted Cells","SLD Drawing Comment","Schematics Modification","Due Date Schematics","Due Date CLO Schematics","Schematics Modification Complexity","Schematics Modification Impacted Cells","Schematics Drawing Comment","ABOM Due Date","ABOM CLO Date","ABOM Comment","BBOM Due Date","BBOM CLO Date","BBOM Comment","NSR Due Date","NSR CLO Date","NSR Comment","PF Due Date","PF CLO Date","PF Comment" };


            ///////////////////
            foreach (string item in GeneralOfferCols)
            {
                GeneralOffer_table.Columns.Add(item);
            }

            foreach (string item in DetailOfferCols)
            {
                DetailOffer_table.Columns.Add(item);
            }

            foreach (string item in GeneralOrderCols)
            {
                GeneralOrder_table.Columns.Add(item);
            }

            foreach (string item in DetailOrderCols)
            {
                DetailOrder_table.Columns.Add(item);
            }

            /////////////////////////////
            int i ;
        PrevOfferSLDstr =new Prp[12];
            i = 1;
            PrevOfferSLDstr[i-1].id = 1;//"Designer"
            PrevOfferSLDstr[i-1].width = 100;
            PrevOfferSLDstr[i-1].read = true;
            PrevOfferSLDstr[i].id = 5;//"Offer Number"
            PrevOfferSLDstr[i].width = 100;
            PrevOfferSLDstr[i].read = true;
            PrevOfferSLDstr[i+1].id = 4;//"Offer Name"
            PrevOfferSLDstr[i+1].width = 150;
            PrevOfferSLDstr[i+1].read = true;
            PrevOfferSLDstr[i+2].id = 8;//"Item Number"
            PrevOfferSLDstr[i+2].width = 70;
            PrevOfferSLDstr[i+2].read = true;
            PrevOfferSLDstr[i+3].id = 10;//"Family"
            PrevOfferSLDstr[i+3].width = 70;
            PrevOfferSLDstr[i+3].read = true;
            PrevOfferSLDstr[i+4].id = 9;//"Total Cells"
            PrevOfferSLDstr[i+4].width = 70;
            PrevOfferSLDstr[i+4].read = true;
            PrevOfferSLDstr[i+5].id = 14;//"SLD Modification"
            PrevOfferSLDstr[i+5].width = 70;
            PrevOfferSLDstr[i+5].read = true;
            PrevOfferSLDstr[i+6].id = 15;//"Due Date SLD"
            PrevOfferSLDstr[i+6].width = 100;
            PrevOfferSLDstr[i+6].read = true;
            PrevOfferSLDstr[i+7].id = 19;//"Standard Hours SLD"
            PrevOfferSLDstr[i+7].width = 120;
            PrevOfferSLDstr[i+7].read = true;
            PrevOfferSLDstr[i+8].id = 18;//"Actual Hours SLD"
            PrevOfferSLDstr[i+8].width = 120;
            PrevOfferSLDstr[i+8].read = false;
            PrevOfferSLDstr[i+9].id = 17;//"Actual Date SLD"
            PrevOfferSLDstr[i+9].width = 120;
            PrevOfferSLDstr[i+9].read = false;
            PrevOfferSLDstr[i+10].id = 22;//"SLD Drawing Comment"
            PrevOfferSLDstr[i+10].width = 200;
            PrevOfferSLDstr[i+10].read = false;

            PrevOfferSchematicsstr = new Prp[12];
            //i = 1;
            PrevOfferSchematicsstr[i-1].id = 1;//"Designer"
            PrevOfferSchematicsstr[i-1].width = 100;
            PrevOfferSchematicsstr[i-1].read = true;
            PrevOfferSchematicsstr[i].id = 5;//"Offer Number"
            PrevOfferSchematicsstr[i].width = 100;
            PrevOfferSchematicsstr[i].read = true;
            PrevOfferSchematicsstr[i+1].id = 4;//"Offer Name"
            PrevOfferSchematicsstr[i+1].width = 150;
            PrevOfferSchematicsstr[i+1].read = true;
            PrevOfferSchematicsstr[i+2].id = 8;//"Item Number"
            PrevOfferSchematicsstr[i+2].width = 70;
            PrevOfferSchematicsstr[i+2].read = true;
            PrevOfferSchematicsstr[i+3].id = 10;//"Family"
            PrevOfferSchematicsstr[i+3].width = 70;
            PrevOfferSchematicsstr[i+3].read = true;
            PrevOfferSchematicsstr[i+4].id = 9;//"Total Cells"
            PrevOfferSchematicsstr[i+4].width = 70;
            PrevOfferSchematicsstr[i+4].read = true;
            PrevOfferSchematicsstr[i+5].id = 23;//"Schematics Modification"
            PrevOfferSchematicsstr[i+5].width = 70;
            PrevOfferSchematicsstr[i+5].read = true;
            PrevOfferSchematicsstr[i+6].id = 24;//"Due Date Schematics"
            PrevOfferSchematicsstr[i+6].width = 70;
            PrevOfferSchematicsstr[i+6].read = true;
            PrevOfferSchematicsstr[i+7].id = 28;//"Standard Hours Schematics"
            PrevOfferSchematicsstr[i+7].width = 70;
            PrevOfferSchematicsstr[i+7].read = true;
            PrevOfferSchematicsstr[i+8].id = 27;//"Actual Hours Schematics"
            PrevOfferSchematicsstr[i+8].width = 70;
            PrevOfferSchematicsstr[i+8].read = false;
            PrevOfferSchematicsstr[i+9].id = 26;//"Actual Date Schematics"
            PrevOfferSchematicsstr[i+9].width = 120;
            PrevOfferSchematicsstr[i+9].read = false;
            PrevOfferSchematicsstr[i+10].id = 31;//"Schematics Drawing Comment"
            PrevOfferSchematicsstr[i+10].width = 200;
            PrevOfferSchematicsstr[i+10].read = false;
            
            PrevOrderSLDstr =new Prp[12];
            //i = 1;
            PrevOrderSLDstr[i-1].id = 1;//"Designer"
            PrevOrderSLDstr[i-1].width = 100;
            PrevOrderSLDstr[i-1].read = true;
            PrevOrderSLDstr[i].id = 5;//"Project Number"
            PrevOrderSLDstr[i].width = 100;
            PrevOrderSLDstr[i].read = true;
            PrevOrderSLDstr[i+1].id = 4;
            PrevOrderSLDstr[i+1].width = 150;
            PrevOrderSLDstr[i+1].read = true;
            PrevOrderSLDstr[i+2].id = 12;
            PrevOrderSLDstr[i+2].width = 70;
            PrevOrderSLDstr[i+2].read = true;
            PrevOrderSLDstr[i+3].id = 19;
            PrevOrderSLDstr[i+3].width = 70;
            PrevOrderSLDstr[i+3].read = true;
            PrevOrderSLDstr[i+4].id = 13;
            PrevOrderSLDstr[i+4].width = 70;
            PrevOrderSLDstr[i+4].read = true;
            PrevOrderSLDstr[i+5].id = 23;
            PrevOrderSLDstr[i+5].width = 70;
            PrevOrderSLDstr[i+5].read = true;
            PrevOrderSLDstr[i+6].id = 24;
            PrevOrderSLDstr[i+6].width = 100;
            PrevOrderSLDstr[i+6].read = true;
            PrevOrderSLDstr[i+7].id = 28;
            PrevOrderSLDstr[i+7].width = 70;
            PrevOrderSLDstr[i+7].read = true;
            PrevOrderSLDstr[i+8].id = 27;
            PrevOrderSLDstr[i+8].width = 70;
            PrevOrderSLDstr[i+8].read = false;
            PrevOrderSLDstr[i+9].id = 26;
            PrevOrderSLDstr[i+9].width = 100;
            PrevOrderSLDstr[i+9].read = false;
            PrevOrderSLDstr[i+10].id = 31;
            PrevOrderSLDstr[i+10].width = 200;
            PrevOrderSLDstr[i+10].read = false;



            PrevOrderSchematicsstr =new Prp[12];
            // i = 1;
            PrevOrderSchematicsstr[i-1].id = 1;//"Designer"
            PrevOrderSchematicsstr[i-1].width = 100;
            PrevOrderSchematicsstr[i-1].read = true;
            PrevOrderSchematicsstr[i].id = 5;//"Project Number"
            PrevOrderSchematicsstr[i].width = 100;
            PrevOrderSchematicsstr[i].read = true;
            PrevOrderSchematicsstr[i+1].id = 4;
            PrevOrderSchematicsstr[i+1].width = 150;
            PrevOrderSchematicsstr[i+1].read = true;
            PrevOrderSchematicsstr[i+2].id = 12;
            PrevOrderSchematicsstr[i+2].width = 70;
            PrevOrderSchematicsstr[i+2].read = true;
            PrevOrderSchematicsstr[i+3].id = 19;
            PrevOrderSchematicsstr[i+3].width = 70;
            PrevOrderSchematicsstr[i+3].read = true;
            PrevOrderSchematicsstr[i+4].id = 13;
            PrevOrderSchematicsstr[i+4].width = 70;
            PrevOrderSchematicsstr[i+4].read = true;
            PrevOrderSchematicsstr[i+5].id = 32;
            PrevOrderSchematicsstr[i+5].width = 70;
            PrevOrderSchematicsstr[i+5].read = true;
            PrevOrderSchematicsstr[i+6].id = 33;
            PrevOrderSchematicsstr[i+6].width = 100;
            PrevOrderSchematicsstr[i+6].read = true;
            PrevOrderSchematicsstr[i+7].id = 37;
            PrevOrderSchematicsstr[i+7].width = 70;
            PrevOrderSchematicsstr[i+7].read = true;
            PrevOrderSchematicsstr[i+8].id = 36;
            PrevOrderSchematicsstr[i+8].width = 70;
            PrevOrderSchematicsstr[i+8].read = false;
            PrevOrderSchematicsstr[i+9].id = 35;
            PrevOrderSchematicsstr[i+9].width = 100;
            PrevOrderSchematicsstr[i+9].read = false;
            PrevOrderSchematicsstr[i+10].id = 40;
            PrevOrderSchematicsstr[i+10].width = 200;
            PrevOrderSchematicsstr[i+10].read = false;


            PrevOrderABOM = new Prp[12];
            // i = 1;
            PrevOrderABOM[0].id = 1;//"Designer"
            PrevOrderABOM[0].width = 100;
            PrevOrderABOM[0].read = true;
            PrevOrderABOM[i].id = 5;//"Project Number"
            PrevOrderABOM[i].width = 100;
            PrevOrderABOM[i].read = true;
            PrevOrderABOM[i+1].id = 4;
            PrevOrderABOM[i+1].width = 150;
            PrevOrderABOM[i+1].read = true;
            PrevOrderABOM[i+2].id = 12;
            PrevOrderABOM[i+2].width = 70;
            PrevOrderABOM[i+2].read = true;
            PrevOrderABOM[i+3].id = 19;
            PrevOrderABOM[i+3].width = 70;
            PrevOrderABOM[i+3].read = true;
            PrevOrderABOM[i+4].id = 13;
            PrevOrderABOM[i+4].width = 70;
            PrevOrderABOM[i+4].read = true;
            PrevOrderABOM[i + 5].id = 20;
            PrevOrderABOM[i + 5].width = 70;
            PrevOrderABOM[i + 5].read = true;
            PrevOrderABOM[i+6].id = 41;
            PrevOrderABOM[i+6].width = 100;
            PrevOrderABOM[i+6].read = true;
            PrevOrderABOM[i+7].id = 45;
            PrevOrderABOM[i+7].width = 70;
            PrevOrderABOM[i+7].read = true;
            PrevOrderABOM[i+8].id = 44;
            PrevOrderABOM[i+8].width = 70;
            PrevOrderABOM[i+8].read = false;
            PrevOrderABOM[i+9].id = 43;
            PrevOrderABOM[i+9].width = 100;
            PrevOrderABOM[i+9].read = false;
            PrevOrderABOM[i+10].id = 46;
            PrevOrderABOM[i+10].width = 200;
            PrevOrderABOM[i+10].read = false;


            PrevOrderBBOM =new Prp[11];
            // i = 1;
            PrevOrderBBOM[i-1].id = 1;//"Designer"
            PrevOrderBBOM[i-1].width = 100;
            PrevOrderBBOM[i-1].read = true;
            PrevOrderBBOM[i].id = 5;//"Project Number"
            PrevOrderBBOM[i].width = 100;
            PrevOrderBBOM[i].read = true;
            PrevOrderBBOM[i+1].id = 4;
            PrevOrderBBOM[i+1].width = 150;
            PrevOrderBBOM[i+1].read = true;
            PrevOrderBBOM[i+2].id = 12;
            PrevOrderBBOM[i+2].width = 70;
            PrevOrderBBOM[i+2].read = true;
            PrevOrderBBOM[i+3].id = 19;
            PrevOrderBBOM[i+3].width = 70;
            PrevOrderBBOM[i+3].read = true;
            PrevOrderBBOM[i+4].id = 13;
            PrevOrderBBOM[i+4].width = 70;
            PrevOrderBBOM[i+4].read = true;
            PrevOrderBBOM[i+5].id = 47;
            PrevOrderBBOM[i+5].width = 100;
            PrevOrderBBOM[i+5].read = true;
            PrevOrderBBOM[i+6].id = 51;
            PrevOrderBBOM[i+6].width = 70;
            PrevOrderBBOM[i+6].read = true;
            PrevOrderBBOM[i+7].id = 50;
            PrevOrderBBOM[i+7].width = 70;
            PrevOrderBBOM[i+7].read = false;
            PrevOrderBBOM[i+8].id = 49;
            PrevOrderBBOM[i+8].width = 100;
            PrevOrderBBOM[i+8].read = false;
            PrevOrderBBOM[i+9].id = 52;
            PrevOrderBBOM[i+9].width = 200;
            PrevOrderBBOM[i+9].read = false;
            
            PrevOrderNSR =new Prp[11];
            // i = 1;
            PrevOrderNSR[i-1].id = 1;//"Designer"
            PrevOrderNSR[i-1].width = 100;
            PrevOrderNSR[i-1].read = true;
            PrevOrderNSR[i].id = 5;//"Project Number"
            PrevOrderNSR[i].width = 100;
            PrevOrderNSR[i].read = true;
            PrevOrderNSR[i+1].id = 4;
            PrevOrderNSR[i+1].width = 150;
            PrevOrderNSR[i+1].read = true;
            PrevOrderNSR[i+2].id = 12;
            PrevOrderNSR[i+2].width = 70;
            PrevOrderNSR[i+2].read = true;
            PrevOrderNSR[i+3].id = 19;
            PrevOrderNSR[i+3].width = 70;
            PrevOrderNSR[i+3].read = true;
            PrevOrderNSR[i+4].id = 13;
            PrevOrderNSR[i+4].width = 70;
            PrevOrderNSR[i+4].read = true;
            PrevOrderNSR[i+5].id = 53;
            PrevOrderNSR[i+5].width = 100;
            PrevOrderNSR[i+5].read = true;
            PrevOrderNSR[i+6].id = 57;
            PrevOrderNSR[i+6].width = 70;
            PrevOrderNSR[i+6].read = true;
            PrevOrderNSR[i+7].id = 56;
            PrevOrderNSR[i+7].width = 70;
            PrevOrderNSR[i+7].read = false;
            PrevOrderNSR[i+8].id = 55;
            PrevOrderNSR[i+8].width = 100;
            PrevOrderNSR[i+8].read = false;
            PrevOrderNSR[i+9].id = 58;
            PrevOrderNSR[i+9].width = 200;
            PrevOrderNSR[i+9].read = false;

            PrevOrderPF = new Prp[11];
            // i = 1;
            PrevOrderPF[i - 1].id = 1;//"Designer"
            PrevOrderPF[i - 1].width = 100;
            PrevOrderPF[i - 1].read = true;
            PrevOrderPF[i].id = 5;//"Project Number"
            PrevOrderPF[i].width = 100;
            PrevOrderPF[i].read = true;
            PrevOrderPF[i+1].id = 4;
            PrevOrderPF[i+1].width = 150;
            PrevOrderPF[i+1].read = true;
            PrevOrderPF[i+2].id = 12;
            PrevOrderPF[i+2].width = 70;
            PrevOrderPF[i+2].read = true;
            PrevOrderPF[i+3].id = 19;
            PrevOrderPF[i+3].width = 70;
            PrevOrderPF[i+3].read = true;
            PrevOrderPF[i+4].id = 13;
            PrevOrderPF[i+4].width = 70;
            PrevOrderPF[i+4].read = true;
            PrevOrderPF[i+5].id = 59;
            PrevOrderPF[i+5].width = 100;
            PrevOrderPF[i+5].read = true;
            PrevOrderPF[i+6].id = 63;
            PrevOrderPF[i+6].width = 70;
            PrevOrderPF[i+6].read = true;
            PrevOrderPF[i+7].id = 62;
            PrevOrderPF[i+7].width = 70;
            PrevOrderPF[i+7].read = false;
            PrevOrderPF[i+8].id = 61;
            PrevOrderPF[i+8].width = 100;
            PrevOrderPF[i+8].read = false;
            PrevOrderPF[i+9].id = 64;
            PrevOrderPF[i+9].width = 200;
            PrevOrderPF[i+9].read = false;

            ModOffer = new Prp[6];
            //i = 1;
            ModOffer[i - 1].id = 1;//"Designer"
            ModOffer[i - 1].width = 100;
            ModOffer[i - 1].read = true;
            ModOffer[i].id = 5;//"Offer Number"
            ModOffer[i].width = 100;
            ModOffer[i].read = true;
            ModOffer[i + 1].id = 4;//"Offer Name"
            ModOffer[i + 1].width = 150;
            ModOffer[i + 1].read = true;
            ModOffer[i + 2].id = 8;//"Item Number"
            ModOffer[i + 2].width = 70;
            ModOffer[i + 2].read = true;
            ModOffer[i + 3].id = 10;//"Family"
            ModOffer[i + 3].width = 70;
            ModOffer[i + 3].read = true;
            ModOffer[i + 4].id = 9;//"Total Cells"
            ModOffer[i + 4].width = 70;
            ModOffer[i + 4].read = true;

            MODOrder = new Prp[6];
            // i = 1;
            MODOrder[i - 1].id = 1;//"Designer"
            MODOrder[i - 1].width = 100;
            MODOrder[i - 1].read = true;
            MODOrder[i].id = 5;//"Project Number"
            MODOrder[i].width = 100;
            MODOrder[i].read = true;
            MODOrder[i + 1].id = 4;
            MODOrder[i + 1].width = 150;
            MODOrder[i + 1].read = true;
            MODOrder[i + 2].id = 12;
            MODOrder[i + 2].width = 70;
            MODOrder[i + 2].read = true;
            MODOrder[i + 3].id = 19;
            MODOrder[i + 3].width = 70;
            MODOrder[i + 3].read = true;
            MODOrder[i + 4].id = 13;
            MODOrder[i + 4].width = 70;
            MODOrder[i + 4].read = true;

            TargetPrevOfferSLD = "Actual Date SLD";
            TargetPrevOfferSchematics = "Actual Date Schematics";
            TargetPrevOrderSLD = "Actual Date SLD";
            TargetPrevOrderSchematics = "Actual Date Schematics";
            TargetPrevOrderABOM = "Actual Date ABOM";
            TargetPrevOrderBBOM = "Actual Date BBOM";
            TargetPrevOrderNSR = "Actual Date NSR";
            TargetPrevOrderPF = "Actual Date PF";
                


        }
        /// <summary>
        /// return a list of required data
        /// </summary>
        /// <param name="department">"LV" or "MV"</param>
        /// <param name="req">"Family" or "Complexity" or "ReqBy"</param>
        /// <returns></returns>
        public static List<string> DepartmentTodata(string department,string req)
        {
            List<string> data = new List<string>();
            data.Add("");
            if (req == "Family")
            {
                if (department=="LV")
                {
                    data.Add("BK7");
                    data.Add("OKKEN");
                    data.Add("SPARE");
                }
                else if(department == "MV")
                {
                    
                    data.Add("SM6");
                    data.Add("RM6");
                    data.Add("MCSET123");
                    data.Add("MCSET4");
                    data.Add("PIXROF");
                    data.Add("RONEX");
                    data.Add("VARBLOK");
                    data.Add("RETROFET");
                    data.Add("SPARE");
                }
                else if (department == "ALL")
                {
                    data.Add("BK7");
                    data.Add("OKKEN");
                    data.Add("SM6");
                    data.Add("RM6");
                    data.Add("MCSET123");
                    data.Add("MCSET4");
                    data.Add("PIXROF");
                    data.Add("RONEX");
                    data.Add("VARBLOK");
                    data.Add("RETROFET");
                    data.Add("SPARE");
                }
            }
           
           
            else
            {
                return null;
            }

            return data;
        }
        /// <summary>
        /// adjust textbox change with datetimepicker
        /// </summary>
        /// <param name="box"></param>
        /// <param name="timepicker"></param>
        public static void TextBoxChange(ref TextBox box, ref DateTimePicker timepicker)
        {
            DateTime temp;
            if (DateTime.TryParse(box.Text,  out temp))
            {
                if (temp < timepicker.MaxDate && temp > timepicker.MinDate && timepicker.Value != temp)
                {
                    timepicker.Value = temp;
                }

            }
            else if (box.Text != "")
            {
                box.Text = timepicker.Value.ToShortDateString();
            }


        }
        public static void DataTimeChange(ref TextBox box, ref DateTimePicker timepicker)
        {
            if (box.Text != timepicker.Text)
            {
                box.Text = timepicker.Value.ToShortDateString();
            }
        }
        public static IEnumerable<int> PrintPages_to_list(string input)
        {
            try
            {
                return input.Split(',').SelectMany(x => x.Contains('-') ? Enumerable.Range(int.Parse(x.Split('-')[0]), int.Parse(x.Split('-')[1]) - int.Parse(x.Split('-')[0]) + 1) : new int[] { int.Parse(x) });
            }
            catch (Exception)
            {

                return null;
            }
            
        }
        /// <summary>
        /// parse testbox to database time
        /// </summary>
        /// <param name="textbx"></param>
        /// <returns></returns>
       public static object Date_validate(string textbx)
        {
            
            
            DateTime parsedDate;
            if (textbx == "")
            {
                return DBNull.Value;
            }
            else
            {
                DateTime.TryParse(textbx,  out parsedDate);
                return parsedDate.Date;
            }
        }
        /// <summary>
        /// parse time database to textbox
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
       public static string Date_show(object d)
        {
            DateTime a;
            if (d.ToString() == "")
            {
                return "";
            }
            else
            {
                DateTime.TryParse(d.ToString(), out a);
                return a.ToShortDateString() ; 
            }
        }
        /// <summary>
        /// convert general offer to detailed data
        /// </summary>
        /// <param name="GeneralTable"></param>
        /// <returns></returns>
        public static DataTable GeneralOffersToDetail(DataTable GeneralTable)
        {
            int count = 0;
            DataTable DetailTable = new DataTable();
            DetailTable = FollowUpCore.DetailOffer_table.Clone();
            DataRow row ;
            IEnumerable<int> items = null;
            //loop over all items on but first check that it's not empty
            if (!string.IsNullOrEmpty(GeneralTable.Rows[0]["Items Numbers"].ToString()))
            {
                items = FollowUpCore.PrintPages_to_list(GeneralTable.Rows[0]["Items Numbers"].ToString());
                count = items.Count<int>();


            }
            if (count == 0)
            {
                return null;
            }

            for (int i = 0; i < int.Parse(GeneralTable.Rows[0]["Total Items"].ToString()); i++)

            {
                row = DetailTable.NewRow();
                if (count > i)
                {
                    foreach (string item in CommonOffer)
                    {
                        row[item] = GeneralTable.Rows[0][item];
                    }
                    row["Item Number"] = items.ElementAt<int>(i);
                    ////create only one entry from detailed table
                    //row["Designer"] = GeneralTable.Rows[0]["Designer"];
                    //row["Team Leader"] = GeneralTable.Rows[0]["Team Leader"];
                    //row["Department"] = GeneralTable.Rows[0]["Department"];
                    //row["Offer Name"] = GeneralTable.Rows[0]["Offer Name"];
                    //row["Offer Number"] = GeneralTable.Rows[0]["Offer Number"];
                    //row["TCO"] = GeneralTable.Rows[0]["TCO"];
                    //row["Segment"] = GeneralTable.Rows[0]["Segment"];
                    //row["Item Number"] = items.ElementAt<int>(i);
                    //row["Total Cells"] = "";
                    //row["Family"] = "";
                    //row["Complexity"] = GeneralTable.Rows[0]["Common Complexity"];
                    //row["Patch Name"] = GeneralTable.Rows[0]["Patch Name"];
                    //row["Receive Date"] = GeneralTable.Rows[0]["Receive Date"];
                    //row["SLD Modification"] = GeneralTable.Rows[0]["SLD Modification"];                    
                    //row["Due Date SLD"] = GeneralTable.Rows[0]["Due Date SLD"];
                    //row["Due Date CLO SLD"] = GeneralTable.Rows[0]["Due Date CLO SLD"];
                    //row["SLD Modification Complexity"] = GeneralTable.Rows[0]["SLD Modification Complexity"];
                    //row["SLD Modification Impacted Cells"] = GeneralTable.Rows[0]["SLD Modification Impacted Cells"];
                    //row["SLD Drawing Comment"] = GeneralTable.Rows[0]["SLD Drawing Comment"];
                    //row["Schematics Modification"] = GeneralTable.Rows[0]["Schematics Modification"];
                    //row["Due Date Schematics"] = GeneralTable.Rows[0]["Due Date Schematics"];
                    //row["Due Date CLO Schematics"] = GeneralTable.Rows[0]["Due Date CLO Schematics"];
                    //row["Schematics Modification Complexity"] = GeneralTable.Rows[0]["Schematics Modification Complexity"];
                    //row["Schematics Modification Impacted Cells"] = GeneralTable.Rows[0]["Schematics Modification Impacted Cells"];
                    //row["Schematics Drawing Comment"] = GeneralTable.Rows[0]["Schematics Drawing Comment"];

                }
                else
                {
                    foreach (string item in CommonOffer)
                    {
                        row[item] = GeneralTable.Rows[0][item];
                    }
                    ////create only one entry from detailed table
                    //row["Designer"] = GeneralTable.Rows[0]["Designer"];
                    //row["Team Leader"] = GeneralTable.Rows[0]["Team Leader"];
                    //row["Department"] = GeneralTable.Rows[0]["Department"];
                    //row["Offer Name"] = GeneralTable.Rows[0]["Offer Name"];
                    //row["Offer Number"] = GeneralTable.Rows[0]["Offer Number"];
                    //row["TCO"] = GeneralTable.Rows[0]["TCO"];
                    //row["Segment"] = GeneralTable.Rows[0]["Segment"];
                    //row["Item Number"] = "";
                    //row["Total Cells"] = "";
                    //row["Family"] = "";
                    //row["Complexity"] = GeneralTable.Rows[0]["Common Complexity"];
                    //row["Patch Name"] = GeneralTable.Rows[0]["Patch Name"];
                    //row["Receive Date"] = GeneralTable.Rows[0]["Receive Date"];
                    //row["SLD Modification"] = GeneralTable.Rows[0]["SLD Modification"];
                    //row["Due Date SLD"] = GeneralTable.Rows[0]["Due Date SLD"];
                    //row["Due Date CLO SLD"] = GeneralTable.Rows[0]["Due Date CLO SLD"];
                    //row["SLD Modification Complexity"] = GeneralTable.Rows[0]["SLD Modification Complexity"];
                    //row["SLD Modification Impacted Cells"] = GeneralTable.Rows[0]["SLD Modification Impacted Cells"];
                    //row["SLD Drawing Comment"] = GeneralTable.Rows[0]["SLD Drawing Comment"];
                    //row["Schematics Modification"] = GeneralTable.Rows[0]["Schematics Modification"];
                    //row["Due Date Schematics"] = GeneralTable.Rows[0]["Due Date Schematics"];
                    //row["Due Date CLO Schematics"] = GeneralTable.Rows[0]["Due Date CLO Schematics"];
                    //row["Schematics Modification Complexity"] = GeneralTable.Rows[0]["Schematics Modification Complexity"];
                    //row["Schematics Modification Impacted Cells"] = GeneralTable.Rows[0]["Schematics Modification Impacted Cells"];
                    //row["Schematics Drawing Comment"] = GeneralTable.Rows[0]["Schematics Drawing Comment"];

                }
                DetailTable.Rows.Add(row);
                //row.Delete();

            }
           // MessageBox.Show(DetailTable.Rows.Count.ToString());

            return DetailTable;
        }

        public static DataTable GeneralOrderToDetail(DataTable GeneralTable)
        {
            int count = 0;
            DataTable DetailTable = new DataTable();
            DetailTable = FollowUpCore.DetailOrder_table.Clone();
            DataRow row;
            IEnumerable<int> items = null;
            //loop over all items on but first check that it's not empty
            if (!string.IsNullOrEmpty(GeneralTable.Rows[0]["Items Numbers"].ToString()))
            {
                items = FollowUpCore.PrintPages_to_list(GeneralTable.Rows[0]["Items Numbers"].ToString());
                count = items.Count<int>();


            }

            for (int i = 0; i < int.Parse(GeneralTable.Rows[0]["Total Items"].ToString()); i++)

            {
                row = DetailTable.NewRow();
                if (count > i)
                {

                    foreach (string item in CommonOrder)
                    {
                        row[item] = GeneralTable.Rows[0][item];
                    }
                    row["Item Number"] = items.ElementAt<int>(i);
                }
                else
                {

                    foreach (string item in CommonOrder)
                    {
                        row[item] = GeneralTable.Rows[0][item];
                    }
                }
                DetailTable.Rows.Add(row);
                //row.Delete();

            }
            // MessageBox.Show(DetailTable.Rows.Count.ToString());

            return DetailTable;
        }

        public static void adjustDGV(ref DataGridView DGV,Prp[] specs,string[] list)
        {
            foreach (string item in list)
            {
                DGV.Columns[item].Visible = false;
            }
            int i = 0;
            foreach (Prp a in specs)
            {
                DGV.Columns[list[a.id]].DisplayIndex = i;
                i++;
                DGV.Columns[list[a.id]].Visible = true;
                DGV.Columns[list[a.id]].Width = a.width;
                DGV.Columns[list[a.id]].ReadOnly = a.read;
            }
            int j = 0;
            foreach (Prp item in specs)
            {
                j = j + item.width;


            }
            DGV.Width = j + 35;

        }
        /// <summary>
        /// update sourse table with data in update all based on "ID" colomn value
        /// function will first check if update row["ID"] =blank ? add it to Source: search for it in sourse(delete found entry and add entry from update)
        /// </summary>
        /// <param name="source">table required to be updated</param>
        /// <param name="update">modification happened on update</param>
       
        public static void updateTablebytable(ref DataTable source,DataTable update, List<string> delete)
        {
            List<DataRow> deleterows = new List<DataRow>();
            DataTable tempsource = source.Copy();
            int sourceindex = 0;
            int updateindex = 0;
            foreach (DataRow URow in update.Rows)
            {
                if (URow["ID"].ToString() == "")//new row copy it to row of source type and add it to main table
                {
                    DataRow row = source.NewRow();
                    foreach (DataColumn col in source.Columns)
                    {
                        row[col.ColumnName] = update.Rows[updateindex][col.ColumnName];
                    }
                    source.Rows.Add(row);
                }
                updateindex++;
            }

            foreach (DataRow SRow in tempsource.Rows)
            {
                updateindex = 0;
                foreach (DataRow URow in update.Rows)
                {
                   
                  if (SRow["ID"].ToString() == URow["ID"].ToString())
                    {
                        CopyRowToRow(ref source, update, sourceindex, updateindex);
                    }
                    updateindex++;
                }
              
                sourceindex++;
            }

            if (delete!=null)
            {


                foreach (DataRow SRow in source.Rows)
                {

                    foreach (string id in delete)
                    {

                        if (SRow["ID"].ToString() == id)
                        {
                            //CopyRowToRow(ref source, update, sourceindex, updateindex);
                            deleterows.Add(SRow);
                        }

                    }
                }
                foreach (DataRow item in deleterows)
                {
                    source.Rows.Remove(item);
                }
            }
           
        }
       static void  CopyRowToRow(ref DataTable sourceT,DataTable updateT,int sourceindex,int updateindex)
        {
            foreach (DataColumn col in sourceT.Columns)
            {
                sourceT.Rows[sourceindex][col.ColumnName] = updateT.Rows[updateindex][col.ColumnName];
            }
        }


        /// <summary>
        /// check if specis value exist in colomn in Datatable
        /// </summary>
        /// <param name="table"></param>
        /// <param name="colomn"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool checkExistInTable(DataTable table, string colomn, string value)
        {
            foreach (DataRow item in table.Rows)
            {
                if (item[colomn].ToString() == value)
                {
                    return true;
                }
            }
            return false;
        }
        public static string Shorten(object source)
        {

            if (DateTime.TryParse(source.ToString(), out DateTime time))
            {
                //source.Columns[col.ColumnName]. = Type.;
                return time.ToShortDateString();
            }
            else
            {
                return source.ToString();
            }

        }
        public static DataTable RemoveColomn(DataTable source, Prp[] selection, string[] colname)
        {
            DataTable data = source.Copy();
            bool remove = true;
            for (int i = 0; i < source.Columns.Count; i++)
            {
                foreach (Prp item in selection)
                {
                    if (i == item.id)
                    {
                        remove = false;
                    }
                }
                if (remove)
                {
                    data.Columns.Remove(colname[i]);
                }
                else
                {
                    remove = true;
                }
            }
            return data;
        }
        public static void ExportDSToExcel(DataSet ds, string destination)
        {
            using (var workbook = SpreadsheetDocument.Create(destination, DocumentFormat.OpenXml.SpreadsheetDocumentType.Workbook))
            {
                var workbookPart = workbook.AddWorkbookPart();
                workbook.WorkbookPart.Workbook = new DocumentFormat.OpenXml.Spreadsheet.Workbook();
                workbook.WorkbookPart.Workbook.Sheets = new DocumentFormat.OpenXml.Spreadsheet.Sheets();

                uint sheetId = 1;

                ////
                Stylesheet styleSheet = new Stylesheet();

                CellFormat cf = new CellFormat();
                cf.NumberFormatId = 14;
                cf.ApplyNumberFormat = true;

                CellFormats cfs = new CellFormats();
                cfs.Append(cf);
                styleSheet.CellFormats = cfs;

                styleSheet.Borders = new Borders();
                styleSheet.Borders.Append(new Border());
                styleSheet.Fills = new Fills();
                styleSheet.Fills.Append(new Fill());
                styleSheet.Fonts = new Fonts();
                styleSheet.Fonts.Append(new Font());

                workbookPart.AddNewPart<WorkbookStylesPart>();
                workbookPart.WorkbookStylesPart.Stylesheet = styleSheet;

                CellStyles css = new CellStyles();
                CellStyle cs = new CellStyle();
                cs.FormatId = 0;
                cs.BuiltinId = 0;
                css.Append(cs);
                css.Count = UInt32Value.FromUInt32((uint)css.ChildElements.Count);
                styleSheet.Append(css);

                ////


                foreach (DataTable table in ds.Tables)
                {
                    var sheetPart = workbook.WorkbookPart.AddNewPart<WorksheetPart>();
                    var sheetData = new DocumentFormat.OpenXml.Spreadsheet.SheetData();
                    //  var stylesPart = workbook.WorkbookPart.AddNewPart<WorkbookStylesPart>();

                    sheetPart.Worksheet = new DocumentFormat.OpenXml.Spreadsheet.Worksheet(sheetData);
                    DocumentFormat.OpenXml.Spreadsheet.Sheets sheets = workbook.WorkbookPart.Workbook.GetFirstChild<DocumentFormat.OpenXml.Spreadsheet.Sheets>();
                    string relationshipId = workbook.WorkbookPart.GetIdOfPart(sheetPart);

                    if (sheets.Elements<DocumentFormat.OpenXml.Spreadsheet.Sheet>().Count() > 0)
                    {
                        sheetId =
                            sheets.Elements<DocumentFormat.OpenXml.Spreadsheet.Sheet>().Select(s => s.SheetId.Value).Max() + 1;
                    }
                    //create sheet here
                    DocumentFormat.OpenXml.Spreadsheet.Sheet sheet = new DocumentFormat.OpenXml.Spreadsheet.Sheet() { Id = relationshipId, SheetId = sheetId, Name = table.TableName };
                    sheets.Append(sheet);

                    DocumentFormat.OpenXml.Spreadsheet.Row headerRow = new DocumentFormat.OpenXml.Spreadsheet.Row();
                    //CreateAccessibilityInstance headers
                    List<String> columns = new List<string>();
                    foreach (DataColumn column in table.Columns)
                    {
                        columns.Add(column.ColumnName);

                        DocumentFormat.OpenXml.Spreadsheet.Cell cell = new DocumentFormat.OpenXml.Spreadsheet.Cell();

                        cell.DataType = new EnumValue<CellValues>(CellValues.String);
                        cell.CellValue = new DocumentFormat.OpenXml.Spreadsheet.CellValue(column.ColumnName);

                        headerRow.AppendChild(cell);
                    }

                    sheetData.AppendChild(headerRow);

                    foreach (DataRow dsrow in table.Rows)
                    {
                        DocumentFormat.OpenXml.Spreadsheet.Row newRow = new DocumentFormat.OpenXml.Spreadsheet.Row();
                        foreach (String col in columns)
                        {
                            DocumentFormat.OpenXml.Spreadsheet.Cell cell = new DocumentFormat.OpenXml.Spreadsheet.Cell();

                            //cell.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.


                            CellData(ref cell, dsrow[col].ToString());



                            newRow.AppendChild(cell);
                        }

                        sheetData.AppendChild(newRow);
                    }
                }
            }
        }
        static public void CellData(ref Cell c, string value)
        {
            if (DateTime.TryParse(value, out DateTime time))
            {
                c.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.Number;
                c.CellValue = new CellValue(time.ToOADate().ToString());

                c.StyleIndex = 0;
            }
            else if (int.TryParse(value, out int x))
            {
                c.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.String;
                c.CellValue = new DocumentFormat.OpenXml.Spreadsheet.CellValue(x.ToString());
                c.StyleIndex = 0;
            }
            else
            {
                c.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.String;
                c.CellValue = new DocumentFormat.OpenXml.Spreadsheet.CellValue(value);
                c.StyleIndex = 0;
            }
        }
        static public CellValue DValue(string value)
        {
            if (DateTime.TryParse(value, out DateTime time))
            {
                return new CellValue(time.ToOADate().ToString());
            }
            else if (int.TryParse(value, out int x))
            {
                return new DocumentFormat.OpenXml.Spreadsheet.CellValue(x.ToString());
            }
            else
            {
                return new DocumentFormat.OpenXml.Spreadsheet.CellValue(value);
            }
        }
        public static void ExportDSToExcel1(DataSet ds, string destination)
        {
            using (var workbook = SpreadsheetDocument.Create(destination, DocumentFormat.OpenXml.SpreadsheetDocumentType.Workbook))
            {
                var workbookPart = workbook.AddWorkbookPart();
                workbook.WorkbookPart.Workbook = new DocumentFormat.OpenXml.Spreadsheet.Workbook();
                workbook.WorkbookPart.Workbook.Sheets = new DocumentFormat.OpenXml.Spreadsheet.Sheets();

                uint sheetId = 1;

                foreach (DataTable table in ds.Tables)
                {
                    var sheetPart = workbook.WorkbookPart.AddNewPart<WorksheetPart>();
                    var sheetData = new DocumentFormat.OpenXml.Spreadsheet.SheetData();


                    sheetPart.Worksheet = new DocumentFormat.OpenXml.Spreadsheet.Worksheet(sheetData);

                    DocumentFormat.OpenXml.Spreadsheet.Sheets sheets = workbook.WorkbookPart.Workbook.GetFirstChild<DocumentFormat.OpenXml.Spreadsheet.Sheets>();
                    string relationshipId = workbook.WorkbookPart.GetIdOfPart(sheetPart);

                    if (sheets.Elements<DocumentFormat.OpenXml.Spreadsheet.Sheet>().Count() > 0)
                    {
                        sheetId =
                            sheets.Elements<DocumentFormat.OpenXml.Spreadsheet.Sheet>().Select(s => s.SheetId.Value).Max() + 1;
                    }
                    //create sheet here
                    DocumentFormat.OpenXml.Spreadsheet.Sheet sheet = new DocumentFormat.OpenXml.Spreadsheet.Sheet() { Id = relationshipId, SheetId = sheetId, Name = table.TableName };
                    sheets.Append(sheet);

                    DocumentFormat.OpenXml.Spreadsheet.Row headerRow = new DocumentFormat.OpenXml.Spreadsheet.Row();
                    //CreateAccessibilityInstance headers
                    List<String> columns = new List<string>();
                    foreach (DataColumn column in table.Columns)
                    {
                        columns.Add(column.ColumnName);

                        DocumentFormat.OpenXml.Spreadsheet.Cell cell = new DocumentFormat.OpenXml.Spreadsheet.Cell();
                        cell.DataType = new EnumValue<CellValues>(CellValues.String);
                        cell.CellValue = new DocumentFormat.OpenXml.Spreadsheet.CellValue(column.ColumnName);

                        headerRow.AppendChild(cell);
                    }

                    sheetData.AppendChild(headerRow);

                    foreach (DataRow dsrow in table.Rows)
                    {
                        DocumentFormat.OpenXml.Spreadsheet.Row newRow = new DocumentFormat.OpenXml.Spreadsheet.Row();
                        foreach (String col in columns)
                        {
                            DocumentFormat.OpenXml.Spreadsheet.Cell cell = new DocumentFormat.OpenXml.Spreadsheet.Cell();

                            //cell.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.


                            cell.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.String;
                            cell.CellValue = new DocumentFormat.OpenXml.Spreadsheet.CellValue(FollowUpCore.Shorten(dsrow[col])); //



                            newRow.AppendChild(cell);
                        }

                        sheetData.AppendChild(newRow);
                    }
                }
            }
        }

        public static string FilterCommand(string Due, string Actual, string Name="", string DateFrom = "", string DateTo = "", List<string> designers = null, string TaskStatus = "")
        {
            string command = "";

            if (!string.IsNullOrEmpty(DateFrom))
            {
                if (command != "")
                {
                    command = command + " AND ";
                }
                command = command + string.Format("([{0}] >= #{1}#)", Due, DateFrom);// "([Due Date SLD] >= #" + DateFrom + "#)";
            }
            if (!string.IsNullOrEmpty(DateTo))
            {
                if (command != "")
                {
                    command = command + " AND ";
                }
                command = command + string.Format("([{0}] <= #{1}#)", Due, DateTo);
            }
            if (designers != null)
            {
                if (command != "")
                {
                    command = command + " AND ";
                }
                command = command + "(";
                foreach (string item in designers)
                {
                    command = command + string.Format("([designer]  = '{0}')", item);
                    if (designers.Count > 1 && item != designers[designers.Count - 1])
                    {
                        command = command + " OR ";
                    }
                }
            }
            command = command + ")";
            if (!string.IsNullOrEmpty(TaskStatus))
            {
                if (command != "")
                {
                    command = command + " AND ";
                }
                if (TaskStatus == "All")
                {
                    // command = command + string.Format();
                }
                else if (TaskStatus == "Completed")
                {
                    command = command + string.Format("[{0}] IS NOT NULL", Actual);
                }
                else if (TaskStatus == "Not Completed")
                {
                    command = command + string.Format("[{0}] IS NULL", Actual);
                }
                else if (TaskStatus == "Over Due Date")
                {
                    command = command + string.Format("([{1}] IS NULL AND [{0}] <= #{2}#) OR ([{0}] < [{1}])", Due, Actual, DateTime.Now.Date.ToShortDateString());
                }
            }



            return command;
        }
        public static void GetTeamDesigners(string EmpName,string Table,ref List<string> ListDesigners,ref Dictionary<string,string> DicDesigners)
        {
           
            try
            {
                ListDesigners.Clear();
                ListDesigners = AccessDB.GetData(new Dictionary<string, string> { { EmpName, "x" } }, "Relations", "Employee", false);
                DicDesigners.Clear();
                foreach (string item in ListDesigners)
                {
                    DicDesigners.Add( item, "Designer");
                }

            }
            catch (Exception)
            {
                ListDesigners = null;
                DicDesigners = null;


            }
           
        }
        public static DateTime AddWorkingDayes(DateTime start,int days,List<DateTime> vacations=null)
        {
            DateTime result = start;
            int count = 0;
            int change = 1;
            if (days<0)
            {
                change = -1;
            }
            while (count != days)
            {
                if (result.DayOfWeek == DayOfWeek.Saturday || result.DayOfWeek == DayOfWeek.Sunday || vacations.Contains(result))
                {

                }
                else
                {
                    count = count+ change;
                }
                result = result.AddDays(1);
            }
            return result;
        }

      public static  List<DateTime> vacations()
        {
            List<DateTime> vac = new List<DateTime>();
            DataTable table = AccessDB.Read_DataSet(null, "Vacations", "Days");
            foreach (DataRow row in table.Rows)
            {
                vac.Add(DateTime.Parse(row["Days"].ToString()));
            }

            return vac;
        }


        public static void ClearGroupBox(GroupBox control)
        {
            foreach (ListBox listBox in control.Controls.OfType<ListBox>())
            {
                listBox.Items.Clear();
                // do more ListBox cleanup
            }
            foreach (CheckedListBox listBox in control.Controls.OfType<CheckedListBox>())
            {
                listBox.Items.Clear();
                // do more CheckedListBox cleanup
            }
            foreach (ListView listView in control.Controls.OfType<ListView>())
            {
                listView.Items.Clear();
                // do more ListView cleanup
            }
            foreach (CheckBox checkBox in control.Controls.OfType<CheckBox>())
            {
                checkBox.Checked = false;
                // do more CheckBox cleanup
            }
            foreach (TextBox textbox in control.Controls.OfType<TextBox>())
            {
                textbox.Text = "";
            }
            foreach (ComboBox combo in control.Controls.OfType<ComboBox>())
            {
                combo.SelectedIndex = 0;
            }
        }
    }

}

 
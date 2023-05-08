using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FollowUp
{
    public partial class Excel_Create : Form
    {
        public Excel_Create()
        {
            InitializeComponent();
        }

        private void Select_file_Order_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            //openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = " Excel File (.xlsx)|*.xlsx";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    tb_url_Order.Text = openFileDialog1.FileName;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        private void Select_file_offer_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            //openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = " Excel File (.xlsx)|*.xlsx";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    tb_url_Offer.Text = openFileDialog1.FileName;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)//order extract link
        {
            //update all data in to below this excel

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "Excel File (.xlsx)|*.xlsx";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;
            string sourceFile = Path.Combine( AppDomain.CurrentDomain.BaseDirectory, "OrderDetail.xlsx") ;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                System.IO.File.Copy(sourceFile, saveFileDialog1.FileName, true);
            }
        }

        private void LinkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)//offer extract link
        {
            DataSet datas = new DataSet();
            datas.Tables.Add(FollowUpCore.LoadOffer);
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "Excel File (.xlsx)|*.xlsx";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;
            string sourceFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "OfferDetail.xlsx");
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // System.IO.File.Copy(sourceFile, saveFileDialog1.FileName, true);
                FollowUpCore.ExportDSToExcel1(datas, saveFileDialog1.FileName);
            }
        }

        private void Upload_Order_Click(object sender, EventArgs e)
        {
            DataTable table = new DataTable();
            table = AccessDB.ReadSchemaTo_Datatable("OrderDetail");
            //validation for openned file to follow required form

            //get all excel data and add it to datatable
            if (tb_url_Order.Text == "")
            {
                MessageBox.Show("You must select excel file");
            }
            if ( File.Exists( tb_url_Order.Text))
            {//upload datatable to database
                DataTable UploadOrder= ToExcel.GetExcelAsDataTable(tb_url_Order.Text, ref table);
                AccessDB.Insert_table(UploadOrder, "OrderDetail");
            }
            else
            {
                MessageBox.Show("You must select excel file");
            }
            
            
        }
    }
}

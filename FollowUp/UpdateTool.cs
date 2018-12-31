using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FollowUp
{
    class UpdateTool
    {

        //need to check CSV file existance
        //if exist load its content to table
        public static bool Update()
        {
            DataTable table;
            string ExcelURL = Properties.Settings.Default.UpdateLink + "\\Update.csv";
            if (checkFile(ExcelURL))//check excel exit then read data
            {
                table = ToExcel.GetDataTabletFromCSVFile(ExcelURL);
                //check last index
                if (table.Rows[table.Rows.Count - 1]["Version"].ToString() != Properties.Settings.Default.UpdateVersion)
                {
                    System.Windows.Forms.MessageBox.Show("New Version exist Contains: " + table.Rows[table.Rows.Count - 1]["Comment"].ToString());
                    return install();
                }
                else
                {
                    return false;
                }
                //if 

            }
            return false;
        }
        static bool checkFile(string file)
        {
            return File.Exists(file) ? true : false;
        }
        static bool install()
        {
            //remove any previous intallation
            try
            {
                File.Delete(Properties.Settings.Default.UpdateFile);
            }
            catch (Exception)
            {


            }
            try
            {
                File.Copy(Properties.Settings.Default.UpdateLink + @"/" + Properties.Settings.Default.UpdateFile, Properties.Settings.Default.UpdateFile, true);
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo()
                {
                    FileName = Properties.Settings.Default.UpdateFile,
                    UseShellExecute = true,
                    Verb = "open"
                });
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}

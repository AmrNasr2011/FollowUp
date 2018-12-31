using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FollowUp
{
    class ToExcel
    {


        public static DataTable ConvertCSVToDataTable(string urlExcel)
        {

            DataTable dt = new DataTable();
            try
            {

                using (StreamReader sr = new StreamReader(urlExcel))
                {
                    string[] headers = sr.ReadLine().Split(',');
                    foreach (string header in headers)
                    {
                        dt.Columns.Add(header.Trim('\"'));
                    }
                    while (!sr.EndOfStream)
                    {
                        string[] rows = sr.ReadLine().Split(',');
                        DataRow dr = dt.NewRow();
                        for (int i = 0; i < headers.Length; i++)
                        {
                            dr[i] = rows[i];
                        }
                        dt.Rows.Add(dr);
                    }

                }
                return dt;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);

                return null;
            }
        }
        public static DataTable GetDataTabletFromCSVFile(string csv_file_path)

        {
            string delimiter = ",";
            int value = 0;
            try
            {
                using (StreamReader sr = new StreamReader(csv_file_path))
                {
                    string headers = sr.ReadLine();
                    value = headers.Split(',').Count<string>();
                    if (value < headers.Split('\t').Count<string>())
                    {
                        delimiter = "\t";
                    }

                }
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }

            DataTable csvData = new DataTable();

            try

            {

                using (TextFieldParser csvReader = new TextFieldParser(csv_file_path))

                {

                    csvReader.SetDelimiters(new string[] { delimiter });

                    csvReader.HasFieldsEnclosedInQuotes = true;


                    string[] colFields = csvReader.ReadFields();

                    foreach (string column in colFields)

                    {

                        DataColumn datecolumn = new DataColumn(column);

                        datecolumn.AllowDBNull = true;

                        csvData.Columns.Add(datecolumn);

                    }

                    while (!csvReader.EndOfData)

                    {

                        string[] fieldData = csvReader.ReadFields();

                        //Making empty value as null

                        for (int i = 0; i < fieldData.Length; i++)

                        {

                            if (fieldData[i] == "")

                            {

                                fieldData[i] = null;

                            }

                        }

                        csvData.Rows.Add(fieldData);

                    }

                }

            }

            catch (Exception ex)

            {
                MessageBox.Show(ex.Message);
            }

            return csvData;

        }
    }
}

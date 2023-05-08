using Microsoft.VisualBasic.FileIO;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
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

        /// <summary>
        /// will open first sheet in excel
        /// 
        /// Assertion: Duplicate column names will be aliased by appending a sequence number (eg. Column, Column1, Column2)
        /// </summary>
        /// <param name="worksheet"></param>
        /// <returns></returns>
        /// i can send datatable that represent this 
        public static DataTable GetExcelAsDataTable(string Path,ref DataTable dt)
        {
            var package = new ExcelPackage(new FileInfo(Path));

            ExcelWorksheet worksheet = package.Workbook.Worksheets[1];
           // var dt = new DataTable(worksheet.Name);
            //dt.Columns.AddRange(GetDataColumns(worksheet).ToArray());
            var headerOffset = 1; //have to skip header row
            var width = dt.Columns.Count;
            //'get number of rows'
            var depth = GetTableDepth(worksheet, headerOffset);
            for (var i = 1; i <= depth; i++)
            {
                DataRow row = dt.NewRow();
                //loop over colomns
                for (var j = 0; j < width; j++)
                {
                    var currentValue = worksheet.Cells[i + headerOffset, j+1].Value;
                    if (dt.Columns[j].DataType== typeof(DateTime))
                    {
                        if (currentValue != null)
                        {
                            row[j] = currentValue;
                        }
                      
                    }
                    else if (dt.Columns[j].DataType == typeof(Boolean))
                    {
                        if (currentValue == null )
                        {
                            row[j] = false;
                        }
                        else
                        {
                            row[j] = currentValue.ToString().ToUpper() == "TRUE" ? true : false;
                        }
                    }
                    else if (dt.Columns[j].DataType == typeof(int))
                    {
                        if (currentValue != null)
                        {
                            row[j] = currentValue;
                        }
                      
                    }
                    else
                    {
                        row[j] = currentValue == null ? null : currentValue.ToString();
                    }
                    
                    //have to decrement b/c excel is 1 based and datatable is 0 based.
                   // row[j - 1] = currentValue == null ? null : currentValue.ToString();
                }

                dt.Rows.Add(row);
            }

            return dt;
        }

        /// <summary>
        /// Assumption: There are no null or empty cells in the first column
        /// </summary>
        /// <param name="worksheet"></param>
        /// <returns></returns>
        private static int GetTableDepth(ExcelWorksheet worksheet, int headerOffset)
        {
            int lastRow = worksheet.Cells.Where(cell => cell.Value != null).Last().End.Row;
            return lastRow-1;
        }

        private static IEnumerable<DataColumn> GetDataColumns(ExcelWorksheet worksheet)
        {
            return GatherColumnNames(worksheet).Select(x => new DataColumn(x));
        }

        private static IEnumerable<string> GatherColumnNames(ExcelWorksheet worksheet)
        {
            var columns = new List<string>();

            var i = 1;
            var j = 1;
            var columnName = worksheet.Cells[i, j].Value;
            while (columnName != null)
            {
                columns.Add(GetUniqueColumnName(columns, columnName.ToString()));
                j++;
                columnName = worksheet.Cells[i, j].Value;
            }

            return columns;
        }

        private static string GetUniqueColumnName(IEnumerable<string> columnNames, string columnName)
        {
            var colName = columnName;
            var i = 1;
            while (columnNames.Contains(colName))
            {
                colName = columnName + i.ToString();
                i++;
            }

            return colName;
        }
        


    }
}

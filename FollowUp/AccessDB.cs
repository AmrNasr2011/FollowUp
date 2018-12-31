using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
using System.IO;

namespace FollowUp
{
    class AccessDB
    {
        public string connectionStringW;
        public string connectionStringR;
        static public string connection_strW = "";
        static public string connection_strR = "";
        public Dictionary<string, string> Dic_in = new Dictionary<string, string>();
        static public string connection_str = "";
        static public string User_Name = "";
        static public Dictionary<string, DataTable> data_Dic;
        static public string SQL_command_str;
        public AccessDB()
        {//I need to specify whay of connection (read only or write) through each function
            connectionStringW = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Properties.Settings.Default.RemoteDBLOC + "; Persist Security Info=False; Mode=16;";
            connectionStringR = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Properties.Settings.Default.RemoteDBLOC + "; Persist Security Info=False; Mode=Read;";
        }
        

        //@@@need function to return datatable based of string filter
        public  DataTable Get_table_withFilter(string filter)
        {
            OleDbConnection con = new OleDbConnection(connectionStringR);
            // string asd = "SELECT * FROM " + table_str + " WHERE User='" + user_id + "'" + "AND Date=#" + Date + "#";
            
            OleDbDataAdapter da = new OleDbDataAdapter(filter, con);
            //OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM " + table_str + " WHERE User='" + user_id + "'" , con);
            DataTable ds = new DataTable();
            da.Fill(ds);
            con.Close();
            return ds;

        }

        public static List<string> GetData(Dictionary<string, string> dict, string table_name, string col_name,bool FirstRowSpace = true)
        {//this function will take 
            /*
            as input ductionary represent filter col-value
            also table name
            also return col name
            and return list of value 
            function will create sql string based on received data  
            */
            string command_str = dic_to_string_Read(dict, table_name, col_name);

            OleDbConnection con = new OleDbConnection(URL_To_ConnectionString(Properties.Settings.Default.RemoteDBLOC,false));
            List<string> str_list = new List<string>(); 
            //here i will do something to make this code more dynamic
            //I will make selection will based on 
            OleDbCommand cmd = new OleDbCommand(command_str, con);
            try
            {

                con.Open();

                OleDbDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    object x = rdr.GetValue(0);
                    var z = x as string;
                    if (z != null)
                    { str_list.Add(rdr.GetString(0)); }

                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            con.Close();
            if (FirstRowSpace)
            {
                str_list.Insert(0, ""); // this to add empty line at first
            }
            
            return str_list.Distinct().ToList();
        }
        public List<string> GetTableColumnNames(string tableName)
        {
            string command_str = "SELECT * FROM [" + tableName + "]";
            using (var connection = new OleDbConnection(connectionStringR))
            {
                OleDbCommand cmd = new OleDbCommand(command_str, connection);
                try
                {
                    connection.Open();
                }
                catch (Exception e)
                {

                    MessageBox.Show(e.Message);
                }

                OleDbDataReader rdr = cmd.ExecuteReader();
                var table = rdr.GetSchemaTable();
                var nameCol = table.Columns["ColumnName"];
                //var schemaTable = connection.GetOleDbSchemaTable(
                //  OleDbSchemaGuid.Columns,
                //  new Object[] { null, null, tableName });
                //if (schemaTable == null)
                //    return null;


                List<string> str_list = new List<string>();
                foreach (DataRow r in table.Rows)
                {
                    str_list.Add(r[nameCol].ToString());
                }
                return str_list;
            }
        }

        /// <summary>
        /// this function return string equivelent to SQL command to read a specific colomn with dictionary based filter
        /// </summary>
        /// <param name="dic_in"></param>
        /// <param name="table_str"></param>
        /// <param name="From_col_string"></param>
        /// <returns></returns>
        public static string dic_to_string_Read(Dictionary<string, string> dic_in, string table_str, string From_col_string)
        {
            string re_value = "";
            if (dic_in == null)
            {
                if (From_col_string == "*")
                {
                    return "SELECT * FROM [" + table_str + "]";
                }
                else
                {
                    return "SELECT [" + From_col_string + "] FROM [" + table_str + "]";
                }

            }
            if (dic_in.Count() == 0)
            {
                if (From_col_string == "*")
                {
                    return "SELECT * FROM [" + table_str + "]";
                }
                else
                {
                    return "SELECT [" + From_col_string + "] FROM [" + table_str + "]";
                }
            }
            else
            {

                foreach (KeyValuePair<string, string> item in dic_in)
                {
                    if (re_value != "")
                    {
                        re_value = re_value + " AND ";
                    }
                    re_value = re_value + " [" + item.Key + "] =" + " '" + item.Value + "'";

                }
                if (From_col_string == "*")
                {
                    return "SELECT * FROM [" + table_str + "] WHERE " + re_value;
                }
                else
                {
                    return "SELECT [" + From_col_string + "] FROM [" + table_str + "] WHERE " + re_value;
                }

            }

        }
        /// <summary>
        /// create SQL command with filters separated with "OR"
        /// </summary>
        /// <param name="dic_in"></param>
        /// <param name="table_str"></param>
        /// <param name="From_col_string"></param>
        /// <returns></returns>
        public static string dic_to_string_Read1(Dictionary<string, string> dic_in, string table_str, string From_col_string)
        {
            string re_value = "";
            if (dic_in == null)
            {
                if (From_col_string == "*")
                {
                    return "SELECT * FROM [" + table_str + "]";
                }
                else
                {
                    return "SELECT [" + From_col_string + "] FROM [" + table_str + "]";
                }

            }
            if (dic_in.Count() == 0)
            {
                if (From_col_string == "*")
                {
                    return "SELECT * FROM [" + table_str + "]";
                }
                else
                {
                    return "SELECT [" + From_col_string + "] FROM [" + table_str + "]";
                }
            }
            else
            {

                foreach (KeyValuePair<string, string> item in dic_in)
                {
                    if (re_value != "")
                    {
                        re_value = re_value + " OR ";
                    }
                    re_value = re_value + " [" + item.Value + "] =" + " '" + item.Key + "'";//

                }
                if (From_col_string == "*")
                {
                    return "SELECT * FROM [" + table_str + "] WHERE " + re_value;
                }
                else
                {
                    return "SELECT [" + From_col_string + "] FROM [" + table_str + "] WHERE " + re_value;
                }

            }

        }
        /// <summary>
        /// count modification index of database.
        /// </summary>
        /// <param name="constr"> URL for DB location</param>
        /// <returns>number of index of DB</returns>
        public static int version_num(string constr)
        {
            //here i will return -1 incase not reachable DB
            OleDbConnection con = new OleDbConnection(URL_To_ConnectionString( constr,true));
            OleDbCommand cmd = new OleDbCommand("select count(*) from version", con);
            try
            {

                con.Open();
                return (int)cmd.ExecuteScalar();
            }
            catch (Exception)
            {

                return -1;
            }
            finally
            {
                con.Close();
            }
        }
        /// <summary>
        /// get connection string used in ADO connection to Database
        /// </summary>
        /// <param name="URL">location for database</param>
        /// <param name="write">True if you need to write to database, False otherwise</param>
        /// <returns>connection string to use in ADO</returns>
        private static string URL_To_ConnectionString(string URL,bool write)
        {
            if (write)
            {
                return @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + URL + "; Persist Security Info=False; Mode=16;";
            }
            else
            {
                return @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + URL + "; Persist Security Info=False; Mode=Read;";
            }
            
        }
        public string dic_to_string_append(Dictionary<string, string> dic_in, string table_str)
        {
            string vals = "";
            string key_s = "";
            foreach (KeyValuePair<string, string> item in dic_in)
            {
                if (key_s == "")
                {
                    key_s = "( [" + item.Key + "]";
                }
                else
                {
                    key_s = key_s + " , " + "[" + item.Key + "]";
                }

                if (vals == "")
                {
                    vals = "( '" + item.Value + "'";
                }
                else
                {
                    vals = vals + " , " + "'" + item.Value + "'";
                }


            }
            if (key_s != "")
            {
                key_s = key_s + ")";
            }
            if (vals != "")
            {
                vals = vals + ")";
            }

            return "INSERT INTO " + "[" + table_str + "] " + key_s + " VALUES " + vals;

        }

        public string dic_to_string_appendWO(Dictionary<string, string> dic_in, string table_str)
        {
            string vals = "";
            string key_s = "";
            foreach (KeyValuePair<string, string> item in dic_in)
            {
                if (key_s == "")
                {
                    key_s = "( [" + item.Key + "]";
                }
                else
                {
                    key_s = key_s + " , " + "[" + item.Key + "]";
                }

                if (vals == "")
                {
                    vals = "( " + item.Value + "";
                }
                else
                {
                    vals = vals + " , " + "" + item.Value + "";
                }


            }
            if (key_s != "")
            {
                key_s = key_s + ")";
            }
            if (vals != "")
            {
                vals = vals + ")";
            }

            return "INSERT INTO " + "[" + table_str + "] " + key_s + " VALUES " + vals;

        }
        public void append_data(Dictionary<string, string> dic_in, string table_str)
        {

            string command_str = dic_to_string_append(dic_in, table_str);
            OleDbConnection con = new OleDbConnection(connectionStringW);

            OleDbCommand cmd = new OleDbCommand(command_str, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);

            }

            con.Close();

        }

        public void Update_data(Dictionary<string, string> dic_set, Dictionary<string, string> dic_where, string table_str)
        {

            string command_str = dic_to_string_Update(dic_set, dic_where, table_str);
            OleDbConnection con = new OleDbConnection(URL_To_ConnectionString(Properties.Settings.Default.RemoteDBLOC,true));

            OleDbCommand cmd = new OleDbCommand(command_str, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);

            }

            con.Close();

        }
        public void Apply_data(string command)
        {


            OleDbConnection con = new OleDbConnection(connectionStringW);


            try
            {
                con.Open();
                foreach (string item in command.Split(';'))
                {
                    if (item == "")
                    {
                        continue;
                    }
                    OleDbCommand cmd = new OleDbCommand(item, con);
                    cmd.ExecuteNonQuery();
                }


            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);

            }

            con.Close();

        }
        public void Delete_data(Dictionary<string, string> dic_where, string table_str)
        {

            string command_str = dic_to_string_delete(dic_where, table_str);
            OleDbConnection con = new OleDbConnection(connectionStringW);

            OleDbCommand cmd = new OleDbCommand(command_str, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);

            }

            con.Close();

        }
        public static void Delete_data_ByID(List<string> dic_where, string table_str)
        {

            string command_str = dic_to_string_deleteByID(dic_where, table_str);
            OleDbConnection con = new OleDbConnection(URL_To_ConnectionString(Properties.Settings.Default.RemoteDBLOC, true));

            OleDbCommand cmd = new OleDbCommand(command_str, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);

            }

            con.Close();

        }
        public string dic_to_string_Update(Dictionary<string, string> dic_SET, Dictionary<string, string> dic_WHERE, string table_str)
        {
            string re_WHERE = "";
            string re_SET = "";
            if (dic_WHERE == null || dic_SET == null)
            {
                return "";
            }
            if (dic_WHERE.Count() == 0 || dic_SET.Count() == 0)
            {
                return "";
            }
            else
            {

                foreach (KeyValuePair<string, string> item in dic_WHERE)
                {
                    if (re_WHERE != "")
                    {
                        re_WHERE = re_WHERE + " AND ";
                    }
                    re_WHERE = re_WHERE + " [" + item.Key + "] =" + " '" + item.Value + "'";

                }

                foreach (KeyValuePair<string, string> item in dic_SET)
                {
                    if (re_SET != "")
                    {
                        re_SET = re_SET + " , ";
                    }
                    re_SET = re_SET + " [" + item.Key + "] =" + " '" + item.Value + "'";

                }

                return "UPDATE [" + table_str + "] SET" + re_SET + " WHERE " + re_WHERE;

            }

        }

        public string dic_to_string_UpdateWO(Dictionary<string, string> dic_SET, Dictionary<string, string> dic_WHERE, string table_str)
        {
            string re_WHERE = "";
            string re_SET = "";
            if (dic_WHERE == null || dic_SET == null)
            {
                return "";
            }
            if (dic_WHERE.Count() == 0 || dic_SET.Count() == 0)
            {
                return "";
            }
            else
            {

                foreach (KeyValuePair<string, string> item in dic_WHERE)
                {
                    if (re_WHERE != "")
                    {
                        re_WHERE = re_WHERE + " AND ";
                    }
                    re_WHERE = re_WHERE + " [" + item.Key + "] =" + " " + item.Value + "";

                }

                foreach (KeyValuePair<string, string> item in dic_SET)
                {
                    if (re_SET != "")
                    {
                        re_SET = re_SET + " , ";
                    }
                    re_SET = re_SET + " [" + item.Key + "] =" + " " + item.Value + "";

                }

                return "UPDATE [" + table_str + "] SET" + re_SET + " WHERE " + re_WHERE;

            }

        }
        public string dic_to_string_delete(Dictionary<string, string> dic_WHERE, string table_str)
        {
            string re_WHERE = "";
            if (dic_WHERE == null)
            {
                return "";
            }
            if (dic_WHERE.Count() == 0)
            {
                return "";
            }
            else
            {

                foreach (KeyValuePair<string, string> item in dic_WHERE)
                {
                    if (re_WHERE != "")
                    {
                        re_WHERE = re_WHERE + " AND ";
                    }
                    re_WHERE = re_WHERE + " [" + item.Key + "] =" + " '" + item.Value + "'";

                }



                return "DELETE FROM [" + table_str + "] " + " WHERE " + re_WHERE;
            }


        }

        public static string dic_to_string_deleteByID(List<string> list_WHERE, string table_str)
        {
            string re_WHERE = "";
            if (list_WHERE == null)
            {
                return "";
            }
            if (list_WHERE.Count() == 0)
            {
                return "";
            }
            else
            {

                foreach (string item in list_WHERE)
                {
                    if (re_WHERE != "")
                    {
                        re_WHERE = re_WHERE + " OR ";
                    }
                    re_WHERE = re_WHERE + " [ID] =" + item + " ";

                }



                return "DELETE FROM [" + table_str + "] " + " WHERE " + re_WHERE;
            }


        }

        public string dic_to_string_deleteWO(Dictionary<string, string> dic_WHERE, string table_str)
        {
            string re_WHERE = "";
            if (dic_WHERE == null)
            {
                return "";
            }
            if (dic_WHERE.Count() == 0)
            {
                return "";
            }
            else
            {

                foreach (KeyValuePair<string, string> item in dic_WHERE)
                {
                    if (re_WHERE != "")
                    {
                        re_WHERE = re_WHERE + " AND ";
                    }
                    re_WHERE = re_WHERE + " [" + item.Key + "] =" + " " + item.Value + "";

                }



                return "DELETE FROM [" + table_str + "] " + " WHERE " + re_WHERE;
            }


        }
        //using Dataset way
        //return dataset object contain all user data 
        //this is not ageneric function
        public DataTable Dataset_select(string table_str, string user_id, string Date)
        {
            OleDbConnection con = new OleDbConnection(connectionStringR);
            // string asd = "SELECT * FROM " + table_str + " WHERE User='" + user_id + "'" + "AND Date=#" + Date + "#";
            string asd = string.Format("SELECT * FROM {0}  WHERE User='{1}' AND Date1= #{2}#", table_str, user_id, Date);
            OleDbDataAdapter da = new OleDbDataAdapter(asd, con);
            //OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM " + table_str + " WHERE User='" + user_id + "'" , con);
            DataTable ds = new DataTable();
            da.Fill(ds);
            con.Close();
            return ds;
        }
        /// <summary>
        /// Read with "AND" in filter(filter separated with AND)
        /// </summary>
        /// <param name="dic_where"></param>
        /// <param name="table_str"></param>
        /// <param name="Column_str"></param>
        /// <returns></returns>
        public static DataTable Read_DataSet(Dictionary<string, string> dic_where, string table_str, string Column_str)
        {
            string select_str;
            OleDbConnection con = new OleDbConnection(URL_To_ConnectionString(Properties.Settings.Default.RemoteDBLOC, false));
            select_str = dic_to_string_Read(dic_where, table_str, Column_str);
            // string asd = "SELECT * FROM " + table_str + " WHERE User='" + user_id + "'" + "AND Date=#" + Date + "#";

            OleDbDataAdapter da = new OleDbDataAdapter(select_str, con);
            //OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM " + table_str + " WHERE User='" + user_id + "'" , con);
            DataTable ds = new DataTable();
            da.Fill(ds);
            con.Close();
          
            return ds;
           
        }
        /// <summary>
        /// Read with "OR" in filter(filter separated with OR)
        /// </summary>
        /// <param name="dic_where"></param>
        /// <param name="table_str"></param>
        /// <param name="Column_str"></param>
        /// <returns></returns>
        public static DataTable Read_DataSet1(Dictionary<string, string> dic_where, string table_str, string Column_str)
        {
            string select_str;
            OleDbConnection con = new OleDbConnection(URL_To_ConnectionString(Properties.Settings.Default.RemoteDBLOC, false));
            select_str = dic_to_string_Read1(dic_where, table_str, Column_str);
            // string asd = "SELECT * FROM " + table_str + " WHERE User='" + user_id + "'" + "AND Date=#" + Date + "#";

            OleDbDataAdapter da = new OleDbDataAdapter(select_str, con);
            //OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM " + table_str + " WHERE User='" + user_id + "'" , con);
            DataTable ds = new DataTable();
            da.Fill(ds);
            con.Close();

            return ds;

        }
        public bool Upload_table(DataTable D_table, string table_str, Dictionary<string, string> dic_where)
        {
            string select_str;
            //create select statment to use in build
            select_str = dic_to_string_Read(dic_where, table_str, "*");
            //start build commands
            OleDbConnection con = new OleDbConnection(connectionStringW);
            OleDbDataAdapter da = new OleDbDataAdapter(select_str, con);
            OleDbCommandBuilder builder = new OleDbCommandBuilder(da);
            builder.SetAllValues = false;
            builder.ConflictOption = ConflictOption.OverwriteChanges;
            builder.QuotePrefix = "[";
            builder.QuoteSuffix = "]";
            builder.GetDeleteCommand();
            builder.GetInsertCommand();
            builder.GetUpdateCommand();
            //think of how to force update statment to update specific colomns only
            try
            {
                da.Update(D_table);
                return true;
            }
            catch (Exception exp)
            {
               // MessageBox.Show(exp.Message);
                con.Close();
                return false;
               
            }

        }

        public static void  Modify_table(DataTable D_table, string table_str, string select_str)
        {
            
            
            //start build commands
            OleDbConnection con = new OleDbConnection(URL_To_ConnectionString(Properties.Settings.Default.RemoteDBLOC,true));
            OleDbDataAdapter da = new OleDbDataAdapter(select_str, con);
            OleDbCommandBuilder builder = new OleDbCommandBuilder(da);
            builder.SetAllValues = false;
            builder.ConflictOption = ConflictOption.OverwriteChanges;
            builder.QuotePrefix = "[";
            builder.QuoteSuffix = "]";
            //builder.GetDeleteCommand();
            //builder.GetInsertCommand();
            builder.GetUpdateCommand();
           
            //think of how to force update statment to update specific colomns only
       
            try
            {
                
                da.Update(D_table);
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
                con.Close();

            }

        }
        /// <summary>
        /// Add table rows to database
        /// </summary>
        /// <param name="D_table">New table to be added</param>
        /// <param name="table_str">table that will be updated in DB</param>
        /// <param name="select_str"> select command to compare data with</param>
        /// <returns>number of changed rows at DB or -1 in case of error</returns>
        public static int Insert_table(DataTable D_table, string table_str, string select_str,List<string> DeleteList = null)
        {

            int count;
            //start build commands
            OleDbConnection con = new OleDbConnection(URL_To_ConnectionString(Properties.Settings.Default.RemoteDBLOC,true));
            if (select_str == "")
            {
                select_str = "SELECT * FROM " + table_str;
            }
            OleDbDataAdapter da = new OleDbDataAdapter();
            
            da.SelectCommand = new OleDbCommand( select_str);
            da.SelectCommand.Connection = con;
            OleDbCommandBuilder builder = new OleDbCommandBuilder(da);
            builder.SetAllValues = false;
            builder.ConflictOption = ConflictOption.OverwriteChanges;
            builder.QuotePrefix = "[";
            builder.QuoteSuffix = "]";
            //
            try
            {
                builder.GetInsertCommand();
                builder.GetUpdateCommand();
                builder.GetDeleteCommand();
                //MessageBox.Show(builder.GetDeleteCommand().CommandText);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return -1;
            }
           
            //builder.GetUpdateCommand();
            //think of how to force update statment to update specific colomns only
            try
            {
               count  = da.Update(D_table);
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
                con.Close();
                return -1;
            }
            if (DeleteList != null && DeleteList.Count !=0)
            {
                Delete_data_ByID(DeleteList, table_str);
                return count;
            }
            else
            {
                return count;
            }
        }
        /// <summary>
        /// this used to add column "status" to this table
        /// </summary>
        /// <param name="table"></param>
        public static void table_with_status_col(ref DataTable table)
        {
            table.Columns.Add("status", typeof(System.String));

        }
        static public string time_str(DateTime time)
        {
            return "#" + time.Date.ToString("MM/dd/yyyy") + "#";
        }

        static public string obj_str(string item)
        {
            return "'" + item + "'";
        }

        public static string Database_LOC(string database_name, out string Database_local)
        {
            string app_loc = Application.StartupPath;
            Database_local = app_loc + "\\" + database_name;
            try
            {
                return System.IO.File.ReadAllText(app_loc + "\\Data");
            }
            catch (Exception)
            {
                return app_loc + "\\" + database_name;
                //MessageBox.Show("Missing connection string file");
            }

        }
        public static bool Check_remote_Database_write(string table, string connectionRemote)
        {
            string connectionstr = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + connectionRemote + "; Persist Security Info=False; Mode=16;";
            try
            {
                OleDbConnection con = new OleDbConnection(connectionstr);

                string asd = string.Format("SELECT * FROM {0}", table);
                OleDbDataAdapter da = new OleDbDataAdapter(asd, con);

                DataTable ds = new DataTable();
                da.Fill(ds);
                con.Close();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        /// <summary>
        /// validate file existence
        /// </summary>
        /// <param name="URL">full location of file</param>
        /// <returns>true if file exist, false otherwise</returns>
       public static bool check_DB_file_exist(string URL)
        {
            return File.Exists(URL) ? true : false;
        }
        

    }

        //here i need to make function to sync all my data 
        //so i need remote database connection string
        //i need to create new colomn uniqueID consist of unique value made of user sesa and counter id 
        //this colomn will be created when upload data to remote database and will be synched or add to local database with sync
        //nead a functoin that contain sync download and sync Upload refreash will done manually (function done aready)
        //synch down will done to all tables in remote DB
        //sync up will done to all tables has modif (could at start do for all tables then to reducce number of required tables to be updated)
        //what needed in update is to insert new colomn with unique id which consist of user sesa and normal used id


    }


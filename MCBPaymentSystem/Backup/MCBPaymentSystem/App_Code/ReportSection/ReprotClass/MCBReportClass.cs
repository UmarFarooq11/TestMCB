using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.ComponentModel;
using Microsoft.Reporting.WebForms;
using System.Data.OracleClient;
using System.Data.OleDb;

//using System.Drawing.Printing;
//using Microsoft.Reporting.WinForms;
/// <summary>
/// Summary description for ReportClass
/// </summary>
    public class MCBReportClass
    {
        private string strCon_Global1;
        private string strCon_GlobalOra;
        public MCBReportClass()
        {
            ////PathReader p1 = new PathReader();
            ////DatabaseConfig D = new DatabaseConfig();
            ////D = p1.Deserialize_Data();
            ////DAL_EXP1.Utility.Startup_Util.DB_Route = "Data Source=" + D.DB + ";Persist Security Info=True;User ID=" + D.UserID + ";Password=" + D.UserPassword + ";Unicode=True;Pooling=false";
            //////strCon_Global1 = DAL_EXP1.Utility.Startup_Util.DB_Route;
            //////strCon_Global1 = "Provider=MSDAORA.1;Password=mcbcs ;User ID=mcbcs_test;Data Source=nt";
            ////strCon_Global1 = ConfigurationManager.AppSettings["ConnectionString1"].ToString();
            PathReader p1 = new PathReader();
            DatabaseConfig D = new DatabaseConfig();
            D = p1.Deserialize_Data();
            DAL_EXP1.Utility.Startup_Util.DB_Route = "Data Source=" + D.DB + ";Persist Security Info=True;User ID=" + D.UserID + ";Password=" + D.UserPassword + ";Unicode=True;Pooling=false";
            /// strCon_Global1 = DAL_EXP1.Utility.Startup_Util.DB_Route;
            strCon_Global1 = "Provider=MSDAORA.1;Password=" + D.UserPassword + ";User ID=" + D.UserID + ";Data Source=" + D.DB;
            strCon_GlobalOra = "Password=" + D.UserPassword + ";User ID=" + D.UserID + ";Data Source=" + D.DB;
            //Data Source=orcl;Persist Security Info=True;User ID=mcbcs;Password=mcbcs;Unicode=True;Pooling=false
        }
        public OleDbConnection GetConnection1()
        {
            //PathReader p1 = new PathReader();
            //DatabaseConfig D = new DatabaseConfig();
            //D = p1.Deserialize_Data();
            //DAL_EXP1.Utility.Startup_Util.DB_Route = "Data Source=" + D.DB + ";Persist Security Info=True;User ID=" + D.UserID + ";Password=" + D.UserPassword + ";Unicode=True;Pooling=false";
            //strCon_Global1 = DAL_EXP1.Utility.Startup_Util.DB_Route;

            PathReader p1 = new PathReader();
            DatabaseConfig D = new DatabaseConfig();
            D = p1.Deserialize_Data();
            DAL_EXP1.Utility.Startup_Util.DB_Route = "Data Source=" + D.DB + ";Persist Security Info=True;User ID=" + D.UserID + ";Password=" + D.UserPassword + ";Unicode=True;Pooling=false";
            //      strCon_Global1 = DAL_EXP1.Utility.Startup_Util.DB_Route;
            // strCon_Global1 = "Provider=MSDAORA.1;Password=mcbcs ;User ID=mcbcs;Data Source=orcl";
            strCon_Global1 = "Provider=MSDAORA.1;Password=" + D.UserPassword + ";User ID=" + D.UserID + ";Data Source=" + D.DB;
            return (new OleDbConnection(strCon_Global1));
        }
        //public OracleConnection GetConnectionOralce()
        //{
        //    PathReader p1 = new PathReader();
        //    DatabaseConfig D = new DatabaseConfig();
        //    D = p1.Deserialize_Data();
        //    DAL_EXP1.Utility.Startup_Util.DB_Route = "Data Source=" + D.DB + ";Persist Security Info=True;User ID=" + D.UserID + ";Password=" + D.UserPassword + ";Unicode=True;Pooling=false";
        //    strCon_Global1 = "Provider=MSDAORA.1;Password=" + D.UserPassword + ";User ID=" + D.UserID + ";Data Source=" + D.DB;
        //    return (new OracleConnection(strCon_Global1));
        //}
        public DataSet Local_GetDataSet1(string SQL)
        {
            try
            {
                OleDbConnection connection = new OleDbConnection(strCon_Global1);
                OleDbDataAdapter adapter;
                try
                {

                    adapter = new OleDbDataAdapter(SQL, connection);
                    DataSet mydata = new DataSet();
                    adapter.Fill(mydata);
                    adapter.Dispose();
                    connection.Close();
                    return mydata;
                }
                catch (Exception e)
                {
                    if (connection.State != ConnectionState.Closed) connection.Close();
                    throw new Exception("Data Base Error: " + e.Message);
                    //return null;
                }
            }
            catch (Exception e)
            {
                throw new Exception("DB : " + e.Message);
            }

        }
        // Execute Non Query for Oledb
        public int ExecuteNonQuery1(string SQL)
        {
            int lngRecords;
            try
            {
                OleDbConnection con = new OleDbConnection(strCon_Global1);
                try
                {
                    OleDbCommand cmdQuery = new OleDbCommand();
                    //con=new OleDbConnection(strCon_Global);
                    cmdQuery.Connection = con;
                    cmdQuery.CommandText = SQL;
                    cmdQuery.CommandType = CommandType.Text;
                    cmdQuery.Connection.Open();
                    lngRecords = cmdQuery.ExecuteNonQuery();
                    cmdQuery.Connection.Close();
                    return lngRecords;
                }
                catch (Exception ex)
                {
                    if (con.State != ConnectionState.Closed) con.Close();
                    throw new Exception("Data Base Error: " + ex.Message);
                }
            }
            catch (Exception e)
            {
                throw new Exception("DB : " + e.Message);
            }


        }
        //Execute Reader for Oledb
        public OleDbDataReader ExecuteReader1(string SQL)
        {//Khateeb Bhai
            OleDbDataReader dr;

            OleDbCommand cmdQuery = new OleDbCommand();
            cmdQuery.Connection = GetConnection1();
            cmdQuery.CommandText = SQL;
            cmdQuery.CommandType = CommandType.Text;
            cmdQuery.Connection.Open();
            dr = cmdQuery.ExecuteReader();
            cmdQuery.Connection.Close();
            return dr;
        }



        //********************** SP Mathods for Oledb **************************
        // Start
        //This Mathod take (1)spname (2)oledb Paramater and return dataset
        public DataSet Local_GetDataSetSP1(string spName, OleDbParameter[] spParams)
        {

            try
            {
                DataSet ds = new DataSet();
                OleDbConnection con = GetConnection1();
                try
                {

                    OleDbCommand cmd = new OleDbCommand();
                    cmd.Parameters.Clear();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = spName;
                    foreach (OleDbParameter itm in spParams)
                    {
                        cmd.Parameters.Add(itm);
                    }

                    OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                    da.Fill(ds, "Table0");
                    con.Close();
                    return ds;
                }
                catch (Exception ex)
                {
                    if (con.State != ConnectionState.Closed) con.Close();
                    throw new Exception("Data Base Error: " + ex.Message);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Data Base Error opening connection: " + e.Message);
            }
        }

        ////This Mathod take (1)spname and return dataset
        public DataSet Local_GetDataSetSP1(string spName)
        {
            try
            {
                DataSet ds = new DataSet();
                OleDbConnection con = GetConnection1();
                try
                {
                    OleDbCommand cmd = new OleDbCommand();
                    cmd.Parameters.Clear();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = spName;

                    OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                    da.Fill(ds, "Table0");
                    con.Close();
                    return ds;
                }
                catch (Exception ex)
                {
                    if (con.State != ConnectionState.Closed) con.Close();
                    throw new Exception("Data Base Error: " + ex.Message);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Data Base Error opening connection: " + e.Message);
            }

        }
        //This Mathod take (1)spname (2)oledb Paramater and return Int
        public Int32 Local_ExecuteSP1(string spName, OleDbParameter[] spParams)
        {

            try
            {
                Int32 returnval;
                DataSet ds = new DataSet();
                OleDbConnection con = GetConnection1();
                try
                {

                    OleDbCommand cmd = new OleDbCommand();
                    cmd.Parameters.Clear();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = spName;
                    foreach (OleDbParameter itm in spParams)
                    {
                        cmd.Parameters.Add(itm);
                    }
                    con.Open();
                    //OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                    //da.Fill(ds, "Table0");
                    returnval = cmd.ExecuteNonQuery();
                    con.Close();
                    return returnval;
                }
                catch (Exception ex)
                {
                    if (con.State != ConnectionState.Closed) con.Close();
                    throw new Exception("Data Base Error: " + ex.Message);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Data Base Error opening connection: " + e.Message);
            }
        }
        //This Mathod take (1)spname (2)oledb Paramater and nothing return
        public DataSet Oracle_GetDataSetSP(string spName, OracleParameter[] spParams)
        {
            DataSet ds = new DataSet();
            OracleConnection con = new OracleConnection(strCon_GlobalOra);
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;

            foreach (OracleParameter itm in spParams)
            { cmd.Parameters.Add(itm); }
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            try
            {
                da.Fill(ds, "Table0");
                da.Dispose();
                cmd.Dispose();
                con.Dispose();
                return ds;
            }
            catch (Exception ex)
            {
                da.Dispose();
                throw new Exception("Data Base Error: " + ex.Message);
            }
        }
        public void ExecuteSP_NoReturnVal1(string spName, OleDbParameter[] spParams)
        {

            try
            {
                DataSet ds = new DataSet();
                OleDbConnection con = GetConnection1();
                try
                {

                    OleDbCommand cmd = new OleDbCommand();
                    cmd.Parameters.Clear();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = spName;
                    foreach (OleDbParameter itm in spParams)
                    {
                        cmd.Parameters.Add(itm);
                    }

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                }
                catch (Exception ex)
                {
                    if (con.State != ConnectionState.Closed) con.Close();
                    throw new Exception("Data Base Error: " + ex.Message);
                }
            }
            catch (Exception e)
            {
                throw new Exception("DB : " + e.Message);
            }


        }
        //This Mathod take (1)spname (2)Oracle Paramater and return String
        public string ExecuteSP_GetReturnVal1(string spName, OleDbParameter[] spParams)
        {
            try
            {
                DataSet ds = new DataSet();
                OleDbConnection con = GetConnection1();
                try
                {

                    OleDbCommand cmd = new OleDbCommand();
                    cmd.Parameters.Clear();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = spName;
                    foreach (OleDbParameter itm in spParams)
                    {
                        cmd.Parameters.Add(itm);
                    }

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    return Convert.ToString(spParams[0].Value);
                }
                catch (Exception ex)
                {
                    if (con.State != ConnectionState.Closed) con.Close();
                    throw new Exception("Data Base Error: " + ex.Message);
                }
            }
            catch (Exception e)
            {
                throw new Exception("DB : " + e.Message);
            }




        }
        public double ExecuteSP_GetReturnDoubleVal1(string spName, OleDbParameter[] spParams, double paranumber)
        {
            try
            {
                DataSet ds = new DataSet();
                OleDbConnection con = GetConnection1();
                try
                {

                    OleDbCommand cmd = new OleDbCommand();
                    cmd.Parameters.Clear();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = spName;
                    foreach (OleDbParameter itm in spParams)
                    {
                        cmd.Parameters.Add(itm);
                    }

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    // return Convert.ToString(spParams[0].Value);
                    return Convert.ToDouble(spParams[Convert.ToInt16(paranumber)].Value); // Add by Qasim 30-01-2009
                }
                catch (Exception ex)
                {
                    if (con.State != ConnectionState.Closed) con.Close();
                    throw new Exception("Data Base Error: " + ex.Message);
                }
            }
            catch (Exception e)
            {
                throw new Exception("DB : " + e.Message);
            }




        }
        public string ExecuteSP_GetReturnStringVal1(string spName, OleDbParameter[] spParams, double paranumber)
        {
            try
            {
                DataSet ds = new DataSet();
                OleDbConnection con = GetConnection1();
                try
                {

                    OleDbCommand cmd = new OleDbCommand();
                    cmd.Parameters.Clear();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = spName;
                    foreach (OleDbParameter itm in spParams)
                    {
                        cmd.Parameters.Add(itm);
                    }

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    // return Convert.ToString(spParams[0].Value);
                    return Convert.ToString(spParams[Convert.ToInt16(paranumber)].Value); // Add by Khateeb 12-02-2009
                }
                catch (Exception ex)
                {
                    if (con.State != ConnectionState.Closed) con.Close();
                    throw new Exception("Data Base Error: " + ex.Message);
                }

            }
            catch (Exception e)
            {
                throw new Exception("DB : " + e.Message);
            }


        }
        public string TransSP_GetReturnStringVal1(OleDbConnection cn, OleDbTransaction tn, string spName, OleDbParameter[] spParams, double paranumber)
        {
            //DataSet ds = new DataSet();
            //OleDbConnection con = GetConnection();
            OleDbCommand cmd = new OleDbCommand(spName, cn, tn);
            //cmd.Parameters.Clear();
            //cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.CommandText = spName;
            foreach (OleDbParameter itm in spParams)
            {
                cmd.Parameters.Add(itm);
            }
            try
            {
                //con.Open();
                cmd.ExecuteNonQuery();
                //con.Close();
                // return Convert.ToString(spParams[0].Value);
                return Convert.ToString(spParams[Convert.ToInt16(paranumber)].Value); // Add by Khateeb 12-02-2009
            }
            catch (Exception ex)
            {
                throw new Exception("Data Base Error: " + ex.Message);
            }


        }
        public string TransSP_GetReturnTwoStringVals1(OleDbConnection cn, OleDbTransaction tn, string spName, OleDbParameter[] spParams, double paranumber1, double paranumber2)
        {
            //DataSet ds = new DataSet();
            //OleDbConnection con = GetConnection();
            OleDbCommand cmd = new OleDbCommand(spName, cn, tn);
            //cmd.Parameters.Clear();
            //cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.CommandText = spName;
            foreach (OleDbParameter itm in spParams)
            {
                cmd.Parameters.Add(itm);
            }
            try
            {
                //con.Open();
                cmd.ExecuteNonQuery();
                //con.Close();
                // return Convert.ToString(spParams[0].Value);
                return Convert.ToString(spParams[Convert.ToInt16(paranumber1)].Value) + ";" + Convert.ToString(spParams[Convert.ToInt16(paranumber2)].Value); // Add by Khateeb 12-02-2009
            }
            catch (Exception ex)
            {
                throw new Exception("Data Base Error: " + ex.Message);
            }
        }
        public string ExecuteSP_GetReturnTwoStringVals1(string spName, OleDbParameter[] spParams, double paranumber1, double paranumber2)
        {
            DataSet ds = new DataSet();
            OleDbConnection con = GetConnection1();
            OleDbCommand cmd = new OleDbCommand();
            cmd.Parameters.Clear();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            foreach (OleDbParameter itm in spParams)
            {
                cmd.Parameters.Add(itm);
            }
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                // return Convert.ToString(spParams[0].Value);
                return Convert.ToString(spParams[Convert.ToInt16(paranumber1)].Value) + ";" + Convert.ToString(spParams[Convert.ToInt16(paranumber2)].Value); // Add by Khateeb 12-02-2009
            }
            catch (Exception ex)
            {
                throw new Exception("Data Base Error: " + ex.Message);
            }


        }

        public OracleParameter OracleDBParameter(string ID, string Val, string DataType, string Direction)
        {
            try
            {
                OracleParameter p1 = new OracleParameter(ID, GetOracleDBType(DataType), 2000);

                if (Direction == "In")
                {
                    p1.Direction = ParameterDirection.Input;
                }
                else if (Direction == "Out")
                {
                    p1.Direction = ParameterDirection.Output;
                }
                else if (Direction == "InOut")
                {
                    p1.Direction = ParameterDirection.InputOutput;
                }
                if (DataType == "DateTime")
                {
                    p1.Value = Val != "" ? Convert.ToDateTime(Val) : Convert.DBNull;
                }
                else if (DataType == "Double")
                {
                    p1.Value = Val != "" ? Convert.ToDouble(Val) : Convert.DBNull;
                }
                else if (DataType == "Int32")
                {
                    p1.Value = Val != "" ? p1.Value = Convert.ToInt32(Val) : Convert.DBNull;
                }
                else
                    p1.Value = Val;
                return p1;

            }
            catch (Exception ex)
            {
                throw new Exception("Data Base Error: " + ex.Message);
            }
        }
        public System.Data.OracleClient.OracleType GetOracleDBType(string strSystemType)
        {
            System.Data.OracleClient.OracleType dbType = System.Data.OracleClient.OracleType.VarChar;

            switch (strSystemType)
            {
                case "String":
                    dbType = System.Data.OracleClient.OracleType.VarChar;
                    break;
                case "Int64":
                    dbType = System.Data.OracleClient.OracleType.Int32;
                    break;
                case "Int32":
                    dbType = System.Data.OracleClient.OracleType.Int32;
                    break;
                case "DateTime":
                    dbType = System.Data.OracleClient.OracleType.DateTime;
                    break;
                case "Double":
                    dbType = System.Data.OracleClient.OracleType.Double;
                    break;
                case "Boolean":
                    dbType = System.Data.OracleClient.OracleType.Blob;
                    break;
                case "Int16":
                    dbType = System.Data.OracleClient.OracleType.Int16;
                    break;
                case "Decimal":
                    dbType = System.Data.OracleClient.OracleType.Double;
                    break;
                case "Cursor":
                    dbType = System.Data.OracleClient.OracleType.Cursor;
                    break;
            }

            return dbType;
        }

        public OleDbParameter OleDbParameter(string ID, string Val, string DataType, string Direction)
        {
            try
            {
                OleDbParameter p1 = new OleDbParameter(ID, GetOleDbType(DataType), 2000);

                if (Direction == "In")
                {
                    p1.Direction = ParameterDirection.Input;
                }
                else if (Direction == "Out")
                {
                    p1.Direction = ParameterDirection.Output;
                }
                else if (Direction == "InOut")
                {
                    p1.Direction = ParameterDirection.InputOutput;
                }

                if (DataType == "DateTime")
                {
                    p1.Value = Val != "" ? Convert.ToDateTime(Val) : Convert.DBNull;
                }
                else if (DataType == "Double")
                {
                    p1.Value = Val != "" ? Convert.ToDouble(Val) : Convert.DBNull;
                }
                else if (DataType == "Int32")
                {
                    p1.Value = Val != "" ? p1.Value = Convert.ToInt32(Val) : Convert.DBNull;
                }
                else
                    p1.Value = Val;
                return p1;

            }
            catch (Exception ex)
            {
                throw new Exception("Data Base Error: " + ex.Message);
            }
        }
        public System.Data.OleDb.OleDbType GetOleDbType(string strSystemType)
        {
            System.Data.OleDb.OleDbType dbType = System.Data.OleDb.OleDbType.VarChar;

            switch (strSystemType)
            {
                case "String":
                    dbType = System.Data.OleDb.OleDbType.VarChar;
                    break;
                case "Int64":
                    dbType = System.Data.OleDb.OleDbType.Integer;
                    break;
                case "Int32":
                    dbType = System.Data.OleDb.OleDbType.Integer;
                    break;
                case "DateTime":
                    dbType = System.Data.OleDb.OleDbType.Date;
                    break;
                case "Double":
                    dbType = System.Data.OleDb.OleDbType.Double;
                    break;
                case "Boolean":
                    dbType = System.Data.OleDb.OleDbType.Boolean;
                    break;
                case "Int16":
                    dbType = System.Data.OleDb.OleDbType.Integer;
                    break;
                case "Decimal":
                    dbType = System.Data.OleDb.OleDbType.Decimal;
                    break;
            }

            return dbType;
        }
    }

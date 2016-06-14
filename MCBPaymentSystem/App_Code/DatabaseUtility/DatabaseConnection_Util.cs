//using System;
//using System.Data;
//using System.Configuration;
//using System.Web;
//using System.Web.Security;
//using System.Web.UI;
//using System.Web.UI.WebControls;
//using System.Web.UI.WebControls.WebParts;
//using System.Web.UI.HtmlControls;
//using System.Collections.Generic;
////using System.Data.SqlClient;
//using System.Data.OracleClient;
//using System.Collections;

using System;
using System.Data;
using System.Configuration;
using System.Web;
//using System.Web.Security;
//using System.Web.UI;
//using System.Web.UI.WebControls;
//using System.Web.UI.WebControls.WebParts;
//using System.Web.UI.HtmlControls;
//using System.Data.OleDb;
using System.Data.OracleClient;
using System.Data.OleDb;
//using System.Data.SqlClient;

public class DatabaseConnection_Util
{
    public string ConnectionString; //= "Data Source=orcl;Persist Security Info=True;User ID=dbo_samba_spds_pre;Password=dbo_samba_spds_pre;Unicode=True";
      
      // strCon_Global1 = DAL_EXP1.Utility.Startup_Util.DB_Route;

   // private readonly string ConnectionString = ConfigurationManager.ConnectionStrings["FRAMEWORK_APPLICATIONConnectionString"].ConnectionString;
    private static DataSet StoredProceDatasetCollection = new DataSet();
    public  OracleConnection DBConnection;
    public string chk = "";

    public DatabaseConnection_Util()
    {
        PathReader p1 = new PathReader();
        DatabaseConfig D = new DatabaseConfig();
        D = p1.Deserialize_Data();
        DAL_EXP1.Utility.Startup_Util.DB_Route = "Data Source=" + D.DB + ";Persist Security Info=True;User ID=" + D.UserID + ";Password=" + D.UserPassword + ";Unicode=True;Pooling=false";
        ConnectionString = DAL_EXP1.Utility.Startup_Util.DB_Route;
        ConnectionMaker(); 
    }
    private void ConnectionMaker()
    {
        DBConnection = new OracleConnection(ConnectionString);
       //DBConnection.Open();
        
    }
    public string getConnString()
    {
        return ConnectionString;

    }
    public DataSet ReteriveDataMultiple(string QRY, string SN_Name)
    {
        //try
        //{
        //    OracleDataAdapter DATA_ADAPTER;
        //    DataSet DATA_DATASET;
        //    DATA_ADAPTER = new OracleDataAdapter(QRY, DBConnection);
        //    DATA_DATASET = new DataSet(SN_Name);
        //    DATA_ADAPTER.Fill(DATA_DATASET);
        //    DBConnection.Close();
        //    return DATA_DATASET;
        //}

        //catch (Exception ex)
        //{
        //    DBConnection.Close();
        //    throw new Exception("Data Base Error: " + ex.Message);
        //}
        
        OracleDataAdapter DATA_ADAPTER;
        DataSet DATA_DATASET;
        DATA_ADAPTER = new OracleDataAdapter(QRY, DBConnection);
        DATA_DATASET = new DataSet(SN_Name);
        DATA_ADAPTER.Fill(DATA_DATASET);
        DBConnection.Close(); /*ali*/
        return DATA_DATASET;   
    }
    //public DataSet ReteriveDataMultiple_DML(string spName, OracleParameter[] spParams)
    //{
    //    OracleDataAdapter DATA_ADAPTER;
    //    DataSet DATA_DATASET;
    //    DATA_ADAPTER = new OracleDataAdapter(QRY, DBConnection);
    //    DATA_DATASET = new DataSet(SN_Name);
    //    DATA_ADAPTER.Fill(DATA_DATASET);
    //    DBConnection.Close(); /*ali*/
    //    return DATA_DATASET;
    //}
    public DataSet ReteriveDataTableMultiple(string[] TB, string SN_Name)
    {
        OracleDataAdapter DATA_ADAPTER;
        DataSet DATA_DATASET;
        DATA_ADAPTER = new OracleDataAdapter();
        DATA_ADAPTER = new OracleDataAdapter("SELECT * FROM " + TB[0].ToString() + "; SELECT * FROM " + TB[1].ToString(), ConnectionString);
        DATA_DATASET = new DataSet(SN_Name);
        DATA_ADAPTER.Fill(DATA_DATASET);
        return DATA_DATASET;
        
    }
    public void DataPlacement(string FD, string Data, DataSet DS, DataRow DR)
    {
       // FD = "V_" + FD;
        if (DR.Table.Columns[FD].DataType.ToString() == "System.Decimal")
        { DR[FD] = Convert.ToDecimal(Data.ToString()); }
        else if (DR.Table.Columns[FD].DataType.ToString() == "System.Int32")
        { DR[FD] = Convert.ToInt32(Data.ToString()); }
        else if (DR.Table.Columns[FD].DataType.ToString() == "System.String")
        { DR[FD] = Data; }
        else if (DR.Table.Columns[FD].DataType.ToString() == "System.Boolean")
        { DR[FD] = Convert.ToBoolean(Data); }
        else if (DR.Table.Columns[FD].DataType.ToString() == "System.DateTime")
        { DR[FD] = Data; }//Convert.ToDateTime(Data); }
        else if (DR.Table.Columns[FD].DataType.ToString() == "System.Byte[]")
        { DR[FD] = Data; }//Convert.ToDateTime(Data); }
    }
    public DataSet StoredProcedurePlacement(DataSet TB, string P_SP_NAME)
    {
        int FLG1 = 0;
        DataSet TempDS = new DataSet();
        DataSet SP = new DataSet();
        //SP = ReteriveDataMultiple("EXEC RPS_SP_StoredProcedures_GetParams '" + SP_NAME + "'", SP_NAME);
        //SP = ReteriveDataMultiple("RPS_SP_StoredProcedures_GetParams '" + P_SP_NAME + "'", P_SP_NAME);
        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = Oracle_Param("P_SP_NAME", OracleType.VarChar, ParameterDirection.Input, P_SP_NAME);
        PR[1] = Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        SP = Oracle_GetDataSetSP("RPS_SP_StoredProcedures_GetPar", PR);


        for (int a = 0; a <= StoredProceDatasetCollection.Tables.Count - 1; a++)
        {
            if (StoredProceDatasetCollection.Tables[a].ToString() == P_SP_NAME.ToString())
            {
                TempDS.Tables.Add(StoredProceDatasetCollection.Tables[a].Clone());
                TempDS.Tables[0].Rows.Clear();
                FLG1 = 1;
            }
        }
        if (FLG1 == 0)
        {
            DataTable T = new DataTable(P_SP_NAME);
            DataRow DR = T.NewRow();
            for (int a = 0; a <= SP.Tables[0].Rows.Count - 1; a++)
            {
                DR.Table.Columns.Add(
                                     MakeRow(
                                             SP.Tables[0].Rows[a][0].ToString(),
                                             SP.Tables[0].Rows[a][1].ToString(),
                                             SP.Tables[0].Rows[a][2].ToString()
                                             )
                                    );
            }
            TempDS.Tables.Add(T);
            StoredProceDatasetCollection.Tables.Add(T.Clone());
        }

        DataRow DRR = TempDS.Tables[0].NewRow();
        for (int b = 0; b <= TB.Tables[0].Rows.Count - 1; b++)
        {
            DRR = TempDS.Tables[0].NewRow();
            for (int a = 0; a <= TB.Tables[0].Columns.Count - 1; a++)
            {
                for (int c = 0; c <= TempDS.Tables[0].Columns.Count - 1; c++)
                {
                    if ("V_"+TB.Tables[0].Columns[a].ToString() == TempDS.Tables[0].Columns[c].ToString())
                    {
                        if (TB.Tables[0].Columns[a].DataType.ToString() != "System.DateTime")
                        {
                            DRR[TempDS.Tables[0].Columns[c].ToString()] = TB.Tables[0].Rows[b][a].ToString();
                        }
                        else 
                        {
                            DRR[TempDS.Tables[0].Columns[c].ToString()] = Convert.ToDateTime(TB.Tables[0].Rows[b][a].ToString()).ToString("dd-MMM-yyyy");
                        }
                    }
                    else if ("V_" + TB.Tables[0].Columns[a].ToString() == TempDS.Tables[0].Columns[c].ToString()+ "NT")
                    {
                        if (TB.Tables[0].Columns[a].DataType.ToString() != "System.DateTime")
                        {
                            DRR[TempDS.Tables[0].Columns[c].ToString()] = TB.Tables[0].Rows[b][a].ToString();
                        }
                        else
                        {
                            DRR[TempDS.Tables[0].Columns[c].ToString()] = Convert.ToDateTime(TB.Tables[0].Rows[b][a].ToString()).ToString("dd-MMM-yyyy");
                        }
                    }
                }
            }
            TempDS.Tables[0].Rows.Add(DRR);
        }

        return TempDS;
    }
    private DataColumn MakeRow(string ColName, string ColDataType, string PARM)
    {
        DataColumn DC;
        if (ColDataType.ToString() == "Decimal")
        { DC = new DataColumn(ColName, typeof(decimal)); }
        else if (ColDataType.ToString() == "Int32")
        { DC = new DataColumn(ColName, typeof(Int32)); }
        else if (ColDataType.ToString() == "String")
        { DC = new DataColumn(ColName, typeof(string)); }
        else if (ColDataType.ToString() == "DateTime")
        { DC = new DataColumn(ColName, typeof(DateTime)); }
        else if (ColDataType.ToString() == "bool")
        { DC = new DataColumn(ColName, typeof(System.Boolean)); }
        else if (ColDataType.ToString() == "Double")
        { DC = new DataColumn(ColName, typeof(System.Double)); }
        else
        { DC = new DataColumn(ColName, typeof(string)); }

        if (PARM == "0")
        { DC.ExtendedProperties["Param"] = "0"; }
        else if (PARM == "1")
        { DC.ExtendedProperties["Param"] = "1"; }
        return DC;
    }
    public DataTable SavingData(DataSet DS, string SP_NAME)
    {
        DataTable DT = new DataTable("ReturnParam");

        DataColumn DC1 = new DataColumn("NAME", typeof(String));
        DC1.Caption = "NAME";

        DataColumn DC2 = new DataColumn("VALUE", typeof(String));
        DC2.Caption = "VALUE";

        DataRow DR = DT.NewRow();
        DR.Table.Columns.Add(DC1);
        DR.Table.Columns.Add(DC2);


        OracleConnection CN = new OracleConnection(ConnectionString);
        OracleCommand CMD = new OracleCommand(SP_NAME, CN);
        CMD.CommandType = CommandType.StoredProcedure;

        for (int a = 0; a <= DS.Tables[0].Rows.Count - 1; a++)
        {
            for (int b = 0; b <= DS.Tables[0].Columns.Count - 1; b++)
            {
                if (DS.Tables[0].Columns[b].ExtendedProperties["Param"].ToString() == "1")
                {
                    DR = DT.NewRow();
                    DR[0] = DS.Tables[0].Columns[b].ToString();
                    DR[1] = "";
                    DT.Rows.Add(DR);
                }
                AddParameterIndex(
                                  CMD,
                                  DS.Tables[0].Columns[b].ToString(),
                                  DS.Tables[0].Columns[b].DataType.ToString(),
                                  DS.Tables[0].Rows[a][b].ToString(),
                                  DS.Tables[0].Columns[b].ExtendedProperties["Param"].ToString()
                                 );
            }
        }
        CMD.Connection.Open();
        CMD.ExecuteNonQuery();
        for (int a = 0; a <= DT.Rows.Count - 1; a++)
        {
            DT.Rows[0][1] = CMD.Parameters[ DT.Rows[a][0].ToString()].Value.ToString();
        }
        return DT;
    }
    public void AddParameterIndex(OracleCommand SQ, string ParamName, string DataType, string Data, string ParamType)
    {
        OracleParameter param = new OracleParameter();
        param.ParameterName =  ParamName;

        if (DataType.ToString() == "System.Decimal")
        {
            //param.DbType= DbType.Decimal;
            param.OracleType = OracleType.Int32;
            param.Value = Convert.ToDecimal(Data.ToString());
        }
        else if (DataType.ToString() == "System.Int32")
        {

            //param.DbType = DbType.Int;
            param.OracleType = OracleType.Int32;
            param.Value = Convert.ToInt32(Data.ToString());
        }
        else if (DataType.ToString() == "System.String")
        {
            //param.DbType = DbType.VarChar;
            param.OracleType = OracleType.VarChar;
            param.Value = Data.ToString();
        }
        else if (DataType.ToString() == "System.DateTime")
        {
            //param.DbType = DbType.DateTime;
            param.OracleType = OracleType.DateTime;
            param.Value = Convert.ToDateTime(Data.ToString()).ToString("dd-MMM-yyyy");
        }
        //else if (DataType.ToString() == "System.Double")
        //{
        //    param.DbType = DbType.Money;
        //    param.Value = Data.ToString();
        //}

        else if (DataType.ToString() == "System.Boolean")
        {
            //param.DbType = DbType.Bit;
            param.OracleType = OracleType.Blob;
            param.Value = Data.ToString();
        }
        if (ParamType == "0")
        { param.Direction = ParameterDirection.Input; }
        else if (ParamType == "1")
        {
            param.Size = 100;
            param.Direction = ParameterDirection.Output;
        }

        SQ.Parameters.Add(param);
    }
    public OracleParameter Oracle_Param(string P_NAME, OracleType PT, ParameterDirection PD, string PV)
    {
        OracleParameter P1 = new OracleParameter();
        P1.Value = PV.ToString();
        P1.ParameterName = P_NAME.ToString();
        P1.OracleType = PT;
        P1.Size = 2000;
        P1.Direction = PD;
        P1.Value = PV.ToString();
        return P1;
    }
    public OracleParameter Oracle_Param(string P_NAME, OracleType PT, ParameterDirection PD, double PV)
    {
        OracleParameter P1 = new OracleParameter();
        P1.Value = PV.ToString();
        P1.ParameterName = P_NAME.ToString();
        P1.OracleType = PT;
        P1.Size = 2000;
        P1.Direction = PD;
        P1.Value = PV;
        return P1;
    }
    public OracleParameter Oracle_Param(string P_NAME, OracleType PT, ParameterDirection PD, byte[] PV)
    {
        OracleParameter P1 = new OracleParameter();
        P1.Value = PV;
        P1.ParameterName = P_NAME.ToString();
        P1.OracleType = PT;
        P1.Size = PV.Length;
        P1.Direction = PD;
        P1.Value = PV;
        return P1;
    }
    public DataSet Oracle_GetDataSetSP(string spName, OracleParameter[] spParams)
    {
        DataSet ds = new DataSet();
        OracleConnection con = new OracleConnection(ConnectionString);
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
    public OracleParameter[] OracleParameterDefination(DataSet DS1)
     {
        int K = 0;
        K = DS1.Tables[0].Columns.Count;
        OracleParameter[] PR = new OracleParameter[K];

        for (int a = 0; a <= DS1.Tables[0].Columns.Count - 1; a++)
        {
            //PR[a] = Oracle_Param("V_" + DS1.Tables[0].Columns[a].ColumnName.ToString(), OracleType.VarChar, ParameterDirection.Input, DS1.Tables[0].Rows[0][a].ToString());

            if (DS1.Tables[0].Columns[a].DataType.ToString() != "System.DateTime")
            {
                PR[a] = Oracle_Param("V_" + DS1.Tables[0].Columns[a].ColumnName.ToString(), OracleType.VarChar, ParameterDirection.Input, DS1.Tables[0].Rows[0][a].ToString());
            }
            else
            {
                PR[a] = Oracle_Param("V_" + DS1.Tables[0].Columns[a].ColumnName.ToString(), OracleType.VarChar, ParameterDirection.Input, Convert.ToDateTime(DS1.Tables[0].Rows[0][a].ToString()).ToString("dd-MMM-yyyy"));
                
            }


            


        }
        return PR;
    }
    public void Oracle_GetDataSetSP_DML(string spName, OracleParameter[] spParams)
    {
        OracleConnection con = new OracleConnection(ConnectionString);
        try
        {
            DataSet ds = new DataSet();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;

            foreach (OracleParameter itm in spParams)
            { cmd.Parameters.Add(itm); }
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            con.Open();
            da.Fill(ds, "Table0");
            con.Close();
        }
        catch (Exception ex)
        {
            con.Close();
            throw new Exception("Data Base Error: " + ex.Message);
        }
    }
    public string Oracle_GetDataSetSP_DML(string spName, OracleParameter[] spParams,int paranumber)
    {
        OracleConnection con = new OracleConnection(ConnectionString);
        try
        {
            DataSet ds = new DataSet();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;

            foreach (OracleParameter itm in spParams)
            { cmd.Parameters.Add(itm); }
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            con.Open();
            da.Fill(ds, "Table0");
            con.Close();

            return Convert.ToString(spParams[paranumber].Value);
        }
        catch (Exception ex)
        {
            con.Close();
            throw new Exception("Data Base Error: " + ex.Message);
        }
    }
    public string OracleExecuteSP_GetReturnVal(string spName, OracleParameter[] spParams, Double paranumber)
    {
        DataSet ds = new DataSet();
        OracleConnection con = new OracleConnection(ConnectionString);
        OracleCommand cmd = new OracleCommand();
        cmd.Parameters.Clear();
        cmd.Connection = con;
        cmd.CommandText = spName;
        cmd.CommandType = CommandType.StoredProcedure;
        foreach (OracleParameter itm in spParams)
        {
            cmd.Parameters.Add(itm);
        }
        try
        {
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            return Convert.ToString(spParams[Convert.ToInt16(paranumber)].Value);
        }
        catch (Exception ex)
        {
            throw new Exception("Data Base Error: " + ex.Message);
        }
    }
    public DataSet CreateSPParams(string strSPName)
    {       
        //string ConnectionString = "Data Source=orcl;Persist Security Info=True;User ID=dbo_samba_spds_pre;Password=dbo_samba_spds_pre;Unicode=True";
        DataSet dst = new DataSet();
        DataTable dtlParam = new DataTable(strSPName);
        OracleCommand cmd = null;
        OracleDataAdapter adp = null;
        //OracleConnection conn = null;

        DataSet dstParams = new DataSet();

        OracleConnection conn = new OracleConnection(ConnectionString);

        try
        {
            try
            {


                cmd = new OracleCommand("RPS_SP_GetPar",  conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("P_SP_Name", OracleType.VarChar);
                cmd.Parameters["P_SP_Name"].Value = strSPName;

                cmd.Parameters.Add("DATA_RESULTSET", OracleType.Cursor);
                cmd.Parameters["DATA_RESULTSET"].Direction = ParameterDirection.Output;

                adp = new OracleDataAdapter(cmd);
                conn.Open();
                adp.Fill(dst);
            }
            catch (Exception ex)
            {
                //LogException("SQLManager", "Inner Block CreateSPParams", ex);

                throw ex;
            }
            finally
            {
                conn.Close();

                conn = null;
                cmd = null;
                adp = null;
            }

            foreach (DataRow drw in dst.Tables[0].Rows)
            {
                dtlParam.Columns.Add(drw["ParamName"].ToString(), GetSystemType(drw["ParamType"].ToString()));
                dtlParam.Columns[drw["ParamName"].ToString()].ExtendedProperties.Add("IsOutParam",
                    drw["IsOutParam"]);
            }

            dtlParam.AcceptChanges();
            dstParams.Tables.Add(dtlParam);
            //return dstParams.Tables[strSPName].Copy();
            return dstParams;
        }
        catch (Exception ex)
        {
            //LogException("SQLManager", "CreateSPParams", ex);

            throw ex;
        }
    }
    //private static Type GetSystemType(string strSQLType)
    //{
    //    Type type = Type.GetType("System.String");

    //    switch (strSQLType)
    //    {
    //        case "text":
    //            type = Type.GetType("System.String");
    //            break;
    //        case "tinyint":
    //            type = Type.GetType("System.Int32");
    //            break;
    //        case "smallint":
    //            type = Type.GetType("System.Int32");
    //            break;
    //        case "int":
    //            type = Type.GetType("System.Int32");
    //            break;
    //        case "smalldatetime":
    //            type = Type.GetType("System.DateTime");
    //            break;
    //        case "real":
    //            type = Type.GetType("System.Double");
    //            break;
    //        case "money":
    //            type = Type.GetType("System.Double");
    //            break;
    //        case "datetime":
    //            type = Type.GetType("System.DateTime");
    //            break;
    //        case "float":
    //            type = Type.GetType("System.Double");
    //            break;
    //        case "ntext":
    //            type = Type.GetType("System.String");
    //            break;
    //        case "bit":
    //            type = Type.GetType("System.Boolean");
    //            break;
    //        case "decimal":
    //            type = Type.GetType("System.Double");
    //            break;
    //        case "numeric":
    //            type = Type.GetType("System.Int32");
    //            break;
    //        case "smallmoney":
    //            type = Type.GetType("System.Double");
    //            break;
    //        case "bigint":
    //            type = Type.GetType("System.Int32");
    //            break;
    //        case "varchar":
    //            type = Type.GetType("System.String");
    //            break;
    //        case "char":
    //            type = Type.GetType("System.String");
    //            break;
    //        case "nvarchar":
    //            type = Type.GetType("System.String");
    //            break;
    //        case "nchar":
    //            type = Type.GetType("System.String");
    //            break;
    //    }

    //    return type;
    //}
    private static Type GetSystemType(string strSQLType)
    {
        Type type = Type.GetType("System.String");

        switch (strSQLType)
        {
            case "text":
                type = Type.GetType("System.String");
                break;
            case "tinyint":
                type = Type.GetType("System.Int32");
                break;
            case "smallint":
                type = Type.GetType("System.Int32");
                break;
            case "int":
                type = Type.GetType("System.Int32");
                break;
            case "smalldatetime":
                type = Type.GetType("System.DateTime");
                break;
            case "real":
                type = Type.GetType("System.Double");
                break;
            case "money":
                type = Type.GetType("System.Double");
                break;
            case "datetime":
                type = Type.GetType("System.DateTime");
                break;
            case "float":
                type = Type.GetType("System.Double");
                break;
            case "ntext":
                type = Type.GetType("System.String");
                break;
            case "bit":
                type = Type.GetType("System.Boolean");
                break;
            case "decimal":
                type = Type.GetType("System.Double");
                break;
            case "numeric":
                type = Type.GetType("System.Int32");
                break;
            case "smallmoney":
                type = Type.GetType("System.Double");
                break;
            case "bigint":
                type = Type.GetType("System.Int32");
                break;
            case "varchar":
                type = Type.GetType("System.String");
                break;
            case "char":
                type = Type.GetType("System.String");
                break;
            case "nvarchar":
                type = Type.GetType("System.String");
                break;
            case "nchar":
                type = Type.GetType("System.String");
                break;
        }

        return type;
    }
    public DataSet Local_GetDataSet1(string SQL)
    {
        try
        {
            OracleConnection connection = new OracleConnection(ConnectionString);
            OracleDataAdapter adapter;
            try
            {

                adapter = new OracleDataAdapter(SQL, connection);
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

    public string TransSPOracle_GetReturnStringVal1(OracleConnection cn, OracleTransaction tn, string spName, OracleParameter[] spParams, double paranumber)
    {
        OracleCommand cmd = new OracleCommand(spName, cn, tn);
        cmd.CommandType = CommandType.StoredProcedure;
        foreach (OracleParameter itm in spParams)
        {
            cmd.Parameters.Add(itm);
        }
        try
        {
            cmd.ExecuteNonQuery();
            return Convert.ToString(spParams[Convert.ToInt16(paranumber)].Value); 
        }
        catch (Exception ex)
        {
            throw new Exception("Data Base Error: " + ex.Message);
        }
    }

}

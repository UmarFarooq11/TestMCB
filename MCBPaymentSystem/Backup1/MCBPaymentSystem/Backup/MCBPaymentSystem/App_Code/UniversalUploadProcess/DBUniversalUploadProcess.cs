using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Oracle.DataAccess.Client;
using System.Data.OracleClient;

/// <summary>
/// Summary description for DBUniversalUploadProcess
/// </summary>
public class DBUniversalUploadProcess
{
    public string ConnectionString;
    public DBUniversalUploadProcess()
    {
        PathReader p1 = new PathReader();
        DatabaseConfig D = new DatabaseConfig();
        D = p1.Deserialize_Data();
        DAL_EXP1.Utility.Startup_Util.DB_Route = "Data Source=" + D.DB +
            ";Persist Security Info=True;User ID=" + D.UserID + ";Password=" + D.UserPassword + ";";
        ConnectionString = DAL_EXP1.Utility.Startup_Util.DB_Route;
    }
    public string UploadProcess(int count, DataTable dt, string Company_code, string ConfID, string FielName)
    {
        string retval = "";
        try
        {
            #region //Array Declare
            string[] arr_company_Code = new string[count];
            string[] arr_ConfID = new string[count];
            string[] arr_FielName = new string[count];

            string[] F1 = new string[count];
            string[] F2 = new string[count];
            string[] F3 = new string[count];
            string[] F4 = new string[count];
            string[] F5 = new string[count];
            string[] F6 = new string[count];
            string[] F7 = new string[count];
            string[] F8 = new string[count];
            string[] F9 = new string[count];
            string[] F10 = new string[count];

            string[] F11 = new string[count];
            string[] F12 = new string[count];
            string[] F13 = new string[count];
            string[] F14 = new string[count];
            string[] F15 = new string[count];
            string[] F16 = new string[count];
            string[] F17 = new string[count];
            string[] F18 = new string[count];
            string[] F19 = new string[count];
            string[] F20 = new string[count];

            string[] F21 = new string[count];
            string[] F22 = new string[count];
            string[] F23 = new string[count];
            string[] F24 = new string[count];
            string[] F25 = new string[count];
            string[] F26 = new string[count];
            string[] F27 = new string[count];
            string[] F28 = new string[count];
            string[] F29 = new string[count];
            string[] F30 = new string[count];

            string[] F31 = new string[count];
            string[] F32 = new string[count];
            string[] F33 = new string[count];
            string[] F34 = new string[count];
            string[] F35 = new string[count];
            string[] F36 = new string[count];
            string[] F37 = new string[count];
            string[] F38 = new string[count];
            string[] F39 = new string[count];
            string[] F40 = new string[count];

            string[] F41 = new string[count];
            string[] F42 = new string[count];
            string[] F43 = new string[count];
            string[] F44 = new string[count];
            string[] F45 = new string[count];
            string[] F46 = new string[count];
            string[] F47 = new string[count];
            string[] F48 = new string[count];
            string[] F49 = new string[count];
            string[] F50 = new string[count];
            #endregion
            int col = 0;
            int[] arrSize = new int[count];
            for (int i = 0; i < count; i++)
            {
                arrSize[i] = 1000;
                #region // Array Bind
                arr_company_Code[i] = Company_code;
                arr_ConfID[i] = ConfID;
                arr_FielName[i] = FielName;

                col = 0;
                F1[i] = (dt.Columns.Count >= col) ? dt.Rows[i][col].ToString() : "";
                col++; if (dt.Columns.Count <= col) continue;

                F2[i] = (dt.Columns.Count >= col) ? dt.Rows[i][col].ToString() : "";
                col++; if (dt.Columns.Count <= col) continue;
                F3[i] = (dt.Columns.Count >= col) ? dt.Rows[i][col].ToString() : "";
                col++; if (dt.Columns.Count <= col) continue;
                F4[i] = (dt.Columns.Count >= col) ? dt.Rows[i][col].ToString() : "";
                col++; if (dt.Columns.Count <= col) continue;
                F5[i] = (dt.Columns.Count >= col) ? dt.Rows[i][col].ToString() : "";
                col++; if (dt.Columns.Count <= col) continue;
                F6[i] = (dt.Columns.Count >= col) ? dt.Rows[i][col].ToString() : "";
                col++; if (dt.Columns.Count <= col) continue;
                F7[i] = (dt.Columns.Count >= col) ? dt.Rows[i][col].ToString() : "";
                col++; if (dt.Columns.Count <= col) continue;
                F8[i] = (dt.Columns.Count >= col) ? dt.Rows[i][col].ToString() : "";
                col++; if (dt.Columns.Count <= col) continue;
                F9[i] = (dt.Columns.Count >= col) ? dt.Rows[i][col].ToString() : "";
                col++; if (dt.Columns.Count <= col) continue;
                F10[i] = (dt.Columns.Count >= col) ? dt.Rows[i][col].ToString() : "";
                col++; if (dt.Columns.Count <= col) continue;
                F11[i] = (dt.Columns.Count >= col) ? dt.Rows[i][col].ToString() : "";
                col++; if (dt.Columns.Count <= col) continue;
                F12[i] = (dt.Columns.Count >= col) ? dt.Rows[i][col].ToString() : "";
                col++; if (dt.Columns.Count <= col) continue;
                F13[i] = (dt.Columns.Count >= col) ? dt.Rows[i][col].ToString() : "";
                col++; if (dt.Columns.Count <= col) continue;
                F14[i] = (dt.Columns.Count >= col) ? dt.Rows[i][col].ToString() : "";
                col++; if (dt.Columns.Count <= col) continue;
                F15[i] = (dt.Columns.Count >= col) ? dt.Rows[i][col].ToString() : "";
                col++; if (dt.Columns.Count <= col) continue;
                F16[i] = (dt.Columns.Count >= col) ? dt.Rows[i][col].ToString() : "";
                col++; if (dt.Columns.Count <= col) continue;
                F17[i] = (dt.Columns.Count >= col) ? dt.Rows[i][col].ToString() : "";
                col++; if (dt.Columns.Count <= col) continue;
                F18[i] = (dt.Columns.Count >= col) ? dt.Rows[i][col].ToString() : "";
                col++; if (dt.Columns.Count <= col) continue;
                F19[i] = (dt.Columns.Count >= col) ? dt.Rows[i][col].ToString() : "";
                col++; if (dt.Columns.Count <= col) continue;
                F20[i] = (dt.Columns.Count >= col) ? dt.Rows[i][col].ToString() : "";
                col++; if (dt.Columns.Count <= col) continue;
                F21[i] = (dt.Columns.Count >= col) ? dt.Rows[i][col].ToString() : "";
                col++; if (dt.Columns.Count <= col) continue;
                F22[i] = (dt.Columns.Count >= col) ? dt.Rows[i][col].ToString() : "";
                col++; if (dt.Columns.Count <= col) continue;
                F23[i] = (dt.Columns.Count >= col) ? dt.Rows[i][col].ToString() : "";
                col++; if (dt.Columns.Count <= col) continue;
                F24[i] = (dt.Columns.Count >= col) ? dt.Rows[i][col].ToString() : "";
                col++; if (dt.Columns.Count <= col) continue;
                F25[i] = (dt.Columns.Count >= col) ? dt.Rows[i][col].ToString() : "";
                col++; if (dt.Columns.Count <= col) continue;
                F26[i] = (dt.Columns.Count >= col) ? dt.Rows[i][col].ToString() : "";
                col++; if (dt.Columns.Count <= col) continue;
                F27[i] = (dt.Columns.Count >= col) ? dt.Rows[i][col].ToString() : "";
                col++; if (dt.Columns.Count <= col) continue;
                F28[i] = (dt.Columns.Count >= col) ? dt.Rows[i][col].ToString() : "";
                col++; if (dt.Columns.Count <= col) continue;
                F29[i] = (dt.Columns.Count >= col) ? dt.Rows[i][col].ToString() : "";
                col++; if (dt.Columns.Count <= col) continue;
                F30[i] = (dt.Columns.Count >= col) ? dt.Rows[i][col].ToString() : "";
                col++; if (dt.Columns.Count <= col) continue;
                F31[i] = (dt.Columns.Count >= col) ? dt.Rows[i][col].ToString() : "";
                col++; if (dt.Columns.Count <= col) continue;
                F32[i] = (dt.Columns.Count >= col) ? dt.Rows[i][col].ToString() : "";
                col++; if (dt.Columns.Count <= col) continue;
                F33[i] = (dt.Columns.Count >= col) ? dt.Rows[i][col].ToString() : "";
                col++; if (dt.Columns.Count <= col) continue;
                F34[i] = (dt.Columns.Count >= col) ? dt.Rows[i][col].ToString() : "";
                col++; if (dt.Columns.Count <= col) continue;
                F35[i] = (dt.Columns.Count >= col) ? dt.Rows[i][col].ToString() : "";
                col++; if (dt.Columns.Count <= col) continue;
                F36[i] = (dt.Columns.Count >= col) ? dt.Rows[i][col].ToString() : "";
                col++; if (dt.Columns.Count <= col) continue;
                F37[i] = (dt.Columns.Count >= col) ? dt.Rows[i][col].ToString() : "";
                col++; if (dt.Columns.Count <= col) continue;
                F38[i] = (dt.Columns.Count >= col) ? dt.Rows[i][col].ToString() : "";
                col++; if (dt.Columns.Count <= col) continue;
                F39[i] = (dt.Columns.Count >= col) ? dt.Rows[i][col].ToString() : "";
                col++; if (dt.Columns.Count <= col) continue;
                F40[i] = (dt.Columns.Count >= col) ? dt.Rows[i][col].ToString() : "";
                col++; if (dt.Columns.Count <= col) continue;
                F41[i] = (dt.Columns.Count >= col) ? dt.Rows[i][col].ToString() : "";
                col++; if (dt.Columns.Count <= col) continue;
                F42[i] = (dt.Columns.Count >= col) ? dt.Rows[i][col].ToString() : "";
                col++; if (dt.Columns.Count <= col) continue;
                F43[i] = (dt.Columns.Count >= col) ? dt.Rows[i][col].ToString() : "";
                col++; if (dt.Columns.Count <= col) continue;
                F44[i] = (dt.Columns.Count >= col) ? dt.Rows[i][col].ToString() : "";
                col++; if (dt.Columns.Count <= col) continue;
                F45[i] = (dt.Columns.Count >= col) ? dt.Rows[i][col].ToString() : "";
                col++; if (dt.Columns.Count <= col) continue;
                F46[i] = (dt.Columns.Count >= col) ? dt.Rows[i][col].ToString() : "";
                col++; if (dt.Columns.Count <= col) continue;
                F47[i] = (dt.Columns.Count >= col) ? dt.Rows[i][col].ToString() : "";
                col++; if (dt.Columns.Count <= col) continue;
                F48[i] = (dt.Columns.Count >= col) ? dt.Rows[i][col].ToString() : "";
                col++; if (dt.Columns.Count <= col) continue;
                F49[i] = (dt.Columns.Count >= col) ? dt.Rows[i][col].ToString() : "";
                col++; if (dt.Columns.Count <= col) continue;
                F50[i] = (dt.Columns.Count >= col) ? dt.Rows[i][col].ToString() : "";
                #endregion
                //arrSize[i] = 1000;
            }
            Oracle.DataAccess.Client.OracleConnection ocnn = new Oracle.DataAccess.Client.OracleConnection(ConnectionString);
            ocnn.Open();
            Oracle.DataAccess.Client.OracleCommand ocmd = ocnn.CreateCommand();
            ocmd.CommandText = "SP_RAW_DATALOAD";
            ocmd.CommandType = CommandType.StoredProcedure;
            ocmd.BindByName = true;
            ocmd.ArrayBindCount = count;
            #region //Pass array to parameter
            ocmd.Parameters.Add("P_COMPANY_CODE", OracleDbType.Varchar2, arr_company_Code, ParameterDirection.Input);
            ocmd.Parameters.Add("P_CONF_ID", OracleDbType.Varchar2, arr_ConfID, ParameterDirection.Input);
            ocmd.Parameters.Add("P_FILE_Name", OracleDbType.Varchar2, arr_FielName, ParameterDirection.Input);
            ocmd.Parameters.Add("P_F1", OracleDbType.Varchar2, F1, ParameterDirection.Input);
            ocmd.Parameters.Add("P_F2", OracleDbType.Varchar2, F2, ParameterDirection.Input);
            ocmd.Parameters.Add("P_F3", OracleDbType.Varchar2, F3, ParameterDirection.Input);
            ocmd.Parameters.Add("P_F4", OracleDbType.Varchar2, F4, ParameterDirection.Input);
            ocmd.Parameters.Add("P_F5", OracleDbType.Varchar2, F5, ParameterDirection.Input);
            ocmd.Parameters.Add("P_F6", OracleDbType.Varchar2, F6, ParameterDirection.Input);
            ocmd.Parameters.Add("P_F7", OracleDbType.Varchar2, F7, ParameterDirection.Input);
            ocmd.Parameters.Add("P_F8", OracleDbType.Varchar2, F8, ParameterDirection.Input);
            ocmd.Parameters.Add("P_F9", OracleDbType.Varchar2, F9, ParameterDirection.Input);
            ocmd.Parameters.Add("P_F10", OracleDbType.Varchar2, F10, ParameterDirection.Input);

            ocmd.Parameters.Add("P_F11", OracleDbType.Varchar2, F11, ParameterDirection.Input);
            ocmd.Parameters.Add("P_F12", OracleDbType.Varchar2, F12, ParameterDirection.Input);
            ocmd.Parameters.Add("P_F13", OracleDbType.Varchar2, F13, ParameterDirection.Input);
            ocmd.Parameters.Add("P_F14", OracleDbType.Varchar2, F14, ParameterDirection.Input);
            ocmd.Parameters.Add("P_F15", OracleDbType.Varchar2, F15, ParameterDirection.Input);
            ocmd.Parameters.Add("P_F16", OracleDbType.Varchar2, F16, ParameterDirection.Input);
            ocmd.Parameters.Add("P_F17", OracleDbType.Varchar2, F17, ParameterDirection.Input);
            ocmd.Parameters.Add("P_F18", OracleDbType.Varchar2, F18, ParameterDirection.Input);
            ocmd.Parameters.Add("P_F19", OracleDbType.Varchar2, F19, ParameterDirection.Input);
            ocmd.Parameters.Add("P_F20", OracleDbType.Varchar2, F20, ParameterDirection.Input);

            ocmd.Parameters.Add("P_F21", OracleDbType.Varchar2, F21, ParameterDirection.Input);
            ocmd.Parameters.Add("P_F22", OracleDbType.Varchar2, F22, ParameterDirection.Input);
            ocmd.Parameters.Add("P_F23", OracleDbType.Varchar2, F23, ParameterDirection.Input);
            ocmd.Parameters.Add("P_F24", OracleDbType.Varchar2, F24, ParameterDirection.Input);
            ocmd.Parameters.Add("P_F25", OracleDbType.Varchar2, F25, ParameterDirection.Input);
            ocmd.Parameters.Add("P_F26", OracleDbType.Varchar2, F26, ParameterDirection.Input);
            ocmd.Parameters.Add("P_F27", OracleDbType.Varchar2, F27, ParameterDirection.Input);
            ocmd.Parameters.Add("P_F28", OracleDbType.Varchar2, F28, ParameterDirection.Input);
            ocmd.Parameters.Add("P_F29", OracleDbType.Varchar2, F29, ParameterDirection.Input);
            ocmd.Parameters.Add("P_F30", OracleDbType.Varchar2, F30, ParameterDirection.Input);

            ocmd.Parameters.Add("P_F31", OracleDbType.Varchar2, F31, ParameterDirection.Input);
            ocmd.Parameters.Add("P_F32", OracleDbType.Varchar2, F32, ParameterDirection.Input);
            ocmd.Parameters.Add("P_F33", OracleDbType.Varchar2, F33, ParameterDirection.Input);
            ocmd.Parameters.Add("P_F34", OracleDbType.Varchar2, F34, ParameterDirection.Input);
            ocmd.Parameters.Add("P_F35", OracleDbType.Varchar2, F35, ParameterDirection.Input);
            ocmd.Parameters.Add("P_F36", OracleDbType.Varchar2, F36, ParameterDirection.Input);
            ocmd.Parameters.Add("P_F37", OracleDbType.Varchar2, F37, ParameterDirection.Input);
            ocmd.Parameters.Add("P_F38", OracleDbType.Varchar2, F38, ParameterDirection.Input);
            ocmd.Parameters.Add("P_F39", OracleDbType.Varchar2, F39, ParameterDirection.Input);
            ocmd.Parameters.Add("P_F40", OracleDbType.Varchar2, F40, ParameterDirection.Input);

            ocmd.Parameters.Add("P_F41", OracleDbType.Varchar2, F41, ParameterDirection.Input);
            ocmd.Parameters.Add("P_F42", OracleDbType.Varchar2, F42, ParameterDirection.Input);
            ocmd.Parameters.Add("P_F43", OracleDbType.Varchar2, F43, ParameterDirection.Input);
            ocmd.Parameters.Add("P_F44", OracleDbType.Varchar2, F44, ParameterDirection.Input);
            ocmd.Parameters.Add("P_F45", OracleDbType.Varchar2, F45, ParameterDirection.Input);
            ocmd.Parameters.Add("P_F46", OracleDbType.Varchar2, F46, ParameterDirection.Input);
            ocmd.Parameters.Add("P_F47", OracleDbType.Varchar2, F47, ParameterDirection.Input);
            ocmd.Parameters.Add("P_F48", OracleDbType.Varchar2, F48, ParameterDirection.Input);
            ocmd.Parameters.Add("P_F49", OracleDbType.Varchar2, F49, ParameterDirection.Input);
            ocmd.Parameters.Add("P_F50", OracleDbType.Varchar2, F50, ParameterDirection.Input);
            ocmd.Parameters.Add("v_retval", OracleDbType.Varchar2, "", ParameterDirection.Output).ArrayBindSize = arrSize;
            #endregion
            int result = ocmd.ExecuteNonQuery();
            ocnn.Close();
            retval = ((Oracle.DataAccess.Types.OracleString[])(ocmd.Parameters["v_retval"].Value))[0].ToString();
        }
        catch (Exception ex)
        {
            retval = ex.Message;
        }
        return retval;
    }
    public string MianProcess(string Company_code, string ConfID, string FielName, string TransType, string sp_name)
    {
        string retval = "";
        try
        {
            System.Data.OracleClient.OracleConnection con = new System.Data.OracleClient.OracleConnection(ConnectionString);
            System.Data.OracleClient.OracleCommand cmd = new System.Data.OracleClient.OracleCommand();
            cmd.Parameters.Clear();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = sp_name;
            cmd.Parameters.Add("p_company_code", OracleType.VarChar, 2000).Value = Company_code;
            cmd.Parameters.Add("P_CONF_ID", OracleType.VarChar, 2000).Value = ConfID;
            cmd.Parameters.Add("P_FILE_NAME", OracleType.VarChar, 2000).Value = FielName;
            cmd.Parameters.Add("P_trans_type", OracleType.VarChar, 2000).Value = TransType;
            cmd.Parameters.Add("v_retval", OracleType.VarChar, 2000).Direction = ParameterDirection.Output;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            retval = cmd.Parameters["v_retval"].Value.ToString();
        }
        catch (Exception ex)
        {
            throw new Exception("Data Base Error: " + ex.Message);
        }
        #region
        //try
        //{
        //    System.Data.OracleClient.OracleConnection con = new System.Data.OracleClient.OracleConnection(ConnectionString);
        //    con.Open();
        //    System.Data.OracleClient.OracleCommand cmd = new System.Data.OracleClient.OracleCommand();
        //    cmd.CommandText = "sp_raw_DATALOAD1";
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.Add("p_company_code", OracleType.VarChar, 2000).Value = Company_code;
        //    cmd.Parameters.Add("P_CONF_ID", OracleType.VarChar, 2000).Value = ConfID;
        //    cmd.Parameters.Add("P_FILE_NAME", OracleType.VarChar, 2000).Value = FielName;
        //    int result = cmd.ExecuteNonQuery();
        //    con.Close();
        //    retval = "Data successfully Processed.";
        //}
        //catch (Exception ex)
        //{
        //    retval = ex.Message;
        //}
        #endregion
        return retval;
    }
    public string DataPublishTrans(int count, DataTable dt, string Company_code, string FielName, string User_ID, string type)
    {
        string retval = "";
        string[] retCount = new string[count];
        try
        {
            string[] arr_company_Code = new string[count];
            string[] arr_FielName = new string[count];
            string[] P_Trans_type = new string[count];
            string[] P_Rowid = new string[count];
            string[] p_bank_code = new string[count];
            string[] p_branch_code = new string[count];
            string[] P_Userid = new string[count];
            string[] P_type = new string[count];
            int[] arrSize = new int[count];
            for (int i = 0; i < count; i++)
            {
                arrSize[i] = 1000;
                arr_company_Code[i] = Company_code;
                arr_FielName[i] = FielName;
                P_Trans_type[i] = dt.Rows[i]["TRANS_TYPE"].ToString();
                P_Rowid[i] = dt.Rows[i]["ROWID"].ToString();

                p_bank_code[i] = "";
                p_branch_code[i] = "";
                P_Userid[i] = User_ID;
                P_type[i] = type;
            }
            Oracle.DataAccess.Client.OracleConnection conn = new Oracle.DataAccess.Client.OracleConnection(ConnectionString);
            conn.Open();
            Oracle.DataAccess.Client.OracleTransaction trans = conn.BeginTransaction();
            Oracle.DataAccess.Client.OracleCommand cmd = conn.CreateCommand();
            cmd.CommandText = "sp_Data_Publish";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.BindByName = true;
            cmd.ArrayBindCount = count;

            cmd.Parameters.Add("P_company_code", OracleDbType.Varchar2, arr_company_Code, ParameterDirection.Input);
            cmd.Parameters.Add("P_FILE_NAME", OracleDbType.Varchar2, arr_FielName, ParameterDirection.Input);
            cmd.Parameters.Add("P_Trans_type", OracleDbType.Varchar2, P_Trans_type, ParameterDirection.Input);
            cmd.Parameters.Add("P_Rowid", OracleDbType.Varchar2, P_Rowid, ParameterDirection.Input);
            cmd.Parameters.Add("p_bank_code", OracleDbType.Varchar2, p_bank_code, ParameterDirection.Input);
            cmd.Parameters.Add("p_branch_code", OracleDbType.Varchar2, p_branch_code, ParameterDirection.Input);
            cmd.Parameters.Add("P_Userid", OracleDbType.Varchar2, P_Userid, ParameterDirection.Input);
            cmd.Parameters.Add("P_type", OracleDbType.Varchar2, P_type, ParameterDirection.Input);
            cmd.Parameters.Add("v_retval", OracleDbType.Varchar2, "", ParameterDirection.Output).ArrayBindSize = arrSize;
            #region
            int result = cmd.ExecuteNonQuery();
            for (int i = 0; i < count; i++)
            {
                retCount[i] = ((Oracle.DataAccess.Types.OracleString[])(cmd.Parameters["v_retval"].Value))[i].ToString();
                if (retCount[i].ToString().StartsWith("04") == false)
                {
                    trans.Rollback();
                    conn.Close();
                    return retCount[i];
                }
            }
            string val = postLeadger(arr_company_Code[0], arr_FielName[0], P_Trans_type[0], P_Rowid[0], p_bank_code[0],
                p_branch_code[0], P_Userid[0], "14");
            if (val.StartsWith("04"))
            {
                trans.Commit();
                conn.Close();
                //CoreBankingPoolCall(arr_company_Code[0], arr_FielName[0], P_Userid[0]);
                retval = retCount[0];
            }
            else
            {
                trans.Rollback();
                conn.Close();
                return val;
            }
            #endregion
        }
        catch (Exception ex)
        {
            retval = ex.Message;
        }
        return retval;
    }
    public string postLeadger(string arr_company_Code, string arr_FileName, string arr_trans_type,
    string arr_Rowid, string arr_bank_code, string arr_branch_code, string arr_Userid, string arr_type)
    {
        string p_return = "";
        try
        {
            int[] arrSize = new int[1];
            arrSize[0] = 1000;
            string[] p_empno = new string[1];
            string[] p_company_code = new string[1];
            p_company_code[0] = arr_company_Code;
            string[] p_file_name = new string[1];
            p_file_name[0] = arr_FileName;
            string[] p_trans_type = new string[1];
            p_trans_type[0] = arr_trans_type;
            string[] p_rowid = new string[1];
            p_rowid[0] = arr_Rowid;
            string[] p_bank_code = new string[1];
            p_bank_code[0] = arr_bank_code;
            string[] p_branch_code = new string[1];
            p_branch_code[0] = arr_branch_code;
            string[] p_userid = new string[1];
            p_userid[0] = arr_Userid;
            string[] p_type = new string[1];
            p_type[0] = arr_type;

            Oracle.DataAccess.Client.OracleConnection conn = new Oracle.DataAccess.Client.OracleConnection(ConnectionString);
            conn.Open();
            Oracle.DataAccess.Client.OracleCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SP_Data_Segregation";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.BindByName = true;
            cmd.ArrayBindCount = 1;

            cmd.Parameters.Add("P_company_code", OracleDbType.Varchar2, p_company_code, ParameterDirection.Input);
            cmd.Parameters.Add("P_FILE_NAME", OracleDbType.Varchar2, p_file_name, ParameterDirection.Input);
            cmd.Parameters.Add("P_Trans_type", OracleDbType.Varchar2, p_trans_type, ParameterDirection.Input);
            cmd.Parameters.Add("P_Rowid", OracleDbType.Varchar2, p_rowid, ParameterDirection.Input);
            cmd.Parameters.Add("p_bank_code", OracleDbType.Varchar2, p_bank_code, ParameterDirection.Input);
            cmd.Parameters.Add("p_branch_code", OracleDbType.Varchar2, p_branch_code, ParameterDirection.Input);
            cmd.Parameters.Add("P_Userid", OracleDbType.Varchar2, p_userid, ParameterDirection.Input);
            cmd.Parameters.Add("P_type", OracleDbType.Varchar2, p_type, ParameterDirection.Input);
            cmd.Parameters.Add("DATA_RESULTSET", OracleDbType.RefCursor, "", ParameterDirection.Output).ArrayBindSize = arrSize;
            cmd.Parameters.Add("v_retval", OracleDbType.Varchar2, "", ParameterDirection.Output).ArrayBindSize = arrSize;
            int result = cmd.ExecuteNonQuery();
            p_return = ((Oracle.DataAccess.Types.OracleString[])(cmd.Parameters["v_retval"].Value))[0].ToString();
            #region
            /*string v_return = "";
            OracleParameter[] parm = new OracleParameter[10];
            int pno = 0;
            parm[pno] = new OracleParameter();
            parm[pno] = _dbConfig.Oracle_Param("P_company_code", OracleType.VarChar, ParameterDirection.Input, ddlCompanyCode.SelectedValue.ToString());
            pno++;
            parm[pno] = new OracleParameter();
            parm[pno] = _dbConfig.Oracle_Param("P_FILE_NAME", OracleType.VarChar, ParameterDirection.Input, ddlFile.SelectedValue.ToString());
            pno++;
            parm[pno] = new OracleParameter();
            parm[pno] = _dbConfig.Oracle_Param("P_Trans_type", OracleType.VarChar, ParameterDirection.Input, "");
            pno++;
            parm[pno] = new OracleParameter();
            parm[pno] = _dbConfig.Oracle_Param("P_Rowid", OracleType.VarChar, ParameterDirection.Input, "");
            pno++;
            parm[pno] = new OracleParameter();
            parm[pno] = _dbConfig.Oracle_Param("p_bank_code", OracleType.VarChar, ParameterDirection.Input, "");
            pno++;
            parm[pno] = new OracleParameter();
            parm[pno] = _dbConfig.Oracle_Param("p_branch_code", OracleType.VarChar, ParameterDirection.Input, "");
            pno++;
            parm[pno] = new OracleParameter();
            parm[pno] = _dbConfig.Oracle_Param("P_Userid", OracleType.VarChar, ParameterDirection.Input, Session["U_NAME"].ToString());
            pno++;
            parm[pno] = new OracleParameter();
            parm[pno] = _dbConfig.Oracle_Param("P_type", OracleType.VarChar, ParameterDirection.Input, "14");
            pno++;
            parm[pno] = new OracleParameter();
            parm[pno] = _dbConfig.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
            pno++;
            parm[pno] = new OracleParameter();
            parm[pno] = _dbConfig.Oracle_Param("v_retval", OracleType.VarChar, ParameterDirection.Output, "");

            v_return = _dbConfig.TransSPOracle_GetReturnStringVal1(conn, tran, "SP_Data_Segregation", parm, pno);
            lblMessage.Text = v_return.Split(',').GetValue(1).ToString();
            return v_return;*/
            #endregion
        }
        catch (Exception ex)
        {
            p_return = ex.Message;
        }
        return p_return;
    }
    //public string CoreBankingPoolCall(string arr_company_code, string arr_file_name, string arr_userid)
    //{
    //    try
    //    {
    //        string[] p_company_code = new string[1];
    //        p_company_code[0] = arr_company_code;
    //        string[] p_file_name = new string[1];
    //        p_file_name[0] = arr_file_name;
    //        string[] p_userid = new string[1];
    //        p_userid[0] = arr_userid;
    //        int[] arrSize = new int[1];
    //        arrSize[0] = 1000;

    //        Oracle.DataAccess.Client.OracleConnection conn = new Oracle.DataAccess.Client.OracleConnection(ConnectionString);
    //        conn.Open();
    //        Oracle.DataAccess.Client.OracleCommand cmd = conn.CreateCommand();
    //        cmd.CommandText = "corebank_system_sym_pub";
    //        cmd.CommandType = CommandType.StoredProcedure;
    //        cmd.BindByName = true;
    //        cmd.ArrayBindCount = 1;

    //        cmd.Parameters.Add("p_company_code", OracleDbType.Varchar2, p_company_code, ParameterDirection.Input);
    //        cmd.Parameters.Add("p_file_name", OracleDbType.Varchar2, p_file_name, ParameterDirection.Input);
    //        cmd.Parameters.Add("p_userid", OracleDbType.Varchar2, p_userid, ParameterDirection.Input);
    //        cmd.Parameters.Add("p_retval", OracleDbType.Varchar2, "", ParameterDirection.Output).ArrayBindSize = arrSize;
    //        int result = cmd.ExecuteNonQuery();
    //        string p_return = ((Oracle.DataAccess.Types.OracleString[])(cmd.Parameters["p_retval"].Value))[0].ToString();
    //    }
    //    catch (Exception ex)
    //    {
    //        return ex.Message;
    //    }
    //    return "";
    //}
    public string force_updation(GridView gv, string User_ID, string type, int count, string company_code, string file_name)
    {
        string retval = "";
        string[] retCount;
        try
        {
            int updateCount = 0;
            string[] arr = new string[count];
            int m = 0;
            for (int i = 0; i < count; i++)
            {
                //if (((HiddenField)gv.Rows[i].FindControl("hf_BranchCode")).Value != "" && ((TextBox)gv.Rows[i].FindControl("txtaccountno_symbol")).Text != "")
                if (((TextBox)gv.Rows[i].FindControl("txtBranchCode")).Text != "Branch not found" &&
                    ((TextBox)gv.Rows[i].FindControl("txtBranchCode")).Text != "" &&
                    ((TextBox)gv.Rows[i].FindControl("txtaccountno_symbol")).Text != "" &&
                    //((TextBox)gv.Rows[i].FindControl("txtSymbolTitle")).Text != "Account Title not found." &&
                    ((TextBox)gv.Rows[i].FindControl("txtSymbolTitle")).Text != "Symbol Title" &&
                    ((TextBox)gv.Rows[i].FindControl("txtSymbolTitle")).Text != "")
                {
                    arr[i] = m.ToString();
                    updateCount++;
                }
                else
                {
                    arr[i] = "N";
                }
                m++;
            }
            string[] p_Rowid = new string[updateCount];
            string[] p_branch_code = new string[updateCount];
            string[] p_Account_no = new string[updateCount];
            string[] p_benename = new string[updateCount];
            string[] P_Userid = new string[updateCount];
            string[] P_type = new string[updateCount];
            string[] P_company_code = new string[updateCount];
            string[] p_file_name = new string[updateCount];
            int[] arrSize = new int[updateCount];
            retCount = new string[updateCount];

            int u = 0;
            for (int i = 0; i < count; i++)
            {
                if (arr[i].ToString() != "N")
                {
                    arrSize[u] = 1000;
                    p_Rowid[u] = gv.Rows[i].Cells[0].Text;
                    //p_branch_code[u] = (((HiddenField)gv.Rows[Convert.ToInt32(arr[i])].FindControl("hf_BranchCode")).Value == "" ? gv.Rows[i].Cells[3].Text : ((HiddenField)gv.Rows[i].FindControl("hf_BranchCode")).Value);
                    p_branch_code[u] = (((TextBox)gv.Rows[Convert.ToInt32(arr[i])].FindControl("txtBranchCode")).Text == "" ? gv.Rows[i].Cells[3].Text : ((TextBox)gv.Rows[i].FindControl("txtBranchCode")).Text);
                    p_Account_no[u] = (((TextBox)gv.Rows[Convert.ToInt32(arr[i])].FindControl("txtaccountno_symbol")).Text == "" ? gv.Rows[i].Cells[1].Text : ((TextBox)gv.Rows[i].FindControl("txtaccountno_symbol")).Text);
                    p_benename[u] = ((TextBox)gv.Rows[Convert.ToInt32(arr[i])].FindControl("txtSymbolTitle")).Text;
                    //(((TextBox)gv.Rows[Convert.ToInt32(arr[i])].FindControl("txtSymbolTitle")).Text == "" ? gv.Rows[i].Cells[1].Text : ((TextBox)gv.Rows[i].FindControl("txtaccountno_symbol")).Text);
                    P_Userid[u] = User_ID;
                    P_type[u] = type;
                    P_company_code[u] = company_code;
                    p_file_name[u] = file_name;
                    u++;
                }
            }
            if (p_Rowid.Length > 0)
            {
                Oracle.DataAccess.Client.OracleConnection conn = new Oracle.DataAccess.Client.OracleConnection(ConnectionString);
                conn.Open();
                Oracle.DataAccess.Client.OracleTransaction trans = conn.BeginTransaction();
                Oracle.DataAccess.Client.OracleCommand cmd = conn.CreateCommand();
                cmd.CommandText = "sp_force_Updation";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.BindByName = true;
                cmd.ArrayBindCount = updateCount;

                cmd.Parameters.Add("p_rowid", OracleDbType.Varchar2, p_Rowid, ParameterDirection.Input);
                cmd.Parameters.Add("p_branch_code", OracleDbType.Varchar2, p_branch_code, ParameterDirection.Input);
                cmd.Parameters.Add("p_Account_no", OracleDbType.Varchar2, p_Account_no, ParameterDirection.Input);
                cmd.Parameters.Add("p_benename", OracleDbType.Varchar2, p_benename, ParameterDirection.Input);
                cmd.Parameters.Add("P_Userid", OracleDbType.Varchar2, P_Userid, ParameterDirection.Input);
                cmd.Parameters.Add("P_type", OracleDbType.Varchar2, P_type, ParameterDirection.Input);
                cmd.Parameters.Add("p_company_code", OracleDbType.Varchar2, P_company_code, ParameterDirection.Input);
                cmd.Parameters.Add("p_file_name", OracleDbType.Varchar2, p_file_name, ParameterDirection.Input);
                cmd.Parameters.Add("p_retval", OracleDbType.Varchar2, "", ParameterDirection.Output).ArrayBindSize = arrSize;
                int result = cmd.ExecuteNonQuery();
                for (int i = 0; i < updateCount; i++)
                {
                    retCount[i] = ((Oracle.DataAccess.Types.OracleString[])(cmd.Parameters["p_retval"].Value))[i].ToString();
                    if (retCount[i].ToString().StartsWith("0") == true) //Error
                    {
                        trans.Rollback();
                        conn.Close();
                        return retCount[i];
                    }
                }
                trans.Commit();
                conn.Close();
                retval = retCount[0];
            }
        }
        catch (Exception ex)
        {
            retval = "0;" + ex.Message;
        }
        return retval;
    }
    public string A2ATransaction(int count, string companyCode, string fileName, GridView gv)
    {
        string retval = "";
        string[] retCount = new string[count];
        try
        {
            string[] p_company_code = new string[1];
            string[] p_filename = new string[1];
            string[] p_row_id = new string[1];
            int[] arrSize = new int[1];
            int y = 0;
            for (int i = 0; i < count; i++)
            {
                CheckBox cb = ((CheckBox)gv.Rows[i].FindControl("cbPublish"));
                if (((CheckBox)gv.Rows[i].FindControl("cbPublish")).Checked == true)
                {
                    /*arrSize[i] = 1000;
                    p_company_code[i] = companyCode;
                    p_filename[i] = fileName;
                    p_row_id[i] = gv.Rows[i].Cells[0].Text;*/

                    Array.Resize(ref arrSize, y + 1);
                    arrSize[y] = 1000;
                    Array.Resize(ref p_company_code, y + 1);
                    p_company_code[y] = companyCode;
                    Array.Resize(ref p_filename, y + 1);
                    p_filename[y] = fileName;
                    Array.Resize(ref p_row_id, y + 1);
                    p_row_id[y] = gv.Rows[i].Cells[0].Text;
                    y++;
                }
            }
            count = y;
            Oracle.DataAccess.Client.OracleConnection conn = new Oracle.DataAccess.Client.OracleConnection(ConnectionString);
            conn.Open();
            Oracle.DataAccess.Client.OracleCommand cmd = conn.CreateCommand();
            cmd.CommandText = "corebank_system_int_symbol";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.BindByName = true;
            cmd.ArrayBindCount = count;
            cmd.Parameters.Add("p_company_code", OracleDbType.Varchar2, p_company_code, ParameterDirection.Input);
            cmd.Parameters.Add("p_file_name", OracleDbType.Varchar2, p_filename, ParameterDirection.Input);
            cmd.Parameters.Add("p_row_id", OracleDbType.Varchar2, p_row_id, ParameterDirection.Input);
            cmd.Parameters.Add("p_retval", OracleDbType.Varchar2, "", ParameterDirection.Output).ArrayBindSize = arrSize;
            int result = cmd.ExecuteNonQuery();
            for (int i = 0; i < count; i++)
            {
                retCount[i] = ((Oracle.DataAccess.Types.OracleString[])(cmd.Parameters["p_retval"].Value))[i].ToString();
                if (retCount[i].ToString().StartsWith("1") == false)
                {
                    return retCount[i];
                }
            }
            retval = retCount[0];
        }
        catch (Exception ex)
        {
            retval = ex.Message;
        }
        return retval;
    }
    public string[] CustomerFindingUpload(int count, string Userid, DataTable dt,string batch_no,out string val)
    {
        string retval = "";
        string[] retmsg = new string[count];
        string[] retCount = new string[count];
        Oracle.DataAccess.Client.OracleConnection conn = null;
        try
        {
            #region
            string[] p_company_code = new string[count];
            string[] p_value_date = new string[count];
            string[] p_amount = new string[count];
            string[] p_control_no = new string[count];
            string[] p_dated = new string[count];
            string[] p_narration = new string[count];
            string[] p_ref1 = new string[count];
            string[] p_ref2 = new string[count];
            string[] p_ref3 = new string[count];
            string[] p_ref4 = new string[count];
            string[] p_ref5 = new string[count];
            string[] p_ref6 = new string[count];
            string[] p_userid = new string[count];
            string[] p_retval = new string[count];
            string[] p_batch_no = new string[count];
            int[] arrSize = new int[count];

            for (int i = 0; i < count; i++)
            {
                p_company_code[i] = dt.Rows[i][0].ToString();
                p_value_date[i] = dt.Rows[i][1].ToString();
                p_amount[i] = dt.Rows[i][2].ToString();
                p_control_no[i] = dt.Rows[i][3].ToString();
                p_dated[i] = dt.Rows[i][4].ToString();
                p_narration[i] = dt.Rows[i][5].ToString();
                p_ref1[i] = dt.Rows[i][6].ToString();
                p_ref2[i] = dt.Rows[i][7].ToString();
                p_ref3[i] = dt.Rows[i][8].ToString();
                p_ref4[i] = dt.Rows[i][9].ToString();
                p_ref5[i] = dt.Rows[i][10].ToString();
                p_ref6[i] = dt.Rows[i][11].ToString();
                p_userid[i] = Userid;
                p_batch_no[i] = batch_no;
                arrSize[i] = 1000;
            }
            #endregion
            #region
            conn = new Oracle.DataAccess.Client.OracleConnection(ConnectionString);
            Oracle.DataAccess.Client.OracleCommand cmd = conn.CreateCommand();
            cmd.CommandText = "sp_cust_funding_upload";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.BindByName = true;
            cmd.ArrayBindCount = count;
            cmd.Parameters.Add("p_company_code", OracleDbType.Varchar2, p_company_code, ParameterDirection.Input);
            cmd.Parameters.Add("p_value_date", OracleDbType.Varchar2, p_value_date, ParameterDirection.Input);
            cmd.Parameters.Add("p_amount", OracleDbType.Varchar2, p_amount, ParameterDirection.Input);
            cmd.Parameters.Add("p_control_no", OracleDbType.Varchar2, p_control_no, ParameterDirection.Input);
            cmd.Parameters.Add("p_dated", OracleDbType.Varchar2, p_dated, ParameterDirection.Input);
            cmd.Parameters.Add("p_narration", OracleDbType.Varchar2, p_narration, ParameterDirection.Input);
            cmd.Parameters.Add("p_ref1", OracleDbType.Varchar2, p_ref1, ParameterDirection.Input);
            cmd.Parameters.Add("p_ref2", OracleDbType.Varchar2, p_ref2, ParameterDirection.Input);
            cmd.Parameters.Add("p_ref3", OracleDbType.Varchar2, p_ref3, ParameterDirection.Input);
            cmd.Parameters.Add("p_ref4", OracleDbType.Varchar2, p_ref4, ParameterDirection.Input);
            cmd.Parameters.Add("p_ref5", OracleDbType.Varchar2, p_ref5, ParameterDirection.Input);
            cmd.Parameters.Add("p_ref6", OracleDbType.Varchar2, p_ref6, ParameterDirection.Input);
            cmd.Parameters.Add("p_userid", OracleDbType.Varchar2, p_userid, ParameterDirection.Input);
            cmd.Parameters.Add("p_batch_no", OracleDbType.Varchar2, p_batch_no, ParameterDirection.Input);
            cmd.Parameters.Add("p_retval", OracleDbType.Varchar2, p_retval, ParameterDirection.Output).ArrayBindSize = arrSize;
            #endregion
            conn.Open();
            int result = cmd.ExecuteNonQuery();
            conn.Close();
            for (int i = 0; i < count; i++)
            {
                retCount[i] = ((Oracle.DataAccess.Types.OracleString[])(cmd.Parameters["p_retval"].Value))[i].ToString();
            }
            val = "0;File successfully uploaded.";
        }
        catch (Exception ex)
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            val = "1;" + ex.Message;
        }
        return retCount;
    }
    //public string BulkCancelationProcess(DataTable dt, string tableName)
    public string BulkCancelationProcess(int count, string[] arr_Company_code, string[] arr_xpin, string[] arr_Filename, int[] arrSize, string sp_name)
    {
        //OracleBulkCopy obj = new OracleBulkCopy(ConnectionString);
        string retval = "";
        try
        {
            #region
            //obj.BulkCopyTimeout = 10000;
            //obj.DestinationTableName = tableName;
            //obj.Connection.Open();
            //obj.WriteToServer(dt);
            //retval = "0;File successfully Uploaded.";
            #endregion
            Oracle.DataAccess.Client.OracleConnection ocnn = new Oracle.DataAccess.Client.OracleConnection(ConnectionString);
            ocnn.Open();
            Oracle.DataAccess.Client.OracleCommand ocmd = ocnn.CreateCommand();
            ocmd.CommandText = sp_name;// "sp_bulk_cancel_detail";
            ocmd.CommandType = CommandType.StoredProcedure;
            ocmd.BindByName = true;
            ocmd.ArrayBindCount = count;
            ocmd.Parameters.Add("p_company_code", OracleDbType.Varchar2, arr_Company_code, ParameterDirection.Input);
            ocmd.Parameters.Add("p_xpin", OracleDbType.Varchar2, arr_xpin, ParameterDirection.Input);
            ocmd.Parameters.Add("p_file_name", OracleDbType.Varchar2, arr_Filename, ParameterDirection.Input);
            ocmd.Parameters.Add("p_retval", OracleDbType.Varchar2, "", ParameterDirection.Output).ArrayBindSize = arrSize;
            int result = ocmd.ExecuteNonQuery();
            ocnn.Close();
            retval = ((Oracle.DataAccess.Types.OracleString[])(ocmd.Parameters["p_retval"].Value))[0].ToString();
        }
        catch (Exception ex)
        {
            retval = "1;" + ex.Message;
        }
        //obj.Connection.Close();
        return retval;
    }





}



//Array.Resize(ref arrSize, y + 1);
//arrSize[y] = 1000;
//Array.Resize(ref p_company_code, y + 1);
//p_company_code[y] = dt.Rows[i][0].ToString();
//Array.Resize(ref p_amount, y + 1);
//p_amount[y] = dt.Rows[i][1].ToString();
//Array.Resize(ref p_dollar_rate, y + 1);
//p_dollar_rate[y] = dt.Rows[i][2].ToString();
//Array.Resize(ref p_remarks, y + 1);
//p_remarks[y] = dt.Rows[i][3].ToString();
//Array.Resize(ref p_reference, y + 1);
//p_reference[y] = dt.Rows[i][4].ToString();
//Array.Resize(ref p_userid, y + 1);
//p_userid[y] = Userid;
//y++;
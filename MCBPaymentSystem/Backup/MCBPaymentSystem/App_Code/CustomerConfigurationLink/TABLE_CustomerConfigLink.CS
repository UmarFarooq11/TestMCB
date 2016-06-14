using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OracleClient;

public class TABLE_CustomerConfigLink : ICMN_CustomerConfigLink
{
    private string ID;
    private string COMPANY_CODE;
    private string CONF_DEF_ID;
    private string FTP_LOADPATH;
    private string FTP_USERID;
    private string FTP_PASSWORD;
    private string FTP_MOVEPATH;
    private string FTP_MOVE_USERID;
    private string FTP_MOVE_PASSWORD;
    private string FTP_TYPE;
    private string FTP_PORT;

    DatabaseConnection_Util DataTransform = new DatabaseConnection_Util();

    private DataSet CustConfigLink_DATASET = new DataSet();
    private DataRow DR;
    public TABLE_CustomerConfigLink()
    {
        //CMN_Currency_DATASET = DataTransform.ReteriveDataMultiple
        //        ("EXEC SP_GET_TABLE_STRUCT CMN_Currency", "NEW_USER_INFO");


        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("P_TABLE_NAME", OracleType.VarChar, ParameterDirection.Input, "customer_conf_link");
        PR[1] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        CustConfigLink_DATASET = DataTransform.Oracle_GetDataSetSP("SP_GET_TABLE_STRUCT", PR);


    }
    public void RecordInputStart()
    { DR = CustConfigLink_DATASET.Tables[0].NewRow(); }
    public void RecordInputCommit()
    { CustConfigLink_DATASET.Tables[0].Rows.Add(DR); }
    public DataSet ReturnResultSet()
    { return CustConfigLink_DATASET; }
    public void ClearTable()
    { CustConfigLink_DATASET.Tables[0].Rows.Clear(); }
    public string Get_ID
    {
        set
        {
            ID = value;
            DataTransform.DataPlacement("ID", ID, CustConfigLink_DATASET, DR);
        }
    }
    public string Get_COMPANY_CODE
    {
        set
        {
            COMPANY_CODE = value;
            DataTransform.DataPlacement("COMPANY_CODE", COMPANY_CODE, CustConfigLink_DATASET, DR);
        }
    }
    public string Get_CONF_DEF_ID
    {
        set
        {
            CONF_DEF_ID = value;
            DataTransform.DataPlacement("CONF_DEF_ID", CONF_DEF_ID, CustConfigLink_DATASET, DR);
        }
    }
    /*--------------------------------*/
    public string Get_FTP_LOADPATH
    {
        set
        {
            FTP_LOADPATH = value;
            DataTransform.DataPlacement("FTP_LOADPATH", FTP_LOADPATH, CustConfigLink_DATASET, DR);
        }
    }
    public string Get_FTP_USERID
    {
        set
        {
            FTP_USERID = value;
            DataTransform.DataPlacement("FTP_USERID", FTP_USERID, CustConfigLink_DATASET, DR);
        }
    }
    public string Get_FTP_PASSWORD
    {
        set
        {
            FTP_PASSWORD = value;
            DataTransform.DataPlacement("FTP_PASSWORD", FTP_PASSWORD, CustConfigLink_DATASET, DR);
        }
    }
    public string Get_FTP_MOVEPATH
    {
        set
        {
            FTP_MOVEPATH = value;
            DataTransform.DataPlacement("FTP_MOVEPATH", FTP_MOVEPATH, CustConfigLink_DATASET, DR);
        }
    }
    public string Get_FTP_MOVE_USERID
    {
        set
        {
            FTP_MOVE_USERID = value;
            DataTransform.DataPlacement("FTP_MOVE_USERID", FTP_MOVE_USERID, CustConfigLink_DATASET, DR);
        }
    }
    public string Get_FTP_MOVE_PASSWORD
    {
        set
        {
            FTP_MOVE_PASSWORD = value;
            DataTransform.DataPlacement("FTP_MOVE_PASSWORD", FTP_MOVE_PASSWORD, CustConfigLink_DATASET, DR);
        }
    }
    public string Get_FTP_TYPE
    {
        set
        {
            FTP_TYPE = value;
            DataTransform.DataPlacement("FTP_TYPE", FTP_TYPE, CustConfigLink_DATASET, DR);
        }
    }
    public string Get_FTP_PORT
    {
        set
        {
            FTP_PORT = value;
            DataTransform.DataPlacement("FTP_PORT", FTP_PORT, CustConfigLink_DATASET, DR);
        }
    }



}

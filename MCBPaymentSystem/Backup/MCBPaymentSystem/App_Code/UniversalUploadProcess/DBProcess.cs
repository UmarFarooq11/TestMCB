using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.OracleClient;

/// <summary>
/// Summary description for DBProcess
/// </summary>
public class DBProcess
{
    DatabaseConnection_Util DataTransform = new DatabaseConnection_Util();
    private DataSet ds = new DataSet();
    private DataRow dr;
    private string Company_Code;
    private string Conf_ID;
    private string FileName;
    private string UserID;
    private string TOTAL_RECORDS;

	public DBProcess()
	{
        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("P_TABLE_NAME", OracleType.VarChar, ParameterDirection.Input, "filelog");
        PR[1] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        ds = DataTransform.Oracle_GetDataSetSP("SP_GET_TABLE_STRUCT", PR);
	}
    public void RecordInputStart()
    { dr = ds.Tables[0].NewRow(); }
    public void RecordInputCommit()
    { 
        ds.Tables[0].Rows.Add(dr); 
    }
    public void ClearTable()
    { 
        ds.Tables[0].Rows.Clear(); 
    }
    public void AddNewGroup()
    { 
        NaviOP("sp_filelog_insert"); 
    }
    private void NaviOP(string SP)
    {
        DataSet DS = new DataSet();
        DataSet RETURN_DS = new DataSet();
        DataTable DT = new DataTable();
        DS = ReturnResultSet();
        RETURN_DS = DataTransform.StoredProcedurePlacement(DS, SP);
        DT = DataTransform.SavingData(RETURN_DS, SP);
        ClearTable();
    }
    public DataSet ReturnResultSet()
    { 
        return ds; 
    }
    public string Get_Company_Code
    {
        set
        {
            Company_Code = value;
            DataTransform.DataPlacement("COMPANY_CODE", Company_Code, ds, dr);
        }
    }
    public string Get_Conf_ID
    {
        set
        {
            Conf_ID = value;
            DataTransform.DataPlacement("CONF_ID", Conf_ID, ds, dr);
        }
    }
    public string Get_FileName
    {
        set
        {
            FileName = value;
            DataTransform.DataPlacement("FILE_NAME", FileName, ds, dr);
        }
    }
    public string Get_UserID
    {
        set
        {
            UserID = value;
            DataTransform.DataPlacement("USERID", UserID, ds, dr);
        }
    }
    public string Get_TOTAL_RECORDS
    {
        set
        {
            TOTAL_RECORDS = value;
            DataTransform.DataPlacement("TOTAL_RECORDS", TOTAL_RECORDS, ds, dr);
        }
    }
    
}

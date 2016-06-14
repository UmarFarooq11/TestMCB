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
using System.Data.OleDb;

/// <summary>
/// Summary description for ReportClass
/// </summary>
public static class RDLCReportClass
{
    static DatabaseConnection_Util DataTransform;
     //= new DatabaseConnection_Util();
    
    //public DataSet BalancesSummaryOfAgents()
    //{
    //    OracleParameter[] PR = new OracleParameter[1];
    //    //PR[0] = DataTransform.Oracle_Param("v_FromDate", OracleType.VarChar, ParameterDirection.Input, FromDate);
    //    //PR[1] = DataTransform.Oracle_Param("v_ToDate", OracleType.VarChar, ParameterDirection.Input, ToDate);
    //    PR[0] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
    //    DataSet DS = DataTransform.Oracle_GetDataSetSP("SP_BalancesSummaryOfAgents_rpt", PR);
    //    return DS;
    //}

    //public DataSet CompanyBalance()
    //{
    //    DataSet dsResult = null;
    //    OracleParameter[] param = new OracleParameter[1];
    //    try
    //    {
    //        param[0] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
    //        dsResult=  DataTransform.Oracle_GetDataSetSP("PAY_SP_RPTCOMPANYBALANCE", param);
    //    }
    //    catch (Exception ex) { }

    //    return dsResult;
    //}

    public static string GetOrgName()
    {
        string companyName = "";
        try
        {
            MCBReportClass RptObj = new MCBReportClass();
            DataSet dsReport = RptObj.Local_GetDataSetSP1("SP_SYSTEM_SETUP");
            if (dsReport.Tables[0].Rows.Count > 0)
            {
                companyName = dsReport.Tables[0].Rows[0]["company_name"].ToString();
            }
        }
        catch (Exception ex)
        { }
        return companyName;
    }

    public static string GetReportHeader(string reportCode)
    {
        string headingName = "";
        try
        {
            MCBReportClass RptObj = new MCBReportClass();
            OleDbParameter[] param = new OleDbParameter[1];

            param[0] = RptObj.OleDbParameter("@v_Report_Code", reportCode, "String", "In");

            DataSet dsReport = RptObj.Local_GetDataSetSP1("SP_REPORT_HEADER", param);
            if (dsReport.Tables[0].Rows.Count > 0)
            {
                headingName = dsReport.Tables[0].Rows[0]["HEADING1"].ToString();
            }
        }
        catch (Exception ex)
        { }
        return headingName;
    }
}

public class ReportHierarchy
{
    public enum CRPaymentReport
    {
        CompanyBalance = 1,
        DraftPrint = 2
    }
}
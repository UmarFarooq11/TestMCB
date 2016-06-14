using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Report;
using System.Data.OracleClient;
using Microsoft.Reporting.WebForms;
using System.Collections.Generic;

public partial class NRDetailStatementRpt : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string usr_name, fromDate, toDate;
        usr_name = Request.QueryString["usr_name"];
        fromDate = Request.QueryString["fromdate"];
        toDate = Request.QueryString["todate"];
        Generate(usr_name, fromDate, toDate);
    }
    private void Generate(string usr_name, string fromDate, string toDate)
    {
        ReportViewer1.Visible = true;
        try
        {
            DataTable temp = new DataTable();
            DataTable dt = new DataTable();
            temp = GetData(usr_name, fromDate, toDate);
            if (temp.Rows.Count > 0)
            {
                ReportDataSource rptDataSource = new ReportDataSource("MCB_DataSet_NRdetailStatement", temp);
                ReportViewer1.LocalReport.DataSources.Clear();
                List<ReportParameter> rpParameter = new List<ReportParameter>();
                rpParameter.Add(new ReportParameter("BankName", "MCB Bank Ltd."));
                rpParameter.Add(new ReportParameter("ReportName", "NR Detail Account Statement"));
                rpParameter.Add(new ReportParameter("From_Date", fromDate));
                rpParameter.Add(new ReportParameter("To_Date", toDate));
                ReportViewer1.LocalReport.DataSources.Add(rptDataSource);
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("NRDetailStatementReport.rdlc");
                ReportViewer1.DataBind();
                ReportViewer1.LocalReport.SetParameters(rpParameter);
                ReportViewer1.LocalReport.Refresh();
            }
            else
            {
                Response.Write("No Data Found");
            }
        }
        catch (Exception ex)
        {
            Response.Write("Exception is:" + ex);
        }
    }
    private DataTable GetData(string p_usr_name, string fromDate, string toDate)
    {
        MCBReportClass RptObj = new MCBReportClass();
        DataSet dsReport = new DataSet();
        OracleParameter[] parm = new OracleParameter[4];
        parm[0] = RptObj.OracleDBParameter("p_usr_name", p_usr_name, "String", "In");
        parm[1] = RptObj.OracleDBParameter("p_from_dt", fromDate, "String", "In");
        parm[2] = RptObj.OracleDBParameter("p_to_dt", toDate, "String", "In");
        parm[3] = RptObj.OracleDBParameter("data_set", "", "Cursor", "Out");
        dsReport = RptObj.Oracle_GetDataSetSP("sp_core_nr_ac_satmnt_rpt", parm);
        string totalstub = dsReport.Tables[0].Rows.Count.ToString();
        return dsReport.Tables[0];
    }
    //public string GetReportName()
    //{
    //    MCBReportClass RptObj = new MCBReportClass();
    //    DataSet dsReport = new DataSet();
    //    OracleParameter[] parm = new OracleParameter[2];
    //    parm[0] = RptObj.OracleDBParameter("v_Report_Code", "R10", "String", "In");
    //    parm[1] = RptObj.OracleDBParameter("DATA_RESULTSET", "", "Cursor", "Out");
    //    dsReport = RptObj.Oracle_GetDataSetSP("SP_REPORT_HEADER", parm);
    //    if (dsReport.Tables[0].Rows.Count > 0)
    //    {
    //        return dsReport.Tables[0].Rows[0][1].ToString();
    //    }
    //    return "";
    //}
    //public string GetBankName()
    //{
    //    MCBReportClass RptObj = new MCBReportClass();
    //    DataSet dsReport = new DataSet();
    //    OracleParameter[] parm = new OracleParameter[1];
    //    parm[0] = RptObj.OracleDBParameter("DATA_RESULTSET", "", "Cursor", "Out");
    //    dsReport = RptObj.Oracle_GetDataSetSP("SP_System_setup", parm);
    //    if (dsReport.Tables[0].Rows.Count > 0)
    //    {
    //        return dsReport.Tables[0].Rows[0][0].ToString();    
    //    }
    //    return "";
    //}
}

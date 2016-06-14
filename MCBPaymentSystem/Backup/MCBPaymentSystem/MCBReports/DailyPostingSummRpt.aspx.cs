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

public partial class DailyPostingSummRpt : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string CompanyName, TransType, AgentType, FromDate, ToDate;
        CompanyName = Request.QueryString["CompanyName"].ToString();
        TransType = Request.QueryString["TransType"].ToString();
        AgentType = Request.QueryString["AgentType"].ToString();
        FromDate = Request.QueryString["FromDate"].ToString();
        ToDate = Request.QueryString["ToDate"].ToString();
        Generate(CompanyName, TransType, AgentType, FromDate, ToDate);
    }
    private void Generate(string CompanyName, string TransType, string AgentType, string FromDate, string ToDate)
    {
        ReportViewer1.Visible = true;
        try
        {
            DataTable temp = new DataTable();
            DataTable dt = new DataTable();
            temp = GetData(CompanyName, TransType, AgentType, FromDate, ToDate);
            if (temp.Rows.Count > 0)
            {
                ReportDataSource rptDataSource = new ReportDataSource
                ("MCB_DataSet_DailyPostSumm", temp);
                ReportViewer1.LocalReport.DataSources.Clear();
                List<ReportParameter> rpParameter = new List<ReportParameter>();
                rpParameter.Add(new ReportParameter("CompanyName", CompanyName));
                rpParameter.Add(new ReportParameter("AgentType", AgentType));
                rpParameter.Add(new ReportParameter("FromDate", FromDate));
                rpParameter.Add(new ReportParameter("ToDate", ToDate));
                rpParameter.Add(new ReportParameter("TransType", TransType));

                rpParameter.Add(new ReportParameter("BankName", GetBankName()));
                rpParameter.Add(new ReportParameter("ReportName", GetReportName()));


                /*if (TransactionDate == "")
                {
                    rpParameter.Add(new ReportParameter("Report_Para_date", "All"));
                }
                else
                {
                    rpParameter.Add(new ReportParameter("Report_Para_date", TransactionDate));
                }*/
                ReportViewer1.LocalReport.DataSources.Add(rptDataSource);
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("DailyPostingSummReport.rdlc");
                ReportViewer1.DataBind();
                ReportViewer1.LocalReport.SetParameters(rpParameter);
                ReportViewer1.LocalReport.Refresh();
            }
            else
            {
                Response.Redirect("DailyPostingSummReport.aspx?IsRecord=" + "0" + "&msg=" + "No Record Found");
            }
        }
        catch (Exception ex)
        {
            Response.Write("Exception is:" + ex);
        }
    }
    private DataTable GetData(string CompanyName, string TransType, string AgentType, string FromDate, string ToDate)
    {
        MCBReportClass RptObj = new MCBReportClass();
        DataSet dsReport = new DataSet();
        OracleParameter[] parm = new OracleParameter[6];
        parm[0] = RptObj.OracleDBParameter("p_company_code", CompanyName, "String", "In");
        parm[1] = RptObj.OracleDBParameter("p_trans_type", TransType, "String", "In");
        parm[2] = RptObj.OracleDBParameter("p_COMPANY_TYPE", AgentType, "String", "In");
        parm[3] = RptObj.OracleDBParameter("p_from_dt", FromDate, "String", "In");
        parm[4] = RptObj.OracleDBParameter("p_to_dt", ToDate, "String", "In");
        parm[5] = RptObj.OracleDBParameter("dataset", "", "Cursor", "Out");
        dsReport = RptObj.Oracle_GetDataSetSP("sp_daily_post_summ_rpt", parm);
        string totalstub = dsReport.Tables[0].Rows.Count.ToString();
        return dsReport.Tables[0];
    }
    public string GetReportName()
    {
        MCBReportClass RptObj = new MCBReportClass();
        DataSet dsReport = new DataSet();
        OracleParameter[] parm = new OracleParameter[2];
        parm[0] = RptObj.OracleDBParameter("v_Report_Code", "R25", "String", "In");
        parm[1] = RptObj.OracleDBParameter("DATA_RESULTSET", "", "Cursor", "Out");
        dsReport = RptObj.Oracle_GetDataSetSP("SP_REPORT_HEADER", parm);
        if (dsReport.Tables[0].Rows.Count > 0)
        {
            return dsReport.Tables[0].Rows[0][1].ToString();
        }
        return "";
    }
    public string GetBankName()
    {
        MCBReportClass RptObj = new MCBReportClass();
        DataSet dsReport = new DataSet();
        OracleParameter[] parm = new OracleParameter[1];
        parm[0] = RptObj.OracleDBParameter("DATA_RESULTSET", "", "Cursor", "Out");
        dsReport = RptObj.Oracle_GetDataSetSP("SP_System_setup", parm);
        if (dsReport.Tables[0].Rows.Count > 0)
        {
            return dsReport.Tables[0].Rows[0][0].ToString();
        }
        return "";
    }

}

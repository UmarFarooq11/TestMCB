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

public partial class SBPRebateSummRpt : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string FromDate, ToDate, USRate, fc_saudiRiyal, CompanyName;
        FromDate = Request.QueryString["FromDate"].ToString();
        ToDate = Request.QueryString["ToDate"].ToString();
        USRate = Request.QueryString["USRate"].ToString();
        fc_saudiRiyal = Request.QueryString["fc_saudiRiyal"].ToString();
        CompanyName = Request.QueryString["CompanyName"].ToString();
        Generate(FromDate, ToDate, USRate, fc_saudiRiyal, CompanyName);
    }
    private void Generate(string FromDate, string ToDate, string USRate, string fc_saudiRiyal, string CompanyName)
    {
        ReportViewer1.Visible = true;
        try
        {
            DataTable temp = new DataTable();
            DataTable dt = new DataTable();
            temp = GetData(FromDate, ToDate, USRate, fc_saudiRiyal, CompanyName);
            if (temp.Rows.Count > 0)
            {
                ReportDataSource rptDataSource = new ReportDataSource
                ("MCB_DataSet_SBPRebSummaryRpt", temp);
                ReportViewer1.LocalReport.DataSources.Clear();
                List<ReportParameter> rpParameter = new List<ReportParameter>();
                rpParameter.Add(new ReportParameter("FromDate", FromDate));
                rpParameter.Add(new ReportParameter("ToDate", ToDate));
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
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("SBPRebateSummReport.rdlc");
                ReportViewer1.DataBind();
                ReportViewer1.LocalReport.SetParameters(rpParameter);
                ReportViewer1.LocalReport.Refresh();
            }
            else
            {
                Response.Redirect("SBPRebateSummReport.aspx?IsRecord=" + "0" + "&msg=" + "No Record Found");
            }
        }
        catch (Exception ex)
        {
            Response.Write("Exception is:" + ex);
        }
    }
    private DataTable GetData(string FromDate, string ToDate, string USRate, string fc_saudiRiyal, string CompanyName)
    {
        MCBReportClass RptObj = new MCBReportClass();
        DataSet dsReport = new DataSet();
        OracleParameter[] parm = new OracleParameter[6];
        parm[0] = RptObj.OracleDBParameter("p_from_date", FromDate, "String", "In");
        parm[1] = RptObj.OracleDBParameter("p_to_date", ToDate, "String", "In");
        parm[2] = RptObj.OracleDBParameter("p_us_rate", USRate, "Double", "In");
        parm[3] = RptObj.OracleDBParameter("P_fc_saudi_riyal", fc_saudiRiyal, "Double", "In");
        parm[4] = RptObj.OracleDBParameter("p_company_name", CompanyName, "String", "In");
        parm[5] = RptObj.OracleDBParameter("DATA_RESULTSET", "", "Cursor", "Out");
        dsReport = RptObj.Oracle_GetDataSetSP("sp_rptstatebankrebate", parm);
        string totalstub = dsReport.Tables[0].Rows.Count.ToString();
        return dsReport.Tables[0];
    }
    public string GetReportName()
    {
        MCBReportClass RptObj = new MCBReportClass();
        DataSet dsReport = new DataSet();
        OracleParameter[] parm = new OracleParameter[2];
        parm[0] = RptObj.OracleDBParameter("v_Report_Code", "R29", "String", "In");
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

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

public partial class HomeRemSummRpt : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string month = Request.QueryString["month"];
        string company_code = Request.QueryString["company_code"];
        Generate(month,company_code);
    }
    private void Generate(string month, string company_code)
    {
        ReportViewer1.Visible = true;
        try
        {
            DataTable temp = new DataTable();
            DataTable dt = new DataTable();
            temp = GetData(month, company_code);
            if (temp.Rows.Count > 0)
            {
                ReportDataSource rptDataSource = new ReportDataSource
                ("MCB_DataSet_HomeRemSumm", temp);
                ReportViewer1.LocalReport.DataSources.Clear();
                List<ReportParameter> rpParameter = new List<ReportParameter>();

                //rpParameter.Add(new ReportParameter("Company_Code", companyCode));
                //rpParameter.Add(new ReportParameter("Status", status));
                //rpParameter.Add(new ReportParameter("From_Date", fromDate));
                //rpParameter.Add(new ReportParameter("To_Date", toDate));
                //rpParameter.Add(new ReportParameter("trans_type", trans_type));
                rpParameter.Add(new ReportParameter("month", month));
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
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("HomeRemSummReport.rdlc");
                ReportViewer1.DataBind();
                ReportViewer1.LocalReport.SetParameters(rpParameter);
                ReportViewer1.LocalReport.Refresh();
            }
            else
            {
                Response.Redirect("HomeRemSummReport.aspx?IsRecord=" + "0" + "&msg=" + "No Record Found");
            }
        }
        catch (Exception ex)
        {
            Response.Write("Exception is:" + ex);
        }
    }
    private DataTable GetData(string month, string company_code)
    {
        MCBReportClass RptObj = new MCBReportClass();
        DataSet dsReport = new DataSet();
        OracleParameter[] parm = new OracleParameter[3];
        parm[0] = RptObj.OracleDBParameter("p_month", month, "String", "In");
        parm[1] = RptObj.OracleDBParameter("p_company_code", company_code, "String", "In");
        parm[2] = RptObj.OracleDBParameter("dataset", "", "Cursor", "Out");
        dsReport = RptObj.Oracle_GetDataSetSP("sp_home_rem_sum_Rpt", parm);
        string totalstub = dsReport.Tables[0].Rows.Count.ToString();
        return dsReport.Tables[0];
    }
    public string GetReportName()
    {
        MCBReportClass RptObj = new MCBReportClass();
        DataSet dsReport = new DataSet();
        OracleParameter[] parm = new OracleParameter[2];
        parm[0] = RptObj.OracleDBParameter("v_Report_Code", "R21", "String", "In");
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

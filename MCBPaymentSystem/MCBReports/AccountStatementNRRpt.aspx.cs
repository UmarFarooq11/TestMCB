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

public partial class AccountStatementNRRpt : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string date = Request.QueryString["date"];
        string to_date = Request.QueryString["ToDate"];
        string CompanyCode = Request.QueryString["CompanyCode"];
        Generate(date, to_date, CompanyCode);
    }
    private void Generate(string date, string to_date, string CompanyCode)
    {
        ReportViewer1.Visible = true;
        try
        {
            DataTable temp = new DataTable();
            DataTable dt = new DataTable();
            temp = GetData(date, to_date, CompanyCode);
            if (temp.Rows.Count > 1)
            {                
                ReportDataSource rptDataSource = new ReportDataSource
                ("MCB_DataSet_AccountStatNR", temp);
                ReportViewer1.LocalReport.DataSources.Clear();
                List<ReportParameter> rpParameter = new List<ReportParameter>();
                rpParameter.Add(new ReportParameter("from_date", date));
                rpParameter.Add(new ReportParameter("to_date", to_date));
                ReportViewer1.LocalReport.DataSources.Add(rptDataSource);
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("AccountStatementNRReport.rdlc");
                ReportViewer1.DataBind();
                ReportViewer1.LocalReport.SetParameters(rpParameter);
                ReportViewer1.LocalReport.Refresh();
            }
            else
            {
                Response.Redirect("AccountStatementNRReport.aspx?IsRecord=" + "0" + "&msg=" + "No Record Found");
            }
        }
        catch (Exception ex)
        {
            Response.Write("Exception is:" + ex);
        }
    }
    private DataTable GetData(string date, string to_date, string CompanyCode)
    {
        MCBReportClass RptObj = new MCBReportClass();
        DataSet dsReport = new DataSet();
        OracleParameter[] parm = new OracleParameter[4];
        parm[0] = RptObj.OracleDBParameter("p_company_code", CompanyCode, "String", "In");
        parm[1] = RptObj.OracleDBParameter("p_from_date", date, "String", "In");
        parm[2] = RptObj.OracleDBParameter("p_to_date", to_date, "String", "In");
        parm[3] = RptObj.OracleDBParameter("p_data_set", "", "Cursor", "Out");
        dsReport = RptObj.Oracle_GetDataSetSP("sp_rpt_nr_account_detail", parm);
        string totalstub = dsReport.Tables[0].Rows.Count.ToString();
        return dsReport.Tables[0];
    }


}

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

public partial class CompanyBalanceRpt : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        Response.Cache.SetCacheability(HttpCacheability.ServerAndNoCache);
        Generate();
    }

    private void Generate()
    {
        ReportViewer1.Visible = true;

        try
        {
            DataTable temp = new DataTable();
            temp = GetReportData();

            if (temp.Rows.Count > 0)
            {
                ReportDataSource rptDataSource = new ReportDataSource("MCB_DataSet_Balances_Summary_Of_Agents", temp);
                this.ReportViewer1.LocalReport.DataSources.Clear();

                List<ReportParameter> rpParam = new List<ReportParameter>();
                rpParam.Add(new ReportParameter("OrganizationName", RDLCReportClass.GetOrgName()));    /*OrganizationName*/
                rpParam.Add(new ReportParameter("ReportHeading", RDLCReportClass.GetReportHeader("R1")));    /*ReportHeading*/
                this.ReportViewer1.LocalReport.DataSources.Add(rptDataSource);
                this.ReportViewer1.LocalReport.ReportPath = Server.MapPath("CompanyBalanceReport.rdlc");
                this.ReportViewer1.DataBind();
                this.ReportViewer1.LocalReport.SetParameters(rpParam);
                this.ReportViewer1.LocalReport.Refresh();

            }
            else
            {
                Response.Redirect("CompanyBalanceReport.aspx?IsRecord=" + "0" + "&msg=" + "No Record Found");
            }
        }
        catch (Exception ex)
        {
            Response.Write("Exception is:" + ex);
        }
    }
    private DataTable GetReportData()
    {
        MCBReportClass RptObj = new MCBReportClass();
        DataSet dsReport = RptObj.Local_GetDataSetSP1("SP_BalancesSummaryOfAgents_rpt");
        return dsReport.Tables[0];
    }

}
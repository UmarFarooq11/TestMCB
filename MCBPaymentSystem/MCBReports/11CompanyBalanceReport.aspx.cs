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
using Microsoft.Reporting.WebForms;
//using Report;
using System.Data.OleDb;
using System.Collections.Generic;
using System.Data.OracleClient;

public partial class CompanyBalanceReport : System.Web.UI.Page
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
                //Response.Redirect("UBCSScrollandSummaryReport.aspx?IsRecord=" + "0" + "&msg=" + "No Record Found");
            }
        }
        catch (Exception ex)
        {
            Response.Write("Exception is:" + ex);
        }
    }

    //private string GetOrgName()
    //{
    //    string companyName = "";
    //    try
    //    {
    //        MCBReportClass RptObj = new MCBReportClass();
    //        DataSet dsReport = RptObj.Local_GetDataSetSP1("SP_SYSTEM_SETUP");
    //            if (dsReport.Tables[0].Rows.Count>0)
    //            {
    //                companyName = dsReport.Tables[0].Rows[0]["company_name"].ToString();
    //            }
    //    }
    //    catch(Exception ex)
    //    {}
    //    return companyName;
    //}

    //private string GetReportHeader()
    //{
    //    string headingName = "";
    //    string reportCode = "R1";
    //    try
    //    {
    //        MCBReportClass RptObj = new MCBReportClass();
    //        OleDbParameter[] param = new OleDbParameter[1];

    //        param[0] = RptObj.OleDbParameter("@v_Report_Code", reportCode, "String", "In");
            
    //        DataSet dsReport = RptObj.Local_GetDataSetSP1("SP_REPORT_HEADER",param);
    //        if (dsReport.Tables[0].Rows.Count > 0)
    //        {
    //            Page.Title = dsReport.Tables[0].Rows[0]["HEADING1"].ToString();
    //            headingName = dsReport.Tables[0].Rows[0]["HEADING2"].ToString();
    //        }
    //    }
    //    catch (Exception ex)
    //    { }
    //    return headingName;
    //}

    private DataTable GetReportData()
    {
        MCBReportClass RptObj = new MCBReportClass();
        DataSet dsReport= RptObj.Local_GetDataSetSP1("SP_BalancesSummaryOfAgents_rpt");
        return dsReport.Tables[0];
    }

}

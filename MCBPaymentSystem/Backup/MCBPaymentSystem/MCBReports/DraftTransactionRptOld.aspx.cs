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

public partial class DraftTransactionRptOld : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetCacheability(HttpCacheability.ServerAndNoCache);
        string CompanyCode = Request.QueryString["CompanyCode"];
        string fileName = Request.QueryString["fileName"];
        string Authorize1 = Request.QueryString["Authorize1"];
        string Authorize2 = Request.QueryString["Authorize2"];
        string IBC1 = Request.QueryString["IBC1"];
        string IBC2 = Request.QueryString["IBC2"];
        string PayeesAccount = Request.QueryString["ACCOUNT"];
        Generate(CompanyCode,fileName,Authorize1,Authorize2,IBC1,IBC2,PayeesAccount);
    }
    private void Generate(string CompanyCode, string fileName, string Authorize1, string Authorize2, string IBC1, string IBC2, string PayeesAccount)
    {
        ReportViewer1.Visible = true;
        try
        {
            DataTable temp = new DataTable();
            string[] whereClause=null;
    
            whereClause = new string[2];
            whereClause[0]= CompanyCode;
            whereClause[1] = fileName;
            temp = GetReportData(whereClause);

            if (temp.Rows.Count > 0)
            {
                ReportDataSource rptDataSource = new ReportDataSource("MCB_DataSet_DraftTransaction", temp);
                this.ReportViewer1.LocalReport.DataSources.Clear();

                List<ReportParameter> rpParam = new List<ReportParameter>();
                rpParam.Add(new ReportParameter("OrganizationName", RDLCReportClass.GetOrgName()));    /*OrganizationName*/
                rpParam.Add(new ReportParameter("ReportHeading", RDLCReportClass.GetReportHeader("R2")));    /*ReportHeading*/
                rpParam.Add(new ReportParameter("Authorize1", Authorize1));
                rpParam.Add(new ReportParameter("Authorize2", Authorize2));
                rpParam.Add(new ReportParameter("IBC1", IBC1));
                rpParam.Add(new ReportParameter("IBC2", IBC2));
                rpParam.Add(new ReportParameter("PayeesAccount", PayeesAccount));
                this.ReportViewer1.LocalReport.DataSources.Add(rptDataSource);
                this.ReportViewer1.LocalReport.ReportPath = Server.MapPath("DraftTransactionRptOLD.rdlc");
                this.ReportViewer1.DataBind();
                this.ReportViewer1.LocalReport.SetParameters(rpParam);
                this.ReportViewer1.LocalReport.Refresh();

            }
            else
            {
                Response.Redirect("DraftTransactionReportOld.aspx?errorMsg=" + "No record found.");
            }
        }
        catch (Exception ex)
        {
            Response.Write("Exception is:" + ex);
        }
    }
    private DataTable GetReportData(string[] whereFilter)
    {
        MCBReportClass RptObj = new MCBReportClass();
        OracleParameter[] spParams= new OracleParameter[3];

        spParams[0] = RptObj.OracleDBParameter("p_company_code", whereFilter[0], "String", "In");
        spParams[1] = RptObj.OracleDBParameter("p_file", whereFilter[1], "String", "In");
        spParams[2] = RptObj.OracleDBParameter("data_resultset","", "Cursor", "Out");
        DataSet dsReport = RptObj.Oracle_GetDataSetSP("SP_DraftTransaction_rpt", spParams);
        return dsReport.Tables[0];
    }
}

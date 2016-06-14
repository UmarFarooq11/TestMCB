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

public partial class CustomerFundingRpt : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string companyCode, fromDate, toDate, COMPANYNAME, balance;
        companyCode = Request.QueryString["companycode"];
       // Status = Request.QueryString["status"];
        fromDate = Request.QueryString["fromdate"];
        toDate = Request.QueryString["todate"];

        balance = Request.QueryString["balance"];
        COMPANYNAME = Request.QueryString["COMPANYNAME"];
        //trans_type = Request.QueryString["trans_type"];
        Generate(companyCode, fromDate, toDate, COMPANYNAME, balance);
    }
    private void Generate(string companyCode, string fromDate, string toDate, string COMPANYNAME, string balance)
    {
        ReportViewer1.Visible = true;
        try
        {
            DataTable temp = new DataTable();
            DataTable dt = new DataTable();
            temp = GetData(companyCode, fromDate, toDate);
            if (temp.Rows.Count > 0)
            {
                ReportDataSource rptDataSource = new ReportDataSource
                ("MCB_DataSet_CUSTOMER_FUNDING", temp);
                ReportViewer1.LocalReport.DataSources.Clear();
                List<ReportParameter> rpParameter = new List<ReportParameter>();

                rpParameter.Add(new ReportParameter("Company_Code", companyCode));
                rpParameter.Add(new ReportParameter("COMPANYNAME", COMPANYNAME));
                rpParameter.Add(new ReportParameter("From_Date", fromDate));
                rpParameter.Add(new ReportParameter("To_Date", toDate));
                rpParameter.Add(new ReportParameter("balance", balance));
                
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
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("CustomerFundingReport.rdlc");
                ReportViewer1.DataBind();
                ReportViewer1.LocalReport.SetParameters(rpParameter);
                ReportViewer1.LocalReport.Refresh();
            }
            else
            {
                Response.Redirect("CustomerFundingReport.aspx?IsRecord=" + "0" + "&msg=" + "No Record Found");
            }
        }
        catch (Exception ex)
        {
            Response.Write("Exception is:" + ex);
        }
    }
    private DataTable GetData(string companycode, string fromDate, string toDate)
    {
        MCBReportClass RptObj = new MCBReportClass();
        DataSet dsReport = new DataSet();
        OracleParameter[] parm = new OracleParameter[4];
        parm[0] = RptObj.OracleDBParameter("p_companycode", companycode, "String", "In");
       // parm[1] = RptObj.OracleDBParameter("p_status", status, "String", "In");
        parm[1] = RptObj.OracleDBParameter("p_fromdate", fromDate, "String", "In");
        parm[2] = RptObj.OracleDBParameter("p_todate", toDate, "String", "In");
       // parm[4] = RptObj.OracleDBParameter("p_trans_type", trans_type, "String", "In");
        parm[3] = RptObj.OracleDBParameter("DATA_RESULTSET", "", "Cursor", "Out");
        dsReport = RptObj.Oracle_GetDataSetSP("SP_CUSTOMER_FUNDING", parm);
        string totalstub = dsReport.Tables[0].Rows.Count.ToString();
        return dsReport.Tables[0];
    }
    public string GetReportName()
    {
        MCBReportClass RptObj = new MCBReportClass();
        DataSet dsReport = new DataSet();
        OracleParameter[] parm = new OracleParameter[2];
        parm[0] = RptObj.OracleDBParameter("v_Report_Code", "R4", "String", "In");
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

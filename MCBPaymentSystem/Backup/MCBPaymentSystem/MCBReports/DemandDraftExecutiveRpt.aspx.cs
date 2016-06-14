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

public partial class DemandDraftExecutiveRpt : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string fromdate = Request.QueryString["from"];
        string todate = Request.QueryString["to"];
        Generate(fromdate, todate);
    }
    private void Generate(string fromdate, string todate)
    {
        ReportViewer1.Visible = true;
        try
        {
            DataTable temp = new DataTable();
            DataTable dt = new DataTable();
            temp = GetData(fromdate, todate);
            if (temp.Rows.Count > 0)
            {
                ReportDataSource rptDataSource = new ReportDataSource
                ("MCB_DataSet_DemandDraftExecutive", temp);
                ReportViewer1.LocalReport.DataSources.Clear();
                List<ReportParameter> rpParameter = new List<ReportParameter>();

                //rpParameter.Add(new ReportParameter("Company_Code", companyCode));
                //rpParameter.Add(new ReportParameter("Status", status));
                //rpParameter.Add(new ReportParameter("From_Date", fromDate));
                //rpParameter.Add(new ReportParameter("To_Date", toDate));
                //rpParameter.Add(new ReportParameter("trans_type", trans_type));
                rpParameter.Add(new ReportParameter("fromdate", fromdate));
                rpParameter.Add(new ReportParameter("todate", todate));
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
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("DemandDraftExecutiveReport.rdlc");
                ReportViewer1.DataBind();
                ReportViewer1.LocalReport.SetParameters(rpParameter);
                ReportViewer1.LocalReport.Refresh();
            }
            else
            {
                Response.Redirect("DemandDraftExecutiveReport.aspx?IsRecord=" + "0" + "&msg=" + "No Record Found");
            }
        }
        catch (Exception ex)
        {
            Response.Write("Exception is:" + ex);
        }
    }
    private DataTable GetData(string fromdate, string todate)
    {
        MCBReportClass RptObj = new MCBReportClass();
        DataSet dsReport = new DataSet();
        OracleParameter[] parm = new OracleParameter[3];
        parm[0] = RptObj.OracleDBParameter("p_fromdate", fromdate, "String", "In");
        parm[1] = RptObj.OracleDBParameter("p_todate", todate, "String", "In");
        parm[2] = RptObj.OracleDBParameter("DATA_RESULTSET", "", "Cursor", "Out");
        dsReport = RptObj.Oracle_GetDataSetSP("sp_DD_EXE_SUMMARY_REPORT", parm);
        string totalstub = dsReport.Tables[0].Rows.Count.ToString();
        return dsReport.Tables[0];
    }
    public string GetReportName()
    {
        MCBReportClass RptObj = new MCBReportClass();
        DataSet dsReport = new DataSet();
        OracleParameter[] parm = new OracleParameter[2];
        parm[0] = RptObj.OracleDBParameter("v_Report_Code", "R16", "String", "In");
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

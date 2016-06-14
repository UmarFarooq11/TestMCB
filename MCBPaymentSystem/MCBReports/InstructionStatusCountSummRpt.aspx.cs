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

public partial class InstructionStatusCountSummRpt : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string Month = Request.QueryString["Month"];
        //string todate = Request.QueryString["to"];
        Generate(Month);
    }
    private void Generate(string Month)
    {
        ReportViewer1.Visible = true;
        try
        {
            DataTable temp = new DataTable();
            DataTable dt = new DataTable();
            temp = GetData(Month);
            if (temp.Rows.Count > 0)
            {
                ReportDataSource rptDataSource = new ReportDataSource
                ("MCB_DataSet_InstructionStatusSummary", temp);
                ReportViewer1.LocalReport.DataSources.Clear();
                List<ReportParameter> rpParameter = new List<ReportParameter>();

                //rpParameter.Add(new ReportParameter("Company_Code", companyCode));
                //rpParameter.Add(new ReportParameter("Status", status));
                //rpParameter.Add(new ReportParameter("From_Date", fromDate));
                //rpParameter.Add(new ReportParameter("To_Date", toDate));
                //rpParameter.Add(new ReportParameter("trans_type", trans_type));
                
                rpParameter.Add(new ReportParameter("Month", Month));
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
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("InstructionStatusCountSummReport.rdlc");
                ReportViewer1.DataBind();
                ReportViewer1.LocalReport.SetParameters(rpParameter);
                ReportViewer1.LocalReport.Refresh();
            }
            else
            {
                Response.Redirect("InstructionStatusCountSummReport.aspx?IsRecord=" + "0" + "&msg=" + "No Record Found");
            }
        }
        catch (Exception ex)
        {
            Response.Write("Exception is:" + ex);
        }
    }
    private DataTable GetData(string Month)
    {
        MCBReportClass RptObj = new MCBReportClass();
        DataSet dsReport = new DataSet();
        OracleParameter[] parm = new OracleParameter[2];
        parm[0] = RptObj.OracleDBParameter("p_month", Month, "String", "In");
        parm[1] = RptObj.OracleDBParameter("dataset", "", "Cursor", "Out");
        dsReport = RptObj.Oracle_GetDataSetSP("sp_ins_status_sumry_rpt", parm);
        string totalstub = dsReport.Tables[0].Rows.Count.ToString();
        return dsReport.Tables[0];
    }
    public string GetReportName()
    {
        MCBReportClass RptObj = new MCBReportClass();
        DataSet dsReport = new DataSet();
        OracleParameter[] parm = new OracleParameter[2];
        parm[0] = RptObj.OracleDBParameter("v_Report_Code", "R22", "String", "In");
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

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

public partial class ChangeAccountRpt : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string companyCode, from_dt, to_dt, trans_type ;
        companyCode = Request.QueryString["companycode"];
        from_dt = Request.QueryString["from_dt"];
        to_dt = Request.QueryString["to_dt"];
        trans_type = Request.QueryString["trans_type"];
        Generate(companyCode, from_dt, to_dt, trans_type);
    }
    private void Generate(string companyCode, string from_dt, string to_dt, string trans_type)
    {
        ReportViewer1.Visible = true;
        try
        {
            DataTable temp = new DataTable();
            DataTable dt = new DataTable();
            temp = GetData(companyCode, from_dt, to_dt,trans_type);
            if (temp.Rows.Count > 0)
            {
                ReportDataSource rptDataSource = new ReportDataSource("MCB_DataSet_BeneReconMIS", temp);
                ReportViewer1.LocalReport.DataSources.Clear();
                List<ReportParameter> rpParameter = new List<ReportParameter>();
                rpParameter.Add(new ReportParameter("From_Date", from_dt));
                rpParameter.Add(new ReportParameter("To_Date", to_dt));
                rpParameter.Add(new ReportParameter("BankName", GetBankName()));
                rpParameter.Add(new ReportParameter("ReportName", GetReportName()));
                ReportViewer1.LocalReport.DataSources.Add(rptDataSource);
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("ChangeAccountReport.rdlc");
                ReportViewer1.DataBind();
                ReportViewer1.LocalReport.SetParameters(rpParameter);
                ReportViewer1.LocalReport.Refresh();
            }
            else
            {
                Response.Write("No Data Found.");
              //  Response.Redirect("ChangeAccountReport.aspx?IsRecord=" + "0" + "&msg=" + "No Record Found");
            }
        }
        catch (Exception ex)
        {
            Response.Write("Exception is:" + ex);
        }
    }
    private DataTable GetData(string p_companycode, string p_from_dt, string p_to_dt, string trans_type)
    {
        MCBReportClass RptObj = new MCBReportClass();
        DataSet dsReport = new DataSet();
        OracleParameter[] parm = new OracleParameter[4];
        parm[0] = RptObj.OracleDBParameter("p_company_code", p_companycode, "String", "In");
        parm[1] = RptObj.OracleDBParameter("p_from_dt", p_from_dt, "String", "In");
        parm[2] = RptObj.OracleDBParameter("p_to_dt", p_to_dt, "String", "In");
        //parm[3] = RptObj.OracleDBParameter("p_trans_type", trans_type, "String", "In");
        parm[3] = RptObj.OracleDBParameter("data_set", "", "Cursor", "Out");
        dsReport = RptObj.Oracle_GetDataSetSP("sp_bene_recon_mis_rpt", parm);
        string totalstub = dsReport.Tables[0].Rows.Count.ToString();
        return dsReport.Tables[0];
    }
    public string GetReportName()
    {
        MCBReportClass RptObj = new MCBReportClass();
        DataSet dsReport = new DataSet();
        OracleParameter[] parm = new OracleParameter[2];
        parm[0] = RptObj.OracleDBParameter("v_Report_Code", "R26", "String", "In");
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

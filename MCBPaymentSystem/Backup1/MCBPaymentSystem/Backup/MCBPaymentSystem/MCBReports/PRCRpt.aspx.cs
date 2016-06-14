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

public partial class PRCRpt : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string Account_no, ref_no, RemePurpose, from_date, to_date, bankname;
        Account_no = Request.QueryString["Account_no"].ToString();
        ref_no = Request.QueryString["ref_no"].ToString();
        RemePurpose = Request.QueryString["RemePurpose"].ToString();
        from_date = Request.QueryString["from_date"].ToString();
        to_date = Request.QueryString["to_date"].ToString();
        bankname = Request.QueryString["bankname"].ToString();
        Generate(Account_no, ref_no, RemePurpose, from_date, to_date, bankname);
    }
    private void Generate(string Account_no, string ref_no, string RemePurpose, string from_date, string to_date, string bankname)
    {
        ReportViewer1.Visible = true;
        try
        {
            DataTable temp = new DataTable();
            DataTable dt = new DataTable();
            temp = GetData(Account_no, ref_no, from_date, to_date);
            if (temp.Rows.Count > 0)
            {
                string[] Purpose = RemePurpose.Split(';');
                ReportDataSource rptDataSource = new ReportDataSource
                ("MCB_DataSet_PRC_Reprot", temp);
                ReportViewer1.LocalReport.DataSources.Clear();
                List<ReportParameter> rpParameter = new List<ReportParameter>();
                rpParameter.Add(new ReportParameter("RemePurpose", Purpose[0]));

                //rpParameter.Add(new ReportParameter("Schedule", Purpose[1]));
                rpParameter.Add(new ReportParameter("Schedule", (Purpose.Length > 1) ? Purpose[1].ToString() : ""));
                rpParameter.Add(new ReportParameter("bankname", bankname));


                ReportViewer1.LocalReport.DataSources.Add(rptDataSource);
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("PRCReport.rdlc");
                ReportViewer1.DataBind();
                ReportViewer1.LocalReport.SetParameters(rpParameter);
                ReportViewer1.LocalReport.Refresh();
            }
            else
            {
                Response.Redirect("PRCReport.aspx?IsRecord=" + "0" + "&msg=" + "No Record Found");
            }
        }
        catch (Exception ex)
        {
            Response.Write("Exception is:" + ex);
        }
    }
    private DataTable GetData(string p_account_no, string p_ref_no, string from_date, string to_date)
    {
        MCBReportClass RptObj = new MCBReportClass();
        DataSet dsReport = new DataSet();
        OracleParameter[] parm = new OracleParameter[5];
        parm[0] = RptObj.OracleDBParameter("p_account_no", p_account_no, "String", "In");
        parm[1] = RptObj.OracleDBParameter("p_ref_no", p_ref_no, "String", "In");
        parm[2] = RptObj.OracleDBParameter("p_from_dt", from_date, "String", "In");
        parm[3] = RptObj.OracleDBParameter("p_to_dt", to_date, "String", "In");
        parm[4] = RptObj.OracleDBParameter("p_dataset", "", "Cursor", "Out");
        dsReport = RptObj.Oracle_GetDataSetSP("sp_payment_prc_rpt", parm);
        return dsReport.Tables[0];
    }


}

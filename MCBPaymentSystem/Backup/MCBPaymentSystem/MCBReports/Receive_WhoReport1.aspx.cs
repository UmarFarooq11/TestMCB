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
using System.Data.OracleClient;

public partial class MCBReports_TESTREPORT : System.Web.UI.Page
{
    static string companycode;
    static string companyname;
    static string usertype = "";
    DataTable dt = new DataTable();
    
    protected void Page_PreInit(object sender, EventArgs e)
    {
        Page.Theme = Session["ThemeChange"].ToString();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        //ScriptManager sm = ScriptManager.GetCurrent(this.Page);
        //sm.RegisterPostBackControl(this.btnExcel);
        DataSet ds = new DataSet();
        //if (Request.QueryString["UID"] != null)
        //{
        //    Session["U_NAME"] = Request.QueryString["UID"].ToString();
        //}
        //else
        //{
        //    if (Session["U_NAME"] == null)
        //    {
        //        String PR_id = Request.QueryString["ProjectID"].ToString();
        //        ds = lov.SP_GETDATA_DPAGE(PR_id);
        //        Response.Redirect(ds.Tables[0].Rows[0]["DPage"].ToString());
        //    }
        //}
        string msg = Request.QueryString["msg"];
        if (msg != "")
        {
            lblmessage.Text = msg;
        }
        if (!Page.IsPostBack)
        {
            // ddlFileName1();
            ddlCompanyBind();
            //if (usertype.ToString() == "COMPANY")
            //{
            //    lblcompanycodedisplay.Visible = false;
            //    lblcompanynamedisplay.Visible = true;
            //    lblcompanynamedisplay.Text = "Company Name ";
            //    lblcompanycodedisplay.ForeColor = System.Drawing.Color.Black;
            //    lblcompanynamedisplay.ForeColor = System.Drawing.Color.Black;
            //    lblcompanyname.Visible = true;
            //    ddlCompanyCode.Visible = false;
            //    CompanyName();
            //}
            //else
            //{
            //    lblcompanycodedisplay.Visible = true;
            //    lblcompanyname.Visible = false;
            //    ddlCompanyCode.Visible = true;
            //    lblcompanycodedisplay.Text = "Company Name ";
            //    lblcompanycodedisplay.ForeColor = System.Drawing.Color.Black;
            //}
        }
    }
    protected void btn_OK_Click(object sender, EventArgs e)
    {
        //if (usertype.ToString() != "COMPANY")
        //{
        //    companycode = (ddlCompanyCode.SelectedValue == "AAA") ? "" : ddlCompanyCode.SelectedValue;
        //}
        //else
        //{
        //    companycode = companycode;/// (ddlCompanyCode.SelectedValue == "AAA") ? "" : ddlCompanyCode.SelectedValue;
        //}
         companycode = "WHO";
        string status = "";//(ddlStatus.SelectedValue == "NULL") ? "" : ddlStatus.SelectedValue;
        string fromDate = (TXT_FROM.Text == "") ? DateTime.Now.ToString("dd-MM-yyyy") : TXT_FROM.Text;
        string toDate = (TXT_TO.Text == "") ? DateTime.Now.ToString("dd-MM-yyyy") : TXT_TO.Text;
        string trans_type = "";// (DDL_TransType.SelectedValue.ToString() == "NULL") ? "" : DDL_TransType.SelectedValue.ToString();
        string selecttype = "Deposit";
        string beneAddress = txtBeneAddress.Text;
        string RemitterName = txtRemitterName.Text;
        string FileName = txt_filename.Text;
        Response.Redirect("Receive_WhoRpt.aspx?UID=" + Session["U_NAME"].ToString() + "&companycode=" + companycode + "&status=" + status + "&fromdate=" + fromDate + "&todate=" + toDate + "&trans_type=" + trans_type + "&selecttype=" + selecttype + "&beneAddress=" + beneAddress + "&RemitterName=" + RemitterName + "&FileName=" + FileName);
    }
    public void ddlCompanyBind()
    {
        //DataSet ds = new DataSet();
        //DataSet dsu = new DataSet();
        //DataTable dt = new DataTable();
        //dsu = lov.SP_GET_USERIFNO(Session["U_NAME"].ToString());
        //if (dsu.Tables[0].Rows.Count > 0)
        //{
        //    usertype = dsu.Tables[0].Rows[0]["USER_TYPE"].ToString();
        //    if (usertype.ToString() != "COMPANY")
        //    {
        //        //ds = lov.Get_Company_setup_lov("%", "%", Session["U_NAME"].ToString());
        //        //if (ds.Tables[0].Rows.Count > 0)
        //        //{
        //        //    ddlCompanyCode.DataSource = ds.Tables[0];
        //        //    ddlCompanyCode.DataValueField = "Company_Code";
        //        //    ddlCompanyCode.DataTextField = "Company_Name";
        //        //    ddlCompanyCode.DataBind();
        //        //    if (usertype.ToString() != "COMPANY")
        //        //    {
        //        //        ddlCompanyCode.Items.Insert(0, new ListItem("All", ""));
        //        //    }
        //        //}
        //    }
        //}
    }
    //public void CompanyName()
    //{
    //    DataSet ds = new DataSet();
    //    DataSet dsC = new DataSet();
    //    DataTable dt = new DataTable();
    //    dsC = lov.SP_GET_COMPANYNAME(Session["U_NAME"].ToString());
    //    if (dsC.Tables[0].Rows.Count > 0)
    //    {
    //        companycode = dsC.Tables[0].Rows[0]["company_code"].ToString();
    //        companyname = dsC.Tables[0].Rows[0]["company_name"].ToString();
    //        lblcompanyname.Text = dsC.Tables[0].Rows[0]["company_name"].ToString();
    //        lblcompanyname.ForeColor = System.Drawing.Color.Black;
    //    }
    //    else
    //    {
    //        lblcompanyname.Text = Session["U_NAME"].ToString() + " is not company user ";
    //        lblcompanyname.ForeColor = System.Drawing.Color.Black;
    //    }
    //}
    protected void btnExcel_Click(object sender, EventArgs e)
    {
        //if (usertype.ToString() != "COMPANY")
        //{
        //    companycode = (ddlCompanyCode.SelectedValue == "AAA") ? "" : ddlCompanyCode.SelectedValue;
        //}
        //else
        //{
        //    companycode = companycode;
        //}
        companycode = "";
        string status = "";//(ddlStatus.SelectedValue == "NULL") ? "" : ddlStatus.SelectedValue;
        string fromDate = (TXT_FROM.Text == "") ? DateTime.Now.ToString("dd-MM-yyyy") : TXT_FROM.Text;
        string toDate = (TXT_TO.Text == "") ? DateTime.Now.ToString("dd-MM-yyyy") : TXT_TO.Text;
        string trans_type = "";// (DDL_TransType.SelectedValue.ToString() == "NULL");
        string selecttype = "Deposit";
        GetData(companycode, status, fromDate, toDate, trans_type, selecttype);
        if (dt.Rows.Count > 0)
        {
            ExportTableData();
        }
        else
        {
            lblmessage.Text = "No Record Found";
        }
    }
    private DataTable GetData(string company_code, string status, string fromDate, string toDate,
    string trans_type, string selecttype)
    {
        MCBReportClass RptObj = new MCBReportClass();
        OracleParameter[] parm = new OracleParameter[8];
        parm[0] = RptObj.OracleDBParameter("p_companycode", companycode, "String", "In");
        parm[1] = RptObj.OracleDBParameter("p_status", status, "String", "In");
        parm[2] = RptObj.OracleDBParameter("p_fromdate", fromDate, "String", "In");
        parm[3] = RptObj.OracleDBParameter("p_todate", toDate, "String", "In");
        parm[4] = RptObj.OracleDBParameter("p_trans_type", trans_type, "String", "In");
        parm[5] = RptObj.OracleDBParameter("p_selecttype", selecttype, "String", "In");
        parm[6] = RptObj.OracleDBParameter("p_usr_name", Session["U_NAME"].ToString(), "String", "In");
        parm[7] = RptObj.OracleDBParameter("DATA_RESULTSET", "", "Cursor", "Out");
        dt = RptObj.Oracle_GetDataSetSP("sp_mispayment", parm).Tables[0];
        return dt;
    }
    public void ExportTableData()
    {
        //string style = @"<style> .text { mso-number-format:\@; } </style> ";
        string attach = "attachment;filename=Receive Report.xls";
        Response.ClearContent();
        Response.AddHeader("content-disposition", attach);
        Response.ContentType = "application/ms-excel";
        if (dt != null)
        {
            foreach (DataColumn dc in dt.Columns)
            {
                Response.Write(dc.ColumnName + "\t");
            }
            Response.Write(System.Environment.NewLine);
            foreach (DataRow dr in dt.Rows)
            {
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    Response.Write(dr[i].ToString() + "\t");
                }
                Response.Write("\n");
            }
            Response.End();
        }
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        // Confirms that an HtmlForm control is rendered for the
        //specified ASP.NET server control at run time.
    }

    //public void ddlFileName1()
    //{
    //    DataSet ds = new DataSet();
    //    ds = lov.LOV_FileName();
    //    if (ds.Tables[0].Rows.Count > 0)
    //    {
    //        ddlFileName.DataSource = ds.Tables[0];
    //        ddlFileName.DataValueField = "file_name";
    //        ddlFileName.DataTextField = "file_name";
    //    }
    //    ddlFileName.Items.Insert(0, new ListItem("All", ""));
    //}

    
    protected void btnLov_Click(object sender, ImageClickEventArgs e)
    {
        if (Session["LOV_IDFILENAME"].ToString() != "")
        {
            txt_filename.Text = Session["LOV_IDFILENAME"].ToString();
            Session["FILENAME"] = Session["LOV_IDFILENAME"].ToString();
            ImageButton1.Enabled = true;
        }
    }
    protected void LOV_REMEADDRESS_Click(object sender, ImageClickEventArgs e)
    {
        if (Session["REMITTER_NAME"].ToString() != "")
        {
            txtRemitterName.Text = Session["REMITTER_NAME"].ToString();
            //txt_branchname.Text = Session["LOV_DESCRIPTION"].ToString();
        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        if (Session["Beneficiary_Address"].ToString() != "")
        {
            txtBeneAddress.Text = Session["Beneficiary_Address"].ToString();
            //txt_branchname.Text = Session["LOV_DESCRIPTION"].ToString();
            LOV_REMEADDRESS.Enabled = true;
        }
    }
   
}

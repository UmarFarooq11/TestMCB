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

public partial class DepositReport : System.Web.UI.Page
{
    LOV_COLLECTION lov = new LOV_COLLECTION();
    DataTable dt = new DataTable();
    protected void Page_PreInit(object sender, EventArgs e)
    {
        Page.Theme = Session["ThemeChange"].ToString();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        ScriptManager sm = ScriptManager.GetCurrent(this.Page);
        sm.RegisterPostBackControl(this.btnExcel);
        DataSet ds = new DataSet();
        if (Request.QueryString["UID"] != null)
        {
            Session["U_NAME"] = Request.QueryString["UID"].ToString();
        }
        else
        {
            if (Session["U_NAME"] == null)
            {
                String PR_id = Request.QueryString["ProjectID"].ToString();
                ds = lov.SP_GETDATA_DPAGE(PR_id);
                Response.Redirect(ds.Tables[0].Rows[0]["DPage"].ToString());
            }
        }
        string msg = Request.QueryString["msg"];
        if (msg != "")
        {
            lblmessage.Text = msg;
        }
        if (!Page.IsPostBack)
        {
            if (checkUser() == false)
            {
                lbl_Message.Text = "Session expired, Please re-login";
                //ddlCompanyCode.Items.Clear();
                return;
            }
            ddlCompanyBind();
            Get_BusinessNature();
        }
    }
    protected void btn_OK_Click(object sender, EventArgs e)
    {
        if (checkUser() == false)
        {
            lbl_Message.Text = "Session expired, Please re-login";
            return ;
        }
        
        if (ddlCompanyCode.SelectedItem.Text == "Company not found")
        {
            lbl_Message.Text = "Company not found";
            return;
        }
        string companycode = ddlCompanyCode.SelectedValue;
        string status = "";
        string fromDate = TXT_FROM.Text;
        string toDate = TXT_TO.Text;
        string trans_type = DDL_TransType.SelectedValue;
        string companytype = ddl_BusinessNature.SelectedValue;
        string selecttype = "Deposit";
        //Response.Redirect("DepositRpt.aspx?UID=" + Session["U_NAME"].ToString() + "&companycode=" + companycode + "&status=" + status + "&fromdate=" + fromDate + "&todate=" + toDate + "&trans_type=" + trans_type + "&selecttype=" + selecttype + "&companytype=" + companytype);
        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Receive Report", "window.open('DepositRpt.aspx?UID=" + Session["U_NAME"].ToString() + "&companycode=" + companycode + "&status=" + status + "&fromdate=" + fromDate + "&todate=" + toDate + "&trans_type=" + trans_type + "&selecttype=" + selecttype + "&companytype=" + companytype + "', 'CS', 'left=0,top=0, height= '+ screen.availHeight +' , width= '+ screen.availWidth +',menubar=no,location=no,toolbar=no,scrollbars=nO,resizable=no');", true);
    }
    public bool checkUser()
    {
        if (Session["U_NAME"] != null)
        {
            if (Session["U_NAME"].ToString() == "" || Session["U_NAME"].ToString().Contains("%") == true)
            {
                return false;
            }
        }
        else
        {
            return false;
        }
        return true;
    }
    public void Get_BusinessNature()
    {
        ddl_BusinessNature.Items.Clear();
        MCBReportClass RptObj = new MCBReportClass();
        DataTable dt = new DataTable();
        OracleParameter[] parm = new OracleParameter[2];
        parm[0] = RptObj.OracleDBParameter("p_type", "", "String", "In");
        parm[1] = RptObj.OracleDBParameter("p_dataset", "", "Cursor", "Out");
        dt = RptObj.Oracle_GetDataSetSP("sp_get_companyType", parm).Tables[0];
        if (dt.Rows.Count > 0)
        {
            ddl_BusinessNature.DataSource = dt;
            ddl_BusinessNature.DataValueField = "business_nature";
            ddl_BusinessNature.DataTextField = "business_desc";
            ddl_BusinessNature.DataBind();
        }
        ddl_BusinessNature.Items.Insert(0, new ListItem("All", ""));
    }
    public void ddlCompanyBind()
    {
        DataSet ds = new DataSet();
        ds = lov.Get_Company_setup_lov("%", "%", Session["U_NAME"].ToString());
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlCompanyCode.DataSource = ds.Tables[0];
            ddlCompanyCode.DataValueField = "Company_Code";
            ddlCompanyCode.DataTextField = "Company_Name";
            ddlCompanyCode.DataBind();
            if (ds.Tables[0].Rows.Count > 1)
            {
                ddlCompanyCode.Items.Insert(0, new ListItem("All", ""));
            }
            btn_OK.Visible = true;
            btnExcel.Visible = true;
        }
        else
        {
            ddlCompanyCode.Items.Insert(0, new ListItem("Company not found", ""));
            btn_OK.Visible = false;
            btnExcel.Visible = false;
        }
    }
    protected void btnExcel_Click(object sender, EventArgs e)
    {
        string companycode = ddlCompanyCode.SelectedValue;
        string status = "";
        string fromDate = TXT_FROM.Text;
        string toDate = TXT_TO.Text;
        string trans_type = DDL_TransType.SelectedValue;
        string companytype = ddl_BusinessNature.SelectedValue;
        string selecttype = "Deposit";
        GetData(companycode, status, fromDate, toDate, trans_type, selecttype,companytype);
        if (dt.Rows.Count > 0)
        {
            ExportTableData();
        }
        else
        {
            lblmessage.Text = "No Record Found";
        }
    }
    private DataTable GetData(string company_code, string status, string fromDate, string toDate, string trans_type, string selecttype, string p_companytype)
    {
        MCBReportClass RptObj = new MCBReportClass();
        OracleParameter[] parm = new OracleParameter[9];
        parm[0] = RptObj.OracleDBParameter("p_companycode", company_code, "String", "In");
        parm[1] = RptObj.OracleDBParameter("p_status", status, "String", "In");
        parm[2] = RptObj.OracleDBParameter("p_fromdate", fromDate, "String", "In");
        parm[3] = RptObj.OracleDBParameter("p_todate", toDate, "String", "In");
        parm[4] = RptObj.OracleDBParameter("p_trans_type", trans_type, "String", "In");
        parm[5] = RptObj.OracleDBParameter("p_selecttype", selecttype, "String", "In");
        parm[6] = RptObj.OracleDBParameter("p_companytype", p_companytype, "String", "In");
        parm[7] = RptObj.OracleDBParameter("p_usr_name", Session["U_NAME"].ToString(), "String", "In");
        parm[8] = RptObj.OracleDBParameter("DATA_RESULTSET", "", "Cursor", "Out");
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
}

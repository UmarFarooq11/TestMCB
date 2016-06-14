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

public partial class AccountStatementNRReport : System.Web.UI.Page
{
    LOV_COLLECTION lov = new LOV_COLLECTION();
    protected void Page_PreInit(object sender, EventArgs e)
    {
        Page.Theme = Session["ThemeChange"].ToString();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
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
        if (!IsPostBack)
        {
            ddlCompanyBind();
        }
        string msg = Request.QueryString["msg"];
        if (msg != "")
        {
            lblmessage.Text = msg;
        }
    }
    protected void btn_OK_Click(object sender, EventArgs e)
    {
        if (txtDate.Text != "" && txtToDate.Text != "")
        {
            string Fromdate = txtDate.Text;
            string ToDate = txtToDate.Text;
            string CompanyCode = ddlCompanyCode.SelectedValue;
            Response.Redirect("AccountStatementNRRpt.aspx?date=" + Fromdate + "&ToDate=" + ToDate + "&CompanyCode=" + CompanyCode);
        }
        else
        {
            lblmessage.Text = "Please enter date / select date.";
        }
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
            //if (ds.Tables[0].Rows.Count > 1)
            //{
            //    ddlCompanyCode.Items.Insert(0, new ListItem("All", ""));
            //}                    
        }
        else
        {
            ddlCompanyCode.Items.Insert(0, new ListItem("Company not found", ""));
        }
    }
}

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

public partial class CommissionInvoiceReport : System.Web.UI.Page
{
    LOV_COLLECTION lov = new LOV_COLLECTION();
    static string companycode;
    static string companyname;
    static string usertype = "";
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
            if (usertype.ToString() == "COMPANY")
            {
                lblcompanycodedisplay.Visible = false;
                lblcompanynamedisplay.Visible = true;
                lblcompanynamedisplay.Text = "Company Name ";
                lblcompanycodedisplay.ForeColor = System.Drawing.Color.Black;
                lblcompanynamedisplay.ForeColor = System.Drawing.Color.Black;
                lblcompanyname.Visible = true;
                ddlCompanyCode.Visible = false;
                CompanyName();
            }
            else
            {
                lblcompanycodedisplay.Visible = true;
                lblcompanyname.Visible = false;
                ddlCompanyCode.Visible = true;
                lblcompanycodedisplay.Text = "Company Name ";
                lblcompanycodedisplay.ForeColor = System.Drawing.Color.Black;
            }
        }

        string msg = Request.QueryString["msg"];
        if (msg != "")
        {
            lblmessage.Text = msg;
        }

    }
    protected void btn_OK_Click(object sender, EventArgs e)
    {
        if (txtDate.Text != "")
        {
            string date = txtDate.Text;
            string CompanyCode = ddlCompanyCode.SelectedValue;
            Response.Redirect("CommissionInvoiceRpt.aspx?date=" + date + "&CompanyCode=" + CompanyCode);
        }
        else
        {
            lblmessage.Text = "Please enter date / select date.";
        }
    }
    public void ddlCompanyBind()
    {
        DataSet ds = new DataSet();
        DataSet dsu = new DataSet();
        DataTable dt = new DataTable();
        dsu = lov.SP_GET_USERIFNO(Session["U_NAME"].ToString());
        if (dsu.Tables[0].Rows.Count > 0)
        {
            usertype = dsu.Tables[0].Rows[0]["USER_TYPE"].ToString();
            if (usertype.ToString() != "COMPANY")
            {
                ds = lov.Get_Company_setup_lov("%", "%", Session["U_NAME"].ToString());
                if (ds.Tables[0].Rows.Count > 0)
                {
                    //DataRow dr = ds.Tables[0].NewRow();
                    //dr["Company_Code"] = "AAA";
                    //dr["Company_Name"] = "ALL";
                    //ds.Tables[0].Rows.Add(dr);
                    //dt = ds.Tables[0];
                    //dt.DefaultView.Sort = "Company_Code ASC";
                    //dt = dt.DefaultView.ToTable();
                    ddlCompanyCode.DataSource = ds.Tables[0];
                    ddlCompanyCode.DataValueField = "Company_Code";
                    ddlCompanyCode.DataTextField = "Company_Name";
                    ddlCompanyCode.DataBind();

                    if (usertype.ToString() != "COMPANY")
                    {
                        ddlCompanyCode.Items.Insert(0, new ListItem("All", ""));
                    }
                }
                else
                {

                }
            }
        }
    }
    public void CompanyName()
    {
        DataSet ds = new DataSet();
        DataSet dsC = new DataSet();
        DataTable dt = new DataTable();
        dsC = lov.SP_GET_COMPANYNAME(Session["U_NAME"].ToString());
        if (dsC.Tables[0].Rows.Count > 0)
        {
            companycode = dsC.Tables[0].Rows[0]["company_code"].ToString();
            companyname = dsC.Tables[0].Rows[0]["company_name"].ToString();
            lblcompanyname.Text = dsC.Tables[0].Rows[0]["company_name"].ToString();
            lblcompanyname.ForeColor = System.Drawing.Color.Black;
        }
        else
        {
            lblcompanyname.Text = Session["U_NAME"].ToString() + " is not company user ";
            lblcompanyname.ForeColor = System.Drawing.Color.Black;
        }
    }
}

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

public partial class ChangeAccountReport : System.Web.UI.Page
{
    LOV_COLLECTION lov = new LOV_COLLECTION();
    DataTable dt = new DataTable();
   static  string companycode;
    string companyname;
    string from_date;
    string to_date;   
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
        string msg = Request.QueryString["msg"];
        if (msg != "")
        {
            lblmessage.Text = msg;
        }
        if (!Page.IsPostBack)
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
        if (!Page.IsPostBack)
        {
            txtFromDate.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
            txtToDate.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
            
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


    protected void btn_OK_Click(object sender, EventArgs e)
    {
        if (usertype.ToString() != "COMPANY")
        {
            companycode = (ddlCompanyCode.SelectedValue == "AAA") ? "" : ddlCompanyCode.SelectedValue;
        }
        else
        {
            companycode = companycode;/// (ddlCompanyCode.SelectedValue == "AAA") ? "" : ddlCompanyCode.
        }
        //companycode = (ddlCompanyCode.SelectedValue == "AAA") ? "" : ddlCompanyCode.SelectedValue;
        from_date = (txtFromDate.Text == "" ? DateTime.Now.ToString("dd-MM-yyyy") : txtFromDate.Text);
        to_date = (txtToDate.Text == "" ? DateTime.Now.ToString("dd-MM-yyyy") : txtToDate.Text);
        string trans_type = (DDL_TransType.SelectedValue.ToString() == "NULL") ? "" : DDL_TransType.SelectedValue.ToString();
                                         //Response.Redirect("ChangeAccountRpt.aspx?companycode=" + companycode + "&from_dt=" + from_date + "&to_dt=" + to_date);
        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "AmendmentReport", "window.open('ChangeAccountRpt.aspx?companycode=" + companycode + "&from_dt=" + from_date + "&to_dt=" + to_date + "&trans_type=" + trans_type + "', 'CS', 'left=0,top=0, height= '+ screen.availHeight +' , width= '+ screen.availWidth +',menubar=no,location=no,toolbar=no,scrollbars=no,resizable=no');", true);
    }
    //public void ddlCompanyBind()
    //{
    //    DataSet ds = new DataSet();
    //    DataSet dsu = new DataSet();
    //    DataTable dt = new DataTable();
    //    ds = lov.Get_Company_setup_lov("%", "%");
    //    if (ds.Tables[0].Rows.Count > 0)
    //    {
    //        ddlCompanyCode.DataSource = ds.Tables[0];
    //        ddlCompanyCode.DataValueField = "Company_Code";
    //        ddlCompanyCode.DataTextField = "Company_Name";
    //        ddlCompanyCode.DataBind();
    //        ddlCompanyCode.Items.Insert(0, new ListItem("All", ""));
    //    }
    //    else
    //    {

    //    }
    //}
    public void ddlCompanyBind()
    {
        DataSet ds = new DataSet();
        DataSet dsu = new DataSet();
        DataTable dt = new DataTable();
        dsu = lov.SP_GET_USERIFNO(Session["U_NAME"].ToString());
        if (dsu.Tables[0].Rows.Count > 0)
        {
            usertype =     dsu.Tables[0].Rows[0]["USER_TYPE"].ToString();
            string CCode = dsu.Tables[0].Rows[0]["Company_Code"].ToString();
            if (usertype.ToString() != "COMPANY")
            {
                ds = lov.Get_Company_setup_lov("%", "%", Session["U_NAME"].ToString());
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ddlCompanyCode.DataSource = ds.Tables[0];
                    ddlCompanyCode.DataValueField = "Company_Code";
                    ddlCompanyCode.DataTextField = "Company_Name";
                    ddlCompanyCode.DataBind();
                    if (usertype.ToString() != "COMPANY")
                    {
                        ddlCompanyCode.Items.Insert(0, new ListItem("All", ""));
                    }
                }
            }
            else
            {                
               // ddlCompanyCode.Items.Add(CCode);
                companycode = CCode;
                
            }
        }
    }

}




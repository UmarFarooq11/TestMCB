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

public partial class CancelReport : System.Web.UI.Page
{
    LOV_COLLECTION lov = new LOV_COLLECTION();
    static string companycode;
    static string companyname; 
    static string usertype ="";
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
            TXT_FROM.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
            TXT_TO.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
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
            companycode = companycode;/// (ddlCompanyCode.SelectedValue == "AAA") ? "" : ddlCompanyCode.SelectedValue;
        }

        
        string status = "";//(ddlStatus.SelectedValue == "NULL") ? "" : ddlStatus.SelectedValue;
        string fromDate = (TXT_FROM.Text == "") ? DateTime.Now.ToString("dd-MM-yyyy") : TXT_FROM.Text;
        string toDate = (TXT_TO.Text == "") ? DateTime.Now.ToString("dd-MM-yyyy") : TXT_TO.Text;
        string trans_type = (DDL_TransType.SelectedValue.ToString() == "NULL") ? "" : DDL_TransType.SelectedValue.ToString();
        string selecttype="Deposit";
        
        //if (RB_Payment.Checked == true)
        //{
        //string selecttype = "Payment";
        //}


        //Response.Redirect("CancelRpt.aspx?companycode=" + companycode + "&status=" + status + "&fromdate=" + fromDate + "&todate=" + toDate + "&trans_type=" + trans_type + "&selecttype=" + selecttype);
        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "CancelRp", "window.open('CancelRpt.aspx?UID=" + Session["U_NAME"].ToString() + "&companycode=" + companycode + "&status=" + status + "&fromdate=" + fromDate + "&todate=" + toDate + "&trans_type=" + trans_type + "&selecttype=" + selecttype + "', 'CS', 'left=0,top=0, height= '+ screen.availHeight +' , width= '+ screen.availWidth +',menubar=no,location=no,toolbar=no,scrollbars=nO,resizable=no');", true);



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
            string CCode = dsu.Tables[0].Rows[0]["Company_Code"].ToString();
            if (usertype.ToString() != "COMPANY")
            {
                ds = lov.Get_Company_setup_lov("%", "%");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow dr = ds.Tables[0].NewRow();
                    dr["Company_Code"] = "AAA";
                    dr["Company_Name"] = "ALL";
                    ds.Tables[0].Rows.Add(dr);
                    dt = ds.Tables[0];
                    dt.DefaultView.Sort = "Company_Code ASC";
                    dt = dt.DefaultView.ToTable();
                    ddlCompanyCode.DataSource = dt;
                    ddlCompanyCode.DataValueField = "Company_Code";
                    ddlCompanyCode.DataTextField = "Company_Name";
                    ddlCompanyCode.DataBind();
                    //((DropDownList)FormView1.FindControl("ddlCompanyCode_EDIT")).SelectedValue = Session["COMCODE"].ToString();
                }
                else
                {
                    companycode = CCode;

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
    protected void RB_Deposit_CheckedChanged(object sender, EventArgs e)
    {

    }
}

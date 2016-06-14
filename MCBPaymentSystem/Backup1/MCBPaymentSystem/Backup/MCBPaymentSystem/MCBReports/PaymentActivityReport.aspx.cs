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

public partial class PaymentActivityReport : System.Web.UI.Page
{
    LOV_COLLECTION lov = new LOV_COLLECTION();
    static string companycode;
    static string companyname;
    static string usertype = "";
    static string branch_id="";
    protected void Page_PreInit(object sender, EventArgs e)
    { 
        Page.Theme = Session["ThemeChange"].ToString(); 
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
       // Session["U_NAME"] = "SHAHEEN1";
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
            CompanyName();
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

       /// string COMPANYCODE = companycode;/// (ddlCompanyCode.SelectedValue == "AAA") ? "" : ddlCompanyCode.SelectedValue;
        
        string status = "P";//(ddlStatus.SelectedValue == "NULL") ? "" : ddlStatus.SelectedValue;
        string fromDate = (TXT_FROM.Text == "") ? DateTime.Now.ToString("dd-MM-yyyy") : TXT_FROM.Text;
        string toDate = (TXT_TO.Text == "") ? DateTime.Now.ToString("dd-MM-yyyy") : TXT_TO.Text;
      //  string trans_type = (DDL_TransType.SelectedValue.ToString() == "NULL") ? "" : DDL_TransType.SelectedValue.ToString();
       /// string selecttype="Deposit";
        
        //if (RB_Payment.Checked == true)
        //{
        string selecttype = "Payment";
        //}


        Response.Redirect("PaymentActivityRpt.aspx?branch_id=" + branch_id + "&status=" + status + "&fromdate=" + fromDate + "&todate=" + toDate + "&selecttype=" + selecttype);
        



    }
    //public void ddlCompanyBind()
    //{
    //    DataSet ds = new DataSet();
    //    DataSet dsu = new DataSet();
    //    DataTable dt = new DataTable();
    //    dsu = lov.SP_GET_USERIFNO(Session["U_NAME"].ToString());
    //    if (dsu.Tables[0].Rows.Count > 0)
    //    {
    //        usertype = dsu.Tables[0].Rows[0]["USER_TYPE"].ToString();
    //        if (usertype.ToString() != "COMPANY")
    //        {
    //            ds = lov.Get_Company_setup_lov("%", "%");
    //            if (ds.Tables[0].Rows.Count > 0)
    //            {
    //                dt = ds.Tables[0];
    //                dt.DefaultView.Sort = "Company_Code ASC";
    //                dt = dt.DefaultView.ToTable();
    //                ddlCompanyCode.DataSource = dt;
    //                ddlCompanyCode.DataValueField = "Company_Code";
    //                ddlCompanyCode.DataTextField = "Company_Name";
    //                ddlCompanyCode.DataBind();
    //                //((DropDownList)FormView1.FindControl("ddlCompanyCode_EDIT")).SelectedValue = Session["COMCODE"].ToString();
    //            }
    //            else
    //            {

    //            }
    //        }
    //    }
    //}
    public void CompanyName()
    {
        DataSet ds = new DataSet();
        DataSet dsC = new DataSet();
        DataTable dt = new DataTable();
        dsC = lov.SP_GET_USERIFNO(Session["U_NAME"].ToString());
        if (dsC.Tables[0].Rows.Count > 0)
        {
            branch_id = dsC.Tables[0].Rows[0]["BRANCH_CODE"].ToString();
            //companyname = dsC.Tables[0].Rows[0]["company_name"].ToString();
            //lblcompanyname.Text = dsC.Tables[0].Rows[0]["company_name"].ToString();
            //lblcompanyname.ForeColor = System.Drawing.Color.Black;
        }
        else
        {
            //lblcompanyname.Text = Session["U_NAME"].ToString() + " is not company user ";
            //lblcompanyname.ForeColor = System.Drawing.Color.Black;
        }
    }
    protected void RB_Deposit_CheckedChanged(object sender, EventArgs e)
    {

    }
}

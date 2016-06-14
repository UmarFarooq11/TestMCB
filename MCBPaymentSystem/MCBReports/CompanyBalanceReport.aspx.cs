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

public partial class CompanyBalanceReport : System.Web.UI.Page
{
    LOV_COLLECTION lov = new LOV_COLLECTION();
    DataTable dt = new DataTable();
    string balance;
    static string companycode;
    static string companyname;
    protected void Page_PreInit(object sender, EventArgs e)
    { 
        Page.Theme = Session["ThemeChange"].ToString(); 
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        //TXT_FROM.Attributes.Add("readonly", "readonly");
        //TXT_TO.Attributes.Add("readonly", "readonly");
        string msg = Request.QueryString["msg"];
        if (msg != "")
        {
            lblmessage.Text = msg;
        }
    }
    protected void btn_OK_Click(object sender, EventArgs e)
    {

        //string COMPANYCODE = companycode;/// (ddlCompanyCode.SelectedValue == "AAA") ? "" : ddlCompanyCode.SelectedValue;
        //string COMPANYNAME = companyname;///ddlCompanyCode.SelectedItem.Text;
        //string fromDate = (TXT_FROM.Text == "") ? DateTime.Now.ToString("dd-MM-yyyy") : TXT_FROM.Text;
        //string toDate = (TXT_TO.Text == "") ? DateTime.Now.ToString("dd-MM-yyyy") : TXT_TO.Text;
        ////string trans_type = (DDL_TransType.SelectedValue.ToString() == "NULL") ? "" : DDL_TransType.SelectedValue.ToString();
        
        //    DataSet dsbal = new DataSet();
        //    //dsbal = lov.SP_COMPANY_BALANCE(ddlCompanyCode.SelectedValue.ToString());
        //    dsbal = lov.SP_COMPANY_BALANCE(companycode);
        //    if (dsbal.Tables[0].Rows.Count >0)
        //    {
        //        balance = dsbal.Tables[0].Rows[0]["BALANCE_AMOUNT"].ToString();
        //        balance = Convert.ToDouble(balance).ToString("###,###,#0.00");
        //    }    
        Response.Redirect("CompanyBalanceRpt.aspx");
        
    }
    //public void ddlCompanyBind()
    //{
    //    DataSet ds = new DataSet();
    //    ds = lov.sp_get_companyname(Session["U_NAME"].ToString());
    //    if (ds.Tables[0].Rows.Count > 0)
    //    {
    //        companycode = ds.Tables[0].Rows[0]["company_code"].ToString();
    //        companyname = ds.Tables[0].Rows[0]["company_name"].ToString();
    //        lblcompanyname.Text = ds.Tables[0].Rows[0]["company_name"].ToString();
    //    }
    //    else
    //    {
    //        lblcompanyname.Text = Session["U_NAME"].ToString() + " is not company user ";
    //    }
    //    //ds = lov.Get_Company_setup_lov("%", "%");
    //    //if (ds.Tables[0].Rows.Count > 0)
    //    //{
    //    //    //DataRow dr = ds.Tables[0].NewRow();
    //    //    //dr["Company_Code"] = " ";
    //    //    //dr["Company_Name"] = "Select";
    //    //    //ds.Tables[0].Rows.Add(dr);
            
    //    //    dt = ds.Tables[0];
    //    //    dt.DefaultView.Sort = "Company_Code ASC";
    //    //    dt = dt.DefaultView.ToTable();
    //    //    ddlCompanyCode.DataSource = dt;
    //    //    ddlCompanyCode.DataValueField = "Company_Code";
    //    //    ddlCompanyCode.DataTextField = "Company_Name";
    //    //    ddlCompanyCode.DataBind();
    //    //    //((DropDownList)FormView1.FindControl("ddlCompanyCode_EDIT")).SelectedValue = Session["COMCODE"].ToString();
    //    //}
    //    //else
    //    //{

    //    //}
    //}
    
}

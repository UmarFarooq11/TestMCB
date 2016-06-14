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

public partial class PRCReport : System.Web.UI.Page
{
    LOV_COLLECTION lov = new LOV_COLLECTION();
    DataTable dt = new DataTable();
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
    }
    protected void btn_OK_Click(object sender, EventArgs e)
    {
        if (TXT_ACC_NO.Text == "" && TXT_REF_NO.Text == "" && txt_from_date.Text == "" && txt_to_date.Text == "")
        {
            lblmessage.Text = "Please input value.";
            return;
        }
        Response.Redirect("PRCRpt.aspx?Account_no=" + TXT_ACC_NO.Text + "&ref_no=" + TXT_REF_NO.Text + "&RemePurpose=" + TXT_PURP_REMET.Text + "&from_date=" + txt_from_date.Text + "&to_date=" + txt_to_date.Text + "&bankname=" + txt_bank_name.Text);
    }



}

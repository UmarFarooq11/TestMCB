using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class AuthorizationMatrix_AuthorisationMatrixView : System.Web.UI.Page
{
    string[] ARY;
    string RGS_SUPPORT;
    LOV_COLLECTION obj_Collection = new LOV_COLLECTION();

    protected void Page_Load(object sender, EventArgs e)
    {
        ViewState["QS"] = Request.QueryString;
        Response.Cache.SetCacheability(HttpCacheability.ServerAndNoCache);
        //Master.Authorize_Center_False();
        Session["RGS"] = "00000";
        String ST = Startup_Util.DcryptionPWD(Request.QueryString[0].ToString());
        ARY = ST.Split('~');
        Session["RGS"] = ARY[0].ToString();
        RGS_SUPPORT = Session["RGS"].ToString();



        if (RGS_SUPPORT.Substring(0, 1) == "0")
        {
            TXT_NEW_USER.Visible = false; /*ADD*/
        }
        else if (RGS_SUPPORT.Substring(0, 1) == "1")
        {
            TXT_NEW_USER.Visible = true;/*ADD*/
        }
        if (RGS_SUPPORT.Substring(3, 1) == "0")
        {
            Response.Redirect("../MasterPage/Default2.aspx"); /*QUERY*/
            MessageClass.MessageBox.Show("Access Deined");
        }
        if (!IsPostBack)
        {
            Session["COMCode"] = "%";
            Session["ProductCode"] = "%";
            Session["Mode"] = "V";
        }
    }
    protected void Page_PreRender(object sender, EventArgs e)
    {
        CustomerProductAccountSetup();
    }
    protected void CMD_MoveNext_Click(object sender, ImageClickEventArgs e)
    { GridView1.PageIndex = GridView1.PageIndex + 1; }
    protected void CMD_MoveBack_Click(object sender, ImageClickEventArgs e)
    {
        if (GridView1.PageIndex == 0)
        { return; }
        else
        { GridView1.PageIndex = GridView1.PageIndex - 1; }
    }
    protected void CMD_MoveLast_Click(object sender, ImageClickEventArgs e)
    { GridView1.PageIndex = GridView1.PageCount - 1; }
    protected void CMD_MoveFirst_Click(object sender, ImageClickEventArgs e)
    { GridView1.PageIndex = 0; }
    protected void DRP_LIST_SelectedIndexChanged(object sender, EventArgs e)
    { GridView1.PageIndex = Convert.ToInt16(DRP_LIST.Text) - 1; }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["COMCode"] = GridView1.SelectedRow.Cells[0].Text;
        Session["ProductCode"] = GridView1.SelectedRow.Cells[2].Text;
        Session["Mode"] = "D";
        Response.Redirect("AuthorisationMatrix.aspx?" + ViewState["QS"]);
    }
    protected void TXT_NEW_USER_Click(object sender, EventArgs e)
    {
        Session["COMCode"] = "";
        Session["ProductCode"] = "";
        Session["Mode"] = "V";
        Response.Redirect("AuthorisationMatrix.aspx?" + ViewState["QS"]);
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Session["COMCode"] = txtcompanycode.Text;
        Session["ProductCode"] = txtProductcode.Text;
        Session["Mode"] = "V";
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        txtcompanycode.Text = "";
        txtProductcode.Text = "";
        Session["COMCode"] = "";
        Session["ProductCode"] = "";
        Session["Mode"] = "";
    }
    void CustomerProductAccountSetup()
    {
        DataSet UserDs = obj_Collection.Get_Company_CodebyUser(Session["U_NAME"].ToString());
        if (UserDs.Tables[0].Rows.Count > 0)
        {
            if (UserDs.Tables[0].Rows[0]["USER_TYPE"].ToString() == "COMPANY")
            {
                Session["COMCode"] = UserDs.Tables[0].Rows[0]["COMPANY_CODE"].ToString();
            }
        }
    }
}

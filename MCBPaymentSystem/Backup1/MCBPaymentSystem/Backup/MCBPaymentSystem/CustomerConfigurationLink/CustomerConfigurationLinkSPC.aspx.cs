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

public partial class CustomerConfigurationLinkSPC : System.Web.UI.Page
{
    FormViewRow D_TEMP;
    TextBox TXT;
    Label LL;

    PROCESS_CustomerConfigLink P_CustomerConfigLink = new PROCESS_CustomerConfigLink();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["COMPANY_CODE"].ToString() == "0")
        {
            FormView1.ChangeMode(FormViewMode.Insert);
            ((Label)FormView1.Row.FindControl("Label_HEAD")).Text = "Customer Configuration Link";
        }
        else
        {
            //((Label)FormView1.FindControl("Label_HEAD")).Text = "Customer Configuration : ";// +Session["COMPANY_CODE"].ToString() + "";

            // / " + Session["CMN_Currency_CurrencyName"].ToString();
            //if (IsPostBack == false)
            //{
            //    ((EO.Web.ToolBar)FormView1.FindControl("DisplayToolBar")).Items[0].Disabled = false;
            //    ((EO.Web.ToolBar)FormView1.FindControl("DisplayToolBar")).Items[2].Disabled = false;
            //    ((EO.Web.ToolBar)FormView1.FindControl("DisplayToolBar")).Items[4].Disabled = false;
            //}
            if (IsPostBack == false)
            {
                string RGS_SUPPORT;
                RGS_SUPPORT = Session["RGS"].ToString();
                /*
                ((EO.Web.ToolBar)FormView1.FindControl("DisplayToolBar")).Items[0].Disabled = false;
                ((EO.Web.ToolBar)FormView1.FindControl("DisplayToolBar")).Items[2].Disabled = false;
                ((EO.Web.ToolBar)FormView1.FindControl("DisplayToolBar")).Items[4].Disabled = false;
                */
                if (RGS_SUPPORT.Substring(2, 1) == "0")
                { ((EO.Web.ToolBar)FormView1.FindControl("DisplayToolBar")).Items[0].Disabled = true; /*Edit*/}
                else if (RGS_SUPPORT.Substring(2, 1) == "1")
                { ((EO.Web.ToolBar)FormView1.FindControl("DisplayToolBar")).Items[0].Disabled = false; /*Edit*/}
                if (RGS_SUPPORT.Substring(4, 1) == "0")
                {
                    ((EO.Web.ToolBar)FormView1.FindControl("DisplayToolBar")).Items[4].Disabled = true; /*Authorize / Unauthorize*/
                    ((EO.Web.ToolBar)FormView1.FindControl("DisplayToolBar")).Items[2].Disabled = false;
                }
                else if (RGS_SUPPORT.Substring(4, 1) == "1")
                {
                    ((EO.Web.ToolBar)FormView1.FindControl("DisplayToolBar")).Items[4].Disabled = false; /*Authorize / Unauthorize*/
                    ((EO.Web.ToolBar)FormView1.FindControl("DisplayToolBar")).Items[2].Disabled = false;
                }
            }
        }
    }
    protected void FormView1_PageIndexChanging(object sender, FormViewPageEventArgs e) 
    { }
    private void BackPage()
    {
        Session["COMPANY_CODE"] = "0";
        Session["CONF_DEF_ID"] = "0";
        // Session["CMN_Currency_CurrencyName"] = "0";
        //   Session["CMN_Currency_ShortName"] = "0";
        // Response.Redirect("../CurrencySetup/frmCMN_Currency.aspx");
        Response.Redirect("../CustomerConfigurationLink/CustomerConfigurationLink.aspx" + "?" + "s1=" + Request.QueryString[0].ToString());
    }
    protected void Page_PreInit(object sender, EventArgs e)
    { Page.Theme = Session["ThemeChange"].ToString(); }
    protected void DisplayToolBar_ItemClick(object sender, EO.Web.ToolBarEventArgs e)
    {
        if (e.Item.ToolTip == "Edit")
        { 
            FormView1.ChangeMode(FormViewMode.Edit); 
        }
        else if (e.Item.ToolTip == "Cancel")
        { 
            BackPage(); 
        }
        else if (e.Item.ToolTip == "Delete")
        {
            P_CustomerConfigLink.RecordInputStart();
            P_CustomerConfigLink.Get_COMPANY_CODE = ((Label)FormView1.FindControl("TXT_CurrencyCode_DISPLAY")).Text;
            P_CustomerConfigLink.Get_CONF_DEF_ID = ((Label)FormView1.FindControl("TXT_TXT_ConfigdeflinkID_DISPLAY")).Text;
            P_CustomerConfigLink.RecordInputCommit();
            P_CustomerConfigLink.DeleteNewGroup();
            BackPage();
        }
    }
    protected void EditToolbar_ItemClick(object sender, EO.Web.ToolBarEventArgs e)
    {
        //Page.Validate();
        //if (e.Item.ToolTip == "Update")
        //{
            //if (Page.IsValid)
            //{
                //LOV_COLLECTION L = new LOV_COLLECTION();
                //DataSet DS;
                //  DS = L.SP_Currency_DP(((TextBox)FormView1.FindControl("TXT_CurrencyCode_EDIT")).Text, Session["CMN_Currency_ID"].ToString());
                //if (DS.Tables[0].Rows.Count > 0)
                //{
                //    ((Label)FormView1.FindControl("lblDuplicate_EDIT")).Text = "Duplicate Record";
                //}
                //else
                //{
                //if (DS.Tables[0].Rows.Count <= 0)
                //{

                //P_CustomerConfigLink.RecordInputStart();
                //P_CustomerConfigLink.Get_COMPANY_CODE = ((TextBox)FormView1.FindControl("TXT_CustomerCode_EDIT")).Text;
                //P_CustomerConfigLink.Get_CONF_DEF_ID = ((TextBox)FormView1.FindControl("TXT_ConfigDefID_EDIT")).Text;
                //P_CustomerConfigLink.RecordInputCommit();
                //P_CustomerConfigLink.EditNewGroup();
                //BackPage();
                //}
                //else
                //{
                //  ((TextBox)FormView1.FindControl("TXT_CurrencyCode_EDIT")).Text = "";
                //  ((RequiredFieldValidator)FormView1.FindControl("REQ_CurrencyCode_EDIT")).Validate();
                //  }
                //    }

            //}
        //}
        //else if (e.Item.ToolTip == "Cancel")
        //{ BackPage(); }
    }
    protected void InsertToolbar_ItemClick(object sender, EO.Web.ToolBarEventArgs e)
    {
        Page.Validate();
        if (e.Item.ToolTip == "Insert")
        {
            if (Page.IsValid)
            {
                //LOV_COLLECTION L = new LOV_COLLECTION();
                //DataSet DS;
                //DS = L.SP_Currency_DP(((TextBox)FormView1.FindControl("TXT_CurrencyCode_INSERT")).Text, "0");
                //if (DS.Tables[0].Rows.Count > 0)
                //{
                //    ((Label)FormView1.FindControl("lblDuplicate_INSERT")).Text = "Duplicate Record";
                //}
                //else
                //{
                //    if (DS.Tables[0].Rows.Count <= 0)
                //    {

                P_CustomerConfigLink.RecordInputStart();
                P_CustomerConfigLink.Get_COMPANY_CODE = ((TextBox)FormView1.FindControl("TXT_CustomerCode_INSERT")).Text;
                P_CustomerConfigLink.Get_CONF_DEF_ID = ((TextBox)FormView1.FindControl("TXT_ConfigDefID_INSERT")).Text;
                P_CustomerConfigLink.Get_FTP_LOADPATH = ((TextBox)FormView1.FindControl("TXT_Upload_Path_INSERT")).Text;
                P_CustomerConfigLink.Get_FTP_USERID = ((TextBox)FormView1.FindControl("TXT_Upload_UserID_INSERT")).Text;
                P_CustomerConfigLink.Get_FTP_PASSWORD = ((TextBox)FormView1.FindControl("TXT_Upload_Password_INSERT")).Text;
                P_CustomerConfigLink.Get_FTP_MOVEPATH = ((TextBox)FormView1.FindControl("TXT_Move_Path_INSERT")).Text;
                P_CustomerConfigLink.Get_FTP_MOVE_USERID = ((TextBox)FormView1.FindControl("TXT_Move_UserID_INSERT")).Text;
                P_CustomerConfigLink.Get_FTP_PASSWORD = ((TextBox)FormView1.FindControl("TXT_Move_Password_INSERT")).Text;
                //P_CMN_Currency.Get_A_UserID = Session["U_NAME"].ToString(); //"0";
                //P_CMN_Currency.Get_A_DateTime = DateTime.Now.ToString("dd-MMM-yyyy").ToString();
                //P_CMN_Currency.Get_E_UserID = Session["U_NAME"].ToString();
                //P_CMN_Currency.Get_E_DateTime = DateTime.Now.ToString("dd-MMM-yyyy").ToString();
                P_CustomerConfigLink.RecordInputCommit();
                P_CustomerConfigLink.AddNewGroup();
                BackPage();
                //    }
                //    else
                //    {
                //        ((TextBox)FormView1.FindControl("TXT_CurrencyCode_INSERT")).Text = "";
                //        ((RequiredFieldValidator)FormView1.FindControl("REQ_CurrencyCode_INSERT")).Validate();
                //    }
                //}
            }
        }
        else if (e.Item.ToolTip == "Cancel")
        { BackPage(); }
    }
    //protected void FormView1_DataBound(object sender, EventArgs e)
    //{
    //    if (FormView1.CurrentMode.ToString() == "Edit")
    //    {

    //    }
    //    else if (FormView1.CurrentMode.ToString() == "Insert")
    //    {
    //        //((TextBox)FormView1.FindControl("TXT_CustomerCode_INSERT")).Attributes.Add("onKeyPress", "javascript: return false;");
    //        //((TextBox)FormView1.FindControl("TXT_CustomerName_INSERT")).Attributes.Add("onKeyPress", "javascript: return false;");
    //        //((TextBox)FormView1.FindControl("TXT_ConfigDefID_INSERT")).Attributes.Add("onKeyPress", "javascript: return false;");
    //        //((TextBox)FormView1.FindControl("TXT_ConfigDefName_INSERT")).Attributes.Add("readonly", "readonly");
    //    }

    //}
    protected void BTN_CustomerCode_INSERT_Click(object sender, ImageClickEventArgs e)
    {
        if (Session["LOV_ID"].ToString() != "")
        {
            ((TextBox)FormView1.FindControl("TXT_CustomerCode_INSERT")).Text = Session["LOV_ID"].ToString();
            ((TextBox)FormView1.FindControl("TXT_CustomerName_INSERT")).Text = Session["LOV_DESCRIPTION"].ToString();
            ((TextBox)FormView1.FindControl("TXT_ConfigDefID_INSERT")).Text = "";
            ((TextBox)FormView1.FindControl("TXT_ConfigDefName_INSERT")).Text = "";
            Session["PARATYPE"] = "1";
        }
    }
    protected void BTN_ConfigDefID_INSERT_Click(object sender, ImageClickEventArgs e)
    {
        if (Session["LOV_ID"].ToString() != "")
        {
            ((TextBox)FormView1.FindControl("TXT_ConfigDefID_INSERT")).Text = Session["CONF_DEF_ID"].ToString();
            ((TextBox)FormView1.FindControl("TXT_ConfigDefName_INSERT")).Text = Session["CONF_DEF_desc"].ToString();
        }
    }
    protected void BTN_CustomerCode_EDIT_Click(object sender, ImageClickEventArgs e)
    {
        if (Session["LOV_ID"].ToString() != "")
        {
            ((TextBox)FormView1.FindControl("TXT_CustomerCode_EDIT")).Text = Session["LOV_ID"].ToString();
            ((TextBox)FormView1.FindControl("TXT_CustomerName_EDIT")).Text = Session["LOV_DESCRIPTION"].ToString();
            ((TextBox)FormView1.FindControl("TXT_ConfigDefID_INSERT")).Text = "";
            ((TextBox)FormView1.FindControl("TXT_ConfigDefName_INSERT")).Text = "";
            Session["PARATYPE"] = "1";
        }
    }
    protected void BTN_ConfigDefID_EDIT_Click(object sender, ImageClickEventArgs e)
    {
        if (Session["LOV_ID"].ToString() != "")
        {
            ((TextBox)FormView1.FindControl("TXT_ConfigDefID_EDIT")).Text = Session["CONF_DEF_ID"].ToString();
            ((TextBox)FormView1.FindControl("TXT_ConfigDefName_EDIT")).Text = Session["CONF_DEF_desc"].ToString();
        }
    }
    //protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    //{
    //    if (Session["LOV_ID"].ToString() != "")
    //    {
    //        ((TextBox)FormView1.FindControl("TXT_CustomerCode_INSERT")).Text = Session["LOV_ID"].ToString();
    //        ((TextBox)FormView1.FindControl("TXT_CustomerName_INSERT")).Text = Session["LOV_DESCRIPTION"].ToString();
    //        ((TextBox)FormView1.FindControl("TXT_ConfigDefID_INSERT")).Text = "";
    //        ((TextBox)FormView1.FindControl("TXT_ConfigDefName_INSERT")).Text = "";
    //        Session["PARATYPE"] = "1";
    //    }
    //}
    //protected void FormView1_DataBound(object sender, EventArgs e)
    //{

    //}
   
}
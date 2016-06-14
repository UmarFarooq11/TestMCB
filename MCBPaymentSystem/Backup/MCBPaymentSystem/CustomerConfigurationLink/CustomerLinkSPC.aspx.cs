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

public partial class CustomerLinkSPC : System.Web.UI.Page
{
    FormViewRow D_TEMP;
    TextBox TXT;
    Label LL;
    static String DraftNo;

    LOV_COLLECTION lov = new LOV_COLLECTION();
    PROCESS_CustomerConfigLink P_CustomerConfigLink = new PROCESS_CustomerConfigLink();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["COMPANY_CODE"].ToString() == "0")
        {
            FormView1.ChangeMode(FormViewMode.Insert);
            ((Label)FormView1.Row.FindControl("Label_HEAD")).Text = "Customer Configuration Link";
            if (!IsPostBack)
            {

            }
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
                //if (RGS_SUPPORT.Substring(2, 1) == "0")
                //{ ((EO.Web.ToolBar)FormView1.FindControl("DisplayToolBar")).Items[0].Disabled = false; /*Edit*/}
                //else if (RGS_SUPPORT.Substring(2, 1) == "1")
                //{ ((EO.Web.ToolBar)FormView1.FindControl("DisplayToolBar")).Items[0].Disabled = false; /*Edit*/}
                //if (RGS_SUPPORT.Substring(4, 1) == "0")
                //{
                //    ((EO.Web.ToolBar)FormView1.FindControl("DisplayToolBar")).Items[4].Disabled = true; /*Authorize / Unauthorize*/
                //    ((EO.Web.ToolBar)FormView1.FindControl("DisplayToolBar")).Items[2].Disabled = false;
                //}
                //else if (RGS_SUPPORT.Substring(4, 1) == "1")
                //{
                //    ((EO.Web.ToolBar)FormView1.FindControl("DisplayToolBar")).Items[4].Disabled = false; /*Authorize / Unauthorize*/
                //    ((EO.Web.ToolBar)FormView1.FindControl("DisplayToolBar")).Items[2].Disabled = false;
                //}
                if (RGS_SUPPORT.Substring(2, 1) == "0")
                {
                    if (FormView1.CurrentMode == FormViewMode.ReadOnly)
                    { ((Button)FormView1.FindControl("BTN_EDIT")).Enabled = false; /*Edit*/}
                }
                else if (RGS_SUPPORT.Substring(2, 1) == "1")
                {
                    if (FormView1.CurrentMode == FormViewMode.ReadOnly)
                    { ((Button)FormView1.FindControl("BTN_EDIT")).Enabled = true; /*Edit*/}
                }

                if (RGS_SUPPORT.Substring(4, 1) == "0")
                {
                   // Master.Authorize_Center_False();
                }
                else if (RGS_SUPPORT.Substring(4, 1) == "1")
                {
                 //  Master.Authorize_Center_True();
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
        Response.Redirect("../CustomerConfigurationLink/CustomerConfigurationLink.aspx" + "?" + "s1=" + Request.QueryString[0].ToString());
    }
    protected void Page_PreInit(object sender, EventArgs e)
    { Page.Theme = Session["ThemeChange"].ToString(); }
    protected void DisplayToolBar_ItemClick(object sender, EO.Web.ToolBarEventArgs e)
    {
        //if (e.Item.ToolTip == "Edit")
        //{ FormView1.ChangeMode(FormViewMode.Edit); }
        //else if (e.Item.ToolTip == "Cancel")
        //{ BackPage(); }
        //else if (e.Item.ToolTip == "Authorize / Unauthorize")
        //{
        //    //LOV_COLLECTION lov = new LOV_COLLECTION();
        //    //DataSet ds = new DataSet();
        //    //ds = lov.Get_SP_RPS_DraftCancellation_Authorized(((Label)FormView1.FindControl("TXT_ID_DISPLAY")).Text, Session["UserId"].ToString(), System.DateTime.Now.ToString());
        //    //BackPage();
        //}
    }
    //protected void EditToolbar_ItemClick(object sender, EO.Web.ToolBarEventArgs e)
    //{
    //    if (e.Item.ToolTip == "Update")
    //    {
    //        P_CustomerConfigLink.RecordInputStart();
    //        P_CustomerConfigLink.Get_ID = FormView1.DataKey.Value.ToString();
    //        P_CustomerConfigLink.Get_COMPANY_CODE = ((DropDownList)FormView1.FindControl("ddlCompanyCode_EDIT")).SelectedValue.ToString();
    //        P_CustomerConfigLink.Get_CONF_DEF_ID = ((DropDownList)FormView1.FindControl("ddlConfigID_EDIT")).SelectedValue.ToString();
    //        P_CustomerConfigLink.Get_FTP_LOADPATH = ((TextBox)FormView1.FindControl("TXT_Upload_Path_EDIT")).Text;
    //        P_CustomerConfigLink.Get_FTP_USERID = ((TextBox)FormView1.FindControl("TXT_Upload_UserID_EDIT")).Text;
    //        P_CustomerConfigLink.Get_FTP_PASSWORD = ((TextBox)FormView1.FindControl("TXT_Upload_Password_EDIT")).Text;
    //        P_CustomerConfigLink.Get_FTP_MOVEPATH = ((TextBox)FormView1.FindControl("TXT_Move_Path_EDIT")).Text;
    //        P_CustomerConfigLink.Get_FTP_MOVE_USERID = ((TextBox)FormView1.FindControl("TXT_Move_UserID_EDIT")).Text;
    //        P_CustomerConfigLink.Get_FTP_MOVE_PASSWORD = ((TextBox)FormView1.FindControl("TXT_Move_Password_EDIT")).Text;
    //        P_CustomerConfigLink.RecordInputCommit();
    //        P_CustomerConfigLink.EditNewGroup();
    //        BackPage();
    //    }
    //    else if (e.Item.ToolTip == "Cancel")
    //    { 
    //        BackPage(); 
    //    }
    //}
    //protected void InsertToolbar_ItemClick(object sender, EO.Web.ToolBarEventArgs e)
    //{
    //    Page.Validate();
    //    if (e.Item.ToolTip == "Insert")
    //    {
    //        if (Page.IsValid)
    //        {
    //            #region
    //            //LOV_COLLECTION L = new LOV_COLLECTION();
    //            //DataSet DS;
    //            //DS = L.SP_Currency_DP(((TextBox)FormView1.FindControl("TXT_CurrencyCode_INSERT")).Text, "0");
    //            //if (DS.Tables[0].Rows.Count > 0)
    //            //{
    //            //    ((Label)FormView1.FindControl("lblDuplicate_INSERT")).Text = "Duplicate Record";
    //            //}
    //            //else
    //            //{
    //            //    if (DS.Tables[0].Rows.Count <= 0)
    //            //    {
    //            #endregion
    //            P_CustomerConfigLink.RecordInputStart();
    //            P_CustomerConfigLink.Get_COMPANY_CODE = ((DropDownList)FormView1.FindControl("ddlCompanyCode")).SelectedValue.ToString();
    //            P_CustomerConfigLink.Get_CONF_DEF_ID = ((DropDownList)FormView1.FindControl("ddlConfigID")).SelectedValue.ToString();
    //            P_CustomerConfigLink.Get_FTP_LOADPATH = ((TextBox)FormView1.FindControl("TXT_Upload_Path_INSERT")).Text;
    //            P_CustomerConfigLink.Get_FTP_USERID = ((TextBox)FormView1.FindControl("TXT_Upload_UserID_INSERT")).Text;
    //            P_CustomerConfigLink.Get_FTP_PASSWORD = ((TextBox)FormView1.FindControl("TXT_Upload_Password_INSERT")).Text;
    //            P_CustomerConfigLink.Get_FTP_MOVEPATH = ((TextBox)FormView1.FindControl("TXT_Move_Path_INSERT")).Text;
    //            P_CustomerConfigLink.Get_FTP_MOVE_USERID = ((TextBox)FormView1.FindControl("TXT_Move_UserID_INSERT")).Text;
    //            P_CustomerConfigLink.Get_FTP_MOVE_PASSWORD = ((TextBox)FormView1.FindControl("TXT_Move_Password_INSERT")).Text;
    //            P_CustomerConfigLink.RecordInputCommit();
    //            P_CustomerConfigLink.AddNewGroup();
    //            BackPage();
    //        }
    //    }
    //    else if (e.Item.ToolTip == "Cancel")
    //    { BackPage(); }
    //}
    protected void BTN_ConfigCode_INSERT_Click(object sender, ImageClickEventArgs e)
    {
        if (Session["LOV_ID"].ToString() != "")
        {
            ((TextBox)FormView1.FindControl("TXT_ConfigCode_INSERT")).Text = Session["CONF_DEF_ID"].ToString();
            ((TextBox)FormView1.FindControl("TXT_ConfigDefName_INSERT")).Text = Session["CONF_DEF_desc"].ToString();
        }
    }
    protected void BTN_CompanyCode_INSERT_Click(object sender, ImageClickEventArgs e)
    {
        if (Session["LOV_ID"].ToString() != "")
        {
            ((TextBox)FormView1.FindControl("TXT_CompanyCode_INSERT")).Text = Session["LOV_ID"].ToString();
            ((TextBox)FormView1.FindControl("TXT_CustomerName_INSERT")).Text = Session["LOV_DESCRIPTION"].ToString();
            ((TextBox)FormView1.FindControl("TXT_ConfigCode_INSERT")).Text = "";
            ((TextBox)FormView1.FindControl("TXT_ConfigDefName_INSERT")).Text = "";
            Session["PARATYPE"] = "1";
        }
    }
    protected void ddlCompanyCode_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlConfigIDBind();
    }
    public void ddlCompanyBind()
    {
        DataSet ds = new DataSet();
        ds = lov.Get_Company_setup_lov("%", "%");
        if (ds.Tables[0].Rows.Count > 0)
        {
            if (FormView1.CurrentMode.ToString() == "Insert")
            {
                ((DropDownList)FormView1.FindControl("ddlCompanyCode")).DataSource = ds;
                ((DropDownList)FormView1.FindControl("ddlCompanyCode")).DataValueField = "Company_Code";
                ((DropDownList)FormView1.FindControl("ddlCompanyCode")).DataTextField = "Company_Name";
                ((DropDownList)FormView1.FindControl("ddlCompanyCode")).DataBind();
            }
            else if (FormView1.CurrentMode.ToString() == "Edit")
            {
                ((DropDownList)FormView1.FindControl("ddlCompanyCode_EDIT")).DataSource = ds;
                ((DropDownList)FormView1.FindControl("ddlCompanyCode_EDIT")).DataValueField = "Company_Code";
                ((DropDownList)FormView1.FindControl("ddlCompanyCode_EDIT")).DataTextField = "Company_Name";
                ((DropDownList)FormView1.FindControl("ddlCompanyCode_EDIT")).DataBind();
                ((DropDownList)FormView1.FindControl("ddlCompanyCode_EDIT")).SelectedValue = Session["COMCODE"].ToString();

            }
        }
        else
        {

        }
    }
    public void ddlConfigIDBind()
    {

        if (FormView1.CurrentMode.ToString() == "Insert")
        {
            DropDownList ddlCompany = ((DropDownList)FormView1.FindControl("ddlCompanyCode"));
            DataSet ds = new DataSet();
            ds = lov.Get_CONFIG_DEF_MASTER_LOV("1", ddlCompany.SelectedValue, "%", "%");
            if (ds.Tables[0].Rows.Count > 0)
            {
            
                ((DropDownList)FormView1.FindControl("ddlConfigID")).DataSource = ds;
                ((DropDownList)FormView1.FindControl("ddlConfigID")).DataValueField = "CONF_DEF_ID";
                ((DropDownList)FormView1.FindControl("ddlConfigID")).DataTextField = "CONF_DEF_DESC";
                ((DropDownList)FormView1.FindControl("ddlConfigID")).DataBind();
            }
        }
        if (FormView1.CurrentMode.ToString() == "Edit")
        {
            DropDownList ddlCompany = ((DropDownList)FormView1.FindControl("ddlCompanyCode_EDIT"));
            DataSet ds = new DataSet();
            ds = lov.Get_CONFIG_DEF_MASTER_LOV("1", ddlCompany.SelectedValue, "%", "%");
            if (ds.Tables[0].Rows.Count > 0)
            {
                ((DropDownList)FormView1.FindControl("ddlConfigID_EDIT")).DataSource = ds;
                ((DropDownList)FormView1.FindControl("ddlConfigID_EDIT")).DataValueField = "CONF_DEF_ID";
                ((DropDownList)FormView1.FindControl("ddlConfigID_EDIT")).DataTextField = "CONF_DEF_DESC";
                ((DropDownList)FormView1.FindControl("ddlConfigID_EDIT")).DataBind();
                ((DropDownList)FormView1.FindControl("ddlConfigID_EDIT")).SelectedValue = Session["CONF_DEF"].ToString();
            }
        }
        
    }
    protected void FormView1_DataBound(object sender, EventArgs e)
    {
        if (FormView1.CurrentMode.ToString() == "Insert")
        {
            ddlCompanyBind();
            ddlConfigIDBind();
        }
        else if (FormView1.CurrentMode.ToString() == "Edit")
        {
            ddlCompanyBind();
            ddlConfigIDBind();
            ((DropDownList)FormView1.FindControl("ddlCompanyCode_EDIT")).Enabled = false;
        }
    }
    protected void BTN_Update_Cancel_Click(object sender, EventArgs e)
    {
        BackPage();
    }
    protected void BTN_INSERT_CANCEL_Click(object sender, EventArgs e)
    {
        BackPage();
    }
    protected void BTN_RESET_Click(object sender, EventArgs e)
    {

    }
    protected void BTN_INSERT_Click(object sender, EventArgs e)
    {
        Page.Validate();
       
            if (Page.IsValid)
            {
                #region
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
                #endregion
                P_CustomerConfigLink.RecordInputStart();
                P_CustomerConfigLink.Get_COMPANY_CODE = ((DropDownList)FormView1.FindControl("ddlCompanyCode")).SelectedValue.ToString();
                P_CustomerConfigLink.Get_CONF_DEF_ID = ((DropDownList)FormView1.FindControl("ddlConfigID")).SelectedValue.ToString();
                P_CustomerConfigLink.Get_FTP_LOADPATH = ((TextBox)FormView1.FindControl("TXT_Upload_Path_INSERT")).Text;
                P_CustomerConfigLink.Get_FTP_USERID = ((TextBox)FormView1.FindControl("TXT_Upload_UserID_INSERT")).Text;
                P_CustomerConfigLink.Get_FTP_PASSWORD = ((TextBox)FormView1.FindControl("TXT_Upload_Password_INSERT")).Text;
                P_CustomerConfigLink.Get_FTP_MOVEPATH = ((TextBox)FormView1.FindControl("TXT_Move_Path_INSERT")).Text;
                P_CustomerConfigLink.Get_FTP_MOVE_USERID = ((TextBox)FormView1.FindControl("TXT_Move_UserID_INSERT")).Text;
                P_CustomerConfigLink.Get_FTP_MOVE_PASSWORD = ((TextBox)FormView1.FindControl("TXT_Move_Password_INSERT")).Text;
                P_CustomerConfigLink.Get_FTP_TYPE = ((DropDownList)FormView1.FindControl("DDL_FTP_TYPE_INSERT")).SelectedValue;
                P_CustomerConfigLink.Get_FTP_PORT = ((TextBox)FormView1.FindControl("TXT_FTP_PORT_INSERT")).Text;
                P_CustomerConfigLink.RecordInputCommit();
                P_CustomerConfigLink.AddNewGroup();
                BackPage();
            
        }
    }
    protected void BTN_Update_Click(object sender, EventArgs e)
    {
        P_CustomerConfigLink.RecordInputStart();
        P_CustomerConfigLink.Get_ID = FormView1.DataKey.Value.ToString();
        P_CustomerConfigLink.Get_COMPANY_CODE = ((DropDownList)FormView1.FindControl("ddlCompanyCode_EDIT")).SelectedValue.ToString();
        P_CustomerConfigLink.Get_CONF_DEF_ID = ((DropDownList)FormView1.FindControl("ddlConfigID_EDIT")).SelectedValue.ToString();
        P_CustomerConfigLink.Get_FTP_LOADPATH = ((TextBox)FormView1.FindControl("TXT_Upload_Path_EDIT")).Text;
        P_CustomerConfigLink.Get_FTP_USERID = ((TextBox)FormView1.FindControl("TXT_Upload_UserID_EDIT")).Text;
        P_CustomerConfigLink.Get_FTP_PASSWORD = ((TextBox)FormView1.FindControl("TXT_Upload_Password_EDIT")).Text;
        P_CustomerConfigLink.Get_FTP_MOVEPATH = ((TextBox)FormView1.FindControl("TXT_Move_Path_EDIT")).Text;
        P_CustomerConfigLink.Get_FTP_MOVE_USERID = ((TextBox)FormView1.FindControl("TXT_Move_UserID_EDIT")).Text;
        P_CustomerConfigLink.Get_FTP_MOVE_PASSWORD = ((TextBox)FormView1.FindControl("TXT_Move_Password_EDIT")).Text;
        P_CustomerConfigLink.Get_FTP_TYPE = ((DropDownList)FormView1.FindControl("DDL_FTP_TYPE_EDIT")).SelectedValue;
        P_CustomerConfigLink.Get_FTP_PORT = ((TextBox)FormView1.FindControl("TXT_FTP_PORT_EDIT")).Text;
        P_CustomerConfigLink.RecordInputCommit();
        P_CustomerConfigLink.EditNewGroup();
        BackPage();
    }
    protected void BTN_EDIT_Click(object sender, EventArgs e)
    {
        FormView1.ChangeMode(FormViewMode.Edit); 
    }
    protected void BTN_Cancel_Click(object sender, EventArgs e)
    {
        BackPage();
    }
}

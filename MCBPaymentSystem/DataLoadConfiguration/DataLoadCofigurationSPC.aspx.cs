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

public partial class DataLoadCofigurationSPC : System.Web.UI.Page
{
    string RGS_SUPPORT = "";
    string checked_File_Value;

    PROCESS_SPDS_DataLoadCofiguration P_SPDS_DataLoadCofiguration = new PROCESS_SPDS_DataLoadCofiguration();
    LOV_COLLECTION lov = new LOV_COLLECTION();
    PROCESS_SPDS_DataLoadCofigurationDetail P_SPDS_DataLoadCofigurationDetail = new PROCESS_SPDS_DataLoadCofigurationDetail();

    protected void Page_PreInit(object sender, EventArgs e)
    { Page.Theme = Session["ThemeChange"].ToString(); }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session["QueryString"] = Request.QueryString[0].ToString();
            //FormView2.Visible = false;

        }
        if (Session["FormMode"].ToString() == "INSERT") //(Session["SPDS_DataLoadDefinationCofiguration_ID"].ToString() == "0")
        {
            FormView1.ChangeMode(FormViewMode.Insert);
            FormView2.Visible = false;
            Label1.Visible = false;
            //((RadioButton)FormView1.FindControl("RB_XLS_INSERT")).Checked = true;
            //RB_XLS_INSERT_CheckedChanged(null, null);
            //RB_CSV_INSERT_CheckedChanged(null, null);
            //RB_TXT_INSERT_CheckedChanged(null, null);

        }
        else if (Session["FormMode"].ToString() == "INTERNAL") //(Session["SPDS_DataLoadDefinationCofiguration_ID"].ToString() == "0")
        {
            FormView1.ChangeMode(FormViewMode.ReadOnly);
            FormView2.ChangeMode(FormViewMode.Insert);
            Label1.Visible = false;
        }
        else
        {
            if (IsPostBack == false)
            {
                RGS_SUPPORT = Session["RGS"].ToString();
                if (RGS_SUPPORT.Substring(2, 1) == "0")
                { ((EO.Web.ToolBar)FormView1.FindControl("DisplayToolBar")).Items[0].Disabled = false; /*Edit*/}
                else if (RGS_SUPPORT.Substring(2, 1) == "1")
                { //((EO.Web.ToolBar)FormView1.FindControl("DisplayToolBar")).Items[0].Disabled = false; /*Edit*/
                }
                if (RGS_SUPPORT.Substring(4, 1) == "0")
                {
                    //((EO.Web.ToolBar)FormView1.FindControl("DisplayToolBar")).Items[4].Disabled = true; /*Authorize / Unauthorize*/
                    //((EO.Web.ToolBar)FormView1.FindControl("DisplayToolBar")).Items[2].Disabled = false;
                }
                else if (RGS_SUPPORT.Substring(4, 1) == "1")
                {
                    ((EO.Web.ToolBar)FormView1.FindControl("DisplayToolBar")).Items[4].Disabled = true; /*Authorize / Unauthorize*/
                    ((EO.Web.ToolBar)FormView1.FindControl("DisplayToolBar")).Items[2].Disabled = false;
                }
                Label1.Visible = true;
            }

        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    { }
    protected void FormView1_PageIndexChanging(object sender, FormViewPageEventArgs e)
    { }
    protected void FormView2_PageIndexChanging(object sender, FormViewPageEventArgs e)
    { }
    protected void MainGrid_Toolbar_ItemClick(object sender, EO.Web.ToolBarEventArgs e)
    { }
    private void BackPage()
    {
        Session["SPDS_DataLoadCofigurationDetail_ID"] = "0";
        //Session["FormMode"] = "INSERT";
        Response.Redirect("../DataLoadConfiguration/DataLoadCofiguration.aspx" + "?" + "s1=" + Session["QueryString"].ToString());
    }
    private void BackPage2()
    {
        Session["SPDS_UniversalUploadCofigurationDetail_ID"] = "0";
        Response.Redirect("../DataLoadConfiguration/DataLoadCofigurationSPC.aspx");
    }
    protected void checkRBINSERT()
    {
        #region
        // RadioButton RB_Customer, RB_CorrBank, RB_Star, RB_Courier, RB_Beneficiray;
        // RB_Customer = ((RadioButton)FormView1.FindControl("RB_Customer_INSERT"));
        // RB_CorrBank = ((RadioButton)FormView1.FindControl("RB_CorrBank_INSERT"));
        // RB_Star = ((RadioButton)FormView1.FindControl("RB_Star_INSERT"));
        // RB_Courier = ((RadioButton)FormView1.FindControl("RB_Courier_INSERT"));
        // RB_Beneficiray = ((RadioButton)FormView1.FindControl("RB_Beneficiray_INSERT"));
        ///// string checkedValue;
        // if (RB_Customer.Checked == true)
        // {
        //     checked_Source_Value = "1";
        //     Source_Id = ((TextBox)FormView1.FindControl("TXT_SourceID_INSERT")).Text;
        // }
        // else if (RB_CorrBank.Checked == true)
        // {
        //     checked_Source_Value = "2";
        //     Source_Id = ((TextBox)FormView1.FindControl("TXT_SourceID_Corr_INSERT")).Text;
        // }
        // else if (RB_Star.Checked == true)
        // {
        //     checked_Source_Value = "3";
        //     Source_Id = ((TextBox)FormView1.FindControl("TXT_SourceID_Star_INSERT")).Text;
        // }
        // else if (RB_Courier.Checked == true)
        // {
        //     checked_Source_Value = "4";
        //     Source_Id = ((TextBox)FormView1.FindControl("TXT_SourceID_Cour_INSERT")).Text;
        // }
        // else if (RB_Beneficiray.Checked == true)
        // {
        //     checked_Source_Value = "5";
        //     Source_Id = ((TextBox)FormView1.FindControl("TXT_SourceID_Bene_INSERT")).Text;
        // }
        #endregion
        RadioButton RB_XLS, RB_CSV, RB_TXT, RB_MT100;
        RB_XLS = ((RadioButton)FormView1.FindControl("RB_XLS_INSERT"));
        RB_CSV = ((RadioButton)FormView1.FindControl("RB_CSV_INSERT"));
        RB_TXT = ((RadioButton)FormView1.FindControl("RB_TXT_INSERT"));
        RB_MT100 = ((RadioButton)FormView1.FindControl("RB_MT100_INSERT"));
        // string checkedValue;
        if (RB_XLS.Checked == true)
        {
            checked_File_Value = "1";
        }
        else if (RB_CSV.Checked == true)
        {
            checked_File_Value = "2";
        }
        else if (RB_TXT.Checked == true)
        {
            checked_File_Value = "3";
        }
        else if (RB_MT100.Checked == true)
        {
            checked_File_Value = "4";
        }
    }
    protected void checkRB_EDIT()
    {
        #region
        //RadioButton RB_Customer, RB_CorrBank, RB_Star, RB_Courier, RB_Beneficiray;
        //RB_Customer = ((RadioButton)FormView1.FindControl("RB_Customer_EDIT"));
        //RB_CorrBank = ((RadioButton)FormView1.FindControl("RB_CorrBank_EDIT"));
        //RB_Star = ((RadioButton)FormView1.FindControl("RB_Star_EDIT"));
        //RB_Courier = ((RadioButton)FormView1.FindControl("RB_Courier_EDIT"));
        //RB_Beneficiray = ((RadioButton)FormView1.FindControl("RB_Beneficiray_EDIT"));
        //string checkedValue;
        //if (RB_Customer.Checked == true)
        //{
        //    checked_Source_Value = "1";
        //}
        //else if (RB_CorrBank.Checked == true)
        //{
        //    checked_Source_Value = "2";
        //}
        //else if (RB_Star.Checked == true)
        //{
        //    checked_Source_Value = "3";
        //}
        //else if (RB_Courier.Checked == true)
        //{
        //    checked_Source_Value = "4";
        //}
        //else if (RB_Beneficiray.Checked == true)
        //{
        //    checked_Source_Value = "5";
        //}
        #endregion
        RadioButton RB_XLS, RB_CSV, RB_TXT, RB_MT100;
        RB_XLS = ((RadioButton)FormView1.FindControl("RB_XLS_EDIT"));
        RB_CSV = ((RadioButton)FormView1.FindControl("RB_CSV_EDIT"));
        RB_TXT = ((RadioButton)FormView1.FindControl("RB_TXT_EDIT"));
        RB_MT100 = ((RadioButton)FormView1.FindControl("RB_MT100_EDIT"));
        // string checkedValue;
        if (RB_XLS.Checked == true)
        {
            checked_File_Value = "1";
        }
        else if (RB_CSV.Checked == true)
        {
            checked_File_Value = "2";
        }
        else if (RB_TXT.Checked == true)
        {
            checked_File_Value = "3";
        }
        else if (RB_MT100.Checked == true)
        {
            checked_File_Value = "4";
        }

    }
    public string ddlfileSep()
    {
        //RadioButton RB_CSV;
        //RB_CSV = ((RadioButton)FormView1.FindControl("RB_CSV_INSERT"));
        string fileSeparate = "";
        //if (RB_CSV.Checked == true)
        //{
        fileSeparate = ((TextBox)FormView1.FindControl("TXT_FileSeparate_Insert")).Text;
        //}
        return fileSeparate;
    }
    public string ddlfileSepEdit()
    {
        //RadioButton RB_CSV;
        //RB_CSV = ((RadioButton)FormView1.FindControl("RB_CSV_EDIT"));
        string fileSeparate = "";
        //if (RB_CSV.Checked == true)
        //{
        fileSeparate = ((TextBox)FormView1.FindControl("TXT_FlieSeparate_Edit")).Text;
        //}
        return fileSeparate;
    }
    protected void DisplayToolBar_ItemClick(object sender, EO.Web.ToolBarEventArgs e)
    {
        //if (e.Item.ToolTip == "Edit")
        //{
        //    FormView1.ChangeMode(FormViewMode.Edit);
        //    Label1.Visible = true;
        //}
        //else if (e.Item.ToolTip == "Cancel")
        //{ BackPage(); }
    }
    protected void EditToolbar_ItemClick(object sender, EO.Web.ToolBarEventArgs e)
    {
        //Page.Validate();
        //if (e.Item.ToolTip == "Update")
        //{
        //    if (Page.IsValid)
        //    {
        //        LOV_COLLECTION L = new LOV_COLLECTION();
        //        checkRB_EDIT();
        //        P_SPDS_DataLoadCofiguration.RecordInputStart();
        //        P_SPDS_DataLoadCofiguration.Get_ConfigurationID = ((TextBox)FormView1.FindControl("TXT_Configuration_ID_EDIT")).Text;
        //        P_SPDS_DataLoadCofiguration.Get_ConfigurationDefinationID = ((TextBox)FormView1.FindControl("TXT_ConfigurationDef_ID_EDIT")).Text;
        //        P_SPDS_DataLoadCofiguration.Get_ConfigurationDefinationDesc = ((TextBox)FormView1.FindControl("TXT_ConfigurationDef_Desc_EDIT")).Text;
        //        P_SPDS_DataLoadCofiguration.Get_FileFormat = checked_File_Value;
        //        P_SPDS_DataLoadCofiguration.Get_FileSeparate = ddlfileSepEdit();
        //        P_SPDS_DataLoadCofiguration.Get_RecordsSkip = ((TextBox)FormView1.FindControl("TXT_RECORD_SKIP_EDIT")).Text;
        //        P_SPDS_DataLoadCofiguration.RecordInputCommit();
        //        P_SPDS_DataLoadCofiguration.EditNewGroup();
        //        BackPage();
        //    }
        //}
        //else if (e.Item.ToolTip == "Cancel")
        //{ BackPage(); }
    }
    protected void InsertToolbar_ItemClick(object sender, EO.Web.ToolBarEventArgs e)
    {
        //Page.Validate();
        //if (e.Item.ToolTip == "Insert")
        //{
        //    if (Page.IsValid)
        //    {
        //        LOV_COLLECTION L = new LOV_COLLECTION();
        //        DataSet DS;
        //        DS = L.SP_DataLoadCofiguration_DP(((DropDownList)FormView1.FindControl("ddlConfigurationID_Insert")).SelectedValue, ((TextBox)FormView1.FindControl("TXT_ConfigurationDef_ID_INSERT")).Text);
        //        if (DS.Tables[0].Rows.Count > 0)
        //        {
        //            ((Label)FormView1.FindControl("lblDuplicate_INSERT")).Text = "Duplicate Record";
        //        }
        //        else
        //        {
        //            checkRBINSERT();
        //            P_SPDS_DataLoadCofiguration.RecordInputStart();
        //            P_SPDS_DataLoadCofiguration.Get_ConfigurationID = ((DropDownList)FormView1.FindControl("ddlConfigurationID_Insert")).SelectedValue;
        //            P_SPDS_DataLoadCofiguration.Get_ConfigurationDefinationID = ((TextBox)FormView1.FindControl("TXT_ConfigurationDef_ID_INSERT")).Text;
        //            P_SPDS_DataLoadCofiguration.Get_ConfigurationDefinationDesc = ((TextBox)FormView1.FindControl("TXT_ConfigurationDef_Desc_INSERT")).Text;
        //            P_SPDS_DataLoadCofiguration.Get_FileFormat = checked_File_Value;
        //            P_SPDS_DataLoadCofiguration.Get_FileSeparate = ddlfileSep();
        //            P_SPDS_DataLoadCofiguration.Get_RecordsSkip = ((TextBox)FormView1.FindControl("TXT_RECORD_SKIP_INSERT")).Text;
        //            P_SPDS_DataLoadCofiguration.RecordInputCommit();
        //            P_SPDS_DataLoadCofiguration.AddNewGroup();
        //            Session["Configuration_ID"] = ((DropDownList)FormView1.FindControl("ddlConfigurationID_Insert")).SelectedValue;
        //            Session["SPDS_DataLoadCofiguration_ID"] = ((DropDownList)FormView1.FindControl("ddlConfigurationID_Insert")).SelectedValue; 
        //            Session["SPDS_DataLoadDefinationCofiguration_ID"] = ((TextBox)FormView1.FindControl("TXT_ConfigurationDef_ID_INSERT")).Text; 
        //            //ToolBar1.Visible = true;
        //            Session["FormMode"] = "INTERNAL";
        //            Response.Redirect("../DataLoadConfiguration/DataLoadCofigurationSPC.aspx" + "?" + "s1=" + Session["QueryString"].ToString());
        //            //FormView1.ChangeMode(FormViewMode.ReadOnly);
        //        }
        //    }
        //}
        //else if (e.Item.ToolTip == "Cancel")
        //{
        //    BackPage();
        //}
    }
    protected void ToolBar1_ItemClick(object sender, EO.Web.ToolBarEventArgs e)
    {
        //if (e.Item.ToolTip == "Add New")
        //{
        //    //Session["SPDS_UniversalUploadCofigurationDetail_ID"] = "0";
        //    FormView2.Visible = true;
        //    FormView2.ChangeMode(FormViewMode.Insert);

        //}
        //else if (e.Item.ToolTip == "Edit")
        //{

        //}
        //else if (e.Item.ToolTip == "Cancel")
        //{
        //    BackPage();
        //}

    }
    protected void FormView1_DataBound(object sender, EventArgs e)
    {
        if (FormView1.CurrentMode.ToString() == "Edit")
        {
            ((TextBox)FormView1.FindControl("TXT_ConfigurationDef_ID_EDIT")).Attributes.Add("style", "visibility: hidden;");
            ((TextBox)FormView1.FindControl("TXT_Configuration_ID_EDIT")).Attributes.Add("style", "visibility: hidden;");
            ((TextBox)FormView1.FindControl("TXT_Configuration_Desc_EDIT")).Attributes.Add("style", "visibility: hidden;");

        }
        else if (FormView1.CurrentMode.ToString() == "Insert")
        {
            ((TextBox)FormView1.FindControl("TXT_Configuration_ID_INSERT")).Attributes.Add("readonly", "readonly");
            ((TextBox)FormView1.FindControl("TXT_Configuration_Desc_INSERT")).Attributes.Add("readonly", "readonly");
            DataSet ds = new DataSet();
            ds = lov.Get_RPS_LOV_DataConfiguration_ALL("%", "%");
            ((DropDownList)FormView1.FindControl("ddlConfigurationID_Insert")).DataSource = ds;
            ((DropDownList)FormView1.FindControl("ddlConfigurationID_Insert")).DataTextField = "CONF_DESC";
            ((DropDownList)FormView1.FindControl("ddlConfigurationID_Insert")).DataValueField = "CONF_ID";
            ((DropDownList)FormView1.FindControl("ddlConfigurationID_Insert")).DataBind();
            //GridView1.Visible = false;
            //FormView2.Visible = false;
            // ToolBar1.Visible = false;
            if (((RadioButton)FormView1.FindControl("RB_XLS_INSERT")).Checked == true)
            {

            }
        }
        else if (FormView1.CurrentMode.ToString() == "ReadOnly")
        {
            //FormView2.Visible = false;
            //Session["Configuration_ID"] = ((Label)FormView1.FindControl("TXT_Configuration_ID_DISPLAY")).Text;
        }
    }
    protected void DisplayToolBar2_ItemClick(object sender, EO.Web.ToolBarEventArgs e)
    {
        //if (e.Item.ToolTip == "Edit")
        //{
        //    FormView2.ChangeMode(FormViewMode.Edit);

        //}
        //else if (e.Item.ToolTip == "Cancel")
        //{
        //    FormView2.Visible = false;
        //}
        //else if (e.Item.ToolTip == "Delete")
        //{
        //    P_SPDS_DataLoadCofigurationDetail.RecordInputStart();
        //    P_SPDS_DataLoadCofigurationDetail.Get_CONF_ID = ((Label)FormView2.FindControl("TXT_CONF_ID_DETAIL_DISPLAY")).Text;
        //    P_SPDS_DataLoadCofigurationDetail.Get_CONF_DEF_ID = ((Label)FormView1.FindControl("TXT_ConfigurationDef_ID_DISPLAY")).Text;
        //    P_SPDS_DataLoadCofigurationDetail.Get_COLUMN_ORDER = ((Label)FormView2.FindControl("TXT_COLUMN_ORDER_DETAIL_DISPLAY")).Text;
        //    P_SPDS_DataLoadCofigurationDetail.Get_COLUMN_SEQ = ((Label)FormView2.FindControl("TXT_COLUMN_SEQ_DETAIL_DISPLAY")).Text;
        //    P_SPDS_DataLoadCofigurationDetail.Get_FROM_POS = "0";
        //    P_SPDS_DataLoadCofigurationDetail.Get_TO_POS = "0";
        //    P_SPDS_DataLoadCofigurationDetail.RecordInputCommit();
        //    P_SPDS_DataLoadCofigurationDetail.DeleteNewGroup();
        //    //Session["FormMode"] = "INTERNAL";
        //    FormView2.Visible = false;
        //    Response.Redirect("../DataLoadConfiguration/DataLoadCofigurationSPC.aspx" + "?" + "s1=" + Session["QueryString"].ToString());
        //    //((Label)FormView2.FindControl("TXT_CONF_ID_DETAIL_DISPLAY")).Text;
        //}

    }
    protected void EditToolbar2_ItemClick(object sender, EO.Web.ToolBarEventArgs e)
    {
        //Page.Validate();
        //if (e.Item.ToolTip == "Update")
        //{
        //    if (Page.IsValid)
        //    {
        //        P_SPDS_DataLoadCofigurationDetail.RecordInputStart();
        //        P_SPDS_DataLoadCofigurationDetail.Get_CONF_DEF_ID = Session["SPDS_CONF_DEF_ID"].ToString();
        //        P_SPDS_DataLoadCofigurationDetail.Get_CONF_ID = Session["SPDS_CONF_ID"].ToString();
        //        P_SPDS_DataLoadCofigurationDetail.Get_COLUMN_ORDER = ((TextBox)FormView2.FindControl("TXT_COLUMN_ORDER_DETAIL_EDIT")).Text; //((DropDownList)FormView2.FindControl("ddlColumnOrder_Edit")).SelectedValue;
        //        P_SPDS_DataLoadCofigurationDetail.Get_COLUMN_SEQ = ((TextBox)FormView2.FindControl("TXT_COLUMN_SEQ_DETAIL_EDIT")).Text;
        //        //P_SPDS_DataLoadCofigurationDetail.Get_COLUMN_SEQ_OLD = Session["SPDS_COLUMN_SEQ"].ToString();
        //        P_SPDS_DataLoadCofigurationDetail.Get_FROM_POS = ((TextBox)FormView2.FindControl("TXT_FROM_POS_DETAIL_EDIT")).Text; 
        //        P_SPDS_DataLoadCofigurationDetail.Get_TO_POS = ((TextBox)FormView2.FindControl("TXT_TO_POS_DETAIL_EDIT")).Text; 
        //        P_SPDS_DataLoadCofigurationDetail.RecordInputCommit();
        //        P_SPDS_DataLoadCofigurationDetail.EditNewGroup();
        //        //Session["FormMode"] = "EDIT";
        //        //FormView2.Visible = false;
        //        Response.Redirect("../DataLoadConfiguration/DataLoadCofigurationSPC.aspx" + "?" + "s1=" + Session["QueryString"].ToString());

        //    }
        //}
        //else if (e.Item.ToolTip == "Cancel")
        //{
        //    FormView2.Visible = false;
        //}
    }
    protected void InsertToolbar2_ItemClick(object sender, EO.Web.ToolBarEventArgs e)
    {
        //Page.Validate();
        //if (e.Item.ToolTip == "Insert")
        //{
        //    if (Page.IsValid)
        //    {
        //        LOV_COLLECTION L = new LOV_COLLECTION();
        //        DataSet DS;
        //        //DS = L.SP_DataLoadCofigurationDetail_DP(Session["Configuration_ID"].ToString(), Session["SPDS_DataLoadDefinationCofiguration_ID"].ToString(), ((DropDownList)FormView2.FindControl("ddlColumnOrder_Insert")).SelectedValue);
        //        //if (DS.Tables[0].Rows.Count > 0)
        //        //{
        //        //    ((Label)FormView2.FindControl("lblDuplicate_INSERT")).Text = "Duplicate Record";
        //        //}
        //        //else
        //        //{
        //            P_SPDS_DataLoadCofigurationDetail.RecordInputStart();
        //            P_SPDS_DataLoadCofigurationDetail.Get_CONF_DEF_ID = Session["SPDS_DataLoadDefinationCofiguration_ID"].ToString();
        //            P_SPDS_DataLoadCofigurationDetail.Get_CONF_ID = Session["Configuration_ID"].ToString();
        //            P_SPDS_DataLoadCofigurationDetail.Get_COLUMN_ORDER = ((DropDownList)FormView2.FindControl("ddlColumnOrder_Insert")).SelectedValue;
        //            P_SPDS_DataLoadCofigurationDetail.Get_COLUMN_SEQ = ((TextBox)FormView2.FindControl("TXT_COLUMN_SEQ_DETAIL_INSERT")).Text;
        //            P_SPDS_DataLoadCofigurationDetail.Get_FROM_POS = ((TextBox)FormView2.FindControl("TXT_FROM_POS_DETAIL_INSERT")).Text;
        //            P_SPDS_DataLoadCofigurationDetail.Get_TO_POS = ((TextBox)FormView2.FindControl("TXT_TO_POS_DETAIL_INSERT")).Text;
        //            P_SPDS_DataLoadCofigurationDetail.RecordInputCommit();
        //            P_SPDS_DataLoadCofigurationDetail.AddNewGroup();
        //            Session["FormMode"] = "INTERNAL";
        //            Response.Redirect("../DataLoadConfiguration/DataLoadCofigurationSPC.aspx" + "?" + "s1=" + Session["QueryString"].ToString());
        //        //}
        //        //FormView2.Visible = false;
        //    }
        //}
        //else if (e.Item.ToolTip == "Cancel")
        //{
        //    FormView2.Visible = false;
        //}
    }
    protected void FormView2_DataBound(object sender, EventArgs e)
    {
        if (FormView2.CurrentMode.ToString() == "Edit")
        {
            ((TextBox)FormView2.FindControl("TXT_CONF_ID_DETAIL_EDIT")).Attributes.Add("style", "visibility:hidden");
            ((TextBox)FormView2.FindControl("TXT_COLUMN_ORDER_DETAIL_EDIT")).Attributes.Add("disabled", "disabled");
            ((TextBox)FormView2.FindControl("TXT_COLUMN_NAME_DETAIL_EDIT")).Attributes.Add("disabled", "disabled");
            ((ImageButton)FormView2.FindControl("BTN_Configuration_Detail_ID_EDIT")).Attributes.Add("style", "visibility:hidden");
            ((TextBox)FormView2.FindControl("TXT_COLUMN_ORDER_DETAIL_EDIT")).Attributes.Add("readonly", "readonly");
            ((TextBox)FormView2.FindControl("TXT_COLUMN_NAME_DETAIL_EDIT")).Attributes.Add("readonly", "readonly");
            //TextBox txtfrom ,txtTo;
            //txtfrom = ((TextBox)FormView2.FindControl("TXT_FROM_POS_DETAIL_INSERT"));
            //txtTo = ((TextBox)FormView2.FindControl("TXT_TO_POS_DETAIL_INSERT"));
            //((EO.Web.ToolBar)FormView2.FindControl("InsertToolbar2")).Attributes.Add("onclick", "onConfirm1(" + ((RadioButton)FormView1.FindControl("RB_TXT_EDIT")).ClientID + "," + txtfrom.ClientID + "," + txtTo.ClientID + ");");

        }
        else if (FormView2.CurrentMode.ToString() == "Insert")
        {
            ((TextBox)FormView2.FindControl("TXT_CONF_ID_DETAIL_INSERT")).Attributes.Add("style", "visibility:hidden");
            ((TextBox)FormView2.FindControl("TXT_COLUMN_ORDER_DETAIL_INSERT")).Attributes.Add("readonly", "readonly");
            ((TextBox)FormView2.FindControl("TXT_COLUMN_NAME_DETAIL_INSERT")).Attributes.Add("readonly", "readonly");
            DataSet ds = new DataSet();
            ds = lov.Get_RPS_LOV_DataConfigurationDetail_ALL(Session["Configuration_ID"].ToString(), "%", "%");
            ((DropDownList)FormView2.FindControl("ddlColumnOrder_Insert")).DataSource = ds;
            ((DropDownList)FormView2.FindControl("ddlColumnOrder_Insert")).DataTextField = "COLUMN_NAME";
            ((DropDownList)FormView2.FindControl("ddlColumnOrder_Insert")).DataValueField = "COLUMN_ORDER";
            ((DropDownList)FormView2.FindControl("ddlColumnOrder_Insert")).DataBind();

            #region MyRegion


            //if (((RadioButton)FormView1.FindControl("RB_XLS_INSERT")).Checked == true)
            //{
            //    ((RequiredFieldValidator)FormView2.FindControl("RFVFrom_Insert")).Enabled = false;
            //    ((RequiredFieldValidator)FormView2.FindControl("RFVTo_Insert")).Enabled = false;
            //    ((TextBox)FormView2.FindControl("TXT_TO_POS_DETAIL_INSERT")).Visible = false;
            //    ((TextBox)FormView2.FindControl("TXT_FROM_POS_DETAIL_INSERT")).Visible = false;
            //}
            //if (((RadioButton)FormView1.FindControl("RB_CSV_INSERT")).Checked == true)
            //{
            //    ((RequiredFieldValidator)FormView2.FindControl("RFVFrom_Insert")).Enabled = false;
            //    ((RequiredFieldValidator)FormView2.FindControl("RFVTo_Insert")).Enabled = false;
            //    ((TextBox)FormView2.FindControl("TXT_TO_POS_DETAIL_INSERT")).Visible = false;
            //    ((TextBox)FormView2.FindControl("TXT_FROM_POS_DETAIL_INSERT")).Visible = false;
            //}
            //if (((RadioButton)FormView1.FindControl("RB_TXT_INSERT")).Checked == true)
            //{
            //    ((RequiredFieldValidator)FormView2.FindControl("RFVFrom_Insert")).Enabled = true;
            //    ((RequiredFieldValidator)FormView2.FindControl("RFVTo_Insert")).Enabled = true;
            //    ((TextBox)FormView2.FindControl("TXT_TO_POS_DETAIL_INSERT")).Visible = true;
            //    ((TextBox)FormView2.FindControl("TXT_FROM_POS_DETAIL_INSERT")).Visible = true;
            //}
            #endregion

        }
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        string S;
        S = GridView1.DataKeys[this.GridView1.SelectedIndex].Value.ToString();
        if (S.ToString() != "")
        {
            Session["SPDS_CONF_ID"] = GridView1.DataKeys[this.GridView1.SelectedIndex].Value.ToString();
            Session["SPDS_CONF_DEF_ID"] = GridView1.SelectedRow.Cells[0].Text;
            Session["SPDS_COLUMN_ORDER"] = GridView1.SelectedRow.Cells[2].Text;
            Session["SPDS_COLUMN_SEQ"] = GridView1.SelectedRow.Cells[4].Text;

            FormView2.Visible = true;
            FormView2.ChangeMode(FormViewMode.ReadOnly);
        }
    }
    protected void BTN_Configuration_ID_INSERT_Click(object sender, ImageClickEventArgs e)
    {
        if (Session["LOV_ID"].ToString() != "")
        {
            Session["ConfigurationID"] = Session["LOV_ID"];
            Session["ConfigurationDescription"] = Session["LOV_Description"];
            ((TextBox)FormView1.FindControl("TXT_Configuration_ID_INSERT")).Text = Session["ConfigurationID"].ToString();
            ((TextBox)FormView1.FindControl("TXT_Configuration_Desc_INSERT")).Text = Session["ConfigurationDescription"].ToString();
        }
    }
    protected void BTN_Configuration_Detail_ID_INSERT_Click(object sender, ImageClickEventArgs e)
    {
        if (Session["LOV_Column_Order"].ToString() != "")
        {
            ((TextBox)FormView2.FindControl("TXT_COLUMN_ORDER_DETAIL_INSERT")).Text = Session["LOV_Column_Order"].ToString();
            ((TextBox)FormView2.FindControl("TXT_COLUMN_NAME_DETAIL_INSERT")).Text = Session["LOV_Column_Name"].ToString();
        }
    }
    protected void BTN_Configuration_Detail_ID_EDIT_Click(object sender, ImageClickEventArgs e)
    {
        if (Session["LOV_Column_Order"].ToString() != "")
        {
            ((TextBox)FormView2.FindControl("TXT_COLUMN_ORDER_DETAIL_EDIT")).Text = Session["LOV_Column_Order"].ToString();
            ((TextBox)FormView2.FindControl("TXT_COLUMN_NAME_DETAIL_EDIT")).Text = Session["LOV_Column_Name"].ToString();
        }
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.GridView1, "Select$" + e.Row.RowIndex);
        //    e.Row.Attributes.Add("onmouseover", "this.style.cursor='hand';");
        //}

    }
    protected void BTN_EDIT_Click(object sender, EventArgs e)
    {
        FormView1.ChangeMode(FormViewMode.Edit);
        Label1.Visible = true;
    }
    protected void BTN_CANCEL_Click(object sender, EventArgs e)
    {
        BackPage();
    }
    protected void UpdateButton_Click(object sender, EventArgs e)
    {
        Page.Validate();

        if (Page.IsValid)
        {
            LOV_COLLECTION L = new LOV_COLLECTION();
            checkRB_EDIT();
            P_SPDS_DataLoadCofiguration.RecordInputStart();
            P_SPDS_DataLoadCofiguration.Get_ConfigurationID = ((TextBox)FormView1.FindControl("TXT_Configuration_ID_EDIT")).Text;
            P_SPDS_DataLoadCofiguration.Get_ConfigurationDefinationID = ((TextBox)FormView1.FindControl("TXT_ConfigurationDef_ID_EDIT")).Text;
            P_SPDS_DataLoadCofiguration.Get_ConfigurationDefinationDesc = ((TextBox)FormView1.FindControl("TXT_ConfigurationDef_Desc_EDIT")).Text;
            P_SPDS_DataLoadCofiguration.Get_FileFormat = checked_File_Value;
            P_SPDS_DataLoadCofiguration.Get_FileSeparate = ddlfileSepEdit();
            P_SPDS_DataLoadCofiguration.Get_RecordsSkip = ((TextBox)FormView1.FindControl("TXT_RECORD_SKIP_EDIT")).Text;
            P_SPDS_DataLoadCofiguration.RecordInputCommit();
            P_SPDS_DataLoadCofiguration.EditNewGroup();
            BackPage();
        }

    }
    protected void BTN_INSERT_Click(object sender, EventArgs e)
    {
        Page.Validate();

        if (Page.IsValid)
        {
            LOV_COLLECTION L = new LOV_COLLECTION();
            DataSet DS;
            DS = L.SP_DataLoadCofiguration_DP(((DropDownList)FormView1.FindControl("ddlConfigurationID_Insert")).SelectedValue, ((TextBox)FormView1.FindControl("TXT_ConfigurationDef_ID_INSERT")).Text);
            if (DS.Tables[0].Rows.Count > 0)
            {
                ((Label)FormView1.FindControl("lblDuplicate_INSERT")).Text = "Duplicate Record";
            }
            else
            {
                checkRBINSERT();
                P_SPDS_DataLoadCofiguration.RecordInputStart();
                P_SPDS_DataLoadCofiguration.Get_ConfigurationID = ((DropDownList)FormView1.FindControl("ddlConfigurationID_Insert")).SelectedValue;
                P_SPDS_DataLoadCofiguration.Get_ConfigurationDefinationID = ((TextBox)FormView1.FindControl("TXT_ConfigurationDef_ID_INSERT")).Text;
                P_SPDS_DataLoadCofiguration.Get_ConfigurationDefinationDesc = ((TextBox)FormView1.FindControl("TXT_ConfigurationDef_Desc_INSERT")).Text;
                P_SPDS_DataLoadCofiguration.Get_FileFormat = checked_File_Value;
                P_SPDS_DataLoadCofiguration.Get_FileSeparate = ddlfileSep();
                P_SPDS_DataLoadCofiguration.Get_RecordsSkip = ((TextBox)FormView1.FindControl("TXT_RECORD_SKIP_INSERT")).Text;
                P_SPDS_DataLoadCofiguration.RecordInputCommit();
                P_SPDS_DataLoadCofiguration.AddNewGroup();
                Session["Configuration_ID"] = ((DropDownList)FormView1.FindControl("ddlConfigurationID_Insert")).SelectedValue;
                Session["SPDS_DataLoadCofiguration_ID"] = ((DropDownList)FormView1.FindControl("ddlConfigurationID_Insert")).SelectedValue;
                Session["SPDS_DataLoadDefinationCofiguration_ID"] = ((TextBox)FormView1.FindControl("TXT_ConfigurationDef_ID_INSERT")).Text;
                //ToolBar1.Visible = true;
                Session["FormMode"] = "INTERNAL";
                Response.Redirect("../DataLoadConfiguration/DataLoadCofigurationSPC.aspx" + "?" + "s1=" + Session["QueryString"].ToString());
                //FormView1.ChangeMode(FormViewMode.ReadOnly);
            }
        }

    }
    protected void BTN_RESET_Click(object sender, EventArgs e)
    {

    }
    protected void BTN_NEW_Click(object sender, EventArgs e)
    {
        FormView2.Visible = true;
        FormView2.ChangeMode(FormViewMode.Insert);
    }
    protected void TXT_EDIT_Detail_Click(object sender, EventArgs e)
    {
        FormView2.ChangeMode(FormViewMode.Edit);
    }
    protected void TXT_Cancel_Detail_Click(object sender, EventArgs e)
    {
        FormView2.Visible = false;
    }
    protected void TXT_DELETE_Detail_Click1(object sender, EventArgs e)
    {
        P_SPDS_DataLoadCofigurationDetail.RecordInputStart();
        P_SPDS_DataLoadCofigurationDetail.Get_CONF_ID = ((Label)FormView2.FindControl("TXT_CONF_ID_DETAIL_DISPLAY")).Text;
        P_SPDS_DataLoadCofigurationDetail.Get_CONF_DEF_ID = ((Label)FormView1.FindControl("TXT_ConfigurationDef_ID_DISPLAY")).Text;
        P_SPDS_DataLoadCofigurationDetail.Get_COLUMN_ORDER = ((Label)FormView2.FindControl("TXT_COLUMN_ORDER_DETAIL_DISPLAY")).Text;
        P_SPDS_DataLoadCofigurationDetail.Get_COLUMN_SEQ = ((Label)FormView2.FindControl("TXT_COLUMN_SEQ_DETAIL_DISPLAY")).Text;
        P_SPDS_DataLoadCofigurationDetail.Get_FROM_POS = "0";
        P_SPDS_DataLoadCofigurationDetail.Get_TO_POS = "0";
        P_SPDS_DataLoadCofigurationDetail.RecordInputCommit();
        P_SPDS_DataLoadCofigurationDetail.DeleteNewGroup();
        //Session["FormMode"] = "INTERNAL";
        FormView2.Visible = false;
        Response.Redirect("../DataLoadConfiguration/DataLoadCofigurationSPC.aspx" + "?" + "s1=" + Session["QueryString"].ToString());
        //((Label)FormView2.FindControl("TXT_CONF_ID_DETAIL_DISPLAY")).Text;
    }
    protected void UpdateButton_DETAIL_Click(object sender, EventArgs e)
    {
        Page.Validate();

        if (Page.IsValid)
        {
            P_SPDS_DataLoadCofigurationDetail.RecordInputStart();
            P_SPDS_DataLoadCofigurationDetail.Get_CONF_DEF_ID = Session["SPDS_CONF_DEF_ID"].ToString();
            P_SPDS_DataLoadCofigurationDetail.Get_CONF_ID = Session["SPDS_CONF_ID"].ToString();
            P_SPDS_DataLoadCofigurationDetail.Get_COLUMN_ORDER = ((TextBox)FormView2.FindControl("TXT_COLUMN_ORDER_DETAIL_EDIT")).Text; //((DropDownList)FormView2.FindControl("ddlColumnOrder_Edit")).SelectedValue;
            P_SPDS_DataLoadCofigurationDetail.Get_COLUMN_SEQ = ((TextBox)FormView2.FindControl("TXT_COLUMN_SEQ_DETAIL_EDIT")).Text;
            //P_SPDS_DataLoadCofigurationDetail.Get_COLUMN_SEQ_OLD = Session["SPDS_COLUMN_SEQ"].ToString();
            P_SPDS_DataLoadCofigurationDetail.Get_FROM_POS = ((TextBox)FormView2.FindControl("TXT_FROM_POS_DETAIL_EDIT")).Text;
            P_SPDS_DataLoadCofigurationDetail.Get_TO_POS = ((TextBox)FormView2.FindControl("TXT_TO_POS_DETAIL_EDIT")).Text;
            P_SPDS_DataLoadCofigurationDetail.RecordInputCommit();
            P_SPDS_DataLoadCofigurationDetail.EditNewGroup();
            //Session["FormMode"] = "EDIT";
            //FormView2.Visible = false;
            Response.Redirect("../DataLoadConfiguration/DataLoadCofigurationSPC.aspx" + "?" + "s1=" + Session["QueryString"].ToString());

        }
    }
    protected void BTN_INSERT_Detail_Click(object sender, EventArgs e)
    {
        Page.Validate();

        if (Page.IsValid)
        {
            LOV_COLLECTION L = new LOV_COLLECTION();
            DataSet DS;
            //DS = L.SP_DataLoadCofigurationDetail_DP(Session["Configuration_ID"].ToString(), Session["SPDS_DataLoadDefinationCofiguration_ID"].ToString(), ((DropDownList)FormView2.FindControl("ddlColumnOrder_Insert")).SelectedValue);
            //if (DS.Tables[0].Rows.Count > 0)
            //{
            //    ((Label)FormView2.FindControl("lblDuplicate_INSERT")).Text = "Duplicate Record";
            //}
            //else
            //{
            P_SPDS_DataLoadCofigurationDetail.RecordInputStart();
            P_SPDS_DataLoadCofigurationDetail.Get_CONF_DEF_ID = Session["SPDS_DataLoadDefinationCofiguration_ID"].ToString();
            P_SPDS_DataLoadCofigurationDetail.Get_CONF_ID = Session["Configuration_ID"].ToString();
            P_SPDS_DataLoadCofigurationDetail.Get_COLUMN_ORDER = ((DropDownList)FormView2.FindControl("ddlColumnOrder_Insert")).SelectedValue;
            P_SPDS_DataLoadCofigurationDetail.Get_COLUMN_SEQ = ((TextBox)FormView2.FindControl("TXT_COLUMN_SEQ_DETAIL_INSERT")).Text;
            P_SPDS_DataLoadCofigurationDetail.Get_FROM_POS = ((TextBox)FormView2.FindControl("TXT_FROM_POS_DETAIL_INSERT")).Text;
            P_SPDS_DataLoadCofigurationDetail.Get_TO_POS = ((TextBox)FormView2.FindControl("TXT_TO_POS_DETAIL_INSERT")).Text;
            P_SPDS_DataLoadCofigurationDetail.RecordInputCommit();
            P_SPDS_DataLoadCofigurationDetail.AddNewGroup();
            Session["FormMode"] = "INTERNAL";
            Response.Redirect("../DataLoadConfiguration/DataLoadCofigurationSPC.aspx" + "?" + "s1=" + Session["QueryString"].ToString());
            //}
            //FormView2.Visible = false;
        }
    }
    protected void BTN_CANCEL_Detail_Click(object sender, EventArgs e)
    {
        FormView2.Visible = false;
    }
}

#region
//protected void BTN_SOURCEID_CODE_EDIT_Click(object sender, ImageClickEventArgs e)
//{
//    if (Session["LOV_ID"] != "")
//    {
//         SourceID = Session["LOV_ID"].ToString();
//        ((TextBox)FormView1.FindControl("TXT_SourceID_EDIT")).Text = Session["LOV_CODE"].ToString();
//        ((TextBox)FormView1.FindControl("TXT_SourceName_EDIT")).Text = Session["LOV_DESCRIPTION"].ToString();
//    }
//}
//protected void BTN_SOURCEID_CODE_INSERT_Click(object sender, ImageClickEventArgs e)
//{
//    if (Session["LOV_ID"] != "")
//    {
//        SourceID = Session["LOV_ID"].ToString();
//        ((TextBox)FormView1.FindControl("TXT_SourceID_INSERT")).Text = Session["LOV_CODE"].ToString();
//        ((TextBox)FormView1.FindControl("TXT_SourceName_INSERT")).Text = Session["LOV_DESCRIPTION"].ToString();
//    }
//}
//protected void BTN_SourceIDSearch_INSERT_Click(object sender, EventArgs e)
//{
//    //if (((TextBox)FormView1.FindControl("TXT_SourceID_INSERT")).Text.Trim().Length > 0 || ((TextBox)FormView1.FindControl("TXT_SourceID_INSERT")).Text != "")
//    //{
//    //    DataSet ds = new DataSet();
//    //    ds = lov.Get_RPS_SP_Customer_GetByCode(((TextBox)FormView1.FindControl("TXT_SourceID_INSERT")).Text);
//    //    if (ds.Tables[0].Rows.Count > 0)
//    //    {
//    //        SourceID = ds.Tables[0].Rows[0]["ID"].ToString();
//    //        ((TextBox)FormView1.FindControl("TXT_SourceID_INSERT")).Text = ds.Tables[0].Rows[0]["BankCode"].ToString();
//    //        ((TextBox)FormView1.FindControl("TXT_SourceName_INSERT")).Text = ds.Tables[0].Rows[0]["BankName"].ToString();
//    //    }
//    //    else
//    //    {
//    //        ((TextBox)FormView1.FindControl("TXT_SourceID_INSERT")).Text = null;
//    //        ((TextBox)FormView1.FindControl("TXT_SourceName_INSERT")).Text = null;
//    //        ((TextBox)FormView1.FindControl("TXT_SourceID_INSERT")).Focus();

//    //        ((RequiredFieldValidator)FormView1.FindControl("REQ_SourceID_INSERT")).Validate();
//    //        ((TextBox)FormView1.FindControl("TXT_SourceID_INSERT")).Focus();

//    //    }
//    //}
//    //else
//    //{
//    //    ((TextBox)FormView1.FindControl("TXT_SourceID_INSERT")).Text = null;
//    //    ((TextBox)FormView1.FindControl("TXT_SourceName_INSERT")).Text = null;
//    //    ((TextBox)FormView1.FindControl("TXT_SourceID_INSERT")).Focus();
//    //}
//    if (((TextBox)FormView1.FindControl(Session["TXT_ID"].ToString().ToString())).Text.Trim().Length > 0 || ((TextBox)FormView1.FindControl(Session["TXT_ID"].ToString())).Text != "")
//    {
//        DataSet ds = new DataSet();
//        ds = lov.Get_RPS_SP_Customer_GetByCode(((TextBox)FormView1.FindControl(Session["TXT_ID"].ToString())).Text);
//        if (ds.Tables[0].Rows.Count > 0)
//        {
//            SourceID = ds.Tables[0].Rows[0]["ID"].ToString();
//            ((TextBox)FormView1.FindControl(Session["TXT_ID"].ToString().ToString())).Text = ds.Tables[0].Rows[0]["BankCode"].ToString();
//            ((TextBox)FormView1.FindControl(Session["TXT_Name"].ToString())).Text = ds.Tables[0].Rows[0]["BankName"].ToString();
//        }
//        else
//        {
//            ((TextBox)FormView1.FindControl(Session["TXT_ID"].ToString())).Text = null;
//            ((TextBox)FormView1.FindControl(Session["TXT_Name"].ToString())).Text = null;
//            ((TextBox)FormView1.FindControl(Session["TXT_ID"].ToString())).Focus();

//            ((RequiredFieldValidator)FormView1.FindControl(Session["REQ_SourceID"].ToString())).Validate();
//            ((TextBox)FormView1.FindControl(Session["TXT_ID"].ToString())).Focus();

//        }
//    }
//    else
//    {
//        ((TextBox)FormView1.FindControl(Session["TXT_ID"].ToString())).Text = null;
//        ((TextBox)FormView1.FindControl(Session["TXT_Name"].ToString())).Text = null;
//        ((TextBox)FormView1.FindControl(Session["TXT_ID"].ToString())).Focus();
//    }
//}

//protected void BTN_SourceIDSearch_EDIT_Click(object sender, EventArgs e)
//{
//    if (((TextBox)FormView1.FindControl(Session["TXT_ID_EDIT"].ToString())).Text.Trim().Length > 0 || ((TextBox)FormView1.FindControl(Session["TXT_ID_EDIT"].ToString())).Text != "")
//    {
//        DataSet ds = new DataSet();
//        ds = lov.Get_RPS_SP_Customer_GetByCode(((TextBox)FormView1.FindControl(Session["TXT_ID_EDIT"].ToString())).Text);
//        if (ds.Tables[0].Rows.Count > 0)
//        {
//            SourceID = ds.Tables[0].Rows[0]["ID"].ToString();
//            ((TextBox)FormView1.FindControl(Session["TXT_ID_EDIT"].ToString())).Text = ds.Tables[0].Rows[0]["BankCode"].ToString();
//            ((TextBox)FormView1.FindControl(Session["TXT_Name_EDIT"].ToString())).Text = ds.Tables[0].Rows[0]["BankName"].ToString();
//        }
//        else
//        {
//            ((TextBox)FormView1.FindControl(Session["TXT_ID_EDIT"].ToString())).Text = null;
//            ((TextBox)FormView1.FindControl(Session["TXT_Name_EDIT"].ToString())).Text = null;
//            ((TextBox)FormView1.FindControl(Session["TXT_ID_EDIT"].ToString())).Focus();

//            ((RequiredFieldValidator)FormView1.FindControl("REQ_SourceID_EDIT")).Validate();
//            ((TextBox)FormView1.FindControl(Session["TXT_ID_EDIT"].ToString())).Focus();

//        }
//    }
//    else
//    {
//        ((TextBox)FormView1.FindControl(Session["TXT_ID_EDIT"].ToString())).Text = null;
//        ((TextBox)FormView1.FindControl(Session["TXT_Name_EDIT"].ToString())).Text = null;
//        ((TextBox)FormView1.FindControl(Session["TXT_ID_EDIT"].ToString())).Focus();
//    }
//}
//protected void BTN_SOURCEID_CORR_INSERT_Click(object sender, ImageClickEventArgs e)
//{
//    if (Session["LOV_ID"] != "")
//    {
//        SourceID = Session["LOV_ID"].ToString();
//        ((TextBox)FormView1.FindControl("TXT_SourceID_Corr_INSERT")).Text = Session["LOV_CODE"].ToString();
//        ((TextBox)FormView1.FindControl("TXT_SourceName_Corr_INSERT")).Text = Session["LOV_DESCRIPTION"].ToString();
//    }
//}
//protected void BTN_SOURCEID_STAR_INSERT_Click(object sender, ImageClickEventArgs e)
//{
//    if (Session["LOV_ID"] != "")
//    {
//        SourceID = Session["LOV_ID"].ToString();
//        ((TextBox)FormView1.FindControl("TXT_SourceID_Star_INSERT")).Text = Session["LOV_CODE"].ToString();
//        ((TextBox)FormView1.FindControl("TXT_SourceName_Star_INSERT")).Text = Session["LOV_DESCRIPTION"].ToString();
//    }

//}
//protected void BTN_SOURCEID_COUR_INSERT_Click(object sender, ImageClickEventArgs e)
//{
//    if (Session["LOV_ID"] != "")
//    {
//        SourceID = Session["LOV_ID"].ToString();
//        ((TextBox)FormView1.FindControl("TXT_SourceID_Cour_INSERT")).Text = Session["LOV_CODE"].ToString();
//        ((TextBox)FormView1.FindControl("TXT_SourceName_Cour_INSERT")).Text = Session["LOV_DESCRIPTION"].ToString();
//    }

//}
//protected void BTN_SOURCEID_Bene_INSERT_Click(object sender, ImageClickEventArgs e)
//{
//    if (Session["LOV_ID"] != "")
//    {
//        SourceID = Session["LOV_ID"].ToString();
//        ((TextBox)FormView1.FindControl("TXT_SourceID_Bene_INSERT")).Text = Session["LOV_CODE"].ToString();
//        ((TextBox)FormView1.FindControl("TXT_SourceName_Bene_INSERT")).Text = Session["LOV_DESCRIPTION"].ToString();
//    }

//}
//protected void BTN_SOURCEID_CORR_EDIT_Click(object sender, ImageClickEventArgs e)
//{
//    if (Session["LOV_ID"] != "")
//    {
//        SourceID = Session["LOV_ID"].ToString();
//        ((TextBox)FormView1.FindControl("TXT_SourceID_Corr_EDIT")).Text = Session["LOV_CODE"].ToString();
//        ((TextBox)FormView1.FindControl("TXT_SourceName_Corr_EDIT")).Text = Session["LOV_DESCRIPTION"].ToString();
//    }
//}
//protected void BTN_SOURCEID_STAR_EDIT_Click(object sender, ImageClickEventArgs e)
//{
//    if (Session["LOV_ID"] != "")
//    {
//        SourceID = Session["LOV_ID"].ToString();
//        ((TextBox)FormView1.FindControl("TXT_SourceID_Star_EDIT")).Text = Session["LOV_CODE"].ToString();
//        ((TextBox)FormView1.FindControl("TXT_SourceName_Star_EDIT")).Text = Session["LOV_DESCRIPTION"].ToString();
//    }

//}
//protected void BTN_SOURCEID_COUR_EDIT_Click(object sender, ImageClickEventArgs e)
//{
//    if (Session["LOV_ID"] != "")
//    {
//        SourceID = Session["LOV_ID"].ToString();
//        ((TextBox)FormView1.FindControl("TXT_SourceID_Cour_EDIT")).Text = Session["LOV_CODE"].ToString();
//        ((TextBox)FormView1.FindControl("TXT_SourceName_Cour_EDIT")).Text = Session["LOV_DESCRIPTION"].ToString();
//    }

//}
//protected void BTN_SOURCEID_BENE_EDIT_Click(object sender, ImageClickEventArgs e)
//{
//    if (Session["LOV_ID"] != "")
//    {
//        SourceID = Session["LOV_ID"].ToString();
//        ((TextBox)FormView1.FindControl("TXT_SourceID_Bene_EDIT")).Text = Session["LOV_CODE"].ToString();
//        ((TextBox)FormView1.FindControl("TXT_SourceName_Bene_EDIT")).Text = Session["LOV_DESCRIPTION"].ToString();
//    }

//}


//protected void RB_Beneficiray_INSERT_CheckedChanged(object sender, EventArgs e)
//{

//}
//protected void RB_Courier_INSERT_CheckedChanged(object sender, EventArgs e)
//{

//}
//protected void RB_Star_INSERT_CheckedChanged(object sender, EventArgs e)
//{

//}
//protected void RB_CorrBank_INSERT_CheckedChanged(object sender, EventArgs e)
//{

//}
//protected void RB_Customer_INSERT_CheckedChanged(object sender, EventArgs e)
//{

//}
//protected void btnInsertAll_Click(object sender, EventArgs e)
//{
//    //DataTable dtSource = (DataTable)ViewState["source"];
//    //DataTable dtSelected = (DataTable)ViewState["selected"];
//    //foreach (DataRow row in dtSource.Rows)
//    //{
//    //    DataRow dr = dtSelected.NewRow();
//    //    dr[0] = row[0];
//    //    dtSelected.Rows.Add(dr);
//    //}
//    //ListBox lstSel = ((ListBox)FormView1.FindControl("lstSelected_EDIT"));
//    //lstSel.DataSource = dtSelected;
//    //lstSel.DataValueField = "ColumnName";
//    //lstSel.DataTextField = "ColumnName";
//    //lstSel.DataBind();
//    //foreach (DataRow row in dtSelected.Rows)
//    //{
//    //    DataRow[] dr = dtSource.Select("ColumnName='" + row[0] + "'");
//    //    //dr[0] = row[0];
//    //    if (dr.Length>0) dtSource.Rows.Remove(dr[0]);
//    //}
//    //ListBox lstSrc = ((ListBox)FormView1.FindControl("lstSource_EDIT"));
//    //lstSrc.DataSource = dtSource;
//    //lstSrc.DataValueField = "ColumnName";
//    //lstSrc.DataTextField = "ColumnName";
//    //lstSrc.DataBind();
//    //  ViewState["source"]=dtSource;
//    //  ViewState["selected"]=dtSelected ;
//}
//protected void btnRemoveAll_Click(object sender, EventArgs e)
//{
//    DataTable dtSource = (DataTable)ViewState["source"];
//    DataTable dtSelected = (DataTable)ViewState["selected"];
//    foreach (DataRow row in dtSelected.Rows)
//    {
//        DataRow dr = dtSource.NewRow();
//        dr[0] = row[0];
//        dtSource.Rows.Add(dr);
//    }
//    ListBox lstSrc = ((ListBox)FormView1.FindControl("lstSource_EDIT"));
//    lstSrc.DataSource = dtSource;
//    lstSrc.DataValueField = "ColumnName";
//    lstSrc.DataTextField = "ColumnName";
//    lstSrc.DataBind();
//    foreach (DataRow row in dtSource.Rows)
//    {
//        DataRow[] dr = dtSelected.Select("ColumnName='" + row[0] + "'");
//        //dr[0] = row[0];
//        if (dr.Length > 0) dtSelected.Rows.Remove(dr[0]);
//    }
//    ListBox lstSel = ((ListBox)FormView1.FindControl("lstSelected_EDIT"));
//    lstSel.DataSource = dtSelected;
//    lstSel.DataValueField = "ColumnName";
//    lstSel.DataTextField = "ColumnName";
//    lstSel.DataBind();
//    ViewState["source"] = dtSource;
//    ViewState["selected"] = dtSelected;
//}
//protected void btnInsertSelected_Click(object sender, EventArgs e)
//{
//    ListBox lstSrc = ((ListBox)FormView1.FindControl("lstSource_EDIT"));
//    ListBox lstSel = ((ListBox)FormView1.FindControl("lstSelected_EDIT"));
//    if (lstSrc.SelectedIndex>=0)
//    {
//        DataTable dtSource = (DataTable)ViewState["source"];
//        DataTable dtSelected = (DataTable)ViewState["selected"];

//        string selectedValue = lstSrc.SelectedValue;
//        DataRow drInsert = dtSelected.NewRow();
//        drInsert[0] = selectedValue;
//        dtSelected.Rows.Add(drInsert);

//        DataRow[] dr = dtSource.Select("ColumnName='" + selectedValue + "'");
//        //dr[0] = row[0];
//        dtSource.Rows.Remove(dr[0]);

//        lstSel.DataSource = dtSelected;
//        lstSel.DataValueField = "ColumnName";
//        lstSel.DataTextField = "ColumnName";
//        lstSel.DataBind();
//        lstSrc.DataSource = dtSource;
//        lstSrc.DataValueField = "ColumnName";
//        lstSrc.DataTextField = "ColumnName";
//        lstSrc.DataBind();
//        ViewState["source"] = dtSource;
//        ViewState["selected"] = dtSelected;
//    }

//}
//protected void btnRemoveSelected_Click(object sender, EventArgs e)
//{
//    ListBox lstSrc = ((ListBox)FormView1.FindControl("lstSource_EDIT"));
//    ListBox lstSel = ((ListBox)FormView1.FindControl("lstSelected_EDIT"));
//    if (lstSel.SelectedIndex>=0)
//    {
//        DataTable dtSource = (DataTable)ViewState["source"];
//        DataTable dtSelected = (DataTable)ViewState["selected"];

//        string selectedValue = lstSel.SelectedValue;
//        DataRow dr = dtSource.NewRow();
//        dr[0] = selectedValue;
//        dtSource.Rows.Add(dr);

//        DataRow[] drRemove = dtSelected.Select("ColumnName='" + selectedValue + "'");
//        //dr[0] = row[0];
//        dtSelected.Rows.Remove(drRemove[0]);

//        lstSel.DataSource = dtSelected;
//        lstSel.DataValueField = "ColumnName";
//        lstSel.DataTextField = "ColumnName";
//        lstSel.DataBind();
//        lstSrc.DataSource = dtSource;
//        lstSrc.DataValueField = "ColumnName";
//        lstSrc.DataTextField = "ColumnName";
//        lstSrc.DataBind();
//        ViewState["source"] = dtSource;
//        ViewState["selected"] = dtSelected;
//    }

// }
//protected void ddlBank_INSERT_SelectedIndexChanged(object sender, EventArgs e)
//{

//}
//protected void btnRemoveAll_INSERT_Click(object sender, EventArgs e)
//{
//    DataTable dtSource = (DataTable)ViewState["source"];
//    DataTable dtSelected = (DataTable)ViewState["selected"];
//    foreach (DataRow row in dtSelected.Rows)
//    {
//        DataRow dr = dtSource.NewRow();
//        dr[0] = row[0];
//        dtSource.Rows.Add(dr);
//    }
//    ListBox lstSrc = ((ListBox)FormView1.FindControl("lstSource_INSERT"));
//    lstSrc.DataSource = dtSource;
//    lstSrc.DataValueField = "ColumnName";
//    lstSrc.DataTextField = "ColumnName";
//    lstSrc.DataBind();
//    foreach (DataRow row in dtSource.Rows)
//    {
//        DataRow[] dr = dtSelected.Select("ColumnName='" + row[0] + "'");
//        //dr[0] = row[0];
//        if (dr.Length > 0) dtSelected.Rows.Remove(dr[0]);
//    }
//    ListBox lstSel = ((ListBox)FormView1.FindControl("lstSelected_INSERT"));
//    lstSel.DataSource = dtSelected;
//    lstSel.DataValueField = "ColumnName";
//    lstSel.DataTextField = "ColumnName";
//    lstSel.DataBind();
//    ViewState["source"] = dtSource;
//    ViewState["selected"] = dtSelected;

//}
//protected void btnRemoveSelected_INSERT_Click(object sender, EventArgs e)
//{
//    ListBox lstSrc = ((ListBox)FormView1.FindControl("lstSource_INSERT"));
//    ListBox lstSel = ((ListBox)FormView1.FindControl("lstSelected_INSERT"));
//    if (lstSel.SelectedIndex >= 0)
//    {
//        DataTable dtSource = (DataTable)ViewState["source"];
//        DataTable dtSelected = (DataTable)ViewState["selected"];

//        string selectedValue = lstSel.SelectedValue;
//        DataRow dr = dtSource.NewRow();
//        dr[0] = selectedValue;
//        dtSource.Rows.Add(dr);

//        DataRow[] drRemove = dtSelected.Select("ColumnName='" + selectedValue + "'");
//        //dr[0] = row[0];
//        dtSelected.Rows.Remove(drRemove[0]);

//        lstSel.DataSource = dtSelected;
//        lstSel.DataValueField = "ColumnName";
//        lstSel.DataTextField = "ColumnName";
//        lstSel.DataBind();
//        lstSrc.DataSource = dtSource;
//        lstSrc.DataValueField = "ColumnName";
//        lstSrc.DataTextField = "ColumnName";
//        lstSrc.DataBind();
//        ViewState["source"] = dtSource;
//        ViewState["selected"] = dtSelected;
//    }

//}
//protected void btnInsertSelected_INSERT_Click(object sender, EventArgs e)
//{
//    ListBox lstSrc = ((ListBox)FormView1.FindControl("lstSource_INSERT"));
//    ListBox lstSel = ((ListBox)FormView1.FindControl("lstSelected_INSERT"));
//    if (lstSrc.SelectedIndex >= 0)
//    {
//        DataTable dtSource = (DataTable)ViewState["source"];
//        DataTable dtSelected = (DataTable)ViewState["selected"];

//        string selectedValue = lstSrc.SelectedValue;
//        DataRow drInsert = dtSelected.NewRow();
//        drInsert[0] = selectedValue;
//        dtSelected.Rows.Add(drInsert);

//        DataRow[] dr = dtSource.Select("ColumnName='" + selectedValue + "'");
//        //dr[0] = row[0];
//        dtSource.Rows.Remove(dr[0]);

//        lstSel.DataSource = dtSelected;
//        lstSel.DataValueField = "ColumnName";
//        lstSel.DataTextField = "ColumnName";
//        lstSel.DataBind();
//        lstSrc.DataSource = dtSource;
//        lstSrc.DataValueField = "ColumnName";
//        lstSrc.DataTextField = "ColumnName";
//        lstSrc.DataBind();
//        ViewState["source"] = dtSource;
//        ViewState["selected"] = dtSelected;
//    }


//}
//protected void btnInsertAll_INSERT_Click(object sender, EventArgs e)
//{
//    DataTable dtSource = (DataTable)ViewState["source"];
//    DataTable dtSelected = (DataTable)ViewState["selected"];
//    foreach (DataRow row in dtSource.Rows)
//    {
//        DataRow dr = dtSelected.NewRow();
//        dr[0] = row[0];
//        dtSelected.Rows.Add(dr);
//    }
//    ListBox lstSel = ((ListBox)FormView1.FindControl("lstSelected_INSERT"));
//    lstSel.DataSource = dtSelected;
//    lstSel.DataValueField = "ColumnName";
//    lstSel.DataTextField = "ColumnName";
//    lstSel.DataBind();
//    foreach (DataRow row in dtSelected.Rows)
//    {
//        DataRow[] dr = dtSource.Select("ColumnName='" + row[0] + "'");
//        //dr[0] = row[0];
//        if (dr.Length > 0) dtSource.Rows.Remove(dr[0]);
//    }
//    ListBox lstSrc = ((ListBox)FormView1.FindControl("lstSource_INSERT"));
//    lstSrc.DataSource = dtSource;
//    lstSrc.DataValueField = "ColumnName";
//    lstSrc.DataTextField = "ColumnName";
//    lstSrc.DataBind();
//    ViewState["source"] = dtSource;
//    ViewState["selected"] = dtSelected;
//}
#endregion
#region
//if (((CheckBox)FormView1.FindControl("RB_Customer_EDIT")).Checked == true)
//{
//    Session["TXT_ID_EDIT"] = "";
//    Session["TXT_Name_EDIT"] = "";
//    Session["TXT_ID_EDIT"] = "TXT_SourceID_EDIT";
//    Session["TXT_Name_EDIT"] = "TXT_SourceName_EDIT";
//    Session["REQ_SourceID_EDIT"] = "REQ_SourceID_EDIT";
//}
//else if (((CheckBox)FormView1.FindControl("RB_CorrBank_EDIT")).Checked == true)
//{
//    Session["TXT_ID_EDIT"] = "";
//    Session["TXT_Name_EDIT"] = "";
//    Session["TXT_ID_EDIT"] = "TXT_SourceID_Corr_EDIT";
//    Session["TXT_Name_EDIT"] = "TXT_SourceID_Corr_EDIT";
//    Session["REQ_SourceID_EDIT"] = "REQ_SourceID_Corr_EDIT";
//}
//else if (((CheckBox)FormView1.FindControl("RB_Star_EDIT")).Checked == true)
//{
//    Session["TXT_ID_EDIT"] = "";
//    Session["TXT_Name_EDIT"] = "";
//    Session["TXT_ID_EDIT"] = "TXT_SourceID_Star_EDIT";
//    Session["TXT_Name_EDIT"] = "TXT_SourceID_Star_EDIT";
//    Session["REQ_SourceID_EDIT"] = "REQ_SourceID_Star_EDIT";
//}
//else if (((CheckBox)FormView1.FindControl("RB_Courier_EDIT")).Checked == true)
//{
//    Session["TXT_ID_EDIT"] = "";
//    Session["TXT_Name_EDIT"] = "";
//    Session["TXT_ID_EDIT"] = "TXT_SourceID_Cour_EDIT";
//    Session["TXT_Name_EDIT"] = "TXT_SourceID_Cour_EDIT";
//    Session["REQ_SourceID_EDIT"] = "REQ_SourceID_Cour_EDIT";
//}
//else if (((CheckBox)FormView1.FindControl("RB_Beneficiray_EDIT")).Checked == true)
//{
//    Session["TXT_ID_EDIT"] = "";
//    Session["TXT_Name_EDIT"] = "";
//    Session["TXT_ID_EDIT"] = "TXT_SourceID_Bene_EDIT";
//    Session["TXT_Name_EDIT"] = "TXT_SourceName_Bene_EDIT";
//    Session["REQ_SourceID_EDIT"] = "REQ_SourceID_Bene_EDIT";
//}
//((TextBox)FormView1.FindControl("TXT_SourceID_EDIT")).Attributes.Add("onchange", "return SearchSourceIDEDIT();");
//((TextBox)FormView1.FindControl("TXT_SourceID_Corr_EDIT")).Attributes.Add("onchange", "return SearchSourceIDEDIT();");
//((TextBox)FormView1.FindControl("TXT_SourceID_Star_EDIT")).Attributes.Add("onchange", "return SearchSourceIDEDIT();");
//((TextBox)FormView1.FindControl("TXT_SourceID_Cour_EDIT")).Attributes.Add("onchange", "return SearchSourceIDEDIT();");
//((TextBox)FormView1.FindControl("TXT_SourceID_Bene_EDIT")).Attributes.Add("onchange", "return SearchSourceIDEDIT();");

/*DataSet ds = new DataSet();
DataSet dsDetail=new DataSet();
string srcID = "",ID="";
ds = lov.Get_SPDS_Bank_Customers();
            
ddlBank_EDIT.DataSource = ds.Tables[0];
ddlBank_EDIT.DataTextField = "BankName";
ddlBank_EDIT.DataValueField = "BankCode";
ddlBank_EDIT.DataBind();

//Bind("SourceID")
try
{
    DataRowView drv = (DataRowView)FormView1.DataItem;
    srcID = drv["SourceID"].ToString();
    ID= drv["ID"].ToString();
    ddlBank_EDIT.SelectedValue = srcID;
}
catch (Exception ex)
{
    ddlBank_EDIT.SelectedIndex = 0;
}
dsDetail = lov.Get_SPDS_SP_UniversalUploadCofigurationDetail_Get(ID);

DataSet dsColumns = new DataSet();
dsColumns = lov.Get_SPDS_UniversalUploadColumns();
ViewState["source"] = dsColumns.Tables[0];
//dsColumns.Tables[0].Rows.Clear();
ViewState["selected"] = dsColumns.Tables[0].Clone();

//((DataTable)ViewState["selected"]).Rows.Clear();
if (ViewState["source"] != null)
{
    DataTable dtSource = (DataTable)ViewState["source"];
    ListBox lstSrc = ((ListBox)FormView1.FindControl("lstSource_EDIT"));
    lstSrc.DataSource = dtSource;
    lstSrc.DataValueField = "ColumnName";
    lstSrc.DataTextField = "ColumnName";
    lstSrc.DataBind();
}
if (dsDetail.Tables[0].Rows.Count>0)
{
    //DataTable dtSource = (DataTable)ViewState["selected"];
    //ListBox lstSel = ((ListBox)FormView1.FindControl("lstSelected_EDIT"));
    //lstSel.DataSource = dtSource;
    //lstSel.DataValueField = "ColumnName";
    //lstSel.DataTextField = "ColumnName";
    //lstSel.DataBind();
    DataTable dtSource = (DataTable)ViewState["source"];
    DataTable dtSelected = (DataTable)ViewState["selected"];
    for (int i = 0; i < dsDetail.Tables[0].Rows.Count; i++)
    {
        DataRow dr = dtSelected.NewRow();
        dr[0] = dsDetail.Tables[0].Rows[i]["ColumnName"].ToString();
        dtSelected.Rows.Add(dr);
    }
    foreach (DataRow row in dtSelected.Rows)
    {
        DataRow[] dr = dtSource.Select("ColumnName='" + row[0] + "'");
        //dr[0] = row[0];
        if (dr.Length > 0) dtSource.Rows.Remove(dr[0]);
    }
    ListBox lstSrc = ((ListBox)FormView1.FindControl("lstSource_EDIT"));
    ListBox lstSel = ((ListBox)FormView1.FindControl("lstSelected_EDIT"));
    lstSel.DataSource = dtSelected;
    lstSel.DataValueField = "ColumnName";
    lstSel.DataTextField = "ColumnName";
    lstSel.DataBind();
    lstSrc.DataSource = dtSource;
    lstSrc.DataValueField = "ColumnName";
    lstSrc.DataTextField = "ColumnName";
    lstSrc.DataBind();
    ViewState["source"] = dtSource;
    ViewState["selected"] = dtSelected;
}*/
#endregion
#region
/*
            //DataSet ds = new DataSet();
            //DataSet dsDetail = new DataSet();
            //string srcID = "", ID = "";
            //ds = lov.Get_SPDS_Bank_Customers();

            //ddlBank_INSERT.DataSource = ds.Tables[0];
            //ddlBank_INSERT.DataTextField = "BankName";
            //ddlBank_INSERT.DataValueField = "BankCode";
            //ddlBank_INSERT.DataBind();

            //Bind("SourceID")
            //try
            //{
                //DataRowView drv = (DataRowView)FormView1.DataItem;
                //srcID = drv["SourceID"].ToString();
                //ID = drv["ID"].ToString();
                //ddlBank_INSERT.SelectedValue = srcID;
            //}
            //catch (Exception ex)
            //{
                //ddlBank_INSERT.SelectedIndex = 0;
            //}
            //dsDetail = lov.Get_SPDS_SP_UniversalUploadCofigurationDetail_Get(ID);

            DataSet dsColumns = new DataSet();
            dsColumns = lov.Get_SPDS_UniversalUploadColumns();
            ViewState["source"] = dsColumns.Tables[0];
            //dsColumns.Tables[0].Rows.Clear();
            ViewState["selected"] = dsColumns.Tables[0].Clone();

            //((DataTable)ViewState["selected"]).Rows.Clear();
            if (ViewState["source"] != null)
            {
                DataTable dtSource = (DataTable)ViewState["source"];
                ListBox lstSrc = ((ListBox)FormView1.FindControl("lstSource_INSERT"));
                lstSrc.DataSource = dtSource;
                lstSrc.DataValueField = "ColumnName";
                lstSrc.DataTextField = "ColumnName";
                lstSrc.DataBind();
            }
            if (dsDetail.Tables[0].Rows.Count > 0)
            {
                //DataTable dtSource = (DataTable)ViewState["selected"];
                //ListBox lstSel = ((ListBox)FormView1.FindControl("lstSelected_EDIT"));
                //lstSel.DataSource = dtSource;
                //lstSel.DataValueField = "ColumnName";
                //lstSel.DataTextField = "ColumnName";
                //lstSel.DataBind();
                DataTable dtSource = (DataTable)ViewState["source"];
                DataTable dtSelected = (DataTable)ViewState["selected"];
                for (int i = 0; i < dsDetail.Tables[0].Rows.Count; i++)
                {
                    DataRow dr = dtSelected.NewRow();
                    dr[0] = dsDetail.Tables[0].Rows[i]["ColumnName"].ToString();
                    dtSelected.Rows.Add(dr);
                }
                foreach (DataRow row in dtSelected.Rows)
                {
                    DataRow[] dr = dtSource.Select("ColumnName='" + row[0] + "'");
                    //dr[0] = row[0];
                    if (dr.Length > 0) dtSource.Rows.Remove(dr[0]);
                }
                ListBox lstSrc = ((ListBox)FormView1.FindControl("lstSource_INSERT"));
                ListBox lstSel = ((ListBox)FormView1.FindControl("lstSelected_INSERT"));
                lstSel.DataSource = dtSelected;
                lstSel.DataValueField = "ColumnName";
                lstSel.DataTextField = "ColumnName";
                lstSel.DataBind();
                lstSrc.DataSource = dtSource;
                lstSrc.DataValueField = "ColumnName";
                lstSrc.DataTextField = "ColumnName";
                lstSrc.DataBind();
                ViewState["source"] = dtSource;
                ViewState["selected"] = dtSelected;
            }

            //((TextBox)FormView1.FindControl("TXT_SourceID_INSERT")).Attributes.Add("onchange", "return SearchSourceIDINSERT();");
            //((TextBox)FormView1.FindControl("TXT_SourceID_Corr_INSERT")).Attributes.Add("onchange", "return SearchSourceIDINSERT();");
            //((TextBox)FormView1.FindControl("TXT_SourceID_Star_INSERT")).Attributes.Add("onchange", "return SearchSourceIDINSERT();");
            //((TextBox)FormView1.FindControl("TXT_SourceID_Cour_INSERT")).Attributes.Add("onchange", "return SearchSourceIDINSERT();");
            //((TextBox)FormView1.FindControl("TXT_SourceID_Bene_INSERT")).Attributes.Add("onchange", "return SearchSourceIDINSERT();");*/
#endregion
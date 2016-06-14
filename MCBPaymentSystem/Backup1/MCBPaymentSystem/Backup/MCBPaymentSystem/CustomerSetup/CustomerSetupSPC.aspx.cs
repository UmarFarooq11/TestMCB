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

public partial class CustomerSetup_frmRPS_BankSPC : System.Web.UI.Page
{
    FormViewRow D_TEMP;
    TextBox TXT;
    Label LL;
    static String CustomerID;

    PROCESS_RPS_Bank P_RPS_Bank = new PROCESS_RPS_Bank();
    PROCESS_RPS_BankContact P_RPS_BankContact = new PROCESS_RPS_BankContact();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["RPS_Bank_ID"].ToString() == "0")
        {
            FormView1.ChangeMode(FormViewMode.Insert);
            ((Label)FormView1.Row.FindControl("Label_HEAD")).Text = "Customer Setup";
        }
        else
        {
            ((Label)FormView1.FindControl("Label_HEAD")).Text = "Customer Setup : " + Session["RPS_Bank_BankCode"].ToString() + " / " + Session["RPS_Bank_BankName"].ToString();
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
    protected void FormView1_PageIndexChanging(object sender, FormViewPageEventArgs e) { }
    private void BackPage()
    {
        Session["RPS_Bank_BankCode"] = "0";
        Session["RPS_Bank_BankName"] = "0";
      ///  Response.Redirect("../CustomerSetup/CustomerSetup.aspx");
        Response.Redirect("../CustomerSetup/CustomerSetup.aspx" + "?" + "s1=" + Request.QueryString[0].ToString());
    }
    protected void Page_PreInit(object sender, EventArgs e)
    { Page.Theme = Session["ThemeChange"].ToString(); }
    protected void DisplayToolBar_ItemClick(object sender, EO.Web.ToolBarEventArgs e)
    {
        if (e.Item.ToolTip == "Edit")
        { FormView1.ChangeMode(FormViewMode.Edit); }
        else if (e.Item.ToolTip == "Cancel")
        { BackPage(); }
        else if (e.Item.ToolTip == "Authorize / Unauthorize")
        {
            LOV_COLLECTION L = new LOV_COLLECTION();
            DataSet DS;
            DS = L.SP_AuthorizeRecord("RPS_Bank", Session["U_NAME"].ToString(), DateTime.Now.ToString("MM-dd-yyyy"), Session["RPS_Bank_ID"].ToString());
           // Response.Redirect("../CustomerSetup/CustomerSetupSPC.aspx");
            Response.Redirect("../CustomerSetup/CustomerSetupSPC.aspx" + "?" + "s1=" + Request.QueryString[0].ToString());
        }
    }
    protected void EditToolbar_ItemClick(object sender, EO.Web.ToolBarEventArgs e)
    {
        Page.Validate();
        if (e.Item.ToolTip == "Update")
        {
            if (Page.IsValid)
            {
                LOV_COLLECTION L = new LOV_COLLECTION();
                DataSet DS;
                DS = L.SP_CustomerSetup_DP(((TextBox)FormView1.FindControl("TXT_BankCode_EDIT")).Text,Session["RPS_Bank_ID"].ToString());
                if (DS.Tables[0].Rows.Count > 0)
                {
                    ((Label)FormView1.FindControl("lblDuplicate_EDIT")).Text = "Duplicate Record";
                }
                else
                {
                    if (DS.Tables[0].Rows.Count <= 0)
                    {

                        P_RPS_Bank.RecordInputStart();
                        P_RPS_Bank.Get_ID = Session["RPS_Bank_ID"].ToString();
                        P_RPS_Bank.Get_BankCode = ((TextBox)FormView1.FindControl("TXT_BankCode_EDIT")).Text;
                        P_RPS_Bank.Get_BankName = ((TextBox)FormView1.FindControl("TXT_BankName_EDIT")).Text;
                        P_RPS_Bank.Get_Abbreviation = ((TextBox)FormView1.FindControl("TXT_Abbreviation_EDIT")).Text;
                        P_RPS_Bank.Get_AssignedCitiBankId = ((TextBox)FormView1.FindControl("TXT_AssignedCitiBankId_EDIT")).Text;

                        //---------Primary Contact--------------
                        P_RPS_Bank.Get_Address = ((TextBox)FormView1.FindControl("TXT_Address_EDIT")).Text;
                        P_RPS_Bank.Get_PhoneNo = ((TextBox)FormView1.FindControl("TXT_PhoneNo_EDIT")).Text;
                        P_RPS_Bank.Get_FaxNo = ((TextBox)FormView1.FindControl("TXT_FaxNo_EDIT")).Text;
                        P_RPS_Bank.Get_Email = ((TextBox)FormView1.FindControl("TXT_Email_EDIT")).Text;

                        P_RPS_Bank.Get_ServiceTypeID = "1";

                        if (((CheckBox)FormView1.FindControl("TXT_InputFileAllowed_EDIT")).Checked == true)
                        {
                            //P_RPS_Bank.Get_InputFileAllowed = "True";
                            P_RPS_Bank.Get_InputFileAllowed = "1";
                        }
                        else
                        {
                            //P_RPS_Bank.Get_InputFileAllowed = "False";
                            P_RPS_Bank.Get_InputFileAllowed = "0";
                        }

                        P_RPS_Bank.Get_UnclaimedDraftPeriod = "0";  //((TextBox)FormView1.FindControl("TXT_UnclaimedDraftPeriod_EDIT")).Text;
                        P_RPS_Bank.Get_FloorLimit = "0";            //((TextBox)FormView1.FindControl("TXT_FloorLimit_EDIT")).Text;
                        P_RPS_Bank.Get_DraftFooterMessage = "0";    //((TextBox)FormView1.FindControl("TXT_DraftFooterMessage_EDIT")).Text;
                        P_RPS_Bank.Get_URL = "0";                   //((TextBox)FormView1.FindControl("TXT_URL_EDIT")).Text;
                        P_RPS_Bank.Get_RemitType = "0";             //((TextBox)FormView1.FindControl("TXT_RemitType_EDIT")).Text;
                        //P_RPS_Bank.Get_IsCitiBank = "True";
                        P_RPS_Bank.Get_IsCitiBank = "1";
                        P_RPS_Bank.Get_A_UserID = Session["U_NAME"].ToString();
                        P_RPS_Bank.Get_A_DateTime = DateTime.Now.ToString("dd-MMM-yyyy").ToString();
                        P_RPS_Bank.Get_E_UserID = Session["U_NAME"].ToString();
                        P_RPS_Bank.Get_E_DateTime = DateTime.Now.ToString("dd-MMM-yyyy").ToString();

                        P_RPS_Bank.Get_OnlineDraftStartingNo = "0";     //((TextBox)FormView1.FindControl("TXT_OnlineDraftStartingNo_EDIT")).Text;
                        P_RPS_Bank.Get_OfflineDraftStartingNo = "0";    //((TextBox)FormView1.FindControl("TXT_OfflineDraftStartingNo_EDIT")).Text;
                        P_RPS_Bank.Get_ReportTitle = ((TextBox)FormView1.FindControl("TXT_ReportTitle_EDIT")).Text;

                        if (((RadioButton)FormView1.FindControl("TXT_IsDollarBased_EDIT")).Checked == true)
                        {
                            //P_RPS_Bank.Get_IsDollarBased = "True";
                            P_RPS_Bank.Get_IsDollarBased = "1";
                        }
                        else if (((RadioButton)FormView1.FindControl("TXT_IsRupeeBased_EDIT")).Checked == true)
                        {
                            //P_RPS_Bank.Get_IsDollarBased = "False";
                            P_RPS_Bank.Get_IsDollarBased = "0";
                        }

                        P_RPS_Bank.Get_AccountNo = ((TextBox)FormView1.FindControl("TXT_Account_No_EDIT")).Text;

                        if (((RadioButton)FormView1.FindControl("TXT_CustomerTypeMTO_EDIT")).Checked == true)
                        {
                            //P_RPS_Bank.Get_CustomerType = "True";
                            P_RPS_Bank.Get_CustomerType = "1";
                        }
                        else if (((RadioButton)FormView1.FindControl("TXT_CustomerTypeCORP_EDIT")).Checked == true)
                        {
                            //P_RPS_Bank.Get_CustomerType = "False";
                            P_RPS_Bank.Get_CustomerType = "0";
                        }
                        P_RPS_Bank.Get_Customer_Balance = ((TextBox)FormView1.FindControl("TXT_CustomerBal_Edit")).Text;
                        //P_RPS_Bank.Get_IsPRI = "True";
                        P_RPS_Bank.Get_IsPRI = "1";
                        P_RPS_Bank.RecordInputCommit();
                        P_RPS_Bank.EditNewGroup();


                        //------Secondary Contact--------
                        P_RPS_BankContact.RecordInputStart();
                        P_RPS_BankContact.Get_ID = "0";
                        P_RPS_BankContact.Get_BankID = Session["RPS_Bank_ID"].ToString();
                        P_RPS_BankContact.Get_Address = ((TextBox)FormView1.FindControl("TXT_SecondayAddress_EDIT")).Text;
                        P_RPS_BankContact.Get_Email = ((TextBox)FormView1.FindControl("TXT_SecondayEmail_EDIT")).Text;
                        P_RPS_BankContact.Get_PhoneNo = ((TextBox)FormView1.FindControl("TXT_SecondayPhoneNo_EDIT")).Text;
                        P_RPS_BankContact.Get_FaxNo = ((TextBox)FormView1.FindControl("TXT_SecondayFaxNo_EDIT")).Text;
                        P_RPS_BankContact.Get_NTNNo = "1";
                        P_RPS_BankContact.RecordInputCommit();
                        P_RPS_BankContact.EditNewGroup();

                        BackPage();
                    }
                    else
                    {
                        ((TextBox)FormView1.FindControl("TXT_BankCode_EDIT")).Text = "";
                        ((RequiredFieldValidator)FormView1.FindControl("REQ_BankCode_EDIT")).Validate();
                    }
                }
            }
        }
        else if (e.Item.ToolTip == "Cancel")
        { BackPage(); }
    }
    protected void InsertToolbar_ItemClick(object sender, EO.Web.ToolBarEventArgs e)
    {
        Page.Validate();
        if (e.Item.ToolTip == "Insert")
        {
            if (Page.IsValid)
            {
                LOV_COLLECTION L = new LOV_COLLECTION();
                DataSet DS;
                DS = L.SP_CustomerSetup_DP(((TextBox)FormView1.FindControl("TXT_BankCode_INSERT")).Text,"0");
                if (DS.Tables[0].Rows.Count > 0)
                {
                    ((Label)FormView1.FindControl("lblDuplicate_INSERT")).Text = "Duplicate Record";
                }
                else
                {
                    if (DS.Tables[0].Rows.Count <= 0)
                    {
                        P_RPS_Bank.RecordInputStart();
                        P_RPS_Bank.Get_ID = "0";
                        P_RPS_Bank.Get_BankCode = ((TextBox)FormView1.FindControl("TXT_BankCode_INSERT")).Text;
                        P_RPS_Bank.Get_BankName = ((TextBox)FormView1.FindControl("TXT_BankName_INSERT")).Text;
                        P_RPS_Bank.Get_Abbreviation = ((TextBox)FormView1.FindControl("TXT_Abbreviation_INSERT")).Text;
                        P_RPS_Bank.Get_AssignedCitiBankId = ((TextBox)FormView1.FindControl("TXT_AssignedCitiBankId_INSERT")).Text;

                        //---------Primary contact-------
                        P_RPS_Bank.Get_Address = ((TextBox)FormView1.FindControl("TXT_Address_INSERT")).Text;
                        P_RPS_Bank.Get_PhoneNo = ((TextBox)FormView1.FindControl("TXT_PhoneNo_INSERT")).Text;
                        P_RPS_Bank.Get_FaxNo = ((TextBox)FormView1.FindControl("TXT_FaxNo_INSERT")).Text;
                        P_RPS_Bank.Get_Email = ((TextBox)FormView1.FindControl("TXT_Email_INSERT")).Text;

                        P_RPS_Bank.Get_ServiceTypeID = "1";

                        if (((CheckBox)FormView1.FindControl("TXT_InputFileAllowed_INSERT")).Checked == true)
                        {
                            //P_RPS_Bank.Get_InputFileAllowed = "True";
                            P_RPS_Bank.Get_InputFileAllowed = "1";
                        }
                        else
                        {
                            //P_RPS_Bank.Get_InputFileAllowed = "False";
                            P_RPS_Bank.Get_InputFileAllowed = "0";
                        }
                        //((TextBox)FormView1.FindControl("TXT_InputFileAllowed_INSERT")).Text;
                        P_RPS_Bank.Get_UnclaimedDraftPeriod = "0";      //((TextBox)FormView1.FindControl("TXT_UnclaimedDraftPeriod_INSERT")).Text;
                        P_RPS_Bank.Get_FloorLimit = "0";                //((TextBox)FormView1.FindControl("TXT_FloorLimit_INSERT")).Text;
                        P_RPS_Bank.Get_DraftFooterMessage = "0";        //((TextBox)FormView1.FindControl("TXT_DraftFooterMessage_INSERT")).Text;
                        P_RPS_Bank.Get_URL = "0";                       //((TextBox)FormView1.FindControl("TXT_URL_INSERT")).Text;
                        P_RPS_Bank.Get_RemitType = "0";                 //((TextBox)FormView1.FindControl("TXT_RemitType_INSERT")).Text;
                        //P_RPS_Bank.Get_IsCitiBank = "True";             //((TextBox)FormView1.FindControl("TXT_IsCitiBank_INSERT")).Text;
                        P_RPS_Bank.Get_IsCitiBank = "1";
                        P_RPS_Bank.Get_A_UserID = Session["U_NAME"].ToString();
                        P_RPS_Bank.Get_A_DateTime = DateTime.Now.ToString("dd-MMM-yyyy").ToString();
                        P_RPS_Bank.Get_E_UserID = Session["U_NAME"].ToString();
                        P_RPS_Bank.Get_E_DateTime = DateTime.Now.ToString("dd-MMM-yyyy").ToString();

                        P_RPS_Bank.Get_OnlineDraftStartingNo = "0";     //((TextBox)FormView1.FindControl("TXT_OnlineDraftStartingNo_INSERT")).Text;
                        P_RPS_Bank.Get_OfflineDraftStartingNo = "0";    //((TextBox)FormView1.FindControl("TXT_OfflineDraftStartingNo_INSERT")).Text;
                        P_RPS_Bank.Get_ReportTitle = ((TextBox)FormView1.FindControl("TXT_ReportTitle_INSERT")).Text;

                        if (((RadioButton)FormView1.FindControl("TXT_IsDollarBased_INSERT")).Checked == true)
                        {
                            //P_RPS_Bank.Get_IsDollarBased = "True";
                            P_RPS_Bank.Get_IsDollarBased = "1";
                        }
                        else if (((RadioButton)FormView1.FindControl("TXT_IsRupeeBased_INSERT")).Checked == true)
                        {
                            //P_RPS_Bank.Get_IsDollarBased = "False";
                            P_RPS_Bank.Get_IsDollarBased = "0";
                        }
                        //P_RPS_Bank.Get_IsDollarBased = "True";//((TextBox)FormView1.FindControl("TXT_IsDollarBased_INSERT")).Text;
                        P_RPS_Bank.Get_AccountNo = ((TextBox)FormView1.FindControl("TXT_Account_No_Insert")).Text;

                        if (((RadioButton)FormView1.FindControl("TXT_CustomerTypeMTO_INSERT")).Checked == true)
                        {
                            //P_RPS_Bank.Get_CustomerType = "True";
                            P_RPS_Bank.Get_CustomerType = "1";
                        }
                        else if (((RadioButton)FormView1.FindControl("TXT_CustomerTypeCORP_INSERT")).Checked == true)
                        {
                            //P_RPS_Bank.Get_CustomerType = "False";
                            P_RPS_Bank.Get_CustomerType = "0";
                        }
                        //P_RPS_Bank.Get_IsPRI = "True";
                        P_RPS_Bank.Get_IsPRI = "1";
                        P_RPS_Bank.Get_Customer_Balance = ((TextBox)FormView1.FindControl("TXT_CustomerBal_Insert")).Text;
                        
                        P_RPS_Bank.RecordInputCommit();
                        P_RPS_Bank.AddNewGroup();

                        //-------------Secondary Contact -----------------
                        /// DataSet DS;
                        DS = L.SP_CustomerSetup_MaxID();
                        Session["RPS_Bank_ID"] = DS.Tables[0].Rows[0][0].ToString();

                        P_RPS_BankContact.RecordInputStart();
                        P_RPS_BankContact.Get_ID = "0";
                        P_RPS_BankContact.Get_BankID = Session["RPS_Bank_ID"].ToString();
                        P_RPS_BankContact.Get_Address = ((TextBox)FormView1.FindControl("TXT_SecondayAddress_INSERT")).Text;
                        P_RPS_BankContact.Get_Email = ((TextBox)FormView1.FindControl("TXT_SecondayEmail_INSERT")).Text;
                        P_RPS_BankContact.Get_PhoneNo = ((TextBox)FormView1.FindControl("TXT_SecondayPhoneNo_INSERT")).Text;
                        P_RPS_BankContact.Get_FaxNo = ((TextBox)FormView1.FindControl("TXT_SecondayFaxNo_INSERT")).Text;
                        P_RPS_BankContact.RecordInputCommit();
                        P_RPS_BankContact.AddNewGroup();
                        BackPage();
                    }
                    else
                    {
                        ((TextBox)FormView1.FindControl("TXT_BankCode_INSERT")).Text = "";
                        ((RequiredFieldValidator)FormView1.FindControl("REQ_BankCode_INSERT")).Validate();
                    }
                }
            }
            
        }
        else if (e.Item.ToolTip == "Cancel")
        { BackPage(); }
    }
    protected void BTN_BankCode_EDIT_Click(object sender, ImageClickEventArgs e)
    {
        if (Session["LOV_ID"] != "")
        {
            CustomerID = Session["LOV_ID"].ToString();
            ((TextBox)FormView1.FindControl("TXT_BankCode_EDIT")).Text = Session["LOV_Abbreviation"].ToString();
            ((TextBox)FormView1.FindControl("TXT_BankName_EDIT")).Text = Session["LOV_DESCRIPTION"].ToString();
        }
    }
    protected void BTN_BankCode_INSERT_Click(object sender, ImageClickEventArgs e)
    {
        if (Session["LOV_ID"] != "")
        {
            CustomerID = Session["LOV_ID"].ToString();
            ((TextBox)FormView1.FindControl("TXT_BankCode_INSERT")).Text = Session["LOV_Abbreviation"].ToString();
            ((TextBox)FormView1.FindControl("TXT_BankName_INSERT")).Text = Session["LOV_DESCRIPTION"].ToString();
        }
    }
}


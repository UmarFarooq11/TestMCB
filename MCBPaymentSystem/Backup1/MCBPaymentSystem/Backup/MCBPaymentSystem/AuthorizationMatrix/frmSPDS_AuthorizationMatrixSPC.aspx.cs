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

public partial class AuthorizationMatrix_frmSPDS_AuthorizationMatrixSPC : System.Web.UI.Page
{
    FormViewRow D_TEMP;
    TextBox TXT;
    Label LL;
    static string CustomerID;
    static string InstrumentID;
    static string MakerSignatoryID,CheckerSignatoryID;
    static string CategoryID;
    LOV_COLLECTION lov = new LOV_COLLECTION();
    PROCESS_SPDS_AuthorizationMatrix P_SPDS_AuthorizationMatrix = new PROCESS_SPDS_AuthorizationMatrix();

    protected void Page_Load(object sender, EventArgs e)
    {
        InstrumentID = "123";
        if (Session["SPDS_AuthorizationMatrix_ID"].ToString() == "0")
        {
            FormView1.ChangeMode(FormViewMode.Insert);
            ((Label)FormView1.Row.FindControl("Label_HEAD")).Text = "Authorization Matrix";
        }
        else
        {
            ///((Label)FormView1.FindControl("Label_HEAD")).Text = " Authorization Matrix : " + Session["SPDS_AuthorizationMatrix_CUSTOMER_NAME"].ToString() + " / " + Session["SPDS_AuthorizationMatrix_INSTRUMENT_NAME"].ToString();
            ((Label)FormView1.FindControl("Label_HEAD")).Text = " Authorization Matrix : " + Session["SPDS_AuthorizationMatrix_CUSTOMER_NAME"].ToString();
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
        BTN_CustomerIDSerach_INSERT.Attributes.Add("style", "visibility:hidden;");
        BTN_CustomerIDSerach_EDIT.Attributes.Add("style", "visibility:hidden;");
        BTN_InstrumentIDSearch_EDIT.Attributes.Add("style", "visibility:hidden;");
        BTN_InstrumentIDSearch_INSERT.Attributes.Add("style", "visibility:hidden;");
        BTN_MakerSignatoryIDSearch_EDIT.Attributes.Add("style", "visibility:hidden;");
        BTN_MakerSignatoryIDSearch_INSERT.Attributes.Add("style", "visibility:hidden;");
        BTN_CheckerSignatoryIDSearch_EDIT.Attributes.Add("style", "visibility:hidden;");
        BTN_CheckerSignatoryIDSearch_INSERT.Attributes.Add("style", "visibility:hidden;");
        BTN_CategoryIDSearch_EDIT.Attributes.Add("style", "visibility:hidden;");
        BTN_CategoryIDSearch_INSERT.Attributes.Add("style", "visibility:hidden;");

    }
    protected void FormView1_PageIndexChanging(object sender, FormViewPageEventArgs e) { }
    private void BackPage()
    {
        Session["SPDS_AuthorizationMatrix_CUSTOMER_NAME"] = "0";
        Session["SPDS_AuthorizationMatrix_INSTRUMENT_NAME"] = "0";
        Session["SPDS_AuthorizationMatrix_MAKE_SIGNATORY_NAME"] = "0";
        Session["SPDS_AuthorizationMatrix_CHECKER_SIGNATORY_NAME"] = "0";
        Session["SPDS_AuthorizationMatrix_CATEGORY_NAME"] = "0";
        Response.Redirect("../AuthorizationMatrix/frmSPDS_AuthorizationMatrix.aspx" + "?" + "s1=" + Request.QueryString[0].ToString());
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
            DS = L.SP_AuthorizeRecord("SPDS_AuthorizationMatrix", Session["U_NAME"].ToString(), DateTime.Now.ToString("MM-dd-yyyy"), Session["SPDS_AuthorizationMatrix_ID"].ToString());
            Response.Redirect("../AuthorizationMatrix/frmSPDS_AuthorizationMatrixSPC.aspx" + "?" + "s1=" + Request.QueryString[0].ToString());
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
                DS = L.SP_AuthorizationMatrix_DP
                    (((TextBox)FormView1.FindControl("TXT_CUSTOMER_ID_EDIT")).Text,
                    ///((TextBox)FormView1.FindControl("TXT_INSTRUMENT_ID_EDIT")).Text,
                    "123",
                    ((TextBox)FormView1.FindControl("TXT_MAKE_SIGNATORY_ID_EDIT")).Text,
                    ((TextBox)FormView1.FindControl("TXT_CHECKER_SIGNATORY_ID_EDIT")).Text,
                    ((TextBox)FormView1.FindControl("TXT_CATEGORY_ID_EDIT")).Text,
                    Session["SPDS_AuthorizationMatrix_ID"].ToString());
                if (DS.Tables[0].Rows.Count > 0)
                {
                    ((Label)FormView1.FindControl("lblDuplicate_EDIT")).Text = "Duplicate Record";
                }
                else
                {
                    if (DS.Tables[0].Rows.Count <= 0)
                    {

                        P_SPDS_AuthorizationMatrix.RecordInputStart();
                        P_SPDS_AuthorizationMatrix.Get_ID = Session["SPDS_AuthorizationMatrix_ID"].ToString();
                        P_SPDS_AuthorizationMatrix.Get_CUSTOMER_ID = ((TextBox)FormView1.FindControl("TXT_CUSTOMER_ID_EDIT")).Text;
                        P_SPDS_AuthorizationMatrix.Get_INSTRUMENT_ID = "123";///((TextBox)FormView1.FindControl("TXT_INSTRUMENT_ID_EDIT")).Text;
                        P_SPDS_AuthorizationMatrix.Get_MAKE_SIGNATORY_ID = ((TextBox)FormView1.FindControl("TXT_MAKE_SIGNATORY_ID_EDIT")).Text;
                        P_SPDS_AuthorizationMatrix.Get_CHECKER_SIGNATORY_ID = ((TextBox)FormView1.FindControl("TXT_CHECKER_SIGNATORY_ID_EDIT")).Text;
                        P_SPDS_AuthorizationMatrix.Get_CATEGORY_ID = ((TextBox)FormView1.FindControl("TXT_CATEGORY_ID_EDIT")).Text;
                        P_SPDS_AuthorizationMatrix.Get_A_UserID = Session["U_NAME"].ToString();
                        P_SPDS_AuthorizationMatrix.Get_A_DateTime = DateTime.Now.ToString("dd-MMM-yyyy").ToString();
                        P_SPDS_AuthorizationMatrix.Get_E_UserID = Session["U_NAME"].ToString();//((TextBox)FormView1.FindControl("TXT_E_UserID_EDIT")).Text;
                        P_SPDS_AuthorizationMatrix.Get_E_DateTime = DateTime.Now.ToString("dd-MMM-yyyy").ToString();
                        P_SPDS_AuthorizationMatrix.RecordInputCommit();
                        P_SPDS_AuthorizationMatrix.EditNewGroup();
                        BackPage();
                    }
                    else
                    {
                        ((TextBox)FormView1.FindControl("TXT_CUSTOMER_ID_EDIT")).Text = "";
                        ((TextBox)FormView1.FindControl("TXT_INSTRUMENT_ID_EDIT")).Text = "";
                        ((TextBox)FormView1.FindControl("TXT_MAKE_SIGNATORY_ID_EDIT")).Text = "";
                        ((TextBox)FormView1.FindControl("TXT_CHECKER_SIGNATORY_ID_EDIT")).Text = "";
                        ((TextBox)FormView1.FindControl("TXT_CATEGORY_ID_EDIT")).Text = "";
                        ((RequiredFieldValidator)FormView1.FindControl("REQ_CUSTOMER_ID_EDIT")).Validate();
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
                DS = L.SP_AuthorizationMatrix_DP
                    
                    (Convert.ToString(CustomerID),Convert.ToString(InstrumentID),Convert.ToString(MakerSignatoryID),
                     Convert.ToString(CheckerSignatoryID),Convert.ToString(CategoryID),"0");

                if (DS.Tables[0].Rows.Count > 0)
                {
                    ((Label)FormView1.FindControl("lblDuplicate_INSERT")).Text = "Duplicate Record";
                }
                else
                {
                    if (DS.Tables[0].Rows.Count <= 0)
                    {

                        P_SPDS_AuthorizationMatrix.RecordInputStart();
                        P_SPDS_AuthorizationMatrix.Get_ID = "0";
                        P_SPDS_AuthorizationMatrix.Get_CUSTOMER_ID = CustomerID;
                        P_SPDS_AuthorizationMatrix.Get_INSTRUMENT_ID = InstrumentID;
                        P_SPDS_AuthorizationMatrix.Get_MAKE_SIGNATORY_ID = MakerSignatoryID;
                        P_SPDS_AuthorizationMatrix.Get_CHECKER_SIGNATORY_ID = CheckerSignatoryID;
                        P_SPDS_AuthorizationMatrix.Get_CATEGORY_ID = CategoryID;
                        P_SPDS_AuthorizationMatrix.Get_A_UserID = Session["U_NAME"].ToString();//((TextBox)FormView1.FindControl("TXT_A_UserID_INSERT")).Text;
                        P_SPDS_AuthorizationMatrix.Get_A_DateTime = DateTime.Now.ToString("dd-MMM-yyyy").ToString();
                        P_SPDS_AuthorizationMatrix.Get_E_UserID = Session["U_NAME"].ToString();
                        P_SPDS_AuthorizationMatrix.Get_E_DateTime = DateTime.Now.ToString("dd-MMM-yyyy").ToString();
                        P_SPDS_AuthorizationMatrix.RecordInputCommit();
                        P_SPDS_AuthorizationMatrix.AddNewGroup();
                        BackPage();
                    }
                    else
                    {
                        ((TextBox)FormView1.FindControl("TXT_CUSTOMER_ID_INSERT")).Text = "";
                        ((TextBox)FormView1.FindControl("TXT_INSTRUMENT_ID_INSERT")).Text = "";
                        ((TextBox)FormView1.FindControl("TXT_MAKE_SIGNATORY_ID_INSERT")).Text = "";
                        ((TextBox)FormView1.FindControl("TXT_CHECKER_SIGNATORY_ID_INSERT")).Text = "";
                        ((TextBox)FormView1.FindControl("TXT_CATEGORY_ID_INSERT")).Text = "";
                        ((RequiredFieldValidator)FormView1.FindControl("REQ_CUSTOMER_ID_INSERT")).Validate();
                    }
                }
            }
        }
        else if (e.Item.ToolTip == "Cancel")
        { BackPage(); }
    }
    protected void BTN_Customer_ID_INSERT_Click(object sender, ImageClickEventArgs e)
    {
        if (Session["LOV_ID"] != "")
        {
            CustomerID = Session["LOV_ID"].ToString();
            Session["SPDS_ProductArrangement_CustomerID"] = Session["LOV_ID"].ToString();
            ((TextBox)FormView1.FindControl("TXT_CUSTOMER_ID_INSERT")).Text = Session["LOV_CODE"].ToString();
            ((TextBox)FormView1.FindControl("TXT_CustomerName_INSERT")).Text = Session["LOV_DESCRIPTION"].ToString();

            ((TextBox)FormView1.FindControl("TXT_INSTRUMENT_ID_INSERT")).Text = "";
            ((TextBox)FormView1.FindControl("TXT_InstrumentName_INSERT")).Text = "";

            Session["LOV_ID"] = "";
            Session["LOV_CODE"] = "";
            Session["LOV_DESCRIPTION"] = "";
        }
    }
    protected void BTN_Instrument_ID_INSERT_Click(object sender, ImageClickEventArgs e)
    {
        if (Session["LOV_ID"] != "")
        {
            Session["LOV_ID"] = "123";
            InstrumentID = Session["LOV_ID"].ToString();
            ((TextBox)FormView1.FindControl("TXT_INSTRUMENT_ID_INSERT")).Text = Session["LOV_ID"].ToString();
            ((TextBox)FormView1.FindControl("TXT_InstrumentName_INSERT")).Text = Session["LOV_DESCRIPTION"].ToString();


           // Session["LOV_ID"] = "";
           // Session["LOV_CODE"] = "";
          //  Session["LOV_DESCRIPTION"] = "";
        }
    }

    protected void BTN_MakerSignatory_ID_INSERT_Click(object sender, ImageClickEventArgs e)
    {
        if (Session["LOV_CODE"] != "")
        {
            MakerSignatoryID = Session["LOV_CODE"].ToString();
            ((TextBox)FormView1.FindControl("TXT_MAKE_SIGNATORY_ID_INSERT")).Text = Session["LOV_CODE"].ToString();
            ((TextBox)FormView1.FindControl("TXT_MakerSignatoryName_INSERT")).Text = Session["LOV_DESCRIPTION"].ToString();
            Session["LOV_ID"] = "";
            Session["LOV_CODE"] = "";
            Session["LOV_DESCRIPTION"] = "";
        }
    }

    protected void BTN_CheckerSignatory_ID_INSERT_Click(object sender, ImageClickEventArgs e)
    {
        if (Session["LOV_CODE"] != "")
        {
            CheckerSignatoryID = Session["LOV_CODE"].ToString();
            ((TextBox)FormView1.FindControl("TXT_CHECKER_SIGNATORY_ID_INSERT")).Text = Session["LOV_CODE"].ToString();
            ((TextBox)FormView1.FindControl("TXT_CheckerSignatoryName_INSERT")).Text = Session["LOV_DESCRIPTION"].ToString();
            
            Session["LOV_ID"] = "";
            Session["LOV_CODE"] = "";
            Session["LOV_DESCRIPTION"] = "";
        }
    }

    protected void BTN_Category_ID_INSERT_Click(object sender, ImageClickEventArgs e)
    {
        if (Session["LOV_ID"] != "")
        {
            CategoryID = Session["LOV_ID"].ToString();
            ((TextBox)FormView1.FindControl("TXT_CATEGORY_ID_INSERT")).Text = Session["LOV_ID"].ToString();
            ((TextBox)FormView1.FindControl("TXT_CATEGORY_Name_INSERT")).Text = Session["LOV_DESCRIPTION"].ToString();

            DataSet ds = new DataSet();
            ds = lov.Get_SPDS_SignatoryCategorySetup_SPC(CategoryID);
            ((TextBox)FormView1.FindControl("TXT_FROMLIMIT_INSERT")).Text = ds.Tables[0].Rows[0]["FROM_LIMIT"].ToString();
            ((TextBox)FormView1.FindControl("TXT_TOLIMIT_INSERT")).Text = ds.Tables[0].Rows[0]["TO_LIMIT"].ToString();
        }
    }

    protected void BTN_Customer_ID_EDIT_Click(object sender, ImageClickEventArgs e)
    {
        if (Session["LOV_ID"] != "")
        {
            ((TextBox)FormView1.FindControl("TXT_CUSTOMER_ID_EDIT")).Text = Session["LOV_ID"].ToString();
            Session["SPDS_ProductArrangement_CustomerID"] = Session["LOV_ID"].ToString();
            ((TextBox)FormView1.FindControl("TXT_CUSTOMER_CODE_EDIT")).Text = Session["LOV_CODE"].ToString();
            ((TextBox)FormView1.FindControl("TXT_CustomerName_EDIT")).Text = Session["LOV_DESCRIPTION"].ToString();

            ((TextBox)FormView1.FindControl("TXT_INSTRUMENT_ID_EDIT")).Text = "";
            ((TextBox)FormView1.FindControl("TXT_InstrumentName_EDIT")).Text = "";

            Session["LOV_ID"] = "";
            Session["LOV_CODE"] = "";
            Session["LOV_DESCRIPTION"] = "";
        }
    }

    protected void BTN_Instrument_ID_EDIT_Click(object sender, ImageClickEventArgs e)
    {
        if (Session["LOV_ID"] != "")
        {
            InstrumentID = Session["LOV_ID"].ToString();
            ((TextBox)FormView1.FindControl("TXT_INSTRUMENT_ID_EDIT")).Text = Session["LOV_ID"].ToString();
            ((TextBox)FormView1.FindControl("TXT_InstrumentName_EDIT")).Text = Session["LOV_DESCRIPTION"].ToString();


            Session["LOV_ID"] = "";
            Session["LOV_CODE"] = "";
            Session["LOV_DESCRIPTION"] = "";
        }
    }

    protected void BTN_MakerSignatory_ID_EDIT_Click(object sender, ImageClickEventArgs e)
    {
        if (Session["LOV_CODE"] != "")
        {
            MakerSignatoryID = Session["LOV_CODE"].ToString();
            ((TextBox)FormView1.FindControl("TXT_MAKE_SIGNATORY_ID_EDIT")).Text = Session["LOV_CODE"].ToString();
            ((TextBox)FormView1.FindControl("TXT_MakerSignatoryName_EDIT")).Text = Session["LOV_DESCRIPTION"].ToString();


            Session["LOV_ID"] = "";
            Session["LOV_CODE"] = "";
            Session["LOV_DESCRIPTION"] = "";
        }
    }

    protected void BTN_CheckerSignatory_ID_EDIT_Click(object sender, ImageClickEventArgs e)
    {
        if (Session["LOV_CODE"] != "")
        {
            CheckerSignatoryID = Session["LOV_CODE"].ToString();
            ((TextBox)FormView1.FindControl("TXT_CHECKER_SIGNATORY_ID_EDIT")).Text = Session["LOV_CODE"].ToString();
            ((TextBox)FormView1.FindControl("TXT_CheckerSignatoryName_EDIT")).Text = Session["LOV_DESCRIPTION"].ToString();


            Session["LOV_ID"] = "";
            Session["LOV_CODE"] = "";
            Session["LOV_DESCRIPTION"] = "";
        }
    }

    protected void BTN_Category_ID_EDIT_Click(object sender, ImageClickEventArgs e)
    {
        
        if (Session["LOV_ID"] != "")
        {
            CategoryID = Session["LOV_ID"].ToString();
            ((TextBox)FormView1.FindControl("TXT_CATEGORY_ID_EDIT")).Text = Session["LOV_ID"].ToString();
            ((TextBox)FormView1.FindControl("TXT_CATEGORY_Name_EDIT")).Text = Session["LOV_DESCRIPTION"].ToString();
            
            DataSet ds =  new DataSet();
            ds = lov.Get_SPDS_SignatoryCategorySetup_SPC(CategoryID);
            ((TextBox)FormView1.FindControl("TXT_FROMLIMIT_EDIT")).Text = ds.Tables[0].Rows[0]["FROM_LIMIT"].ToString();
            ((TextBox)FormView1.FindControl("TXT_TOLIMIT_EDIT")).Text = ds.Tables[0].Rows[0]["TO_LIMIT"].ToString();
            
        }
    }

    protected void BTN_CustomerIDSerach_EDIT_Click(object sender, EventArgs e)
    {
        if (((TextBox)FormView1.FindControl("TXT_CUSTOMER_CODE_EDIT")).Text.Trim().Length > 0 || ((TextBox)FormView1.FindControl("TXT_CUSTOMER_CODE_EDIT")).Text != "")
        {
            DataSet ds = new DataSet();
            ds = lov.Get_RPS_SP_Customer_GetByCode(((TextBox)FormView1.FindControl("TXT_CUSTOMER_CODE_EDIT")).Text); /* set lov of Province */
            if (ds.Tables[0].Rows.Count > 0)
            {
                Session["SPDS_ProductArrangement_CustomerID"] = ds.Tables[0].Rows[0]["ID"].ToString();
                ((TextBox)FormView1.FindControl("TXT_CUSTOMER_ID_EDIT")).Text = ds.Tables[0].Rows[0]["ID"].ToString();
                ((TextBox)FormView1.FindControl("TXT_CUSTOMER_CODE_EDIT")).Text = ds.Tables[0].Rows[0]["BankCode"].ToString();
                ((TextBox)FormView1.FindControl("TXT_CustomerName_EDIT")).Text = ds.Tables[0].Rows[0]["BankName"].ToString();
            }
            else
            {
                ((TextBox)FormView1.FindControl("TXT_CUSTOMER_ID_EDIT")).Text = null;
                ((TextBox)FormView1.FindControl("TXT_CUSTOMER_CODE_EDIT")).Text = null;
                ((TextBox)FormView1.FindControl("TXT_CustomerName_EDIT")).Text = null;
                ((RequiredFieldValidator)FormView1.FindControl("REQ_CUSTOMER_ID_EDIT")).Validate();
                ((TextBox)FormView1.FindControl("TXT_CUSTOMER_ID_EDIT")).Focus();
            }
        }
        else
        {
            ((TextBox)FormView1.FindControl("TXT_CUSTOMER_ID_EDIT")).Text = null;
            ((TextBox)FormView1.FindControl("TXT_CUSTOMER_CODE_EDIT")).Text = null;
            ((TextBox)FormView1.FindControl("TXT_CustomerName_EDIT")).Text = null;
            ((TextBox)FormView1.FindControl("TXT_CUSTOMER_CODE_EDIT")).Focus();

            ((TextBox)FormView1.FindControl("TXT_CUSTOMER_CODE_EDIT")).Focus();
        }
    }

    protected void BTN_CustomerIDSerach_INSERT_Click(object sender, EventArgs e)
    {
        if (((TextBox)FormView1.FindControl("TXT_CUSTOMER_ID_INSERT")).Text.Trim().Length > 0 || ((TextBox)FormView1.FindControl("TXT_CUSTOMER_ID_INSERT")).Text != "")
        {
            DataSet ds = new DataSet();
            ds = lov.Get_RPS_SP_Customer_GetByCode(((TextBox)FormView1.FindControl("TXT_CUSTOMER_ID_INSERT")).Text); /* set lov of Province */
            if (ds.Tables[0].Rows.Count > 0)
            {
                Session["SPDS_ProductArrangement_CustomerID"] = ds.Tables[0].Rows[0]["ID"].ToString();
                CustomerID = ds.Tables[0].Rows[0]["ID"].ToString();
                ((TextBox)FormView1.FindControl("TXT_CUSTOMER_ID_INSERT")).Text = ds.Tables[0].Rows[0]["BankCode"].ToString();
                ((TextBox)FormView1.FindControl("TXT_CustomerName_INSERT")).Text = ds.Tables[0].Rows[0]["BankName"].ToString();
            }
            else
            {
                ((TextBox)FormView1.FindControl("TXT_CUSTOMER_ID_INSERT")).Text = null;
                ((TextBox)FormView1.FindControl("TXT_CustomerName_INSERT")).Text = null;
                ((TextBox)FormView1.FindControl("TXT_CUSTOMER_ID_INSERT")).Focus();
                ((RequiredFieldValidator)FormView1.FindControl("REQ_CUSTOMER_ID_INSERT")).Validate();
                ((TextBox)FormView1.FindControl("TXT_CUSTOMER_ID_INSERT")).Focus();
            }
        }
        else
        {
            ((TextBox)FormView1.FindControl("TXT_CUSTOMER_ID_INSERT")).Text = null;
            ((TextBox)FormView1.FindControl("TXT_CustomerName_INSERT")).Text = null;
            ((TextBox)FormView1.FindControl("TXT_CUSTOMER_ID_INSERT")).Focus();
        }
    }

    protected void BTN_InstrumentIDSearch_INSERT_Click(object sender, EventArgs e)
    {
        if (((TextBox)FormView1.FindControl("TXT_INSTRUMENT_ID_INSERT")).Text.Trim().Length > 0 || ((TextBox)FormView1.FindControl("TXT_INSTRUMENT_ID_INSERT")).Text != "")
        {
            DataSet ds = new DataSet();
            ds = lov.Get_SP_SPDS_InstrumentSetup_GetByCode(Convert.ToInt32(((TextBox)FormView1.FindControl("TXT_INSTRUMENT_ID_INSERT")).Text)); /* set lov of Province */
            if (ds.Tables[0].Rows.Count > 0)
            {
                InstrumentID = ds.Tables[0].Rows[0]["ID"].ToString();
                ((TextBox)FormView1.FindControl("TXT_INSTRUMENT_ID_INSERT")).Text = ds.Tables[0].Rows[0]["ID"].ToString();
                ((TextBox)FormView1.FindControl("TXT_InstrumentName_INSERT")).Text = ds.Tables[0].Rows[0]["INSTRUMENT_NAME"].ToString();
            }
            else
            {
                ((TextBox)FormView1.FindControl("TXT_INSTRUMENT_ID_INSERT")).Text = null;
                ((TextBox)FormView1.FindControl("TXT_InstrumentName_INSERT")).Text = null;
                ((TextBox)FormView1.FindControl("TXT_INSTRUMENT_ID_INSERT")).Focus();
                ((RequiredFieldValidator)FormView1.FindControl("REQ_INSTRUMENT_ID_INSERT")).Validate();
                ((TextBox)FormView1.FindControl("TXT_INSTRUMENT_ID_INSERT")).Focus();
            }
        }
        else
        {
            ((TextBox)FormView1.FindControl("TXT_INSTRUMENT_ID_INSERT")).Text = null;
            ((TextBox)FormView1.FindControl("TXT_InstrumentName_INSERT")).Text = null;
            ((TextBox)FormView1.FindControl("TXT_INSTRUMENT_ID_INSERT")).Focus();
        }
    }

    protected void FormView1_DataBound(object sender, EventArgs e)
    {
        if (FormView1.CurrentMode.ToString() == "Edit")
        {
            ((TextBox)FormView1.FindControl("TXT_CUSTOMER_ID_EDIT")).Attributes.Add("style", "visibility:hidden;");
            ((TextBox)FormView1.FindControl("TXT_CUSTOMER_CODE_EDIT")).Attributes.Add("onchange", "return SearchCustomerIDEDIT();");
            ((TextBox)FormView1.FindControl("TXT_INSTRUMENT_ID_EDIT")).Attributes.Add("onchange", "return  SearchInstrumentID_EDIT();");
            ((TextBox)FormView1.FindControl("TXT_MAKE_SIGNATORY_ID_EDIT")).Attributes.Add("onchange", "return   SearchMakerID_EDIT();");
            ((TextBox)FormView1.FindControl("TXT_CHECKER_SIGNATORY_ID_EDIT")).Attributes.Add("onchange", "return  SearchCheckerID_EDIT();");
            ((TextBox)FormView1.FindControl("TXT_CATEGORY_ID_EDIT")).Attributes.Add("onchange", "return  SearchCategoryID_EDIT();");
        }
        else if (FormView1.CurrentMode.ToString() == "Insert")
        {
            ((TextBox)FormView1.FindControl("TXT_CUSTOMER_ID_INSERT")).Attributes.Add("onchange", "return SearchCustomerIDINSERT();");
            ((TextBox)FormView1.FindControl("TXT_INSTRUMENT_ID_INSERT")).Attributes.Add("onchange", "return  SearchInstrumentID_INSERT();");
            ((TextBox)FormView1.FindControl("TXT_MAKE_SIGNATORY_ID_INSERT")).Attributes.Add("onchange", "return   SearchMakerID_INSERT();");
            ((TextBox)FormView1.FindControl("TXT_CHECKER_SIGNATORY_ID_INSERT")).Attributes.Add("onchange", "return  SearchCheckerID_INSERT();");
            ((TextBox)FormView1.FindControl("TXT_CATEGORY_ID_INSERT")).Attributes.Add("onchange", "return  SearchCategoryID_INSERT();");
        }
    }

    protected void BTN_InstrumentIDSearch_EDIT_Click(object sender, EventArgs e)
    {
        if (((TextBox)FormView1.FindControl("TXT_INSTRUMENT_ID_EDIT")).Text.Trim().Length > 0 || ((TextBox)FormView1.FindControl("TXT_INSTRUMENT_ID_EDIT")).Text != "")
        {
            DataSet ds = new DataSet();
            ds = lov.Get_SP_SPDS_InstrumentSetup_GetByCode(Convert.ToInt32(((TextBox)FormView1.FindControl("TXT_INSTRUMENT_ID_EDIT")).Text));
            if (ds.Tables[0].Rows.Count > 0)
            {
                InstrumentID = ds.Tables[0].Rows[0]["ID"].ToString();
                ((TextBox)FormView1.FindControl("TXT_INSTRUMENT_ID_EDIT")).Text = ds.Tables[0].Rows[0]["ID"].ToString();
                ((TextBox)FormView1.FindControl("TXT_InstrumentName_EDIT")).Text = ds.Tables[0].Rows[0]["INSTRUMENT_NAME"].ToString();
            }
            else
            {
                ((TextBox)FormView1.FindControl("TXT_INSTRUMENT_ID_EDIT")).Text = null;
                ((TextBox)FormView1.FindControl("TXT_InstrumentName_EDIT")).Text = null;
                ((TextBox)FormView1.FindControl("TXT_INSTRUMENT_ID_EDIT")).Focus();
                ((RequiredFieldValidator)FormView1.FindControl("REQ_INSTRUMENT_ID_EDIT")).Validate();
                ((TextBox)FormView1.FindControl("TXT_INSTRUMENT_ID_EDIT")).Focus();
            }
        }
        else
        {
            ((TextBox)FormView1.FindControl("TXT_INSTRUMENT_ID_EDIT")).Text = null;
            ((TextBox)FormView1.FindControl("TXT_InstrumentName_EDIT")).Text = null;
            ((TextBox)FormView1.FindControl("TXT_INSTRUMENT_ID_EDIT")).Focus();
        }
    }

    protected void BTN_MakerSignatoryIDSearch_INSERT_Click(object sender, EventArgs e)
    {
        if (((TextBox)FormView1.FindControl("TXT_MAKE_SIGNATORY_ID_INSERT")).Text.Trim().Length > 0 || ((TextBox)FormView1.FindControl("TXT_MAKE_SIGNATORY_ID_INSERT")).Text != "")
        {
            DataSet ds = new DataSet();
            ds = lov.Get_SPDS_SignatorySetup_SPC(((TextBox)FormView1.FindControl("TXT_MAKE_SIGNATORY_ID_INSERT")).Text);
            if (ds.Tables[0].Rows.Count > 0)
            {
                MakerSignatoryID = ds.Tables[0].Rows[0]["ID"].ToString();
                ((TextBox)FormView1.FindControl("TXT_MAKE_SIGNATORY_ID_INSERT")).Text = ds.Tables[0].Rows[0]["ID"].ToString();
                ((TextBox)FormView1.FindControl("TXT_MakerSignatoryName_INSERT")).Text = ds.Tables[0].Rows[0]["SIGNATORY_NAME"].ToString();
            }
            else
            {
                ((TextBox)FormView1.FindControl("TXT_MAKE_SIGNATORY_ID_INSERT")).Text = null;
                ((TextBox)FormView1.FindControl("TXT_MakerSignatoryName_INSERT")).Text = null;
                ((TextBox)FormView1.FindControl("TXT_MAKE_SIGNATORY_ID_INSERT")).Focus();
                ((RequiredFieldValidator)FormView1.FindControl("REQ_MAKE_SIGNATORY_ID_INSERT")).Validate();
                ((TextBox)FormView1.FindControl("TXT_MAKE_SIGNATORY_ID_INSERT")).Focus();
            }
        }
        else
        {
            ((TextBox)FormView1.FindControl("TXT_MAKE_SIGNATORY_ID_INSERT")).Text = null;
            ((TextBox)FormView1.FindControl("TXT_MakerSignatoryName_INSERT")).Text = null;
            ((TextBox)FormView1.FindControl("TXT_MAKE_SIGNATORY_ID_INSERT")).Focus();
        }
    }

    protected void BTN_CheckerSignatoryIDSearch_INSERT_Click(object sender, EventArgs e)
    {
        if (((TextBox)FormView1.FindControl("TXT_CHECKER_SIGNATORY_ID_INSERT")).Text.Trim().Length > 0 || ((TextBox)FormView1.FindControl("TXT_CHECKER_SIGNATORY_ID_INSERT")).Text != "")
        {
            DataSet ds = new DataSet();
            ds = lov.Get_SPDS_SignatorySetup_SPC(((TextBox)FormView1.FindControl("TXT_CHECKER_SIGNATORY_ID_INSERT")).Text);
            if (ds.Tables[0].Rows.Count > 0)
            {
                CheckerSignatoryID = ds.Tables[0].Rows[0]["ID"].ToString();
                ((TextBox)FormView1.FindControl("TXT_CHECKER_SIGNATORY_ID_INSERT")).Text = ds.Tables[0].Rows[0]["ID"].ToString();
                ((TextBox)FormView1.FindControl("TXT_CheckerSignatoryName_INSERT")).Text = ds.Tables[0].Rows[0]["SIGNATORY_NAME"].ToString();
            }
            else
            {
                ((TextBox)FormView1.FindControl("TXT_CHECKER_SIGNATORY_ID_INSERT")).Text = null;
                ((TextBox)FormView1.FindControl("TXT_CheckerSignatoryName_INSERT")).Text = null;
                ((TextBox)FormView1.FindControl("TXT_CHECKER_SIGNATORY_ID_INSERT")).Focus();
                ((RequiredFieldValidator)FormView1.FindControl("REQ_CHECKER_SIGNATORY_ID_INSERT")).Validate();
                ((TextBox)FormView1.FindControl("TXT_CHECKER_SIGNATORY_ID_INSERT")).Focus();
            }
        }
        else
        {
            ((TextBox)FormView1.FindControl("TXT_CHECKER_SIGNATORY_ID_INSERT")).Text = null;
            ((TextBox)FormView1.FindControl("TXT_CheckerSignatoryName_INSERT")).Text = null;
            ((TextBox)FormView1.FindControl("TXT_CHECKER_SIGNATORY_ID_INSERT")).Focus();
        }
    }

    protected void BTN_CheckerSignatoryIDSearch_EDIT_Click(object sender, EventArgs e)
    {
        if (((TextBox)FormView1.FindControl("TXT_CHECKER_SIGNATORY_ID_EDIT")).Text.Trim().Length > 0 || ((TextBox)FormView1.FindControl("TXT_CHECKER_SIGNATORY_ID_EDIT")).Text != "")
        {
            DataSet ds = new DataSet();
            ds = lov.Get_SPDS_SignatorySetup_SPC(((TextBox)FormView1.FindControl("TXT_CHECKER_SIGNATORY_ID_EDIT")).Text);
            if (ds.Tables[0].Rows.Count > 0)
            {
                CheckerSignatoryID = ds.Tables[0].Rows[0]["ID"].ToString();
                ((TextBox)FormView1.FindControl("TXT_CHECKER_SIGNATORY_ID_EDIT")).Text = ds.Tables[0].Rows[0]["ID"].ToString();
                ((TextBox)FormView1.FindControl("TXT_CheckerSignatoryName_EDIT")).Text = ds.Tables[0].Rows[0]["SIGNATORY_NAME"].ToString();
            }
            else
            {
                ((TextBox)FormView1.FindControl("TXT_CHECKER_SIGNATORY_ID_EDIT")).Text = null;
                ((TextBox)FormView1.FindControl("TXT_CheckerSignatoryName_EDIT")).Text = null;
                ((TextBox)FormView1.FindControl("TXT_CHECKER_SIGNATORY_ID_EDIT")).Focus();
                ((RequiredFieldValidator)FormView1.FindControl("REQ_CHECKER_SIGNATORY_ID_EDIT")).Validate();
                ((TextBox)FormView1.FindControl("TXT_CHECKER_SIGNATORY_ID_EDIT")).Focus();
            }
        }
        else
        {
            ((TextBox)FormView1.FindControl("TXT_CHECKER_SIGNATORY_ID_EDIT")).Text = null;
            ((TextBox)FormView1.FindControl("TXT_CheckerSignatoryName_EDIT")).Text = null;
            ((TextBox)FormView1.FindControl("TXT_CHECKER_SIGNATORY_ID_EDIT")).Focus();
        }
    }

    protected void BTN_CategoryIDSearch_INSERT_Click(object sender, EventArgs e)
    {
        if (((TextBox)FormView1.FindControl("TXT_CATEGORY_ID_INSERT")).Text.Trim().Length > 0 || ((TextBox)FormView1.FindControl("TXT_CATEGORY_ID_INSERT")).Text != "")
        {
            DataSet ds = new DataSet();
            ds = lov.Get_SPDS_SignatoryCategorySetup_SPC(((TextBox)FormView1.FindControl("TXT_CATEGORY_ID_INSERT")).Text);

            if (ds.Tables[0].Rows.Count > 0)
            {
                CategoryID = ds.Tables[0].Rows[0]["ID"].ToString();
                ((TextBox)FormView1.FindControl("TXT_CATEGORY_ID_INSERT")).Text = ds.Tables[0].Rows[0]["ID"].ToString();
                ((TextBox)FormView1.FindControl("TXT_CATEGORY_Name_INSERT")).Text = ds.Tables[0].Rows[0]["CATEGORY_NAME"].ToString();

                ((TextBox)FormView1.FindControl("TXT_FROMLIMIT_INSERT")).Text = ds.Tables[0].Rows[0]["FROM_LIMIT"].ToString();
                ((TextBox)FormView1.FindControl("TXT_TOLIMIT_INSERT")).Text = ds.Tables[0].Rows[0]["TO_LIMIT"].ToString();

            }
            else
            {
                ((TextBox)FormView1.FindControl("TXT_CATEGORY_ID_INSERT")).Text = null;
                ((TextBox)FormView1.FindControl("TXT_CATEGORY_Name_INSERT")).Text = null;
                ((TextBox)FormView1.FindControl("TXT_CATEGORY_ID_INSERT")).Focus();

                ((TextBox)FormView1.FindControl("TXT_FROMLIMIT_INSERT")).Text = null;
                ((TextBox)FormView1.FindControl("TXT_TOLIMIT_INSERT")).Text = null;
    

                ((RequiredFieldValidator)FormView1.FindControl("REQ_CATEGORY_ID_INSERT")).Validate();
                ((TextBox)FormView1.FindControl("TXT_CATEGORY_ID_INSERT")).Focus();
            }
        }
        else
        {
            ((TextBox)FormView1.FindControl("TXT_CATEGORY_ID_INSERT")).Text = null;
            ((TextBox)FormView1.FindControl("TXT_CATEGORY_Name_INSERT")).Text = null;
            ((TextBox)FormView1.FindControl("TXT_FROMLIMIT_INSERT")).Text = null;
            ((TextBox)FormView1.FindControl("TXT_TOLIMIT_INSERT")).Text = null;
    
            ((TextBox)FormView1.FindControl("TXT_CATEGORY_ID_INSERT")).Focus();
        }
    }

    protected void BTN_CategoryIDSearch_EDIT_Click(object sender, EventArgs e)
    {
        if (((TextBox)FormView1.FindControl("TXT_CATEGORY_ID_EDIT")).Text.Trim().Length > 0 || ((TextBox)FormView1.FindControl("TXT_CATEGORY_ID_EDIT")).Text != "")
        {
            DataSet ds = new DataSet();
            ds = lov.Get_SPDS_SignatoryCategorySetup_SPC(((TextBox)FormView1.FindControl("TXT_CATEGORY_ID_EDIT")).Text);
            if (ds.Tables[0].Rows.Count > 0)
            {
                CategoryID = ds.Tables[0].Rows[0]["ID"].ToString();
                ((TextBox)FormView1.FindControl("TXT_CATEGORY_ID_EDIT")).Text = ds.Tables[0].Rows[0]["ID"].ToString();
                ((TextBox)FormView1.FindControl("TXT_CATEGORY_Name_EDIT")).Text = ds.Tables[0].Rows[0]["CATEGORY_NAME"].ToString();

                ((TextBox)FormView1.FindControl("TXT_FROMLIMIT_EDIT")).Text = ds.Tables[0].Rows[0]["FROM_LIMIT"].ToString();
                ((TextBox)FormView1.FindControl("TXT_TOLIMIT_EDIT")).Text = ds.Tables[0].Rows[0]["TO_LIMIT"].ToString();
            }
            else
            {
                ((TextBox)FormView1.FindControl("TXT_CATEGORY_ID_EDIT")).Text = null;
                ((TextBox)FormView1.FindControl("TXT_CATEGORY_Name_EDIT")).Text = null;
                ((TextBox)FormView1.FindControl("TXT_FROMLIMIT_EDIT")).Text = null;
                ((TextBox)FormView1.FindControl("TXT_TOLIMIT_EDIT")).Text = null;
    
                ((TextBox)FormView1.FindControl("TXT_CATEGORY_ID_EDIT")).Focus();
                ((RequiredFieldValidator)FormView1.FindControl("REQ_CATEGORY_ID_EDIT")).Validate();
                ((TextBox)FormView1.FindControl("TXT_CATEGORY_ID_EDIT")).Focus();
            }
        }
        else
        {
            ((TextBox)FormView1.FindControl("TXT_CATEGORY_ID_EDIT")).Text = null;
            /// ((TextBox)FormView1.FindControl("TXT_CheckerSignatoryName_EDIT")).Text = null;
            /// 
            ((TextBox)FormView1.FindControl("TXT_FROMLIMIT_EDIT")).Text = null;
            ((TextBox)FormView1.FindControl("TXT_TOLIMIT_EDIT")).Text = null;
    
            ((TextBox)FormView1.FindControl("TXT_CATEGORY_ID_EDIT")).Focus();
        }
    }

    protected void BTN_MakerSignatoryIDSearch_EDIT_Click(object sender, EventArgs e)
    {
        if (((TextBox)FormView1.FindControl("TXT_MAKE_SIGNATORY_ID_EDIT")).Text.Trim().Length > 0 || ((TextBox)FormView1.FindControl("TXT_MAKE_SIGNATORY_ID_EDIT")).Text != "")
        {
            DataSet ds = new DataSet();
            ds = lov.Get_SPDS_SignatorySetup_SPC(((TextBox)FormView1.FindControl("TXT_MAKE_SIGNATORY_ID_EDIT")).Text);
            if (ds.Tables[0].Rows.Count > 0)
            {
                MakerSignatoryID = ds.Tables[0].Rows[0]["ID"].ToString();
                ((TextBox)FormView1.FindControl("TXT_MAKE_SIGNATORY_ID_EDIT")).Text = ds.Tables[0].Rows[0]["ID"].ToString();
                ((TextBox)FormView1.FindControl("TXT_MakerSignatoryName_EDIT")).Text = ds.Tables[0].Rows[0]["SIGNATORY_NAME"].ToString();
            }
            else
            {
                ((TextBox)FormView1.FindControl("TXT_MAKE_SIGNATORY_ID_EDIT")).Text = null;
                ((TextBox)FormView1.FindControl("TXT_MakerSignatoryName_EDIT")).Text = null;
                ((TextBox)FormView1.FindControl("TXT_MAKE_SIGNATORY_ID_EDIT")).Focus();
                ((RequiredFieldValidator)FormView1.FindControl("REQ_MAKE_SIGNATORY_ID_EDIT")).Validate();
                ((TextBox)FormView1.FindControl("TXT_MAKE_SIGNATORY_ID_EDIT")).Focus();
            }
        }
        else
        {
            ((TextBox)FormView1.FindControl("TXT_MAKE_SIGNATORY_ID_EDIT")).Text = null;
            ((TextBox)FormView1.FindControl("TXT_MakerSignatoryName_EDIT")).Text = null;
            ((TextBox)FormView1.FindControl("TXT_MAKE_SIGNATORY_ID_EDIT")).Focus();
        }
    }


}
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

public partial class frmCustomerBalanceSPC : System.Web.UI.Page
{
    FormViewRow D_TEMP;
    TextBox TXT;
    Label LL;
    string CustomerID = "";

    PROCESS_CMN_CUST_BAL CustBalObj = new PROCESS_CMN_CUST_BAL();

    protected void Page_Load(object sender, EventArgs e)
    {
        System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");
        if (!IsPostBack)
        {
            Session["QueryString"] = Request.QueryString[0].ToString();
        }
        if (Session["CustBalCode"].ToString() == "0")
        {
            FormView1.ChangeMode(FormViewMode.Insert);
            ((Label)FormView1.Row.FindControl("Label_HEAD")).Text = "Customer Funding";
        }
        else
        {
            ((Label)FormView1.FindControl("Label_HEAD")).Text = "Customer Funding : " + Session["CustBalCode"].ToString() + " / " + Session["CustBalName"].ToString();

            if (IsPostBack == false)
            {
                string RGS_SUPPORT;
                RGS_SUPPORT = Session["RGS"].ToString();
                if (RGS_SUPPORT.Substring(2, 1) == "0")
                {
                    if (FormView1.CurrentMode == FormViewMode.ReadOnly)
                    {
                        ((Button)FormView1.FindControl("BTN_EDIT")).Enabled = false; /*Edit*/
                        ((Button)FormView1.FindControl("CMD_AUTHORIZE")).Enabled = true; /*Authorize*/
                        ((Button)FormView1.FindControl("CMD_AUTHORIZE")).Visible = true; /*Authorize*/
                    }
                }
                else if (RGS_SUPPORT.Substring(2, 1) == "1")
                {
                    if (FormView1.CurrentMode == FormViewMode.ReadOnly)
                    { ((Button)FormView1.FindControl("BTN_EDIT")).Enabled = true; /*Edit*/}
                }
                //if (RGS_SUPPORT.Substring(2, 1) == "0")
                //{ ((EO.Web.ToolBar)FormView1.FindControl("DisplayToolBar")).Items[0].Disabled = true; /*Edit*/}
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
            }
        }
    }
    protected void FormView1_PageIndexChanging(object sender, FormViewPageEventArgs e)
    { }
    private void BackPage()
    {
        Session["CustBalCode"] = "0";
        Session["CustBalName"] = "";
        Session["CustBalDate"] = "";
        Session["CustBalAmount"] = "0";
        Response.Redirect("../CustomerSetup/frmCustomerBalance.aspx?s1=" + Session["QueryString"].ToString());
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
            DS = L.SP_AuthorizeRecord("RPS_CUSTOMER_BALANCE", Session["U_NAME"].ToString(), DateTime.Now.ToString("MM-dd-yyyy"), Session["CustBalCode"].ToString());
            Response.Redirect("../CustomerSetup/frmCustomerBalanceSPC.aspx?s1=" + Request.QueryString[0].ToString());
        }
    }
    protected void EditToolbar_ItemClick(object sender, EO.Web.ToolBarEventArgs e)
    {
        Page.Validate();
        if (e.Item.ToolTip == "Update")
        {
            if (Page.IsValid)
            {
                //LOV_COLLECTION L = new LOV_COLLECTION();
                //DataSet DS;
                //DS = L.SP_Currency_DP(((TextBox)FormView1.FindControl("txtBANKCODE_EDIT")).Text, "0");
                //if (DS.Tables[0].Rows.Count > 0)
                //{
                //    ((Label)FormView1.FindControl("lblDuplicate_EDIT")).Text = "Duplicate Record";
                //}
                //else
                //{
                //    if (DS.Tables[0].Rows.Count <= 0)
                //    {

                /* // Commit By ibrahim siad ali bhai
                CustBalObj.RecordInputStart();
                CustBalObj.setBankCode = ((TextBox)FormView1.FindControl("txtBANKCODE_EDIT")).Text;
                CustBalObj.setRateDate = ((TextBox)FormView1.FindControl("txtRATE_DATE_EDIT")).Text;
                CustBalObj.setBalAmount = ((TextBox)FormView1.FindControl("txtBAL_AMOUNT_EDIT")).Text;

                CustBalObj.setA_UserID = Session["U_NAME"].ToString();
                CustBalObj.setA_DateTime = DateTime.Now.ToString("dd-MMM-yyyy").ToString();
                CustBalObj.setE_UserID = Session["U_NAME"].ToString();
                CustBalObj.setE_DateTime = DateTime.Now.ToString("dd-MMM-yyyy").ToString();
                CustBalObj.RecordInputCommit();
                CustBalObj.EditNewGroup();
                BackPage();
                //    }
                //    else
                //    {
                ((TextBox)FormView1.FindControl("txtBANKCODE_EDIT")).Text = "";
                ((TextBox)FormView1.FindControl("txtRATE_DATE_EDIT")).Text = "";
                ((TextBox)FormView1.FindControl("txtBAL_AMOUNT_EDIT")).Text = "";
                //((RequiredFieldValidator)FormView1.FindControl("REQ_CurrencyCode_INSERT")).Validate();
                //    }
                // }*/
            }
        }
        else if (e.Item.ToolTip == "Cancel")
        { BackPage(); }
    }
    //protected void InsertToolbar_ItemClick(object sender, EO.Web.ToolBarEventArgs e)
    //{
    //    try
    //    {
    //        Page.Validate();
    //        if (e.Item.ToolTip == "Insert")
    //        {
    //            if (Page.IsValid)
    //            {
    //                if (Convert.ToDateTime(((TextBox)FormView1.FindControl("txtRATE_DATE_INSERT")).Text) <= Convert.ToDateTime(((TextBox)FormView1.FindControl("txtSysdate")).Text))
    //                {

    //                }
    //                else
    //                {
    //                    ((Label)FormView1.FindControl("lblDuplicate_INSERT")).Text = "Date must be equal or less then system date";
    //                    return;
    //                }
    //                CustBalObj.RecordInputStart();
    //                CustBalObj.setBankCode = ((DropDownList)FormView1.FindControl("ddlCompanyCode")).SelectedValue.ToString();//((TextBox)FormView1.FindControl("txtBANKCODE_INSERT")).Text;
    //                CustBalObj.setRateDate = Convert.ToDateTime(((TextBox)FormView1.FindControl("txtRATE_DATE_INSERT")).Text).ToString("dd-MMM-yyyy");
    //                CustBalObj.setBalAmount = ((TextBox)FormView1.FindControl("txtBAL_AMOUNT_INSERT")).Text;
    //                CustBalObj.setRefNo = ((TextBox)FormView1.FindControl("TXT_Ref_No_Insert")).Text;
    //                //CustBalObj.setA_UserID = "";
    //                //CustBalObj.setA_DateTime = "";
    //                CustBalObj.setE_UserID = Session["U_NAME"].ToString();
    //                CustBalObj.setE_DateTime = DateTime.Now.ToString("dd-MMM-yyyy").ToString();
    //                CustBalObj.RecordInputCommit();
    //                DataTable dt = new DataTable();
    //                dt = CustBalObj.AddNewGroup("");
    //                if (dt.Rows[0][1].ToString().StartsWith("0"))
    //                {
    //                    string[] arr = dt.Rows[0][1].ToString().Split(';');
    //                    string msg = arr[1];
    //                    ((Label)FormView1.FindControl("lblDuplicate_INSERT")).Text = msg;
    //                    return;
    //                }
    //                BackPage();
    //            }
    //        }
    //        else if (e.Item.ToolTip == "Cancel")
    //        {
    //            BackPage();
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        ((Label)FormView1.FindControl("lblDuplicate_INSERT")).Text = ex.Message;

    //    }
    //}
    protected void FormView1_DataBound(object sender, EventArgs e)
    {
        if (FormView1.CurrentMode.ToString() == "Insert")
        {
            //System.Diagnostics.Debugger.Break();
            ((TextBox)FormView1.FindControl("txtSysdate")).Text = DateTime.Now.ToString("dd-MM-yyyy").ToString();
            ((TextBox)FormView1.FindControl("txtSysdate")).Attributes.Add("style", "visibility:hidden;");
            ((TextBox)FormView1.FindControl("txtBANKCODE_INSERT")).Attributes.Add("readonly", "readonly");
            ((TextBox)FormView1.FindControl("TXT_Current_Bal_Amt_Insert")).Attributes.Add("readonly", "readonly");
            ((TextBox)FormView1.FindControl("txtRATE_DATE_INSERT")).Text = DateTime.Now.ToString("dd-MM-yyyy").ToString();
            ((TextBox)FormView1.FindControl("txtRATE_DATE_INSERT")).Attributes.Add("readonly", "readonly");
            ddlCompanyBind();
        }
    }
    protected void ddlCompanyCode_SelectedIndexChanged(object sender, EventArgs e)
    {
        Get_CompanyBal();
    }
    public void ddlCompanyBind()
    {
        LOV_COLLECTION lov = new LOV_COLLECTION();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        ds = lov.Get_Company_setup_lov("%", "%");
        if (ds.Tables[0].Rows.Count > 0)
        {
            ((DropDownList)FormView1.FindControl("ddlCompanyCode")).DataSource = ds;
            ((DropDownList)FormView1.FindControl("ddlCompanyCode")).DataValueField = "Company_Code";
            ((DropDownList)FormView1.FindControl("ddlCompanyCode")).DataTextField = "Company_Name";
            ((DropDownList)FormView1.FindControl("ddlCompanyCode")).DataBind();
            dt = ds.Tables[0];
            ViewState["COMPANYDATATABLE"] = dt;
            Get_CompanyBal();
        }
        else
        {
            DataTable dt1 = new DataTable();
            DataRow DR = null;
            dt1.Columns.Add("Company_Code");
            dt1.Columns.Add("Company_Name");
            DR = dt1.NewRow();
            DR[0] = "Company not found";
            DR[1] = "Company not found";
            dt1.Rows.Add(DR);

            ((DropDownList)FormView1.FindControl("ddlCompanyCode")).DataSource = dt1;
            ((DropDownList)FormView1.FindControl("ddlCompanyCode")).DataValueField = "Company_Code";
            ((DropDownList)FormView1.FindControl("ddlCompanyCode")).DataTextField = "Company_Name";
            ((DropDownList)FormView1.FindControl("ddlCompanyCode")).DataBind();
            ViewState["COMPANYDATATABLE"] = "";
        }
    }
    public void Get_CompanyBal()
    {
        if (ViewState["COMPANYDATATABLE"].ToString() != "")
        {
            DropDownList ddl = ((DropDownList)FormView1.FindControl("ddlCompanyCode"));
            DataTable dtCom = new DataTable();
            dtCom = (DataTable)ViewState["COMPANYDATATABLE"];
            dtCom.DefaultView.RowFilter = "COMPANY_CODE='" + ddl.SelectedValue + "'";
            dtCom = dtCom.DefaultView.ToTable();
            string amount = dtCom.Rows[0]["BALANCE_AMOUNT"].ToString();
            ((TextBox)FormView1.FindControl("TXT_Current_Bal_Amt_Insert")).Text = (amount == "&nbsp;") ? "0" : (amount == "") ? "0" : amount;
        }
        else
        {
            ((Label)FormView1.FindControl("lblDuplicate_INSERT")).Text = "Company not found.";
        }
    
    }
    protected void btnPicker_Click(object sender, ImageClickEventArgs e)
    {
        if (Session["LOV_ID"].ToString() != "")
        {
            CustomerID = Session["LOV_ID"].ToString();
            ((TextBox)FormView1.FindControl("txtBANKCODE_INSERT")).Text = Session["LOV_ID"].ToString();
            ((TextBox)FormView1.FindControl("txtBANKNAME_INSERT")).Text = Session["LOV_DESCRIPTION"].ToString();
            ((TextBox)FormView1.FindControl("TXT_Current_Bal_Amt_Insert")).Text = (Session["BALANCE_AMOUNT"].ToString() == "&nbsp;") ? "" : Session["BALANCE_AMOUNT"].ToString();
        }
    }
    protected void BTN_INSERT_Click(object sender, EventArgs e)
    {
        try
        {
            Page.Validate();
            
                if (Page.IsValid)
                {
                    if (Convert.ToDateTime(((TextBox)FormView1.FindControl("txtRATE_DATE_INSERT")).Text) <= Convert.ToDateTime(((TextBox)FormView1.FindControl("txtSysdate")).Text))
                    {

                    }
                    else
                    {
                        ((Label)FormView1.FindControl("lblDuplicate_INSERT")).Text = "Date must be equal or less then system date";
                        return;
                    }
                    CustBalObj.RecordInputStart();
                    CustBalObj.setBankCode = ((DropDownList)FormView1.FindControl("ddlCompanyCode")).SelectedValue.ToString();//((TextBox)FormView1.FindControl("txtBANKCODE_INSERT")).Text;
                    CustBalObj.setRateDate = Convert.ToDateTime(((TextBox)FormView1.FindControl("txtRATE_DATE_INSERT")).Text).ToString("dd-MMM-yyyy");
                    CustBalObj.setBalAmount = ((TextBox)FormView1.FindControl("txtBAL_AMOUNT_INSERT")).Text;
                    CustBalObj.setRefNo = ((TextBox)FormView1.FindControl("TXT_Ref_No_Insert")).Text;
                    //CustBalObj.setA_UserID = "";
                    //CustBalObj.setA_DateTime = "";
                    CustBalObj.setE_UserID = Session["U_NAME"].ToString();
                    CustBalObj.setE_DateTime = DateTime.Now.ToString("dd-MMM-yyyy").ToString();
                    CustBalObj.RecordInputCommit();
                    DataTable dt = new DataTable();
                    dt = CustBalObj.AddNewGroup("");
                    if (dt.Rows[0][1].ToString().StartsWith("0"))
                    {
                        string[] arr = dt.Rows[0][1].ToString().Split(';');
                        string msg = arr[1];
                        ((Label)FormView1.FindControl("lblDuplicate_INSERT")).Text = msg;
                        return;
                    }
                    BackPage();
                }
            
           
        }
        catch (Exception ex)
        {
            ((Label)FormView1.FindControl("lblDuplicate_INSERT")).Text = ex.Message;

        }
    }
    protected void BTN_RESET_Click(object sender, EventArgs e)
    {

    }
    protected void BTN_INSERT_CANCEL_Click(object sender, EventArgs e)
    {
        BackPage();
    }
}
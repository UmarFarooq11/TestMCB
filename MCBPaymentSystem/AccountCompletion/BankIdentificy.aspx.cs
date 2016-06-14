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
using System.Xml;
using System.Threading;
using System.Text;

public partial class BankIdentificy : System.Web.UI.Page
{
    string[] ARY;
    string RGS_SUPPORT;
    DatabaseConnection_Util _dbConfig = new DatabaseConnection_Util();
    LOV_COLLECTION lov = new LOV_COLLECTION();
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetCacheability(HttpCacheability.ServerAndNoCache);
        Session["RGS"] = "00000";
        String ST = Startup_Util.DcryptionPWD(Request.QueryString[0].ToString());
        ARY = ST.Split('~');
        Session["RGS"] = ARY[0].ToString();
        RGS_SUPPORT = Session["RGS"].ToString();

        if (RGS_SUPPORT.Substring(0, 1) == "0")
        { btnSubmit.Visible = false; /*ADD*/}
        else if (RGS_SUPPORT.Substring(0, 1) == "1")
        { btnSubmit.Visible = true; /*ADD*/}

        if (!Page.IsPostBack)
        {
            //btnSubmit.Enabled = false;
            txtagent.Attributes.Add("readonly", "readonly");

            btnSubmit.Attributes.Add("style", "visibility:hidden;");
            btnSubmit.Attributes.Add("onclick", "return funConfirm();");

            lblFieldTrans.Attributes.Add("style", "visibility:hidden;");
            lblTransaction.Attributes.Add("style", "visibility:hidden;");
            lblTotalFile.Attributes.Add("style", "visibility:hidden;");
            lblTotalRecord.Attributes.Add("style", "visibility:hidden;");
            btnGetBank.Attributes.Add("style", "visibility:hidden;");
            ddlCompanyBind();
            dllFilename();
        }
    }
    private void loadGrid(string check)
    {
        DataSet ds = new DataSet();
        OracleParameter[] parms = new OracleParameter[10];

        parms[0] = new OracleParameter();
        parms[0] = _dbConfig.Oracle_Param("P_company_code", OracleType.VarChar, ParameterDirection.Input, ddlCompanyCode.SelectedValue.ToString());

        parms[1] = new OracleParameter();
        parms[1] = _dbConfig.Oracle_Param("P_FILE_NAME", OracleType.VarChar, ParameterDirection.Input, (ddlFile.SelectedItem == null) ? "" : ddlFile.SelectedItem.ToString());

        parms[2] = new OracleParameter();
        parms[2] = _dbConfig.Oracle_Param("P_Trans_type", OracleType.VarChar, ParameterDirection.Input, "");

        parms[3] = new OracleParameter();
        parms[3] = _dbConfig.Oracle_Param("P_Rowid", OracleType.VarChar, ParameterDirection.Input, "");

        parms[4] = new OracleParameter();
        parms[4] = _dbConfig.Oracle_Param("p_bank_code", OracleType.VarChar, ParameterDirection.Input, "");
        parms[5] = new OracleParameter();
        parms[5] = _dbConfig.Oracle_Param("p_branch_code", OracleType.VarChar, ParameterDirection.Input, "");

        parms[6] = new OracleParameter();
        parms[6] = _dbConfig.Oracle_Param("P_Userid", OracleType.VarChar, ParameterDirection.Input, Session["U_NAME"].ToString());

        parms[7] = new OracleParameter();
        parms[7] = _dbConfig.Oracle_Param("P_type", OracleType.VarChar, ParameterDirection.Input, "02");

        parms[8] = new OracleParameter();
        parms[8] = _dbConfig.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        parms[9] = new OracleParameter();
        parms[9] = _dbConfig.Oracle_Param("v_retval", OracleType.VarChar, ParameterDirection.Output, "");
        ds = _dbConfig.Oracle_GetDataSetSP("SP_Data_Segregation", parms);

        if (parms[9].Value.ToString() == "")
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                ViewState["TaskTable"] = dt;
                grdTransaction.DataSource = ds;
                grdTransaction.DataBind();
                onEnterPress();
                ((TextBox)grdTransaction.Rows[0].FindControl("txtbandcode")).Focus();
                ViewState["dsBank"] = lov.Get_PS_SP_CorrBank_LOV("%", "%").Tables[0];
                if (check != "S")
                {
                    lblMessage.Text = "";
                }
                lblTransaction.Text = ds.Tables[0].Rows.Count.ToString();
                btnSubmit.Attributes.Add("style", "visibility:visible;");
                lblFieldTrans.Attributes.Add("style", "visibility:visible;");
                lblTransaction.Attributes.Add("style", "visibility:visible;");
            }
            else if (check == "S")
            {
                btnSubmit.Attributes.Add("style", "visibility:hidden;");
                grdTransaction.DataSource = null;
                grdTransaction.DataBind();
                lblTransaction.Text = ds.Tables[0].Rows.Count.ToString();
                lblFieldTrans.Attributes.Add("style", "visibility:hidden;");
                lblTransaction.Attributes.Add("style", "visibility:hidden;");
            }
            else if (check == "Q")
            {
                btnSubmit.Attributes.Add("style", "visibility:hidden;");
                grdTransaction.DataSource = null;
                grdTransaction.DataBind();
                lblMessage.Text = "No data found.";
                lblTransaction.Text = ds.Tables[0].Rows.Count.ToString();
                lblFieldTrans.Attributes.Add("style", "visibility:hidden;");
                lblTransaction.Attributes.Add("style", "visibility:hidden;");
            }
        }
        else
        {

        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            string p_return = "";
            string[] p_retval;
            for (int i = 0; i < grdTransaction.Rows.Count; i++)
            {
                string bankCode = ((HiddenField)grdTransaction.Rows[i].Cells[6].FindControl("hf_BankCode")).Value;
                if (bankCode != "" && bankCode != "0")
                {
                    DataSet ds = new DataSet();
                    OracleParameter[] parms = new OracleParameter[10];

                    parms[0] = new OracleParameter();
                    parms[0] = _dbConfig.Oracle_Param("P_company_code", OracleType.VarChar, ParameterDirection.Input, ddlCompanyCode.SelectedValue.ToString());

                    parms[1] = new OracleParameter();
                    parms[1] = _dbConfig.Oracle_Param("P_FILE_NAME", OracleType.VarChar, ParameterDirection.Input, (ddlFile.SelectedItem.ToString() == "") ? "" : ddlFile.SelectedItem.ToString());

                    parms[2] = new OracleParameter();
                    parms[2] = _dbConfig.Oracle_Param("P_Trans_type", OracleType.VarChar, ParameterDirection.Input, grdTransaction.Rows[i].Cells[1].Text);

                    parms[3] = new OracleParameter();
                    parms[3] = _dbConfig.Oracle_Param("P_Rowid", OracleType.VarChar, ParameterDirection.Input, grdTransaction.Rows[i].Cells[0].Text);

                    parms[4] = new OracleParameter();
                    parms[4] = _dbConfig.Oracle_Param("p_bank_code", OracleType.VarChar, ParameterDirection.Input, bankCode);

                    parms[5] = new OracleParameter();
                    parms[5] = _dbConfig.Oracle_Param("p_branch_code", OracleType.VarChar, ParameterDirection.Input, "");

                    parms[6] = new OracleParameter();
                    parms[6] = _dbConfig.Oracle_Param("P_Userid", OracleType.VarChar, ParameterDirection.Input, Session["U_NAME"].ToString());

                    parms[7] = new OracleParameter();
                    parms[7] = _dbConfig.Oracle_Param("P_type", OracleType.VarChar, ParameterDirection.Input, "05");

                    parms[8] = new OracleParameter();
                    parms[8] = _dbConfig.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");

                    parms[9] = new OracleParameter();
                    parms[9] = _dbConfig.Oracle_Param("v_retval", OracleType.VarChar, ParameterDirection.Output, "");

                    ds = _dbConfig.Oracle_GetDataSetSP("SP_Data_Segregation", parms);
                    p_return = ds.Tables[0].Rows[0][0].ToString();
                    p_retval = p_return.Split(',');
                    lblMessage.Text = p_retval[1].ToString();
                    p_return = p_retval[0].ToString();

                }
            }
            if (p_return == "04")
            {
                loadGrid("S");
            }
            //return;
        }
        catch (Exception EX)
        {
            lblMessage.Text = EX.Message;
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Page.Validate();
        if (Page.IsValid)
        {
            loadGrid("Q");
        }
    }
    public void onEnterPress()
    {
        for (int i = 0; i < grdTransaction.Rows.Count; i++)
        {
            if (grdTransaction.Rows.Count - 1 > i)
            {
                //((TextBox)sort_table.Rows[i + 1].FindControl("txtBranchCode")).Focus();
                ((TextBox)grdTransaction.Rows[i].FindControl("txtbandcode")).Attributes.Add("onkeypress", "if (event.keyCode==13) {document.getElementById('" + ((TextBox)grdTransaction.Rows[i + 1].FindControl("txtbandcode")).ClientID + "').focus();return false;}");
            }
            if (grdTransaction.Rows.Count - 1 == i)
            {
                ((TextBox)grdTransaction.Rows[i].FindControl("txtbandcode")).Attributes.Add("onkeypress", "if (event.keyCode==13) {document.getElementById('" + ((ImageButton)grdTransaction.Rows[i].FindControl("BTN_PrincipleBankId_INSERT")).ClientID + "').focus();return false;}");
            }
        }

    }
    protected void BTN_PrincipleBankId_INSERT_Click(object sender, ImageClickEventArgs e)
    {
        GridViewRow row = grdTransaction.SelectedRow;
        if (Session["BankCode"].ToString() != "")
        {
            int i = Convert.ToInt16(hdRowIndex.Value);
            ((TextBox)grdTransaction.Rows[i].FindControl("txtbandcode")).Text = Session["LOV_CODE"].ToString();
            ((TextBox)grdTransaction.Rows[i].FindControl("txtbandcode")).ToolTip = Session["LOV_CODE"].ToString();

            ((HiddenField)grdTransaction.Rows[i].FindControl("hf_BankCode")).Value = Session["RPS_Customer_Bank_ID"].ToString();
        }
    }
    protected void grdTransaction_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            ((ImageButton)e.Row.FindControl("BTN_PrincipleBankId_INSERT")).Attributes.Add("onclick", "BankLOV(" + e.Row.RowIndex + ",'" + hdRowIndex.ClientID + "')");
            //((TextBox)e.Row.FindControl("txtbandcode")).Attributes.Add("readonly", "readonly");
            ((TextBox)e.Row.FindControl("txtbandcode")).Attributes.Add("onchange", "clickbtn(" + e.Row.RowIndex + ");");
            //if (e.Row.RowIndex == 0)
            //{
            //    ds = lov.Get_PS_SP_CorrBank_LOV("%", "%");    
            //}
            //((DropDownList)e.Row.FindControl("ddlBank")).DataSource = ds;
            //((DropDownList)e.Row.FindControl("ddlBank")).DataTextField = "BankName";
            //((DropDownList)e.Row.FindControl("ddlBank")).DataValueField = "BankCode";
            //((DropDownList)e.Row.FindControl("ddlBank")).DataBind();

        }
    }
    //public void ddlBankBind()
    //{
    //    DataSet ds = new DataSet();

    //    ds = lov.Get_PS_SP_CorrBank_LOV("%", "%");
    //    if (ds.Tables[0].Rows.Count > 0)
    //    {
    //        ddlCompanyCode.DataSource = ds;
    //        ddlCompanyCode.DataValueField = "Company_Code";
    //        ddlCompanyCode.DataTextField = "Company_Name";
    //        ddlCompanyCode.DataBind();
    //    }
    //    else
    //    {

    //    }
    //}
    protected void btnCustomerCode_Click(object sender, ImageClickEventArgs e)
    {

        if (Session["LOV_ID"].ToString() != "")
        {
            txtagent.Text = Session["COMPANY_CODE"].ToString();
            txtagentname.Text = Session["COMPANY_NAME"].ToString();
            DataSet ds = new DataSet();
            OracleParameter[] parms = new OracleParameter[3];
            parms[0] = _dbConfig.Oracle_Param("p_company_code", OracleType.VarChar, ParameterDirection.Input, txtagent.Text);
            parms[1] = _dbConfig.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
            parms[2] = _dbConfig.Oracle_Param("v_retval", OracleType.VarChar, ParameterDirection.Output, "");
            ds = _dbConfig.Oracle_GetDataSetSP("SP_Data_Segregation_LOV", parms);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlFile.DataSource = ds;
                ddlFile.DataValueField = "FILE_NAME";
                ddlFile.DataTextField = "FILE_NAME";
                ddlFile.DataBind();

                ViewState["dataset"] = ds;
                lblTotalRecord.Text = ds.Tables[0].Rows[0]["total_records"].ToString();
                lblTotalRecord.Attributes.Add("style", "visibility:visible;");
                lblTotalFile.Attributes.Add("style", "visibility:visible;");
            }
            else
            {
                ddlFile.DataSource = string.Empty;
                ddlFile.DataValueField = "";
                ddlFile.DataTextField = "";
                ddlFile.DataBind();
                btnSubmit.Attributes.Add("style", "visibility:hidden;");
                grdTransaction.DataSource = null;
                grdTransaction.DataBind();
            }
        }
        else
        {
            txtagent.Text = "";
            txtagentname.Text = "";
        }
    }
    protected void Page_PreInit(object sender, EventArgs e)
    {
        Page.Theme = "SkinFile"; //Session["ThemeChange"].ToString();
    }
    //protected void grdTransaction_PageIndexChanging(object sender, GridViewPageEventArgs e)
    //{
    //    grdTransaction.PageIndex = e.NewPageIndex;
    //    loadGrid();
    //}
    protected void ddlFile_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        ds = (DataSet)ViewState["dataset"];
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                if (ddlFile.SelectedValue.ToString() == ds.Tables[0].Rows[i]["FILE_NAME"].ToString())
                {
                    lblTotalRecord.Text = ds.Tables[0].Rows[i]["total_records"].ToString();
                    lblTotalFile.Attributes.Add("style", "visibility:visible;");
                    lblTotalRecord.Attributes.Add("style", "visibility:visible;");
                }
            }
        }
        grdTransaction.DataSource = null;
        grdTransaction.DataBind();
        btnSubmit.Attributes.Add("style", "visibility:hidden;");
        lblTransaction.Attributes.Add("style", "visibility:hidden;");
        lblFieldTrans.Attributes.Add("style", "visibility:hidden;");
    }
    private string GetSortDirection(string column)
    {
        string sortDirection = "ASC";
        string sortExpression = ViewState["SortExpression"] as string;
        if (sortExpression != null)
        {
            if (sortExpression == column)
            {
                string lastDirection = ViewState["SortDirection"] as string;
                if ((lastDirection != null) && (lastDirection == "ASC"))
                {
                    sortDirection = "DESC";
                }
            }
        }
        ViewState["SortDirection"] = sortDirection;
        ViewState["SortExpression"] = column;
        return sortDirection;
    }
    protected void grdTransaction_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataTable dt = ViewState["TaskTable"] as DataTable;
        if (dt != null)
        {
            dt.DefaultView.Sort = e.SortExpression + " " + GetSortDirection(e.SortExpression);
            grdTransaction.DataSource = ViewState["TaskTable"];
            grdTransaction.DataBind();
        }
    }
    public void ddlCompanyBind()
    {
        DataSet ds = new DataSet();

        ds = lov.Get_Company_setup_lov("%", "%");
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlCompanyCode.DataSource = ds;
            ddlCompanyCode.DataValueField = "Company_Code";
            ddlCompanyCode.DataTextField = "Company_Name";
            ddlCompanyCode.DataBind();
        }
        else
        {

        }
    }
    protected void ddlCompanyCode_SelectedIndexChanged(object sender, EventArgs e)
    {
        dllFilename();
        lblMessage.Text = "";
    }
    public void dllFilename()
    {

        //txtagent.Text = Session["COMPANY_CODE"].ToString();
        //txtagentname.Text = Session["COMPANY_NAME"].ToString();
        DataSet ds = new DataSet();
        OracleParameter[] parms = new OracleParameter[3];
        parms[0] = _dbConfig.Oracle_Param("p_company_code", OracleType.VarChar, ParameterDirection.Input, ddlCompanyCode.SelectedValue.ToString());
        parms[1] = _dbConfig.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        parms[2] = _dbConfig.Oracle_Param("v_retval", OracleType.VarChar, ParameterDirection.Output, "");
        ds = _dbConfig.Oracle_GetDataSetSP("SP_Data_Segregation_LOV", parms);
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlFile.DataSource = ds;
            ddlFile.DataValueField = "FILE_NAME";
            ddlFile.DataTextField = "FILE_NAME";
            ddlFile.DataBind();

            ViewState["dataset"] = ds;
            lblTotalRecord.Text = ds.Tables[0].Rows[0]["total_records"].ToString();
            lblTotalRecord.Attributes.Add("style", "visibility:visible;");
            lblTotalFile.Attributes.Add("style", "visibility:visible;");
        }
        else
        {
            ddlFile.DataSource = string.Empty;
            ddlFile.DataValueField = "";
            ddlFile.DataTextField = "";
            ddlFile.DataBind();
            btnSubmit.Attributes.Add("style", "visibility:hidden;");
            grdTransaction.DataSource = null;
            grdTransaction.DataBind();
        }

    }
    protected void btnGetBank_Click(object sender, EventArgs e)
    {
        try
        {
            int i = Convert.ToInt16(hdRowIndex.Value);
            DataTable dt = new DataTable();
            dt = (DataTable)ViewState["dsBank"];
            string bankCode = ((TextBox)grdTransaction.Rows[i].FindControl("txtbandcode")).Text;
            dt.DefaultView.RowFilter = "BANKCODE='" + bankCode + "'";
            dt = dt.DefaultView.ToTable();
            if (dt.Rows.Count > 0 && dt.Rows[0][0].ToString() != "" && dt.Rows[0][0].ToString() != "")
            {
                ((TextBox)grdTransaction.Rows[i].FindControl("txtbandcode")).Text = dt.Rows[0][2].ToString();
                ((TextBox)grdTransaction.Rows[i].FindControl("txtbandcode")).ToolTip = dt.Rows[0][2].ToString();
                ((HiddenField)grdTransaction.Rows[i].FindControl("hf_BankCode")).Value = dt.Rows[0][1].ToString();
                ((TextBox)grdTransaction.Rows[i].FindControl("txtbandcode")).ForeColor = System.Drawing.Color.Blue;
                if (grdTransaction.Rows.Count - 1 > i)
                {
                    ((TextBox)grdTransaction.Rows[i + 1].FindControl("txtbandcode")).Focus();
                }
            }
            else
            {

                ((TextBox)grdTransaction.Rows[i].FindControl("txtbandcode")).Text = "Bank not found";
                ((TextBox)grdTransaction.Rows[i].FindControl("txtbandcode")).ToolTip = "Bank not found";
                ((HiddenField)grdTransaction.Rows[i].FindControl("hf_BankCode")).Value = "";
                ((TextBox)grdTransaction.Rows[i].FindControl("txtbandcode")).ForeColor = System.Drawing.Color.Red;
                if (bankCode == "")
                {
                    ((TextBox)grdTransaction.Rows[i].FindControl("txtbandcode")).Text = "";
                    ((TextBox)grdTransaction.Rows[i].FindControl("txtbandcode")).ToolTip = "No Bank against this entry";
                    ((TextBox)grdTransaction.Rows[i].FindControl("txtbandcode")).ForeColor = System.Drawing.Color.Blue;
                }
                if (grdTransaction.Rows.Count - 1 > i)
                {
                    ((TextBox)grdTransaction.Rows[i + 1].FindControl("txtbandcode")).Focus();
                }
            }
            lblMessage.Text = "";
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }
}
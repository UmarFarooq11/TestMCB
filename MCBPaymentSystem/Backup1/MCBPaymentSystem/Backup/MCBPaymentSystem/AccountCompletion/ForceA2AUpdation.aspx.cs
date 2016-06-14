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
using System.Collections.Specialized;

public partial class ForceA2AUpdation : System.Web.UI.Page
{
    string[] ARY;
    string RGS_SUPPORT;
    DatabaseConnection_Util _dbConfig = new DatabaseConnection_Util();
    LOV_COLLECTION lov = new LOV_COLLECTION();
    DataSet dsbranch = new DataSet();
    protected void Page_PreInit(object sender, EventArgs e)
    {
        Page.Theme = "SkinFile"; //Session["ThemeChange"].ToString(); 
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetCacheability(HttpCacheability.ServerAndNoCache);
        Session["RGS"] = "00000";
        String ST = Startup_Util.DcryptionPWD(Request.QueryString[0].ToString());
        ARY = ST.Split('~');
        Session["RGS"] = ARY[0].ToString();
        RGS_SUPPORT = Session["RGS"].ToString();

        if (RGS_SUPPORT.Substring(0, 1) == "0")
        {
            btnSubmit.Visible = false; /*ADD*/
            btnAuthorize.Visible = true; /*ADD*/
            ViewState["Authorize"] = "true";
        }
        else if (RGS_SUPPORT.Substring(0, 1) == "1")
        {
            btnSubmit.Visible = true; /*ADD*/
            btnAuthorize.Visible = false;
            ViewState["Authorize"] = "false";
        }
        if (RGS_SUPPORT.Substring(4, 1) == "0")
        {
            //ViewState["Authorize"] = "false";
        }
        else if (RGS_SUPPORT.Substring(4, 1) == "1")
        {
            //ViewState["Authorize"] = "true";
        }
        if (!Page.IsPostBack)
        {
            ViewState["ConnectionString"] = _dbConfig.ConnectionString;
            btnSubmit.Attributes.Add("style", "visibility:hidden;");
            btnSubmit.Attributes.Add("onclick", "return funConfirm();");
            btnAuthorize.Attributes.Add("style", "visibility:hidden;");
            btnAuthorize.Attributes.Add("onclick", "return OnConfirmAuth();");

            lblFieldTrans.Attributes.Add("style", "visibility:hidden;");
            lblTransaction.Attributes.Add("style", "visibility:hidden;");
            lblTotalFile.Attributes.Add("style", "visibility:hidden;");
            lblTotalRecord.Attributes.Add("style", "visibility:hidden;");
            ddlCompanyBind();
            dllFilename();
            Panel1.Attributes.Add("style", "visibility:hidden;");
            btnGetAccount.Attributes.Add("style", "visibility:hidden;");
            //btnGetSymbolAcct_title.Attributes.Add("style", "visibility:hidden;");

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
    public void dllFilename()
    {
        DataSet ds = new DataSet();
        OracleParameter[] parms = new OracleParameter[3];
        parms[0] = _dbConfig.Oracle_Param("p_company_code", OracleType.VarChar, ParameterDirection.Input, ddlCompanyCode.SelectedValue.ToString());
        parms[1] = _dbConfig.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        parms[2] = _dbConfig.Oracle_Param("v_retval", OracleType.VarChar, ParameterDirection.Output, "");
        ds = _dbConfig.Oracle_GetDataSetSP("SP_Data_Segregation_LOV", parms);
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlFile.DataSource = ds.Tables[0];
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
            ddlFile.DataSource = "";
            ddlFile.DataValueField = "";
            ddlFile.DataTextField = "";
            ddlFile.DataBind();

            btnSubmit.Attributes.Add("style", "visibility:hidden;");
            GridView1.DataSource = null;
            GridView1.DataBind();


            lblTotalRecord.Attributes.Add("style", "visibility:hidden;");
            lblTotalFile.Attributes.Add("style", "visibility:hidden;");
            lblTransaction.Attributes.Add("style", "visibility:hidden;");
            lblFieldTrans.Attributes.Add("style", "visibility:hidden;");
        }

    }
    private void loadGrid(string check)
    {
        if (ddlFile.SelectedValue != "")
        {
            DataSet ds = new DataSet();
            OracleParameter[] parms = new OracleParameter[10];

            int pno = 0;
            parms[pno] = new OracleParameter();
            parms[pno] = _dbConfig.Oracle_Param("P_company_code", OracleType.VarChar, ParameterDirection.Input, ddlCompanyCode.SelectedValue.ToString());
            pno++;

            parms[pno] = new OracleParameter();
            parms[pno] = _dbConfig.Oracle_Param("P_FILE_NAME", OracleType.VarChar, ParameterDirection.Input, (ddlFile.SelectedItem == null) ? "" : ddlFile.SelectedItem.ToString());
            pno++;

            parms[pno] = new OracleParameter();
            parms[pno] = _dbConfig.Oracle_Param("P_Trans_type", OracleType.VarChar, ParameterDirection.Input, "");
            pno++;

            parms[pno] = new OracleParameter();
            parms[pno] = _dbConfig.Oracle_Param("P_Rowid", OracleType.VarChar, ParameterDirection.Input, "");
            pno++;

            parms[pno] = new OracleParameter();
            parms[pno] = _dbConfig.Oracle_Param("p_bank_code", OracleType.VarChar, ParameterDirection.Input, "");
            pno++;

            parms[pno] = new OracleParameter();
            parms[pno] = _dbConfig.Oracle_Param("p_branch_code", OracleType.VarChar, ParameterDirection.Input, "");
            pno++;

            parms[pno] = new OracleParameter();
            parms[pno] = _dbConfig.Oracle_Param("P_Userid", OracleType.VarChar, ParameterDirection.Input, "");
            pno++;

            parms[pno] = new OracleParameter();
            parms[pno] = _dbConfig.Oracle_Param("P_type", OracleType.VarChar, ParameterDirection.Input, "19");
            pno++;

            parms[pno] = new OracleParameter();
            parms[pno] = _dbConfig.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
            pno++;

            parms[pno] = new OracleParameter();
            parms[pno] = _dbConfig.Oracle_Param("v_retval", OracleType.VarChar, ParameterDirection.Output, "");

            ds = _dbConfig.Oracle_GetDataSetSP("SP_Data_Segregation", parms);

            if (parms[pno].Value.ToString() == "")
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataTable dt = new DataTable();
                    dt = ds.Tables[0];
                    ViewState["TaskTable"] = dt;
                    GridView1.DataSource = ds;
                    GridView1.DataBind();
                    ((TextBox)GridView1.Rows[0].FindControl("txtBranchCode")).Focus();
                    dsbranch = lov.Get_SP_Setup_Branch_lOV("%", "%");
                    ViewState["dsbranch"] = dsbranch.Tables[0];
                    onEnterPress();
                    Panel1.Attributes.Add("style", "visibility:visible;");
                    if (ViewState["Authorize"].ToString() == "true")
                    {
                        btnAuthorize.Attributes.Add("style", "visibility:visible;");
                    }
                    else
                    {
                        btnSubmit.Attributes.Add("style", "visibility:visible;");
                    }
                    
                    if (check != "S")
                    {
                        lblMessage.Text = "";
                    }

                    lblTransaction.Text = ds.Tables[0].Rows.Count.ToString();
                    lblFieldTrans.Attributes.Add("style", "visibility:visible;");
                    lblTransaction.Attributes.Add("style", "visibility:visible;");
                }
                else if (check == "S")
                {
                    btnSubmit.Attributes.Add("style", "visibility:hidden;");
                    GridView1.DataSource = null;
                    GridView1.DataBind();
                    Panel1.Attributes.Add("style", "visibility:hidden;");
                    lblTransaction.Text = ds.Tables[0].Rows.Count.ToString();
                    lblFieldTrans.Attributes.Add("style", "visibility:hidden;");
                    lblTransaction.Attributes.Add("style", "visibility:hidden;");
                }
                else
                {
                    btnSubmit.Attributes.Add("style", "visibility:hidden;");
                    GridView1.DataSource = null;
                    GridView1.DataBind();
                    lblMessage.Text = "No data found.";
                    lblTransaction.Text = ds.Tables[0].Rows.Count.ToString();
                    lblFieldTrans.Attributes.Add("style", "visibility:hidden;");
                    lblTransaction.Attributes.Add("style", "visibility:hidden;");
                    Panel1.Attributes.Add("style", "visibility:hidden;");
                }
            }
            else
            {

            }
        }
    }
    public void onEnterPress()
    {
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            if (GridView1.Rows.Count - 1 > i)
            {
                ((TextBox)GridView1.Rows[i].FindControl("txtaccountno_symbol")).Attributes.Add("onkeypress","if (event.keyCode==13) {document.getElementById('" + ((TextBox)GridView1.Rows[i + 1].FindControl("txtBranchCode")).ClientID + "').focus();return false;}");
                ((TextBox)GridView1.Rows[i].FindControl("txtBranchCode")).Attributes.Add("onkeypress","if (event.keyCode==13) {document.getElementById('" + ((TextBox)GridView1.Rows[i].FindControl("txtaccountno_symbol")).ClientID + "').focus();return false;}");
            }
            if (GridView1.Rows.Count - 1 == i)
            {
                ((TextBox)GridView1.Rows[i].FindControl("txtBranchCode")).Attributes.Add("onkeypress","if (event.keyCode==13) {document.getElementById('" + ((TextBox)GridView1.Rows[i].FindControl("txtaccountno_symbol")).ClientID + "').focus();return false;}");
                ((TextBox)GridView1.Rows[i].FindControl("txtaccountno_symbol")).Attributes.Add("onkeypress", 
                "if (event.keyCode==13) {document.getElementById('" + ((TextBox)GridView1.Rows[i].FindControl(
                "txtBranchCode")).ClientID + "').focus();return false;}");
            }
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
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            DBUniversalUploadProcess db = new DBUniversalUploadProcess();
            string val = db.force_updation(GridView1, Session["U_NAME"].ToString(), "01", GridView1.Rows.Count,ddlCompanyCode.SelectedValue,ddlFile.SelectedValue);
            lblMessage.Text = (val.Contains(";") == true ? val.Split(';').GetValue(1).ToString() : val);
#region
            //OracleConnection con = new OracleConnection(ViewState["ConnectionString"].ToString());
            //con.Open();
            //OracleTransaction trans = con.BeginTransaction();
            //string val = Execute_sp(con, trans);
            //if (val.StartsWith("04") == true)
            //{
            //    val = postLeadger(con, trans);
            //    if (val.StartsWith("04") == true)
            //    {
            //        trans.Commit();
            //        con.Close();
            //        loadGrid("S");
            //    }
            //    else
            //    {
            //        trans.Rollback();
            //        con.Close();
            //    }
            //}
            //else
            //{
            //    trans.Rollback();
            //    con.Close();
            //}
            #endregion
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }
    protected void btnAuthorize_Click(object sender, EventArgs e)
    {
        string v_return = "";
        OracleParameter[] parm = new OracleParameter[8];
        int pno = 0;
        parm[pno] = new OracleParameter();
        parm[pno] = _dbConfig.Oracle_Param("p_rowid", OracleType.VarChar, ParameterDirection.Input, "");
        pno++;
        parm[pno] = new OracleParameter();
        parm[pno] = _dbConfig.Oracle_Param("p_branch_code", OracleType.VarChar, ParameterDirection.Input, "");
        pno++;
        parm[pno] = new OracleParameter();
        parm[pno] = _dbConfig.Oracle_Param("p_Account_no", OracleType.VarChar, ParameterDirection.Input, "");
        pno++;
        parm[pno] = new OracleParameter();
        parm[pno] = _dbConfig.Oracle_Param("P_Userid", OracleType.VarChar, ParameterDirection.Input, Session["U_NAME"].ToString());
        pno++;
        parm[pno] = new OracleParameter();
        parm[pno] = _dbConfig.Oracle_Param("P_type", OracleType.VarChar, ParameterDirection.Input, "02");
        pno++;
        parm[pno] = new OracleParameter();
        parm[pno] = _dbConfig.Oracle_Param("P_company_code", OracleType.VarChar, ParameterDirection.Input, ddlCompanyCode.SelectedValue);
        pno++;
        parm[pno] = new OracleParameter();
        parm[pno] = _dbConfig.Oracle_Param("p_file_name", OracleType.VarChar, ParameterDirection.Input, ddlFile.SelectedValue);
        pno++;
        parm[pno] = new OracleParameter();
        parm[pno] = _dbConfig.Oracle_Param("p_retval", OracleType.VarChar, ParameterDirection.Output, "");
        v_return = _dbConfig.OracleExecuteSP_GetReturnVal("sp_force_Updation", parm, pno);
        lblMessage.Text = v_return.Split(';').GetValue(1).ToString();
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //((TextBox)e.Row.FindControl("txtaccountno_symbol")).Attributes.Add("onchange", "clickbtnaccount(" + e.Row.RowIndex + ");");
            //((TextBox)e.Row.FindControl("txtBranchCode")).Attributes.Add("onchange", "clickbtn(" + e.Row.RowIndex + ");");
            //((TextBox)e.Row.FindControl("txtSymbolTitle")).Attributes.Add("readonly", "readonly");
            ((TextBox)e.Row.FindControl("txtSymbolTitle")).Enabled = true;
            ((TextBox)e.Row.FindControl("txtSymbolTitle")).Attributes.Add("onchange", "if(this.value =='') this.value='Symbol Title';");

            #region
            //((TextBox)e.Row.FindControl("txtBranchCode")).Attributes.Add("onkeypress",
            //    "if (event.keyCode==13) {document.getElementById('" +
            //((TextBox)e.Row.FindControl("txtaccountno_symbol")).ClientID + "').focus();return false;}");
            //if (ViewState["Authorize"].ToString() == "true")
            //{
            //    //Column 6 for edit
            //    //Column 7 for authorize
            //    e.Row.Cells[6].CssClass = "hidden";  //Edit link button false
            //    LinkButton linkBtn = (LinkButton)(e.Row.Cells[7].Controls[0]);
            //    if (e.Row.Cells[5].Text == "Un-Authorized") //Check transaction Un-Authorized?
            //    {
            //        if (linkBtn.Text == "Authorize") linkBtn.Attributes.Add("onclick", "return OnConfirmAuth();");
            //    }
            //    else
            //    {
            //        linkBtn.Enabled = false;
            //    }
            //}
            //else if (ViewState["Authorize"].ToString() == "false")
            //{
            //    e.Row.Cells[7].CssClass = "hidden";    //Authorize link button false
            //    LinkButton linkBtn = (LinkButton)(e.Row.Cells[6].Controls[0]);
            //    if (linkBtn.Text == "Update") linkBtn.Attributes.Add("onclick", "return OnConfirmGV();");
            //}
            #endregion
        }
    }
    protected void ddlCompanyCode_SelectedIndexChanged(object sender, EventArgs e)
    {
        dllFilename();
        lblMessage.Text = "";
    }
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
                    lblTotalFile.Visible = true;
                    lblTotalRecord.Visible = true;
                }
            }
        }
        GridView1.DataSource = null;
        GridView1.DataBind();
        btnSubmit.Attributes.Add("style", "visibility:hidden;");
        lblTransaction.Attributes.Add("style", "visibility:hidden;");
        lblFieldTrans.Attributes.Add("style", "visibility:hidden;");
    }
    protected void btnGetAccount_Click(object sender, EventArgs e)
    {
        try
        {
            int i = Convert.ToInt16(hdRowIndex.Value);
            DataTable dt = new DataTable();
            dt = (DataTable)ViewState["dsbranch"];
            string branchCode = ((TextBox)GridView1.Rows[i].FindControl("txtBranchCode")).Text;
            dt.DefaultView.RowFilter = "BRANCH_CODE='" + branchCode + "'";
            dt = dt.DefaultView.ToTable();
            if (dt.Rows.Count > 0 && dt.Rows[0][0].ToString() != "" && dt.Rows[0][0].ToString() != "")
            {
                ((TextBox)GridView1.Rows[i].FindControl("txtBranchCode")).Text = dt.Rows[0][1].ToString();
                ((TextBox)GridView1.Rows[i].FindControl("txtBranchCode")).ToolTip = dt.Rows[0][0].ToString() + " --- " + dt.Rows[0][1].ToString();
                ((HiddenField)GridView1.Rows[i].FindControl("hf_BranchCode")).Value = dt.Rows[0][0].ToString();
                ((TextBox)GridView1.Rows[i].FindControl("txtBranchCode")).ForeColor = System.Drawing.Color.Blue;
                ((TextBox)GridView1.Rows[i].FindControl("txtaccountno_symbol")).Focus();
                //if (GridView1.Rows.Count - 1 > i)
                //{
                //    ((TextBox)GridView1.Rows[i + 1].FindControl("txtBranchCode")).Focus();
                //}26-07-2012
            }
            else
            {
                ((TextBox)GridView1.Rows[i].FindControl("txtBranchCode")).ForeColor = System.Drawing.Color.Red;
                ((TextBox)GridView1.Rows[i].FindControl("txtBranchCode")).Text = "Branch not found";
                ((TextBox)GridView1.Rows[i].FindControl("txtBranchCode")).ToolTip = "Branch not found";
                ((HiddenField)GridView1.Rows[i].FindControl("hf_BranchCode")).Value = "";
                if (branchCode == "")
                {
                    ((TextBox)GridView1.Rows[i].FindControl("txtBranchCode")).Text = "";
                    ((TextBox)GridView1.Rows[i].FindControl("txtBranchCode")).ToolTip = "No Branch against this entry";
                    ((TextBox)GridView1.Rows[i].FindControl("txtBranchCode")).ForeColor = System.Drawing.Color.Blue;
                }
                ((TextBox)GridView1.Rows[i].FindControl("txtBranchCode")).Focus();
                //if (GridView1.Rows.Count - 1 > i)
                //{
                //    ((TextBox)GridView1.Rows[i + 1].FindControl("txtBranchCode")).Focus();
                //}26-07-2012
            }
            lblMessage.Text = "";
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }
    protected void btnGetSymbolAcct_title_Click(object sender, EventArgs e)
    {
        //int i = Convert.ToInt16(hdRowIndex.Value);
        DataTable dt = new DataTable();
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            //string branchCode = ((HiddenField)GridView1.Rows[i].FindControl("hf_BranchCode")).Value;
            string branchCode = ((TextBox)GridView1.Rows[i].FindControl("txtBranchCode")).Text;
            string account_no = ((TextBox)GridView1.Rows[i].FindControl("txtaccountno_symbol")).Text;
            if (branchCode == "" && account_no == "")
            {
                ((TextBox)GridView1.Rows[i].FindControl("txtSymbolTitle")).Text = "Symbol Title";
                continue;
            }
            string account_Title = getSymbolAccountTitle(branchCode, account_no);
            ((TextBox)GridView1.Rows[i].FindControl("txtSymbolTitle")).Text = account_Title;
            /*if (GridView1.Rows.Count - 1 > i)
            {
                ((TextBox)GridView1.Rows[i + 1].FindControl("txtBranchCode")).Focus();
            }
            else
            {
                ((TextBox)GridView1.Rows[0].FindControl("txtSymbolTitle")).Focus();
            }*/
        }
    }
    public string getSymbolAccountTitle(string branchCode, string account_no)
    {
        try
        {
            DataSet ds = new DataSet();
            OracleParameter[] parm = new OracleParameter[3];
            int pno=0;
            parm[pno] = new OracleParameter();
            parm[pno] = _dbConfig.Oracle_Param("p_account_no", OracleType.VarChar, ParameterDirection.Input, account_no);
            pno++;

            parm[pno] = new OracleParameter();
            parm[pno] = _dbConfig.Oracle_Param("p_branch_code", OracleType.VarChar, ParameterDirection.Input, branchCode);
            pno++;

            parm[pno] = new OracleParameter();
            parm[pno] = _dbConfig.Oracle_Param("DATA_SET", OracleType.Cursor, ParameterDirection.Output, "");

            ds = _dbConfig.Oracle_GetDataSetSP("sp_SYMBOL_ACCOUNT_fetch", parm);
            return (ds.Tables[0].Rows.Count > 0 ? ds.Tables[0].Rows[0]["acct_title"].ToString() : "Account Title not found.");
        }
        catch (Exception ex)
        {

            lblMessage.Text = ex.Message;
        }
        return "";
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
    protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataTable dt = ViewState["TaskTable"] as DataTable;
        if (dt != null)
        {
            dt.DefaultView.Sort = e.SortExpression + " " + GetSortDirection(e.SortExpression);
            GridView1.DataSource = ViewState["TaskTable"];
            GridView1.DataBind();
        }
    }
    //public string Execute_sp(OracleConnection conn, OracleTransaction tran)
    //{

    //    string v_return = "";
    //    for (int i = 0; i < GridView1.Rows.Count; i++)
    //    {
    //        //if (((CheckBox)GridView1.Rows[i].FindControl("cbPublish")).Checked == true)
    //        OracleParameter[] parm = new OracleParameter[10];
    //        int pno = 0;
    //        parm[pno] = new OracleParameter();
    //        parm[pno] = _dbConfig.Oracle_Param("P_company_code", OracleType.VarChar, ParameterDirection.Input, ddlCompanyCode.SelectedValue.ToString());
    //        pno++;
    //        parm[pno] = new OracleParameter();
    //        parm[pno] = _dbConfig.Oracle_Param("P_FILE_NAME", OracleType.VarChar, ParameterDirection.Input, ddlFile.SelectedValue.ToString());
    //        pno++;
    //        parm[pno] = new OracleParameter();
    //        parm[pno] = _dbConfig.Oracle_Param("P_Trans_type", OracleType.VarChar, ParameterDirection.Input, (GridView1.Rows[i].Cells[1].Text == "&nbsp;") ? "" : GridView1.Rows[i].Cells[1].Text);
    //        pno++;
    //        parm[pno] = new OracleParameter();
    //        parm[pno] = _dbConfig.Oracle_Param("P_Rowid", OracleType.VarChar, ParameterDirection.Input, GridView1.Rows[i].Cells[0].Text);
    //        pno++;
    //        parm[pno] = new OracleParameter();
    //        parm[pno] = _dbConfig.Oracle_Param("p_bank_code", OracleType.VarChar, ParameterDirection.Input, "");
    //        pno++;
    //        parm[pno] = new OracleParameter();
    //        parm[pno] = _dbConfig.Oracle_Param("p_branch_code", OracleType.VarChar, ParameterDirection.Input, "");
    //        pno++;
    //        parm[pno] = new OracleParameter();
    //        parm[pno] = _dbConfig.Oracle_Param("P_Userid", OracleType.VarChar, ParameterDirection.Input, Session["U_NAME"].ToString());
    //        pno++;
    //        parm[pno] = new OracleParameter();
    //        parm[pno] = _dbConfig.Oracle_Param("P_type", OracleType.VarChar, ParameterDirection.Input, "10");
    //        pno++;
    //        parm[pno] = new OracleParameter();
    //        parm[pno] = _dbConfig.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
    //        pno++;
    //        parm[pno] = new OracleParameter();
    //        parm[pno] = _dbConfig.Oracle_Param("v_retval", OracleType.VarChar, ParameterDirection.Output, "");

    //        v_return = _dbConfig.TransSPOracle_GetReturnStringVal1(conn, tran, "SP_Data_Segregation", parm, pno);
    //        if (v_return.StartsWith("04") == false)
    //        {
    //            lblMessage.Text = v_return.Split(',').GetValue(1).ToString();
    //            return v_return;
    //        }

    //    }
    //    return v_return;
    //}
    //public string spRow_Updation(string rowid, string beneName, string AccountNO, string Type)
    //{

    //    string v_return = "";
    //    //for (int i = 0; i < GridView1.Rows.Count; i++)
    //    //{
    //    //if (((CheckBox)GridView1.Rows[i].FindControl("cbPublish")).Checked == true)
    //    OracleParameter[] parm = new OracleParameter[26];
    //    int pno = 0;
    //    parm[pno] = new OracleParameter();
    //    parm[pno] = _dbConfig.Oracle_Param("P_company_code", OracleType.VarChar, ParameterDirection.Input, "");
    //    pno++;
    //    parm[pno] = new OracleParameter();
    //    parm[pno] = _dbConfig.Oracle_Param("P_FILE_NAME", OracleType.VarChar, ParameterDirection.Input, "");
    //    pno++;
    //    parm[pno] = new OracleParameter();
    //    parm[pno] = _dbConfig.Oracle_Param("P_BENENAME", OracleType.VarChar, ParameterDirection.Input, beneName);
    //    pno++;
    //    parm[pno] = new OracleParameter();
    //    parm[pno] = _dbConfig.Oracle_Param("P_BENEADDRESS", OracleType.VarChar, ParameterDirection.Input, "");
    //    pno++;
    //    parm[pno] = new OracleParameter();
    //    parm[pno] = _dbConfig.Oracle_Param("P_CONTACTNUMBER", OracleType.VarChar, ParameterDirection.Input, "");
    //    pno++;
    //    parm[pno] = new OracleParameter();
    //    parm[pno] = _dbConfig.Oracle_Param("P_CNIC", OracleType.VarChar, ParameterDirection.Input, "");
    //    pno++;
    //    parm[pno] = new OracleParameter();
    //    parm[pno] = _dbConfig.Oracle_Param("P_REMENAME", OracleType.VarChar, ParameterDirection.Input, "");
    //    pno++;
    //    parm[pno] = new OracleParameter();
    //    parm[pno] = _dbConfig.Oracle_Param("P_DATEOFREME", OracleType.VarChar, ParameterDirection.Input, "");
    //    pno++;
    //    parm[pno] = new OracleParameter();
    //    parm[pno] = _dbConfig.Oracle_Param("P_CUSTOMERREFERENCENUMBER", OracleType.VarChar, ParameterDirection.Input, "");
    //    pno++;
    //    parm[pno] = new OracleParameter();
    //    parm[pno] = _dbConfig.Oracle_Param("P_ACCOUNTNUMBER", OracleType.VarChar, ParameterDirection.Input, AccountNO);
    //    pno++;
    //    parm[pno] = new OracleParameter();
    //    parm[pno] = _dbConfig.Oracle_Param("P_XPIN", OracleType.VarChar, ParameterDirection.Input, "");
    //    pno++;
    //    parm[pno] = new OracleParameter();
    //    parm[pno] = _dbConfig.Oracle_Param("P_COVERAMOUNT", OracleType.VarChar, ParameterDirection.Input, "");
    //    pno++;
    //    parm[pno] = new OracleParameter();
    //    parm[pno] = _dbConfig.Oracle_Param("P_EXCHANGERATE", OracleType.VarChar, ParameterDirection.Input, "");
    //    pno++;
    //    parm[pno] = new OracleParameter();
    //    parm[pno] = _dbConfig.Oracle_Param("P_TRANSAMOUNT", OracleType.VarChar, ParameterDirection.Input, "");
    //    pno++;
    //    parm[pno] = new OracleParameter();
    //    parm[pno] = _dbConfig.Oracle_Param("P_BANK", OracleType.VarChar, ParameterDirection.Input, "");
    //    pno++;
    //    parm[pno] = new OracleParameter();
    //    parm[pno] = _dbConfig.Oracle_Param("P_BANK_CODE", OracleType.VarChar, ParameterDirection.Input, "");
    //    pno++;
    //    parm[pno] = new OracleParameter();
    //    parm[pno] = _dbConfig.Oracle_Param("P_BRANCH_CODE", OracleType.VarChar, ParameterDirection.Input, "");
    //    pno++;
    //    parm[pno] = new OracleParameter();
    //    parm[pno] = _dbConfig.Oracle_Param("P_BRANCH_NAME", OracleType.VarChar, ParameterDirection.Input, "");
    //    pno++;
    //    parm[pno] = new OracleParameter();
    //    parm[pno] = _dbConfig.Oracle_Param("P_BRANCH_ADDRESS", OracleType.VarChar, ParameterDirection.Input, "");
    //    pno++;
    //    parm[pno] = new OracleParameter();
    //    parm[pno] = _dbConfig.Oracle_Param("P_FXCODE", OracleType.VarChar, ParameterDirection.Input, "");
    //    pno++;
    //    parm[pno] = new OracleParameter();
    //    parm[pno] = _dbConfig.Oracle_Param("P_COUNTRY", OracleType.VarChar, ParameterDirection.Input, "");
    //    pno++;
    //    parm[pno] = new OracleParameter();
    //    parm[pno] = _dbConfig.Oracle_Param("P_Userid", OracleType.VarChar, ParameterDirection.Input, Session["U_NAME"].ToString());
    //    pno++;
    //    parm[pno] = new OracleParameter();
    //    parm[pno] = _dbConfig.Oracle_Param("P_type", OracleType.VarChar, ParameterDirection.Input, Type);
    //    pno++;
    //    parm[pno] = new OracleParameter();
    //    parm[pno] = _dbConfig.Oracle_Param("P_Rowid", OracleType.VarChar, ParameterDirection.Input, rowid);
    //    pno++;
    //    parm[pno] = new OracleParameter();
    //    parm[pno] = _dbConfig.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
    //    pno++;
    //    parm[pno] = new OracleParameter();
    //    parm[pno] = _dbConfig.Oracle_Param("v_retval", OracleType.VarChar, ParameterDirection.Output, "");

    //    v_return = _dbConfig.Oracle_GetDataSetSP_DML("SP_Data_Segregation_updation", parm, pno);
    //    if (v_return.StartsWith("04") == false)
    //    {
    //        lblMessage.Text = v_return.Split(',').GetValue(1).ToString();
    //        return v_return;
    //    }
    //    else
    //    {
    //        lblMessage.Text = v_return.Split(',').GetValue(1).ToString();
    //    }
    //    //}
    //    return v_return;
    //}
    //public string postLeadger(OracleConnection conn, OracleTransaction tran)
    //{
    //    string v_return = "";
    //    OracleParameter[] parm = new OracleParameter[10];
    //    int pno = 0;
    //    parm[pno] = new OracleParameter();
    //    parm[pno] = _dbConfig.Oracle_Param("P_company_code", OracleType.VarChar, ParameterDirection.Input, ddlCompanyCode.SelectedValue.ToString());
    //    pno++;
    //    parm[pno] = new OracleParameter();
    //    parm[pno] = _dbConfig.Oracle_Param("P_FILE_NAME", OracleType.VarChar, ParameterDirection.Input, ddlFile.SelectedValue.ToString());
    //    pno++;
    //    parm[pno] = new OracleParameter();
    //    parm[pno] = _dbConfig.Oracle_Param("P_Trans_type", OracleType.VarChar, ParameterDirection.Input, "");
    //    pno++;
    //    parm[pno] = new OracleParameter();
    //    parm[pno] = _dbConfig.Oracle_Param("P_Rowid", OracleType.VarChar, ParameterDirection.Input, "");
    //    pno++;
    //    parm[pno] = new OracleParameter();
    //    parm[pno] = _dbConfig.Oracle_Param("p_bank_code", OracleType.VarChar, ParameterDirection.Input, "");
    //    pno++;
    //    parm[pno] = new OracleParameter();
    //    parm[pno] = _dbConfig.Oracle_Param("p_branch_code", OracleType.VarChar, ParameterDirection.Input, "");
    //    pno++;
    //    parm[pno] = new OracleParameter();
    //    parm[pno] = _dbConfig.Oracle_Param("P_Userid", OracleType.VarChar, ParameterDirection.Input, Session["U_NAME"].ToString());
    //    pno++;
    //    parm[pno] = new OracleParameter();
    //    parm[pno] = _dbConfig.Oracle_Param("P_type", OracleType.VarChar, ParameterDirection.Input, "14");
    //    pno++;
    //    parm[pno] = new OracleParameter();
    //    parm[pno] = _dbConfig.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
    //    pno++;
    //    parm[pno] = new OracleParameter();
    //    parm[pno] = _dbConfig.Oracle_Param("v_retval", OracleType.VarChar, ParameterDirection.Output, "");

    //    v_return = _dbConfig.TransSPOracle_GetReturnStringVal1(conn, tran, "SP_Data_Segregation", parm, pno);
    //    lblMessage.Text = v_return.Split(',').GetValue(1).ToString();
    //    return v_return;
    //}
    //protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    //{
    //    GridView1.EditIndex = e.NewEditIndex;
    //    loadGrid("S");
    //}
    //protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    //{
    //    GridView1.EditIndex = -1;
    //    loadGrid("S");
    //}
    //protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    string RowID = GridView1.SelectedRow.Cells[0].Text;
    //    //02 For Authorize
    //    spRow_Updation(RowID, "", "", "02");
    //    loadGrid("S");
    //}
    //protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    //{
    //string RowID = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[0].Controls[0])).Text;
    ////string CNIC = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[8].Controls[0])).Text;
    //string BeneName = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[6].Controls[0])).Text;
    //string AccountNO = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[9].Controls[0])).Text;
    ////02 For Update
    //spRow_Updation(RowID, BeneName, AccountNO, "01");
    //GridView1.EditIndex = -1;
    //loadGrid("S");
    //}
}

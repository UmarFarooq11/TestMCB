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

public partial class BranchIdentificy : System.Web.UI.Page
{
    string[] ARY;
    string RGS_SUPPORT;
    DatabaseConnection_Util _dbConfig = new DatabaseConnection_Util();
    LOV_COLLECTION lov = new LOV_COLLECTION();
    DataSet ds = new DataSet();
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
        { btnSubmit.Visible = false; /*ADD*/}
        else if (RGS_SUPPORT.Substring(0, 1) == "1")
        { btnSubmit.Visible = true; /*ADD*/}

        if (!Page.IsPostBack)
        {
            btnSubmit.Attributes.Add("style", "visibility:hidden;");
            txtAgnetCode.Attributes.Add("readonly", "readonly");
            txtAgentName.Attributes.Add("readonly", "readonly");
            btnSubmit.Attributes.Add("onclick", "return funConfirm();");

            lblFieldTrans.Attributes.Add("style", "visibility:hidden;");
            lblTransaction.Attributes.Add("style", "visibility:hidden;");
            lblTotalFile.Attributes.Add("style", "visibility:hidden;");
            lblTotalRecord.Attributes.Add("style", "visibility:hidden;");
            btnGetBranch.Attributes.Add("style", "visibility:hidden;");
            ddlCompanyBind();
            dllFilename();
        }
        //ScrolBar();
    }
    private void loadGrid(string check)
    {
        DataSet ds = new DataSet();
        OracleParameter[] parms = new OracleParameter[10];

        int pno = 0;
        parms[pno] = new OracleParameter();
        parms[pno] = _dbConfig.Oracle_Param("P_company_code", OracleType.VarChar, ParameterDirection.Input,ddlCompanyCode.SelectedValue.ToString());
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
        parms[pno] = _dbConfig.Oracle_Param("P_type", OracleType.VarChar, ParameterDirection.Input, "03");
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
                sort_table.DataSource = ds;
                sort_table.DataBind();
                ((TextBox)sort_table.Rows[0].FindControl("txtBranchCode")).Focus();
                //ViewState["TaskTable"] = sort_table.DataSource; 
                //dsbranch = lov.Get_CMN_Branch_LOV("%", "%");
                dsbranch = lov.Get_SP_Setup_Branch_lOV("%", "%");
                ViewState["dsbranch"] = dsbranch.Tables[0];
                onEnterPress();
                if (check !="S")
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
                sort_table.DataSource = null;
                sort_table.DataBind();
                lblTransaction.Text = ds.Tables[0].Rows.Count.ToString();
                lblFieldTrans.Attributes.Add("style", "visibility:hidden;");
                lblTransaction.Attributes.Add("style", "visibility:hidden;");
            }
            else
            {
                btnSubmit.Attributes.Add("style", "visibility:hidden;");
                sort_table.DataSource = null;
                sort_table.DataBind();
                lblMessage.Text = "No data found.";
                lblTransaction.Text = ds.Tables[0].Rows.Count.ToString();
                lblFieldTrans.Attributes.Add("style", "visibility:hidden;");
                lblTransaction.Attributes.Add("style", "visibility:hidden;");
            }
        }
        else
        {

        }
        #region
        //if (grdTransaction.Rows.Count <= 0)
        //{
        //    DataRow dr = ds.Tables[0].NewRow();
        //    ds.Tables[0].Rows.Add(dr);

        //    this.grdTransaction.DataSource = ds.Tables[0];
        //    this.grdTransaction.DataBind();

        //    this.grdTransaction.Rows[0].Cells.Clear();
        //    this.grdTransaction.Rows[0].Cells.Add(new TableCell());
        //    this.grdTransaction.Rows[0].Cells[0].ColumnSpan = grdTransaction.Rows[0].Cells.Count;
        //    this.grdTransaction.Rows[0].Cells[0].Text = "No Record found.";
        //}    
        #endregion
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
            Execute_sp();
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }
    public void Execute_sp()
    {
        string v_return = "";
        for (int i = 0; i < sort_table.Rows.Count; i++)
        {
            //string branchCode = ((HiddenField)sort_table.Rows[i].FindControl("hf_BranchCode")).Value;
            string branchCode = ((TextBox)sort_table.Rows[i].FindControl("txtBranchCode")).Text;
            if (branchCode != "")
            {
                branchCode = get_Branch(i);
            }
            OracleParameter[] parm = new OracleParameter[10];
            int pno = 0;
            if (branchCode != "" && branchCode != "0" && branchCode != "Branch not found")
            {
                parm[pno] = new OracleParameter();
                parm[pno] = _dbConfig.Oracle_Param("P_company_code", OracleType.VarChar, ParameterDirection.Input, ddlCompanyCode.SelectedValue.ToString());
                pno++;
                parm[pno] = new OracleParameter();
                parm[pno] = _dbConfig.Oracle_Param("P_FILE_NAME", OracleType.VarChar, ParameterDirection.Input, ddlFile.SelectedValue.ToString());
                pno++;
                parm[pno] = new OracleParameter();
                parm[pno] = _dbConfig.Oracle_Param("P_Trans_type", OracleType.VarChar, ParameterDirection.Input, sort_table.Rows[i].Cells[1].Text);
                pno++;
                parm[pno] = new OracleParameter();
                parm[pno] = _dbConfig.Oracle_Param("P_Rowid", OracleType.VarChar, ParameterDirection.Input, sort_table.Rows[i].Cells[0].Text);
                pno++;
                parm[pno] = new OracleParameter();
                parm[pno] = _dbConfig.Oracle_Param("p_bank_code", OracleType.VarChar, ParameterDirection.Input, "");
                pno++;
                parm[pno] = new OracleParameter();
                parm[pno] = _dbConfig.Oracle_Param("p_branch_code", OracleType.VarChar, ParameterDirection.Input, branchCode);
                pno++;
                parm[pno] = new OracleParameter();
                parm[pno] = _dbConfig.Oracle_Param("P_Userid", OracleType.VarChar, ParameterDirection.Input, Session["U_NAME"].ToString());
                pno++;
                parm[pno] = new OracleParameter();
                parm[pno] = _dbConfig.Oracle_Param("P_type", OracleType.VarChar, ParameterDirection.Input, "06");
                pno++;
                parm[pno] = new OracleParameter();
                parm[pno] = _dbConfig.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
                pno++;
                parm[pno] = new OracleParameter();
                parm[pno] = _dbConfig.Oracle_Param("v_retval", OracleType.VarChar, ParameterDirection.Output, "");

                v_return = _dbConfig.Oracle_GetDataSetSP_DML("SP_Data_Segregation", parm, pno);
                lblMessage.Text = v_return.Split(',').GetValue(1).ToString();
            }
        }
        /*if (v_return.Split(',').GetValue(0).ToString() == "04")
        {
            loadGrid("S");
        }*/
    }
    protected void btnAgent_Click(object sender, ImageClickEventArgs e)
    {
        //if (Session["COMPANY_CODE"].ToString() != "" && Session["COMPANY_CODE"].ToString() != "0")
        if (Session["LOV_ID"].ToString() != "")
        {
            txtAgnetCode.Text = Session["COMPANY_CODE"].ToString();
            txtAgentName.Text = Session["COMPANY_NAME"].ToString();
            DataSet ds = new DataSet();
            OracleParameter[] parms = new OracleParameter[3];
            parms[0] = _dbConfig.Oracle_Param("p_company_code", OracleType.VarChar, ParameterDirection.Input, txtAgnetCode.Text);
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
                sort_table.DataSource = null;
                sort_table.DataBind();


                lblTotalRecord.Attributes.Add("style", "visibility:hidden;");
                lblTotalFile.Attributes.Add("style", "visibility:hidden;");
                lblTransaction.Attributes.Add("style", "visibility:hidden;");
                lblFieldTrans.Attributes.Add("style", "visibility:hidden;");
            }
        }
    }
    protected void sort_table_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            ((ImageButton)e.Row.FindControl("btnLov")).Attributes.Add("onclick", "BankLOV(" + 
             e.Row.RowIndex + ",'" + hdRowIndex.ClientID + "')");
            //((TextBox)e.Row.FindControl("txtBranchCode")).Attributes.Add("onchange", "clickbtn(" + e.Row.RowIndex + ");");
            //((TextBox)e.Row.FindControl("txtBranchCode")).Attributes.Add("onkeypress", 
            //"if (event.keyCode==13) {document.getElementById('" + ((TextBox)e.Row.
            //FindControl("txtBranchCode")).ClientID + "').focus();return false;}");
            #region
            //if (e.Row.RowIndex == 0)
            //{
            //    ds = lov.Get_SP_Setup_Branch_lOV("%", "%");
            //}
            //((DropDownList)e.Row.FindControl("ddlBranch")).DataSource = ds;
            //((DropDownList)e.Row.FindControl("ddlBranch")).DataTextField = "Branch_Name";
            //((DropDownList)e.Row.FindControl("ddlBranch")).DataValueField = "Branch_Code";
            //((DropDownList)e.Row.FindControl("ddlBranch")).DataBind();
            #endregion
        }
    }
    public void onEnterPress()
    {
        for (int i = 0; i < sort_table.Rows.Count; i++)
        {
            if (i != 0)
            {
                ((TextBox)sort_table.Rows[i].FindControl("txtBranchCode")).Attributes.Add("onkeypress", "if (event.keyCode==46) {document.getElementById('" + ((TextBox)sort_table.Rows[i - 1].FindControl("txtBranchCode")).ClientID + "').focus();return false;}");
                //((TextBox)sort_table.Rows[i].FindControl("txtBranchCode")).Attributes.Add("onkeypress", "if (event.keyCode==38) {document.getElementById('" + ((TextBox)sort_table.Rows[i + 1].FindControl("txtBranchCode")).ClientID + "').focus();return false;}");
            }
            if (sort_table.Rows.Count - 1 > i)
            {
                ((TextBox)sort_table.Rows[i].FindControl("txtBranchCode")).Attributes.Add("onkeypress", "if (event.keyCode==13) {document.getElementById('" + ((TextBox)sort_table.Rows[i + 1].FindControl("txtBranchCode")).ClientID + "').focus();return false;}");
            }
            if (sort_table.Rows.Count - 1 == i)
            {
                ((TextBox)sort_table.Rows[i].FindControl("txtBranchCode")).Attributes.Add("onkeypress", "if (event.keyCode==13) {document.getElementById('" + ((ImageButton)sort_table.Rows[i].FindControl("btnLov")).ClientID + "').focus();return false;}");
            }
        }
    
    }
    protected void rpt_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item)
        {
            ((ImageButton)e.Item.FindControl("ImageButton1")).Attributes.Add("onclick", "rowsIndex('" + e.Item.ItemIndex + "');");
        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        if (Session["LOV_ID"].ToString() != "")
        {
            int i = Convert.ToInt16(hdRowIndex.Value);
            ((TextBox)sort_table.Rows[i].FindControl("txtBranchCode")).Text = Session["LOV_DESCRIPTION"].ToString();
            ((HiddenField)sort_table.Rows[i].FindControl("hf_BranchCode")).Value = Session["LOV_ID"].ToString();
        }
    }
    protected void btnLov_Click(object sender, ImageClickEventArgs e)
    {
        if (Session["LOV_ID"].ToString() != "")
        {
            int i = Convert.ToInt16(hdRowIndex.Value);
            //((TextBox)sort_table.Rows[i].FindControl("txtBranchCode")).Text = Session["LOV_DESCRIPTION"].ToString();
            ((TextBox)sort_table.Rows[i].FindControl("txtBranchCode")).Text = Session["LOV_ID"].ToString();
            //((TextBox)sort_table.Rows[i].FindControl("txtBranchCode")).ToolTip = Session["LOV_DESCRIPTION"].ToString();
            //((HiddenField)sort_table.Rows[i].FindControl("hf_BranchCode")).Value = Session["LOV_ID"].ToString();
            ((TextBox)sort_table.Rows[i].FindControl("txtBranchCode")).ForeColor = System.Drawing.Color.Blue;
        }
    }
    //protected void sort_table_PageIndexChanging(object sender, GridViewPageEventArgs e)
    //{
    //    //(List<YourObjects>)(Session["YourData"]);
    //    sort_table.PageIndex = e.NewPageIndex;
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
                    //lblTotalFile.Visible = true;
                    lblTotalFile.Attributes.Add("style", "visibility:visible;");
                    lblTotalRecord.Attributes.Add("style", "visibility:visible;");
                    //lblTotalRecord.Visible = true;
                }
            }
        }
        sort_table.DataSource = null;
        sort_table.DataBind();
        btnSubmit.Attributes.Add("style", "visibility:hidden;");
        //btnSubmit.Visible = false;
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
    protected void sort_table_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataTable dt = (DataTable)ViewState["TaskTable"];
        //DataTable dt = sort_table.DataSource as DataTable;
        
        if (dt != null)
        {
            dt.DefaultView.Sort = e.SortExpression + " " + GetSortDirection(e.SortExpression);
            sort_table.DataSource = ViewState["TaskTable"];
            sort_table.DataBind();
        }
        ((TextBox)sort_table.Rows[0].FindControl("txtBranchCode")).Focus();
        onEnterPress();
    }
    //protected void sort_table_PageIndexChanging(object sender, GridViewPageEventArgs e)
    //{
    //    string value, desc;
    //    DataTable dt = new DataTable();
    //    dt = (DataTable)ViewState["TaskTable"];
    //    for (int i = 0; i < sort_table.Rows.Count; i++)
    //    {
    //        value = ((HiddenField)sort_table.Rows[i].FindControl("hf_BranchCode")).Value;
    //        desc = ((TextBox)sort_table.Rows[i].FindControl("txtBranchCode")).Text;
    //        dt.Rows[i]["value"] = value;
    //        dt.Rows[i]["desc"] = desc;
    //    }
    //    sort_table.PageIndex = e.NewPageIndex;
    //    sort_table.DataSource = dt;
    //    sort_table.DataBind();



    //}
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
        //if (Session["LOV_ID"].ToString() != "")
        //{
        //txtAgnetCode.Text = Session["COMPANY_CODE"].ToString();
        //txtAgentName.Text = Session["COMPANY_NAME"].ToString();

        //}
    }
    public void dllFilename()
    {

        DataSet ds = new DataSet();
        OracleParameter[] parms = new OracleParameter[3];
        parms[0] = _dbConfig.Oracle_Param("p_company_code", OracleType.VarChar, ParameterDirection.Input, ddlCompanyCode.SelectedValue);
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
            ddlFile.DataSource = "";
            ddlFile.DataValueField = "";
            ddlFile.DataTextField = "";
            ddlFile.DataBind();

            btnSubmit.Attributes.Add("style", "visibility:hidden;");
            sort_table.DataSource = null;
            sort_table.DataBind();


            lblTotalRecord.Attributes.Add("style", "visibility:hidden;");
            lblTotalFile.Attributes.Add("style", "visibility:hidden;");
            lblTransaction.Attributes.Add("style", "visibility:hidden;");
            lblFieldTrans.Attributes.Add("style", "visibility:hidden;");
        }

    }
    protected void btnGetBranch_Click(object sender, EventArgs e)
    {
        int i = Convert.ToInt16(hdRowIndex.Value);
        DataTable dt = new DataTable();
        dt = (DataTable)ViewState["dsbranch"];
        string branchCode = ((TextBox)sort_table.Rows[i].FindControl("txtBranchCode")).Text;
        dt.DefaultView.RowFilter = "BRANCH_CODE='" + branchCode + "'";
        dt = dt.DefaultView.ToTable();
        if (dt.Rows.Count > 0 && dt.Rows[0][0].ToString() != "" && dt.Rows[0][0].ToString() !="")
        {
            ((TextBox)sort_table.Rows[i].FindControl("txtBranchCode")).Text = dt.Rows[0][1].ToString();
            ((TextBox)sort_table.Rows[i].FindControl("txtBranchCode")).ToolTip = dt.Rows[0][0].ToString() + " --- " + dt.Rows[0][1].ToString();
            ((HiddenField)sort_table.Rows[i].FindControl("hf_BranchCode")).Value = dt.Rows[0][0].ToString();
            ((TextBox)sort_table.Rows[i].FindControl("txtBranchCode")).ForeColor = System.Drawing.Color.Blue;
            if (sort_table.Rows.Count - 1 > i)
            {
                ((TextBox)sort_table.Rows[i + 1].FindControl("txtBranchCode")).Focus();
            }
        }
        else
        {
            ((TextBox)sort_table.Rows[i].FindControl("txtBranchCode")).ForeColor = System.Drawing.Color.Red;
            ((TextBox)sort_table.Rows[i].FindControl("txtBranchCode")).Text = "Branch not found";
            ((TextBox)sort_table.Rows[i].FindControl("txtBranchCode")).ToolTip = "Branch not found";
            ((HiddenField)sort_table.Rows[i].FindControl("hf_BranchCode")).Value = "";
            if (branchCode == "")
            {
                ((TextBox)sort_table.Rows[i].FindControl("txtBranchCode")).Text = "";
                ((TextBox)sort_table.Rows[i].FindControl("txtBranchCode")).ToolTip = "No Branch against this entry";
                ((TextBox)sort_table.Rows[i].FindControl("txtBranchCode")).ForeColor = System.Drawing.Color.Blue;
            }
            if (sort_table.Rows.Count - 1 > i)
            {
                ((TextBox)sort_table.Rows[i + 1].FindControl("txtBranchCode")).Focus();
            }
        }
    }
    public string get_Branch(int i)
    {
        //int i = Convert.ToInt16(hdRowIndex.Value);
        DataTable dt = new DataTable();
        dt = (DataTable)ViewState["dsbranch"];
        string branchCode = ((TextBox)sort_table.Rows[i].FindControl("txtBranchCode")).Text;
        dt.DefaultView.RowFilter = "BRANCH_CODE='" + branchCode + "'";
        dt = dt.DefaultView.ToTable();
        if (dt.Rows.Count > 0 && dt.Rows[0][0].ToString() != "" && dt.Rows[0][0].ToString() != "")
        {
            //((TextBox)sort_table.Rows[i].FindControl("txtBranchCode")).ForeColor = System.Drawing.Color.Blue;
            return branchCode;
            /*((TextBox)sort_table.Rows[i].FindControl("txtBranchCode")).Text = dt.Rows[0][1].ToString();
            ((TextBox)sort_table.Rows[i].FindControl("txtBranchCode")).ToolTip = dt.Rows[0][0].ToString() + " --- " + dt.Rows[0][1].ToString();
            ((HiddenField)sort_table.Rows[i].FindControl("hf_BranchCode")).Value = dt.Rows[0][0].ToString();
            ((TextBox)sort_table.Rows[i].FindControl("txtBranchCode")).ForeColor = System.Drawing.Color.Blue;
            if (sort_table.Rows.Count - 1 > i)
            {
                ((TextBox)sort_table.Rows[i + 1].FindControl("txtBranchCode")).Focus();
            }*/
        }
        else
        {
            //((TextBox)sort_table.Rows[i].FindControl("txtBranchCode")).ForeColor = System.Drawing.Color.Red;
            ((TextBox)sort_table.Rows[i].FindControl("txtBranchCode")).Text = "Branch not found";
            ((TextBox)sort_table.Rows[i].FindControl("txtBranchCode")).ToolTip = "Branch not found";
            return "";
            /*((HiddenField)sort_table.Rows[i].FindControl("hf_BranchCode")).Value = "";
            if (branchCode == "")
            {
                ((TextBox)sort_table.Rows[i].FindControl("txtBranchCode")).Text = "";
                ((TextBox)sort_table.Rows[i].FindControl("txtBranchCode")).ToolTip = "No Branch against this entry";
                ((TextBox)sort_table.Rows[i].FindControl("txtBranchCode")).ForeColor = System.Drawing.Color.Blue;
            }
            if (sort_table.Rows.Count - 1 > i)
            {
                ((TextBox)sort_table.Rows[i + 1].FindControl("txtBranchCode")).Focus();
            }*/
        }
    }
    public void getDataSort()
    {
        DataTable dt = (DataTable)ViewState["TaskTable"];
        for (int i = 0; i < sort_table.Rows.Count; i++)
        {
            dt.Rows[i]["branch_write"] = ((TextBox)sort_table.Rows[i].FindControl("txtBranchCode")).Text;
        }
        if (dt.Rows.Count > 0)
        {
            DataView dv = dt.DefaultView;
            if (this.ViewState["SortExpression"] != null)
            {
                dv.Sort = string.Format("{0} {1}", ViewState["SortExpression"].ToString(), 
                    this.ViewState["SortOrder"].ToString());
            }
            sort_table.DataSource = dt;
            sort_table.DataBind();
        }
    }
    protected void sort_table_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("Sort"))
        {
            if (ViewState["SortExpression"] != null)
            {
                if (this.ViewState["SortExpression"].ToString() == e.CommandArgument.ToString())
                {
                    if (ViewState["SortOrder"].ToString() == "ASC")
                        ViewState["SortOrder"] = "DESC";
                    else
                        ViewState["SortOrder"] = "ASC";
                }
                else
                {
                    ViewState["SortOrder"] = "ASC";
                    ViewState["SortExpression"] = e.CommandArgument.ToString();
                }
            }
            else
            {
                ViewState["SortExpression"] = e.CommandArgument.ToString();
                ViewState["SortOrder"] = "ASC";
            }
        }
        getDataSort();
        ((TextBox)sort_table.Rows[0].FindControl("txtBranchCode")).Focus();
    }
}

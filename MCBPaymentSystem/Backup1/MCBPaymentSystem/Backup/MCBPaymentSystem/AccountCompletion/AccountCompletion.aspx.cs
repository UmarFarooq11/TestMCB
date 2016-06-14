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

public partial class AccountCompletion_AccountCompletion : System.Web.UI.Page
{
    string[] ARY;
    string RGS_SUPPORT;
    string ROWID = "";
    int a;
    DatabaseConnection_Util _dbConfig = new DatabaseConnection_Util();
    LOV_COLLECTION lov = new LOV_COLLECTION();
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

        //if (RGS_SUPPORT.Substring(2, 1) == "0")
        //{ btnFetch.Visible = false; /*QUERY*/}
        //else if (RGS_SUPPORT.Substring(2, 1) == "1")
        //{ btnFetch.Visible = true; /*QUERY*/}

        if (!IsPostBack)
        {
            txtagent.Attributes.Add("readonly", "readonly");
            //  btnSubmit.Attributes.Add("style", "visibility:hidden;");
            btnSubmit.Attributes.Add("onclick", "return funConfirm();");
            lblFieldTrans.Attributes.Add("style", "visibility:hidden;");
            lblTransaction.Attributes.Add("style", "visibility:hidden;");
            lblTotalFile.Attributes.Add("style", "visibility:hidden;");
            lblTotalRecord.Attributes.Add("style", "visibility:hidden;");
            ddlCompanyBind();
            dllFilename();

            Panel1.Visible = false;
            Panel2.Visible = false;
            Panel3.Visible = false;
            Session["row"] = "";


        }
    }
    protected void Page_PreInit(object sender, EventArgs e)
    {
        Page.Theme = "SkinFile"; //Session["ThemeChange"].ToString(); 
    }
    protected void btnFetch_Click(object sender, EventArgs e)
    {
        //DataSet DS = new DataSet();
        //GridView1.DataSource = DS.Tables[0];
        //GridView1.DataBind();
        //GridView2.DataSource = DS.Tables[0];
        //GridView2.DataBind();
        //GridView3.DataSource = DS.Tables[0];
        //GridView3.DataBind();
        Page.Validate();
        if (Page.IsValid)
        {
            loadGridView1();
            loadGV_TransInfo();
            loadGV_AvalilableMatch();
        }


    }
    private void loadGridView1()
    {
        if (ddlFile.SelectedValue.ToString() != "")
        {
            DataSet ds = new DataSet();
            OracleParameter[] parms = new OracleParameter[10];

            parms[0] = new OracleParameter();
            parms[0] = _dbConfig.Oracle_Param("P_company_code", OracleType.VarChar, ParameterDirection.Input, ddlCompanyCode.SelectedValue.ToString());

            parms[1] = new OracleParameter();
            parms[1] = _dbConfig.Oracle_Param("P_FILE_NAME", OracleType.VarChar, ParameterDirection.Input, ddlFile.SelectedItem.ToString());

            parms[2] = new OracleParameter();
            parms[2] = _dbConfig.Oracle_Param("P_Trans_type", OracleType.VarChar, ParameterDirection.Input, "");

            parms[3] = new OracleParameter();
            parms[3] = _dbConfig.Oracle_Param("P_Rowid", OracleType.VarChar, ParameterDirection.Input, "");

            parms[4] = new OracleParameter();
            parms[4] = _dbConfig.Oracle_Param("p_bank_code", OracleType.VarChar, ParameterDirection.Input, "");
            parms[5] = new OracleParameter();
            parms[5] = _dbConfig.Oracle_Param("p_branch_code", OracleType.VarChar, ParameterDirection.Input, "");

            parms[6] = new OracleParameter();
            parms[6] = _dbConfig.Oracle_Param("P_Userid", OracleType.VarChar, ParameterDirection.Input, Session["U_NAME"].ToString());//Session["U_NAME"].ToString()

            parms[7] = new OracleParameter();
            parms[7] = _dbConfig.Oracle_Param("P_type", OracleType.VarChar, ParameterDirection.Input, "07");

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
                    //     ViewState["TaskTable"] = dt;
                    GridView1.DataSource = ds;
                    ////  GridView1.PageSize = 20;
                    GridView1.DataBind();
                    lblMessage.Text = "";
                    lblTransaction.Text = ds.Tables[0].Rows.Count.ToString();
                    btnSubmit.Attributes.Add("style", "visibility:visible;");
                    lblFieldTrans.Attributes.Add("style", "visibility:visible;");
                    lblTransaction.Attributes.Add("style", "visibility:visible;");
                    Panel1.Visible = true;

                }
                else
                {

                    DataRow dr = ds.Tables[0].NewRow();
                    ds.Tables[0].Rows.Add(dr);
                    GridView1.DataSource = ds;
                    GridView1.DataBind();
                    int Newcell = GridView1.Rows[0].Cells.Count;
                    GridView1.Rows[0].Cells.Clear();
                    GridView1.Rows[0].Cells.Add(new TableCell());
                    GridView1.Rows[0].Cells[0].ColumnSpan = Newcell;
                    GridView1.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
                    GridView1.Rows[0].Cells[0].Text = "No data found.";
                    Panel1.Visible = true;

                    // btnSubmit.Attributes.Add("style", "visibility:hidden;");
                    //GridView1.DataSource = null;
                    //GridView1.DataBind();
                    //lblMessage.Text = "No data found.";
                    //lblTransaction.Text = ds.Tables[0].Rows.Count.ToString();
                    //lblFieldTrans.Attributes.Add("style", "visibility:hidden;");
                    //lblTransaction.Attributes.Add("style", "visibility:hidden;");
                }
            }
        }
    }
    private void loadGV_TransInfo()
    {
        DataSet ds = new DataSet();
        OracleParameter[] parms = new OracleParameter[10];

        parms[0] = new OracleParameter();
        parms[0] = _dbConfig.Oracle_Param("P_company_code", OracleType.VarChar, ParameterDirection.Input, ddlCompanyCode.SelectedValue.ToString());

        parms[1] = new OracleParameter();
        parms[1] = _dbConfig.Oracle_Param("P_FILE_NAME", OracleType.VarChar, ParameterDirection.Input, ddlFile.SelectedItem.ToString());

        parms[2] = new OracleParameter();
        parms[2] = _dbConfig.Oracle_Param("P_Trans_type", OracleType.VarChar, ParameterDirection.Input, "");

        parms[3] = new OracleParameter();
        parms[3] = _dbConfig.Oracle_Param("P_Rowid", OracleType.VarChar, ParameterDirection.Input, "");

        parms[4] = new OracleParameter();
        parms[4] = _dbConfig.Oracle_Param("p_bank_code", OracleType.VarChar, ParameterDirection.Input, "");
        parms[5] = new OracleParameter();
        parms[5] = _dbConfig.Oracle_Param("p_branch_code", OracleType.VarChar, ParameterDirection.Input, "");

        parms[6] = new OracleParameter();
        parms[6] = _dbConfig.Oracle_Param("P_Userid", OracleType.VarChar, ParameterDirection.Input, Session["U_NAME"].ToString());//Session["U_NAME"].ToString()

        parms[7] = new OracleParameter();
        parms[7] = _dbConfig.Oracle_Param("P_type", OracleType.VarChar, ParameterDirection.Input, "08");

        parms[8] = new OracleParameter();
        parms[8] = _dbConfig.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        parms[9] = new OracleParameter();
        parms[9] = _dbConfig.Oracle_Param("v_retval", OracleType.VarChar, ParameterDirection.Output, "");
        ds = _dbConfig.Oracle_GetDataSetSP("SP_Data_Segregation", parms);

        if (parms[9].Value.ToString() == "")
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                Panel2.Visible = true;
                //DataTable dt = new DataTable();
                //dt = ds.Tables[0];
                //     ViewState["TaskTable"] = dt;
                GV_TransInfo.DataSource = ds;
                ////  GridView1.PageSize = 20;
                GV_TransInfo.DataBind();
                lblMessage.Text = "";
                lblTransaction.Text = ds.Tables[0].Rows.Count.ToString();
                // btnSubmit.Attributes.Add("style", "visibility:visible;");
                //  lblFieldTrans.Attributes.Add("style", "visibility:visible;");
                //  lblTransaction.Attributes.Add("style", "visibility:visible;");
            }
            else
            {
                DataRow dr = ds.Tables[0].NewRow();
                ds.Tables[0].Rows.Add(dr);
                GV_TransInfo.DataSource = ds;
                GV_TransInfo.DataBind();
                int Newcell = GV_TransInfo.Rows[0].Cells.Count;
                GV_TransInfo.Rows[0].Cells.Clear();
                GV_TransInfo.Rows[0].Cells.Add(new TableCell());
                GV_TransInfo.Rows[0].Cells[0].ColumnSpan = Newcell;
                GV_TransInfo.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
                GV_TransInfo.Rows[0].Cells[0].Text = "No data found.";
                Panel2.Visible = true;

                //  btnSubmit.Attributes.Add("style", "visibility:hidden;");
                //GV_TransInfo.DataSource = null;
                //GV_TransInfo.DataBind();
                //lblMessage.Text = "No data found.";
                //   lblTransaction.Text = ds.Tables[0].Rows.Count.ToString();
                //  lblFieldTrans.Attributes.Add("style", "visibility:hidden;");
                //  lblTransaction.Attributes.Add("style", "visibility:hidden;");
            }
        }
    }
    private void loadGV_AvalilableMatch()
    {
        DataSet ds = new DataSet();
        OracleParameter[] parms = new OracleParameter[10];

        parms[0] = new OracleParameter();
        parms[0] = _dbConfig.Oracle_Param("P_company_code", OracleType.VarChar, ParameterDirection.Input, ddlCompanyCode.SelectedValue.ToString());

        parms[1] = new OracleParameter();
        parms[1] = _dbConfig.Oracle_Param("P_FILE_NAME", OracleType.VarChar, ParameterDirection.Input, ddlFile.SelectedItem.ToString());

        parms[2] = new OracleParameter();
        parms[2] = _dbConfig.Oracle_Param("P_Trans_type", OracleType.VarChar, ParameterDirection.Input, "");

        parms[3] = new OracleParameter();
        parms[3] = _dbConfig.Oracle_Param("P_Rowid", OracleType.VarChar, ParameterDirection.Input, ROWID);

        parms[4] = new OracleParameter();
        parms[4] = _dbConfig.Oracle_Param("p_bank_code", OracleType.VarChar, ParameterDirection.Input, "");
        parms[5] = new OracleParameter();
        parms[5] = _dbConfig.Oracle_Param("p_branch_code", OracleType.VarChar, ParameterDirection.Input, "");

        parms[6] = new OracleParameter();
        parms[6] = _dbConfig.Oracle_Param("P_Userid", OracleType.VarChar, ParameterDirection.Input, Session["U_NAME"].ToString());//Session["U_NAME"].ToString()

        parms[7] = new OracleParameter();
        parms[7] = _dbConfig.Oracle_Param("P_type", OracleType.VarChar, ParameterDirection.Input, "11");

        parms[8] = new OracleParameter();
        parms[8] = _dbConfig.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        parms[9] = new OracleParameter();
        parms[9] = _dbConfig.Oracle_Param("v_retval", OracleType.VarChar, ParameterDirection.Output, "");
        ds = _dbConfig.Oracle_GetDataSetSP("SP_Data_Segregation", parms);

        if (parms[9].Value.ToString() == "")
        {
            if (ds.Tables[0].Rows.Count > 0)
            {

                //DataTable dt = new DataTable();
                //dt = ds.Tables[0];
                //     ViewState["TaskTable"] = dt;
                GV_AvalilableMatch.DataSource = ds;
                ////  GridView1.PageSize = 20;
                GV_AvalilableMatch.DataBind();
                lblMessage.Text = "";
                lblTransaction.Text = ds.Tables[0].Rows.Count.ToString();
                // btnSubmit.Attributes.Add("style", "visibility:visible;");
                //  lblFieldTrans.Attributes.Add("style", "visibility:visible;");
                //  lblTransaction.Attributes.Add("style", "visibility:visible;");
                Panel3.Visible = true;
            }
            else
            {
                DataRow dr = ds.Tables[0].NewRow();
                ds.Tables[0].Rows.Add(dr);
                GV_AvalilableMatch.DataSource = ds.Tables[0];
                GV_AvalilableMatch.DataBind();
                int Newcell = GV_AvalilableMatch.Rows[0].Cells.Count;
                GV_AvalilableMatch.Rows[0].Cells.Clear();
                GV_AvalilableMatch.Rows[0].Cells.Add(new TableCell());
                GV_AvalilableMatch.Rows[0].Cells[0].ColumnSpan = Newcell;
                GV_AvalilableMatch.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
                GV_AvalilableMatch.Rows[0].Cells[0].Text = "No data found.";
                Panel3.Visible = true;
                //btnSubmit.Attributes.Add("style", "visibility:hidden;");
                //GV_AvalilableMatch.DataSource = null;
                //GV_AvalilableMatch.DataBind();
                //lblMessage.Text = "No data found.";
                //   lblTransaction.Text = ds.Tables[0].Rows.Count.ToString();
                //  lblFieldTrans.Attributes.Add("style", "visibility:hidden;");
                //  lblTransaction.Attributes.Add("style", "visibility:hidden;");
            }
        }
    }
    private void process(string company_code, string FILE_NAME)
    {
        DataSet ds = new DataSet();
        OracleParameter[] param = new OracleParameter[4];
        param[0] = new OracleParameter();
        param[0] = _dbConfig.Oracle_Param("P_company_code", OracleType.VarChar, ParameterDirection.Input, company_code);
        param[1] = new OracleParameter();
        param[1] = _dbConfig.Oracle_Param("P_FILE_NAME", OracleType.VarChar, ParameterDirection.Input, FILE_NAME);
        param[2] = new OracleParameter();
        param[2] = _dbConfig.Oracle_Param("P_userid", OracleType.VarChar, ParameterDirection.Input, Session["U_NAME"].ToString());//Session["U_NAME"].ToString()
        param[3] = new OracleParameter();
        param[3] = _dbConfig.Oracle_Param("v_retval", OracleType.VarChar, ParameterDirection.Output, "");
        string return1 = _dbConfig.OracleExecuteSP_GetReturnVal("Account_Completion", param, 3).ToString();
        lblMessage.Text = return1.Split(';').GetValue(1).ToString();
        //string return1 = "1;Data successfully Proceed.";

    }
    private void submitdatagrid1()
    {
        DataSet ds = new DataSet();
        string retval;
        string[] returnval;
        OracleParameter[] parms = new OracleParameter[10];
        if (GridView1.Rows[0].Cells[0].Text != "No data found.")
        {
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                if (((CheckBox)GridView1.Rows[i].FindControl("Ckb_Select")).Checked == true)
                {
                    parms[0] = new OracleParameter();
                    parms[0] = _dbConfig.Oracle_Param("P_company_code", OracleType.VarChar, ParameterDirection.Input, ddlCompanyCode.SelectedValue.ToString());
                    parms[1] = new OracleParameter();
                    parms[1] = _dbConfig.Oracle_Param("P_FILE_NAME", OracleType.VarChar, ParameterDirection.Input, ddlFile.SelectedItem.ToString());
                    parms[2] = new OracleParameter();
                    parms[2] = _dbConfig.Oracle_Param("P_Trans_type", OracleType.VarChar, ParameterDirection.Input, "");
                    parms[3] = new OracleParameter();
                    parms[3] = _dbConfig.Oracle_Param("P_Rowid", OracleType.VarChar, ParameterDirection.Input, GridView1.Rows[i].Cells[0].Text);
                    parms[4] = new OracleParameter();
                    parms[4] = _dbConfig.Oracle_Param("p_bank_code", OracleType.VarChar, ParameterDirection.Input, "");
                    parms[5] = new OracleParameter();
                    parms[5] = _dbConfig.Oracle_Param("p_branch_code", OracleType.VarChar, ParameterDirection.Input, "");
                    parms[6] = new OracleParameter();
                    parms[6] = _dbConfig.Oracle_Param("P_Userid", OracleType.VarChar, ParameterDirection.Input, Session["U_NAME"].ToString());//Session["U_NAME"].ToString()
                    parms[7] = new OracleParameter();
                    parms[7] = _dbConfig.Oracle_Param("P_type", OracleType.VarChar, ParameterDirection.Input, "12");
                    parms[8] = new OracleParameter();
                    parms[8] = _dbConfig.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
                    parms[9] = new OracleParameter();
                    parms[9] = _dbConfig.Oracle_Param("v_retval", OracleType.VarChar, ParameterDirection.Output, "");
                    ds = _dbConfig.Oracle_GetDataSetSP("SP_Data_Segregation", parms);
                    retval = ds.Tables[0].Rows[0][0].ToString();
                    returnval = retval.Split(',');
                    lblMessage.Text = returnval[1].ToString();
                }
            }
        }
    }
    private void submitAvalilableMatch()
    {
        DataSet ds = new DataSet();
        string retval;
        string[] returnval;
        OracleParameter[] parms = new OracleParameter[10];
        if (GV_AvalilableMatch.Rows[0].Cells[0].Text != "No data found.")
        {
            for (int i = 0; i < GV_AvalilableMatch.Rows.Count; i++)
            {
                if (((CheckBox)GV_AvalilableMatch.Rows[i].FindControl("CkbGVA_Select")).Checked == true)
                {
                    parms[0] = new OracleParameter();
                    parms[0] = _dbConfig.Oracle_Param("P_company_code", OracleType.VarChar, ParameterDirection.Input, ddlCompanyCode.SelectedValue.ToString());
                    parms[1] = new OracleParameter();
                    parms[1] = _dbConfig.Oracle_Param("P_FILE_NAME", OracleType.VarChar, ParameterDirection.Input, ddlFile.SelectedItem.ToString());
                    parms[2] = new OracleParameter();
                    parms[2] = _dbConfig.Oracle_Param("P_Trans_type", OracleType.VarChar, ParameterDirection.Input, "");
                    parms[3] = new OracleParameter();
                    parms[3] = _dbConfig.Oracle_Param("P_Rowid", OracleType.VarChar, ParameterDirection.Input, GV_AvalilableMatch.Rows[i].Cells[0].Text);
                    parms[4] = new OracleParameter();
                    parms[4] = _dbConfig.Oracle_Param("p_bank_code", OracleType.VarChar, ParameterDirection.Input, GV_AvalilableMatch.Rows[i].Cells[6].Text);
                    parms[5] = new OracleParameter();
                    parms[5] = _dbConfig.Oracle_Param("p_branch_code", OracleType.VarChar, ParameterDirection.Input, ViewState["GV_Trans_AccountNo"].ToString());
                    parms[6] = new OracleParameter();
                    parms[6] = _dbConfig.Oracle_Param("P_Userid", OracleType.VarChar, ParameterDirection.Input, Session["U_NAME"].ToString());//Session["U_NAME"].ToString()
                    parms[7] = new OracleParameter();
                    parms[7] = _dbConfig.Oracle_Param("P_type", OracleType.VarChar, ParameterDirection.Input, "13");
                    parms[8] = new OracleParameter();
                    parms[8] = _dbConfig.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
                    parms[9] = new OracleParameter();
                    parms[9] = _dbConfig.Oracle_Param("v_retval", OracleType.VarChar, ParameterDirection.Output, "");
                    ds = _dbConfig.Oracle_GetDataSetSP("SP_Data_Segregation", parms);
                    retval = ds.Tables[0].Rows[0][0].ToString();
                    returnval = retval.Split(',');
                    lblMessage.Text = returnval[1].ToString();
                }
            }
        }
    }
    protected void btnCustomerCode_Click(object sender, ImageClickEventArgs e)
    {
        if (Session["COMPANY_CODE"].ToString() != "" && Session["COMPANY_CODE"].ToString() != "0")
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
                // btnSubmit.Attributes.Add("style", "visibility:hidden;");
                GridView1.DataSource = null;
                GridView1.DataBind();
                lblTotalRecord.Attributes.Add("style", "visibility:hidden;");
                lblTotalFile.Attributes.Add("style", "visibility:hidden;");
                lblTransaction.Attributes.Add("style", "visibility:hidden;");
                lblFieldTrans.Attributes.Add("style", "visibility:hidden;");
            }
        }
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
                    lblTotalFile.Attributes.Add("style", "visibility:visible;");
                    lblTotalRecord.Attributes.Add("style", "visibility:visible;");
                }
            }
        }

        GridView1.DataSource = null;
        GridView1.DataBind();

        GV_TransInfo.DataSource = null;
        GV_TransInfo.DataBind();
        GV_AvalilableMatch.DataSource = null;
        GV_AvalilableMatch.DataBind();
        Panel1.Visible = false;
        Panel2.Visible = false;
        Panel3.Visible = false;
        // btnSubmit.Attributes.Add("style", "visibility:hidden;");
        lblTransaction.Attributes.Add("style", "visibility:hidden;");
        lblFieldTrans.Attributes.Add("style", "visibility:hidden;");
        lblMessage.Text = "";
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        submitdatagrid1();
        submitAvalilableMatch();
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
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }
    private string GetSortDirection(string column)
    {
        string sortDirection = "ASC";
        string sortExpression = ViewState["sortExpression"] as string;
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
    protected void GV_TransInfo_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void btnprocess_Click(object sender, EventArgs e)
    {
        process(ddlCompanyCode.SelectedValue.ToString(), ddlFile.SelectedValue);
    }
    protected void GV_TransInfo_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        string BENENAME = ((LinkButton)e.CommandSource).Text;
        GridViewRow grv = ((GridViewRow)(((LinkButton)e.CommandSource).NamingContainer));
        a = grv.RowIndex;
        ROWID = grv.Cells[0].Text;
        ViewState["GV_Trans_AccountNo"] = grv.Cells[3].Text;
        loadGV_AvalilableMatch();
        GV_TransInfo.Rows[a].BackColor = System.Drawing.Color.DeepSkyBlue;
        GV_TransInfo.Rows[Convert.ToInt16(ViewState["row"])].BackColor = System.Drawing.Color.Empty;//"#D1DDF1"
        ViewState["row"] = a;

    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {

    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if ((e.Row.RowType == DataControlRowType.Header))
        {
            ((CheckBox)e.Row.FindControl("Ckb_SelectALL")).Attributes.Add("onclick", "javascript:SelectAll('" + ((CheckBox)e.Row.FindControl("Ckb_SelectALL")).ClientID + "')");
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
            // btnSubmit.Attributes.Add("style", "visibility:hidden;");
            GridView1.DataSource = null;
            GridView1.DataBind();
            lblTotalRecord.Attributes.Add("style", "visibility:hidden;");
            lblTotalFile.Attributes.Add("style", "visibility:hidden;");
            lblTransaction.Attributes.Add("style", "visibility:hidden;");
            lblFieldTrans.Attributes.Add("style", "visibility:hidden;");
        }

    }
    protected void GV_AvalilableMatch_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if ((e.Row.RowType == DataControlRowType.Header))
        {
            //((CheckBox)e.Row.FindControl("CkbGVA_SelectALL")).Attributes.Add("onclick", "javascript:SelectAllAVA('" + ((CheckBox)e.Row.FindControl("Ckb_Select")).ClientID + "')");
        }
    }
}

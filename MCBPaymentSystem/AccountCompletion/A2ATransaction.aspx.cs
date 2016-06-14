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

public partial class A2ATransaction : System.Web.UI.Page
{
    string[] ARY;
    string RGS_SUPPORT;
    DatabaseConnection_Util _dbConfig = new DatabaseConnection_Util();
    LOV_COLLECTION lov = new LOV_COLLECTION();
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
            ViewState["ConnectionString"] = _dbConfig.ConnectionString;


            btnSubmit.Attributes.Add("style", "visibility:hidden;");
            btnSubmit.Attributes.Add("onclick", "return funConfirm();");
            lblFieldTrans.Attributes.Add("style", "visibility:hidden;");
            lblTransaction.Attributes.Add("style", "visibility:hidden;");
            lblTotalFile.Attributes.Add("style", "visibility:hidden;");
            lblTotalRecord.Attributes.Add("style", "visibility:hidden;");

            lblStart.Attributes.Add("style", "visibility:hidden;");
            lblStartTrans.Attributes.Add("style", "visibility:hidden;");
            lblEnd.Attributes.Add("style", "visibility:hidden;");
            lblEndTrans.Attributes.Add("style", "visibility:hidden;");

            ddlCompanyBind();
            dllFilename();
        }
    }
    public void ddlCompanyBind()
    {
        DataSet ds = new DataSet();

        ds = lov.Get_Company_setup_lov("%", "%");
        if (ds.Tables[0].Rows.Count > 0)
        {
            DataTable dt = new DataTable();
            DataRow dr = null;
            dr = ds.Tables[0].NewRow();
            dr[2] = "AAA";
            dr[3] = "Select";
            ds.Tables[0].Rows.Add(dr);
            dt = ds.Tables[0];
            dt.DefaultView.Sort = "Company_Code ASC";
            dt = dt.DefaultView.ToTable();

            ddlCompanyCode.DataSource = dt;
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
        DataRow dr = null;
        OracleParameter[] parms = new OracleParameter[3];
        parms[0] = _dbConfig.Oracle_Param("p_company_code", OracleType.VarChar, ParameterDirection.Input, ddlCompanyCode.SelectedValue.ToString());
        parms[1] = _dbConfig.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        parms[2] = _dbConfig.Oracle_Param("v_retval", OracleType.VarChar, ParameterDirection.Output, "");
        ds = _dbConfig.Oracle_GetDataSetSP("SP_Data_Segregation_LOV_a2a", parms);
        if (ds.Tables[0].Rows.Count > 0)
        {
            DataTable dt = new DataTable();
            dr = ds.Tables[0].NewRow();
            dr[0] = "AAA";
            dr[1] = "Select";
            dr[2] = "Select";
            dr[3] = "0";
            ds.Tables[0].Rows.Add(dr);
            dt = ds.Tables[0];
            dt.DefaultView.Sort = "Company_Code ASC";
            dt = dt.DefaultView.ToTable();

            ddlFile.DataSource = dt;
            ddlFile.DataValueField = "FILE_NAME";
            ddlFile.DataTextField = "FILE_NAME";
            ddlFile.DataBind();
            ViewState["dataset"] = dt;
            lblTotalRecord.Text = dt.Rows[0]["total_records"].ToString();
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

            lblStart.Attributes.Add("style", "visibility:hidden;");
            lblStartTrans.Attributes.Add("style", "visibility:hidden;");
            lblEnd.Attributes.Add("style", "visibility:hidden;");
            lblEndTrans.Attributes.Add("style", "visibility:hidden;");
        }

    }
    public void transSeq(string company_code, string file_name)
    {
        DataSet ds = new DataSet();
        OracleParameter[] parm = new OracleParameter[3];
        int pno = 0;
        parm[pno] = new OracleParameter();
        parm[pno] = _dbConfig.Oracle_Param("P_COMPANY_CODE", OracleType.VarChar, ParameterDirection.Input, company_code);
        pno++;
        parm[pno] = new OracleParameter();
        parm[pno] = _dbConfig.Oracle_Param("P_FILE_NAME", OracleType.VarChar, ParameterDirection.Input, file_name);
        pno++;
        parm[pno] = new OracleParameter();
        parm[pno] = _dbConfig.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        ds = _dbConfig.Oracle_GetDataSetSP("sp_trans_sequence", parm);
        if (ds.Tables[0].Rows.Count > 0)
        {
            lblStartTrans.Text = ds.Tables[0].Rows[0]["min_trans"].ToString();
            lblEndTrans.Text = ds.Tables[0].Rows[0]["max_trans"].ToString();
            lblStart.Attributes.Add("style", "visibility:visible;");
            lblStartTrans.Attributes.Add("style", "visibility:visible;");
            lblEndTrans.Attributes.Add("style", "visibility:visible;");
            lblEnd.Attributes.Add("style", "visibility:visible;");
        }
        else
        {
            lblStartTrans.Text = "Not found data.";
        }


    }
    public void FetchDataValidation()
    {
        if (txtFromDate.Text != "" && txtToDate.Text != "" && ddlCompanyCode.SelectedValue == "AAA")
        {
            lblMessage.Text = "Please select Agent.";
            return;
        }
        string file_name = (ddlCompanyCode.SelectedValue == "AAA" ? "" : (ddlFile.Items.Count == 0 ? "" : (ddlFile.SelectedItem.Text == "Select" ? "" : ddlFile.SelectedItem.Text)));
        string company_code = (ddlCompanyCode.SelectedValue == "AAA" ? "" : ddlCompanyCode.SelectedValue);
        //loadGrid("Q", company_code, file_name, txtFromDate.Text, txtToDate.Text, txtCNIC.Text, txtAccountNo.Text, txtCustomerRefNo.Text);
        loadGrid("Q", company_code, file_name, txtFromDate.Text, txtToDate.Text, "", "", "");
    }
    public void loadGrid(string check, string company_code, string filename, string from_date, string to_date,
    string cnic, string acccount_no, string cust_ref_no)
    {
        //if (ddlFile.SelectedValue != "")
        //{
        DataSet ds = new DataSet();
        #region
        /*OracleParameter[] parms = new OracleParameter[10];
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
            parms[pno] = _dbConfig.Oracle_Param("P_type", OracleType.VarChar, ParameterDirection.Input, "20");
            pno++;

            parms[pno] = new OracleParameter();
            parms[pno] = _dbConfig.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
            pno++;

            parms[pno] = new OracleParameter();
            parms[pno] = _dbConfig.Oracle_Param("v_retval", OracleType.VarChar, ParameterDirection.Output, "");

            ds = _dbConfig.Oracle_GetDataSetSP("SP_Data_Segregation", parms);*/
        #endregion
        OracleParameter[] parms = new OracleParameter[9];
        int pno = 0;
        parms[pno] = _dbConfig.Oracle_Param("P_company_code", OracleType.VarChar, ParameterDirection.Input, company_code);
        pno++;
        parms[pno] = _dbConfig.Oracle_Param("p_file_name", OracleType.VarChar, ParameterDirection.Input, filename);
        pno++;
        parms[pno] = _dbConfig.Oracle_Param("p_from_date", OracleType.VarChar, ParameterDirection.Input, from_date);
        pno++;
        parms[pno] = _dbConfig.Oracle_Param("p_to_date", OracleType.VarChar, ParameterDirection.Input, to_date);
        pno++;
        parms[pno] = _dbConfig.Oracle_Param("p_cnic", OracleType.VarChar, ParameterDirection.Input, cnic);
        pno++;
        parms[pno] = _dbConfig.Oracle_Param("p_account_no", OracleType.VarChar, ParameterDirection.Input, acccount_no);
        pno++;
        parms[pno] = _dbConfig.Oracle_Param("p_cust_ref_no", OracleType.VarChar, ParameterDirection.Input, cust_ref_no);
        pno++;
        parms[pno] = _dbConfig.Oracle_Param("data_resultset", OracleType.Cursor, ParameterDirection.Output, "");
        pno++;
        parms[pno] = _dbConfig.Oracle_Param("p_retval", OracleType.VarChar, ParameterDirection.Output, "");
        ds = _dbConfig.Oracle_GetDataSetSP("sp_a2a_trans_fetch", parms);
        if (parms[pno].Value.ToString() == "")
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                ViewState["TaskTable"] = dt;
                ViewState["DataTable"] = dt;
                GridView1.DataSource = ds;
                GridView1.DataBind();

                btnSubmit.Attributes.Add("style", "visibility:visible;");
                //lblMessage.Text = "";

                lblTransaction.Text = ds.Tables[0].Rows.Count.ToString();
                lblFieldTrans.Attributes.Add("style", "visibility:visible;");
                lblTransaction.Attributes.Add("style", "visibility:visible;");
            }
            else if (check == "S")
            {
                btnSubmit.Attributes.Add("style", "visibility:hidden;");
                GridView1.DataSource = null;
                GridView1.DataBind();
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
            }
        }
        else
        {
            lblMessage.Text = "No Data return SP";
        }
        //}
    }
    public string Execute_sp()
    {
        string v_return = "";
        DBUniversalUploadProcess Upload = new DBUniversalUploadProcess();
        v_return = Upload.A2ATransaction(GridView1.Rows.Count, ddlCompanyCode.SelectedValue, ddlFile.SelectedValue, GridView1);
        lblMessage.Text = v_return;
        #region
        //for (int i = 0; i < GridView1.Rows.Count; i++)
        //{
        //    //if (((CheckBox)GridView1.Rows[i].FindControl("cbPublish")).Checked == true)
        //    //{
        //    OracleParameter[] parm = new OracleParameter[4];
        //    int pno = 0;
        //    parm[pno] = _dbConfig.Oracle_Param("p_company_code", OracleType.VarChar, ParameterDirection.Input, ddlCompanyCode.SelectedValue);
        //    pno++;
        //    parm[pno] = _dbConfig.Oracle_Param("p_file_name", OracleType.VarChar, ParameterDirection.Input, ddlFile.SelectedValue);
        //    pno++;
        //    parm[pno] = _dbConfig.Oracle_Param("p_row_id", OracleType.VarChar, ParameterDirection.Input, GridView1.Rows[i].Cells[0].Text);
        //    pno++;
        //    parm[pno] = _dbConfig.Oracle_Param("p_retval", OracleType.VarChar, ParameterDirection.Output, "");
        //    v_return = _dbConfig.OracleExecuteSP_GetReturnVal("corebank_system_int_symbol", parm, pno);
        //    lblMessage.Text = v_return.Split(';').GetValue(1).ToString();
        //    /*if (v_return.StartsWith("0") == false)
        //    {
        //        lblMessage.Text = v_return.Split(';').GetValue(1).ToString();
        //    }*/
        //    //}
        //}
        #endregion
        return v_return;
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
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Page.Validate();
        if (Page.IsValid)
        {
            FetchDataValidation();
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            Execute_sp();
            FetchDataValidation();
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }
    protected void ddlCompanyCode_SelectedIndexChanged(object sender, EventArgs e)
    {
        dllFilename();
        lblMessage.Text = "";
    }
    protected void ddlFile_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        dt = (DataTable)ViewState["dataset"];
        if (dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (ddlFile.SelectedValue.ToString() == dt.Rows[i]["FILE_NAME"].ToString())
                {
                    lblTotalRecord.Text = dt.Rows[i]["total_records"].ToString();
                    lblTotalFile.Visible = true;
                    lblTotalRecord.Visible = true;
                }
            }
            txtFromDate.Text = "";
            txtToDate.Text = "";
            txtAccountNo.Text = "";
            txtCNIC.Text = "";
            txtCustomerRefNo.Text = "";
        }
        GridView1.DataSource = null;
        GridView1.DataBind();
        btnSubmit.Attributes.Add("style", "visibility:hidden;");
        lblTransaction.Attributes.Add("style", "visibility:hidden;");
        lblFieldTrans.Attributes.Add("style", "visibility:hidden;");
        lblStart.Attributes.Add("style", "visibility:hidden;");
        lblStartTrans.Attributes.Add("style", "visibility:hidden;");
        lblEnd.Attributes.Add("style", "visibility:hidden;");
        lblEndTrans.Attributes.Add("style", "visibility:hidden;");
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
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if ((e.Row.RowType == DataControlRowType.Header))
        {
            ((CheckBox)e.Row.FindControl("Ckb_SelectALL")).Attributes.Add("onclick", "javascript:SelectAll('" + ((CheckBox)e.Row.FindControl("Ckb_SelectALL")).ClientID + "')");
        }
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        txtFromDate.Text = "";
        txtToDate.Text = "";
        txtCNIC.Text = "";
        txtAccountNo.Text = "";
        txtCustomerRefNo.Text = "";
        lblMessage.Text = "";
        GridView1.DataSource = null;
        GridView1.DataBind();
        ddlCompanyCode.SelectedIndex = 0;
        btnSubmit.Attributes.Add("style", "visibility:hidden;");
        if (ddlFile.Items.Count > 0)
        {
            dllFilename();
        }
    }
}

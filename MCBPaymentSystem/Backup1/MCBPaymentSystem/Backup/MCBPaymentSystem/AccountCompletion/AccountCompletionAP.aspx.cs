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

public partial class AccountCompletionAP : System.Web.UI.Page
{
    string[] ARY;
    string RGS_SUPPORT;
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
            btnSubmit.Attributes.Add("onclick", "return funConfirm();");
            lblFieldTrans.Attributes.Add("style", "visibility:hidden;");
            lblTransaction.Attributes.Add("style", "visibility:hidden;");
            lblTotalFile.Attributes.Add("style", "visibility:hidden;");
            lblTotalRecord.Attributes.Add("style", "visibility:hidden;");
            ddlCompanyBind();
            dllFilename();
            Panel1.Visible = false;
        }
    }
    protected void Page_PreInit(object sender, EventArgs e)
    {
        Page.Theme = "SkinFile"; //Session["ThemeChange"].ToString(); 
    }
    private void loadGridView1()
    {
        if (ddlFile.SelectedValue.ToString() != "")
        {
            DataSet ds = new DataSet();
            OracleParameter[] parms = new OracleParameter[3];
            parms[0] = _dbConfig.Oracle_Param("p_company_code", OracleType.VarChar, ParameterDirection.Input, ddlCompanyCode.SelectedValue.ToString());
            parms[1] = _dbConfig.Oracle_Param("p_file_name", OracleType.VarChar, ParameterDirection.Input, ddlFile.SelectedItem.ToString());
            parms[2] = _dbConfig.Oracle_Param("p_data_set", OracleType.Cursor, ParameterDirection.Output, "");
            ds = _dbConfig.Oracle_GetDataSetSP("sp_get_acc_completion_publish", parms);
            if (ds.Tables[0].Rows.Count > 0)
            {
                GridView1.DataSource = ds;
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
                Panel1.Visible = true;
            }
        }
    }
    protected void btnFetch_Click(object sender, EventArgs e)
    {
        Page.Validate();
        if (Page.IsValid)
        {
            loadGridView1();
        }
    }
    private void ExecuteGridView1()
    {
        DataSet ds = new DataSet();
        string retval;
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            if (((CheckBox)GridView1.Rows[i].FindControl("Ckb_Select")).Checked == true)
            {
                OracleParameter[] parms = new OracleParameter[5];
                parms[0] = _dbConfig.Oracle_Param("p_company_code", OracleType.VarChar, ParameterDirection.Input, ddlCompanyCode.SelectedValue.ToString());
                parms[1] = _dbConfig.Oracle_Param("p_file_name", OracleType.VarChar, ParameterDirection.Input, ddlFile.SelectedItem.ToString());
                parms[2] = _dbConfig.Oracle_Param("p_rowid", OracleType.VarChar, ParameterDirection.Input, GridView1.Rows[i].Cells[0].Text);
                parms[3] = _dbConfig.Oracle_Param("p_userid", OracleType.VarChar, ParameterDirection.Input, Session["U_NAME"].ToString());//Session["U_NAME"].ToString()
                parms[4] = _dbConfig.Oracle_Param("p_retval", OracleType.VarChar, ParameterDirection.Output, "");
                retval = _dbConfig.OracleExecuteSP_GetReturnVal("sp_acc_comp_publish_submit", parms, 4);
                lblMessage.Text = retval.Split(',')[1].ToString();
            }
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        ExecuteGridView1();
    }
    private void process(string company_code, string file_name)
    {
        DataSet ds = new DataSet();
        OracleParameter[] param = new OracleParameter[4];
        param[0] = _dbConfig.Oracle_Param("p_company_code", OracleType.VarChar, ParameterDirection.Input, company_code);
        param[1] = _dbConfig.Oracle_Param("p_file_name", OracleType.VarChar, ParameterDirection.Input, file_name);
        param[2] = _dbConfig.Oracle_Param("p_userid", OracleType.VarChar, ParameterDirection.Input, Session["U_NAME"].ToString());//Session["U_NAME"].ToString()
        param[3] = _dbConfig.Oracle_Param("p_retval", OracleType.VarChar, ParameterDirection.Output, "");
        string p_return = _dbConfig.OracleExecuteSP_GetReturnVal("account_completion_publish", param, 3).ToString();
        lblMessage.Text = p_return.Split(';')[1].ToString();
    }
    protected void btnprocess_Click(object sender, EventArgs e)
    {
        process(ddlCompanyCode.SelectedValue.ToString(), ddlFile.SelectedValue);
    }
    public void dllFilename()
    {
        DataSet ds = new DataSet();
        OracleParameter[] parms = new OracleParameter[3];
        parms[0] = _dbConfig.Oracle_Param("p_company_code", OracleType.VarChar, ParameterDirection.Input, ddlCompanyCode.SelectedValue.ToString());
        parms[1] = _dbConfig.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        parms[2] = _dbConfig.Oracle_Param("v_retval", OracleType.VarChar, ParameterDirection.Output, "");
        ds = _dbConfig.Oracle_GetDataSetSP("sp_data_segregation_lov_a2a", parms);
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
                    lblTotalFile.Attributes.Add("style", "visibility:visible;");
                    lblTotalRecord.Attributes.Add("style", "visibility:visible;");
                }
            }
        }
        GridView1.DataSource = null;
        GridView1.DataBind();
        //GV_TransInfo.DataSource = null;
        //GV_TransInfo.DataBind();
        //GV_AvalilableMatch.DataSource = null;
        //GV_AvalilableMatch.DataBind();
        Panel1.Visible = false;
        //Panel2.Visible = false;
        //Panel3.Visible = false;
        lblTransaction.Attributes.Add("style", "visibility:hidden;");
        lblFieldTrans.Attributes.Add("style", "visibility:hidden;");
        lblMessage.Text = "";
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if ((e.Row.RowType == DataControlRowType.Header))
        {
            ((CheckBox)e.Row.FindControl("Ckb_SelectALL")).Attributes.Add("onclick", "javascript:SelectAll('" + ((CheckBox)e.Row.FindControl("Ckb_SelectALL")).ClientID + "')");
        }
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
}
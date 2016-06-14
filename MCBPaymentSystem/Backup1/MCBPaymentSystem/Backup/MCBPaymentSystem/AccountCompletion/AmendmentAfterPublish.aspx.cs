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

public partial class AmendmentAfterPublish : System.Web.UI.Page
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
        {
            //btnSearch.Visible = false; /*ADD*/
        }
        else if (RGS_SUPPORT.Substring(0, 1) == "1")
        {
            //btnSearch.Visible = true; /*ADD*/
        }
        if (RGS_SUPPORT.Substring(4, 1) == "0")
        {
            Session["Authorize"] = "false";
        }
        else if (RGS_SUPPORT.Substring(4, 1) == "1")
        {
            Session["Authorize"] = "true";
        }
        if (!Page.IsPostBack)
        {
            ViewState["ConnectionString"] = _dbConfig.ConnectionString;
            lblFieldTrans.Attributes.Add("style", "visibility:hidden;");
            lblTransaction.Attributes.Add("style", "visibility:hidden;");
            lblTotalFile.Attributes.Add("style", "visibility:hidden;");
            lblTotalRecord.Attributes.Add("style", "visibility:hidden;");
            ddlCompanyBind();
            dllFilename();
            Panel1.Attributes.Add("style", "visibility:hidden;");
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
    public void dllFilename()
    {
        DataSet ds = new DataSet();
        OracleParameter[] parms = new OracleParameter[3];
        parms[0] = _dbConfig.Oracle_Param("p_company_code", OracleType.VarChar, ParameterDirection.Input, ddlCompanyCode.SelectedValue.ToString());
        parms[1] = _dbConfig.Oracle_Param("data_resultset", OracleType.Cursor, ParameterDirection.Output, "");
        parms[2] = _dbConfig.Oracle_Param("v_retval", OracleType.VarChar, ParameterDirection.Output, "");
        ds = _dbConfig.Oracle_GetDataSetSP("sp_data_segregation_lov_a2a", parms);
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlFile.DataSource = ds.Tables[0];
            ddlFile.DataValueField = "file_name";
            ddlFile.DataTextField = "file_name";
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
            OracleParameter[] parms = new OracleParameter[3];
            parms[0] = _dbConfig.Oracle_Param("P_company_code", OracleType.VarChar, ParameterDirection.Input, ddlCompanyCode.SelectedValue.ToString());
            parms[1] = _dbConfig.Oracle_Param("p_file_name", OracleType.VarChar, ParameterDirection.Input, ddlFile.SelectedItem == null ? "" : ddlFile.SelectedItem.ToString());
            parms[2] = _dbConfig.Oracle_Param("p_data_set", OracleType.Cursor, ParameterDirection.Output, "");
            ds = _dbConfig.Oracle_GetDataSetSP("sp_get_a2a_trans", parms);
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                ViewState["TaskTable"] = dt;
                GridView1.DataSource = ds;
                GridView1.DataBind();
                Panel1.Attributes.Add("style", "visibility:visible;");
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
                GridView1.DataSource = null;
                GridView1.DataBind();
                Panel1.Attributes.Add("style", "visibility:hidden;");
                lblTransaction.Text = ds.Tables[0].Rows.Count.ToString();
                lblFieldTrans.Attributes.Add("style", "visibility:hidden;");
                lblTransaction.Attributes.Add("style", "visibility:hidden;");
            }
            else
            {
                GridView1.DataSource = null;
                GridView1.DataBind();
                lblMessage.Text = "No data found.";
                lblTransaction.Text = ds.Tables[0].Rows.Count.ToString();
                lblFieldTrans.Attributes.Add("style", "visibility:hidden;");
                lblTransaction.Attributes.Add("style", "visibility:hidden;");
                Panel1.Attributes.Add("style", "visibility:hidden;");
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
    public string spRow_Updation(string rowid, string beneName, string AccountNO, string beneid, string Type)
    {
        string v_return = "";
        OracleParameter[] parm = new OracleParameter[7];
        parm[0] = _dbConfig.Oracle_Param("p_benename", OracleType.VarChar, ParameterDirection.Input, beneName); 
        parm[1] = _dbConfig.Oracle_Param("p_accountnumber", OracleType.VarChar, ParameterDirection.Input, AccountNO); 
        parm[2] = _dbConfig.Oracle_Param("p_beneficiaryid", OracleType.VarChar, ParameterDirection.Input, beneid); 
        parm[3] = _dbConfig.Oracle_Param("p_userid", OracleType.VarChar, ParameterDirection.Input, Session["U_NAME"].ToString()); 
        parm[4] = _dbConfig.Oracle_Param("p_type", OracleType.VarChar, ParameterDirection.Input, Type); 
        parm[5] = _dbConfig.Oracle_Param("p_rowid", OracleType.VarChar, ParameterDirection.Input, rowid); 
        parm[6] = _dbConfig.Oracle_Param("p_retval", OracleType.VarChar, ParameterDirection.Output, "");
        v_return = _dbConfig.Oracle_GetDataSetSP_DML("sp_amedment_afterPublish", parm, 6);
        if (v_return.StartsWith("04") == false)
        {
            lblMessage.Text = v_return.Split(',').GetValue(1).ToString();
            return v_return;
        }
        else
        {
            lblMessage.Text = v_return.Split(',').GetValue(1).ToString();
        }
        return v_return;
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
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (Session["Authorize"].ToString() == "true")
            {
                e.Row.Cells[16].CssClass = "hidden";  //Edit link button false
                LinkButton linkBtn = (LinkButton)(e.Row.Cells[17].Controls[0]);
                if (e.Row.Cells[14].Text == "Un-Authorized") //Check transaction Un-Authorized?
                {
                    if (linkBtn.Text == "Authorize") linkBtn.Attributes.Add("onclick", "return OnConfirmAuth();");
                }
                else
                {
                    linkBtn.Enabled = false;
                }
            }
            else if (Session["Authorize"].ToString() == "false")
            {
                e.Row.Cells[17].CssClass = "hidden";    //Authorize link button false
                LinkButton linkBtn = (LinkButton)(e.Row.Cells[16].Controls[0]);
                if (linkBtn.Text == "Update") linkBtn.Attributes.Add("onclick", "return OnConfirmGV();");
            }
        }
        else if (e.Row.RowType == DataControlRowType.Header)
        {
            if (Session["Authorize"].ToString() == "true")
            {
                //e.Row.Cells[15].CssClass = "hidden"; //Header Edit false
                e.Row.Cells[16].CssClass = "hidden"; //Header Edit false
            }
            else if (Session["Authorize"].ToString() == "false")
            {
                //e.Row.Cells[16].CssClass = "hidden"; //Header Authorize false
                e.Row.Cells[17].CssClass = "hidden"; //Header Authorize false
            }
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
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string RowID = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[0].Controls[0])).Text;
        string BeneName = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[6].Controls[0])).Text;
        string AccountNO = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[9].Controls[0])).Text;
        string beneid = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[18].Controls[0])).Text;
        spRow_Updation(RowID, BeneName, AccountNO, beneid, "01");
        GridView1.EditIndex = -1;
        loadGrid("S");
    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        loadGrid("S");
    }
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        loadGrid("S");
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        string RowID = GridView1.SelectedRow.Cells[0].Text;
        spRow_Updation(RowID, "", "", "", "02");
        loadGrid("S");
    }
}

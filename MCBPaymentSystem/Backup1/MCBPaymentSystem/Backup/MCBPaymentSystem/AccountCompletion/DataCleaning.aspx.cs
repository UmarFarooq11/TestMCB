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

public partial class DataCleaning : System.Web.UI.Page
{
    string[] ARY;
    string RGS_SUPPORT;
    DatabaseConnection_Util _dbConfig = new DatabaseConnection_Util();
    LOV_COLLECTION lov = new LOV_COLLECTION();
    DataSet ds = new DataSet();
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
            btnCleaning.Visible = false; /*ADD*/
        }
        else if (RGS_SUPPORT.Substring(0, 1) == "1")
        { btnCleaning.Visible = true; /*ADD*/}

        if (!Page.IsPostBack)
        {
            //btnCleaning.Enabled = false;


            btnCleaning.Attributes.Add("style", "visibility:hidden;");
            btnCleaning.Attributes.Add("onclick", "return funConfirm();");

            lblFieldTrans.Attributes.Add("style", "visibility:hidden;");
            lblTransaction.Attributes.Add("style", "visibility:hidden;");
            lblTotalFile.Attributes.Add("style", "visibility:hidden;");
            lblTotalRecord.Attributes.Add("style", "visibility:hidden;");
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
            GridView1.DataSource = ds;
            GridView1.DataBind();
            btnCleaning.Attributes.Add("style", "visibility:visible;");
            //ddlFile.DataSource = ds;
            //ddlFile.DataValueField = "FILE_NAME";
            //ddlFile.DataTextField = "FILE_NAME";
            //ddlFile.DataBind();
            ViewState["dataset"] = ds;
            //lblTotalRecord.Text = ds.Tables[0].Rows[0]["total_records"].ToString();
            //lblTotalRecord.Attributes.Add("style", "visibility:visible;");
            //lblTotalFile.Attributes.Add("style", "visibility:visible;");
        }
        else
        {
            GridView1.DataSource = null;
            GridView1.DataBind();
            btnCleaning.Attributes.Add("style", "visibility:hidden;");

            /*ddlFile.DataSource = string.Empty;
            ddlFile.DataValueField = "";
            ddlFile.DataTextField = "";
            ddlFile.DataBind();
            btnCleaning.Attributes.Add("style", "visibility:hidden;");
            grdTransaction.DataSource = null;
            grdTransaction.DataBind();*/
        }

    }
    private void loadGrid(string check,string file_name)
    {
        DataSet ds = new DataSet();
        OracleParameter[] parms = new OracleParameter[10];

        parms[0] = new OracleParameter();
        parms[0] = _dbConfig.Oracle_Param("P_company_code", OracleType.VarChar, ParameterDirection.Input, ddlCompanyCode.SelectedValue.ToString());

        parms[1] = new OracleParameter();
        parms[1] = _dbConfig.Oracle_Param("P_FILE_NAME", OracleType.VarChar, ParameterDirection.Input, file_name);

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
        parms[7] = _dbConfig.Oracle_Param("P_type", OracleType.VarChar, ParameterDirection.Input, "01");

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
                if (check != "S")
                {
                    lblMessage.Text = "";
                }

                lblTransaction.Text = ds.Tables[0].Rows.Count.ToString();
                //btnCleaning.Attributes.Add("style", "visibility:visible;");
                btnCleaning.Visible = true;
                lblFieldTrans.Attributes.Add("style", "visibility:visible;");
                lblTransaction.Attributes.Add("style", "visibility:visible;");
            }
            else if (check == "S")
            {
                btnCleaning.Attributes.Add("style", "visibility:hidden;");
                grdTransaction.DataSource = null;
                grdTransaction.DataBind();
                lblTransaction.Text = ds.Tables[0].Rows.Count.ToString();
                lblFieldTrans.Attributes.Add("style", "visibility:hidden;");
                lblTransaction.Attributes.Add("style", "visibility:hidden;");
            }
            else if (check == "Q")
            {
                btnCleaning.Attributes.Add("style", "visibility:hidden;");
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
    protected void ddlCompanyCode_SelectedIndexChanged(object sender, EventArgs e)
    {
        grdTransaction.DataSource = null;
        grdTransaction.DataBind();
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
        grdTransaction.DataSource = null;
        grdTransaction.DataBind();
        btnCleaning.Attributes.Add("style", "visibility:hidden;");
        lblTransaction.Attributes.Add("style", "visibility:hidden;");
        lblFieldTrans.Attributes.Add("style", "visibility:hidden;");
    }

    protected void btnCleaning_Click(object sender, EventArgs e)
    {
        try
        {
            string p_return = "";
            string[] p_retval;
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                if (((CheckBox)GridView1.Rows[i].FindControl("cbPublish")).Checked == true)
                {
                    DataSet ds = new DataSet();
                    OracleParameter[] parms = new OracleParameter[10];

                    parms[0] = new OracleParameter();
                    parms[0] = _dbConfig.Oracle_Param("P_company_code", OracleType.VarChar, ParameterDirection.Input, ddlCompanyCode.SelectedValue);

                    parms[1] = new OracleParameter();
                    //parms[1] = _dbConfig.Oracle_Param("P_FILE_NAME", OracleType.VarChar, ParameterDirection.Input, (ddlFile.SelectedItem.ToString() == "") ? "" : ddlFile.SelectedItem.ToString());
                    parms[1] = _dbConfig.Oracle_Param("P_FILE_NAME", OracleType.VarChar, ParameterDirection.Input, ((LinkButton)GridView1.Rows[i].FindControl("LinkButton1")).Text);

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
                    parms[7] = _dbConfig.Oracle_Param("P_type", OracleType.VarChar, ParameterDirection.Input, "18");

                    parms[8] = new OracleParameter();
                    parms[8] = _dbConfig.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");

                    parms[9] = new OracleParameter();
                    parms[9] = _dbConfig.Oracle_Param("v_retval", OracleType.VarChar, ParameterDirection.Output, "");

                    ds = _dbConfig.Oracle_GetDataSetSP("SP_Data_Segregation", parms);
                    p_return = ds.Tables[0].Rows[0][0].ToString();
                    p_retval = p_return.Split(';');
                    //lblMessage.Text = p_retval[1].ToString();
                    GridView1.Rows[i].Cells[2].Text = p_retval[1].ToString();
                    p_return = p_retval[0].ToString();
                    //if (p_return == "04")
                    //{
                    //loadGrid("S");
                    //}
                }
            }
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
            //loadGrid("Q");
        }
    }

    protected void grdTransaction_Sorting(object sender, GridViewSortEventArgs e)
    {
        //DataTable dt = ViewState["TaskTable"] as DataTable;
        //if (dt != null)
        //{
        //    dt.DefaultView.Sort = e.SortExpression + " " + GetSortDirection(e.SortExpression);
        //    grdTransaction.DataSource = ViewState["TaskTable"];
        //    grdTransaction.DataBind();
        //}
    }
    
    //protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
    //{
    //    DataSet ds = ViewState["dataset"] as DataSet;
    //    DataTable dt = new DataTable();
    //    dt = ds.Tables[0];
    //    if (dt != null)
    //    {
    //        dt.DefaultView.Sort = e.SortExpression + " " + GetSortDirection(e.SortExpression);
    //        GridView1.DataSource = ViewState["dataset"];
    //        GridView1.DataBind();
    //    }
    //}
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if ((e.Row.RowType == DataControlRowType.Header))
        {
            ((CheckBox)e.Row.FindControl("Ckb_SelectALL")).Attributes.Add("onclick", "javascript:SelectAll('" + ((CheckBox)e.Row.FindControl("Ckb_SelectALL")).ClientID + "')");
        }
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        LinkButton lb = (LinkButton)e.CommandSource;
        GridViewRow grv = (GridViewRow)lb.NamingContainer;
        //string EvenCode = lb.Text;
        string file_name = lb.Text;
        loadGrid("Q", file_name);
    }


    
}
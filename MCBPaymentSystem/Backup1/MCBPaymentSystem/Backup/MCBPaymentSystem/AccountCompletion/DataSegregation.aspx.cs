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

public partial class DataSegregation : System.Web.UI.Page
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
            //btnSubmit.Enabled = false;
            txtagent.Attributes.Add("readonly", "readonly");

            btnSubmit.Attributes.Add("style", "visibility:hidden;");
            btnSubmit.Attributes.Add("onclick", "return funConfirm();");
            lblFieldTrans.Attributes.Add("style", "visibility:hidden;");
            lblTransaction.Attributes.Add("style", "visibility:hidden;");
            lblTotalFile.Attributes.Add("style", "visibility:hidden;");
            lblTotalRecord.Attributes.Add("style", "visibility:hidden;");
            ddlCompanyBind();
            dllFilename();
            // loadCombo();
            //DataTable dt = new DataTable();
            //DataRow dr=null;
            //dt.Columns.Add("FXCODE");
            //dt.Columns.Add("BENENAME");
            //dt.Columns.Add("BENEADDRESS");
            //dt.Columns.Add("TRANSAMOUNT");
            //dt.Columns.Add("ACCOUNTNUMBER");
            //dt.Columns.Add("BANK");
            //for (int i = 0; i < 6; i++)
            //{
            //    dr = dt.NewRow();
            //    dr[0] = i;
            //    dt.Rows.Add(dr);
            //}
            //grdTransaction.DataSource = dt;
            //grdTransaction.DataBind();

        }
    }
    private void loadGrid(string check)
    {
        DataSet ds = new DataSet();
        OracleParameter[] parms = new OracleParameter[10];

        parms[0] = new OracleParameter();
        parms[0] = _dbConfig.Oracle_Param("P_company_code", OracleType.VarChar, ParameterDirection.Input, (ddlCompanyCode.SelectedValue == null) ? "" : ddlCompanyCode.SelectedValue.ToString());

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
        parms[6] = _dbConfig.Oracle_Param("P_Userid", OracleType.VarChar, ParameterDirection.Input, "ADMIN1");//Session["U_NAME"].ToString()

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
                GridView1.DataSource = ds;
                //GridView1.PageSize = 10;
                GridView1.DataBind();

                btnSubmit.Attributes.Add("style", "visibility:visible;");
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

        }
        //if (check == "S")
        //{
        //    btnSubmit.Attributes.Add("style", "visibility:hidden;");
        //    GridView1.DataSource = null;
        //    GridView1.DataBind();
        //    lblTransaction.Text = ds.Tables[0].Rows.Count.ToString();
        //    lblFieldTrans.Attributes.Add("style", "visibility:hidden;");
        //    lblTransaction.Attributes.Add("style", "visibility:hidden;");
        //}
        //ds = _dbConfig.Oracle_GetDataSetSP("SP_Data_Segregation", parms);
        //this.grdTransaction.DataSource = ds.Tables[0];
        //this.grdTransaction.DataBind();

        //if (grdTransaction.Rows.Count <= 0)
        //{
        //    DataRow dr = ds.Tables[0].NewRow();
        //    ds.Tables[0].Rows.Add(dr);
        //    grdTransaction.DataSource = ds.Tables[0];
        //    grdTransaction.DataBind();
        //    int NewCell = grdTransaction.Rows[0].Cells.Count;
        //    grdTransaction.Rows[0].Cells.Clear();
        //    grdTransaction.Rows[0].Cells.Add(new TableCell());
        //    grdTransaction.Rows[0].Cells[0].ColumnSpan = NewCell;
        //    grdTransaction.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
        //    grdTransaction.Rows[0].Cells[0].Text = "No Record found.";
        //}
        //else
        //{


        //}
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            string p_return="";
            string[] p_retval;
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                string transType = ((DropDownList)GridView1.Rows[i].FindControl("DDLCHANGETO")).SelectedValue.ToString();
                if (transType != "Select Mode")
                {
                    DataSet ds = new DataSet();
                    OracleParameter[] parms = new OracleParameter[10];

                    parms[0] = new OracleParameter();
                    parms[0] = _dbConfig.Oracle_Param("P_company_code", OracleType.VarChar, ParameterDirection.Input, ddlCompanyCode.SelectedValue.ToString());

                    parms[1] = new OracleParameter();
                    parms[1] = _dbConfig.Oracle_Param("P_FILE_NAME", OracleType.VarChar, ParameterDirection.Input, ddlFile.SelectedItem.ToString());

                    parms[2] = new OracleParameter();
                    parms[2] = _dbConfig.Oracle_Param("P_Trans_type", OracleType.VarChar, ParameterDirection.Input, transType);

                    parms[3] = new OracleParameter();
                    parms[3] = _dbConfig.Oracle_Param("P_Rowid", OracleType.VarChar, ParameterDirection.Input, GridView1.Rows[i].Cells[0].Text);

                    parms[4] = new OracleParameter();
                    parms[4] = _dbConfig.Oracle_Param("p_bank_code", OracleType.VarChar, ParameterDirection.Input, GridView1.Rows[i].Cells[3].Text);

                    parms[5] = new OracleParameter();
                    parms[5] = _dbConfig.Oracle_Param("p_branch_code", OracleType.VarChar, ParameterDirection.Input, GridView1.Rows[i].Cells[4].Text);

                    parms[6] = new OracleParameter();
                    parms[6] = _dbConfig.Oracle_Param("P_Userid", OracleType.VarChar, ParameterDirection.Input, Session["U_NAME"].ToString());

                    parms[7] = new OracleParameter();
                    parms[7] = _dbConfig.Oracle_Param("P_type", OracleType.VarChar, ParameterDirection.Input, "04");

                    parms[8] = new OracleParameter();
                    parms[8] = _dbConfig.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");

                    parms[9] = new OracleParameter();
                    parms[9] = _dbConfig.Oracle_Param("v_retval", OracleType.VarChar, ParameterDirection.Output, "");

                    p_return = _dbConfig.Oracle_GetDataSetSP_DML("SP_Data_Segregation", parms, 9);
                    lblMessage.Text = p_return.Split(',').GetValue(1).ToString();

                }


            }
            if (p_return.Split(',').GetValue(0).ToString() == "04")
            {
                loadGrid("S");
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
            loadGrid("Q");
        }
    }
    protected void BTN_PrincipleBankId_INSERT_Click(object sender, ImageClickEventArgs e)
    {

        GridViewRow row = GridView1.SelectedRow;
        if (Session["BankCode"].ToString() != "")
        {
            int i = Convert.ToInt16(hdRowIndex.Value);
            ((TextBox)GridView1.Rows[i].FindControl("txtbandcode")).Text = Session["RPS_Customer_Bank_ID"].ToString();
            //((TextBox)grdTransaction.Rows[i].FindControl("txtbandcode")).Text = Session["BankName"].ToString();
        }
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //((ImageButton)e.Row.FindControl("BTN_PrincipleBankId_INSERT")).Attributes.Add("onclick", "BankLOV(" + e.Row.RowIndex + ",'" + hdRowIndex.ClientID + "')");
            // ((TextBox)e.Row.FindControl("txtbandcode")).Attributes.Add("readonly", "readonly");
            //  grdTransaction.Rows[e.Row].Cells[0].Attributes.Add("style", "visibility:hidden;");

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

                btnSubmit.Attributes.Add("style", "visibility:hidden;");
                GridView1.DataSource = null;
                GridView1.DataBind();


                lblTotalRecord.Attributes.Add("style", "visibility:hidden;");
                lblTotalFile.Attributes.Add("style", "visibility:hidden;");
                lblTransaction.Attributes.Add("style", "visibility:hidden;");
                lblFieldTrans.Attributes.Add("style", "visibility:hidden;");
            }
        }
        //if (Session["LOV_ID"].ToString() != "")
        //{
        //    txtagent.Text = Session["COMPANY_CODE"].ToString();
        //    txtagentname.Text = Session["COMPANY_NAME"].ToString();
        //    DataSet ds = new DataSet();
        //    OracleParameter[] parms = new OracleParameter[3];
        //    parms[0] = _dbConfig.Oracle_Param("p_company_code", OracleType.VarChar, ParameterDirection.Input, txtagent.Text);
        //    parms[1] = _dbConfig.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        //    parms[2] = _dbConfig.Oracle_Param("v_retval", OracleType.VarChar, ParameterDirection.Output, "");
        //    ds = _dbConfig.Oracle_GetDataSetSP("SP_Data_Segregation_LOV", parms);
        //    if (ds.Tables[0].Rows.Count > 0)
        //    {
        //        DDLFILE.DataSource = ds;
        //        DDLFILE.DataValueField = "FILE_NAME";
        //        DDLFILE.DataTextField = "FILE_NAME";
        //        DDLFILE.DataBind();
        //    }
        //    else
        //    {
        //        DDLFILE.DataSource = string.Empty;
        //        DDLFILE.DataValueField = "";
        //        DDLFILE.DataTextField = "";
        //        DDLFILE.DataBind();
        //        grdTransaction.DataSource = null;
        //        grdTransaction.DataBind();
        //    }
        //}
        //else
        //{
        //    txtagent.Text = "";
        //    txtagentname.Text = "";
        //}
    }
    //protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    //{
    //    GridView1.PageIndex = e.NewPageIndex;
    //    //GridView1.DataBind();
    //    loadGrid();
    //    //ClientScript.RegisterStartupScript(this.GetType(),"page_index_script", "alert('page index changed!');", true);
    //    //DataView myDataView = new DataView(mybll.GetItemsOrdered());


    //    //GridView gv = sender as GridView;
    //    //gv.PageIndex = e.NewPageIndex;
    //    //gv.DataBind();

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
                    lblTotalFile.Visible = true;
                    lblTotalRecord.Visible = true;
                }
            }
        }
        GridView1.DataSource = null;
        GridView1.DataBind();
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
}

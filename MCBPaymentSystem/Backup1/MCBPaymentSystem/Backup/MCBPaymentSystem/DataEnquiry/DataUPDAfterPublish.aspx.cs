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

public partial class DataUPDAfterPublish : System.Web.UI.Page
{
    string[] ARY;
    string RGS_SUPPORT;
    DatabaseConnection_Util _dbConfig = new DatabaseConnection_Util();
    LOV_COLLECTION lov = new LOV_COLLECTION();
    bool _isLength=false;

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
        }
        else if (RGS_SUPPORT.Substring(0, 1) == "1")
        {
            btnSubmit.Visible = true; /*ADD*/
        }
        if (RGS_SUPPORT.Substring(4, 1) == "0")
        {
            Session["Authorize"] = "false";
            //btnAuthorize.Visible = false;
        }
        else if (RGS_SUPPORT.Substring(4, 1) == "1")
        {
            Session["Authorize"] = "true";
            //btnAuthorize.Visible = true;
        }
        if (!Page.IsPostBack)
        {
            ViewState["ConnectionString"] = _dbConfig.ConnectionString;
            btnSubmit.Attributes.Add("style", "visibility:hidden;");
            btnSubmit.Attributes.Add("onclick", "return funConfirm();");

            /*txtAgnetCode.Attributes.Add("readonly", "readonly");
            txtAgentName.Attributes.Add("readonly", "readonly");
            lblFieldTrans.Attributes.Add("style", "visibility:hidden;");
            lblTransaction.Attributes.Add("style", "visibility:hidden;");
            lblTotalFile.Attributes.Add("style", "visibility:hidden;");
            lblTotalRecord.Attributes.Add("style", "visibility:hidden;");
            ddlCompanyBind();
            dllFilename();*/
           // Panel1.Attributes.Add("style", "visibility:hidden;");
        }
    }
    private void loadGrid(string type)
    {
        DataSet ds = new DataSet();
        OracleParameter[] parms = new OracleParameter[6];

        parms[0] = new OracleParameter();
        parms[0] = _dbConfig.Oracle_Param("p_DRAFTNO", OracleType.VarChar, ParameterDirection.Input, txtDraftNo.Text);

        parms[1] = new OracleParameter();
        parms[1] = _dbConfig.Oracle_Param("p_CUSTREFNUMBER", OracleType.VarChar, ParameterDirection.Input, txtCustomerRef.Text);

        parms[2] = new OracleParameter();
        parms[2] = _dbConfig.Oracle_Param("P_USER_ID", OracleType.VarChar, ParameterDirection.Input, Session["U_NAME"].ToString());

        parms[3] = new OracleParameter();
        parms[3] = _dbConfig.Oracle_Param("p_rowid", OracleType.VarChar, ParameterDirection.Input, "");

        parms[4] = new OracleParameter();
        parms[4] = _dbConfig.Oracle_Param("v_retval", OracleType.VarChar, ParameterDirection.Output, "");

        parms[5] = new OracleParameter();
        parms[5] = _dbConfig.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");

        ds = _dbConfig.Oracle_GetDataSetSP("sp_afterPublish_fetch", parms);
        if (ds.Tables[0].Rows.Count > 0)
        {
            DataTable dt = new DataTable();
            dt = ds.Tables[0];
            ViewState["TaskTable"] = dt;
            GridView1.DataSource = ds;
            GridView1.DataBind();
            lblRecord.Text = dt.Rows.Count.ToString() + " Record(s) found.";

            if (type == "E")
                lblMessage.Text = lblMessage.Text;
            else
                lblMessage.Text = "";
            //btnPrint.Attributes.Add("style", "visibility:visible;");
            //btnPrint.Attributes.Add("style", "visibility:visible;");
        }
        else
        {
            //btnPrint.Attributes.Add("style", "visibility:hidden;");
            GridView1.DataSource = null;
            GridView1.DataBind();
            lblRecord.Text = "";
            lblMessage.Text = "No data found.";
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        //Page.Validate();
        //if (Page.IsValid)
        //{
        //    loadGrid("");
        //}

        _isLength = true;
        Page.Validate();
        if (Page.IsValid)
        {
            if ((txtDraftNo.Text.Length == 0) && (txtCustomerRef.Text.Length == 0))
            {
                _isLength = false;
                lblRecord.Text = "Invalid Criteria";
            }
            else
            {
                loadGrid("");
            }
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            //OracleConnection con = new OracleConnection(ViewState["ConnectionString"].ToString());
            //con.Open();
            //OracleTransaction trans = con.BeginTransaction();
            //string val = Execute_sp(con, trans);
            //if (val.StartsWith("1") == true)
            //{
            //    val = postLeadger(con, trans);
            //    if (val.StartsWith("1") == true)
            //    {
            //        trans.Commit();
            //        con.Close();
            //        loadGrid("E");
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
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
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
    public string spRow_Updation(string rowid, string beneName, string AccountNO, string Type, string bank_code, string branchID)
    {

        string v_return = "";
        //for (int i = 0; i < GridView1.Rows.Count; i++)
        //{
            //if (((CheckBox)GridView1.Rows[i].FindControl("cbPublish")).Checked == true)
            OracleParameter[] parm = new OracleParameter[7];
            int pno = 0;
            parm[pno] = new OracleParameter();
            parm[pno] = _dbConfig.Oracle_Param("p_benename", OracleType.VarChar, ParameterDirection.Input, beneName);
            pno++;
            parm[pno] = new OracleParameter();
            parm[pno] = _dbConfig.Oracle_Param("P_accountno", OracleType.VarChar, ParameterDirection.Input, AccountNO);
            pno++;

            parm[pno] = new OracleParameter();
            parm[pno] = _dbConfig.Oracle_Param("p_bank_code", OracleType.VarChar, ParameterDirection.Input, bank_code);
            pno++;

            parm[pno] = new OracleParameter();
            parm[pno] = _dbConfig.Oracle_Param("p_branchid", OracleType.VarChar, ParameterDirection.Input, branchID);
            pno++;
            parm[pno] = new OracleParameter();
            parm[pno] = _dbConfig.Oracle_Param("P_Rowid", OracleType.VarChar, ParameterDirection.Input, rowid);
            pno++;
            parm[pno] = new OracleParameter();
            parm[pno] = _dbConfig.Oracle_Param("P_type", OracleType.VarChar, ParameterDirection.Input, Type);
            pno++;
            parm[pno] = new OracleParameter();
            parm[pno] = _dbConfig.Oracle_Param("P_retval", OracleType.VarChar, ParameterDirection.Output, "");

            v_return = _dbConfig.Oracle_GetDataSetSP_DML("sp_Trans_Enquiry_upd", parm, pno);
            if (v_return.StartsWith("1") == false)
            {
                lblMessage.Text = v_return.Split(';').GetValue(1).ToString();
                return v_return;
            }
            else
            {
                lblMessage.Text = v_return.Split(';').GetValue(1).ToString();
            }
        //}
        return v_return;
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //22 edit
        //23 authorize
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (Session["Authorize"].ToString() == "true")
            {
                e.Row.Cells[22].CssClass = "hidden";  //Edit link button false
                LinkButton linkBtn = (LinkButton)(e.Row.Cells[23].Controls[0]);
                if (e.Row.Cells[21].Text == "Un-Authorized") //Check transaction Un-Authorized?
                {
                    if (linkBtn.Text == "Authorize") linkBtn.Attributes.Add("onclick", "return OnConfirmAuth();");
                }
                else
                {
                    linkBtn.Enabled = false;
                }
                if (e.Row.Cells[19].Text == "PAID TRANSACTION" || e.Row.Cells[19].Text == "TRANSACTION CANCEL" ||
                    e.Row.Cells[19].Text == "TRANSACTION HOLD" || e.Row.Cells[19].Text == "DUPLICATE DD")
                {
                    /*LinkButton linkBtn = (LinkButton)(e.Row.Cells[22].Controls[0]);
                    if (linkBtn.Text == "Update") linkBtn.Attributes.Add("onclick", "return OnConfirmGV();");*/
                    linkBtn.Enabled = false;
                }
                else
                {

                    if (linkBtn.Text == "Authorize") linkBtn.Attributes.Add("onclick", "return OnConfirmAuth();");
                }
            }
            else if (Session["Authorize"].ToString() == "false")
            {
                e.Row.Cells[23].CssClass = "hidden";    //Authorize link button false
                LinkButton linkBtn = (LinkButton)(e.Row.Cells[22].Controls[0]);
                if (e.Row.Cells[19].Text == "PAID TRANSACTION" || e.Row.Cells[19].Text == "TRANSACTION CANCEL" ||
                    e.Row.Cells[19].Text == "TRANSACTION HOLD" || e.Row.Cells[19].Text == "DUPLICATE DD")
                
                {
                    /*LinkButton linkBtn = (LinkButton)(e.Row.Cells[22].Controls[0]);
                    if (linkBtn.Text == "Update") linkBtn.Attributes.Add("onclick", "return OnConfirmGV();");*/
                    linkBtn.Enabled = false;
                }
                else
                {
                    
                    if (linkBtn.Text == "Update") linkBtn.Attributes.Add("onclick", "return OnConfirmGV();");
                }
            }





        }
        else if (e.Row.RowType == DataControlRowType.Header)
        {
            if (Session["Authorize"].ToString() == "true")
            {
                e.Row.Cells[22].CssClass = "hidden"; //Header Edit false
            }
            else if (Session["Authorize"].ToString() == "false")
            {
                e.Row.Cells[23].CssClass = "hidden"; //Header Authorize false
            }
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

    /*public void ddlCompanyBind()
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

    }*/
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string RowID = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[0].Controls[0])).Text;
        //string CNIC = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[8].Controls[0])).Text;
        string BeneName = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[9].Controls[0])).Text;
        string AccountNO = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[11].Controls[0])).Text;
        string BankCode = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[14].Controls[0])).Text;
        string BranchCode = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[16].Controls[0])).Text;
        //02 For Update
        spRow_Updation(RowID, BeneName, AccountNO, "1",BankCode,BranchCode);
        GridView1.EditIndex = -1;
        loadGrid("E");
    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        loadGrid("E");
    }
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        loadGrid("");
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        string RowID = GridView1.SelectedRow.Cells[0].Text;
        //02 For Authorize
        spRow_Updation(RowID, "", "","2","","");
        loadGrid("E");
    }
}

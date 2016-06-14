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
using System.Data.OleDb;

public partial class DepositoryAddandRemove : System.Web.UI.Page
{
    string[] ARY;
    string RGS_SUPPORT;
    DatabaseConnection_Util _dbConfig = new DatabaseConnection_Util();
    LOV_COLLECTION lov = new LOV_COLLECTION();
    DataTable dtFile = new DataTable();
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
            //btnAuthorize.Visible = false;
        }
        else if (RGS_SUPPORT.Substring(4, 1) == "1")
        {
            Session["Authorize"] = "true";
        }
        if (!Page.IsPostBack)
        {
            ViewState["ConnectionString"] = _dbConfig.ConnectionString;
            btnSubmit.Attributes.Add("style", "visibility:hidden");
        }
        btnGetSymbolAcct_title.Attributes.Add("style", "visibility:hidden");
        btnSubmit.Attributes.Add("onclick", "return OnConfirmGV();");
        
    }
    private void loadGrid(string check)
    {
        DataSet ds = new DataSet();
        OracleParameter[] parms = new OracleParameter[3];

        int pno = 0;
        parms[pno] = new OracleParameter();
        parms[pno] = _dbConfig.Oracle_Param("p_account_no", OracleType.VarChar, ParameterDirection.Input, txtAccountNo.Text);
        pno++;

        parms[pno] = new OracleParameter();
        parms[pno] = _dbConfig.Oracle_Param("p_branch_code", OracleType.VarChar, ParameterDirection.Input, txtBranchCode.Text);
        pno++;

        parms[pno] = new OracleParameter();
        parms[pno] = _dbConfig.Oracle_Param("DATA_SET", OracleType.Cursor, ParameterDirection.Output, "");
        ds = _dbConfig.Oracle_GetDataSetSP("sp_depository_fetch", parms);

        if (ds.Tables[0].Rows.Count > 0)
        {
            DataTable dt = new DataTable();
            dt = ds.Tables[0];
            GridView1.DataSource = ds;
            GridView1.DataBind();
            btnSubmit.Attributes.Add("style", "visibility:visible");
            if (check != "S")
            {
                lblMessage.Text = "";
            }
        }
        else if (check == "S")
        {
            GridView1.DataSource = null;
            GridView1.DataBind();
        }
        else
        {
            GridView1.DataSource = null;
            GridView1.DataBind();
            lblMessage.Text = "No data found.";
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
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        spRow_Updation("01");
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Page.Validate();
        if (Page.IsValid)
        {
            loadGrid("Q");
        }
    }
    public string spRow_Updation(string Type)
    {
        string account_no = "";
        string branch_code = "";
        string TitleofAccount = "";
        string rowid = "";
        string v_return = "";
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            rowid = GridView1.Rows[i].Cells[0].Text;
            account_no = ((TextBox)GridView1.Rows[i].FindControl("txtAccountNo")).Text;
            branch_code = ((TextBox)GridView1.Rows[i].FindControl("txtBranchCode")).Text;
            TitleofAccount = ((TextBox)GridView1.Rows[i].FindControl("txtTitleofAccount")).Text;
            if (rowid != "" && account_no != "" && branch_code != "" && TitleofAccount != "")
            {
                OracleParameter[] parm = new OracleParameter[7];
                int pno = 0;
                parm[pno] = new OracleParameter();
                parm[pno] = _dbConfig.Oracle_Param("P_Rowid", OracleType.VarChar, ParameterDirection.Input, rowid);
                pno++;
                parm[pno] = new OracleParameter();
                parm[pno] = _dbConfig.Oracle_Param("P_ACCOUNTNUMBER", OracleType.VarChar, ParameterDirection.Input, account_no);
                pno++;
                parm[pno] = new OracleParameter();
                parm[pno] = _dbConfig.Oracle_Param("P_BRANCH_CODE", OracleType.VarChar, ParameterDirection.Input, branch_code);
                pno++;
                parm[pno] = new OracleParameter();
                parm[pno] = _dbConfig.Oracle_Param("p_bene_name", OracleType.VarChar, ParameterDirection.Input, TitleofAccount);
                pno++;
                parm[pno] = new OracleParameter();
                parm[pno] = _dbConfig.Oracle_Param("P_Userid", OracleType.VarChar, ParameterDirection.Input, Session["U_NAME"].ToString());
                pno++;
                parm[pno] = new OracleParameter();
                parm[pno] = _dbConfig.Oracle_Param("P_type", OracleType.VarChar, ParameterDirection.Input, Type);
                pno++;
                parm[pno] = new OracleParameter();
                parm[pno] = _dbConfig.Oracle_Param("p_retval", OracleType.VarChar, ParameterDirection.Output, "");

                v_return = _dbConfig.OracleExecuteSP_GetReturnVal("sp_depository_update_auth", parm, pno);
                if (v_return.StartsWith("04") == false)
                {
                    lblMessage.Text = v_return.Split(',').GetValue(1).ToString();
                    return v_return;
                }
                else
                {
                    lblMessage.Text = v_return.Split(',').GetValue(1).ToString();
                    txtAccountNo.Text = "";
                    txtBranchCode.Text = "";
                    loadGrid("S");
                }
            }
            else
            { 
                lblMessage.Text = "Account No and Title must be required.";
                v_return = "Account No,Branch Code and Title must be required.";
            }
        }
        return v_return;
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        txtAccountNo.Text = "";
        txtBranchCode.Text = "";
        btnSubmit.Attributes.Add("style", "visibility:hidden");
        loadGrid("S");
    }
}



















#region comment code
//protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
//{
//    if (e.Row.RowType == DataControlRowType.DataRow)
//    {

//        if (Session["Authorize"].ToString() == "true")
//        {
//            e.Row.Cells[7].CssClass = "hidden";
//            LinkButton linkBtn = (LinkButton)(e.Row.Cells[8].Controls[0]);
//            if (e.Row.Cells[6].Text == "Un-Authorized")
//            {
//                if (linkBtn.Text == "Authorize") linkBtn.Attributes.Add("onclick", "return OnConfirmAuth();");
//            }
//            else
//            {
//                linkBtn.Enabled = false;
//            }
//        }
//        else if (Session["Authorize"].ToString() == "false")
//        {
//            e.Row.Cells[8].CssClass = "hidden";
//            LinkButton linkBtn = (LinkButton)(e.Row.Cells[7].Controls[0]);
//            if (linkBtn.Text == "Update") linkBtn.Attributes.Add("onclick", "return OnConfirmGV();");
//        }

//    }
//    else if (e.Row.RowType == DataControlRowType.Header)
//    {
//        if (Session["Authorize"].ToString() == "true")
//        {
//            //e.Row.Cells[12].CssClass = "hidden";
//            e.Row.Cells[7].CssClass = "hidden";
//        }
//        else if (Session["Authorize"].ToString() == "false")
//        {
//            //e.Row.Cells[13].CssClass = "hidden";
//            e.Row.Cells[8].CssClass = "hidden";
//        }
//    }

//}
//private string GetSortDirection(string column)
//{
//    string sortDirection = "ASC";
//    string sortExpression = ViewState["SortExpression"] as string;
//    if (sortExpression != null)
//    {
//        if (sortExpression == column)
//        {
//            string lastDirection = ViewState["SortDirection"] as string;
//            if ((lastDirection != null) && (lastDirection == "ASC"))
//            {
//                sortDirection = "DESC";
//            }
//        }
//    }
//    ViewState["SortDirection"] = sortDirection;
//    ViewState["SortExpression"] = column;
//    return sortDirection;
//}
//protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
//{
//    //DataTable dt = ViewState["TaskTable"] as DataTable;
//    //if (dt != null)
//    //{
//    //    dt.DefaultView.Sort = e.SortExpression + " " + GetSortDirection(e.SortExpression);
//    //    GridView1.DataSource = ViewState["TaskTable"];
//    //    GridView1.DataBind();
//    //}
//}
//protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
//{
//    //dtFile = (DataTable)ViewState["TaskTable"];
//    //string company_code = dtFile.Rows[e.RowIndex]["company_code"].ToString();
//    //string file_name = dtFile.Rows[e.RowIndex]["file_name"].ToString();
//    string company_code = "";
//    string file_name = "";
//    string RowID = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[0].Controls[0])).Text;
//    string AccountNO = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("txt_account_no_edit")).Text;
//    string BranchCode = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("txtBranchCode_Edit")).Text;
//    string BeneName = GridView1.Rows[e.RowIndex].Cells[3].Text;
//    spRow_Updation(RowID, BranchCode, AccountNO, BeneName, "01", company_code, file_name, txtAccountNo.Text);//01 For Update
//    GridView1.EditIndex = -1;
//    loadGrid("S");
//}
//protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
//{
//    GridView1.EditIndex = e.NewEditIndex;
//    loadGrid("S");
//    //((TextBox)GridView1.Rows[e.NewEditIndex].FindControl("txt_account_no_edit")).Attributes.Add("onchange", "clickbtnaccount(" + e.NewEditIndex + ");");
//    //((TextBox)GridView1.Rows[e.NewEditIndex].FindControl("txtBranchCode_Edit")).Attributes.Add("onchange", "clickbtnaccount(" + e.NewEditIndex + ");");
//}
//protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
//{
//    GridView1.EditIndex = -1;
//    loadGrid("S");
//}
//protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
//{
//    string RowID = GridView1.SelectedRow.Cells[0].Text;
//    spRow_Updation(RowID, "", "", "", "02", "", "", ""); //02 For Authorize
//    loadGrid("S");
//}
//protected void btnGetSymbolAcct_title_Click(object sender, EventArgs e)
//{
//    /*int i = Convert.ToInt16(hdRowIndex.Value);
//    DataTable dt = new DataTable();
//    string branchCode = ((TextBox)GridView1.Rows[i].FindControl("txtBranchCode_Edit")).Text;
//    string account_no = ((TextBox)GridView1.Rows[i].FindControl("txt_account_no_edit")).Text;
//    string account_Title = getSymbolAccountTitle(branchCode, account_no);
//    GridView1.Rows[i].Cells[3].Text = account_Title;
//    */
//    //if (GridView1.Rows.Count - 1 > i)
//    //{
//    //    //((TextBox)GridView1.Rows[i + 1].FindControl("txtBranchCode")).Focus();
//    //}
//    //else
//    //{
//    //    //((TextBox)GridView1.Rows[0].FindControl("txtSymbolTitle")).Focus();
//    //}
//}
//public string getSymbolAccountTitle(string branchCode, string account_no)
//{
//    try
//    {
//        DataSet ds = new DataSet();
//        OracleParameter[] parm = new OracleParameter[3];
//        int pno = 0;
//        parm[pno] = new OracleParameter();
//        parm[pno] = _dbConfig.Oracle_Param("p_account_no", OracleType.VarChar, ParameterDirection.Input, account_no);
//        pno++;

//        parm[pno] = new OracleParameter();
//        parm[pno] = _dbConfig.Oracle_Param("p_branch_code", OracleType.VarChar, ParameterDirection.Input, branchCode);
//        pno++;

//        parm[pno] = new OracleParameter();
//        parm[pno] = _dbConfig.Oracle_Param("DATA_SET", OracleType.Cursor, ParameterDirection.Output, "");

//        ds = _dbConfig.Oracle_GetDataSetSP("sp_SYMBOL_ACCOUNT_fetch", parm);
//        return (ds.Tables[0].Rows.Count > 0 ? ds.Tables[0].Rows[0]["acct_title"].ToString() : "Account Title not found.");
//    }
//    catch (Exception ex)
//    {

//        lblMessage.Text = ex.Message;
//    }
//    return "";
//}
//protected void txt_account_no_edit_TextChanged(object sender, EventArgs e)
//{
//    int i = Convert.ToInt16(hdRowIndex.Value);
//    DataTable dt = new DataTable();
//    string branchCode = ((TextBox)GridView1.Rows[i].FindControl("txtBranchCode_Edit")).Text;
//    string account_no = ((TextBox)GridView1.Rows[i].FindControl("txt_account_no_edit")).Text;
//    string account_Title = getSymbolAccountTitle(branchCode, account_no);
//    GridView1.Rows[i].Cells[3].Text = account_Title;
//}
//protected void txtBranchCode_Edit_TextChanged(object sender, EventArgs e)
//{
//    int i = Convert.ToInt16(hdRowIndex.Value);
//    DataTable dt = new DataTable();
//    string branchCode = ((TextBox)GridView1.Rows[i].FindControl("txtBranchCode_Edit")).Text;
//    string account_no = ((TextBox)GridView1.Rows[i].FindControl("txt_account_no_edit")).Text;
//    string account_Title = getSymbolAccountTitle(branchCode, account_no);
//    GridView1.Rows[i].Cells[3].Text = account_Title;
//}
#endregion 
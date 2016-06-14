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

public partial class PRIUnpaid : System.Web.UI.Page
{
    string[] ARY;
    string RGS_SUPPORT;
    DatabaseConnection_Util _dbConfig = new DatabaseConnection_Util();
    LOV_COLLECTION lov = new LOV_COLLECTION();
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetCacheability(HttpCacheability.ServerAndNoCache);
        Session["RGS"] = "00000";
        String ST = Startup_Util.DcryptionPWD(Request.QueryString[0].ToString());
        ARY = ST.Split('~');
        Session["RGS"] = ARY[0].ToString();
        RGS_SUPPORT = Session["RGS"].ToString();

        if (RGS_SUPPORT.Substring(0, 1) == "0")//For Authorize
        {
            btnUnpaid.Visible = false;
            btnAuthorized.Visible = true;
        }
        else if (RGS_SUPPORT.Substring(0, 1) == "1") //For Maker
        {
            btnUnpaid.Visible = true;
            btnAuthorized.Visible = false;
            GridView1.Columns[9].Visible = false;
            GridView1.Columns[10].Visible = false;
        }
        if (!IsPostBack)
        {
            if (Request.QueryString["UID"] != null)
            {
                Session["U_NAME"] = Request.QueryString["UID"].ToString();
            }
            btnUnpaid.Visible = false;
            btnAuthorized.Attributes.Add("onclick", "return funConfirm();");
            btnUnpaid.Attributes.Add("onclick", "return funConfirm();");
        }
        lbl_msg.Text = "";
    }
    protected void Page_PreInit(object sender, EventArgs e)
    { Page.Theme = Session["ThemeChange"].ToString(); }
    protected void btnFetch_Click(object sender, EventArgs e)
    {
        if (Session["U_NAME"].ToString() == "")
        {
            lbl_msg.Text = "User session has been expired, Please Re-Login.";
            return;
        }
        if (txtCustRefno.Text == "" && txtDraftno.Text == "" && btnAuthorized.Visible == false)
        {
            lbl_msg.Text = "Please input value.";
            btnUnpaid.Visible = false;
            return;
        }
        string action = btnAuthorized.Visible == false ? "I" : "A";
        GetPRITransForUnpaid(txtDraftno.Text, txtCustRefno.Text, action);
    }
    protected void btnUnpaid_Click(object sender, EventArgs e)
    {
        string retval = "";
        if (Session["U_NAME"].ToString() == "")
        {
            lbl_msg.Text = "User session has been expired, Please Re-Login.";
            return;
        }
        retval = trans_process(GridView1.Rows[0].Cells[0].Text, GridView1.Rows[0].Cells[1].Text, GridView1.Rows[0].Cells[4].Text, GridView1.Rows[0].Cells[5].Text, GridView1.Rows[0].Cells[7].Text, GridView1.Rows[0].Cells[3].Text, GridView1.Rows[0].Cells[2].Text, Session["U_NAME"].ToString(), "I");
        if (retval.StartsWith("0"))
        {
            lbl_msg.Text = retval.Split(';')[1].ToString(); ;
            btnUnpaid.Visible = false;
        }
        else
        {
            lbl_msg.Text = retval.Split(';')[1].ToString(); ;
            btnUnpaid.Visible = true;
        }

    }
    protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataSet ds = null;// GetPRIForSymbol(ddlCompanyCode.SelectedValue, ddlBank.SelectedValue);
        if (ds.Tables[0] != null)
        {
            ds.Tables[0].DefaultView.Sort = e.SortExpression + " " + GetSortDirection(e.SortExpression);
            GridView1.DataSource = ds.Tables[0];
            GridView1.DataBind();
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
    public DataSet GetPRITransForUnpaid(string draftno, string cust_refno, string action)
    {        
        if (Session["U_NAME"].ToString() == "")
        {
            lbl_msg.Text = "User session has been expired, Please Re-Login.";
            return null;
        }
        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[4];
        PR[0] = _dbConfig.Oracle_Param("p_draftno", OracleType.VarChar, ParameterDirection.Input, draftno);
        PR[1] = _dbConfig.Oracle_Param("p_cust_refno", OracleType.VarChar, ParameterDirection.Input, cust_refno);
        PR[2] = _dbConfig.Oracle_Param("p_action", OracleType.VarChar, ParameterDirection.Input, action);
        PR[3] = _dbConfig.Oracle_Param("p_dataset", OracleType.Cursor, ParameterDirection.Output, "");
        DS = _dbConfig.Oracle_GetDataSetSP("sp_get_pri_trans_for_unpaid", PR);

        if (DS.Tables[0].Rows.Count > 0)
        {
            GridView1.DataSource = DS.Tables[0];
            GridView1.DataBind();
        }
        else
        {
            GridView1.DataSource = null;
            GridView1.DataBind();
            btnUnpaid.Visible = false;

        }
        return DS;
    }
    public string trans_process(string p_rowid, string p_companycode, string p_draftno, string p_cust_refno, string p_transtype, string p_amount, string p_bankcode, string p_userid, string p_action)
    {
        string retVal = "";
        OracleParameter[] param = new OracleParameter[8];
        param[0] = _dbConfig.Oracle_Param("p_rowid", OracleType.VarChar, ParameterDirection.Input, p_rowid);
        param[1] = _dbConfig.Oracle_Param("p_companycode", OracleType.VarChar, ParameterDirection.Input, p_companycode);
        param[2] = _dbConfig.Oracle_Param("p_draftno", OracleType.VarChar, ParameterDirection.Input, p_draftno);
        param[3] = _dbConfig.Oracle_Param("p_cust_refno", OracleType.VarChar, ParameterDirection.Input, p_cust_refno);
        param[4] = _dbConfig.Oracle_Param("p_amount", OracleType.VarChar, ParameterDirection.Input, p_amount);
        param[5] = _dbConfig.Oracle_Param("p_userid", OracleType.VarChar, ParameterDirection.Input, p_userid);
        param[6] = _dbConfig.Oracle_Param("p_action", OracleType.VarChar, ParameterDirection.Input, p_action);
        param[7] = _dbConfig.Oracle_Param("p_return", OracleType.VarChar, ParameterDirection.Output, "");
        retVal = _dbConfig.OracleExecuteSP_GetReturnVal("sp_unpaid_trans", param, 7);
        return retVal;
    }
    protected void btnAuthorized_Click(object sender, EventArgs e)
    {
        string retval = "";
        if (Session["U_NAME"].ToString() == "")
        {
            lbl_msg.Text = "User session has been expired, Please Re-Login.";
            return;
        }
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            if (((CheckBox)GridView1.Rows[i].FindControl("chkSelect")).Checked == true)
            {
                retval = trans_process(GridView1.Rows[i].Cells[0].Text, GridView1.Rows[i].Cells[1].Text, GridView1.Rows[i].Cells[4].Text, GridView1.Rows[i].Cells[5].Text, GridView1.Rows[i].Cells[7].Text, GridView1.Rows[i].Cells[3].Text, GridView1.Rows[i].Cells[2].Text, Session["U_NAME"].ToString(), "A");
                ((Label)GridView1.Rows[i].FindControl("lblstatus")).Text = retval.Split(';')[1].ToString();
                ((CheckBox)GridView1.Rows[i].FindControl("chkSelect")).Checked = false;
                ((CheckBox)GridView1.Rows[i].FindControl("chkSelect")).Visible = false;
            }
        }
    }
}
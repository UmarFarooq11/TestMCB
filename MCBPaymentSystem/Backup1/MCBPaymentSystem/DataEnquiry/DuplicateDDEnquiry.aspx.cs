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

public partial class DuplicateDDEnquiry : System.Web.UI.Page
{
    string[] ARY;
    string RGS_SUPPORT;
    DatabaseConnection_Util _dbConfig = new DatabaseConnection_Util();
    LOV_COLLECTION lov = new LOV_COLLECTION();
    bool _isLength = false;

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
            btnSearch.Visible = false; /*ADD*/
        }
        else if (RGS_SUPPORT.Substring(0, 1) == "1")
        { 
            btnSearch.Visible = true; /*ADD*/
        }
        if (!Page.IsPostBack)
        {
            btnDuplicate.Attributes.Add("style", "visibility:hidden;");
            //btnDuplicate.Attributes.Add("onclick", "getPrint('Print_All');");
        }
    }
    private void loadGrid()
    {

        DataSet ds = new DataSet();
        OracleParameter[] parms = new OracleParameter[5];

        parms[0] = new OracleParameter();
        parms[0] = _dbConfig.Oracle_Param("p_DRAFTNO", OracleType.VarChar, ParameterDirection.Input, txtDraftNo.Text);

        parms[1] = new OracleParameter();
        parms[1] = _dbConfig.Oracle_Param("p_CUSTREFNUMBER", OracleType.VarChar, ParameterDirection.Input, txtCustomerRef.Text);

        parms[2] = new OracleParameter();
        parms[2] = _dbConfig.Oracle_Param("p_rowid", OracleType.VarChar, ParameterDirection.Input, "");
        
        parms[3] = new OracleParameter();
        parms[3] = _dbConfig.Oracle_Param("v_retval", OracleType.VarChar, ParameterDirection.Output, "");        
        
        parms[4] = new OracleParameter();
        parms[4] = _dbConfig.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");

        ds = _dbConfig.Oracle_GetDataSetSP("sp_Trans_Enquiry_DD", parms);
        if (ds.Tables[0].Rows.Count > 0)
        {
            DataTable dt = new DataTable();
            dt = ds.Tables[0];
            ViewState["TaskTable"] = dt;
            GridView1.DataSource = ds;
            GridView1.DataBind();
            lblRecord.Text = ds.Tables[0].Rows.Count.ToString() + " Record(s) found.";
            btnDuplicate.Attributes.Add("style", "visibility:visible;");
        }
        else
        {
            btnDuplicate.Attributes.Add("style", "visibility:hidden;");
            GridView1.DataSource = null;
            GridView1.DataBind();
            lblMessage.Text = "";
            lblRecord.Text = "";
        }

    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
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
               loadGrid();
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
    public void txtReset()
    {
        txtDraftNo.Text = txtCustomerRef.Text = "";
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        loadGrid();
    }
    protected void btnDuplicate_Click(object sender, EventArgs e)
    {
        string rowCode = GridView1.DataKeys[0].Value.ToString();
        if (this.GridView1.Rows.Count > 0)
        {
            if (rowCode.Length > 0)
            {
                OracleParameter[] parms = new OracleParameter[2];

                parms[0] = new OracleParameter();
                parms[0] = _dbConfig.Oracle_Param("p_rowid", OracleType.VarChar, ParameterDirection.Input, rowCode);

                parms[1] = new OracleParameter();
                parms[1] = _dbConfig.Oracle_Param("p_retval", OracleType.VarChar, ParameterDirection.Output, "");

                //DataSet ds = _dbConfig.Oracle_GetDataSetSP("sp_duplicate_dd", parms);
                _dbConfig.Oracle_GetDataSetSP_DML("sp_duplicate_dd", parms);

                if (CRUtlityGetsafeString(parms[1].Value).Length > 0)
                { 
                    string[] result=CRUtlityGetsafeString(parms[1].Value).Split(';');
                    if (result[0] == "0")
                    {
                        this.lblMessage.Visible = true;
                        this.lblMessage.Text = result[1];
                        this.lblRecord.Visible = false;
                    }
                    else
                    {
                        this.lblRecord.Visible = true;
                        this.lblRecord.Text = result[1];
                        this.lblMessage.Visible = false;
                    }
                }
            }
        }
    }
    private string CRUtlityGetsafeString(object value)
    {
        if (value != null)
        {
            return value.ToString();
        }
        else
        {
            return "";
        }
    }
    
}

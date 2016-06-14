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

public partial class AccountEnquiry : System.Web.UI.Page
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
        if (!Page.IsPostBack)
        {
            btnPrint.Attributes.Add("style", "visibility:hidden;");
            //btnPrint.Attributes.Add("onclick", "return onPrint();");
            btnPrint.Attributes.Add("onclick", "getPrint('Print_All');");
            rbAccountEnquiry.Checked = true;
            ViewState["TYPE"] = "01";
            rbAccountEnquiry_CheckedChanged(null, null);
            rbBranchEnquiry_CheckedChanged(null, null);
        }
    }
    private void loadGrid()
    {

        DataSet ds = new DataSet();
        OracleParameter[] parms = new OracleParameter[8];

        parms[0] = new OracleParameter();
        parms[0] = _dbConfig.Oracle_Param("P_Accountnumber", OracleType.VarChar, ParameterDirection.Input, txtAccountNo.Text);

        parms[1] = new OracleParameter();
        parms[1] = _dbConfig.Oracle_Param("P_custnic", OracleType.VarChar, ParameterDirection.Input, txtCNIC.Text);

        parms[2] = new OracleParameter();
        parms[2] = _dbConfig.Oracle_Param("P_accounttitle", OracleType.VarChar, ParameterDirection.Input, txtAccountTitle.Text);

        parms[3] = new OracleParameter();
        parms[3] = _dbConfig.Oracle_Param("P_branch_code", OracleType.VarChar, ParameterDirection.Input, txtBranchCode.Text);

        parms[4] = new OracleParameter();
        parms[4] = _dbConfig.Oracle_Param("p_branch_loc", OracleType.VarChar, ParameterDirection.Input, txtBrLocation.Text);

        parms[5] = new OracleParameter();
        parms[5] = _dbConfig.Oracle_Param("p_branch_city", OracleType.VarChar, ParameterDirection.Input, txtCity.Text); 

        parms[6] = new OracleParameter();
        parms[6] = _dbConfig.Oracle_Param("p_type", OracleType.VarChar, ParameterDirection.Input, ViewState["TYPE"].ToString());        
        
        parms[7] = new OracleParameter();
        parms[7] = _dbConfig.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");

        ds = _dbConfig.Oracle_GetDataSetSP("ENQUIRY_DATA", parms);
        if (ds.Tables[0].Rows.Count > 0)
        {
            DataTable dt = new DataTable();
            dt = ds.Tables[0];
            ViewState["TaskTable"] = dt;
            GridView1.DataSource = ds;
            GridView1.DataBind();
            lblRecord.Text = ds.Tables[0].Rows.Count.ToString() + " Record(s) found.";
            //btnPrint.Attributes.Add("style", "visibility:visible;");
            btnPrint.Attributes.Add("style", "visibility:visible;");
        }
        else
        {
            btnPrint.Attributes.Add("style", "visibility:hidden;");
            GridView1.DataSource = null;
            GridView1.DataBind();
            lblMessage.Text = "";
            //lblMessage.Text = "No data found.";
            lblRecord.Text = "";
        }

    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Page.Validate();
        if (Page.IsValid)
        {
            loadGrid();
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
    protected void rbAccountEnquiry_CheckedChanged(object sender, EventArgs e)
    {
        if (rbAccountEnquiry.Checked)
        {
            span1.Visible = true;
            span2.Visible = false;
            ViewState["TYPE"] = "01";
            GridView1.DataSource = null;
            GridView1.DataBind();
            btnPrint.Attributes.Add("style", "visibility:hidden;");
            lblRecord.Text = "";
            txtReset();
        }
    }
    protected void rbBranchEnquiry_CheckedChanged(object sender, EventArgs e)
    {
        if (rbBranchEnquiry.Checked)
        {
            span1.Visible = false;
            span2.Visible = true;
            ViewState["TYPE"] = "02";
            GridView1.DataSource = null;
            GridView1.DataBind();
            btnPrint.Attributes.Add("style", "visibility:hidden;");
            lblRecord.Text = "";
            txtReset();
        }
    }
    public void txtReset()
    {
        txtAccountNo.Text = txtAccountTitle.Text = txtBranchCode.Text = txtBrLocation.Text = 
        txtCity.Text = txtCNIC.Text = "";
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        loadGrid();
    }
}

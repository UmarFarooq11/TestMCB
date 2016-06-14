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

public partial class TransEnquiry : System.Web.UI.Page
{
    string[] ARY;
    string RGS_SUPPORT;
    DatabaseConnection_Util _dbConfig = new DatabaseConnection_Util();
    LOV_COLLECTION lov = new LOV_COLLECTION();
    //bool _isLength;

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
            btnPrint.Attributes.Add("style", "visibility:hidden;");
            //btnPrint.Attributes.Add("onclick", "return onPrint();");
            btnPrint.Attributes.Add("onclick", "getPrint('Print_All');");
        }
    }
    private void loadGrid(string draftno,string customerRef,string account_no)
    {
        int pno = 0;
        DataSet ds = new DataSet();
        OracleParameter[] parms = new OracleParameter[7];
        parms[pno] = _dbConfig.Oracle_Param("p_DRAFTNO", OracleType.VarChar, ParameterDirection.Input, draftno); pno++;
        parms[pno] = _dbConfig.Oracle_Param("p_CUSTREFNUMBER", OracleType.VarChar, ParameterDirection.Input, customerRef); pno++;
        parms[pno] = _dbConfig.Oracle_Param("p_account_no", OracleType.VarChar, ParameterDirection.Input, account_no); pno++;
        parms[pno] = _dbConfig.Oracle_Param("P_USER_ID", OracleType.VarChar, ParameterDirection.Input, Session["U_NAME"].ToString()); pno++;
        parms[pno] = _dbConfig.Oracle_Param("p_rowid", OracleType.VarChar, ParameterDirection.Input, ""); pno++;
        parms[pno] = _dbConfig.Oracle_Param("v_retval", OracleType.VarChar, ParameterDirection.Output, ""); pno++;
        parms[pno] = _dbConfig.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        ds = _dbConfig.Oracle_GetDataSetSP("sp_Trans_Enquiry", parms);
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
        //_isLength = true;
        string DraftNo = "";
        string CustomerRef = "";
        string AccountNo="";
        Page.Validate();
        if (Page.IsValid)
        {
            if (txtDraftNo.Text == "" && txtCustomerRef.Text== "" && txtAccountNo.Text =="")
            {
                //_isLength = false;
                lblRecord.Text = "Invalid Criteria";
            }
            else
            {
                if (txtDraftNo.Text !="")
                {
                    DraftNo = "%" + txtDraftNo.Text + "%"; 
                    CustomerRef ="";
                    AccountNo="";
                }
                if (txtCustomerRef.Text != "")
                {
                    CustomerRef = "%" + txtCustomerRef.Text + "%";
                    DraftNo = ""; AccountNo = "";
                }
                if (txtAccountNo.Text != "")
                {
                    AccountNo = "%" + txtAccountNo.Text + "%";
                    DraftNo = ""; CustomerRef = "";
                }
                loadGrid(DraftNo, CustomerRef, AccountNo);
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
        //loadGrid();
    }
    protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
    {
        
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
            e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";
            //e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.GridView1, "Select$" + e.Row.RowIndex);
            //e.Row.Cells[2].Text       draftno
            //e.Row.Cells[6].Text       ref #    
            //e.Row.Cells[12].Text      A/C #
            string draftno = e.Row.Cells[2].Text;
            string company_code = e.Row.Cells[0].Text;
            string account_no = "";
            string reference_no = "";
            string user_id = Session["U_NAME"].ToString();
            e.Row.Attributes.Add("onclick", "var str='MCB';wid=window.open('EnquiryDetail.aspx?draftno=" + draftno + "&cust_ref_no=" + reference_no + "&account_no=" + account_no + "&user_id=" + Session["U_NAME"].ToString() + "&company_code=" + company_code + "', 'CS', 'left=550,top=165,height=650, width= 450 ,menubar=no,location=no,toolbar=no,scrollbars=yes,resizable=yes');return false;");

        }
    }
}

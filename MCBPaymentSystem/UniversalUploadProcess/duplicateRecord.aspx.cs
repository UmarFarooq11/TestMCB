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

public partial class UniversalUploadProcess_duplicateRecord : System.Web.UI.Page
{
    DatabaseConnection_Util _dbConfig = new DatabaseConnection_Util();
    DataSet ds = new DataSet();
    protected void Page_PreInit(object sender, EventArgs e)
    { Page.Theme = "SkinFile"; }//Session["ThemeChange"].ToString(); }
    protected void Page_Load(object sender, EventArgs e)
    {
        string company_code = Request.QueryString["company_code"].ToString();
        string file_name = Request.QueryString["file_name"].ToString();
        if (company_code != "" && file_name != "")
        {
            Get_DuplicateData(company_code, file_name);
            if (ds.Tables[0].Rows.Count > 0)
            {
                GridView1.DataSource = ds;
                GridView1.DataBind();
                lblMessage.Text = "";
            }
            else
            {
                //GridView1.DataSource = "";
                //GridView1.DataBind();
                lblMessage.Text = "No Data found.";
            }
        }
        else 
        {
            lblMessage.Text = "Company Code and file name must be required.";
        }
    }
    public DataSet Get_DuplicateData(string CompanyCode, string filename)
    {
        OracleParameter[] PR = new OracleParameter[3];
        PR[0] = _dbConfig.Oracle_Param("P_company_code", OracleType.VarChar, ParameterDirection.Input, CompanyCode);
        PR[1] = _dbConfig.Oracle_Param("P_FILE_NAME", OracleType.VarChar, ParameterDirection.Input, filename);
        PR[2] = _dbConfig.Oracle_Param("data_set", OracleType.Cursor, ParameterDirection.Output, "");
        ds = _dbConfig.Oracle_GetDataSetSP("sp_get_duplicate_records", PR);
        ViewState["TaskTable"] = ds.Tables[0];
        return ds;
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
}

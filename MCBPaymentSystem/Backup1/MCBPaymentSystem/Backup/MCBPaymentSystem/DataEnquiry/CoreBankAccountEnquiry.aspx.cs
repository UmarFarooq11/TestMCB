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
using System.Web.Services;

public partial class CoreBankAccountEnquiry : System.Web.UI.Page
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
            btnSearch.Visible = false; /*ADD*/
        }
        else if (RGS_SUPPORT.Substring(0, 1) == "1")
        {
            btnSearch.Visible = true; /*ADD*/
        }
        if (!IsPostBack)
        {
            btnCheck.Attributes.Add("onclick", "IsIBANCheck()");
        }
    }
    private void loadGrid()
    {
        string p_return = "";
        DataTable dt = new DataTable();
        OracleParameter[] parms = new OracleParameter[5];
        parms[0] = _dbConfig.Oracle_Param("p_custnic", OracleType.VarChar, ParameterDirection.Input, txtCNIC.Text);
        parms[1] = _dbConfig.Oracle_Param("p_branch_cd", OracleType.VarChar, ParameterDirection.Input, txtBranchCode.Text);
        parms[2] = _dbConfig.Oracle_Param("p_accno", OracleType.VarChar, ParameterDirection.Input, txtAccNo.Text);
        parms[3] = _dbConfig.Oracle_Param("p_iban", OracleType.VarChar, ParameterDirection.Input, txbIBAN.Text);
        parms[4] = _dbConfig.Oracle_Param("data_resultset", OracleType.Cursor, ParameterDirection.Output, "");
        dt = _dbConfig.Oracle_GetDataSetSP("sp_core_bank_acc_enquiry", parms).Tables[0];
        if (dt.Rows.Count > 0)
        {
            ViewState["TaskTable"] = dt;
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
        else
        {
            ViewState["TaskTable"] = null;
            GridView1.DataSource = null;
            GridView1.DataBind();
            lblMessage.Text = "No record found.";
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        lblMessage.Text = "";

        bool status = false;





        if (txtBranchCode.Text != "" || txtCNIC.Text != "" || txtAccNo.Text != "" || txbIBAN.Text != "")
        {

            //if (txtAccNo.Text == "" && txbIBAN.Text == "")
            //{   
            //    if(txtCNIC.Text == "")
            //    {

            //    lblMessage.Text = "Account # or IBAN is required.";
            //    return;
            //    }
            //}

            if (txtBranchCode.Text != "")
            {

                if (txtBranchCode.Text.Length != 4)
                {
                    lblMessage.Text = "Input 4 digit branch code.";
                    return;
                }

                if (txtAccNo.Text == "")
                {
                    lblMessage.Text = "Account # is required with Branch.";
                    return;

                }


            }

            //if (txtAccNo.Text != "")
            //{
            //    if (txtBranchCode.Text == "")
            //    {
            //        lblMessage.Text = "Branch  is required with Account #.";
            //        return;
            //    }

            //}





            if (txtAccNo.Text != "")
            {
                //if (txtAccNo.Text.Length !=4)
                //{                    
                //    lblMessage.Text = "Input last 4 digit of Account No.";
                //    return;
                //}

                if (txtAccNo.Text.Length < 4 || txtAccNo.Text.Length > 16)
                {
                    //lblMessage.Text = "Input last 4 digit of Account No.";
                    lblMessage.Text = "Account # digit sholuld be bewteen 4 to 16.";
                    return;
                }

            }
            if (txbIBAN.Text != "")
            {
                if (txbIBAN.Text.Length != 24)
                {

                    lblMessage.Text = "IBAN # sholuld be 24 digit.";
                    return;
                }

                if (txbIBAN.Text.Substring(0, 2).ToUpper() != "PK" || txbIBAN.Text.Substring(4, 4).ToUpper() != "MUCB")
                {
                    lblMessage.Text = "Invalid IBAN Format.";
                    return;

                }
            }




            loadGrid();
        }
        else
        {
            lblMessage.Text = "Please input search Criteria.";
        }

    }
    public void txtReset()
    {
        txtBranchCode.Text = txtCNIC.Text = txtAccNo.Text = txbIBAN.Text = "";

    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        txtReset();
        lblMessage.Text = "";
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
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        loadGrid();
    }
    [WebMethod]
    public static string IsIBANvalid(string IBAN)
    {
        try
        {
            DataTable dt = new DataTable();
            //string connString = "data source = ''; user id = 'js_payment';password='js_payment';";
            string connString = DAL_EXP1.Utility.Startup_Util.DB_Route;
            using (OracleConnection conn = new OracleConnection())
            {
                conn.ConnectionString = connString;
                using (OracleCommand cmd = new OracleCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select iban_validator('" + IBAN + "') from dual";
                    cmd.Connection = conn;
                    try
                    {
                        conn.Open();
                        using (OracleDataAdapter adp = new OracleDataAdapter(cmd))
                        {
                            adp.Fill(dt);
                        }
                    }
                    catch (Exception ex)
                    {
                        return ex.Message;
                    }
                    conn.Close();
                    return dt.Rows[0][0].ToString();
                }
            }
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }
}

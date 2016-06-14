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

public partial class PRIPostForSymbol : System.Web.UI.Page
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
        if (RGS_SUPPORT.Substring(0, 1) == "0")
        { btnSubmit.Visible = false; /*ADD*/}
        else if (RGS_SUPPORT.Substring(0, 1) == "1")
        { btnSubmit.Visible = true; /*ADD*/}
        if (!IsPostBack)
        {
            if (Request.QueryString["UID"] != null)
            {
                Session["U_NAME"] = Request.QueryString["UID"].ToString();
            }
            ddlCompanyBind();
            ddlBankBind();
            btnSubmit.Visible = false;

        }
    }
    protected void Page_PreInit(object sender, EventArgs e)
    { Page.Theme = Session["ThemeChange"].ToString(); }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (Session["U_NAME"].ToString() == "")
        {
            lbl_msg.Text = "User session has been expired, Please Re-Login.";
            return;
        }
        if (GridView1.Rows.Count > 0)
        {
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                trans_process("", "", "", "");
            }
            
        }
        
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        GetPRIForSymbol(ddlCompanyCode.SelectedValue, ddlBank.SelectedValue);
        ddlBank.Enabled = true;
        ddlCompanyCode.Enabled = true;
    }

    public DataSet GetPRIForSymbol(string company_code, string bank_code)
    {
        if (Session["U_NAME"].ToString() == "")
        {
            lbl_msg.Text = "User session has been expired, Please Re-Login.";
            return null;
        }
        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[3];
        PR[0] = _dbConfig.Oracle_Param("p_company_code", OracleType.VarChar, ParameterDirection.Input, company_code);
        PR[1] = _dbConfig.Oracle_Param("p_bank_code", OracleType.VarChar, ParameterDirection.Input, bank_code);
        PR[2] = _dbConfig.Oracle_Param("p_dataset", OracleType.Cursor, ParameterDirection.Output, "");
        DS = _dbConfig.Oracle_GetDataSetSP("sp_get_pri_postforsymbol", PR);

        if (DS.Tables[0].Rows.Count > 0)
        {
            GridView1.DataSource = DS.Tables[0];
            GridView1.DataBind();
        }
        else
        {
            lbl_msg.Text = "Data not found";
            btnSubmit.Visible = false;

        }
        return DS;
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
            ddlCompanyCode.Items.Insert(0, new ListItem("Select Company", ""));
        }

    }
    public void ddlBankBind()
    {
        DataSet ds = new DataSet();
        OracleParameter[] PR = new OracleParameter[5];
        PR[0] = _dbConfig.Oracle_Param("P_BANK_CODE", OracleType.VarChar, ParameterDirection.Input, "%");
        PR[1] = _dbConfig.Oracle_Param("P_AREA_CODE", OracleType.VarChar, ParameterDirection.Input, "%");
        PR[2] = _dbConfig.Oracle_Param("P_BANK_NAME", OracleType.VarChar, ParameterDirection.Input, "%");
        PR[3] = _dbConfig.Oracle_Param("P_IS_MCB", OracleType.VarChar, ParameterDirection.Input, "N");
        PR[4] = _dbConfig.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        ds = _dbConfig.Oracle_GetDataSetSP("SP_SETUP_BANK_ALL", PR);
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlBank.DataSource = ds;
            ddlBank.DataValueField = "BANK_CODE";
            ddlBank.DataTextField = "BANK_NAME";
            ddlBank.DataBind();
            ddlBank.Items.Insert(0, new ListItem("Select Bank", ""));
        }


    }
    protected void ddlBank_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlBank.SelectedIndex == 0)
        {
            ddlCompanyCode.SelectedIndex = 0;
            ddlCompanyCode.Enabled = true;
        }
        else
        {
            ddlCompanyCode.SelectedIndex = 0;
            ddlCompanyCode.Enabled = false;
        }
        GridView1.DataSource = null;
        GridView1.DataBind();
        btnSubmit.Visible = false;
        lbl_msg.Text = "";

    }
    protected void ddlCompanyCode_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCompanyCode.SelectedIndex == 0)
        {
            ddlBank.SelectedIndex = 0;
            ddlBank.Enabled = true;
        }
        else
        {
            ddlBank.SelectedIndex = 0;
            ddlBank.Enabled = false;
        }
        GridView1.DataSource = null;
        GridView1.DataBind();
        btnSubmit.Visible = false;
        lbl_msg.Text = "";

    }

    public string trans_process(string p_company_code, string p_bank_code, string p_cust_refno, string p_userid)
    {
        string retVal = "";
        OracleParameter[] param = new OracleParameter[5];
        param[0] = _dbConfig.Oracle_Param("p_company_code", OracleType.VarChar, ParameterDirection.Input, p_company_code);
        param[1] = _dbConfig.Oracle_Param("p_bank_code", OracleType.VarChar, ParameterDirection.Input, p_bank_code);
        param[2] = _dbConfig.Oracle_Param("p_cust_refno", OracleType.VarChar, ParameterDirection.Input, p_cust_refno);
        param[3] = _dbConfig.Oracle_Param("p_userid", OracleType.VarChar, ParameterDirection.Input, p_userid);
        param[4] = _dbConfig.Oracle_Param("p_return", OracleType.VarChar, ParameterDirection.Output, "");
        retVal = _dbConfig.OracleExecuteSP_GetReturnVal("sp_pri_poston_symbol", param, 4);
        return retVal;
    }
    protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataSet ds = GetPRIForSymbol(ddlCompanyCode.SelectedValue, ddlBank.SelectedValue);
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
}
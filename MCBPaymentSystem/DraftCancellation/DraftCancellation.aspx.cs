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

public partial class DraftCancellaion_DraftCancellation : System.Web.UI.Page
{
    string[] ARY;
    string RGS_SUPPORT;
    string rowid = "";
    DatabaseConnection_Util _dbConfig = new DatabaseConnection_Util();
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
            GridView1.Columns[9].Visible = false;
        }
        else if (RGS_SUPPORT.Substring(0, 1) == "1")
        {
            GridView1.Columns[9].Visible = true; /*ADD*/
        }
        if (Request.QueryString["UID"] != null)
        {
            Session["U_NAME"] = Request.QueryString["UID"].ToString();
        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton imgbtn = (ImageButton)sender;
        GridViewRow row = (GridViewRow)imgbtn.NamingContainer;
        rowid = GridView1.Rows[row.RowIndex].Cells[0].Text;
        Response.Redirect("../DraftCancellation/frmRPS_DraftCancellationSPC.aspx?s1=" + Request.QueryString[0].ToString() + "&UID=" + Session["U_NAME"].ToString() + "&rowid=" + Server.UrlEncode(rowid));
    }
    protected void Page_PreInit(object sender, EventArgs e)
    { Page.Theme = Session["ThemeChange"].ToString(); }
    protected void BTN_SEARCH_Click(object sender, EventArgs e)
    {
        if (Session["U_NAME"].ToString() == "")
        {
            lblMessage.Text = "User session has been expired, please re-login";
            return;
        }
        Get_data(TXT_DraftNo.Text, TXT_CustRefNo.Text, txt_company_code.Text);
    }
    protected void BTN_CLEAR_Click(object sender, EventArgs e)
    {
        TXT_DraftNo.Text = "";
        txt_company_code.Text = "";
        TXT_CustRefNo.Text = "";
        Get_data("", "", "");
    }
    public void Get_data(string draftno, string remitterrefno, string company_code)
    {
        DataSet dsReport = new DataSet();
        OracleParameter[] parm = new OracleParameter[5];
        parm[0] = _dbConfig.Oracle_Param("p_draftno", OracleType.VarChar, ParameterDirection.Input, draftno);
        parm[1] = _dbConfig.Oracle_Param("p_customerref", OracleType.VarChar, ParameterDirection.Input, remitterrefno);
        parm[2] = _dbConfig.Oracle_Param("p_company_code", OracleType.VarChar, ParameterDirection.Input, company_code);
        parm[3] = _dbConfig.Oracle_Param("p_userid", OracleType.VarChar, ParameterDirection.Input, Session["U_NAME"].ToString());
        parm[4] = _dbConfig.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");
        DataSet ds = _dbConfig.Oracle_GetDataSetSP("rps_sp_draft_getallforcancel", parm);
        if (ds.Tables[0].Rows.Count > 0)
        {
            GridView1.DataSource = ds.Tables[0];
            GridView1.DataBind();
        }
        else
        {
            GridView1.DataSource = null;
            GridView1.DataBind();
        }

    }
}

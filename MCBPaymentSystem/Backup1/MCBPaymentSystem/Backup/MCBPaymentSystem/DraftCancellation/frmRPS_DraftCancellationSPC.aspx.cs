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

public partial class DraftCancellation_frmRPS_DraftCancellationSPC : System.Web.UI.Page
{
    string[] ARY;
    string RGS_SUPPORT;
    //string rowid;
    DatabaseConnection_Util _dbConfig = new DatabaseConnection_Util();
    LOV_COLLECTION lov = new LOV_COLLECTION();
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
            btnUpdate.Visible = false;
        }
        else if (RGS_SUPPORT.Substring(0, 1) == "1")
        {
            btnUpdate.Visible = true;
        }
        if (!IsPostBack)
        {
            btnUpdate.Attributes.Add("onclick", "return funConfirm();");
            ViewState["rowid"] = Request.QueryString["rowid"].ToString();
            Get_Value(ViewState["rowid"].ToString());
            GetStatusCodeBind();
        }
    }
    protected void Page_PreInit(object sender, EventArgs e)
    { Page.Theme = Session["ThemeChange"].ToString(); }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        if (Session["U_NAME"].ToString() == "")
        {
            lblmessage.Text = "User session has been expired, please re-login";
            return;
        }
        Submit(ViewState["rowid"].ToString(), txtDraftNo.Text, ddlCancelCode.SelectedValue, Session["U_NAME"].ToString(), ddlCancelAction.SelectedValue, "S", txtCompanyCode.Text);
        ViewState["rowid"] = "";
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        BackPage();
    }
    private void BackPage()
    {
        Response.Redirect("../DraftCancellation/DraftCancellation.aspx?s1=" + Request.QueryString[0].ToString() + "&UID=" + Session["U_NAME"].ToString());
    }
    private void Submit(string rowid, string draftid, string cancel_no, string userid, string cancel_action, string p_type, string company_code)
    {
        try
        {
            DataSet dsReport = new DataSet();
            OracleParameter[] parm = new OracleParameter[8];
            parm[0] = _dbConfig.Oracle_Param("p_rowid", OracleType.VarChar, ParameterDirection.Input, rowid);
            parm[1] = _dbConfig.Oracle_Param("p_draftid", OracleType.VarChar, ParameterDirection.Input, draftid);
            parm[2] = _dbConfig.Oracle_Param("p_cancel_no", OracleType.VarChar, ParameterDirection.Input, cancel_no);
            parm[3] = _dbConfig.Oracle_Param("p_userid", OracleType.VarChar, ParameterDirection.Input, userid);
            parm[4] = _dbConfig.Oracle_Param("p_cancel_action", OracleType.VarChar, ParameterDirection.Input, cancel_action);
            parm[5] = _dbConfig.Oracle_Param("p_type", OracleType.VarChar, ParameterDirection.Input, p_type);
            parm[6] = _dbConfig.Oracle_Param("p_company_code", OracleType.VarChar, ParameterDirection.Input, company_code);
            parm[7] = _dbConfig.Oracle_Param("p_return", OracleType.VarChar, ParameterDirection.Output, "");
            string retVal = _dbConfig.OracleExecuteSP_GetReturnVal("RPS_SP_DraftCancellation_Add", parm, 7);
            lblmessage.Text = retVal;
            if (retVal.StartsWith("0"))
            {
                btnUpdate.Enabled = false;
            }
        }
        catch (Exception ex)
        {
            lblmessage.Text = ex.Message;
        }
    }
    private void GetStatusCodeBind()
    {
        DataSet dsReport = new DataSet();
        OracleParameter[] parm = new OracleParameter[3];
        parm[0] = _dbConfig.Oracle_Param("v_StatusCode", OracleType.VarChar, ParameterDirection.Input, "%");
        parm[1] = _dbConfig.Oracle_Param("v_Description", OracleType.VarChar, ParameterDirection.Input, "%");
        parm[2] = _dbConfig.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DataSet ds = _dbConfig.Oracle_GetDataSetSP("SP_RPS_DetailStatus_LOV", parm);
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlCancelCode.DataSource = ds.Tables[0];
            ddlCancelCode.DataTextField = "DESCRIPTION";
            ddlCancelCode.DataValueField = "code";
            ddlCancelCode.DataBind();
        }
    }
    private void Get_Value(string rowid)
    {
        DataSet dsReport = new DataSet();
        OracleParameter[] parm = new OracleParameter[2];
        parm[0] = _dbConfig.Oracle_Param("p_rowid", OracleType.VarChar, ParameterDirection.Input, rowid);
        parm[1] = _dbConfig.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");
        DataSet ds = _dbConfig.Oracle_GetDataSetSP("RPS_SP_DraftCancellationSPC", parm);
        if (ds.Tables[0].Rows.Count > 0)
        {
            txtCompanyCode.Text = ds.Tables[0].Rows[0]["COMPANY_CODE"].ToString();
            txtCompanyName.Text = ds.Tables[0].Rows[0]["COMPANY_NAME"].ToString();
            txtBankCode.Text = ds.Tables[0].Rows[0]["bank_code"].ToString();
            txtBankName.Text = ds.Tables[0].Rows[0]["bank_name"].ToString();
            txtAmount.Text = ds.Tables[0].Rows[0]["draftamount"].ToString();
            txtDraftNo.Text = ds.Tables[0].Rows[0]["DraftNo"].ToString();
            txtCustomerRef.Text = ds.Tables[0].Rows[0]["custrefnumber"].ToString();
            txtTransType.Text = ds.Tables[0].Rows[0]["trans_type"].ToString();

        }
    }

}





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

public partial class IBANIdentificy : System.Web.UI.Page
{
    string[] ARY;
    string RGS_SUPPORT;
    TextBox txtIBANGrD;
    DatabaseConnection_Util _dbConfig = new DatabaseConnection_Util();
    LOV_COLLECTION lov = new LOV_COLLECTION();
    DataSet ds = new DataSet();
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
        { btnSubmit.Visible = false; /*ADD*/}
        else if (RGS_SUPPORT.Substring(0, 1) == "1")
        { btnSubmit.Visible = true; /*ADD*/}

        if (!Page.IsPostBack)
        {
            //btnSubmit.Enabled = false;
            //txtagent.Attributes.Add("readonly", "readonly");

            btnSubmit.Attributes.Add("style", "visibility:hidden;");
            btnSubmit.Attributes.Add("onclick", "return funConfirm();");

            lblFieldTrans.Attributes.Add("style", "visibility:hidden;");
            lblTransaction.Attributes.Add("style", "visibility:hidden;");
            lblTotalFile.Attributes.Add("style", "visibility:hidden;");
            lblTotalRecord.Attributes.Add("style", "visibility:hidden;");
            //btnGetBank.Attributes.Add("style", "visibility:hidden;");
            ddlCompanyBind();
            dllFilename();
            btnConvertAll.Attributes.Add("onclick", "return funConfirm_All();");


        }
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
        }
    }
    public void dllFilename()
    {
        DataSet ds = new DataSet();
        OracleParameter[] parms = new OracleParameter[3];
        parms[0] = _dbConfig.Oracle_Param("p_company_code", OracleType.VarChar, ParameterDirection.Input, ddlCompanyCode.SelectedValue.ToString());
        parms[1] = _dbConfig.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        parms[2] = _dbConfig.Oracle_Param("v_retval", OracleType.VarChar, ParameterDirection.Output, "");
        ds = _dbConfig.Oracle_GetDataSetSP("SP_Data_Segregation_LOV", parms);
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlFile.DataSource = ds;
            ddlFile.DataValueField = "FILE_NAME";
            ddlFile.DataTextField = "FILE_NAME";
            ddlFile.DataBind();

            ViewState["dataset"] = ds;
            lblTotalRecord.Text = ds.Tables[0].Rows[0]["total_records"].ToString();
            lblTotalRecord.Attributes.Add("style", "visibility:visible;");
            lblTotalFile.Attributes.Add("style", "visibility:visible;");
        }
        else
        {
            ddlFile.DataSource = string.Empty;
            ddlFile.DataValueField = "";
            ddlFile.DataTextField = "";
            ddlFile.DataBind();
            btnSubmit.Attributes.Add("style", "visibility:hidden;");
            grdTransaction.DataSource = null;
            grdTransaction.DataBind();
        }
    }
    private void loadGrid()
    {
        DataSet ds = new DataSet();
        OracleParameter[] parms = new OracleParameter[3];
        parms[0] = _dbConfig.Oracle_Param("p_company_code", OracleType.VarChar, ParameterDirection.Input, ddlCompanyCode.SelectedValue.ToString());
        parms[1] = _dbConfig.Oracle_Param("p_file_name", OracleType.VarChar, ParameterDirection.Input, (ddlFile.SelectedItem == null) ? "" : ddlFile.SelectedItem.ToString());
        parms[2] = _dbConfig.Oracle_Param("data_resultset", OracleType.Cursor, ParameterDirection.Output, "");
        ds = _dbConfig.Oracle_GetDataSetSP("sp_get_data_seg_iban", parms);
        if (ds.Tables[0].Rows.Count > 0)
        {
            grdTransaction.DataSource = ds;
            grdTransaction.DataBind();
            lblTransaction.Text = ds.Tables[0].Rows.Count.ToString();
            btnSubmit.Attributes.Add("style", "visibility:visible;");
            lblFieldTrans.Attributes.Add("style", "visibility:visible;");
            lblTransaction.Attributes.Add("style", "visibility:visible;");
        }
        else
        {
            btnSubmit.Attributes.Add("style", "visibility:hidden;");
            grdTransaction.DataSource = null;
            grdTransaction.DataBind();
            lblTransaction.Text = ds.Tables[0].Rows.Count.ToString();
            lblFieldTrans.Attributes.Add("style", "visibility:hidden;");
            lblTransaction.Attributes.Add("style", "visibility:hidden;");
        }
    }
    protected void ddlCompanyCode_SelectedIndexChanged(object sender, EventArgs e)
    {
        dllFilename();
        lblMessage.Text = "";
    }
    protected void ddlFile_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        ds = (DataSet)ViewState["dataset"];
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                if (ddlFile.SelectedValue.ToString() == ds.Tables[0].Rows[i]["FILE_NAME"].ToString())
                {
                    lblTotalRecord.Text = ds.Tables[0].Rows[i]["total_records"].ToString();
                    lblTotalFile.Attributes.Add("style", "visibility:visible;");
                    lblTotalRecord.Attributes.Add("style", "visibility:visible;");
                }
            }
        }
        grdTransaction.DataSource = null;
        grdTransaction.DataBind();
        btnSubmit.Attributes.Add("style", "visibility:hidden;");
        lblTransaction.Attributes.Add("style", "visibility:hidden;");
        lblFieldTrans.Attributes.Add("style", "visibility:hidden;");
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        lblMessage.Text = "";
        try
        {
            for (int i = 0; i < grdTransaction.Rows.Count; i++)
            {
                string IBAN = ((TextBox)grdTransaction.Rows[i].FindControl("txtIBAN")).Text;
                Label lblStatus = (Label)grdTransaction.Rows[i].FindControl("lblStatus");
                CheckBox Ckb_Select = (CheckBox)grdTransaction.Rows[i].FindControl("Ckb_Select");
                if (Ckb_Select.Checked == true && IBAN != "")
                {
                    string p_return = "";
                    DataSet ds = new DataSet();
                    OracleParameter[] parms = new OracleParameter[4];
                    parms[0] = _dbConfig.Oracle_Param("p_company_code", OracleType.VarChar, ParameterDirection.Input, ddlCompanyCode.SelectedValue.ToString());
                    parms[1] = _dbConfig.Oracle_Param("p_rowid", OracleType.VarChar, ParameterDirection.Input, grdTransaction.Rows[i].Cells[0].Text);
                    parms[2] = _dbConfig.Oracle_Param("p_iban", OracleType.VarChar, ParameterDirection.Input, IBAN);
                    parms[3] = _dbConfig.Oracle_Param("p_retval", OracleType.VarChar, ParameterDirection.Output, "");
                    p_return = _dbConfig.OracleExecuteSP_GetReturnVal("sp_seg_iban_update", parms, 3);
                    lblStatus.Text = p_return.Split(';')[1].ToString();
                    if (p_return.StartsWith("0"))
                    {
                        Ckb_Select.Checked = false;
                        Ckb_Select.Enabled = false;
                    }
                }
            }
            //dllFilename();
            //ddlFile_SelectedIndexChanged(null, null);
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
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
    protected void grdTransaction_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        if ((e.Row.RowType == DataControlRowType.Header))
        {
            ((CheckBox)e.Row.FindControl("Ckb_SelectALL")).Attributes.Add("onclick", "javascript:SelectAll('" + ((CheckBox)e.Row.FindControl("Ckb_SelectALL")).ClientID + "')");
        }
        //}
    }
    protected void btnBanToIBAN_Click(object sender, EventArgs e)
    {
        string InputIBAN = "";
        GridViewRow gvr = (GridViewRow)(sender as Control).Parent.Parent;
        txtIBANGrD = (TextBox)grdTransaction.Rows[gvr.RowIndex].FindControl("txtIBAN");
        InputIBAN = (txtIBANGrD.Text == "" ? grdTransaction.Rows[gvr.RowIndex].Cells[1].Text : txtIBANGrD.Text);
        string str = get_BAN_To_IBAN(InputIBAN);
        txtIBANGrD.Text = str;
    }
    public string get_BAN_To_IBAN(string ban)
    {
        OracleConnection oracleConn = new OracleConnection(_dbConfig.ConnectionString);
        OracleCommand oracleCmd = new OracleCommand();
        try
        {
            oracleCmd.Connection = oracleConn;
            oracleCmd.CommandText = "ban_to_iban";
            oracleCmd.CommandType = CommandType.StoredProcedure;
            oracleCmd.Parameters.Add("bban", OracleType.VarChar).Value = ban;
            oracleCmd.Parameters.Add("return", OracleType.VarChar, 30).Direction = ParameterDirection.ReturnValue;
            oracleConn.Open();
            oracleCmd.ExecuteNonQuery();
            oracleConn.Close();
        }
        catch (Exception ex)
        {
            oracleConn.Close();
            lblMessage.Text = "1;" + ex.Message;
        }
        return Convert.ToString(oracleCmd.Parameters["return"].Value);
    }
    protected void btnConvertAll_Click(object sender, EventArgs e)
    {
        lblMessage.Text = "";
        foreach (GridViewRow dr in grdTransaction.Rows)
        {
            txtIBANGrD = (TextBox)dr.FindControl("txtIBAN");
            Label lblStatus = (Label)dr.FindControl("lblStatus");
            string str = get_BAN_To_IBAN(txtIBANGrD.Text);
            if (str.StartsWith("0"))
            {
                txtIBANGrD.Text = str;
                lblStatus.Text = "";
            }
            else
            {
                txtIBANGrD.Text = "";
                lblStatus.Text = str;
            }
        }
    }

}
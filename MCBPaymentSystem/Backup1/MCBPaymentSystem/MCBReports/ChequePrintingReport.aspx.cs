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
using Microsoft.Reporting.WebForms;
//using Report;
using System.Data.OleDb;
using System.Collections.Generic;
using System.Data.OracleClient;

public partial class ChequePrintingReport : System.Web.UI.Page
{
    DatabaseConnection_Util _dbConfig = new DatabaseConnection_Util();
    LOV_COLLECTION lov = new LOV_COLLECTION();
    static string usertype = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetCacheability(HttpCacheability.ServerAndNoCache);
        lblError.Text = "";

        if (!Page.IsPostBack)
        {
            DataSet ds = new DataSet();
            if (Request.QueryString["UID"] != null)
            {
                Session["U_NAME"] = Request.QueryString["UID"].ToString();
            }
            else
            {
                if (Session["U_NAME"] == null)
                {
                    String PR_id = Request.QueryString["ProjectID"].ToString();
                    ds = lov.SP_GETDATA_DPAGE(PR_id);
                    Response.Redirect(ds.Tables[0].Rows[0]["DPage"].ToString());
                }
            }

            ddlCompanyBind();
            dllFilename();
            //txtAuthorize1.Text = "MOHAMMAD IBRAHIM";
            //txtAuthorize2.Text = "ALI JABBULI";
            //txtIBC1.Text = "5212";
            //txtIBC2.Text = "5421";
        }
        /*txtAuthorize1.Text = "TEST123";
        txtAuthorize2.Text = "TEST789";
        txtIBC1.Text = "1212";
        txtIBC2.Text = "1313";*/
        //ddlCompanyCode.SelectedValue = "EZRMT";
        
        if (Convert.ToString(Request.QueryString["errorMsg"]) != null)
        {lblError.Text = Request.QueryString["errorMsg"].ToString();}
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Page.Validate();
        if (Page.IsValid)
        {
            if (ValidateDate())
            {
                Response.Redirect("DraftTransactionRpt.aspx?CompanyCode=" + ddlCompanyCode.SelectedValue + "&fileName=" + ddlFile.SelectedValue + "&Authorize1=" + txtAuthorize1.Text + "&Authorize2=" + txtAuthorize2.Text + "&IBC1=" + txtIBC1.Text + "&IBC2=" + txtIBC2.Text);
            }
        }
    }
    private bool ValidateDate()
    {
        /*if ((this.txtFromDate.Text == "") || (this.txtToDate.Text == ""))
        {
            lblError.Text = "Invalid Date";
            txtToDate.Focus();
            return false;
        }
        else if (Convert.ToDateTime(this.txtToDate.Text) < Convert.ToDateTime(this.txtFromDate.Text))
        {
            lblError.Text = "FromDate should be less than ToDate";
            txtToDate.Focus();
            return false;
        }*/
        return true;
    }
    protected void ddlCompanyCode_SelectedIndexChanged(object sender, EventArgs e)
    {
        dllFilename();
    }
    public void ddlCompanyBind()
    {
        DataSet ds = new DataSet();
        DataSet dsu = new DataSet();
        DataTable dt = new DataTable();
        dsu = lov.SP_GET_USERIFNO(Session["U_NAME"].ToString());
        if (dsu.Tables[0].Rows.Count > 0)
        {
            usertype = dsu.Tables[0].Rows[0]["USER_TYPE"].ToString();
            if (usertype.ToString() != "COMPANY")
            {
                ds = lov.Get_Company_setup_lov("%", "%");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    //DataRow dr = ds.Tables[0].NewRow();
                    //dr["Company_Code"] = "AAA";
                    //dr["Company_Name"] = "ALL";
                    //ds.Tables[0].Rows.Add(dr);
                    dt = ds.Tables[0];
                    dt.DefaultView.Sort = "Company_Code ASC";
                    dt = dt.DefaultView.ToTable();
                    ddlCompanyCode.DataSource = dt;
                    ddlCompanyCode.DataValueField = "Company_Code";
                    ddlCompanyCode.DataTextField = "Company_Name";
                    ddlCompanyCode.DataBind();
                    //((DropDownList)FormView1.FindControl("ddlCompanyCode_EDIT")).SelectedValue = Session["COMCODE"].ToString();
                }
                else
                {

                }
            }
        }
    }
    public void dllFilename()
    {
        DataSet ds = new DataSet();
        OracleParameter[] parms = new OracleParameter[3];
        parms[0] = _dbConfig.Oracle_Param("p_company_code", OracleType.VarChar, ParameterDirection.Input, ddlCompanyCode.SelectedValue.ToString());
        parms[1] = _dbConfig.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        parms[2] = _dbConfig.Oracle_Param("v_retval", OracleType.VarChar, ParameterDirection.Output, "");
        ds = _dbConfig.Oracle_GetDataSetSP("SP_DraftFileName_LOV", parms);
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlFile.DataSource = ds;
            ddlFile.DataValueField = "FILE_NAME";
            ddlFile.DataTextField = "FILE_NAME";
            ddlFile.DataBind();
           // ddlFile.SelectedValue = "EZ REMIT.xls";
            /*ViewState["dataset"] = ds;
            lblTotalRecord.Text = ds.Tables[0].Rows[0]["total_records"].ToString();
            lblTotalRecord.Attributes.Add("style", "visibility:visible;");
            lblTotalFile.Attributes.Add("style", "visibility:visible;");*/
        }
        else
        {
            ddlFile.DataSource = string.Empty;
            ddlFile.DataValueField = "";
            ddlFile.DataTextField = "";
            ddlFile.DataBind();

            /*btnSubmit.Attributes.Add("style", "visibility:hidden;");
            grdTransaction.DataSource = null;
            grdTransaction.DataBind();*/
        }

    }
    protected void Page_PreInit(object sender, EventArgs e)
    {
        Page.Theme = Session["ThemeChange"].ToString();
    }
}

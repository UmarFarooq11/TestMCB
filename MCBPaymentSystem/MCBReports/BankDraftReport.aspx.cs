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

public partial class MCBReports_BankDraftReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            ddlCompanyBind();
            dllFilename();
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {

    }
    protected void ddlCompanyCode_SelectedIndexChanged(object sender, EventArgs e)
    {
        dllFilename();
    }
    public void ddlCompanyBind()
    {
        //DataSet ds = new DataSet();
        //DataSet dsu = new DataSet();
        //DataTable dt = new DataTable();
        //dsu = lov.SP_GET_USERIFNO(Session["U_NAME"].ToString());
        //if (dsu.Tables[0].Rows.Count > 0)
        //{
        //    usertype = dsu.Tables[0].Rows[0]["USER_TYPE"].ToString();
        //    if (usertype.ToString() != "COMPANY")
        //    {
        //        ds = lov.Get_Company_setup_lov("%", "%");
        //        if (ds.Tables[0].Rows.Count > 0)
        //        {
        //            //DataRow dr = ds.Tables[0].NewRow();
        //            //dr["Company_Code"] = "AAA";
        //            //dr["Company_Name"] = "ALL";
        //            //ds.Tables[0].Rows.Add(dr);
        //            dt = ds.Tables[0];
        //            dt.DefaultView.Sort = "Company_Code ASC";
        //            dt = dt.DefaultView.ToTable();
        //            ddlCompanyCode.DataSource = dt;
        //            ddlCompanyCode.DataValueField = "Company_Code";
        //            ddlCompanyCode.DataTextField = "Company_Name";
        //            ddlCompanyCode.DataBind();
        //            //((DropDownList)FormView1.FindControl("ddlCompanyCode_EDIT")).SelectedValue = Session["COMCODE"].ToString();
        //        }
        //        else
        //        {

        //        }
        //    }
        //}
    }
    public void dllFilename()
    {
        //DataSet ds = new DataSet();
        //OracleParameter[] parms = new OracleParameter[3];
        //parms[0] = _dbConfig.Oracle_Param("p_company_code", OracleType.VarChar, ParameterDirection.Input, ddlCompanyCode.SelectedValue.ToString());
        //parms[1] = _dbConfig.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        //parms[2] = _dbConfig.Oracle_Param("v_retval", OracleType.VarChar, ParameterDirection.Output, "");
        //ds = _dbConfig.Oracle_GetDataSetSP("SP_DraftFileName_LOV", parms);
        //if (ds.Tables[0].Rows.Count > 0)
        //{
        //    ddlFile.DataSource = ds;
        //    ddlFile.DataValueField = "FILE_NAME";
        //    ddlFile.DataTextField = "FILE_NAME";
        //    ddlFile.DataBind();
        //    // ddlFile.SelectedValue = "EZ REMIT.xls";
        //    /*ViewState["dataset"] = ds;
        //    lblTotalRecord.Text = ds.Tables[0].Rows[0]["total_records"].ToString();
        //    lblTotalRecord.Attributes.Add("style", "visibility:visible;");
        //    lblTotalFile.Attributes.Add("style", "visibility:visible;");*/
        //}
        //else
        //{
        //    ddlFile.DataSource = string.Empty;
        //    ddlFile.DataValueField = "";
        //    ddlFile.DataTextField = "";
        //    ddlFile.DataBind();

        //    /*btnSubmit.Attributes.Add("style", "visibility:hidden;");
        //    grdTransaction.DataSource = null;
        //    grdTransaction.DataBind();*/
        //}

    }
}

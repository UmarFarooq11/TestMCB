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
using System.IO;

public partial class DetailNRAccountStatement : System.Web.UI.Page
{
    string[] ARY;
    string RGS_SUPPORT;
    DatabaseConnection_Util _dbConfig = new DatabaseConnection_Util();
    LOV_COLLECTION lov = new LOV_COLLECTION();
    static string companycode;
    static string companyname;
    public static string _CompanyName = "";
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
            BtnExport.Enabled = false; /*ADD*/
        }
        else if (RGS_SUPPORT.Substring(0, 1) == "1")
        {
            BtnExport.Enabled = true;/*ADD*/
        }
        if (RGS_SUPPORT.Substring(3, 1) == "0")
        {
            Response.Redirect("../MasterPage/Default2.aspx"); /*QUERY*/
            MessageClass.MessageBox.Show("Access Deined");
        }
        Session["U_NAME"] = Request.QueryString["UID"].ToString();
        if (!IsPostBack)
        {
            ViewState["CompanyCode"] = "";
            GetCompany();
        }
    }
    protected void Page_PreInit(object sender, EventArgs e)
    {
        //Page.Theme = Session["ThemeChange"].ToString(); 
        Page.Theme = "SkinFile"; //Session["ThemeChange"].ToString(); 
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        lblMessage.Text = "";
        DataTable dt = GridDataSource();
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
    public void GetCompany()
    {
        DataSet ds = new DataSet();
        DataSet dsC = new DataSet();
        DataTable dt = new DataTable();
        dsC = lov.SP_GET_COMPANYNAME(Session["U_NAME"].ToString());
        if (dsC.Tables[0].Rows.Count > 0)
        {
            ViewState["CompanyCode"] = dsC.Tables[0].Rows[0]["company_code"].ToString();
        }
        else
        {
            ViewState["CompanyCode"] = "";
            lblMessage.Text = "Company code not define against User ID.";
        }
    }
    public DataTable GridDataSource()
    {
        DataTable dt = new DataTable();
        try
        {
            OracleParameter[] PR = new OracleParameter[4];
            PR[0] = _dbConfig.Oracle_Param("p_company_code", OracleType.VarChar, ParameterDirection.Input, ViewState["CompanyCode"].ToString() == "" ? "" : ViewState["CompanyCode"].ToString());
            PR[1] = _dbConfig.Oracle_Param("p_from_dt", OracleType.VarChar, ParameterDirection.Input,txtFormDate.Text);
            PR[2] = _dbConfig.Oracle_Param("p_to_dt", OracleType.VarChar, ParameterDirection.Input, txtToDate.Text);
            PR[3] = _dbConfig.Oracle_Param("data_set", OracleType.Cursor, ParameterDirection.Output, "");
            dt = _dbConfig.Oracle_GetDataSetSP("sp_core_nr_ac_satmnt_rpt", PR).Tables[0];
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
        return dt;
    }
    protected void BtnExport_Click(object sender, EventArgs e)
    {
        lblMessage.Text = "";
        if (!String.IsNullOrEmpty(txtFormDate.Text))
        {
            if (GridView1.Rows.Count > 0)
            {
                fillrecord(ref GridView1);
            }
            else
            {
                DataTable dt = GridDataSource();
                dt.Columns.Remove("ord");
                GridView tmpgrd = new GridView();
                tmpgrd.DataSource = dt;
                tmpgrd.DataBind();
                fillrecord(ref tmpgrd);
            }
        }
        #region
        //if (!String.IsNullOrEmpty(txtDate.Text))
        //{
        //    if (GridView1.Rows.Count > 0)
        //    {
        //        GridDataSource();
        //    }
        //    Response.Clear();
        //    Response.AddHeader("content-disposition", "attachment;filename=DetailNRAccountStatement.xls");
        //    Response.Charset = "";
        //    Response.ContentType = "application/vnd.xls";
        //    StringWriter StringWriter = new System.IO.StringWriter();
        //    HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(StringWriter);

        //    GridView1.DataSource = (DataSet)ViewState["data1"];
        //    GridView1.AllowPaging = false;
        //    GridView1.DataBind();
        //    GridView1.RenderControl(HtmlTextWriter);

        //    string str = HtmlTextWriter.InnerWriter.ToString();
        //    str = HttpUtility.UrlDecode(str);
        //    str = HttpUtility.UrlDecode(StringWriter.ToString());
        //    StringReader sr = new StringReader(str);

        //    Response.Write(StringWriter.ToString());
        //    Response.End();
        //}
        //else
        //{

        //}
        #endregion
    }
    private void fillrecord(ref GridView dgReport)
    {
        try
        {
            int colspan = 3;
            Response.Clear();
            Response.ClearHeaders();
            Response.AddHeader("content-disposition", "attachment;filename=DetailNRAccountStatement.xls");
            Response.Charset = "";
            EnableViewState = false;
            Response.ContentType = "application/excel.xls";
            System.IO.StringWriter stringWrite = new System.IO.StringWriter();
            HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
            htmlWrite.Write("<table>");
            htmlWrite.Write("<tr><td colspan=" + colspan + " class=tdCenter>" + "<CENTER><H3> Balance Report </H3></CENTER></tr>");
            htmlWrite.Write("</table>");
            string style = @"<style> .textmode { mso-number-format:\@; } </style>";
            for (int i = 0; i < dgReport.Rows.Count; i++)
            {
                GridViewRow row = dgReport.Rows[i];
                row.Cells[1].Attributes.Add("class", "textmode");
            }
            htmlWrite.Write(style);
            dgReport.RenderControl(htmlWrite);
            Response.Write(stringWrite.ToString());
            Response.End();
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message.ToString();
        }
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        //return;
    }
    
}

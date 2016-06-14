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
using System.Collections.Specialized;

public partial class A2ATransaction : System.Web.UI.Page
{
    string[] ARY;
    string RGS_SUPPORT;
    DatabaseConnection_Util db = new DatabaseConnection_Util();
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
        { btnSubmit.Visible = false; /*ADD*/}
        else if (RGS_SUPPORT.Substring(0, 1) == "1")
        { btnSubmit.Visible = true; /*ADD*/}

        if (!Page.IsPostBack)
        {
            btnSubmit.Attributes.Add("style", "visibility:hidden;");
            btnSubmit.Attributes.Add("onclick", "return funConfirm();");
        }
    }
    public void FetchData()
    {
        int pno = 0;
        DataSet ds = new DataSet();
        OracleParameter[] parms = new OracleParameter[3];
        parms[pno] = db.Oracle_Param("p_xpin", OracleType.VarChar, ParameterDirection.Input, txtXpin.Text); pno++;
        parms[pno] = db.Oracle_Param("p_cust_ref_no", OracleType.VarChar, ParameterDirection.Input, txtCustomerRef.Text); pno++;
        parms[pno] = db.Oracle_Param("p_data_set", OracleType.Cursor, ParameterDirection.Output, "");
        ds = db.Oracle_GetDataSetSP("sp_hold_trans_fetch", parms);
        if (ds.Tables[0].Rows.Count > 0)
        {
            GridView1.DataSource = ds.Tables[0];
            GridView1.DataBind();
            btnSubmit.Attributes.Add("style", "visibility:visible;");
        }
        else
        {
            btnSubmit.Attributes.Add("style", "visibility:hidden;");
            GridView1.DataSource = null;
            GridView1.DataBind();
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            FetchData();
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }
    public void Execute_sp()
    {
        string v_return = "";
        Label lblStatus;
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            lblStatus = ((Label)GridView1.Rows[i].FindControl("lblStatus"));
            if (((CheckBox)GridView1.Rows[i].FindControl("cbPublish")).Checked == true)
            {
                int pno = 0;
                OracleParameter[] parm = new OracleParameter[3];
                parm[pno] = db.Oracle_Param("p_row_id", OracleType.VarChar, ParameterDirection.Input, GridView1.Rows[i].Cells[0].Text); pno++;
                parm[pno] = db.Oracle_Param("p_user_id", OracleType.VarChar, ParameterDirection.Input, Session["U_NAME"].ToString()); pno++;
                parm[pno] = db.Oracle_Param("p_retval", OracleType.VarChar, ParameterDirection.Output, "");
                v_return = db.OracleExecuteSP_GetReturnVal("sp_update_unhold_trans", parm, pno);
                lblStatus.Text = v_return.Split(';')[1].ToString();
            }
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            Execute_sp();
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if ((e.Row.RowType == DataControlRowType.Header))
        {
            ((CheckBox)e.Row.FindControl("Ckb_SelectALL")).Attributes.Add("onclick", "javascript:SelectAll('" + ((CheckBox)e.Row.FindControl("Ckb_SelectALL")).ClientID + "')");
        }
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        txtXpin.Text = "";
        txtCustomerRef.Text = "";
        lblMessage.Text = "";
        GridView1.DataSource = null;
        GridView1.DataBind();
        btnSubmit.Attributes.Add("style", "visibility:hidden;");
    }
}

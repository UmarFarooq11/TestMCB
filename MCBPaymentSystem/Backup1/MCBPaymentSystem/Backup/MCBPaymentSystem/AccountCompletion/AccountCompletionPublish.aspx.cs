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

public partial class AccountCompletionPublish : System.Web.UI.Page
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
        { btnSubmit.Visible = false; /*ADD*/}
        else if (RGS_SUPPORT.Substring(0, 1) == "1")
        { btnSubmit.Visible = true; /*ADD*/}

        if (!Page.IsPostBack)
        {
            Session["U_NAME"] = Request.QueryString["UID"].ToString();
            btnSubmit.Attributes.Add("style", "visibility:hidden;");
            btnSubmit.Attributes.Add("onclick", "return funConfirm();");
            ddlCompanyBind();
            dllFilename();
        }
    }
    private void loadGrid(string file_name)
    {
        int pno = 0;
        DataSet ds = new DataSet();
        OracleParameter[] parms = new OracleParameter[10];
        parms[pno] = _dbConfig.Oracle_Param("P_company_code", OracleType.VarChar, ParameterDirection.Input, ddlCompanyCode.SelectedValue); pno++;
        parms[pno] = _dbConfig.Oracle_Param("P_FILE_NAME", OracleType.VarChar, ParameterDirection.Input, file_name); pno++;
        parms[pno] = _dbConfig.Oracle_Param("P_Trans_type", OracleType.VarChar, ParameterDirection.Input, ""); pno++;
        parms[pno] = _dbConfig.Oracle_Param("P_Rowid", OracleType.VarChar, ParameterDirection.Input, ""); pno++;
        parms[pno] = _dbConfig.Oracle_Param("p_bank_code", OracleType.VarChar, ParameterDirection.Input, ""); pno++;
        parms[pno] = _dbConfig.Oracle_Param("p_branch_code", OracleType.VarChar, ParameterDirection.Input, ""); pno++;
        parms[pno] = _dbConfig.Oracle_Param("P_Userid", OracleType.VarChar, ParameterDirection.Input, ""); pno++;
        parms[pno] = _dbConfig.Oracle_Param("P_type", OracleType.VarChar, ParameterDirection.Input, "09"); pno++;
        parms[pno] = _dbConfig.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, ""); pno++;
        parms[pno] = _dbConfig.Oracle_Param("v_retval", OracleType.VarChar, ParameterDirection.Output, "");
        ds = _dbConfig.Oracle_GetDataSetSP("SP_Data_Segregation", parms);
        if (parms[pno].Value.ToString() == "")
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                GridView1.DataSource = ds;
                GridView1.DataBind();
                lblMessage.Text = "";
            }
            else
            {
                GridView1.EmptyDataText = "DATA NOT FOUND";
                GridView1.DataSource = null;
                GridView1.DataBind();
            }
        }
        else
        {
            lblMessage.Text = parms[pno].Value.ToString();
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
        else
        {
            ddlCompanyCode.Items.Insert(0, new ListItem("No company found.", ""));
        }
    }
    public void dllFilename()
    {
        DataSet ds = new DataSet();
        OracleParameter[] parms = new OracleParameter[3];
        parms[0] = _dbConfig.Oracle_Param("p_company_code", OracleType.VarChar, ParameterDirection.Input, ddlCompanyCode.SelectedValue);
        parms[1] = _dbConfig.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        parms[2] = _dbConfig.Oracle_Param("v_retval", OracleType.VarChar, ParameterDirection.Output, "");
        ds = _dbConfig.Oracle_GetDataSetSP("SP_Data_Segregation_LOV", parms);
        if (ds.Tables[0].Rows.Count > 0)
        {
            GridView2.DataSource = ds;
            GridView2.DataBind();
            btnSubmit.Attributes.Add("style", "visibility:visible;");
        }
        else
        {
            btnSubmit.Attributes.Add("style", "visibility:hidden;");
            GridView2.DataSource = null;
            GridView2.DataBind();
            GridView1.DataSource = null;
            GridView1.DataBind();
        }
    }
    protected void ddlCompanyCode_SelectedIndexChanged(object sender, EventArgs e)
    {
        dllFilename();
        lblMessage.Text = "";
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (Session["U_NAME"].ToString() == "")
        {
            lblMessage.Text = "User session expired, Please Re-Login";
            return;
        }
        try
        {
            for (int i = 0; i < GridView2.Rows.Count; i++)
            {
                if (((CheckBox)GridView2.Rows[i].FindControl("Ckb_Select")).Checked == true)
                {
                    string file_name = ((LinkButton)GridView2.Rows[i].FindControl("lbfile_name")).Text;
                    string status = Process(ddlCompanyCode.SelectedValue, file_name, "Publish", Session["U_NAME"].ToString());
                    GridView2.Rows[i].Cells[4].Text = status;
                    transSeq(ddlCompanyCode.SelectedValue, file_name, i);
                }
            }
            GridView1.DataSource = null;
            GridView1.DataBind();
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }
    public string Process(string p_company_code, string p_file_name, string p_type, string p_user_id)
    {
        string v_return = "";
        OracleParameter[] parm = new OracleParameter[5];
        parm[0] = _dbConfig.Oracle_Param("p_company_code", OracleType.VarChar, ParameterDirection.Input, p_company_code);
        parm[1] = _dbConfig.Oracle_Param("p_file_name", OracleType.VarChar, ParameterDirection.Input, p_file_name);
        parm[2] = _dbConfig.Oracle_Param("p_type", OracleType.VarChar, ParameterDirection.Input, p_type);
        parm[3] = _dbConfig.Oracle_Param("p_user_id", OracleType.VarChar, ParameterDirection.Input, p_user_id);
        parm[4] = _dbConfig.Oracle_Param("p_return", OracleType.VarChar, ParameterDirection.Output, "");
        v_return = _dbConfig.OracleExecuteSP_GetReturnVal("sp_publish_file_manual", parm, 4);
        return v_return;

    }
    public void transSeq(string company_code, string file_name, int i)
    {
        DataSet ds = new DataSet();
        OracleParameter[] parm = new OracleParameter[3];
        int pno = 0;
        parm[pno] = _dbConfig.Oracle_Param("P_COMPANY_CODE", OracleType.VarChar, ParameterDirection.Input, company_code); pno++;
        parm[pno] = _dbConfig.Oracle_Param("P_FILE_NAME", OracleType.VarChar, ParameterDirection.Input, file_name); pno++;
        parm[pno] = _dbConfig.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        ds = _dbConfig.Oracle_GetDataSetSP("sp_trans_sequence", parm);
        if (ds.Tables[0].Rows.Count > 0)
        {
            GridView2.Rows[i].Cells[2].Text = ds.Tables[0].Rows[0]["min_trans"].ToString();
            GridView2.Rows[i].Cells[3].Text = ds.Tables[0].Rows[0]["max_trans"].ToString();
        }
        else
        {
            GridView2.Rows[i].Cells[2].Text = "";
            GridView2.Rows[i].Cells[3].Text = "";
        }
    }
    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if ((e.Row.RowType == DataControlRowType.Header))
        {
            ((CheckBox)e.Row.FindControl("Ckb_SelectALL")).Attributes.Add("onclick", "javascript:SelectAll('" + ((CheckBox)e.Row.FindControl("Ckb_SelectALL")).ClientID + "')");
        }
    }
    protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        LinkButton lb = (LinkButton)e.CommandSource;
        GridViewRow gv = (GridViewRow)lb.NamingContainer;
        string file_name = lb.Text;
        loadGrid(file_name);
    }
}
#region
//public string Execute_sp(OracleConnection conn, OracleTransaction tran)
//{
//    string v_return = "";
//    for (int i = 0; i < GridView1.Rows.Count; i++)
//    {
//        //if (((CheckBox)GridView1.Rows[i].FindControl("cbPublish")).Checked == true)
//        OracleParameter[] parm = new OracleParameter[10];
//        int pno = 0;
//        parm[pno] = new OracleParameter();
//        parm[pno] = _dbConfig.Oracle_Param("P_company_code", OracleType.VarChar, ParameterDirection.Input, ddlCompanyCode.SelectedValue.ToString());
//        pno++;
//        parm[pno] = new OracleParameter();
//        parm[pno] = _dbConfig.Oracle_Param("P_FILE_NAME", OracleType.VarChar, ParameterDirection.Input, ddlFile.SelectedValue.ToString());
//        pno++;
//        parm[pno] = new OracleParameter();
//        parm[pno] = _dbConfig.Oracle_Param("P_Trans_type", OracleType.VarChar, ParameterDirection.Input, (GridView1.Rows[i].Cells[1].Text == "&nbsp;") ? "" : GridView1.Rows[i].Cells[1].Text);
//        pno++;
//        parm[pno] = new OracleParameter();
//        parm[pno] = _dbConfig.Oracle_Param("P_Rowid", OracleType.VarChar, ParameterDirection.Input, GridView1.Rows[i].Cells[0].Text);
//        pno++;
//        parm[pno] = new OracleParameter();
//        parm[pno] = _dbConfig.Oracle_Param("p_bank_code", OracleType.VarChar, ParameterDirection.Input, "");
//        pno++;
//        parm[pno] = new OracleParameter();
//        parm[pno] = _dbConfig.Oracle_Param("p_branch_code", OracleType.VarChar, ParameterDirection.Input, "");
//        pno++;
//        parm[pno] = new OracleParameter();
//        parm[pno] = _dbConfig.Oracle_Param("P_Userid", OracleType.VarChar, ParameterDirection.Input, Session["U_NAME"].ToString());
//        pno++;
//        parm[pno] = new OracleParameter();
//        parm[pno] = _dbConfig.Oracle_Param("P_type", OracleType.VarChar, ParameterDirection.Input, "10");
//        pno++;
//        parm[pno] = new OracleParameter();
//        parm[pno] = _dbConfig.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
//        pno++;
//        parm[pno] = new OracleParameter();
//        parm[pno] = _dbConfig.Oracle_Param("v_retval", OracleType.VarChar, ParameterDirection.Output, "");

//        v_return = _dbConfig.TransSPOracle_GetReturnStringVal1(conn, tran, "SP_Data_Segregation", parm, pno);
//        if (v_return.StartsWith("04") == false)
//        {
//            lblMessage.Text = v_return.Split(',').GetValue(1).ToString();
//            return v_return;
//        }
//    }
//    return v_return;
//}
//protected void ddlFile_SelectedIndexChanged(object sender, EventArgs e)
//{
//    DataSet ds = new DataSet();
//    ds = (DataSet)ViewState["dataset"];
//    if (ds.Tables[0].Rows.Count > 0)
//    {
//        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
//        {
//            if (ddlFile.SelectedValue.ToString() == ds.Tables[0].Rows[i]["FILE_NAME"].ToString())
//            {
//                lblTotalRecord.Text = ds.Tables[0].Rows[i]["total_records"].ToString();
//                lblTotalFile.Visible = true;
//                lblTotalRecord.Visible = true;
//            }
//        }
//    }
//    GridView1.DataSource = null;
//    GridView1.DataBind();
//    btnSubmit.Attributes.Add("style", "visibility:hidden;");
//    lblTransaction.Attributes.Add("style", "visibility:hidden;");
//    lblFieldTrans.Attributes.Add("style", "visibility:hidden;");
//    lblStart.Attributes.Add("style", "visibility:hidden;");
//    lblStartTrans.Attributes.Add("style", "visibility:hidden;");
//    lblEnd.Attributes.Add("style", "visibility:hidden;");
//    lblEndTrans.Attributes.Add("style", "visibility:hidden;");
//}
//private bool GenerateSMS(string MobileNo, string MSG)
//{
//    try
//    {
//        GetSMSData();
//        string SMSMsg = Utility.SendSMS(Session["SMSUserID"].ToString(), Session["SMSPassword"].ToString(), MobileNo, MSG, Session["SMSChannelCode"].ToString());
//        if (SMSMsg == "00")
//        {
//            return true;
//        }
//        else
//        {
//            return false;
//        }
//    }
//    catch (Exception ex)
//    {
//        lblMessage.Text = ex.Message;
//    }
//    return true;
//}
//private string GetSMSData()
//{
//    string UserID = "", Password = "", ChannelCode = "";
//    //Database db = new Database();
//    System.Data.DataTable dt = lov.GetIDPASSforSMS("select DYVAL2 UserID,DYVAL3 PWD,DYVAL4 ChannelCode from mcb_dynamicsetup where DYCD='MCBSMS' and DYDESC='SMS Service'").Tables[0];

//    if (dt.Rows.Count > 0)
//    {
//        Session["SMSUserID"] = dt.Rows[0]["UserID"];
//        Session["SMSPassword"] = dt.Rows[0]["PWD"];
//        Session["SMSChannelCode"] = dt.Rows[0]["ChannelCode"];
//    }
//    return UserID + ";" + Password + ";" + ChannelCode;
//}
//public string postLeadger(OracleConnection conn, OracleTransaction tran)
//{
//    string v_return = "";
//    OracleParameter[] parm = new OracleParameter[10];
//    int pno = 0;
//    parm[pno] = new OracleParameter();
//    parm[pno] = _dbConfig.Oracle_Param("P_company_code", OracleType.VarChar, ParameterDirection.Input, ddlCompanyCode.SelectedValue.ToString());
//    pno++;
//    parm[pno] = new OracleParameter();
//    parm[pno] = _dbConfig.Oracle_Param("P_FILE_NAME", OracleType.VarChar, ParameterDirection.Input, ddlFile.SelectedValue.ToString());
//    pno++;
//    parm[pno] = new OracleParameter();
//    parm[pno] = _dbConfig.Oracle_Param("P_Trans_type", OracleType.VarChar, ParameterDirection.Input, "");
//    pno++;
//    parm[pno] = new OracleParameter();
//    parm[pno] = _dbConfig.Oracle_Param("P_Rowid", OracleType.VarChar, ParameterDirection.Input, "");
//    pno++;
//    parm[pno] = new OracleParameter();
//    parm[pno] = _dbConfig.Oracle_Param("p_bank_code", OracleType.VarChar, ParameterDirection.Input, "");
//    pno++;
//    parm[pno] = new OracleParameter();
//    parm[pno] = _dbConfig.Oracle_Param("p_branch_code", OracleType.VarChar, ParameterDirection.Input, "");
//    pno++;
//    parm[pno] = new OracleParameter();
//    parm[pno] = _dbConfig.Oracle_Param("P_Userid", OracleType.VarChar, ParameterDirection.Input, Session["U_NAME"].ToString());
//    pno++;
//    parm[pno] = new OracleParameter();
//    parm[pno] = _dbConfig.Oracle_Param("P_type", OracleType.VarChar, ParameterDirection.Input, "14");
//    pno++;
//    parm[pno] = new OracleParameter();
//    parm[pno] = _dbConfig.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
//    pno++;
//    parm[pno] = new OracleParameter();
//    parm[pno] = _dbConfig.Oracle_Param("v_retval", OracleType.VarChar, ParameterDirection.Output, "");

//    v_return = _dbConfig.TransSPOracle_GetReturnStringVal1(conn, tran, "SP_Data_Segregation", parm, pno);
//    lblMessage.Text = v_return.Split(',').GetValue(1).ToString();
//    return v_return;
//}
//public string BulkInsertion(string file_name)
//{
//    DataTable data = new DataTable();
//    data = (DataTable)ViewState["DataTable"];
//    if (data == null)
//    {
//        return "No Data found against this File.";
//    }
//    if (data.Rows.Count > 0)
//    {
//        DBUniversalUploadProcess Upload = new DBUniversalUploadProcess();
//        string val = Upload.DataPublishTrans(data.Rows.Count, data, ddlCompanyCode.SelectedValue, file_name, Session["U_NAME"].ToString(), "10");
//        if (val.StartsWith("04"))
//        {
//            return val.Split(',').GetValue(1).ToString();
//        }
//        else
//        {
//            //condition modify in future.
//            int t = val.IndexOf(',');
//            if (t > 0)
//            {
//                //val = val.Split(',').GetValue(1).ToString();
//                //lblMessage.Text = val;
//                return val;
//            }
//            else
//            {
//                //lblMessage.Text = val;
//                return val;
//            }
//        }
//    }
//    else
//    {
//        return "No Data found against this File.";
//    }

//}
#endregion
#region Bulk Insertion's code
//DataTable data = new DataTable();
//data = (DataTable)ViewState["DataTable"];
//DBUniversalUploadProcess Upload = new DBUniversalUploadProcess();
//string val = Upload.DataPublishTrans(data.Rows.Count, data, ddlCompanyCode.SelectedValue, ddlFile.SelectedValue.ToString(), Session["U_NAME"].ToString(),"10");

//if (val.StartsWith("04"))
//{
//    loadGrid("S");
//    lblMessage.Text = val.Split(',').GetValue(1).ToString();
//    transSeq(ddlCompanyCode.SelectedValue,ddlFile.SelectedValue);
//}
//else
//{
//    int t = val.IndexOf(',');
//    if (t > 0)
//    {
//        val = val.Split(',').GetValue(1).ToString();
//        lblMessage.Text = val;
//    }
//    else
//    {
//        lblMessage.Text = val;
//    }
//}
#endregion
#region old Coding
//OracleConnection con = new OracleConnection(ViewState["ConnectionString"].ToString());
//con.Open();
//OracleTransaction trans = con.BeginTransaction();
//string val = Execute_sp(con, trans);
//if (val.StartsWith("04") == true)
//{
//    val = postLeadger(con,trans);
//    if (val.StartsWith("04") == true)
//    {
//        trans.Commit();
//        con.Close();
//        loadGrid("S");
//        transSeq(ddlCompanyCode.SelectedValue, ddlFile.SelectedValue);
//        DataTable dt = new DataTable();
//        dt = lov.GetContactNoforSMS(ddlCompanyCode.SelectedValue, ddlFile.SelectedItem.ToString(), "02").Tables[0];
//        if (dt.Rows.Count > 0)
//        {
//            int y = 0;
//            for (int i = 0; i < dt.Rows.Count; i++)
//            {
//                if (GenerateSMS(dt.Rows[i]["contactnumber"].ToString(), dt.Rows[i]["msg"].ToString()) == true)
//                {
//                    y = 1;
//                }
//            }
//            if (y == 1)
//            {
//                lblMessage.Text += " and SMS has been sent to Beneficiary.";
//            }
//        }
//    }
//    else
//    {
//        trans.Rollback();
//        con.Close();
//    }
//}
//else
//{
//    trans.Rollback();
//    con.Close();
//}
#endregion

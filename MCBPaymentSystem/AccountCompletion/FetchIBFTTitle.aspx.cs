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
//using IBFT_Transaction;
using System.Xml.Linq;
using System.Xml;

public partial class AccountCompletion_AccountCompletion : System.Web.UI.Page
{
    string[] ARY;
    string RGS_SUPPORT;
    DatabaseConnection_Util db = new DatabaseConnection_Util();
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
        { btnSubmit.Visible = false; /*ADD*/}
        else if (RGS_SUPPORT.Substring(0, 1) == "1")
        { btnSubmit.Visible = true; /*ADD*/}
        if (!IsPostBack)
        {
            btnSubmit.Attributes.Add("onclick", "return funConfirm();");
            lblFieldTrans.Attributes.Add("style", "visibility:hidden;");
            lblTransaction.Attributes.Add("style", "visibility:hidden;");
            lblTotalFile.Attributes.Add("style", "visibility:hidden;");
            lblTotalRecord.Attributes.Add("style", "visibility:hidden;");
            btnSubmit.Attributes.Add("style", "visibility:hidden;");
            ddlCompanyBind();
            dllFilename();
        }
    }
    protected void Page_PreInit(object sender, EventArgs e)
    {
        Page.Theme = "SkinFile"; //Session["ThemeChange"].ToString(); 
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
        parms[0] = db.Oracle_Param("p_company_code", OracleType.VarChar, ParameterDirection.Input, ddlCompanyCode.SelectedValue.ToString());
        parms[1] = db.Oracle_Param("data_resultset", OracleType.Cursor, ParameterDirection.Output, "");
        parms[2] = db.Oracle_Param("v_retval", OracleType.VarChar, ParameterDirection.Output, "");
        ds = db.Oracle_GetDataSetSP("SP_Data_Segregation_LOV", parms);
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlFile.DataSource = ds.Tables[0];
            ddlFile.DataValueField = "file_name";
            ddlFile.DataTextField = "file_name";
            ddlFile.DataBind();
            ViewState["dataset"] = ds;
            lblTotalRecord.Text = ds.Tables[0].Rows[0]["total_records"].ToString();
            lblTotalRecord.Attributes.Add("style", "visibility:visible;");
            lblTotalFile.Attributes.Add("style", "visibility:visible;");
        }
        else
        {
            ddlFile.DataSource = "";
            ddlFile.DataValueField = "";
            ddlFile.DataTextField = "";
            ddlFile.DataBind();
            GridView1.DataSource = null;
            GridView1.DataBind();
            lblTotalRecord.Attributes.Add("style", "visibility:hidden;");
            lblTotalFile.Attributes.Add("style", "visibility:hidden;");
            lblTransaction.Attributes.Add("style", "visibility:hidden;");
            lblFieldTrans.Attributes.Add("style", "visibility:hidden;");
        }
    }
    protected void ddlCompanyCode_SelectedIndexChanged(object sender, EventArgs e)
    {
        dllFilename();
        lblMessage.Text = "";
        btnSubmit.Attributes.Add("style", "visibility:hidden;");
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

        GridView1.DataSource = null;
        GridView1.DataBind();
        lblTransaction.Attributes.Add("style", "visibility:hidden;");
        lblFieldTrans.Attributes.Add("style", "visibility:hidden;");
        btnSubmit.Attributes.Add("style", "visibility:hidden;");
        lblMessage.Text = "";
    }
    protected void btnGetAccountTitle_Click(object sender, EventArgs e)
    {
        Page.Validate();
        if (Page.IsValid)
        {
            AddInQueueTitleFetchTrans();
            //GetTitle(ddlCompanyCode.SelectedValue, ddlFile.SelectedValue);
        }
    }
    public void AddInQueueTitleFetchTrans()
    {
        string retval = "";
        try
        {
            OracleParameter[] parms = new OracleParameter[4];
            parms[0] = db.Oracle_Param("p_company_code", OracleType.VarChar, ParameterDirection.Input, ddlCompanyCode.SelectedValue);
            parms[1] = db.Oracle_Param("p_file_name", OracleType.VarChar, ParameterDirection.Input, ddlFile.SelectedValue);
            parms[2] = db.Oracle_Param("p_userid", OracleType.VarChar, ParameterDirection.Input, Session["U_NAME"].ToString());
            parms[3] = db.Oracle_Param("p_return", OracleType.VarChar, ParameterDirection.Output, "");
            retval = db.OracleExecuteSP_GetReturnVal("sp_insert_ibft_title", parms, 3);
            lblMessage.Text = retval;
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }
    private void GetTitleRecord()
    {
        try
        {
            DataSet ds = new DataSet();
            OracleParameter[] param = new OracleParameter[3];
            int pno = 0;
            param[0] = db.Oracle_Param("P_company_code", OracleType.VarChar, ParameterDirection.Input, ddlCompanyCode.SelectedValue); pno++;
            param[1] = db.Oracle_Param("p_file_name", OracleType.VarChar, ParameterDirection.Input, ddlFile.SelectedValue); pno++;
            param[2] = db.Oracle_Param("p_data_set", OracleType.Cursor, ParameterDirection.Output, ""); pno++;
            ds = db.Oracle_GetDataSetSP("sp_get_dataTitlefor_ibft", param);
            if (ds.Tables[0].Rows.Count > 0)
            {
                lblTransaction.Text = ds.Tables[0].Rows.Count.ToString();
                lblFieldTrans.Attributes.Add("style", "visibility:visible;");
                lblTransaction.Attributes.Add("style", "visibility:visible;");
                btnSubmit.Attributes.Add("style", "visibility:visible;");
                GridView1.DataSource = ds;
                GridView1.DataBind();
                lblMessage.Text = "";
            }
            else
            {
                lblTransaction.Text = "0";
                lblFieldTrans.Attributes.Add("style", "visibility:visible;");
                lblTransaction.Attributes.Add("style", "visibility:visible;");
                btnSubmit.Attributes.Add("style", "visibility:visible;");
                GridView1.DataSource = "";
                GridView1.DataBind();
                lblMessage.Text = "No data found.";
            }
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }
    //public string FetchIBFTAccountTitle(string AccountNo, string DebitAccount, string BankCode, string Amount, string Trans_Date, string TransRef_NO, string CompanyCode, string ibft_TYPE)
    //{
    //    string Str_Result = "";
    //    //return Str_Result = "0;Computer Research PVT LTD.";
    //    string returncode = "";
    //    string ISOResponseCode = "";
    //    string BeneBank = "";
    //    string AccountTitle = "";
    //    string RetrievalReference = "";
    //    try
    //    {
    //        IBFT_Process obj = new IBFT_Process();
    //        obj.DBConnectionString = DAL_EXP1.Utility.Startup_Util.DB_Route;
    //        obj.wsdlURL = ConfigurationManager.AppSettings["IBFT_URL"].ToString();
    //        #region Get value from web.config for IBFT configuration
    //        string UserName = ConfigurationManager.AppSettings["IBFT_USERNAME"].ToString();
    //        string Password = ConfigurationManager.AppSettings["IBFT_PASSWORD"].ToString();
    //        string IP = ConfigurationManager.AppSettings["IBFT_IP"].ToString();
    //        string CardAcceptorTerminalId = "", NetworkID = "";
    //        if (ibft_TYPE == "HOME_REMIT")
    //        {
    //            CardAcceptorTerminalId = ConfigurationManager.AppSettings["IBFT_CARDACCEPTORTERMINALID_SSO_HR"].ToString();
    //            NetworkID = ConfigurationManager.AppSettings["IBFT_NETWORKID_SSO_HR"].ToString();
    //        }
    //        else if (ibft_TYPE == "SSO_CORP")
    //        {
    //            CardAcceptorTerminalId = ConfigurationManager.AppSettings["IBFT_CARDACCEPTORTERMINALID_SSO_CORP"].ToString();
    //            NetworkID = ConfigurationManager.AppSettings["IBFT_NETWORKID_SSO_CORP"].ToString();
    //        }
    //        #endregion
    //        string soapResult = obj.FetchTitle(UserName, Password, IP, DebitAccount, AccountNo, BankCode, Amount, Trans_Date, TransRef_NO, CardAcceptorTerminalId, NetworkID, CompanyCode, "Payment System HM - Title Fetch");
    //        #region Response tracking
    //        if (soapResult.StartsWith("0;"))
    //        {
    //            soapResult = soapResult.Substring(2);
    //            returncode = getNodeValue(soapResult, "ResponseCode");
    //            switch (returncode)
    //            {
    //                case "000000":
    //                    AccountTitle = getNodeValue(soapResult, "AccountTitle").Trim();
    //                    Str_Result = returncode + "-" + AccountTitle;
    //                    break;
    //                default:
    //                    Str_Result = returncode + "-" + getNodeValue(soapResult, "ResponseMessage");
    //                    break;
    //            }
    //            if (returncode == "000000")
    //            {
    //                ISOResponseCode = getNodeValue(soapResult, "ISOResponseCode");
    //                if (ISOResponseCode == "0")
    //                {
    //                    if (AccountTitle != "")
    //                    {
    //                        BeneBank = getNodeValue(soapResult, "BranchDetail").Trim().ToUpper();
    //                        if (BeneBank.Contains(BankCode))
    //                        {
    //                            RetrievalReference = getNodeValue(soapResult, "RetrievalReference");
    //                            if (RetrievalReference == TransRef_NO)
    //                            {
    //                                //Str_Result = "0;" + Str_Result + "-ISOResponseCode-" + ISOResponseCode + "-InputBank-" + RefBankIMD + "-ReceivedBank-" + BeneBank + "-InputRRN-" + CustomerRef + "-ReceivedRRN-" + RetrievalReference;
    //                                Str_Result = "0;" + AccountTitle;
    //                            }
    //                            else
    //                            {
    //                                Str_Result = "1;" + Str_Result + ", ISOResponseCode :" + ISOResponseCode + ", InputBank-" + BankCode + ", ReceivedBank :" + BeneBank + ", InputRRN-" + TransRef_NO + ", ReceivedRRN :" + RetrievalReference + " Mismatch RRN";
    //                            }
    //                        }
    //                        else
    //                        {
    //                            Str_Result = "1;" + Str_Result + ", ISOResponseCode :" + ISOResponseCode + ", InputBank :" + BankCode + ", ReceivedBank :" + BeneBank + " Mismatch BeneBank Name";
    //                        }
    //                    }
    //                    else
    //                    {
    //                        Str_Result = "1;" + Str_Result + ", ISOResponseCode :" + ISOResponseCode + " AccountTitle should not be empty.";
    //                    }

    //                }
    //                else
    //                {
    //                    Str_Result = "1;" + Str_Result + ", ISOResponseCode :" + ISOResponseCode;
    //                }
    //            }
    //            else
    //            {
    //                Str_Result = "1;" + Str_Result;
    //            }
    //        }
    //        else
    //        {
    //            Str_Result = soapResult;
    //        }
    //        #endregion
    //    }
    //    catch (Exception ex)
    //    {
    //        Str_Result = "1;" + ex.Message;
    //    }
    //    return Str_Result;
    //}
    public string getNodeValue(string responseSOAP, string tagName)
    {
        string returnNode = "";
        try
        {
            XDocument xDocc = XDocument.Parse(responseSOAP);
            XmlReader xr = xDocc.CreateReader();
            xr.ReadToFollowing(tagName);
            returnNode = xr.ReadElementString();
        }
        catch (Exception ex)
        {
            returnNode = "1;" + ex.Message;
        }
        return returnNode.Trim();
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if ((e.Row.RowType == DataControlRowType.Header))
        {
            ((CheckBox)e.Row.FindControl("Ckb_SelectALL")).Attributes.Add("onclick", "javascript:SelectAll('" + ((CheckBox)e.Row.FindControl("Ckb_SelectALL")).ClientID + "')");
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        updateTitle();
    }
    private void updateTitle()
    {
        string retval = "";
        string beneTitle = "";
        CheckBox Ckb_Select;
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            Ckb_Select = ((CheckBox)GridView1.Rows[i].FindControl("Ckb_Select"));
            if (Ckb_Select.Checked == true)
            {
                beneTitle = GridView1.Rows[i].Cells[3].Text.Replace("&nbsp;", "");
                beneTitle = GridView1.Rows[i].Cells[3].Text.Replace("0;", "");

                if (beneTitle != "" && beneTitle.StartsWith("1;") == false)
                {
                    OracleParameter[] parms = new OracleParameter[4];
                    parms[0] = db.Oracle_Param("p_rowid", OracleType.VarChar, ParameterDirection.Input, GridView1.Rows[i].Cells[0].Text);
                    parms[1] = db.Oracle_Param("p_benename", OracleType.VarChar, ParameterDirection.Input, beneTitle);
                    parms[2] = db.Oracle_Param("P_Userid", OracleType.VarChar, ParameterDirection.Input, Session["U_NAME"].ToString());
                    parms[3] = db.Oracle_Param("p_return", OracleType.VarChar, ParameterDirection.Output, "");
                    retval = db.OracleExecuteSP_GetReturnVal("sp_ibfttitleupdate", parms, 3);
                    GridView1.Rows[i].Cells[6].Text = retval.Contains(";") == true ? retval.Split(';')[1].ToString() : retval;
                }
                else
                {
                    GridView1.Rows[i].Cells[6].Text = "Transaction is not process, error found during title fetch.";
                }
            }
        }

    }
    protected void btnPreview_Click(object sender, EventArgs e)
    {
        GetTitleRecord();
    }
}

//private void GetTitle(string company_code, string file_name)
//{
//    string AccTitle, BeneTitle, p_accountno, p_debitaccount, p_bankcode, p_amount, p_trans_date, p_transref_no, p_companycode, p_ibft_type = "";
//    try
//    {
//        DataSet ds = new DataSet();
//        OracleParameter[] param = new OracleParameter[3];
//        int pno = 0;
//        param[0] = db.Oracle_Param("P_company_code", OracleType.VarChar, ParameterDirection.Input, company_code); pno++;
//        param[1] = db.Oracle_Param("p_file_name", OracleType.VarChar, ParameterDirection.Input, file_name); pno++;
//        param[2] = db.Oracle_Param("p_data_set", OracleType.Cursor, ParameterDirection.Output, ""); pno++;
//        ds = db.Oracle_GetDataSetSP("sp_get_dataTitlefor_ibft", param);
//        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
//        {
//            AccTitle = BeneTitle = p_accountno = p_debitaccount = p_bankcode = p_amount = p_trans_date = p_transref_no = p_companycode = p_ibft_type = "";

//            p_accountno = ds.Tables[0].Rows[i]["accountnumber"].ToString();
//            p_debitaccount = ds.Tables[0].Rows[i]["debit_account"].ToString();
//            p_bankcode = ds.Tables[0].Rows[i]["ref_bank_code"].ToString();
//            p_amount = ds.Tables[0].Rows[i]["transamount"].ToString();
//            p_trans_date = ds.Tables[0].Rows[i]["trans_date"].ToString();
//            p_transref_no = ds.Tables[0].Rows[i]["rrn"].ToString();
//            p_companycode = ds.Tables[0].Rows[i]["company_code"].ToString();
//            p_ibft_type = ds.Tables[0].Rows[i]["ibft_type"].ToString();
//            AccTitle = FetchIBFTAccountTitle(p_accountno, p_debitaccount, p_bankcode, p_amount, p_trans_date, p_transref_no, p_companycode, p_ibft_type);
//            if (AccTitle.StartsWith("0;"))
//            {
//                if (AccTitle.Replace("0;", "").Trim() == "")
//                {
//                    BeneTitle = "1;Fetch Title sccessfull but Account Title is missing.";
//                }
//                else
//                {
//                    BeneTitle = AccTitle.Replace("0;", "").Trim();
//                }
//            }
//            else
//            {
//                BeneTitle = AccTitle;
//            }
//            ds.Tables[0].Rows[i]["TitleofAccount"] = BeneTitle;
//        }
//        lblTransaction.Text = ds.Tables[0].Rows.Count.ToString();
//        lblFieldTrans.Attributes.Add("style", "visibility:visible;");
//        lblTransaction.Attributes.Add("style", "visibility:visible;");
//        btnSubmit.Attributes.Add("style", "visibility:visible;");
//        GridView1.DataSource = ds;
//        GridView1.DataBind();
//        lblMessage.Text = "";
//    }
//    catch (Exception ex)
//    {
//        lblMessage.Text = ex.Message;
//    }
//}

//public string Responsetracking(string soapResult)
//    {
//        #region Response Tracking
//        string returncode = "";
//        if (soapResult.StartsWith("0;"))
//        {
//            soapResult = soapResult.Substring(2);
//            returncode = getNodeValue(soapResult, "ResponseCode");
//            switch (returncode)
//            {
//                case "000000":
//                    soapResult = "0;" + getNodeValue(soapResult, "AccountTitle").Trim();
//                    break;
//                default:
//                    soapResult = "1;" + returncode + "-" + getNodeValue(soapResult, "ResponseMessage");
//                    break;
//            }
//        }
//        else
//        {
//            return soapResult;
//        }
//        return soapResult;
//        #endregion
//    }
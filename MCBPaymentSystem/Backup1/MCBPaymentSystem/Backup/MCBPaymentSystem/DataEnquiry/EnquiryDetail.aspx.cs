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

public partial class DataEnquiry_EnquiryDetail : System.Web.UI.Page
{
    DatabaseConnection_Util _dbConfig = new DatabaseConnection_Util();
    protected void Page_PreInit(object sender, EventArgs e)
    {
        Page.Theme = "SkinFile"; //Session["ThemeChange"].ToString();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        string draft_no = Request.QueryString["draftno"];
        string reference_no = Request.QueryString["cust_ref_no"];
        string account_no = Request.QueryString["account_no"];
        string user_id = Request.QueryString["user_id"];
        string company_code = Request.QueryString["company_code"];


        if (draft_no == "" && reference_no == "" && account_no == "")
        {
            //lblRecord.Text = "Invalid Criteria";
        }
        else
        {
            loadGrid(draft_no, reference_no, account_no, user_id, company_code);
        }
    }
    private void loadGrid(string draft_no, string reference_no, string account_no, string user_id, string company_code)
    {
        int pno = 0;
        DataSet ds = new DataSet();
        OracleParameter[] parms = new OracleParameter[7];
        parms[pno] = _dbConfig.Oracle_Param("p_DRAFTNO", OracleType.VarChar, ParameterDirection.Input, draft_no); pno++;
        parms[pno] = _dbConfig.Oracle_Param("p_CUSTREFNUMBER", OracleType.VarChar, ParameterDirection.Input, reference_no); pno++;
        parms[pno] = _dbConfig.Oracle_Param("p_account_no", OracleType.VarChar, ParameterDirection.Input, account_no); pno++;
        parms[pno] = _dbConfig.Oracle_Param("P_USER_ID", OracleType.VarChar, ParameterDirection.Input, user_id); pno++;
        parms[pno] = _dbConfig.Oracle_Param("p_rowid", OracleType.VarChar, ParameterDirection.Input, company_code); pno++;
        parms[pno] = _dbConfig.Oracle_Param("v_retval", OracleType.VarChar, ParameterDirection.Output, ""); pno++;
        parms[pno] = _dbConfig.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        ds = _dbConfig.Oracle_GetDataSetSP("sp_Trans_Enquiry", parms);
        if (ds.Tables[0].Rows.Count > 0)
        {
            lbl_CompanyCode.Text = ds.Tables[0].Rows[0]["company_code"].ToString();
            lbl_CompanyName.Text = ds.Tables[0].Rows[0]["company_name"].ToString();
            lbl_DraftNo.Text = ds.Tables[0].Rows[0]["draftno"].ToString();
            lbl_Amount.Text = ds.Tables[0].Rows[0]["draftamount"].ToString();
            lbl_TransNo.Text = ds.Tables[0].Rows[0]["trans_no"].ToString();
            lbl_TransactionDate.Text = ds.Tables[0].Rows[0]["draftdate"].ToString();
            lbl_CustomerRef.Text = ds.Tables[0].Rows[0]["CUSTREFNUMBER"].ToString();
            lbl_PaymentDate.Text = ds.Tables[0].Rows[0]["E_DATETIME"].ToString();
            lbl_TransType.Text = ds.Tables[0].Rows[0]["trans_type"].ToString();
            lbl_TransferMethod.Text = ds.Tables[0].Rows[0]["transfer_method"].ToString();
            lbl_BeneficiaryName.Text = ds.Tables[0].Rows[0]["bene_name"].ToString();
            lbl_BeneficiaryAddress.Text = ds.Tables[0].Rows[0]["bene_address"].ToString();
            lbl_AccountNo.Text = ds.Tables[0].Rows[0]["ACCOUNTNO"].ToString();
            lbl_CNIC.Text = ds.Tables[0].Rows[0]["NICNO"].ToString();
            lbl_ContactNo.Text = ds.Tables[0].Rows[0]["PHONENO"].ToString();
            lbl_PayeeBranch.Text = ds.Tables[0].Rows[0]["paybranchid"].ToString();
            lbl_BankCode.Text = ds.Tables[0].Rows[0]["correspondingbankid"].ToString();
            lbl_BankName.Text = ds.Tables[0].Rows[0]["bank_name"].ToString();
            lbl_BranchCode.Text = ds.Tables[0].Rows[0]["branchid"].ToString();
            lbl_BranchName.Text = ds.Tables[0].Rows[0]["branch_name"].ToString();
            lbl_RemitterName.Text = ds.Tables[0].Rows[0]["rem_name"].ToString();
            lbl_Status.Text = ds.Tables[0].Rows[0]["STATUS"].ToString();
            lbl_CancelDate.Text = ds.Tables[0].Rows[0]["canceldate"].ToString();
            lbl_Remarks.Text = ds.Tables[0].Rows[0]["remarks"].ToString();

        }
        //DataTable dt = new DataTable();
        //dt = ds.Tables[0];
        //ViewState["TaskTable"] = dt;
        //GridView1.DataSource = ds;
        //GridView1.DataBind();
        //lblRecord.Text = ds.Tables[0].Rows.Count.ToString() + " Record(s) found.";
        //btnPrint.Attributes.Add("style", "visibility:visible;");
    }
}

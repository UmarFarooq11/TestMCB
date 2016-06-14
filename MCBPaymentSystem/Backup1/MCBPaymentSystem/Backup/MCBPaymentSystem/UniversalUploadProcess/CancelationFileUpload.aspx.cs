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
using System.IO;
using System.Data.OracleClient;
using System.Text.RegularExpressions;

public partial class CancelationFileUpload : System.Web.UI.Page
{
    DataTable dt = new DataTable();
    LOV_COLLECTION lov = new LOV_COLLECTION();
    DatabaseConnection_Util db = new DatabaseConnection_Util();
    DataSet ds = new DataSet();
    string[] arr_company = null;
    string[] arr_xpin = null;
    string[] arr_file = null;
    int[] arr_size = null;

    protected void Page_PreInit(object sender, EventArgs e)
    { Page.Theme = "SkinFile"; }
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Response.Cache.SetCacheability(HttpCacheability.ServerAndNoCache);
            btnUpload.Attributes.Add("onclick", "return funConfirm();");
            if (!IsPostBack)
            {
                Session["UserId"] = Request.QueryString["UID"].ToString();
                ddlCompanyBind();
            }
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
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
            ddlCompanyCode.Items.Insert(0, new ListItem("Select Company", ""));
        }
    }
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        Page.Validate();
        if (Page.IsValid)
        {
            try
            {
                if (CRUtlityGetsafeString(Session["UserId"]) == "")
                {
                    lblMessage.Text = "Session expired, Please re-login";
                    return;
                }
                if (UploadFile() == true)
                {
                    process();
                }
                else
                {
                    lblMessage.Text = "Invalid file format";
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
            Deletefile(ViewState["filepath"].ToString());
        }
    }
    public bool UploadFile()
    {
        if (FileUpload1.PostedFile != null)
        {
            int fileLength = FileUpload1.PostedFile.ContentLength;
            if (fileLength <= 1048576)
            {
                byte[] myData = new byte[fileLength];
                FileUpload1.PostedFile.InputStream.Read(myData, 0, fileLength);
                ViewState["fileName"] = FileUpload1.FileName;
                ViewState["filepath"] = Server.MapPath("../UploadFiles/" + FileUpload1.FileName);
                WriteToFile(ViewState["filepath"].ToString(), myData);
                FileUpload1.PostedFile.InputStream.Close();
                lblMessage.Text = "File successfully uploaded.";
                return true;
            }
        }
        else
        {
            lblMessage.Text = "FileUpload1 Control value is null";
        }
        return false;
    }
    private void WriteToFile(string strPath, byte[] Buffer)
    {
        FileStream newFile = new FileStream(strPath, FileMode.Create);
        newFile.Write(Buffer, 0, Buffer.Length);
        newFile.Close();
    }
    public void process()
    {
        string retvalue = "";
        try
        {
            if (Get_data(ViewState["filepath"].ToString()))
            {
                if (arr_size.Length > 0)
                {
                    OracleConnection conn = new OracleConnection(db.ConnectionString);
                    conn.Open();
                    OracleTransaction trans = conn.BeginTransaction();
                    try
                    {
                        retvalue = executeMasterData(conn, trans, arr_size.Length.ToString());
                        if (retvalue.StartsWith("0"))
                        {
                            retvalue = "";
                            DBUniversalUploadProcess Upload = new DBUniversalUploadProcess();
                            //retvalue = Upload.BulkCancelationProcess(dt, "bulk_cancel_upload");
                            retvalue = Upload.BulkCancelationProcess(arr_size.Length, arr_company, arr_xpin, arr_file, arr_size, "sp_bulk_cancel_detail");
                            if (retvalue.StartsWith("0") == true)
                            {
                                trans.Commit();
                                conn.Close();
                                lblMessage.Text = retvalue.IndexOf(';') > 0 ? retvalue.Split(';')[1].ToString() : retvalue;
                            }
                            else
                            {
                                trans.Rollback();
                                conn.Close();
                                lblMessage.Text = retvalue.IndexOf(';') > 0 ? retvalue.Split(';')[1].ToString() : retvalue;
                            }
                        }
                        else
                        {
                            trans.Rollback();
                            conn.Close();
                            lblMessage.Text = retvalue.IndexOf(';') > 0 ? retvalue.Split(';')[1].ToString() : retvalue;
                        }
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        conn.Close();
                        lblMessage.Text = ex.Message;
                    }
                }
                else
                {
                    lblMessage.Text = "No record available for cancelation";
                }
            }
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }
    public bool Get_data(string filepath)
    {
        try
        {
            FileInfo file = new FileInfo(filepath);
            if (CSVFile(filepath))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
            return false;
        }
    }
    public bool CSVFile(string filepath)
    {
        StreamReader sr = new StreamReader(filepath);
        try
        {
            #region
            //arr_Xpin = File.ReadAllLines(filepath);
            //if (arr_Xpin.Length > 1000)
            //{
            //    lblMessage.Text = "Transactions count are out of range, maximum 1000 transactions are allow.";
            //    sr.Close();
            //    return false;
            //}
            //else
            //{
            //    dt.Columns.Add("COMPANY_CODE");
            //    dt.Columns.Add("XPIN");
            //    dt.Columns.Add("STATUS");
            //    dt.Columns.Add("FILE_NAME");

            //    dt.Rows.Add(arr_Xpin);
            //}
            #endregion
            arr_xpin = File.ReadAllLines(filepath);
            arr_company = new string[arr_xpin.Length];
            arr_file = new string[arr_xpin.Length];
            arr_size = new int[arr_xpin.Length];
            if (arr_xpin.Length > 1000)
            {
                lblMessage.Text = "Transactions count are out of range, maximum 1000 transactions are allow.";
                sr.Close();
                return false;
            }
            else
            {
                for (int i = 0; i < arr_xpin.Length; i++)
                {
                    arr_company[i] = ddlCompanyCode.SelectedValue;
                    arr_file[i] = ViewState["fileName"].ToString();
                    arr_size[i] = 1000;
                }
            }
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
            sr.Close();
            return false;
        }
        sr.Close();
        return true;
    }
    public void Databind(string companyCode, string filename)
    {
        ds = lov.UniversalUploadDataBind(companyCode, filename);
        if (ds.Tables[0].Rows.Count > 0)
        {
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }
        else
        {
            GridView1.DataSource = null;
            GridView1.DataBind();
        }

    }
    public static string CRUtlityGetsafeString(object value)
    {
        if (value != null)
        {
            return value.ToString();
        }
        else
        {
            return "";
        }
    }
    public string[] SplitCSV(string input)
    {
        Regex csvSplit = new Regex("(?:^|,)(\"(?:[^\"]+|\"\")*\"|[^,]*)", RegexOptions.Compiled);
        string[] str = new string[csvSplit.Matches(input).Count];
        int i = 0;
        foreach (Match match in csvSplit.Matches(input))
        {
            string val = match.Value.TrimStart(',');
            str[i] = val.Replace('"', ' ').Replace(" ", "");
            i++;
        }
        return str;
    }
    public void Deletefile(string filePath)
    {
        try
        {
            if (File.Exists(filePath) == true)
            {
                File.Delete(filePath);
            }
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }
    public string[] StringToArray(string value, int arr_length)
    {
        string[] arr = new string[arr_length];
        for (int i = 0; i < arr_length; i++)
        {
            arr[i] = value;
        }
        return arr;
    }
    public int[] IntToArray(int value, int arr_length)
    {
        int[] arr = new int[arr_length];
        for (int i = 0; i < arr_length; i++)
        {
            arr[i] = value;
        }
        return arr;
    }
    public string executeMasterData(OracleConnection conn, OracleTransaction trans, string p_noofrecord)
    {

        string p_file_type = rbCancel.Checked == true ? "C" : "U"; //File Type C for Cancel and U for Unhold
        string p_return = "";
        try
        {
            OracleParameter[] param = new OracleParameter[6];
            param[0] = db.Oracle_Param("p_company_code", OracleType.VarChar, ParameterDirection.Input, ddlCompanyCode.SelectedValue);
            param[1] = db.Oracle_Param("p_file_name", OracleType.VarChar, ParameterDirection.Input, ViewState["fileName"].ToString());
            param[2] = db.Oracle_Param("p_noofrecord", OracleType.VarChar, ParameterDirection.Input, p_noofrecord);
            param[3] = db.Oracle_Param("p_user_id", OracleType.VarChar, ParameterDirection.Input, Session["UserId"].ToString());
            param[4] = db.Oracle_Param("p_file_type", OracleType.VarChar, ParameterDirection.Input, p_file_type);
            param[5] = db.Oracle_Param("p_retval", OracleType.VarChar, ParameterDirection.Output, "");
            p_return = db.TransSPOracle_GetReturnStringVal1(conn, trans, "sp_bulk_cancel_upload", param, 5);
        }
        catch (Exception ex)
        {
            p_return = "1;" + ex.Message;
        }
        return p_return;
    }
    protected void btnSearchFileStatus_Click(object sender, EventArgs e)
    {
        if (txtSearchFileStatus.Text == "")
        {
            lblMessage.Text = "Please Insert Flie Name In Search Text Box";
        }
        else
        {
            executeStatusData(txtSearchFileStatus.Text);
        }
       
    }
    public void executeStatusData(string filename)
    {
        DataSet ds = new DataSet();
        OracleParameter[] parms = new OracleParameter[2];
        parms[0] = db.Oracle_Param("P_FILE_NAME", OracleType.VarChar, ParameterDirection.Input, filename);
        parms[1] = db.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        ds = db.Oracle_GetDataSetSP("sp_cancelwhoxpin_status", parms);
        if (ds.Tables[0].Rows.Count > 0)
        {
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }
        else
        {
            GridView1.DataSource = null;
            GridView1.DataBind();
        }
    }  
}
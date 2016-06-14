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
using System.Net;
using System.Data.SqlClient;
using MCBRPSDLL;
using System.Data.OleDb;
using DataStreams.Csv;
using DataStreams.FixedWidth;
using System.Data.OracleClient;

public partial class CustomerFundingFileUpload : System.Web.UI.Page
{
    string[] ARY;
    string RGS_SUPPORT;
    DataTable dt = new DataTable();
    LOV_COLLECTION lov = new LOV_COLLECTION();
    DatabaseConnection_Util _dbConfig = new DatabaseConnection_Util();
    DataSet ds = new DataSet();
    protected void Page_PreInit(object sender, EventArgs e)
    {
        Page.Theme = Session["ThemeChange"].ToString();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Response.Cache.SetCacheability(HttpCacheability.ServerAndNoCache);
            Session["RGS"] = "00000";
            String ST = Startup_Util.DcryptionPWD(Request.QueryString[0].ToString());
            ARY = ST.Split('~');
            Session["RGS"] = ARY[0].ToString();
            RGS_SUPPORT = Session["RGS"].ToString();
            if (RGS_SUPPORT.Substring(0, 1) == "0")
            {
                btnUpload.Visible = false;
            }
            else if (RGS_SUPPORT.Substring(0, 1) == "1")
            {
                btnUpload.Visible = true;
                btnUpload.Visible = true;
            }
            Response.Cache.SetCacheability(HttpCacheability.ServerAndNoCache);
            Session["UserId"] = Session["U_NAME"].ToString();
            if (!IsPostBack)
            {
                btnUpload.Attributes.Add("onclick", "return funConfirm();");
                ViewState["FileName"] = "";
            }
        }
        catch (Exception ex)
        {
            lbl_Message.Text = ex.Message;
        }
    }
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        Page.Validate();
        if (Page.IsValid)
        {
            try
            {
                if (Session["U_NAME"].ToString() == "")
                {
                    lbl_Message.Text = "User session expired, Please Re-Login";
                    return;
                }
                string p_return = UploadFile();
                if (p_return.Split(';')[0].ToString() == "0")
                {
                    insertData(p_return.Split(';')[1].ToString());
                }
                else
                {
                    lbl_Message.Text = "Error on file upload " + p_return.Split(';')[1].ToString();
                }
            }
            catch (Exception ex)
            {
                lbl_Message.Text = ex.Message;
            }
        }
    }
    public string UploadFile()
    {
        try
        {
            if (FileUpload1.PostedFile != null)
            {
                string filepath = "";
                string fileExtension = System.IO.Path.GetExtension(FileUpload1.FileName).ToUpper().Replace(".", "");
                int fileLength = FileUpload1.PostedFile.ContentLength;
                if (fileLength <= 1048576) //1048576KB equal to 1GB 
                {
                    byte[] myData = new byte[fileLength];
                    FileUpload1.PostedFile.InputStream.Read(myData, 0, fileLength);
                    filepath = Server.MapPath("../UploadFiles/" + FileUpload1.FileName);
                    WriteToFile(filepath, myData);
                    FileUpload1.PostedFile.InputStream.Close();
                    ViewState["FileName"] = FileUpload1.FileName;
                    return "0;" + filepath;
                }
            }
            else
            {
                lbl_Message.Text = "FileUpload1 Control value is null";
            }
        }
        catch (Exception ex)
        {
            return "1;" + ex.Message;
        }
        return "1;Error on file upload.";
    }
    public void insertData(string filepath)
    {
        string batch_no = "";
        Random rdnum = new Random();
        batch_no = DateTime.Now.ToString("yyyyMMdd") + rdnum.Next(1, 99999);
        hdn_value.Value = batch_no;
        try
        {
            DataTable fileData = new DataTable();
            Get_data(filepath);
            if (dt.Rows.Count > 0)
            {
                string[] retvalue;
                DBUniversalUploadProcess Upload = new DBUniversalUploadProcess();
                if (dt.Rows.Count > 0)
                {
                    string v_out = "";
                    retvalue = Upload.CustomerFindingUpload(dt.Rows.Count, Session["U_NAME"].ToString(), dt, batch_no, out v_out);

                    if (v_out.Split(';')[0] == "0")
                    {
                        bindDatawithStatus(retvalue);
                    }
                    else
                    {
                        lbl_Message.Text = v_out;
                    }
                }
            }
            else
            {
                lbl_Message.Text = "No data found in file.";
            }
        }
        catch (Exception ex)
        {
            lbl_Message.Text = ex.Message;
        }
        finally
        {
            if (File.Exists(filepath) == true)
            {
                File.Delete(filepath);
            }
        }
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
    private void WriteToFile(string strPath, byte[] Buffer)
    {
        FileStream newFile = new FileStream(strPath, FileMode.Create);
        newFile.Write(Buffer, 0, Buffer.Length);
        newFile.Close();
    }
    public void ExcelFile(string connstr)
    {
        try
        {
            string excelSheets = "";
            DataTable dtsheet = new DataTable();
            OleDbConnection conn = new OleDbConnection(connstr);
            conn.Open();
            dtsheet = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            string strSQL = "select * from [Sheet1$]";
            if (dtsheet != null)
            {
                excelSheets = dtsheet.Rows[0]["TABLE_NAME"].ToString();
                strSQL = "select * from [" + excelSheets + "]";
            }
            else
            {
                lbl_Message.Text = "Excel sheet not available in file.";
                return;
            }
            OleDbDataAdapter da = new OleDbDataAdapter(strSQL, conn);
            da.Fill(dt);
            conn.Close();
            #region
            //string connectionString = String.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=""Excel 8.0;HDR=YES;IMEX=1;""", connstr);
            //string query = "SELECT * FROM [" + excelSheets[0] + "]";
            //OleDbDataAdapter dataAdapter = new OleDbDataAdapter(query, connectionString);
            //dataAdapter.AcceptChangesDuringFill = false;
            //DataSet dataSet = new DataSet();
            //dataAdapter.Fill(dataSet);
            //dt = dataSet.Tables[0];
            //dataAdapter.Dispose();
            #endregion
        }
        catch (Exception ex)
        {
            lbl_Message.Text = ex.Message;
        }
    }
    public void Get_data(string filepath)
    {
        try
        {
            FileInfo file = new FileInfo(filepath);
            string strconnection = "";
            if (file.Extension.ToUpper() == ".XLSX")
            {
                strconnection = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + filepath + ";" + "Extended Properties=\"Excel 12.0 Xml;HDR=YES\"";
                ExcelFile(strconnection);
            }
            else if (file.Extension.ToUpper() == ".XLS")
            {
                strconnection = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filepath + ";Extended Properties=Excel 8.0;";
                ExcelFile(strconnection);
            }
            else
            {
                lbl_Message.Text = "File Format is invalid.";
                return;
            }
        }
        catch (Exception ex)
        {
            lbl_Message.Text = ex.Message;
        }
    }
    protected void btnPreview_Click(object sender, EventArgs e)
    {
        DataTable dt = get_data_cust_fund(hdn_value.Value);
        if (dt.Rows.Count > 0)
        {
            GridView1.DataSource = dt;
            GridView1.DataBind();
            btnUpload.Visible = false;
        }
    }
    public DataTable get_data_cust_fund(string p_batch_no)
    {
        DataSet ds = new DataSet();
        OracleParameter[] param = new OracleParameter[2];
        param[0] = _dbConfig.Oracle_Param("p_batch_no", OracleType.VarChar, ParameterDirection.Input, p_batch_no);
        param[1] = _dbConfig.Oracle_Param("p_dataset", OracleType.Cursor, ParameterDirection.Output, "");
        ds = _dbConfig.Oracle_GetDataSetSP("sp_get_cust_funding_upd", param);
        return ds.Tables[0];
    }
    public void bindDatawithStatus(string[] val)
    {
        DataTable dt_status = new DataTable();
        dt_status.Columns.AddRange(new DataColumn[1] { new DataColumn("Status", typeof(string)) });
        for (int i = 0; i < val.Length; i++)
        {
            dt_status.Rows.Add(val[i]);
        }
        GridView1.DataSource = dt_status;
        GridView1.DataBind();
    }
}
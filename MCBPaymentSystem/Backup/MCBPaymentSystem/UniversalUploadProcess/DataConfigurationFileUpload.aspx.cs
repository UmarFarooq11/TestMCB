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
using System.Text.RegularExpressions;
using System.Text;

public partial class DataConfigurationFileUpload : System.Web.UI.Page
{
    bool CheckGlobalVar = false;
    DataTable dt = new DataTable();
    LOV_COLLECTION lov = new LOV_COLLECTION();
    DatabaseConnection_Util _dbConfig = new DatabaseConnection_Util();
    DataSet ds = new DataSet();
    protected void Page_PreInit(object sender, EventArgs e)
    { Page.Theme = "SkinFile"; }//Session["ThemeChange"].ToString(); }
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Response.Cache.SetCacheability(HttpCacheability.ServerAndNoCache);

            btnProcess.Attributes.Add("style", "visibility:hidden;");
            btnUpload.Attributes.Add("onclick", "return funConfirm();");
            btnProcess.Attributes.Add("onclick", "return funConfirm();");
            btnRollBack.Attributes.Add("style", "visibility:hidden;");
            btnRollBack.Attributes.Add("onclick", "return funConfirmRollback();");
            Session["UserId"] = Request.QueryString["UID"].ToString();
            //Session["UserId"] = Session["U_NAME"].ToString();

            lbIBFT.Attributes.Add("style", "visibility:hidden;");
            lbA2A.Attributes.Add("style", "visibility:hidden;");
            lbPRI.Attributes.Add("style", "visibility:hidden;");
            lbCOC.Attributes.Add("style", "visibility:hidden;");
            lbDD.Attributes.Add("style", "visibility:hidden;");
            lbDuplicateRecords.Attributes.Add("style", "visibility:hidden;");
            lbIBANRecords.Attributes.Add("style", "visibility:hidden;");
            lbTotalTransaction.Attributes.Add("style", "visibility:hidden;");
            lbTotalAmount.Attributes.Add("style", "visibility:hidden;");
            lblSummary.Visible = false;
            lblrecord.Visible = false;
            lblamount.Visible = false;

            if (!IsPostBack)
            {
                ddlCompanyBind();
                ddlConfigIDBind();
                lblTotalRecord.Text = "";
                lblTotalAmount.Text = "";
            }
        }
        catch (Exception ex)
        {
            lbl_Message.Text = ex.Message;
        }
    }
    public void ddlCompanyBind()
    {
        if (CRUtlityGetsafeString(Session["UserId"]) == "")
        {
            lbl_Message.Text = "Session expired, Please re-login";
            return;
        }
        DataSet ds = new DataSet();
        ds = Get_Company_setup_lov("%", "%", Session["UserId"].ToString());
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlCompanyCode.DataSource = ds;
            ddlCompanyCode.DataValueField = "Company_Code";
            ddlCompanyCode.DataTextField = "Company_Name";
            ddlCompanyCode.DataBind();
        }
        else
        {
            ddlCompanyCode.Items.Insert(0, new ListItem("Company not found", ""));
        }
    }
    public void ddlConfigIDBind()
    {
        DataSet ds = new DataSet();

        ds = lov.Get_CONFIG_DEF_MASTER_LOV("2", ddlCompanyCode.SelectedValue, "%", "%");
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlConfigID.DataSource = ds;
            ddlConfigID.DataValueField = "CONF_DEF_ID";
            ddlConfigID.DataTextField = "CONF_DEF_DESC";
            ddlConfigID.DataBind();
        }
        else
        {
            ddlConfigID.Items.Insert(0, new ListItem("File templete not found", ""));
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
                    lbl_Message.Text = "Session expired, Please re-login";
                    return;
                }
                DataSet dsFileConfig = new DataSet();
                string Extension = "";
                string fileSeparate = "";
                GetGlobalVariable();
                dsFileConfig = FileFormat(ddlConfigID.SelectedValue.ToString());
                if (dsFileConfig.Tables[0].Rows.Count > 0)
                {
                    Extension = dsFileConfig.Tables[0].Rows[0][0].ToString();
                    fileSeparate = dsFileConfig.Tables[0].Rows[0][1].ToString();
                }
                else
                {
                    lbl_Message.Text = "File format not found.";
                }
                if (Extension != "")
                {
                    if (UploadFile(Extension) == true)
                    {
                        if (process(fileSeparate) == true)
                        {
                            Databind(ddlCompanyCode.SelectedValue, ViewState["fileName"].ToString());
                            btnRollBack.Attributes.Add("style", "visibility:visible;");
                            btnProcess.Attributes.Add("style", "visibility:visible;");

                        }
                        else
                        {
                            GridView1.DataSource = null;
                            GridView1.DataBind();
                        }
                    }
                    else
                    {
                        lbl_Message.Text = "Invalid file format";
                    }
                }
                else
                {
                    lbl_Message.Text = "File format not found";
                }
            }
            catch (Exception ex)
            {
                lbl_Message.Text = ex.Message;
            }
        }
    }
    public bool UploadFile(string Extension)
    {
        if (FileUpload1.PostedFile != null)
        {
            string fileExtension = System.IO.Path.GetExtension(FileUpload1.FileName).ToUpper().Replace(".", "");
            if (fileExtension == "XLSX" && Extension == "XLS")
            {
                fileExtension = "XLS";
            }
            //else if (fileExtension == "TXT" && Extension == "CSV")
            //{
            //    fileExtension = "CSV";
            //}
            if (fileExtension == Extension.ToUpper())
            {
                int fileLength = FileUpload1.PostedFile.ContentLength;
                if (fileLength <= 1048576) //1048576KB equal to 1GB 
                {
                    byte[] myData = new byte[fileLength];
                    FileUpload1.PostedFile.InputStream.Read(myData, 0, fileLength);
                    ViewState["fileName"] = FileUpload1.FileName;
                    string[] actualExt = ViewState["fileName"].ToString().Split('.');
                    if (actualExt[1].ToUpper() == "XLS")
                    {
                        actualExt[1] = ".XLSX";
                        ViewState["filepath"] = Server.MapPath("../UploadFiles/" + actualExt[0] + actualExt[1]);
                        WriteToFile(ViewState["filepath"].ToString(), myData);
                        FileUpload1.PostedFile.InputStream.Close();
                        lbl_Message.Text = "File successfully uploaded.";
                        return true;
                    }
                    #region
                    //else if (actualExt[1].ToUpper() == "TXT")
                    //{
                    //    actualExt[1] = ".CSV";
                    //    ViewState["filepath"] = Server.MapPath("../UploadFiles/" + actualExt[0] + actualExt[1]);
                    //    WriteToFile(ViewState["filepath"].ToString(), myData);
                    //    FileUpload1.PostedFile.InputStream.Close();
                    //    lbl_Message.Text = "File successfully uploaded.";
                    //    return true;
                    //}
                    #endregion
                    else
                    {
                        ViewState["filepath"] = Server.MapPath("../UploadFiles/" + ViewState["fileName"].ToString());
                        WriteToFile(ViewState["filepath"].ToString(), myData);
                        FileUpload1.PostedFile.InputStream.Close();
                        lbl_Message.Text = "File successfully uploaded.";
                        return true;
                    }
                }
            }
            else
            {
                lbl_Message.Text = "File format not match from Configuration";
            }
        }
        else
        {
            lbl_Message.Text = "FileUpload1 Control value is null";
        }
        return false;
    }
    private void WriteToFile(string strPath, byte[] Buffer)
    {
        FileStream newFile = new FileStream(strPath, FileMode.Create);
        newFile.Write(Buffer, 0, Buffer.Length);
        newFile.Close();
    }
    public bool process(string fileSeparate)
    {
        try
        {
            DataTable fileData = new DataTable();
            UploadLog(ddlCompanyCode.SelectedValue, ViewState["fileName"].ToString(), Session["UserId"].ToString(), "Get data from file Start", DateTime.Now.ToString());
            Get_data(ViewState["filepath"].ToString(), fileSeparate);
            UploadLog(ddlCompanyCode.SelectedValue, ViewState["fileName"].ToString(), Session["UserId"].ToString(), "Get data from file and records length " + dt.Rows.Count.ToString() + " End", DateTime.Now.ToString());

            string sp_name = "";
            if (dt.Rows.Count > 0)
            {
                string retvalue = "";
                DBUniversalUploadProcess Upload = new DBUniversalUploadProcess();
                retvalue = Upload.UploadProcess(dt.Rows.Count, dt, ddlCompanyCode.SelectedValue, ddlConfigID.SelectedValue, ViewState["fileName"].ToString());
                //sp_name = retvalue.Split(';').GetValue(1).ToString();
                sp_name = retvalue.IndexOf(';') > 0 ? retvalue.Split(';').GetValue(1).ToString() : retvalue;
                if (retvalue.StartsWith("0") == true)
                {
                    lbl_Message.Text = retvalue.Split(';').GetValue(1).ToString();
                    lblA2A.Text = "";
                    lblPRI.Text = "";
                    lblCOC.Text = "";
                    lblDD.Text = "";
                    lblDuplicateRecords.Text = "";
                    lblInvalidIBANRecords.Text = "";
                    lblTotalRecord.Text = "";
                    lblTotalAmount.Text = "";

                    lblA2ATOT.Text = "";
                    lblPRITOT.Text = "";
                    lblCOCTOT.Text = "";
                    lblDDTOT.Text = "";
                    lblDUPTOT.Text = "";
                    lblIBANTOT.Text = "";

                    if (File.Exists(ViewState["filepath"].ToString()) == true)
                    {
                        File.Delete(ViewState["filepath"].ToString());
                    }
                    UploadLog(ddlCompanyCode.SelectedValue, ViewState["fileName"].ToString(), Session["UserId"].ToString(), "Error on SP_RAW_DATALOAD : " + retvalue + " and file deleted at local path", DateTime.Now.ToString());
                    return false;
                }
                else
                {
                    string TransType = (chTransDD.Checked == true) ? "Y" : "N";
                    UploadLog(ddlCompanyCode.SelectedValue, ViewState["fileName"].ToString(), Session["UserId"].ToString(), "Call SP_RAW_DATALOAD1 Start", DateTime.Now.ToString());
                    retvalue = Upload.MianProcess(ddlCompanyCode.SelectedValue, ddlConfigID.SelectedValue, ViewState["fileName"].ToString(), TransType, sp_name);
                    UploadLog(ddlCompanyCode.SelectedValue, ViewState["fileName"].ToString(), Session["UserId"].ToString(), "Call SP_RAW_DATALOAD1 and return value " + retvalue + " End", DateTime.Now.ToString());

                    lbl_Message.Text = retvalue.IndexOf(';') > 0 ? retvalue.Split(';').GetValue(1).ToString() : retvalue;
                    //retvalue.Split(';').GetValue(1).ToString();
                    DataSet ds1 = new DataSet();
                    if (retvalue.StartsWith("1") == true)
                    {
                        DBProcess spProcess = new DBProcess();
                        spProcess.RecordInputStart();
                        spProcess.Get_Company_Code = ddlCompanyCode.SelectedValue;
                        spProcess.Get_Conf_ID = ddlConfigID.SelectedValue;
                        spProcess.Get_FileName = ViewState["fileName"].ToString();
                        spProcess.Get_UserID = Session["UserId"].ToString();
                        spProcess.Get_TOTAL_RECORDS = dt.Rows.Count.ToString();
                        spProcess.RecordInputCommit();
                        spProcess.AddNewGroup();


                        #region Summary and Duplication
                        UploadLog(ddlCompanyCode.SelectedValue, ViewState["fileName"].ToString(), Session["UserId"].ToString(), "Get data for file summary Start", DateTime.Now.ToString());
                        ds1 = lov.GetFileSummary(ddlCompanyCode.SelectedValue, ViewState["fileName"].ToString());
                        UploadLog(ddlCompanyCode.SelectedValue, ViewState["fileName"].ToString(), Session["UserId"].ToString(), "Get data for file summary End", DateTime.Now.ToString());

                        lblIBFT.Text = ds1.Tables[0].Rows[0]["IBFT"].ToString();
                        lblA2A.Text = ds1.Tables[0].Rows[0]["A2A"].ToString();
                        lblPRI.Text = ds1.Tables[0].Rows[0]["PRI"].ToString();
                        lblCOC.Text = ds1.Tables[0].Rows[0]["COC"].ToString();
                        lblDD.Text = ds1.Tables[0].Rows[0]["DD"].ToString();
                        lblDuplicateRecords.Text = ds1.Tables[1].Rows[0]["DuplicateRecords"].ToString();
                        lblInvalidIBANRecords.Text = ds1.Tables[1].Rows[0]["InvalidIBANRecords"].ToString();

                        /*filerecodsSp = Convert.ToInt32(ds1.Tables[0].Rows[0]["total_records"]) 
                                      +Convert.ToInt32(ds1.Tables[1].Rows[0]["DuplicateRecords"]);*/

                        lblIBFTTOT.Text = ds1.Tables[0].Rows[0]["IBFTTOT"].ToString();
                        lblA2ATOT.Text = ds1.Tables[0].Rows[0]["A2ATOT"].ToString();
                        lblPRITOT.Text = ds1.Tables[0].Rows[0]["PRITOT"].ToString();
                        lblCOCTOT.Text = ds1.Tables[0].Rows[0]["COCTOT"].ToString();
                        lblDDTOT.Text = ds1.Tables[0].Rows[0]["DDTOT"].ToString();
                        lblDUPTOT.Text = ds1.Tables[1].Rows[0]["DUPTOT"].ToString();
                        lblIBANTOT.Text = ds1.Tables[1].Rows[0]["IBANTOT"].ToString();

                        lblTotalAmount.Text = Convert.ToString(Convert.ToDecimal(ds1.Tables[0].Rows[0]["TotalAmount"]) + Convert.ToDecimal(ds1.Tables[1].Rows[0]["DUPTOT"]) + Convert.ToDecimal(ds1.Tables[1].Rows[0]["IBANTOT"]));
                        int count = Convert.ToInt32(ds1.Tables[0].Rows[0]["IBFT"]) +
                                    Convert.ToInt32(ds1.Tables[0].Rows[0]["A2A"]) +
                                    Convert.ToInt32(ds1.Tables[0].Rows[0]["PRI"]) +
                                    Convert.ToInt32(ds1.Tables[0].Rows[0]["COC"]) +
                                    Convert.ToInt32(ds1.Tables[0].Rows[0]["DD"]);
                        lblTotalRecord.Text = Convert.ToString(count + Convert.ToInt64(lblDuplicateRecords.Text) + Convert.ToInt64(lblInvalidIBANRecords.Text));

                        lbIBFT.Attributes.Add("style", "visibility:visible;");
                        lbA2A.Attributes.Add("style", "visibility:visible;");
                        lbPRI.Attributes.Add("style", "visibility:visible;");
                        lbCOC.Attributes.Add("style", "visibility:visible;");
                        lbDD.Attributes.Add("style", "visibility:visible;");
                        lbDuplicateRecords.Attributes.Add("style", "visibility:visible;");
                        lbIBANRecords.Attributes.Add("style", "visibility:visible;");
                        lbTotalTransaction.Attributes.Add("style", "visibility:visible;");
                        lbTotalAmount.Attributes.Add("style", "visibility:visible;");

                        if (Convert.ToInt32(lblDuplicateRecords.Text) > 0)
                        {
                            //lbDuplicateRecords
                            lbDuplicateRecords.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
                            lbDuplicateRecords.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";
                            string company_code = ddlCompanyCode.SelectedValue;
                            string file_name = ViewState["fileName"].ToString();
                            lbDuplicateRecords.Attributes.Add("onclick", "var str='MCB';wid=window.open('duplicateRecord.aspx?company_code=" + company_code + "&file_name=" + file_name + "', 'CS', 'left=550,top=165,height=650, width= 450 ,menubar=no,location=no,toolbar=no,scrollbars=yes,resizable=yes');return false;");
                        }
                        else
                        {
                            lbDuplicateRecords.Attributes["onmouseover"] = "javascript:NODuplicate(this);";
                            lbDuplicateRecords.Attributes.Add("onclick", "return false");
                        }
                        if (Convert.ToInt32(lblInvalidIBANRecords.Text) > 0)
                        {
                            //lbDuplicateRecords
                            lbIBANRecords.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
                            lbIBANRecords.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";
                            string company_code = ddlCompanyCode.SelectedValue;
                            string file_name = ViewState["fileName"].ToString();
                            lbIBANRecords.Attributes.Add("onclick", "var str='MCB';wid=window.open('IBANInvalidRecord.aspx?company_code=" + company_code + "&file_name=" + file_name + "', 'CS', 'left=550,top=165,height=650, width= 450 ,menubar=no,location=no,toolbar=no,scrollbars=yes,resizable=yes');return false;");
                        }
                        else
                        {
                            lbIBANRecords.Attributes["onmouseover"] = "javascript:NODuplicate(this);";
                            lbIBANRecords.Attributes.Add("onclick", "return false");
                        }


                        lblSummary.Visible = true;
                        lblrecord.Visible = true;
                        lblamount.Visible = true;
                        dt = lov.GetContactNoforSMS(ddlCompanyCode.SelectedValue, ViewState["fileName"].ToString(), "01").Tables[0];
                        if (dt.Rows.Count > 0)
                        {
                            int y = 0;
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                if (GenerateSMS(dt.Rows[i]["contactnumber"].ToString(), dt.Rows[i]["msg"].ToString()) == true)
                                {
                                    y = 1;
                                }
                            }
                            if (y == 1)
                            {
                                lbl_Message.Text += " and SMS has been sent to Beneficiary.";
                            }
                        }
                        #endregion
                    }
                }
            }
        }
        catch (Exception ex)
        {
            lbl_Message.Text = ex.Message;
        }

        UploadLog(ddlCompanyCode.SelectedValue, ViewState["fileName"].ToString(), Session["UserId"].ToString(), "In process method file delete at local path Start", DateTime.Now.ToString());
        if (File.Exists(ViewState["filepath"].ToString()) == true)
        {
            File.Delete(ViewState["filepath"].ToString());
        }
        UploadLog(ddlCompanyCode.SelectedValue, ViewState["fileName"].ToString(), Session["UserId"].ToString(), "In process method file delete at local path End", DateTime.Now.ToString());
        return true;
    }
    public void Get_data(string filepath, string fileSeparate)
    {
        try
        {
            FileInfo file = new FileInfo(filepath);
            string strconnection = "";
            if (file.Extension.ToUpper() == ".XLSX")
            {
                strconnection = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + filepath + ";" + "Extended Properties=\"Excel 12.0 Xml;HDR=YES\"";
                UploadLog(ddlCompanyCode.SelectedValue, ViewState["fileName"].ToString(), Session["UserId"].ToString(), "Excel connection string :" + strconnection, DateTime.Now.ToString());
                ExcelFile(strconnection);
            }
            else if (file.Extension.ToUpper() == ".XLS")
            {
                strconnection = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filepath + ";Extended Properties=Excel 8.0;";
                UploadLog(ddlCompanyCode.SelectedValue, ViewState["fileName"].ToString(), Session["UserId"].ToString(), "Excel connection string :" + strconnection, DateTime.Now.ToString());
                ExcelFile(strconnection);
            }
            else if (file.Extension.ToUpper() == ".CSV")
            {
                CSVFile(filepath, fileSeparate);
            }
            else if (file.Extension.ToUpper() == ".TXT")
            {
                FixedFILE(filepath, fileSeparate);
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
    public void ExcelFile(string connstr)
    {
        //String strExcelConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + strFilePath + ";Extended Properties='Excel 8.0;HDR=No'";
        OleDbConnection connExcel = new OleDbConnection(connstr);
        OleDbCommand cmdExcel = new OleDbCommand();
        try
        {
            cmdExcel.Connection = connExcel;
            UploadLog(ddlCompanyCode.SelectedValue, ViewState["fileName"].ToString(), Session["UserId"].ToString(), "Excel Connection Open & check connection state Start : " + connExcel.State.ToString(), DateTime.Now.ToString());
            connExcel.Open();
            UploadLog(ddlCompanyCode.SelectedValue, ViewState["fileName"].ToString(), Session["UserId"].ToString(), "Excel Connection Open & check connection state End " + connExcel.State.ToString(), DateTime.Now.ToString());

            DataTable dtExcelSchema;
            UploadLog(ddlCompanyCode.SelectedValue, ViewState["fileName"].ToString(), Session["UserId"].ToString(), "Get excel sheet name Start", DateTime.Now.ToString());
            dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            UploadLog(ddlCompanyCode.SelectedValue, ViewState["fileName"].ToString(), Session["UserId"].ToString(), "Get excel sheet name End : " + dtExcelSchema.Rows[0]["TABLE_NAME"].ToString(), DateTime.Now.ToString());

            connExcel.Close();
            UploadLog(ddlCompanyCode.SelectedValue, ViewState["fileName"].ToString(), Session["UserId"].ToString(), "Connection Close Excel Sheet", DateTime.Now.ToString());


            UploadLog(ddlCompanyCode.SelectedValue, ViewState["fileName"].ToString(), Session["UserId"].ToString(), "Excel Connection Open For Fill datatable & check connection state Start : " + connExcel.State.ToString(), DateTime.Now.ToString());
            connExcel.Open();
            UploadLog(ddlCompanyCode.SelectedValue, ViewState["fileName"].ToString(), Session["UserId"].ToString(), "Excel Connection Open For Fill datatable & check connection state End : " + connExcel.State.ToString(), DateTime.Now.ToString());

            OleDbDataAdapter da = new OleDbDataAdapter();
            DataSet ds = new DataSet();
            string SheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
            cmdExcel.CommandText = "SELECT * From [" + SheetName + "]";
            da.SelectCommand = cmdExcel;
            da.AcceptChangesDuringFill = false;
            UploadLog(ddlCompanyCode.SelectedValue, ViewState["fileName"].ToString(), Session["UserId"].ToString(), "Fill data in datatable Start", DateTime.Now.ToString());
            da.Fill(dt);
            UploadLog(ddlCompanyCode.SelectedValue, ViewState["fileName"].ToString(), Session["UserId"].ToString(), "Fill data in datatable End : " + dt.Rows.Count.ToString(), DateTime.Now.ToString());
            connExcel.Close();
        }
        catch (Exception ex)
        {
            lbl_Message.Text = ex.Message;
        }
        finally
        {
            if (connExcel.State == ConnectionState.Open)
            {
                connExcel.Close();
            }
            cmdExcel.Dispose();
            connExcel.Dispose();
        }
        UploadLog(ddlCompanyCode.SelectedValue, ViewState["fileName"].ToString(), Session["UserId"].ToString(), "After all activity of fill datatable & check connection State : " + connExcel.State.ToString(), DateTime.Now.ToString());
    }
    public void CSVFile(string filepath, string fileSeparate)
    {
        StreamReader sr = new StreamReader(filepath);
        try
        {
            DataSet ds = new DataSet();
            //using (CsvReader csvData = new CsvReader(filepath))
            //{
            //    dt = csvData.ReadToEnd(true);
            //}
            ds = lov.Get_Column_Lenght(ddlConfigID.SelectedValue);
            if (fileSeparate == "") fileSeparate = ",";

            int colLen = 0;
            string inputLine = "";
            string[] values = null;
            int a = 0;
            while ((inputLine = sr.ReadLine()) != null)
            {
                if (a >= Convert.ToInt32((ds.Tables[0].Rows[0]["record_skip"].ToString() == "" ? "0" : ds.Tables[0].Rows[0]["record_skip"])))
                {
                    if (fileSeparate == ",")
                    {
                        values = SplitCSV(inputLine);
                    }
                    else
                    {
                        values = inputLine.Split(Convert.ToChar(fileSeparate));
                    }

                    if (dt.Columns.Count == 0)
                    {
                        for (int i = 0; i < values.Length; i++)
                        {
                            dt.Columns.Add(new DataColumn("Column" + i, typeof(string)));
                        }
                    }
                    colLen = dt.Columns.Count;
                    if (colLen >= values.Length)
                    {
                        dt.Rows.Add(values);
                    }
                    else
                    {
                        for (int l = colLen; l < values.Length; l++)
                        {
                            dt.Columns.Add(new DataColumn("Column" + l, typeof(string)));
                        }
                        //dt.Columns.Add(new DataColumn("Column" + colLen, typeof(string)));
                        dt.Rows.Add(values);
                    }
                }
                a++;
            }
        }
        catch (Exception ex)
        {
            lbl_Message.Text = ex.Message;
        }
        sr.Close();
    }
    public void FixedFILE(string filepath, string fileSeparate)
    {
        #region
        //DataSet ds = new DataSet();
        //ds = lov.Get_Column_Lenght(ddlConfigID.SelectedValue);
        //if (ds.Tables[0].Rows.Count > 0)
        //{
        //    using (FixedWidthReader FixedFileRead = new FixedWidthReader(filepath))
        //    {
        //        int k = 0;
        //        for (int i = 0; i <= 50; i++)
        //        {
        //            FixedFileRead.Columns.Add(Convert.ToInt32(ds.Tables[0].Rows[i][0]));
        //            k++;
        //            if (ds.Tables[0].Rows.Count <= k) break;
        //        }
        //        dt = FixedFileRead.ReadToEnd(20);
        //    }
        //}
        #endregion
        //DataTable dt = new DataTable();
        if (fileSeparate == "")
        {
            DataSet ds = new DataSet();
            using (TextReader tr = File.OpenText(filepath))
            {
                string line;
                ds = lov.Get_Column_Lenght(ddlConfigID.SelectedValue);
                int a = 0;
                while ((line = tr.ReadLine()) != null)
                {
                    if (a >= Convert.ToInt32((ds.Tables[0].Rows[0]["record_skip"].ToString() == "" ? "0" : ds.Tables[0].Rows[0]["record_skip"])))
                    {
                        string[] items = new string[ds.Tables[0].Rows.Count];
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {

                            if (i == 0)
                            {
                                items[i] = line.Substring(Convert.ToInt32(ds.Tables[0].Rows[i][0]), Convert.ToInt32(ds.Tables[0].Rows[i][1]) - 1);
                            }
                            else
                            {
                                items[i] = line.Substring(Convert.ToInt32(ds.Tables[0].Rows[i][0]) - 1, Convert.ToInt32(ds.Tables[0].Rows[i][1]));
                            }


                        }
                        if (dt.Columns.Count == 0)
                        {
                            for (int i = 0; i < items.Length; i++)
                            {
                                dt.Columns.Add(new DataColumn("Column" + i, typeof(string)));
                            }
                        }
                        dt.Rows.Add(items);
                        //if (a >= Convert.ToInt32((ds.Tables[0].Rows[0]["record_skip"] == "" ? "0" : ds.Tables[0].Rows[0]["record_skip"])))
                        //{
                        //    dt.Rows.Add(items);
                        //}
                    }
                    a++;
                }
            }
        }
        else
        {
            StreamReader sr = new StreamReader(filepath);
            try
            {
                DataSet ds = new DataSet();
                ds = lov.Get_Column_Lenght(ddlConfigID.SelectedValue);
                if (fileSeparate == "null") fileSeparate = ",";

                string inputLine = "";
                //DataTable dt = new DataTable();
                string[] values = null;
                int a = 0;
                while ((inputLine = sr.ReadLine()) != null)
                {
                    if (a >= Convert.ToInt32((ds.Tables[0].Rows[0]["record_skip"].ToString() == "" ? "0" : ds.Tables[0].Rows[0]["record_skip"])))
                    {
                        values = inputLine.Split(Convert.ToChar(fileSeparate));
                        if (dt.Columns.Count == 0)
                        {
                            for (int i = 0; i < values.Length; i++)
                            {
                                dt.Columns.Add(new DataColumn("Column" + i, typeof(string)));
                            }
                        }
                        dt.Rows.Add(values);
                    }
                    a++;
                }
                //sr.Close();
            }
            catch (Exception ex)
            {
                lbl_Message.Text = ex.Message;
            }
            sr.Close();
        }
    }
    public void Databind(string companyCode, string filename)
    {
        ds = lov.UniversalUploadDataBind(companyCode, filename);
        if (ds.Tables[0].Rows.Count > 0)
        {
            ViewState["TaskTable"] = ds.Tables[0];
            GridView1.DataSource = ds;
            GridView1.DataBind();
            //lblTotalRecord.Text = ds.Tables[0].Rows.Count.ToString();
        }
        else
        {
            //lblA2A.Text = "";
            //lblPRI.Text = "";
            //lblCOC.Text = "";
            //lblDD.Text = "";
            //lblDuplicateRecords.Text = "";
            //lblTotalRecord.Text = "";
            ViewState["TaskTable"] = ds.Tables[0];
            DataRow dr = ds.Tables[0].NewRow();
            ds.Tables[0].Rows.Add(dr);

            this.GridView1.DataSource = ds.Tables[0];
            this.GridView1.DataBind();

            this.GridView1.Rows[0].Cells.Clear();
            this.GridView1.Rows[0].Cells.Add(new TableCell());
            this.GridView1.Rows[0].Cells[0].ColumnSpan = GridView1.Rows[0].Cells.Count;
            this.GridView1.Rows[0].Cells[0].Text = "No Record found.";

            //GridView1.DataSource = null;
            //GridView1.DataBind();
        }
    }
    protected void ddlCompanyCode_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlConfigIDBind();
    }
    protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataTable dt = ViewState["TaskTable"] as DataTable;
        if (dt != null)
        {
            //if (dt.Rows.Count > 0)
            //{
            dt.DefaultView.Sort = e.SortExpression + " " + GetSortDirection(e.SortExpression);
            GridView1.DataSource = ViewState["TaskTable"];
            GridView1.DataBind();

            //}
        }
    }
    private string GetSortDirection(string column)
    {
        string sortDirection = "ASC";
        string sortExpression = ViewState["SortExpression"] as string;
        if (sortExpression != null)
        {
            if (sortExpression == column)
            {
                string lastDirection = ViewState["SortDirection"] as string;
                if ((lastDirection != null) && (lastDirection == "ASC"))
                {
                    sortDirection = "DESC";
                }
            }
        }
        ViewState["SortDirection"] = sortDirection;
        ViewState["SortExpression"] = column;
        return sortDirection;
    }
    protected void btnRollBack_Click(object sender, EventArgs e)
    {
        try
        {
            string p_return = "";
            DataSet ds = new DataSet();
            OracleParameter[] parms = new OracleParameter[10];
            parms[0] = _dbConfig.Oracle_Param("P_company_code", OracleType.VarChar, ParameterDirection.Input, ddlCompanyCode.SelectedValue.ToString());
            parms[1] = _dbConfig.Oracle_Param("P_FILE_NAME", OracleType.VarChar, ParameterDirection.Input, ViewState["fileName"].ToString());
            parms[2] = _dbConfig.Oracle_Param("P_Trans_type", OracleType.VarChar, ParameterDirection.Input, "");
            parms[3] = _dbConfig.Oracle_Param("P_Rowid", OracleType.VarChar, ParameterDirection.Input, "");
            parms[4] = _dbConfig.Oracle_Param("p_bank_code", OracleType.VarChar, ParameterDirection.Input, "");
            parms[5] = _dbConfig.Oracle_Param("p_branch_code", OracleType.VarChar, ParameterDirection.Input, "");
            parms[6] = _dbConfig.Oracle_Param("P_Userid", OracleType.VarChar, ParameterDirection.Input, Session["U_NAME"].ToString());
            parms[7] = _dbConfig.Oracle_Param("P_type", OracleType.VarChar, ParameterDirection.Input, "16");
            parms[8] = _dbConfig.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
            parms[9] = _dbConfig.Oracle_Param("v_retval", OracleType.VarChar, ParameterDirection.Output, "");
            ds = _dbConfig.Oracle_GetDataSetSP("SP_Data_Segregation", parms);
            p_return = ds.Tables[0].Rows[0][0].ToString().Split(';').GetValue(1).ToString();
            lbl_Message.Text = p_return;
            Databind(ddlCompanyCode.SelectedValue, ViewState["fileName"].ToString());

            lblIBFT.Text = "";
            lblA2A.Text = "";
            lblPRI.Text = "";
            lblCOC.Text = "";
            lblDD.Text = "";
            lblDuplicateRecords.Text = "";
            lblInvalidIBANRecords.Text = "";
            lblTotalRecord.Text = "";
            lblTotalAmount.Text = "";

            lblIBFTTOT.Text = "";
            lblA2ATOT.Text = "";
            lblPRITOT.Text = "";
            lblCOCTOT.Text = "";
            lblDDTOT.Text = "";
            lblDUPTOT.Text = "";
            lblIBANTOT.Text = "";
        }
        catch (Exception ex)
        {
            lbl_Message.Text = ex.Message;
        }
    }
    private bool GenerateSMS(string MobileNo, string MSG)
    {
        try
        {
            GetSMSData();
            string SMSMsg = Utility.SendSMS(Session["SMSUserID"].ToString(), Session["SMSPassword"].ToString(), MobileNo, MSG, Session["SMSChannelCode"].ToString());
            if (SMSMsg == "00")
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
            lbl_Message.Text = ex.Message;
        }
        return true;
    }
    private string GetSMSData()
    {
        string UserID = "", Password = "", ChannelCode = "";
        System.Data.DataTable dt = lov.GetIDPASSforSMS("select DYVAL2 UserID,DYVAL3 PWD,DYVAL4 ChannelCode from mcb_dynamicsetup where DYCD='MCBSMS' and DYDESC='SMS Service'").Tables[0];

        if (dt.Rows.Count > 0)
        {
            Session["SMSUserID"] = dt.Rows[0]["UserID"];
            Session["SMSPassword"] = dt.Rows[0]["PWD"];
            Session["SMSChannelCode"] = dt.Rows[0]["ChannelCode"];
        }
        return UserID + ";" + Password + ";" + ChannelCode;
    }
    protected void btnProcess_Click(object sender, EventArgs e)
    {
        Page.Validate();
        if (Page.IsValid)
        {
            if (CRUtlityGetsafeString(Session["UserId"].ToString()) == "")
            {
                lbl_Message.Text = "User session expired, Please Re-Login";
                return;
            }
            try
            {
                clearSummary();
                string val = FileProcess(ddlCompanyCode.SelectedValue, ViewState["fileName"].ToString(), "Upload", Session["UserId"].ToString());
                val = val.Contains(";") == true ? val.Split(';')[1].ToString() : val;
                lbl_Message.Text = val;
                btnRollBack.Attributes.Add("style", "visibility:hidden;");
                GridView1.DataSource = null;
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                lbl_Message.Text = ex.Message;
            }
        }
    }
    public DataSet FileFormat(string ConfigDefID)
    {
        DataSet ds = new DataSet();
        OracleParameter[] param = new OracleParameter[2];
        param[0] = _dbConfig.Oracle_Param("p_conf_def_id", OracleType.VarChar, ParameterDirection.Input, ConfigDefID);
        param[1] = _dbConfig.Oracle_Param("p_dataset", OracleType.Cursor, ParameterDirection.Output, "");
        ds = _dbConfig.Oracle_GetDataSetSP("sp_get_fileParser", param);
        return ds;
    }
    public string[] FileRollBack(string company_code, string file_name)
    {
        string p_return = "";
        string[] p_retval;
        try
        {
            DataSet ds = new DataSet();
            OracleParameter[] parms = new OracleParameter[10];
            parms[0] = _dbConfig.Oracle_Param("P_company_code", OracleType.VarChar, ParameterDirection.Input, company_code);
            parms[1] = _dbConfig.Oracle_Param("P_FILE_NAME", OracleType.VarChar, ParameterDirection.Input, file_name);
            parms[2] = _dbConfig.Oracle_Param("P_Trans_type", OracleType.VarChar, ParameterDirection.Input, "");
            parms[3] = _dbConfig.Oracle_Param("P_Rowid", OracleType.VarChar, ParameterDirection.Input, "");
            parms[4] = _dbConfig.Oracle_Param("p_bank_code", OracleType.VarChar, ParameterDirection.Input, "");
            parms[5] = _dbConfig.Oracle_Param("p_branch_code", OracleType.VarChar, ParameterDirection.Input, "");
            parms[6] = _dbConfig.Oracle_Param("P_Userid", OracleType.VarChar, ParameterDirection.Input, Session["UserId"].ToString());
            parms[7] = _dbConfig.Oracle_Param("P_type", OracleType.VarChar, ParameterDirection.Input, "16");
            parms[8] = _dbConfig.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
            parms[9] = _dbConfig.Oracle_Param("v_retval", OracleType.VarChar, ParameterDirection.Output, "");
            ds = _dbConfig.Oracle_GetDataSetSP("SP_Data_Segregation", parms);
            p_return = ds.Tables[0].Rows[0][0].ToString();
        }
        catch (Exception ex)
        {
            p_return = "0;" + ex.Message;
        }
        p_retval = p_return.Split(';');
        return p_retval;
    }
    public void clearSummary()
    {
        lblIBFT.Text = "";
        lblA2A.Text = "";
        lblPRI.Text = "";
        lblCOC.Text = "";
        lblDD.Text = "";
        lblDuplicateRecords.Text = "";
        lblInvalidIBANRecords.Text = "";
        lblTotalRecord.Text = "";
        lblTotalAmount.Text = "";

        lblIBFTTOT.Text = "";
        lblA2ATOT.Text = "";
        lblPRITOT.Text = "";
        lblCOCTOT.Text = "";
        lblDDTOT.Text = "";
        lblDUPTOT.Text = "";
        lblIBANTOT.Text = "";
    }
    public void UploadLog(string comapny_code, string filename, string user_id, string action, string app_datetime)
    {
        string p_return = "";
        try
        {
            if (CheckGlobalVar == true)
            {
                OracleParameter[] parm = new OracleParameter[6];
                parm[0] = _dbConfig.Oracle_Param("p_company_code", OracleType.VarChar, ParameterDirection.Input, comapny_code);
                parm[1] = _dbConfig.Oracle_Param("p_file_name", OracleType.VarChar, ParameterDirection.Input, filename);
                parm[2] = _dbConfig.Oracle_Param("p_userid", OracleType.VarChar, ParameterDirection.Input, user_id);
                parm[3] = _dbConfig.Oracle_Param("p_action", OracleType.VarChar, ParameterDirection.Input, action);
                parm[4] = _dbConfig.Oracle_Param("p_app_datetime", OracleType.VarChar, ParameterDirection.Input, app_datetime);
                parm[5] = _dbConfig.Oracle_Param("p_return", OracleType.VarChar, ParameterDirection.Output, "");
                p_return = _dbConfig.OracleExecuteSP_GetReturnVal("sp_UploadLog", parm, 5);
            }
        }
        catch (Exception ex)
        {
            p_return = ex.Message;
        }
    }
    public void GetGlobalVariable()
    {
        DataTable dtChk = new DataTable();
        string p_return = "";
        try
        {
            OracleParameter[] parm = new OracleParameter[1];
            parm[0] = _dbConfig.Oracle_Param("p_data_set", OracleType.Cursor, ParameterDirection.Output, "");
            dtChk = _dbConfig.Oracle_GetDataSetSP("sp_check_globalVal", parm).Tables[0];
            if (dtChk.Rows.Count > 0)
            {
                string val = dtChk.Rows[0][0].ToString();
                CheckGlobalVar = val.ToUpper() == "TRUE" ? true : false;
            }
            else
            {
                CheckGlobalVar = true;
            }
        }
        catch (Exception ex)
        {
            CheckGlobalVar = true;
            p_return = ex.Message;
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
    public DataSet Get_Company_setup_lov(string companycode, string companyname, string userid)
    {
        DataSet DS = new DataSet();
        OracleParameter[] parms = new OracleParameter[4];
        parms[0] = _dbConfig.Oracle_Param("P_COMPANY_CODE", OracleType.VarChar, ParameterDirection.Input, companycode);
        parms[1] = _dbConfig.Oracle_Param("P_COMPANY_NAME", OracleType.VarChar, ParameterDirection.Input, companyname);
        parms[2] = _dbConfig.Oracle_Param("P_USER_ID", OracleType.VarChar, ParameterDirection.Input, userid);
        parms[3] = _dbConfig.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = _dbConfig.Oracle_GetDataSetSP("SP_COMPANY_SETUP_ALL", parms);
        return DS;
    }
    public string FileProcess(string p_company_code, string p_file_name, string p_type, string p_user_id)
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
}
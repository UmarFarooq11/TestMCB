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


public partial class PRIDownloadIBAN : System.Web.UI.Page
{
    string[] ARY;
    string RGS_SUPPORT;
    DatabaseConnection_Util DB = new DatabaseConnection_Util();
    DatabaseConnection_Util DataTransform = new DatabaseConnection_Util();
    FileOp FO = new FileOp();
    protected void Page_PreInit(object sender, EventArgs e)
    { Page.Theme = Session["ThemeChange"].ToString(); }
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetCacheability(HttpCacheability.ServerAndNoCache);
        //ScriptManager sm = ScriptManager.GetCurrent(this.Page);
        //sm.RegisterPostBackControl(GridView1);
        Session["RGS"] = "00000";
        String ST = Startup_Util.DcryptionPWD(Request.QueryString[0].ToString());
        ARY = ST.Split('~');
        Session["RGS"] = ARY[0].ToString();
        RGS_SUPPORT = Session["RGS"].ToString();
        if (RGS_SUPPORT.Substring(0, 1) == "0")
        {
            GridView1.Visible = false; /*ADD*/
        }
        else if (RGS_SUPPORT.Substring(0, 1) == "1")
        {
            GridView1.Visible = true; /*ADD*/
        }
        if (!IsPostBack)
        {
            if (Request.QueryString["UID"] != null)
            {
                Session["U_NAME"] = Request.QueryString["UID"].ToString();
                DisplayFiles();
            }
        }
    }
    public void GridBind()
    {
        try
        {
            DataSet DS = new DataSet();
            OracleParameter[] PR = new OracleParameter[1];
            PR[0] = DataTransform.Oracle_Param("data_resultset", OracleType.Cursor, ParameterDirection.Output, "");
            DS = DataTransform.Oracle_GetDataSetSP("sp_getpridatafodownload", PR);
            if (DS.Tables[0].Rows.Count > 0)
            {
                GridView1.DataSource = DS;
                GridView1.DataBind();
            }
            else
            {
                GridView1.DataSource = null;
                GridView1.DataBind();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnFetch_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["U_NAME"].ToString() == "")
            {
                lblMessage.Text = "User session has been expired, Please Re-Login.";
                return;
            }
            lblMessage.Text = "";
            GridBind();
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }
    protected void btnDownload_Click(object sender, EventArgs e)
    {
        try
        {
            FileFoDownload();
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }
    protected void btnPaid_Click(object sender, EventArgs e)
    {
        if (Session["U_NAME"].ToString() == "")
        {
            lblMessage.Text = "User session has been expired, Please Re-Login.";
            return;
        }
        LinkButton lnkbtn = (LinkButton)sender;
        GridViewRow row = (GridViewRow)lnkbtn.NamingContainer;
        filedownload(row.RowIndex);
    }
    public void filedownload(int row)
    {
        try
        {
            string ID = GridView1.Rows[row].Cells[1].Text;
            string pri_filename = "PRI_03_" + GridView1.Rows[row].Cells[0].Text + "_" + DateTime.Now.ToString("ddMMyyyy") + "_" + DateTime.Now.ToString("HHmm") + ".TXT";
            string retval = PRIDownloadMarking(ID, pri_filename, Session["U_NAME"].ToString());
            if (retval.StartsWith("0"))
            {
                DisplayFiles();
                GridBind();
            }
            else
            {
                ((Label)GridView1.Rows[row].FindControl("lblstatus")).Text = retval.Contains(";") == true ? retval.Split(';')[1].ToString() : retval;
            }
            
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }
    public string PRIDownloadMarking(string ID, string fileName, string userid)
    {
        string retVal = "";
        try
        {
            OracleParameter[] PR = new OracleParameter[4];
            PR[0] = DataTransform.Oracle_Param("p_corrbankid", OracleType.VarChar, ParameterDirection.Input, ID);
            PR[1] = DataTransform.Oracle_Param("p_pri_filename", OracleType.VarChar, ParameterDirection.Input, fileName);
            PR[2] = DataTransform.Oracle_Param("p_user_id", OracleType.VarChar, ParameterDirection.Input, userid);
            PR[3] = DataTransform.Oracle_Param("p_return", OracleType.VarChar, ParameterDirection.Output, "");
            retVal = DataTransform.OracleExecuteSP_GetReturnVal("sp_pridownloadmarking", PR, 3);
        }
        catch (Exception ex)
        {
            retVal = ex.Message;
        }
        return retVal;

    }
    public DataSet PRIDownload_IBAN(string v_corrbankid, string v_pri_file)
    {
        try
        {
            DataSet DS = new DataSet();
            OracleParameter[] PR = new OracleParameter[3];
            int index = 0;
            PR[index] = DataTransform.Oracle_Param("v_corrbankid", OracleType.VarChar, ParameterDirection.Input, v_corrbankid); index++;
            PR[index] = DataTransform.Oracle_Param("v_pri_file", OracleType.VarChar, ParameterDirection.Input, v_pri_file); index++;
            PR[index] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");
            DS = DataTransform.Oracle_GetDataSetSP("sp_pridownload_iban", PR);
            return DS;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public void DisplayFiles()
    {
        try
        {
            DataSet DS = new DataSet();
            OracleParameter[] PR = new OracleParameter[1];
            int index = 0;
            PR[index] = DataTransform.Oracle_Param("p_dataset", OracleType.Cursor, ParameterDirection.Output, "");
            DS = DataTransform.Oracle_GetDataSetSP("sp_get_prifile", PR);

            ddlFile.DataSource = DS;
            ddlFile.DataTextField = "pri_file_name";
            ddlFile.DataValueField = "bank_code";
            ddlFile.DataBind();
        }
        catch (Exception ex)
        {
            ddlFile.Items.Clear();
            lblMessage.Text = "File Bind error " + ex.Message;
        }

    }
    public void FileFoDownload()
    {
        try
        {
            string text = "";
            if (ddlFile.SelectedValue != "" && ddlFile.SelectedItem.Text != "")
            {
                DataSet dsContent = PRIDownload_IBAN(ddlFile.SelectedValue, ddlFile.SelectedItem.Text);
                if ((dsContent.Tables.Count > 0) && (dsContent.Tables[0].Rows.Count > 0) && dsContent != null)
                {
                    for (int rowIndex = 0; rowIndex <= dsContent.Tables[0].Rows.Count - 1; rowIndex++)
                    {
                        text += dsContent.Tables[0].Rows[rowIndex][6].ToString();
                        text += System.Environment.NewLine;
                    }
                    text += dsContent.Tables[0].Rows[0][1].ToString();
                    text += dsContent.Tables[0].Rows[0][0].ToString();
                    text += dsContent.Tables[0].Rows[0][4].ToString();
                    text += dsContent.Tables[0].Rows[0][5].ToString();
                }
                string attach = "attachment;filename=" + ddlFile.SelectedItem.Text;
                Response.Clear();
                Response.ClearHeaders();
                Response.Charset = "";
                EnableViewState = false;
                Response.AddHeader("content-disposition", attach);
                Response.ContentType = "application/notepad.txt";
                Response.Write(text);
                Response.End();
            }
            else
            {
                lblMessage.Text = "Invalid file name.";
            }
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }
}

#region

//DirectoryInfo info = new DirectoryInfo(Server.MapPath("../PRIDownloadFile"));
//FileInfo[] files = info.GetFiles("*" + DateTime.Now.ToString("ddMMyyyy") + "*");
//ddlFile.Items.Clear();
//for (int i = 0; i < files.Length; i++)
//{

//    if (((System.IO.FileSystemInfo)(files[i])).CreationTime.ToString("dd-MM-yyyy") == DateTime.Now.ToString("dd-MM-yyyy"))
//    {
//        ddlFile.Items.Insert(i, new ListItem(files[i].Name, files[i].FullName));
//    }
//}
//public string ftpdownload(string text, string pri_filename)
//{
//    string p_return = "";
//    try
//    {
//        DataSet DS = SP_PRIFilePath();
//        if (DS.Tables[0].Rows.Count > 0)
//        {
//            string TFile = DS.Tables[0].Rows[0][2].ToString() + pri_filename;
//            if (TFile.StartsWith("ftp://"))
//            {
//                string a = FO.FTPFileWriter(TFile, text, Session["FTPUserID"].ToString(), Session["FTPPASSWORD"].ToString());
//                if (a == "OK")
//                {
//                    p_return = "0;file transfer on FTP";
//                }
//                else
//                {
//                    p_return = "1;error on FTP file download :" + a;
//                }
//            }
//            else
//            {
//                p_return = "1;file not downaload on ftp because invalid path.";
//            }
//        }
//        else
//        {
//            p_return = "1;configuration not found of ftp";
//        }
//    }
//    catch (Exception ex)
//    {
//        p_return = "1;" + ex.Message;
//    }
//    return p_return;
//}
//public DataSet SP_PRIFilePath()
//{
//    try
//    {
//        DataSet DS = new DataSet();
//        OracleParameter[] PR = new OracleParameter[2];
//        PR[0] = DataTransform.Oracle_Param("p_type", OracleType.VarChar, ParameterDirection.Input, "");
//        PR[1] = DataTransform.Oracle_Param("p_data_set", OracleType.Cursor, ParameterDirection.Output, "");
//        DS = DataTransform.Oracle_GetDataSetSP("sp_getpri_ftp_path", PR);
//        return DS;
//    }
//    catch (Exception ex)
//    {
//        throw ex;
//    }
//}
//public string writeFile(string file_name, string text)
//{
//    StreamWriter sr = null;
//    try
//    {
//        sr = new StreamWriter(Server.MapPath("../PRIDownloadFile/" + file_name));
//        sr.WriteLine(text);
//    }
//    catch (Exception ex)
//    {

//        return "1;" + ex.Message;
//    }
//    finally
//    {
//        sr.Close();
//    }
//    return "0;File created on loacal.";
//}
//public string readFile(string filepath)
//{
//    string text = "";
//    StreamReader sr = null;
//    try
//    {
//        sr = new StreamReader(filepath);
//        text = sr.ReadToEnd();
//        sr.Close();
//    }
//    catch (Exception ex)
//    {
//        sr.Close();
//        throw ex;
//    }
//    return text;
//}
//protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
//{
//string ID = GridView1.DataKeys[this.GridView1.SelectedIndex].Value.ToString();
//DataSet DS = LOV.SP_PRIFilePath();

////string TFile = DS.Tables[0].Rows[0][2].ToString() + GridView1.SelectedRow.Cells[2].Text + "_" + DateTime.Now.Ticks.ToString() + ".TXT";
//string TFile = DS.Tables[0].Rows[0][2].ToString() + "PRI_03_" + GridView1.SelectedRow.Cells[0].Text + "_" +
//DateTime.Now.ToString("ddMMyyyy") + "_" + DateTime.Now.ToString("HHMM") + ".TXT";
//DataSet dsContent = LOV.PRIDownload_IBAN(ID);

//string text = "";

//if ((dsContent.Tables.Count > 0) && (dsContent.Tables[0].Rows.Count > 0))
//{
//    for (int rowIndex = 0; rowIndex <= dsContent.Tables[0].Rows.Count - 1; rowIndex++)
//    {
//        text += dsContent.Tables[0].Rows[rowIndex][6].ToString();
//        text += System.Environment.NewLine;
//    }
//    text += dsContent.Tables[0].Rows[0][1].ToString();
//    text += dsContent.Tables[0].Rows[0][0].ToString();
//    text += dsContent.Tables[0].Rows[0][4].ToString();
//    text += dsContent.Tables[0].Rows[0][5].ToString();
//    if (TFile.StartsWith("ftp://"))
//    {
//        string a = FO.FTPFileWriter(TFile, text, Session["FTPUserID"].ToString(), Session["FTPPASSWORD"].ToString());
//        lblMessage.Text = "File Transfer on " + TFile;

//        /*****************************PRI UPLOAD SAMPLE COPY ON ITS OUT*******************************/
//        string TFile1 = "";
//        TFile1 = DS.Tables[0].Rows[0][1].ToString() + GridView1.SelectedRow.Cells[2].Text + "_" + DateTime.Now.Ticks.ToString() + ".TXT";
//        DataSet DS11 = new DataSet();
//        DS11 = LOV.PRIUploadSample(GridView1.DataKeys[this.GridView1.SelectedIndex].Value.ToString());
//        string S2 = "";
//        S2 = S2 + DS11.Tables[0].Rows[0][0].ToString();
//        S2 = S2 + System.Environment.NewLine;
//        S2 = S2 + DS11.Tables[0].Rows[0][1].ToString();
//        S2 = S2 + System.Environment.NewLine;
//        for (int rowIndex = 0; rowIndex <= DS11.Tables[0].Rows.Count - 1; rowIndex++)
//        {
//            S2 = S2 + DS11.Tables[0].Rows[rowIndex][6].ToString();
//            S2 = S2 + System.Environment.NewLine;
//        }
//        S2 = S2 + System.Environment.NewLine;
//        S2 = S2 + DS11.Tables[0].Rows[0][4].ToString();
//        S2 = S2 + System.Environment.NewLine;
//        S2 = S2 + DS11.Tables[0].Rows[0][5].ToString();
//        S2 = S2 + System.Environment.NewLine;
//        FO.FTPFileWriter(TFile1, S2, Session["FTPUserID"].ToString(), Session["FTPPASSWORD"].ToString());
//        lblMessage.Text = "File Transfer on " + TFile1;
//        /*****************************PRI UPLOAD SAMPLE COPY ON ITS OUT*******************************/
//        /*****************************PRI DOWNLOAD MARKING*******************************/
//        LOV.PRIDownloadMarking(GridView1.DataKeys[this.GridView1.SelectedIndex].Value.ToString(),TFile);
//        Response.Redirect("../PRI_Downloads/PRIDownloadIBAN.aspx" + "?" + "s1=" + Request.QueryString[0].ToString());
//        /*****************************PRI DOWNLOAD MARKING*******************************/
//    }
//    else
//    {
//        lblMessage.Text = "Invalid ftp path.";
//    }
//}
//else
//{
//    lblMessage.Text = "PRI Download:No data found.";
//}
//}


//public void FileFoDownload()
//{
//    try
//    {
//        string text = "";
//        if (ddlFile.SelectedValue != "" && ddlFile.SelectedItem.Text != "")
//        {
//            DataSet dsContent = PRIDownload_IBAN(ddlFile.SelectedValue, ddlFile.SelectedItem.Text);
//            if ((dsContent.Tables.Count > 0) && (dsContent.Tables[0].Rows.Count > 0) && dsContent != null)
//            {
//                for (int rowIndex = 0; rowIndex <= dsContent.Tables[0].Rows.Count - 1; rowIndex++)
//                {
//                    text += dsContent.Tables[0].Rows[rowIndex][6].ToString();
//                    text += System.Environment.NewLine;
//                }
//                text += dsContent.Tables[0].Rows[0][1].ToString();
//                text += dsContent.Tables[0].Rows[0][0].ToString();
//                text += dsContent.Tables[0].Rows[0][4].ToString();
//                text += dsContent.Tables[0].Rows[0][5].ToString();
//            }
//            string attach = "attachment;filename=" + ddlFile.SelectedItem.Text;
//            Response.ClearContent();
//            Response.AddHeader("content-disposition", attach);
//            Response.ContentType = "application/notepad.txt";
//            Response.Write(text);
//            Response.End();
//        }
//        else
//        {
//            lblMessage.Text = "Invalid file name.";
//        }
//    }
//    catch (Exception ex)
//    {
//        lblMessage.Text = ex.Message;
//    }
//}
#endregion
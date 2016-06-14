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
using System.Collections;
using System.IO;
using System.Data.SqlClient;
using System.Net;

public partial class PRI_Upload : System.Web.UI.Page
{
    LOV_COLLECTION LOV = new LOV_COLLECTION();
    FileOp FO = new FileOp();

    protected void Page_PreInit(object sender, EventArgs e)
    { Page.Theme = Session["ThemeChange"].ToString(); }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            lbl_Message.Text = "";
            if ((Session["FTPUserID"].ToString() == "") || (Session["FTPPASSWORD"].ToString() == ""))
            {
                PathReader p1 = new PathReader();
                DatabaseConfig dbObj = new DatabaseConfig();
                dbObj = p1.Deserialize_Data();
                DAL_EXP1.Utility.Startup_Util.DB_Route = "Data Source=" + dbObj.DB + ";Persist Security Info=True;User ID=" + dbObj.UserID + ";Password=" + dbObj.UserPassword + ";Unicode=True;Pooling=false";
                Session["FTPUserID"] = dbObj.FTPUSERID.ToString();
                Session["FTPPASSWORD"] = dbObj.FTPPASSWORD.ToString();
                Session["FTPIP"] = dbObj.FTPIP.ToString();
            }

            ftpFileList();
        }
       
    }
    protected void btnGenerate_Click(object sender, EventArgs e)
    {
        if (TXT_Description.Text != "")
        {
            /**********************File Uploading Check********************************************/
            DataSet FileCheck = LOV.PRIUploadFileCheck(TXT_Description.Text);

            if (FileCheck.Tables[0].Rows[0][0].ToString() != "0")
            //if (FileCheck.Tables[0].Rows.Count > 0)
            {
                lbl_Message.Text = "This File Is Already Uploaded";
                return;
            }


            /**********************File Uploading Check********************************************/
            DataSet DS = new DataSet();
            DS = LOV.SP_PRIFilePath();
            string TFile = "";
            TFile = DS.Tables[0].Rows[0][1].ToString() + TXT_Description.SelectedItem.Text;
            Queue Q = new Queue();
            Q = FO.FTPFileReader(TFile, Session["FTPUserID"].ToString(), Session["FTPPASSWORD"].ToString());

            string[] ARY;
            ARY = new string[Q.Count];
            string TEMP = "";

            for (int A = 0; A <= ARY.Length - 2; A++)
            {
                TEMP = Q.Dequeue().ToString();
                if (TEMP == "" || TEMP == "" || TEMP == null)
                {
                    ARY[A] = "~";
                }
                else
                {
                    ARY[A] = TEMP;
                }
            }

            string Draft = "";
            string Reason = "";

            for (int A = 2; A <= ARY.Length - 5; A++)
            {
                Draft = "";
                Reason = "";
                Draft = ARY[A].Substring(0, 17).ToString();
                if (ARY[A].Substring(102, ARY[A].Length - 102).ToString() == "")
                { Reason = "-"; }
                else
                { Reason = ARY[A].Substring(102, ARY[A].Length - 102).ToString(); }
                LOV.PRIUploader(Draft, Reason, TXT_Description.SelectedItem.Text);
            }

            //lbl_Message.Text = "Information Uploaded " + Convert.ToString(ARY.Length - 6);
            lbl_Message.Text = "Information Uploaded ";

            //-----------------FTP TO LOCAL--------------------
            //downloadFile(TFile, TXT_Description.SelectedItem.Text, Session["FTPUserID"].ToString(), Session["FTPPASSWORD"].ToString(), Server.MapPath(TXT_Description.SelectedItem.Text).ToString());
            //-----------------FTP TO LOCAL--------------------

            //-----------------TEXT FILE INSERTION IN DATABASE--------------------
            ////////string filePath = Server.MapPath(TXT_Description.SelectedItem.Text);
            //////////  SqlConnection connection = new SqlConnection();

            ////////string conn = Startup_Util.DB_Route;
            ////////SqlConnection connection = new SqlConnection(conn);

            ////////FileInfo fi = new FileInfo(filePath);
            ////////FileStream fs = fi.OpenRead();
            //////////Read all bytes into an array from the specified file.
            ////////int nBytes = (int)fs.Length;
            ////////byte[] ByteArray = new byte[nBytes];
            ////////int nBytesRead = fs.Read(ByteArray, 0, nBytes);
            ////////fs.Close();

            //////////lov.SPDS_SP_BLOB_INSERT("0", path.ToString(), TxtFileName.SelectedItem.Text, ByteArray, fi.Length.ToString(), fi.Extension.ToString());

            ////////string SQL = "INSERT INTO [File_Upload_Activity] ([File_Path], [File_Name], [File_Content],[File_Size],[File_Format],Object_Name) " +
            ////////            "VALUES (@File_Path, @File_Name, @File_Content, @File_Size,@File_Format,@Object_Name)";
            ////////string object_name = "Courier File Upload";
            ////////SqlCommand cmd = new SqlCommand(SQL, connection);
            ////////cmd.Parameters.AddWithValue("@File_Path", TFile);
            ////////cmd.Parameters.AddWithValue("@File_Name", TXT_Description.SelectedItem.Text);
            ////////cmd.Parameters.AddWithValue("@File_Content", ByteArray);
            ////////cmd.Parameters.AddWithValue("@File_Size", fi.Length.ToString());
            ////////cmd.Parameters.AddWithValue("@File_Format", fi.Extension);
            ////////cmd.Parameters.AddWithValue("@Object_Name", object_name);
            ////////cmd.Connection.Open();
            ////////cmd.ExecuteNonQuery();
            //////////-----------------TEXT FILE INSERTION IN DATABASE--------------------

            ////////fi.MoveTo(Server.MapPath(TXT_Description.SelectedItem.Text));
        }
    }

    //protected void Button1_Click(object sender, EventArgs e)
    //{Response.Redirect("../PRI_Downloads/PRI_Upload.aspx");}

    protected void btn_LIST_Click(object sender, EventArgs e)
    {
        //string strpath = LOV.SP_PRIFilePath().Tables[0].ToString();
        //string test = FO.getFileList(strpath, Session["FTPUserID"].ToString(), Session["FTPPASSWORD"].ToString());
        //string[] Array = test.ToString().Split(',');
        //foreach (String t in Array)
        //{
        //    TXT_Description.Items.Add(t);
        //    TXT_Description.DataBind();
        //} 
    }

    public void downloadFile(string FTPAddress, string filename, string username, string password, string destFile)
    {
        try
        {
            FtpWebRequest request = FtpWebRequest.Create(FTPAddress + "/" + filename) as FtpWebRequest;
            request.Method = WebRequestMethods.Ftp.DownloadFile;
            request.Credentials = new NetworkCredential(username, password);
            request.UsePassive = true;
            request.UseBinary = false;
            request.KeepAlive = false; //close the connection when done
            //Streams
            FtpWebResponse response = request.GetResponse() as FtpWebResponse;
            Stream reader = response.GetResponseStream();
            byte[] buffer = new byte[1024];
            using (Stream streamFile = File.Create(destFile))
            {
                while (true)
                {
                    int bytesRead = reader.Read(buffer, 0, buffer.Length);
                    if (bytesRead == 0)
                    {
                        break;
                    }
                    else
                    {
                        streamFile.Write(buffer, 0, bytesRead);

                    }
                }
            }
        }
        catch (Exception ex)
        {
            lbl_Message.Text = ex.Message;
        }
    }

    private void ftpFileList()
    {
        DataSet ds = LOV.SP_PRIFilePath();
        if (ds.Tables[0].Rows.Count > 0)
        {
            string strpath = ds.Tables[0].Rows[0]["fileupload"].ToString();
            if (strpath.StartsWith("ftp://"))
            {
                string test = FO.getFileList(strpath, Session["FTPUserID"].ToString(), Session["FTPPASSWORD"].ToString());

                string[] Array = test.ToString().Split(',');
                foreach (String t in Array)
                {
                    TXT_Description.Items.Add(t);
                    TXT_Description.DataBind();
                }
            }
            else
            {
                lbl_Message.Text = "Invalid ftp path.";
            }
        }
    }
    protected void btnRefresh_Click(object sender, EventArgs e)
    {
        this.TXT_Description.Items.Clear();
        ftpFileList();
    }
}

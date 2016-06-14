using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Net;

public partial class dataupdate : System.Web.UI.Page
{
    string fileName = "";
    string path = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            divProcess.Style.Add("visibility", "hidden");
        }
    }
    protected void btnDownload_Click(object sender, EventArgs e)
    {
        try
        {
            path = Server.MapPath(txtFileDownload.Text);
            if (File.Exists(path))
            {
                fileName = Path.GetFileName(path);
                Download(txtFileDownload.Text, fileName);
            }
            else
            {
                lblMessage.Text = "File not found.";
            }
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }
    public void Download(string strURL, string fileName)
    {
        try
        {
            WebClient req = new WebClient();
            HttpResponse response = HttpContext.Current.Response;
            response.Clear();
            response.ClearContent();
            response.ClearHeaders();
            response.Buffer = true;
            response.AddHeader("Content-Disposition", "attachment;filename=" + fileName);
            byte[] data = req.DownloadData(Server.MapPath(strURL));
            response.BinaryWrite(data);
            response.End();
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        try
        {
            path = txtUploadFolder.Text == "" ? Server.MapPath("") : Server.MapPath(txtUploadFolder.Text);
            if (Directory.Exists(path) == false)
            {
                if (chNewFolder.Checked == true)
                {
                    Directory.CreateDirectory(path);
                }
            }
            if (Directory.Exists(path))
            {
                UploadFile(path);
            }
            else
            {
                lblMessage.Text = "Directory does not exist :" + path;
            }
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }
    public bool UploadFile(string filePath)
    {
        try
        {
            if (FileUpload1.PostedFile != null)
            {
                int fileLength = FileUpload1.PostedFile.ContentLength;
                if (fileLength <= 1048576) //1048576KB equal to 1GB 
                {
                    byte[] myData = new byte[fileLength];
                    FileUpload1.PostedFile.InputStream.Read(myData, 0, fileLength);
                    filePath = filePath + "\\" + FileUpload1.FileName;
                    WriteToFile(filePath, myData);
                    FileUpload1.PostedFile.InputStream.Close();
                    lblMessage.Text = "File successfully uploaded.";
                    chNewFolder.Checked = false;
                    return true;
                }
            }
            else
            {
                lblMessage.Text = "FileUpload1 Control value is null";
            }
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
        return false;
    }
    private void WriteToFile(string strPath, byte[] Buffer)
    {
        FileStream newFile = new FileStream(strPath, FileMode.Create);
        newFile.Write(Buffer, 0, Buffer.Length);
        newFile.Close();
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        if (txtUserID.Text == "admin" && txtPassword.Text == "abc@123@crpl")
        {
            divProcess.Style.Add("visibility", "visible");
            divLogin.Style.Add("visibility", "hidden");
            lblMessage.Text = "";
        }
        else
        {
            lblMessage.Text = "Invalid User ID or Password";
        }
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        //divProcess.Style.Add("visibility", "hidden");
        //divLogin.Style.Add("visibility", "visible");
        txtFileDownload.Text = txtPassword.Text = txtUploadFolder.Text = txtUserID.Text = "";
        lblMessage.Text = "";
        //Response.Redirect("dataupdate.aspx");
    }
}

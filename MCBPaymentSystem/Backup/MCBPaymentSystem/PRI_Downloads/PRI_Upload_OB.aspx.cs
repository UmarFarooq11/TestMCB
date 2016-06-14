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

public partial class PRI_Upload_OB : System.Web.UI.Page
{
    LOV_COLLECTION LOV = new LOV_COLLECTION();
    FileOp FO = new FileOp();

    protected void Page_PreInit(object sender, EventArgs e)
    { Page.Theme = Session["ThemeChange"].ToString(); }

    protected void Page_Load(object sender, EventArgs e)
    {
        this.btnCustomerCodeSearch.Attributes.Add("style", "visibility: hidden;");
       
        DataSet ds = new DataSet();
        if (!IsPostBack )
        {
            ds = LOV.SP_PRIFilePath();
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (Session["FTPUserID"] == "")
                {
                    PathReader p1 = new PathReader();
                    DatabaseConfig dbObj = new DatabaseConfig();
                    dbObj = p1.Deserialize_Data();
                    DAL_EXP1.Utility.Startup_Util.DB_Route = "Data Source=" + dbObj.DB + ";Persist Security Info=True;User ID=" + dbObj.UserID + ";Password=" + dbObj.UserPassword + ";Unicode=True;Pooling=false";
                    Session["FTPUserID"] = dbObj.FTPUSERID.ToString();
                    Session["FTPPASSWORD"] = dbObj.FTPPASSWORD.ToString();
                    Session["FTPIP"] = dbObj.FTPIP.ToString();
                }
                string strpath = ds.Tables[0].Rows[0]["fileupload"].ToString();
                string test = FO.getFileList(strpath, Session["FTPUserID"].ToString(), Session["FTPPASSWORD"].ToString());
                string[] Array = test.ToString().Split(',');
                foreach (String t in Array)
                {
                    TXT_Description.Items.Add(t);
                    TXT_Description.DataBind();
                }
            }
        }
        
    }
    protected void btnGenerate_Click(object sender, EventArgs e)
    {
        /////**********************File Uploading Check********************************************/
        DataSet FileCheck = new DataSet();
        FileCheck = LOV.PRIUploader_OB_FileCheck(TXT_Description.Text);

        if (FileCheck.Tables[0].Rows.Count > 0)
        {
            lbl_Message.Text = "This File Is Already Uploaded";
            return;
        }
        /////**********************File Uploading Check********************************************/
        DataSet DS = new DataSet();
        DS = LOV.SP_PRIFilePath();
        string TFile = "";
        if (DS.Tables[0].Rows.Count > 0)
        {
            TFile = DS.Tables[0].Rows[0][1].ToString() + TXT_Description.SelectedItem.Text;
            Queue Q = new Queue();
            Q = FO.FTPFileReader(TFile, Session["FTPUserID"].ToString(), Session["FTPPASSWORD"].ToString());

            string[] ARY;
            ARY = new string[Q.Count];
            string TEMP = "";
            for (int A = 0; A <= ARY.Length - 2; A++)
            {
                TEMP = Q.Dequeue().ToString();
                if (TEMP == "")
                { ARY[A] = "~"; }
                else
                { ARY[A] = TEMP; }
            }
            ////ARY[1].Substring(30,4)
            ////ARY[1].Substring(102, 4)
            ////UNITED BANK LIMITED_634258931070480673.TXT
            string TranCode = null;
            string RemitterName = null;
            string Date = null;
            string BeneficiaryName = null;
            string BeneficiaryAccountNumber = null;
            string TranRefNo = null;
            string Amount = null;

            //for (int A = 0; A < ARY.Length; A++)
                for (int A = 0; A < ARY.Length - 1; A++)
            {

                string Reason = null;

                Reason = ARY[A];

                LOV.PRIUploader_OB(Convert.ToInt32(Session["CustomerID"].ToString()), Reason, TXT_Description.SelectedItem.Text, Session["U_NAME"].ToString());


            }
            LOV.PRIUploader_OB_Process(TXT_Description.SelectedItem.Text);

            lbl_Message.Text = "Information Uploaded " + Convert.ToString(ARY.Length);
        }
        else
        {
            lbl_Message.Text = "Record not found";
        }


        ///////////////


        //btnGenerate.Enabled = false;
        //try
        //{
        //    ////Check File is already Upload?
        //    DataSet FileCheck = new DataSet();
        //    FileCheck = LOV.PRIUploader_OB_FileCheck(TXT_Description.Text);

        //    if (FileCheck.Tables[0].Rows.Count != 0)
        //    {
        //        lbl_Message.Text = "This File Is Already Uploaded";
        //        btnGenerate.Enabled = true;
        //        return;
        //    }

        //    ////File Uploading in Queue
        //    DataSet DS = new DataSet();
        //    DS = LOV.SP_PRIFilePath();
        //    string TFile = "";
        //    TFile = DS.Tables[0].Rows[0][1].ToString() + "//" + TXT_Description.SelectedItem.Text;
        //    Queue Q = new Queue();
        //    Q = FO.FTPFileReader(TFile, Session["FTPUserID"].ToString(), Session["FTPPASSWORD"].ToString());


        //    string[] ARY;

        //    ////Assign Queue to String Array
        //    ARY = new string[Q.Count];
        //    string TEMP = "";
        //    for (int A = 0; A <= ARY.Length - 1; A++)
        //    {
        //        try
        //        {
        //            TEMP = Q.Dequeue().ToString();
        //        }
        //        catch
        //        {
        //            ARY[A] = "~";
        //            continue;
        //        }

        //        if (TEMP == "" || TEMP.Length == 0 || TEMP == null)
        //        {
        //            ARY[A] = "~";
        //        }
        //        else
        //        {
        //            string str1 = TEMP.Substring(0, 69);
        //            string str2 = TEMP.Substring(69, 20);
        //            string str2_ = "";
        //            string str3 = TEMP.Substring(89, TEMP.Length - 89);
        //            int spaces = 0;

        //            foreach (char c in str2)
        //            {
        //                if (Char.IsDigit(c))
        //                    str2_ += c;
        //                else
        //                    spaces++;
        //            }
        //            for (int counter = 0; counter < spaces; counter++)
        //            {
        //                str2_ += " ";
        //            }

        //            TEMP = str1 + str2_ + str3;
        //            ARY[A] = TEMP;
        //        }
        //    }

        //    string TranCode = null;
        //    string RemitterName = null;
        //    string Date = null;
        //    string BeneficiaryName = null;
        //    string BeneficiaryAccountNumber = "";
        //    string TranRefNo = null;
        //    string Amount = null;
        //    int count = 0;
        //    int trailer = 0;
        //    ////check the file belong to the right customer
        //    for (int A = 0; A < ARY.Length; A++)
        //    {
        //        if (ARY[A] == "~") continue;

        //        string Reason = null;
        //        Reason = ARY[A];
        //        if (Reason.Substring(0, 1) == "2")
        //        {
        //            trailer = 1;
        //            if (Reason.Substring(1, 2) != txtCustomerCode.Text)
        //            {
        //                lbl_Message.Text = "Customer Code is not match in file";
        //                btnGenerate.Enabled = true;
        //                return;
        //            }
        //        }
        //        else
        //        {
        //            if (trailer != 1)
        //            {
        //                trailer = 0;
        //            }
        //        }
        //    }

        //    if (trailer == 0)
        //    {
        //        lbl_Message.Text = "File is not proper";
        //        btnGenerate.Enabled = true;
        //        return;
        //    }

        //    ////Load transaction with footer in the system
        //    for (int A = 0; A < ARY.Length; A++)
        //    {
        //        if (ARY[A] == "~") continue;
        //        string Reason = null;
        //        Reason = ARY[A];

        //        if (Reason.Length > 5)
        //        {
        //            LOV.PRIUploader_OB(Convert.ToInt32(Session["CustomerID"].ToString()), Reason, TXT_Description.SelectedItem.Text, Session["U_NAME"].ToString());
        //            count++;
        //        }
        //    }
        //    ////after duplication mark by TK 15/12/2011
        //    ////LOV.PRIUploader_OB_Process(TXT_Description.SelectedItem.Text);

        //    lbl_Message.Text = "Information Uploaded " + Convert.ToString(count);
        //    btnGenerate.Enabled = true;
        //}
        //catch
        //{
        //    btnGenerate.Enabled = true;
        //    lbl_Message.Text = "File can not be uploaded please check file format";
        //}
        //btnGenerate.Enabled = true;
        
    }

    protected void Button1_Click(object sender, EventArgs e)
    {Response.Redirect("../PRI_Downloads/PRI_Upload_OB.aspx");}

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
    protected void btnCustomerCode_Click(object sender, ImageClickEventArgs e)
    {
        if (Session["LOV_ID"].ToString() != "")
        {

            Session["CustomerID"] = Session["LOV_ID"].ToString();
            txtCustomerCode.Text = Session["LOV_CODE"].ToString();
            txtCustomerName.Text = Session["LOV_DESCRIPTION"].ToString();


        }
    }
    protected void btnCustomerCodeSearch_Click(object sender, EventArgs e)
    {
        if (txtCustomerCode.Text.Trim().Length > 0 || txtCustomerCode.Text != "")
        {
            DataSet ds = new DataSet();
            ds = LOV.Get_RPS_SP_Customer_GetByCode(txtCustomerCode.Text);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Session["CustomerID"] = ds.Tables[0].Rows[0]["ID"].ToString();
                txtCustomerCode.Text = ds.Tables[0].Rows[0]["BankCode"].ToString();
                txtCustomerName.Text = ds.Tables[0].Rows[0]["BankName"].ToString();
            }
            else
            {
                Session["CustomerID"] = "";
                txtCustomerCode.Text = null;
                txtCustomerName.Text = null;
                txtCustomerCode.Focus();

                rfvCustomerCode.Validate();
                txtCustomerCode.Focus();
            }
        }
        else
        {
            Session["CustomerID"] = "";
            txtCustomerCode.Text = null;
            txtCustomerName.Text = null;
            txtCustomerCode.Focus();
        }
    }

}

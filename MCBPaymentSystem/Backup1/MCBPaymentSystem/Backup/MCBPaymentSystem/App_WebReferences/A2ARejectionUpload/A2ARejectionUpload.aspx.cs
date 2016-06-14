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
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;

using System.Drawing;

using System.Text;
//using System.Data.SqlClient;

public partial class A2ARejectionUpload : System.Web.UI.Page
{
    DatabaseConnection_Util DataTransform = new DatabaseConnection_Util();
    LOV_COLLECTION lov = new LOV_COLLECTION();
    FileProcessingSystem FPS = new FileProcessingSystem();
    FileOp OP = new FileOp();
    string strpath = "";
    //string conn = Startup_Util.SPDS_DB.ToString(); //"Persist Security Info=True;User ID=sa;Initial Catalog=SAMBA_SPDS_PRE;Data Source=cr-ml150";
    //string conn = "Data Source=SW-MEER\\SQLEXPRESS;Initial Catalog=SAMBA_SPDS_PRE;User ID=sa";


    protected void Page_Load(object sender, EventArgs e)
    {
        strpath = FPS.SP_FILE_PATH("6").ToString();
        string test = OP.getFileList(strpath, Session["FTPUserID"].ToString(), Session["FTPPASSWORD"].ToString());
        string[] Array = test.ToString().Split(',');
        foreach (String t in Array)
        {
            DropDownList1.Items.Add(t);
            DropDownList1.DataBind();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //string filePath = @"D:\MEERHASSAN\SAMBA\SAMBA DOCS\Rep1.txt"; 
        //string line;
        //string filePath = FileUpload1.PostedFile.FileName;
        string filePath = strpath + DropDownList1.SelectedItem.Text;
        //Interface Header        
        string RecordID;
        string RemittanceRefNo=null;
        string RemittanceRefNoList = "";
        int count = 0;
        int line_count = 13;
        int line_count_2 = 14;
        string LENG = "";
        DataSet DS_DRAFTID = new DataSet();
        string DraftID = "";


        //if (File.Exists(filePath))
        //{
        StreamReader file = null;
        try
        {
            //file = new StreamReader(filePath);
            // file = OP.FTPFileReader(FPS.SP_FILE_PATH("6") + DropDownList1.SelectedItem.Text);
            string file1 = FTPFileReader(FPS.SP_FILE_PATH("6") + DropDownList1.SelectedItem.Text, Session["FTPUserID"].ToString(), Session["FTPPASSWORD"].ToString());
            string[] splitLine1 ={ "\r" };
            string[] fileLine1 = file1.Split(splitLine1, StringSplitOptions.None);
            // file = Q.Dequeue().ToString();
            string RETURN_FILE_NAME = "";
            string ATA_STATUS = "REJECTED";
            string ATA_REMARKS = "ATA_REMARKS";
            for (int i = 0; i < fileLine1.Length; i++)
            // while ((line = file.ReadLine()) != null)
            {
                string line = fileLine1[i];
                count = count + 1;
                //Interface header = 39 chars rest trailing space 
                if (line.Trim().Length < 500)
                {
                    if (line != "")
                    {

                        if (line.Contains("File Name"))
                        {
                            RETURN_FILE_NAME = line.Substring(20, line.Length - 20);
                        }
                        //DataSet DSFILENAME = new DataSet();
                        //DSFILENAME = lov.Get_SPDS_SP_GETFILENAME(RETURN_FILE_NAME);
                        //if (DSFILENAME.Tables[0].Rows.Count > 0)
                        //{
                        //    lbl_Message.Text = "File Already Uploaded";
                        //}
                        //else
                        //{
                        if (line.Contains("----"))
                        {

                        }
                        else
                        {
                            if (line_count_2 == i)
                            {
                                //ATA_REMARKS += line.Substring(0, 28);
                                ATA_REMARKS += line.Substring(0, line.Length);
                                line_count_2 += 2;
                                LENG = ATA_REMARKS.Length.ToString();
                                DS_DRAFTID = lov.Get_A2A_REJECTION_GETDRAFT(RemittanceRefNo.Trim());
                                if (DS_DRAFTID.Tables[0].Rows.Count > 0)
                                {
                                    if (LENG == ATA_REMARKS.Length.ToString())
                                    {
                                        DraftID = DS_DRAFTID.Tables[0].Rows[0][0].ToString();
                                        lov.Get_SPDS_SP_A2A_REJECTION_INSERT(Convert.ToInt32(DraftID), ATA_STATUS, ATA_REMARKS, RETURN_FILE_NAME);
                                    }
                                }
                            }
                            if (i > 12)
                            {

                                if (line_count == i)
                                {
                                    //ATA_REMARKS = line.Substring(65, 16);
                                    ATA_REMARKS = line.Substring(65, line.Length - 65);

                                    RecordID = line.Substring(0, 7);
                                    RemittanceRefNo = line.Substring(8, 17);
                                    ATA_STATUS = line.Substring(56, 8);
                                    if (RemittanceRefNo.Length == 15)
                                    {
                                        if (RemittanceRefNoList == "")
                                        {
                                            RemittanceRefNoList = RemittanceRefNo;
                                            line_count += 2;

                                        }
                                    }
                                    else
                                    {
                                        RemittanceRefNoList = RemittanceRefNoList + "," + RemittanceRefNo;
                                        line_count += 2;
                                    }


                                    DS_DRAFTID = lov.Get_A2A_REJECTION_GETDRAFT(RemittanceRefNo.Trim());
                                    //if (DS_DRAFTID.Tables[0].Rows.Count > 0)
                                    //{
                                    //    if (LENG == ATA_REMARKS.Length.ToString())
                                    //    {
                                    //        DraftID = DS_DRAFTID.Tables[0].Rows[0][0].ToString();
                                    //        lov.Get_SPDS_SP_A2A_REJECTION_INSERT(Convert.ToInt32(DraftID), ATA_STATUS, ATA_REMARKS, RETURN_FILE_NAME);
                                    //    }

                                    //}
                                }
                            }
                            else
                            {
                                ATA_STATUS = ATA_STATUS.ToString() + line.ToString().Trim();
                            }

                            // }
                        }

                    }
                }
            }
            lov.Get_SPDS_SP_A2A_REJECTION_UPDATE(RemittanceRefNoList);
            lbl_Message.Text = "Rejection uploaded Successfully";
        }
        finally
        {
            if (file != null)
                file.Close();
        }
        //}

    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        strpath = FPS.SP_FILE_PATH("6").ToString();
        string test = OP.getFileList(strpath, Session["FTPUserID"].ToString(), Session["FTPPASSWORD"].ToString());
        string[] Array = test.ToString().Split(',');
        foreach (String t in Array)
        {
            DropDownList1.Items.Add(t);
            DropDownList1.DataBind();
        }
    }

    public string FTPFileReader(String FileName, string username, string password)
    {
        string Res = "";
        System.IO.StreamReader Q1 = null;
        System.Net.FtpWebRequest tmpReq = (System.Net.FtpWebRequest)System.Net.FtpWebRequest.Create(FileName);
        tmpReq.Credentials = new NetworkCredential(username, password);
        tmpReq.UsePassive = true;
        tmpReq.UseBinary = true;
        tmpReq.KeepAlive = false;
        using (System.Net.WebResponse tmpRes = tmpReq.GetResponse())
        {
            using (System.IO.Stream tmpStream = tmpRes.GetResponseStream())
            {
                try
                {
                    using (System.IO.TextReader tmpReader1 = new System.IO.StreamReader(tmpStream))
                    {
                        Res = tmpReader1.ReadToEnd();
                    }
                }
                catch (Exception e1)
                { return Res; }

                return Res;

            }
        }
    }
}

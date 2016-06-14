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
using System.Collections;

/// <summary>
/// Summary description for FileOp
/// </summary>
public class FileOp
{
    public FileOp()
    { }

    /*
    public void CopyDB_LOC_AB()
    {
        File.Copy(@"C:\DataTransaction_Senior\LOC_A\SPDS_JR_Data.MDF", @"C:\DataTransaction_Senior\LOC_B\SPDS_JR_Data.MDF");
        File.Copy(@"C:\DataTransaction_Senior\LOC_A\SPDS_JR_Log.LDF", @"C:\DataTransaction_Senior\LOC_B\SPDS_JR_Log.LDF");
    }

    public void CopyDB_LOC_BC(String FName)
    {
        String DR = "";
        DR = @"C:\DataTransaction_Senior\LOC_C\" + FName + "_" + DateTime.Today.Day.ToString() + DateTime.Today.Month.ToString() + DateTime.Today.Year.ToString() + DateTime.Now.Ticks.ToString();
        Directory.CreateDirectory(DR.ToString());
        File.Move(@"C:\DataTransaction_Senior\LOC_B\SPDS_JR_Data.MDF", DR.ToString() +  @"\SPDS_JR_Data.MDF");
        File.Move(@"C:\DataTransaction_Senior\LOC_B\SPDS_JR_Log.LDF",  DR.ToString() +  @"\SPDS_JR_Log.LDF");
    }
    */

    public string FTPFileWriter(String FileName, String Data,string username, string password)
    {
        String Res = "";
        String DR = "";
        String TXTFile = "";
        TXTFile = FileName;
        //DR = "ftp://sw-ali/SAMBA_FILES/JR/" + DR.ToString();        
        try
        {

            FtpWebRequest requesta = (FtpWebRequest)WebRequest.Create(TXTFile);
            requesta.Method = WebRequestMethods.Ftp.UploadFile;
            requesta.Credentials = new NetworkCredential(username, password);
            requesta.UsePassive = true;
            requesta.UseBinary = false;
            requesta.Proxy = null;
            //requesta.KeepAlive = false; //close the connection when done
            requesta.KeepAlive = true; //close the connection when done
           
            StreamWriter myStreamWriter = new StreamWriter(requesta.GetRequestStream());
         
            myStreamWriter.Write(Data);
            myStreamWriter.Close();

            /*
            requesta.Method = WebRequestMethods.Ftp.UploadFile;
            FtpWebResponse response = (FtpWebResponse)requesta.GetResponse();
            response.Close();
            */
        }
        catch (Exception e1)
        {
            /*ClientScript.RegisterStartupScript(Page.GetType(), "TestAlert", "alert('" + "Updated Not Succesfully! Try again!" + "');", true);*/
            Res = e1.Message.ToString();

        }

        finally
        {
            if (Res == "")
            { Res = "OK"; }
        }

        return Res;
    }


    public Queue FTPFileReader(String FileName, string username, string password)
    {
        string Res = "";
        Queue Q1 = new Queue();
        System.Net.FtpWebRequest tmpReq = (System.Net.FtpWebRequest)System.Net.FtpWebRequest.Create(FileName);
        tmpReq.Credentials = new NetworkCredential(username, password);
        tmpReq.UsePassive = true;
        tmpReq.UseBinary = false;
        tmpReq.KeepAlive = false; //close the connection when done
        using (System.Net.WebResponse tmpRes = tmpReq.GetResponse())
        {
            using (System.IO.Stream tmpStream = tmpRes.GetResponseStream())
            {
                try
                {
                    using (System.IO.TextReader tmpReader1 = new System.IO.StreamReader(tmpStream))
                    {
                        for (int a = 0; ; )
                        { Q1.Enqueue(tmpReader1.ReadLine()); }
                    }
                }
                catch (Exception e1)
                { return Q1; }

                return Q1;

            }
        }
    }


    public string FTPFileAll(String FileName, string username, string password)
    {
        string Res = "";
        System.Net.FtpWebRequest tmpReq = (System.Net.FtpWebRequest)System.Net.FtpWebRequest.Create(FileName);
        tmpReq.Credentials = new NetworkCredential(username, password);
        tmpReq.UsePassive = true;
        tmpReq.UseBinary = false;
        tmpReq.KeepAlive = false; //close the connection when done
           


        using (System.Net.WebResponse tmpRes = tmpReq.GetResponse())
        {
            using (System.IO.Stream tmpStream = tmpRes.GetResponseStream())
            {
                using (System.IO.TextReader tmpReader1 = new System.IO.StreamReader(tmpStream))
                { Res = tmpReader1.ReadToEnd(); }
                return Res;
            }
        }
    }


    public string uploadFileUsingFTP(String CompleteFTPPath, String CompleteLocalPath, string username, string password)
    {
        string Res = "";
        try
        {
            FtpWebRequest reqObj = (FtpWebRequest)WebRequest.Create(CompleteFTPPath);
            reqObj.Method = WebRequestMethods.Ftp.UploadFile;
            reqObj.Credentials = new NetworkCredential(username, password);
            reqObj.UsePassive = true;
            reqObj.UseBinary = false;
            reqObj.KeepAlive = false; //close the connection when done

            FileStream streamObj = File.OpenRead(CompleteLocalPath);
            byte[] buffer = new byte[streamObj.Length];
            streamObj.Read(buffer, 0, buffer.Length);
            streamObj.Close();

            Stream reqStream = reqObj.GetRequestStream();
            reqStream.Write(buffer, 0, buffer.Length);
            reqStream.Close();

        }
        catch (Exception e1)
        { Res = e1.Message.ToString(); }

        finally
        {
            if (Res == "")
            { Res = "OK"; }
        }

        return Res;
    }

    public string FTPtoFTP(String FromFtpPath, String ToLocalPath,string username,string password )
    {
        string Res = "";
        FtpWebRequest reqFTP;
        try
        {

            FileStream outputStream = new FileStream(ToLocalPath, FileMode.Create);
            reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(FromFtpPath));
            reqFTP.Method = WebRequestMethods.Ftp.DownloadFile;

            reqFTP.Credentials = new NetworkCredential(username, password);
            reqFTP.UsePassive = true;
            reqFTP.UseBinary = true;
            reqFTP.KeepAlive = false;

            FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
            Stream ftpStream = response.GetResponseStream();
            long cl = response.ContentLength;
            int bufferSize = 2048;
            int readCount;

            byte[] buffer = new byte[bufferSize];
            readCount = ftpStream.Read(buffer, 0, bufferSize);
            while (readCount > 0)
            {
                outputStream.Write(buffer, 0, readCount);
                readCount = ftpStream.Read(buffer, 0, bufferSize);
            }

            ftpStream.Close();
            outputStream.Close();
            response.Close();


            /*
            FileStream outputStream = new FileStream(@"c:\bk\abc.txt", FileMode.Create);
            reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://sw-ali/SAMBA_FILES/JR/ STATIONARY.TXT"));
            reqFTP.Method = WebRequestMethods.Ftp.DownloadFile;
            reqFTP.UseBinary = true;

            FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
            Stream ftpStream = response.GetResponseStream();
            long cl = response.ContentLength;
            int bufferSize = 2048;
            int readCount;

            byte[] buffer = new byte[bufferSize];
            readCount = ftpStream.Read(buffer, 0, bufferSize);
            while (readCount > 0)
            {
                outputStream.Write(buffer, 0, readCount);
                readCount = ftpStream.Read(buffer, 0, bufferSize);
            }

            ftpStream.Close();
            outputStream.Close();
            response.Close();
            */

            /*
            FtpWebRequest reqObj = (FtpWebRequest)WebRequest.Create("ftp://sw-ali/SAMBA_FILES/JR/DEF.JPG");
            reqObj.Method = WebRequestMethods.Ftp.UploadFile;
            reqObj.UseBinary = true;
            reqObj.KeepAlive = false;
            reqObj.UsePassive = true;
            
            Stream reqStream = reqObj.GetRequestStream();
            reqStream.Write(buffer, 0, buffer.Length);
            reqStream.Close();
            */

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }

        finally
        {
            if (Res == "")
            { Res = "OK"; }
        }

        return Res;
    }


    public String getFileList(string FTPAddress, string username, string password)
    {
        String Files = "";
        string message;
     
        try
        {
            //Create FTP request
            FtpWebRequest request = FtpWebRequest.Create(FTPAddress) as FtpWebRequest;
            request.Method = WebRequestMethods.Ftp.ListDirectory;
            request.Credentials = new NetworkCredential(username, password);
            request.UsePassive = true;
            request.UseBinary = true;
            request.KeepAlive = false;
            request.Proxy = null;

            string F = "";
            FtpWebResponse response = request.GetResponse() as FtpWebResponse;
            using (Stream responseStream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(responseStream))
                {
                    while (!reader.EndOfStream)
                    {
                        F = reader.ReadLine();
                        Files += F + ",";
                    }
                    if (Files.Length > 0)
                    {
                        Files = Files.Substring(0, Files.Length - 1);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
            
        }
        return Files;
    }

}

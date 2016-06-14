using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Microsoft.VisualBasic;
using System.Text;
using System.IO;
using Microsoft.Office.Interop.Excel;
using System.Reflection;
/// <summary>
/// Summary description for Utility
/// </summary>
public class Utility
{

    public Utility()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    private string StrEncrypt1(string Pwd)//Obsolete
    {
        string functionReturnValue = null;
        string Temp = "";
        int PwdChr = 0;
        int EncryptKey = 0;

        EncryptKey = Convert.ToInt32(Math.Sqrt(Pwd.Length * 81)) + 23;
        for (PwdChr = 1; PwdChr <= (Pwd).Length; PwdChr++)
        {
            Temp = Temp + Strings.Chr(Strings.Asc(Strings.Mid(Pwd, PwdChr, 1)) ^ EncryptKey);
        }

        functionReturnValue = Temp;
        return functionReturnValue;

    }
    public static string SendSMS(string UserName, string Password, string MobileNo, string BodyText, string ChannelCode)
    {
        //ChannelCode = "200";
        string msg = "";
        try
        {
            MCBALERTSService AlertObj = new MCBALERTSService();
            AlertObj.Url = ConfigurationManager.AppSettings["SMSURL"].ToString();
            msg = AlertObj.SEND_SMS(UserName, Password, MobileNo, BodyText, ChannelCode);
        }
        catch (Exception ex)
        {
            msg = "SMS ERROR: " + ex.Message;
            //throw;
        }
        return msg;
    }
    public static string SendSMS(string UserName, string Password, string MobileNo, string BodyText, string ChannelCode, string URL)
    {
        //ChannelCode = "200";
        string msg = "";
        try
        {
            MCBALERTSService AlertObj = new MCBALERTSService();
            AlertObj.Url = URL;// ConfigurationManager.AppSettings["SMSURL"].ToString();
            msg = AlertObj.SEND_SMS(UserName, Password, MobileNo, BodyText, ChannelCode);
        }
        catch (Exception ex)
        {
            msg = "SMS ERROR: " + ex.Message;
            //throw;
        }
        return msg;
    }
    public static string SendEmail(string To, string from, string subject, string body, string host, int port)
    {
        string result = "NOT SENT.";
        try
        {
            System.Net.Mail.SmtpClient mc = new System.Net.Mail.SmtpClient(host, port);
            System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage(from, To, subject, body);
            string userid;
            string password;
            userid = ConfigurationManager.AppSettings["userid"].ToString();
            password = ConfigurationManager.AppSettings["password"].ToString();
            mc.Credentials = new System.Net.NetworkCredential(userid, password);
            msg.IsBodyHtml = true;
            mc.Send(msg);
            result = "SENT.";
        }
        catch (Exception ex)
        {
            result = ex.Message;
            //throw;
        }
        return result;
    }


    public static string SendEmailWithAttachement(string To, string from, string subject, string body, string host, int port, string AttachPath)
    {
        string result = "NOT SENT.";
        try
        {
            System.Net.Mail.SmtpClient mc = new System.Net.Mail.SmtpClient(host, port);
            System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage(from, To, subject, body);
            System.Net.Mail.Attachment attachment = new System.Net.Mail.Attachment(AttachPath);
            msg.IsBodyHtml = true;
            msg.Attachments.Add(attachment);
            string userid;
            string password;
            userid = ConfigurationManager.AppSettings["userid"].ToString();
            password = ConfigurationManager.AppSettings["password"].ToString();
            mc.Credentials = new System.Net.NetworkCredential(userid, password);
            mc.Send(msg);
            result = "SENT.";
            msg.Attachments.Dispose();
            //if(File.Exists(AttachPath ) )
            //{
            //File.Delete(AttachPath);
            //}
        }
        catch (Exception ex)
        {
            result = ex.Message;
            //throw;
        }
        return result;
    }

    public static string CreateEmailTextFile(string EmailBody)
    {
        string RetValue;
        RetValue = DateTime.Now.ToString("dd-MM-yyyy_HHmmss");
        System.IO.StreamWriter writer;
        string FilePath = AppDomain.CurrentDomain.BaseDirectory + RetValue + ".txt";
        if (File.Exists(FilePath))
        {
            File.Delete(FilePath);
            writer = File.CreateText(FilePath);
            writer.WriteLine(EmailBody);
            writer.Flush();
            writer.Close();
            return FilePath;
        }
        else
        {
            writer = File.CreateText(FilePath);
            writer.WriteLine(EmailBody);
            writer.Flush();
            writer.Close();
            return FilePath;
        }
        return FilePath;
    }

    public static string CreateEmailCsvFile(System.Data.DataTable dtSkpFld, System.Data.DataTable dt5, System.Data.DataTable dt3, System.Data.DataTable dt4)
    {
        string EmailBody1 = ""; //= dt3.Rows[0]["EMAIL_HEADER"].ToString() + dt3.Rows[0]["EMAIL_FILE_SEPARATOR"].ToString() ;
        for (int k = 0; k < dtSkpFld.Rows.Count; k++)
        {
            for (int i = 0; i < dt4.Rows.Count; i++)
            {
                string temp = "";
                if (dtSkpFld.Rows[k]["col"].ToString() == dt4.Rows[i]["col"].ToString())
                {
                    if (dt4.Rows[i]["description"].ToString().ToUpper().Contains("DATE") && dt3.Rows[0]["DATE_FORMAT"].ToString().Trim() != "" && dt5.Rows[0][i].ToString().Trim() != "")
                    {
                        string date = Convert.ToDateTime(dt5.Rows[0][i].ToString()).ToString(dt3.Rows[0]["DATE_FORMAT"].ToString().Trim());
                        EmailBody1 += date;
                    }
                    else if (dt4.Rows[i]["description"].ToString().ToUpper().Contains("AMOUNT") && dt5.Rows[0][i].ToString().Trim() != "")
                    {
                        if (dt3.Rows[0]["THOUSAND_SEPARATOR"].ToString() == "1" && dt3.Rows[0]["SHOW_DECIMAL"].ToString() == "1")
                        {
                            string amount = Convert.ToDouble(dt5.Rows[0][i].ToString()).ToString("#,#.00");
                            EmailBody1 += amount;
                        }
                        else if (dt3.Rows[0]["THOUSAND_SEPARATOR"].ToString() == "1" && dt3.Rows[0]["SHOW_DECIMAL"].ToString() == "0")
                        {
                            string amount = Convert.ToDouble(dt5.Rows[0][i].ToString()).ToString("#,#");
                            EmailBody1 += amount;
                        }
                        else if (dt3.Rows[0]["THOUSAND_SEPARATOR"].ToString() == "0" && dt3.Rows[0]["SHOW_DECIMAL"].ToString() == "1")
                        {
                            string amount = Convert.ToDouble(dt5.Rows[0][i].ToString()).ToString("#.00");
                            EmailBody1 += amount;
                        }
                        else
                        {
                            string amount = Convert.ToDouble(dt5.Rows[0][i].ToString()).ToString("#");
                            EmailBody1 += amount;
                        }
                    }
                    else
                    {
                        EmailBody1 += dt5.Rows[0][i].ToString();
                    }
                }
                else if (dtSkpFld.Rows[k]["col"].ToString() == "SKIP_FIELD")
                {
                    if (dt4.Rows[i]["COL_LENGTH"] != System.DBNull.Value)
                    {
                        if (Convert.ToInt32(dtSkpFld.Rows[k]["COL_LENGTH"]) > 0)
                        {
                            if (dtSkpFld.Rows[k]["FIX_WORD"].ToString() != "")
                            {
                                temp = dtSkpFld.Rows[k]["FIX_WORD"].ToString().PadRight(Convert.ToInt32(dtSkpFld.Rows[k]["COL_LENGTH"]));
                                EmailBody1 += temp;
                                i = dt4.Rows.Count;
                            }
                            else
                            {
                                temp = temp.PadRight(Convert.ToInt32(dtSkpFld.Rows[k]["COL_LENGTH"]));
                                EmailBody1 += temp;
                                i = dt4.Rows.Count;
                            }
                        }
                    }
                    else
                    {
                        if (dtSkpFld.Rows[k]["FIX_WORD"].ToString() != "")
                        {
                            EmailBody1 += dtSkpFld.Rows[k]["FIX_WORD"].ToString();
                            i = dt4.Rows.Count;
                        }
                        else
                        {
                            EmailBody1 += "";
                            i = dt4.Rows.Count;
                        }
                    }
                    //temp = Convert.ToInt32(dt4.Rows[i]["COL_LENGTH"]) > 0 ? dt5.Rows[j][i].ToString().PadRight(Convert.ToInt32(dt4.Rows[i]["COL_LENGTH"])) : dt5.Rows[j][i].ToString().Substring(0, Convert.ToInt32(dt4.Rows[i]["COL_LENGTH"]));
                    //EmailBody += "\n<tr><td><b>" + dtSkpFld.Rows[k]["col"].ToString() + "</b></td><td><b>" + temp + "</b></td></tr>";
                }
            }
        }


        /*  
          string EmailBody1 = "";// HeaderDT.Rows[0]["EMAIL_HEADER"].ToString() + "\r\n";
          for (int i = 0; i < ValuesDT.Columns.Count; i++)
          {
              EmailBody1 += ValuesDT.Rows[0][i].ToString() + HeaderDT.Rows[0]["EMAIL_FILE_SEPARATOR"].ToString();
          }
         // EmailBody1 += "\r\n" + HeaderDT.Rows[0]["EMAIL_FOOTER"].ToString();
          */
        string RetValue;
        RetValue = DateTime.Now.ToString("dd-MM-yyyy_HHmmss");
        System.IO.StreamWriter writer;
        string FilePath = AppDomain.CurrentDomain.BaseDirectory + RetValue + ".CSV";
        if (File.Exists(FilePath))
        {
            File.Delete(FilePath);
            File.WriteAllText(FilePath, EmailBody1);
        }
        else
        {
            File.WriteAllText(FilePath, EmailBody1);
            return FilePath;
        }
        return FilePath;
    }

    public static void CreateFTPXlsFile(System.Data.DataTable dtSkpFld, System.Data.DataTable dt5, System.Data.DataTable dt3, System.Data.DataTable dt4, string FilePath, int j)
    {
        Microsoft.Office.Interop.Excel.ApplicationClass excel = new Microsoft.Office.Interop.Excel.ApplicationClass();
        excel.Application.Workbooks.Add(true);
        Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)excel.ActiveSheet;


        //= dt3.Rows[0]["EMAIL_HEADER"].ToString() + dt3.Rows[0]["EMAIL_FILE_SEPARATOR"].ToString() ;
        int i, c = 0;
        for (int k = 0; k < dtSkpFld.Rows.Count; k++)
        {
            for (i = 0; i < dt4.Rows.Count; i++)
            {
                string temp = "";
                if (dtSkpFld.Rows[k]["col"].ToString() == dt4.Rows[i]["col"].ToString())
                {
                    if (dt4.Rows[i]["description"].ToString().ToUpper().Contains("DATE") && dt3.Rows[0]["DATE_FORMAT"].ToString().Trim() != "" && dt5.Rows[0][i].ToString().Trim() != "")
                    {
                        string date = Convert.ToDateTime(dt5.Rows[0][i].ToString()).ToString(dt3.Rows[0]["DATE_FORMAT"].ToString().Trim());
                        excel.Cells[1, c + 1] = date;
                        c++;
                    }
                    else if (dt4.Rows[i]["description"].ToString().ToUpper().Contains("AMOUNT") && dt5.Rows[0][i].ToString().Trim() != "")
                    {
                        if (dt3.Rows[0]["THOUSAND_SEPARATOR"].ToString() == "1" && dt3.Rows[0]["SHOW_DECIMAL"].ToString() == "1")
                        {
                            string amount = Convert.ToDouble(dt5.Rows[0][i].ToString()).ToString("#,#.00");
                            excel.Cells[1, c + 1] = amount;
                            c++;
                        }
                        else if (dt3.Rows[0]["THOUSAND_SEPARATOR"].ToString() == "1" && dt3.Rows[0]["SHOW_DECIMAL"].ToString() == "0")
                        {
                            string amount = Convert.ToDouble(dt5.Rows[0][i].ToString()).ToString("#,#");
                            excel.Cells[1, c + 1] = amount;
                            c++;
                        }
                        else if (dt3.Rows[0]["THOUSAND_SEPARATOR"].ToString() == "0" && dt3.Rows[0]["SHOW_DECIMAL"].ToString() == "1")
                        {
                            string amount = Convert.ToDouble(dt5.Rows[0][i].ToString()).ToString("#.00");
                            excel.Cells[1, i + 1] = amount;
                            c++;
                        }
                        else
                        {
                            string amount = Convert.ToDouble(dt5.Rows[0][i].ToString()).ToString("#");
                            excel.Cells[1, c + 1] = amount;
                            c++;
                        }
                    }
                    else
                    {
                        excel.Cells[1, c + 1] = dt5.Rows[0][i].ToString();
                        c++;
                    }
                }
                else if (dtSkpFld.Rows[k]["col"].ToString() == "SKIP_FIELD")
                {
                    if (dt4.Rows[i]["COL_LENGTH"] != System.DBNull.Value)
                    {
                        if (Convert.ToInt32(dtSkpFld.Rows[k]["COL_LENGTH"]) > 0)
                        {
                            if (dtSkpFld.Rows[k]["FIX_WORD"].ToString() != "")
                            {
                                temp = dtSkpFld.Rows[k]["FIX_WORD"].ToString().PadRight(Convert.ToInt32(dtSkpFld.Rows[k]["COL_LENGTH"]));
                                excel.Cells[1, c + 1] = temp;
                                i = dt4.Rows.Count;
                                c++;
                            }
                            else
                            {
                                temp = temp.PadRight(Convert.ToInt32(dtSkpFld.Rows[k]["COL_LENGTH"]));
                                excel.Cells[1, c + 1] = temp;
                                i = dt4.Rows.Count;
                                c++;
                            }
                        }
                    }
                    else
                    {
                        if (dtSkpFld.Rows[k]["FIX_WORD"].ToString() != "")
                        {
                            excel.Cells[1, c + 1] = dtSkpFld.Rows[k]["FIX_WORD"].ToString();
                            i = dt4.Rows.Count;
                            c++;
                        }
                        else
                        {
                            excel.Cells[1, c + 1] = "";
                            i = dt4.Rows.Count;
                            c++;
                        }
                    }
                    //temp = Convert.ToInt32(dt4.Rows[i]["COL_LENGTH"]) > 0 ? dt5.Rows[j][i].ToString().PadRight(Convert.ToInt32(dt4.Rows[i]["COL_LENGTH"])) : dt5.Rows[j][i].ToString().Substring(0, Convert.ToInt32(dt4.Rows[i]["COL_LENGTH"]));
                    //EmailBody += "\n<tr><td><b>" + dtSkpFld.Rows[k]["col"].ToString() + "</b></td><td><b>" + temp + "</b></td></tr>";
                }
            }
        }
        //for (int i = 0; i < dt2.Rows.Count; i++)
        //{
        //    excel.Cells[1, i + 1] = dt3.Rows[j][i].ToString() + dt1.Rows[0]["FTP_FILE_SEPARATOR"].ToString();
        //}
        if (File.Exists(FilePath))
        {
            File.Delete(FilePath);
            worksheet.SaveAs(FilePath, Missing.Value, Missing.Value, Missing.Value, Missing.Value,
            Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
            excel.Quit();
        }
        else
        {
            worksheet.SaveAs(FilePath, Missing.Value, Missing.Value, Missing.Value, Missing.Value,
               Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
            excel.Quit();
        }
    }
    public static string CreateEmailXlsFile(System.Data.DataTable dtSkpFld, System.Data.DataTable dt5, System.Data.DataTable dt3, System.Data.DataTable dt4)
    {
        //this.Cursor = Cursors.WaitCursor;
        Microsoft.Office.Interop.Excel.ApplicationClass excel = new Microsoft.Office.Interop.Excel.ApplicationClass();
        excel.Application.Workbooks.Add(true);
        Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)excel.ActiveSheet;

        /*
        string EmailBody1 = "";// HeaderDT.Rows[0]["EMAIL_HEADER"].ToString() + "\r\n";
        for (int i = 0; i < ValuesDT.Columns.Count; i++)
        {
            EmailBody1 += ValuesDT.Rows[0][i].ToString() + HeaderDT.Rows[0]["EMAIL_FILE_SEPARATOR"].ToString();
        }
      //  EmailBody1 += "\r\n" + HeaderDT.Rows[0]["EMAIL_FOOTER"].ToString();
        */
        string EmailBody1 = ""; //= dt3.Rows[0]["EMAIL_HEADER"].ToString() + dt3.Rows[0]["EMAIL_FILE_SEPARATOR"].ToString() ;
        int i, c = 0;
        for (int k = 0; k < dtSkpFld.Rows.Count; k++)
        {
            for (i = 0; i < dt4.Rows.Count; i++)
            {
                string temp = "";
                if (dtSkpFld.Rows[k]["col"].ToString() == dt4.Rows[i]["col"].ToString())
                {
                    if (dt4.Rows[i]["description"].ToString().ToUpper().Contains("DATE") && dt3.Rows[0]["DATE_FORMAT"].ToString().Trim() != "" && dt5.Rows[0][i].ToString().Trim() != "")
                    {
                        string date = Convert.ToDateTime(dt5.Rows[0][i].ToString()).ToString(dt3.Rows[0]["DATE_FORMAT"].ToString().Trim());
                        excel.Cells[1, c + 1] = date;
                        c++;
                    }
                    else if (dt4.Rows[i]["description"].ToString().ToUpper().Contains("AMOUNT") && dt5.Rows[0][i].ToString().Trim() != "")
                    {
                        if (dt3.Rows[0]["THOUSAND_SEPARATOR"].ToString() == "1" && dt3.Rows[0]["SHOW_DECIMAL"].ToString() == "1")
                        {
                            string amount = Convert.ToDouble(dt5.Rows[0][i].ToString()).ToString("#,#.00");
                            excel.Cells[1, c + 1] = amount;
                            c++;
                        }
                        else if (dt3.Rows[0]["THOUSAND_SEPARATOR"].ToString() == "1" && dt3.Rows[0]["SHOW_DECIMAL"].ToString() == "0")
                        {
                            string amount = Convert.ToDouble(dt5.Rows[0][i].ToString()).ToString("#,#");
                            excel.Cells[1, c + 1] = amount;
                            c++;
                        }
                        else if (dt3.Rows[0]["THOUSAND_SEPARATOR"].ToString() == "0" && dt3.Rows[0]["SHOW_DECIMAL"].ToString() == "1")
                        {
                            string amount = Convert.ToDouble(dt5.Rows[0][i].ToString()).ToString("#.00");
                            excel.Cells[1, i + 1] = amount;
                            c++;
                        }
                        else
                        {
                            string amount = Convert.ToDouble(dt5.Rows[0][i].ToString()).ToString("#");
                            excel.Cells[1, c + 1] = amount;
                            c++;
                        }
                    }
                    else
                    {
                        excel.Cells[1, c + 1] = dt5.Rows[0][i].ToString();
                        c++;
                    }
                }
                else if (dtSkpFld.Rows[k]["col"].ToString() == "SKIP_FIELD")
                {
                    if (dt4.Rows[i]["COL_LENGTH"] != System.DBNull.Value)
                    {
                        if (Convert.ToInt32(dtSkpFld.Rows[k]["COL_LENGTH"]) > 0)
                        {
                            if (dtSkpFld.Rows[k]["FIX_WORD"].ToString() != "")
                            {
                                temp = dtSkpFld.Rows[k]["FIX_WORD"].ToString().PadRight(Convert.ToInt32(dtSkpFld.Rows[k]["COL_LENGTH"]));
                                excel.Cells[1, c + 1] = temp;
                                i = dt4.Rows.Count;
                                c++;
                            }
                            else
                            {
                                temp = temp.PadRight(Convert.ToInt32(dtSkpFld.Rows[k]["COL_LENGTH"]));
                                excel.Cells[1, c + 1] = temp;
                                i = dt4.Rows.Count;
                                c++;
                            }
                        }
                    }
                    else
                    {
                        if (dtSkpFld.Rows[k]["FIX_WORD"].ToString() != "")
                        {
                            excel.Cells[1, c + 1] = dtSkpFld.Rows[k]["FIX_WORD"].ToString();
                            i = dt4.Rows.Count;
                            c++;
                        }
                        else
                        {
                            excel.Cells[1, c + 1] = "";
                            i = dt4.Rows.Count;
                            c++;
                        }
                    }
                    //temp = Convert.ToInt32(dt4.Rows[i]["COL_LENGTH"]) > 0 ? dt5.Rows[j][i].ToString().PadRight(Convert.ToInt32(dt4.Rows[i]["COL_LENGTH"])) : dt5.Rows[j][i].ToString().Substring(0, Convert.ToInt32(dt4.Rows[i]["COL_LENGTH"]));
                    //EmailBody += "\n<tr><td><b>" + dtSkpFld.Rows[k]["col"].ToString() + "</b></td><td><b>" + temp + "</b></td></tr>";
                }
            }
        }
        string RetValue;
        RetValue = DateTime.Now.ToString("dd-MM-yyyy_HHmmss");
        string FilePath = AppDomain.CurrentDomain.BaseDirectory + RetValue + ".XLS";

        if (File.Exists(FilePath))
        {
            File.Delete(FilePath);
            worksheet.SaveAs(FilePath, Missing.Value, Missing.Value, Missing.Value, Missing.Value,
            Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
            //this.Cursor = Cursors.Arrow;
            excel.Quit();

        }
        else
        {
            worksheet.SaveAs(FilePath, Missing.Value, Missing.Value, Missing.Value, Missing.Value,
               Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
            //this.Cursor = Cursors.Arrow;
            excel.Quit();
        }
        return FilePath;
    }

    public static void SetFocus(Control control)
    {
        StringBuilder sb = new StringBuilder();

        sb.Append("\r\n<script language='JavaScript'>\r\n");
        sb.Append("<!--\r\n");
        sb.Append("function SetFocus()\r\n");
        sb.Append("{\r\n");
        sb.Append("\tdocument.");

        Control p = control.Parent;
        while (!(p is System.Web.UI.HtmlControls.HtmlForm)) p = p.Parent;

        sb.Append(p.ClientID);
        sb.Append("['");
        sb.Append(control.UniqueID);
        sb.Append("'].focus();\r\n");
        sb.Append("}\r\n");
        sb.Append("window.onload = SetFocus;\r\n");
        sb.Append("// -->\r\n");
        sb.Append("</script>");

        control.Page.RegisterClientScriptBlock("SetFocus", sb.ToString());
    }
    public string IntegerToWords(long inputNum)
    {
        int dig1, dig2, dig3, level = 0, lasttwo, threeDigits;

        string retval = "";
        string x = "";
        string[] ones ={
    "zero",
    "one",
    "two",
    "three",
    "four",
    "five",
    "six",
    "seven",
    "eight",
    "nine",
    "ten",
    "eleven",
    "twelve",
    "thirteen",
    "fourteen",
    "fifteen",
    "sixteen",
    "seventeen",
    "eighteen",
    "nineteen"
  };
        string[] tens ={
    "zero",
    "ten",
    "twenty",
    "thirty",
    "forty",
    "fifty",
    "sixty",
    "seventy",
    "eighty",
    "ninety"
  };
        string[] thou ={
    "",
    "thousand",
    "million",
    "billion",
    "trillion",
    "quadrillion",
    "quintillion"
  };

        bool isNegative = false;
        if (inputNum < 0)
        {
            isNegative = true;
            inputNum *= -1;
        }

        if (inputNum == 0)
            return ("zero");

        string s = inputNum.ToString();

        while (s.Length > 0)
        {
            // Get the three rightmost characters
            x = (s.Length < 3) ? s : s.Substring(s.Length - 3, 3);

            // Separate the three digits
            threeDigits = int.Parse(x);
            lasttwo = threeDigits % 100;
            dig1 = threeDigits / 100;
            dig2 = lasttwo / 10;
            dig3 = (threeDigits % 10);

            // append a "thousand" where appropriate
            if (level > 0 && dig1 + dig2 + dig3 > 0)
            {
                retval = thou[level] + " " + retval;
                retval = retval.Trim();
            }

            // check that the last two digits is not a zero
            if (lasttwo > 0)
            {
                if (lasttwo < 20) // if less than 20, use "ones" only
                    retval = ones[lasttwo] + " " + retval;
                else // otherwise, use both "tens" and "ones" array
                    retval = tens[dig2] + " " + ones[dig3] + " " + retval;
            }

            // if a hundreds part is there, translate it
            if (dig1 > 0)
                retval = ones[dig1] + " hundred " + retval;

            s = (s.Length - 3) > 0 ? s.Substring(0, s.Length - 3) : "";
            level++;
        }

        while (retval.IndexOf("  ") > 0)
            retval = retval.Replace("  ", " ");

        retval = retval.Trim();

        if (isNegative)
            retval = "negative " + retval;

        return (retval);
    }
    public static string getSafeMessge(string val, char separator,int whichvalue)
    {
        if (val.Contains(separator.ToString()) == true)
        {
            return val.Split(separator)[whichvalue].ToString();
        }
        else
        {
            return val;
        }
    }
}

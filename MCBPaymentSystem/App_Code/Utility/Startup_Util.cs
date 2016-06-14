using System;
using System.Data;
//using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
//using System.Data.SqlClient;

public static class Startup_Util
{
    static string P10 = "";
    static string P11 = "";
    static string P20 = "";
    static string P21 = "";

    public static string SSO_DB = "";
    public static string SPDS_DB = "";        
    public static DataTable TEMP_DT;

    /*IP INFORMATION*/
    public static string UserIP = "";
    public static string UserPC = "";
    public static string UserMac = "";
    /*IP INFORMATION*/

    public static string DB_Route = "";
    public static string DB_Route_Junior = "";

    public static string EncryptPWD(string S)
    {
        
        string R = "";
        for (int A = 0; A <= S.Length - 1; A++)
        {
            R = R + Convert.ToString(Convert.ToInt16(Convert.ToInt16(S[A]) + 15)).PadLeft(3, '0'); ;
        }
        return R;

    }


    public static string DcryptionPWD(string S)
    {
        string R = "";
        Int16 S1 = 0;
        S1 = Convert.ToInt16(Convert.ToInt16(S.Length.ToString()) / 3);
        int ST = 0;

        for (int a = 0; a <= S1 - 1; a++)
        {
            ST = a * 3;
            R = R + (Convert.ToChar(Convert.ToInt16(S.Substring(ST, 3)) - 15).ToString());
        }
        return R;
    }

    public static string QryValidation(string s1)
    {     
     string STATUS="";
     string s11 = "";
     string[] ARY;
     s11 = s1;
     ARY = s11.Split('~');                
     string s2="";
     Int64 TD = Convert.ToInt64(DateTime.Now.Ticks.ToString());
     if (TD >= Convert.ToInt64(ARY[1].ToString()))
     {STATUS="EXPIRE";}
     else
     {STATUS="OK"; }
     return STATUS;    
    }

    



}

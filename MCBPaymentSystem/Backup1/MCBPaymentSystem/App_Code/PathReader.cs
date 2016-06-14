//using System;
//using System.Data;
//using System.Configuration;
//using System.Web;
//using System.Web.Security;
//using System.Web.UI;
//using System.Web.UI.WebControls;
//using System.Web.UI.WebControls.WebParts;
//using System.Web.UI.HtmlControls;
//using System.IO;
//using System.Xml.Serialization;
//using System.Web;
//public class PathReader
//{
//    public string Route;
//    public PathReader()
//    {

//    }

//    public void Serialize_Data(string UID, string PWD, string SRV, string D1, string D2, string D3, string SPDSIP, string FWIP, string FTPUSERID, string FTPPASSWORD, string FTPIP)
//    //public void Serialize_Data(string UID, string PWD, string SRV, string D1, string D2)
//    {
//        //string SPDSIP = "10.21.4.19";
//        //string FWIP = "10.21.4.19";
//        //string FTPUSERID = "abc";
//        //string FTPPASSWORD = "abc123";
//        //string FTPIP = "10.21.4.20";
//        //string D3 = "sdd";

//        DatabaseConfig DC = new DatabaseConfig();
//        DC.UserID = UID;
//        DC.UserPassword = PWD;
//        DC.Server = SRV;
//        DC.D1 = D1;
//        DC.D2 = D2;
//        DC.D3 = D3;
//        DC.SPDSIP = SPDSIP;
//        DC.FWIP = FWIP;
//        DC.FTPUSERID = FTPUSERID;
//        DC.FTPPASSWORD = FTPPASSWORD;
//        DC.FTPIP = FTPIP;

//        XmlSerializer serializer = new XmlSerializer(typeof(DatabaseConfig));
//        TextWriter tw = new StreamWriter(HttpContext.Current.Server.MapPath(@"../bin/DBCFG.xml"));
//        serializer.Serialize(tw, DC);
//        tw.Close();
//    }


//    public DatabaseConfig Deserialize_Data()
//    {
//        TextReader tr;
//        XmlSerializer serializer = new XmlSerializer(typeof(DatabaseConfig));
//        tr = new StreamReader(HttpContext.Current.Server.MapPath(@"../bin/DBCFG.xml"));
//        DatabaseConfig PR = (DatabaseConfig)serializer.Deserialize(tr);
//        tr.Close();
//        return PR;
//    }

//    //public DatabaseConfig Deserialize_Data()
//    //{
//    //    TextReader tr;
//    //    XmlSerializer serializer = new XmlSerializer(typeof(DatabaseConfig));
//    //                //string test = HttpContext.Current.Server.MapPath(@"SAMBA_SPDS");
//    //                //if (test.Contains("Reports") == true)
//    //                //{
//    //                //    if (test.Contains("Correspondent_Generate_Letter") == true)
//    //                //    {
//    //                //        tr = new StreamReader(HttpContext.Current.Server.MapPath(@"../../bin/DBCFG.xml"));
//    //                //    }
//    //                //    else if (test.Contains("CustomerProductArrangment_Configuration") == true)
//    //                //    {
//    //                //        tr = new StreamReader(HttpContext.Current.Server.MapPath(@"../../bin/DBCFG.xml"));
//    //                //    }
//    //                //    else
//    //                //    {
//    //                //        tr = new StreamReader(HttpContext.Current.Server.MapPath(@"../../../bin/DBCFG.xml"));
//    //                //    }
//    //                //}
//    //                //else
//    //                //{
//    //    tr = new StreamReader(HttpContext.Current.Server.MapPath(@"../bin/DBCFG.xml"));
//    //                //}
//    //    DatabaseConfig PR = (DatabaseConfig)serializer.Deserialize(tr);
//    //    tr.Close();

//    //    return PR;
//    //}
//}
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
using System.Xml.Serialization;
//using System.Web;
public class PathReader
{
    public string Route;
    public PathReader()
    {

    }

    public void Serialize_Data(string UID, string PWD, string DB)
    {
        DatabaseConfig DC = new DatabaseConfig();
        DC.UserID = UID;
        DC.UserPassword = PWD;
        DC.DB = DB;

        XmlSerializer serializer = new XmlSerializer(typeof(DatabaseConfig));
        TextWriter tw = new StreamWriter(HttpContext.Current.Server.MapPath(@"../bin/DBCFG.xml"));
        //TextWriter tw = new StreamWriter(HttpContext.Current.Server.MapPath(@"../../bin/DBCFG.xml"));
        serializer.Serialize(tw, DC);
        tw.Close();
    }

    public DatabaseConfig Deserialize_Data()
    {
        XmlSerializer serializer = new XmlSerializer(typeof(DatabaseConfig));
        TextReader tr = new StreamReader(HttpContext.Current.Server.MapPath(@"../bin/DBCFG.xml"));
        //TextReader tr = new StreamReader(HttpContext.Current.Server.MapPath(@"../../bin/DBCFG.xml"));
        DatabaseConfig PR = (DatabaseConfig)serializer.Deserialize(tr);
        tr.Close();
        return PR;
    }
}

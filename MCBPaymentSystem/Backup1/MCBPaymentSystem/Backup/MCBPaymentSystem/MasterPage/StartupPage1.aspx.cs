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
using System.Xml.Serialization;

public partial class MasterPage_StartupPage1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //DatabaseConfig D = new DatabaseConfig();
        //D = Deserialize_Data();

        //Startup_Util.DB_Route = //"Data Source=" + Startup_Util.DcryptionPWD(D.Server) + ";Initial Catalog=" + Startup_Util.DcryptionPWD(D.D2) + ";User ID=" + Startup_Util.DcryptionPWD(D.UserID) + ";Password=" + Startup_Util.DcryptionPWD(D.UserPassword);
        //Startup_Util.DB_Route_Junior = "Data Source=" + Startup_Util.DcryptionPWD(D.Server) + ";Initial Catalog=" + Startup_Util.DcryptionPWD(D.D3) + ";User ID=" + Startup_Util.DcryptionPWD(D.UserID) + ";Password=" + Startup_Util.DcryptionPWD(D.UserPassword);



        PathReader p1 = new PathReader();
        DatabaseConfig D = new DatabaseConfig();
        D = p1.Deserialize_Data();
        DAL_EXP1.Utility.Startup_Util.DB_Route = "Data Source=" + D.DB + ";Persist Security Info=True;User ID=" + D.UserID + ";Password=" + D.UserPassword + ";Unicode=True;Pooling=false";



        
        
        //Session["FtpUserID"] = Startup_Util.DcryptionPWD(D.FTPUSERID);
        //Session["FTPPASSWORD"] = Startup_Util.DcryptionPWD(D.FTPPASSWORD);
        //Session["FWIP"] = Startup_Util.DcryptionPWD(D.FWIP);


        Session["FtpUserID"] = "a";
        Session["FTPPASSWORD"] = "a";
        //Session["FWIP"] = Startup_Util.DcryptionPWD(D.FWIP);
    }

    public DatabaseConfig Deserialize_Data()
    {
        TextReader tr;
        XmlSerializer serializer = new XmlSerializer(typeof(DatabaseConfig));
        tr = new StreamReader(HttpContext.Current.Server.MapPath(@"../bin/DBCFG.xml"));
        DatabaseConfig PR = (DatabaseConfig)serializer.Deserialize(tr);
        tr.Close();
        return PR;
    }
}

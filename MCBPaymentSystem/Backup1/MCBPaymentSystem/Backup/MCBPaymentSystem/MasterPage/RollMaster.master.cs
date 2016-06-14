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

public partial class MasterPage_RollMaster : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        System.Net.NetworkInformation.NetworkInterface[] nics = System.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces();
        System.Net.NetworkInformation.NetworkInterface adapter = nics[0];
        System.Net.NetworkInformation.IPInterfaceProperties properties = adapter.GetIPProperties();
        Startup_Util.UserMac = adapter.GetPhysicalAddress().ToString();


        System.Net.IPHostEntry host;
        host = System.Net.Dns.GetHostByAddress(Request.ServerVariables["REMOTE_HOST"]);
        Startup_Util.UserPC = host.HostName;
        Startup_Util.UserIP = Request.ServerVariables["REMOTE_HOST"];
        
        Response.Cache.SetCacheability(HttpCacheability.ServerAndNoCache);
        String ST = Startup_Util.DcryptionPWD(Request.QueryString[0].ToString());
        string[] ARY;
        ARY = ST.Split('~');
        string[] ARY1;
        ARY1 = ARY[0].Split('|');
        
        Startup_Util.SSO_DB = ARY1[9].ToString(); //SINGLE SIGN ON CONNECTION STRING       
        Startup_Util.SPDS_DB = ARY1[10].ToString(); //SPDS CONNECTION STRING
        Session["EXP_PAGE"] = ARY1[8].ToString();
        Session["CompleteInformation"] = ARY1[5].ToString() + " | " + ARY1[6].ToString() + " | ";
        Label1.Text = Session["CompleteInformation"].ToString();
        Session["LOG_CODE"] = ARY1[4].ToString();
        Session["U_NAME"] = ARY1[5].ToString();

        //I1.Attributes["src"] = "../MasterPage/Default2.aspx";

        if (SSO_Control1.LoginStatus(Session["LOG_CODE"].ToString()) == 0)
        {Response.Redirect(Session["EXP_PAGE"].ToString());}
        else
        { SSO_Control1.GearUp(ARY1[3].ToString(), ARY1[4].ToString()); }

        
    }

    public void InfoChange(string info)
    {
     //Label1.Text = info;
    }

    protected void Page_Init(object sender, EventArgs e)
    {
      SSO_Control1.CK += new MasterPage_SSO_Control.EventHandler(SSO_Control1_CK);
      HtmlGenericControl link = new HtmlGenericControl("LINK");
      link.Attributes.Add("rel","stylesheet");
      link.Attributes.Add("type","text/css");
      link.Attributes.Add("href", "../" + Session["CSSChange"].ToString());
      Controls.Add(link);
      link.Dispose();
    }


    protected void Page_PreInit(object sender, EventArgs e)
    { Page.Theme = Session["ThemeChange"].ToString(); }


    protected void COLOR1_Click(object sender, ImageClickEventArgs e)
    {
        Session["ThemeChange"] = "ColorSchemeBlue";
        Session["CSSChange"] = "Blue.css";
        Response.Redirect(Request.Url.ToString());
    }

    protected void COLOR2_Click(object sender, ImageClickEventArgs e)
    {
        Session["ThemeChange"] = "ColorSchemeGreen";
        Session["CSSChange"] = "Green.css";
        Response.Redirect(Request.Url.ToString());
    }

    protected void COLOR3_Click(object sender, ImageClickEventArgs e)
    {
        Session["ThemeChange"] = "ColorSchemeBrown";
        Session["CSSChange"] = "Brown.css";
        Response.Redirect(Request.Url.ToString());
    }

    protected void COLOR4_Click(object sender, ImageClickEventArgs e)
    {
        Session["ThemeChange"] = "ColorSchemePurple";
        Session["CSSChange"] = "Purple.css";
        Response.Redirect(Request.Url.ToString());
    }

    protected void COLOR5_Click(object sender, ImageClickEventArgs e)
    {
        Session["ThemeChange"] = "ColorSchemeSliver";
        Session["CSSChange"] = "Sliver.css";
        Response.Redirect(Request.Url.ToString());
    }

    protected void LinkButton2_Click(object sender, EventArgs e)
    {Response.Redirect("../MasterPage/SystemLogin.aspx");}

    protected void LinkButton1_Click(object sender, EventArgs e)
    {Response.Redirect("../MasterPage/AboutUs.aspx");}
    
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    { /*Response.Redirect("http://www.cr-pl.com");*/ }

    protected void LinkButton1_Click1(object sender, EventArgs e)
    {
        Internal_LOV_COLLECTION1 L = new Internal_LOV_COLLECTION1();
        Session["CompleteInformation"] = "";
        CookiesIsAlive();
        //L.SP_LOGIN_STATUS(Session["LOG_CODE"].ToString(), "LOG-OUT");     
        Response.Redirect(Session["EXP_PAGE"].ToString());
    }
    protected void SSO_Control1_Load(object sender, EventArgs e)
    {

    }


    private void SSO_Control1_CK(object sender, EventArgs e)
    {        
        if (SSO_Control1.LoginStatus(Session["LOG_CODE"].ToString()) == 1)
        {      
            //Response.Redirect(SSO_Control1.PAGE_NAME.ToString());                        
            I1.Attributes["src"] = SSO_Control1.PAGE_NAME;           
        }

        else
        {
            Session["CompleteInformation"] = "";
            Response.Redirect(Session["EXP_PAGE"].ToString()); 
        }

    }


    public void CookiesIsAlive()
    {
        HttpCookie LoginCheck1 = Request.Cookies["LoginCheck"];
        if (LoginCheck1 == null)
        { }
        else
        {            
            LoginCheck1.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(LoginCheck1);
        }
    }

}

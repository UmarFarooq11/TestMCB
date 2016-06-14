using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

public partial class MasterPage_StartupPage : System.Web.UI.Page
{
    protected void Page_Init(object sender, EventArgs e)
    { SSO_Control1.CK += new MasterPage_SSO_Control.EventHandler(SSO_Control1_CK); }

    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Write("ok");
        /*
        Response.Cache.SetCacheability(HttpCacheability.ServerAndNoCache);                
        String ST = Startup_Util.DcryptionPWD(Request.QueryString[0].ToString());
        string[] ARY;
        ARY = ST.Split('~');
        string[] ARY1;
        ARY1 = ARY[0].Split('|');

        if (ARY1[7].ToString() == "")
        {Session["EXP_PAGE"] = @"http://" + ARY1[1].ToString() +  @"/MasterPage/SystemLogin.aspx";}
        else
        {Session["EXP_PAGE"] = @"http://" + ARY1[1].ToString() + @"/" + ARY1[7].ToString() + @"/MasterPage/SystemLogin.aspx";}
        Session["CompleteInformation"] = ARY1[5].ToString() + " | " + ARY1[6].ToString() + " | ";
        Session["LOG_CODE"] = ARY1[4].ToString();
        Session["U_NAME"] = ARY1[5].ToString();
        */

        /*
        if (SSO_Control1.LoginStatus(Session["LOG_CODE"].ToString()) == 0)
        { Response.Redirect(Session["EXP_PAGE"].ToString()); }
        else
        { SSO_Control1.GearUp(ARY1[3].ToString(), ARY1[4].ToString()); }
        */
    }

    private void SSO_Control1_CK(object sender, EventArgs e)
    {   
        I1.Attributes["src"] = "http://www.yahoo.com";

        /*
        if (SSO_Control1.LoginStatus(Session["LOG_CODE"].ToString()) == 1)
        { I1.Attributes["src"] = "http://www.yahoo.com";} //SSO_Control1.PAGE_NAME;
        else        
        { Response.Redirect(Session["EXP_PAGE"].ToString()); }        
        */
    }

    
}

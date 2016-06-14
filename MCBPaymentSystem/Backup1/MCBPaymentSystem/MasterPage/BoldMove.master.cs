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

public partial class MasterPage_BoldMove : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Label1.Text = Session["CompleteInformation"].ToString();    

    }

    public void InfoChange(string info)
    {
        //Label1.Text = info;
    }

    protected void Page_Init(object sender, EventArgs e)
    {        
      /*
        HtmlLink css = new HtmlLink();
        css.Href = "~/Brown.css";
        css.Attributes["rel"] = "stylesheet";
        css.Attributes["type"] = "text/css";
        css.Attributes["media"] = "all";        
        Page.Controls.Add(css);
      */        
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
        L.SP_LOGIN_STATUS(Session["LOG_CODE"].ToString(), "LOG-OUT");     
        Response.Redirect(Session["EXP_PAGE"].ToString());
    }
}

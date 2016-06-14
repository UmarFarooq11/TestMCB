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
using System.Data.OracleClient;

public partial class MasterPage_BoldMoveMain : System.Web.UI.MasterPage
{

    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetCacheability(HttpCacheability.ServerAndNoCache);
        if (Request.QueryString["UID"] != null)
        {
            Session["U_NAME"] = Request.QueryString["UID"].ToString();
        }
       
        #region
        //txtpage.Attributes.Add("style", "visibility: hidden;");
        //string dpage = "";
        //if (!IsPostBack)
        //{
        //    DataSet sds = new DataSet();
        //    sds = Fetch_DPAGE();
        //    if (sds.Tables[0].Rows.Count > 0)
        //    {
        //        dpage = sds.Tables[0].Rows[0]["dpage"].ToString();
        //        string[] mpage = dpage.Split('/');
        //        string spage = mpage[0] + "//" + mpage[1] + mpage[2] + "/" + mpage[3] + "/" + mpage[4] + "/" + "Sessiontimeout.aspx";
        //        //txtpage.Text = spage; ;
        //    }
        //}
        //string strpage = "";
        //if (Request.UrlReferrer != null)
        //{
        //    strpage = Request.UrlReferrer.Segments[Request.UrlReferrer.Segments.Length - 1];
        //}
        //if (strpage == "")
        //{
        //    Response.Redirect(dpage);
        //}
        #endregion
    }

    protected void Page_Init(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string[] host = null;
            string AllowHost = ConfigurationSettings.AppSettings["AllowHost"] == null ? "" : ConfigurationSettings.AppSettings["AllowHost"].ToString();
            host = AllowHost.Split(';');
            string LoginURL = ConfigurationSettings.AppSettings["LoginURL"] == null ? "" : ConfigurationSettings.AppSettings["LoginURL"].ToString();
            if (LoginURL == "")
            {
                Exception ex = new Exception("Login URL not define");
                throw ex;
            }
            string strpage = "";

            if (Request.UrlReferrer != null)
            {
                strpage = Request.UrlReferrer.Segments[Request.UrlReferrer.Segments.Length - 1];
            }
            if (strpage == "")
            {
                Response.Redirect(LoginURL);
            }
            bool is_true = false;
            //Use for CSRF Start
            //for (int i = 0; i < host.Length; i++)
            //{
            //    if (Request.Url.Host.ToUpper() == host[i].ToUpper())
            //    {
            //        is_true = true;
            //        break;
            //    }
            //}
            //if (is_true == true)
            //{*/
            for (int i = 0; i < host.Length; i++)
            {
                if (Request.UrlReferrer.Host.ToUpper() == host[i].ToUpper())
                {
                    is_true = true;
                    break;
                }
            }
            //}
            if (is_true == false)
            {
                Response.Redirect(LoginURL);
            }
            //Use for CSRF End
        }



        //if (Session.IsNewSession)
        //{
        //    // Force session to be created;
        //    // otherwise the session ID changes on every request.
        //    Session["ForceSession"] = DateTime.Now;
        //}
        //// 'Sign' the viewstate with the current session.
        //this.Page.ViewStateUserKey = Session.SessionID;
        //if (Page.EnableViewState)
        //{
        //    // Make sure ViewState wasn't passed on the querystring.
        //    // This helps prevent one-click attacks.
        //    if (!string.IsNullOrEmpty(Request.Params["__VIEWSTATE"]) &&
        //      string.IsNullOrEmpty(Request.Form["__VIEWSTATE"]))
        //    {
        //        throw new Exception("Viewstate existed, but not on the form.");
        //    }
        //}
    }
    //protected void Page_Init(object sender, EventArgs e)
    //{
    //    // Validate whether ViewState contains the MAC fingerprint
    //    // Without a fingerprint, it's impossible to prevent CSRF.
    //    if (!this.Page.EnableViewStateMac)
    //    {
    //        throw new InvalidOperationException(
    //            "The page does NOT have the MAC enabled and the view" +
    //            "state is therefore vulnerable to tampering.");
    //    }

    //    this.Page.ViewStateUserKey = this.Session.SessionID;



    //    //if (Page.User.Identity.IsAuthenticated)
    //    //    Page.ViewStateUserKey = Session.SessionID;

    //    ////Below code use for Cross Site Request Forgery -Start
    //    //if (Session.IsNewSession)
    //    //{
    //    //    Session["ForceSession"] = DateTime.Now;
    //    //}
    //    //Page.ViewStateUserKey = Session.SessionID;


    //    //if (Page.EnableViewState)
    //    //{
    //    //    if (!string.IsNullOrEmpty(Request.Params["__VIEWSTATE"]) && string.IsNullOrEmpty(Request.Form["__VIEWSTATE"]))
    //    //    {
    //    //        throw new Exception("Viewstate existed, but not on the form.");
    //    //    }
    //    //}
    //    //End//
    //    #region
    //    //HtmlGenericControl link = new HtmlGenericControl("LINK");
    //    //link.Attributes.Add("rel", "stylesheet");
    //    //link.Attributes.Add("type", "text/css");
    //    //link.Attributes.Add("href", "../" + Session["CSSChange"].ToString());
    //    //Controls.Add(link);
    //    //link.Dispose();


    //    //HtmlGenericControl link1 = new HtmlGenericControl("LINK");
    //    //link1.Attributes.Add("rel", "stylesheet");
    //    //link1.Attributes.Add("type", "text/css");
    //    //link1.Attributes.Add("href", "../" + Session["Menucss"].ToString());
    //    //Page.Header.Controls.Add(link1);
    //    //link1.Dispose();

    //    //HtmlGenericControl link2 = new HtmlGenericControl("script");
    //    //link2.Attributes.Add("type", "text/javascript");
    //    //link2.Attributes.Add("src", "../" + Session["Menujs"].ToString());
    //    //Page.Header.Controls.Add(link2);
    //    //link2.Dispose();
    //    //Startup_Util.SPDS_DB = "Data Source=CR-ML150;Initial Catalog=SAMBA_SPDS_PRE;User ID=sa";
    //    //ConnectionBean.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
    //    ///ConnectionBean.ConnectionString = Startup_Util.SPDS_DB.ToString();
    //    //ConnectionBean.ConnectionString;//= "Data Source=SW-waqas\\SQLEXPRESS;Initial Catalog=SAMBA_SPDS_RA;User ID=sa;password=sa";
    //    //ConnectionBean.ConnectionString = Startup_Util.DB_Route;


    //    //------------------------COMMENTED BY WAQAS ON 18-04-2011--------------------------------------
    //    //PathReader p1 = new PathReader();
    //    //DatabaseConfig D = new DatabaseConfig();
    //    //D = p1.Deserialize_Data();
    //    //Session["FtpUserID"] = Startup_Util.DcryptionPWD(D.FTPUSERID);
    //    //Session["FTPPASSWORD"] = Startup_Util.DcryptionPWD(D.FTPPASSWORD);
    //    //Session["FWIP"] = Startup_Util.DcryptionPWD(D.FWIP);
    //    //------------------------COMMENTED BY WAQAS ON 18-04-2011--------------------------------------
    //    #endregion
    //}


    protected void Page_PreInit(object sender, EventArgs e)
    { Page.Theme = Session["ThemeChange"].ToString(); }


    protected void COLOR1_Click(object sender, ImageClickEventArgs e)
    {
        Session["ThemeChange"] = "ColorSchemeBlue";
        Session["CSSChange"] = "Blue.css";

        Session["Menucss"] = "bluemenu.css";
        Session["Menujs"] = "bluemenu.js";

        Response.Redirect(Request.Url.ToString());
    }

    protected void COLOR2_Click(object sender, ImageClickEventArgs e)
    {
        Session["ThemeChange"] = "ColorSchemeGreen";
        Session["CSSChange"] = "Green.css";

        Session["Menucss"] = "greenmenu.css";
        Session["Menujs"] = "greenmenu.js";

        Response.Redirect(Request.Url.ToString());
    }

    protected void COLOR3_Click(object sender, ImageClickEventArgs e)
    {
        Session["ThemeChange"] = "ColorSchemeBrown";
        Session["CSSChange"] = "Brown.css";

        Session["Menucss"] = "redmenu.css";
        Session["Menujs"] = "redmenu.js";

        Response.Redirect(Request.Url.ToString());
    }

    protected void COLOR4_Click(object sender, ImageClickEventArgs e)
    {
        Session["ThemeChange"] = "ColorSchemePurple";
        Session["CSSChange"] = "Purple.css";

        Session["Menucss"] = "purplemenu.css";
        Session["Menujs"] = "purplemenu.js";

        Response.Redirect(Request.Url.ToString());
    }

    protected void COLOR5_Click(object sender, ImageClickEventArgs e)
    {
        Session["ThemeChange"] = "ColorSchemeSliver";
        Session["CSSChange"] = "Sliver.css";


        Session["Menucss"] = "slivermenu.css";
        Session["Menujs"] = "slivermenu.js";


        Response.Redirect(Request.Url.ToString());
    }


    public void Authorize_Center_True()
    { CMD_AUTHORIZE.Visible = true; }

    public void Authorize_Center_False()
    { CMD_AUTHORIZE.Visible = false; }


    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        Response.Redirect("../MasterPage/Logout.aspx");
    }
    protected void CMD_AUTHORIZE_Click(object sender, EventArgs e)
    {
        /*
        Bal_Sample.General_LOV.LOV_COLLECTION LOV_COLLECTION = new Bal_Sample.General_LOV.LOV_COLLECTION();
        DataSet Y = LOV_COLLECTION.SP_AUTH_INFO (Session["TABLE_NAME"].ToString(),
                                                "ROWID",
                                                Session["ROWID"].ToString());
        if (Y.Tables[0].Rows[0]["AUTHORIZER"].ToString().Length > 0)
        {
            DataSet X = LOV_COLLECTION.SP_AUTH_COMMIT(Session["TABLE_NAME"].ToString(),
                "","",                                    
                //Session["LOG_UID"].ToString(),
                                                    //DateTime.Now.ToString("dd-MMM-yyyy").ToString(),
                                                    "ROWID",
                                                    Session["ROWID"].ToString());
            Response.Redirect("../" + Session["FORM_NAME"].ToString());
        }
        else
        {
            DataSet X = LOV_COLLECTION.SP_AUTH_COMMIT(Session["TABLE_NAME"].ToString(),
            //                                        "", "",
                                                    Session["LOG_UID"].ToString(),
                                                    DateTime.Now.ToString("dd-MMM-yyyy").ToString(),
                                                    "ROWID",
                                                    Session["ROWID"].ToString());
            Response.Redirect("../" + Session["FORM_NAME"].ToString());
        }*/
    }

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    { /*Response.Redirect("http://www.cr-pl.com");*/
        Response.Redirect("http://www.google.com");
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    { Response.Redirect("../MasterPage/AboutUs.aspx"); }
    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        Response.Redirect("http://www.cr-pl.com");
    }


    private void SSO_Control1_CK(object sender, EventArgs e)
    {
        //I1.Attributes["src"] = SSO_Control1.PAGE_NAME;
    }
    protected DataSet Fetch_DPAGE()
    {
        DatabaseConnection_Util db = new DatabaseConnection_Util();
        DataSet ds = new DataSet();
        OracleParameter[] param = new OracleParameter[1];
        param[0] = db.Oracle_Param("data_resultset", OracleType.Cursor, ParameterDirection.Output, "");
        ds = db.Oracle_GetDataSetSP("sp_web_setup_getdpage", param);
        return ds;
    }
}



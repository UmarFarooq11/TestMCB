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

public partial class SPDS_InstrumentFileSetup_SPDS_InstrumentFileSetup : System.Web.UI.Page
{
    LOV_COLLECTION LOV = new LOV_COLLECTION();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack == false)
        {
            string[] ARY;
            string RGS_SUPPORT;

            Response.Cache.SetCacheability(HttpCacheability.ServerAndNoCache);
            Session["RGS"] = "00000";
            String ST = Startup_Util.DcryptionPWD(Request.QueryString[0].ToString());
            ARY = ST.Split('~');
            Session["RGS"] = ARY[0].ToString();
            RGS_SUPPORT = Session["RGS"].ToString();         
            
            if (RGS_SUPPORT.Substring(2, 1) == "0")
            { EditToolbar.Items[0].Disabled = true; /*Edit*/}
            else if (RGS_SUPPORT.Substring(2, 1) == "1")
            { EditToolbar.Items[0].Disabled = false; /*Edit*/}

            if (RGS_SUPPORT.Substring(4, 1) == "0")
            { EditToolbar.Items[1].Disabled = true; /*Authorize / Unauthorize*/}
            else if (RGS_SUPPORT.Substring(4, 1) == "1")
            { EditToolbar.Items[1].Disabled = false; /*Authorize / Unauthorize*/}

            DataSet DS = new DataSet();
            DS = LOV.INS_CALL();
            if (DS.Tables[0].Rows.Count > 0)
            {
                TXT_FILE.Text = DS.Tables[0].Rows[0][0].ToString();    
            }
            else
            {
                lblMessage.Text = "Path is not Defined.";
            }
            
        }
    }    
    protected void EditToolbar_ItemClick(object sender, EO.Web.ToolBarEventArgs e)
    {                
        if (e.Item.ToolTip == "Update")
        { 
            LOV.INS_SAVE(TXT_FILE.Text,Session["U_NAME"].ToString());
            lblMessage.Text = "File path successfully updated.";
            lblMessage.ForeColor = System.Drawing.Color.Blue;
        }

        else if (e.Item.ToolTip == "Authorize")
        {
            LOV.INS_AUTH(Session["U_NAME"].ToString());
        }


        //Session["U_NAME"].ToString();

    }
}

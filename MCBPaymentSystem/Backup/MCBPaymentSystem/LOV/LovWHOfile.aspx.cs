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

public partial class LOV_LovWHOfile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetCacheability(HttpCacheability.ServerAndNoCache);
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["WHO_FILE_NAME"] = GridView1.SelectedRow.Cells[0].Text;
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {

    }
   
}

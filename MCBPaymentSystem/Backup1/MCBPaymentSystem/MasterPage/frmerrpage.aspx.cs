using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage_frmerrpage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current != null)
        {
            try
            {
                string[] Errline = Session["sError"].ToString().Split(';');
                Response.Write("Err on      :" + Errline[0].ToString() + Environment.NewLine);
                Response.Write("Err Message :" + Errline[1].ToString() + Environment.NewLine);
                Response.Write("Err Method  :" + Errline[2].ToString());
            }
            catch (Exception)
            {

            }
        }

    }
}

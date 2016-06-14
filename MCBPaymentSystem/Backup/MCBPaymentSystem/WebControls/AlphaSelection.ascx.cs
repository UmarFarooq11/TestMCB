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

public partial class WebControls_AlphaSelection : System.Web.UI.UserControl
{
    public delegate void EventHandler(Object obj, EventArgs e);
    public event EventHandler CK;
    public string AlphaClick = "";
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void CK_IN()
    {
        if (CK != null)
        {
            CK(this, new EventArgs());
        }
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        Button bt;
        bt = (Button)sender;
        AlphaClick = bt.Text;
        CK_IN();
    }
}

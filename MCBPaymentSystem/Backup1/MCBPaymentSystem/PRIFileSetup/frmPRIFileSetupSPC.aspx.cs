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

public partial class PRIFileSetup_frmPRIFileSetupSPC : System.Web.UI.Page
{
    FormViewRow D_TEMP;
    TextBox TXT;
    Label LL;

    PROCESS_PRIFileSetup P_PRIFileSetup = new PROCESS_PRIFileSetup();

    protected void Page_Load(object sender, EventArgs e)
    {
        ((Label)FormView1.FindControl("Label_HEAD")).Text = "PRI File Setup";
      if (IsPostBack == false)
      {
       ((EO.Web.ToolBar)FormView1.FindControl("DisplayToolBar")).Items[0].Disabled = false;
       ((EO.Web.ToolBar)FormView1.FindControl("DisplayToolBar")).Items[2].Disabled = false;
       //((EO.Web.ToolBar)FormView1.FindControl("DisplayToolBar")).Items[4].Disabled = false;
     //  ((EO.Web.ToolBar)FormView1.FindControl("DisplayToolBar")).Items[4].Visible = false;
      }        
    }
    protected void FormView1_PageIndexChanging(object sender, FormViewPageEventArgs e) { }
    private void BackPage()
    {
        Session["ID"] = "1";
        Session["FileUpload"] = "";
        Session["FileDownload"] = "";
        Response.Redirect("../PRIFileSetup/frmPRIFileSetupSPC.aspx");
        //((EO.Web.ToolBar)FormView1.FindControl("DisplayToolBar")).Items[0].Disabled = false;
        //((EO.Web.ToolBar)FormView1.FindControl("DisplayToolBar")).Items[2].Disabled = false;
        //((EO.Web.ToolBar)FormView1.FindControl("DisplayToolBar")).Items[4].Disabled = false;
        //FormView1.ChangeMode(FormViewMode.ReadOnly);
        
    }
    protected void Page_PreInit(object sender, EventArgs e)
    { Page.Theme = Session["ThemeChange"].ToString(); }
    protected void DisplayToolBar_ItemClick(object sender, EO.Web.ToolBarEventArgs e)
    {
        if (e.Item.ToolTip == "Edit")
        { FormView1.ChangeMode(FormViewMode.Edit); }
        else if (e.Item.ToolTip == "Cancel")
        { BackPage(); }
        else if (e.Item.ToolTip == "Authorize / Unauthorize")
        { }
    }
    protected void EditToolbar_ItemClick(object sender, EO.Web.ToolBarEventArgs e)
    {
        if (e.Item.ToolTip == "Update")
        {
            P_PRIFileSetup.RecordInputStart();
            P_PRIFileSetup.Get_ID = "1";
            P_PRIFileSetup.Get_FileUpload = ((TextBox)FormView1.FindControl("TXT_FileUpload_EDIT")).Text;
            P_PRIFileSetup.Get_FileDownload = ((TextBox)FormView1.FindControl("TXT_FileDownload_EDIT")).Text;
            P_PRIFileSetup.RecordInputCommit();
            P_PRIFileSetup.EditNewGroup();
            BackPage();
            
        }
        else if (e.Item.ToolTip == "Cancel")
        { BackPage(); }
    }
    protected void InsertToolbar_ItemClick(object sender, EO.Web.ToolBarEventArgs e)
    {}
}

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

public partial class LOV_LOV_BASE_LOCATION : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetCacheability(HttpCacheability.ServerAndNoCache);
        if (IsPostBack == false)
        {
            Session["USR_NAME"] = "";
            Session["LOV_ID"] = "";
            Session["LOV_DESCRIPTION"] = "";
        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    { }
    protected void Page_Init(object sender, EventArgs e)
    {
        AlphaSelection1.CK += new WebControls_AlphaSelection.EventHandler(AlphaSelection1_CK);
        HtmlGenericControl link = new HtmlGenericControl("LINK");
        link.Attributes.Add("rel", "stylesheet");
        link.Attributes.Add("type", "text/css");
        link.Attributes.Add("href", "../" + Session["CSSChange"].ToString());
        Controls.Add(link);
        link.Dispose();
    }
    protected void Page_PreInit(object sender, EventArgs e)
    { Page.Theme = Session["ThemeChange"].ToString(); }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

        Session["USER_CODE"] = GridView1.DataKeys[this.GridView1.SelectedIndex].Value.ToString();
        Session["USR_NAME"] = GridView1.SelectedRow.Cells[1].Text;
        TXT_USER_NAME.Text = Session["USER_CODE"].ToString();
        Session["LOV_ID"] = GridView1.SelectedRow.Cells[0].Text;
        Session["LOV_DESCRIPTION"] = GridView1.SelectedRow.Cells[1].Text;
        Session["REAL_NAME"] = GridView1.SelectedRow.Cells[2].Text;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        DRP_LIST.Items.Clear();
        LBL_GridStatus.Text = "Page(s): 0-0";
        LBL_RowStatus.Text = "Display Row(s): 0-0";
        Session["USR_NAME"] = "%" + TXT_USER_NAME.Text + "%";
    }
    private void AlphaSelection1_CK(object sender, EventArgs e)
    {
        DRP_LIST.Items.Clear();
        LBL_GridStatus.Text = "Page(s): 0-0";
        LBL_RowStatus.Text = "Display Row(s): 0-0";
        if (RD_USER_NAME.Checked == true)
        {
            Session["USR_NAME"] = AlphaSelection1.AlphaClick + '%';
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        DRP_LIST.Items.Clear();
        LBL_GridStatus.Text = "Page(s): 0-0";
        LBL_RowStatus.Text = "Display Row(s): 0-0";

        TXT_USER_NAME.Text = "";
        RD_USER_NAME.Checked = false;
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        Others.GridMouseOver(Session["ThemeChange"].ToString(), e);
        int Lower_Count = 0;
        LBL_GridStatus.Text = "Page(s): " + Convert.ToString(GridView1.PageIndex + 1) + "-" + GridView1.PageCount.ToString();
        if (GridView1.PageCount > 1)
        { DRP_LIST.Text = Convert.ToString(GridView1.PageIndex + 1); }

        if (GridView1.Rows.Count < 20)
        {
            LBL_RowStatus.Text = Convert.ToString((GridView1.PageIndex * Convert.ToInt16(Session["DEFAULT_ROWS"].ToString())) + GridView1.Rows.Count);
            Lower_Count = ((GridView1.PageIndex * Convert.ToInt16(Session["DEFAULT_ROWS"].ToString())) + GridView1.Rows.Count) - (GridView1.Rows.Count + 1);
            Lower_Count = Lower_Count + 2;
            LBL_RowStatus.Text = "Display Rows: " + Lower_Count.ToString() + "-" + LBL_RowStatus.Text;
        }
        else
        {
            LBL_RowStatus.Text = Convert.ToString((GridView1.PageIndex + 1) * Convert.ToInt16(GridView1.Rows.Count.ToString()));
            Lower_Count = (GridView1.PageIndex + 1) * Convert.ToInt16(GridView1.Rows.Count.ToString()) - (GridView1.Rows.Count + 1);
            Lower_Count = Lower_Count + 2;
            LBL_RowStatus.Text = "Display Rows: " + Lower_Count.ToString() + "-" + LBL_RowStatus.Text;
        }
        if (DRP_LIST.Items.Count == 0)
        {
            for (int A = 1; A <= GridView1.PageCount; A++)
            { DRP_LIST.Items.Add(A.ToString()); }
        }
    }

    protected void CMD_MoveNext_Click(object sender, ImageClickEventArgs e)
    { GridView1.PageIndex = GridView1.PageIndex + 1; }
    protected void CMD_MoveBack_Click(object sender, ImageClickEventArgs e)
    {
        if (GridView1.PageIndex == 0)
        { return; }
        else
        { GridView1.PageIndex = GridView1.PageIndex - 1; }
    }
    protected void CMD_MoveLast_Click(object sender, ImageClickEventArgs e)
    { GridView1.PageIndex = GridView1.PageCount - 1; }
    protected void CMD_MoveFirst_Click(object sender, ImageClickEventArgs e)
    { GridView1.PageIndex = 0; }

    protected void DRP_LIST_SelectedIndexChanged(object sender, EventArgs e)
    { GridView1.PageIndex = Convert.ToInt16(DRP_LIST.Text) - 1; }
}

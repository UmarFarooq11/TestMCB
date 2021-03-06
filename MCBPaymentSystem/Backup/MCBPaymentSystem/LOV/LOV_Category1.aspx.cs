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

public partial class LOV_LOV_Category1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetCacheability(HttpCacheability.ServerAndNoCache);
        if (IsPostBack == false)
        {
            Session["SPDS_SignatoryCategorySetup_ID"] = "0";
            Session["SPDS_SignatoryCategorySetup_CATEGORY_NAME"] = "%";
            ToolBar1.Items[0].Disabled = false;
            ToolBar1.Items[1].Disabled = false;
            ToolBar1.Items[2].Disabled = false;
        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    { }
    protected void Page_Init(object sender, EventArgs e)
    { AlphaSelection1.CK += new WebControls_AlphaSelection.EventHandler(AlphaSelection1_CK); }
    protected void Page_PreInit(object sender, EventArgs e)
    { Page.Theme = Session["ThemeChange"].ToString(); }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        string S;
        S = GridView1.DataKeys[this.GridView1.SelectedIndex].Value.ToString();
        if (S.Substring(0, 1).ToString() != "I")
        {
            Session["SPDS_SignatoryCategorySetup_ID"] = GridView1.DataKeys[this.GridView1.SelectedIndex].Value.ToString();
            Session["SPDS_SignatoryCategorySetup_CATEGORY_NAME"] = GridView1.SelectedRow.Cells[1].Text;

            Session["LOV_ID"] = GridView1.DataKeys[this.GridView1.SelectedIndex].Value.ToString();
            Session["LOV_DESCRIPTION"] = GridView1.SelectedRow.Cells[1].Text;
          ///  Response.Redirect("../SignatoryCategorySetup/frmSPDS_SignatoryCategorySetupSPC.aspx");
        }
    }
    private void AlphaSelection1_CK(object sender, EventArgs e)
    {
        if (RD_CATEGORY_NAME.Checked == true)
        {
            Session["SPDS_SignatoryCategorySetup_CATEGORY_NAME"] = AlphaSelection1.AlphaClick + '%';
            ////Session["SPDS_SignatoryCategorySetup_FROM_LIMIT"] = '%';
            ////Session["SPDS_SignatoryCategorySetup_TO_LIMIT"] = '%';
            ////Session["SPDS_SignatoryCategorySetup_CurrentStatus"] = '%';
        }
        if (RD_FROM_LIMIT.Checked == true)
        {
            Session["SPDS_SignatoryCategorySetup_CATEGORY_NAME"] = '%';
            //Session["SPDS_SignatoryCategorySetup_FROM_LIMIT"] = AlphaSelection1.AlphaClick + '%';
            //Session["SPDS_SignatoryCategorySetup_TO_LIMIT"] = '%';
            //Session["SPDS_SignatoryCategorySetup_CurrentStatus"] = '%';
        }
        if (RD_TO_LIMIT.Checked == true)
        {
            Session["SPDS_SignatoryCategorySetup_CATEGORY_NAME"] = '%';
            //Session["SPDS_SignatoryCategorySetup_FROM_LIMIT"] = '%';
            //Session["SPDS_SignatoryCategorySetup_TO_LIMIT"] = AlphaSelection1.AlphaClick + '%';
            //Session["SPDS_SignatoryCategorySetup_CurrentStatus"] = '%';
        }
        if (RD_CurrentStatus.Checked == true)
        {
            Session["SPDS_SignatoryCategorySetup_CATEGORY_NAME"] = '%';
            //Session["SPDS_SignatoryCategorySetup_FROM_LIMIT"] = '%';
            //Session["SPDS_SignatoryCategorySetup_TO_LIMIT"] = '%';
            //Session["SPDS_SignatoryCategorySetup_CurrentStatus"] = AlphaSelection1.AlphaClick + '%';
        }
    }
    protected void SP_DPS_City_Info_ALL_Selected(object sender, ObjectDataSourceStatusEventArgs e) { }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    { /*Startup_Util.GridMouseOver(Session["ThemeChange"].ToString(), e);*/
        int Lower_Count = 0;
        LBL_GridStatus.Text = "Page(s) : " + Convert.ToString(GridView1.PageIndex + 1) + "-" + GridView1.PageCount.ToString();
        DRP_LIST.Text = Convert.ToString(GridView1.PageIndex + 1);
        if (GridView1.Rows.Count < 20)
        {
            LBL_RowStatus.Text = Convert.ToString((GridView1.PageIndex * Convert.ToInt16(Session["DEFAULT_ROWS"].ToString())) + GridView1.Rows.Count);
            Lower_Count = ((GridView1.PageIndex * Convert.ToInt16(Session["DEFAULT_ROWS"].ToString())) + GridView1.Rows.Count) - (GridView1.Rows.Count + 1);
            Lower_Count = Lower_Count + 2;
            LBL_RowStatus.Text = "Row(s) : " + Lower_Count.ToString() + "-" + LBL_RowStatus.Text;
        }
        else
        {
            LBL_RowStatus.Text = Convert.ToString((GridView1.PageIndex + 1) * Convert.ToInt16(GridView1.Rows.Count.ToString()));
            Lower_Count = (GridView1.PageIndex + 1) * Convert.ToInt16(GridView1.Rows.Count.ToString()) - (GridView1.Rows.Count + 1);
            Lower_Count = Lower_Count + 2;
            LBL_RowStatus.Text = "Row(s) : " + Lower_Count.ToString() + "-" + LBL_RowStatus.Text;
        }
        if (DRP_LIST.Items.Count == 0)
        {
            for (int A = 1; A <= GridView1.PageCount; A++)
            { DRP_LIST.Items.Add(A.ToString()); }
        }
    }
    protected void DRP_LIST_SelectedIndexChanged(object sender, EventArgs e)
    { GridView1.PageIndex = Convert.ToInt16(DRP_LIST.Text) - 1; }
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
    protected void MainGrid_Toolbar_ItemClick(object sender, EO.Web.ToolBarEventArgs e) { }
    protected void ToolBar1_ItemClick(object sender, EO.Web.ToolBarEventArgs e)
    {
        if (e.Item.ToolTip == "Add New")
        {
            Session["SPDS_SignatoryCategorySetup_ID"] = "0";
            Session["SPDS_SignatoryCategorySetup_CATEGORY_NAME"] = "%";
            //Session["SPDS_SignatoryCategorySetup_FROM_LIMIT"] = "%";
            //Session["SPDS_SignatoryCategorySetup_TO_LIMIT"] = "%";
            //Session["SPDS_SignatoryCategorySetup_CurrentStatus"] = "%";
          ///  Response.Redirect("../SignatoryCategorySetup/frmSPDS_SignatoryCategorySetupSPC.aspx");
        }
        else if (e.Item.ToolTip == "Search")
        {
            Session["SPDS_SignatoryCategorySetup_CATEGORY_NAME"] = "%" + TXT_CATEGORY_NAME.Text + "%";
            ////Session["SPDS_SignatoryCategorySetup_FROM_LIMIT"] = "%" + TXT_FROM_LIMIT.Text + "%";
            ////Session["SPDS_SignatoryCategorySetup_TO_LIMIT"] = "%" + TXT_TO_LIMIT.Text + "%";
            ////Session["SPDS_SignatoryCategorySetup_CurrentStatus"] = "%" + TXT_CurrentStatus.Text + "%";
        }
        else if (e.Item.ToolTip == "Refresh")
        {
            TXT_CATEGORY_NAME.Text = "";
            //TXT_FROM_LIMIT.Text = "";
            //TXT_TO_LIMIT.Text = "";
            //TXT_CurrentStatus.Text = "";
        }
    }
}

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

public partial class LOV_LOV_PrintAgentDetail_Location : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetCacheability(HttpCacheability.ServerAndNoCache);
         if (IsPostBack == false)
         {
        //Session["SPDS_PrintAgentDetail_PRINT_AGENT_ID"] = "%" + TXT_PRINT_AGENT_ID.Text + "%";
        //Session["SPDS_PrintAgentDetail_PRINT_LOCATION_ID"] = "%" + TXT_PRINT_LOCATION_ID.Text + "%";
        Session["SPDS_PrintAgentDetail_DONGAL_PIN"] = "0";
        Session["SPDS_PrintAgentDetail_MASTER_ZIP_CODE"] = "0";
        Session["LOV_ID"] = "";
        Session["LOV_CODE"] = "";
        Session["LOV_DESCRIPTION"] = "";
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
        //string S;
        //S = GridView1.DataKeys[this.GridView1.SelectedIndex].Value.ToString();
        //if (S.Substring(0, 1).ToString() != "I")
        //{
            Session["SPDS_PrintAgentDetail_ID"] = GridView1.DataKeys[this.GridView1.SelectedIndex].Value.ToString();
            Session["ID"] = GridView1.SelectedRow.Cells[0].Text;
           // Session["SPDS_PrintAgentDetail_PRINT_LOCATION_ID"] = GridView1.SelectedRow.Cells[4].Text;
          //  Session["SPDS_PrintAgentDetail_PRINT_AGENT_ID"] = GridView1.SelectedRow.Cells[5].Text;

            Session["SPDS_PrintAgentSetup_PRINT_AGENT_NAME"] = GridView1.SelectedRow.Cells[1].Text;
            Session["CMN_DISTRICT_DISTRICTNAME"] = GridView1.SelectedRow.Cells[2].Text;
            Session["LOV_ID"] = GridView1.DataKeys[this.GridView1.SelectedIndex].Value.ToString(); //GridView1.SelectedRow.Cells[0].Text;
            Session["LOV_CODE"] = GridView1.SelectedRow.Cells[1].Text;
            Session["LOV_DESCRIPTION"] = GridView1.SelectedRow.Cells[1].Text;

           // Response.Redirect("../PrintAgentDetail/frmSPDS_PrintAgentDetailSPC.aspx");
       /// }
    }
    private void AlphaSelection1_CK(object sender, EventArgs e)
    {
        
        if (RD_PRINT_LOCATION_ID.Checked == true)
        {
            Session["SPDS_PrintAgentDetail_PRINT_AGENT_ID"] = '%';
            Session["SPDS_PrintAgentDetail_PRINT_LOCATION_ID"] = AlphaSelection1.AlphaClick + '%';
            //Session["SPDS_PrintAgentDetail_DONGAL_PIN"] = '%';
            //Session["SPDS_PrintAgentDetail_MASTER_ZIP_CODE"] = '%';
        }
        //if (RD_DONGAL_PIN.Checked == true)
        //{
        //    Session["SPDS_PrintAgentDetail_PRINT_AGENT_ID"] = '%';
        //    Session["SPDS_PrintAgentDetail_PRINT_LOCATION_ID"] = '%';
        //    Session["SPDS_PrintAgentDetail_DONGAL_PIN"] = AlphaSelection1.AlphaClick + '%';
        //    Session["SPDS_PrintAgentDetail_MASTER_ZIP_CODE"] = '%';
        //}
        //if (RD_MASTER_ZIP_CODE.Checked == true)
        //{
        //    Session["SPDS_PrintAgentDetail_PRINT_AGENT_ID"] = '%';
        //    Session["SPDS_PrintAgentDetail_PRINT_LOCATION_ID"] = '%';
        //    Session["SPDS_PrintAgentDetail_DONGAL_PIN"] = '%';
        //    Session["SPDS_PrintAgentDetail_MASTER_ZIP_CODE"] = AlphaSelection1.AlphaClick + '%';
        //}
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
            Session["SPDS_PrintAgentDetail_ID"] = "0";
            Session["SPDS_PrintAgentDetail_PRINT_AGENT_ID"] = "0";
            Session["SPDS_PrintAgentDetail_PRINT_LOCATION_ID"] = "0";
            //Session["SPDS_PrintAgentDetail_DONGAL_PIN"] = "%";
            //Session["SPDS_PrintAgentDetail_MASTER_ZIP_CODE"] = "%";
           // Response.Redirect("../PrintAgentDetail/frmSPDS_PrintAgentDetailSPC.aspx");
        }
        else if (e.Item.ToolTip == "Search")
        {
            //Session["SPDS_PrintAgentDetail_PRINT_AGENT_ID"] = "%" + TXT_PRINT_AGENT_ID.Text + "%";
            Session["SPDS_PrintAgentDetail_PRINT_LOCATION_ID"] = "%" + TXT_PRINT_LOCATION_ID.Text + "%";
            //Session["SPDS_PrintAgentDetail_DONGAL_PIN"] = "%" + TXT_DONGAL_PIN.Text + "%";
            //Session["SPDS_PrintAgentDetail_MASTER_ZIP_CODE"] = "%" + TXT_MASTER_ZIP_CODE.Text + "%";
        }
        else if (e.Item.ToolTip == "Refresh")
        {
            //TXT_PRINT_AGENT_ID.Text = "";
            TXT_PRINT_LOCATION_ID.Text = "";
            //TXT_DONGAL_PIN.Text = "";
            //TXT_MASTER_ZIP_CODE.Text = "";
        }
    }
}

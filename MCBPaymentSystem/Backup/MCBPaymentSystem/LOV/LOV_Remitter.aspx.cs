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

public partial class MasterRemitterInfo_frmRPS_Remitter : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["RPS_Remitter_ID"] = "0";
        Session["RPS_Remitter_RemitterNo"] = "0";
        Session["RPS_Remitter_FirstName"] = "0";
        Session["RPS_Remitter_MiddleName"] = "0";
        Session["RPS_Remitter_LastName"] = "0";
        Session["LOV_ID"] = "0";
        Session["LOV_RemitterNo"] = "0";
        Session["LOV_FirstName"] = "0";
        Session["LOV_MiddleName"] = "0";
        Session["LOV_LastName"] = "0";
        ToolBar1.Items[0].Visible = false;
        ToolBar1.Items[1].Disabled = false;
        ToolBar1.Items[2].Disabled = false;
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    { }
    protected void Page_Init(object sender, EventArgs e)
    { AlphaSelection1.CK += new WebControls_AlphaSelection.EventHandler(AlphaSelection1_CK); }
    protected void Page_PreInit(object sender, EventArgs e)
    { Page.Theme = Session["ThemeChange"].ToString(); }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
       
            Session["RPS_Remitter_ID"] = GridView1.DataKeys[this.GridView1.SelectedIndex].Value.ToString();
            Session["RPS_Remitter_RemitterNo"] = GridView1.SelectedRow.Cells[1].Text;
            Session["RPS_Remitter_FirstName"] = GridView1.SelectedRow.Cells[2].Text;
            Session["RPS_Remitter_MiddleName"] = GridView1.SelectedRow.Cells[3].Text;
            Session["RPS_Remitter_LastName"] = GridView1.SelectedRow.Cells[4].Text;

            Session["LOV_ID"] = GridView1.DataKeys[this.GridView1.SelectedIndex].Value.ToString();
            Session["LOV_RemitterNo"] = GridView1.SelectedRow.Cells[1].Text;
            Session["LOV_FirstName"] = GridView1.SelectedRow.Cells[2].Text;
            Session["LOV_MiddleName"] = GridView1.SelectedRow.Cells[3].Text;
            Session["LOV_LastName"] = GridView1.SelectedRow.Cells[4].Text;

    }
    private void AlphaSelection1_CK(object sender, EventArgs e)
    {
        DRP_LIST.Items.Clear();
        LBL_GridStatus.Text = "Page(s): 0-0";
        LBL_RowStatus.Text = "Display Row(s): 0-0";
        
        if (RD_RemitterNo.Checked == true)
        {
            Session["RPS_Remitter_PrincipleBankName"] = '%';
            Session["RPS_Remitter_RemitterNo"] = AlphaSelection1.AlphaClick + '%';
            Session["RPS_Remitter_FirstName"] = '%';
            Session["RPS_Remitter_MiddleName"] = '%';
            Session["RPS_Remitter_LastName"] = '%';
        }
        if (RD_FirstName.Checked == true)
        {
            Session["RPS_Remitter_PrincipleBankName"] = '%';
            Session["RPS_Remitter_RemitterNo"] = '%';
            Session["RPS_Remitter_FirstName"] = AlphaSelection1.AlphaClick + '%';
            Session["RPS_Remitter_MiddleName"] = '%';
            Session["RPS_Remitter_LastName"] = '%';
        }
        if (RD_MiddleName.Checked == true)
        {
            Session["RPS_Remitter_PrincipleBankName"] = '%';
            Session["RPS_Remitter_RemitterNo"] = '%';
            Session["RPS_Remitter_FirstName"] = '%';
            Session["RPS_Remitter_MiddleName"] = AlphaSelection1.AlphaClick + '%';
            Session["RPS_Remitter_LastName"] = '%';
        }
        if (RD_LastName.Checked == true)
        {
            Session["RPS_Remitter_PrincipleBankName"] = '%';
            Session["RPS_Remitter_RemitterNo"] = '%';
            Session["RPS_Remitter_FirstName"] = '%';
            Session["RPS_Remitter_MiddleName"] = '%';
            Session["RPS_Remitter_LastName"] = AlphaSelection1.AlphaClick + '%';
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
        
        if (e.Item.ToolTip == "Search")
        {
            Session["RPS_Remitter_PrincipleBankName"] = "%";
            Session["RPS_Remitter_RemitterNo"] = "%" + TXT_RemitterNo.Text + "%";
            Session["RPS_Remitter_FirstName"] = "%" + TXT_FirstName.Text + "%";
            Session["RPS_Remitter_MiddleName"] = "%" + TXT_MiddleName.Text + "%";
            Session["RPS_Remitter_LastName"] = "%" + TXT_LastName.Text + "%";
        }
        else if (e.Item.ToolTip == "Refresh")
        {
        
            TXT_RemitterNo.Text = "";
            TXT_FirstName.Text = "";
            TXT_MiddleName.Text = "";
            TXT_LastName.Text = "";
        }
    }
   
}

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

public partial class LOV_LOV_DraftHolded: System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
         Response.Cache.SetCacheability(HttpCacheability.ServerAndNoCache);
         if (IsPostBack == false)
         {
             Session["LOV_ID"] = "";
             Session["LOV_DraftNo"] = "";
             Session["LOV_RemitterName"] = "";
             Session["LOV_BeneficiaryNo"] = "";
             Session["LOV_RemittanceRefNo"] = "";
             Session["LOV_RemitterNo"] = "";
             Session["LOV_BeneficiaryNo"] = "";

             Session["GetDraftHolded_ID"] = "";
             Session["GetDraftHolded_DraftNo"] = "";
             Session["GetDraftHolded_BeneficiaryName"] = "";
             Session["GetDraftHolded_RemitterName"] = "";
             Session["GetDraftHolded_RemittanceRefNo"] = "";
             Session["GetDraftHolded_BeneficiaryNo"] = "";
             Session["GetDraftHolded_RemitterNo"] = "";

             ToolBar1.Items[0].Visible = false;
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
            Session["GetDraftHolded_ID"] = GridView1.DataKeys[this.GridView1.SelectedIndex].Value.ToString();
            Session["GetDraftHolded_ID"] = GridView1.SelectedRow.Cells[0].Text;
            Session["GetDraftHolded_DraftNo"] = GridView1.SelectedRow.Cells[1].Text;
            Session["GetDraftHolded_BeneficiaryName"] = GridView1.SelectedRow.Cells[2].Text;
            Session["GetDraftHolded_RemitterName"] = GridView1.SelectedRow.Cells[3].Text;
            Session["GetDraftHolded_RemittanceRefNo"] = GridView1.SelectedRow.Cells[4].Text;
            Session["GetDraftHolded_BeneficiaryNo"] = GridView1.SelectedRow.Cells[5].Text;
            Session["GetDraftHolded_RemitterNo"] = GridView1.SelectedRow.Cells[6].Text;

            Session["LOV_ID"] = GridView1.DataKeys[this.GridView1.SelectedIndex].Value.ToString();
            Session["LOV_DraftNo"] = GridView1.SelectedRow.Cells[1].Text;
            Session["LOV_RemitterName"] = GridView1.SelectedRow.Cells[2].Text;
            Session["LOV_BeneficiaryNo"] = GridView1.SelectedRow.Cells[3].Text;
            Session["LOV_RemittanceRefNo"] = GridView1.SelectedRow.Cells[4].Text;
            Session["LOV_RemitterNo"] = GridView1.SelectedRow.Cells[5].Text;
            Session["LOV_BeneficiaryNo"] = GridView1.SelectedRow.Cells[6].Text;

    }
    private void AlphaSelection1_CK(object sender, EventArgs e)
    {
        if (RD_DraftNo.Checked == true)
        {
            Session["GetDraftHolded_DraftNo"] = AlphaSelection1.AlphaClick + '%';
            Session["GetDraftHolded_BeneficiaryName"] = '%';
            Session["GetDraftHolded_RemitterName"] = '%';
            Session["GetDraftHolded_RemittanceRefNo"] = '%';
            Session["GetDraftHolded_BeneficiaryNo"] = '%';
            Session["GetDraftHolded_RemitterNo"] = '%';
        }
        if (RD_BeneficiaryName.Checked == true)
        {
            Session["GetDraftHolded_DraftNo"] = '%';
            Session["GetDraftHolded_BeneficiaryName"] = AlphaSelection1.AlphaClick + '%';
            Session["GetDraftHolded_RemitterName"] = '%';
            Session["GetDraftHolded_RemittanceRefNo"] = '%';
            Session["GetDraftHolded_BeneficiaryNo"] = '%';
            Session["GetDraftHolded_RemitterNo"] = '%';
        }
        if (RD_RemitterName.Checked == true)
        {
            Session["GetDraftHolded_DraftNo"] = '%';
            Session["GetDraftHolded_BeneficiaryName"] = '%';
            Session["GetDraftHolded_RemitterName"] = AlphaSelection1.AlphaClick + '%';
            Session["GetDraftHolded_RemittanceRefNo"] = '%';
            Session["GetDraftHolded_BeneficiaryNo"] = '%';
            Session["GetDraftHolded_RemitterNo"] = '%';
        }
        if (RD_RemittanceRefNo.Checked == true)
        {
            Session["GetDraftHolded_DraftNo"] = '%';
            Session["GetDraftHolded_BeneficiaryName"] = '%';
            Session["GetDraftHolded_RemitterName"] = '%';
            Session["GetDraftHolded_RemittanceRefNo"] = AlphaSelection1.AlphaClick + '%';
            Session["GetDraftHolded_BeneficiaryNo"] = '%';
            Session["GetDraftHolded_RemitterNo"] = '%';
        }
        if (RD_BeneficiaryNo.Checked == true)
        {
            Session["GetDraftHolded_DraftNo"] = '%';
            Session["GetDraftHolded_BeneficiaryName"] = '%';
            Session["GetDraftHolded_RemitterName"] = '%';
            Session["GetDraftHolded_RemittanceRefNo"] = '%';
            Session["GetDraftHolded_BeneficiaryNo"] = AlphaSelection1.AlphaClick + '%';
            Session["GetDraftHolded_RemitterNo"] = '%';
        }
        if (RD_RemitterNo.Checked == true)
        {
            Session["GetDraftHolded_DraftNo"] = '%';
            Session["GetDraftHolded_BeneficiaryName"] = '%';
            Session["GetDraftHolded_RemitterName"] = '%';
            Session["GetDraftHolded_RemittanceRefNo"] = '%';
            Session["GetDraftHolded_BeneficiaryNo"] = '%';
            Session["GetDraftHolded_RemitterNo"] = AlphaSelection1.AlphaClick + '%';
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
            Session["GetDraftHolded_DraftNo"] = "%" + TXT_DraftNo.Text + "%";
            Session["GetDraftHolded_BeneficiaryName"] = "%" + TXT_BeneficiaryName.Text + "%";
            Session["GetDraftHolded_RemitterName"] = "%" + TXT_RemitterName.Text + "%";
            Session["GetDraftHolded_RemittanceRefNo"] = "%" + TXT_RemittanceRefNo.Text + "%";
            Session["GetDraftHolded_BeneficiaryNo"] = "%" + TXT_BeneficiaryNo.Text + "%";
            Session["GetDraftHolded_RemitterNo"] = "%" + TXT_RemitterNo.Text + "%";
        }
        else if (e.Item.ToolTip == "Refresh")
        {
            TXT_DraftNo.Text = "";
            TXT_BeneficiaryName.Text = "";
            TXT_RemitterName.Text = "";
            TXT_RemittanceRefNo.Text = "";
            TXT_BeneficiaryNo.Text = "";
            TXT_RemitterNo.Text = "";
        }
    }
}

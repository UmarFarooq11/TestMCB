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

public partial class Draft_frmRPS_Draft : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        Response.Cache.SetCacheability(HttpCacheability.ServerAndNoCache);
        if (IsPostBack == false)
        {

            Session["RPS_Draft_ID"] = "";
            Session["RPS_Draft_DraftNo"] = "";
            Session["LOV_ID"] = "";
            Session["LOV_Description"] = "";

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
        Session["RPS_Draft_ID"] = GridView1.DataKeys[this.GridView1.SelectedIndex].Value.ToString();
        Session["RPS_Draft_DraftNo"] = GridView1.SelectedRow.Cells[1].Text;

        Session["LOV_ID"] = GridView1.DataKeys[this.GridView1.SelectedIndex].Value.ToString();
        Session["LOV_Description"] = GridView1.SelectedRow.Cells[1].Text;

        Session["IncomingBatchHeaderID"] = GridView1.SelectedRow.Cells[2].Text;


    }
    private void AlphaSelection1_CK(object sender, EventArgs e)
    {
        DRP_LIST.Items.Clear();
        LBL_GridStatus.Text = "Page(s): 0-0";
        LBL_RowStatus.Text = "Display Row(s): 0-0";
        if (RD_PODNO.Checked == true)
        {
            Session["DRAFTIQUIRY_PODNO"] = AlphaSelection1.AlphaClick + '%';
            Session["DRAFTIQUIRY_RemitterNo"] = '%';
            Session["DRAFTIQUIRY_RemitterName"] = '%';
            Session["DRAFTIQUIRY_BeneficiaryNo"] = '%';
            Session["DRAFTIQUIRY_BeneficiaryName"] = '%';
            Session["DRAFTIQUIRY_STARDRAFTNO"] = '%';
            Session["DRAFTIQUIRY_STATIONNAME"] = '%';
            Session["DRAFTIQUIRY_REMITTANCENO"] = '%';
            Session["DRAFTIQUIRY_SPDS_TYPE"] = '%';
        }
        if (RD_PRODUCTTYPE.Checked == true)
        {
            Session["DRAFTIQUIRY_PODNO"] = '%';
            Session["DRAFTIQUIRY_RemitterNo"] = '%';
            Session["DRAFTIQUIRY_RemitterName"] = '%';
            Session["DRAFTIQUIRY_BeneficiaryNo"] = '%';
            Session["DRAFTIQUIRY_BeneficiaryName"] = '%';
            Session["DRAFTIQUIRY_STARDRAFTNO"] = '%';
            Session["DRAFTIQUIRY_STATIONNAME"] = '%';
            Session["DRAFTIQUIRY_REMITTANCENO"] = '%';
            Session["DRAFTIQUIRY_SPDS_TYPE"] = AlphaSelection1.AlphaClick + '%';
            Session["DRAFTIQUIRY_DRAFTNO"] = '%';
        }
        if (RD_RemitterName.Checked == true)
        {
            Session["DRAFTIQUIRY_PODNO"] = '%';
            Session["DRAFTIQUIRY_RemitterNo"] = '%';
            Session["DRAFTIQUIRY_RemitterName"] = AlphaSelection1.AlphaClick + '%';
            Session["DRAFTIQUIRY_BeneficiaryNo"] = '%';
            Session["DRAFTIQUIRY_BeneficiaryName"] = '%';
            Session["DRAFTIQUIRY_STARDRAFTNO"] = '%';
            Session["DRAFTIQUIRY_STATIONNAME"] = '%';
            Session["DRAFTIQUIRY_REMITTANCENO"] = '%';
            Session["DRAFTIQUIRY_SPDS_TYPE"] = '%';
            Session["DRAFTIQUIRY_DRAFTNO"] = '%';
        }
        if (RD_BeneficiaryName.Checked == true)
        {
            Session["DRAFTIQUIRY_PODNO"] = '%';
            Session["DRAFTIQUIRY_RemitterNo"] = '%';
            Session["DRAFTIQUIRY_RemitterName"] = '%';
            Session["DRAFTIQUIRY_BeneficiaryNo"] = '%';
            Session["DRAFTIQUIRY_BeneficiaryName"] = AlphaSelection1.AlphaClick + '%';
            Session["DRAFTIQUIRY_STARDRAFTNO"] = '%';
            Session["DRAFTIQUIRY_STATIONNAME"] = '%';
            Session["DRAFTIQUIRY_REMITTANCENO"] = '%';
            Session["DRAFTIQUIRY_SPDS_TYPE"] = '%';
            Session["DRAFTIQUIRY_DRAFTNO"] = '%';
        } 
        if (RD_DRAFTNO.Checked == true)
        {
            Session["DRAFTIQUIRY_DRAFTNO"] = AlphaSelection1.AlphaClick + '%';
            Session["DRAFTIQUIRY_PODNO"] = '%';
            Session["DRAFTIQUIRY_RemitterNo"] = '%';
            Session["DRAFTIQUIRY_RemitterName"] = '%';
            Session["DRAFTIQUIRY_BeneficiaryNo"] = '%';
            Session["DRAFTIQUIRY_BeneficiaryName"] = '%';
            Session["DRAFTIQUIRY_STARDRAFTNO"] = '%';
            Session["DRAFTIQUIRY_STATIONNAME"] = '%';
            Session["DRAFTIQUIRY_REMITTANCENO"] = '%';
            Session["DRAFTIQUIRY_SPDS_TYPE"] = '%';
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
            Session["DRAFTIQUIRY_RemitterNo"] = "%" + TXT_RemitterNO.Text; // +"%";
            Session["DRAFTIQUIRY_RemitterName"] = "%" + TXT_RemitterName.Text; // + "%";
            Session["DRAFTIQUIRY_BeneficiaryNo"] = "%" + TXT_BENEFICIARY_NO.Text; // + "%";
            Session["DRAFTIQUIRY_BeneficiaryName"] = "%" + TXT_BENEFICIARY_NAME.Text; // + "%";
            Session["DRAFTIQUIRY_STARDRAFTNO"] = "%" + TXT_STARDRAFT_NO.Text; // + "%";
            Session["DRAFTIQUIRY_STATIONNAME"] = "%" + TXT_STATION_NAME.Text; // + "%";
            Session["DRAFTIQUIRY_PODNO"] = "%" + TXT_PODNO.Text; // + "%";
            Session["DRAFTIQUIRY_REMITTANCENO"] = "%" + TXT_REMITTANCE_NO.Text; // + "%";
            Session["DRAFTIQUIRY_SPDS_TYPE"] = "%" + TXT_SPDS_TYPE.Text; // + "%";
            Session["DRAFTIQUIRY_DRAFTNO"] = "%" + TXT_DRAFTNO.Text; // + "%";
        }
        else if (e.Item.ToolTip == "Refresh")
        {
            TXT_RemitterNO.Text =
            TXT_RemitterName.Text =
            TXT_BENEFICIARY_NO.Text =
            TXT_BENEFICIARY_NAME.Text =
            TXT_STARDRAFT_NO.Text =
            TXT_STATION_NAME.Text =
            TXT_PODNO.Text =
            TXT_REMITTANCE_NO.Text =
            TXT_SPDS_TYPE.Text =
            TXT_DRAFTNO.Text = "";
        }
    }
}

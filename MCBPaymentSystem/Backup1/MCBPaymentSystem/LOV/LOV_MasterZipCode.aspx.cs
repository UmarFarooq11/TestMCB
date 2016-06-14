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

public partial class MasterZipCodeSetup_frmRPS_MasterZipCode : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
         Response.Cache.SetCacheability(HttpCacheability.ServerAndNoCache);
         if (IsPostBack == false)
         {
             Session["RPS_MasterZipCode_ID"] = "%";
             Session["RPS_MasterZipCode_ZipCode"] = "%";

             Session["LOV_ID"] = "0"; 
             Session["LOV_CODE"] = "0";


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
     
            Session["RPS_MasterZipCode_ID"] = GridView1.DataKeys[this.GridView1.SelectedIndex].Value.ToString();
            Session["RPS_MasterZipCode_ZipCode"] = GridView1.SelectedRow.Cells[1].Text;

            Session["LOV_ID"] = GridView1.DataKeys[this.GridView1.SelectedIndex].Value.ToString();
            Session["LOV_CODE"] = GridView1.SelectedRow.Cells[1].Text;

            Response.Redirect("../MasterZipCodeSetup/frmRPS_MasterZipCodeSPC.aspx");

    }
    private void AlphaSelection1_CK(object sender, EventArgs e)
    {
        DRP_LIST.Items.Clear();
        LBL_GridStatus.Text = "Page(s): 0-0";
        LBL_RowStatus.Text = "Display Row(s): 0-0";
        if (RD_CourierID.Checked == true)
        {
            Session["RPS_MasterZipCode_CourierID"] = AlphaSelection1.AlphaClick + '%';
            Session["RPS_MasterZipCode_StationID"] = '%';
            Session["RPS_MasterZipCode_ServiceID"] = '%';
            Session["RPS_MasterZipCode_BankID"] = '%';
            Session["RPS_MasterZipCode_BranchID"] = '%';
            Session["RPS_MasterZipCode_ZipCode"] = '%';
        }
        if (RD_StationID.Checked == true)
        {
            Session["RPS_MasterZipCode_CourierID"] = '%';
            Session["RPS_MasterZipCode_StationID"] = AlphaSelection1.AlphaClick + '%';
            Session["RPS_MasterZipCode_ServiceID"] = '%';
            Session["RPS_MasterZipCode_BankID"] = '%';
            Session["RPS_MasterZipCode_BranchID"] = '%';
            Session["RPS_MasterZipCode_ZipCode"] = '%';
        }
        //if (RD_ServiceID.Checked == true)
        //{
        //    Session["RPS_MasterZipCode_CourierID"] = '%';
        //    Session["RPS_MasterZipCode_StationID"] = '%';
        //    Session["RPS_MasterZipCode_ServiceID"] = AlphaSelection1.AlphaClick + '%';
        //    Session["RPS_MasterZipCode_BankID"] = '%';
        //    Session["RPS_MasterZipCode_BranchID"] = '%';
        //    Session["RPS_MasterZipCode_ZipCode"] = '%';
        //}
        if (RD_BankID.Checked == true)
        {
            Session["RPS_MasterZipCode_"] = '%';
            Session["RPS_MasterZipCode_StationID"] = '%';
            Session["RPS_MasterZipCode_ServiceID"] = '%';
            Session["RPS_MasterZipCode_BankID"] = AlphaSelection1.AlphaClick + '%';
            Session["RPS_MasterZipCode_BranchID"] = '%';
            Session["RPS_MasterZipCode_ZipCode"] = '%';
        }
        if (RD_BranchID.Checked == true)
        {
            Session["RPS_MasterZipCode_CourierID"] = '%';
            Session["RPS_MasterZipCode_StationID"] = '%';
            Session["RPS_MasterZipCode_ServiceID"] = '%';
            Session["RPS_MasterZipCode_BankID"] = '%';
            Session["RPS_MasterZipCode_BranchID"] = AlphaSelection1.AlphaClick + '%';
            Session["RPS_MasterZipCode_ZipCode"] = '%';
        }
        //if (RD_ZipCode.Checked == true)
        //{
        //    Session["RPS_MasterZipCode_CourierID"] = '%';
        //    Session["RPS_MasterZipCode_StationID"] = '%';
        //    Session["RPS_MasterZipCode_ServiceID"] = '%';
        //    Session["RPS_MasterZipCode_BankID"] = '%';
        //    Session["RPS_MasterZipCode_BranchID"] = '%';
        //    Session["RPS_MasterZipCode_ZipCode"] = AlphaSelection1.AlphaClick + '%';
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
       
        if (e.Item.ToolTip == "Search")
        {
            Session["RPS_MasterZipCode_CourierID"] = "%" + TXT_COURIER_NAME.Text+ "%";
            Session["RPS_MasterZipCode_StationID"] = "%" + TXT_STATION_NAME.Text + "%";
            Session["RPS_MasterZipCode_ServiceID"] = "%";
            Session["RPS_MasterZipCode_BankID"] = "%" + TXT_BANK_NAME.Text + "%";
            Session["RPS_MasterZipCode_BranchID"] = "%" + TXT_BRANCH_NAME.Text + "%";
            Session["RPS_MasterZipCode_ZipCode"] = "%" + TXT_ZipCode.Text + "%";
        }
        else if (e.Item.ToolTip == "Refresh")
        {
           
            TXT_ZipCode.Text = "";
            TXT_COURIER_NAME.Text = "";
            TXT_STATION_NAME.Text = "";
            TXT_BANK_NAME.Text = "";
            TXT_BRANCH_NAME.Text = "";
        }
    }
}

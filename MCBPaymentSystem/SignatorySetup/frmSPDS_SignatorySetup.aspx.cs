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

public partial class SignatorySetup_frmSPDS_SignatorySetup : System.Web.UI.Page
{
    string[] ARY;
    string RGS_SUPPORT;

    protected void Page_Load(object sender, EventArgs e)
    {
        /* ToolBar1.Items[0].Disabled = false;
           ToolBar1.Items[1].Disabled = false;
           ToolBar1.Items[2].Disabled = false;
        */
        //Response.Redirect("../BlankPage.aspx");
        Response.Cache.SetCacheability(HttpCacheability.ServerAndNoCache);
        Session["RGS"] = "00000";
        String ST = Startup_Util.DcryptionPWD(Request.QueryString[0].ToString());
        ARY = ST.Split('~');
        Session["RGS"] = ARY[0].ToString();
        RGS_SUPPORT = Session["RGS"].ToString();
        if (RGS_SUPPORT.Substring(0, 1) == "0")
        {
            BTN_NEW.Enabled = false; /*ADD*/
        }
        else if (RGS_SUPPORT.Substring(0, 1) == "1")
        {
            BTN_NEW.Enabled = true;/*ADD*/
        }
        if (RGS_SUPPORT.Substring(3, 1) == "0")
        {
            Response.Redirect("../MasterPage/Default2.aspx"); /*QUERY*/
            MessageClass.MessageBox.Show("Access Deined");
        }
        //if (RGS_SUPPORT.Substring(0, 1) == "0")
        //{ ToolBar1.Items[0].Disabled = true; /*ADD*/}
        //else if (RGS_SUPPORT.Substring(0, 1) == "1")
        //{ ToolBar1.Items[0].Disabled = false; /*ADD*/}

        //if (RGS_SUPPORT.Substring(3, 1) == "0")
        //{ ToolBar1.Items[1].Disabled = true; /*QUERY*/}
        //else if (RGS_SUPPORT.Substring(3, 1) == "1")
        //{ ToolBar1.Items[1].Disabled = false; /*QUERY*/}
        //ToolBar1.Items[2].Disabled = false;
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
            Session["ROWID"] = GridView1.DataKeys[this.GridView1.SelectedIndex].Value.ToString();
            Session["SPDS_SignatorySetup_ID"] = GridView1.DataKeys[this.GridView1.SelectedIndex].Value.ToString();
            Session["SPDS_SignatorySetup_SIGNATORY_NAME"] = GridView1.SelectedRow.Cells[1].Text;
            Response.Redirect("../SignatorySetup/frmSPDS_SignatorySetupSPC.aspx" + "?" + "s1=" + Request.QueryString[0].ToString() + "&CHK=abc");
        }
    }
    private void AlphaSelection1_CK(object sender, EventArgs e)
    {
        //if (RD_ID.Checked == true)
        //{
        //    Session["ID"] = AlphaSelection1.AlphaClick + '%';
        //    Session["SIGNATORY_NAME"] = '%';
        //}
        if (RD_SIGNATORY_NAME.Checked == true)
        {
            Session["SPDS_SignatorySetup_SIGNATORY_NAME"] = AlphaSelection1.AlphaClick + '%';
            Session["SPDS_SignatorySetup_ID"] = '%';
        }
    }
    protected void SP_DPS_City_Info_ALL_Selected(object sender, ObjectDataSourceStatusEventArgs e) { }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        Others1.GridMouseOver(Session["ThemeChange"].ToString(), e);
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
            Session["SPDS_SignatorySetup_ID"] = "0";
            Session["SIGNATORY_NAME"] = "%";
            Session["UPLOAD_IMAGE_PATH"] = "%";
            Session["UPLOAD_IMAGE"] = "%";
            Session["CURRENT_STATUS"] = "%";
            Session["A_userID"] = "%";
            Session["A_DateTime"] = "%";
            Session["E_UserID"] = "%";
            Session["E_DateTime"] = "%";
            Response.Redirect("../SignatorySetup/frmSPDS_SignatorySetupSPC.aspx" + "?" + "s1=" + Request.QueryString[0].ToString());
        }
        else if (e.Item.ToolTip == "Search")
        {
            Session["SPDS_SignatorySetup_ID"] = "%" + TXT_ID.Text + "%";
            Session["SPDS_SignatorySetup_SIGNATORY_NAME"] = "%" + TXT_SIGNATORY_NAME.Text + "%";
        }
        else if (e.Item.ToolTip == "Refresh")
        {
            TXT_ID.Text = "";
            TXT_SIGNATORY_NAME.Text = "";
        }
    }
    protected void BTN_NEW_Click(object sender, EventArgs e)
    {
        Session["SPDS_SignatorySetup_ID"] = "0";
        Session["SIGNATORY_NAME"] = "%";
        Session["UPLOAD_IMAGE_PATH"] = "%";
        Session["UPLOAD_IMAGE"] = "%";
        Session["CURRENT_STATUS"] = "%";
        Session["A_userID"] = "%";
        Session["A_DateTime"] = "%";
        Session["E_UserID"] = "%";
        Session["E_DateTime"] = "%";
        //Response.Redirect("../SignatorySetup/frmSPDS_SignatorySetupSPC.aspx" + "?" + "s1=" + Request.QueryString[0].ToString());
        Response.Redirect("../SignatorySetup/SignatorySetup.aspx?s1=" + Request.QueryString[0].ToString());
    }
    protected void BTN_SEARCH_Click(object sender, EventArgs e)
    {
        Session["SPDS_SignatorySetup_ID"] = "%" + TXT_ID.Text + "%";
        Session["SPDS_SignatorySetup_SIGNATORY_NAME"] = "%" + TXT_SIGNATORY_NAME.Text + "%";

    }
    protected void BTN_CLEAR_Click(object sender, EventArgs e)
    {

        TXT_ID.Text = "";
        TXT_SIGNATORY_NAME.Text = "";
    }
}
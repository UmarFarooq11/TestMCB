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

public partial class Forms_LOV_CustomerBank : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    string sql, CustomerCode, CustomerName, WebService;
    DatabaseConnection_Util obj_database = new DatabaseConnection_Util();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            sql = "select p.*,'0' webservice from rps_bank p where serviceTypeid = '1'";
            try
            {
                DataSet Cacheds = new DataSet();
                Cacheds = obj_database.Local_GetDataSet1(sql);
                if (Cacheds.Tables[0].Rows.Count > 0)
                {
                    //Session["Webservice"] = Cacheds.Tables[0].Rows[0]["webservice"];
                    grvBank.DataSource = Cacheds.Tables[0];
                    grvBank.DataBind();
                }
                else
                {
                    int TotalColumns = grvBank.Rows[0].Cells.Count;
                    grvBank.Rows[0].Cells.Clear();
                    grvBank.Rows[0].Cells.Add(new TableCell());
                    grvBank.Rows[0].Cells[0].ColumnSpan = TotalColumns;
                    grvBank.Rows[0].Cells[0].Font.Bold = true;
                    grvBank.Rows[0].Cells[0].Text = "No Record Found";
                }
            }
            catch (Exception ex)
            {
                
            }
        }
        CustomerCode = Request.QueryString["Custombercode"];
        CustomerName = Request.QueryString["CustomerName"];
    }
    protected void grvBank_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "View")
        {
            GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
            string RowCustomerName = row.Cells[1].Text;

            if (Request.QueryString.Count > 1)
            {
                Response.Write("<script language=javascript>window.opener.document.all('" + CustomerCode+ "').value='" + e.CommandArgument
                   + "';window.opener.document.all('" + CustomerName
                   + "').value='" + RowCustomerName +
                   "';window.opener.document.all('" + CustomerCode + "').focus;self.close();</script>");
            }
            else
            {
                Response.Write("<script language=javascript>window.opener.document.all('" + CustomerCode + "').value='" + e.CommandArgument + "';window.opener.document.all('" + CustomerCode + "').focus;self.close();</script>");
            }
        }
    }
    protected void grvBank_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton lnkabc = (LinkButton)(e.Row.FindControl("lnkCode"));
        }
    }
}

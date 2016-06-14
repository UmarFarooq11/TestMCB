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

public partial class Forms_LOV_Bank : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    string sql;//, Bankcode, Bankname;
    string Province;
    //Database obj_database = new Database();
    LOV_COLLECTION lov = new LOV_COLLECTION();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //sql = "SELECT BANK_CODE,BANK_NAME FROM SETUP_BANK where authorizer is not null and closed = 0 ORDER BY BANK_NAME";
            //ds = obj_database.Local_GetDataSet(sql);
            //grvBank.DataSource = ds.Tables[0];
            //grvBank.DataBind();
            if (Cache["ProvinceCache"] == null)
            {
                try
                {
                    DataSet Cacheds = new DataSet();
                    //Cacheds = obj_database.Local_GetDataSet1(sql);
                    Cacheds = lov.LOV_BENEADDRESS("ALL");
                    if (Cacheds.Tables[0].Rows.Count > 0)
                    {
                        grvBank.DataSource = Cacheds.Tables[0];
                        grvBank.DataBind();
                        System.Web.HttpContext.Current.Cache.Insert("ProvinceCache", Cacheds.Tables[0], null, System.DateTime.Now.AddDays(1), TimeSpan.Zero);
                    }
                    else
                    {
                        Cacheds.Tables[0].Rows.Add(Cacheds.Tables[0].NewRow());
                        grvBank.DataSource = Cacheds.Tables[0];
                        grvBank.DataBind();

                        int TotalColumns = grvBank.Rows[0].Cells.Count;
                        grvBank.Rows[0].Cells.Clear();
                        grvBank.Rows[0].Cells.Add(new TableCell());
                        grvBank.Rows[0].Cells[0].ColumnSpan = TotalColumns;
                        grvBank.Rows[0].Cells[0].Font.Bold = true;
                        grvBank.Rows[0].Cells[0].Text = "No Record Found";
                    }
                }
                catch (Exception exxx)
                {

                    //throw;
                }
            }
            else
            {
                DataTable dt = (DataTable)Cache["ProvinceCache"];
                grvBank.DataSource = dt;
                grvBank.DataBind();
            }
        }
        Province = Request.QueryString["Province"];
        //Bankname = Request.QueryString["Bankname"];
    }
    protected void grvBank_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "View")
        {
            //string sql1;
            //sql1 = "SELECT BANK_NAME FROM SETUP_BANK where BANK_CODE = '" + e.CommandArgument + "' and authorizer is not null and closed = 0";
            //ds = new DataSet();
            //GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
            //string RowBankName = row.Cells[1].Text;
            // ds.Tables[0].Rows[0][0];
            if (Request.QueryString.Count > 1)
            {
                //ds = obj_database.Local_GetDataSet(sql1);
                //Response.Write("<script language=javascript>window.opener.document.all('" + ACTIVITY_REF + "').value='" + e.CommandArgument + "';window.opener.document.all('" + Bankname + "').value='" + RowBankName + "';window.opener.document.all('" + Bankcode + "').focus;self.close();</script>");
                Response.Write("<script language=javascript>window.opener.document.all('" + Province + "').value='" + e.CommandArgument + "';window.opener.document.all('" + Province + "').focus;self.close();</script>");
            }
            else
                Response.Write("<script language=javascript>window.opener.document.all('" + Province + "').value='" + e.CommandArgument + "';window.opener.document.all('" + Province + "').focus;self.close();</script>");
        }


        //If e.CommandName = "View" Then
        //    SQL = "select name from RM_OUTLET where outletcode='" & e.CommandArgument & "'"
        //    ds = obj_Param.GetDataSet(SQL)
        //    Dim desc As String = ds.Tables(0).Rows(0)(0)
        //    'Response.Write("<script language=javascript>alert('before');window.opener." & formname & ".item('" & controlName & "').value = '123';alert('after');self.close();</script>")
        //    Response.Write("<script language=javascript>window.opener.document.all('" & controlName & "').value='" & e.CommandArgument & "';window.opener.document.all('" & controlName & "').focus;self.close();</script>")

        //End If




    }
    protected void grvBank_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton lnkabc = (LinkButton)(e.Row.FindControl("LinkButton1"));
        }
    }
}

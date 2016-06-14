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

public partial class NRDetailStatementReport : System.Web.UI.Page
{
    LOV_COLLECTION lov = new LOV_COLLECTION();
    DataTable dt = new DataTable();
    protected void Page_PreInit(object sender, EventArgs e)
    {
        Page.Theme = Session["ThemeChange"].ToString();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        if (Request.QueryString["UID"] != null)
        {
            Session["U_NAME"] = Request.QueryString["UID"].ToString();
        }
        else
        {
            if (Session["U_NAME"] == null)
            {
                String PR_id = Request.QueryString["ProjectID"].ToString();
                ds = lov.SP_GETDATA_DPAGE(PR_id);
                Response.Redirect(ds.Tables[0].Rows[0]["DPage"].ToString());
            }
        }

        string msg = Request.QueryString["msg"];
        if (msg != "")
        {
            lblmessage.Text = msg;
        }
        if (!IsPostBack)
        {
            //ViewState["CompanyCode"] = "";
            //GetCompany();
        }
    }
    //public void GetCompany()
    //{
    //    DataSet ds = new DataSet();
    //    DataSet dsC = new DataSet();
    //    DataTable dt = new DataTable();
    //    dsC = lov.SP_GET_COMPANYNAME(Session["U_NAME"].ToString());
    //    if (dsC.Tables[0].Rows.Count > 0)
    //    {
    //        ViewState["CompanyCode"] = dsC.Tables[0].Rows[0]["company_code"].ToString();
    //    }
    //    else
    //    {
    //        ViewState["CompanyCode"] = "";
    //        lblMessage.Text = "Company code not define against User ID.";
    //    }
    //}
    protected void btn_OK_Click(object sender, EventArgs e)
    {
        //string company_code = ViewState["CompanyCode"].ToString();
        string fromDate = TXT_FROM.Text == "" ? DateTime.Now.ToString("dd-MM-yyyy") : TXT_FROM.Text;
        string toDate = TXT_TO.Text == "" ? DateTime.Now.ToString("dd-MM-yyyy") : TXT_TO.Text;
        Response.Redirect("NRDetailStatementRpt.aspx?fromdate=" + fromDate + "&todate=" + toDate + "&usr_name=" + Session["U_NAME"].ToString());

        #region
        //DataSet dsbal = new DataSet();
        //dsbal = lov.SP_COMPANY_BALANCE(companycode);
        ////if (dsbal.Tables[0].Rows.Count >0)
        ////{
        ////    balance = dsbal.Tables[0].Rows[0]["BALANCE_AMOUNT"].ToString();
        ////    balance = Convert.ToDouble(balance).ToString("###,###,#0.00");
        ////}
        //Response.Redirect("FileLogRpt.aspx?companycode=" + companycode + "&fromdate=" + fromDate + "&todate=" + toDate + "&companytype=" + companytype);

        
        //Response.Write("<script type=text/javascript>window.open('NRdetailStatementRpt.aspx??fromdate=" + fromDate + "&&todate=" + toDate + "', 'CS', 'left=0,top=0,height= screen.availHeigh, width= screen.availWidth,menubar=no,location=no,toolbar=no,scrollbars=yes,resizable=yes');return false;</script>");
        //Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "FileLogRpt", "window.open('NRdetailStatementRpt.aspx??fromdate=" + fromDate + "&&todate=" + toDate +"', 'CS', 'left=0,top=0,height=screen.availHeigh, width=screen.availWidth,menubar=no,location=no,toolbar=no,scrollbars=yes,resizable=yes');", true);
        //Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "FileLogRpt", "window.open('NRdetailStatementRpt.aspx??fromdate=" + fromDate + "&&todate=" + toDate +"', 'CS', 'left=0,top=0, height='+ screen.availHeigh +', width='+ screen.availWidth +',menubar=no,location=no,toolbar=no,scrollbars=yes,resizable=yes');", true);
        //Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "FileLogRpt", "window.open('NRdetailStatementRpt.aspx??fromdate=" + fromDate + "&&todate=" + toDate + "', 'CS', 'left=0,top=0, height= '+ screen.availHeight +' , width= '+ screen.availWidth +',menubar=no,location=no,toolbar=no,scrollbars=nO,resizable=no');", true);
        #endregion

    }


}

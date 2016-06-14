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
using System.Data.OracleClient;

public partial class Default2 : System.Web.UI.Page
{
    DatabaseConnection_Util _dbConfig = new DatabaseConnection_Util();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //rpt.DataSource = BindGrid();
            //rpt.DataBind();
            //sort_table.DataSource = BindGrid();
            //sort_table.DataBind();
            loadGrid();
        }
    }
    private void loadGrid()
    {
        DataSet ds = new DataSet();
        OracleParameter[] parms = new OracleParameter[10];

        int pno = 0;
        parms[pno] = new OracleParameter();
        parms[pno] = _dbConfig.Oracle_Param("P_company_code", OracleType.VarChar, ParameterDirection.Input, "RIA");
        pno++;

        parms[pno] = new OracleParameter();
        parms[pno] = _dbConfig.Oracle_Param("P_FILE_NAME", OracleType.VarChar, ParameterDirection.Input, "after Ac Completion - 1.xls");
        pno++;

        parms[pno] = new OracleParameter();
        parms[pno] = _dbConfig.Oracle_Param("P_Trans_type", OracleType.VarChar, ParameterDirection.Input, "");
        pno++;

        parms[pno] = new OracleParameter();
        parms[pno] = _dbConfig.Oracle_Param("P_Rowid", OracleType.VarChar, ParameterDirection.Input, "");
        pno++;

        parms[pno] = new OracleParameter();
        parms[pno] = _dbConfig.Oracle_Param("p_bank_code", OracleType.VarChar, ParameterDirection.Input, "");
        pno++;

        parms[pno] = new OracleParameter();
        parms[pno] = _dbConfig.Oracle_Param("p_branch_code", OracleType.VarChar, ParameterDirection.Input, "");
        pno++;

        parms[pno] = new OracleParameter();
        parms[pno] = _dbConfig.Oracle_Param("P_Userid", OracleType.VarChar, ParameterDirection.Input, "");
        pno++;

        parms[pno] = new OracleParameter();
        parms[pno] = _dbConfig.Oracle_Param("P_type", OracleType.VarChar, ParameterDirection.Input, "03");
        pno++;

        parms[pno] = new OracleParameter();
        parms[pno] = _dbConfig.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        pno++;

        parms[pno] = new OracleParameter();
        parms[pno] = _dbConfig.Oracle_Param("v_retval", OracleType.VarChar, ParameterDirection.Output, "");

        ds = _dbConfig.Oracle_GetDataSetSP("SP_Data_Segregation", parms);

        if (parms[pno].Value.ToString() == "")
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataTable dt = new DataTable();
                //ds.Tables[0].Columns.Add("value");
                //ds.Tables[0].Columns.Add("desc");
                dt = ds.Tables[0];
                ViewState["TaskTable"] = dt;
                sort_table.DataSource = ds;
                sort_table.PageSize = 20;
                //sort_table.Width = 50;
                sort_table.DataBind();
                //lblMessage.Text = "";
                // rpt.DataSource = ds;
                // rpt.DataBind();

                //lblTransaction.Text = ds.Tables[0].Rows.Count.ToString();
                //btnSubmit.Attributes.Add("style", "visibility:visible;");
                //lblFieldTrans.Attributes.Add("style", "visibility:visible;");
                //lblTransaction.Attributes.Add("style", "visibility:visible;");
            }
            else
            {
                //btnSubmit.Attributes.Add("style", "visibility:hidden;");
                sort_table.DataSource = null;
                sort_table.DataBind();
                //lblMessage.Text = "No data found.";
                //lblTransaction.Text = ds.Tables[0].Rows.Count.ToString();
                //lblFieldTrans.Attributes.Add("style", "visibility:hidden;");
                //lblTransaction.Attributes.Add("style", "visibility:hidden;");
            }
        }
        else
        {

        }
        #region
        //if (grdTransaction.Rows.Count <= 0)
        //{
        //    DataRow dr = ds.Tables[0].NewRow();
        //    ds.Tables[0].Rows.Add(dr);

        //    this.grdTransaction.DataSource = ds.Tables[0];
        //    this.grdTransaction.DataBind();

        //    this.grdTransaction.Rows[0].Cells.Clear();
        //    this.grdTransaction.Rows[0].Cells.Add(new TableCell());
        //    this.grdTransaction.Rows[0].Cells[0].ColumnSpan = grdTransaction.Rows[0].Cells.Count;
        //    this.grdTransaction.Rows[0].Cells[0].Text = "No Record found.";
        //}    
        #endregion
    }
    public DataSet BindGrid()
    {
        DataSet ds = new DataSet();
        OracleConnection conn = new OracleConnection("data source=nt;user id = scott;password=aa;");
        OracleDataAdapter adp = new OracleDataAdapter("select * from emp", conn);
        adp.Fill(ds);
        adp.Dispose();
        return ds;
    }
    protected void rpt_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item)
        {
            ((ImageButton)e.Item.FindControl("ImageButton1")).Attributes.Add("onclick", "rowsIndex('" + e.Item.ItemIndex + "');");
        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        //int i = Convert.ToInt16(hdRows.Value);
        //Session["value"] = "25";
        //((TextBox)rpt.Items[i].FindControl("TextBox1")).Text = Session["value"].ToString();
    }
}

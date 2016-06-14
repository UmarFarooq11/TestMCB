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
using System.IO;

public partial class UniversalUploadProcess_frmSPDS_UniversalUploadCofigurationSPC : System.Web.UI.Page
{
    FormViewRow D_TEMP;
    TextBox TXT;
    Label LL;
    String UniversalUploadID = "";
    PROCESS_SPDS_UniversalUploadCofiguration P_SPDS_UniversalUploadCofiguration = new PROCESS_SPDS_UniversalUploadCofiguration();
    LOV_COLLECTION lov = new LOV_COLLECTION();


    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == false)
        {
            FormView1.ChangeMode(FormViewMode.Insert);
            ((Label)FormView1.Row.FindControl("Label_HEAD")).Text = "Universal Upload Process";
        }
    }
    protected void FormView1_PageIndexChanging(object sender, FormViewPageEventArgs e) { }
    private void BackPage()
    {
        ((TextBox)FormView1.FindControl("TXT_ConfigurationName_INSERT")).Text = "";
        ((ListBox)FormView1.FindControl("ListBox1")).Items.Clear();
    }
    protected void Page_PreInit(object sender, EventArgs e)
    { Page.Theme = Session["ThemeChange"].ToString(); }
    protected void DisplayToolBar_ItemClick(object sender, EO.Web.ToolBarEventArgs e)
    {
    }
    protected void EditToolbar_ItemClick(object sender, EO.Web.ToolBarEventArgs e)
    {
    }
    protected void InsertToolbar_ItemClick(object sender, EO.Web.ToolBarEventArgs e)
    {
        if (e.Item.ToolTip == "Start Process")
        {
            StreamReader sr = new StreamReader(((ListBox)FormView1.FindControl("ListBox1")).SelectedValue);
            string line = sr.ReadLine();
            string[] v;
            string QRY="";
            DataSet ds = new DataSet();
            ds = lov.Get_SPDS_UniversalUploadCofiguration_SPC(Session["LOV_ID"].ToString());
            DataSet ds2 = new DataSet();
            ds2 = lov.Get_SPDS_UniversalUploadCofigurationDetail_ALL(Session["LOV_ID"].ToString());
            do
            {
                v = line.Split(',');
                //QRY = "Insert into " + ds.Tables[0].Rows[0]["ObjectName"].ToString() + " ( ";
                QRY = "Insert into CMN_COURIER ( ";
                for (int x = 0; x < ds2.Tables[0].Rows.Count; x++)
                {
                    QRY += ds2.Tables[0].Rows[x]["ColumnName"].ToString() + ", ";
                }
                QRY = QRY.Substring(0, QRY.Length - 2) + " ) Values ( ";

                foreach (string datavalue in v)
                {
                    //QRY += "'" + datavalue + "', ";
                    //QRY += "\"" + datavalue + "\"" + ",";
                    QRY += Convert.ToChar(39) + datavalue + Convert.ToChar(39) + ", ";
                    //QRY += Convert.ToChar(34) + datavalue + Convert.ToChar(34) + ", ";
                }
                QRY = QRY.Substring(0, QRY.Length - 2) + " )";
                //QRY.Replace ("\","");
                DataSet dum;
                dum = lov.Set_SP_SPDS_UniversalFileUpload(QRY);
                //((TextBox)FormView1.FindControl("TextBox1")).Text += line;
                ((TextBox)FormView1.FindControl("TextBox1")).Text += QRY + Convert.ToChar(13);
                line = sr.ReadLine();
            }
            while (line != null);
        }
        else if (e.Item.ToolTip == "Cancel")
        { BackPage(); }
    }

    protected void BTN_Configuration_INSERT_Click(object sender, ImageClickEventArgs e)
    {
        if (Session["LOV_ID"] != "")
        {
            UniversalUploadID = Session["LOV_ID"].ToString();
            ((TextBox)FormView1.FindControl("TXT_ConfigurationName_INSERT")).Text = Session["LOV_DESCRIPTION"].ToString();
            ((ListBox)FormView1.FindControl("ListBox1")).Items.Clear();
            DataSet ds = new DataSet();
            ds = lov.Get_SPDS_UniversalUploadCofiguration_SPC(Session["LOV_ID"].ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                string[] fle;
                if (ds.Tables[0].Rows[0]["FileFormat"].ToString() == "1")
                { fle = Directory.GetFiles(ds.Tables[0].Rows[0]["FilePath"].ToString(), "*.xls"); }
                else if (ds.Tables[0].Rows[0]["FileFormat"].ToString() == "2")
                { fle = Directory.GetFiles(ds.Tables[0].Rows[0]["FilePath"].ToString(), "*.csv"); }
                else if (ds.Tables[0].Rows[0]["FileFormat"].ToString() == "3")
                { fle = Directory.GetFiles(ds.Tables[0].Rows[0]["FilePath"].ToString(), "*.txt"); }
                else
                { fle = Directory.GetFiles(ds.Tables[0].Rows[0]["FileFormat"].ToString(), "*.*"); }
                foreach (string x in fle)
                {
                    ((ListBox)FormView1.FindControl("ListBox1")).Items.Add(x);
                }
            }
        }
    }
    
}

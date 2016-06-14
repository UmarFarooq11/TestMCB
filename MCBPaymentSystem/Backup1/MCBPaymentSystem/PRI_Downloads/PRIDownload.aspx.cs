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
using iCORE.RPS.BUSINESSOBJECTS.ENTITIES;
using iCORE.RPS.DATAOBJECTS;
using iCORE.RPS.BUSINESSOBJECTS.CONTROLLER;
using iCORE.RPS.PRESENTATIONOBJECTS.Cmn;
using iCORE.RPS.BUSINESSOBJECTS.PARSERS;
using iCORE.XMS.DATAOBJECTS;


public partial class PRIDownload : System.Web.UI.Page
{
    DatabaseConnection_Util DB = new DatabaseConnection_Util();
    string[] test=new string[15];
    string data = "";
    LOV_COLLECTION LOV = new LOV_COLLECTION();
    FileOp FO = new FileOp();
    protected void Page_PreInit(object sender, EventArgs e)
    { Page.Theme = Session["ThemeChange"].ToString(); }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (GridView1.Rows.Count == 0)
        {
            lbl_Message.Text = "No Data Found";
        }    
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {

    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        string ID = GridView1.DataKeys[this.GridView1.SelectedIndex].Value.ToString();
        DataSet DS = LOV.SP_PRIFilePath();

        //string TFile = DS.Tables[0].Rows[0][2].ToString() + GridView1.SelectedRow.Cells[2].Text + "_" + DateTime.Now.Ticks.ToString() + ".TXT";
        string TFile = DS.Tables[0].Rows[0][2].ToString() + "PRI_03_" + GridView1.SelectedRow.Cells[0].Text + "_" +
        DateTime.Now.ToString("ddMMyyyy") + "_" + DateTime.Now.ToString("HHMM") + ".TXT";
        DataSet dsContent = LOV.PRIDownload(ID);

        string text = "";

        if ((dsContent.Tables.Count > 0) && (dsContent.Tables[0].Rows.Count > 0))
        {
            for (int rowIndex = 0; rowIndex <= dsContent.Tables[0].Rows.Count - 1; rowIndex++)
            {
                text += dsContent.Tables[0].Rows[rowIndex][6].ToString();
                text += System.Environment.NewLine;
            }

            text += dsContent.Tables[0].Rows[0][1].ToString();
            text += dsContent.Tables[0].Rows[0][0].ToString();

            text += dsContent.Tables[0].Rows[0][4].ToString();
            text += dsContent.Tables[0].Rows[0][5].ToString();

            //S1 = S1 + System.Environment.NewLine;
            //S1 = S1 + DS1.Tables[0].Rows[0][4].ToString();
            //S1 = S1 + System.Environment.NewLine;
            //S1 = S1 + DS1.Tables[0].Rows[0][5].ToString();
            //S1 = S1 + System.Environment.NewLine;

            if (TFile.StartsWith("ftp://"))
            {
                string a = FO.FTPFileWriter(TFile, text, Session["FTPUserID"].ToString(), Session["FTPPASSWORD"].ToString());
                lbl_Message.Text = "File Transfer on " + TFile;

                /*****************************PRI UPLOAD SAMPLE COPY ON ITS OUT*******************************/
                string TFile1 = "";
                TFile1 = DS.Tables[0].Rows[0][1].ToString() + GridView1.SelectedRow.Cells[2].Text + "_" + DateTime.Now.Ticks.ToString() + ".TXT";
                DataSet DS11 = new DataSet();
                DS11 = LOV.PRIUploadSample(GridView1.DataKeys[this.GridView1.SelectedIndex].Value.ToString());
                string S2 = "";
                S2 = S2 + DS11.Tables[0].Rows[0][0].ToString();
                S2 = S2 + System.Environment.NewLine;
                S2 = S2 + DS11.Tables[0].Rows[0][1].ToString();
                S2 = S2 + System.Environment.NewLine;

                for (int rowIndex = 0; rowIndex <= DS11.Tables[0].Rows.Count - 1; rowIndex++)
                {
                    S2 = S2 + DS11.Tables[0].Rows[rowIndex][6].ToString();
                    S2 = S2 + System.Environment.NewLine;
                }
                S2 = S2 + System.Environment.NewLine;
                S2 = S2 + DS11.Tables[0].Rows[0][4].ToString();
                S2 = S2 + System.Environment.NewLine;
                S2 = S2 + DS11.Tables[0].Rows[0][5].ToString();
                S2 = S2 + System.Environment.NewLine;

                FO.FTPFileWriter(TFile1, S2, Session["FTPUserID"].ToString(), Session["FTPPASSWORD"].ToString());
                lbl_Message.Text = "File Transfer on " + TFile1;
                /*****************************PRI UPLOAD SAMPLE COPY ON ITS OUT*******************************/

                /*****************************PRI DOWNLOAD MARKING*******************************/
                LOV.PRIDownloadMarking(GridView1.DataKeys[this.GridView1.SelectedIndex].Value.ToString(),TFile);
                Response.Redirect("../PRI_Downloads/PRIDownload.aspx");
                /*****************************PRI DOWNLOAD MARKING*******************************/
            }
            else
            {
                lbl_Message.Text = "Invalid ftp path.";
            }
        }
        else
        {
            lbl_Message.Text = "PRI Download:No data found.";
        }
    }
}

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

public partial class InstrumentSetup_frmSPDS_InstrumentSetupSPC : System.Web.UI.Page
{
    FormViewRow D_TEMP;
    TextBox TXT;
    Label LL;
    LOV_COLLECTION LOV = new LOV_COLLECTION();
    PROCESS_SPDS_InstrumentSetup P_SPDS_InstrumentSetup = new PROCESS_SPDS_InstrumentSetup();
    FileProcessingSystem FPS = new FileProcessingSystem();

    string path = "";
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["SPDS_InstrumentSetup_ID"].ToString() == "0")
        {
            FormView1.ChangeMode(FormViewMode.Insert);
            ((Label)FormView1.Row.FindControl("Label_HEAD")).Text = "Instrument Setup";

        }
        else
        {
            ((Label)FormView1.FindControl("Label_HEAD")).Text = "Instrument Setup : " + Session["SPDS_InstrumentSetup_INSTRUMENT_NAME"].ToString();
            if (IsPostBack == false)
            {
                string RGS_SUPPORT;
                RGS_SUPPORT = Session["RGS"].ToString();

                if (RGS_SUPPORT.Substring(2, 1) == "0")
                {
                    if (FormView1.CurrentMode == FormViewMode.ReadOnly)
                    {
                        ((Button)FormView1.FindControl("BTN_EDIT")).Enabled = false; /*Edit*/
                        ((Button)FormView1.FindControl("CMD_AUTHORIZE")).Enabled = true; /*Authorize*/
                    }
                }
                else if (RGS_SUPPORT.Substring(2, 1) == "1")
                {
                    if (FormView1.CurrentMode == FormViewMode.ReadOnly)
                    {
                        ((Button)FormView1.FindControl("BTN_EDIT")).Enabled = true; /*Edit*/
                        // ((Button)FormView1.FindControl("CMD_AUTHORIZE")).Enabled = false; /*Authorize*/

                    }
                    ((Button)FormView1.FindControl("BTN_CANCEL")).Enabled = true; /*Edit*/
                }
                /*
                ((EO.Web.ToolBar)FormView1.FindControl("DisplayToolBar")).Items[0].Disabled = false;
                ((EO.Web.ToolBar)FormView1.FindControl("DisplayToolBar")).Items[2].Disabled = false;
                ((EO.Web.ToolBar)FormView1.FindControl("DisplayToolBar")).Items[4].Disabled = false;
                */
                //if (RGS_SUPPORT.Substring(2, 1) == "0")
                //{ ((EO.Web.ToolBar)FormView1.FindControl("DisplayToolBar")).Items[0].Disabled = true; /*Edit*/}
                //else if (RGS_SUPPORT.Substring(2, 1) == "1")
                //{ ((EO.Web.ToolBar)FormView1.FindControl("DisplayToolBar")).Items[0].Disabled = false; /*Edit*/}

                //if (RGS_SUPPORT.Substring(4, 1) == "0")
                //{
                //    ((EO.Web.ToolBar)FormView1.FindControl("DisplayToolBar")).Items[4].Disabled = true; /*Authorize / Unauthorize*/
                //    ((EO.Web.ToolBar)FormView1.FindControl("DisplayToolBar")).Items[2].Disabled = false;
                //}
                //else if (RGS_SUPPORT.Substring(4, 1) == "1")
                //{
                //    ((EO.Web.ToolBar)FormView1.FindControl("DisplayToolBar")).Items[4].Disabled = false; /*Authorize / Unauthorize*/
                //    ((EO.Web.ToolBar)FormView1.FindControl("DisplayToolBar")).Items[2].Disabled = false;
                //}

            }
        }
    }
    protected void FormView1_PageIndexChanging(object sender, FormViewPageEventArgs e) { }
    private void BackPage()
    {
        Session["SPDS_InstrumentSetup_ID"] = "0";
        Session["SPDS_InstrumentSetup_INSTRUMENT_NAME"] = "0";
        Session["SPDS_InstrumentSetup_RDLC_UPLOAD"] = "0";
        Session["SPDS_InstrumentSetup_RDLC_UPLOAD_PATH"] = "0";
        Session["SPDS_InstrumentSetup_A_UserID"] = "%";
        Session["SPDS_InstrumentSetup_A_DateTime"] = "%";
        Session["SPDS_InstrumentSetup_E_UserID"] = "%";
        Session["SPDS_InstrumentSetup_E_DateTime"] = "%";
        Response.Redirect("../InstrumentSetup/frmSPDS_InstrumentSetup.aspx" + "?" + "s1=" + Request.QueryString[0].ToString());
    }
    protected void Page_PreInit(object sender, EventArgs e)
    { Page.Theme = Session["ThemeChange"].ToString(); }
    protected void DisplayToolBar_ItemClick(object sender, EO.Web.ToolBarEventArgs e)
    {
        //if (e.Item.ToolTip == "Edit")
        //{ FormView1.ChangeMode(FormViewMode.Edit); }
        //else if (e.Item.ToolTip == "Cancel")
        //{ BackPage(); }
        //else if (e.Item.ToolTip == "Authorize / Unauthorize")
        //{
        //    LOV_COLLECTION L = new LOV_COLLECTION();
        //    DataSet DS;
        //    DS = L.SP_AuthorizeRecord("SPDS_InstrumentSetup", Session["U_NAME"].ToString(), DateTime.Now.ToString("MM-dd-yyyy"), Session["SPDS_InstrumentSetup_ID"].ToString());
        //    Response.Redirect("../InstrumentSetup/frmSPDS_InstrumentSetupSPC.aspx" + "?" + "s1=" + Request.QueryString[0].ToString());
        //}
    }
    protected void EditToolbar_ItemClick(object sender, EO.Web.ToolBarEventArgs e)
    {
        //string FileName = "";
        //string FilePath = "";
        //string fullPath = "";
        //string fullExtention = "";
        //Page.Validate();
        //if (e.Item.ToolTip == "Update")
        //{
        //    if (Page.IsValid)
        //    {

        //        LOV_COLLECTION L = new LOV_COLLECTION();
        //        DataSet DS;
        //        DS = L.SP_InstrumentSetup_DP(((TextBox)FormView1.FindControl("TXT_INSTRUMENT_NAME_EDIT")).Text, Session["SPDS_InstrumentSetup_ID"].ToString());
        //        if (DS.Tables[0].Rows.Count > 0)
        //        {
        //            ((Label)FormView1.FindControl("lblDuplicate_EDIT")).Text = "Duplicate Record";
        //        }
        //        else
        //        {
        //            if (DS.Tables[0].Rows.Count <= 0)
        //            {
        //                if (((FileUpload)FormView1.FindControl("TXT_RDLC_UPLOAD_PATH_EDIT")).HasFile == true)
        //                {
        //                    FileName = System.IO.Path.GetFileName(((FileUpload)FormView1.FindControl("TXT_RDLC_UPLOAD_PATH_EDIT")).PostedFile.FileName);
        //                    FilePath = System.IO.Path.GetDirectoryName(((FileUpload)FormView1.FindControl("TXT_RDLC_UPLOAD_PATH_EDIT")).PostedFile.FileName);
        //                    fullPath = System.IO.Path.GetFullPath(((FileUpload)FormView1.FindControl("TXT_RDLC_UPLOAD_PATH_EDIT")).PostedFile.FileName);
        //                    fullExtention = System.IO.Path.GetExtension(((FileUpload)FormView1.FindControl("TXT_RDLC_UPLOAD_PATH_EDIT")).PostedFile.FileName);
        //                    //{
        //                }
        //                else
        //                {
        //                    ((Label)FormView1.FindControl("lblDuplicate_EDIT")).Text = ("Select File First");
        //                }
        //                if (fullExtention.ToUpper() == ".RDLC")
        //                {
        //                    P_SPDS_InstrumentSetup.RecordInputStart();
        //                    P_SPDS_InstrumentSetup.Get_ID = Session["SPDS_InstrumentSetup_ID"].ToString();
        //                    P_SPDS_InstrumentSetup.Get_INSTRUMENT_NAME = ((TextBox)FormView1.FindControl("TXT_INSTRUMENT_NAME_EDIT")).Text;
        //                    P_SPDS_InstrumentSetup.Get_RDLC_UPLOAD = FileName;//((TextBox)FormView1.FindControl("TXT_RDLC_UPLOAD_EDIT")).Text;
        //                    P_SPDS_InstrumentSetup.Get_RDLC_UPLOAD_PATH = Server.MapPath("~") + "\\RDLCReports\\";
        //                    P_SPDS_InstrumentSetup.Get_A_UserID = "0";// ((TextBox)FormView1.FindControl("TXT_A_UserID_EDIT")).Text;
        //                    P_SPDS_InstrumentSetup.Get_A_DateTime = DateTime.Now.ToString("dd-MMM-yyyy").ToString();
        //                    P_SPDS_InstrumentSetup.Get_E_UserID = Session["U_NAME"].ToString();// ((TextBox)FormView1.FindControl("TXT_E_UserID_EDIT")).Text;
        //                    P_SPDS_InstrumentSetup.Get_E_DateTime = DateTime.Now.ToString("dd-MMM-yyyy").ToString();
        //                    P_SPDS_InstrumentSetup.RecordInputCommit();

        //                    //if (File.Exists(DS1.Tables[0].Rows[0][0].ToString() + @"\" + FileName))
        //                    //{
        //                    //    ((Label)FormView1.FindControl("lblDuplicate_EDIT")).Text = "File Already Exist";
        //                    //}
        //                    //else
        //                    //{
        //                    //File.Copy(fullPath, DS1.Tables[0].Rows[0][0].ToString() + @"\" + FileName, true);
        //                    P_SPDS_InstrumentSetup.EditNewGroup();


        //                    //DataSet DS1 = new DataSet();
        //                    //DS1 = LOV.RPT_Path();
        //                    //String FP = System.IO.Path.GetFullPath(((FileUpload)FormView1.FindControl("TXT_RDLC_UPLOAD_PATH_EDIT")).PostedFile.FileName);
        //                    //FileOp FO = new FileOp();
        //                    //String RP = "";
        //                    //RP = FO.uploadFileUsingFTP(FPS.SP_FILE_PATH("4").ToString() + ((FileUpload)FormView1.FindControl("TXT_RDLC_UPLOAD_PATH_EDIT")).FileName.ToString(), FP.ToString(), Session["FTPUserID"].ToString(), Session["FTPPASSWORD"].ToString());


        //                    BackPage();
        //                    //}
        //                }
        //                else
        //                {
        //                    ((Label)FormView1.FindControl("lblDuplicate_EDIT")).Text = "File format must be RDLC";
        //                    //lblMessage.Text = "File format must be RDLC";
        //                }



        //            }
        //            else
        //            {
        //                ((TextBox)FormView1.FindControl("TXT_INSTRUMENT_NAME_EDIT")).Text = "";
        //                ((RequiredFieldValidator)FormView1.FindControl("REQ_INSTRUMENT_NAME_EDIT")).Validate();
        //            }
        //        }
        //    }
        //}
        //else if (e.Item.ToolTip == "Cancel")
        //{ BackPage(); }
    }
    protected void InsertToolbar_ItemClick(object sender, EO.Web.ToolBarEventArgs e)
    {
    //    string FileName = "";
    //    string FilePath = "";
    //    string fullPath = "";
    //    string fullExtention = "";
    //    Page.Validate();
    //    if (e.Item.ToolTip == "Insert")
    //    {
    //        if (Page.IsValid)
    //        {
    //            LOV_COLLECTION L = new LOV_COLLECTION();
    //            DataSet DS;
    //            DS = L.SP_InstrumentSetup_DP(((TextBox)FormView1.FindControl("TXT_INSTRUMENT_NAME_INSERT")).Text, "0");
    //            if (DS.Tables[0].Rows.Count > 0)
    //            {
    //                ((Label)FormView1.FindControl("lblDuplicate_INSERT")).Text = "Duplicate Record";
    //            }
    //            else
    //            {
    //                if (DS.Tables[0].Rows.Count <= 0)
    //                {
    //                    if (((FileUpload)FormView1.FindControl("TXT_RDLC_UPLOAD_PATH_INSERT")).HasFile)
    //                    {
    //                        fullPath = ((FileUpload)FormView1.FindControl("TXT_RDLC_UPLOAD_PATH_INSERT")).FileName;
    //                        FileName = System.IO.Path.GetFileNameWithoutExtension(fullPath);
    //                        FilePath = System.IO.Path.GetDirectoryName(fullPath);
    //                        fullPath = fullPath.ToString();
    //                        fullExtention = System.IO.Path.GetExtension(((FileUpload)FormView1.FindControl("TXT_RDLC_UPLOAD_PATH_INSERT")).FileName);
    //                        ((FileUpload)FormView1.FindControl("TXT_RDLC_UPLOAD_PATH_INSERT")).SaveAs(Server.MapPath("~") + "\\RDLCReports\\" + fullPath);

    //                        if (fullExtention.ToUpper() == ".RDLC")
    //                        {
    //                            P_SPDS_InstrumentSetup.RecordInputStart();
    //                            P_SPDS_InstrumentSetup.Get_ID = "0";
    //                            P_SPDS_InstrumentSetup.Get_INSTRUMENT_NAME = ((TextBox)FormView1.FindControl("TXT_INSTRUMENT_NAME_INSERT")).Text;
    //                            P_SPDS_InstrumentSetup.Get_RDLC_UPLOAD = fullPath;//((TextBox)FormView1.FindControl("TXT_RDLC_UPLOAD_INSERT")).Text;
    //                            P_SPDS_InstrumentSetup.Get_RDLC_UPLOAD_PATH = Server.MapPath("~") + "\\RDLCReports\\";//fullPath;
    //                            P_SPDS_InstrumentSetup.Get_A_UserID = Session["U_NAME"].ToString();//((TextBox)FormView1.FindControl("TXT_A_UserID_INSERT")).Text;
    //                            P_SPDS_InstrumentSetup.Get_A_DateTime = DateTime.Now.ToString("dd-MMM-yyyy").ToString();
    //                            P_SPDS_InstrumentSetup.Get_E_UserID = Session["U_NAME"].ToString();// ((TextBox)FormView1.FindControl("TXT_E_UserID_INSERT")).Text;
    //                            P_SPDS_InstrumentSetup.Get_E_DateTime = DateTime.Now.ToString("dd-MMM-yyyy").ToString();
    //                            P_SPDS_InstrumentSetup.RecordInputCommit();
    //                            P_SPDS_InstrumentSetup.AddNewGroup();
    //                            BackPage();
    //                        }
    //                        else
    //                        {
    //                            ((Label)FormView1.FindControl("lblDuplicate_INSERT")).Text = "File format must be RDLC";
    //                        }
    //                    }
    //                    else
    //                    {
    //                        ((Label)FormView1.FindControl("lblDuplicate_INSERT")).Text = "Please select RDLC File";
    //                    }
    //                }

    //                else
    //                {
    //                    ((TextBox)FormView1.FindControl("TXT_INSTRUMENT_NAME_INSERT")).Text = "";
    //                    ((RequiredFieldValidator)FormView1.FindControl("REQ_INSTRUMENT_NAME_INSERT")).Validate();
    //                }
    //            }
    //        }
    //    }
    //    else if (e.Item.ToolTip == "Cancel")
    //    { BackPage(); }
    }

    private void UPLOADFILE(FileUpload path)
    {


    }
    protected void FormView1_DataBound(object sender, EventArgs e)
    {
        if (FormView1.CurrentMode.ToString() == "Insert")
        {
            ((TextBox)FormView1.FindControl("TXT_RDLC_UPLOAD_INSERT")).Attributes.Add("readonly", "readonly");
            ((TextBox)FormView1.FindControl("TXT_INSTRUMENT_ID")).Attributes.Add("style", "visibility:hidden;");
        }
        if (FormView1.CurrentMode.ToString() == "Edit")
        {
            ((TextBox)FormView1.FindControl("TXT_RDLC_UPLOAD_Edit")).Attributes.Add("readonly", "readonly");
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //    FormView1.ChangeMode(FormViewMode.Edit);
    }
    protected void BtnDelete_Click(object sender, EventArgs e)
    {

    }
    protected void BtnCancel_Click(object sender, EventArgs e)
    {
       // BackPage();
    }
    protected void BtnAuthorize_Click(object sender, EventArgs e)
    {
        //LOV_COLLECTION L = new LOV_COLLECTION();
        //DataSet DS;
        //DS = L.SP_AuthorizeRecord("SPDS_InstrumentSetup", Session["U_NAME"].ToString(), DateTime.Now.ToString("MM-dd-yyyy"), Session["SPDS_InstrumentSetup_ID"].ToString());
        //Response.Redirect("../InstrumentSetup/frmSPDS_InstrumentSetupSPC.aspx" + "?" + "s1=" + Request.QueryString[0].ToString());
    }
    protected void BtnEEdit_Click(object sender, EventArgs e)
    {
        //string FileName = "";
        //string FilePath = "";
        //string fullPath = "";
        //string fullExtention = "";
        //Page.Validate();
        ////if (e.Item.ToolTip == "Update")
        ////{
        //if (Page.IsValid)
        //{

        //    LOV_COLLECTION L = new LOV_COLLECTION();
        //    DataSet DS;
        //    DS = L.SP_InstrumentSetup_DP(((TextBox)FormView1.FindControl("TXT_INSTRUMENT_NAME_EDIT")).Text, Session["SPDS_InstrumentSetup_ID"].ToString());
        //    if (DS.Tables[0].Rows.Count > 0)
        //    {
        //        ((Label)FormView1.FindControl("lblDuplicate_EDIT")).Text = "Duplicate Record";
        //    }
        //    else
        //    {
        //        if (DS.Tables[0].Rows.Count <= 0)
        //        {
        //            if (((FileUpload)FormView1.FindControl("TXT_RDLC_UPLOAD_PATH_EDIT")).HasFile == true)
        //            {
        //                FileName = System.IO.Path.GetFileName(((FileUpload)FormView1.FindControl("TXT_RDLC_UPLOAD_PATH_EDIT")).PostedFile.FileName);
        //                FilePath = System.IO.Path.GetDirectoryName(((FileUpload)FormView1.FindControl("TXT_RDLC_UPLOAD_PATH_EDIT")).PostedFile.FileName);
        //                fullPath = System.IO.Path.GetFullPath(((FileUpload)FormView1.FindControl("TXT_RDLC_UPLOAD_PATH_EDIT")).PostedFile.FileName);
        //                fullExtention = System.IO.Path.GetExtension(((FileUpload)FormView1.FindControl("TXT_RDLC_UPLOAD_PATH_EDIT")).PostedFile.FileName);
        //                //{
        //            }
        //            else
        //            {
        //                ((Label)FormView1.FindControl("lblDuplicate_EDIT")).Text = ("Select File First");
        //            }
        //            if (fullExtention.ToUpper() == ".RDLC")
        //            {
        //                P_SPDS_InstrumentSetup.RecordInputStart();
        //                P_SPDS_InstrumentSetup.Get_ID = Session["SPDS_InstrumentSetup_ID"].ToString();
        //                P_SPDS_InstrumentSetup.Get_INSTRUMENT_NAME = ((TextBox)FormView1.FindControl("TXT_INSTRUMENT_NAME_EDIT")).Text;
        //                P_SPDS_InstrumentSetup.Get_RDLC_UPLOAD = FileName;//((TextBox)FormView1.FindControl("TXT_RDLC_UPLOAD_EDIT")).Text;
        //                P_SPDS_InstrumentSetup.Get_RDLC_UPLOAD_PATH = Server.MapPath("~") + "\\RDLCReports\\";
        //                P_SPDS_InstrumentSetup.Get_A_UserID = "0";// ((TextBox)FormView1.FindControl("TXT_A_UserID_EDIT")).Text;
        //                P_SPDS_InstrumentSetup.Get_A_DateTime = DateTime.Now.ToString("dd-MMM-yyyy").ToString();
        //                P_SPDS_InstrumentSetup.Get_E_UserID = Session["U_NAME"].ToString();// ((TextBox)FormView1.FindControl("TXT_E_UserID_EDIT")).Text;
        //                P_SPDS_InstrumentSetup.Get_E_DateTime = DateTime.Now.ToString("dd-MMM-yyyy").ToString();
        //                P_SPDS_InstrumentSetup.RecordInputCommit();

        //                //if (File.Exists(DS1.Tables[0].Rows[0][0].ToString() + @"\" + FileName))
        //                //{
        //                //    ((Label)FormView1.FindControl("lblDuplicate_EDIT")).Text = "File Already Exist";
        //                //}
        //                //else
        //                //{
        //                //File.Copy(fullPath, DS1.Tables[0].Rows[0][0].ToString() + @"\" + FileName, true);
        //                P_SPDS_InstrumentSetup.EditNewGroup();


        //                //DataSet DS1 = new DataSet();
        //                //DS1 = LOV.RPT_Path();
        //                //String FP = System.IO.Path.GetFullPath(((FileUpload)FormView1.FindControl("TXT_RDLC_UPLOAD_PATH_EDIT")).PostedFile.FileName);
        //                //FileOp FO = new FileOp();
        //                //String RP = "";
        //                //RP = FO.uploadFileUsingFTP(FPS.SP_FILE_PATH("4").ToString() + ((FileUpload)FormView1.FindControl("TXT_RDLC_UPLOAD_PATH_EDIT")).FileName.ToString(), FP.ToString(), Session["FTPUserID"].ToString(), Session["FTPPASSWORD"].ToString());


        //                BackPage();
        //                //}
        //            }
        //            else
        //            {
        //                ((Label)FormView1.FindControl("lblDuplicate_EDIT")).Text = "File format must be RDLC";
        //                //lblMessage.Text = "File format must be RDLC";
        //            }



        //        }
        //        else
        //        {
        //            ((TextBox)FormView1.FindControl("TXT_INSTRUMENT_NAME_EDIT")).Text = "";
        //            ((RequiredFieldValidator)FormView1.FindControl("REQ_INSTRUMENT_NAME_EDIT")).Validate();
        //        }
        //    }
        //    // }
        //}
    }
    protected void BtnECancel_Click(object sender, EventArgs e)
    {
       // BackPage();
    }
    protected void Button1_Click1(object sender, EventArgs e)
    {
        //string FileName = "";
        //string FilePath = "";
        //string fullPath = "";
        //string fullExtention = "";
        //Page.Validate();
        ////if (e.Item.ToolTip == "Insert")
        ////{
        //if (Page.IsValid)
        //{
        //    LOV_COLLECTION L = new LOV_COLLECTION();
        //    DataSet DS;
        //    DS = L.SP_InstrumentSetup_DP(((TextBox)FormView1.FindControl("TXT_INSTRUMENT_NAME_INSERT")).Text, "0");
        //    if (DS.Tables[0].Rows.Count > 0)
        //    {
        //        ((Label)FormView1.FindControl("lblDuplicate_INSERT")).Text = "Duplicate Record";
        //    }
        //    else
        //    {
        //        if (DS.Tables[0].Rows.Count <= 0)
        //        {
        //            if (((FileUpload)FormView1.FindControl("TXT_RDLC_UPLOAD_PATH_INSERT")).HasFile)
        //            {
        //                fullPath = ((FileUpload)FormView1.FindControl("TXT_RDLC_UPLOAD_PATH_INSERT")).FileName;
        //                FileName = System.IO.Path.GetFileNameWithoutExtension(fullPath);
        //                FilePath = System.IO.Path.GetDirectoryName(fullPath);
        //                fullPath = fullPath.ToString();
        //                fullExtention = System.IO.Path.GetExtension(((FileUpload)FormView1.FindControl("TXT_RDLC_UPLOAD_PATH_INSERT")).FileName);
        //                ((FileUpload)FormView1.FindControl("TXT_RDLC_UPLOAD_PATH_INSERT")).SaveAs(Server.MapPath("~") + "\\RDLCReports\\" + fullPath);

        //                if (fullExtention.ToUpper() == ".RDLC")
        //                {
        //                    P_SPDS_InstrumentSetup.RecordInputStart();
        //                    P_SPDS_InstrumentSetup.Get_ID = "0";
        //                    P_SPDS_InstrumentSetup.Get_INSTRUMENT_NAME = ((TextBox)FormView1.FindControl("TXT_INSTRUMENT_NAME_INSERT")).Text;
        //                    P_SPDS_InstrumentSetup.Get_RDLC_UPLOAD = fullPath;//((TextBox)FormView1.FindControl("TXT_RDLC_UPLOAD_INSERT")).Text;
        //                    P_SPDS_InstrumentSetup.Get_RDLC_UPLOAD_PATH = Server.MapPath("~") + "\\RDLCReports\\";//fullPath;
        //                    P_SPDS_InstrumentSetup.Get_A_UserID = Session["U_NAME"].ToString();//((TextBox)FormView1.FindControl("TXT_A_UserID_INSERT")).Text;
        //                    P_SPDS_InstrumentSetup.Get_A_DateTime = DateTime.Now.ToString("dd-MMM-yyyy").ToString();
        //                    P_SPDS_InstrumentSetup.Get_E_UserID = Session["U_NAME"].ToString();// ((TextBox)FormView1.FindControl("TXT_E_UserID_INSERT")).Text;
        //                    P_SPDS_InstrumentSetup.Get_E_DateTime = DateTime.Now.ToString("dd-MMM-yyyy").ToString();
        //                    P_SPDS_InstrumentSetup.RecordInputCommit();
        //                    P_SPDS_InstrumentSetup.AddNewGroup();
        //                    BackPage();
        //                }
        //                else
        //                {
        //                    ((Label)FormView1.FindControl("lblDuplicate_INSERT")).Text = "File format must be RDLC";
        //                }
        //            }
        //            else
        //            {
        //                ((Label)FormView1.FindControl("lblDuplicate_INSERT")).Text = "Please select RDLC File";
        //            }
        //        }

        //        else
        //        {
        //            ((TextBox)FormView1.FindControl("TXT_INSTRUMENT_NAME_INSERT")).Text = "";
        //            ((RequiredFieldValidator)FormView1.FindControl("REQ_INSTRUMENT_NAME_INSERT")).Validate();
        //        }
        //    }
        //}
        // }

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        // else if (e.Item.ToolTip == "Cancel")
     //   BackPage();
    }
    protected void BtnEEdit_Click1(object sender, EventArgs e)
    {
    //    string FileName = "";
    //    string FilePath = "";
    //    string fullPath = "";
    //    string fullExtention = "";
    //    Page.Validate();
    //    //if (e.Item.ToolTip == "Update")
    //    //{
    //    if (Page.IsValid)
    //    {

    //        LOV_COLLECTION L = new LOV_COLLECTION();
    //        DataSet DS;
    //        DS = L.SP_InstrumentSetup_DP(((TextBox)FormView1.FindControl("TXT_INSTRUMENT_NAME_EDIT")).Text, Session["SPDS_InstrumentSetup_ID"].ToString());
    //        if (DS.Tables[0].Rows.Count > 0)
    //        {
    //            ((Label)FormView1.FindControl("lblDuplicate_EDIT")).Text = "Duplicate Record";
    //        }
    //        else
    //        {
    //            if (DS.Tables[0].Rows.Count <= 0)
    //            {
    //                if (((FileUpload)FormView1.FindControl("TXT_RDLC_UPLOAD_PATH_EDIT")).HasFile == true)
    //                {
    //                    FileName = System.IO.Path.GetFileName(((FileUpload)FormView1.FindControl("TXT_RDLC_UPLOAD_PATH_EDIT")).PostedFile.FileName);
    //                    FilePath = System.IO.Path.GetDirectoryName(((FileUpload)FormView1.FindControl("TXT_RDLC_UPLOAD_PATH_EDIT")).PostedFile.FileName);
    //                    fullPath = System.IO.Path.GetFullPath(((FileUpload)FormView1.FindControl("TXT_RDLC_UPLOAD_PATH_EDIT")).PostedFile.FileName);
    //                    fullExtention = System.IO.Path.GetExtension(((FileUpload)FormView1.FindControl("TXT_RDLC_UPLOAD_PATH_EDIT")).PostedFile.FileName);
    //                    //{
    //                }
    //                else
    //                {
    //                    ((Label)FormView1.FindControl("lblDuplicate_EDIT")).Text = ("Select File First");
    //                }
    //                if (fullExtention.ToUpper() == ".RDLC")
    //                {
    //                    P_SPDS_InstrumentSetup.RecordInputStart();
    //                    P_SPDS_InstrumentSetup.Get_ID = Session["SPDS_InstrumentSetup_ID"].ToString();
    //                    P_SPDS_InstrumentSetup.Get_INSTRUMENT_NAME = ((TextBox)FormView1.FindControl("TXT_INSTRUMENT_NAME_EDIT")).Text;
    //                    P_SPDS_InstrumentSetup.Get_RDLC_UPLOAD = FileName;//((TextBox)FormView1.FindControl("TXT_RDLC_UPLOAD_EDIT")).Text;
    //                    P_SPDS_InstrumentSetup.Get_RDLC_UPLOAD_PATH = Server.MapPath("~") + "\\RDLCReports\\";
    //                    P_SPDS_InstrumentSetup.Get_A_UserID = "0";// ((TextBox)FormView1.FindControl("TXT_A_UserID_EDIT")).Text;
    //                    P_SPDS_InstrumentSetup.Get_A_DateTime = DateTime.Now.ToString("dd-MMM-yyyy").ToString();
    //                    P_SPDS_InstrumentSetup.Get_E_UserID = Session["U_NAME"].ToString();// ((TextBox)FormView1.FindControl("TXT_E_UserID_EDIT")).Text;
    //                    P_SPDS_InstrumentSetup.Get_E_DateTime = DateTime.Now.ToString("dd-MMM-yyyy").ToString();
    //                    P_SPDS_InstrumentSetup.RecordInputCommit();

    //                    //if (File.Exists(DS1.Tables[0].Rows[0][0].ToString() + @"\" + FileName))
    //                    //{
    //                    //    ((Label)FormView1.FindControl("lblDuplicate_EDIT")).Text = "File Already Exist";
    //                    //}
    //                    //else
    //                    //{
    //                    //File.Copy(fullPath, DS1.Tables[0].Rows[0][0].ToString() + @"\" + FileName, true);
    //                    P_SPDS_InstrumentSetup.EditNewGroup();


    //                    //DataSet DS1 = new DataSet();
    //                    //DS1 = LOV.RPT_Path();
    //                    //String FP = System.IO.Path.GetFullPath(((FileUpload)FormView1.FindControl("TXT_RDLC_UPLOAD_PATH_EDIT")).PostedFile.FileName);
    //                    //FileOp FO = new FileOp();
    //                    //String RP = "";
    //                    //RP = FO.uploadFileUsingFTP(FPS.SP_FILE_PATH("4").ToString() + ((FileUpload)FormView1.FindControl("TXT_RDLC_UPLOAD_PATH_EDIT")).FileName.ToString(), FP.ToString(), Session["FTPUserID"].ToString(), Session["FTPPASSWORD"].ToString());


    //                    BackPage();
    //                    //}
    //                }
    //                else
    //                {
    //                    ((Label)FormView1.FindControl("lblDuplicate_EDIT")).Text = "File format must be RDLC";
    //                    //lblMessage.Text = "File format must be RDLC";
    //                }



    //            }
    //            else
    //            {
    //                ((TextBox)FormView1.FindControl("TXT_INSTRUMENT_NAME_EDIT")).Text = "";
    //                ((RequiredFieldValidator)FormView1.FindControl("REQ_INSTRUMENT_NAME_EDIT")).Validate();
    //            }
    //        }
    //    }
    //}
    }
   
    
    
    
    
    
    
    
    protected void CMD_AUTHORIZE_Click(object sender, EventArgs e)
    {
        LOV_COLLECTION L = new LOV_COLLECTION();
        DataSet DS;
        DS = L.SP_AuthorizeRecord("SPDS_InstrumentSetup", Session["U_NAME"].ToString(), DateTime.Now.ToString("MM-dd-yyyy"), Session["SPDS_InstrumentSetup_ID"].ToString());
        Response.Redirect("../InstrumentSetup/frmSPDS_InstrumentSetupSPC.aspx" + "?" + "s1=" + Request.QueryString[0].ToString());
    }
    protected void BTN_RESET_Click(object sender, EventArgs e)
    {
        ((TextBox)FormView1.FindControl("TXT_INSTRUMENT_NAME_INSERT")).Text = "";
    }
    protected void BTN_EDIT_Click(object sender, EventArgs e)
    {
        FormView1.ChangeMode(FormViewMode.Edit);
        ((Button)FormView1.FindControl("BTN_CANCEL")).Enabled = true;

    }


    protected void BTN_CANCEL_Click(object sender, EventArgs e)
    {
        BackPage();
    }
    protected void UpdateButton_Click(object sender, EventArgs e)
    {
        string FileName = "";
        string FilePath = "";
        string fullPath = "";
        string fullExtention = "";
        Page.Validate();

        {
            if (Page.IsValid)
            {

                LOV_COLLECTION L = new LOV_COLLECTION();
                DataSet DS;
                DS = L.SP_InstrumentSetup_DP(((TextBox)FormView1.FindControl("TXT_INSTRUMENT_NAME_EDIT")).Text, Session["SPDS_InstrumentSetup_ID"].ToString());
                if (DS.Tables[0].Rows.Count > 0)
                {
                    ((Label)FormView1.FindControl("lblDuplicate_EDIT")).Text = "Duplicate Record";
                }
                else
                {
                    if (DS.Tables[0].Rows.Count <= 0)
                    {
                        if (((FileUpload)FormView1.FindControl("TXT_RDLC_UPLOAD_PATH_EDIT")).HasFile == true)
                        {
                            FileName = System.IO.Path.GetFileName(((FileUpload)FormView1.FindControl("TXT_RDLC_UPLOAD_PATH_EDIT")).PostedFile.FileName);
                            FilePath = System.IO.Path.GetDirectoryName(((FileUpload)FormView1.FindControl("TXT_RDLC_UPLOAD_PATH_EDIT")).PostedFile.FileName);
                            fullPath = System.IO.Path.GetFullPath(((FileUpload)FormView1.FindControl("TXT_RDLC_UPLOAD_PATH_EDIT")).PostedFile.FileName);
                            fullExtention = System.IO.Path.GetExtension(((FileUpload)FormView1.FindControl("TXT_RDLC_UPLOAD_PATH_EDIT")).PostedFile.FileName);
                            //{
                        }
                        else
                        {
                            ((Label)FormView1.FindControl("lblDuplicate_EDIT")).Text = ("Select File First");
                        }
                        if (fullExtention.ToUpper() == ".RDLC")
                        {
                            P_SPDS_InstrumentSetup.RecordInputStart();
                            P_SPDS_InstrumentSetup.Get_ID = Session["SPDS_InstrumentSetup_ID"].ToString();
                            P_SPDS_InstrumentSetup.Get_INSTRUMENT_NAME = ((TextBox)FormView1.FindControl("TXT_INSTRUMENT_NAME_EDIT")).Text;
                            P_SPDS_InstrumentSetup.Get_RDLC_UPLOAD = FileName;//((TextBox)FormView1.FindControl("TXT_RDLC_UPLOAD_EDIT")).Text;
                            P_SPDS_InstrumentSetup.Get_RDLC_UPLOAD_PATH = Server.MapPath("~") + "\\RDLCReports\\";
                            P_SPDS_InstrumentSetup.Get_A_UserID = "0";// ((TextBox)FormView1.FindControl("TXT_A_UserID_EDIT")).Text;
                            P_SPDS_InstrumentSetup.Get_A_DateTime = DateTime.Now.ToString("dd-MMM-yyyy").ToString();
                            P_SPDS_InstrumentSetup.Get_E_UserID = Session["U_NAME"].ToString();// ((TextBox)FormView1.FindControl("TXT_E_UserID_EDIT")).Text;
                            P_SPDS_InstrumentSetup.Get_E_DateTime = DateTime.Now.ToString("dd-MMM-yyyy").ToString();
                            P_SPDS_InstrumentSetup.RecordInputCommit();

                            //if (File.Exists(DS1.Tables[0].Rows[0][0].ToString() + @"\" + FileName))
                            //{
                            //    ((Label)FormView1.FindControl("lblDuplicate_EDIT")).Text = "File Already Exist";
                            //}
                            //else
                            //{
                            //File.Copy(fullPath, DS1.Tables[0].Rows[0][0].ToString() + @"\" + FileName, true);
                            P_SPDS_InstrumentSetup.EditNewGroup();


                            //DataSet DS1 = new DataSet();
                            //DS1 = LOV.RPT_Path();
                            //String FP = System.IO.Path.GetFullPath(((FileUpload)FormView1.FindControl("TXT_RDLC_UPLOAD_PATH_EDIT")).PostedFile.FileName);
                            //FileOp FO = new FileOp();
                            //String RP = "";
                            //RP = FO.uploadFileUsingFTP(FPS.SP_FILE_PATH("4").ToString() + ((FileUpload)FormView1.FindControl("TXT_RDLC_UPLOAD_PATH_EDIT")).FileName.ToString(), FP.ToString(), Session["FTPUserID"].ToString(), Session["FTPPASSWORD"].ToString());


                            BackPage();
                            //}
                        }
                        else
                        {
                            ((Label)FormView1.FindControl("lblDuplicate_EDIT")).Text = "File format must be RDLC";
                            //lblMessage.Text = "File format must be RDLC";
                        }



                    }
                    else
                    {
                        ((TextBox)FormView1.FindControl("TXT_INSTRUMENT_NAME_EDIT")).Text = "";
                        ((RequiredFieldValidator)FormView1.FindControl("REQ_INSTRUMENT_NAME_EDIT")).Validate();
                    }
                }
            }
        }

    }
    protected void BTN_INSERT_Click(object sender, EventArgs e)
    {
        string FileName = "";
        string FilePath = "";
        string fullPath = "";
        string fullExtention = "";
        Page.Validate();

        if (Page.IsValid)
        {
            LOV_COLLECTION L = new LOV_COLLECTION();
            DataSet DS;
            DS = L.SP_InstrumentSetup_DP(((TextBox)FormView1.FindControl("TXT_INSTRUMENT_NAME_INSERT")).Text, "0");
            if (DS.Tables[0].Rows.Count > 0)
            {
                ((Label)FormView1.FindControl("lblDuplicate_INSERT")).Text = "Duplicate Record";
            }
            else
            {
                if (DS.Tables[0].Rows.Count <= 0)
                {
                    if (((FileUpload)FormView1.FindControl("TXT_RDLC_UPLOAD_PATH_INSERT")).HasFile)
                    {
                        fullPath = ((FileUpload)FormView1.FindControl("TXT_RDLC_UPLOAD_PATH_INSERT")).FileName;
                        FileName = System.IO.Path.GetFileNameWithoutExtension(fullPath);
                        FilePath = System.IO.Path.GetDirectoryName(fullPath);
                        fullPath = fullPath.ToString();
                        fullExtention = System.IO.Path.GetExtension(((FileUpload)FormView1.FindControl("TXT_RDLC_UPLOAD_PATH_INSERT")).FileName);
                        ((FileUpload)FormView1.FindControl("TXT_RDLC_UPLOAD_PATH_INSERT")).SaveAs(Server.MapPath("~") + "\\RDLCReports\\" + fullPath);

                        if (fullExtention.ToUpper() == ".RDLC")
                        {
                            P_SPDS_InstrumentSetup.RecordInputStart();
                            P_SPDS_InstrumentSetup.Get_ID = "0";
                            P_SPDS_InstrumentSetup.Get_INSTRUMENT_NAME = ((TextBox)FormView1.FindControl("TXT_INSTRUMENT_NAME_INSERT")).Text;
                            P_SPDS_InstrumentSetup.Get_RDLC_UPLOAD = fullPath;//((TextBox)FormView1.FindControl("TXT_RDLC_UPLOAD_INSERT")).Text;
                            P_SPDS_InstrumentSetup.Get_RDLC_UPLOAD_PATH = Server.MapPath("~") + "\\RDLCReports\\";//fullPath;
                            P_SPDS_InstrumentSetup.Get_A_UserID = Session["U_NAME"].ToString();//((TextBox)FormView1.FindControl("TXT_A_UserID_INSERT")).Text;
                            P_SPDS_InstrumentSetup.Get_A_DateTime = DateTime.Now.ToString("dd-MMM-yyyy").ToString();
                            P_SPDS_InstrumentSetup.Get_E_UserID = Session["U_NAME"].ToString();// ((TextBox)FormView1.FindControl("TXT_E_UserID_INSERT")).Text;
                            P_SPDS_InstrumentSetup.Get_E_DateTime = DateTime.Now.ToString("dd-MMM-yyyy").ToString();
                            P_SPDS_InstrumentSetup.RecordInputCommit();
                            P_SPDS_InstrumentSetup.AddNewGroup();
                            BackPage();
                        }
                        else
                        {
                            ((Label)FormView1.FindControl("lblDuplicate_INSERT")).Text = "File format must be RDLC";
                        }
                    }
                    else
                    {
                        ((Label)FormView1.FindControl("lblDuplicate_INSERT")).Text = "Please select RDLC File";
                    }
                }

                else
                {
                    ((TextBox)FormView1.FindControl("TXT_INSTRUMENT_NAME_INSERT")).Text = "";
                    ((RequiredFieldValidator)FormView1.FindControl("REQ_INSTRUMENT_NAME_INSERT")).Validate();
                }
            }

        }
    }
}
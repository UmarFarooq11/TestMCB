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
using System.Data.SqlClient;
using System.Net;
using System.Data.OracleClient;
using System.IO;

public partial class SignatorySetup_frmSPDS_SignatorySetupSPC : System.Web.UI.Page
{
    FormViewRow D_TEMP;
    TextBox TXT;
    Label LL;
    PROCESS_SPDS_SignatorySetup P_SPDS_SignatorySetup = new PROCESS_SPDS_SignatorySetup();
    FileProcessingSystem FPS = new FileProcessingSystem();
    DatabaseConnection_Util obj_DBLayer = new DatabaseConnection_Util();
    LOV_COLLECTION obj_lov = new LOV_COLLECTION();
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["RPS_Bank_BankCode"] = "%";

        if (Session["SPDS_SignatorySetup_ID"].ToString() == "0")
        {
            FormView1.ChangeMode(FormViewMode.Insert);
            //((Label)FormView1.Row.FindControl("Label_HEAD")).Text = "Signatory Setup";
        }
        else
        {
            //((Label)FormView1.FindControl("Label_HEAD")).Text = "Signatory Setup : " + Session["SPDS_SignatorySetup_ID"].ToString() + " / " + Session["SPDS_SignatorySetup_SIGNATORY_NAME"].ToString();
            if (IsPostBack == false)
            {
                SetDataSource();
                string RGS_SUPPORT;
                RGS_SUPPORT = Session["RGS"].ToString();
                if (RGS_SUPPORT.Substring(2, 1) == "0")
                {
                    if (FormView1.CurrentMode == FormViewMode.ReadOnly)
                    {

                    }
                }
                else if (RGS_SUPPORT.Substring(2, 1) == "1")
                {
                    if (FormView1.CurrentMode == FormViewMode.ReadOnly)
                    {
                    }
                }
                if (FormView1.CurrentMode == FormViewMode.ReadOnly)
                {
                    if (RGS_SUPPORT.Substring(4, 1) == "0")
                    {
                        ((Button)FormView1.FindControl("btnAuthorize")).Enabled = false; /*Edit*/
                        ((Button)FormView1.FindControl("BTN_EDIT")).Enabled = true; /*Edit*/
                    }
                    else if (RGS_SUPPORT.Substring(4, 1) == "1")
                    {
                        ((Button)FormView1.FindControl("btnAuthorize")).Enabled = true; /*Edit*/
                        ((Button)FormView1.FindControl("BTN_EDIT")).Enabled = false; /*Edit*/
                    }
                }
            }
        }

    }
    private void BackPage()
    {
        Session["SPDS_SignatorySetup_ID"] = "0";
        Session["SPDS_SignatorySetup_SIGNATORY_NAME"] = "%";
        Response.Redirect("../SignatorySetup/frmSPDS_SignatorySetup.aspx" + "?" + "s1=" + Request.QueryString[0].ToString());
    }
    protected void Page_PreInit(object sender, EventArgs e)
    { Page.Theme = Session["ThemeChange"].ToString(); }
    protected void DisplayToolBar_ItemClick(object sender, EO.Web.ToolBarEventArgs e)
    {
        if (e.Item.ToolTip == "Edit")
        { FormView1.ChangeMode(FormViewMode.Edit); }
        else if (e.Item.ToolTip == "Cancel")
        { BackPage(); }
        else if (e.Item.ToolTip == "Authorize / Unauthorize")
        {
            LOV_COLLECTION L = new LOV_COLLECTION();
            DataSet DS;
            DS = L.SP_AuthorizeRecord("SPDS_SignatorySetup", Session["U_NAME"].ToString(), DateTime.Now.ToString("MM-dd-yyyy"), Session["SPDS_SignatorySetup_ID"].ToString());
            Response.Redirect("../SignatorySetup/frmSPDS_SignatorySetupSPC.aspx" + "?" + "s1=" + Request.QueryString[0].ToString());
        }
    }
    protected void EditToolbar_ItemClick(object sender, EO.Web.ToolBarEventArgs e)
    {
        //Page.Validate();
        //if (e.Item.ToolTip == "Update")
        //{
        //    if (Page.IsValid)
        //    {
        //        LOV_COLLECTION L = new LOV_COLLECTION();
        //        DataSet DS;
        //        DS = L.SP_SignatorySetup_DP(((TextBox)FormView1.FindControl("TXT_SIGNATORY_NAME_EDIT")).Text, Session["SPDS_SignatorySetup_ID"].ToString());
        //        if (DS.Tables[0].Rows.Count > 0)
        //        {
        //            ((Label)FormView1.FindControl("lblDuplicate_EDIT")).Text = "Duplicate Record";
        //        }
        //        else
        //        {
        //            //SP_SET_UPDATE_SPDS_SignSetup
        //            if (DS.Tables[0].Rows.Count <= 0)
        //            {
        //                string v_return = "";
        //                OracleParameter[] parm = new OracleParameter[6];
        //                int pno = 0;

        //                parm[pno] = new OracleParameter();
        //                parm[pno] = obj_DBLayer.Oracle_Param("v_ID", OracleType.VarChar, ParameterDirection.Input, Session["SPDS_SignatorySetup_ID"].ToString());
        //                pno++;
        //                parm[pno] = new OracleParameter();
        //                parm[pno] = obj_DBLayer.Oracle_Param("v_SIGNATORY_NAME", OracleType.VarChar, ParameterDirection.Input, ((TextBox)FormView1.FindControl("TXT_SIGNATORY_NAME_EDIT")).Text);
        //                pno++;
        //                parm[pno] = new OracleParameter();
        //                parm[pno] = obj_DBLayer.Oracle_Param("v_UPLOAD_IMAGE_PATH", OracleType.VarChar, ParameterDirection.Input, ((FileUpload)FormView1.FindControl("TXT_UPLOAD_IMAGE_PATH_EDIT")).FileName.ToString());
        //                pno++;
        //                parm[pno] = new OracleParameter();
        //                parm[pno] = obj_DBLayer.Oracle_Param("v_UPLOAD_IMAGE", OracleType.Blob, ParameterDirection.Input, ((FileUpload)FormView1.FindControl("TXT_UPLOAD_IMAGE_PATH_EDIT")).FileBytes);
        //                pno++;
        //                parm[pno] = new OracleParameter();
        //                parm[pno] = obj_DBLayer.Oracle_Param("v_CURRENT_STATUS", OracleType.VarChar, ParameterDirection.Input, ((DropDownList)FormView1.FindControl("DDL_CURRENT_STATUS_EDIT")).SelectedValue);
        //                pno++;
        //                parm[pno] = new OracleParameter();
        //                parm[pno] = obj_DBLayer.Oracle_Param("v_E_UserID", OracleType.VarChar, ParameterDirection.Input, Session["U_NAME"].ToString());

        //                v_return = obj_DBLayer.Oracle_GetDataSetSP_DML("SP_SET_UPDATE_SPDS_SignSetup", parm, pno);
        //                ((FileUpload)FormView1.FindControl("TXT_UPLOAD_IMAGE_PATH_EDIT")).SaveAs(Server.MapPath("~") + "\\SignatureImage\\" + ((FileUpload)FormView1.FindControl("TXT_UPLOAD_IMAGE_PATH_EDIT")).FileName.ToString());

        //                /*P_SPDS_SignatorySetup.RecordInputStart();
        //                P_SPDS_SignatorySetup.Get_ID = Session["SPDS_SignatorySetup_ID"].ToString();
        //                P_SPDS_SignatorySetup.Get_SIGNATORY_NAME = ((TextBox)FormView1.FindControl("TXT_SIGNATORY_NAME_EDIT")).Text;
        //                P_SPDS_SignatorySetup.Get_UPLOAD_IMAGE_PATH = ((FileUpload)FormView1.FindControl("TXT_UPLOAD_IMAGE_PATH_EDIT")).FileName.ToString();
        //                P_SPDS_SignatorySetup.Get_CURRENT_STATUS = ((DropDownList)FormView1.FindControl("DDL_CURRENT_STATUS_EDIT")).SelectedValue;
        //                P_SPDS_SignatorySetup.Get_ImageName = ((FileUpload)FormView1.FindControl("TXT_UPLOAD_IMAGE_PATH_EDIT")).FileName; 
        //                P_SPDS_SignatorySetup.Get_A_userID = Session["U_NAME"].ToString();
        //                P_SPDS_SignatorySetup.Get_A_DateTime = DateTime.Now.ToString("dd-MMM-yyyy").ToString();
        //                P_SPDS_SignatorySetup.Get_E_UserID = Session["U_NAME"].ToString();
        //                P_SPDS_SignatorySetup.Get_E_DateTime = DateTime.Now.ToString("dd-MMM-yyyy").ToString();
        //                P_SPDS_SignatorySetup.RecordInputCommit();
        //                P_SPDS_SignatorySetup.EditNewGroup();
        //                ImageSaving_EDIT(Session["SPDS_SignatorySetup_ID"].ToString(), ((FileUpload)FormView1.FindControl("TXT_UPLOAD_IMAGE_PATH_EDIT")));*/
        //                BackPage();
        //            }
        //            else
        //            {
        //                ((TextBox)FormView1.FindControl("TXT_SIGNATORY_NAME_EDIT")).Text = "";
        //                ((RequiredFieldValidator)FormView1.FindControl("REQ_Name_EDIT")).Validate();
        //            }
        //        }
        //    }
        //}
        //else if (e.Item.ToolTip == "Cancel")
        //{ BackPage(); }
    }
    protected void InsertToolbar_ItemClick(object sender, EO.Web.ToolBarEventArgs e)
    {

        //Page.Validate();
        //if (e.Item.ToolTip == "Insert")
        //{
        //    if (Page.IsValid)
        //    {
        //        LOV_COLLECTION L = new LOV_COLLECTION();
        //        DataSet DS;
        //        DS = L.SP_SignatorySetup_DP(((TextBox)FormView1.FindControl("TXT_SIGNATORY_NAME_INSERT")).Text, "0");
        //        if (DS.Tables[0].Rows.Count > 0)
        //        {
        //            ((Label)FormView1.FindControl("lblDuplicate_INSERT")).Text = "Duplicate Record";
        //        }
        //        else
        //        {
        //            if (Path.GetExtension(((FileUpload)FormView1.FindControl("TXT_UPLOAD_IMAGE_PATH_INSERT")).FileName.ToLower()) == ".jpg")
        //            {
        //                if (DS.Tables[0].Rows.Count <= 0)
        //                {
        //                    string v_return = "";
        //                    OracleParameter[] parm = new OracleParameter[6];
        //                    int pno = 0;

        //                    parm[pno] = new OracleParameter();
        //                    parm[pno] = obj_DBLayer.Oracle_Param("v_ID", OracleType.VarChar, ParameterDirection.Input, "0");
        //                    pno++;
        //                    parm[pno] = new OracleParameter();
        //                    parm[pno] = obj_DBLayer.Oracle_Param("v_SIGNATORY_NAME", OracleType.VarChar, ParameterDirection.Input, ((TextBox)FormView1.FindControl("TXT_SIGNATORY_NAME_INSERT")).Text);
        //                    pno++;
        //                    parm[pno] = new OracleParameter();
        //                    parm[pno] = obj_DBLayer.Oracle_Param("v_UPLOAD_IMAGE_PATH", OracleType.VarChar, ParameterDirection.Input, ((FileUpload)FormView1.FindControl("TXT_UPLOAD_IMAGE_PATH_INSERT")).FileName.ToString());
        //                    pno++;
        //                    parm[pno] = new OracleParameter();
        //                    parm[pno] = obj_DBLayer.Oracle_Param("v_UPLOAD_IMAGE", OracleType.Blob, ParameterDirection.Input, ((FileUpload)FormView1.FindControl("TXT_UPLOAD_IMAGE_PATH_INSERT")).FileBytes);
        //                    pno++;
        //                    parm[pno] = new OracleParameter();
        //                    parm[pno] = obj_DBLayer.Oracle_Param("v_CURRENT_STATUS", OracleType.VarChar, ParameterDirection.Input, ((DropDownList)FormView1.FindControl("DDL_CURRENT_STATUS_INSERT")).SelectedValue);
        //                    pno++;
        //                    parm[pno] = new OracleParameter();
        //                    parm[pno] = obj_DBLayer.Oracle_Param("v_E_UserID", OracleType.VarChar, ParameterDirection.Input, Session["U_NAME"].ToString());

        //                    v_return = obj_DBLayer.Oracle_GetDataSetSP_DML("SP_SET_INSERT_SignatorySetup", parm, pno);

        //                    /*P_SPDS_SignatorySetup.RecordInputStart();
        //                    P_SPDS_SignatorySetup.Get_ID = "0";
        //                    P_SPDS_SignatorySetup.Get_SIGNATORY_NAME = ((TextBox)FormView1.FindControl("TXT_SIGNATORY_NAME_INSERT")).Text;
        //                    P_SPDS_SignatorySetup.Get_UPLOAD_IMAGE_PATH = ((FileUpload)FormView1.FindControl("TXT_UPLOAD_IMAGE_PATH_INSERT")).FileName.ToString();
        //                    P_SPDS_SignatorySetup.Get_CURRENT_STATUS = ((DropDownList)FormView1.FindControl("DDL_CURRENT_STATUS_INSERT")).SelectedValue;
        //                    P_SPDS_SignatorySetup.Get_A_userID = Session["U_NAME"].ToString();
        //                    P_SPDS_SignatorySetup.Get_A_DateTime = DateTime.Now.ToString("dd-MMM-yyyy").ToString();
        //                    P_SPDS_SignatorySetup.Get_E_UserID = Session["U_NAME"].ToString();
        //                    P_SPDS_SignatorySetup.Get_E_DateTime = DateTime.Now.ToString("dd-MMM-yyyy").ToString();
        //                    P_SPDS_SignatorySetup.Get_ImageBye = ((FileUpload)FormView1.FindControl("TXT_UPLOAD_IMAGE_PATH_INSERT")).FileBytes;
        //                    P_SPDS_SignatorySetup.RecordInputCommit();
        //                    P_SPDS_SignatorySetup.AddNewGroup();
        //                    ImageSaving_INSERT(Startup_Util.TEMP_DT.Rows[0][1].ToString(), ((FileUpload)FormView1.FindControl("TXT_UPLOAD_IMAGE_PATH_INSERT")));*/



        //                    ((FileUpload)FormView1.FindControl("TXT_UPLOAD_IMAGE_PATH_INSERT")).SaveAs(Server.MapPath("~") + "\\SignatureImage\\" + ((FileUpload)FormView1.FindControl("TXT_UPLOAD_IMAGE_PATH_INSERT")).FileName.ToString());
        //                    BackPage();
        //                }
        //                else
        //                {

        //                    ((TextBox)FormView1.FindControl("TXT_SIGNATORY_NAME_INSERT")).Text = "";
        //                    ((RequiredFieldValidator)FormView1.FindControl("REQ_SignatoryName_INSERT")).Validate();
        //                }
        //            }
        //            else
        //            {

        //                ((Label)FormView1.FindControl("lblDuplicate_INSERT")).Text = "Select JPG image file";
        //                return;
        //            }
        //        }
        //    }
        //}
        //else if (e.Item.ToolTip == "Cancel")
        //{ BackPage(); }
    }
    protected void ImageSaving_INSERT(string ID, FileUpload imgUpload)
    {
        OracleConnection connection = new OracleConnection();
        try
        {
            FileUpload img = (FileUpload)imgUpload;
            Byte[] imgByte = null;

            if (img.HasFile && img.PostedFile != null)
            {
                HttpPostedFile File = imgUpload.PostedFile;
                imgByte = new Byte[File.ContentLength];
                File.InputStream.Read(imgByte, 0, File.ContentLength);
            }
            string conn = DAL_EXP1.Utility.Startup_Util.DB_Route; //ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            connection = new OracleConnection(conn);
            connection.Open();
            //string sql = "INSERT INTO EmpDetails(empname,empimg) VALUES(@enm, @eimg) SELECT @@IDENTITY";
            //string sql = "UPDATE SPDS_SignatorySetup SET UPLOAD_IMAGE =@eimg WHERE ID=@enm";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = "sp_signatorysetup_img_upd";
            cmd.CommandType = CommandType.StoredProcedure;
            OracleParameter[] parm = new OracleParameter[2];
            parm[0] = new OracleParameter("v_image", OracleType.Blob, 2000);
            parm[0].Value = imgByte;

            parm[1] = new OracleParameter("v_id", OracleType.VarChar, 2000);
            parm[1].Value = ID;
            cmd.Connection = connection;
            //cmd.Parameters.AddWithValue("@enm", ID);
            //cmd.Parameters.AddWithValue("@eimg", imgByte);
            int id = Convert.ToInt32(cmd.ExecuteScalar());
        }
        catch
        { ((TextBox)FormView1.FindControl("TXT_SIGNATORY_NAME_INSERT")).Text = "error"; }
        finally
        { connection.Close(); }
    }
    protected void ImageSaving_EDIT(string ID, FileUpload imgUpload)
    {
        OracleConnection connection = new OracleConnection();
        try
        {
            FileUpload img = (FileUpload)imgUpload;
            Byte[] imgByte = null;

            if (img.HasFile && img.PostedFile != null)
            {
                HttpPostedFile File = imgUpload.PostedFile;
                imgByte = new Byte[File.ContentLength];
                File.InputStream.Read(imgByte, 0, File.ContentLength);
            }
            string conn = DAL_EXP1.Utility.Startup_Util.DB_Route;//Startup_Util.SPDS_DB.ToString(); //ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            connection = new OracleConnection(conn);
            connection.Open();
            //string sql = "INSERT INTO EmpDetails(empname,empimg) VALUES(@enm, @eimg) SELECT @@IDENTITY";
            // string sql = "UPDATE SPDS_SignatorySetup SET UPLOAD_IMAGE =@eimg WHERE ID=@enm";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = "sp_signatorysetup_img_upd";
            cmd.CommandType = CommandType.StoredProcedure;
            OracleParameter[] parm = new OracleParameter[2];
            parm[0] = new OracleParameter("v_image", OracleType.Blob, 2000);
            parm[0].Value = imgByte;

            parm[1] = new OracleParameter("v_id", OracleType.VarChar, 2000);
            parm[1].Value = ID;
            cmd.Connection = connection;
            //cmd.Parameters.AddWithValue("@enm", ID);
            //cmd.Parameters.AddWithValue("@eimg", imgByte);
            int id = Convert.ToInt32(cmd.ExecuteScalar());
        }
        catch
        { ((TextBox)FormView1.FindControl("TXT_SIGNATORY_NAME_EDIT")).Text = "error"; }
        finally
        { connection.Close(); }
    }
    protected void TXT_CURRENT_STATUS_EDIT_TextChanged(object sender, EventArgs e)
    { }
    protected void btnlov_Click(object sender, ImageClickEventArgs e)
    {
        TextBox UsrID = FormView1.CurrentMode == FormViewMode.Insert ? (TextBox)FormView1.FindControl("TXT_SIGNATORY_NAME_INSERT") : FormView1.CurrentMode == FormViewMode.Edit ? (TextBox)FormView1.FindControl("TXT_SIGNATORY_NAME_EDIT") : null;
        TextBox UsrName = FormView1.CurrentMode == FormViewMode.Insert ? (TextBox)FormView1.FindControl("txtusername") : FormView1.CurrentMode == FormViewMode.Edit ? (TextBox)FormView1.FindControl("txtusernameedit") : null;
        if (UsrID != null || UsrName != null)
        {
            UsrID.Text = Session["LOV_DESCRIPTION"].ToString();
            UsrName.Text = Session["LOV_RealName"].ToString();
        }
    }
    protected void BTN_EDIT_Click(object sender, EventArgs e)
    {
        Response.Redirect("../SignatorySetup/SignatorySetup.aspx?" + "s1=" + Request.QueryString[0].ToString());
        //FormView1.ChangeMode(FormViewMode.Edit);
    }
    protected void BTN_Cancel_Click(object sender, EventArgs e)
    {
        BackPage();
    }
    protected void UpdateButton_Click(object sender, EventArgs e)
    {
        Page.Validate();

        if (Page.IsValid)
        {
            LOV_COLLECTION L = new LOV_COLLECTION();
            DataSet DS;
            DS = L.SP_SignatorySetup_DP(((TextBox)FormView1.FindControl("TXT_SIGNATORY_NAME_EDIT")).Text, Session["SPDS_SignatorySetup_ID"].ToString());
            if (DS.Tables[0].Rows.Count > 0)
            {
                ((Label)FormView1.FindControl("lblDuplicate_EDIT")).Text = "Duplicate Record";
            }
            else
            {
                //SP_SET_UPDATE_SPDS_SignSetup
                if (DS.Tables[0].Rows.Count <= 0)
                {
                    string v_return = "";
                    OracleParameter[] parm = new OracleParameter[7];
                    int pno = 0;

                    parm[pno] = new OracleParameter();
                    parm[pno] = obj_DBLayer.Oracle_Param("v_ID", OracleType.VarChar, ParameterDirection.Input, Session["SPDS_SignatorySetup_ID"].ToString());
                    pno++;
                    parm[pno] = new OracleParameter();
                    parm[pno] = obj_DBLayer.Oracle_Param("v_SIGNATORY_NAME", OracleType.VarChar, ParameterDirection.Input, ((TextBox)FormView1.FindControl("TXT_SIGNATORY_NAME_EDIT")).Text);
                    pno++;
                    parm[pno] = new OracleParameter();
                    parm[pno] = obj_DBLayer.Oracle_Param("v_UPLOAD_IMAGE_PATH", OracleType.VarChar, ParameterDirection.Input, ((FileUpload)FormView1.FindControl("TXT_UPLOAD_IMAGE_PATH_EDIT")).FileName.ToString());
                    pno++;
                    parm[pno] = new OracleParameter();
                    parm[pno] = obj_DBLayer.Oracle_Param("v_CURRENT_STATUS", OracleType.VarChar, ParameterDirection.Input, ((DropDownList)FormView1.FindControl("DDL_CURRENT_STATUS_EDIT")).SelectedValue);
                    pno++;
                    parm[pno] = new OracleParameter();
                    parm[pno] = obj_DBLayer.Oracle_Param("v_UPLOAD_IMAGE", OracleType.Blob, ParameterDirection.Input, ((FileUpload)FormView1.FindControl("TXT_UPLOAD_IMAGE_PATH_EDIT")).FileBytes);
                    pno++;
                    parm[pno] = new OracleParameter();
                    parm[pno] = obj_DBLayer.Oracle_Param("v_E_UserID", OracleType.VarChar, ParameterDirection.Input, Session["U_NAME"].ToString());
                    pno++;
                    parm[pno] = new OracleParameter();
                    parm[pno] = obj_DBLayer.Oracle_Param("V_RETURN", OracleType.VarChar, ParameterDirection.Output, "");

                    v_return = obj_DBLayer.Oracle_GetDataSetSP_DML("SP_SET_UPDATE_SPDS_SignSetup", parm, pno);
                    if (v_return.StartsWith("0"))
                    {
                        ((FileUpload)FormView1.FindControl("TXT_UPLOAD_IMAGE_PATH_EDIT")).SaveAs(Server.MapPath("~") + "\\SignatureImage\\" + ((FileUpload)FormView1.FindControl("TXT_UPLOAD_IMAGE_PATH_EDIT")).FileName.ToString());
                        BackPage();
                    }
                    else
                    {
                        ((Label)FormView1.FindControl("lblDuplicate_EDIT")).Text = v_return.Replace("1;", "");
                    }
                }
                else
                {
                    ((TextBox)FormView1.FindControl("TXT_SIGNATORY_NAME_EDIT")).Text = "";
                    ((RequiredFieldValidator)FormView1.FindControl("REQ_Name_EDIT")).Validate();
                }
            }
        }
    }
    protected void UpdateCancelButton_Click(object sender, EventArgs e)
    {
        BackPage();
    }
    protected void BTN_INSERT_Click(object sender, EventArgs e)
    {
        Page.Validate();
        if (Page.IsValid)
        {
            LOV_COLLECTION L = new LOV_COLLECTION();
            DataSet DS;
            DS = L.SP_SignatorySetup_DP(((TextBox)FormView1.FindControl("TXT_SIGNATORY_NAME_INSERT")).Text, "0");
            if (DS.Tables[0].Rows.Count > 0)
            {
                Session["error1"] = "Duplicate Record";
                ((Label)FormView1.FindControl("lblDuplicate_INSERT")).Text = "Duplicate Record";
            }
            else
            {
                if (Path.GetExtension(((FileUpload)FormView1.FindControl("TXT_UPLOAD_IMAGE_PATH_INSERT")).FileName.ToLower()) == ".jpg")
                {
                    if (DS.Tables[0].Rows.Count <= 0)
                    {
                        string v_return = "";
                        OracleParameter[] parm = new OracleParameter[7];
                        int pno = 0;

                        parm[pno] = new OracleParameter();
                        parm[pno] = obj_DBLayer.Oracle_Param("v_ID", OracleType.VarChar, ParameterDirection.Input, "0");
                        pno++;
                        parm[pno] = new OracleParameter();
                        parm[pno] = obj_DBLayer.Oracle_Param("v_SIGNATORY_NAME", OracleType.VarChar, ParameterDirection.Input, ((TextBox)FormView1.FindControl("TXT_SIGNATORY_NAME_INSERT")).Text);
                        pno++;
                        parm[pno] = new OracleParameter();
                        parm[pno] = obj_DBLayer.Oracle_Param("v_UPLOAD_IMAGE_PATH", OracleType.VarChar, ParameterDirection.Input, ((FileUpload)FormView1.FindControl("TXT_UPLOAD_IMAGE_PATH_INSERT")).FileName.ToString());
                        pno++;
                        parm[pno] = new OracleParameter();
                        parm[pno] = obj_DBLayer.Oracle_Param("v_UPLOAD_IMAGE", OracleType.Blob, ParameterDirection.Input, ((FileUpload)FormView1.FindControl("TXT_UPLOAD_IMAGE_PATH_INSERT")).FileBytes);
                        pno++;
                        parm[pno] = new OracleParameter();
                        parm[pno] = obj_DBLayer.Oracle_Param("v_CURRENT_STATUS", OracleType.VarChar, ParameterDirection.Input, ((DropDownList)FormView1.FindControl("DDL_CURRENT_STATUS_INSERT")).SelectedValue);
                        pno++;
                        parm[pno] = new OracleParameter();
                        parm[pno] = obj_DBLayer.Oracle_Param("v_A_UserID", OracleType.VarChar, ParameterDirection.Input, Session["U_NAME"].ToString());
                        pno++;
                        parm[pno] = new OracleParameter();
                        parm[pno] = obj_DBLayer.Oracle_Param("v_return", OracleType.VarChar, ParameterDirection.Output, "");

                        v_return = obj_DBLayer.Oracle_GetDataSetSP_DML("SP_SET_INSERT_SignatorySetup", parm, pno);
                        if (v_return.StartsWith("0"))
                        {
                            ((FileUpload)FormView1.FindControl("TXT_UPLOAD_IMAGE_PATH_INSERT")).SaveAs(Server.MapPath("~") + "\\SignatureImage\\" + ((FileUpload)FormView1.FindControl("TXT_UPLOAD_IMAGE_PATH_INSERT")).FileName.ToString());
                            BackPage();
                        }
                        else
                        {
                            ((Label)FormView1.FindControl("lblDuplicate_INSERT")).Text = v_return.Replace("1;", "");
                        }

                    }
                    else
                    {

                        ((TextBox)FormView1.FindControl("TXT_SIGNATORY_NAME_INSERT")).Text = "";
                    }
                }
                else
                {
                    ((Label)FormView1.FindControl("lblDuplicate_INSERT")).Text = "Select JPG image file";
                    return;
                }
            }
        }
    }
    protected void BTN_RESET_Click(object sender, EventArgs e)
    {

    }
    protected void BTN_INSERT_CANCEL_Click(object sender, EventArgs e)
    {
        BackPage();
    }
    protected void btnAuthorize_Click(object sender, EventArgs e)
    {
        Page.Validate();
        if (Page.IsValid)
        {
            LOV_COLLECTION L = new LOV_COLLECTION();
            DataSet DS;

            string v_return = "";
            OracleParameter[] parm = new OracleParameter[3];
            int pno = 0;

            parm[pno] = new OracleParameter();
            parm[pno] = obj_DBLayer.Oracle_Param("p_id", OracleType.VarChar, ParameterDirection.Input, Session["SPDS_SignatorySetup_ID"].ToString());
            pno++;
            parm[pno] = new OracleParameter();
            parm[pno] = obj_DBLayer.Oracle_Param("p_user_id", OracleType.VarChar, ParameterDirection.Input, Session["U_NAME"].ToString());
            pno++;
            parm[pno] = new OracleParameter();
            parm[pno] = obj_DBLayer.Oracle_Param("p_return", OracleType.VarChar, ParameterDirection.Output, "");

            v_return = obj_DBLayer.Oracle_GetDataSetSP_DML("sp_signatorysetup_autho", parm, pno);

            if (v_return.StartsWith("0"))
            {
                //Response.Redirect("../InstrumentSetup/frmSPDS_InstrumentSetupSPC.aspx" + "?" + "s1=" + Request.QueryString[0].ToString());
                Response.Redirect("../SignatorySetup/frmSPDS_SignatorySetupSPC.aspx" + "?" + "s1=" + Request.QueryString[0].ToString());
                //BackPage();
                //((FileUpload)FormView1.FindControl("TXT_UPLOAD_IMAGE_PATH_EDIT")).SaveAs(Server.MapPath("~") + "\\SignatureImage\\" + ((FileUpload)FormView1.FindControl("TXT_UPLOAD_IMAGE_PATH_EDIT")).FileName.ToString());
            }
            else
            {
                ((Label)FormView1.FindControl("lblDuplicate_Auth")).Text = v_return.Replace("1;", "");
            }
        }
    }
    protected void FormView1_DataBound(object sender, EventArgs e)
    {
        //if (Session["CHK"].ToString() == "abc")
        //{
        //    Session["error1"] = "";
        //}
        //else
        //{
        //    ((Label)FormView1.FindControl("lblDuplicate_INSERT")).Text = Session["error1"] != null ? Session["error1"].ToString() : "";
        //}
    }
    void SetDataSource()
    {
        string sRowID = Session["SPDS_SignatorySetup_ID"] != null ? Session["SPDS_SignatorySetup_ID"].ToString() : "0";
        FormView1.DataSource = obj_lov.Get_SPDS_SignatorySetup_SPC(sRowID);
        FormView1.DataBind();
    }


    protected void FormView1_ModeChanging(object sender, FormViewModeEventArgs e)
    {

    }
}
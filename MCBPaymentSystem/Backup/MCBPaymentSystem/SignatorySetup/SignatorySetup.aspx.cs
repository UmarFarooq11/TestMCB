using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OracleClient;
using System.IO;

public partial class SignatorySetup_SignatorySetup : System.Web.UI.Page
{
    LOV_COLLECTION lov = new LOV_COLLECTION();
    DatabaseConnection_Util obj_DBLayer = new DatabaseConnection_Util();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ROWID"] != null && Session["ROWID"].ToString() != "" && Session["ROWID"].ToString() != "0")
        {
            tblinst.Visible = false;
            tbledit.Visible = true;
            FillControl();
        }
        if (Session["SPDS_SignatorySetup_ID"] != null && Session["SPDS_SignatorySetup_ID"].ToString() == "0")
        {
            tbledit.Visible = false;
        }

    }
    protected void UpdateButton_Click(object sender, EventArgs e)
    {
        Page.Validate();

        if (Page.IsValid)
        {
            LOV_COLLECTION L = new LOV_COLLECTION();
            DataSet DS;
            DS = L.SP_SignatorySetup_DP(TXT_SIGNATORY_NAME_INSERT.Text, Session["SPDS_SignatorySetup_ID"].ToString());
            if (DS.Tables[0].Rows.Count > 0)
            {
                lblDuplicate_INSERT.Text = "Duplicate Record";
            }
            else
            {
                if (Path.GetExtension(TXT_UPLOAD_IMAGE_PATH_INSERT.FileName.ToLower()) == ".jpg")
                {
                    if (DS.Tables[0].Rows.Count <= 0)
                    {
                        string v_return = "";
                        OracleParameter[] parm = new OracleParameter[7];
                        int pno = 0;

                        parm[pno] = new OracleParameter();
                        parm[pno] = obj_DBLayer.Oracle_Param("v_ID", OracleType.VarChar, ParameterDirection.Input, Session["SPDS_SignatorySetup_ID"].ToString());
                        pno++;
                        parm[pno] = new OracleParameter();
                        parm[pno] = obj_DBLayer.Oracle_Param("v_SIGNATORY_NAME", OracleType.VarChar, ParameterDirection.Input, TXT_SIGNATORY_NAME_INSERT.Text);
                        pno++;
                        parm[pno] = new OracleParameter();
                        parm[pno] = obj_DBLayer.Oracle_Param("v_UPLOAD_IMAGE_PATH", OracleType.VarChar, ParameterDirection.Input, TXT_UPLOAD_IMAGE_PATH_INSERT.FileName.ToString());
                        pno++;
                        parm[pno] = new OracleParameter();
                        parm[pno] = obj_DBLayer.Oracle_Param("v_CURRENT_STATUS", OracleType.VarChar, ParameterDirection.Input, DDL_CURRENT_STATUS_INSERT.SelectedValue);
                        pno++;
                        parm[pno] = new OracleParameter();
                        parm[pno] = obj_DBLayer.Oracle_Param("v_UPLOAD_IMAGE", OracleType.Blob, ParameterDirection.Input, TXT_UPLOAD_IMAGE_PATH_INSERT.FileBytes);
                        pno++;
                        parm[pno] = new OracleParameter();
                        parm[pno] = obj_DBLayer.Oracle_Param("v_E_UserID", OracleType.VarChar, ParameterDirection.Input, Session["U_NAME"].ToString());
                        pno++;
                        parm[pno] = new OracleParameter();
                        parm[pno] = obj_DBLayer.Oracle_Param("V_RETURN", OracleType.VarChar, ParameterDirection.Output, "");

                        v_return = obj_DBLayer.Oracle_GetDataSetSP_DML("SP_SET_UPDATE_SPDS_SignSetup", parm, pno);
                        if (v_return.StartsWith("0"))
                        {
                            TXT_UPLOAD_IMAGE_PATH_INSERT.SaveAs(Server.MapPath("~") + "\\SignatureImage\\" + TXT_UPLOAD_IMAGE_PATH_INSERT.FileName.ToString());
                        }
                        else
                        {
                            lblDuplicate_INSERT.Text = v_return.Replace("1;", "");
                        }
                        Response.Redirect("../SignatorySetup/frmSPDS_SignatorySetup.aspx?s1=" + Request.QueryString[0].ToString());
                    }
                    else
                    {
                        TXT_SIGNATORY_NAME_INSERT.Text = "";
                    }
                }
                else
                {
                    lblDuplicate_INSERT.Text = "Select JPG image file";
                    return;
                }
            }
        }

    }
    protected void UpdateCancelButton_Click(object sender, EventArgs e)
    {


    }
    protected void BTN_INSERT_Click(object sender, EventArgs e)
    {
        Page.Validate();
        if (Page.IsValid)
        {
            LOV_COLLECTION L = new LOV_COLLECTION();
            DataSet DS;
            DS = L.SP_SignatorySetup_DP(TXT_SIGNATORY_NAME_INSERT.Text, "0");
            if (DS.Tables[0].Rows.Count > 0)
            {
                Session["error1"] = "Duplicate Record";
                lblDuplicate_INSERT.Text = "Duplicate Record";
            }
            else
            {
                if (Path.GetExtension(TXT_UPLOAD_IMAGE_PATH_INSERT.FileName.ToLower()) == ".jpg")
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
                        parm[pno] = obj_DBLayer.Oracle_Param("v_SIGNATORY_NAME", OracleType.VarChar, ParameterDirection.Input, TXT_SIGNATORY_NAME_INSERT.Text);
                        pno++;
                        parm[pno] = new OracleParameter();
                        parm[pno] = obj_DBLayer.Oracle_Param("v_UPLOAD_IMAGE_PATH", OracleType.VarChar, ParameterDirection.Input, TXT_UPLOAD_IMAGE_PATH_INSERT.FileName.ToString());
                        pno++;
                        parm[pno] = new OracleParameter();
                        parm[pno] = obj_DBLayer.Oracle_Param("v_UPLOAD_IMAGE", OracleType.Blob, ParameterDirection.Input, TXT_UPLOAD_IMAGE_PATH_INSERT.FileBytes);
                        pno++;
                        parm[pno] = new OracleParameter();
                        parm[pno] = obj_DBLayer.Oracle_Param("v_CURRENT_STATUS", OracleType.VarChar, ParameterDirection.Input, DDL_CURRENT_STATUS_INSERT.SelectedValue);
                        pno++;
                        parm[pno] = new OracleParameter();
                        parm[pno] = obj_DBLayer.Oracle_Param("v_A_UserID", OracleType.VarChar, ParameterDirection.Input, Session["U_NAME"].ToString());
                        pno++;
                        parm[pno] = new OracleParameter();
                        parm[pno] = obj_DBLayer.Oracle_Param("v_return", OracleType.VarChar, ParameterDirection.Output, "");

                        v_return = obj_DBLayer.Oracle_GetDataSetSP_DML("SP_SET_INSERT_SignatorySetup", parm, pno);
                        if (v_return.StartsWith("0"))
                        {
                            TXT_UPLOAD_IMAGE_PATH_INSERT.SaveAs(Server.MapPath("~") + "\\SignatureImage\\" + TXT_UPLOAD_IMAGE_PATH_INSERT.FileName.ToString());
                        }
                        else
                        {
                            lblDuplicate_INSERT.Text = v_return.Replace("1;", "");
                        }
                        Response.Redirect("../SignatorySetup/frmSPDS_SignatorySetup.aspx?s1=" + Request.QueryString[0].ToString());
                    }
                    else
                    {

                        TXT_SIGNATORY_NAME_INSERT.Text = "";
                    }
                }
                else
                {
                    lblDuplicate_INSERT.Text = "Select JPG image file";
                    return;
                }
            }
        }
    }
    protected void BTN_RESET_Click(object sender, EventArgs e)
    {
        TXT_SIGNATORY_NAME_INSERT.Text = "";
        txtusername.Text = "";
    }
    protected void BTN_INSERT_CANCEL_Click(object sender, EventArgs e)
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
        Response.Redirect("../SignatorySetup/frmSPDS_SignatorySetup.aspx?s1=" + Request.QueryString[0].ToString());
    }
    protected void btnlov_Click(object sender, ImageClickEventArgs e)
    {
        if (Session["LOV_DESCRIPTION"] != null && Session["LOV_DESCRIPTION"].ToString() != "")
        {
            TXT_SIGNATORY_NAME_INSERT.Text = Session["LOV_DESCRIPTION"].ToString();
            txtusername.Text = Session["LOV_RealName"].ToString();
        }
    }
    void FillControl()
    {
        DataSet DS = lov.Get_SPDS_SignatorySetup_SPC(Session["ROWID"].ToString());
        TXT_SIGNATORY_NAME_INSERT.Text = DS.Tables[0].Rows[0]["SIGNATORY_NAME"].ToString();
        txtusername.Text = DS.Tables[0].Rows[0]["REAL_NAME"].ToString();
        Session["ROWID"] = "";
    }
}

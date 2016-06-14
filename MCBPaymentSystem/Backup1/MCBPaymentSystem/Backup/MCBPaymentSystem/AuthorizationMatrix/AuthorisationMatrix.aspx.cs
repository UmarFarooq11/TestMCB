using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OracleClient;

public partial class AuthorizationMatrix_AuthorisationMatrix_ : System.Web.UI.Page
{
    LOV_COLLECTION obj_collection = new LOV_COLLECTION();
    DatabaseConnection_Util obj_DBLayer = new DatabaseConnection_Util();
    TextBox txtfrmamt, txttoamt, txtnumofSign; //grdiview template control 
    DropDownList ddlMak, ddlChk, ddlSingle, ddlDual, ddlTriple, ddlPublish; //grdiview template control
    string[] ARY;
    string RGS_SUPPORT;

    protected void Page_Load(object sender, EventArgs e)
    {
        ViewState["QS"] = Request.QueryString;
        Response.Cache.SetCacheability(HttpCacheability.ServerAndNoCache);
        //Master.Authorize_Center_False();
        Session["RGS"] = "00000";
        String ST = Startup_Util.DcryptionPWD(Request.QueryString[0].ToString());
        ARY = ST.Split('~');
        Session["RGS"] = ARY[0].ToString();
        RGS_SUPPORT = Session["RGS"].ToString();

        if (RGS_SUPPORT.Substring(2, 1) == "0")
        {
            UpdateButton.Visible = RGS_SUPPORT.Substring(0, 1) == "1" ? false : true;
            BTN_DELETE.Visible = RGS_SUPPORT.Substring(0, 1) == "1" ? false : true;
            btnedit.Enabled = false; /*Edit*/
        }

        else if (RGS_SUPPORT.Substring(2, 1) == "1")
        {
            UpdateButton.Visible = RGS_SUPPORT.Substring(0, 1) == "1" ? false : true;
            BTN_DELETE.Visible = RGS_SUPPORT.Substring(0, 1) == "1" ? false : true;
            btnedit.Enabled = true; /*Edit*/
        }

        btnautho.Visible = RGS_SUPPORT.Substring(4, 1) == "1" ? true : false;
        if (RGS_SUPPORT.Substring(3, 1) == "0")
        {
            Response.Redirect("../MasterPage/Default2.aspx"); /*QUERY*/
            MessageClass.MessageBox.Show("Access Deined");
        }

        if (!IsPostBack)
        {
            fillddllist();
            FillGrid();

        }
    }
    protected void Page_PreRender(object sender, EventArgs e)
    {
        if (!IsPostBack)
            CustomerProductAccountSetup();

    }
    void fillddllist()
    {
        DataSet Customer_Ds = obj_collection.Get_RPS_CustomerSetup_LOV("%", "%");
        ddlcompany.DataSource = Customer_Ds;
        ddlcompany.DataTextField = "BANKNAME";
        ddlcompany.DataValueField = "BANKCODE";
        ddlcompany.DataBind();
        ddlcompany.Items.Insert(0, "--Select--");
    }
    DataTable TempDataTable()
    {
        DataTable VDT = new DataTable();
        VDT.Columns.Add("tmp");
        DataRow dr;

        for (int i = 0; i < 10; i++)
        {
            dr = VDT.NewRow();
            dr[0] = string.Empty;

            VDT.Rows.Add(dr);
        }
        return VDT;
    }
    protected void ddlcompany_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblmsg.Text = "";
        DataSet Product_Ds = obj_collection.Get_SPDS_ProductMaster_AMatrix(ddlcompany.SelectedValue);
        if (Product_Ds.Tables[0].Rows.Count > 0)
        {
            ddlproduct.Items.Clear();
            ddlproduct.DataSource = Product_Ds;
            ddlproduct.DataTextField = "Product_name";
            ddlproduct.DataValueField = "Product_code";
            ddlproduct.DataBind();

            grd_matrix.DataSource = TempDataTable();
            grd_matrix.DataBind();
        }
        else
        {
            lblmsg.Text = "Product Not Found";
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        int index = 0;
        while (index < grd_matrix.Rows.Count)
        {
            txtfrmamt = (TextBox)grd_matrix.Rows[index].FindControl("txtfrmamt");
            //txtfrmamt.Text = grd_matrix.Rows[index].Cells[0].Text;
            if (txtfrmamt.Text != "")
            {
                break;
            }
            index++;
        }
        if (txtfrmamt.Text != "")
        {
            if (ValidateMatrixGrid() == true)
            {
                DMLOperation("I");
                btnreturn_Click(null, null);
            }
        }
        else
        {
            this.lblmsg.Text = "Enter From Amount";
        }
        //if (ViewState["EDIT"].ToString() == "Y")
        //{
        //    AuthoOperation("D");
        //    DMLOperation("I");
        //    btnreturn_Click(null, null);
        //}
        //else
        //{
        //    if (ValidateMatrixGrid() == true)
        //    {
        //        DMLOperation("I");
        //        btnreturn_Click(null, null);
        //    }
        //}
    }
    void GetTemplateControlReference(int RowIndex)
    {
        txtfrmamt = (TextBox)grd_matrix.Rows[RowIndex].FindControl("txtfrmamt");
        txttoamt = (TextBox)grd_matrix.Rows[RowIndex].FindControl("txttoamt");
        txtnumofSign = (TextBox)grd_matrix.Rows[RowIndex].FindControl("txtnumofSign");
        ddlMak = (DropDownList)grd_matrix.Rows[RowIndex].FindControl("ddlMak");
        ddlChk = (DropDownList)grd_matrix.Rows[RowIndex].FindControl("ddlChk");
        ddlSingle = (DropDownList)grd_matrix.Rows[RowIndex].FindControl("ddlSingle");
        ddlDual = (DropDownList)grd_matrix.Rows[RowIndex].FindControl("ddlDual");
        ddlTriple = (DropDownList)grd_matrix.Rows[RowIndex].FindControl("ddlTriple");
        ddlPublish = (DropDownList)grd_matrix.Rows[RowIndex].FindControl("ddlPublish");
    }
    void DMLOperation(string Action)
    {
        OracleParameter[] parms = new OracleParameter[15];

        for (int i = 0; i < grd_matrix.Rows.Count; i++)
        {
            GetTemplateControlReference(i);

            if (txtfrmamt.Text != "")
            {
                parms[0] = new OracleParameter();
                parms[0] = obj_DBLayer.Oracle_Param("P_company_code", OracleType.VarChar, ParameterDirection.Input, ddlcompany.SelectedValue);

                parms[1] = new OracleParameter();
                parms[1] = obj_DBLayer.Oracle_Param("P_product_code", OracleType.VarChar, ParameterDirection.Input, ddlproduct.SelectedValue);

                parms[2] = new OracleParameter();
                parms[2] = obj_DBLayer.Oracle_Param("P_follow_seq", OracleType.VarChar, ParameterDirection.Input, chkflowSeq.Checked == true ? "Y" : "N");

                parms[3] = new OracleParameter();
                parms[3] = obj_DBLayer.Oracle_Param("P_from_amount", OracleType.VarChar, ParameterDirection.Input, txtfrmamt.Text);

                parms[4] = new OracleParameter();
                parms[4] = obj_DBLayer.Oracle_Param("P_to_amount", OracleType.VarChar, ParameterDirection.Input, txttoamt.Text);

                parms[5] = new OracleParameter();
                parms[5] = obj_DBLayer.Oracle_Param("P_maker_cat", OracleType.VarChar, ParameterDirection.Input, ddlMak.SelectedItem.Text);

                parms[6] = new OracleParameter();
                parms[6] = obj_DBLayer.Oracle_Param("P_check_cat", OracleType.VarChar, ParameterDirection.Input, ddlChk.SelectedItem.Text);

                parms[7] = new OracleParameter();
                parms[7] = obj_DBLayer.Oracle_Param("P_no_of_sign", OracleType.VarChar, ParameterDirection.Input, txtnumofSign.Text);

                parms[8] = new OracleParameter();
                parms[8] = obj_DBLayer.Oracle_Param("P_single_cat", OracleType.VarChar, ParameterDirection.Input, ddlSingle.SelectedItem.Text);

                parms[9] = new OracleParameter();
                parms[9] = obj_DBLayer.Oracle_Param("P_dual_cat", OracleType.VarChar, ParameterDirection.Input, ddlDual.SelectedItem.Text);

                parms[10] = new OracleParameter();
                parms[10] = obj_DBLayer.Oracle_Param("P_triple_cat", OracleType.VarChar, ParameterDirection.Input, ddlTriple.SelectedItem.Text);

                parms[11] = new OracleParameter();
                parms[11] = obj_DBLayer.Oracle_Param("P_publisher", OracleType.VarChar, ParameterDirection.Input, ddlPublish.SelectedItem.Text);

                parms[12] = new OracleParameter();
                parms[12] = obj_DBLayer.Oracle_Param("P_User", OracleType.VarChar, ParameterDirection.Input, Session["U_NAME"].ToString());

                parms[13] = new OracleParameter();
                parms[13] = obj_DBLayer.Oracle_Param("P_active", OracleType.VarChar, ParameterDirection.Input, chkactive.Checked == true ? "Y" : "N");

                parms[14] = new OracleParameter();
                parms[14] = obj_DBLayer.Oracle_Param("P_What", OracleType.VarChar, ParameterDirection.Input, Action);

                obj_DBLayer.Oracle_GetDataSetSP_DML("SP_DMLAuthorizationMatrix", parms);

                parms.Initialize();
            }
        }


    }
    void FillGrid()
    {
        string CompanyCD = Session["COMCode"].ToString();
        string ProductCD = Session["ProductCode"].ToString();
        string Mode = Session["Mode"].ToString();
        ViewState["EDIT"] = "N";
        if (CompanyCD != "" && ProductCD != "")
        {
            DataSet GetMatrixData = obj_collection.Get_AuthorizationMatrix(CompanyCD, ProductCD, Mode);
            if (GetMatrixData.Tables[0].Rows.Count > 0)
            {
                ddlcompany.SelectedValue = GetMatrixData.Tables[0].Rows[0]["company_code"].ToString();
                ddlcompany_SelectedIndexChanged(null, null);
                ddlproduct.SelectedValue = GetMatrixData.Tables[0].Rows[0]["product_code"].ToString();
                chkactive.Checked = GetMatrixData.Tables[0].Rows[0]["active"].ToString() == "Y" ? true : false;
                //chkflowSeq.Checked = GetMatrixData.Tables[0].Rows[0]["follow_seq"].ToString() == "Y" ? true : false;

                for (int i = 0; i < GetMatrixData.Tables[0].Rows.Count; i++)
                {
                    GetTemplateControlReference(i);
                    txtfrmamt.Text = GetMatrixData.Tables[0].Rows[i]["from_amount"].ToString();
                    txttoamt.Text = GetMatrixData.Tables[0].Rows[i]["to_amount"].ToString();
                    ddlMak.SelectedValue = GetMatrixData.Tables[0].Rows[i]["maker_cat"].ToString();
                    ddlChk.SelectedValue = GetMatrixData.Tables[0].Rows[i]["check_cat"].ToString();
                    txtnumofSign.Text = GetMatrixData.Tables[0].Rows[i]["no_of_sign"].ToString();
                    ddlSingle.SelectedValue = GetMatrixData.Tables[0].Rows[i]["single_cat"].ToString();
                    ddlDual.SelectedValue = GetMatrixData.Tables[0].Rows[i]["dual_cat"].ToString();
                    ddlTriple.SelectedValue = GetMatrixData.Tables[0].Rows[i]["triple_cat"].ToString();
                    ddlPublish.SelectedValue = GetMatrixData.Tables[0].Rows[i]["publisher"].ToString();
                    chkflowSeq.Checked = GetMatrixData.Tables[0].Rows[i]["FOLLOW_SEQ"].ToString() == "Y" ? true : false;
                    ViewState["EDIT"] = "Y";
                    ddlproduct.Enabled = false;
                    ddlcompany.Enabled = false;
                    EnableDisableGridControl(false);
                    btnedit.Visible = Session["RGS"].ToString().Substring(2, 1) == "1" ? true : false;
                    BTN_DELETE.Visible = RGS_SUPPORT.Substring(0, 1) == "1" ? true : false;
                    BTN_INSERT.Visible = false; btnreset.Visible = false;
                }
            }
        }
    }
    void EnableDisableGridControl(bool Action)
    {
        for (int i = 0; i < grd_matrix.Rows.Count; i++)
        {
            GetTemplateControlReference(i);
            txtfrmamt.Enabled = Action;
            txttoamt.Enabled = Action;
            txtnumofSign.Enabled = Action;
            //ddlSigNo.Enabled = Action;
            ddlMak.Enabled = Action;
            ddlChk.Enabled = Action;
            ddlSingle.Enabled = Action;
            ddlDual.Enabled = Action;
            ddlTriple.Enabled = Action;
            ddlPublish.Enabled = Action;
        }
        chkflowSeq.Enabled = Action;
        chkactive.Enabled = Action;
    }
    protected void btnedit_Click(object sender, EventArgs e)
    {
        EnableDisableGridControl(true);
        //BTN_INSERT.Enabled = true;
        ddlproduct.Enabled = true;
        btnedit.Visible = false; UpdateButton.Visible = true;
    }
    protected void btnreturn_Click(object sender, EventArgs e)
    {
        Response.Redirect("AuthorisationMatrixView.aspx?" + ViewState["QS"]);
    }
    void AuthoOperation(string Action)
    {
        OracleParameter[] parms = new OracleParameter[15];
        int i = 0;

        GetTemplateControlReference(i);

        if (txtfrmamt.Text != "")
        {
            parms[0] = new OracleParameter();
            parms[0] = obj_DBLayer.Oracle_Param("P_company_code", OracleType.VarChar, ParameterDirection.Input, ddlcompany.SelectedValue);

            parms[1] = new OracleParameter();
            parms[1] = obj_DBLayer.Oracle_Param("P_product_code", OracleType.VarChar, ParameterDirection.Input, ddlproduct.SelectedValue);

            parms[2] = new OracleParameter();
            parms[2] = obj_DBLayer.Oracle_Param("P_follow_seq", OracleType.VarChar, ParameterDirection.Input, chkflowSeq.Checked == true ? "Y" : "N");

            parms[3] = new OracleParameter();
            parms[3] = obj_DBLayer.Oracle_Param("P_from_amount", OracleType.VarChar, ParameterDirection.Input, txtfrmamt.Text);

            parms[4] = new OracleParameter();
            parms[4] = obj_DBLayer.Oracle_Param("P_to_amount", OracleType.VarChar, ParameterDirection.Input, txttoamt.Text);

            parms[5] = new OracleParameter();
            parms[5] = obj_DBLayer.Oracle_Param("P_maker_cat", OracleType.VarChar, ParameterDirection.Input, ddlMak.SelectedItem.Text);

            parms[6] = new OracleParameter();
            parms[6] = obj_DBLayer.Oracle_Param("P_check_cat", OracleType.VarChar, ParameterDirection.Input, ddlChk.SelectedItem.Text);

            parms[7] = new OracleParameter();
            parms[7] = obj_DBLayer.Oracle_Param("P_no_of_sign", OracleType.VarChar, ParameterDirection.Input, txtnumofSign.Text);

            parms[8] = new OracleParameter();
            parms[8] = obj_DBLayer.Oracle_Param("P_single_cat", OracleType.VarChar, ParameterDirection.Input, ddlSingle.SelectedItem.Text);

            parms[9] = new OracleParameter();
            parms[9] = obj_DBLayer.Oracle_Param("P_dual_cat", OracleType.VarChar, ParameterDirection.Input, ddlDual.SelectedItem.Text);

            parms[10] = new OracleParameter();
            parms[10] = obj_DBLayer.Oracle_Param("P_triple_cat", OracleType.VarChar, ParameterDirection.Input, ddlTriple.SelectedItem.Text);

            parms[11] = new OracleParameter();
            parms[11] = obj_DBLayer.Oracle_Param("P_publisher", OracleType.VarChar, ParameterDirection.Input, ddlPublish.SelectedItem.Text);

            parms[12] = new OracleParameter();
            parms[12] = obj_DBLayer.Oracle_Param("P_User", OracleType.VarChar, ParameterDirection.Input, Session["U_NAME"].ToString());

            parms[13] = new OracleParameter();
            parms[13] = obj_DBLayer.Oracle_Param("P_active", OracleType.VarChar, ParameterDirection.Input, chkactive.Checked == true ? "Y" : "N");

            parms[14] = new OracleParameter();
            parms[14] = obj_DBLayer.Oracle_Param("P_What", OracleType.VarChar, ParameterDirection.Input, Action);

            obj_DBLayer.Oracle_GetDataSetSP_DML("SP_DMLAuthorizationMatrix", parms);

            parms.Initialize();
        }
    }
    protected void btnautho_Click(object sender, EventArgs e)
    {
        AuthoOperation("A");
        Response.Redirect("AuthorisationMatrixView.aspx?" + ViewState["QS"]);
    }
    bool ValidateMatrixGrid()
    {
        lblmsg.Text = "";
        bool chk = true;
        for (int i = 0; i < grd_matrix.Rows.Count; i++)
        {
            GetTemplateControlReference(i);
            if (txtfrmamt.Text != "")
            {
                if (txtfrmamt.Text == "") { chk = false; lblmsg.Text = "Enter from amount"; goto EndofCode; }
                if (txttoamt.Text == "") { chk = false; lblmsg.Text = "Enter to amount"; goto EndofCode; }
                if (Convert.ToInt64(txttoamt.Text) <= Convert.ToInt64(txtfrmamt.Text)) { chk = false; lblmsg.Text = "To amount must be greater then from amount"; goto EndofCode; }
                if (ddlMak.SelectedIndex == 0) { chk = false; lblmsg.Text = "Select Maker group"; goto EndofCode; }
                if (txtnumofSign.Text == "") { ddlSingle.SelectedIndex = 0; ddlDual.SelectedIndex = 0; ddlTriple.SelectedIndex = 0; }
                if (txtnumofSign.Text == "1" && ddlSingle.SelectedIndex == 0) { chk = false; lblmsg.Text = "Select single signatory group"; goto EndofCode; }
                if (txtnumofSign.Text == "2" && ddlSingle.SelectedIndex == 0 && ddlDual.SelectedIndex == 0) { chk = false; lblmsg.Text = "Select single and Dual signatory group"; goto EndofCode; }
                if (txtnumofSign.Text == "2" && ddlSingle.SelectedIndex == 0 && ddlDual.SelectedIndex == 0 && ddlTriple.SelectedIndex == 0) { chk = false; lblmsg.Text = "Select single , Dual and triple  signatory group"; goto EndofCode; }
            }
        }

    EndofCode:
        return chk;
    }
    protected void btnreset_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < grd_matrix.Rows.Count; i++)
        {
            GetTemplateControlReference(i);
            txtfrmamt.Text = "";
            txttoamt.Text = "";
            txtnumofSign.Text = "";
            //ddlSigNo.SelectedIndex = 0;
            ddlMak.SelectedIndex = 0;
            ddlChk.SelectedIndex = 0;
            ddlSingle.SelectedIndex = 0;
            ddlDual.SelectedIndex = 0;
            ddlTriple.SelectedIndex = 0;
            ddlPublish.SelectedIndex = 0;
        }
        lblmsg.Text = "";
    }
    void CustomerProductAccountSetup()
    {
        DataSet UserDs = obj_collection.Get_Company_CodebyUser(Session["U_NAME"].ToString());
        if (UserDs.Tables[0].Rows.Count > 0)
        {
            if (UserDs.Tables[0].Rows[0]["USER_TYPE"].ToString() == "COMPANY")
            {
                Session["COMCode"] = UserDs.Tables[0].Rows[0]["COMPANY_CODE"].ToString();
                ddlcompany.SelectedValue = UserDs.Tables[0].Rows[0]["COMPANY_CODE"].ToString();
                ddlcompany.Enabled = false;
                ddlcompany_SelectedIndexChanged(null, null);
                FillGrid();
            }
        }
    }
    protected void UpdateButton_Click(object sender, EventArgs e)
    {
        if (ViewState["EDIT"].ToString() == "Y")
        {
            AuthoOperation("D");
            DMLOperation("I");
            btnreturn_Click(null, null);
        }
    }
}

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
using iCORE.RPS.BUSINESSOBJECTS.CONTROLLER;
using iCORE.RPS.BUSINESSOBJECTS.ENTITIES;
using iCORE.RPS.DATAOBJECTS ;
using iCORE.RPS.PRESENTATIONOBJECTS.Cmn;
using iCORE.XMS.DATAOBJECTS;
public partial class HoldReleaseDraft_HoldReleaseDraft : System.Web.UI.Page
{
    private IDataManager entityDataManager;
  
    private Result rslt, rsltDraft, rsltRemitter, rsltBeneficiary, rsltPOD;
    private string objectName = "Draft";

    private DraftCommand DraftEntity;
    private BeneficiaryCommand BeneficiaryEntity;
    private RemittanceCommand RemmittanceEntity;
    private RemitterCommand RemmitterEntity;
    private PODCommand PODEntity;
    private IDataManager draftdatamanager;
    private IDataManager Remittancedatamanager;
    private IDataManager Beneficiarydatamanager;
    private IDataManager Remitterdatamanager;
    private IDataManager poddatamanager;
    private GridViewRow drv;
    LOV_COLLECTION lov = new LOV_COLLECTION();
    protected void Page_PreInit(object sender, EventArgs e)
    { Page.Theme = Session["ThemeChange"].ToString(); }
    protected void Page_Load(object sender, EventArgs e)
    {
        //ConnectionBean.ConnectionString = "Data Source=CR-ML150;Initial Catalog=samba_spds;User ID=sa;Password=";
        try
         {
            Response.Cache.SetCacheability(HttpCacheability.ServerAndNoCache);
            
            Session["UserId"]=Session["U_NAME"].ToString();

                DraftEntity = RuntimeClassLoader.GetEntity(objectName) as DraftCommand;
                BeneficiaryEntity = RuntimeClassLoader.GetEntity("Beneficiary") as BeneficiaryCommand;
                RemmittanceEntity = RuntimeClassLoader.GetEntity("Remittance") as RemittanceCommand;
                RemmitterEntity = RuntimeClassLoader.GetEntity("Remitter") as RemitterCommand;
                PODEntity = RuntimeClassLoader.GetEntity("POD") as PODCommand;

                entityDataManager = RuntimeClassLoader.GetDataManager(objectName);
                draftdatamanager = RuntimeClassLoader.GetDataManager(objectName);
                Remittancedatamanager = RuntimeClassLoader.GetDataManager("Remittance");
                Beneficiarydatamanager = RuntimeClassLoader.GetDataManager("Beneficiary");
                Remitterdatamanager = RuntimeClassLoader.GetDataManager("Remitter");
                poddatamanager = RuntimeClassLoader.GetDataManager("POD");
                if (!IsPostBack)
                {
                    Session["RowId"] = 0;
                    Session["DraftNo"]="";                   

                    this.btnHoldReleasedraft.Enabled = true;

                    //btnTextCodeLookup.Attributes.Add("onclick", "wid=window.showModalDialog('../LOV/ListOfRecord.aspx?DataManager=DefaultMessages&Id=0&Entity=" + "" + "&Text=Text Code List&Values="+""+"&ListType=LookupList', 'CS', 'left=250,top=165,height=400, width= 500 ,menubar=no,location=no,toolbar=no,scrollbars=yes,resizable=no');");

                    txbDraftCurrency.Attributes.Add("style", "text-align: right;");

                    this.btnTextCodeSearch.Attributes.Add("style", "visibility: hidden;");
                    txbTextCode.Attributes.Add("onchange", "return SearchTextCode();");


                    //-----------This two lines create error---------
                    //rslt = (entityDataManager as DraftDataManager).GetAllHolded();
                    //Session["DataSource"] = rslt.dstResult.Tables[0];
                    
                    //btnHolded.Attributes.Add("onclick", "wid=window.showModalDialog('../LOV/ListOfRecord.aspx?DataManager=Draft&Id=0&Entity=" + "" + "&Text=Draft List&Values=" + "" + "&ListType=SetupList&IsDataSource=1', 'CS', 'left=250,top=165,height=400, width= 500 ,menubar=no,location=no,toolbar=no,scrollbars=yes,resizable=no');");

                    Session["GetAll"] = "HoldReleaseDraft";
                    //btnReleased.Attributes.Add("onclick", "wid=window.showModalDialog('../LOV/ListOfRecord.aspx?DataManager=Draft&Id=0&Entity=" + "" + "&Text=Draft List&Values=" + "" + "&ListType=SpecificList', 'CS', 'left=250,top=165,height=400, width= 500 ,menubar=no,location=no,toolbar=no,scrollbars=yes,resizable=no');");
                    //((ScriptManager)Master.FindControl("ScriptManager1")).SetFocus(txbTextCode);
                    Session["drv"] = "";
                    Session["drw"] = "";
                }
            /*
                if ((int)Session["RowId"] > 0 && Session["DraftNo"].ToString().Length > 0 && btnHoldReleasedraft.Text == "Hold Draft")
                    btnHoldReleasedraft.Attributes.Add("onclick", "wid=window.showModalDialog('../Transaction/MiscellaneousMsg.aspx?DraftId=" + Session["RowId"].ToString() + "&PriorityCode=601&DraftNo=" + Session["DraftNo"].ToString() + "&HoldReason=" + txbHoldReason.Text + "',null,'status:no;dialogWidth:1200px;dialogHeight:850px;dialogHide:true;help:no;scroll:yes');");
                else
                {
                    btnHoldReleasedraft.Attributes.Remove("onclick");
                }*/
                
        }
        catch (Exception ex)
        {
            lbl_Message.Text = ex.Message;
           // DataManager.SQLManager.LogException("HR_Transaction_CourierFeedback", "Page_Load", ex, Session["UserId"].ToString());
        }
    }

    private void Clear()
    {
        Session["RowId"] = 0;
        this.txbTextCode.Text = null;
        this.txbPODNo.Text = null;
        this.txbAlternateFirstName.Text = null;
        this.txbAlternateLastName.Text = null;
        this.txbBeneficiaryAddress.Text = null;
        this.txbBeneficiaryCity.Text = null;
        this.txbBeneficiaryFirstName.Text = null;
        this.txbBeneficiaryLastName.Text = null; ;
        this.txbBeneficiaryMiddleName.Text = null;
        this.txbBeneficiaryNo.Text = null;
        this.txbBeneficiaryZipCode.Text = null;
        //  this.txbBeneficiaryZipCodeDesc.Text = null;
        //this.txbDraftAlternateName.Text = null;
        this.txbDraftBankCode.Text = null;
        this.txbDraftBankName.Text = null;
        this.txbDraftCoverAmountUSD.Text = null;
        this.txbDraftCurrency.Text = null;
        this.txbDraftDate.Text = null;
        // this.txbDraftLocation.Text = null;
        this.txbDraftNo.Text = null;
        this.txbDraftTransactionAmount.Text = null;
        // this.txbDraftZipCode.Text = null;
        this.txbPODDate.Text = null;
        this.txbPODDeliveryDate.Text = null;
        this.txbPODNo.Text = null;
        this.txbPODStatusCode.Text = null;
        this.txbPODStatusDate.Text = null;
        this.txbPODStatusDescription.Text = null;
        this.txbRemitterCity.Text = null;
        this.txbRemitterDeliveryDate.Text = null;
        this.txbRemitterFirstName.Text = null;
        this.txbRemitterLastName.Text = null;
        this.txbRemitterMiddleName.Text = null;
        this.txbRemitterNo.Text = null;
        this.txbRemitterPOBoxNo.Text = null;
        this.txbRemitterReferenceNo.Text = null;
        this.txbRemitterZipCode.Text = null;
        this.txbDraftRate.Text = null;
        this.txbHoldReason.Text = "";
        //this.lblHoldReason.Text = "";
        lbl_Message.Text = "";
        //((ScriptManager)Master.FindControl("ScriptManager1")).SetFocus(txbTextCode);
    }

    private void ShowHoldedList()
    {
        try
        {
            lbl_Message.Text = "";            
            FillData();
            //((ScriptManager)Master.FindControl("ScriptManager1")).SetFocus(btnHoldReleasedraft);
        }
        catch (Exception ex)
        {
            lbl_Message.Text = ex.Message;
            //DataManager.SQLManager.LogException("HR_Transaction_CourierFeedback", "ShowHoldedList", ex, Session["UserId"].ToString());
        }
    }

    private void ShowReleasedList()
    {
        try
        {
            lbl_Message.Text = "";
            FillData();
            //((ScriptManager)Master.FindControl("ScriptManager1")).SetFocus(btnHoldReleasedraft);
           
        }     
        catch (Exception ex)
        {
            lbl_Message.Text = ex.Message;
            //DataManager.SQLManager.LogException("HR_Transaction_CourierFeedback", "ShowReleasedList", ex, Session["UserId"].ToString());
        }
    }

    private void FillData()
    {
        try
        {
            if (Session["drv"].ToString() != "")
            {
                //drv = (GridViewRow)Session["drv"];
                DataRow drw = (DataRow)Session["drw"];

                txbTextCode.Text = null;
                Session["RowId"] = drw["ID"];
                this.txbBeneficiaryNo.Text = drw["BeneficiaryNo"].ToString();
                this.txbDraftNo.Text = drw["DraftNo"].ToString();
                Session["DraftNo"] = drw["DraftNo"].ToString();
                this.txbRemitterNo.Text = drw["RemitterNo"].ToString();
                this.txbPODNo.Text = drw["PODNo"].ToString();
                this.txbDraftDate.Text = drw["DraftDate"].ToString();
                this.txbDraftRate.Text = drw["Rate"].ToString();
                rsltDraft = (draftdatamanager as DraftDataManager).GetByCode(drw["DraftNo"].ToString());
                //rsltRemitter = (Remitterdatamanager as RemitterDataManager).GetByCode(drw["RemitterNo"].ToString());
                rsltRemitter = (Remitterdatamanager as RemitterDataManager).GetByCode(drw["DraftNo"].ToString());
                //IBRAHIM //rsltPOD = (poddatamanager as PODDataManager).GetByCode(drw["PODNo"].ToString());
                if (rsltRemitter.dstResult.Tables[0].Rows.Count > 0)
                {
                    Session["RemitterId"] = Convert.ToInt32(rsltRemitter.dstResult.Tables[0].Rows[0]["ID"]);
                    this.txbRemitterCity.Text = rsltRemitter.dstResult.Tables[0].Rows[0]["City"].ToString();
                    this.txbRemitterFirstName.Text = rsltRemitter.dstResult.Tables[0].Rows[0]["FirstName"].ToString();
                    this.txbRemitterLastName.Text = rsltRemitter.dstResult.Tables[0].Rows[0]["LastName"].ToString();
                    this.txbRemitterMiddleName.Text = rsltRemitter.dstResult.Tables[0].Rows[0]["MiddleName"].ToString();
                    this.txbRemitterPOBoxNo.Text = rsltRemitter.dstResult.Tables[0].Rows[0]["POBoxNo"].ToString();
                    this.txbRemitterZipCode.Text = rsltRemitter.dstResult.Tables[0].Rows[0]["ZipCode"].ToString();

                    if (rsltRemitter.dstResult.Tables[0].Rows[0]["SDNDiscrepant"].ToString() == "True")
                        chbRemSDNDiscrepant.Checked = true;
                    else
                        chbRemSDNDiscrepant.Checked = false;
                    if (rsltRemitter.dstResult.Tables[0].Rows[0]["AMLDiscrepant"].ToString() == "True")
                        chbRemAMLDiscrepant.Checked = true;
                    else
                        chbRemAMLDiscrepant.Checked = false;

                    //rsltBeneficiary = (Beneficiarydatamanager as BeneficiaryDataManager).GetByCode(Convert.ToInt32(rsltRemitter.dstResult.Tables[0].Rows[0]["ID"]), this.txbBeneficiaryNo.Text);
                   // rsltBeneficiary = (Beneficiarydatamanager as BeneficiaryDataManager).GetByCode(326889, drw["BeneficiaryNo"].ToString());
                    LOV_COLLECTION L = new LOV_COLLECTION();
                    DataSet DS;
                    //DS = L.RPS_SP_Beneficiary_GetByCode((int)Session["RemitterId"], drw["BeneficiaryNo"].ToString());
                    DS = L.RPS_SP_Beneficiary_GetByCode(Session["RemitterId"].ToString(), drw["BeneficiaryNo"].ToString());


                    if (DS.Tables[0].Rows.Count > 0)
                    {
                        Session["BeneficiaryId"] = Convert.ToInt32(DS.Tables[0].Rows[0]["ID"]);
                        this.txbAlternateFirstName.Text = DS.Tables[0].Rows[0]["AlternateFirstName"].ToString();
                        this.txbAlternateMiddleName.Text = DS.Tables[0].Rows[0]["AlternateMiddleName"].ToString();
                        this.txbAlternateLastName.Text = DS.Tables[0].Rows[0]["AlternateLastName"].ToString();
                        this.txbBeneficiaryAddress.Text = DS.Tables[0].Rows[0]["Address1"].ToString();
                        this.txbBeneficiaryCity.Text = DS.Tables[0].Rows[0]["City"].ToString();
                        this.txbBeneficiaryFirstName.Text = DS.Tables[0].Rows[0]["FirstName"].ToString();
                        this.txbBeneficiaryLastName.Text = DS.Tables[0].Rows[0]["LastName"].ToString(); ;
                        this.txbBeneficiaryMiddleName.Text = DS.Tables[0].Rows[0]["MiddleName"].ToString();
                        this.txbBeneficiaryZipCode.Text = DS.Tables[0].Rows[0]["ZipCode"].ToString();
                        if (DS.Tables[0].Rows[0]["SDNDiscrepant"].ToString() == "True")
                            chbBeneSDNDiscrepant.Checked = true;
                        else
                            chbBeneSDNDiscrepant.Checked = false;

                        if (DS.Tables[0].Rows[0]["AMLDiscrepant"].ToString() == "True")
                            chbBeneAMLDiscrepant.Checked = true;
                        else
                            chbBeneAMLDiscrepant.Checked = false;
                    }
                }

                this.txbDraftBankCode.Text = drw["Bank_Code"].ToString();
                this.txbDraftBankName.Text = drw["Bank_Name"].ToString();
                this.txbDraftCoverAmountUSD.Text = drw["CoverAmountUSD"].ToString();
                this.txbDraftCurrency.Text = drw["CurrencyCode"].ToString();
                this.txbDraftTransactionAmount.Text = drw["TransactionAmount"].ToString();
                this.txbRemitterReferenceNo.Text = drw["RemittanceRefNo"].ToString();
                // this.txbDraftZipCode.Text = rsltDraft.dstResult.Tables[0].Rows[0]["StatusDate"].ToString();

                //<IBRAHIM>
                //if (rsltPOD.dstResult.Tables[0].Rows.Count > 0)
                //{
                //    this.txbPODDate.Text = rsltPOD.dstResult.Tables[0].Rows[0]["PODDate"].ToString();
                //    this.txbPODDeliveryDate.Text = rsltPOD.dstResult.Tables[0].Rows[0]["DeliveryDate"].ToString();
                //    this.txbPODNo.Text = rsltPOD.dstResult.Tables[0].Rows[0]["PODNo"].ToString();
                //    this.txbPODStatusCode.Text = rsltPOD.dstResult.Tables[0].Rows[0]["StatusID"].ToString();
                //    this.txbPODStatusDate.Text = rsltPOD.dstResult.Tables[0].Rows[0]["StatusDate"].ToString();
                //    this.txbPODStatusDescription.Text = rsltPOD.dstResult.Tables[0].Rows[0]["StatusDescription"].ToString();
                //}
                //</IBRAHIM>
                bool holdRelease = Convert.ToBoolean(rsltDraft.dstResult.Tables[0].Rows[0]["Holded"].ToString());
                this.txbHoldReason.Text = drw["HoldReason"].ToString();

                if (holdRelease)
                {
                    this.txbHoldReason.ReadOnly = this.txbTextCode.ReadOnly = true;
                    this.btnTextCodeLookup.Enabled = false;
                }
                else
                {
                    this.txbHoldReason.ReadOnly = this.txbTextCode.ReadOnly = false;
                    this.btnTextCodeLookup.Enabled = true;
                }

               ButtonFunctional(holdRelease);
                Session["drv"] = "";
                Session["drw"] = "";
            }
        }
        catch (Exception ex)
        {
            lbl_Message.Text = ex.Message;
            //DataManager.SQLManager.LogException("HR_Transaction_CourierFeedback", "FillData", ex, Session["UserId"].ToString());
        }
    }


    private void ButtonFunctional(bool holdRelease)
    {
        if (holdRelease == true)
        {
            this.btnHoldReleasedraft.Text = "Release Draft";
            btnHoldReleasedraft.OnClientClick = "return confirm('Are you sure you want to Release the Draft?');";
        }
        else
        {
            this.btnHoldReleasedraft.Text = "Hold Draft";
            btnHoldReleasedraft.OnClientClick = "return confirm('Are you sure you want to Hold the Draft?')";
            this.txbHoldReason.Focus();
        }
    }


    
    /*
    private void BuildOpenWindowsJavaScript()
    {
        System.Text.StringBuilder js = new System.Text.StringBuilder();
        js.Append("<script language=\"javascript\">");
        js.Append("\n");
        js.Append("wid=window.showModalDialog('../Transaction/MiscellaneousMsg.aspx?DraftId=" + Session["RowId"].ToString() + "&PriorityCode=601&DraftNo=" + Session["DraftNo"].ToString() + "&HoldReason=" + txbHoldReason.Text + "',null,'status:no;dialogWidth:1200px;dialogHeight:850px;dialogHide:true;help:no;scroll:yes');");
        //js.Append("window.opener.reload();self.close();");
        //js.Append("window.close();");
        js.Append("</script>");

        String js1 = js.ToString();
        // ClientScript.RegisterClientScriptBlock(Type.Missing,"windowsopen", js1);
        Page.RegisterClientScriptBlock("windowsopen", js1);
        //Response.Write(js1);

     //   btnPOD.Attributes.Add("onclick", "wid=window.showModalDialog('../Transaction/MiscellaneousMsg.aspx?DraftId=" + Session["RowId"].ToString() + "&PriorityCode=601&DraftNo=" + Session["DraftNo"].ToString() + "&HoldReason=" + txbHoldReason.Text + "',null,'status:no;dialogWidth:1200px;dialogHeight:850px;dialogHide:true;help:no;scroll:yes');");
                    
    }*/

    protected void btnEdit_Click(object sender, EventArgs e)
    {

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {

    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        Clear();
    }
  
    protected void btnAuthorize_Click(object sender, EventArgs e)
    {

    }
    protected void btnTextCodeSearch_Click(object sender, EventArgs e)
    {
        try
        {
            lbl_Message.Text = "";
            if (this.txbTextCode.Text.Trim().Length > 0)
            {
                IDataManager textCodeEntityDataManager = RuntimeClassLoader.GetDataManager("DefaultMessages");

                rslt = textCodeEntityDataManager.GetByCode(this.txbTextCode.Text);

                if (rslt.isSuccessful && rslt.dstResult.Tables[0].Rows.Count > 0)
                {
                    this.txbHoldReason.Text = rslt.dstResult.Tables[0].Rows[0]["Description"].ToString();
                }
                else
                {
                    this.txbTextCode.Text = null;
                    this.txbHoldReason.Text = null;
                  // lbl_Message.Text = ApplicationMessages.RECORD_NOT_FOUND_MESSAGE;
                    this.txbTextCode.Focus();
                    
                }
            }
        }
        catch (Exception ex)
        {
            lbl_Message.Text = ex.Message;
            //DataManager.SQLManager.LogException("HR_Transaction_CourierFeedback", "btnTextCodeSearch_Click", ex, Session["UserId"].ToString());
        }

    }
    protected void btnReleased_Click(object sender, EventArgs e)
    {
        DataSet ds;
        if (Session["LOV_ID"].ToString() != "")
        {
            ds = lov.Get_GetDraftReleased(Session["LOV_ID"].ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                Session["drw"] = ds.Tables[0].Rows[0];
                Session["drv"] = ds.Tables[0].Rows[0];
                ShowReleasedList();
                Session["drw"] = "";
                Session["drv"] = "";
            }
            else
            { lbl_Message.Text = "Record not found"; }
        }
        

    }
    protected void btnHolded_Click(object sender, EventArgs e)
    {
        if (Session["LOV_ID"].ToString() != "")
        {

            Session["drw"] = lov.Get_GetDraftHolded(Session["LOV_ID"].ToString()).Tables[0].Rows[0];
            Session["drv"] = lov.Get_GetDraftHolded(Session["LOV_ID"].ToString()).Tables[0].Rows[0];

            ShowHoldedList();
            Session["drw"] = "";
            Session["drv"] = "";
            //entityDataManager = RuntimeClassLoader.GetDataManager(objectName);
            //rslt = (entityDataManager as DraftDataManager).GetAllHolded();
            //Session["DataSource"] = rslt.dstResult.Tables[0];
        }
    }
    protected void btnTextCodeLookup_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            if (Session["LOV_ID"].ToString() != "")
            {
                //lbl_Message.Text = "";
               //drv = (GridViewRow)Session["drv"];
                //DataRow drw = (DataRow)Session["drw"];
                this.txbTextCode.Text = Session["LOV_CODE"].ToString();
                this.txbHoldReason.Text = Session["LOV_DESCRIPTION"].ToString();
                //Session["drw"] = "";
                //Session["drv"] = "";
            }
        }
        catch (Exception ex)
        {
            lbl_Message.Text = ex.Message;
            //DataManager.SQLManager.LogException("HR_Transaction_CourierFeedback", "btnServiceTypeLookup_Click", ex, Session["UserId"].ToString());
        }
    }

    protected void btnHoldReleasedraft_Click(object sender, EventArgs e)
    {
        try
        {
            lbl_Message.Text = "";
            DraftDataManager DraftEntityDataManager =
            RuntimeClassLoader.GetDataManager("Draft") as DraftDataManager;
            if (this.btnHoldReleasedraft.Text == "Release Draft")
            {
                btnHoldReleasedraft.OnClientClick = "return confirm('Are you sure you want to Release the Draft?');";
                //rslt = DraftEntityDataManager.MarkRelease((int)Session["RowId"]);
                rslt = DraftEntityDataManager.MarkRelease(Convert.ToInt32(Session["RowId"]));
                LOV_COLLECTION t = new LOV_COLLECTION();
                DataSet ds;
                string remiaml = "";
                string remisdn = "";
                if (chbRemAMLDiscrepant.Checked == true)
                {
                    remiaml = "1";
                }
                else
                {
                    remiaml = "0";
                }
                if (chbRemSDNDiscrepant.Checked == true)
                {
                    remisdn = "1";
                }
                else
                {
                    remisdn = "0";
                }
                ds = t.RPS_SP_Remitter_UpdateSDNAML(Convert.ToInt32(Session["RowId"]), remiaml, remisdn);
                if (ds.Tables[0].Rows.Count>0)
                {
                    lbl_Message.Text = ApplicationMessages.UPDATE_SUCCESS_MESSAGE;

                    this.btnHoldReleasedraft.Text = "Hold Draft";
                    btnHoldReleasedraft.OnClientClick = "return confirm('Are you sure you want to Hold the Draft?')";
                    this.txbHoldReason.ReadOnly = this.txbTextCode.ReadOnly = false;
                    this.btnTextCodeLookup.Enabled = true;
                }
                else
                    lbl_Message.Text =  ApplicationMessages.UPDATE_FAILURE_MESSAGE;
            }
            else if (this.btnHoldReleasedraft.Text == "Hold Draft")
            {
                btnHoldReleasedraft.OnClientClick = "return confirm('Are you sure you want to Hold the Draft?')";
                 rslt = DraftEntityDataManager.MarkHold(Convert.ToInt32(Session["RowId"]), this.txbHoldReason.Text);
                 LOV_COLLECTION rsltBeneficiary = new LOV_COLLECTION();
                 DataSet ds;
                 string beniaml="";
                 string benisdn="";
                 if (chbBeneAMLDiscrepant.Checked==true)
                 {
                     beniaml = "1";
                 }
                 else
                 {
                     beniaml = "0";
                 }
                 if (chbBeneSDNDiscrepant.Checked == true)
                 {
                     benisdn = "1";
                 }
                 else
                 {
                     benisdn = "0";
                 }
                 //ds = rsltBeneficiary.RPS_SP_Beneficiary_UpdateSDNAML((int)Session["BeneficiaryId"], beniaml, benisdn);
                 //Session["BeneficiaryId"] = "1821";
                 ds = rsltBeneficiary.RPS_SP_Beneficiary_UpdateSDNAML(Session["BeneficiaryId"].ToString(), beniaml, benisdn);


                 //rsltBeneficiary = DraftEntityDataManager.MarkBeneficiarySDNAML((int)Session["BeneficiaryId"], chbBeneAMLDiscrepant.Checked,chbBeneSDNDiscrepant.Checked);
                 //Session["RemitterId"] = "1821";
                 //rsltRemitter = DraftEntityDataManager.MarkRemitterSDNAML(Convert.ToInt32(Session["RemitterId"]), chbRemSDNDiscrepant.Checked, chbRemAMLDiscrepant.Checked);
                 rsltRemitter = DraftEntityDataManager.MarkRemitterSDNAML(Convert.ToInt32(Session["RemitterId"]), (chbRemSDNDiscrepant.Checked == true) ? "0" : "1", (chbRemAMLDiscrepant.Checked == true) ? "0" : "1");
                if (rslt.isSuccessful)
                {
                    /*
                    if ((int)Session["RowId"] > 0 && Session["DraftNo"].ToString().Length > 0 && btnHoldReleasedraft.Text == "Hold Draft")
                        btnHoldReleasedraft.Attributes.Add("onclick", "wid=window.showModalDialog('../Transaction/MiscellaneousMsg.aspx?DraftId=" + Session["RowId"].ToString() + "&PriorityCode=601&DraftNo=" + Session["DraftNo"].ToString() + "&HoldReason=" + txbHoldReason.Text + "',null,'status:no;dialogWidth:1200px;dialogHeight:850px;dialogHide:true;help:no;scroll:yes');");
                    else
                    {
                        btnHoldReleasedraft.Attributes.Remove("onclick");
                    }   */

                    lbl_Message.Text = ApplicationMessages.UPDATE_SUCCESS_MESSAGE;
                    this.btnHoldReleasedraft.Text = "Release Draft";
                    this.txbHoldReason.ReadOnly = this.txbTextCode.ReadOnly = true;
                    this.btnTextCodeLookup.Enabled = false;
                    Response.Redirect("../MiscellaneousMessage/frmRPS_FreeTextMessageSPC.aspx?DraftId=" + Session["RowId"].ToString() + "&RI=987&PC=601&DraftNo=" + Session["DraftNo"].ToString() + "&TC=" + txbTextCode.Text+"&HoldReason=" + txbHoldReason.Text);

                }

                //else
                //lbl_Message.Text = ApplicationMessages.UPDATE_FAILURE_MESSAGE;
            }
        }
        catch (Exception ex)
        {
            lbl_Message.Text = ex.Message;
            //DataManager.SQLManager.LogException("HR_Transaction_CourierFeedback", "btnHoldReleaseDraft_Click", ex, Session["UserId"].ToString());
        }
    }
    
}

<%@ Application Language="C#" %>

<script RunAt="server">

    void Application_Start(object sender, EventArgs e)
    {
        // Code that runs on application startup
        //LOV_COLLECTION L = new LOV_COLLECTION();
        //PathReader p1 = new PathReader();
        //DatabaseConfig D = new DatabaseConfig();
        //D = p1.Deserialize_Data();
        //System.Data.DataSet ds = new System.Data.DataSet();
        //Session["FTPUserID"] = D.FTPUSERID.ToString();
        //Session["FTPPASSWORD"] = D.FTPPASSWORD.ToString();
        //Session["FTPIP"] = D.FTPIP.ToString();
    }

    void Application_End(object sender, EventArgs e)
    {
        //  Code that runs on application shutdown

    }

    void Application_Error(object sender, EventArgs e)
    {
        /*if (HttpContext.Current != null)
        {
            try
            {
                HttpContext ctx = HttpContext.Current;
                string e404_PAGE = ctx.Request.Url.Segments[ctx.Request.Url.Segments.Length - 1].ToString();
                if (e404_PAGE != "frmerrpage.aspx")
                {
                    string e404_MESSAGE = ctx.Server.GetLastError().InnerException == null ? ctx.Server.GetLastError().Message : ctx.Server.GetLastError().Message + ":" + ctx.Server.GetLastError().InnerException.Message.ToString();
                    string e404_METHODNAME = ctx.Server.GetLastError().InnerException == null ? ctx.Server.GetLastError().Message : ctx.Server.GetLastError().InnerException.TargetSite.ToString();
                    string e404_STACKTRACE = ctx.Server.GetLastError().InnerException == null ? ctx.Server.GetLastError().Message : ctx.Server.GetLastError().InnerException.StackTrace.ToString();
                    Server.ClearError();
                    Response.Clear();
                    InsertApplicationError(e404_PAGE, e404_MESSAGE, e404_METHODNAME, e404_STACKTRACE, Session["U_NAME"] == null ? "" : Session["U_NAME"].ToString());
                }
                Response.Redirect("../MasterPage/frmerrpage.aspx");
            }
            catch (Exception)
            {
                Response.Redirect("../MasterPage/frmerrpage.aspx");
            }
        }*/
    }
    public void InsertApplicationError(string vERRPAGENAME, string vERRMESSAGE, string vERRMETHOD, string vERRSTACKTRACE, string vERRONUSER)
    {
        DatabaseConnection_Util db = new DatabaseConnection_Util();
        System.Data.OracleClient.OracleParameter[] parms = new System.Data.OracleClient.OracleParameter[5];
        parms[0] = db.Oracle_Param("vERRPAGENAME", System.Data.OracleClient.OracleType.VarChar, System.Data.ParameterDirection.Input, vERRPAGENAME);
        parms[1] = db.Oracle_Param("vERRMESSAGE", System.Data.OracleClient.OracleType.VarChar, System.Data.ParameterDirection.Input,vERRMESSAGE);
        parms[2] = db.Oracle_Param("vERRMETHOD", System.Data.OracleClient.OracleType.VarChar, System.Data.ParameterDirection.Input, vERRMETHOD);
        parms[3] = db.Oracle_Param("vERRSTACKTRACE", System.Data.OracleClient.OracleType.VarChar, System.Data.ParameterDirection.Input, vERRSTACKTRACE);
        parms[4] = db.Oracle_Param("vERRONUSER", System.Data.OracleClient.OracleType.VarChar, System.Data.ParameterDirection.Input, vERRONUSER);
        db.Oracle_GetDataSetSP_DML("SP_APPLICATION_ERROR", parms);
    }
    void Session_Start(object sender, EventArgs e)
    {
        
        PathReader p1 = new PathReader();
        DatabaseConfig D = new DatabaseConfig();
        D = p1.Deserialize_Data();
        System.Data.DataSet ds = new System.Data.DataSet();
        Session["FTPUserID"] = D.FTPUSERID.ToString();
        Session["FTPPASSWORD"] = D.FTPPASSWORD.ToString();
        Session["FTPIP"] = D.FTPIP.ToString();

        Session["BranchCode"] = "%";
        Session["BranchName"] = "%";

        Session["LOV_Column_Order"] = "";
        Session["SPDS_DataLoadDefinationCofiguration_ID"] = "0";
        Session["SSO_DB"] = "";
        Session["GearUp"] = "0";
        Session["LOG_ROLE"] = "";
        Session["CompleteInformation"] = "";
        Session["OCX_FLG_1"] = "0";
        Session["EXP_PAGE"] = "";
        Session["RGS"] = "00000";
        Session["Invalid"] = "0";
        Session["INVALID_COUNTER"] = "0";
        Session["Role_Assign"] = "0";
        Session["DEFAULT_ROWS"] = "20";
        Session["DEFAULT_ROWS2"] = "5";

        Session["ThemeChange"] = "ColorSchemeBlue";
        Session["CSSChange"] = "Blue.css";

        Session["Menucss"] = "bluemenu.css";
        Session["Menujs"] = "bluemenu.js";

        Session["PageCount"] = "0";

        Session["COLS"] = "%";
        Session["DIR"] = "%";

        Session["LOG_CODE"] = "0";
        //Session["U_NAME"] = "Danish"; //Edit By Danish
        Session["U_NAME"] = ""; //Edit By irfan

        Session["PARATYPE"] = "";
        // SESSION VARIABLES FOR LOV //
        Session["WIDTH"] = "850";
        Session["HEIGHT"] = "400";
        Session["LOV_ID"] = "";
        Session["LOV_CODE"] = "";
        Session["LOV_DESCRIPTION"] = "";

        Session["CMN_PrincipleBankName"] = "0";
        Session["LOV_ID"] = "";
        Session["LOV_PrincipleBankId"] = "";
        Session["LOV_HeaderId"] = "";
        Session["LOV_BatchDate"] = "";
        Session["LOV_BatchNumber"] = "";
        Session["LOV_NumberOfTransactions"] = "";

        Session["City_id"] = "0";
        Session["City_Code"] = "%";
        Session["City_Full_Name"] = "%";
        Session["City_Short_Name"] = "%";
        Session["System_DateTime"] = "%";
        Session["City_status"] = "%";

        Session["SPDS_DraftBulkCancellation_CustomerName"] = "%";
        Session["SPDS_DraftBulkCancellation_Filename"] = "%";    
        
        
        Session["RPS_Bank_ID"] = "0";
        Session["RPS_Bank_BankCode"] = "%";
        Session["RPS_Bank_BankName"] = "%";
        Session["RPS_Bank_ServiceTypeID"] = "%";
        Session["RPS_Bank_InputFileAllowed"] = "%";
        Session["RPS_Bank_UnclaimedDraftPeriod"] = "%";
        Session["RPS_Bank_FloorLimit"] = "%";
        Session["RPS_Bank_DraftFooterMessage"] = "%";
        Session["RPS_Bank_URL"] = "%";
        Session["RPS_Bank_AssignedCitiBankId"] = "%";
        Session["RPS_Bank_Abbreviation"] = "%";
        Session["RPS_Bank_Address"] = "%";
        Session["RPS_Bank_PhoneNo"] = "%";
        Session["RPS_Bank_FaxNo"] = "%";
        Session["RPS_Bank_Email"] = "%";
        Session["RPS_Bank_RemitType"] = "%";
        Session["RPS_Bank_IsCitiBank"] = "%";
        Session["RPS_Bank_A_UserID"] = "%";
        Session["RPS_Bank_A_DateTime"] = "%";
        Session["RPS_Bank_E_UserID"] = "%";
        Session["RPS_Bank_E_DateTime"] = "%";
        Session["RPS_Bank_OnlineDraftStartingNo"] = "%";
        Session["RPS_Bank_OfflineDraftStartingNo"] = "%";
        Session["RPS_Bank_ReportTitle"] = "%";
        Session["RPS_Bank_IsDollarBased"] = "%";
        Session["RPS_Bank_AccountNo"] = "%";
        Session["RPS_Bank_BankName2"] = "%";

        Session["CMN_Country_ID"] = "0";
        Session["CMN_Country_SBPCode"] = "0";
        Session["CMN_Country_CountryName"] = "0";
        Session["CMN_Country_A_UserID"] = "%";
        Session["CMN_Country_A_DateTime"] = "%";
        Session["CMN_Country_E_UserID"] = "%";
        Session["CMN_Country_E_DateTime"] = "%";

        Session["CMN_Province_ID"] = "0";
        Session["CMN_Province_ProvinceCode"] = "0";
        Session["CMN_Province_ProvinceName"] = "0";
        Session["CMN_Province_SBPCode"] = "0";
        Session["CMN_Province_CountryName"] = "0";
        Session["CMN_Province_A_UserID"] = "%";
        Session["CMN_Province_A_DateTime"] = "%";
        Session["CMN_Province_E_UserID"] = "%";
        Session["CMN_Province_E_DateTime"] = "%";


        Session["CMN_District_ID"] = "0";
        Session["CMN_District_ProvinceID"] = "%";
        Session["CMN_District_DistrictCode"] = "0";
        Session["CMN_District_DistrictName"] = "0";
        Session["CMN_District_ProvinceName"] = "0";
        Session["CMN_District_A_UserID"] = "%";
        Session["CMN_District_A_DateTime"] = "%";
        Session["CMN_District_E_UserID"] = "%";
        Session["CMN_District_E_DateTime"] = "%";

        Session["CMN_Tehsil_ID"] = "0";
        Session["CMN_Tehsil_DistrictID"] = "%";
        Session["CMN_Tehsil_DistrictName"] = "0";
        Session["CMN_Tehsil_TehsilCode"] = "0";
        Session["CMN_Tehsil_TehsilName"] = "0";
        Session["CMN_Tehsil_ServiceClassificationID"] = "%";
        Session["CMN_Tehsil_A_UserID"] = "%";
        Session["CMN_Tehsil_A_DateTime"] = "%";
        Session["CMN_Tehsil_E_UserID"] = "%";
        Session["CMN_Tehsil_E_DateTime"] = "%";

        Session["RPS_ExciseRate_ID"] = "0";
        Session["RPS_ExciseRate_ExciseDate"] = "0";
        Session["RPS_ExciseRate_Rate"] = "%";
        Session["RPS_ExciseRate_A_UserID"] = "%";
        Session["RPS_ExciseRate_A_DateTime"] = "%";
        Session["RPS_ExciseRate_E_UserID"] = "%";
        Session["RPS_ExciseRate_E_DateTime"] = "%";
        Session["RPS_ExciseRate_Description"] = "0";

        Session["RPS_DefaultMessages_ID"] = "0";
        Session["RPS_DefaultMessages_DefaultMessageCode"] = "0";
        Session["RPS_DefaultMessages_Description"] = "0";
        Session["RPS_DefaultMessages_A_UserID"] = "%";
        Session["RPS_DefaultMessages_A_DateTime"] = "%";
        Session["RPS_DefaultMessages_E_UserID"] = "%";
        Session["RPS_DefaultMessages_E_DateTime"] = "%";

        Session["SPDS_ProductArrangement_ID"] = "0";
        Session["SPDS_ProductArrangement_CustomerID"] = "0";
        Session["SPDS_ProductArrangement_ProductID"] = "0";

        Session["SPDS_ProductArrangement_CustomerName"] = "0";
        Session["SPDS_ProductArrangement_ProductName"] = "0";
        Session["SPDS_ProductArrangement_CorrespondentBank"] = "0";
        Session["SPDS_ProductArrangement_CourierName"] = "0";

        Session["SPDS_ProductArrangement_Isonline"] = "%";
        Session["SPDS_ProductArrangement_ServiceID"] = "%";
        Session["SPDS_ProductArrangement_CurrencyCode"] = "%";
        Session["SPDS_ProductArrangement_PrintLocation"] = "%";
        Session["SPDS_ProductArrangement_CorrespondentBank"] = "%";
        Session["SPDS_ProductArrangement_Courier"] = "%";
        Session["SPDS_ProductArrangement_A_UserID"] = "%";
        Session["SPDS_ProductArrangement_A_DateTime"] = "%";
        Session["SPDS_ProductArrangement_E_UserID"] = "%";
        Session["SPDS_ProductArrangement_E_DateTime"] = "%";
        Session["SPDS_ProductArrangement_FED_Check"] = "%";

        Session["CMN_Courier_ID"] = "0";
        Session["CMN_Courier_CourierCode"] = "0";
        Session["CMN_Courier_CourierName"] = "0";
        Session["CMN_Courier_Address"] = "%";
        Session["CMN_Courier_ContactPerson"] = "%";
        Session["CMN_Courier_PhoneNo"] = "%";
        Session["CMN_Courier_FaxNo"] = "%";
        Session["CMN_Courier_Email"] = "%";
        Session["CMN_Courier_URL"] = "%";
        Session["CMN_Courier_AgreementNo"] = "%";
        Session["CMN_Courier_NTNNo"] = "%";
        Session["CMN_Courier_AccountNo"] = "%";
        Session["CMN_Courier_A_UserID"] = "%";
        Session["CMN_Courier_A_DateTime"] = "%";
        Session["CMN_Courier_E_UserID"] = "%";
        Session["CMN_Courier_E_DateTime"] = "%";
        Session["CMN_Courier_InSideRate"] = "%";
        Session["CMN_Courier_OutSideRate"] = "%";
        Session["CMN_Courier_AWBImagePath"] = "%";
        Session["CMN_Courier_AWBNoAvailable"] = "%";
        Session["CMN_Courier_AWBNo"] = "%";
        Session["CMN_Courier_AWBUploadPath"] = "%";
        Session["CMN_Courier_AWBDownloadPath"] = "%";

        Session["CMN_Station_ID"] = "0";
        Session["CMN_Station_CourierID"] = "%";
        Session["CMN_Station_TehsilID"] = "%";
        Session["CMN_Station_StationName"] = "0";
        Session["CMN_Station_ProvinceName"] = "0";
        Session["CMN_Station_DistrictName"] = "0";
        Session["CMN_Station_TehsilName"] = "0";
        Session["CMN_Station_CourierName"] = "0";
        Session["CMN_Station_StationCode"] = "0";
        Session["CMN_Station_ServiceID"] = "%";
        Session["CMN_Station_PickupTime"] = "%";
        Session["CMN_Station_DestinationCode"] = "%";
        Session["CMN_Station_SequenceNumber"] = "%";
        Session["CMN_Station_A_UserID"] = "%";
        Session["CMN_Station_A_DateTime"] = "%";
        Session["CMN_Station_E_UserID"] = "%";
        Session["CMN_Station_E_DateTime"] = "%";
        Session["CMN_Station_OutofService"] = "%";

        Session["RPS_MasterStatus_ID"] = "0";
        Session["RPS_MasterStatus_MasterStatusCode"] = "0";
        Session["RPS_MasterStatus_CustomerCode"] = "%";
        Session["RPS_MasterStatus_CustomerName"] = "0";
        Session["RPS_MasterStatus_Description"] = "0";
        Session["RPS_MasterStatus_A_UserID"] = "%";
        Session["RPS_MasterStatus_A_DateTime"] = "%";
        Session["RPS_MasterStatus_E_UserID"] = "%";
        Session["RPS_MasterStatus_E_DateTime"] = "%";

        Session["RPS_DetailStatus_ID"] = "0";
        Session["RPS_DetailStatus_MasterStatusCode"] = "0";
        Session["RPS_DetailStatus_StatusCode"] = "0";
        Session["RPS_DetailStatus_Description"] = "0";
        Session["RPS_DetailStatus_StatusSwitch"] = "%";
        Session["RPS_DetailStatus_A_UserID"] = "%";
        Session["RPS_DetailStatus_A_DateTime"] = "%";
        Session["RPS_DetailStatus_E_UserID"] = "%";
        Session["RPS_DetailStatus_E_DateTime"] = "%";

        Session["RPS_Bank_ID"] = "0";
        Session["RPS_Bank_BankCode"] = "0";
        Session["RPS_Bank_BankName"] = "0";
        Session["RPS_Bank_ServiceTypeID"] = "%";
        Session["RPS_Bank_InputFileAllowed"] = "%";
        Session["RPS_Bank_UnclaimedDraftPeriod"] = "%";
        Session["RPS_Bank_FloorLimit"] = "%";
        Session["RPS_Bank_DraftFooterMessage"] = "%";
        Session["RPS_Bank_URL"] = "%";
        Session["RPS_Bank_AssignedCitiBankId"] = "%";
        Session["RPS_Bank_Abbreviation"] = "%";
        Session["RPS_Bank_Address"] = "%";
        Session["RPS_Bank_PhoneNo"] = "%";
        Session["RPS_Bank_FaxNo"] = "%";
        Session["RPS_Bank_Email"] = "%";
        Session["RPS_Bank_RemitType"] = "%";
        Session["RPS_Bank_IsCitiBank"] = "%";
        Session["RPS_Bank_A_UserID"] = "%";
        Session["RPS_Bank_A_DateTime"] = "%";
        Session["RPS_Bank_E_UserID"] = "%";
        Session["RPS_Bank_E_DateTime"] = "%";
        Session["RPS_Bank_OnlineDraftStartingNo"] = "%";
        Session["RPS_Bank_OfflineDraftStartingNo"] = "%";
        Session["RPS_Bank_ReportTitle"] = "%";
        Session["RPS_Bank_IsDollarBased"] = "%";
        Session["RPS_Bank_AccountNo"] = "%";

        Session["SPDS_STATIONARY_MASTER_ID"] = "0";
        Session["SPDS_STATIONARY_MASTER_SERIAL_DATE"] = "0";

        Session["SPDS_STATIONARY_MASTER_CUSTOMER_NAME"] = "0";
        Session["SPDS_STATIONARY_MASTER_CORR_BANK_NAME"] = "0";
        Session["SPDS_STATIONARY_MASTER_INSTRUMENT_NAME"] = "0";
        Session["SPDS_STATIONARY_MASTER_PRODUCT_NAME"] = "0";
        Session["SPDS_STATIONARY_MASTER_COURIER_NAME"] = "0";
        Session["SPDS_STATIONARY_MASTER_CURRENCY_CODE"] = "0";

        Session["SPDS_STATIONARY_MASTER_PRINT_AGENT_ID"] = "%";
        Session["SPDS_STATIONARY_MASTER_PRINT_LOCATION_ID"] = "%";
        Session["SPDS_STATIONARY_MASTER_THRESHOLD"] = "%";
        Session["SPDS_STATIONARY_MASTER_LAST_ACTIVATION_DATE"] = "%";

        Session["SPDS_ProductMaster_ID"] = "0";
        Session["SPDS_ProductMaster_ProductCode"] = "0";
        Session["SPDS_ProductMaster_Isonline"] = "%";
        Session["SPDS_ProductMaster_ServiceID"] = "%";
        Session["SPDS_ProductMaster_A_UserID"] = "%";
        Session["SPDS_ProductMaster_A_DateTime"] = "%";
        Session["SPDS_ProductMaster_E_UserID"] = "%";
        Session["SPDS_ProductMaster_E_DateTime"] = "%";
        Session["SPDS_ProductMaster_ProductName"] = "0";

        Session["SPDS_PrintingLocationPricing_ID"] = "0";
        Session["SPDS_PrintingLocationPricing_PrintingAgentID"] = "0";
        Session["SPDS_PrintingLocationPricing_PrintingLocationID"] = "0";
        Session["SPDS_PrintingLocationPricing_ProductID"] = "0";
        Session["SPDS_PrintingLocationPricing_PrintCostCharges"] = "%";
        Session["SPDS_PrintingLocationPricing_CourierArrangementBy"] = "%";
        Session["SPDS_PrintingLocationPricing_CourierArrangementOn"] = "%";
        Session["SPDS_PrintingLocationPricing_A_UserID"] = "%";
        Session["SPDS_PrintingLocationPricing_A_DateTime"] = "%";
        Session["SPDS_PrintingLocationPricing_E_UserID"] = "%";
        Session["SPDS_PrintingLocationPricing_E_DateTime"] = "%";

        Session["RPS_CustomerFilesPath_ID"] = "0";
        Session["RPS_CustomerFilesPath_CustomerId"] = "0";
        Session["RPS_CustomerFilesPath_CustomerName"] = "0";
        Session["RPS_CustomerFilesPath_SendFilePath"] = "%";
        Session["RPS_CustomerFilesPath_ReceiveFilePath1"] = "%";
        Session["RPS_CustomerFilesPath_E_UserId"] = "%";
        Session["RPS_CustomerFilesPath_E_DateTime"] = "%";
        Session["RPS_CustomerFilesPath_A_UserId"] = "%";
        Session["RPS_CustomerFilesPath_A_DateTime"] = "%";

        Session["RPS_DraftFooterMessage_ID"] = "0";
        Session["RPS_DraftFooterMessage_PrincipleBankName"] = "0";
        Session["RPS_DraftFooterMessage_CorrespondingBankName"] = "0";
        Session["RPS_DraftFooterMessage_InstrumentName"] = "0";
        Session["RPS_DraftFooterMessage_A_DateTime"] = "%";
        Session["RPS_DraftFooterMessage_E_DateTime"] = "%";
        Session["RPS_DraftFooterMessage_Message"] = "0";
        Session["RPS_DraftFooterMessage_A_UserID"] = "%";
        Session["RPS_DraftFooterMessage_E_UserID"] = "%";

        Session["SPDS_PODAWBSeriesIssuanceManagement_ID"] = "0";
        Session["SPDS_PODAWBSeriesIssuanceManagement_CourierID"] = "0";
        Session["SPDS_PODAWBSeriesIssuanceManagement_CourierName"] = "0";
        Session["SPDS_PODAWBSeriesIssuanceManagement_AWBStart"] = "%";
        Session["SPDS_PODAWBSeriesIssuanceManagement_AWBEnd"] = "%";
        Session["SPDS_PODAWBSeriesIssuanceManagement_A_userID"] = "%";
        Session["SPDS_PODAWBSeriesIssuanceManagement_A_DateTime"] = "%";
        Session["SPDS_PODAWBSeriesIssuanceManagement_E_UserID"] = "%";
        Session["SPDS_PODAWBSeriesIssuanceManagement_E_DateTime"] = "%";

        Session["CMN_Branch_ID"] = "0";
        Session["CMN_Branch_BankID"] = "%";
        Session["CMN_Branch_TehsilID"] = "%";
        Session["CMN_Branch_BankName"] = "%";
        Session["CMN_Branch_TehsilName"] = "%";
        Session["CMN_Branch_ProvinceName"] = "%";
        Session["CMN_Branch_DistrictName"] = "%";
        Session["CMN_Branch_BranchCode"] = "0";
        Session["CMN_Branch_BranchName"] = "0";

        Session["CMN_Branch_BranchCode_NEW"] = "%";
        Session["CMN_Branch_BranchName_NEW"] = "%";

        Session["CMN_Branch_Address"] = "%";
        Session["CMN_Branch_AreaName"] = "%";
        Session["CMN_Branch_PhoneNo"] = "%";
        Session["CMN_Branch_TelexNo"] = "%";
        Session["CMN_Branch_FaxNo"] = "%";
        Session["CMN_Branch_RegionalBranchID"] = "%";
        Session["CMN_Branch_IsRegionalBranch"] = "%";
        Session["CMN_Branch_Flag"] = "%";
        Session["CMN_Branch_IsOnline"] = "%";
        Session["CMN_Branch_CitiBranchID"] = "%";
        Session["CMN_Branch_AlternateBranchID"] = "%";
        Session["CMN_Branch_A_UserID"] = "%";
        Session["CMN_Branch_A_DateTime"] = "%";
        Session["CMN_Branch_E_UserID"] = "%";
        Session["CMN_Branch_E_DateTime"] = "%";

        Session["CMN_Branch_ProvinceID"] = "%";
        Session["CMN_Branch_ProvinceName"] = "%";
        Session["CMN_Branch_DistrictID"] = "%";
        Session["CMN_Branch_DistrictName"] = "%";


        Session["RPS_POD_ID"] = "%";
        Session["RPS_POD_CourierID"] = "%";
        Session["RPS_POD_StationID"] = "%";
        Session["RPS_POD_MenifestID"] = "%";
        Session["RPS_POD_PODNo"] = "0";
        Session["RPS_POD_PODDate"] = "%";
        Session["RPS_POD_DueDate"] = "%";
        Session["RPS_POD_CorrespondingBankID"] = "0";
        Session["RPS_POD_RemitterID"] = "%";
        Session["RPS_POD_BeneficiaryID"] = "%";
        Session["RPS_POD_RemittanceID"] = "%";
        Session["RPS_POD_DraftID"] = "%";
        Session["RPS_POD_DeliveryDate"] = "%";
        Session["RPS_POD_StatusID"] = "%";
        Session["RPS_POD_StatusDate"] = "%";
        Session["RPS_POD_StatusTime"] = "%";
        Session["RPS_POD_PODTypeID"] = "%";
        Session["RPS_POD_LanguageID"] = "%";
        Session["RPS_POD_BeneficiaryMessage"] = "%";
        Session["RPS_POD_StatusSwitch"] = "%";
        Session["RPS_POD_A_UserID"] = "%";
        Session["RPS_POD_A_DateTime"] = "%";
        Session["RPS_POD_E_UserID"] = "%";
        Session["RPS_POD_E_DateTime"] = "%";

        Session["SPDS_CourierPricing_Master_ID"] = "%";
        Session["SPDS_CourierPricing_Master_CourierID"] = "0";
        Session["SPDS_CourierPricing_Master_FlatRateforAllStations"] = "%";
        Session["SPDS_CourierPricing_Master_A_UserID"] = "%";
        Session["SPDS_CourierPricing_Master_A_DateTime"] = "%";
        Session["SPDS_CourierPricing_Master_E_UserID"] = "%";
        Session["SPDS_CourierPricing_Master_E_DateTime"] = "%";

        Session["SPDS_CourierPricing_Detail_ID"] = "0";
        Session["SPDS_CourierPricing_Detail_CourierPricingID"] = "%";
        Session["SPDS_CourierPricing_Detail_RateTypeID"] = "%";
        Session["SPDS_CourierPricing_Detail_FromStationID"] = "0";
        Session["SPDS_CourierPricing_Detail_ToStationID"] = "0";
        Session["SPDS_CourierPricing_Detail_ServiceTypeID"] = "%";
        Session["SPDS_CourierPricing_Detail_FromVolume"] = "%";
        Session["SPDS_CourierPricing_Detail_ToVolume"] = "%";
        Session["SPDS_CourierPricing_Detail_PacketCharges"] = "%";
        Session["SPDS_CourierPricing_Detail_PODCharges"] = "%";
        Session["SPDS_CourierPricing_Detail_OutofServiceAreaCharges"] = "%";
        Session["SPDS_CourierPricing_Detail_A_UserID"] = "%";
        Session["SPDS_CourierPricing_Detail_A_DateTime"] = "%";
        Session["SPDS_CourierPricing_Detail_E_UserID"] = "%";
        Session["SPDS_CourierPricing_Detail_E_DateTime"] = "%";

        Session["RPS_CorrespondingBankFilesPath_Id"] = "0";
        Session["RPS_CorrespondingBankFilesPath_CorrespondingBankId"] = "0";
        Session["RPS_CorrespondingBankFilesPath_CorrespondingBankName"] = "0";
        Session["RPS_CorrespondingBankFilesPath_SendFilePath"] = "%";
        Session["RPS_CorrespondingBankFilesPath_ReceiveFilePath"] = "%";
        Session["RPS_CorrespondingBankFilesPath_E_UserId"] = "%";
        Session["RPS_CorrespondingBankFilesPath_E_DateTime"] = "%";
        Session["RPS_CorrespondingBankFilesPath_A_UserId"] = "%";
        Session["RPS_CorrespondingBankFilesPath_A_DateTime"] = "%";

        Session["CMN_Holiday_ID"] = "%";
        Session["CMN_Holiday_HolidayCode"] = "0";
        Session["CMN_Holiday_Holiday"] = "0";
        Session["CMN_Holiday_Remarks"] = "%";
        Session["CMN_Holiday_A_UserID"] = "%";
        Session["CMN_Holiday_A_DateTime"] = "%";
        Session["CMN_Holiday_E_UserID"] = "%";
        Session["CMN_Holiday_E_DateTime"] = "%";

        Session["RPS_BankContact_ID"] = "0";
        Session["RPS_BankContact_BankID"] = "%";
        Session["RPS_BankContact_ContactName"] = "%";
        Session["RPS_BankContact_Address"] = "%";
        Session["RPS_BankContact_PhoneNo"] = "%";
        Session["RPS_BankContact_FaxNo"] = "%";
        Session["RPS_BankContact_Email"] = "%";
        Session["RPS_BankContact_NTNNo"] = "%";

        Session["CMN_Currency_ID"] = "0";
        Session["CMN_Currency_CurrencyCode"] = "0";
        Session["CMN_Currency_CurrencyName"] = "0";
        Session["CMN_Currency_ShortName"] = "%";
        Session["CMN_Currency_A_UserID"] = "%";
        Session["CMN_Currency_A_DateTime"] = "%";
        Session["CMN_Currency_E_UserID"] = "%";
        Session["CMN_Currency_E_DateTime"] = "%";

        Session["RPS_Tracer_ID"] = "0";
        Session["RPS_Tracer_BatchID"] = "%";
        Session["RPS_Tracer_PrincipleBankID"] = "%";
        Session["RPS_Tracer_RemitterID"] = "%";
        Session["RPS_Tracer_BeneficiaryID"] = "%";
        Session["RPS_Tracer_RemittanceID"] = "%";
        Session["RPS_Tracer_TracerDate"] = "%";
        Session["RPS_Tracer_SequenceNo"] = "%";
        Session["RPS_Tracer_TracerTransactionTypeID"] = "%";
        Session["RPS_Tracer_TracerTypeID"] = "%";
        Session["RPS_Tracer_StatusID"] = "%";
        Session["RPS_Tracer_FreeTextMessage"] = "%";
        Session["RPS_Tracer_TracerID"] = "%";
        Session["RPS_Tracer_StatusSwitch"] = "%";
        Session["RPS_Tracer_A_UserID"] = "%";
        Session["RPS_Tracer_A_DateTime"] = "%";
        Session["RPS_Tracer_E_UserID"] = "%";
        Session["RPS_Tracer_E_DateTime"] = "%";
        Session["RPS_Tracer_RemitterNo"] = "0";
        Session["RPS_Tracer_RemittanceRefNo"] = "0";



        Session["RPS_FreeTextMessage_ID"] = "0";
        Session["RPS_FreeTextMessage_TransactionCode"] = "0";
        Session["RPS_FreeTextMessage_IncomingBatchHeaderID"] = "0";
        Session["RPS_FreeTextMessage_OutgoingHeaderID"] = "0";
        Session["RPS_FreeTextMessage_CreationDateTime"] = "%";
        Session["RPS_FreeTextMessage_SequenceNo"] = "0";
        Session["RPS_FreeTextMessage_PriorityCode"] = "0";
        Session["RPS_FreeTextMessage_DraftID"] = "%";
        Session["RPS_FreeTextMessage_Message"] = "0";
        Session["RPS_FreeTextMessage_A_UserID"] = "%";
        Session["RPS_FreeTextMessage_A_DateTime"] = "%";
        Session["RPS_FreeTextMessage_E_UserID"] = "%";
        Session["RPS_FreeTextMessage_E_DateTime"] = "%";

        Session["SPDS_STATIONARY_DETAIL_ID"] = "0";
        Session["SPDS_STATIONARY_DETAIL_STATIONARY_MASTER_ID"] = "0";
        Session["SPDS_STATIONARY_DETAIL_START_SERIAL_NO"] = "%";
        Session["SPDS_STATIONARY_DETAIL_END_SERIAL_NO"] = "%";
        Session["SPDS_STATIONARY_DETAIL_ACTIVATION_DATE"] = "%";
        Session["SPDS_STATIONARY_DETAIL_ACTIVATE_FLG"] = "%";
        Session["SPDS_STATIONARY_DETAIL_A_USERID"] = "%";
        Session["SPDS_STATIONARY_DETAIL_A_DATETIME"] = "%";
        Session["SPDS_STATIONARY_DETAIL_E_USERID"] = "%";
        Session["SPDS_STATIONARY_DETAIL_E_DATETIME"] = "%";

        Session["SPDS_StarFileSetup_ID"] = "0";
        Session["SPDS_StarFileSetup_CustomerID"] = "0";
        Session["SPDS_StarFileSetup_PRODUCTID"] = "0";
        Session["SPDS_StarFileSetup_CustomerName"] = "%";
        Session["SPDS_StarFileSetup_PRODUCTName"] = "%";
        Session["SPDS_StarFileSetup_DownloadPath"] = "%";
        Session["SPDS_StarFileSetup_UploadPath"] = "%";
        Session["SPDS_StarFileSetup_A_userID"] = "%";
        Session["SPDS_StarFileSetup_A_DateTime"] = "%";
        Session["SPDS_StarFileSetup_E_UserID"] = "%";
        Session["SPDS_StarFileSetup_E_DateTime"] = "%";

        Session["SPDS_DraftBulkCancellation_ID"] = "0";
        Session["SPDS_DraftBulkCancellation_BatchID"] = "%";
        Session["SPDS_DraftBulkCancellation_CustomerID"] = "0";
        Session["SPDS_DraftBulkCancellation_Filename"] = "0";
        Session["SPDS_DraftBulkCancellation_CreateDate"] = "%";
        Session["SPDS_DraftBulkCancellation_IsProcessed"] = "%";
        Session["SPDS_DraftBulkCancellation_UploadDate"] = "%";
        Session["SPDS_DraftBulkCancellation_A_UserID"] = "%";
        Session["SPDS_DraftBulkCancellation_A_DateTime"] = "%";
        Session["SPDS_DraftBulkCancellation_E_UserID"] = "%";
        Session["SPDS_DraftBulkCancellation_E_DateTime"] = "%";

        Session["RPS_CorrespondingBankTransactions_ID"] = "";
        Session["RPS_CorrespondingBankTransactions_CorrespondingBankID"] = "%";
        Session["RPS_CorrespondingBankTransactions_PrincipleBankID"] = "%";
        Session["RPS_CorrespondingBankTransactions_DraftID"] = "%";
        Session["RPS_CorrespondingBankTransactions_DraftNo"] = "0";
        Session["RPS_CorrespondingBankTransactions_EntryDate"] = "%";
        Session["RPS_CorrespondingBankTransactions_EntryTypeID"] = "%";
        Session["RPS_CorrespondingBankTransactions_Amount"] = "%";
        Session["RPS_CorrespondingBankTransactions_Remarks"] = "%";
        Session["RPS_CorrespondingBankTransactions_IsCarryOverEntry"] = "%";
        Session["RPS_CorrespondingBankTransactions_E_UserID"] = "%";
        Session["RPS_CorrespondingBankTransactions_E_DateTime"] = "%";
        Session["RPS_CorrespondingBankTransactions_forced_status"] = "%";

        Session["RPS_DailyClosingBalance_ID"] = "0";
        Session["RPS_DailyClosingBalance_PrincipleBankID"] = "0";
        Session["RPS_DailyClosingBalance_CorrespondingBankID"] = "0";

        Session["RPS_DailyClosingBalance_PrincipleBankName"] = "0";
        Session["RPS_DailyClosingBalance_CorrespondingBankName"] = "0";

        Session["RPS_DailyClosingBalance_BalanceDate"] = "%";
        Session["RPS_DailyClosingBalance_CitiBankClosingAmount"] = "%";
        Session["RPS_DailyClosingBalance_CorrespondingBankClosingAmount"] = "%";
        Session["RPS_DailyClosingBalance_A_UserID"] = "%";
        Session["RPS_DailyClosingBalance_A_DateTime"] = "%";
        Session["RPS_DailyClosingBalance_E_UserID"] = "%";
        Session["RPS_DailyClosingBalance_E_DateTime"] = "%";

        Session["SPDS_SignatorySetup_ID"] = "0";
        Session["SPDS_SignatorySetup_SIGNATORY_NAME"] = "%";
        Session["SPDS_SignatorySetup_UPLOAD_IMAGE_PATH"] = "%";
        Session["SPDS_SignatorySetup_UPLOAD_IMAGE"] = "%";
        Session["SPDS_SignatorySetup_CURRENT_STATUS"] = "%";
        Session["SPDS_SignatorySetup_A_userID"] = "%";
        Session["SPDS_SignatorySetup_A_DateTime"] = "%";
        Session["SPDS_SignatorySetup_E_UserID"] = "%";
        Session["SPDS_SignatorySetup_E_DateTime"] = "%";

        Session["RPS_Remitter_ID"] = "0";
        Session["RPS_Remitter_BatchID"] = "%";
        Session["RPS_Remitter_PrincipleBankID"] = "%";
        Session["RPS_Remitter_PrincipleBankName"] = "0";
        Session["RPS_Remitter_RemitterNo"] = "0";
        Session["RPS_Remitter_FirstName"] = "0";
        Session["RPS_Remitter_MiddleName"] = "0";
        Session["RPS_Remitter_LastName"] = "0";
        Session["RPS_Remitter_POBoxNo"] = "%";
        Session["RPS_Remitter_City"] = "%";
        Session["RPS_Remitter_ZipCode"] = "%";
        Session["RPS_Remitter_NICNo"] = "%";
        Session["RPS_Remitter_DateOfBirth"] = "%";
        Session["RPS_Remitter_Nationality"] = "%";
        Session["RPS_Remitter_PassportNo"] = "%";
        Session["RPS_Remitter_SDNDiscrepant"] = "%";
        Session["RPS_Remitter_AMLDiscrepant"] = "%";
        Session["RPS_Remitter_UpdateStatusID"] = "%";
        Session["RPS_Remitter_UpdateDate"] = "%";
        Session["RPS_Remitter_PhoneNo"] = "%";
        Session["RPS_Remitter_Country"] = "%";
        Session["RPS_Remitter_StatusSwitch"] = "%";
        Session["RPS_Remitter_A_UserID"] = "%";
        Session["RPS_Remitter_A_DateTime"] = "%";
        Session["RPS_Remitter_E_UserID"] = "%";
        Session["RPS_Remitter_E_DateTime"] = "%";
        Session["RPS_Remitter_MaxSingleTransAmount"] = "%";
        Session["RPS_Remitter_NoOfTransPerMonth"] = "%";

        Session["RPS_Beneficiary_ID"] = "0";
        Session["RPS_Beneficiary_BatchID"] = "%";
        Session["RPS_Beneficiary_RemitterID"] = "%";
        Session["RPS_Beneficiary_RemitterNo"] = "0";
        Session["RPS_Beneficiary_BeneficiaryNo"] = "0";
        Session["RPS_Beneficiary_CorrespondingBankID"] = "%";
        Session["RPS_Beneficiary_CorrespondingBankName"] = "0";
        Session["RPS_Beneficiary_BranchID"] = "%";
        Session["RPS_Beneficiary_BranchName"] = "0";
        Session["RPS_Beneficiary_FirstName"] = "0";
        Session["RPS_Beneficiary_MiddleName"] = "0";
        Session["RPS_Beneficiary_LastName"] = "%";
        Session["RPS_Beneficiary_AlternateFirstName"] = "%";
        Session["RPS_Beneficiary_AlternateMiddleName"] = "%";
        Session["RPS_Beneficiary_AlternateLastName"] = "%";
        Session["RPS_Beneficiary_Address1"] = "%";
        Session["RPS_Beneficiary_Address2"] = "%";
        Session["RPS_Beneficiary_City"] = "%";
        Session["RPS_Beneficiary_ZipCode"] = "%";
        Session["RPS_Beneficiary_AccountNo"] = "%";
        Session["RPS_Beneficiary_UpdateStatusID"] = "%";
        Session["RPS_Beneficiary_UpdateDate"] = "%";
        Session["RPS_Beneficiary_LanguageID"] = "%";
        Session["RPS_Beneficiary_NICNo"] = "%";
        Session["RPS_Beneficiary_DateOfBirth"] = "%";
        Session["RPS_Beneficiary_Nationality"] = "%";
        Session["RPS_Beneficiary_PassportNo"] = "%";
        Session["RPS_Beneficiary_SDNDiscrepant"] = "%";
        Session["RPS_Beneficiary_AMLDiscrepant"] = "%";
        Session["RPS_Beneficiary_PhoneNo"] = "%";
        Session["RPS_Beneficiary_StatusSwitch"] = "%";
        Session["RPS_Beneficiary_A_UserID"] = "%";
        Session["RPS_Beneficiary_A_DateTime"] = "%";
        Session["RPS_Beneficiary_E_UserID"] = "%";
        Session["RPS_Beneficiary_E_DateTime"] = "%";

        Session["RPS_Beneficiary_MaxSingleTransAmount"] = "%";
        Session["RPS_Beneficiary_NoOfTransPerMonth"] = "%";

        Session["SPDS_DataFileTransferConfiguration_ID"] = "0";
        Session["SPDS_DataFileTransferConfiguration_Source"] = "0";
        Session["SPDS_DataFileTransferConfiguration_SourceID"] = "%";
        Session["SPDS_DataFileTransferConfiguration_ProductID"] = "%";
        Session["SPDS_DataFileTransferConfiguration_TransferFileName"] = "%";
        Session["SPDS_DataFileTransferConfiguration_FileFormat"] = "%";
        Session["SPDS_DataFileTransferConfiguration_FileName"] = "%";
        Session["SPDS_DataFileTransferConfiguration_A_userID"] = "%";
        Session["SPDS_DataFileTransferConfiguration_A_DateTime"] = "%";
        Session["SPDS_DataFileTransferConfiguration_E_UserID"] = "%";
        Session["SPDS_DataFileTransferConfiguration_E_DateTime"] = "%";

        Session["SPDS_DataFileTransferConfigurationDetail_ID"] = "0";
        Session["SPDS_DataFileTransferConfigurationDetail_MASTER_ID"] = "0";
        Session["SPDS_DataFileTransferConfigurationDetail_COLUMNNAME"] = "%";
        Session["SPDS_DataFileTransferConfigurationDetail_SEQUENCE_NO"] = "%";

        Session["courierId"] = "0";


        Session["RPS_BeneficiaryHistory_SequenceNo"] = "%";
        Session["RPS_BeneficiaryHistory_UpdatedOn"] = "%";
        Session["RPS_BeneficiaryHistory_ID"] = "%";
        Session["RPS_BeneficiaryHistory_BatchID"] = "%";
        Session["RPS_BeneficiaryHistory_RemitterID"] = "%";
        Session["RPS_BeneficiaryHistory_BeneficiaryNo"] = "%";
        Session["RPS_BeneficiaryHistory_CorrespondingBankID"] = "%";
        Session["RPS_BeneficiaryHistory_BranchID"] = "%";
        Session["RPS_BeneficiaryHistory_FirstName"] = "%";
        Session["RPS_BeneficiaryHistory_MiddleName"] = "%";
        Session["RPS_BeneficiaryHistory_LastName"] = "%";
        Session["RPS_BeneficiaryHistory_AlternateFirstName"] = "%";
        Session["RPS_BeneficiaryHistory_AlternateMiddleName"] = "%";
        Session["RPS_BeneficiaryHistory_AlternateLastName"] = "%";
        Session["RPS_BeneficiaryHistory_Address1"] = "%";
        Session["RPS_BeneficiaryHistory_Address2"] = "%";
        Session["RPS_BeneficiaryHistory_City"] = "%";
        Session["RPS_BeneficiaryHistory_ZipCode"] = "%";
        Session["RPS_BeneficiaryHistory_AccountNo"] = "%";
        Session["RPS_BeneficiaryHistory_UpdateStatusID"] = "%";
        Session["RPS_BeneficiaryHistory_UpdateDate"] = "%";
        Session["RPS_BeneficiaryHistory_LanguageID"] = "%";
        Session["RPS_BeneficiaryHistory_NICNo"] = "%";
        Session["RPS_BeneficiaryHistory_DateOfBirth"] = "%";
        Session["RPS_BeneficiaryHistory_Nationality"] = "%";
        Session["RPS_BeneficiaryHistory_PassportNo"] = "%";
        Session["RPS_BeneficiaryHistory_SDNDiscrepant"] = "%";
        Session["RPS_BeneficiaryHistory_AMLDiscrepant"] = "%";
        Session["RPS_BeneficiaryHistory_PhoneNo"] = "%";
        Session["RPS_BeneficiaryHistory_StatusSwitch"] = "%";
        Session["RPS_BeneficiaryHistory_A_UserID"] = "%";
        Session["RPS_BeneficiaryHistory_A_DateTime"] = "%";
        Session["RPS_BeneficiaryHistory_E_UserID"] = "%";
        Session["RPS_BeneficiaryHistory_E_DateTime"] = "%";

        Session["SPDS_SignatoryCategorySetup_ID"] = "0";
        Session["SPDS_SignatoryCategorySetup_CATEGORY_NAME"] = "0";
        Session["SPDS_SignatoryCategorySetup_FROM_LIMIT"] = "0";
        Session["SPDS_SignatoryCategorySetup_TO_LIMIT"] = "0";
        Session["SPDS_SignatoryCategorySetup_CurrentStatus"] = "0";

        Session["SPDS_CustomerInstrumentSetup_ID"] = "0";
        Session["SPDS_CustomerInstrumentSetup_CUSTOMER_ID"] = "0";
        Session["SPDS_CustomerInstrumentSetup_INSTRUMENT_ID"] = "%";
        Session["SPDS_CustomerInstrumentSetup_CUSTOMER_Name"] = "0";
        Session["SPDS_CustomerInstrumentSetup_INSTRUMENT_Name"] = "0";
        Session["SPDS_CustomerInstrumentSetup_CHOPPER_REQUIRED"] = "%";
        Session["SPDS_CustomerInstrumentSetup_A_UserID"] = "%";
        Session["SPDS_CustomerInstrumentSetup_A_DateTime"] = "%";
        Session["SPDS_CustomerInstrumentSetup_E_UserID"] = "%";
        Session["SPDS_CustomerInstrumentSetup_E_DateTime"] = "%";


        Session["SPDS_InstrumentSetup_ID"] = "%";
        Session["SPDS_InstrumentSetup_INSTRUMENT_NAME"] = "0";
        Session["SPDS_InstrumentSetup_RDLC_UPLOAD"] = "%";
        Session["SPDS_InstrumentSetup_RDLC_UPLOAD_PATH"] = "%";
        Session["SPDS_InstrumentSetup_A_UserID"] = "%";
        Session["SPDS_InstrumentSetup_A_DateTime"] = "%";
        Session["SPDS_InstrumentSetup_E_UserID"] = "%";
        Session["SPDS_InstrumentSetup_E_DateTime"] = "%";

        Session["SPDS_AuthorizationMatrix_ID"] = "%";
        Session["SPDS_AuthorizationMatrix_CUSTOMER_ID"] = "%";
        Session["SPDS_AuthorizationMatrix_INSTRUMENT_ID"] = "%";
        Session["SPDS_AuthorizationMatrix_MAKE_SIGNATORY_ID"] = "%";
        Session["SPDS_AuthorizationMatrix_CHECKER_SIGNATORY_ID"] = "%";

        Session["SPDS_AuthorizationMatrix_CATEGORY_NAME"] = "0";
        Session["SPDS_AuthorizationMatrix_CUSTOMER_NAME"] = "0";
        Session["SPDS_AuthorizationMatrix_INSTRUMENT_NAME"] = "0";
        Session["SPDS_AuthorizationMatrix_MAKE_SIGNATORY_NAME"] = "0";
        Session["SPDS_AuthorizationMatrix_CHECKER_SIGNATORY_NAME"] = "0";
        Session["SPDS_AuthorizationMatrix_CATEGORY_NAME"] = "0";

        Session["SPDS_AuthorizationMatrix_A_UserID"] = "%";
        Session["SPDS_AuthorizationMatrix_A_DateTime"] = "%";
        Session["SPDS_AuthorizationMatrix_E_UserID"] = "%";
        Session["SPDS_AuthorizationMatrix_E_DateTime"] = "%";

        Session["SPDS_CustomerProductPricing_Master_CustomerID"] = "0";
        Session["SPDS_CustomerProductPricing_Master_ProductID"] = "0";

        Session["SPDS_CustomerProductPricing_Master_CustomerName"] = "0";
        Session["SPDS_CustomerProductPricing_Master_ProductName"] = "0";
        Session["SPDS_CustomerProductPricing_Master_CorrespondingName"] = "%";
        Session["SPDS_CustomerProductPricing_Master_CourierName"] = "%";

        Session["SPDS_CustomerProductPricing_Detail_ID"] = "0";
        Session["SPDS_CustomerProductPricing_Detail_CustomerProductPricingID"] = "0";
        Session["SPDS_CustomerProductPricing_Detail_MinServiceCharges"] = "%";
        Session["SPDS_CustomerProductPricing_Detail_FlatRate"] = "%";
        Session["SPDS_CustomerProductPricing_Detail_PricingTypeID"] = "%";
        Session["SPDS_CustomerProductPricing_Detail_FromStationID"] = "%";
        Session["SPDS_CustomerProductPricing_Detail_ToStationID"] = "%";
        Session["SPDS_CustomerProductPricing_Detail_SambaServiceCharges"] = "%";
        Session["SPDS_CustomerProductPricing_Detail_PrintLocationCharges"] = "%";
        Session["SPDS_CustomerProductPricing_Detail_OtherBankCharges"] = "%";
        Session["SPDS_CustomerProductPricing_Detail_CourierChargesSameCity"] = "%";
        Session["SPDS_CustomerProductPricing_Detail_ReturnChargesSameCity"] = "%";
        Session["SPDS_CustomerProductPricing_Detail_PODChargesSameCity"] = "%";
        Session["SPDS_CustomerProductPricing_Detail_CourierChargesOtherCity"] = "%";
        Session["SPDS_CustomerProductPricing_Detail_ReturnChargesOtherCity"] = "%";
        Session["SPDS_CustomerProductPricing_Detail_PODChargesOtherCity"] = "%";
        Session["SPDS_CustomerProductPricing_Detail_A_UserID"] = "%";
        Session["SPDS_CustomerProductPricing_Detail_A_DateTime"] = "%";
        Session["SPDS_CustomerProductPricing_Detail_E_UserID"] = "%";
        Session["SPDS_CustomerProductPricing_Detail_E_DateTime"] = "%";

        Session["RPS_MoneyGramRemittance_PrincipleBankID"] = "0";
        Session["RPS_MoneyGramRemittance_IncomingBeneficiaryID"] = "0";
        Session["RPS_MoneyGramRemittance_IncomingRemittanceID"] = "0";
        Session["RPS_MoneyGramRemittance_IncomingRemitterID"] = "0";
        Session["RPS_MoneyGramRemittance_IncomingBatchHeaderID"] = "%";
        Session["RPS_MoneyGramRemittance_TransactionRefNo"] = "%";
        Session["RPS_MoneyGramRemittance_CoverAmountUSD"] = "%";
        Session["RPS_MoneyGramRemittance_TransactionAmount"] = "0";
        Session["RPS_MoneyGramRemittance_RemitterID"] = "%";
        Session["RPS_MoneyGramRemittance_RemitterAccountNo"] = "%";
        Session["RPS_MoneyGramRemittance_FirstName"] = "%";
        Session["RPS_MoneyGramRemittance_MiddleName"] = "%";
        Session["RPS_MoneyGramRemittance_LastName"] = "%";
        Session["RPS_MoneyGramRemittance_TelephoneNo"] = "%";
        Session["RPS_MoneyGramRemittance_Country"] = "%";
        Session["RPS_MoneyGramRemittance_BeneficiaryFirstName"] = "%";
        Session["RPS_MoneyGramRemittance_BeneficiaryMiddleName"] = "%";
        Session["RPS_MoneyGramRemittance_BeneficiaryLastName"] = "%";
        Session["RPS_MoneyGramRemittance_Address1"] = "%";
        Session["RPS_MoneyGramRemittance_Address2"] = "%";
        Session["RPS_MoneyGramRemittance_AccountNo"] = "%";
        Session["RPS_MoneyGramRemittance_City"] = "%";
        Session["RPS_MoneyGramRemittance_BeneficiaryTelephoneNo"] = "%";
        Session["RPS_MoneyGramRemittance_NICNo"] = "0";
        Session["RPS_MoneyGramRemittance_BeneficiaryZipCode"] = "%";
        Session["RPS_MoneyGramRemittance_A_UserID"] = "%";
        Session["RPS_MoneyGramRemittance_A_DateTime"] = "%";
        Session["RPS_MoneyGramRemittance_E_UserID"] = "%";
        Session["RPS_MoneyGramRemittance_E_DateTime"] = "%";


        Session["RPS_DraftStopPayment_ID"] = "0";
        Session["RPS_DraftStopPayment_DraftID"] = "0";
        Session["RPS_DraftStopPayment_DraftCancellationID"] = "%";
        Session["RPS_DraftStopPayment_RequestDate"] = "%";
        Session["RPS_DraftStopPayment_BankConfirmationDate"] = "%";
        Session["RPS_DraftStopPayment_StatusSwitch"] = "%";
        Session["RPS_DraftStopPayment_A_UserID"] = "%";
        Session["RPS_DraftStopPayment_A_DateTime"] = "%";
        Session["RPS_DraftStopPayment_E_UserID"] = "%";
        Session["RPS_DraftStopPayment_E_DateTime"] = "%";

        Session["SPDS_PrintAgentSetup_ID"] = "0";
        Session["SPDS_PrintAgentSetup_PRINT_AGENT_NAME"] = "0";
        Session["SPDS_PrintAgentSetup_CONTACT_PERSON"] = "0";
        Session["SPDS_PrintAgentSetup_ADDRESS"] = "0";
        Session["SPDS_PrintAgentSetup_PHONE"] = "%";
        Session["SPDS_PrintAgentSetup_FAX"] = "%";
        Session["SPDS_PrintAgentSetup_EMAIL"] = "%";
        Session["SPDS_PrintAgentSetup_SECONDARY_CONTACT_NAME"] = "0";
        Session["SPDS_PrintAgentSetup_SECONDARY_ADDRESS"] = "0";
        Session["SPDS_PrintAgentSetup_SECONDARY_PHONE"] = "%";
        Session["SPDS_PrintAgentSetup_SECONDARY_FAX"] = "%";
        Session["SPDS_PrintAgentSetup_SECONDARY_EMAIL"] = "%";


        Session["SPDS_PrintAgentDetail_ID"] = "0";
        Session["SPDS_PrintAgentDetail_PRINT_AGENT_ID"] = "0";
        Session["SPDS_PrintAgentDetail_PRINT_LOCATION_ID"] = "%";
        Session["SPDS_PrintAgentDetail_DONGAL_PIN"] = "%";
        Session["SPDS_PrintAgentDetail_MASTER_ZIP_CODE"] = "%";
        Session["SPDS_PrintAgentDetail_A_UserID"] = "%";
        Session["SPDS_PrintAgentDetail_A_DateTime"] = "%";
        Session["SPDS_PrintAgentDetail_E_UserID"] = "%";
        Session["SPDS_PrintAgentDetail_E_DateTime"] = "%";

        Session["RPS_MasterZipCode_ID"] = "%";
        Session["RPS_MasterZipCode_CourierID"] = "0";
        Session["RPS_MasterZipCode_StationID"] = "0";
        Session["RPS_MasterZipCode_ServiceID"] = "0";
        Session["RPS_MasterZipCode_BankID"] = "0";
        Session["RPS_MasterZipCode_BranchID"] = "0";
        Session["RPS_MasterZipCode_ZipCode"] = "0";
        Session["RPS_MasterZipCode_Address"] = "%";
        Session["RPS_MasterZipCode_TehsilID"] = "%";
        Session["RPS_MasterZipCode_A_UserID"] = "%";
        Session["RPS_MasterZipCode_A_DateTime"] = "%";
        Session["RPS_MasterZipCode_E_UserID"] = "%";
        Session["RPS_MasterZipCode_E_DateTime"] = "%";

        Session["RPS_DraftCancellation_ID"] = "0";
        Session["RPS_DraftCancellation_DraftID"] = "0";
        Session["RPS_DraftCancellation_CancelNo"] = "%";
        Session["RPS_DraftCancellation_CancelDate"] = "%";
        Session["RPS_DraftCancellation_AcknowledgeDate"] = "%";
        Session["RPS_DraftCancellation_AcknowledgeRefNo"] = "%";
        Session["RPS_DraftCancellation_CancelStatusID"] = "%";
        Session["RPS_DraftCancellation_TracerID"] = "%";
        Session["RPS_DraftCancellation_StatusSwitch"] = "%";
        Session["RPS_DraftCancellation_A_UserID"] = "%";
        Session["RPS_DraftCancellation_A_DateTime"] = "%";
        Session["RPS_DraftCancellation_E_UserID"] = "%";
        Session["RPS_DraftCancellation_E_DateTime"] = "%";

        Session["RPS_CorrespondingBankFilesPath_CorrespondingBankCode"] = "%";
        Session["RPS_CorrespondingBankFilesPath_CorrespondingBankName"] = "0";



        Session["GetDraftHolded_ID"] = "0";
        Session["GetDraftHolded_IsOnline"] = "%";
        Session["GetDraftHolded_DraftNo"] = "0";
        Session["GetDraftHolded_DraftDate"] = "%";
        Session["GetDraftHolded_BeneficiaryName"] = "0";
        Session["GetDraftHolded_RemitterName"] = "0";
        Session["GetDraftHolded_RemittanceRefNo"] = "0";
        Session["GetDraftHolded_BeneficiaryNo"] = "0";
        Session["GetDraftHolded_RemitterNo"] = "0";
        Session["GetDraftHolded_Rate"] = "%";
        Session["GetDraftHolded_CurrencyCode"] = "%";
        Session["GetDraftHolded_CurrencyName"] = "%";
        Session["GetDraftHolded_TransactionAmount"] = "%";
        Session["GetDraftHolded_CoverAmountUSD"] = "%";
        Session["GetDraftHolded_BankCode"] = "%";
        Session["GetDraftHolded_BankName"] = "%";
        Session["GetDraftHolded_PODID"] = "%";
        Session["GetDraftHolded_PODNo"] = "%";
        Session["GetDraftHolded_MenifestID"] = "%";
        Session["GetDraftHolded_MenifestNo"] = "%";
        Session["GetDraftHolded_A_UserID"] = "%";
        Session["GetDraftHolded_HoldReason"] = "%";
        Session["drw"] = "";

        Session["GetDraftReleased_ID"] = "0";
        Session["GetDraftReleased_IsOnline"] = "%";
        Session["GetDraftReleased_DraftNo"] = "0";
        Session["GetDraftReleased_DraftDate"] = "%";
        Session["GetDraftReleased_BeneficiaryName"] = "0";
        Session["GetDraftReleased_RemitterName"] = "0";
        Session["GetDraftReleased_RemittanceRefNo"] = "0";
        Session["GetDraftReleased_BeneficiaryNo"] = "0";
        Session["GetDraftReleased_RemitterNo"] = "0";
        Session["GetDraftReleased_Rate"] = "%";
        Session["GetDraftReleased_CurrencyCode"] = "%";
        Session["GetDraftReleased_CurrencyName"] = "%";
        Session["GetDraftReleased_TransactionAmount"] = "%";
        Session["GetDraftReleased_CoverAmountUSD"] = "%";
        Session["GetDraftReleased_BankCode"] = "%";
        Session["GetDraftReleased_BankName"] = "%";
        Session["GetDraftReleased_PODID"] = "%";
        Session["GetDraftReleased_PODNo"] = "%";
        Session["GetDraftReleased_MenifestID"] = "%";
        Session["GetDraftReleased_MenifestNo"] = "%";
        Session["GetDraftReleased_A_UserID"] = "%";
        Session["GetDraftReleased_HoldReason"] = "%";
        Session["drw"] = "";

        Session["RPS_DraftGetAllForCancel_DraftID"] = "0";
        Session["RPS_DraftGetAllForCancel_DraftType"] = "%";
        Session["RPS_DraftGetAllForCancel_DraftNo"] = "0";
        Session["RPS_DraftGetAllForCancel_DraftDate"] = "%";
        Session["RPS_DraftGetAllForCancel_CurrencyCode"] = "%";
        Session["RPS_DraftGetAllForCancel_CurrencyName"] = "%";
        Session["RPS_DraftGetAllForCancel_TransactionAmount"] = "%";
        Session["RPS_DraftGetAllForCancel_CoverAmountUSD"] = "%";
        Session["RPS_DraftGetAllForCancel_RemitterNo"] = "0";
        Session["RPS_DraftGetAllForCancel_RemittanceRefNo"] = "0";
        Session["RPS_DraftGetAllForCancel_BeneficiaryNo"] = "0";
        Session["RPS_DraftGetAllForCancel_BankCode"] = "%";
        Session["RPS_DraftGetAllForCancel_BankName"] = "%";
        Session["RPS_DraftGetAllForCancel_PODID"] = "%";
        Session["RPS_DraftGetAllForCancel_PODNo"] = "0";
        Session["RPS_DraftGetAllForCancel_MenifestID"] = "%";
        Session["RPS_DraftGetAllForCancel_MenifestNo"] = "%";
        Session["RPS_DraftGetAllForCancel_BeneficiaryID"] = "%";
        Session["RPS_DraftGetAllForCancel_RemitterID"] = "%";
        Session["RPS_DraftGetAllForCancel_A_UserID"] = "%";

        Session["RPS_Draft_ID"] = "%";
        Session["RPS_Draft_DraftAssignmentBatchID"] = "%";
        Session["RPS_Draft_DraftNo"] = "0";
        Session["RPS_Draft_CorrespondingBankID"] = "%";


        Session["STR1_SUPPORT"] = "";

        Session["rps_sp_RemittanceCode"] = "%";
        Session["Batch_ID"] = "0";


        Session["Source"] = "%";
        Session["ConfigurationName"] = "%";

        Session["REMITTERNO"] = "0";
        Session["PODNO"] = "0";

        Session["SSO_UserID"] = "%";
        Session["PrintAgentDetail_IDD"] = "%";

        //Session["FTPUserID"] = "";
        //Session["FTPPASSWORD"] = "";
        //Session["FTPIP"] = "";



        Session["DRAFTIQUIRY_RemitterNo"] = "%";
        Session["DRAFTIQUIRY_RemitterName"] = "%";
        Session["DRAFTIQUIRY_BeneficiaryNo"] = "%";
        Session["DRAFTIQUIRY_BeneficiaryName"] = "%";
        Session["DRAFTIQUIRY_STARDRAFTNO"] = "%";
        Session["DRAFTIQUIRY_STATIONNAME"] = "%";
        Session["DRAFTIQUIRY_PODNO"] = "%";
        Session["DRAFTIQUIRY_REMITTANCENO"] = "%";
        Session["DRAFTIQUIRY_SPDS_TYPE"] = "%";
        Session["DRAFTIQUIRY_DRAFTNO"] = "%";
    }
    void Session_End(object sender, EventArgs e)
    {
        Session.Clear();
        Session.Abandon();
    }
    void Session_OnEnd(object sender, EventArgs e)
    { }       
</script>


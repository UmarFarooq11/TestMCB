using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.OracleClient;

public class TABLE_RPS_Bank : IRPS_Bank
{
    private string A_DateTime;
    private string A_UserID;
    private string Abbreviation;
    private string AccountNo;
    private string Address;
    private string AssignedCitiBankId;
    private string BankCode;
    private string BankName;
    private string CustomerType;
    private string DraftFooterMessage;
    private string E_DateTime;
    private string E_UserID;
    private string Email;
    private string FaxNo;
    private string FloorLimit;
    private string ID;
    private string InputFileAllowed;
    private string IsCitiBank;
    private string IsDollarBased;
    private string IsPRI;
    private string OfflineDraftStartingNo;
    private string OnlineDraftStartingNo;
    private string PhoneNo;
    private string RemitType;
    private string ReportTitle;
    private string ServiceTypeID;
    private string UnclaimedDraftPeriod;
    private string URL;
    private string CustomerBalance;
    DatabaseConnection_Util DataTransform = new DatabaseConnection_Util();

    private DataSet RPS_Bank_DATASET = new DataSet();
    private DataRow DR;

    public TABLE_RPS_Bank()
    {
        //RPS_Bank_DATASET = DataTransform.ReteriveDataMultiple
        //        ("SP_GET_TABLE_STRUCT RPS_Bank", "NEW_USER_INFO");


        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("P_TABLE_NAME", OracleType.VarChar, ParameterDirection.Input, "RPS_Bank");
        PR[1] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        RPS_Bank_DATASET = DataTransform.Oracle_GetDataSetSP("SP_GET_TABLE_STRUCT", PR);

    }

    public void RecordInputStart()
    { DR = RPS_Bank_DATASET.Tables[0].NewRow(); }

    public void RecordInputCommit()
    { RPS_Bank_DATASET.Tables[0].Rows.Add(DR); }

    public DataSet ReturnResultSet()
    { return RPS_Bank_DATASET; }

    public void ClearTable()
    { RPS_Bank_DATASET.Tables[0].Rows.Clear(); }
    public string Get_A_DateTime
    {
        set
        {
            A_DateTime = value;
            DataTransform.DataPlacement("A_DateTime", A_DateTime, RPS_Bank_DATASET, DR);
        }
    }
   
    public string Get_Customer_Balance
    {
        set
        {
            CustomerBalance = value;
            DataTransform.DataPlacement("BAL_AMOUNT", CustomerBalance, RPS_Bank_DATASET, DR);
        }
    }
    public string Get_A_UserID
    {
        set
        {
            A_UserID = value;
            DataTransform.DataPlacement("A_UserID", A_UserID, RPS_Bank_DATASET, DR);
        }
    }
    public string Get_Abbreviation
    {
        set
        {
            Abbreviation = value;
            DataTransform.DataPlacement("Abbreviation", Abbreviation, RPS_Bank_DATASET, DR);
        }
    }
    public string Get_AccountNo
    {
        set
        {
            AccountNo = value;
            DataTransform.DataPlacement("AccountNo", AccountNo, RPS_Bank_DATASET, DR);
        }
    }
    public string Get_Address
    {
        set
        {
            Address = value;
            DataTransform.DataPlacement("Address", Address, RPS_Bank_DATASET, DR);
        }
    }
    public string Get_AssignedCitiBankId
    {
        set
        {
            AssignedCitiBankId = value;
            DataTransform.DataPlacement("AssignedCitiBankId", AssignedCitiBankId, RPS_Bank_DATASET, DR);
        }
    }
    public string Get_BankCode
    {
        set
        {
            BankCode = value;
            DataTransform.DataPlacement("BankCode", BankCode, RPS_Bank_DATASET, DR);
        }
    }
    public string Get_BankName
    {
        set
        {
            BankName = value;
            DataTransform.DataPlacement("BankName", BankName, RPS_Bank_DATASET, DR);
        }
    }
    public string Get_CustomerType
    {
        set
        {
            CustomerType = value;
            DataTransform.DataPlacement("CustomerType", CustomerType, RPS_Bank_DATASET, DR);
        }
    }
    public string Get_DraftFooterMessage
    {
        set
        {
            DraftFooterMessage = value;
            DataTransform.DataPlacement("DraftFooterMessage", DraftFooterMessage, RPS_Bank_DATASET, DR);
        }
    }
    public string Get_E_DateTime
    {
        set
        {
            E_DateTime = value;
            DataTransform.DataPlacement("E_DateTime", E_DateTime, RPS_Bank_DATASET, DR);
        }
    }
    public string Get_E_UserID
    {
        set
        {
            E_UserID = value;
            DataTransform.DataPlacement("E_UserID", E_UserID, RPS_Bank_DATASET, DR);
        }
    }
    public string Get_Email
    {
        set
        {
            Email = value;
            DataTransform.DataPlacement("Email", Email, RPS_Bank_DATASET, DR);
        }
    }
    public string Get_FaxNo
    {
        set
        {
            FaxNo = value;
            DataTransform.DataPlacement("FaxNo", FaxNo, RPS_Bank_DATASET, DR);
        }
    }
    public string Get_FloorLimit
    {
        set
        {
            FloorLimit = value;
            DataTransform.DataPlacement("FloorLimit", FloorLimit, RPS_Bank_DATASET, DR);
        }
    }
    public string Get_ID
    {
        set
        {
            ID = value;
            DataTransform.DataPlacement("ID", ID, RPS_Bank_DATASET, DR);
        }
    }
    public string Get_InputFileAllowed
    {
        set
        {
            InputFileAllowed = value;
            DataTransform.DataPlacement("InputFileAllowed", InputFileAllowed, RPS_Bank_DATASET, DR);
        }
    }
    public string Get_IsCitiBank
    {
        set
        {
            IsCitiBank = value;
            DataTransform.DataPlacement("IsCitiBank", IsCitiBank, RPS_Bank_DATASET, DR);
        }
    }
    public string Get_IsDollarBased
    {
        set
        {
            IsDollarBased = value;
            DataTransform.DataPlacement("IsDollarBased", IsDollarBased, RPS_Bank_DATASET, DR);
        }
    }
    public string Get_IsPRI
    {
        set
        {
            IsPRI = value;
            DataTransform.DataPlacement("IsPRI", IsPRI, RPS_Bank_DATASET, DR);
        }
    }
    public string Get_OfflineDraftStartingNo
    {
        set
        {
            OfflineDraftStartingNo = value;
            DataTransform.DataPlacement("OfflineDraftStartingNo", OfflineDraftStartingNo, RPS_Bank_DATASET, DR);
        }
    }
    public string Get_OnlineDraftStartingNo
    {
        set
        {
            OnlineDraftStartingNo = value;
            DataTransform.DataPlacement("OnlineDraftStartingNo", OnlineDraftStartingNo, RPS_Bank_DATASET, DR);
        }
    }
    public string Get_PhoneNo
    {
        set
        {
            PhoneNo = value;
            DataTransform.DataPlacement("PhoneNo", PhoneNo, RPS_Bank_DATASET, DR);
        }
    }
    public string Get_RemitType
    {
        set
        {
            RemitType = value;
            DataTransform.DataPlacement("RemitType", RemitType, RPS_Bank_DATASET, DR);
        }
    }
    public string Get_ReportTitle
    {
        set
        {
            ReportTitle = value;
            DataTransform.DataPlacement("ReportTitle", ReportTitle, RPS_Bank_DATASET, DR);
        }
    }
    public string Get_ServiceTypeID
    {
        set
        {
            ServiceTypeID = value;
            DataTransform.DataPlacement("ServiceTypeID", ServiceTypeID, RPS_Bank_DATASET, DR);
        }
    }
    public string Get_UnclaimedDraftPeriod
    {
        set
        {
            UnclaimedDraftPeriod = value;
            DataTransform.DataPlacement("UnclaimedDraftPeriod", UnclaimedDraftPeriod, RPS_Bank_DATASET, DR);
        }
    }
    public string Get_URL
    {
        set
        {
            URL = value;
            DataTransform.DataPlacement("URL", URL, RPS_Bank_DATASET, DR);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OracleClient;

public class TABLE_RPS_BankContact : IRPS_BankContact
{
    private string Address;
    private string BankID;
    private string ContactName;
    private string Email;
    private string FaxNo;
    private string ID;
    private string NTNNo;
    private string PhoneNo;
    DatabaseConnection_Util DataTransform = new DatabaseConnection_Util();

    private DataSet RPS_BankContact_DATASET = new DataSet();
    private DataRow DR;

    public TABLE_RPS_BankContact()
    {
        //RPS_BankContact_DATASET = DataTransform.ReteriveDataMultiple
        //        ("EXEC SP_GET_TABLE_STRUCT RPS_BankContact", "NEW_USER_INFO");

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("P_TABLE_NAME", OracleType.VarChar, ParameterDirection.Input, "RPS_BankContact");
        PR[1] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        RPS_BankContact_DATASET = DataTransform.Oracle_GetDataSetSP("SP_GET_TABLE_STRUCT", PR);

    }

    public void RecordInputStart()
    { DR = RPS_BankContact_DATASET.Tables[0].NewRow(); }

    public void RecordInputCommit()
    { RPS_BankContact_DATASET.Tables[0].Rows.Add(DR); }

    public DataSet ReturnResultSet()
    { return RPS_BankContact_DATASET; }

    public void ClearTable()
    { RPS_BankContact_DATASET.Tables[0].Rows.Clear(); }

    public string Get_Address
    {
        set
        {
            Address = value;
            DataTransform.DataPlacement("Address", Address, RPS_BankContact_DATASET, DR);
        }
    }
    public string Get_BankID
    {
        set
        {
            BankID = value;
            DataTransform.DataPlacement("BankID", BankID, RPS_BankContact_DATASET, DR);
        }
    }
    public string Get_ContactName
    {
        set
        {
            ContactName = value;
            DataTransform.DataPlacement("ContactName", ContactName, RPS_BankContact_DATASET, DR);
        }
    }
    public string Get_Email
    {
        set
        {
            Email = value;
            DataTransform.DataPlacement("Email", Email, RPS_BankContact_DATASET, DR);
        }
    }
    public string Get_FaxNo
    {
        set
        {
            FaxNo = value;
            DataTransform.DataPlacement("FaxNo", FaxNo, RPS_BankContact_DATASET, DR);
        }
    }
    public string Get_ID
    {
        set
        {
            ID = value;
            DataTransform.DataPlacement("ID", ID, RPS_BankContact_DATASET, DR);
        }
    }
    public string Get_NTNNo
    {
        set
        {
            NTNNo = value;
            DataTransform.DataPlacement("NTNNo", NTNNo, RPS_BankContact_DATASET, DR);
        }
    }
    public string Get_PhoneNo
    {
        set
        {
            PhoneNo = value;
            DataTransform.DataPlacement("PhoneNo", PhoneNo, RPS_BankContact_DATASET, DR);
        }
    }
}

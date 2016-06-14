using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.OracleClient;

public class TABLE_RPS_DraftCancellation : IRPS_DraftCancellation
{
    private string A_DateTime;
    private string A_UserID;
    private string AcknowledgeDate;
    private string AcknowledgeRefNo;
    private string CancelDate;
    private string CancelNo;
    private string CancelStatusID;
    private string DraftID;
    private string E_DateTime;
    private string E_UserID;
    private string ID;
    private string StatusSwitch;
    private string TracerID;
    private string ReIssue;
    private string Refund ;
    private string SundryDuplicate;
    private string CompanyCode;
    DatabaseConnection_Util DataTransform = new DatabaseConnection_Util();

    private DataSet RPS_DraftCancellation_DATASET = new DataSet();
    private DataRow DR;

    public TABLE_RPS_DraftCancellation()
    {
        RPS_DraftCancellation_DATASET = DataTransform.ReteriveDataMultiple
                ("select DraftID ID ,DraftID,CancelNo,to_char(CancelDate,'MM/dd/yyyy') CancelDate,to_char(AcknowledgeDate,'MM/dd/yyyy') AcknowledgeDate,AcknowledgeRefNo,CancelStatusID,TracerID ,'' ReIssue,'' Refund ,'' SundryDuplicate ,A_UserID ,to_char(A_DateTime,'MM/dd/yyyy HH:MI:SS') A_DateTime ,E_UserID ,to_char(E_DateTime,'MM/dd/yyyy HH:MI:SS') E_DateTime,company_code from RPS_DraftCancellation WHERE 2=1 ", "NEW_USER_INFO");
                      //top 0 ID,

        //OracleParameter[] PR = new OracleParameter[2];
        //PR[0] = DataTransform.Oracle_Param("P_TABLE_NAME", OracleType.VarChar, ParameterDirection.Input, "RPS_DraftCancellation");
        //PR[1] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        //RPS_DraftCancellation_DATASET = DataTransform.Oracle_GetDataSetSP("SP_GET_TABLE_STRUCT", PR);
    }
    public void RecordInputStart()
    { DR = RPS_DraftCancellation_DATASET.Tables[0].NewRow(); }
    public void RecordInputCommit()
    { RPS_DraftCancellation_DATASET.Tables[0].Rows.Add(DR); }
    public DataSet ReturnResultSet()
    { return RPS_DraftCancellation_DATASET; }
    public void ClearTable()
    { RPS_DraftCancellation_DATASET.Tables[0].Rows.Clear(); }

    public string Get_A_DateTime
    {
        set
        {
            A_DateTime = value;
            DataTransform.DataPlacement("A_DateTime", A_DateTime, RPS_DraftCancellation_DATASET, DR);
        }
    }
    public string Get_A_UserID
    {
        set
        {
            A_UserID = value;
            DataTransform.DataPlacement("A_UserID", A_UserID, RPS_DraftCancellation_DATASET, DR);
        }
    }
    public string Get_AcknowledgeDate
    {
        set
        {
            AcknowledgeDate = value;
            DataTransform.DataPlacement("AcknowledgeDate", AcknowledgeDate, RPS_DraftCancellation_DATASET, DR);
        }
    }
    public string Get_AcknowledgeRefNo
    {
        set
        {
            AcknowledgeRefNo = value;
            DataTransform.DataPlacement("AcknowledgeRefNo", AcknowledgeRefNo, RPS_DraftCancellation_DATASET, DR);
        }
    }
    public string Get_CancelDate
    {
        set
        {
            CancelDate = value;
            DataTransform.DataPlacement("CancelDate", CancelDate, RPS_DraftCancellation_DATASET, DR);
        }
    }
    public string Get_CancelNo
    {
        set
        {
            CancelNo = value;
            DataTransform.DataPlacement("CancelNo", CancelNo, RPS_DraftCancellation_DATASET, DR);
        }
    }
    public string Get_CancelStatusID
    {
        set
        {
            CancelStatusID = value;
            DataTransform.DataPlacement("CancelStatusID", CancelStatusID, RPS_DraftCancellation_DATASET, DR);
        }
    }
    public string Get_DraftID
    {
        set
        {
            DraftID = value;
            DataTransform.DataPlacement("DraftID", DraftID, RPS_DraftCancellation_DATASET, DR);
        }
    }
    public string Get_E_DateTime
    {
        set
        {
            E_DateTime = value;
            DataTransform.DataPlacement("E_DateTime", E_DateTime, RPS_DraftCancellation_DATASET, DR);
        }
    }
    public string Get_E_UserID
    {
        set
        {
            E_UserID = value;
            DataTransform.DataPlacement("E_UserID", E_UserID, RPS_DraftCancellation_DATASET, DR);
        }
    }
    public string Get_ID
    {
        set
        {
            ID = value;
            DataTransform.DataPlacement("ID", ID, RPS_DraftCancellation_DATASET, DR);
        }
    }
    public string Get_StatusSwitch
    {
        set
        {
            StatusSwitch = value;
            DataTransform.DataPlacement("StatusSwitch", StatusSwitch, RPS_DraftCancellation_DATASET, DR);
        }
    }
    public string Get_TracerID
    {
        set
        {
            TracerID = value;
            DataTransform.DataPlacement("TracerID", TracerID, RPS_DraftCancellation_DATASET, DR);
        }
    }

    public string Get_Refund
    {
        set
        {
            Refund = value;
            DataTransform.DataPlacement("Refund", Refund, RPS_DraftCancellation_DATASET, DR);
        }
    }
    public string Get_ReIssue
    {
        set
        {
            ReIssue = value;
            DataTransform.DataPlacement("ReIssue", ReIssue, RPS_DraftCancellation_DATASET, DR);
        }
    }
    public string Get_SundryDuplicate
    {
        set
        {
            SundryDuplicate = value;
            DataTransform.DataPlacement("SundryDuplicate", SundryDuplicate, RPS_DraftCancellation_DATASET, DR);
        }
    }
    public string Get_Company_Code
    {
        set
        {
            CompanyCode = value;
            DataTransform.DataPlacement("company_code", CompanyCode, RPS_DraftCancellation_DATASET, DR);
        }
    }
}

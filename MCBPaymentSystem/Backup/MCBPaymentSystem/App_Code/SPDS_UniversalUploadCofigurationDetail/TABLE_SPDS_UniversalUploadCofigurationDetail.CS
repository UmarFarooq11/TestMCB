using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OracleClient;

public class TABLE_SPDS_UniversalUploadCofigurationDetail : ISPDS_UniversalUploadCofigurationDetail
{
    private string A_DateTime;
    private string A_userID;
    private string ColumnName;
    private string E_DateTime;
    private string E_UserID;
    private string ID;
    private string Sequence;
    private string UniversalUploadID;
    DatabaseConnection_Util DataTransform = new DatabaseConnection_Util();

    private DataSet SPDS_UniversalUploadCofigurationDetail_DATASET = new DataSet();
    private DataRow DR;

    public TABLE_SPDS_UniversalUploadCofigurationDetail()
    {
        // SPDS_UniversalUploadCofigurationDetail_DATASET = DataTransform.ReteriveDataMultiple
        // ("EXEC SP_GET_TABLE_STRUCT SPDS_UniversalUploadCofigurationDetail","NEW_USER_INFO");

        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("P_TABLE_NAME", OracleType.VarChar, ParameterDirection.Input, "SPDS_UNIVUploadCofiguration");
        PR[1] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        SPDS_UniversalUploadCofigurationDetail_DATASET = DataTransform.Oracle_GetDataSetSP("SP_GET_TABLE_STRUCT", PR);

    }

    public void RecordInputStart()
    { DR = SPDS_UniversalUploadCofigurationDetail_DATASET.Tables[0].NewRow(); }

    public void RecordInputCommit()
    { SPDS_UniversalUploadCofigurationDetail_DATASET.Tables[0].Rows.Add(DR); }

    public DataSet ReturnResultSet()
    { return SPDS_UniversalUploadCofigurationDetail_DATASET; }

    public void ClearTable()
    { SPDS_UniversalUploadCofigurationDetail_DATASET.Tables[0].Rows.Clear(); }
    public string Get_A_DateTime
    {
        set
        {
            A_DateTime = value;
            DataTransform.DataPlacement("A_DateTime", A_DateTime, SPDS_UniversalUploadCofigurationDetail_DATASET, DR);
        }
    }
    public string Get_A_userID
    {
        set
        {
            A_userID = value;
            DataTransform.DataPlacement("A_userID", A_userID, SPDS_UniversalUploadCofigurationDetail_DATASET, DR);
        }
    }
    public string Get_ColumnName
    {
        set
        {
            ColumnName = value;
            DataTransform.DataPlacement("ColumnName", ColumnName, SPDS_UniversalUploadCofigurationDetail_DATASET, DR);
        }
    }
    public string Get_E_DateTime
    {
        set
        {
            E_DateTime = value;
            DataTransform.DataPlacement("E_DateTime", E_DateTime, SPDS_UniversalUploadCofigurationDetail_DATASET, DR);
        }
    }
    public string Get_E_UserID
    {
        set
        {
            E_UserID = value;
            DataTransform.DataPlacement("E_UserID", E_UserID, SPDS_UniversalUploadCofigurationDetail_DATASET, DR);
        }
    }
    public string Get_ID
    {
        set
        {
            ID = value;
            DataTransform.DataPlacement("ID", ID, SPDS_UniversalUploadCofigurationDetail_DATASET, DR);
        }
    }
    public string Get_Sequence
    {
        set
        {
            Sequence = value;
            DataTransform.DataPlacement("Sequence", Sequence, SPDS_UniversalUploadCofigurationDetail_DATASET, DR);
        }
    }
    public string Get_UniversalUploadID
    {
        set
        {
            UniversalUploadID = value;
            DataTransform.DataPlacement("UniversalUploadID", UniversalUploadID, SPDS_UniversalUploadCofigurationDetail_DATASET, DR);
        }
    }
}

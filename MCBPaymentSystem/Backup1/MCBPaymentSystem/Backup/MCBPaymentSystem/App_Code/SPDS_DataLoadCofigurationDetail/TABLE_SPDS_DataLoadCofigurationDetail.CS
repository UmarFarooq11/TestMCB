using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OracleClient;

public class TABLE_SPDS_DataLaodCofigurationDetail : ISPDS_DataLoadCofigurationDetail
{


    private string CONF_ID;
    private string CONF_DEF_ID;
    private string COLUMN_ORDER;
    private string COLUMN_SEQ;
    private string COLUMN_SEQ_OLD;
    private string FROM_POS;
    private string TO_POS;

    //private string A_DateTime;
    //private string A_userID;
    //private string ColumnName;
    //private string E_DateTime;
    //private string E_UserID;
    //private string ID;
    //private string Sequence;
    //private string UniversalUploadID;
    DatabaseConnection_Util DataTransform = new DatabaseConnection_Util();

    private DataSet SPDS_DataLoadCofigurationDetail_DATASET = new DataSet();
    private DataRow DR;

    public TABLE_SPDS_DataLaodCofigurationDetail()
    {
        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("P_TABLE_NAME", OracleType.VarChar, ParameterDirection.Input, "CONFIG_DEF_DETAIL");
        PR[1] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        SPDS_DataLoadCofigurationDetail_DATASET = DataTransform.Oracle_GetDataSetSP("SP_GET_TABLE_STRUCT", PR);
    }

    public void RecordInputStart()
    { DR = SPDS_DataLoadCofigurationDetail_DATASET.Tables[0].NewRow(); }

    public void RecordInputCommit()
    { SPDS_DataLoadCofigurationDetail_DATASET.Tables[0].Rows.Add(DR); }

    public DataSet ReturnResultSet()
    { return SPDS_DataLoadCofigurationDetail_DATASET; }

    public void ClearTable()
    { SPDS_DataLoadCofigurationDetail_DATASET.Tables[0].Rows.Clear(); }


    public string Get_CONF_ID
    {
        set
        {
            CONF_ID = value;
            DataTransform.DataPlacement("CONF_ID", CONF_ID, SPDS_DataLoadCofigurationDetail_DATASET, DR);
        }
    }
    public string Get_CONF_DEF_ID
    {
        set
        {
            CONF_DEF_ID = value;
            DataTransform.DataPlacement("CONF_DEF_ID", CONF_DEF_ID, SPDS_DataLoadCofigurationDetail_DATASET, DR);
        }
    }
    public string Get_COLUMN_ORDER
    {
        set
        {
            COLUMN_ORDER = value;
            DataTransform.DataPlacement("COLUMN_ORDER", COLUMN_ORDER, SPDS_DataLoadCofigurationDetail_DATASET, DR);
        }
    }
    public string Get_COLUMN_SEQ
    {
        set
        {
            COLUMN_SEQ = value;
            DataTransform.DataPlacement("COLUMN_SEQ", COLUMN_SEQ, SPDS_DataLoadCofigurationDetail_DATASET, DR);
        }
    }
    public string Get_COLUMN_SEQ_OLD
    {
        set
        {
            COLUMN_SEQ_OLD = value;
            DataTransform.DataPlacement("COLUMN_SEQ", COLUMN_SEQ_OLD, SPDS_DataLoadCofigurationDetail_DATASET, DR);
        }
    }
    public string Get_FROM_POS
    {
        set
        {
            FROM_POS = value;
            DataTransform.DataPlacement("FROM_POS", (FROM_POS == "") ? "0" : FROM_POS, SPDS_DataLoadCofigurationDetail_DATASET, DR);
        }
    }
    public string Get_TO_POS
    {
        set
        {
            TO_POS = value;
            DataTransform.DataPlacement("TO_POS", (TO_POS == "") ? "0" : TO_POS, SPDS_DataLoadCofigurationDetail_DATASET, DR);
        }
    }

    //public string Get_A_DateTime
    //{
    //    set
    //    {
    //        A_DateTime = value;
    //        DataTransform.DataPlacement("A_DateTime", A_DateTime, SPDS_DataLoadCofigurationDetail_DATASET, DR);
    //    }
    //}
    //public string Get_A_userID
    //{
    //    set
    //    {
    //        A_userID = value;
    //        DataTransform.DataPlacement("A_userID", A_userID, SPDS_DataLoadCofigurationDetail_DATASET, DR);
    //    }
    //}
    //public string Get_ColumnName
    //{
    //    set
    //    {
    //        ColumnName = value;
    //        DataTransform.DataPlacement("ColumnName", ColumnName, SPDS_DataLoadCofigurationDetail_DATASET, DR);
    //    }
    //}
    //public string Get_E_DateTime
    //{
    //    set
    //    {
    //        E_DateTime = value;
    //        DataTransform.DataPlacement("E_DateTime", E_DateTime, SPDS_DataLoadCofigurationDetail_DATASET, DR);
    //    }
    //}
    //public string Get_E_UserID
    //{
    //    set
    //    {
    //        E_UserID = value;
    //        DataTransform.DataPlacement("E_UserID", E_UserID, SPDS_DataLoadCofigurationDetail_DATASET, DR);
    //    }
    //}
    //public string Get_ID
    //{
    //    set
    //    {
    //        ID = value;
    //        DataTransform.DataPlacement("ID", ID, SPDS_DataLoadCofigurationDetail_DATASET, DR);
    //    }
    //}
    //public string Get_Sequence
    //{
    //    set
    //    {
    //        Sequence = value;
    //        DataTransform.DataPlacement("Sequence", Sequence, SPDS_DataLoadCofigurationDetail_DATASET, DR);
    //    }
    //}
    //public string Get_UniversalUploadID
    //{
    //    set
    //    {
    //        UniversalUploadID = value;
    //        DataTransform.DataPlacement("UniversalUploadID", UniversalUploadID, SPDS_DataLoadCofigurationDetail_DATASET, DR);
    //    }
    //}
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OracleClient;

public class TABLE_SPDS_STATIONARY_DETAIL : ISPDS_STATIONARY_DETAIL
{
    private string A_DATETIME;
    private string A_USERID;
    private string ACTIVATE_FLG;
    private string ACTIVATION_DATE;
    private string E_DATETIME;
    private string E_USERID;
    private string END_SERIAL_NO;
    private string ID;
    private string START_SERIAL_NO;
    private string STATIONARY_MASTER_ID;
    private string PrintLocationID;
    private string PrintAgent;
    DatabaseConnection_Util DataTransform = new DatabaseConnection_Util();

    private DataSet SPDS_STATIONARY_DETAIL_DATASET = new DataSet();
    private DataRow DR;

    public TABLE_SPDS_STATIONARY_DETAIL()
    {
        //SPDS_STATIONARY_DETAIL_DATASET = DataTransform.ReteriveDataMultiple
        //        ("EXEC SP_GET_TABLE_STRUCT SPDS_STATIONARY_DETAIL", "NEW_USER_INFO");

        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("P_TABLE_NAME", OracleType.VarChar, ParameterDirection.Input, "SPDS_STATIONARY_DETAIL");
        PR[1] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        SPDS_STATIONARY_DETAIL_DATASET = DataTransform.Oracle_GetDataSetSP("SP_GET_TABLE_STRUCT", PR);


    }

    public void RecordInputStart()
    { DR = SPDS_STATIONARY_DETAIL_DATASET.Tables[0].NewRow(); }

    public void RecordInputCommit()
    { SPDS_STATIONARY_DETAIL_DATASET.Tables[0].Rows.Add(DR); }

    public DataSet ReturnResultSet()
    { return SPDS_STATIONARY_DETAIL_DATASET; }

    public void ClearTable()
    { SPDS_STATIONARY_DETAIL_DATASET.Tables[0].Rows.Clear(); }
    public string Get_A_DATETIME
    {
        set
        {
            A_DATETIME = value;
            DataTransform.DataPlacement("A_DATETIME", A_DATETIME, SPDS_STATIONARY_DETAIL_DATASET, DR);
        }
    }
    public string Get_A_USERID
    {
        set
        {
            A_USERID = value;
            DataTransform.DataPlacement("A_USERID", A_USERID, SPDS_STATIONARY_DETAIL_DATASET, DR);
        }
    }
    public string Get_ACTIVATE_FLG
    {
        set
        {
            ACTIVATE_FLG = value;
            DataTransform.DataPlacement("ACTIVATE_FLG", ACTIVATE_FLG, SPDS_STATIONARY_DETAIL_DATASET, DR);
        }
    }
    public string Get_ACTIVATION_DATE
    {
        set
        {
            ACTIVATION_DATE = value;
            DataTransform.DataPlacement("ACTIVATION_DATE", ACTIVATION_DATE, SPDS_STATIONARY_DETAIL_DATASET, DR);
        }
    }
    public string Get_E_DATETIME
    {
        set
        {
            E_DATETIME = value;
            DataTransform.DataPlacement("E_DATETIME", E_DATETIME, SPDS_STATIONARY_DETAIL_DATASET, DR);
        }
    }
    public string Get_E_USERID
    {
        set
        {
            E_USERID = value;
            DataTransform.DataPlacement("E_USERID", E_USERID, SPDS_STATIONARY_DETAIL_DATASET, DR);
        }
    }
    public string Get_END_SERIAL_NO
    {
        set
        {
            END_SERIAL_NO = value;
            DataTransform.DataPlacement("END_SERIAL_NO", END_SERIAL_NO, SPDS_STATIONARY_DETAIL_DATASET, DR);
        }
    }
    public string Get_ID
    {
        set
        {
            ID = value;
            DataTransform.DataPlacement("ID", ID, SPDS_STATIONARY_DETAIL_DATASET, DR);
        }
    }
    public string Get_START_SERIAL_NO
    {
        set
        {
            START_SERIAL_NO = value;
            DataTransform.DataPlacement("START_SERIAL_NO", START_SERIAL_NO, SPDS_STATIONARY_DETAIL_DATASET, DR);
        }
    }
    public string Get_STATIONARY_MASTER_ID
    {
        set
        {
            STATIONARY_MASTER_ID = value;
            DataTransform.DataPlacement("STATIONARY_MASTER_ID", STATIONARY_MASTER_ID, SPDS_STATIONARY_DETAIL_DATASET, DR);
        }
    }

    public string Get_PrintLocationID
    {
        set
        {
            PrintLocationID = value;
            DataTransform.DataPlacement("PrintLocationID", PrintLocationID, SPDS_STATIONARY_DETAIL_DATASET, DR);
        }
    }
    public string Get_PrintAgent
    {
        set
        {
            PrintAgent = value;
            DataTransform.DataPlacement("PrintAgent", PrintAgent, SPDS_STATIONARY_DETAIL_DATASET, DR);
        }
    }
}

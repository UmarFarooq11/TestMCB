using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OracleClient;

public class TABLE_SPDS_STATIONARY_MASTER : ISPDS_STATIONARY_MASTER
{
    private string A_DATETIME;
    private string A_USERID;
    private string PARRID;   
    private string E_DATETIME;
    private string E_USERID;
    private string ID;
    private string LAST_ACTIVATION_DATE; 
    private string SERIAL_DATE;
    private string THRESHOLD;
    DatabaseConnection_Util DataTransform = new DatabaseConnection_Util();

    private DataSet SPDS_STATIONARY_MASTER_DATASET = new DataSet();
    private DataRow DR;

    public TABLE_SPDS_STATIONARY_MASTER()
    {
       // SPDS_STATIONARY_MASTER_DATASET = DataTransform.ReteriveDataMultiple
            //    ("EXEC SP_GET_TABLE_STRUCT SPDS_STATIONARY_MASTER", "NEW_USER_INFO");

        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("P_TABLE_NAME", OracleType.VarChar, ParameterDirection.Input, "SPDS_STATIONARY_MASTER");
        PR[1] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        SPDS_STATIONARY_MASTER_DATASET = DataTransform.Oracle_GetDataSetSP("SP_GET_TABLE_STRUCT", PR);


    }

    public void RecordInputStart()
    { DR = SPDS_STATIONARY_MASTER_DATASET.Tables[0].NewRow(); }

    public void RecordInputCommit()
    { SPDS_STATIONARY_MASTER_DATASET.Tables[0].Rows.Add(DR); }

    public DataSet ReturnResultSet()
    { return SPDS_STATIONARY_MASTER_DATASET; }

    public void ClearTable()
    { SPDS_STATIONARY_MASTER_DATASET.Tables[0].Rows.Clear(); }
    public string Get_A_DATETIME
    {
        set
        {
            A_DATETIME = value;
            DataTransform.DataPlacement("A_DATETIME", A_DATETIME, SPDS_STATIONARY_MASTER_DATASET, DR);
        }
    }
    public string Get_A_USERID
    {
        set
        {
            A_USERID = value;
            DataTransform.DataPlacement("A_USERID", A_USERID, SPDS_STATIONARY_MASTER_DATASET, DR);
        }
    }
    
    
    public string Get_E_DATETIME
    {
        set
        {
            E_DATETIME = value;
            DataTransform.DataPlacement("E_DATETIME", E_DATETIME, SPDS_STATIONARY_MASTER_DATASET, DR);
        }
    }
    public string Get_E_USERID
    {
        set
        {
            E_USERID = value;
            DataTransform.DataPlacement("E_USERID", E_USERID, SPDS_STATIONARY_MASTER_DATASET, DR);
        }
    }
    public string Get_ID
    {
        set
        {
            ID = value;
            DataTransform.DataPlacement("ID", ID, SPDS_STATIONARY_MASTER_DATASET, DR);
        }
    }
    
    public string Get_LAST_ACTIVATION_DATE
    {
        set
        {
            LAST_ACTIVATION_DATE = value;
            DataTransform.DataPlacement("LAST_ACTIVATION_DATE", LAST_ACTIVATION_DATE, SPDS_STATIONARY_MASTER_DATASET, DR);
        }
    }

    public string Get_SERIAL_DATE
    {
        set
        {
            SERIAL_DATE = value;
            DataTransform.DataPlacement("SERIAL_DATE", SERIAL_DATE, SPDS_STATIONARY_MASTER_DATASET, DR);
        }
    }

    public string Get_THRESHOLD
    {
        set
        {
            THRESHOLD = value;
            DataTransform.DataPlacement("THRESHOLD", THRESHOLD, SPDS_STATIONARY_MASTER_DATASET, DR);
        }
    }


    public string Get_PARRID 
    {
        set
        {
            PARRID = value;
            DataTransform.DataPlacement("PARRID", PARRID, SPDS_STATIONARY_MASTER_DATASET, DR);
        }
    }
}
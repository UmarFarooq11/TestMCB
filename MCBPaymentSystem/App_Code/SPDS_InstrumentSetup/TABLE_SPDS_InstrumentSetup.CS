using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OracleClient;

public class TABLE_SPDS_InstrumentSetup : ISPDS_InstrumentSetup
{
    private string A_DateTime;
    private string A_UserID;
    private string E_DateTime;
    private string E_UserID;
    private string ID;
    private string INSTRUMENT_NAME;
    private string RDLC_UPLOAD;
    private string RDLC_UPLOAD_PATH;
    DatabaseConnection_Util DataTransform = new DatabaseConnection_Util();

    private DataSet SPDS_InstrumentSetup_DATASET = new DataSet();
    private DataRow DR;

    public TABLE_SPDS_InstrumentSetup()
    {
      //    SPDS_InstrumentSetup_DATASET = DataTransform.ReteriveDataMultiple
          //      ("EXEC SP_GET_TABLE_STRUCT SPDS_InstrumentSetup", "NEW_USER_INFO");

        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("P_TABLE_NAME", OracleType.VarChar, ParameterDirection.Input, "SPDS_InstrumentSetup");
        PR[1] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        SPDS_InstrumentSetup_DATASET = DataTransform.Oracle_GetDataSetSP("SP_GET_TABLE_STRUCT", PR);

    }

    public void RecordInputStart()
    { DR = SPDS_InstrumentSetup_DATASET.Tables[0].NewRow(); }

    public void RecordInputCommit()
    { SPDS_InstrumentSetup_DATASET.Tables[0].Rows.Add(DR); }

    public DataSet ReturnResultSet()
    { return SPDS_InstrumentSetup_DATASET; }

    public void ClearTable()
    { SPDS_InstrumentSetup_DATASET.Tables[0].Rows.Clear(); }
    public string Get_A_DateTime
    {
        set
        {
            A_DateTime = value;
            DataTransform.DataPlacement("A_DateTime", A_DateTime, SPDS_InstrumentSetup_DATASET, DR);
        }
    }
    public string Get_A_UserID
    {
        set
        {
            A_UserID = value;
            DataTransform.DataPlacement("A_UserID", A_UserID, SPDS_InstrumentSetup_DATASET, DR);
        }
    }
    public string Get_E_DateTime
    {
        set
        {
            E_DateTime = value;
            DataTransform.DataPlacement("E_DateTime", E_DateTime, SPDS_InstrumentSetup_DATASET, DR);
        }
    }
    public string Get_E_UserID
    {
        set
        {
            E_UserID = value;
            DataTransform.DataPlacement("E_UserID", E_UserID, SPDS_InstrumentSetup_DATASET, DR);
        }
    }
    public string Get_ID
    {
        set
        {
            ID = value;
            DataTransform.DataPlacement("ID", ID, SPDS_InstrumentSetup_DATASET, DR);
        }
    }
    public string Get_INSTRUMENT_NAME
    {
        set
        {
            INSTRUMENT_NAME = value;
            DataTransform.DataPlacement("INSTRUMENT_NAME", INSTRUMENT_NAME, SPDS_InstrumentSetup_DATASET, DR);
        }
    }
    public string Get_RDLC_UPLOAD
    {
        set
        {
            RDLC_UPLOAD = value;
            DataTransform.DataPlacement("RDLC_UPLOAD", RDLC_UPLOAD, SPDS_InstrumentSetup_DATASET, DR);
        }
    }
    public string Get_RDLC_UPLOAD_PATH
    {
        set
        {
            RDLC_UPLOAD_PATH = value;
            DataTransform.DataPlacement("RDLC_UPLOAD_PATH", RDLC_UPLOAD_PATH, SPDS_InstrumentSetup_DATASET, DR);
        }
    }
}

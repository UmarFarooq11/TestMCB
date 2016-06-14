using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OracleClient;

public class TABLE_SPDS_SignatorySetup : ISPDS_SignatorySetup
{
    private string A_DateTime;
    private string A_userID;
    private string CURRENT_STATUS;
    private string E_DateTime;
    private string E_UserID;
    private string ID;
    private string SIGNATORY_NAME;
    private string UPLOAD_IMAGE_PATH;
    private string UPLOAD_IMAGE;

    DatabaseConnection_Util DataTransform = new DatabaseConnection_Util();

    private DataSet SPDS_SignatorySetup_DATASET = new DataSet();
    private DataRow DR;

    public TABLE_SPDS_SignatorySetup()
    {
        //SPDS_SignatorySetup_DATASET = DataTransform.ReteriveDataMultiple
        //        ("EXEC SP_GET_TABLE_STRUCT 'SPDS_SignatorySetup'", "NEW_USER_INFO");

        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("P_TABLE_NAME", OracleType.VarChar, ParameterDirection.Input, "SPDS_SignatorySetup");
        PR[1] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        SPDS_SignatorySetup_DATASET = DataTransform.Oracle_GetDataSetSP("SP_GET_TABLE_STRUCT", PR);


    }

    public void RecordInputStart()
    { DR = SPDS_SignatorySetup_DATASET.Tables[0].NewRow(); }

    public void RecordInputCommit()
    { SPDS_SignatorySetup_DATASET.Tables[0].Rows.Add(DR); }

    public DataSet ReturnResultSet()
    { return SPDS_SignatorySetup_DATASET; }

    public void ClearTable()
    { SPDS_SignatorySetup_DATASET.Tables[0].Rows.Clear(); }
    public string Get_A_DateTime
    {
        set
        {
            A_DateTime = value;
            DataTransform.DataPlacement("A_DateTime", A_DateTime, SPDS_SignatorySetup_DATASET, DR);
        }
    }
    public string Get_A_userID
    {
        set
        {
            A_userID = value;
            DataTransform.DataPlacement("A_userID", A_userID, SPDS_SignatorySetup_DATASET, DR);
        }
    }
    public string Get_CURRENT_STATUS
    {
        set
        {
            CURRENT_STATUS = value;
            DataTransform.DataPlacement("CURRENT_STATUS", CURRENT_STATUS, SPDS_SignatorySetup_DATASET, DR);
        }
    }
    public string Get_E_DateTime
    {
        set
        {
            E_DateTime = value;
            DataTransform.DataPlacement("E_DateTime", E_DateTime, SPDS_SignatorySetup_DATASET, DR);
        }
    }
    public string Get_E_UserID
    {
        set
        {
            E_UserID = value;
            DataTransform.DataPlacement("E_UserID", E_UserID, SPDS_SignatorySetup_DATASET, DR);
        }
    }
    public string Get_ID
    {
        set
        {
            ID = value;
            DataTransform.DataPlacement("ID", ID, SPDS_SignatorySetup_DATASET, DR);
        }
    }
    public string Get_SIGNATORY_NAME
    {
        set
        {
            SIGNATORY_NAME = value;
            DataTransform.DataPlacement("SIGNATORY_NAME", SIGNATORY_NAME, SPDS_SignatorySetup_DATASET, DR);
        }
    }

    public string Get_UPLOAD_IMAGE_PATH
    {
        set
        {
            UPLOAD_IMAGE_PATH = value;
            DataTransform.DataPlacement("UPLOAD_IMAGE_PATH", UPLOAD_IMAGE_PATH, SPDS_SignatorySetup_DATASET, DR);
        }
    }
    public string Get_UPLOAD_IMAGE
    {
        set
        {
            UPLOAD_IMAGE = value;
            DataTransform.DataPlacement("UPLOAD_IMAGE", UPLOAD_IMAGE, SPDS_SignatorySetup_DATASET, DR);
        }
    }
}

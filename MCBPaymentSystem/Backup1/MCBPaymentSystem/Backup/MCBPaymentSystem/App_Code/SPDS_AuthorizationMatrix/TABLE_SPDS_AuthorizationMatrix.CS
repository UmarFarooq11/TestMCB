using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OracleClient;

public class TABLE_SPDS_AuthorizationMatrix : ISPDS_AuthorizationMatrix
{
    private string A_DateTime;
    private string A_UserID;
    private string CATEGORY_ID;
    private string CHECKER_SIGNATORY_ID;
    private string CUSTOMER_ID;
    private string E_DateTime;
    private string E_UserID;
    private string ID;
    private string INSTRUMENT_ID;
    private string MAKE_SIGNATORY_ID;
    DatabaseConnection_Util DataTransform = new DatabaseConnection_Util();

    private DataSet SPDS_AuthorizationMatrix_DATASET = new DataSet();
    private DataRow DR;

    public TABLE_SPDS_AuthorizationMatrix()
    {
        //SPDS_AuthorizationMatrix_DATASET = DataTransform.ReteriveDataMultiple
        //        ("EXEC SP_GET_TABLE_STRUCT SPDS_AuthorizationMatrix", "NEW_USER_INFO");

        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("P_TABLE_NAME", OracleType.VarChar, ParameterDirection.Input, "SPDS_AuthorizationMatrix");
        PR[1] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        SPDS_AuthorizationMatrix_DATASET = DataTransform.Oracle_GetDataSetSP("SP_GET_TABLE_STRUCT", PR);



    }

    public void RecordInputStart()
    { DR = SPDS_AuthorizationMatrix_DATASET.Tables[0].NewRow(); }

    public void RecordInputCommit()
    { SPDS_AuthorizationMatrix_DATASET.Tables[0].Rows.Add(DR); }

    public DataSet ReturnResultSet()
    { return SPDS_AuthorizationMatrix_DATASET; }

    public void ClearTable()
    { SPDS_AuthorizationMatrix_DATASET.Tables[0].Rows.Clear(); }
    public string Get_A_DateTime
    {
        set
        {
            A_DateTime = value;
            DataTransform.DataPlacement("A_DateTime", A_DateTime, SPDS_AuthorizationMatrix_DATASET, DR);
        }
    }
    public string Get_A_UserID
    {
        set
        {
            A_UserID = value;
            DataTransform.DataPlacement("A_UserID", A_UserID, SPDS_AuthorizationMatrix_DATASET, DR);
        }
    }
    public string Get_CATEGORY_ID
    {
        set
        {
            CATEGORY_ID = value;
            DataTransform.DataPlacement("CATEGORY_ID", CATEGORY_ID, SPDS_AuthorizationMatrix_DATASET, DR);
        }
    }
    public string Get_CHECKER_SIGNATORY_ID
    {
        set
        {
            CHECKER_SIGNATORY_ID = value;
            DataTransform.DataPlacement("CHECKER_SIGNATORY_ID", CHECKER_SIGNATORY_ID, SPDS_AuthorizationMatrix_DATASET, DR);
        }
    }
    public string Get_CUSTOMER_ID
    {
        set
        {
            CUSTOMER_ID = value;
            DataTransform.DataPlacement("CUSTOMER_ID", CUSTOMER_ID, SPDS_AuthorizationMatrix_DATASET, DR);
        }
    }
    public string Get_E_DateTime
    {
        set
        {
            E_DateTime = value;
            DataTransform.DataPlacement("E_DateTime", E_DateTime, SPDS_AuthorizationMatrix_DATASET, DR);
        }
    }
    public string Get_E_UserID
    {
        set
        {
            E_UserID = value;
            DataTransform.DataPlacement("E_UserID", E_UserID, SPDS_AuthorizationMatrix_DATASET, DR);
        }
    }
    public string Get_ID
    {
        set
        {
            ID = value;
            DataTransform.DataPlacement("ID", ID, SPDS_AuthorizationMatrix_DATASET, DR);
        }
    }
    public string Get_INSTRUMENT_ID
    {
        set
        {
            INSTRUMENT_ID = value;
            DataTransform.DataPlacement("INSTRUMENT_ID", INSTRUMENT_ID, SPDS_AuthorizationMatrix_DATASET, DR);
        }
    }
    public string Get_MAKE_SIGNATORY_ID
    {
        set
        {
            MAKE_SIGNATORY_ID = value;
            DataTransform.DataPlacement("MAKE_SIGNATORY_ID", MAKE_SIGNATORY_ID, SPDS_AuthorizationMatrix_DATASET, DR);
        }
    }
}

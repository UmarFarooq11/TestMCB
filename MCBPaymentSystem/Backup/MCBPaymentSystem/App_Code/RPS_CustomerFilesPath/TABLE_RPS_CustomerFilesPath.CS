using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OracleClient;

public class TABLE_RPS_CustomerFilesPath : IRPS_CustomerFilesPath
{
    private string A_DateTime;
    private string A_UserId;
    private string CustomerId;
    private string E_DateTime;
    private string E_UserId;
    private string ID;
    private string ReceiveFilePath1;
    private string SendFilePath;
    DatabaseConnection_Util DataTransform = new DatabaseConnection_Util();

    private DataSet RPS_CustomerFilesPath_DATASET = new DataSet();
    private DataRow DR;

    public TABLE_RPS_CustomerFilesPath()
    {
      //  RPS_CustomerFilesPath_DATASET = DataTransform.ReteriveDataMultiple
     
           // ("EXEC SP_GET_TABLE_STRUCT RPS_CustomerFilesPath", "NEW_USER_INFO");





        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("P_TABLE_NAME", OracleType.VarChar, ParameterDirection.Input, "RPS_CustomerFilesPath");
        PR[1] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        RPS_CustomerFilesPath_DATASET = DataTransform.Oracle_GetDataSetSP("SP_GET_TABLE_STRUCT", PR);


    }

    public void RecordInputStart()
    { DR = RPS_CustomerFilesPath_DATASET.Tables[0].NewRow(); }

    public void RecordInputCommit()
    { RPS_CustomerFilesPath_DATASET.Tables[0].Rows.Add(DR); }

    public DataSet ReturnResultSet()
    { return RPS_CustomerFilesPath_DATASET; }

    public void ClearTable()
    { RPS_CustomerFilesPath_DATASET.Tables[0].Rows.Clear(); }
    public string Get_A_DateTime
    {
        set
        {
            A_DateTime = value;
            DataTransform.DataPlacement("A_DateTime", A_DateTime, RPS_CustomerFilesPath_DATASET, DR);
        }
    }
    public string Get_A_UserId
    {
        set
        {
            A_UserId = value;
            DataTransform.DataPlacement("A_UserId", A_UserId, RPS_CustomerFilesPath_DATASET, DR);
        }
    }
    public string Get_CustomerId
    {
        set
        {
            CustomerId = value;
            DataTransform.DataPlacement("CustomerId", CustomerId, RPS_CustomerFilesPath_DATASET, DR);
        }
    }
    public string Get_E_DateTime
    {
        set
        {
            E_DateTime = value;
            DataTransform.DataPlacement("E_DateTime", E_DateTime, RPS_CustomerFilesPath_DATASET, DR);
        }
    }
    public string Get_E_UserId
    {
        set
        {
            E_UserId = value;
            DataTransform.DataPlacement("E_UserId", E_UserId, RPS_CustomerFilesPath_DATASET, DR);
        }
    }
    public string Get_ID
    {
        set
        {
            ID = value;
            DataTransform.DataPlacement("ID", ID, RPS_CustomerFilesPath_DATASET, DR);
        }
    }
    public string Get_ReceiveFilePath1
    {
        set
        {
            ReceiveFilePath1 = value;
            DataTransform.DataPlacement("ReceiveFilePath1", ReceiveFilePath1, RPS_CustomerFilesPath_DATASET, DR);
        }
    }
    public string Get_SendFilePath
    {
        set
        {
            SendFilePath = value;
            DataTransform.DataPlacement("SendFilePath", SendFilePath, RPS_CustomerFilesPath_DATASET, DR);
        }
    }
}

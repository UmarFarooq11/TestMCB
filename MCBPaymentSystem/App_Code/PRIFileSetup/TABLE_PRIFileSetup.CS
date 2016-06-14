using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OracleClient;

public class TABLE_PRIFileSetup : IPRIFileSetup
{
    private string FileDownload;
    private string FileUpload;
    private string ID;
    DatabaseConnection_Util DataTransform = new DatabaseConnection_Util();

    private DataSet PRIFileSetup_DATASET = new DataSet();
    private DataRow DR;

    public TABLE_PRIFileSetup()
    {
        //PRIFileSetup_DATASET = DataTransform.ReteriveDataMultiple
             //   ("EXEC SP_GET_TABLE_STRUCT PRIFileSetup", "NEW_USER_INFO");

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("P_TABLE_NAME", OracleType.VarChar, ParameterDirection.Input, "PRIFileSetup");
        PR[1] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        PRIFileSetup_DATASET = DataTransform.Oracle_GetDataSetSP("SP_GET_TABLE_STRUCT", PR);






    }

    public void RecordInputStart()
    { DR = PRIFileSetup_DATASET.Tables[0].NewRow(); }

    public void RecordInputCommit()
    { PRIFileSetup_DATASET.Tables[0].Rows.Add(DR); }

    public DataSet ReturnResultSet()
    { return PRIFileSetup_DATASET; }

    public void ClearTable()
    { PRIFileSetup_DATASET.Tables[0].Rows.Clear(); }
    public string Get_FileDownload
    {
        set
        {
            FileDownload = value;
            DataTransform.DataPlacement("FileDownload", FileDownload, PRIFileSetup_DATASET, DR);
        }
    }
    public string Get_FileUpload
    {
        set
        {
            FileUpload = value;
            DataTransform.DataPlacement("FileUpload", FileUpload, PRIFileSetup_DATASET, DR);
        }
    }
    public string Get_ID
    {
        set
        {
            ID = value;
            DataTransform.DataPlacement("ID", ID, PRIFileSetup_DATASET, DR);
        }
    }
}
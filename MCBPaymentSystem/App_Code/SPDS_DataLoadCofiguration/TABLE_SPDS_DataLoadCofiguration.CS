using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OracleClient;

public class TABLE_SPDS_DataLoadCofiguration : ISPDS_DataLoadCofiguration
{
    #region //Variables
    private string ConfigurationDefinationID;
    private string ConfigurationDefinationDesc;
    private string FileFormat;
    private string ConfigurationID;
    private string fileSeparate;
    private string recordskip;
    

    /*private string A_DateTime;
    private string A_userID;
    private string ArchivePath;
    private string Channel;
    private string E_DateTime;
    private string E_UserID;
    private string FilePath;
    private string ID;
    private string ObjectName;
    private string ObjectType;
    private string SourceID;*/
    #endregion
        
    DatabaseConnection_Util DataTransform = new DatabaseConnection_Util();
    private DataSet SPDS_DataLoadCofiguration_DATASET = new DataSet();
    private DataRow DR;
    public TABLE_SPDS_DataLoadCofiguration()
    {
        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("P_TABLE_NAME", OracleType.VarChar, ParameterDirection.Input, "CONFIG_DEF_MASTER");
        PR[1] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        SPDS_DataLoadCofiguration_DATASET = DataTransform.Oracle_GetDataSetSP("SP_GET_TABLE_STRUCT", PR);
    }
    #region //Methods
    public void RecordInputStart()
    { DR = SPDS_DataLoadCofiguration_DATASET.Tables[0].NewRow(); }

    public void RecordInputCommit()
    { SPDS_DataLoadCofiguration_DATASET.Tables[0].Rows.Add(DR); }

    public DataSet ReturnResultSet()
    { return SPDS_DataLoadCofiguration_DATASET; }

    public void ClearTable()
    { SPDS_DataLoadCofiguration_DATASET.Tables[0].Rows.Clear(); }

    #endregion


    #region //Properties

    public string Get_ConfigurationDefinationID
    {
        set
        {
            ConfigurationDefinationID = value;
            DataTransform.DataPlacement("CONF_DEF_ID", ConfigurationDefinationID, SPDS_DataLoadCofiguration_DATASET, DR);
        }
    }

    public string Get_ConfigurationDefinationDesc
    {
        set
        {
            ConfigurationDefinationDesc = value;
            DataTransform.DataPlacement("CONF_DEF_DESC", ConfigurationDefinationDesc, SPDS_DataLoadCofiguration_DATASET, DR);
        }
    }
    public string Get_FileFormat
    {
        set
        {
            FileFormat = value;
            DataTransform.DataPlacement("FILE_FORMAT", FileFormat, SPDS_DataLoadCofiguration_DATASET, DR);
        }
    }
    public string Get_ConfigurationID
    {
        set
        {
            ConfigurationID = value;
            DataTransform.DataPlacement("CONF_ID", ConfigurationID, SPDS_DataLoadCofiguration_DATASET, DR);
        }
    }
    public string Get_FileSeparate
    {
        set
        {
            fileSeparate = value;
            DataTransform.DataPlacement("fileSeparate", fileSeparate, SPDS_DataLoadCofiguration_DATASET, DR);
        }
    }
    public string Get_RecordsSkip
    {
        set
        {
            recordskip = value;
            DataTransform.DataPlacement("record_skip", recordskip, SPDS_DataLoadCofiguration_DATASET, DR);
        }
    }
   


    /*
    public string Get_ConfigurationName
    {
        set
        {
            ConfigurationName = value;
            DataTransform.DataPlacement("ConfigurationName", ConfigurationName, SPDS_DataLoadCofiguration_DATASET, DR);
        }
    }
    public string Get_A_DateTime
    {
        set
        {
            A_DateTime = value;
            DataTransform.DataPlacement("A_DateTime", A_DateTime, SPDS_DataLoadCofiguration_DATASET, DR);
        }
    }
    public string Get_A_userID
    {
        set
        {
            A_userID = value;
            DataTransform.DataPlacement("A_userID", A_userID, SPDS_DataLoadCofiguration_DATASET, DR);
        }
    }
    public string Get_ArchivePath
    {
        set
        {
            ArchivePath = value;
            DataTransform.DataPlacement("ArchivePath", ArchivePath, SPDS_DataLoadCofiguration_DATASET, DR);
        }
    }
    public string Get_Channel
    {
        set
        {
            Channel = value;
            DataTransform.DataPlacement("Channel", Channel, SPDS_DataLoadCofiguration_DATASET, DR);
        }
    }
    
    public string Get_E_DateTime
    {
        set
        {
            E_DateTime = value;
            DataTransform.DataPlacement("E_DateTime", E_DateTime, SPDS_DataLoadCofiguration_DATASET, DR);
        }
    }
    public string Get_E_UserID
    {
        set
        {
            E_UserID = value;
            DataTransform.DataPlacement("E_UserID", E_UserID, SPDS_DataLoadCofiguration_DATASET, DR);
        }
    }
    
    public string Get_FilePath
    {
        set
        {
            FilePath = value;
            DataTransform.DataPlacement("FilePath", FilePath, SPDS_DataLoadCofiguration_DATASET, DR);
        }
    }
    public string Get_ID
    {
        set
        {
            ID = value;
            DataTransform.DataPlacement("ID", ID, SPDS_DataLoadCofiguration_DATASET, DR);
        }
    }
    public string Get_ObjectName
    {
        set
        {
            ObjectName = value;
            DataTransform.DataPlacement("ObjectName", ObjectName, SPDS_DataLoadCofiguration_DATASET, DR);
        }
    }
    public string Get_ObjectType
    {
        set
        {
            ObjectType = value;
            DataTransform.DataPlacement("ObjectType", ObjectType, SPDS_DataLoadCofiguration_DATASET, DR);
        }
    }
    public string Get_SourceID
    {
        set
        {
            SourceID = value;
            DataTransform.DataPlacement("SourceID", SourceID, SPDS_DataLoadCofiguration_DATASET, DR);
        }
    }*/
    #endregion
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OracleClient;

    public class TABLE_SPDS_UniversalUploadCofiguration : ISPDS_UniversalUploadCofiguration
    {
private string A_DateTime;
private string A_userID;
private string ArchivePath;
private string Channel;
private string ConfigurationName;
private string E_DateTime;
private string E_UserID;
private string FileFormat;
private string FilePath;
private string ID;
private string ObjectName;
private string ObjectType;
private string SourceID;
       DatabaseConnection_Util DataTransform = new DatabaseConnection_Util();

        private DataSet SPDS_UniversalUploadCofiguration_DATASET = new DataSet();
        private DataRow DR;

        public TABLE_SPDS_UniversalUploadCofiguration()
        {
          //SPDS_UniversalUploadCofiguration_DATASET = DataTransform.ReteriveDataMultiple
                //  ("EXEC SP_GET_TABLE_STRUCT SPDS_UniversalUploadCofiguration","NEW_USER_INFO");

          OracleParameter[] PR = new OracleParameter[2];
          PR[0] = DataTransform.Oracle_Param("P_TABLE_NAME", OracleType.VarChar, ParameterDirection.Input, "SPDS_UNIVUploadCofiguration");
          PR[1] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
          SPDS_UniversalUploadCofiguration_DATASET = DataTransform.Oracle_GetDataSetSP("SP_GET_TABLE_STRUCT", PR);

        }

        public void RecordInputStart()
        {DR = SPDS_UniversalUploadCofiguration_DATASET.Tables[0].NewRow();}

        public void RecordInputCommit()
        { SPDS_UniversalUploadCofiguration_DATASET.Tables[0].Rows.Add(DR); }

        public DataSet ReturnResultSet()
        { return SPDS_UniversalUploadCofiguration_DATASET; }

        public void ClearTable()
        { SPDS_UniversalUploadCofiguration_DATASET.Tables[0].Rows.Clear(); }
public string Get_A_DateTime
{
        set
            {
A_DateTime= value;
DataTransform.DataPlacement("A_DateTime",A_DateTime,SPDS_UniversalUploadCofiguration_DATASET, DR);
            }
        }
public string Get_A_userID
{
        set
            {
A_userID= value;
DataTransform.DataPlacement("A_userID",A_userID,SPDS_UniversalUploadCofiguration_DATASET, DR);
            }
        }
public string Get_ArchivePath
{
        set
            {
ArchivePath= value;
DataTransform.DataPlacement("ArchivePath",ArchivePath,SPDS_UniversalUploadCofiguration_DATASET, DR);
            }
        }
public string Get_Channel
{
        set
            {
Channel= value;
DataTransform.DataPlacement("Channel",Channel,SPDS_UniversalUploadCofiguration_DATASET, DR);
            }
        }
public string Get_ConfigurationName
{
        set
            {
ConfigurationName= value;
DataTransform.DataPlacement("ConfigurationName",ConfigurationName,SPDS_UniversalUploadCofiguration_DATASET, DR);
            }
        }
public string Get_E_DateTime
{
        set
            {
E_DateTime= value;
DataTransform.DataPlacement("E_DateTime",E_DateTime,SPDS_UniversalUploadCofiguration_DATASET, DR);
            }
        }
public string Get_E_UserID
{
        set
            {
E_UserID= value;
DataTransform.DataPlacement("E_UserID",E_UserID,SPDS_UniversalUploadCofiguration_DATASET, DR);
            }
        }
public string Get_FileFormat
{
        set
            {
FileFormat= value;
DataTransform.DataPlacement("FileFormat",FileFormat,SPDS_UniversalUploadCofiguration_DATASET, DR);
            }
        }
public string Get_FilePath
{
        set
            {
FilePath= value;
DataTransform.DataPlacement("FilePath",FilePath,SPDS_UniversalUploadCofiguration_DATASET, DR);
            }
        }
public string Get_ID
{
        set
            {
ID= value;
DataTransform.DataPlacement("ID",ID,SPDS_UniversalUploadCofiguration_DATASET, DR);
            }
        }
public string Get_ObjectName
{
        set
            {
ObjectName= value;
DataTransform.DataPlacement("ObjectName",ObjectName,SPDS_UniversalUploadCofiguration_DATASET, DR);
            }
        }
public string Get_ObjectType
{
        set
            {
ObjectType= value;
DataTransform.DataPlacement("ObjectType",ObjectType,SPDS_UniversalUploadCofiguration_DATASET, DR);
            }
        }
public string Get_SourceID
{
        set
            {
SourceID= value;
DataTransform.DataPlacement("SourceID",SourceID,SPDS_UniversalUploadCofiguration_DATASET, DR);
            }
        }
    }

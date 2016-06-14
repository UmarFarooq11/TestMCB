using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OracleClient;

    public class TABLE_RPS_DefaultMessages : IRPS_DefaultMessages
    {
private string A_DateTime;
private string A_UserID;
private string DefaultMessageCode;
private string Description;
private string E_DateTime;
private string E_UserID;
private string ID;
       DatabaseConnection_Util DataTransform = new DatabaseConnection_Util();

        private DataSet RPS_DefaultMessages_DATASET = new DataSet();
        private DataRow DR;

        public TABLE_RPS_DefaultMessages()
        {
         // RPS_DefaultMessages_DATASET = DataTransform.ReteriveDataMultiple
               //   ("EXEC SP_GET_TABLE_STRUCT RPS_DefaultMessages","NEW_USER_INFO");



          DataSet DS = new DataSet();
          OracleParameter[] PR = new OracleParameter[2];
          PR[0] = DataTransform.Oracle_Param("P_TABLE_NAME", OracleType.VarChar, ParameterDirection.Input, "RPS_DefaultMessages");
          PR[1] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
          RPS_DefaultMessages_DATASET = DataTransform.Oracle_GetDataSetSP("SP_GET_TABLE_STRUCT", PR);



        }

        public void RecordInputStart()
        {DR = RPS_DefaultMessages_DATASET.Tables[0].NewRow();}

        public void RecordInputCommit()
        { RPS_DefaultMessages_DATASET.Tables[0].Rows.Add(DR); }

        public DataSet ReturnResultSet()
        { return RPS_DefaultMessages_DATASET; }

        public void ClearTable()
        { RPS_DefaultMessages_DATASET.Tables[0].Rows.Clear(); }
public string Get_A_DateTime
{
        set
            {
A_DateTime= value;
DataTransform.DataPlacement("A_DateTime",A_DateTime,RPS_DefaultMessages_DATASET, DR);
            }
        }
public string Get_A_UserID
{
        set
            {
A_UserID= value;
DataTransform.DataPlacement("A_UserID",A_UserID,RPS_DefaultMessages_DATASET, DR);
            }
        }
public string Get_DefaultMessageCode
{
        set
            {
DefaultMessageCode= value;
DataTransform.DataPlacement("DefaultMessageCode",DefaultMessageCode,RPS_DefaultMessages_DATASET, DR);
            }
        }
public string Get_Description
{
        set
            {
Description= value;
DataTransform.DataPlacement("Description",Description,RPS_DefaultMessages_DATASET, DR);
            }
        }
public string Get_E_DateTime
{
        set
            {
E_DateTime= value;
DataTransform.DataPlacement("E_DateTime",E_DateTime,RPS_DefaultMessages_DATASET, DR);
            }
        }
public string Get_E_UserID
{
        set
            {
E_UserID= value;
DataTransform.DataPlacement("E_UserID",E_UserID,RPS_DefaultMessages_DATASET, DR);
            }
        }
public string Get_ID
{
        set
            {
ID= value;
DataTransform.DataPlacement("ID",ID,RPS_DefaultMessages_DATASET, DR);
            }
        }
    }

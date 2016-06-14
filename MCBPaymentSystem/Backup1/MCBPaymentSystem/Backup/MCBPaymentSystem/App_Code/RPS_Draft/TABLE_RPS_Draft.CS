using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OracleClient;

    public class TABLE_RPS_Draft : IRPS_Draft
    {
private string A_DateTime;
private string A_UserID;
private string BeneficiaryID;
private string BranchID;
private string CorrespondingBankID;
private string CoverAmountUSD;
private string CurrencyID;
private string DeliveryDate;
private string DraftAmount;
private string DraftAssignmentBatchID;
private string DraftDate;
private string DraftNo;
private string DraftTypeID;
private string E_DateTime;
private string E_UserID;
private string ExciseDuty;
private string HoldReason;
private string ID;
private string LanguageID;
private string LiquidationDate;
private string PrincipleBankID;
private string Rate;
private string RemittanceID;
private string RemitterID;
private string RemitterMessage;
private string RequestDate;
private string StatusID;
private string StatusSwitch;
private string TransactionAmount;
private string UpdateDate;
       DatabaseConnection_Util DataTransform = new DatabaseConnection_Util();

        private DataSet RPS_Draft_DATASET = new DataSet();
        private DataRow DR;

        public TABLE_RPS_Draft()
        {
         // RPS_Draft_DATASET = DataTransform.ReteriveDataMultiple
                 // ("EXEC SP_GET_TABLE_STRUCT RPS_Draft","NEW_USER_INFO");

          DataSet DS = new DataSet();
          OracleParameter[] PR = new OracleParameter[2];
          PR[0] = DataTransform.Oracle_Param("P_TABLE_NAME", OracleType.VarChar, ParameterDirection.Input, "RPS_Draft");
          PR[1] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
          RPS_Draft_DATASET = DataTransform.Oracle_GetDataSetSP("SP_GET_TABLE_STRUCT", PR);


        }

        public void RecordInputStart()
        {DR = RPS_Draft_DATASET.Tables[0].NewRow();}

        public void RecordInputCommit()
        { RPS_Draft_DATASET.Tables[0].Rows.Add(DR); }

        public DataSet ReturnResultSet()
        { return RPS_Draft_DATASET; }

        public void ClearTable()
        { RPS_Draft_DATASET.Tables[0].Rows.Clear(); }
public string Get_A_DateTime
{
        set
            {
A_DateTime= value;
DataTransform.DataPlacement("A_DateTime",A_DateTime,RPS_Draft_DATASET, DR);
            }
        }
public string Get_A_UserID
{
        set
            {
A_UserID= value;
DataTransform.DataPlacement("A_UserID",A_UserID,RPS_Draft_DATASET, DR);
            }
        }
public string Get_BeneficiaryID
{
        set
            {
BeneficiaryID= value;
DataTransform.DataPlacement("BeneficiaryID",BeneficiaryID,RPS_Draft_DATASET, DR);
            }
        }
public string Get_BranchID
{
        set
            {
BranchID= value;
DataTransform.DataPlacement("BranchID",BranchID,RPS_Draft_DATASET, DR);
            }
        }
public string Get_CorrespondingBankID
{
        set
            {
CorrespondingBankID= value;
DataTransform.DataPlacement("CorrespondingBankID",CorrespondingBankID,RPS_Draft_DATASET, DR);
            }
        }
public string Get_CoverAmountUSD
{
        set
            {
CoverAmountUSD= value;
DataTransform.DataPlacement("CoverAmountUSD",CoverAmountUSD,RPS_Draft_DATASET, DR);
            }
        }
public string Get_CurrencyID
{
        set
            {
CurrencyID= value;
DataTransform.DataPlacement("CurrencyID",CurrencyID,RPS_Draft_DATASET, DR);
            }
        }
public string Get_DeliveryDate
{
        set
            {
DeliveryDate= value;
DataTransform.DataPlacement("DeliveryDate",DeliveryDate,RPS_Draft_DATASET, DR);
            }
        }
public string Get_DraftAmount
{
        set
            {
DraftAmount= value;
DataTransform.DataPlacement("DraftAmount",DraftAmount,RPS_Draft_DATASET, DR);
            }
        }
public string Get_DraftAssignmentBatchID
{
        set
            {
DraftAssignmentBatchID= value;
DataTransform.DataPlacement("DraftAssignmentBatchID",DraftAssignmentBatchID,RPS_Draft_DATASET, DR);
            }
        }
public string Get_DraftDate
{
        set
            {
DraftDate= value;
DataTransform.DataPlacement("DraftDate",DraftDate,RPS_Draft_DATASET, DR);
            }
        }
public string Get_DraftNo
{
        set
            {
DraftNo= value;
DataTransform.DataPlacement("DraftNo",DraftNo,RPS_Draft_DATASET, DR);
            }
        }
public string Get_DraftTypeID
{
        set
            {
DraftTypeID= value;
DataTransform.DataPlacement("DraftTypeID",DraftTypeID,RPS_Draft_DATASET, DR);
            }
        }
public string Get_E_DateTime
{
        set
            {
E_DateTime= value;
DataTransform.DataPlacement("E_DateTime",E_DateTime,RPS_Draft_DATASET, DR);
            }
        }
public string Get_E_UserID
{
        set
            {
E_UserID= value;
DataTransform.DataPlacement("E_UserID",E_UserID,RPS_Draft_DATASET, DR);
            }
        }
public string Get_ExciseDuty
{
        set
            {
ExciseDuty= value;
DataTransform.DataPlacement("ExciseDuty",ExciseDuty,RPS_Draft_DATASET, DR);
            }
        }
public string Get_HoldReason
{
        set
            {
HoldReason= value;
DataTransform.DataPlacement("HoldReason",HoldReason,RPS_Draft_DATASET, DR);
            }
        }
public string Get_ID
{
        set
            {
ID= value;
DataTransform.DataPlacement("ID",ID,RPS_Draft_DATASET, DR);
            }
        }
public string Get_LanguageID
{
        set
            {
LanguageID= value;
DataTransform.DataPlacement("LanguageID",LanguageID,RPS_Draft_DATASET, DR);
            }
        }
public string Get_LiquidationDate
{
        set
            {
LiquidationDate= value;
DataTransform.DataPlacement("LiquidationDate",LiquidationDate,RPS_Draft_DATASET, DR);
            }
        }
public string Get_PrincipleBankID
{
        set
            {
PrincipleBankID= value;
DataTransform.DataPlacement("PrincipleBankID",PrincipleBankID,RPS_Draft_DATASET, DR);
            }
        }
public string Get_Rate
{
        set
            {
Rate= value;
DataTransform.DataPlacement("Rate",Rate,RPS_Draft_DATASET, DR);
            }
        }
public string Get_RemittanceID
{
        set
            {
RemittanceID= value;
DataTransform.DataPlacement("RemittanceID",RemittanceID,RPS_Draft_DATASET, DR);
            }
        }
public string Get_RemitterID
{
        set
            {
RemitterID= value;
DataTransform.DataPlacement("RemitterID",RemitterID,RPS_Draft_DATASET, DR);
            }
        }
public string Get_RemitterMessage
{
        set
            {
RemitterMessage= value;
DataTransform.DataPlacement("RemitterMessage",RemitterMessage,RPS_Draft_DATASET, DR);
            }
        }
public string Get_RequestDate
{
        set
            {
RequestDate= value;
DataTransform.DataPlacement("RequestDate",RequestDate,RPS_Draft_DATASET, DR);
            }
        }
public string Get_StatusID
{
        set
            {
StatusID= value;
DataTransform.DataPlacement("StatusID",StatusID,RPS_Draft_DATASET, DR);
            }
        }
public string Get_StatusSwitch
{
        set
            {
StatusSwitch= value;
DataTransform.DataPlacement("StatusSwitch",StatusSwitch,RPS_Draft_DATASET, DR);
            }
        }
public string Get_TransactionAmount
{
        set
            {
TransactionAmount= value;
DataTransform.DataPlacement("TransactionAmount",TransactionAmount,RPS_Draft_DATASET, DR);
            }
        }
public string Get_UpdateDate
{
        set
            {
UpdateDate= value;
DataTransform.DataPlacement("UpdateDate",UpdateDate,RPS_Draft_DATASET, DR);
            }
        }
    }

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.OracleClient;


public class TABLE_CMN_CUST_BAL : ICMN_CUST_BAL
{
    private string bankCode;
    private string rateDate;
    private string balAmount;
    private string RefNo;

    private string AUserID;
    private string ADateTime;
    private string EUserID;
    private string EDateTime;

    DatabaseConnection_Util DataTransform = new DatabaseConnection_Util();

    private DataSet dsResult = new DataSet();
    private DataRow dr;

    public TABLE_CMN_CUST_BAL()
    {
        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("P_TABLE_NAME", OracleType.VarChar, ParameterDirection.Input, "RPS_CUSTOMER_BALANCE");
        PR[1] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        dsResult = DataTransform.Oracle_GetDataSetSP("SP_GET_TABLE_STRUCT", PR);
    }

    public void RecordInputStart()
    { dr = dsResult.Tables[0].NewRow(); }

    public void RecordInputCommit()
    { dsResult.Tables[0].Rows.Add(dr); }

    public DataSet ReturnResultSet()
    { return dsResult; }

    public void ClearTable()
    { dsResult.Tables[0].Rows.Clear(); }

    public string setBankCode
    {
        set
        {
            bankCode = value;
            DataTransform.DataPlacement("company_code", bankCode, dsResult, dr);
        }
    }
    public string setRateDate
    {
        set
        {
            rateDate = value;
            DataTransform.DataPlacement("rate_date", rateDate, dsResult, dr);
        }
    }

    public string setBalAmount
    {
        set 
        {
            balAmount = value;
            DataTransform.DataPlacement("bal_amount", balAmount, dsResult, dr);
        }
    }
    public string setRefNo
    {
        set
        {
            RefNo = value;
            DataTransform.DataPlacement("referenceno", RefNo, dsResult, dr);
        }
    }

    public string setA_UserID
    {
        set 
        {
            AUserID = value;
            DataTransform.DataPlacement("a_userid", AUserID, dsResult, dr);
        }
    }

    public string setA_DateTime
    {
        set
        {
            ADateTime = value;
            DataTransform.DataPlacement("a_datetime", ADateTime, dsResult, dr);
        }
    }

    public string setE_UserID
    {
        set
        {
            EUserID = value;
            DataTransform.DataPlacement("e_userid", EUserID, dsResult, dr);
        }
    }

    public string setE_DateTime
    {
        set
        {
            EDateTime = value;
            DataTransform.DataPlacement("e_Datetime", EDateTime, dsResult, dr);
        }
    }
}

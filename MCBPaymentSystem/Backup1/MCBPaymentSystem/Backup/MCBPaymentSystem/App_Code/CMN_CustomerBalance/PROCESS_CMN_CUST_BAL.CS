using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OracleClient;
using System.Windows.Forms;

public class PROCESS_CMN_CUST_BAL : TABLE_CMN_CUST_BAL
{
    DatabaseConnection_Util DataTransform = new DatabaseConnection_Util();
    private DataRow DR;

    public DataSet DisplaySet()
    {
        DataSet DS = new DataSet();
        DS = DataTransform.ReteriveDataMultiple("EXEC ", " DISPLAY-SET ");
        ClearTable();
        return DS;
    }
    public void AddNewGroup()
    {
        NaviOP("SP_CLOSING_BAL_INSERT");
    }
    public DataTable AddNewGroup(string a)
    {
        DataTable dt = new DataTable();
        dt = NaviOP("SP_CLOSING_BAL_INSERT",0);
        return dt;
    }

    public void EditNewGroup()
    {
        NaviOP("RPS_SP_CUST_BAL_UPDATE");
    }

    public void DeleteNewGroup()
    {
        NaviOP("RPS_SP_CUST_BAL_DELETE"); 
    }

    private void NaviOP(string SP)
    {
        DataSet DS = new DataSet();
        DataSet RETURN_DS = new DataSet();
        DataTable DT = new DataTable();
        DS = ReturnResultSet();
        RETURN_DS = DataTransform.StoredProcedurePlacement(DS, SP);

        DT = DataTransform.SavingData(RETURN_DS, SP);
        ClearTable();
    }
    private DataTable NaviOP(string SP,int a)
    {
        DataSet DS = new DataSet();
        DataSet RETURN_DS = new DataSet();
        DataTable DT = new DataTable();
        DS = ReturnResultSet();
        RETURN_DS = DataTransform.StoredProcedurePlacement(DS, SP);

        DT = DataTransform.SavingData(RETURN_DS, SP);
        ClearTable();
        return DT;
    }

}

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

public class PROCESS_SPDS_SignatorySetup : TABLE_SPDS_SignatorySetup
{
    DatabaseConnection_Util DataTransform = new DatabaseConnection_Util();
    private DataSet SPDS_SignatorySetup_DATASET = new DataSet();
    private DataRow DR;

    public DataSet DisplaySet()
    {
        DataSet DS = new DataSet();
        DS = DataTransform.ReteriveDataMultiple("SELECT ID,SIGNATORY_NAME,UPLOAD_IMAGE_PATH,CURRENT_STATUS,A_userID,A_DateTime,E_UserID,E_DateTime FROM SPDS_SignatorySetup", " DISPLAY-SET ");
        ClearTable();
        return DS;
    }
    public void AddNewGroup()
    { 
        NaviOP("SP_SET_INSERT_SignatorySetup"); 
    }

    public void EditNewGroup()
    { NaviOP("SP_SET_UPDATE_SPDS_SignSetup"); }

    public void DeleteNewGroup()
    { NaviOP("SP_SET_DELETE_SPDS_SignatorySetup"); }

    private void NaviOP(string SP)
    {
        DataSet DS = new DataSet();
        DataSet RETURN_DS = new DataSet();
        DataTable DT = new DataTable();
        DS = ReturnResultSet();
        RETURN_DS = DataTransform.StoredProcedurePlacement(DS, SP);
        DT = DataTransform.SavingData(RETURN_DS, SP);
        Startup_Util.TEMP_DT = DT.Copy();        
        ClearTable();
    }

}

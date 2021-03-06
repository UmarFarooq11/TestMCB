using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
    public class PROCESS_RPS_CustomerFilesPath : TABLE_RPS_CustomerFilesPath
    {
       DatabaseConnection_Util DataTransform = new DatabaseConnection_Util();
        private DataSet RPS_CustomerFilesPath_DATASET = new DataSet();
        private DataRow DR;

        public DataSet DisplaySet()
        {
            DataSet DS = new DataSet();
            DS = DataTransform.ReteriveDataMultiple("EXEC ", " DISPLAY-SET ");
            ClearTable();
            return DS;
        }        public void AddNewGroup()
        { NaviOP("SP_SET_INSERT_RPSCustFilesPath"); }

        public void EditNewGroup()
        { NaviOP("SP_SET_UPDATE_RPS_CustFilePath"); }

        public void DeleteNewGroup()
        { NaviOP("SP_SET_DELETE_RPS_CustomerFilesPath"); }

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

    }

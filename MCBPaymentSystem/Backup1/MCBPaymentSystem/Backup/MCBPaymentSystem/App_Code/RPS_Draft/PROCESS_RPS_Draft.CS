using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
   public class PROCESS_RPS_Draft :TABLE_RPS_Draft
    {
       DatabaseConnection_Util DataTransform = new DatabaseConnection_Util();
        private DataSet RPS_Draft_DATASET = new DataSet();
        private DataRow DR;

        public DataSet DisplaySet()
        {
            DataSet DS = new DataSet();
            DS = DataTransform.ReteriveDataMultiple("EXEC ", " DISPLAY-SET ");
            ClearTable();
            return DS;
        }        public void AddNewGroup()
        { NaviOP(""); }

        public void EditNewGroup()
        { NaviOP(""); }

        public void DeleteNewGroup()
        { NaviOP(""); }

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

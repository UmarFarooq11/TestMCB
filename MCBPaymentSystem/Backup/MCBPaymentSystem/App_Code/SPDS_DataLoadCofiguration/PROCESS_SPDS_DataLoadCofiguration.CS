using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
    public class PROCESS_SPDS_DataLoadCofiguration : TABLE_SPDS_DataLoadCofiguration
    {
       DatabaseConnection_Util DataTransform = new DatabaseConnection_Util();
        private DataSet SPDS_DataLoadCofiguration_DATASET = new DataSet();
        private DataRow DR;

        public DataSet DisplaySet()
        {
            DataSet DS = new DataSet();
            DS = DataTransform.ReteriveDataMultiple("EXEC ", " DISPLAY-SET ");
            ClearTable();
            return DS;
        }        public void AddNewGroup()
        { NaviOP("sp_config_def_master_insert"); }

        public void EditNewGroup()
        { NaviOP("sp_config_def_master_update"); }

        public void DeleteNewGroup()
        { NaviOP("SP_SET_DELETE_SPDS_UniversalUploadCofiguration"); }

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

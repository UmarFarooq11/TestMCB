using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
    public class PROCESS_SPDS_DataLoadCofigurationDetail : TABLE_SPDS_DataLaodCofigurationDetail
    {
       DatabaseConnection_Util DataTransform = new DatabaseConnection_Util();
        private DataSet SPDS_UniversalUploadCofigurationDetail_DATASET = new DataSet();
        private DataRow DR;

        public DataSet DisplaySet()
        {
            DataSet DS = new DataSet();
            DS = DataTransform.ReteriveDataMultiple("EXEC ", " DISPLAY-SET ");
            ClearTable();
            return DS;
        }        public void AddNewGroup()
        { NaviOP("sp_config_def_detail_insert"); }

        public void EditNewGroup()
        { NaviOP("sp_config_def_detail_update"); }

        public void DeleteNewGroup()
        { NaviOP("SP_CONFIG_DEF_DETAIL_DELETE"); }

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

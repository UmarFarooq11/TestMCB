using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
    public class PROCESS_SPDS_UniversalUploadCofigurationDetail : TABLE_SPDS_UniversalUploadCofigurationDetail
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
        { NaviOP("SP_INS_SPDS_UNIVUploadCofigDtl"); }

        public void EditNewGroup()
        { NaviOP("SP_UPDATE_UNIVUploadCofigDtl"); }

        public void DeleteNewGroup()
        { NaviOP("SP_DEL_SPDS_UNIVUploadCofigDtl"); }

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

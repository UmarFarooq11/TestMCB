using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

    interface ISPDS_STATIONARY_DETAIL
    {
        void RecordInputStart();
        void RecordInputCommit();
        DataSet ReturnResultSet();
        void ClearTable();
      String Get_A_DATETIME
		{ set;}
      String Get_A_USERID
		{ set;}
      String Get_ACTIVATE_FLG
		{ set;}
      String Get_ACTIVATION_DATE
		{ set;}
      String Get_E_DATETIME
		{ set;}
      String Get_E_USERID
		{ set;}
      String Get_END_SERIAL_NO
		{ set;}
      String Get_ID
		{ set;}
      String Get_START_SERIAL_NO
		{ set;}
      String Get_STATIONARY_MASTER_ID
		{ set;}
        String Get_PrintLocationID
      { set;}
        String Get_PrintAgent
      { set;}
      }

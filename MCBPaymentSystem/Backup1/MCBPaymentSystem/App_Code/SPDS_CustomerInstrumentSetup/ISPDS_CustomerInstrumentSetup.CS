using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

    interface ISPDS_CustomerInstrumentSetup
    {
        void RecordInputStart();
        void RecordInputCommit();
        DataSet ReturnResultSet();
        void ClearTable();
      String Get_A_DateTime
		{ set;}
      String Get_A_UserID
		{ set;}
      String Get_CHOPPER_REQUIRED
		{ set;}
      String Get_CUSTOMER_ID
		{ set;}
      String Get_E_DateTime
		{ set;}
      String Get_E_UserID
		{ set;}
      String Get_ID
		{ set;}
      String Get_INSTRUMENT_ID
		{ set;}
      }

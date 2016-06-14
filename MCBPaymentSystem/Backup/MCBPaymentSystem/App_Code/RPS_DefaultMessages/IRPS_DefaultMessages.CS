using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

    interface IRPS_DefaultMessages
    {
        void RecordInputStart();
        void RecordInputCommit();
        DataSet ReturnResultSet();
        void ClearTable();
      String Get_A_DateTime
		{ set;}
      String Get_A_UserID
		{ set;}
      String Get_DefaultMessageCode
		{ set;}
      String Get_Description
		{ set;}
      String Get_E_DateTime
		{ set;}
      String Get_E_UserID
		{ set;}
      String Get_ID
		{ set;}
      }

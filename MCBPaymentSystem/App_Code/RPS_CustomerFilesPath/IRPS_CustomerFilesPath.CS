using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

    interface IRPS_CustomerFilesPath
    {
        void RecordInputStart();
        void RecordInputCommit();
        DataSet ReturnResultSet();
        void ClearTable();
      String Get_A_DateTime
		{ set;}
      String Get_A_UserId
		{ set;}
      String Get_CustomerId
		{ set;}
      String Get_E_DateTime
		{ set;}
      String Get_E_UserId
		{ set;}
      String Get_ID
		{ set;}
      String Get_ReceiveFilePath1
		{ set;}
      String Get_SendFilePath
		{ set;}
      }

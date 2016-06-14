using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

    interface ISPDS_SignatorySetup
    {
        void RecordInputStart();
        void RecordInputCommit();
        DataSet ReturnResultSet();
        void ClearTable();
      String Get_A_DateTime
		{ set;}
      String Get_A_userID
		{ set;}
      String Get_CURRENT_STATUS
		{ set;}
      String Get_E_DateTime
		{ set;}
      String Get_E_UserID
		{ set;}
      String Get_ID
		{ set;}
      String Get_SIGNATORY_NAME
		{ set;}
      String Get_UPLOAD_IMAGE_PATH
		{ set;}
      }

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
//using System.Data.SqlClient;

interface ICMN_CustomerConfigLink
    {
        void RecordInputStart();
        void RecordInputCommit();
        DataSet ReturnResultSet();
        void ClearTable();

    String Get_COMPANY_CODE
		{ set;}
    String Get_CONF_DEF_ID
		{ set;}
     
      }

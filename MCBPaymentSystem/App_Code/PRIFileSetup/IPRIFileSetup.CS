using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

    interface IPRIFileSetup
    {
        void RecordInputStart();
        void RecordInputCommit();
        DataSet ReturnResultSet();
        void ClearTable();
      String Get_FileDownload
		{ set;}
      String Get_FileUpload
		{ set;}
      String Get_ID
		{ set;}
      }

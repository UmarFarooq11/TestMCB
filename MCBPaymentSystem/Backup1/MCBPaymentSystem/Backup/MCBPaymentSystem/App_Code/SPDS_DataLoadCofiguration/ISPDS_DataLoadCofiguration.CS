using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

    interface ISPDS_DataLoadCofiguration
    {
        void RecordInputStart();
        void RecordInputCommit();
        DataSet ReturnResultSet();
        void ClearTable();

      


        String Get_ConfigurationDefinationID
		{ set;}
        String Get_ConfigurationDefinationDesc
		{ set;}
        String Get_FileFormat
		{ set;}
        String Get_ConfigurationID
		{ set;}
        /*
      String Get_ConfigurationName
		{ set;}
      String Get_E_DateTime
		{ set;}
      String Get_E_UserID
		{ set;}
      String Get_FileFormat
		{ set;}
      String Get_FilePath
		{ set;}
      String Get_ID
		{ set;}
      String Get_ObjectName
		{ set;}
      String Get_ObjectType
		{ set;}
      String Get_SourceID
		{ set;}*/
      }

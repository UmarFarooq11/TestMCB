using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

    interface IRPS_DraftCancellation
    {
        void RecordInputStart();
        void RecordInputCommit();
        DataSet ReturnResultSet();
        void ClearTable();

        string Get_A_DateTime
		{ set;}
      string Get_A_UserID
		{ set;}
        string Get_AcknowledgeDate
		{ set;}
      string Get_AcknowledgeRefNo
		{ set;}
        string Get_CancelDate
		{ set;}
      string Get_CancelNo
		{ set;}
      string Get_CancelStatusID
		{ set;}
      string Get_DraftID
		{ set;}
        string Get_E_DateTime
		{ set;}
      string Get_E_UserID
		{ set;}
      string Get_ID
		{ set;}
      string Get_StatusSwitch
		{ set;}
      string Get_TracerID
		{ set;}
      string Get_ReIssue
        { set;}
      string Get_Refund
        { set;}
      string Get_SundryDuplicate
        { set;}
      }

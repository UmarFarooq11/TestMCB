using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

interface ISPDS_DataLoadCofigurationDetail
{
    void RecordInputStart();
    void RecordInputCommit();
    DataSet ReturnResultSet();
    void ClearTable();

    String Get_CONF_ID { set;}
    String Get_CONF_DEF_ID { set;}
    String Get_COLUMN_ORDER { set;}
    String Get_COLUMN_SEQ { set;}
    String Get_FROM_POS { set;}
    String Get_TO_POS { set;}

    
    /*
    String Get_A_DateTime
    { set;}
    String Get_A_userID
    { set;}
    String Get_ColumnName
    { set;}
    String Get_E_DateTime
    { set;}
    String Get_E_UserID
    { set;}
    String Get_ID
    { set;}
    String Get_Sequence
    { set;}
    String Get_UniversalUploadID
    { set;}*/
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

interface ISPDS_STATIONARY_MASTER
{
    void RecordInputStart();
    void RecordInputCommit();
    DataSet ReturnResultSet();
    void ClearTable();
    String Get_A_DATETIME
    { set;}
    String Get_A_USERID
    { set;}
    String Get_PARRID 
    { set;}
    String Get_E_DATETIME
    { set;}
    String Get_E_USERID
    { set;}
    String Get_ID
    { set;}
    String Get_LAST_ACTIVATION_DATE
    { set;}
    String Get_SERIAL_DATE
    { set;}
    String Get_THRESHOLD
    { set;}

}

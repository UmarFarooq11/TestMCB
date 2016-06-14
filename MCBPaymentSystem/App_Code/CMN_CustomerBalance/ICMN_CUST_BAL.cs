using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

interface ICMN_CUST_BAL
{
    void RecordInputStart();

    void RecordInputCommit();

    DataSet ReturnResultSet();

    void ClearTable();

    string setBankCode
    { set;}

    string setRateDate
    { set;}

    string setBalAmount
    { set;}

    string setA_DateTime
    { set;}

    string setA_UserID
    { set;}

    string setE_DateTime
    { set;}

    string setE_UserID
    { set;}
}

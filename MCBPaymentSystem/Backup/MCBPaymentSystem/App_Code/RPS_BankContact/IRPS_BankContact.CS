using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

interface IRPS_BankContact
{
    void RecordInputStart();
    void RecordInputCommit();
    DataSet ReturnResultSet();
    void ClearTable();
    String Get_Address
    { set;}
    String Get_BankID
    { set;}
    String Get_ContactName
    { set;}
    String Get_Email
    { set;}
    String Get_FaxNo
    { set;}
    String Get_ID
    { set;}
    String Get_NTNNo
    { set;}
    String Get_PhoneNo
    { set;}
}

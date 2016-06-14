using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections;
using System.Data.OracleClient;


public class RcvFileCustomerRules
{
    DatabaseConnection_Util DataTransform = new DatabaseConnection_Util();
    DataSet DS = new DataSet();

    public RcvFileCustomerRules()
	{}

    public int DateCheck(string DT )
    {
        try { 
            Convert.ToDateTime(DT);
            return 1;
            }
        catch
            {return 0;}
    }

    public string Get_SP_CMN_CURRENCY_CHECK(string CurrencyCode)
    {
        DataSet DS = new DataSet();
        DS = DataTransform.ReteriveDataMultiple("EXEC SP_CMN_CURRENCY_CHECK '" + CurrencyCode  + "'", "GET_ALL_USER");

        return DS.Tables[0].Rows[0][0].ToString();
    }


    public string Get_SP_RPS_MasterZipCode_CHECK(string ZipCode)
    {
        DataSet DS = new DataSet();
        DS = DataTransform.ReteriveDataMultiple("EXEC SP_RPS_MasterZipCode_CHECK '" + ZipCode + "'", "GET_ALL_USER");
        return DS.Tables[0].Rows[0][0].ToString();
    }




    public string BatchHeader_CurrencyCheck(Queue STR)
    {
        string res = "";
        string ST = "";
        string[] ARY;
        string[] ARY1;
        ST = STR.Dequeue().ToString();
        ARY = ST.Split('|');
        res = Get_SP_CMN_CURRENCY_CHECK(ARY[6].ToString());

        if (res == "0")
        { return "0"; }


        ARY1 = ST.Split('~');
        for (int a = 1; a <= ARY1.Length - 2; a++)
        {
            string[] ARY0;
            ARY0 = ARY1[a].Split('|');
            if (ARY0[0].ToString() != "   ")
            {
                res = Get_SP_CMN_CURRENCY_CHECK(ARY0[0].ToString());
                if (res == "0")
                { return "0"; }
            }

        }



        return res;
    }

    public string FinancialTransaction_CurrencyCheck(Queue STR)
    {
        string RES = "";
        string[] ARY;
               
       
        while (STR.Count >= 1)
        {
            ARY = STR.Dequeue().ToString().Split('|');
            RES = Get_SP_CMN_CURRENCY_CHECK(ARY[6].ToString());

            if (RES == "0")
            { return "0"; }
        }

        return RES;

    }


    public string Trailer_CurrencyCheck(Queue STR)
    {
        string res = "";
        string ST = "";
        string[] ARY;
        string[] ARY1;
        string TMP = "";
                
        while (STR.Count >= 1)
        {
            TMP = STR.Dequeue().ToString();
            ST = TMP;

            ARY = ST.Split('|');
            res = Get_SP_CMN_CURRENCY_CHECK(ARY[6].ToString());

            if (res == "0")
            {return "0";}

            ARY1 = TMP.Split('~');
            for (int a = 1; a <= ARY1.Length - 1; a++)
            {
                if (ARY1[a].ToString() == "")
                { }
                else
                {
                    res = BatchHeaderSupport(ARY1[a].ToString());
                    if (res == "0")
                    { return "0"; }
                }
            }
            
        }
        return res;             
    }

    protected string BatchHeaderSupport(string STR)
    {
     string[] ARY;
     ARY = STR.Split('|');     
     return Get_SP_CMN_CURRENCY_CHECK(ARY[0].ToString());
    }



    public string RemitterInformation_Check(Queue STR)
    {
        string RES = "";
        string[] ARY;

        while (STR.Count >= 1)
        {
            ARY = STR.Dequeue().ToString().Split('|');
            if ((ARY[9].ToString() == "110") || (ARY[9].ToString() == "111") || (ARY[9].ToString() == "112"))
            { RES = "1"; }
            else
            { RES = "0"; }


            if (RES == "0")
            { return "0"; }
        }

        return RES;

    }



    

    public string BeneficiaryInformation_Check(Queue STR)
    {
        string RES = "";
        string[] ARY;

        while (STR.Count >= 1)
        {
            ARY = STR.Dequeue().ToString().Split('|');
            if ((ARY[15].ToString() == "210") || (ARY[15].ToString() == "211") || (ARY[1].ToString() == "212"))
            { RES = "1"; }
            else
            { RES = "0"; }


            if (RES == "0")
            { return "0"; }
        }

        return RES;
    }


    public string BeneficiaryZip_Check(string[] STR)
    {
        string RES = "";
        for (int A = 0; A <= STR.Length - 1; A++)
        {
         string[] ARY;
         ARY = STR[A].Split('|');
         if (Get_SP_RPS_MasterZipCode_CHECK(ARY[9].ToString()) == "1")
         {RES = "1";}
         else
         { RES = "0"; }
            
         if (RES == "0")
         { return "0"; }
         
        }
        return RES;
    }

    public string TransactionNo_Check(string ST1, string ST2)
    {     
        string[] ARY;
        ARY = ST2.Split('|');
        if (Convert.ToInt32(ARY[3].ToString()) == Convert.ToInt32(ST1.ToString()))                        
        {return "1";}
        else
        { return "0"; }
    }


    public string BatchNo_Check(string ST1, string ST2)
    {     
        string[] ARY;
        ARY = ST2.Split('|');
        if (Convert.ToInt32(ARY[4].ToString()) == Convert.ToInt32(ST1.ToString()))                        
        {return "1";}
        else
        { return "0"; }
    }
    


    public string FileVerification(string[] RemitterCommand, string[] BeneficiaryCommand, string[] RemittanceCommand, string[] TracerCommand)
    {
        decimal sum1 = 0;
        string[] ARY;
        string[] BeneficiaryCommand1;
        string[] RemittanceCommand1;
        string[] TracerCommand1;

        for (int A = 0; A <= RemitterCommand.Length-1; A++)
        {
            ARY = RemitterCommand[A].Split('|');
            sum1 += ((int.Parse(ARY[1].ToString())) * (decimal)1000);
        }

        for (int A = 0; A <= BeneficiaryCommand.Length - 1; A++)
        {
            BeneficiaryCommand1 = BeneficiaryCommand[A].Split('|');
            sum1 += (((int.Parse(BeneficiaryCommand1[1].ToString())) * (decimal)1000) + ((int.Parse(BeneficiaryCommand1[2].ToString())) * (decimal)10));
        }

        for (int A = 0; A <= RemittanceCommand.Length - 1; A++)
        {
            RemittanceCommand1 = RemittanceCommand[A].Split('|');
            sum1 += (((int.Parse(RemittanceCommand1[1].ToString())) * (decimal)1000) + ((int.Parse(RemittanceCommand1[2].ToString())) * (decimal)10));
        }


        for (int A = 0; A <= TracerCommand.Length - 1; A++)
        {
            TracerCommand1 = TracerCommand[A].Split('|');
            sum1 += (((int.Parse(TracerCommand1[1].ToString())) * (decimal)1000) + ((int.Parse(TracerCommand1[2].ToString())) * (decimal)10));
        }
        
        return GetModulus11(sum1).ToString();
    }


    private decimal GetModulus11(decimal sum1)
    {
        string sum = sum1.ToString().Substring(0, sum1.ToString().Length - 1);
        string N = sum;
        int S = 0;
        int num = 0;
        int digit = 7;
        for (int i = 0; i < N.Length; i++)
        {
            num = Convert.ToInt32(N.Substring(N.Length - 1 - i, 1));
            S += (digit * num);
            digit--;
            if (digit < 2)
                digit = 7;
        }
        int q = S / 11;
        //round
        decimal r = Math.Round((decimal)S % 11, 1);
        //string chk = r.ToString().PadLeft(18, '0');
        //decimal r = S % 11;
        int checkDigit = (int)(11 - r);
        if (checkDigit == 10)
            checkDigit = 1;
        else if (checkDigit == 11)
            checkDigit = 2;

        return Convert.ToDecimal(sum + checkDigit.ToString());
    }

    private decimal GetModulus11Two(decimal sum1)
    {
        string N = sum1.ToString();
        int S = 0;
        int num = 0;
        int digit = 7;
        for (int i = 0; i < N.Length; i++)
        {
            num = Convert.ToInt32(N.Substring(N.Length - 1 - i, 1));
            S += digit * num;
            digit--;
            if (digit < 2)
                digit = 7;
        }
        int q = S / 11;
        //round
        decimal r = Math.Round((decimal)S / 11, 1);
        string chk = r.ToString().PadLeft(18, '0');
        chk = chk.Substring(chk.Length - 2, 2);
        if (chk.Substring(0, 1) == ".")
            chk = chk.Substring(1, 1);
        else
            chk = "0";
        r = Convert.ToInt32(chk);
        //decimal r = S % 11;
        int checkDigit = (int)(11 - r);
        if (checkDigit == 10)
            checkDigit = 1;
        else if (checkDigit == 11)
            checkDigit = 2;
        string sum = sum1.ToString().Substring(0, sum1.ToString().Length - 1);

        return Convert.ToDecimal(sum + checkDigit.ToString());
    }




    /**************FILE SAVE INFORMATION***************************/
    public string RPS_SP_IncomingFile_Add_1(string ID, string PrincipleBankID, string FileName, string CitibankCode, string ReceivedDateTime,
                                            string FileStatusCode, string AssignedSequenceNo, string NoOfRecords, string Remarks,
                                            string A_UserID, string A_DateTime, string E_UserID, string E_DateTime)
    {   
        DataSet DS = new DataSet();
        DS = DataTransform.ReteriveDataMultiple(" EXEC RPS_SP_IncomingFile_Add_1  " + ID + "," + PrincipleBankID + ",'" + FileName + "','" + CitibankCode + "','" +
                                                  Convert.ToDateTime(ReceivedDateTime) + "','" + FileStatusCode + "','" + AssignedSequenceNo + "'," + NoOfRecords + ",'" + Remarks + "','" + 
                                                  A_UserID + "','" + Convert.ToDateTime(A_DateTime) + "','" + E_UserID + "','" + Convert.ToDateTime(E_DateTime) + "'" , "GET_ALL_USER");

        return DS.Tables[0].Rows[0][0].ToString();
    }



    public string RPS_SP_IncomingBatchHeader_Add_1(string ID, string IncomingHeaderID, string TransmissionDate, string BatchNumber, string NoOfTransactions,
                                                   string NoOfRecords, string HashTotal, string CurrencyCode, string TotalCoverAmount,
                                                   string A_UserID, string A_DateTime, string E_UserID, string E_DateTime)
    {   
        DataSet DS = new DataSet();
        DS = DataTransform.ReteriveDataMultiple("EXEC RPS_SP_IncomingBatchHeader_Add_1  " + ID  + "," + IncomingHeaderID + ",'" + TransmissionDate + "'," + BatchNumber + "," + NoOfTransactions + "," +
                                                 NoOfRecords + ",'" + HashTotal + "','" + CurrencyCode + "'," + TotalCoverAmount + ",'" +
                                                 A_UserID + "','" + Convert.ToDateTime(A_DateTime) + "','" + E_UserID + "','" + Convert.ToDateTime(E_DateTime) + "'", "GET_ALL_USER");

        return DS.Tables[0].Rows[0][0].ToString();
    }



    public string RPS_SP_IncomingRemitterInfo_Add_1(string ID,string IncomingBatchHeaderID,string RemitterAccountNo,string FirstName,string MiddleName,string LastName,string POBoxNo,string City,
                                                    string ZipCode,string DateOfBirth,string UpdateStatus,string UpdateDate,string PhoneNo,string Country,string RemitterID,
                                                    string A_UserID, string A_DateTime, string E_UserID, string E_DateTime)
    {
        DataSet DS = new DataSet();

        //DateOfBirth = null;

        DS = DataTransform.ReteriveDataMultiple("EXEC RPS_SP_IncomingRemitterInfo_Add_1 " + ID + "," + IncomingBatchHeaderID + ","
                                                 + "'" + RemitterAccountNo + "'," + "'" + FirstName + "'," + "'" + MiddleName + "',"
                                                 + "'" + LastName + "'," + "'" + POBoxNo + "'," + "'" + City + "'," + "'" + ZipCode + "',"
                                                 + "'" + DateOfBirth + "'," + "'" + UpdateStatus + "'," + "'" + Convert.ToDateTime(UpdateDate).ToString("dd-MMM-yyyy") + "',"
                                                 + "'" + PhoneNo + "'," + "'" + Country + "'," + RemitterID + "," + "'" + A_UserID + "',"
                                                 + "'" + Convert.ToDateTime(A_DateTime) + "'," + "'" + E_UserID + "'," + "'" + Convert.ToDateTime(E_DateTime) + "'" , "GET_ALL_USER");

        return DS.Tables[0].Rows[0][0].ToString();
    }

    public string RPS_SP_IncomingBeneficiaryInfo_Add_1(string ID, string IncomingBatchHeaderID, string RemitterAccountNo, string BeneficiaryNo,
                                                        string FirstName, string MiddleName, string LastName, string AlternateFirstName,
                                                        string AlternateMiddleName, string AlternateLastName, string AddressLine1, string AddressLine2,
                                                        string CTP, string ZipCode, string AccountNo, string UpdateStatus, string UpdateDate,
                                                        string LanguageCode, string PhoneNo, string NICNo, string IncomingRemitterID,
                                                        string A_UserID, string A_DateTime, string E_UserID, string E_DateTime)
    {
 
        DS = DataTransform.ReteriveDataMultiple("EXEC RPS_SP_IncomingBeneficiaryInfo_Add_1 " +
                                                 ID + "," + IncomingBatchHeaderID + "," + "'" + RemitterAccountNo +"'," + "'" + BeneficiaryNo +"'," + 
                                                 "'" + FirstName +"'," + "'" + MiddleName +"'," + "'" + LastName +"'," + "'" + AlternateFirstName +"'," + 
                                                 "'" + AlternateMiddleName +"'," + "'" + AlternateLastName +"'," + "'" + AddressLine1 +"'," + 
                                                 "'" + AddressLine2 +"'," + "'" + CTP +"'," + "'" + ZipCode +"'," + "'" + AccountNo +"'," + 
                                                 "'" + UpdateStatus +"'," + "'" + UpdateDate +"'," + "'" + LanguageCode +"'," + "'" + PhoneNo +"'," + 
                                                 "'" + NICNo +"'," + IncomingRemitterID +"," + "'" + A_UserID +"'," + "'" + A_DateTime +"'," + 
                                                 "'" + E_UserID +"'," + "'" + E_DateTime + "'", "GET_ALL_USER");
        return DS.Tables[0].Rows[0][0].ToString();
    
    }

    public string RPS_SP_IncomingRemittanceInfo_Add_1(string ID, string IncomingBatchHeaderID, string RemitterAccountNo, string BeneficiaryNo,
                                                      string AltBenFlag, string RemittanceReferenceNo, string RemittanceDate, string CurrencyCode,
                                                      string CoverAmountUSD, string RemittanceAmount, string LanguageCode, string RemitterMessage,
                                                      string IncomingRemitterID, string IncomingBeneficiaryID, string A_UserID,
                                                      string A_DateTime, string E_UserID, string E_DateTime)
    {
        DS = DataTransform.ReteriveDataMultiple("EXEC RPS_SP_IncomingRemittanceInfo_Add_1 " + ID + "," + IncomingBatchHeaderID + ",'" + RemitterAccountNo + "','" + BeneficiaryNo + "','" + AltBenFlag + "','" + RemittanceReferenceNo + "','" +
                                                 RemittanceDate + "','" + CurrencyCode + "'," + CoverAmountUSD + "," + RemittanceAmount + ",'" + LanguageCode + "','" + RemitterMessage + "'," +
                                                 IncomingRemitterID + ",'" + IncomingBeneficiaryID + "','" + A_UserID + "','" + A_DateTime + "','" + E_UserID + "','" + E_DateTime + "'", "GET_ALL_USER");

        return DS.Tables[0].Rows[0][0].ToString();
    
    }
    
    public string RPS_SP_IncomingTracer_Add_1(string ID, string IncomingBatchHeaderID, string RemitterAccountNo, string BeneficiaryNo,
                                              string RemittanceReferenceNo, string SequenceNo, string TransactionTypeCode, string RequestCode,
                                              string FreeTextMessage, string A_UserID, string A_DateTime, string E_UserID, string E_DateTime)
    {        

        DS = DataTransform.ReteriveDataMultiple("EXEC RPS_SP_IncomingTracer_Add_1 " + ID + "," + IncomingBatchHeaderID + ",'" + RemitterAccountNo + "','" + 
                                                 BeneficiaryNo + "','" + RemittanceReferenceNo + "','" + SequenceNo + "','" + TransactionTypeCode + "','" + 
                                                 RequestCode + "','" + FreeTextMessage + "','" + A_UserID + "','" + A_DateTime + "','" + E_UserID + "','" + E_DateTime + "'", "GET_ALL_USER");

        return DS.Tables[0].Rows[0][0].ToString();
        
    }



    public string RPS_SP_IncomingTrailer_Add_1(string ID, string IncomingBatchHeaderID, string BatchDate, string BatchNumber, string BatchesToThisDate,
                                               string LastBatchNumber, string RecordsToDate, string CurrencyCode, string TotalCoverAmount,
                                               string A_UserID, string A_DateTime, string E_UserID, string E_DateTime)
    {        

        DS = DataTransform.ReteriveDataMultiple("EXEC RPS_SP_IncomingTrailer_Add_1 " + ID + "," + IncomingBatchHeaderID + ",'" + BatchDate + "','" + 
                                                BatchNumber + "','" + BatchesToThisDate + "','" + LastBatchNumber + "','" + RecordsToDate + "','" + CurrencyCode + "'," + TotalCoverAmount + ",'" + 
                                                A_UserID + "','" + A_DateTime + "','" + E_UserID + "','" + E_DateTime + "'", "GET_ALL_USER");

        return DS.Tables[0].Rows[0][0].ToString();
        
    }
    public string RPS_SP_IncomingTrailerDetail_Add_1(string ID, string IncomingTrailerID, string CurrencyCode, string CoverAmount, string CurrencyAmount)
    {

        DS = DataTransform.ReteriveDataMultiple("EXEC RPS_SP_IncomingTrailerDetail_Add_1 " + ID + "," + IncomingTrailerID + ",'" + CurrencyCode + "'," + CoverAmount + "," + CurrencyAmount, "GET_ALL_USER");
        return DS.Tables[0].Rows[0][0].ToString();
        
    }
    public string RPS_SP_IncomingBatchHeaderDetail_Add_1(string ID, string IncomingBatchHeaderID, string CurrencyCode, string ExchangeRate, string CurrencyAmount, string CoverAmount)
    {
        DS = DataTransform.ReteriveDataMultiple("RPS_SP_IncomingBatchHeaderDetail_Add_1 " + ID + "," + IncomingBatchHeaderID + ",'" + CurrencyCode + "'," + 
                                                 CoverAmount + "," + ExchangeRate + "," + CurrencyAmount, "GET_ALL_USER");
        return DS.Tables[0].Rows[0][0].ToString();
    }

    public string GetCustomerFilePath(string ID)
    {
        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("v_ID", OracleType.VarChar, ParameterDirection.Input, ID);
        PR[1] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("GetCustomerFilePath", PR);

        //return DS;
        //DS = DataTransform.ReteriveDataMultiple("EXEC GetCustomerFilePath " + ID , "GET_ALL_USER");
        return DS.Tables[0].Rows[0][0].ToString();
    }


    public void RPS_SP_IncomingHeader_Process(string ID)
    {
        DS = DataTransform.ReteriveDataMultiple("EXEC RPS_SP_IncomingHeader_Process " + ID, "GET_ALL_USER");        
    }



    public string CheckProcessedOrNot(string filename)
    {
        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("v_Return_File_name", OracleType.VarChar, ParameterDirection.Input, filename);
        PR[1] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("sp_CheckFileProcessedorNot", PR);

        //DS = DataTransform.ReteriveDataMultiple("EXEC sp_CheckFileProcessedorNot '" + filename + "'", "GET_ALL_USER");
        return DS.Tables[0].Rows[0][0].ToString();
    }
    
    

    /**************FILE SAVE INFORMATION***************************/


    
}

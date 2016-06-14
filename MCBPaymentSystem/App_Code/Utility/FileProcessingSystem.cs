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

/// <summary>
/// Summary description for FileProcessingSystem
/// </summary>
public class FileProcessingSystem
{
    DatabaseConnection_Util DataTransform = new DatabaseConnection_Util();
    DataSet DS = new DataSet();

    /*
    public DataSet Get_CMN_Country_ALL(string SBPCode, string CountryName)
    {
        DataSet DS = new DataSet();
        DS = DataTransform.ReteriveDataMultiple("EXEC SP_CMN_Country_ALL '" + SBPCode + "','" + CountryName + "'", "GET_ALL_USER");
        return DS;
    }
    */

    public FileProcessingSystem()
	{}


    public Queue HeaderDivsion(string STR)
    {
        Queue ARY = new Queue();
        string TEMP_STR = "";
        string TEMP = STR;
        
        TEMP_STR = TEMP.Substring(0, 2).ToString() + "|" + TEMP.Substring(2, 7).ToString() + "|" + TEMP.Substring(9, 8).ToString() + "|" + TEMP.Substring(17, 6).ToString();       

        /*
        ARY.Enqueue(TEMP.Substring(0, 2).ToString());
        ARY.Enqueue(TEMP.Substring(2, 7).ToString());
        ARY.Enqueue(TEMP.Substring(9, 8).ToString());
        ARY.Enqueue(TEMP.Substring(17, 6).ToString());
        */
        ARY.Enqueue(TEMP_STR);
        return ARY;        
    }


    public Queue BatchHeaderDivsion(Queue STR)
    {
        Queue ARY = new Queue();

        string TEMP0 = "";
        string TEMP1 = "";
        string TEMP2 = "";
        string TEMP3 = "";
        string TEMP4 = "";
        string TEMP5 = "";


        String[] S;
        string TEMP = "";
        string SUB = "";
        TEMP = "";
        TEMP = STR.Dequeue().ToString();
        SUB = TEMP.Substring(0, 2).ToString() + "|" +
        TEMP.Substring(2, 8).ToString() + "|" +
        TEMP.Substring(10, 2).ToString() + "|" +
        TEMP.Substring(12, 5).ToString() + "|" +
        TEMP.Substring(17, 5).ToString() + "|" +
        TEMP.Substring(22, 18).ToString() + "|" +
        TEMP.Substring(40, 3).ToString() + "|" +
        TEMP.Substring(43, 13).ToString() + "~" +

        TEMP.Substring(56, 3).ToString() + "|" +
        TEMP.Substring(59, 9).ToString() + "|" +
        TEMP.Substring(68, 15).ToString() + "|" +
        TEMP.Substring(83, 13).ToString() + "~" +

        TEMP.Substring(96, 3).ToString() + "|" +
        TEMP.Substring(99, 9).ToString() + "|" +
        TEMP.Substring(108, 15).ToString() + "|" +
        TEMP.Substring(123, 13).ToString() + "~" +

        TEMP.Substring(136, 3).ToString() + "|" +
        TEMP.Substring(139, 9).ToString() + "|" +
        TEMP.Substring(148, 15).ToString() + "|" +
        TEMP.Substring(163, 13).ToString() + "~" +

        TEMP.Substring(176, 3).ToString() + "|" +
        TEMP.Substring(179, 9).ToString() + "|" +
        TEMP.Substring(188, 15).ToString() + "|" +
        TEMP.Substring(203, 13).ToString() + "~" +

        TEMP.Substring(216, 3).ToString() + "|" +
        TEMP.Substring(219, 9).ToString() + "|" +
        TEMP.Substring(228, 15).ToString() + "|" +
        TEMP.Substring(243, 13).ToString() + "~";

        





        /*
        if (TEMP.Length > 96)
        {
            TEMP0 = TEMP.Substring(96, TEMP.Length - 96).ToString();
            if (TEMP0.Length == 200)
            {
                TEMP1 = TEMP0.Substring(0, 40).ToString();
                TEMP2 = TEMP0.Substring(40, 40).ToString();
                TEMP3 = TEMP0.Substring(80, 40).ToString();
                TEMP4 = TEMP0.Substring(120, 40).ToString();
                TEMP5 = TEMP0.Substring(160, 40).ToString();
            }
            else if (TEMP0.Length == 160)
            {
                TEMP1 = TEMP0.Substring(0, 40).ToString();
                TEMP2 = TEMP0.Substring(40, 40).ToString();
                TEMP3 = TEMP0.Substring(80, 40).ToString();
                TEMP4 = TEMP0.Substring(120, 40).ToString();                
            }
            else if (TEMP0.Length == 120)
            {
                TEMP1 = TEMP0.Substring(0, 40).ToString();
                TEMP2 = TEMP0.Substring(40, 40).ToString();
                TEMP3 = TEMP0.Substring(80, 40).ToString();                
            }
            else if (TEMP0.Length == 80)
            {
                TEMP1 = TEMP0.Substring(0, 40).ToString();
                TEMP2 = TEMP0.Substring(40, 40).ToString();                
            }

            else if (TEMP0.Length == 40)
            { TEMP1 = TEMP0.Substring(0, 40).ToString(); }
        }

        if (TEMP1.Length != 0)
        {
            TEMP0 = "";
            TEMP0 = TEMP1.Substring(0, 3) + "|" + TEMP1.Substring(3, 9) + "|" + TEMP1.Substring(12, 15) + "|" + TEMP1.Substring(27, 13);
            TEMP1 = TEMP0;
        }

        if (TEMP2.Length != 0)
        {
            TEMP0 = "";
            TEMP0 = TEMP2.Substring(0, 3) + "|" + TEMP2.Substring(3, 9) + "|" + TEMP2.Substring(12, 15) + "|" + TEMP2.Substring(27, 13);
            TEMP2 = TEMP0;
        }

        if (TEMP3.Length != 0)
        {
            TEMP0 = "";
            TEMP0 = TEMP3.Substring(0, 3) + "|" + TEMP3.Substring(3, 9) + "|" + TEMP3.Substring(12, 15) + "|" + TEMP3.Substring(27, 13);
            TEMP3 = TEMP0;
        }


        if (TEMP4.Length != 0)
        {
            TEMP0 = "";
            TEMP0 = TEMP4.Substring(0, 3) + "|" + TEMP4.Substring(3, 9) + "|" + TEMP4.Substring(12, 15) + "|" + TEMP4.Substring(27, 13);
            TEMP4 = TEMP0;
        }


        if (TEMP5.Length != 0)
        {
            TEMP0 = "";
            TEMP0 = TEMP5.Substring(0, 3) + "|" + TEMP5.Substring(3, 9) + "|" + TEMP5.Substring(12, 15) + "|" + TEMP5.Substring(27, 13);
            TEMP5 = TEMP0;
        }
        
        SUB = SUB + TEMP1 + "~" + TEMP2 + "~" + TEMP3 + "~" + TEMP4 + "~" + TEMP5;
        */

        ARY.Enqueue(SUB);
        return ARY;     
    }

    

    public Queue RemitterInformationDivision(Queue STR)
    {
        Queue ARY = new Queue();
        String[] S;
        string TEMP = "";
        string SUB = "";
        while (STR.Count >= 1)
        {
            TEMP = "";
            TEMP = STR.Dequeue().ToString();
            SUB = TEMP.Substring(0, 2).ToString() + "|" +
            TEMP.Substring(2, 10).ToString() + "|" +
            TEMP.Substring(12, 20).ToString() + "|" +
            TEMP.Substring(32, 20).ToString() + "|" +
            TEMP.Substring(52, 20).ToString() + "|" +
            TEMP.Substring(72, 10).ToString() + "|" +
            TEMP.Substring(82, 20).ToString() + "|" +
            TEMP.Substring(102, 7).ToString() + "|" +
            TEMP.Substring(109, 8).ToString() + "|" +
            TEMP.Substring(117, 3).ToString() + "|" +
            TEMP.Substring(120, 8).ToString();            
            ARY.Enqueue(SUB);
        }
        return ARY;     
    }

    public Queue BeneficiaryInformationDivision(Queue STR)
    {
        Queue ARY = new Queue();
        String[] S;
        string TEMP = "";
        string SUB = "";
        while (STR.Count >= 1)
        {
            TEMP = "";
            TEMP = STR.Dequeue().ToString();
            SUB = TEMP.Substring(0, 2).ToString() + "|" +
            TEMP.Substring(2, 10).ToString() + "|" +
            TEMP.Substring(12, 2).ToString() + "|" +
            TEMP.Substring(14, 20).ToString() + "|" +
            TEMP.Substring(34, 20).ToString() + "|" +
            TEMP.Substring(54, 20).ToString() + "|" +
            TEMP.Substring(74, 30).ToString() + "|" +
            TEMP.Substring(104, 30).ToString() + "|" +
            TEMP.Substring(134, 30).ToString() + "|" +
            TEMP.Substring(164, 10).ToString() + "|" +
            TEMP.Substring(174, 20).ToString() + "|" +
            TEMP.Substring(194, 20).ToString() + "|" +
            TEMP.Substring(214, 20).ToString() + "|" +
            TEMP.Substring(234, 19).ToString() + "|" +
            TEMP.Substring(253,1).ToString() + "|" +
            TEMP.Substring(254,3).ToString() + "|" +
            TEMP.Substring(257,8).ToString();
            ARY.Enqueue(SUB);
        }
        return ARY;     
    }

    public Queue FinancialTransactionDivision(Queue STR)
    {
        Queue ARY = new Queue();
        String[] S;
        string TEMP = "";
        string SUB = "";
        while (STR.Count >= 1)
        {
            TEMP = "";
            TEMP = STR.Dequeue().ToString();
            SUB = TEMP.Substring(0, 2).ToString() + "|" +
            TEMP.Substring(2, 10).ToString() + "|" +
            TEMP.Substring(12, 2).ToString() + "|" +
            TEMP.Substring(14, 1).ToString() + "|" +
            TEMP.Substring(15, 17).ToString() + "|" +
            TEMP.Substring(32, 8).ToString() + "|" +
            TEMP.Substring(40, 3).ToString() + "|" +
            TEMP.Substring(43, 13).ToString() + "|" +
            TEMP.Substring(56, 15).ToString() + "|" +
            TEMP.Substring(71, 1).ToString();
            ARY.Enqueue(SUB);
        }
        return ARY;
    }



    public Queue RequestTracersDivision(Queue STR)
    {
        Queue ARY = new Queue();
        String[] S;
        string TEMP = "";
        string SUB = "";
        while (STR.Count >= 1)
        {
            TEMP = "";
            TEMP = STR.Dequeue().ToString();
            SUB = TEMP.Substring(0, 2).ToString() + "|" +
            TEMP.Substring(2, 10).ToString() + "|" +
            TEMP.Substring(12, 2).ToString() + "|" +
            TEMP.Substring(14, 17).ToString() + "|" +
            TEMP.Substring(31, 3).ToString() + "|" +
            TEMP.Substring(34, 2).ToString() + "|" +
            TEMP.Substring(36, 3).ToString() + "|";
            
            if (TEMP.Length > 39)
            { SUB = SUB + TEMP.Substring(39,TEMP.Length-39).ToString(); }
            else
            { SUB = SUB + "~"; }                       
            
            ARY.Enqueue(SUB);
        }
        return ARY;
    }



    public Queue TrailerDivision(Queue STR)
    {
        Queue ARY = new Queue();
        String[] S;
        string TEMP = "";

        string TEMP0 = "";
        string TEMP1 = "";
        string TEMP2 = "";
        string TEMP3 = "";
        string TEMP4 = "";


        string SUB = "";
        while (STR.Count >= 1)
        {
            TEMP = "";

            TEMP0 = "";
            TEMP1 = "";
            TEMP2 = "";
            TEMP3 = "";
            TEMP4 = "";

            TEMP = STR.Dequeue().ToString();
            SUB = TEMP.Substring(0, 2).ToString() + "|" +
            TEMP.Substring(2, 8).ToString() + "|" +
            TEMP.Substring(10, 2).ToString() + "|" +
            TEMP.Substring(12, 6).ToString() + "|" +
            TEMP.Substring(18, 2).ToString() + "|" +
            TEMP.Substring(20, 11).ToString() + "|" +
            TEMP.Substring(31, 3).ToString() + "|" +
            TEMP.Substring(34, 15).ToString() + "~" +

            TEMP.Substring(49, 3).ToString() + "|" +
            TEMP.Substring(52, 17).ToString() + "|" +
            TEMP.Substring(69, 15).ToString() + "~" +

            TEMP.Substring(84, 3).ToString() + "|" +
            TEMP.Substring(87, 17).ToString() + "|" +
            TEMP.Substring(104, 15).ToString() + "~" +

            TEMP.Substring(119, 3).ToString() + "|" +
            TEMP.Substring(122, 17).ToString() + "|" +
            TEMP.Substring(139, 15).ToString() + "~" +

            TEMP.Substring(154, 3).ToString() + "|" +
            TEMP.Substring(157, 17).ToString() + "|" +
            TEMP.Substring(174, 15).ToString() + "~" +
                        
            TEMP.Substring(189, 3).ToString() + "|" +
            TEMP.Substring(192, 17).ToString() + "|" +
            TEMP.Substring(209, 15).ToString() + "~"; 
            

            /*
            if (TEMP.Length > 84)
            {
             TEMP0 = TEMP.Substring(84, TEMP.Length - 84).ToString();
             if (TEMP0.Length == 140)
             {
              TEMP1 = TEMP0.Substring(0,35).ToString();
              TEMP2 = TEMP0.Substring(35,35).ToString();
              TEMP3 = TEMP0.Substring(70,35).ToString();
              TEMP4 = TEMP0.Substring(105,35).ToString();
             }
             else if (TEMP0.Length == 105)
             {
              TEMP1 = TEMP0.Substring(0, 35).ToString();
              TEMP2 = TEMP0.Substring(35, 35).ToString();
              TEMP3 = TEMP0.Substring(70, 35).ToString();              
             }
             else if (TEMP0.Length == 70)
             {
              TEMP1 = TEMP0.Substring(0, 35).ToString();
              TEMP2 = TEMP0.Substring(35, 35).ToString();                 
             }
             else if (TEMP0.Length == 35)
             {TEMP1 = TEMP0.Substring(0, 35).ToString();}
            }

            if (TEMP1.Length != 0)
            {
                TEMP0 = "";
                TEMP0 = TEMP1.Substring(0, 3) + "|" + TEMP1.Substring(3, 17) + "|" + TEMP1.Substring(18, 15);
                TEMP1 = TEMP0;
            }


            if (TEMP2.Length != 0)
            {
                TEMP0 = "";
                TEMP0 = TEMP2.Substring(0, 3) + "|" + TEMP2.Substring(3, 17) + "|" + TEMP2.Substring(18, 15);
                TEMP2 = TEMP0;
            }


            if (TEMP3.Length != 0)
            {
                TEMP0 = "";
                TEMP0 = TEMP3.Substring(0, 3) + "|" + TEMP3.Substring(3, 17) + "|" + TEMP3.Substring(18, 15);
                TEMP3 = TEMP0;
            }


            if (TEMP4.Length != 0)
            {
                TEMP0 = "";
                TEMP0 = TEMP4.Substring(0, 3) + "|" + TEMP4.Substring(3, 17) + "|" + TEMP4.Substring(18, 15);
                TEMP4 = TEMP0;
            }
            SUB = SUB +  TEMP1 + "~" + TEMP2 + "~" + TEMP3 + "~" + TEMP4;            
            */
            ARY.Enqueue(SUB);
        }
        return ARY;
    }




    



    



    //public Stack BatchHeaderDivision(string STR)    {}


    /**************************3RD PARTY PRINTING SYSTEM**********************************************/

    public DataSet Get_RPS_DRAFT_V11(string ID)
    {
        DataSet DS = new DataSet();
        DS = DataTransform.ReteriveDataMultiple("EXEC SP_PRINT_V11 " + ID , "GET_ALL_USER");
        return DS;
    }

    public DataSet Get_RPS_DRAFT_V12(string ID)
    {
        DataSet DS = new DataSet();
        DS = DataTransform.ReteriveDataMultiple("EXEC SP_PRINT_V12 " + ID , "GET_ALL_USER");
        return DS;
    }


    public void Get_PRINT_V11_CONFIRM(string ID)
    {
        DataSet DS = new DataSet();
        DS = DataTransform.ReteriveDataMultiple("EXEC SP_PRINT_V11_CONFIRM " + ID, "GET_ALL_USER");        
    }

    public DataSet Get_RPS_DRAFT_V11_COUNTER()
    {
        DataSet DS = new DataSet();
        DS = DataTransform.ReteriveDataMultiple("EXEC SP_RPS_DRAFT_V11_COUNTER", "GET_ALL_USER");
        return DS;
    }



    public DataSet Get_CUR_DRAFT_COUNTER(string DM, string AID)
    {
        DataSet DS = new DataSet();
        DS = DataTransform.ReteriveDataMultiple("EXEC SP_CUR_DRAFT_COUNTER " + DM + "," +  AID, "GET_ALL_USER");
        return DS;
    }


    public DataSet Get_SP_ActiveStationary()
    {
        DataSet DS = new DataSet();
        DS = DataTransform.ReteriveDataMultiple("EXEC SP_ActiveStationary ", "GET_ALL_USER");
        return DS;
    }


    public DataSet Get_STATIONARY_TRANSFER(string ID)
    {
        DataSet DS = new DataSet();
        DS = DataTransform.ReteriveDataMultiple("EXEC SP_STATIONARY_TRANSFER " + ID, "GET_ALL_USER");
        return DS;
    }

    public DataSet Get_RPS_OffsitePrintUpload()
    {
        DataSet DS = new DataSet();
        DS = DataTransform.ReteriveDataMultiple("EXEC SP_RPS_OffsitePrintUpload", "GET_ALL_USER");
        return DS;
    }


    public DataSet CK_Deuplicate(string FileName)
    {
        DataSet DS = new DataSet();
        DS = DataTransform.ReteriveDataMultiple("EXEC CK_RPS_OffsitePrintUpload_DUP " + "'" + FileName + "'", "GET_ALL_USER");
        return DS;
    }


    public void SP_SET_INSERT_RPS_OffsitePrintUpload(string FileName, string DownloadSeries, string DownloadDate, string DownloadTime, string DraftCount)
    {
        DataSet DS = new DataSet();
        DS = DataTransform.ReteriveDataMultiple("EXEC SP_SET_INSERT_RPS_OffsitePrintUpload '" + FileName + "'," + DownloadSeries + ",'" + DownloadDate + "','" + DownloadTime + "'," + DraftCount, "GET_ALL_USER");        
    }


    public void RPS_DRAFT_V11_UPDATE(string IDD, string UID, string UCODE, string StationSeries, string STrack)
    {
        DataSet DS = new DataSet();
        DS = DataTransform.ReteriveDataMultiple("EXEC SP_RPS_DRAFT_V11_UPDATE " + IDD + "," + UID + ",'" + UCODE + "'," + StationSeries + "," + STrack, "GET_ALL_USER");
    }



    public String SP_FILE_PATH(string ID)
    {
        DataSet DS = new DataSet();
        DS = DataTransform.ReteriveDataMultiple("SELECT FTP_PATH FROM FTP_SETUP WHERE ID=" + ID  ,"GET_ALL_USER");
        return DS.Tables[0].Rows[0][0].ToString();
    }



    public DataSet RPS_SP_POD_GetAllForSend(string CourierID, string CorrID, string EXEDate)
    {
        DataSet DS = new DataSet();
        DS = DataTransform.ReteriveDataMultiple("EXEC RPS_SP_POD_GetAllForSend " + CourierID + "," + CorrID + ",'" + EXEDate.ToString()   + "'", "GET_ALL_USER");
        return DS;
    }



    public DataSet SP_Draft_GetAllForCorrBnkDwnld(string CorrID, string EXEDate)
    {
        DataSet DS = new DataSet();
        DS = DataTransform.ReteriveDataMultiple("EXEC SP_Draft_GetAllForCorrBnkDwnld " + CorrID + ",'" + EXEDate.ToString() + "'", "GET_ALL_USER");
        return DS;
    }



    public DataSet RPS_SP_CorrespondingBankFilesPath(string CorrID)
    {
        DataSet DS = new DataSet();
        DS = DataTransform.ReteriveDataMultiple("EXEC RPS_SP_CorrespondingBankFilesPath_GetByCorrespondingBankId " + CorrID , "GET_ALL_USER");
        return DS;
    }



    public string SP_GetFileName(string FileName)
    {
        DataSet DS = new DataSet();
        DS = DataTransform.ReteriveDataMultiple("EXEC SP_GetFileName '" + FileName + "'", "GET_ALL_USER");
        return DS.Tables[0].Rows[0][0].ToString();
    }




    /**************************3RD PARTY PRINTING SYSTEM**********************************************/









    
}

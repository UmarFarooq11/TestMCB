using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OracleClient;

    public class TABLE_RPS_MoneyGramRemittance : IRPS_MoneyGramRemittance
    {
       DatabaseConnection_Util DataTransform = new DatabaseConnection_Util();

        private DataSet RPS_MoneyGramRemittance_DATASET = new DataSet();

        private DataRow DR;
        private string PrincipleBankID;
        private string CoverAmountUSD;
        private string TransactionAmount;
        private string TransactionRefNo;
        private string IncomingBeneficiaryID;
        private string IncomingRemittanceID;
        private string IncomingRemitterID;
        private string IncomingBatchHeaderID;
        private string RemitterID;
        private string RemitterAccountNo;
        private string FirstName;
        private string MiddleName;
        private string LastName;
        private string TelephoneNo ;
        private string Country;
        private string BeneficiaryFirstName;
        private string BeneficiaryMiddleName;
        private string BeneficiaryLastName;
        private string Address1;
        private string Address2;
        private string AccountNo;  
        private string City;
        private string BeneficiaryTelephoneNo;
        private string NICNo;
        private string BeneficiaryZipCode;
        private string A_UserID;
        private string A_DateTime;
        private string E_UserID;
        private string E_DateTime;
        private string IncomingBeneficiaryID1;
        private string IncomingRemittanceID1;
        private string IncomingRemitterID1;
  
        public TABLE_RPS_MoneyGramRemittance()
        {
          //RPS_MoneyGramRemittance_DATASET = DataTransform.ReteriveDataMultiple
          //        ("EXEC SP_GET_TABLE_STRUCT RPS_MoneyGramRemittance","NEW_USER_INFO");


            OracleParameter[] PR = new OracleParameter[2];
            PR[0] = DataTransform.Oracle_Param("P_TABLE_NAME", OracleType.VarChar, ParameterDirection.Input, "RPS_MoneyGramRemittance");
            PR[1] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
            RPS_MoneyGramRemittance_DATASET = DataTransform.Oracle_GetDataSetSP("SP_GET_TABLE_STRUCT", PR);

        }

        public void RecordInputStart()
        {DR = RPS_MoneyGramRemittance_DATASET.Tables[0].NewRow();}

        public void RecordInputCommit()
        { RPS_MoneyGramRemittance_DATASET.Tables[0].Rows.Add(DR); }

        public DataSet ReturnResultSet()
        { return RPS_MoneyGramRemittance_DATASET; }

        public void ClearTable()
        { RPS_MoneyGramRemittance_DATASET.Tables[0].Rows.Clear(); }

        public string Get_PrincipleBankID
        {
            set
            {
                PrincipleBankID = value;
                DataTransform.DataPlacement("PrincipleBankID", PrincipleBankID, RPS_MoneyGramRemittance_DATASET, DR);
            }
        }

        public string Get_CoverAmountUSD
        {
            set
            {
                CoverAmountUSD = value;
                DataTransform.DataPlacement("CoverAmountUSD", CoverAmountUSD, RPS_MoneyGramRemittance_DATASET, DR);
            }
        }

        public string Get_TransactionAmount
        {
            set
            {
                TransactionAmount = value;
                DataTransform.DataPlacement("TransactionAmount", TransactionAmount, RPS_MoneyGramRemittance_DATASET, DR);
            }
        }

        public string Get_TransactionRefNo
        {
            set
            {
                TransactionRefNo = value;
                DataTransform.DataPlacement("TransactionRefNo", TransactionRefNo, RPS_MoneyGramRemittance_DATASET, DR);
            }
        }

        public string Get_IncomingBeneficiaryID
        {
            set
            {
                IncomingBeneficiaryID = value;
                DataTransform.DataPlacement("IncomingBeneficiaryID", IncomingBeneficiaryID, RPS_MoneyGramRemittance_DATASET, DR);
            }
        }

        public string Get_IncomingRemittanceID
        {
            set
            {
                IncomingRemittanceID = value;
                DataTransform.DataPlacement("IncomingRemittanceID", IncomingRemittanceID, RPS_MoneyGramRemittance_DATASET, DR);
            }
        }
        
        public string Get_IncomingRemitterID
        {
            set
            {
                IncomingRemitterID = value;
                DataTransform.DataPlacement("IncomingRemitterID", IncomingRemitterID, RPS_MoneyGramRemittance_DATASET, DR);
            }
        }
         
       public string Get_IncomingBatchHeaderID
        {
            set
            {
                IncomingBatchHeaderID = value;
                DataTransform.DataPlacement("IncomingBatchHeaderID", IncomingBatchHeaderID, RPS_MoneyGramRemittance_DATASET, DR);
            }
        }

        public string Get_RemitterID
        {
            set
            {
                RemitterID = value;
                DataTransform.DataPlacement("RemitterID", RemitterID, RPS_MoneyGramRemittance_DATASET, DR);
            }
        }

        public string Get_RemitterAccountNo
        {
            set
            {
                RemitterAccountNo = value;
                DataTransform.DataPlacement("RemitterAccountNo", RemitterAccountNo, RPS_MoneyGramRemittance_DATASET, DR);
            }
        }

        public string Get_FirstName
        {
            set
            {
                FirstName = value;
                DataTransform.DataPlacement("FirstName", FirstName, RPS_MoneyGramRemittance_DATASET, DR);
            }
        }

        public string Get_MiddleName
        {
            set
            {
                MiddleName = value;
                DataTransform.DataPlacement("MiddleName", MiddleName, RPS_MoneyGramRemittance_DATASET, DR);
            }
        }
        
             
        public string Get_LastName
        {
            set
            {
                LastName = value;
                DataTransform.DataPlacement("LastName", LastName, RPS_MoneyGramRemittance_DATASET, DR);
            }
        } 
           
        public string Get_TelephoneNo
        {
            set
            {
                TelephoneNo = value;
                DataTransform.DataPlacement("TelephoneNo", TelephoneNo, RPS_MoneyGramRemittance_DATASET, DR);
            }
        }

        public string Get_Country
        {
            set
            {
                Country = value;
                DataTransform.DataPlacement("Country", Country, RPS_MoneyGramRemittance_DATASET, DR);
            }
        } 
       
        public string Get_BeneficiaryFirstName
        {
            set
            {
                BeneficiaryFirstName = value;
                DataTransform.DataPlacement("BeneficiaryFirstName", BeneficiaryFirstName, RPS_MoneyGramRemittance_DATASET, DR);
            }
        } 

         public string Get_BeneficiaryMiddleName
        {
            set
            {
                BeneficiaryMiddleName = value;
                DataTransform.DataPlacement("BeneficiaryMiddleName", BeneficiaryMiddleName, RPS_MoneyGramRemittance_DATASET, DR);
            }
        }
        
        public string Get_BeneficiaryLastName
        {
            set
            {
                BeneficiaryLastName = value;
                DataTransform.DataPlacement("BeneficiaryLastName", BeneficiaryLastName, RPS_MoneyGramRemittance_DATASET, DR);
            }
        } 
            
         public string Get_Address1
        {
            set
            {
                Address1 = value;
                DataTransform.DataPlacement("Address1", Address1, RPS_MoneyGramRemittance_DATASET, DR);
            }
        } 
         
        public string Get_Address2
        {
            set
            {
                Address2 = value;
                DataTransform.DataPlacement("Address2", Address2, RPS_MoneyGramRemittance_DATASET, DR);
            }
        } 
        
        public string Get_AccountNo
        {
            set
            {
                AccountNo = value;
                DataTransform.DataPlacement("AccountNo", AccountNo, RPS_MoneyGramRemittance_DATASET, DR);
            }
        }   
        
        public string Get_City
        {
            set
            {
                City = value;
                DataTransform.DataPlacement("City", City, RPS_MoneyGramRemittance_DATASET, DR);
            }
        }   

        public string Get_BeneficiaryTelephoneNo
        {
            set
            {
                BeneficiaryTelephoneNo = value;
                DataTransform.DataPlacement("BeneficiaryTelephoneNo", BeneficiaryTelephoneNo, RPS_MoneyGramRemittance_DATASET, DR);
            }
        }   

         public string Get_NICNo
        {
            set
            {
                NICNo = value;
                DataTransform.DataPlacement("NICNo", NICNo, RPS_MoneyGramRemittance_DATASET, DR);
            }
        }


        public string Get_BeneficiaryZipCode
        {
            set
            {
                BeneficiaryZipCode = value;
                DataTransform.DataPlacement("BeneficiaryZipCode", BeneficiaryZipCode, RPS_MoneyGramRemittance_DATASET, DR);
            }
        }

        public string Get_A_UserID
        {
            set
            {
                A_UserID = value;
                DataTransform.DataPlacement("A_UserID", A_UserID, RPS_MoneyGramRemittance_DATASET, DR);
            }
        }

        public string Get_A_DateTime
        {
            set
            {
                A_DateTime = value;
                DataTransform.DataPlacement("A_DateTime", A_DateTime, RPS_MoneyGramRemittance_DATASET, DR);
            }
        }

        public string Get_E_UserID
        {
            set
            {
                E_UserID = value;
                DataTransform.DataPlacement("E_UserID", E_UserID, RPS_MoneyGramRemittance_DATASET, DR);
            }
        }

        public string Get_E_DateTime
        {
            set
            {
                E_DateTime = value;
                DataTransform.DataPlacement("E_DateTime", E_DateTime, RPS_MoneyGramRemittance_DATASET, DR);
            }
        }

        public string Get_IncomingBeneficiaryID1
        {
            set
            {
                IncomingBeneficiaryID1 = value;
                DataTransform.DataPlacement("IncomingBeneficiaryID1", IncomingBeneficiaryID1, RPS_MoneyGramRemittance_DATASET, DR);
            }
        }

        public string Get_IncomingRemittanceID1
        {
            set
            {
                IncomingRemittanceID1 = value;
                DataTransform.DataPlacement("IncomingRemittanceID1", IncomingRemittanceID1, RPS_MoneyGramRemittance_DATASET, DR);
            }
        }

        public string Get_IncomingRemitterID1
        {
            set
            {
                IncomingRemitterID1 = value;
                DataTransform.DataPlacement("IncomingRemitterID1", IncomingRemitterID1, RPS_MoneyGramRemittance_DATASET, DR);
            }
        }
    }

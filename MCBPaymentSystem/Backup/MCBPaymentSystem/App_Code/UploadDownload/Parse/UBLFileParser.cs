using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Office.Interop.Excel;
using System.Data;
using System.IO;
using ENTITIES;

namespace PARSERS
{
    public class UBLFileParser //: CorrespondingBankFileParser
    {

        string filePath = string.Empty;
        int correspondingBankId;
        //CBFileDataDataManager fileDataManager;
        string user;
        List<CBFileDataCommand> fileDataCmdList = new List<CBFileDataCommand>();

        LOV_COLLECTION lov = new LOV_COLLECTION();
        DataSet dstable = new DataSet();

        public UBLFileParser(string filePath, string user, int correspondingBankId)
        {
            this.filePath = filePath;
            this.correspondingBankId = correspondingBankId;
            this.user = user;
            
            //fileDataManager = RuntimeClassLoader.GetDataManager("CBFileData") as CBFileDataDataManager;
        }

        public void Parse()
        {
            ApplicationClass app;
            Workbook workbook = null;
            try
            {
                app = new Microsoft.Office.Interop.Excel.ApplicationClass();
                workbook = app.Workbooks.Open(filePath,
                    0,
                    true,
                    5,
                    "",
                    "",
                    true,
                    Microsoft.Office.Interop.Excel.XlPlatform.xlWindows,
                    "\t",
                    false,
                    false,
                    0,
                    true,
                    1,
                    0);
                Worksheet workSheet = (Worksheet)workbook.Sheets["Citi"];
                int row = 6;
                string dat = ((Range)workSheet.Cells[row, 1]).Value2.ToString().Trim();
                while (dat != String.Empty)
                {
                    CBFileDataCommand cmd = new CBFileDataCommand();
                    string date = GetValue(((Range)workSheet.Cells[row, 2]));
                    if (date.Length > 0)
                        date = date.Substring(0, date.Length - 1);
                    cmd.ProcessingDate = GetDate(date);
                    cmd.CorrespondingBankUniqueId = GetValue(((Range)workSheet.Cells[row, 3]));
                    cmd.DraftNo = GetValue(((Range)workSheet.Cells[row, 4]));
                    cmd.DraftPaidDate = GetDate(((Range)workSheet.Cells[row, 5]).Text.ToString());
                    cmd.BeneficiaryName = GetValue(((Range)workSheet.Cells[row, 6]));
                    cmd.Amount = ConvertToDouble(GetValue(((Range)workSheet.Cells[row, 7])));
                    cmd.ProcessingRemarks = GetValue(((Range)workSheet.Cells[row, 8]));
                    cmd.BranchCode = GetValue(((Range)workSheet.Cells[row, 9]));
                    cmd.Charges = ConvertToDouble(GetValue(((Range)workSheet.Cells[row, 10])));
                    cmd.Remarks = GetValue(((Range)workSheet.Cells[row, 11]));
                    cmd.Type = GetValue(((Range)workSheet.Cells[row, 12]));
                    cmd.TEZStatus = GetValue(((Range)workSheet.Cells[row, 13]));
                    cmd.TCSNo = GetValue(((Range)workSheet.Cells[row, 14]));
                    cmd.DispatchDate = GetDate(GetValue(((Range)workSheet.Cells[row, 15])));
                    cmd.DeliveryDate = GetDate(GetValue(((Range)workSheet.Cells[row, 16])));
                    cmd.RecievedBy = GetValue(((Range)workSheet.Cells[row, 17]));
                    cmd.E_UserId = user;
                    cmd.E_DateTime = DateTime.Now;
                    fileDataCmdList.Add(cmd);
                    row++;
                    dat = GetValue(((Range)workSheet.Cells[row, 1]));
                }
            }
            finally
            {
                workbook.Close(false, filePath, false);
            }
        }
        private string GetValue(Range range)
        {
            if (range.Value2 != null)
                return range.Value2.ToString().Trim();
            else
                return string.Empty;
        }
        private double ConvertToDouble(string val)
        {
            if (val.Trim() == string.Empty)
                return 0;
            else
                return Convert.ToDouble(val);
        }
        private DateTime GetDate(string date)
        {
            if (date.Trim() != string.Empty)
            {
                return Convert.ToDateTime(date);
            }
            else
                //return Convert.ToDateTime(DateTime.MinValue);
                return Convert.ToDateTime("1/1/1900");
        }
        public DataSet SaveDataToDb()
        {
            return this.Add(fileDataCmdList, GetFileName(), user, correspondingBankId);
        }

        public DataSet Get_RPS_SP_CorrespondingBankFilesId()
        {
            DatabaseConnection_Util DataTransform = new DatabaseConnection_Util();
            DataSet DS = new DataSet();
            DS = DataTransform.ReteriveDataMultiple("select max(ID) from RPS_CorrespondingBankFile", "GET_ALL_USER");
            return DS;
        }


        public DataSet Add(List<CBFileDataCommand> fileDataCmdList, string fileName, string userId, int correspondingBankId)
        {
            DataSet dst = new DataSet();
            
            LOV_COLLECTION lov = new LOV_COLLECTION();
            dst = lov.Get_RPS_SP_CorrespondingBankFile_Add(0, correspondingBankId, fileName, DateTime.Now, userId, DateTime.Now, "", DateTime.MinValue);

            dst = Get_RPS_SP_CorrespondingBankFilesId();
          
            foreach (CBFileDataCommand cmd in fileDataCmdList)
            {
                lov.Get_RPS_SP_CorrespondingBankFileData_Add(cmd.Id, Convert.ToInt32(dst.Tables[0].Rows[0][0].ToString()), cmd.CorrespondingBankUniqueId, cmd.ProcessingDate, cmd.DraftNo, cmd.DraftPaidDate, cmd.BeneficiaryName, cmd.Amount, cmd.ProcessingRemarks, cmd.BranchCode, cmd.Charges, cmd.Remarks, cmd.Type, cmd.TEZStatus, cmd.TCSNo, cmd.DispatchDate, cmd.DeliveryDate, cmd.RecievedBy, cmd.A_UserId, cmd.A_DateTime, cmd.E_UserId, cmd.E_DateTime);
            }

            return dst;
        }
        
        
        private string GetFileName()
        {
            string fileName = filePath.Substring(filePath.LastIndexOf("\\") + 1);
            //fileName = fileName.Substring(0, fileName.IndexOf("."));
            return fileName;
        }
    }
}

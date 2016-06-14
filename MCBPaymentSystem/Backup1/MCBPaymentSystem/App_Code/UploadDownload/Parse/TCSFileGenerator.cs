using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.IO;

/*****************************************************************
  Form Name:  TCSFileGenerator
  Form Description: <The form maintains CorrespondentBankSetup>
  Created By: 
  Created Date: 
  Version No: 1.0
  Modification: Development of the form              
  Modified By: Shamraiz Ahmad
  Modification Date: 25-10-2007
*****************************************************************/

namespace PARSERS
{
    public class TCSFileGenerator //: CourierFileGenerator
    {
        int correspondingBankId;
        string userId;
        int courierID;
        string abbriviation;
        DataSet correspondingBanks;
        DataSet couriers;
        DateTime creationDateTime;
        //PODDataManager podDataManager;
        public bool dataFound = false;
        private string filePath;
        LOV_COLLECTION lov = new LOV_COLLECTION();
        bool isFileGenerated = false;
        DataSet dstable = new DataSet();

        public TCSFileGenerator(string userId, int correspondingBankId, string abbriviation, DataSet correspondingBanks, DateTime creationDateTime, int courierID, DataSet couriers)
        {
            this.correspondingBankId = correspondingBankId;
            this.creationDateTime = creationDateTime;
            this.userId = userId;
            this.correspondingBanks = correspondingBanks;
            this.abbriviation = abbriviation;
            this.courierID = courierID;
            this.couriers = couriers;
            //podDataManager = RuntimeClassLoader.GetDataManager("POD") as PODDataManager;

        }
        private string ConstructRecord(DataRow drw)
        {
            string record = string.Empty;
            for (int i = 0; i < drw.Table.Columns.Count; i++)
            {
                record += drw[i] + "|";
            }
            record = record.Substring(0, record.Length - 1);
            return record;
        }
        private string GetMonthYear(DateTime date)
        {
            return date.Day.ToString().PadLeft(2, '0') + date.Month.ToString().PadLeft(2, '0') + date.Year.ToString().Substring(2, 2).PadLeft(2, '0');
        }
        public bool GenerateData()
        {
            string records = string.Empty;
            string fileName = string.Empty;
            int menifestID = 0;
            this.dataFound = false;

            if (couriers == null)
            {
                // DataFilesDataManager df = new DataFilesDataManager();
                
                dstable = lov.Get_RPS_SP_CourierFilesPath_GetByCourierId(courierID);
                //Result rst = df.GetCourierFilesPath(this.courierID);
                if (dstable.Tables[0].Rows.Count < 1)
                {
                    throw new ApplicationException("FILE_PATH_NOT_PRESENT_MESSAGE");
                }


                filePath = dstable.Tables[0].Rows[0]["AWBDownloadPath"].ToString();

                if (correspondingBanks == null)
                {
                    dstable = lov.Get_RPS_SP_POD_GetAllForSend(courierID, correspondingBankId, creationDateTime);
                    //rst = podDataManager.GetAllPODForDataSend(courierID, correspondingBankId, creationDateTime);
                    if (dstable.Tables[0].Rows.Count < 1)
                    {
                        throw new ApplicationException("FILE_RECORDS_NOT_AVAILABLE_MESSAGE");
                    }

                    DataTable dtlCourierData = dstable.Tables[0].Copy();

                    menifestID = Convert.ToInt32(dstable.Tables[0].Rows[0]["MenifestID"]);

                    dtlCourierData.Columns.Remove("PODID");
                    dtlCourierData.Columns.Remove("MenifestNo");
                    dtlCourierData.Columns.Remove("MenifestID");

                    foreach (DataRow drw in dtlCourierData.Rows)
                    {
                        this.dataFound = true;
                        records += ConstructRecord(drw) + Environment.NewLine;
                    }

                    if (this.dataFound)
                    {
                        fileName = GetMonthYear(creationDateTime) + ".man";

                        StreamWriter sw = new StreamWriter(filePath + "\\" + fileName);
                        sw.Write(records);
                        sw.Flush();
                        sw.Close();
                    }

                    if (menifestID == 0)
                    {
                        DataSet dsMenifest = new DataSet();

                        //Result rst1 = podDataManager.AddMenifest(rst.dstResult.Tables[0].Rows[0]["MenifestNo"].ToString(),
                       
                        dsMenifest = lov.Get_RPS_SP_CourierMenifest_Add(dstable.Tables[0].Rows[0]["MenifestNo"].ToString(),
                            fileName, courierID, correspondingBankId, userId);
                        
                        if (dsMenifest.Tables[0].Rows .Count < 1)
                        {
                            File.Delete(filePath + "\\" + fileName);
                            return false;
                        }
                        DataTable dtl = dstable.Tables[0];
                        DataRow drw;
                        foreach (DataRow dr in dtl.Rows)
                        {
                            drw = dstable.Tables[0].NewRow();

                            drw["ID"] = dr["PODID"];
                            drw["MenifestID"] = dsMenifest.Tables[0].Rows[0][0];

                            dsMenifest = lov.Get_RPS_SP_POD_UpdateMenifestID((int)drw["ID"], (int)drw["MenifestID"]);


                        }


                        //rst1 = podDataManager.UpdateMenifestID(rst.dstResult.Tables[0], (int)rst1.hstOutParams["RPS_CourierMenifest.ID0"]);
                        if (dstable.Tables[0].Rows.Count < 1)
                        {
                            File.Delete(filePath + "\\" + fileName);
                            return false;
                        }
                    }
                    return true;

                }
                else
                {
                    

                    foreach (DataRow bank in correspondingBanks.Tables[0].Rows)
                    {

                        correspondingBankId = (int)bank["ID"];
                        
                        //rst = podDataManager.GetAllPODForDataSend(courierID, correspondingBankId, creationDateTime);
                        dstable = lov.Get_RPS_SP_POD_GetAllForSend(courierID, correspondingBankId, creationDateTime);
                        try
                        {
                            if (dstable.Tables[0].Rows.Count < 1)
                                continue;

                            DataTable dtlCourierData = dstable.Tables[0].Copy();

                            menifestID = Convert.ToInt32(dstable.Tables[0].Rows[0]["MenifestID"]);

                            dtlCourierData.Columns.Remove("PODID");
                            dtlCourierData.Columns.Remove("MenifestNo");
                            dtlCourierData.Columns.Remove("MenifestID");

                            foreach (DataRow drw in dtlCourierData.Rows)
                            {
                                records += ConstructRecord(drw) + Environment.NewLine;
                                this.dataFound = true;
                            }

                            if (dataFound)
                            {
                                fileName = GetMonthYear(creationDateTime) + ".man";
                                StreamWriter sw = new StreamWriter(filePath + "\\" + fileName);

                                sw.Write(records);
                                sw.Flush();
                                sw.Close();
                            }

                            if (menifestID == 0)
                            {
                                /*
                                Result rst1 = podDataManager.AddMenifest(rst.dstResult.Tables[0].Rows[0]["MenifestNo"].ToString(),
                                    fileName, courierID, correspondingBankId, userId);
                                if (!rst1.isSuccessful)
                                {
                                    File.Delete(filePath + "\\" + fileName);
                                    return false;
                                }
                                rst1 = podDataManager.UpdateMenifestID(rst.dstResult.Tables[0], (int)rst1.hstOutParams["RPS_CourierMenifest.ID0"]);
                                 * */
                                DataSet dsMenifest =new DataSet ();
                        dsMenifest = lov.Get_RPS_SP_CourierMenifest_Add(dstable.Tables[0].Rows[0]["MenifestNo"].ToString(),
                            fileName, courierID, correspondingBankId, userId);
                        if (dsMenifest.Tables[0].Rows .Count < 1)
                        {
                            File.Delete(filePath + "\\" + fileName);
                            return false;
                        }
                        DataTable dtl = dstable.Tables[0];
                        DataRow drw;
                        foreach (DataRow dr in dtl.Rows)
                        {
                            drw = dstable.Tables[0].NewRow();

                            drw["ID"] = dr["PODID"];
                            drw["MenifestID"] = dsMenifest.Tables[0].Rows[0][0];

                            dsMenifest = lov.Get_RPS_SP_POD_UpdateMenifestID((int)drw["ID"], (int)drw["MenifestID"]);


                        }


                        //rst1 = podDataManager.UpdateMenifestID(rst.dstableResult.Tables[0], (int)rst1.hstOutParams["RPS_CourierMenifest.ID0"]);
                        if (dstable.Tables[0].Rows.Count < 1)
                        {
                            File.Delete(filePath + "\\" + fileName);
                            return false;
                        }                            }

                            isFileGenerated = true;

                        }
                        catch (Exception ex)
                        {
                            return false;
                        }
                    }


                }
                if (isFileGenerated && dataFound)
                {
                    return true;
                }
                else
                    throw new ApplicationException("FILE_RECORDS_NOT_AVAILABLE_MESSAGE");


            }


            else
            {
                bool isFileGenerated = false;

                foreach (DataRow courier in couriers.Tables[0].Rows)
                {

                    courierID = (int)courier["ID"];
                    DataSet ds = new DataSet();
                    dstable = lov.Get_RPS_SP_CourierFilesPath_GetByCourierId(this.courierID);
                    //Result rst = df.GetCourierFilesPath(this.courierID);
                    if (dstable.Tables[0].Rows.Count < 1)
                    {
                        throw new ApplicationException("FILE_PATH_NOT_PRESENT_MESSAGE");
                    }
                    filePath = dstable.Tables[0].Rows[0]["SendFilePath"].ToString();

                    if (correspondingBanks == null)
                    {
                        dstable = lov.Get_RPS_SP_POD_GetAllForSend(courierID, correspondingBankId, creationDateTime);
                        //rst = podDataManager.GetAllPODForDataSend(courierID, correspondingBankId, creationDateTime);
                        if (dstable.Tables[0].Rows.Count < 1)
                        {
                            throw new ApplicationException("FILE_RECORDS_NOT_AVAILABLE_MESSAGE");
                        }

                        DataTable dtlCourierData = dstable.Tables[0].Copy();

                        menifestID = Convert.ToInt32(dstable.Tables[0].Rows[0]["MenifestID"]);

                        dtlCourierData.Columns.Remove("PODID");
                        dtlCourierData.Columns.Remove("MenifestNo");
                        dtlCourierData.Columns.Remove("MenifestID");

                        foreach (DataRow drw in dtlCourierData.Rows)
                        {
                            this.dataFound = true;
                            records += ConstructRecord(drw) + Environment.NewLine;
                        }

                        if (this.dataFound)
                        {
                            fileName = GetMonthYear(creationDateTime) + ".man";

                            StreamWriter sw = new StreamWriter(filePath + "\\" + fileName);
                            sw.Write(records);
                            sw.Flush();
                            sw.Close();
                        }

                        if (menifestID == 0)
                        {
                            DataSet dsMenifest = new DataSet();

                            //Result rst1 = podDataManager.AddMenifest(rst.dstResult.Tables[0].Rows[0]["MenifestNo"].ToString(),

                            dsMenifest = lov.Get_RPS_SP_CourierMenifest_Add(dstable.Tables[0].Rows[0]["MenifestNo"].ToString(),
                                        fileName, courierID, correspondingBankId, userId);
                            if (dsMenifest.Tables[0].Rows.Count < 1)
                            {
                                File.Delete(filePath + "\\" + fileName);
                                return false;
                            }
                            DataTable dtl = dstable.Tables[0];
                            DataRow drw;
                            foreach (DataRow dr in dtl.Rows)
                            {
                                drw = dstable.Tables[0].NewRow();

                                drw["ID"] = dr["PODID"];
                                drw["MenifestID"] =  dsMenifest.Tables[0].Rows[0];

                                dsMenifest = lov.Get_RPS_SP_POD_UpdateMenifestID((int)drw["ID"], (int)drw["MenifestID"]);


                            }


                            //rst1 = podDataManager.UpdateMenifestID(rst.dstResult.Tables[0], (int)rst1.hstOutParams["RPS_CourierMenifest.ID0"]);
                            if (dstable.Tables[0].Rows.Count < 1)
                            {
                                File.Delete(filePath + "\\" + fileName);
                                return false;
                            }
                        }
                        isFileGenerated = true;

                    }
                    else
                    {
                        foreach (DataRow bank in correspondingBanks.Tables[0].Rows)
                        {

                            correspondingBankId = (int)bank["ID"];
                            
                            dstable = lov.Get_RPS_SP_CourierFilesPath_GetByCourierId(this.courierID);
                            //Result rst = df.GetCourierFilesPath(this.courierID);
                            if (dstable.Tables[0].Rows.Count < 1)
                            {
                                throw new ApplicationException("FILE_PATH_NOT_PRESENT_MESSAGE");
                            }
                            filePath = dstable.Tables[0].Rows[0]["SendFilePath"].ToString();

                            if (correspondingBanks == null)
                            {
                                dstable = lov.Get_RPS_SP_POD_GetAllForSend(courierID, correspondingBankId, creationDateTime);
                                //rst = podDataManager.GetAllPODForDataSend(courierID, correspondingBankId, creationDateTime);
                                if (dstable.Tables[0].Rows.Count < 1)
                                {
                                    throw new ApplicationException("FILE_RECORDS_NOT_AVAILABLE_MESSAGE");
                                }

                                DataTable dtlCourierData = dstable.Tables[0].Copy();

                                menifestID = Convert.ToInt32(dstable.Tables[0].Rows[0]["MenifestID"]);

                                dtlCourierData.Columns.Remove("PODID");
                                dtlCourierData.Columns.Remove("MenifestNo");
                                dtlCourierData.Columns.Remove("MenifestID");

                                foreach (DataRow drw in dtlCourierData.Rows)
                                {
                                    this.dataFound = true;
                                    records += ConstructRecord(drw) + Environment.NewLine;
                                }

                                if (this.dataFound)
                                {
                                    fileName = GetMonthYear(creationDateTime) + ".man";

                                    StreamWriter sw = new StreamWriter(filePath + "\\" + fileName);
                                    sw.Write(records);
                                    sw.Flush();
                                    sw.Close();
                                }

                                if (menifestID == 0)
                                {
                                    DataSet dsMenifest = new DataSet();

                                    //Result rst1 = podDataManager.AddMenifest(rst.dstResult.Tables[0].Rows[0]["MenifestNo"].ToString(),
                                    
                                    dsMenifest = lov.Get_RPS_SP_CourierMenifest_Add(dstable.Tables[0].Rows[0]["MenifestNo"].ToString(),
                                        fileName, courierID, correspondingBankId, userId);
                                    if (dsMenifest.Tables[0].Rows.Count< 1)
                                    {
                                        File.Delete(filePath + "\\" + fileName);
                                        return false;
                                    }
                                    DataTable dtl = dstable.Tables[0];
                                    DataRow  drw ;
                                    foreach (DataRow dr in dtl.Rows)
                                    {
                                        drw = dstable.Tables[0].NewRow();

                                        drw["ID"] = dr["PODID"];
                                        drw["MenifestID"] = dsMenifest.Tables [0].Rows[0];

                                        dsMenifest = lov.Get_RPS_SP_POD_UpdateMenifestID((int)drw["ID"], (int)drw["MenifestID"]);


                                    }


                                    //rst1 = podDataManager.UpdateMenifestID(rst.dstResult.Tables[0], (int)rst1.hstOutParams["RPS_CourierMenifest.ID0"]);
                                    if (dstable.Tables[0].Rows.Count < 1)
                                    {
                                        File.Delete(filePath + "\\" + fileName);
                                        return false;
                                    }
                                }
                                isFileGenerated = true;

                            }
                            else
                                return false;

                        }
                    }
                }

                if (isFileGenerated && dataFound)
                {
                    return true;
                }
                else
                    throw new ApplicationException("FILE_RECORDS_NOT_AVAILABLE_MESSAGE");
            }
        }
    }
}

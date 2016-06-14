
using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.OracleClient;

public class LOV_COLLECTION
{
    DatabaseConnection_Util DataTransform = new DatabaseConnection_Util();
    DataSet DS = new DataSet();

    public DataSet Get_CMN_Country_ALL(string SBPCode, string CountryName)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_CMN_Country_ALL '" + SBPCode + "','" + CountryName + "'", "GET_ALL_USER");
        //return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[3];
        PR[0] = DataTransform.Oracle_Param("v_SBPCode", OracleType.VarChar, ParameterDirection.Input, SBPCode);
        PR[1] = DataTransform.Oracle_Param("v_CountryName", OracleType.VarChar, ParameterDirection.Input, CountryName);
        PR[2] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_CMN_Country_ALL", PR);
        return DS;
    }

    public DataSet Get_CMN_Country_SPC(string ID)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_CMN_Country_SPC " + ID + " , '" + DATA_RESULTSET + "'", "GET_ALL_USER");
        //return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("v_ID", OracleType.VarChar, ParameterDirection.Input, ID);
        PR[1] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_CMN_Country_SPC", PR);
        return DS;


    }

    public DataSet Get_CMN_Province_ALL(string SBPCode, string CountryName, string ProvinceCode, string ProvinceName)
    {
        // DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_CMN_Province_ALL '" + ProvinceCode + "','" + ProvinceName + "','" + SBPCode + "','" + CountryName + "'", "GET_ALL_USER");
        //return DS;


        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[5];
        PR[0] = DataTransform.Oracle_Param("v_SBPCode", OracleType.VarChar, ParameterDirection.Input, SBPCode);
        PR[1] = DataTransform.Oracle_Param("v_CountryName", OracleType.VarChar, ParameterDirection.Input, CountryName);
        PR[2] = DataTransform.Oracle_Param("v_ProvinceCode", OracleType.VarChar, ParameterDirection.Input, ProvinceCode);
        PR[3] = DataTransform.Oracle_Param("v_ProvinceName", OracleType.VarChar, ParameterDirection.Input, ProvinceName);
        PR[4] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_CMN_Province_ALL", PR);
        return DS;


    }

    public DataSet Get_CMN_Province_SPC(string ID)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_CMN_Province_SPC " + ID, "GET_ALL_USER");
        //return DS;
        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("v_ID", OracleType.VarChar, ParameterDirection.Input, ID);
        PR[1] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_CMN_Province_SPC", PR);
        return DS;


    }

    public DataSet Get_CMN_District_ALL(string DistrictCode, string DistrictName, string ProvinceName)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_CMN_District_ALL '" + DistrictCode + "','" + DistrictName + "','" + ProvinceName + "'", "GET_ALL_USER");
        //return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[4];
        PR[0] = DataTransform.Oracle_Param("v_DistrictCode", OracleType.VarChar, ParameterDirection.Input, DistrictCode);
        PR[1] = DataTransform.Oracle_Param("v_DistrictName", OracleType.VarChar, ParameterDirection.Input, DistrictName);
        PR[2] = DataTransform.Oracle_Param("v_ProvinceName", OracleType.VarChar, ParameterDirection.Input, ProvinceName);
        PR[3] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_CMN_District_ALL", PR);
        return DS;

    }

    public DataSet Get_CMN_District_SPC(string ID)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_CMN_District_SPC " + ID, "GET_ALL_USER");
        //return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("v_ID", OracleType.VarChar, ParameterDirection.Input, ID);
        PR[1] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_CMN_District_SPC", PR);
        return DS;


    }

    public DataSet Get_CMN_Tehsil_ALL(string TehsilCode, string TehsilName, string DistrictName)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_CMN_Tehsil_ALL '" + TehsilCode + "','" + TehsilName + "','" + DistrictName + "'", "GET_ALL_USER");
        //return DS;


        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[4];
        PR[0] = DataTransform.Oracle_Param("v_TehsilCode", OracleType.VarChar, ParameterDirection.Input, TehsilCode);
        PR[1] = DataTransform.Oracle_Param("v_TehsilName", OracleType.VarChar, ParameterDirection.Input, TehsilName);
        PR[2] = DataTransform.Oracle_Param("v_DistrictName", OracleType.VarChar, ParameterDirection.Input, DistrictName);
        PR[3] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_CMN_Tehsil_ALL", PR);
        return DS;

    }

    public DataSet Get_CMN_Tehsil_SPC(string ID)
    {
        //  DataSet DS = new DataSet();
        // DS = DataTransform.ReteriveDataMultiple("EXEC SP_CMN_Tehsil_SPC " + ID, "GET_ALL_USER");
        //return DS;


        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[4];
        PR[0] = DataTransform.Oracle_Param("v_ID", OracleType.VarChar, ParameterDirection.Input, ID);
        PR[1] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        PR[2] = DataTransform.Oracle_Param("cv_2", OracleType.Cursor, ParameterDirection.Output, "");
        PR[3] = DataTransform.Oracle_Param("cv_3", OracleType.Cursor, ParameterDirection.Output, "");

        DS = DataTransform.Oracle_GetDataSetSP("SP_CMN_Tehsil_SPC", PR);
        return DS;



    }

    public DataSet Get_RPS_ExciseRate_ALL(string Description)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_RPS_ExciseRate_ALL '" + Description + "'", "GET_ALL_USER");
        //return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("v_Description", OracleType.VarChar, ParameterDirection.Input, Description);
        PR[1] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_RPS_ExciseRate_ALL", PR);
        return DS;



    }

    public DataSet Get_RPS_ExciseRate_SPC(string ID)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_RPS_ExciseRate_SPC " + ID, "GET_ALL_USER");
        //return DS;
        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("v_ID", OracleType.VarChar, ParameterDirection.Input, ID);
        PR[1] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_RPS_ExciseRate_SPC", PR);
        return DS;





    }

    #region --------------------------Default Message Setup Dataset-------------------------------

    public DataSet Get_RPS_DefaultMessages_ALL(string DefaultMessageCode, string Description)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_RPS_DefaultMessages_ALL '" + DefaultMessageCode + "','" + Description + "'", "GET_ALL_USER");
        //return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[3];
        PR[0] = DataTransform.Oracle_Param("v_DefaultMessageCode", OracleType.VarChar, ParameterDirection.Input, DefaultMessageCode);
        PR[1] = DataTransform.Oracle_Param("v_Description", OracleType.VarChar, ParameterDirection.Input, Description);
        PR[2] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_RPS_DefaultMessages_ALL", PR);
        return DS;
    }

    public DataSet Get_RPS_DefaultMessages_SPC(string ID)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_RPS_DefaultMessages_SPC " + ID, "GET_ALL_USER");
        //return DS;
        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("v_ID", OracleType.VarChar, ParameterDirection.Input, ID);
        PR[1] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_RPS_DefaultMessages_SPC", PR);
        return DS;
    }

    public DataSet Get_RPS_SP_DefaultMessages_GetByCode(string ID)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC RPS_SP_DefaultMessages_GetByCode " + ID, "GET_ALL_USER");
        //return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("v_Code", OracleType.VarChar, ParameterDirection.Input, ID);
        PR[1] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("RPS_SP_DefaultMsg_GetByCode", PR);
        return DS;
    }

    #endregion -----------------------Default Message Setup Dataset-------------------------------

    #region -----------------------Customer Product Arrangement Dateset--------------------
    public DataSet Get_SPDS_ProductArrangement_ALL(string CustomerName, string ProductName)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_SPDS_ProductArrangement_ALL '" + CustomerName + "','" + ProductName + "'", "GET_ALL_USER");
        //return DS;


        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[3];
        PR[0] = DataTransform.Oracle_Param("v_CustomerName", OracleType.VarChar, ParameterDirection.Input, CustomerName);
        PR[1] = DataTransform.Oracle_Param("v_ProductName", OracleType.VarChar, ParameterDirection.Input, ProductName);
        PR[2] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_SPDS_ProductArrangement_ALL", PR);
        return DS;
    }

    public DataSet Get_SPDS_ProductArrangement_LOV(string CustomerName, string ProductName)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_SPDS_ProductArrangement_LOV '" + CustomerName + "','" + ProductName + "'", "GET_ALL_USER");
        //return DS;


        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[3];
        PR[0] = DataTransform.Oracle_Param("v_CustomerName", OracleType.VarChar, ParameterDirection.Input, CustomerName);
        PR[1] = DataTransform.Oracle_Param("v_ProductName", OracleType.VarChar, ParameterDirection.Input, ProductName);
        PR[2] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_SPDS_ProductArrangement_LOV", PR);
        return DS;
    }

    public DataSet Get_SPDS_ProductArrangement_SPC(string ID)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_SPDS_ProductArrangement_SPC " + ID, "GET_ALL_USER");
        //return DS;
        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("v_ID", OracleType.VarChar, ParameterDirection.Input, ID);
        PR[1] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_SPDS_ProductArrangement_SPC", PR);
        return DS;
    }

    public DataSet SP_ProductArrangement_DP(string CustomerID, string ProductID, string ID)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_ProductArrangement_DP '" + CustomerID + "','" + ProductID + "','" + ID + "'", "GET_ALL_USER");
        //return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[4];
        PR[0] = DataTransform.Oracle_Param("v_CustomerID", OracleType.VarChar, ParameterDirection.Input, CustomerID);
        PR[1] = DataTransform.Oracle_Param("v_ProductID", OracleType.VarChar, ParameterDirection.Input, ProductID);
        PR[2] = DataTransform.Oracle_Param("v_ID", OracleType.VarChar, ParameterDirection.Input, ID);
        PR[3] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_ProductArrangement_DP", PR);
        return DS;
    }
    #endregion -----------------------Customer Product Arrangement Dateset--------------------

    public DataSet Get_CMN_Courier_ALL(string CourierCode, string CourierName)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_CMN_Courier_ALL '" + CourierCode + "','" + CourierName + "'", "GET_ALL_USER");
        //return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[3];
        PR[0] = DataTransform.Oracle_Param("v_CourierCode", OracleType.VarChar, ParameterDirection.Input, CourierCode);
        PR[1] = DataTransform.Oracle_Param("v_CourierName", OracleType.VarChar, ParameterDirection.Input, CourierName);

        PR[2] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_CMN_Courier_ALL", PR);
        return DS;





    }

    public DataSet Get_CMN_Courier_SPC(string ID)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_CMN_Courier_SPC " + ID, "GET_ALL_USER");
        //return DS;


        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("v_ID", OracleType.VarChar, ParameterDirection.Input, ID);
        PR[1] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_CMN_Courier_SPC", PR);
        return DS;




    }

    public DataSet Get_CMN_Station_ALL(string ProvinceName, string DistrictName, string TehsilName, string CourierName, string StationCode, string StationName)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_CMN_Station_ALL '" + ProvinceName + "','" + DistrictName + "','" + TehsilName + "','" + CourierName + "','" + StationCode + "','" + StationName + "'", "GET_ALL_USER");
        //return DS;



        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[7];
        PR[0] = DataTransform.Oracle_Param("v_ProvinceName", OracleType.VarChar, ParameterDirection.Input, ProvinceName);
        PR[1] = DataTransform.Oracle_Param("v_DistrictName", OracleType.VarChar, ParameterDirection.Input, DistrictName);

        PR[2] = DataTransform.Oracle_Param("v_TehsilName", OracleType.VarChar, ParameterDirection.Input, TehsilName);
        PR[3] = DataTransform.Oracle_Param("v_CourierName", OracleType.VarChar, ParameterDirection.Input, CourierName);
        PR[4] = DataTransform.Oracle_Param("v_StationCode", OracleType.VarChar, ParameterDirection.Input, StationCode);

        PR[5] = DataTransform.Oracle_Param("v_StationName", OracleType.VarChar, ParameterDirection.Input, StationName);


        PR[6] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_CMN_Station_ALL", PR);
        return DS;




    }

    public DataSet Get_CMN_Station_SPC(string ID)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_CMN_Station_SPC " + ID, "GET_ALL_USER");
        //return DS;


        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("v_ID", OracleType.VarChar, ParameterDirection.Input, ID);
        PR[1] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_CMN_Station_SPC", PR);
        return DS;


    }

    public DataSet Get_RPS_MasterStatus_ALL(string MasterStatusCode, string CustomerName, string Description)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_RPS_MasterStatus_ALL '" + MasterStatusCode + "','" + CustomerName + "','" + Description + "'", "GET_ALL_USER");
        //return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[4];
        PR[0] = DataTransform.Oracle_Param("v_MasterStatusCode", OracleType.VarChar, ParameterDirection.Input, MasterStatusCode);
        PR[1] = DataTransform.Oracle_Param("v_CustomerName", OracleType.VarChar, ParameterDirection.Input, CustomerName);
        PR[2] = DataTransform.Oracle_Param("v_Description", OracleType.VarChar, ParameterDirection.Input, Description);
        PR[3] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("sp_rps_masterstatus_all", PR);
        return DS;



    }

    public DataSet Get_RPS_MasterStatus_SPC(string ID)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_RPS_MasterStatus_SPC " + ID, "GET_ALL_USER");
        //return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("v_ID", OracleType.VarChar, ParameterDirection.Input, ID);
        PR[1] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_RPS_MasterStatus_SPC", PR);
        return DS;


    }

    public DataSet Get_RPS_MasterStatus_GetByCode(string Code, string CustomerID)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_RPS_MasterStatus_GetByCode '" + Code + "','" + CustomerID + "'", "GET_ALL_USER");
        //return DS;


        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[3];
        PR[0] = DataTransform.Oracle_Param("v_MasterCode", OracleType.VarChar, ParameterDirection.Input, Code);
        PR[1] = DataTransform.Oracle_Param("v_CustomerID", OracleType.VarChar, ParameterDirection.Input, CustomerID);
        PR[2] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_RPS_MasterStatus_GetByCode", PR);
        return DS;


    }

    public DataSet Get_RPS_DetailStatus_ALL(string MasterCode, string StatusCode, string Description)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_RPS_DetailStatus_ALL '" + id + "','" + StatusCode + "','" + Description + "'", "GET_ALL_USER");
        //return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[4];
        PR[0] = DataTransform.Oracle_Param("v_StatusCode", OracleType.VarChar, ParameterDirection.Input, StatusCode);
        PR[1] = DataTransform.Oracle_Param("v_MasterCode", OracleType.VarChar, ParameterDirection.Input, MasterCode);
        PR[2] = DataTransform.Oracle_Param("v_Description", OracleType.VarChar, ParameterDirection.Input, Description);
        PR[3] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_RPS_DetailStatus_ALL", PR);
        return DS;


    }

    public DataSet Get_RPS_DetailStatus_SPC(string ID)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_RPS_DetailStatus_SPC " + ID, "GET_ALL_USER");
        //return DS;


        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("v_ID", OracleType.VarChar, ParameterDirection.Input, ID);
        PR[1] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_RPS_DetailStatus_SPC", PR);
        return DS;


    }

    public DataSet Get_RPS_SP_DetailStatus_GetAllBeneficiaryStatusCodes(string StatusCode, string Description)
    {
        // Oracle does not supports larg name of SP
        //old name is RPS_SP_DetailStatus_GetAllBeneficiaryStatusCodes
        //short name is RPS_SP_DTSTGetAllBeneStsCod
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC RPS_SP_DTSTGetAllBeneStsCod '" + StatusCode + "','" + Description + "'", "GET_ALL_USER");
        //return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[3];
        PR[0] = DataTransform.Oracle_Param("v_StatusCode", OracleType.VarChar, ParameterDirection.Input, StatusCode);
        PR[1] = DataTransform.Oracle_Param("v_Description", OracleType.VarChar, ParameterDirection.Input, Description);
        PR[2] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_RPS_MasterStatus_SPC", PR);
        return DS;

    }

    #region //---------------------- Correspondent Bank Setup DataSet-----------------------

    public DataSet Get_RPS_Bank_ALL(string BankCode, string BankName)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_RPS_Bank_ALL '" + BankCode + "','" + BankName + "'", "GET_ALL_USER");
        //return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[3];
        PR[0] = DataTransform.Oracle_Param("v_BankCode", OracleType.VarChar, ParameterDirection.Input, BankCode);
        PR[1] = DataTransform.Oracle_Param("v_BankName", OracleType.VarChar, ParameterDirection.Input, BankName);
        PR[2] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_RPS_Bank_ALL", PR);
        return DS;
    }

    public DataSet Get_RPS_Bank_SPC(string ID)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_RPS_Bank_SPC " + ID + "", "GET_ALL_USER");
        //return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("v_ID", OracleType.VarChar, ParameterDirection.Input, ID);
        PR[1] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_RPS_Bank_SPC", PR);
        return DS;
    }

    public DataSet SP_CorrespondentSetup_DP(string BankCode, string ID)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_CorrespondentSetup_DP '" + BankCode + "','" + ID + "'", "GET_ALL_USER");
        //return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[3];
        PR[0] = DataTransform.Oracle_Param("v_BankCode", OracleType.VarChar, ParameterDirection.Input, BankCode);
        PR[1] = DataTransform.Oracle_Param("v_ID", OracleType.VarChar, ParameterDirection.Input, ID);
        PR[2] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_CorrespondentSetup_DP", PR);
        return DS;

    }

    public DataSet SP_Bank_ALL()
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_BANK_ALL ", "GET_ALL_USER");
        //return DS;
        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[1];
        PR[0] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_BANK_ALL", PR);
        return DS;
    }

    public DataSet Get_RPS_SP_Bank_GetAll(string ID)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC RPS_SP_Bank_GetAll " + ID, "GET_ALL_USER");
        //return DS;
        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("v_ID", OracleType.VarChar, ParameterDirection.Input, ID);
        PR[1] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("RPS_SP_Bank_GetAll", PR);
        return DS;
    }

    public DataSet Get_RPS_SP_Bank_GetCorrPrinciple(string ID)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC RPS_SP_Bank_GetCorrPrinciple " + ID, "GET_ALL_USER");
        //return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("v_ID", OracleType.VarChar, ParameterDirection.Input, ID);
        PR[1] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("RPS_SP_Bank_GetCorrPrinciple", PR);
        return DS;
    }

    public DataSet Get_RPS_CORR_PRINCIPLE_DELETE(string ID)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC RPS_CORR_PRINCIPLE_DELETE " + ID, "GET_ALL_USER");
        //return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[1];
        PR[0] = DataTransform.Oracle_Param("v_ID", OracleType.VarChar, ParameterDirection.Input, ID);
        DS = DataTransform.Oracle_GetDataSetSP("RPS_CORR_PRINCIPLE_DELETE", PR);
        return DS;
    }

    #endregion ---------------------- Correspondent Bank Setup DataSet-----------------------

    public DataSet Get_SPDS_STATIONARY_MASTER_ALL(string CustomerName, string ProductName)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_SPDS_STATIONARY_MASTER_ALL '" + CustomerName + "','" + ProductName + "'", "GET_ALL_USER");
        //return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[3];
        PR[0] = DataTransform.Oracle_Param("v_CustomerName", OracleType.VarChar, ParameterDirection.Input, CustomerName);
        PR[1] = DataTransform.Oracle_Param("v_ProductName", OracleType.VarChar, ParameterDirection.Input, ProductName);
        PR[2] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_SPDS_STATIONARY_MASTER_ALL", PR);
        return DS;



    }

    public DataSet Get_RPS_CustomerSetup_ALL(string BankCode, string BankName)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_RPS_CustomerSetup_ALL '" + BankCode + "','" + BankName + "'", "GET_ALL_USER");
        //return DS;


        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[3];
        PR[0] = DataTransform.Oracle_Param("v_BankCode", OracleType.VarChar, ParameterDirection.Input, BankCode);
        PR[1] = DataTransform.Oracle_Param("v_BankName", OracleType.VarChar, ParameterDirection.Input, BankName);
        PR[2] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_RPS_CustomerSetup_ALL", PR);
        return DS;



    }

    public DataSet Get_RPS_CustomerSetup_SPC(string ID)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_RPS_CustomerSetup_SPC " + ID + "", "GET_ALL_USER");
        //return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("v_ID", OracleType.VarChar, ParameterDirection.Input, ID);
        PR[1] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_RPS_CustomerSetup_SPC", PR);
        return DS;

    }

    public DataSet Get_RPS_CorrespondentSetup_ALL(string BankCode, string BankName)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_RPS_CorrespondentSetup_ALL '" + BankCode + "','" + BankName + "'", "GET_ALL_USER");
        //return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[3];
        PR[0] = DataTransform.Oracle_Param("v_BankCode", OracleType.VarChar, ParameterDirection.Input, BankCode);
        PR[1] = DataTransform.Oracle_Param("v_BankName", OracleType.VarChar, ParameterDirection.Input, BankName);
        PR[2] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_RPS_CorrespondentSetup_ALL", PR);
        return DS;

    }

    public DataSet Get_SPDS_STATIONARY_MASTER_SPC(string ID)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_SPDS_STATIONARY_MASTER_SPC " + ID, "GET_ALL_USER");
        //return DS;


        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("v_ID", OracleType.VarChar, ParameterDirection.Input, ID);
        PR[1] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_SPDS_STATIONARY_MASTER_SPC", PR);
        return DS;



    }

    #region ------------------------Product Master Setup Dataset-----------------------

    public DataSet Get_SPDS_ProductMaster_ALL(string ProductCode, string ProductName)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_SPDS_ProductMaster_ALL '" + ProductCode + "','" + ProductName + "'", "GET_ALL_USER");
        //return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[3];
        PR[0] = DataTransform.Oracle_Param("v_ProductCode", OracleType.VarChar, ParameterDirection.Input, ProductCode);
        PR[1] = DataTransform.Oracle_Param("v_ProductName", OracleType.VarChar, ParameterDirection.Input, ProductName);
        PR[2] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_SPDS_ProductMaster_ALL", PR);
        return DS;
    }

    public DataSet Get_SPDS_ProductMaster_SPC(string ID)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_SPDS_ProductMaster_SPC " + ID, "GET_ALL_USER");
        //return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("v_ID", OracleType.VarChar, ParameterDirection.Input, ID);
        PR[1] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_SPDS_ProductMaster_SPC", PR);
        return DS;


    }

    public DataSet Get_SPDS_ProductMaster_GetByCode(string Code)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_SPDS_ProductMaster_GetByCode " + Code, "GET_ALL_USER");
        //return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("v_ProductCode", OracleType.VarChar, ParameterDirection.Input, Code);
        PR[1] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_ProductMaster_GetByCode", PR);
        return DS;



    }

    #endregion ------------------------Product Master Setup Dataset-----------------------

    public DataSet Get_RPS_CustomerFilesPath_ALL(string CustomerName)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_RPS_CustomerFilesPath_ALL '" + CustomerName + "'", "GET_ALL_USER");
        //return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("v_CustomerName", OracleType.VarChar, ParameterDirection.Input, CustomerName);
        PR[1] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_RPS_CustomerFilesPath_ALL", PR);
        return DS;


    }

    public DataSet Get_RPS_CustomerFilesPath_SPC(string ID)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_RPS_CustomerFilesPath_SPC " + ID, "GET_ALL_USER");
        //return DS;


        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("v_ID", OracleType.VarChar, ParameterDirection.Input, ID);
        PR[1] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_RPS_CustomerFilesPath_SPC", PR);
        return DS;



    }

    #region ---------------------------Draft Footer Message Dataset------------------------

    public DataSet Get_RPS_DraftFooterMessage_ALL(string PrincipleBankName, string CorrespondingBankName, string InstrumentName, string Message)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_RPS_DraftFooterMessage_ALL '" + PrincipleBankName + "','" + CorrespondingBankName + "','" + InstrumentName + "','" + Message + "'", "GET_ALL_USER");
        //return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[5];
        PR[0] = DataTransform.Oracle_Param("v_PrincipleBankName", OracleType.VarChar, ParameterDirection.Input, PrincipleBankName);
        PR[1] = DataTransform.Oracle_Param("v_CorrespondingBankName", OracleType.VarChar, ParameterDirection.Input, CorrespondingBankName);
        PR[2] = DataTransform.Oracle_Param("v_InstrumentName", OracleType.VarChar, ParameterDirection.Input, InstrumentName);
        PR[3] = DataTransform.Oracle_Param("v_Message", OracleType.VarChar, ParameterDirection.Input, Message);
        PR[4] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_RPS_DraftFooterMessage_ALL", PR);
        return DS;
    }

    public DataSet Get_RPS_DraftFooterMessage_SPC(string ID)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_RPS_DraftFooterMessage_SPC " + ID + "", "GET_ALL_USER");
        //return DS;


        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("v_ID", OracleType.VarChar, ParameterDirection.Input, ID);
        PR[1] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_RPS_DraftFooterMessage_SPC", PR);
        return DS;


    }

    #endregion  -----------------------------Draft Footer Message Dataset------------------------

    #region -------------------- POD Series Issue Management Dataset---------------------

    public DataSet Get_SPDS_PODAWBSeriesIssuanceManagement_ALL(string CourierID)
    {
        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("v_CourierName", OracleType.VarChar, ParameterDirection.Input, CourierID);
        PR[1] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_PODAWBSeriesIssueMGMT_ALL", PR);
        return DS;
    }

    public DataSet Get_SPDS_PODAWBSeriesIssuanceManagement_SPC(string ID)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_SPDS_PODAWBSeriesIssuanceManagement_SPC " + ID, "GET_ALL_USER");
        //return DS;
        //Old Procedure name is SP_SPDS_PODAWBSeriesIssuanceManagement_SPC
        //New Procedure name is SP_SPDS_PODAWBSerIssuMage_SPC

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("v_ID", OracleType.VarChar, ParameterDirection.Input, ID);
        PR[1] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_PODAWBSeriesIssuanceMGT_SPC", PR);
        return DS;
    }

    #endregion -------------------- POD Series Issue Management Dataset---------------------

    #region ---------------------- Branch Setup DataSet--------------------------------

    public DataSet Get_CMN_Branch_ALL(string BankName, string ProvinceName, string DistrictName, string TehsilName, string BranchCode, string BranchName)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_CMN_Branch_ALL '" + BankName + "','" + ProvinceName + "','" + DistrictName + "','" + TehsilName + "','" + BranchCode + "','" + BranchName + "'", "GET_ALL_USER");
        //return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[7];
        PR[0] = DataTransform.Oracle_Param("v_BankName", OracleType.VarChar, ParameterDirection.Input, BankName);
        PR[1] = DataTransform.Oracle_Param("v_ProvinceName", OracleType.VarChar, ParameterDirection.Input, ProvinceName);
        PR[2] = DataTransform.Oracle_Param("v_DistrictName", OracleType.VarChar, ParameterDirection.Input, DistrictName);
        PR[3] = DataTransform.Oracle_Param("v_TehsilName", OracleType.VarChar, ParameterDirection.Input, TehsilName);
        PR[4] = DataTransform.Oracle_Param("v_BranchCode", OracleType.VarChar, ParameterDirection.Input, BranchCode);
        PR[5] = DataTransform.Oracle_Param("v_BranchName", OracleType.VarChar, ParameterDirection.Input, BranchName);
        PR[6] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_CMN_Branch_ALL", PR);
        return DS;
    }

    public DataSet SP_Branch_DP(string BranchCode, string BankID, string ID)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_Branch_DP '" + BranchCode + "','" + BankID + "'," + ID, "GET_ALL_USER");
        //return DS;
        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[4];
        PR[0] = DataTransform.Oracle_Param("v_BranchCode", OracleType.VarChar, ParameterDirection.Input, BranchCode);
        PR[1] = DataTransform.Oracle_Param("v_BankID", OracleType.VarChar, ParameterDirection.Input, BankID);
        PR[2] = DataTransform.Oracle_Param("v_ID", OracleType.VarChar, ParameterDirection.Input, ID);
        PR[3] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_Branch_DP", PR);
        return DS;

    }

    public DataSet Get_CMN_Branch_SPC(string ID)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_CMN_Branch_SPC " + ID + "", "GET_ALL_USER");
        //return DS;
        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("v_ID", OracleType.VarChar, ParameterDirection.Input, ID);
        PR[1] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_CMN_Branch_SPC", PR);
        return DS;
    }

    public DataSet Get_Branch_GetAllRegionalBranches(string BankID)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC RPS_SP_Branch_GetAllRegionalBranches '" + BankID + "'", "GET_ALL_USER");
        //return DS;


        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("v_BankID", OracleType.VarChar, ParameterDirection.Input, BankID);
        PR[1] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("RPS_SP_Branch_GetAllRegionBrch", PR);
        return DS;



    }

    public DataSet Get_Branch_GetAllCitiBranches()
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC RPS_SP_Branch_GetAllCitiBranches ", "GET_ALL_USER");
        //return DS;


        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[1];
        PR[0] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("RPS_SP_Branch_GetAllCitiBrch", PR);
        return DS;


    }

    public DataSet Get_Branch_GetAllAlternateBranches(string BankID, string BranchID)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC RPS_SP_Branch_GetAllAlternateBranches " + BankID + "," + BranchID + "", "GET_ALL_USER");
        //return DS;




        //DataSet DS = new DataSet();
        //OracleParameter[] PR = new OracleParameter[2];
        //PR[0] = DataTransform.Oracle_Param("v_BankID", OracleType.VarChar, ParameterDirection.Input, BankID);
        //PR[1] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        //DS = DataTransform.Oracle_GetDataSetSP("RPS_SP_Branch_GetAllRegionBrch", PR);
        //return DS;




        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[3];
        PR[0] = DataTransform.Oracle_Param("v_BankID", OracleType.VarChar, ParameterDirection.Input, BankID);
        PR[1] = DataTransform.Oracle_Param("v_BranchID", OracleType.VarChar, ParameterDirection.Input, BranchID);

        PR[2] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("RPS_SP_Brch_GetAllAltBrch", PR);
        return DS;


    }

    #endregion ------------- Branch Setup DataSet--------------------------------

    public DataSet Get_RPS_POD_ALL(string CorrespondingBankID, string PODNo)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_RPS_POD_ALL '" + CorrespondingBankID + "','" + PODNo + "'", "GET_ALL_USER");
        //return DS;



        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[3];
        PR[0] = DataTransform.Oracle_Param("v_CorrespondingBankID", OracleType.VarChar, ParameterDirection.Input, CorrespondingBankID);
        //  PR[0] = DataTransform.Oracle_Param("v_CorrespondingBankName", OracleType.VarChar, ParameterDirection.Input, v_CorrespondingBankName);
        PR[1] = DataTransform.Oracle_Param("v_PODNo", OracleType.VarChar, ParameterDirection.Input, PODNo);

        PR[2] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_RPS_POD_ALL1", PR);
        return DS;






    }

    public DataSet Get_RPS_POD_SPC(string ID)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_RPS_POD_SPC " + ID, "GET_ALL_USER");
        //return DS;



        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("v_ID", OracleType.VarChar, ParameterDirection.Input, ID);
        PR[1] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_SPDS_PODAWBSerIssuMage_SPC", PR);
        return DS;


    }

    public DataSet Get_RPS_SP_Bank_GetByCode(string MasterID, string Code)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC RPS_SP_Bank_GetByCode " + MasterID + ",'" + Code + "'", "GET_ALL_USER");
        //return DS;
        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[3];
        PR[0] = DataTransform.Oracle_Param("v_MasterID", OracleType.VarChar, ParameterDirection.Input, MasterID);
        PR[1] = DataTransform.Oracle_Param("v_Code", OracleType.VarChar, ParameterDirection.Input, Code);
        PR[2] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("RPS_SP_Bank_GetByCode", PR);
        return DS;
    }

    public DataSet Get_SPDS_CourierPricing_Master_ALL(string CourierID)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_SPDS_CourierPricing_Master_ALL '" + CourierID + "'", "GET_ALL_USER");
        //return DS;


        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("v_CourierID", OracleType.VarChar, ParameterDirection.Input, CourierID);
        PR[1] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_SPDS_CourierPric_Mast_ALL", PR);
        return DS;







    }

    public DataSet Get_SPDS_CourierPricing_Master_SPC(string ID)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_SPDS_CourierPricing_Master_SPC " + ID, "GET_ALL_USER");
        //return DS;

        //Tufail 

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("v_ID", OracleType.VarChar, ParameterDirection.Input, ID);
        PR[1] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_SPDS_CourierPrice_Mstr_SPC", PR);
        return DS;

    }

    public DataSet Get_SPDS_CourierPricing_Detail_ALL(string FromStationID, string ToStationID, string ID)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_SPDS_CourierPricing_Detail_ALL  '" + FromStationID + "','" + ToStationID + "'," + ID, "GET_ALL_USER");
        //return DS;
        //Old SP Name is SP_SPDS_CourierPricing_Detail_ALL
        //New SP Name is  SP_SPDS_CorPricing_Detail_ALL 


        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[4];
        PR[0] = DataTransform.Oracle_Param("v_FromStationID", OracleType.VarChar, ParameterDirection.Input, FromStationID);
        PR[1] = DataTransform.Oracle_Param("v_ToStationID", OracleType.VarChar, ParameterDirection.Input, ToStationID);
        PR[2] = DataTransform.Oracle_Param("v_ID", OracleType.VarChar, ParameterDirection.Input, ID);
        PR[3] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_SPDS_CourierPrice_Dtl_ALL", PR);
        //SP_SPDS_CourierPricing_Detail_ALL

        return DS;




    }

    public DataSet Get_SPDS_CourierPricing_Detail_SPC(string ID)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_SPDS_CourierPricing_Detail_SPC " + ID, "GET_ALL_USER");

        //return DS;



        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("V_ID", OracleType.VarChar, ParameterDirection.Input, ID);
        PR[1] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");

        //SP_SPDS_CourierPricing_Detail_SPC
        DS = DataTransform.Oracle_GetDataSetSP("SP_SPDS_CourierPricing_Dtl_SPC", PR);
        return DS;

    }

    #region --------------------- Corresponding Bank File Setup DataSet -----------------------------

    public DataSet Get_RPS_CorrespondingBankFilesPath_ALL(string CorrespondingBankName)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_RPS_CorrespondingBankFilesPath_ALL '" + CorrespondingBankName + "'", "GET_ALL_USER");
        //return DS;
        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("V_CorrespondingBankName", OracleType.VarChar, ParameterDirection.Input, CorrespondingBankName);
        PR[1] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_RPS_CorrBankFilesPath_ALL", PR);
        return DS;
    }

    public DataSet Get_RPS_CorrespondingBankFilesPath_SPC(string Id)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_RPS_CorrespondingBankFilesPath_SPC '" + Id + "'", "GET_ALL_USER");
        //return DS;
        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("V_Id", OracleType.VarChar, ParameterDirection.Input, Id);
        PR[1] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_RPS_CorrBankFilesPath_SPC", PR);
        return DS;
    }

    public DataSet SP_CorrespondingBankFilesPath_DP(string CorrespondingBankId, string Id)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_CorrespondingBankFilesPath_DP '" + CorrespondingBankId + "','" + Id + "'", "GET_ALL_USER");
        //return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[3];
        PR[0] = DataTransform.Oracle_Param("V_CorrespondingBankId", OracleType.VarChar, ParameterDirection.Input, CorrespondingBankId);
        PR[1] = DataTransform.Oracle_Param("V_Id", OracleType.VarChar, ParameterDirection.Input, Id);
        PR[2] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_CorrBankFilesPath_DP", PR);
        return DS;
    }

    public DataSet Get_RPS_CorrespondingBankFilesPath_SPC1(string Id)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_RPS_CorrespondingBankFilesPath_SPC1 '" + Id + "'", "GET_ALL_USER");
        //return DS;
        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("v_Id", OracleType.VarChar, ParameterDirection.Input, Id);
        PR[1] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_CorrBankFilesPath_SPC1", PR);
        return DS;
    }

    public DataSet Get_RPS_CorrespondentSetup_LOV(string BankCode, string BankName)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_RPS_CorrespondentSetup_LOV '" + BankCode + "','" + BankName + "'", "GET_ALL_USER");
        //return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[3];
        PR[0] = DataTransform.Oracle_Param("v_BankCode", OracleType.VarChar, ParameterDirection.Input, BankCode);
        PR[1] = DataTransform.Oracle_Param("v_BankName", OracleType.VarChar, ParameterDirection.Input, BankName);
        PR[2] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_RPS_CorrespondentSetup_LOV", PR);
        return DS;
    }

    #endregion --------------------- Corresponding Bank File Setup DataSet -----------------------------

    public DataSet Get_CMN_Holiday_ALL(string HolidayCode, string Remarks)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_CMN_Holiday_ALL '" + HolidayCode + "','" + Remarks + "'", "GET_ALL_USER");
        //return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[3];
        PR[0] = DataTransform.Oracle_Param("v_HolidayCode", OracleType.VarChar, ParameterDirection.Input, HolidayCode);
        PR[1] = DataTransform.Oracle_Param("v_Remarks", OracleType.VarChar, ParameterDirection.Input, Remarks);
        PR[2] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_CMN_Holiday_ALL", PR);
        return DS;


    }

    public DataSet Get_CMN_Holiday_SPC(string ID)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_CMN_Holiday_SPC " + ID + "", "GET_ALL_USER");
        //return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("v_ID", OracleType.VarChar, ParameterDirection.Input, ID);
        PR[1] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_CMN_Holiday_SPC", PR);
        return DS;


    }

    //public DataSet Get_CMN_Holiday_SPC(string ID)
    //{
    //    //DataSet DS = new DataSet();
    //    //DS = DataTransform.ReteriveDataMultiple("EXEC SP_CMN_Holiday_SPC " + ID + ", '" + DATA_RESULTSET + "'", "GET_ALL_USER");
    //    //return DS;


    //    DataSet DS = new DataSet();
    //    OracleParameter[] PR = new OracleParameter[2];
    //    PR[0] = DataTransform.Oracle_Param("v_ID", OracleType.VarChar, ParameterDirection.Input,ID);        
    //    PR[1] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
    //    DS = DataTransform.Oracle_GetDataSetSP("SP_CMN_Holiday_SPC", PR);
    //    return DS;



    //}


    //SP NOT FOUND SP_RPS_BankContact_ALL
    //public DataSet Get_RPS_BankContact_ALL(string ContactName)
    //{
    //    DataSet DS = new DataSet();
    //    DS = DataTransform.ReteriveDataMultiple("EXEC SP_RPS_BankContact_ALL '" + ContactName + "'", "GET_ALL_USER");
    //    return DS;
    //}



    // SP NOT FOUND IN SAMBA SP_RPS_BankContact_SPC

    //public DataSet Get_RPS_BankContact_SPC(string ID)
    //{
    //    DataSet DS = new DataSet();
    //    DS = DataTransform.ReteriveDataMultiple("EXEC SP_RPS_BankContact_SPC " + ID, "GET_ALL_USER");
    //    return DS;
    //}

    public DataSet Get_RPS_SP_Branch_GetAllRegionalBranches(string ID)
    {
        //DataSet DS = new DataSet();

        //DS = DataTransform.ReteriveDataMultiple("EXEC RPS_SP_Branch_GetAllRegionalBranches " + ID, "GET_ALL_USER");
        //return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("v_BankID", OracleType.VarChar, ParameterDirection.Input, ID);
        PR[1] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("RPS_SP_GetAllRegionalBranches", PR);
        return DS;
    }

    #region ---------------------Currency Setup Dataset----------------------
    public DataSet Get_CMN_Currency_ALL(string CurrencyCode, string CurrencyName)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_CMN_Currency_ALL '" + CurrencyCode + "','" + CurrencyName + "'", "GET_ALL_USER");
        //return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[3];
        PR[0] = DataTransform.Oracle_Param("v_CurrencyCode", OracleType.VarChar, ParameterDirection.Input, CurrencyCode);
        PR[1] = DataTransform.Oracle_Param("v_CurrencyName", OracleType.VarChar, ParameterDirection.Input, CurrencyName);
        PR[2] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_CMN_Currency_ALL", PR);
        return DS;



    }

    public DataSet Get_CMN_Currency_GetByCode(string CurrencyCode)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_CMN_Currency_GetByCode '" + CurrencyCode + "','" + DATA_RESULTSET + "'", "GET_ALL_USER");
        //return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("v_CurrencyCode", OracleType.VarChar, ParameterDirection.Input, CurrencyCode);
        PR[1] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_CMN_Currency_GetByCode", PR);
        return DS;


    }

    public DataSet Get_CMN_Currency_SPC(string ID)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_CMN_Currency_SPC " + ID, "GET_ALL_USER");
        //return DS;


        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("v_ID", OracleType.VarChar, ParameterDirection.Input, ID);
        PR[1] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_CMN_Currency_SPC", PR);
        return DS;




    }

    #endregion ---------------------Currency Setup Dataset----------------------

    public DataSet Get_SP_RPS_Tracer_ALL(string PrincipleBankID, string RemitterID, string BeneficiaryID, string FreeTextMessage)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_RPS_Tracer_ALL '" + PrincipleBankID + "','" + RemitterID + "','" + BeneficiaryID + "','" + FreeTextMessage + "'", "GET_ALL_USER");
        //return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[5];
        PR[0] = DataTransform.Oracle_Param("v_PrincipleBankID", OracleType.VarChar, ParameterDirection.Input, PrincipleBankID);
        PR[1] = DataTransform.Oracle_Param("v_RemitterID", OracleType.VarChar, ParameterDirection.Input, RemitterID);
        PR[2] = DataTransform.Oracle_Param("v_BeneficiaryID", OracleType.VarChar, ParameterDirection.Input, BeneficiaryID);
        PR[3] = DataTransform.Oracle_Param("v_FreeTextMessage", OracleType.VarChar, ParameterDirection.Input, FreeTextMessage);

        PR[4] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_RPS_Tracer_ALL", PR);
        return DS;
    }

    public DataSet Get_RPS_SP_Tracer_GetAllReceived(string PrincipleBankID, string RemitterID, string BeneficiaryID, string FreeTextMessage, string RemitterNo, string RemittanceRefNo)
    {
        //DataSet DS = new DataSet();
        ////DS = DataTransform.ReteriveDataMultiple("EXEC SP_RPS_Tracer_ALL '" + PrincipleBankID + "','" + RemitterID + "','" + BeneficiaryID + "','" + FreeTextMessage + "'", "GET_ALL_USER");
        //DS = DataTransform.ReteriveDataMultiple("EXEC RPS_SP_Tracer_GetAllReceived  '" + PrincipleBankID + "','" + RemitterID + "','" + BeneficiaryID + "','" + FreeTextMessage + "','" + RemitterNo + "','" + RemittanceRefNo + "'", "GET_ALL_USER");
        //return DS;



        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[5];
        PR[0] = DataTransform.Oracle_Param("v_PrincipleBankID", OracleType.VarChar, ParameterDirection.Input, PrincipleBankID);
        PR[1] = DataTransform.Oracle_Param("v_RemitterID", OracleType.VarChar, ParameterDirection.Input, RemitterID);
        PR[2] = DataTransform.Oracle_Param("v_BeneficiaryID", OracleType.VarChar, ParameterDirection.Input, BeneficiaryID);
        PR[3] = DataTransform.Oracle_Param("v_FreeTextMessage", OracleType.VarChar, ParameterDirection.Input, FreeTextMessage);

        //PR[4] = DataTransform.Oracle_Param("v_RemitterNo", OracleType.VarChar, ParameterDirection.Input, RemitterNo);
        //PR[5] = DataTransform.Oracle_Param("v_RemittanceRefNo", OracleType.VarChar, ParameterDirection.Input, RemittanceRefNo);
        PR[4] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_RPS_Tracer_ALL", PR);
        return DS;


    }

    public DataSet Get_RPS_SP_Tracer_GetAllReceived_SPC(string ID)
    {

        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC RPS_SP_Tracer_GetAllReceived_SPC " + ID, "GET_ALL_USER");
        //return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("v_ID", OracleType.VarChar, ParameterDirection.Input, ID);
        PR[1] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_RPS_Tracer_ALL", PR);
        return DS;




    }

    public DataSet Get_RPS_SP_Tracer_GetAllSent(string PrincipleBankID, string RemitterID, string BeneficiaryID, string FreeTextMessage, string RemitterNo, string RemittanceRefNo)
    {
        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[5];
        PR[0] = DataTransform.Oracle_Param("v_PrincipleBankID", OracleType.VarChar, ParameterDirection.Input, PrincipleBankID);
        PR[1] = DataTransform.Oracle_Param("v_RemitterID", OracleType.VarChar, ParameterDirection.Input, RemitterID);
        PR[2] = DataTransform.Oracle_Param("v_BeneficiaryID", OracleType.VarChar, ParameterDirection.Input, BeneficiaryID);
        PR[3] = DataTransform.Oracle_Param("v_FreeTextMessage", OracleType.VarChar, ParameterDirection.Input, FreeTextMessage);
        PR[4] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_RPS_Tracer_ALL", PR);

        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_RPS_Tracer_ALL '" + PrincipleBankID + "','" + RemitterID + "','" + BeneficiaryID + "','" + FreeTextMessage + "'", "GET_ALL_USER");
        // new DS = DataTransform.ReteriveDataMultiple("EXEC RPS_SP_Tracer_GetAllSent  '" + PrincipleBankID + "','" + RemitterID + "','" + BeneficiaryID + "','" + FreeTextMessage + "','" + RemitterNo + "','" + RemittanceRefNo + "'", "GET_ALL_USER");
        return DS;
    }

    public DataSet Get_RPS_SP_Tracer_GetAllSent_SPC(string ID)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC RPS_SP_Tracer_GetAllSent_SPC " + ID, "GET_ALL_USER");
        //return DS;


        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("v_ID", OracleType.VarChar, ParameterDirection.Input, ID);
        PR[1] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_RPS_Tracer_ALL", PR);
        return DS;


    }

    public DataSet Get_RPS_SP_Tracer_Reverse(string ID)
    {
        // DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC RPS_SP_Tracer_MarkReversed " + ID, "GET_ALL_USER");
        // return DS;


        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[1];
        PR[0] = DataTransform.Oracle_Param("v_ID", OracleType.VarChar, ParameterDirection.Input, ID);

        DS = DataTransform.Oracle_GetDataSetSP("RPS_SP_Tracer_MarkReversed", PR);
        return DS;



    }

    public DataSet Get_RPS_FreeTextMessage_ALL(string TransactionCode, string SequenceNo, string PriorityCode, string Message)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_RPS_FreeTextMessage_ALL '" + TransactionCode + "','" + SequenceNo + "','" + PriorityCode + "','" + Message + "'", "GET_ALL_USER");
        //return DS;


        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[5];
        PR[0] = DataTransform.Oracle_Param("v_TransactionCode", OracleType.VarChar, ParameterDirection.Input, TransactionCode);
        PR[1] = DataTransform.Oracle_Param("v_SequenceNo", OracleType.VarChar, ParameterDirection.Input, SequenceNo);
        PR[2] = DataTransform.Oracle_Param("v_PriorityCode", OracleType.VarChar, ParameterDirection.Input, PriorityCode);
        PR[3] = DataTransform.Oracle_Param("v_Message", OracleType.VarChar, ParameterDirection.Input, Message);

        PR[4] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_RPS_FreeTextMessage_ALL", PR);
        return DS;



    }

    public DataSet Get_RPS_FreeTextMessage_SPC(string ID)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_RPS_FreeTextMessage_SPC " + ID, "GET_ALL_USER");
        //return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("v_ID", OracleType.VarChar, ParameterDirection.Input, ID);
        PR[1] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_RPS_FreeTextMessage_SPC", PR);
        return DS;
    }

    public DataSet Get_SPDS_STATIONARY_DETAIL_ALL(string STATIONARY_MASTER_ID)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_SPDS_STATIONARY_DETAIL_ALL '" + STATIONARY_MASTER_ID + "'", "GET_ALL_USER");
        //return DS;
        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("v_STATIONARY_MASTER_ID", OracleType.VarChar, ParameterDirection.Input, STATIONARY_MASTER_ID);
        PR[1] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_SPDS_STATIONARY_DETAIL_ALL", PR);
        return DS;

    }


    public DataSet Get_SPDS_STATIONARY_DETAIL_ISSUE_ALL(string STATIONARY_MASTER_ID)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_SPDS_STATIONARY_DETAIL_ISSUE_ALL '" + STATIONARY_MASTER_ID + "'", "GET_ALL_USER");
        //return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("v_STATIONARY_MASTER_ID", OracleType.VarChar, ParameterDirection.Input, STATIONARY_MASTER_ID);
        PR[1] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_STATIONARY_DTL_ISSUE_ALL", PR);
        return DS;






    }

    public DataSet Get_SPDS_STATIONARY_DETAIL_SPC(string ID)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_SPDS_STATIONARY_DETAIL_SPC " + ID, "GET_ALL_USER");
        //return DS;



        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("v_ID", OracleType.VarChar, ParameterDirection.Input, ID);
        PR[1] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_SPDS_STATIONARY_DETAIL_SPC", PR);
        return DS;
    }

    public DataSet Get_SPDS_StarFileSetup_ALL(string CustomerName, string ProductName)
    {
        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[3];
        PR[0] = DataTransform.Oracle_Param("v_CustomerName", OracleType.VarChar, ParameterDirection.Input, CustomerName);
        PR[1] = DataTransform.Oracle_Param("v_PRODUCTNAME", OracleType.VarChar, ParameterDirection.Input, ProductName);
        PR[2] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_SPDS_StarFileSetup_ALL", PR);
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_SPDS_StarFileSetup_ALL '" + CustomerName + "','" + ProductName + "'", "GET_ALL_USER");
        return DS;
    }

    public DataSet Get_SPDS_StarFileSetup_SPC(string ID)
    {
        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("v_ID", OracleType.VarChar, ParameterDirection.Input, ID);
        PR[1] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_SPDS_StarFileSetup_SPC", PR);

        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_SPDS_StarFileSetup_SPC " + ID, "GET_ALL_USER");
        return DS;
    }

    public DataSet Get_SPDS_DraftBulkCancellation_ALL(string CustomerName, string Filename)
    {
        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[3];
        PR[0] = DataTransform.Oracle_Param("v_CustomerName", OracleType.VarChar, ParameterDirection.Input, CustomerName);
        PR[1] = DataTransform.Oracle_Param("v_Filename", OracleType.VarChar, ParameterDirection.Input, Filename);
        PR[2] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_SPDS_DraftBulkCancel_ALL", PR);

        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_SPDS_DraftBulkCancellation_ALL '" + CustomerName + "','" + Filename + "'", "GET_ALL_USER");
        return DS;
    }

    public DataSet Get_SPDS_DraftBulkCancellation_SPC(string ID)
    {
        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[3];
        PR[0] = DataTransform.Oracle_Param("v_ID", OracleType.VarChar, ParameterDirection.Input, ID);
        PR[1] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_SPDS_DraftBulkCancel_SPC", PR);
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_SPDS_DraftBulkCancellation_SPC " + ID, "GET_ALL_USER");
        return DS;
    }

    public DataSet Get_RPS_CorrespondingBankTransactions_ALL(string CorrespondingBankID, string PrincipleBankID, string DraftNo, string EntryType)
    {
        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[5];
        PR[0] = DataTransform.Oracle_Param("v_CorrespondingBankID", OracleType.VarChar, ParameterDirection.Input, CorrespondingBankID);
        PR[1] = DataTransform.Oracle_Param("v_PrincipleBankID", OracleType.VarChar, ParameterDirection.Input, PrincipleBankID);
        PR[2] = DataTransform.Oracle_Param("v_DraftNo", OracleType.VarChar, ParameterDirection.Input, DraftNo);
        PR[3] = DataTransform.Oracle_Param("v_EntryType", OracleType.VarChar, ParameterDirection.Input, EntryType);
        PR[4] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_RPS_CorrBankTrans_ALL", PR);

        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_RPS_CorrespondingBankTransactions_ALL '" + CorrespondingBankID + "','" + PrincipleBankID + "','" + DraftNo + "'," + 4 + "", "GET_ALL_USER");
        return DS;
    }

    public DataSet Get_RPS_CorrespondingBankTransactions_SPC(string ID)
    {
        DataSet DS = new DataSet();
        //DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("v_ID", OracleType.VarChar, ParameterDirection.Input, ID);
        PR[1] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_RPS_CorrBankTran_SPC", PR);

        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_RPS_CorrespondingBankTransactions_SPC " + ID, "GET_ALL_USER");
        return DS;
    }

    public DataSet Get_RPS_DailyClosingBalance_ALL(string PrincipleBankName, string CorrespondingBankName)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_RPS_DailyClosingBalance_ALL '" + PrincipleBankName + "','" + CorrespondingBankName + "'", "GET_ALL_USER");
        //return DS;
        DataSet DS = new DataSet();
        //DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[3];
        PR[0] = DataTransform.Oracle_Param("v_PrincipleBankName", OracleType.VarChar, ParameterDirection.Input, PrincipleBankName);
        PR[1] = DataTransform.Oracle_Param("v_CorrespondingBankName", OracleType.VarChar, ParameterDirection.Input, CorrespondingBankName);
        PR[2] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_RPS_DailyClosingBalance_ALL", PR);
        return DS;
    }

    public DataSet Get_RPS_DailyClosingBalance_SPC(string ID)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_RPS_DailyClosingBalance_SPC " + ID, "GET_ALL_USER");
        //return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("v_ID", OracleType.VarChar, ParameterDirection.Input, ID);
        PR[1] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_RPS_DailyClosingBalance_SPC", PR);
        return DS;


    }

    #region -------------------------Master Remitter Info Dataset------------------

    public DataSet Get_RPS_Remitter_ALL(string PrincipleBankName, string RemitterNo, string FirstName, string MiddleName, string LastName)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_RPS_Remitter_ALL '" + PrincipleBankName + "','" + RemitterNo + "','" + FirstName + "','" + MiddleName + "','" + LastName + "'", "GET_ALL_USER");
        //return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[6];
        PR[0] = DataTransform.Oracle_Param("v_PrincipleBankName", OracleType.VarChar, ParameterDirection.Input, PrincipleBankName);
        PR[1] = DataTransform.Oracle_Param("v_RemitterNo", OracleType.VarChar, ParameterDirection.Input, RemitterNo);
        PR[2] = DataTransform.Oracle_Param("v_FirstName", OracleType.VarChar, ParameterDirection.Input, FirstName);
        PR[3] = DataTransform.Oracle_Param("v_MiddleName", OracleType.VarChar, ParameterDirection.Input, MiddleName);
        PR[4] = DataTransform.Oracle_Param("v_LastName", OracleType.VarChar, ParameterDirection.Input, LastName);
        PR[5] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_RPS_Remitter_ALL", PR);
        return DS;
    }

    public DataSet Get_RPS_Remitter_SPC(string ID)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC RPS_SP_Remitter_SPC " + ID, "GET_ALL_USER");
        //return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("v_ID", OracleType.VarChar, ParameterDirection.Input, ID);
        PR[1] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("RPS_SP_Remitter_SPC", PR);
        return DS;
    }

    public DataSet SP_Remitter_DP(string RemitterNo, string ID)
    {
        //DataSet DS = new DataSet();
        // DS = DataTransform.ReteriveDataMultiple("EXEC SP_Remitter_DP '" + RemitterNo + "','" + ID + "'", "GET_ALL_USER");
        //return DS;
        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[3];
        PR[0] = DataTransform.Oracle_Param("v_RemitterNo", OracleType.VarChar, ParameterDirection.Input, RemitterNo);
        PR[1] = DataTransform.Oracle_Param("v_ID", OracleType.VarChar, ParameterDirection.Input, ID);
        PR[2] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_Remitter_DP", PR);
        return DS;
    }

    #endregion -------------------------Master Remitter Info Dataset------------------

    #region -------------------------Master Beneficiary Info Dataset------------------

    public DataSet Get_RPS_Beneficiary_ALL(string RemitterNo, string BeneficiaryNo, string CorrespondingBankName, string BranchName, string FirstName, string MiddleName)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_RPS_Beneficiary_ALL '" + RemitterNo + "','" + BeneficiaryNo + "','" + CorrespondingBankName + "','" + BranchName + "','" + FirstName + "','" + MiddleName + "'", "GET_ALL_USER");
        //return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[7];
        PR[0] = DataTransform.Oracle_Param("v_RemitterNo", OracleType.VarChar, ParameterDirection.Input, RemitterNo);
        PR[1] = DataTransform.Oracle_Param("v_BeneficiaryNo", OracleType.VarChar, ParameterDirection.Input, BeneficiaryNo);
        PR[2] = DataTransform.Oracle_Param("v_CorrespondingBankName", OracleType.VarChar, ParameterDirection.Input, CorrespondingBankName);
        PR[3] = DataTransform.Oracle_Param("v_BranchName", OracleType.VarChar, ParameterDirection.Input, BranchName);
        PR[4] = DataTransform.Oracle_Param("v_FirstName", OracleType.VarChar, ParameterDirection.Input, FirstName);
        PR[5] = DataTransform.Oracle_Param("v_MiddleName", OracleType.VarChar, ParameterDirection.Input, MiddleName);
        PR[6] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_RPS_Beneficiary_ALL", PR);
        return DS;
    }

    public DataSet Get_RPS_Beneficiary_SPC(string ID)
    {
        //DataSet DS = new DataSet();
        ////DS = DataTransform.ReteriveDataMultiple("EXEC SP_RPS_Beneficiary_SPC " + ID, "GET_ALL_USER");
        //return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("v_ID", OracleType.VarChar, ParameterDirection.Input, ID);
        PR[1] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("RPS_SP_Beneficiary_SPC", PR);
        return DS;
    }

    public DataSet SP_Beneficiary_DP(string RemitterID, string BeneficiaryNo, string ID)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_Beneficiary_DP '" + RemitterID + "','" + BeneficiaryNo + "','" + ID + "'", "GET_ALL_USER");
        //return DS;
        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[4];
        PR[0] = DataTransform.Oracle_Param("v_RemitterID", OracleType.VarChar, ParameterDirection.Input, RemitterID);
        PR[1] = DataTransform.Oracle_Param("v_BeneficiaryNo", OracleType.VarChar, ParameterDirection.Input, BeneficiaryNo);
        PR[2] = DataTransform.Oracle_Param("v_ID", OracleType.VarChar, ParameterDirection.Input, ID);
        PR[3] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_Beneficiary_DP", PR);
        return DS;
    }

    #endregion -------------------------Master Beneficiary Info Dataset------------------

    //public DataSet Get_SPDS_DataFileTransferConfiguration_ALL(string Source)
    //{
    //    DataSet DS = new DataSet();
    //    DS = DataTransform.ReteriveDataMultiple("EXEC SP_SPDS_DataFileTransferConfiguration_ALL '" + Source + "'", "GET_ALL_USER");
    //    return DS;
    //}
    public DataSet Get_SPDS_DataFileTransferConfiguration_ALL(string Source)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_SPDS_DataFileTranConfig_ALL '" + Source + "'", "GET_ALL_USER");
        //return DS;


        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("v_Source", OracleType.VarChar, ParameterDirection.Input, Source);
        PR[1] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_SPDS_DataFileTranConfig_ALL", PR);
        return DS;


    }


    public DataSet Get_SPDS_DataFileTransferConfiguration_SPC(string ID)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_SPDS_DataFileTransferConfiguration_SPC " + ID, "GET_ALL_USER");
        //return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("v_ID", OracleType.VarChar, ParameterDirection.Input, ID);
        PR[1] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_SPDS_DataFileTranConfig_SPC", PR);
        return DS;

    }


    public DataSet Get_SPDS_DataFileTransferConfigurationDetail_ALL(string MASTER_ID)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_SPDS_DataFileTransferConfigurationDetail_ALL '" + MASTER_ID + "'", "GET_ALL_USER");
        //return DS;
        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("v_MASTER_ID", OracleType.VarChar, ParameterDirection.Input, MASTER_ID);
        PR[1] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_DataFileTrnsfConfDtl_ALL", PR);
        return DS;
    }

    public DataSet Get_SPDS_DataFileTransferConfigurationDetail_SPC(string ID)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_SPDS_DataFileTransferConfigurationDetail_SPC " + ID, "GET_ALL_USER");
        //return DS;
        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("v_ID", OracleType.VarChar, ParameterDirection.Input, ID);
        PR[1] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_DataFileTransferConfDtl_SPC", PR);
        return DS;
    }

    public DataSet Get_RPS_SP_Province_GetByCode(string Code)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC RPS_SP_Province_GetByCode '" + Code + "'", "GET_ALL_USER");
        //return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("v_Code", OracleType.VarChar, ParameterDirection.Input, Code);
        PR[1] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("RPS_SP_Province_GetByCode", PR);
        return DS;
    }

    public DataSet Get_RPS_SP_Country_GetByCode(string Code)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC RPS_SP_Country_GetByCode '" + Code + "'", "GET_ALL_USER");
        //return DS;


        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("v_Code", OracleType.VarChar, ParameterDirection.Input, Code);
        PR[1] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("RPS_SP_Country_GetByCode", PR);
        return DS;
    }

    #region -========================Signatory Setup Dataset--------------------------
    public DataSet Get_SPDS_SignatorySetup_ALL(string ID, string SIGNATORY_NAME)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_SPDS_SignatorySetup_ALL '" + ID + "','" + SIGNATORY_NAME + "'", "GET_ALL_USER");
        //return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[3];
        PR[0] = DataTransform.Oracle_Param("v_ID", OracleType.VarChar, ParameterDirection.Input, ID);
        PR[1] = DataTransform.Oracle_Param("v_SIGNATORY_NAME", OracleType.VarChar, ParameterDirection.Input, SIGNATORY_NAME);
        PR[2] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_SPDS_SignatorySetup_ALL", PR);
        return DS;
    }

    public DataSet Get_SPDS_SignatorySetup_SPC(string ID)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_SPDS_SignatorySetup_SPC " + ID, "GET_ALL_USER");
        //return DS;


        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("v_ID", OracleType.VarChar, ParameterDirection.Input, ID);
        PR[1] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_SPDS_SignatorySetup_SPC", PR);
        return DS;
    }

    #endregion -========================Signatory Setup Dataset--------------------------

    public DataSet Get_RPS_SP_CorrespondentFilePath_GetByCorrId(string ID)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC RPS_SP_CorrespondingBankFilesPath_GetByCorrespondingBankId " + ID, "GET_ALL_USER");
        //return DS;


        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("v_ID", OracleType.VarChar, ParameterDirection.Input, ID);
        PR[1] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_CorrBankFilePath_GetCorrId", PR);
        return DS;
    }

    public DataSet Get_RPS_SP_CourierFilesPath_GetByCourierId(int ID)
    {
        //    DataSet DS = new DataSet();
        //    DS = DataTransform.ReteriveDataMultiple("EXEC RPS_SP_CourierFilesPath_GetByCourierId " + ID, "GET_ALL_USER");
        //    return DS;


        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("v_CourierId", OracleType.VarChar, ParameterDirection.Input, ID.ToString());
        PR[1] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("RPS_SP_CourierPathGetCourierId", PR);
        return DS;
    }

    public DataSet Get_RPS_SP_POD_GetAllForSend(int CourierID, int CorrespondingBankID, DateTime FileGenerationDate)
    {
        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[4];
        PR[0] = DataTransform.Oracle_Param("v_CourierID", OracleType.Number, ParameterDirection.Input, CourierID.ToString());
        PR[1] = DataTransform.Oracle_Param("v_CorrespondingBankID", OracleType.Number, ParameterDirection.Input, CorrespondingBankID.ToString());
        PR[2] = DataTransform.Oracle_Param("v_FileGenerationDate", OracleType.DateTime, ParameterDirection.Input, FileGenerationDate.ToString());
        PR[3] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("RPS_SP_POD_GetAllForSend", PR);
        //DS = DataTransform.ReteriveDataMultiple("EXEC RPS_SP_POD_GetAllForSend " + CourierID + "," + CorrespondingBankID + ",'" + FileGenerationDate + "'", "GET_ALL_USER");
        return DS;
    }

    public DataSet Get_RPS_SP_CourierMenifest_Add(string menifestNo, string fileName, int courierID, int correspondingBankID, string userID)
    {

        //NotFind Procedture in Database <ibrahim>
        DS = DataTransform.ReteriveDataMultiple("EXEC RPS_SP_CourierMenifest_Add 0," + courierID + "," + correspondingBankID + ",'" + menifestNo + "','" + fileName + "','" + DateTime.Now.ToString() + "','" + userID + "','" + DateTime.Now.ToString() + "','" + userID + "','" + DateTime.Now.ToString() + "'", "GET_ALL_USER");
        return DS;
    }

    public DataSet Get_RPS_SP_POD_UpdateMenifestID(int PODID, int MenifestID)
    {
        //NotFind Procedture in Database <ibrahim>
        DS = DataTransform.ReteriveDataMultiple("EXEC RPS_SP_CourierMenifest_Add " + PODID + ",'" + MenifestID + "'", "GET_ALL_USER");
        return DS;
    }

    public DataSet Get_RPS_SP_City_GetByCode(string Code)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC RPS_SP_City_GetByCode '" + Code + "'", "GET_ALL_USER");
        //return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("v_Code", OracleType.VarChar, ParameterDirection.Input, Code);
        PR[1] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("RPS_SP_City_GetByCode", PR);
        return DS;
    }

    public DataSet Get_RPS_SP_District_GetByCode(string Code, string ProvinceId)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC RPS_SP_District_GetByCode '" + Code + "'," + ProvinceId + "", "GET_ALL_USER");
        //return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[3];
        PR[0] = DataTransform.Oracle_Param("v_Code", OracleType.VarChar, ParameterDirection.Input, Code);
        PR[1] = DataTransform.Oracle_Param("v_ProvinceId", OracleType.VarChar, ParameterDirection.Input, ProvinceId);
        PR[2] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("RPS_SP_District_GetByCode", PR);
        return DS;
    }

    public DataSet Get_RPS_SP_Tehsil_GetByCode(string Code, string MasterId)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC RPS_SP_Tehsil_GetByCode " + MasterId + ",'" + Code + "'", "GET_ALL_USER");
        //return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[3];
        PR[0] = DataTransform.Oracle_Param("v_Code", OracleType.VarChar, ParameterDirection.Input, Code);
        PR[1] = DataTransform.Oracle_Param("v_MasterId", OracleType.VarChar, ParameterDirection.Input, MasterId);
        PR[2] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("RPS_SP_Tehsil_GetByCode", PR);
        return DS;
    }

    //public DataSet Get_RPS_SP_Bank_GetByCode(string Code,string MasterId)
    //{
    //    DataSet DS = new DataSet();
    //    DS = DataTransform.ReteriveDataMultiple("EXEC RPS_SP_Bank_GetByCode " + MasterId + ",'" + Code + "'", "GET_ALL_USER");
    //    return DS;
    //}

    public DataSet Get_RPS_SP_Customer_GetByCode(string Code)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC RPS_SP_Customer_GetByCode '" + Code + "'", "GET_ALL_USER");
        //return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("v_Code", OracleType.VarChar, ParameterDirection.Input, Code);
        PR[1] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("RPS_SP_Customer_GetByCode", PR);
        return DS;

    }

    #region --------------------------------Courier Setup Dataset -----------------------------

    public DataSet Get_RPS_SP_Courier_GetByCode(string Code)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC RPS_SP_Courier_GetByCode '" + Code + "'", "GET_ALL_USER");
        //return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("v_Code", OracleType.VarChar, ParameterDirection.Input, Code);
        PR[1] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("RPS_SP_Courier_GetByCode", PR);
        return DS;
    }

    #endregion --------------------------------Courier Setup Dataset -----------------------------

    public DataSet Get_RPS_SP_Branch_SendBranches(int principleBankId, string correspondingBankCode, string fromBranchCode, string toBranchCode, string userId)
    {
        OracleParameter[] PR = new OracleParameter[5];
        PR[0] = DataTransform.Oracle_Param("v_PrincipleBankID", OracleType.VarChar, ParameterDirection.Input, principleBankId.ToString());
        PR[1] = DataTransform.Oracle_Param("v_BankCode", OracleType.VarChar, ParameterDirection.Input, correspondingBankCode);
        PR[2] = DataTransform.Oracle_Param("iv_FromBranchCode", OracleType.VarChar, ParameterDirection.Input, fromBranchCode);
        PR[3] = DataTransform.Oracle_Param("iv_ToBranchCode", OracleType.VarChar, ParameterDirection.Input, toBranchCode);
        PR[4] = DataTransform.Oracle_Param("v_UserID", OracleType.VarChar, ParameterDirection.Input, userId);
        DataTransform.Oracle_GetDataSetSP_DML("RPS_SP_Branch_SendBranches", PR);

        //DS = DataTransform.ReteriveDataMultiple("RPS_SP_Branch_SendBranches", PR);

        //DS = DataTransform.ReteriveDataMultiple("EXEC RPS_SP_Branch_SendBranches " + principleBankId + ",'" + correspondingBankCode + "','" + fromBranchCode + "','" + toBranchCode + "','" + userId + "'", "GET_ALL_USER");
        return DS;
    }

    public DataSet Get_RPS_SP_MasterZipCode_GetAll()
    {

        //DS = DataTransform.ReteriveDataMultiple("EXEC RPS_SP_MasterZipCode_GetAll ", "GET_ALL_USER");
        //return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[1];
        PR[0] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("RPS_SP_MasterZipCode_GetAll", PR);
        return DS;


    }

    public DataSet Get_RPS_SP_MasterZipCode_SendZipCodes(int principleBankId, string fromZipCode, string toZipCode, string userId)
    {
        OracleParameter[] PR = new OracleParameter[4];
        PR[0] = DataTransform.Oracle_Param("v_PrincipleBankID", OracleType.VarChar, ParameterDirection.Input, principleBankId.ToString());
        PR[1] = DataTransform.Oracle_Param("iv_FromZipCode", OracleType.VarChar, ParameterDirection.Input, fromZipCode);
        PR[2] = DataTransform.Oracle_Param("iv_ToZipCode", OracleType.VarChar, ParameterDirection.Input, toZipCode);
        PR[3] = DataTransform.Oracle_Param("v_UserID", OracleType.VarChar, ParameterDirection.Input, userId);
        //PR[4] = DataTransform.Oracle_Param("v_UserID", OracleType.VarChar, ParameterDirection.Input, userId);
        DataTransform.Oracle_GetDataSetSP_DML("RPS_SP_MastZipCode_SendZipCode", PR);

        //DS = DataTransform.ReteriveDataMultiple("EXEC RPS_SP_MasterZipCode_SendZipCodes " + principleBankId + ",'" + fromZipCode + "','" + toZipCode + "','" + userId + "'", "GET_ALL_USER");
        return DS;
    }

    public DataSet Get_SPDS_UniversalUploadCofiguration_ALL(string ConfigurationName)
    {

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("v_ConfigurationName", OracleType.VarChar, ParameterDirection.Input, ConfigurationName);
        PR[1] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_SPDS_UNIVUploadCofig_ALL", PR);
        return DS;
    }


    public DataSet Get_SPDS_UniversalUploadCofiguration_SPC(string ID)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_SPDS_UniversalUploadCofiguration_SPC " + ID, "GET_ALL_USER");
        //return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("v_ID", OracleType.VarChar, ParameterDirection.Input, ID);
        PR[1] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_SPDS_UNIVUploadCofig_SPC", PR);
        return DS;
    }
    public DataSet Get_SPDS_DataLoadCofiguration_ALL(string ConfigurationID, string ConfigurationName)
    {
        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[3];
        PR[0] = DataTransform.Oracle_Param("v_ConfigurationID", OracleType.VarChar, ParameterDirection.Input, ConfigurationID);
        PR[1] = DataTransform.Oracle_Param("v_ConfigurationName", OracleType.VarChar, ParameterDirection.Input, ConfigurationName);
        PR[2] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("sp_config_def_master_getall", PR);
        return DS;
    }
    public DataSet Get_SPDS_DataLoadCofiguration_SPC(string p_CONF_ID, string p_CONF_DEF_ID)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_SPDS_UniversalUploadCofiguration_SPC " + ID, "GET_ALL_USER");
        //return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[3];
        PR[0] = DataTransform.Oracle_Param("p_CONF_ID", OracleType.VarChar, ParameterDirection.Input, p_CONF_ID);
        PR[1] = DataTransform.Oracle_Param("p_CONF_DEF_ID", OracleType.VarChar, ParameterDirection.Input, p_CONF_DEF_ID);
        PR[2] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("sp_config_def_master_getbycode", PR);
        return DS;
    }

    public DataSet Get_SPDS_DataLoadCofigurationDetail_ALL(string p_CONF_DEF_ID)
    {

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("p_CONF_DEF_ID", OracleType.VarChar, ParameterDirection.Input, p_CONF_DEF_ID);
        PR[1] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_CONFIG_DEF_DETAIL_GETALL", PR);
        return DS;
    }
    public DataSet Get_SPDS_DataLoadCofigurationDetail_SPC(string p_CONF_ID, string p_CONF_DEF_ID, string P_COLUMN_ORDER, string P_COLUMN_SEQ)
    {
        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[5];
        PR[0] = DataTransform.Oracle_Param("p_CONF_ID", OracleType.VarChar, ParameterDirection.Input, p_CONF_ID);
        PR[1] = DataTransform.Oracle_Param("p_CONF_DEF_ID", OracleType.VarChar, ParameterDirection.Input, p_CONF_DEF_ID);
        PR[2] = DataTransform.Oracle_Param("P_COLUMN_ORDER", OracleType.VarChar, ParameterDirection.Input, P_COLUMN_ORDER);
        PR[3] = DataTransform.Oracle_Param("P_COLUMN_SEQ", OracleType.VarChar, ParameterDirection.Input, P_COLUMN_SEQ);
        PR[4] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_CONFIG_DEF_DETAIL_GetByCode", PR);
        return DS;
    }
    public DataSet Get_SPDS_UniversalUploadCofigurationDetail_ALL(string UniversalUploadID)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_SPDS_UniversalUploadCofigurationDetail_ALL '" + UniversalUploadID + "'", "GET_ALL_USER");
        //return DS;


        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("v_UniversalUploadID", OracleType.VarChar, ParameterDirection.Input, UniversalUploadID);
        PR[1] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_SPDS_UNIVUploadCofigDtl_ALL", PR);
        return DS;
    }

    public DataSet Get_SPDS_UniversalUploadCofigurationDetail_SPC(string ID)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_SPDS_UniversalUploadCofigurationDetail_SPC " + ID, "GET_ALL_USER");
        //return DS;


        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("v_ID", OracleType.VarChar, ParameterDirection.Input, ID);
        PR[1] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_SPDS_UNIVUploadCofigDtl_SPC", PR);
        return DS;
    }

    public DataSet Get_RPS_BeneficiaryHistory_ALL(string RemitterID, string BeneficiaryNo, string FirstName, string MiddleName, string LastName)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_RPS_BeneficiaryHistory_ALL '" + RemitterID + "','" + BeneficiaryNo + "','" + FirstName + "','" + MiddleName + "','" + LastName + "'", "GET_ALL_USER");
        //return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[6];

        PR[0] = DataTransform.Oracle_Param("RemitterID", OracleType.VarChar, ParameterDirection.Input, "v_RemitterID");
        PR[1] = DataTransform.Oracle_Param("BeneficiaryNo", OracleType.VarChar, ParameterDirection.Input, "v_BeneficiaryNo");
        PR[2] = DataTransform.Oracle_Param("FirstName", OracleType.VarChar, ParameterDirection.Input, "v_FirstName");
        PR[3] = DataTransform.Oracle_Param("MiddleName", OracleType.VarChar, ParameterDirection.Input, "v_MiddleName");
        PR[4] = DataTransform.Oracle_Param("LastName", OracleType.VarChar, ParameterDirection.Input, "v_LastName");

        PR[5] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_RPS_BeneficiaryHistory_ALL", PR);
        return DS;

    }

    public DataSet Get_SPDS_CustomerProductPricing_Master_ALL(string CustomerID, string ProductID)
    {
        DataSet DS = new DataSet();
        //OracleParameter[] PR = new OracleParameter[6];
        //PR[0] = DataTransform.Oracle_Param("RemitterID", OracleType.VarChar, ParameterDirection.Input, "v_RemitterID");
        //PR[1] = DataTransform.Oracle_Param("BeneficiaryNo", OracleType.VarChar, ParameterDirection.Input, "v_BeneficiaryNo");
        //PR[2] = DataTransform.Oracle_Param("FirstName", OracleType.VarChar, ParameterDirection.Input, "v_FirstName");
        //PR[3] = DataTransform.Oracle_Param("MiddleName", OracleType.VarChar, ParameterDirection.Input, "v_MiddleName");
        //PR[4] = DataTransform.Oracle_Param("LastName", OracleType.VarChar, ParameterDirection.Input, "v_LastName");
        //Not find procedure in database <ibrahim>
        DS = DataTransform.ReteriveDataMultiple("EXEC SP_SPDS_CustomerProductPricing_Master_ALL '" + CustomerID + "','" + ProductID + "'", "GET_ALL_USER");
        return DS;
    }

    public DataSet Get_SPDS_CustomerProductPricing_Master_SPC(string ID)
    {
        DataSet DS = new DataSet();
        //Not find procedure in database <ibrahim>
        DS = DataTransform.ReteriveDataMultiple("EXEC SP_SPDS_CustomerProductPricing_Master_SPC " + ID, "GET_ALL_USER");
        return DS;
    }

    #region -----------------------------Signatory Category Setup Dataset----------------------------------

    public DataSet Get_SPDS_SignatoryCategorySetup_ALL(string CATEGORY_NAME, string FROM_LIMIT, string TO_LIMIT, string CurrentStatus)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_SPDS_SignatoryCategorySetup_ALL '" + CATEGORY_NAME + "','" + FROM_LIMIT + "','" + TO_LIMIT + "','" + CurrentStatus + "'", "GET_ALL_USER");
        //return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[5];
        PR[0] = DataTransform.Oracle_Param("v_CATEGORY_NAME", OracleType.VarChar, ParameterDirection.Input, CATEGORY_NAME);
        PR[1] = DataTransform.Oracle_Param("v_FROM_LIMIT", OracleType.VarChar, ParameterDirection.Input, FROM_LIMIT);
        PR[2] = DataTransform.Oracle_Param("v_TO_LIMIT", OracleType.VarChar, ParameterDirection.Input, TO_LIMIT);
        PR[3] = DataTransform.Oracle_Param("v_CurrentStatus", OracleType.VarChar, ParameterDirection.Input, CurrentStatus);
        PR[4] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_SPDS_SignatoryCatSetup_ALL", PR);
        return DS;
    }

    public DataSet Get_SPDS_SignatoryCategorySetup_LOV_ALL(string CATEGORY_NAME)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_SPDS_SignatoryCategorySetup_LOV_ALL '" + CATEGORY_NAME + "'", "GET_ALL_USER");
        //return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("v_CATEGORY_NAME", OracleType.VarChar, ParameterDirection.Input, CATEGORY_NAME);
        PR[1] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_SignatoryCatSetup_LOV_ALL", PR);
        return DS;
    }

    public DataSet Get_SPDS_SignatoryCategorySetup_SPC(string ID)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_SPDS_SignatoryCategorySetup_SPC " + ID, "GET_ALL_USER");
        //return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("v_ID", OracleType.VarChar, ParameterDirection.Input, ID);
        PR[1] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_SPDS_SignatoryCatSetup_SPC", PR);
        return DS;
    }

    public DataSet SP_SignatoryCategorySetup_DP(string CATEGORY_NAME, string FROM_LIMIT, string TO_LIMIT, string ID)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_SignatoryCategorySetup_DP '" + CATEGORY_NAME + "','" + FROM_LIMIT + "','" + TO_LIMIT + "','" + ID + "'", "GET_ALL_USER");
        //return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[5];
        PR[0] = DataTransform.Oracle_Param("v_CATEGORY_NAME", OracleType.VarChar, ParameterDirection.Input, CATEGORY_NAME);
        PR[1] = DataTransform.Oracle_Param("v_FROM_LIMIT", OracleType.VarChar, ParameterDirection.Input, FROM_LIMIT);
        PR[2] = DataTransform.Oracle_Param("v_TO_LIMIT", OracleType.VarChar, ParameterDirection.Input, TO_LIMIT);
        PR[3] = DataTransform.Oracle_Param("v_ID", OracleType.VarChar, ParameterDirection.Input, ID);
        PR[4] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_SignatoryCategorySetup_DP", PR);
        return DS;
    }

    #endregion -----------------------------Signatory Category Setup Dataset----------------------------------

    public DataSet Get_SPDS_CustomerInstrumentSetup_ALL(string CUSTOMER_Name, string INSTRUMENT_Name)
    {

        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_SPDS_CustomerInstrumentSetup_ALL '" + CUSTOMER_Name + "','" + INSTRUMENT_Name + "'", "GET_ALL_USER");
        //return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[3];


        PR[0] = DataTransform.Oracle_Param("v_CUSTOMER_Name", OracleType.VarChar, ParameterDirection.Input, CUSTOMER_Name);
        PR[1] = DataTransform.Oracle_Param("v_INSTRUMENT_Name", OracleType.VarChar, ParameterDirection.Input, INSTRUMENT_Name);
        PR[2] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_SPDS_CustInstrumentSetupALL", PR);
        return DS;
    }

    public DataSet Get_SPDS_CustomerInstrumentSetup_SPC(string ID)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_SPDS_CustomerInstrumentSetup_SPC " + ID, "GET_ALL_USER");
        //return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];


        PR[0] = DataTransform.Oracle_Param("v_ID", OracleType.VarChar, ParameterDirection.Input, ID);
        PR[1] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_SPDS_CustomerInstSetup_SPC", PR);
        return DS;



    }

    public DataSet Get_SPDS_UniversalUploadCofiguration_LOV(string Channel, string ConfigurationName)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_SPDS_UniversalUploadCofiguration_LOV '" + Channel + "','" + ConfigurationName + "'", "GET_ALL_USER");
        //return DS;


        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[3];


        PR[0] = DataTransform.Oracle_Param("v_Channel", OracleType.VarChar, ParameterDirection.Input, Channel);
        PR[1] = DataTransform.Oracle_Param("v_ConfigurationName", OracleType.VarChar, ParameterDirection.Input, ConfigurationName);
        PR[2] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_SPDS_UNIVUploadCofig_LOV", PR);
        return DS;

    }

    #region ----------------------Instrument Setup Dataset-------------------------------------

    public DataSet Get_SPDS_InstrumentSetup_ALL(string INSTRUMENT_NAME)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_SPDS_InstrumentSetup_ALL '" + INSTRUMENT_NAME + "'", "GET_ALL_USER");
        //return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("v_INSTRUMENT_NAME", OracleType.VarChar, ParameterDirection.Input, INSTRUMENT_NAME);
        PR[1] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_SPDS_InstrumentSetup_ALL", PR);
        return DS;
    }

    public DataSet Get_SPDS_InstrumentSetup_SPC(string ID)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_SPDS_InstrumentSetup_SPC " + ID, "GET_ALL_USER");
        //return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("v_ID", OracleType.VarChar, ParameterDirection.Input, ID);
        PR[1] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_SPDS_InstrumentSetup_SPC", PR);
        return DS;
    }

    public DataSet Get_SP_SPDS_InstrumentSetup_GetByCode(int Code)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_SPDS_InstrumentSetup_GetByCode " + Code, "GET_ALL_USER");
        //return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("v_Code", OracleType.VarChar, ParameterDirection.Input, Code.ToString());
        PR[1] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_SPDS_InstSetup_GetByCode", PR);
        return DS;
    }

    #endregion  ----------------------Instrument Setup Dataset-------------------------------------

    public DataSet Get_RPS_SP_Reconcile_GetLoadData(int customerId, int principleBankId, DateTime ReconcileDate)
    {
        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[4];
        PR[0] = DataTransform.Oracle_Param("v_PrincipleBankID", OracleType.Number, ParameterDirection.Input, customerId.ToString());
        PR[1] = DataTransform.Oracle_Param("v_CorrespondingBankID", OracleType.Number, ParameterDirection.Input, principleBankId.ToString());
        PR[2] = DataTransform.Oracle_Param("v_ReconcileDate", OracleType.DateTime, ParameterDirection.Input, ReconcileDate.ToString());
        PR[3] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("RPS_SP_Reconcile_GetLoadData", PR);

        //DS = DataTransform.ReteriveDataMultiple("EXEC RPS_SP_Reconcile_GetLoadData " + customerId + "," + principleBankId + ",'" + ReconcileDate + "'", "GET_ALL_USER");


        return DS;
    }

    public DataSet Get_RPS_SP_Reconcile_Get(int ID)
    {
        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("v_ID", OracleType.Number, ParameterDirection.Input, ID.ToString());
        PR[1] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("RPS_SP_Reconcile_Get", PR);

        //DS = DataTransform.ReteriveDataMultiple("EXEC RPS_SP_Reconcile_Get " + ID + "", "GET_ALL_USER");
        return DS;
    }

    public DataSet Get_RPS_SP_Reconcile_Process(int ID, int PrincipleBankID, int CorrespondingBankID, DateTime ReconciliationStartDate, DateTime ReconciliationEndDate,
                           decimal CitibankOpeningBalance, decimal CorrespondingBankOpeningBalance, string Remarks, string A_UserID, string A_DateTime, string E_UserID, string E_DateTime)
    {
        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("v_ID", OracleType.Number, ParameterDirection.Input, ID.ToString());
        PR[1] = DataTransform.Oracle_Param("v_PrincipleBankID", OracleType.Number, ParameterDirection.Input, PrincipleBankID.ToString());
        PR[2] = DataTransform.Oracle_Param("v_CorrespondingBankID", OracleType.Number, ParameterDirection.Input, CorrespondingBankID.ToString());
        PR[3] = DataTransform.Oracle_Param("v_ReconciliationStartDate", OracleType.DateTime, ParameterDirection.Input, ReconciliationStartDate.ToString());
        PR[4] = DataTransform.Oracle_Param("v_ReconciliationEndDate", OracleType.DateTime, ParameterDirection.Input, ReconciliationEndDate.ToString());
        PR[5] = DataTransform.Oracle_Param("v_CitibankOpeningBalance", OracleType.Number, ParameterDirection.Input, CitibankOpeningBalance.ToString());
        PR[6] = DataTransform.Oracle_Param("v_CorrespondingBankOpeningBala", OracleType.Number, ParameterDirection.Input, CorrespondingBankOpeningBalance.ToString());
        PR[7] = DataTransform.Oracle_Param("v_Remarks", OracleType.VarChar, ParameterDirection.Input, Remarks.ToString());
        PR[8] = DataTransform.Oracle_Param("v_A_UserID", OracleType.VarChar, ParameterDirection.Input, A_UserID.ToString());
        PR[9] = DataTransform.Oracle_Param("v_A_DateTime", OracleType.DateTime, ParameterDirection.Input, A_DateTime.ToString());
        PR[10] = DataTransform.Oracle_Param("v_E_UserID", OracleType.VarChar, ParameterDirection.Input, E_UserID.ToString());
        PR[11] = DataTransform.Oracle_Param("v_E_DateTime", OracleType.DateTime, ParameterDirection.Input, E_DateTime.ToString());

        DataTransform.Oracle_GetDataSetSP_DML("RPS_SP_Reconcile_Process", PR);
        return DS;
    }

    public DataSet Get_SPDS_AuthorizationMatrix_ALL(string CUSTOMER_NAME, string INSTRUMENT_NAME, string MAKE_SIGNATORY_NAME, string CHECKER_SIGNATORY, string CATEGORY_NAME)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_SPDS_AuthorizationMatrix_ALL '" + CUSTOMER_NAME + "','" + INSTRUMENT_NAME + "','" + MAKE_SIGNATORY_NAME + "','" + CHECKER_SIGNATORY + "','" + CATEGORY_NAME + "'", "GET_ALL_USER");
        //return DS;

        if (CUSTOMER_NAME == "0")
        { CUSTOMER_NAME = "%"; }
        if (INSTRUMENT_NAME == "0")
        { INSTRUMENT_NAME = "%"; }
        if (MAKE_SIGNATORY_NAME == "0")
        { MAKE_SIGNATORY_NAME = "%"; }

        if (CHECKER_SIGNATORY == "0")
        { CHECKER_SIGNATORY = "%"; }

        if (CATEGORY_NAME == "0")
        { CATEGORY_NAME = "%"; }




        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[6];
        PR[0] = DataTransform.Oracle_Param("v_CUSTOMER_NAME", OracleType.VarChar, ParameterDirection.Input, CUSTOMER_NAME);
        PR[1] = DataTransform.Oracle_Param("v_INSTRUMENT_NAME", OracleType.VarChar, ParameterDirection.Input, INSTRUMENT_NAME);
        PR[2] = DataTransform.Oracle_Param("v_MAKE_SIGNATORY_NAME", OracleType.VarChar, ParameterDirection.Input, MAKE_SIGNATORY_NAME);
        PR[3] = DataTransform.Oracle_Param("v_CHECKER_SIGNATORY_NAME", OracleType.VarChar, ParameterDirection.Input, CHECKER_SIGNATORY);
        PR[4] = DataTransform.Oracle_Param("v_CATEGORY_NAME", OracleType.VarChar, ParameterDirection.Input, CATEGORY_NAME);
        PR[5] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_SPDS_AuthMatrix_ALL", PR);
        return DS;
    }

    public DataSet Get_SP_SPDS_AuthorizationMatrix_SPC(string ID)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_SPDS_AuthorizationMatrix_SPC " + ID, "GET_ALL_USER");
        //return DS;


        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("v_ID", OracleType.VarChar, ParameterDirection.Input, ID);
        PR[1] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_SPDS_AuthMatrix_SPC", PR);
        return DS;
    }

    public DataSet Set_SP_SPDS_UniversalFileUpload(string QRY)
    {
        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[1];
        PR[0] = DataTransform.Oracle_Param("v_QRY", OracleType.VarChar, ParameterDirection.Input, QRY);
        DataTransform.Oracle_GetDataSetSP_DML("SP_SPDS_UniversalFileUpload", PR);

        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_SPDS_UniversalFileUpload '" + QRY + "'", "GET_ALL_USER");
        return DS;
    }

    public DataSet Get_RPS_DraftCancellation_ALL(string DraftID)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC RPS_SP_Draft_GetAllForCancel ", "GET_ALL_USER");
        //return DS;


        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("v_DraftID", OracleType.VarChar, ParameterDirection.Input, DraftID);
        PR[1] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("RPS_SP_Draft_GetAllForCancel", PR);
        return DS;
    }

    /// <summary>
    /// Draft Cancellation
    /// </summary>
    /// <param name="DraftNo"></param>
    /// <param name="RemitterNo"></param>
    /// <param name="RemittanceRefNo"></param>
    /// <param name="BeneficiaryNo"></param>
    /// <param name="BankName"></param>
    /// <param name="PODNo"></param>
    /// <returns></returns>
    public DataSet Get_RPS_DraftGetAllForCancel_ALL(string DraftNo, string RemitterNo, string RemittanceRefNo, string BeneficiaryNo, string BankName, string PODNo)
    {
        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[7];
        PR[0] = DataTransform.Oracle_Param("v_DraftNo", OracleType.VarChar, ParameterDirection.Input, DraftNo);
        PR[1] = DataTransform.Oracle_Param("v_RemitterNo", OracleType.VarChar, ParameterDirection.Input, RemitterNo);
        PR[2] = DataTransform.Oracle_Param("v_BeneficiaryNo", OracleType.VarChar, ParameterDirection.Input, BeneficiaryNo);
        PR[3] = DataTransform.Oracle_Param("v_RemittanceRefNo", OracleType.VarChar, ParameterDirection.Input, RemittanceRefNo);
        PR[4] = DataTransform.Oracle_Param("v_BankName", OracleType.VarChar, ParameterDirection.Input, BankName);
        PR[5] = DataTransform.Oracle_Param("v_PODNo", OracleType.VarChar, ParameterDirection.Input, PODNo);
        PR[6] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");

        DS = DataTransform.Oracle_GetDataSetSP("RPS_SP_Draft_GetAllForCancel", PR);
        return DS;
    }

    /// <summary>
    /// Draft Cancellaion Confirmation
    /// </summary>
    /// <param name="ID"></param>
    /// <param name="A_User"></param>
    /// <param name="A_DateTime"></param>
    /// <returns></returns>
    public DataSet Get_SP_RPS_DraftCancellation_Authorized(string ID, string A_User, DateTime A_DateTime)
    {
        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[3];
        PR[0] = DataTransform.Oracle_Param("v_ID", OracleType.VarChar, ParameterDirection.Input, ID);
        PR[1] = DataTransform.Oracle_Param("v_A_UserID", OracleType.VarChar, ParameterDirection.Input, A_User);
        PR[2] = DataTransform.Oracle_Param("v_A_DateTime", OracleType.DateTime, ParameterDirection.Input, A_DateTime.ToString());
        DataTransform.Oracle_GetDataSetSP_DML("RPS_SP_DraftCancellation_Autho", PR);

        //DS = DataTransform.ReteriveDataMultiple("EXEC RPS_SP_DraftCancellation_Authorize " + ID + ",'" + A_User + "','" + A_DateTime + "'", "GET_ALL_USER");
        return DS;
    }

    /// <summary>
    /// Draft Cancellaion Confirmation
    /// </summary>
    /// <param name="DraftNo"></param>
    /// <param name="RemitterNo"></param>
    /// <param name="RemittanceRefNo"></param>
    /// <param name="BeneficiaryNo"></param>
    /// <param name="BankName"></param>
    /// <param name="PODNo"></param>
    /// <returns></returns>
    public DataSet Get_RPS_DraftGetAllForCancel_ALL_Authorized(string DraftNo, string RemitterNo, string RemittanceRefNo, string BeneficiaryNo, string BankName, string PODNo)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC RPS_SP_Draft_GetAllForCancel_Authorized '" + DraftNo + "','" + RemitterNo + "','" + RemittanceRefNo + "','" + BeneficiaryNo + "','" + BankName + "','" + PODNo + "'", "GET_ALL_USER");
        //return DS;



        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[7];
        PR[0] = DataTransform.Oracle_Param("v_DraftNo", OracleType.VarChar, ParameterDirection.Input, DraftNo);
        PR[1] = DataTransform.Oracle_Param("v_RemitterNo", OracleType.VarChar, ParameterDirection.Input, RemitterNo);
        PR[2] = DataTransform.Oracle_Param("v_RemittanceRefNo", OracleType.VarChar, ParameterDirection.Input, RemittanceRefNo);
        PR[3] = DataTransform.Oracle_Param("v_BeneficiaryNo", OracleType.VarChar, ParameterDirection.Input, BeneficiaryNo);
        PR[4] = DataTransform.Oracle_Param("v_BankName", OracleType.VarChar, ParameterDirection.Input, BankName);
        PR[5] = DataTransform.Oracle_Param("v_PODNo", OracleType.VarChar, ParameterDirection.Input, PODNo);

        PR[6] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("RPS_SP_Drft_GetAll4Cancel_Auth", PR);
        return DS;
    }

    public DataSet Get_SP_RPS_DraftCancellation_SPC(string ID, string company_code)
    {
        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[3];
        PR[0] = DataTransform.Oracle_Param("v_ID", OracleType.VarChar, ParameterDirection.Input, ID);
        PR[1] = DataTransform.Oracle_Param("v_company_code", OracleType.VarChar, ParameterDirection.Input, company_code);
        PR[2] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("RPS_SP_DraftCancellationSPC", PR);
        return DS;
    }
    //public DataSet SP_CUST_CONF_LINK_SPC(string ID)
    //{
    //    DataSet DS = new DataSet();
    //    OracleParameter[] PR = new OracleParameter[2];
    //    PR[0] = DataTransform.Oracle_Param("v_ID", OracleType.VarChar, ParameterDirection.Input, ID);
    //    PR[1] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");
    //    DS = DataTransform.Oracle_GetDataSetSP("RPS_SP_DraftCancellationSPC", PR);
    //    return DS;
    //}

    public DataSet Get_RPS_MoneyGramRemittance_ALL(string PrincipleBankID,
        string IncomingBeneficiaryID, string IncomingRemitterID, string NICNo)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC RPS_SP_MoneyGramRemittance_GetAllByParams '" + PrincipleBankID + "','" + IncomingBeneficiaryID + "','" + IncomingRemitterID + "','" + NICNo + "'", "GET_ALL_USER");
        //return DS;


        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[5];
        PR[0] = DataTransform.Oracle_Param("v_PrincipleBankID", OracleType.VarChar, ParameterDirection.Input, PrincipleBankID);
        PR[1] = DataTransform.Oracle_Param("v_IncomingBeneficiaryID", OracleType.VarChar, ParameterDirection.Input, IncomingBeneficiaryID);
        PR[2] = DataTransform.Oracle_Param("v_IncomingRemitterID", OracleType.VarChar, ParameterDirection.Input, IncomingRemitterID);
        PR[3] = DataTransform.Oracle_Param("v_NICNo", OracleType.VarChar, ParameterDirection.Input, NICNo);
        PR[4] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("RPS_SP_MGramRemit_GetAllParam", PR);
        return DS;
    }

    public DataSet Get_RPS_MoneyGramRemittance_SPC(string MasterCode, string Code)
    {
        //    DataSet DS = new DataSet();
        //    DS = DataTransform.ReteriveDataMultiple("EXEC RPS_SP_MoneyGramRemittance_SPC '" + MasterCode + "','" + Code + "'", "GET_ALL_USER");
        //    return DS;


        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[3];
        PR[0] = DataTransform.Oracle_Param("v_MasterCode", OracleType.VarChar, ParameterDirection.Input, MasterCode);
        PR[1] = DataTransform.Oracle_Param("v_Code", OracleType.VarChar, ParameterDirection.Input, Code);
        PR[2] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("RPS_SP_MoneyGramRemittance_SPC", PR);
        return DS;
    }

    public DataSet Get_RPS_DraftStopPayment_ALL(string Confirmed)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC RPS_SP_DraftStopPayment_GetAllUnAuthorized " + Confirmed + "", "GET_ALL_USER");
        //return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("v_Confirmed", OracleType.VarChar, ParameterDirection.Input, Confirmed);
        PR[1] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("RPS_SP_DrftStpPay_GetAllUnAuth", PR);
        return DS;
    }

    ////public DataSet GetTest_SPC(string stringID ,bool confirm)
    ////{
    ////    DataSet DS = new DataSet();
    ////    DS = DataTransform.ReteriveDataMultiple("EXEC SP_RPS_DraftStopPayment_SPC " + ID + "," + confirm, "GET_ALL_USER");
    ////    return DS;
    ////}

    public DataSet Get_RPS_DraftStopPayment_SPC(string ID, string Confirmed)
    {
        Confirmed = "0";
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC RPS_SP_DraftStopPayment_GetAllUnAuthorized_SPC " + ID + "," + Confirmed + "", "GET_ALL_USER");
        //return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[3];
        PR[0] = DataTransform.Oracle_Param("v_IsConfirmed", OracleType.VarChar, ParameterDirection.Input, Confirmed);
        PR[1] = DataTransform.Oracle_Param("v_DraftNo", OracleType.VarChar, ParameterDirection.Input, ID);
        PR[2] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("RPS_SP_DrftStpPay_GetAllUnAuth", PR);
        return DS;
    }

    public DataSet Get_RPS_DraftStopPayment_ALL2(string Confirmed, string DraftNo)
    {
        Confirmed = "0";
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC RPS_SP_DraftStopPayment_GetAllUnAuthorized " + Confirmed + ",'" + DraftNo + "'", "GET_ALL_USER");
        //return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[3];
        PR[0] = DataTransform.Oracle_Param("v_IsConfirmed", OracleType.VarChar, ParameterDirection.Input, Confirmed);
        PR[1] = DataTransform.Oracle_Param("v_DraftNo", OracleType.VarChar, ParameterDirection.Input, DraftNo);
        PR[2] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("RPS_SP_DrftStpPay_GetAllUnAuth", PR);
        return DS;
    }

    ////public DataSet GetTest_SPC(string stringID ,bool confirm)
    ////{
    ////    DataSet DS = new DataSet();
    ////    DS = DataTransform.ReteriveDataMultiple("EXEC SP_RPS_DraftStopPayment_SPC " + ID + "," + confirm, "GET_ALL_USER");
    ////    return DS;
    ////}

    public DataSet Get_RPS_DraftStopPayment_SPC2(string ID, string Confirmed)
    {
        Confirmed = "0";
        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[3];
        PR[0] = DataTransform.Oracle_Param("v_ID", OracleType.VarChar, ParameterDirection.Input, ID);
        PR[1] = DataTransform.Oracle_Param("v_Confirmed", OracleType.VarChar, ParameterDirection.Input, Confirmed);
        PR[2] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_DrftStopPay_GetAllUnAuthSPC", PR);
        return DS;
    }

    public DataSet Get_RPS_DraftStopPayment_Authorized(string ID, string A_User, string A_DateTime)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC RPS_SP_DraftStopPayment_Authorize " + ID + ",'" + A_User + "','" + A_DateTime + "'", "GET_ALL_USER");
        //return DS;


        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[4];
        PR[0] = DataTransform.Oracle_Param("v_ID", OracleType.VarChar, ParameterDirection.Input, ID);
        PR[1] = DataTransform.Oracle_Param("v_A_User", OracleType.VarChar, ParameterDirection.Input, A_User);
        PR[2] = DataTransform.Oracle_Param("v_A_DateTime", OracleType.VarChar, ParameterDirection.Input, A_DateTime);
        PR[3] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("RPS_SP_DrftStopPayment_Auth", PR);
        return DS;
    }

    public void Get_RPS_DraftStopPayment_Authorized_2(string ID, string A_User, string A_DateTime)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC RPS_SP_DraftStopPayment_Authorize " + ID + ",'" + A_User + "','" + A_DateTime + "'", "GET_ALL_USER");


        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[4];
        PR[0] = DataTransform.Oracle_Param("v_ID", OracleType.VarChar, ParameterDirection.Input, ID);
        PR[1] = DataTransform.Oracle_Param("v_A_User", OracleType.VarChar, ParameterDirection.Input, A_User);
        PR[2] = DataTransform.Oracle_Param("v_A_DateTime", OracleType.VarChar, ParameterDirection.Input, A_DateTime);
        PR[3] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("RPS_SP_DrftStopPayment_Auth", PR);


    }

    #region ---------------------- Print Agent Setup Dataset ---------------------------------

    public DataSet Get_SPDS_PrintAgentSetup_ALL(string PRINT_AGENT_NAME, string CONTACT_PERSON, string ADDRESS, string SECONDARY_CONTACT_NAME, string SECONDARY_ADDRESS)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_SPDS_PrintAgentSetup_ALL '" + PRINT_AGENT_NAME + "','" + CONTACT_PERSON + "','" + ADDRESS + "','" + SECONDARY_CONTACT_NAME + "','" + SECONDARY_ADDRESS + "'", "GET_ALL_USER");
        //return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[6];
        PR[0] = DataTransform.Oracle_Param("v_PRINT_AGENT_NAME", OracleType.VarChar, ParameterDirection.Input, PRINT_AGENT_NAME);
        PR[1] = DataTransform.Oracle_Param("v_CONTACT_PERSON", OracleType.VarChar, ParameterDirection.Input, CONTACT_PERSON);
        PR[2] = DataTransform.Oracle_Param("v_ADDRESS", OracleType.VarChar, ParameterDirection.Input, ADDRESS);
        PR[3] = DataTransform.Oracle_Param("v_SECONDARY_CONTACT_NAME", OracleType.VarChar, ParameterDirection.Input, SECONDARY_CONTACT_NAME);
        PR[4] = DataTransform.Oracle_Param("v_SECONDARY_ADDRESS", OracleType.VarChar, ParameterDirection.Input, SECONDARY_ADDRESS);
        PR[5] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_SPDS_PrintAgentSetup_ALL", PR);
        return DS;
    }

    public DataSet Get_SPDS_PrintAgentSetup_SPC(string ID)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_SPDS_PrintAgentSetup_SPC " + ID, "GET_ALL_USER");
        //return DS;
        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("v_ID", OracleType.VarChar, ParameterDirection.Input, ID);
        PR[1] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_SPDS_PrintAgentSetup_SPC", PR);
        return DS;
    }

    public DataSet SP_PrintAgentSetup_DP(string PRINT_AGENT_NAME, string ID)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_PrintAgentSetup_DP '" + PRINT_AGENT_NAME + "','" + ID + "'", "GET_ALL_USER");
        //return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[3];
        PR[0] = DataTransform.Oracle_Param("v_PRINT_AGENT_NAME", OracleType.VarChar, ParameterDirection.Input, PRINT_AGENT_NAME);
        PR[1] = DataTransform.Oracle_Param("v_ID", OracleType.VarChar, ParameterDirection.Input, ID);
        PR[2] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_PrintAgentSetup_DP", PR);
        return DS;
    }

    public DataSet Get_RPS_SP_PrintAgent_GetByCode(string ID)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC RPS_SP_PrintAgent_GetByCode '" + ID + "'", "GET_ALL_USER");
        //return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("v_Code", OracleType.VarChar, ParameterDirection.Input, ID);
        PR[1] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("RPS_SP_PrintAgent_GetByCode", PR);
        return DS;

    }

    public DataSet Get_SPDS_PrintAgentSetup_LOV(string PRINT_AGENT_NAME, string CONTACT_PERSON)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_SPDS_PrintAgentSetup_LOV '" + PRINT_AGENT_NAME + "','" + CONTACT_PERSON + "'", "GET_ALL_USER");
        //return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[3];
        PR[0] = DataTransform.Oracle_Param("v_PRINT_AGENT_NAME", OracleType.VarChar, ParameterDirection.Input, PRINT_AGENT_NAME);
        PR[1] = DataTransform.Oracle_Param("v_CONTACT_PERSON", OracleType.VarChar, ParameterDirection.Input, CONTACT_PERSON);

        PR[2] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_SPDS_PrintAgentSetup_LOV", PR);
        return DS;



    }

    #endregion ---------------------- Print Agent Setup Dataset ---------------------------------

    public DataSet Get_RPS_SP_Location_GetByCode(string Code)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC RPS_SP_Location_GetByCode '" + Code + "'", "GET_ALL_USER");
        //return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("v_ID", OracleType.VarChar, ParameterDirection.Input, Code);
        PR[1] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("RPS_SP_Location_GetByCode", PR);
        return DS;



    }

    public DataSet Get_RPS_SP_Zip_GetByCode(string ID)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC RPS_SP_Zip_GetByCode '" + ID + "'", "GET_ALL_USER");
        //return DS;


        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("v_Code", OracleType.VarChar, ParameterDirection.Input, ID);
        PR[1] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("RPS_SP_Zip_GetByCode", PR);
        return DS;



    }

    #region ----------------------- Print Location Setup Dataset ----------------------------

    public DataSet Get_SPDS_PrintAgentDetail_ALL(string PRINT_AGENT_ID, string PRINT_LOCATION_ID)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_SPDS_PrintAgentDetail_ALL '" + PRINT_AGENT_ID + "','" + PRINT_LOCATION_ID + "'", "GET_ALL_USER");
        //return DS;
        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[3];
        PR[0] = DataTransform.Oracle_Param("v_PRINT_AGENT_ID", OracleType.VarChar, ParameterDirection.Input, PRINT_AGENT_ID);
        PR[1] = DataTransform.Oracle_Param("v_PRINT_LOCATION_ID", OracleType.VarChar, ParameterDirection.Input, PRINT_LOCATION_ID);
        PR[2] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_SPDS_PrintAgentDetail_ALL", PR);
        return DS;

    }

    public DataSet Get_SPDS_PrintAgentDetail_GETBYCODE(string PRINT_AGENT_ID)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_SPDS_PrintAgntDtlLOVGETCODE '" + PRINT_AGENT_ID + "'", "GET_ALL_USER");
        //return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("v_PrintAgentID", OracleType.VarChar, ParameterDirection.Input, PRINT_AGENT_ID);
        PR[1] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_SPDS_PrintAgntDtlLOVGETCODE", PR);
        return DS;
    }

    public DataSet Get_SPDS_PrintAgentDetail_SPC(string stringID)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_SPDS_PrintAgentDetail_SPC " + stringID, "GET_ALL_USER");
        //return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("v_ID", OracleType.VarChar, ParameterDirection.Input, stringID);
        PR[1] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_SPDS_PrintAgentDetail_SPC", PR);
        return DS;

    }

    public DataSet Get_MasterZipCode_BySelection(string ID, String ZipCodes)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC RPS_SP_MasterZipCode_BySelection " + ID + ",'" + ZipCodes + "'", "GET_ALL_USER");
        //return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[3];
        PR[0] = DataTransform.Oracle_Param("v_PrintAgentDetailID", OracleType.VarChar, ParameterDirection.Input, ID);
        PR[1] = DataTransform.Oracle_Param("iv_ZipCodes", OracleType.VarChar, ParameterDirection.Input, ZipCodes);
        PR[2] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("RPS_SP_MasterZipCode_BySelecti", PR);
        return DS;
    }

    #endregion ----------------------- Print Location Setup Dataset ----------------------------

    public DataSet Get_RPS_MasterZipCode_ALL(string CourierID, string StationID, string ServiceID, string BankID, string BranchID, string ZipCode)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_RPS_MasterZipCode_ALL '" + CourierID + "','" + StationID + "','" + ServiceID + "','" + BankID + "','" + BranchID + "','" + ZipCode + "'", "GET_ALL_USER");
        //return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[7];
        PR[0] = DataTransform.Oracle_Param("v_CourierID", OracleType.VarChar, ParameterDirection.Input, CourierID);
        PR[1] = DataTransform.Oracle_Param("v_StationID", OracleType.VarChar, ParameterDirection.Input, StationID);
        PR[2] = DataTransform.Oracle_Param("v_ServiceID", OracleType.VarChar, ParameterDirection.Input, ServiceID);
        PR[3] = DataTransform.Oracle_Param("v_BankID", OracleType.VarChar, ParameterDirection.Input, BankID);
        PR[4] = DataTransform.Oracle_Param("v_BranchID", OracleType.VarChar, ParameterDirection.Input, BranchID);
        PR[5] = DataTransform.Oracle_Param("v_ZipCode", OracleType.VarChar, ParameterDirection.Input, ZipCode);
        PR[6] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_RPS_MasterZipCode_ALL", PR);
        return DS;



    }

    public DataSet Get_RPS_MasterZipCodeLOVSendBranch_ALL(string CourierID, string StationID, string ServiceID,
        string BankID, string BranchID, string ZipCode, string CustomerID)
    {
        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[8];
        PR[0] = DataTransform.Oracle_Param("v_CourierID", OracleType.VarChar, ParameterDirection.Input, CourierID);
        PR[1] = DataTransform.Oracle_Param("v_StationID", OracleType.VarChar, ParameterDirection.Input, StationID);
        PR[2] = DataTransform.Oracle_Param("v_ServiceID", OracleType.VarChar, ParameterDirection.Input, ServiceID);
        PR[3] = DataTransform.Oracle_Param("v_BankID", OracleType.VarChar, ParameterDirection.Input, BankID);
        PR[4] = DataTransform.Oracle_Param("v_BranchID", OracleType.VarChar, ParameterDirection.Input, BranchID);
        PR[5] = DataTransform.Oracle_Param("v_ZipCode", OracleType.VarChar, ParameterDirection.Input, ZipCode);
        PR[6] = DataTransform.Oracle_Param("v_ZipCode", OracleType.VarChar, ParameterDirection.Input, CustomerID);
        PR[7] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_MastZipCodeLOVSndBranch_ALL", PR);

        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_RPS_MasterZipCodeLOVSendBranch_ALL '" + CourierID + "','" + StationID + "','" + ServiceID + "','" + BankID + "','" + BranchID + "','" + ZipCode + "'," + CustomerID + "", "GET_ALL_USER");
        return DS;
    }

    public DataSet Get_SP_RPS_CorrBank_ZipCodeLOV(string ZipCode, string BANKNAME, string BRANCHNAME, string COURIERNAME, string STATIONNAME, string CorrBankID)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_RPS_CorrBank_ZipCodeLOV '" + ZipCode + "','" + BANKNAME + "','" + BRANCHNAME + "','" + COURIERNAME + "','" + STATIONNAME + "','" + CorrBankID + "'", "GET_ALL_USER");
        //return DS;
        /*DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[7];
        PR[0] = DataTransform.Oracle_Param("v_ZipCode", OracleType.VarChar, ParameterDirection.Input, ZipCode);
        PR[1] = DataTransform.Oracle_Param("v_BANKNAME", OracleType.VarChar, ParameterDirection.Input, BANKNAME);
        PR[2] = DataTransform.Oracle_Param("v_BRANCHNAME", OracleType.VarChar, ParameterDirection.Input, BRANCHNAME);
        PR[3] = DataTransform.Oracle_Param("v_COURIERNAME", OracleType.VarChar, ParameterDirection.Input, COURIERNAME);
        PR[4] = DataTransform.Oracle_Param("v_STATIONNAME", OracleType.VarChar, ParameterDirection.Input, STATIONNAME);
        PR[5] = DataTransform.Oracle_Param("v_CorrBankID", OracleType.VarChar, ParameterDirection.Input, CorrBankID);
        PR[6] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_RPS_CorrBank_ZipCodeLOV", PR);
        
        return DS;*/
        //commit by ibrahim Reson : Old sp and parameter change

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[7];
        PR[0] = DataTransform.Oracle_Param("v_ZipCode", OracleType.VarChar, ParameterDirection.Input, ZipCode);
        PR[1] = DataTransform.Oracle_Param("v_BANKNAME", OracleType.VarChar, ParameterDirection.Input, BANKNAME);
        PR[2] = DataTransform.Oracle_Param("v_BRANCHNAME", OracleType.VarChar, ParameterDirection.Input, BRANCHNAME);
        PR[3] = DataTransform.Oracle_Param("v_COURIERNAME", OracleType.VarChar, ParameterDirection.Input, COURIERNAME);
        PR[4] = DataTransform.Oracle_Param("v_STATIONNAME", OracleType.VarChar, ParameterDirection.Input, STATIONNAME);
        PR[5] = DataTransform.Oracle_Param("v_CorrBankID", OracleType.VarChar, ParameterDirection.Input, CorrBankID);
        PR[6] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_RPS_CorrBank_ZipCodeLOV", PR);

        return DS;







    }

    public DataSet Get_SP_RPS_Station_ZipCodeLOV(string ZipCode, string BANKNAME, string BRANCHNAME, string COURIERNAME, string STATIONNAME, string StaionID)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_RPS_Station_ZipCodeLOV '" + ZipCode + "','" + BANKNAME + "','" + BRANCHNAME + "','" + COURIERNAME + "','" + STATIONNAME + "','" + StaionID + "'", "GET_ALL_USER");
        //return DS;
        if (ZipCode == "0")
        { ZipCode = "%"; }
        if (BANKNAME == "0")
        { BANKNAME = "%"; }
        if (BRANCHNAME == "0")
        { BRANCHNAME = "%"; }
        if (COURIERNAME == "0")
        { COURIERNAME = "%"; }
        if (STATIONNAME == "0")
        { STATIONNAME = "%"; }



        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[7];
        PR[0] = DataTransform.Oracle_Param("v_ZipCode", OracleType.VarChar, ParameterDirection.Input, ZipCode);
        PR[1] = DataTransform.Oracle_Param("v_BANKNAME", OracleType.VarChar, ParameterDirection.Input, BANKNAME);
        PR[2] = DataTransform.Oracle_Param("v_BRANCHNAME", OracleType.VarChar, ParameterDirection.Input, BRANCHNAME);
        PR[3] = DataTransform.Oracle_Param("v_COURIERNAME", OracleType.VarChar, ParameterDirection.Input, COURIERNAME);
        PR[4] = DataTransform.Oracle_Param("v_STATIONNAME", OracleType.VarChar, ParameterDirection.Input, STATIONNAME);
        PR[5] = DataTransform.Oracle_Param("v_StationID", OracleType.VarChar, ParameterDirection.Input, StaionID);

        PR[6] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_RPS_Station_ZipCodeLOV", PR);
        return DS;
    }

    public DataSet Get_RPS_MasterZipCode_SPC(string ID)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_RPS_MasterZipCode_SPC " + ID, "GET_ALL_USER");
        //return DS;



        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("v_ID", OracleType.VarChar, ParameterDirection.Input, ID);
        PR[1] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_RPS_MasterZipCode_SPC", PR);
        return DS;
    }

    public DataSet Get_RPS_SP_CorrespondingBankTransactions_GetAllByParams(int CorrespondingBankID, int PrincipleBankID, DateTime EntryDate, int EntryTypeId)
    {
        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[5];
        PR[0] = DataTransform.Oracle_Param("v_CorrespondingBankID", OracleType.VarChar, ParameterDirection.Input, CorrespondingBankID.ToString());
        PR[1] = DataTransform.Oracle_Param("v_PrincipleBankID", OracleType.VarChar, ParameterDirection.Input, PrincipleBankID.ToString());
        PR[2] = DataTransform.Oracle_Param("v_EntryDate", OracleType.DateTime, ParameterDirection.Input, EntryDate.ToString());
        PR[3] = DataTransform.Oracle_Param("v_EntryTypeId", OracleType.VarChar, ParameterDirection.Input, EntryTypeId.ToString());
        PR[4] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_CorrBankTran_GetAllByParams", PR);
        return DS;


        //DS = DataTransform.ReteriveDataMultiple("EXEC RPS_SP_CorrespondingBankTransactions_GetAllByParams " + CorrespondingBankID + "," + PrincipleBankID + ",'" + EntryDate + "'," + EntryTypeId + "", "GET_ALL_USER");
    }

    public DataSet Get_RPS_SP_CorrespondingBankTransactions_Delete(int ID)
    {
        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[1];
        PR[0] = DataTransform.Oracle_Param("v_ID", OracleType.VarChar, ParameterDirection.Input, ID.ToString());
        DataTransform.Oracle_GetDataSetSP_DML("RPS_SP_CorrBankTran_Delete", PR);
        //DS = DataTransform.ReteriveDataMultiple("EXEC RPS_SP_CorrespondingBankTransactions_Delete " + ID, "GET_ALL_USER");
        return DS;
    }

    public DataSet Get_RPS_SP_CorrespondingBankFile_Add(int Id, int CorrespondingBankId, string FileName, DateTime FileCreationDateTime, string E_UserId, DateTime E_DateTime, string A_UserId, DateTime A_DateTime)
    {
        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[9];
        PR[0] = DataTransform.Oracle_Param("v_Id", OracleType.VarChar, ParameterDirection.Input, Id.ToString());
        PR[1] = DataTransform.Oracle_Param("v_CorrespondingBankId", OracleType.VarChar, ParameterDirection.Input, CorrespondingBankId.ToString());
        PR[2] = DataTransform.Oracle_Param("v_FileName", OracleType.DateTime, ParameterDirection.Input, FileName);
        PR[3] = DataTransform.Oracle_Param("v_FileCreationDateTime", OracleType.VarChar, ParameterDirection.Input, FileCreationDateTime.ToString());
        PR[4] = DataTransform.Oracle_Param("v_E_UserId", OracleType.VarChar, ParameterDirection.Input, E_UserId);
        PR[5] = DataTransform.Oracle_Param("v_E_DateTime", OracleType.VarChar, ParameterDirection.Input, E_DateTime.ToString());
        PR[6] = DataTransform.Oracle_Param("v_A_DateTime", OracleType.VarChar, ParameterDirection.Input, A_DateTime.ToString());
        PR[7] = DataTransform.Oracle_Param("v_A_UserId", OracleType.VarChar, ParameterDirection.Input, A_UserId);
        PR[8] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("RPS_SP_CorrBankFile_Add", PR);

        //DS = DataTransform.ReteriveDataMultiple("EXEC RPS_SP_CorrespondingBankFile_Add " + Id + "," + CorrespondingBankId + ",'" + FileName + "','" + FileCreationDateTime + "','" + E_UserId + "','" + E_DateTime + "','" + string.Empty + "','" + A_UserId + "' ", "GET_ALL_USER");
        return DS;
    }

    public DataSet Get_RPS_SP_CorrespondingBankFileData_Add(int ID, int CorrespondingBankFileID, string CorrespondingBankUniqueId,
        DateTime ProcessingDate, string DraftNo, DateTime DraftPaidDate, string BeneficiaryName, double Amount,
        string ProcessingRemarks, string BranchCode, double Charges, string Remarks, string Type, string TEZStatus,
        string TCSNo, DateTime DispatchDate, DateTime DeliveryDate, string RecievedBy, string A_UserID,
        DateTime A_DateTime, string E_UserID, DateTime E_DateTime)
    {
        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[22];
        PR[0] = DataTransform.Oracle_Param("v_ID", OracleType.Number, ParameterDirection.Output, ID.ToString());
        PR[1] = DataTransform.Oracle_Param("v_CorrespondingBankFileID", OracleType.Number, ParameterDirection.Input, CorrespondingBankFileID.ToString());
        PR[2] = DataTransform.Oracle_Param("v_CorrespondingBankUniqueId", OracleType.VarChar, ParameterDirection.Input, CorrespondingBankUniqueId);
        PR[3] = DataTransform.Oracle_Param("v_ProcessingDate", OracleType.DateTime, ParameterDirection.Input, ProcessingDate.ToString());
        PR[4] = DataTransform.Oracle_Param("v_DraftNo", OracleType.VarChar, ParameterDirection.Input, DraftNo);
        PR[5] = DataTransform.Oracle_Param("v_DraftPaidDate", OracleType.DateTime, ParameterDirection.Input, DraftPaidDate.ToString());
        PR[6] = DataTransform.Oracle_Param("v_BeneficiaryName", OracleType.VarChar, ParameterDirection.Input, BeneficiaryName);
        PR[7] = DataTransform.Oracle_Param("v_Amount", OracleType.Number, ParameterDirection.Input, Amount.ToString());
        PR[8] = DataTransform.Oracle_Param("v_ProcessingRemarks", OracleType.VarChar, ParameterDirection.Input, ProcessingRemarks);
        PR[9] = DataTransform.Oracle_Param("v_BranchCode", OracleType.VarChar, ParameterDirection.Input, BranchCode);
        PR[10] = DataTransform.Oracle_Param("v_Charges", OracleType.Number, ParameterDirection.Input, Charges.ToString());
        PR[11] = DataTransform.Oracle_Param("v_Remarks", OracleType.VarChar, ParameterDirection.Input, Remarks);
        PR[12] = DataTransform.Oracle_Param("v_Type", OracleType.VarChar, ParameterDirection.Input, Type);
        PR[13] = DataTransform.Oracle_Param("v_TEZStatus", OracleType.VarChar, ParameterDirection.Input, TEZStatus);
        PR[14] = DataTransform.Oracle_Param("v_TCSNo", OracleType.VarChar, ParameterDirection.Input, TCSNo);
        PR[15] = DataTransform.Oracle_Param("v_DispatchDate", OracleType.DateTime, ParameterDirection.Input, DispatchDate.ToString());
        PR[16] = DataTransform.Oracle_Param("v_DeliveryDate", OracleType.DateTime, ParameterDirection.Input, DeliveryDate.ToString());
        PR[17] = DataTransform.Oracle_Param("v_RecievedBy", OracleType.VarChar, ParameterDirection.Input, RecievedBy);
        PR[18] = DataTransform.Oracle_Param("v_A_UserID", OracleType.VarChar, ParameterDirection.Input, A_UserID);
        PR[19] = DataTransform.Oracle_Param("v_A_DateTime", OracleType.DateTime, ParameterDirection.Input, A_DateTime.ToString());
        PR[20] = DataTransform.Oracle_Param("v_E_UserID", OracleType.VarChar, ParameterDirection.Input, E_UserID);
        PR[21] = DataTransform.Oracle_Param("v_E_DateTime", OracleType.DateTime, ParameterDirection.Input, E_DateTime.ToString());
        //PR[8] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("RPS_SP_CorrBankFileData_Add", PR);


        //DS = DataTransform.ReteriveDataMultiple("EXEC RPS_SP_CorrespondingBankFileData_Add " + ID + "," + CorrespondingBankFileID + ",'" + CorrespondingBankUniqueId + "','" + ProcessingDate + "','" + DraftNo + "','" + DraftPaidDate + "','" + BeneficiaryName + "'," + Amount + ",'" + ProcessingRemarks + "','" + BranchCode + "'," + Charges + ",'" + Remarks + "','" + Type + "','" + TEZStatus + "','" + TCSNo + "','" + DispatchDate + "','" + DeliveryDate + "','" + RecievedBy + "','" + A_UserID + "','" + string.Empty + "','" + E_UserID + "','" + E_DateTime + "' ", "GET_ALL_USER");

        return DS;
    }

    public DataSet Get_RPS_SP_CorrespondingBankFilesPath_GetByCorrespondingBankId(int CorrespondingBankId)
    {
        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("v_CorrespondingBankId", OracleType.VarChar, ParameterDirection.Input, CorrespondingBankId.ToString());
        PR[1] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_CorrBankFilePath_GetCorrId", PR);

        //DS = DataTransform.ReteriveDataMultiple("EXEC RPS_SP_CorrespondingBankFilesPath_GetByCorrespondingBankId " + CorrespondingBankId, "GET_ALL_USER");
        return DS;
    }

    public DataSet Get_RPS_SP_CurrencyRate_GetAll(string RateDate)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC RPS_SP_CurrencyRate_GetAll '" + RateDate + "'", "GET_ALL_USER");
        //return DS;
        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("v_RateDate", OracleType.VarChar, ParameterDirection.Input, RateDate);
        PR[1] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("RPS_SP_CurrencyRate_GetAll", PR);
        return DS;

    }

    public DataSet Get_RPS_SP_CurrencyRate_Add(int ID, int CurrencyID, string PrincipleBankID, string RateDate, double CitibankRate, double CitiSellingRate, double CustomerRate, string A_UserID, DateTime A_DateTime, string E_UserID, DateTime E_DateTime)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC RPS_SP_CurrencyRate_Add " + ID + "," + CurrencyID + "," + PrincipleBankID + ",'" + RateDate + "'," + CitibankRate + "," + CitiSellingRate + "," + CustomerRate + ",'" + A_UserID + "','" + A_DateTime + "','" + E_UserID + "','" + E_DateTime + "'", "GET_ALL_USER");
        //return DS;


        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[11];
        PR[0] = DataTransform.Oracle_Param("v_ID", OracleType.Number, ParameterDirection.Input, ID.ToString());
        PR[1] = DataTransform.Oracle_Param("v_CurrencyID", OracleType.Number, ParameterDirection.Input, CurrencyID.ToString());
        PR[2] = DataTransform.Oracle_Param("v_PrincipleBankID", OracleType.VarChar, ParameterDirection.Input, PrincipleBankID);
        PR[3] = DataTransform.Oracle_Param("v_RateDate", OracleType.VarChar, ParameterDirection.Input, RateDate.ToString());
        PR[4] = DataTransform.Oracle_Param("v_CitibankRate", OracleType.Number, ParameterDirection.Input, CitibankRate.ToString());
        PR[5] = DataTransform.Oracle_Param("v_CitiSellingRate", OracleType.Number, ParameterDirection.Input, CitiSellingRate.ToString());
        PR[6] = DataTransform.Oracle_Param("iv_CustomerRate", OracleType.Number, ParameterDirection.Input, CustomerRate.ToString());
        PR[7] = DataTransform.Oracle_Param("v_A_UserID", OracleType.VarChar, ParameterDirection.Input, A_UserID.ToString());
        PR[8] = DataTransform.Oracle_Param("v_A_DateTime", OracleType.VarChar, ParameterDirection.Input, A_DateTime.ToString("dd-MMM-yyyy"));
        PR[9] = DataTransform.Oracle_Param("v_E_UserID", OracleType.VarChar, ParameterDirection.Input, E_UserID.ToString());
        PR[10] = DataTransform.Oracle_Param("v_E_DateTime", OracleType.VarChar, ParameterDirection.Input, E_DateTime.ToString("dd-MMM-yyyy"));


        //PR[11] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("RPS_SP_CurrencyRate_Add", PR);
        return DS;
    }

    public DataSet Get_RPS_SP_MoneyGramRemittance_GetLoadData(int PrincipleBankID, string UserID)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC RPS_SP_MoneyGramRemittance_GetLoadData " + PrincipleBankID + ",'" + UserID + "'", "GET_ALL_USER");
        //return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[3];
        PR[0] = DataTransform.Oracle_Param("v_PrincipleBankID", OracleType.VarChar, ParameterDirection.Input, PrincipleBankID.ToString());
        PR[1] = DataTransform.Oracle_Param("v_UserID", OracleType.VarChar, ParameterDirection.Input, UserID.ToString());
        PR[2] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("RPS_SP_MGramRemit_GetLoadDt", PR);
        return DS;
    }

    public DataSet GetTehsilProvince(string TEHSIL_ID)
    {

        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_GetTehsilProvince " + TEHSIL_ID, "GET_ALL_USER");
        //return DS;


        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("v_TEHSIL_ID", OracleType.VarChar, ParameterDirection.Input, TEHSIL_ID);
        PR[1] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_GetTehsilProvince", PR);
        return DS;


    }

    public DataSet ProvinceDistrict(string ID, string DistrictCode, string DistrictName)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_ProvinceDistrict '" + ID + "','" + DistrictCode + "','" + DistrictName + "'", "GET_ALL_USER");
        //return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[4];
        PR[0] = DataTransform.Oracle_Param("v_ID", OracleType.VarChar, ParameterDirection.Input, ID);
        PR[1] = DataTransform.Oracle_Param("v_DistrictCode", OracleType.VarChar, ParameterDirection.Input, DistrictCode);
        PR[2] = DataTransform.Oracle_Param("v_DistrictName", OracleType.VarChar, ParameterDirection.Input, DistrictName);
        PR[3] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_ProvinceDistrict", PR);
        return DS;

    }

    public DataSet Get_SPDS_PrintAgentSetup_GetAllDownload()
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SPDS_PrintAgentSetup_GetAllDownload ", "GET_ALL_USER");
        //return DS;


        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[1];
        PR[0] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SPDS_PrintAgentSetup_GetAllDownload", PR);
        return DS;
    }

    public DataSet Get_RPS_SP_DraftCancellation_Add(int ID, int DraftID, int CancelNo, DateTime CancelDate, DateTime AcknowledgeDate,
        string AcknowledgeRefNo, int CancelStatusID, int TracerID, bool ReIssue, bool Refund, bool SundryDuplicate, string A_UserID, DateTime A_DateTime, string E_UserID, DateTime E_DateTime)
    {
        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[16];

        PR[0] = DataTransform.Oracle_Param("iv_ID", OracleType.VarChar, ParameterDirection.Input, ID.ToString());
        PR[1] = DataTransform.Oracle_Param("v_DraftID", OracleType.VarChar, ParameterDirection.Input, DraftID.ToString());
        PR[3] = DataTransform.Oracle_Param("v_CancelNo", OracleType.VarChar, ParameterDirection.Input, CancelNo.ToString());
        PR[4] = DataTransform.Oracle_Param("v_CancelDate", OracleType.VarChar, ParameterDirection.Input, CancelDate.ToString());
        PR[5] = DataTransform.Oracle_Param("v_AcknowledgeDate", OracleType.VarChar, ParameterDirection.Input, AcknowledgeDate.ToString());
        PR[6] = DataTransform.Oracle_Param("v_AcknowledgeRefNo", OracleType.VarChar, ParameterDirection.Input, AcknowledgeRefNo.ToString());
        PR[7] = DataTransform.Oracle_Param("iv_CancelStatusID", OracleType.VarChar, ParameterDirection.Input, CancelStatusID.ToString());
        PR[8] = DataTransform.Oracle_Param("iv_TracerID", OracleType.VarChar, ParameterDirection.Input, TracerID.ToString());
        PR[9] = DataTransform.Oracle_Param("v_ReIssue", OracleType.VarChar, ParameterDirection.Input, ReIssue.ToString());
        PR[10] = DataTransform.Oracle_Param("v_Refund", OracleType.VarChar, ParameterDirection.Input, Refund.ToString());
        PR[11] = DataTransform.Oracle_Param("v_SundryDuplicate", OracleType.VarChar, ParameterDirection.Input, SundryDuplicate.ToString());
        PR[12] = DataTransform.Oracle_Param("v_A_UserID", OracleType.VarChar, ParameterDirection.Input, A_UserID.ToString());
        PR[13] = DataTransform.Oracle_Param("v_A_DateTime", OracleType.VarChar, ParameterDirection.Input, A_DateTime.ToString());
        PR[14] = DataTransform.Oracle_Param("v_E_UserID", OracleType.VarChar, ParameterDirection.Input, E_UserID.ToString());
        PR[15] = DataTransform.Oracle_Param("v_E_DateTime", OracleType.VarChar, ParameterDirection.Input, E_DateTime.ToString());
        DataTransform.Oracle_GetDataSetSP_DML("RPS_SP_DraftCancellation_Add", PR);

        //DS = DataTransform.ReteriveDataMultiple("EXEC RPS_SP_DraftCancellation_Add " + ID + "," + DraftID + "," + CancelNo + ",'" + CancelDate + "','" + AcknowledgeDate + "','" + AcknowledgeRefNo + "'," + CancelStatusID + "," + TracerID + ",'" + ReIssue + "','" + Refund + "','" + SundryDuplicate + "','" + A_UserID + "','" + A_DateTime + "','" + E_UserID + "','" + E_DateTime + "'", "GET_ALL_USER");
        return DS;
    }

    public DataSet Get_CMN_Branch_LOV(string BranchCode, string BranchName)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_CMN_Branch_LOV '" + BranchCode + "','" + BranchName + "'", "GET_ALL_USER");
        //return DS;
        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[3];
        PR[0] = DataTransform.Oracle_Param("v_BranchCode", OracleType.VarChar, ParameterDirection.Input, BranchCode);
        PR[1] = DataTransform.Oracle_Param("v_BranchName", OracleType.VarChar, ParameterDirection.Input, BranchName);

        PR[2] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_CMN_Branch_LOV", PR);
        return DS;


    }

    public DataSet Get_CMN_Branch_NEW_LOV(string BranchCode, string BranchName, string BankID)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_CMN_Branch_NEW_LOV '" + BranchCode + "','" + BranchName + "','" + BankID + "'", "GET_ALL_USER");
        //return DS;
        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[4];
        PR[0] = DataTransform.Oracle_Param("v_BranchCode", OracleType.VarChar, ParameterDirection.Input, BranchCode);
        PR[1] = DataTransform.Oracle_Param("v_BranchName", OracleType.VarChar, ParameterDirection.Input, BranchName);
        PR[2] = DataTransform.Oracle_Param("v_BankID", OracleType.VarChar, ParameterDirection.Input, BankID);
        PR[3] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_CMN_Branch_NEW_LOV", PR);
        return DS;


    }

    public DataSet Get_CMN_BranchZip_LOV(string BranchCode, string BranchName, string BankID)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_CMN_BranchZipd_LOV '" + BranchCode + "','" + BranchName + "'," + BankID + "", "GET_ALL_USER");
        //return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[4];
        PR[0] = DataTransform.Oracle_Param("v_BranchCode", OracleType.VarChar, ParameterDirection.Input, BranchCode);
        PR[1] = DataTransform.Oracle_Param("v_BranchName", OracleType.VarChar, ParameterDirection.Input, BranchName);
        PR[2] = DataTransform.Oracle_Param("v_BankID", OracleType.VarChar, ParameterDirection.Input, BankID);
        PR[3] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_CMN_BranchZipd_LOV", PR);
        return DS;


    }



    public DataSet Get_CMN_Country_LOV(string SBPCode, string CountryName)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_CMN_Country_LOV '" + SBPCode + "','" + CountryName + "'", "GET_ALL_USER");
        //return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[3];
        PR[0] = DataTransform.Oracle_Param("v_SBPCode", OracleType.VarChar, ParameterDirection.Input, SBPCode);
        PR[1] = DataTransform.Oracle_Param("v_CountryName", OracleType.VarChar, ParameterDirection.Input, CountryName);
        PR[2] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_CMN_Country_LOV", PR);
        return DS;




    }

    public DataSet Get_CMN_Courier_LOV(string CourierCode, string CourierName)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_CMN_Courier_LOV '" + CourierCode + "','" + CourierName + "'", "GET_ALL_USER");
        //return DS;
        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[3];
        PR[0] = DataTransform.Oracle_Param("v_CourierCode", OracleType.VarChar, ParameterDirection.Input, CourierCode);
        PR[1] = DataTransform.Oracle_Param("v_CourierName", OracleType.VarChar, ParameterDirection.Input, CourierName);
        PR[2] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_CMN_Courier_LOV", PR);
        return DS;




    }

    public DataSet Get_RPS_CustomerSetup_LOV(string BankCode, string BankName)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_RPS_CustomerSetup_LOV '" + BankCode + "','" + BankName + "'", "GET_ALL_USER");
        //return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[3];
        PR[0] = DataTransform.Oracle_Param("v_BankCode", OracleType.VarChar, ParameterDirection.Input, BankCode);
        PR[1] = DataTransform.Oracle_Param("v_BankName", OracleType.VarChar, ParameterDirection.Input, BankName);
        PR[2] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_RPS_CustomerSetup_LOV", PR);
        return DS;




    }

    public DataSet Get_RPS_DefaultMessages_LOV(string DefaultMessageCode, string Description)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_RPS_DefaultMessages_LOV '" + DefaultMessageCode + "','" + Description + "'", "GET_ALL_USER");
        //return DS;


        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[3];
        PR[0] = DataTransform.Oracle_Param("v_DefaultMessageCode", OracleType.VarChar, ParameterDirection.Input, DefaultMessageCode);
        PR[1] = DataTransform.Oracle_Param("v_Description", OracleType.VarChar, ParameterDirection.Input, Description);
        PR[2] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_RPS_DefaultMessages_LOV", PR);
        return DS;


    }

    public DataSet Get_RPS_DetailStatus_LOV(string StatusCode, string Description)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_RPS_DetailStatus_LOV '" + StatusCode + "','" + Description + "'", "GET_ALL_USER");
        //return DS;


        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[3];
        PR[0] = DataTransform.Oracle_Param("v_StatusCode", OracleType.VarChar, ParameterDirection.Input, StatusCode);
        PR[1] = DataTransform.Oracle_Param("v_Description", OracleType.VarChar, ParameterDirection.Input, Description);
        PR[2] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_RPS_DetailStatus_LOV", PR);
        return DS;


    }

    public DataSet Get_SPDS_InstrumentSetup_LOV(string INSTRUMENT_NAME)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_SPDS_InstrumentSetup_LOV '" + INSTRUMENT_NAME + "'", "GET_ALL_USER");
        //return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("v_INSTRUMENT_NAME", OracleType.VarChar, ParameterDirection.Input, INSTRUMENT_NAME);
        PR[1] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_SPDS_InstrumentSetup_LOV", PR);
        return DS;




    }

    public DataSet Get_RPS_MasterStatus_LOV(string MasterStatusCode, string Description)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_RPS_MasterStatus_LOV '" + MasterStatusCode + "','" + Description + "'", "GET_ALL_USER");
        //return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[3];
        PR[0] = DataTransform.Oracle_Param("v_MasterStatusCode", OracleType.VarChar, ParameterDirection.Input, MasterStatusCode);
        PR[1] = DataTransform.Oracle_Param("v_Description", OracleType.VarChar, ParameterDirection.Input, Description);

        PR[2] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_RPS_MasterStatus_LOV", PR);
        return DS;

    }

    public DataSet Get_SPDS_ProductMaster_LOV(string ProductCode, string ProductName)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_SPDS_ProductMaster_LOV '" + ProductCode + "','" + ProductName + "'", "GET_ALL_USER");
        //return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[3];
        PR[0] = DataTransform.Oracle_Param("v_ProductCode", OracleType.VarChar, ParameterDirection.Input, ProductCode);
        PR[1] = DataTransform.Oracle_Param("v_ProductName", OracleType.VarChar, ParameterDirection.Input, ProductName);

        PR[2] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_SPDS_ProductMaster_LOV", PR);
        return DS;



    }

    public DataSet Get_CMN_Province_LOV(string ProvinceCode, string ProvinceName)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_CMN_Province_LOV '" + ProvinceCode + "','" + ProvinceName + "'", "GET_ALL_USER");
        //return DS;
        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[3];
        PR[0] = DataTransform.Oracle_Param("v_ProvinceCode", OracleType.VarChar, ParameterDirection.Input, ProvinceCode);
        PR[1] = DataTransform.Oracle_Param("v_ProvinceName", OracleType.VarChar, ParameterDirection.Input, ProvinceName);

        PR[2] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_CMN_Province_LOV", PR);
        return DS;


    }

    public DataSet Get_SPDS_SignatorySetup_LOV(string ID, string SIGNATORY_NAME)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_SPDS_SignatorySetup_LOV '" + ID + "','" + SIGNATORY_NAME + "'", "GET_ALL_USER");
        //return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[3];
        PR[0] = DataTransform.Oracle_Param("v_ID", OracleType.VarChar, ParameterDirection.Input, ID);
        PR[1] = DataTransform.Oracle_Param("v_SIGNATORY_NAME", OracleType.VarChar, ParameterDirection.Input, SIGNATORY_NAME);

        PR[2] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_SPDS_SignatorySetup_LOV", PR);
        return DS;





    }

    public DataSet Get_CMN_Station_LOV(string StationCode, string StationName)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_CMN_Station_LOV '" + StationCode + "','" + StationName + "'", "GET_ALL_USER");
        //return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[3];
        PR[0] = DataTransform.Oracle_Param("v_StationCode", OracleType.VarChar, ParameterDirection.Input, StationCode);
        PR[1] = DataTransform.Oracle_Param("v_StationName", OracleType.VarChar, ParameterDirection.Input, StationName);

        PR[2] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_CMN_Station_LOV", PR);
        return DS;


    }

    // OLD FUNCTION HAVE TWO PARAMETER BUT STORED PROCEDURE HAVE 3 PARAMETER SO CERATE NEW FUNCTOIN
    //public DataSet Get_CMN_Tehsil_LOV(string TehsilCode, string TehsilName)
    //{
    //    //DataSet DS = new DataSet();
    //    //DS = DataTransform.ReteriveDataMultiple("EXEC SP_CMN_Tehsil_LOV '" + TehsilCode + "','" + TehsilName + "'", "GET_ALL_USER");
    //    //return DS;
    //}



    //public DataSet Get_CMN_Tehsil_LOV(string DistrictID,string TehsilCode, string TehsilName)
    //{
    //    //DataSet DS = new DataSet();
    //    //DS = DataTransform.ReteriveDataMultiple("EXEC SP_CMN_Tehsil_LOV '" + TehsilCode + "','" + TehsilName + "'", "GET_ALL_USER");
    //    //return DS;


    //    DataSet DS = new DataSet();
    //    OracleParameter[] PR = new OracleParameter[4];
    //    PR[0] = DataTransform.Oracle_Param("v_DistrictID", OracleType.VarChar, ParameterDirection.Input, DistrictID);
    //    PR[1] = DataTransform.Oracle_Param("v_TehsilCode ", OracleType.VarChar, ParameterDirection.Input, TehsilCode);
    //    PR[2] = DataTransform.Oracle_Param("v_TehsilName", OracleType.VarChar, ParameterDirection.Input, TehsilName);


    //    PR[3] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
    //    DS = DataTransform.Oracle_GetDataSetSP("SP_CMN_Tehsil_LOV", PR);
    //    return DS;



    //}

    public DataSet Get_CMN_Tehsil_LOV(string TehsilCode, string TehsilName)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_CMN_Tehsil_LOV '" + TehsilCode + "','" + TehsilName + "'", "GET_ALL_USER");
        //return DS;
        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[4];
        PR[0] = DataTransform.Oracle_Param("v_TehsilCode ", OracleType.VarChar, ParameterDirection.Input, TehsilCode);
        PR[1] = DataTransform.Oracle_Param("v_TehsilName", OracleType.VarChar, ParameterDirection.Input, TehsilName);
        PR[2] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_CMN_Tehsil_LOV", PR);
        return DS;
    }

    public DataSet DistrictTehsilLov(string ID, string TehsilCode, string TehsilName)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_DistrictTehsilLov " + ID + ",'" + TehsilCode + "','" + TehsilName + "'", "GET_ALL_USER");
        //return DS;

        ID = "173";

        if (TehsilCode == "0") { TehsilCode = "%"; }
        if (TehsilName == "0") { TehsilName = "%"; }


        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[4];
        PR[0] = DataTransform.Oracle_Param("v_ID", OracleType.VarChar, ParameterDirection.Input, ID);
        PR[1] = DataTransform.Oracle_Param("v_TehsilCode", OracleType.VarChar, ParameterDirection.Input, TehsilCode);
        PR[2] = DataTransform.Oracle_Param("v_TehsilName", OracleType.VarChar, ParameterDirection.Input, TehsilName);
        PR[3] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_DistrictTehsilLov", PR);
        return DS;


    }

    public DataSet Get_RPS_SP_DetailStatus_GetByCode(string Code)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC RPS_SP_DetailStatus_GetByCode '" + Code + "'", "GET_ALL_USER");
        //return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[4];
        PR[0] = DataTransform.Oracle_Param("v_Code", OracleType.VarChar, ParameterDirection.Input, Code);
        PR[1] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("RPS_SP_DetailStatus_GetByCode", PR);
        return DS;


    }

    public DataSet SP_ProductMaster_DP(string ProductCode, string ID)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_ProductMaster_DP '" + ProductCode + "','" + ID + "'", "GET_ALL_USER");
        //return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[3];
        PR[0] = DataTransform.Oracle_Param("v_ProductCode", OracleType.VarChar, ParameterDirection.Input, ProductCode);
        PR[1] = DataTransform.Oracle_Param("v_ID", OracleType.VarChar, ParameterDirection.Input, ID);
        PR[2] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_ProductMaster_DP", PR);
        return DS;



    }

    public DataSet SP_CustomerSetup_DP(string BankCode, string ID)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_CustomerSetup_DP '" + BankCode + "','" + ID + "'", "GET_ALL_USER");
        //return DS;


        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[3];
        PR[0] = DataTransform.Oracle_Param("v_BankCode", OracleType.VarChar, ParameterDirection.Input, BankCode);
        PR[1] = DataTransform.Oracle_Param("v_ID", OracleType.VarChar, ParameterDirection.Input, ID);


        PR[2] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("sp_customersetup_dp", PR);
        return DS;


    }

    public DataSet SP_CustomerSetup_MaxID()
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_CustomerSetup_MaxID ", "GET_ALL_USER");
        //return DS;




        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[1];
        PR[0] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_CustomerSetup_MaxID", PR);
        return DS;



    }

    public DataSet SP_CustomerFilesPath_DP(string CustomerID, string ID)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_CustomerFilesPath_DP '" + CustomerID + "','" + ID + "'", "GET_ALL_USER");
        //return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[3];
        PR[0] = DataTransform.Oracle_Param("v_CustomerID", OracleType.VarChar, ParameterDirection.Input, CustomerID);
        PR[1] = DataTransform.Oracle_Param("v_ID", OracleType.VarChar, ParameterDirection.Input, ID);
        PR[2] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_CustomerFilesPath_DP", PR);
        return DS;



    }

    public DataSet SP_Country_DP(string SBPCode, string ID)
    {


        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_Country_DP '" + SBPCode + "','" + ID + "'", "GET_ALL_USER");
        //return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[3];
        PR[0] = DataTransform.Oracle_Param("v_SBPCode", OracleType.VarChar, ParameterDirection.Input, SBPCode);
        PR[1] = DataTransform.Oracle_Param("v_ID", OracleType.VarChar, ParameterDirection.Input, ID);
        PR[2] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_Country_DP", PR);
        return DS;

    }

    public DataSet SP_Province_DP(string ProvinceCode, string CountryID, string ID)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_Province_DP '" + ProvinceCode + "','" + CountryID + "','" + ID + "'", "GET_ALL_USER");
        //return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[4];
        PR[0] = DataTransform.Oracle_Param("v_ProvinceCode", OracleType.VarChar, ParameterDirection.Input, ProvinceCode);
        PR[1] = DataTransform.Oracle_Param("v_CountryID", OracleType.VarChar, ParameterDirection.Input, CountryID);
        PR[2] = DataTransform.Oracle_Param("v_ID", OracleType.VarChar, ParameterDirection.Input, ID);
        PR[3] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_Province_DP", PR);
        return DS;






    }

    public DataSet SP_District_DP(string DistrictCode, string ProvinceID, string ID)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_District_DP '" + DistrictCode + "','" + ProvinceID + "','" + ID + "'", "GET_ALL_USER");
        //return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[4];
        PR[0] = DataTransform.Oracle_Param("v_DistrictCode", OracleType.VarChar, ParameterDirection.Input, DistrictCode);
        PR[1] = DataTransform.Oracle_Param("v_ProvinceID", OracleType.VarChar, ParameterDirection.Input, ProvinceID);
        PR[2] = DataTransform.Oracle_Param("v_ID", OracleType.VarChar, ParameterDirection.Input, ID);
        PR[3] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_District_DP", PR);
        return DS;

    }

    public DataSet Get_RPS_SP_Branch_GetByCode(string BranchCode, string BankCode)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC RPS_SP_Branch_GetByCode '" + BranchCode + "','" + BankCode + "'", "GET_ALL_USER");
        //return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[3];
        PR[0] = DataTransform.Oracle_Param("v_MasterID", OracleType.VarChar, ParameterDirection.Input, BranchCode);
        PR[1] = DataTransform.Oracle_Param("v_Code", OracleType.VarChar, ParameterDirection.Input, BankCode);
        PR[2] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("RPS_SP_Branch_GetByCode", PR);
        return DS;



    }

    public DataSet SP_Tehsil_DP(string TehsilCode, string DistrictID, string ID)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_Tehsil_DP '" + TehsilCode + "','" + DistrictID + "','" + ID + "'", "GET_ALL_USER");
        //return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[4];
        PR[0] = DataTransform.Oracle_Param("v_TehsilCode", OracleType.VarChar, ParameterDirection.Input, TehsilCode);
        PR[1] = DataTransform.Oracle_Param("v_DistrictID", OracleType.VarChar, ParameterDirection.Input, DistrictID);
        PR[2] = DataTransform.Oracle_Param("v_ID", OracleType.VarChar, ParameterDirection.Input, ID);

        PR[3] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_Tehsil_DP", PR);
        return DS;


    }

    public DataSet SP_Courier_DP(string CourierCode, string ID)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_Courier_DP '" + CourierCode + "','" + ID + "'", "GET_ALL_USER");
        //return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[3];
        PR[0] = DataTransform.Oracle_Param("v_CourierCode", OracleType.VarChar, ParameterDirection.Input, CourierCode);
        PR[1] = DataTransform.Oracle_Param("v_ID", OracleType.VarChar, ParameterDirection.Input, ID);
        PR[2] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_Courier_DP", PR);
        return DS;





    }

    public DataSet SP_Currency_DP(string CurrencyCode, string ID)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_Currency_DP '" + CurrencyCode + "','" + ID + "'", "GET_ALL_USER");
        //return DS;


        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[3];
        PR[0] = DataTransform.Oracle_Param("v_CurrencyCode", OracleType.VarChar, ParameterDirection.Input, CurrencyCode);
        PR[1] = DataTransform.Oracle_Param("v_ID", OracleType.VarChar, ParameterDirection.Input, ID);
        PR[2] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_Currency_DP", PR);
        return DS;


    }

    public DataSet SP_DefaultMessages_DP(string DefaultMessageCode, string ID)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_DefaultMessages_DP '" + DefaultMessageCode + "','" + ID + "'", "GET_ALL_USER");
        //return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[3];
        PR[0] = DataTransform.Oracle_Param("v_DefaultMessageCode", OracleType.VarChar, ParameterDirection.Input, DefaultMessageCode);
        PR[1] = DataTransform.Oracle_Param("v_ID", OracleType.VarChar, ParameterDirection.Input, ID);
        PR[2] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_DefaultMessages_DP", PR);
        return DS;




    }

    public DataSet SP_MasterStatus_DP(string MasterStatusCode, string CustomerID, string ID)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_MasterStatus_DP '" + MasterStatusCode + "','" + CustomerID + "','" + ID + "'", "GET_ALL_USER");
        //return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[4];
        PR[0] = DataTransform.Oracle_Param("v_MasterStatusCode", OracleType.VarChar, ParameterDirection.Input, MasterStatusCode);
        PR[1] = DataTransform.Oracle_Param("v_CustomerID", OracleType.VarChar, ParameterDirection.Input, CustomerID);
        PR[2] = DataTransform.Oracle_Param("v_ID", OracleType.VarChar, ParameterDirection.Input, ID);
        PR[3] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_MasterStatus_DP", PR);
        return DS;




    }

    public DataSet SP_DailyClosingBalance_DP(string BalanceDate, string PrincipleBankID, string CorrespondingBankID, string ID)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_DailyClosingBalance_DP '" + BalanceDate + "','" + PrincipleBankID + "','" + CorrespondingBankID + "','" + ID + "'", "GET_ALL_USER");
        //return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[5];
        PR[0] = DataTransform.Oracle_Param("v_BalanceDate", OracleType.VarChar, ParameterDirection.Input, BalanceDate);
        PR[1] = DataTransform.Oracle_Param("v_PrincipleBankID", OracleType.VarChar, ParameterDirection.Input, (PrincipleBankID == null) ? "" : PrincipleBankID);
        PR[2] = DataTransform.Oracle_Param("v_CorrespondingBankID", OracleType.VarChar, ParameterDirection.Input, (CorrespondingBankID == null) ? "" : CorrespondingBankID);
        PR[3] = DataTransform.Oracle_Param("v_ID", OracleType.VarChar, ParameterDirection.Input, ID);
        PR[4] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_DailyClosingBalance_DP", PR);
        return DS;





    }



    public DataSet Get_RPS_Batch_ALL(string CustomerName)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_RPS_Batch_ALL '" + CustomerName + "'", "GET_ALL_USER");
        //return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("v_PrincipleBankName", OracleType.VarChar, ParameterDirection.Input, CustomerName);
        PR[1] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_RPS_Batch_ALL", PR);
        return DS;








    }

    public DataSet SP_StarFileSetup_DP(string CustomerID, string PRODUCTID, string ID)
    {
        //DataSet DS = new DataSet();
        // DS = DataTransform.ReteriveDataMultiple("EXEC SP_StarFileSetup_DP '" + CustomerID + "','" + PRODUCTID + "','" + ID + "'", "GET_ALL_USER");
        // return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[4];
        PR[0] = DataTransform.Oracle_Param("v_CustomerID", OracleType.VarChar, ParameterDirection.Input, CustomerID);
        PR[1] = DataTransform.Oracle_Param("v_PRODUCTID", OracleType.VarChar, ParameterDirection.Input, PRODUCTID);
        PR[2] = DataTransform.Oracle_Param("v_ID", OracleType.VarChar, ParameterDirection.Input, ID);
        PR[3] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_StarFileSetup_DP", PR);
        return DS;

    }

    public DataSet Get_RPS_SP_Batch_GetByCode(string BatchNumber)
    {
        // DataSet DS = new DataSet();
        // DS = DataTransform.ReteriveDataMultiple("EXEC RPS_SP_Batch_GetByCode '" + BatchNumber + "'", "GET_ALL_USER");
        //return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("v_BatchNumber", OracleType.VarChar, ParameterDirection.Input, BatchNumber);
        PR[1] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("RPS_SP_Batch_GetByCode", PR);
        return DS;



    }

    public DataSet SP_CustomerInstrumentSetup_DP(string CustomerID, string InstrumentID, string ID)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_CustomerInstrumentSetup_DP '" + CustomerID + "','" + InstrumentID + "','" + ID + "'", "GET_ALL_USER");
        //return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[4];
        PR[0] = DataTransform.Oracle_Param("v_CustomerID", OracleType.VarChar, ParameterDirection.Input, CustomerID);
        PR[1] = DataTransform.Oracle_Param("v_InstrumentID", OracleType.VarChar, ParameterDirection.Input, InstrumentID);
        PR[2] = DataTransform.Oracle_Param("v_ID", OracleType.VarChar, ParameterDirection.Input, ID);
        PR[3] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_CustomerInstrumentSetup_DP", PR);
        return DS;
    }

    public DataSet SP_PODAWBSeriesIssuanceManagement_DP(string CourierID, string ID)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_PODAWBSeriesIssuanceManagement_DP '" + CourierID + "','" + ID + "'", "GET_ALL_USER");
        //return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[3];
        PR[0] = DataTransform.Oracle_Param("v_CourierID", OracleType.VarChar, ParameterDirection.Input, CourierID);
        PR[1] = DataTransform.Oracle_Param("v_ID", OracleType.VarChar, ParameterDirection.Input, ID);


        PR[2] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_PODAWBSeriesIssuanceMgMT_DP", PR);
        return DS;

    }

    public DataSet SP_Station_DP(string StationCode, string CourierID, string ID)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_Station_DP '" + StationCode + "','" + CourierID + "','" + ID + "'", "GET_ALL_USER");
        //return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[4];
        PR[0] = DataTransform.Oracle_Param("v_StationCode", OracleType.VarChar, ParameterDirection.Input, StationCode);
        PR[1] = DataTransform.Oracle_Param("v_CourierID", OracleType.VarChar, ParameterDirection.Input, CourierID);
        PR[2] = DataTransform.Oracle_Param("v_ID", OracleType.VarChar, ParameterDirection.Input, ID);

        PR[3] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_Station_DP", PR);
        return DS;



    }

    public DataSet SP_SignatorySetup_DP(string SIGNATORY_NAME, string ID)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_SignatorySetup_DP '" + SIGNATORY_NAME + "','" + ID + "'", "GET_ALL_USER");
        //return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[3];
        PR[0] = DataTransform.Oracle_Param("v_SIGNATORY_NAME", OracleType.VarChar, ParameterDirection.Input, SIGNATORY_NAME);
        PR[1] = DataTransform.Oracle_Param("v_ID", OracleType.VarChar, ParameterDirection.Input, ID);
        PR[2] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_SignatorySetup_DP", PR);
        return DS;

    }

    public DataSet SP_AuthorizationMatrix_DP(string CUSTOMER_ID, string INSTRUMENT_ID, string MAKE_SIGNATORY_ID, string CHECKER_SIGNATORY_ID, string CATEGORY_ID, string ID)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_AuthorizationMatrix_DP " + CUSTOMER_ID + "," + INSTRUMENT_ID + "," + MAKE_SIGNATORY_ID + "," + CHECKER_SIGNATORY_ID + "," + CATEGORY_ID + "," + ID + "", "GET_ALL_USER");
        //return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[7];
        PR[0] = DataTransform.Oracle_Param("v_CUSTOMER_ID", OracleType.VarChar, ParameterDirection.Input, CUSTOMER_ID);
        PR[1] = DataTransform.Oracle_Param("v_INSTRUMENT_ID", OracleType.VarChar, ParameterDirection.Input, INSTRUMENT_ID);
        PR[2] = DataTransform.Oracle_Param("v_MAKE_SIGNATORY_ID", OracleType.VarChar, ParameterDirection.Input, MAKE_SIGNATORY_ID);
        PR[3] = DataTransform.Oracle_Param("v_CHECKER_SIGNATORY_ID", OracleType.VarChar, ParameterDirection.Input, CHECKER_SIGNATORY_ID);
        PR[4] = DataTransform.Oracle_Param("v_CATEGORY_ID", OracleType.VarChar, ParameterDirection.Input, CATEGORY_ID);
        PR[5] = DataTransform.Oracle_Param("v_ID", OracleType.VarChar, ParameterDirection.Input, ID);
        PR[6] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_AuthorizationMatrix_DP", PR);
        return DS;
    }

    public DataSet SP_Holiday_DP(string ID, string HolidayCode)
    {
        // DataSet DS = new DataSet();
        // DS = DataTransform.ReteriveDataMultiple("EXEC SP_CMN_Holiday_DP '" + ID + "','" + HolidayCode + "'", "GET_ALL_USER");
        // return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[3];
        PR[0] = DataTransform.Oracle_Param("v_ID", OracleType.VarChar, ParameterDirection.Input, ID);
        PR[1] = DataTransform.Oracle_Param("v_HolidayCode", OracleType.VarChar, ParameterDirection.Input, HolidayCode);
        PR[2] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_CMN_Holiday_DP", PR);
        return DS;


    }

    public DataSet SP_ExciseRate_DP(string ExciseDate, string ID)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_ExciseRate_DP '" + ExciseDate + "','" + ID + "'", "GET_ALL_USER");
        //return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[3];
        PR[0] = DataTransform.Oracle_Param("v_ExciseDate", OracleType.VarChar, ParameterDirection.Input, ExciseDate);
        PR[1] = DataTransform.Oracle_Param("v_ID", OracleType.VarChar, ParameterDirection.Input, ID);
        PR[2] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_ExciseRate_DP", PR);
        return DS;

    }

    public DataSet Get_RPS_SP_MasterStatus_GetByCode(string MasterId, string ID)
    {
        //  DataSet DS = new DataSet();
        //  DS = DataTransform.ReteriveDataMultiple("EXEC RPS_SP_MasterStatus_GetByCode " + MasterId + ",'" + ID + "'", "GET_ALL_USER");
        //  return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[4];
        PR[0] = DataTransform.Oracle_Param("v_MasterId", OracleType.VarChar, ParameterDirection.Input, MasterId);
        PR[1] = DataTransform.Oracle_Param("v_ID", OracleType.VarChar, ParameterDirection.Input, ID);
        PR[2] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("RPS_SP_MasterStatus_GetByCode", PR);
        return DS;


    }

    public DataSet SP_AuthorizeRecord(string TableName, string A_UserID, string A_DateTime, string ID)
    {
        DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_AuthorizeRecord '" + TableName + "','" + A_UserID + "','" + A_DateTime + "','" + ID + "'", "GET_ALL_USER");


        DS = DataTransform.ReteriveDataMultiple("UPDATE " + TableName.ToLower() + " SET A_USERID = '" + A_UserID + "', A_DATETIME = TO_DATE('" + A_DateTime + "','mm-dd-yyyy') WHERE ID = '" + ID + "'", "GET_ALL_USER");

        /*
        string EditLink = "0";
        string IsAuthFG = "";

        DataSet DS = new DataSet();
        DS = DataTransform.ReteriveDataMultiple("SELECT EditLink, IsAuthFG FROM " + TableName + " WHERE ID=" + ID, "GET_ALL_USER");
        if (DS.Tables[0].Rows.Count == 0)
        { 
            EditLink = "0";
            IsAuthFG = "";
        }
        else
        { 
            EditLink = DS.Tables[0].Rows[0]["EditLink"].ToString();
            IsAuthFG = DS.Tables[0].Rows[0]["IsAuthFG"].ToString(); 
        }

        if (IsAuthFG == "Edit")
        {
            DS = DataTransform.ReteriveDataMultiple("EXEC SP_AuthorizeRecord '" + TableName + "','" + A_UserID + "','" + A_DateTime + "','" + ID + "'", "GET_ALL_USER");
            DS = DataTransform.ReteriveDataMultiple("DELETE FROM " + TableName + " WHERE ID=" + EditLink, "GET_ALL_USER");
        }
        else if (IsAuthFG == "Insert")
        { DS = DataTransform.ReteriveDataMultiple("EXEC SP_AuthorizeRecord_Insert '" + TableName + "','" + A_UserID + "','" + A_DateTime + "','" + ID + "'", "GET_ALL_USER"); }
        */
        return DS;
    }



    public DataSet SP_DetailStatus_DP(string StatusCode, string MasterStatusID, string ID)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_DetailStatus_DP '" + StatusCode + "','" + MasterStatusID + "','" + ID + "'", "GET_ALL_USER");
        //return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[4];
        PR[0] = DataTransform.Oracle_Param("v_StatusCode", OracleType.VarChar, ParameterDirection.Input, StatusCode);
        PR[1] = DataTransform.Oracle_Param("v_MasterStatusID", OracleType.VarChar, ParameterDirection.Input, MasterStatusID);
        PR[2] = DataTransform.Oracle_Param("v_ID", OracleType.VarChar, ParameterDirection.Input, ID);

        PR[3] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_DetailStatus_DP", PR);
        return DS;


    }

    public DataSet SP_InstrumentSetup_DP(string INSTRUMENT_NAME, string ID)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_InstrumentSetup_DP '" + INSTRUMENT_NAME + "','" + ID + "'", "GET_ALL_USER");
        //return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[3];
        PR[0] = DataTransform.Oracle_Param("v_INSTRUMENT_NAME", OracleType.VarChar, ParameterDirection.Input, INSTRUMENT_NAME);
        PR[1] = DataTransform.Oracle_Param("v_ID", OracleType.VarChar, ParameterDirection.Input, ID);
        PR[2] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_InstrumentSetup_DP", PR);
        return DS;


    }

    #region -----------------Draft Footer Message Duplicate Check SP----------------------
    public DataSet SP_DraftFooterMessage_DP(string PrincipleBankID, string CorrespondingBankID, string InstrumentID, string ID)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC RPS_DRAFTFOOTERMESSAGE_DP '" + PrincipleBankID + "','" + CorrespondingBankID + "','" + InstrumentID + "','" + ID + "'", "GET_ALL_USER");
        //return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[5];
        PR[0] = DataTransform.Oracle_Param("v_PrincipleBankID", OracleType.VarChar, ParameterDirection.Input, PrincipleBankID);
        PR[1] = DataTransform.Oracle_Param("v_CorrespondingBankID", OracleType.VarChar, ParameterDirection.Input, CorrespondingBankID);
        PR[2] = DataTransform.Oracle_Param("v_InStrumentID", OracleType.VarChar, ParameterDirection.Input, InstrumentID);
        PR[3] = DataTransform.Oracle_Param("v_ID", OracleType.VarChar, ParameterDirection.Input, ID);
        PR[4] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("RPS_DRAFTFOOTERMESSAGE_DP", PR);
        return DS;
    }
    #endregion

    public DataSet SP_PrintAgentDetail_DP(string PRINT_AGENT_ID, string PRINT_AGENT_NAME, string ID)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_PrintAgentDetail_DP '" + PRINT_AGENT_ID + "','" + PRINT_AGENT_NAME + "' , '" + ID + "'", "GET_ALL_USER");
        //return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[4];
        PR[0] = DataTransform.Oracle_Param("v_PRINT_AGENT_ID", OracleType.VarChar, ParameterDirection.Input, PRINT_AGENT_ID);
        PR[1] = DataTransform.Oracle_Param("v_PRINT_LOCATION_NAME", OracleType.VarChar, ParameterDirection.Input, PRINT_AGENT_NAME);
        PR[2] = DataTransform.Oracle_Param("v_ID", OracleType.VarChar, ParameterDirection.Input, ID);


        PR[3] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_PrintAgentDetail_DP", PR);
        return DS;

    }



    public DataSet Get_GetDraftHolded_ALL(string DraftNo, string BeneficiaryName, string RemitterName, string RemittanceRefNo, string BeneficiaryNo, string RemitterNo)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC RPS_SP_Draft_GetAllHolded '" + DraftNo + "','" + BeneficiaryName + "','" + RemitterName + "','" + RemittanceRefNo + "','" + BeneficiaryNo + "','" + RemitterNo + "'", "GET_ALL_USER");
        //return DS;


        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[7];
        PR[0] = DataTransform.Oracle_Param("v_DraftNo", OracleType.VarChar, ParameterDirection.Input, DraftNo);
        PR[1] = DataTransform.Oracle_Param("v_BeneficiaryName", OracleType.VarChar, ParameterDirection.Input, BeneficiaryName);
        PR[2] = DataTransform.Oracle_Param("v_RemitterName", OracleType.VarChar, ParameterDirection.Input, RemitterName);
        PR[3] = DataTransform.Oracle_Param("v_RemittanceRefNo", OracleType.VarChar, ParameterDirection.Input, RemittanceRefNo);
        PR[4] = DataTransform.Oracle_Param("v_BeneficiaryNo", OracleType.VarChar, ParameterDirection.Input, BeneficiaryNo);
        PR[5] = DataTransform.Oracle_Param("v_RemitterNo", OracleType.VarChar, ParameterDirection.Input, RemitterNo);

        PR[6] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("RPS_SP_Draft_GetAllHolded", PR);
        return DS;


    }

    public DataSet Get_GetDraftReleased_ALL(string DraftNo, string BeneficiaryName, string RemitterName, string RemittanceRefNo, string BeneficiaryNo, string RemitterNo)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC RPS_SP_Draft_GetAllReleased '" + DraftNo + "','" + BeneficiaryName + "','" + RemitterName + "','" + RemittanceRefNo + "','" + BeneficiaryNo + "','" + RemitterNo + "'", "GET_ALL_USER");
        //return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[7];
        PR[0] = DataTransform.Oracle_Param("v_DraftNo", OracleType.VarChar, ParameterDirection.Input, DraftNo);
        PR[1] = DataTransform.Oracle_Param("v_BeneficiaryName", OracleType.VarChar, ParameterDirection.Input, BeneficiaryName);
        PR[2] = DataTransform.Oracle_Param("v_RemitterName", OracleType.VarChar, ParameterDirection.Input, RemitterName);
        PR[3] = DataTransform.Oracle_Param("v_RemittanceRefNo", OracleType.VarChar, ParameterDirection.Input, RemittanceRefNo);
        PR[4] = DataTransform.Oracle_Param("v_BeneficiaryNo", OracleType.VarChar, ParameterDirection.Input, BeneficiaryNo);
        PR[5] = DataTransform.Oracle_Param("v_RemitterNo", OracleType.VarChar, ParameterDirection.Input, RemitterNo);

        PR[6] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("RPS_SP_Draft_GetAllReleased", PR);
        return DS;

    }

    public DataSet Get_GetDraftHolded(string ID)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC RPS_SP_Draft_GetHolded " + ID + "", "GET_ALL_USER");
        //return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];

        PR[0] = DataTransform.Oracle_Param("v_ID", OracleType.VarChar, ParameterDirection.Input, ID);

        PR[1] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("RPS_SP_Draft_GetHolded", PR);
        return DS;


    }

    public DataSet Get_GetDraftReleased(string ID)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC RPS_SP_Draft_GetReleased " + ID + "", "GET_ALL_USER");
        //return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];

        PR[0] = DataTransform.Oracle_Param("v_ID", OracleType.VarChar, ParameterDirection.Input, ID);

        PR[1] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("RPS_SP_Draft_GetReleased", PR);
        return DS;


    }

    public DataSet Get_PrintLocation_ALL(string PrintLocationName)
    {
        // DataSet DS = new DataSet();
        // DS = DataTransform.ReteriveDataMultiple("EXEC SP_PrintLocation_ALL '" + PrintLocationName + "'", "GET_ALL_USER");
        // return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];

        PR[0] = DataTransform.Oracle_Param("v_PrintLocationName", OracleType.VarChar, ParameterDirection.Input, PrintLocationName);

        PR[1] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_PrintLocation_ALL", PR);
        return DS;





    }

    //public DataSet SP_PrintingLocationPricing_DP(string PrintingAgentID, string PrintingLocationID, string ProductID, string ID)
    //{
    //    DataSet DS = new DataSet();
    //    DS = DataTransform.ReteriveDataMultiple("EXEC SP_PrintingLocationPricing_DP '" + PrintingAgentID + "','" + PrintingLocationID + "','" + ProductID + "','" + ID + "'", "GET_ALL_USER");
    //    return DS;
    //}

    public DataSet SP_PrintingLocationPricing_DP(string PrintingLocationID, string ProductID, string ID)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_PrintingLocationPricing_DP '" + PrintingLocationID + "','" + ProductID + "','" + ID + "'", "GET_ALL_USER");
        //return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[4];

        PR[0] = DataTransform.Oracle_Param("v_PrintingLocationID", OracleType.VarChar, ParameterDirection.Input, PrintingLocationID);
        PR[1] = DataTransform.Oracle_Param("v_ProductID", OracleType.VarChar, ParameterDirection.Input, ProductID);
        PR[2] = DataTransform.Oracle_Param("v_ID", OracleType.VarChar, ParameterDirection.Input, ID);


        PR[3] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_PrintingLocationPricing_DP", PR);
        return DS;



    }

    public DataSet SP_CourierPricing_Master_DP(string CourierID, string ID)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_CourierPricing_Master_DP '" + CourierID + "','" + ID + "'", "GET_ALL_USER");
        //return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[4];

        PR[0] = DataTransform.Oracle_Param("v_CourierID", OracleType.VarChar, ParameterDirection.Input, CourierID);
        PR[1] = DataTransform.Oracle_Param("v_ID", OracleType.VarChar, ParameterDirection.Input, ID);


        PR[3] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_PrintingLocationPricing_DP", PR);
        return DS;

    }

    public DataSet Get_RPS_SP_Station_GetByCode(string Code)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC RPS_SP_Station_GetByCode '" + Code + "'", "GET_ALL_USER");
        //return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];

        PR[0] = DataTransform.Oracle_Param("v_Code", OracleType.VarChar, ParameterDirection.Input, Code);
        PR[1] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_PrintingLocationPricing_DP", PR);
        return DS;


    }

    public DataSet Get_SP_SPDS_ProductArrangement_Search(string CustomerID, string ProductID)
    {
        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[3];

        PR[0] = DataTransform.Oracle_Param("v_CustomerID", OracleType.VarChar, ParameterDirection.Input, CustomerID);
        PR[1] = DataTransform.Oracle_Param("v_ProductID", OracleType.VarChar, ParameterDirection.Input, ProductID);
        PR[2] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_SPDS_ProdArrang_Search", PR);
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_SPDS_ProductArrangement_Search '" + CustomerID + "','" + ProductID + "'", "GET_ALL_USER");
        return DS;
    }

    public DataSet SP_UniversalUploadCofiguration_DP(string ConfigurationName, string ID)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_UniversalUploadCofiguration_DP '" + ConfigurationName + "','" + ID + "'", "GET_ALL_USER");
        //return DS;


        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[3];

        PR[0] = DataTransform.Oracle_Param("v_ConfigurationName", OracleType.VarChar, ParameterDirection.Input, ConfigurationName);
        PR[1] = DataTransform.Oracle_Param("v_ID", OracleType.VarChar, ParameterDirection.Input, ID);
        PR[2] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_UniversalUploadCofig_DP", PR);
        return DS;
    }

    public DataSet SP_DataLoadCofiguration_DP(string p_CONF_ID, string p_CONF_DEF_ID)
    {

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[3];

        PR[0] = DataTransform.Oracle_Param("p_CONF_ID", OracleType.VarChar, ParameterDirection.Input, p_CONF_ID);
        PR[1] = DataTransform.Oracle_Param("p_CONF_DEF_ID", OracleType.VarChar, ParameterDirection.Input, p_CONF_DEF_ID);
        PR[2] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_CONFIG_DEF_MASTER_DP", PR);
        return DS;
    }
    public DataSet SP_DataLoadCofigurationDetail_DP(string p_CONF_ID, string p_CONF_DEF_ID, string p_COLUMN_ORDER)
    {
        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[4];
        PR[0] = DataTransform.Oracle_Param("p_CONF_ID", OracleType.VarChar, ParameterDirection.Input, p_CONF_ID);
        PR[1] = DataTransform.Oracle_Param("p_CONF_DEF_ID", OracleType.VarChar, ParameterDirection.Input, p_CONF_DEF_ID);
        PR[2] = DataTransform.Oracle_Param("p_COLUMN_ORDER", OracleType.VarChar, ParameterDirection.Input, p_COLUMN_ORDER);
        PR[3] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_CONFIG_DEF_DETAIL_DP", PR);
        return DS;
    }
    public DataSet SP_SysColumns_All(string UniversalUploadID)
    {
        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];

        PR[0] = DataTransform.Oracle_Param("v_UniversalUploadID", OracleType.VarChar, ParameterDirection.Input, UniversalUploadID);
        PR[1] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_SysColumns_ALL", PR);

        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_SysColumns_All '" + UniversalUploadID + "'", "GET_ALL_USER");
        return DS;
    }

    public DataSet Get_SP_UPDATE_SPDS_PrintAgentDetailZipCode(int ID, int PRINT_AGENT_DETAIL_ID, int MASTER_ZIP_CODE_ID, int STATUS)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_UPDATE_SPDS_PrintAgentDetailZipCode " + ID + "," + PRINT_AGENT_DETAIL_ID + "," + MASTER_ZIP_CODE_ID + "," + STATUS + "", "GET_ALL_USER");
        //return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[4];

        PR[0] = DataTransform.Oracle_Param("v_ID", OracleType.VarChar, ParameterDirection.Input, ID.ToString());
        PR[1] = DataTransform.Oracle_Param("v_PRINT_AGENT_DETAIL_ID", OracleType.VarChar, ParameterDirection.Input, PRINT_AGENT_DETAIL_ID.ToString());
        PR[2] = DataTransform.Oracle_Param("v_MASTER_ZIP_CODE_ID", OracleType.VarChar, ParameterDirection.Input, MASTER_ZIP_CODE_ID.ToString());
        PR[3] = DataTransform.Oracle_Param("v_STATUS", OracleType.VarChar, ParameterDirection.Input, STATUS.ToString());


        //        PR[4] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_UPDATE_PrintAgentDtl_ZpCode", PR);
        return DS;
    }

    public DataSet Get_SP_INSERT_SPDS_PrintAgentDetailZipCode(int ID, int PRINT_AGENT_DETAIL_ID, int MASTER_ZIP_CODE_ID, int STATUS)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_INSERT_SPDS_PrintAgentDetailZipCode " + ID + "," + PRINT_AGENT_DETAIL_ID + "," + MASTER_ZIP_CODE_ID + "," + STATUS + "", "GET_ALL_USER");
        //return DS;



        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[4];

        PR[0] = DataTransform.Oracle_Param("v_ID", OracleType.VarChar, ParameterDirection.Input, ID.ToString());
        PR[1] = DataTransform.Oracle_Param("v_PRINT_AGENT_DETAIL_ID", OracleType.VarChar, ParameterDirection.Input, PRINT_AGENT_DETAIL_ID.ToString());
        PR[2] = DataTransform.Oracle_Param("v_MASTER_ZIP_CODE_ID", OracleType.VarChar, ParameterDirection.Input, MASTER_ZIP_CODE_ID.ToString());
        PR[3] = DataTransform.Oracle_Param("v_STATUS", OracleType.VarChar, ParameterDirection.Input, STATUS.ToString());


        //        PR[4] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_INS_SPDSPrintAgntDtlZipCode", PR);
        return DS;
    }

    public DataSet Get_SP_SPDS_PrintAgentDetailZipCode_Authorized(int ID, int PRINT_AGENT_DETAIL_ID, int MASTER_ZIP_CODE_ID, int STATUS, string Userid)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_SPDS_PrintAgentDetailZipCode_Authorized " + ID + "," + PRINT_AGENT_DETAIL_ID + "," + MASTER_ZIP_CODE_ID + "," + STATUS + ",'" + Userid + "'", "GET_ALL_USER");
        //return DS;



        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[5];

        PR[0] = DataTransform.Oracle_Param("v_ID", OracleType.VarChar, ParameterDirection.Input, ID.ToString());
        PR[1] = DataTransform.Oracle_Param("v_PRINT_AGENT_DETAIL_ID", OracleType.VarChar, ParameterDirection.Input, PRINT_AGENT_DETAIL_ID.ToString());
        PR[2] = DataTransform.Oracle_Param("v_MASTER_ZIP_CODE_ID", OracleType.VarChar, ParameterDirection.Input, MASTER_ZIP_CODE_ID.ToString());
        PR[3] = DataTransform.Oracle_Param("v_STATUS", OracleType.VarChar, ParameterDirection.Input, STATUS.ToString());
        PR[4] = DataTransform.Oracle_Param("v_Userid", OracleType.VarChar, ParameterDirection.Input, Userid.ToString());


        //        PR[4] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_PrintAgentDtlZipCode_Auth", PR);
        return DS;
    }

    public DataSet Get_SP_SPDS_PrintAgentDetailZipCode_CheckZipcode(int MASTER_ZIP_CODE_ID)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_SPDS_PrintAgentDetailZipCode_CheckZipcode " + MASTER_ZIP_CODE_ID + "", "GET_ALL_USER");
        //return DS;





        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];

        PR[0] = DataTransform.Oracle_Param("v_MASTER_ZIP_CODE_ID", OracleType.VarChar, ParameterDirection.Input, MASTER_ZIP_CODE_ID.ToString());

        PR[1] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_PrntAgntDtlZipCd_ChkZipcode", PR);
        return DS;
    }

    public DataSet Get_SP_SPDS_PrintAgentDetail_MaxID()
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_SPDS_PrintAgentDetail_MaxID ", "GET_ALL_USER");
        //return DS;


        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[1];


        PR[0] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_SPDS_PrintAgentDetail_MaxID", PR);
        return DS;
    }

    public DataSet Get_RPS_MasterZipCodeLOV_ALL(string CourierID, string StationID, string ServiceID, string BankID, string BranchID, string ZipCode)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_RPS_MasterZipCodeLOVAgent_ALL '" + CourierID + "','" + StationID + "','" + ServiceID + "','" + BankID + "','" + BranchID + "','" + ZipCode + "'", "GET_ALL_USER");
        //return DS;


        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[7];
        PR[0] = DataTransform.Oracle_Param("v_CourierID", OracleType.VarChar, ParameterDirection.Input, CourierID.ToString());
        PR[1] = DataTransform.Oracle_Param("v_StationID", OracleType.VarChar, ParameterDirection.Input, StationID.ToString());
        PR[2] = DataTransform.Oracle_Param("v_ServiceID", OracleType.VarChar, ParameterDirection.Input, ServiceID.ToString());
        PR[3] = DataTransform.Oracle_Param("v_BankID", OracleType.VarChar, ParameterDirection.Input, BankID.ToString());
        PR[4] = DataTransform.Oracle_Param("v_BranchID", OracleType.VarChar, ParameterDirection.Input, BranchID.ToString());
        PR[5] = DataTransform.Oracle_Param("v_ZipCode", OracleType.VarChar, ParameterDirection.Input, ZipCode.ToString());

        PR[6] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_RPS_MasterZipCodeLOVAgntALL", PR);
        return DS;
    }

    public DataSet SP_DataFileTransferConfiguration_DP(string ConfigurationName, string ID)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_DataFileTransferConfiguration_DP '" + ConfigurationName + "','" + ID + "'", "GET_ALL_USER");
        //return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[3];
        PR[0] = DataTransform.Oracle_Param("v_ConfigurationName", OracleType.VarChar, ParameterDirection.Input, ConfigurationName);
        PR[1] = DataTransform.Oracle_Param("v_ID", OracleType.VarChar, ParameterDirection.Input, ID);
        PR[2] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_DataFileTransferConfig_DP", PR);
        return DS;

    }

    public DataSet SP_SysColumnsDownload_All(string DataFileTransferConfigurationID)
    {
        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("v_DataFileTransferConfiguratio", OracleType.VarChar, ParameterDirection.Input, DataFileTransferConfigurationID);
        PR[1] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_SysColumnsDownload_ALL", PR);

        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_SysColumnsDownload_All '" + DataFileTransferConfigurationID + "'", "GET_ALL_USER");
        return DS;
    }

    public DataSet Get_SP_SPDS_CustomerInstrumentSetup_GetByCode(string CustomerID, string ID)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_SPDS_CustomerInstrumentSetup_GetByCode '" + CustomerID + "','" + ID + "'", "GET_ALL_USER");
        //return DS;


        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[3];
        PR[0] = DataTransform.Oracle_Param("v_CustomerID", OracleType.VarChar, ParameterDirection.Input, CustomerID.ToString());
        PR[1] = DataTransform.Oracle_Param("v_ID", OracleType.VarChar, ParameterDirection.Input, ID.ToString());

        PR[2] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_SPDS_CustInstSetup_GetCode", PR);
        return DS;
    }

    public DataSet SP_SPDS_CustomerInstrumentSetupLOV_ALL(string CUSTOMERID, string CUSTOMER_NAME, string INSTRUMENT_NAME)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_SPDS_CustomerInstrumentSetupLOV_ALL '" + CUSTOMER_NAME + "','" + INSTRUMENT_NAME + "'," + CUSTOMERID + "", "GET_ALL_USER");
        //return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[4];
        PR[0] = DataTransform.Oracle_Param("v_CUSTOMERID", OracleType.VarChar, ParameterDirection.Input, CUSTOMERID.ToString());
        PR[1] = DataTransform.Oracle_Param("v_CUSTOMER_NAME", OracleType.VarChar, ParameterDirection.Input, CUSTOMER_NAME.ToString());
        PR[2] = DataTransform.Oracle_Param("v_INSTRUMENT_NAME", OracleType.VarChar, ParameterDirection.Input, INSTRUMENT_NAME.ToString());

        PR[3] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_SPDS_CustINSTSetupLOV_ALL", PR);
        return DS;
    }

    public DataSet Get_RPS_SP_PrintAgentDetail_GetByCode(string PrintAgentID, string ID)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC RPS_SP_PrintAgentDetail_GetByCode '" + PrintAgentID + "','" + ID + "'", "GET_ALL_USER");
        //return DS;


        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[3];
        PR[0] = DataTransform.Oracle_Param("v_PrintAgentID", OracleType.VarChar, ParameterDirection.Input, PrintAgentID.ToString());
        PR[1] = DataTransform.Oracle_Param("v_ID", OracleType.VarChar, ParameterDirection.Input, ID.ToString());
        PR[2] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("RPS_SP_PrintAgentDtl_GetByCode", PR);
        return DS;
    }

    public DataSet SP_SPDS_PrintAgentDetailLOV_ALL(string PRINT_AGENT_ID, string PRINT_LOCATION_ID, string DONGAL_PIN, string PrintAgentID)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_SPDS_PrintAgentDetailLOV_ALL '" + PRINT_AGENT_ID + "','" + PRINT_LOCATION_ID + "','" + DONGAL_PIN + "'" + PrintAgentID + "'", "GET_ALL_USER");
        //return DS;


        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[5];
        PR[0] = DataTransform.Oracle_Param("v_PRINT_AGENT_ID", OracleType.VarChar, ParameterDirection.Input, PRINT_AGENT_ID.ToString());
        PR[1] = DataTransform.Oracle_Param("v_PRINT_LOCATION_ID", OracleType.VarChar, ParameterDirection.Input, PRINT_LOCATION_ID.ToString());
        PR[2] = DataTransform.Oracle_Param("v_DONGAL_PIN", OracleType.VarChar, ParameterDirection.Input, DONGAL_PIN.ToString());
        PR[3] = DataTransform.Oracle_Param("v_PrintAgentID", OracleType.VarChar, ParameterDirection.Input, PrintAgentID.ToString());


        PR[4] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_PrintAgentDetailLOV_ALL", PR);
        return DS;
    }

    public DataSet SP_SPDS_PrintAgentDetail_Location_LOV(string PRINT_AGENT_ID, string PRINT_LOCATION_ID, string DONGAL_PIN)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_SPDS_PrintAgentDetail_Location_LOV '" + PRINT_AGENT_ID + "','" + PRINT_LOCATION_ID + "','" + DONGAL_PIN + "'", "GET_ALL_USER");
        //return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[4];
        PR[0] = DataTransform.Oracle_Param("v_PRINT_AGENT_ID", OracleType.VarChar, ParameterDirection.Input, PRINT_AGENT_ID.ToString());
        PR[1] = DataTransform.Oracle_Param("v_PRINT_LOCATION_ID", OracleType.VarChar, ParameterDirection.Input, PRINT_LOCATION_ID.ToString());
        PR[2] = DataTransform.Oracle_Param("v_DONGAL_PIN", OracleType.VarChar, ParameterDirection.Input, DONGAL_PIN.ToString());

        PR[3] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_PrintAgentDtl_Location_LOV", PR);
        return DS;
    }

    public DataSet Get_RPS_Draft_ALL(string DraftNo, string PrincipleBankID, string CorrespondingBankID)
    {
        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[4];
        PR[0] = DataTransform.Oracle_Param("v_DraftNo", OracleType.VarChar, ParameterDirection.Input, DraftNo.ToString());
        PR[1] = DataTransform.Oracle_Param("v_PrincipleBankID", OracleType.VarChar, ParameterDirection.Input, PrincipleBankID.ToString());
        PR[2] = DataTransform.Oracle_Param("v_CorrespondingBankID", OracleType.VarChar, ParameterDirection.Input, CorrespondingBankID.ToString());

        PR[3] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_RPS_Draft_ALL", PR);
        return DS;
    }

    public DataSet Get_RPS_LOV_DataConfiguration_ALL(string P_CONF_ID, string P_CONF_DESC)
    {
        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[3];
        PR[0] = DataTransform.Oracle_Param("P_CONF_ID", OracleType.VarChar, ParameterDirection.Input, P_CONF_ID.ToString());
        PR[1] = DataTransform.Oracle_Param("P_CONF_DESC", OracleType.VarChar, ParameterDirection.Input, P_CONF_DESC.ToString());
        PR[2] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_CONFIG_MASTER_ALL", PR);
        return DS;
    }
    public DataSet Get_RPS_LOV_DataConfigurationDetail_ALL(string P_CONF_ID, string P_column_order, string P_column_name)
    {
        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[4];
        PR[0] = DataTransform.Oracle_Param("P_CONF_ID", OracleType.VarChar, ParameterDirection.Input, P_CONF_ID);
        PR[1] = DataTransform.Oracle_Param("P_column_order", OracleType.VarChar, ParameterDirection.Input, (P_column_order == null) ? "%" : P_column_order);
        PR[2] = DataTransform.Oracle_Param("P_column_name", OracleType.VarChar, ParameterDirection.Input, (P_column_name == null) ? "%" : P_column_name);
        PR[3] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_CONFIG_MAST_DTL_ALL", PR);
        return DS;
    }


    public DataSet Get_SP_RPS_DraftInquiry_ALL(string DRAFTNO, string REMITTERNO, string REMITTERNAME, string BENEFICIARYNO, string BENEFICIARYNAME, string STAR_DRAFTNO, string STATION_NAME, string POD_NO, string REMITTANCE_NO, string SPDS_TYPE)
    {
        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[13];
        PR[0] = DataTransform.Oracle_Param("v_DRAFTNO", OracleType.VarChar, ParameterDirection.Input, DRAFTNO);
        PR[1] = DataTransform.Oracle_Param("v_REMITTERNO", OracleType.VarChar, ParameterDirection.Input, REMITTERNO);
        PR[2] = DataTransform.Oracle_Param("v_REM_FIRSTNAME", OracleType.VarChar, ParameterDirection.Input, REMITTERNAME);
        PR[3] = DataTransform.Oracle_Param("v_BENEFICIARYNO", OracleType.VarChar, ParameterDirection.Input, BENEFICIARYNO);
        PR[4] = DataTransform.Oracle_Param("v_BEN_FIRSTNAME", OracleType.VarChar, ParameterDirection.Input, BENEFICIARYNAME);
        PR[5] = DataTransform.Oracle_Param("v_STAR_DRAFTNO", OracleType.VarChar, ParameterDirection.Input, STAR_DRAFTNO);
        PR[6] = DataTransform.Oracle_Param("v_STATION_NAME", OracleType.VarChar, ParameterDirection.Input, STATION_NAME);
        PR[7] = DataTransform.Oracle_Param("v_POD_NO", OracleType.VarChar, ParameterDirection.Input, POD_NO);
        PR[8] = DataTransform.Oracle_Param("v_REMITTANCE_NO", OracleType.VarChar, ParameterDirection.Input, REMITTANCE_NO);
        PR[9] = DataTransform.Oracle_Param("v_SPDSTYPE", OracleType.VarChar, ParameterDirection.Input, SPDS_TYPE);
        PR[10] = DataTransform.Oracle_Param("v_TransactionAmount", OracleType.VarChar, ParameterDirection.Input, "0");
        PR[11] = DataTransform.Oracle_Param("v_DRAFTDATE", OracleType.VarChar, ParameterDirection.Input, REMITTERNO);
        PR[12] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_RPS_DraftInquiry_ALL", PR);
        return DS;
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_RPS_DraftInquiry_ALL '" + DRAFTNO + "','" + REMITTERNO + "','" + REMITTERNAME + "','" + BENEFICIARYNO + "','" + BENEFICIARYNAME + "','" + STAR_DRAFTNO + "','" + STATION_NAME + "','" + POD_NO + "','" + REMITTANCE_NO + "','" + SPDS_TYPE + "'", "GET_ALL_USER");
    }

    public DataSet GetTest_SPC(string ID)
    {
        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("v_ID", OracleType.VarChar, ParameterDirection.Input, ID);
        PR[1] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_RPS_Draft_SPC", PR);

        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_RPS_Draft_SPC " + ID, "GET_ALL_USER");
        return DS;
    }

    public DataSet Get_SystemtoStarDownload(string CustomerID, string ServiceType)
    {
        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[5];
        PR[0] = DataTransform.Oracle_Param("v_CustomerID", OracleType.VarChar, ParameterDirection.Input, CustomerID);
        PR[1] = DataTransform.Oracle_Param("v_ServiceType", OracleType.VarChar, ParameterDirection.Input, ServiceType);
        PR[2] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");
        PR[3] = DataTransform.Oracle_Param("cv_2", OracleType.Cursor, ParameterDirection.Output, "");
        PR[4] = DataTransform.Oracle_Param("cv_3", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_SPDS_SystemToStar", PR);


        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_SPDS_SystemToStar " + CustomerID + "," + ServiceType + "", "GET_ALL_USER");
        return DS;
    }

    public DataSet Get_SystemtoStar_Marked(string CustomerID, string ServiceType, int Status)
    {
        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[5];
        PR[0] = DataTransform.Oracle_Param("v_CustomerID", OracleType.VarChar, ParameterDirection.Input, CustomerID);
        PR[1] = DataTransform.Oracle_Param("iv_ServiceType", OracleType.VarChar, ParameterDirection.Input, ServiceType);
        PR[2] = DataTransform.Oracle_Param("v_Status", OracleType.VarChar, ParameterDirection.Input, Status.ToString());
        DataTransform.Oracle_GetDataSetSP_DML("SP_SPDS_SystemToStar_Mark", PR);

        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_SPDS_SystemToStar_Mark " + CustomerID + "," + ServiceType + "," + Status + "", "GET_ALL_USER");
        return DS;
    }

    public DataSet Get_StarToSystemUpload(string AppEmpDep, string StarDraftNo, string DraftPrintDateArabic, string DraftPrintDateGregorian,
        string BeneficiaryName, string Currency, string Amount, string AmountWords, string PayBankName, string payableBankAddress, string payableBankAddress2,
        string payableBankAddress3, string payableBankAddress4, string Others, string FileName, string CustomerID,
        string DateTimeStamp, string Status)
    {
        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[19];
        PR[0] = DataTransform.Oracle_Param("v_AppEmpDep", OracleType.VarChar, ParameterDirection.Input, AppEmpDep);
        PR[1] = DataTransform.Oracle_Param("v_StarDraftNo", OracleType.VarChar, ParameterDirection.Input, StarDraftNo);
        PR[2] = DataTransform.Oracle_Param("v_DraftPrintDateArabic", OracleType.VarChar, ParameterDirection.Input, DraftPrintDateArabic);
        PR[3] = DataTransform.Oracle_Param("v_DraftPrintDateGregorian", OracleType.VarChar, ParameterDirection.Input, DraftPrintDateGregorian);
        PR[4] = DataTransform.Oracle_Param("v_BeneficiaryName", OracleType.VarChar, ParameterDirection.Input, BeneficiaryName);
        PR[5] = DataTransform.Oracle_Param("v_Currency", OracleType.VarChar, ParameterDirection.Input, Currency);
        PR[6] = DataTransform.Oracle_Param("v_Amount", OracleType.VarChar, ParameterDirection.Input, Amount);
        PR[7] = DataTransform.Oracle_Param("v_AmountWords", OracleType.VarChar, ParameterDirection.Input, AmountWords);
        PR[8] = DataTransform.Oracle_Param("v_PayBankName", OracleType.VarChar, ParameterDirection.Input, PayBankName);
        PR[9] = DataTransform.Oracle_Param("v_payableBankAddress", OracleType.VarChar, ParameterDirection.Input, payableBankAddress);
        PR[10] = DataTransform.Oracle_Param("v_payableBankAddress2", OracleType.VarChar, ParameterDirection.Input, payableBankAddress2);
        PR[11] = DataTransform.Oracle_Param("v_payableBankAddress3", OracleType.VarChar, ParameterDirection.Input, payableBankAddress3);
        PR[12] = DataTransform.Oracle_Param("v_payableBankAddress4", OracleType.VarChar, ParameterDirection.Input, payableBankAddress4);
        PR[13] = DataTransform.Oracle_Param("v_Others", OracleType.VarChar, ParameterDirection.Input, Others);
        PR[14] = DataTransform.Oracle_Param("v_FileName", OracleType.VarChar, ParameterDirection.Input, FileName);
        PR[15] = DataTransform.Oracle_Param("v_CustomerID", OracleType.VarChar, ParameterDirection.Input, CustomerID);
        PR[16] = DataTransform.Oracle_Param("v_CorrBankID", OracleType.VarChar, ParameterDirection.Input, "0");
        PR[17] = DataTransform.Oracle_Param("v_DateTimeStamp", OracleType.VarChar, ParameterDirection.Input, DateTimeStamp);
        PR[18] = DataTransform.Oracle_Param("v_Status", OracleType.VarChar, ParameterDirection.Input, Status);
        DataTransform.Oracle_GetDataSetSP_DML("SP_SPDS_STAR_SYSTEM_UPLOAD", PR);

        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_SPDS_STAR_SYSTEM_UPLOAD '" + AppEmpDep + "','" + StarDraftNo + "','" + DraftPrintDateArabic + "','" + DraftPrintDateGregorian + "','" + BeneficiaryName + "','" + Currency + "','" + Amount + "','" + AmountWords + "','" + PayBankName + "','" + payableBankAddress + "','" + payableBankAddress2 + "','" + payableBankAddress3 + "','" + payableBankAddress4 + "','" + Others + "','" + FileName + "'," + CustomerID + "," + 0 + ",'" + DateTimeStamp + "'," + Status + "", "GET_ALL_USER");
        return DS;
    }

    public DataSet Get_StarToSystem_Delete()
    {
        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[0];
        DataTransform.Oracle_GetDataSetSP_DML("SP_SPDS_STAR_SYSTEM_Delete", PR);
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_SPDS_STAR_SYSTEM_Delete ", "GET_ALL_USER");
        return DS;
    }

    public DataSet Get_StarToSystem_GetAll()
    {
        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[0];
        DS = DataTransform.Oracle_GetDataSetSP("SP_SPDS_STAR_SYSTEM_GetAll", PR);



        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_SPDS_STAR_SYSTEM_GetAll ", "GET_ALL_USER");
        return DS;
    }
    public DataSet Get_StarToSystem_Process()
    {
        DataSet DS = new DataSet();


        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_SPDS_STAR_SYSTEM_Process ", "GET_ALL_USER");
        return DS;
    }







    public DataSet AgentNameDownload()
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_AgentNameDownload ", "-");
        //return DS;


        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[1];
        PR[0] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_AgentNameDownload", PR);
        return DS;
    }

    public DataSet ListofCustomer(String AGENT_ID)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_ListofCustomer " + AGENT_ID, "-");
        //return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("v_AGENT_ID", OracleType.VarChar, ParameterDirection.Input, AGENT_ID);
        PR[1] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_ListofCustomer", PR);
        return DS;
    }

    public DataSet ListofCorrBank(String CUSTOMER_ID)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_ListofCorrBank " + CUSTOMER_ID, "-");
        //return DS;



        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("v_CUSTOMER_ID", OracleType.VarChar, ParameterDirection.Input, CUSTOMER_ID);
        PR[1] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_ListofCorrBank", PR);
        return DS;
    }

    public DataSet RPS_DATA(string PrintAgentID)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_RPS_DATA " + PrintAgentID, "-");
        //return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("v_PrintAgentID", OracleType.VarChar, ParameterDirection.Input, PrintAgentID);
        PR[1] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_RPS_DATA", PR);
        return DS;
    }

    public DataSet SP_MasterZipCodeSetup_DP(string ZipCode, string ID)
    {
        //    DataSet DS = new DataSet();
        //    DS = DataTransform.ReteriveDataMultiple("EXEC SP_MasterZipCodeSetup_DP '" + ZipCode + "','" + ID + "'", "GET_ALL_USER");
        //    return DS;


        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[3];
        PR[0] = DataTransform.Oracle_Param("v_ZipCode", OracleType.VarChar, ParameterDirection.Input, ZipCode);
        PR[1] = DataTransform.Oracle_Param("v_ID", OracleType.VarChar, ParameterDirection.Input, ID);
        PR[2] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_MasterZipCodeSetup_DP", PR);
        return DS;
    }

    public void RPS_Attached(string ID)
    {
        DataSet DS = new DataSet();
        DS = DataTransform.ReteriveDataMultiple("EXEC SP_ATTACH " + ID, "-");
    }

    public void RPS_DeAttached()
    {
        DataSet DS = new DataSet();
        DS = DataTransform.ReteriveDataMultiple("EXEC sp_detach_db 'SPDS_JR', 'true' ", "-");
    }

    #region -----------------------------Instrument File Setup Dataset----------------------
    public DataSet INS_CALL()
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_INS_CALL ", "GET_ALL_USER");
        //return DS;
        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[1];
        PR[0] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_INS_CALL", PR);
        return DS;
    }

    public void INS_SAVE(string PT, string USER_ID)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_INS_SAVE '" + PT + "','" + USER_ID + "'", "GET_ALL_USER");

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("v_INS", OracleType.VarChar, ParameterDirection.Input, PT);
        PR[1] = DataTransform.Oracle_Param("v_USER_ID", OracleType.VarChar, ParameterDirection.Input, USER_ID);
        DS = DataTransform.Oracle_GetDataSetSP("SP_INS_SAVE", PR);
    }

    public void INS_AUTH(string USER_ID)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_INS_AUTH '" + USER_ID + "'", "GET_ALL_USER");

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[1];
        PR[0] = DataTransform.Oracle_Param("v_USER_ID", OracleType.VarChar, ParameterDirection.Input, USER_ID);
        DS = DataTransform.Oracle_GetDataSetSP("SP_INS_AUTH", PR);
    }

    #endregion -----------------------------Instrument File Setup Dataset----------------------

    public DataSet RPT_Path()
    {
        DataSet DS = new DataSet();
        DS = DataTransform.ReteriveDataMultiple("SELECT InstrumentFile FROM SPDS_InstrumentFileSetup", "GET_ALL_USER");
        return DS;

        //DataSet DS = new DataSet();
        //OracleParameter[] PR = new OracleParameter[2];
        //PR[0] = DataTransform.Oracle_Param("v_INS", OracleType.VarChar, ParameterDirection.Input, PT);
        //PR[1] = DataTransform.Oracle_Param("v_USER_ID", OracleType.VarChar, ParameterDirection.Input, USER_ID);
        //DS = DataTransform.Oracle_GetDataSetSP("SP_INS_SAVE", PR);
    }

    #region --=====================Customer Product Arrangement Get By Code LOV==========================
    public DataSet Get_RPS_SP_ProductArrangement_GetByCode(string CODE)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC RPS_SP_ProductArrangement_GetByCode '" + CODE + "'", "GET_ALL_USER");
        //return DS;
        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("v_CODE", OracleType.VarChar, ParameterDirection.Input, CODE);
        PR[1] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("RPS_SP_ProductArrang_GetByCode", PR);
        return DS;

    }
    #endregion

    public DataSet Get_SP_SPDS_StarFilesSetup_GetByStarId(string CustomerID)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_SPDS_StarFilesSetup_GetByStarId '" + CustomerID + "'", "GET_ALL_USER");
        //return DS;
        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("v_CustomerId", OracleType.VarChar, ParameterDirection.Input, CustomerID);
        PR[1] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_StarFilesSetup_GetByStarId", PR);
        return DS;

    }

    public DataSet Get_SPDS_CustomerProductPricing_Detail_ALL(string FromStationID, string ToStationID, string ID)
    {
        // OLD IS SP_SPDS_CustomerProductPricing_Detail_ALL
        //   NEW IS SP_SPDS_CustProdPric_Det_ALL

        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_SPDS_CustomerProductPricing_Detail_ALL '" + FromStationID + "','" + ToStationID + "','" + ID + "'", "GET_ALL_USER");
        //return DS;


        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[4];

        //Change by Ibrahim
        PR[0] = DataTransform.Oracle_Param("v_FromStationID", OracleType.VarChar, ParameterDirection.Input, FromStationID);
        PR[1] = DataTransform.Oracle_Param("v_ToStationID", OracleType.VarChar, ParameterDirection.Input, ToStationID);
        PR[2] = DataTransform.Oracle_Param("v_ID", OracleType.VarChar, ParameterDirection.Input, ID);
        PR[3] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_SPDS_CustProdPricing_DtlALL", PR);

        return DS;

    }

    public DataSet Get_SPDS_CustomerProductPricing_Detail_SPC(string ID)
    {
        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("v_ID", OracleType.VarChar, ParameterDirection.Input, ID);
        PR[1] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_SPDS_CustProdPricing_DtlSPC", PR);

        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_SPDS_CustomerProductPricing_Detail_SPC " + ID, "GET_ALL_USER");
        return DS;
    }

    public DataSet Get_RPS_SP_DraftUnAssignmentCount()
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC RPS_SP_DraftUnAssignmentCount ", "GET_ALL_USER");
        //return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[1];
        PR[0] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("RPS_SP_DraftUnAssignmentCount", PR);
        return DS;
    }

    public DataSet Get_RPS_SP_DraftProductUnAssignCheck()
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC RPS_SP_DraftProductUnAssignCheck ", "GET_ALL_USER");
        //return DS;


        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[1];
        PR[0] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("Get_RPS_SP_DraftPrdUnAssignChk", PR);
        return DS;
    }

    public DataSet SP_SPDS_CustomerProductPricing_Detail_DP(string ID, string FromStationID, string ToStationID, string ProductArrangeID)
    {
        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[5];
        PR[0] = DataTransform.Oracle_Param("v_ID", OracleType.VarChar, ParameterDirection.Input, ID);
        PR[1] = DataTransform.Oracle_Param("v_FromStationID", OracleType.VarChar, ParameterDirection.Input, FromStationID);
        PR[2] = DataTransform.Oracle_Param("v_ToStationID", OracleType.VarChar, ParameterDirection.Input, ToStationID);
        PR[3] = DataTransform.Oracle_Param("v_ProductArrangeID", OracleType.VarChar, ParameterDirection.Input, ProductArrangeID);
        PR[4] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_SPDS_CustPrdPricing_Dtl_DP", PR);


        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_SPDS_CustomerProductPricing_Detail_DP '" + ID + "','" + FromStationID + "','" + ToStationID + "','" + ProductArrangeID + "'", "GET_ALL_USER");
        return DS;
    }

    public DataSet Get_SPDS_PrintingLocationPricing_ALL(string PrintingLocationID, string ProductID, string ID)
    {
        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[4];
        PR[0] = DataTransform.Oracle_Param("v_PrintingLocationID", OracleType.VarChar, ParameterDirection.Input, PrintingLocationID);
        PR[1] = DataTransform.Oracle_Param("v_ProductID", OracleType.VarChar, ParameterDirection.Input, ProductID);
        PR[2] = DataTransform.Oracle_Param("v_AGENT_ID", OracleType.VarChar, ParameterDirection.Input, "");
        PR[3] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_SPDS_PrintLocationPrice_ALL", PR);
        //SP_SPDS_PrintLocationPrice_ALLSP_SPDS_CustPrdPricing_Dtl_DP
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_SPDS_PrintingLocationPricing_ALL '" + PrintingLocationID + "','" + ProductID + "'," + ID, "GET_ALL_USER");
        return DS;
    }

    public DataSet Get_SPDS_PrintingLocationPricing_SPC(string ID)
    {
        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("v_ID", OracleType.VarChar, ParameterDirection.Input, ID);
        PR[1] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_SPDS_PrintLocationPrice_SPC", PR);

        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_SPDS_PrintingLocationPricing_SPC " + ID, "GET_ALL_USER");
        return DS;
    }

    public DataSet Get_SPDS_PRODUCTARRANGEMENT_DP(string CustomerID, string ProductID)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SPDS_PRODUCTARRANGEMENT_DP '" + CustomerID + "','" + ProductID + "'", "GET_ALL_USER");
        //return DS;


        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[3];
        PR[0] = DataTransform.Oracle_Param("v_CustomerID", OracleType.VarChar, ParameterDirection.Input, CustomerID);
        PR[1] = DataTransform.Oracle_Param("v_ProductID", OracleType.VarChar, ParameterDirection.Input, ProductID);

        PR[2] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SPDS_PRODUCTARRANGEMENT_DP", PR);
        return DS;

    }

    public DataSet RPS_SP_MoneyGramRemittance_GetLoadData(int PrincepalID, string UserID)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC RPS_SP_MoneyGramRemittance_GetLoadData '" + PrincepalID + "','" + UserID + "'", "GET_ALL_USER");
        //return DS;



        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[3];
        PR[0] = DataTransform.Oracle_Param("v_PrincepalID", OracleType.VarChar, ParameterDirection.Input, PrincepalID.ToString());
        PR[1] = DataTransform.Oracle_Param("v_UserID", OracleType.VarChar, ParameterDirection.Input, UserID);

        PR[2] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("RPS_SP_MGramRemit_GetLoadDt", PR);
        return DS;
    }

    public DataSet RPS_SP_Beneficiary_GetByCode(string MasterID, string Code)
    {
        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[3];
        PR[0] = DataTransform.Oracle_Param("v_MasterID", OracleType.VarChar, ParameterDirection.Input, MasterID);
        PR[1] = DataTransform.Oracle_Param("v_Code", OracleType.VarChar, ParameterDirection.Input, Code);
        PR[2] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("RPS_SP_Beneficiary_GetByCode", PR);
        return DS;
    }

    public DataSet SP_RPS_Draft_GETBYID(int DRAFTID)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_RPS_Draft_GETBYID '" + DRAFTID + "'", "GET_ALL_USER");
        //return DS;


        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("v_DraftId", OracleType.VarChar, ParameterDirection.Input, DRAFTID.ToString());
        PR[1] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_RPS_Draft_GETBYID", PR);
        return DS;


    }

    public DataSet RPS_SP_Beneficiary_UpdateSDNAML(string Beniid, string SDNDiscrepant, string AMLDiscrepant)
    {
        DataSet DS = new DataSet();
        /*OracleParameter[] PR = new OracleParameter[4];
        PR[0] = DataTransform.Oracle_Param("v_ID", OracleType.VarChar, ParameterDirection.Input, Beniid);
        PR[1] = DataTransform.Oracle_Param("v_SDNDiscrepant", OracleType.VarChar, ParameterDirection.Input, SDNDiscrepant);
        PR[2] = DataTransform.Oracle_Param("v_AMLDiscrepant", OracleType.VarChar, ParameterDirection.Input, AMLDiscrepant);
        PR[3] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_RPS_Draft_GETBYID", PR);*/

        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("v_DraftId", OracleType.VarChar, ParameterDirection.Input, Beniid);
        PR[1] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_RPS_Draft_GETBYID", PR);
        return DS;
    }

    public DataSet RPS_SP_Remitter_UpdateSDNAML(int remiID, string SDNDiscrepant, string AMLDiscrepant)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC RPS_SP_Remitter_UpdateSDNAML '" + remiID + "','" + SDNDiscrepant + "','" + AMLDiscrepant + "'", "GET_ALL_USER");
        //return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[4];
        PR[0] = DataTransform.Oracle_Param("v_ID", OracleType.VarChar, ParameterDirection.Input, remiID.ToString());
        PR[1] = DataTransform.Oracle_Param("v_SDNDiscrepant", OracleType.VarChar, ParameterDirection.Input, SDNDiscrepant);
        PR[2] = DataTransform.Oracle_Param("v_AMLDiscrepant", OracleType.VarChar, ParameterDirection.Input, AMLDiscrepant);
        PR[3] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("RPS_SP_Remitter_UpdateSDNAML", PR);
        return DS;



    }

    public DataSet Get_RPS_SP_Reconcile_MaxID()
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC RPS_SP_Reconcile_MaxID ", "GET_ALL_USER");
        //return DS;
        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[1];
        PR[0] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("RPS_SP_Reconcile_MaxID", PR);
        return DS;
    }

    public DataSet Get_SPDS_STATIONARY_DETAIL_DP(string PrintAgent, string PrintLocation, string StartSerialNo, string EndSerialNo)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SPDS_STATIONARY_DETAIL_DP '" + PrintAgent + "','" + PrintLocation + "','" + StartSerialNo + "','" + EndSerialNo + "' ", "GET_ALL_USER");
        //return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[5];
        PR[0] = DataTransform.Oracle_Param("v_PRINTAGENT", OracleType.VarChar, ParameterDirection.Input, PrintAgent);
        PR[1] = DataTransform.Oracle_Param("v_PRINTLOCATIONID", OracleType.VarChar, ParameterDirection.Input, PrintLocation);
        PR[2] = DataTransform.Oracle_Param("v_START_SERIAL_NO", OracleType.VarChar, ParameterDirection.Input, StartSerialNo);
        PR[3] = DataTransform.Oracle_Param("v_END_SERIAL_NO", OracleType.VarChar, ParameterDirection.Input, EndSerialNo);

        PR[4] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SPDS_STATIONARY_DETAIL_DP", PR);
        return DS;

    }

    public DataSet Get_RPS_SP_StopPaymentLetter_GetByDraftId(string DraftID)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC RPS_SP_StopPaymentLetter_GetByDraftId '" + DraftID + "'", "GET_ALL_USER");
        //return DS;


        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("v_DraftNo", OracleType.VarChar, ParameterDirection.Input, DraftID);

        PR[1] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("RPS_SP_StopPayLtr_GetDrftId", PR);
        return DS;
    }

    public DataSet Get_RPS_SP_DraftCancellationMaxId()
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC RPS_SP_DraftCancellationMaxId", "GET_ALL_USER");
        //return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[1];
        PR[0] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("RPS_SP_DraftCancellationMaxId", PR);
        return DS;



    }

    public DataSet Get_SPDS_PrintLocationPricing_DP(string PrintLocationID, string ProductID, string ID)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SPDS_PrintLocationPricing_DP '" + PrintLocationID + "','" + ProductID + "','" + ID + "',", "GET_ALL_USER");
        //return DS;


        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[4];
        PR[0] = DataTransform.Oracle_Param("v_PrintLocationID", OracleType.VarChar, ParameterDirection.Input, PrintLocationID);
        PR[1] = DataTransform.Oracle_Param("v_ProductID", OracleType.VarChar, ParameterDirection.Input, ProductID);
        PR[2] = DataTransform.Oracle_Param("v_ID", OracleType.VarChar, ParameterDirection.Input, ID);

        PR[3] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SPDS_PrintLocationPricing_DP", PR);
        return DS;
    }

    public DataSet Get_SP_SPDS_PrintAgentDetail_LOV(string PrintAgentID, string PrintLocationID)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_SPDS_PrintAgentDetail_LOV " + PrintAgentID + ",'" + PrintLocationID + "'", "GET_ALL_USER");
        //return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[3];
        PR[0] = DataTransform.Oracle_Param("v_PRINT_AGENT_ID", OracleType.VarChar, ParameterDirection.Input, PrintAgentID);
        PR[1] = DataTransform.Oracle_Param("v_PRINT_LOCATION_ID", OracleType.VarChar, ParameterDirection.Input, PrintLocationID);

        PR[2] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_SPDS_PrintAgentDetail_LOV", PR);
        return DS;
    }

    public DataSet Get_RPS_SP_IncomingFile_GetALL(string CustomerID, string FileName)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC RPS_SP_IncomingFile_GetALL '" + CustomerID + "','" + FileName + "'", "GET_ALL_USER");
        //return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[3];
        PR[0] = DataTransform.Oracle_Param("v_CustomerID", OracleType.VarChar, ParameterDirection.Input, CustomerID);
        PR[1] = DataTransform.Oracle_Param("v_FileName", OracleType.VarChar, ParameterDirection.Input, FileName);
        PR[2] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("RPS_SP_IncomingFile_GetALL", PR);
        return DS;

    }

    public DataSet SP_SPDS_CourierPricing_Detail_DP(string FromStation, string ToStation, string CourierID, string ServiceTypeID, string ID)
    {
        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[3];
        PR[0] = DataTransform.Oracle_Param("v_FromStationID", OracleType.VarChar, ParameterDirection.Input, FromStation);
        PR[1] = DataTransform.Oracle_Param("v_ToStationID", OracleType.VarChar, ParameterDirection.Input, ToStation);
        PR[1] = DataTransform.Oracle_Param("v_CourierID", OracleType.VarChar, ParameterDirection.Input, CourierID);
        PR[1] = DataTransform.Oracle_Param("v_ServiceTypeID", OracleType.VarChar, ParameterDirection.Input, ServiceTypeID);
        PR[1] = DataTransform.Oracle_Param("v_ID", OracleType.VarChar, ParameterDirection.Input, ID);
        PR[2] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_SPDS_CourierPrice_Dtl_DP", PR);

        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_SPDS_CourierPricing_Detail_DP '" + FromStation + "','" + ToStation + "','" + CourierID + "','" + ServiceTypeID + "','" + ID + "'", "GET_ALL_USER");
        return DS;
    }

    public DataSet Get_SP_SPDS_PrintAgentDetail_GetByCode(string Code, string PrintAgentID)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_SPDS_PrintAgentDetail_GetByCode '" + Code + "','" + PrintAgentID + "'", "GET_ALL_USER");
        //return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[3];
        PR[0] = DataTransform.Oracle_Param("v_Code", OracleType.VarChar, ParameterDirection.Input, Code);
        PR[1] = DataTransform.Oracle_Param("v_PrintAgentID", OracleType.VarChar, ParameterDirection.Input, PrintAgentID);

        PR[2] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_PrintAgentDtl_GetByCode", PR);
        return DS;
    }

    public DataSet Get_SP_RPS_REMITTERLOV_ALL(string RemitterNo)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_RPS_REMITTERLOV_ALL  '" + RemitterNo + "'", "GET_ALL_USER");
        //return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("v_RemitterNo", OracleType.VarChar, ParameterDirection.Input, RemitterNo);

        PR[1] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_RPS_REMITTERLOV_ALL", PR);
        return DS;
    }

    public DataSet SP_RPS_REMITTERLOV_GETBYCODE(int PRINCIPALID)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_RPS_REMITTERLOV_GETBYCODE '" + PRINCIPALID + "'", "GET_ALL_USER");
        //return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("v_PRINCIPALID", OracleType.VarChar, ParameterDirection.Input, PRINCIPALID.ToString());

        PR[1] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_RPS_REMITTERLOV_GETBYCODE", PR);
        return DS;
    }

    public DataSet SP_SPDS_PrintLocation_All(string DistrictCode, string DistrictName)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_SPDS_PrintLocation_All '" + DistrictCode + "','" + DistrictName + "'", "GET_ALL_USER");
        //return DS;


        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[3];
        PR[0] = DataTransform.Oracle_Param("v_DistrictCode", OracleType.VarChar, ParameterDirection.Input, DistrictCode.ToString());
        PR[1] = DataTransform.Oracle_Param("v_DistrictName", OracleType.VarChar, ParameterDirection.Input, DistrictName.ToString());

        PR[2] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_SPDS_PrintLocation_All", PR);
        return DS;
    }

    public DataSet GET_SP_RPS_PODLOV_ALL(string PODNo)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_RPS_PODLOV_ALL '" + PODNo + "'", "GET_ALL_USER");
        //return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("v_PODNo", OracleType.VarChar, ParameterDirection.Input, PODNo.ToString());
        PR[1] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_RPS_PODLOV_ALL", PR);
        return DS;
    }

    public DataSet GET_SP_RPS_INCOMINGTRACERLOV_ALL(int ID)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_RPS_INCOMINGTRACERLOV_ALL", "GET_ALL_USER");
        //return DS;

        DataSet DS = new DataSet();
        //OracleParameter[] PR = new OracleParameter[2];
        OracleParameter[] PR = new OracleParameter[1];
        //PR[0] = DataTransform.Oracle_Param("v_ID", OracleType.VarChar, ParameterDirection.Input, ID.ToString());
        PR[0] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_RPS_INCOMINGTRACERLOV_ALL", PR);
        return DS;
    }

    public DataSet GET_SP_RPS_INCOMINGTRAILERLOV_ALL(int ID)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_RPS_INCOMINGTRAILERLOV_ALL", "GET_ALL_USER");
        //return DS;


        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[1];
        // PR[0] = DataTransform.Oracle_Param("v_ID", OracleType.VarChar, ParameterDirection.Input, ID.ToString());


        PR[0] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_RPS_INCOMINGTRAILERLOV_ALL", PR);
        return DS;
    }

    public DataSet GET_RPS_SP_Remittance_LOV(string RemittanceCode)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC RPS_SP_Remittance_LOV '" + RemittanceCode + "'", "GET_ALL_USER");
        //return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];
        //PR[0] = DataTransform.Oracle_Param("v_RemittanceCode", OracleType.VarChar, ParameterDirection.Input, RemittanceCode);
        PR[0] = DataTransform.Oracle_Param("v_RemittanceCode", OracleType.VarChar, ParameterDirection.Input, RemittanceCode);
        PR[1] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        //DS = DataTransform.Oracle_GetDataSetSP("RPS_IncomingHeader_LOV", PR);
        DS = DataTransform.Oracle_GetDataSetSP("RPS_SP_Remittance_LOV", PR);
        return DS;


    }

    public DataSet GET_RPS_IncomingBatchHeader_LOV(string BatchID)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC RPS_IncomingBatchHeader_LOV '" + BatchID + "'", "GET_ALL_USER");
        //return DS;


        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];
        //PR[0] = DataTransform.Oracle_Param("v_BatchID", OracleType.VarChar, ParameterDirection.Input, BatchID.ToString());

        PR[0] = DataTransform.Oracle_Param("v_IncomingHeaderID", OracleType.VarChar, ParameterDirection.Input, BatchID);
        PR[1] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("RPS_IncomingBatchHeader_LOV", PR);
        return DS;
    }

    public DataSet GET_RPS_IncomingHeader_LOV(string FileName)
    {
        // DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC RPS_IncomingHeader_LOV '" + FileName + "'", "GET_ALL_USER");
        // return DS;


        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("v_FileName", OracleType.VarChar, ParameterDirection.Input, FileName);
        PR[1] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("RPS_IncomingHeader_LOV", PR);
        return DS;







    }

    public DataSet Get_SP_CMN_BankBranch_lOV(string BankID, string BranchCode, string BranchName)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_CMN_BankBranch_lOV " + BankID + ",'" + BranchCode + "','" + BranchName + "'", "GET_ALL_USER");
        //return DS;



        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[4];
        PR[0] = DataTransform.Oracle_Param("v_MasterID", OracleType.VarChar, ParameterDirection.Input, BankID);
        PR[1] = DataTransform.Oracle_Param("v_BranchCode", OracleType.VarChar, ParameterDirection.Input, BranchCode);
        PR[2] = DataTransform.Oracle_Param("v_BranchName", OracleType.VarChar, ParameterDirection.Input, BranchName);


        PR[3] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_CMN_BankBranch_lOV", PR);
        return DS;
    }
    public DataSet Get_SP_Setup_Branch_lOV(string BranchCode, string BranchName)
    {
        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[3];

        PR[0] = DataTransform.Oracle_Param("v_BranchCode", OracleType.VarChar, ParameterDirection.Input, BranchCode);
        PR[1] = DataTransform.Oracle_Param("v_BranchName", OracleType.VarChar, ParameterDirection.Input, BranchName);
        PR[2] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("PS_SP_Branch_LOV", PR);
        return DS;
    }
    public DataSet SP_SPDS_DataFileTransferConfiguration_DISPLAY()
    {
        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[1];
        PR[0] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_DataFileTrnsfConf_DISPLAY", PR);

        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_SPDS_DataFileTransferConfiguration_DISPLAY", "GET_ALL_USER");
        return DS;
    }

    public DataSet SP_DataDownload(string ID)
    {
        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[1];
        PR[0] = DataTransform.Oracle_Param("v_ID", OracleType.VarChar, ParameterDirection.Input, ID);
        DataTransform.Oracle_GetDataSetSP_DML("SP_DataDownload", PR);
        return DS;
    }

    public DataSet SambaBankApperance()
    {
        // DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_SambaBankApperance", "GET_ALL_USER");
        //return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[1];

        PR[0] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_SambaBankApperance", PR);
        return DS;

    }

    public DataSet GetPRIDataFoDownload()
    {
        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[1];
        PR[0] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_GetPRIDataFoDownload", PR);
        return DS;
    }

    public DataSet PRIDownload(string ID)
    {
        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];

        int index = 0;
        PR[index] = DataTransform.Oracle_Param("v_CorrBankID", OracleType.VarChar, ParameterDirection.Input, ID.ToString());
        index++;

        PR[index] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");

        DS = DataTransform.Oracle_GetDataSetSP("SP_PRIDownload", PR);
        return DS;
    }
    public DataSet PRIDownload_IBAN(string ID)
    {
        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];

        int index = 0;
        PR[index] = DataTransform.Oracle_Param("v_CorrBankID", OracleType.VarChar, ParameterDirection.Input, ID.ToString());
        index++;

        PR[index] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");

        DS = DataTransform.Oracle_GetDataSetSP("SP_PRIDOWNLOAD_IBAN", PR);
        return DS;
    }

    public DataSet SP_PRIFileSetup()
    {
        //  DataSet DS = new DataSet();
        //  DS = DataTransform.ReteriveDataMultiple("EXEC SP_PRIFileSetup_SPC", "GET_ALL_USER");
        //  return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[1];
        PR[0] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_PRIFileSetup_SPC", PR);
        return DS;


    }

    public DataSet SP_PRIFilePath()
    {
        DataSet DS = new DataSet();
        DS = DataTransform.ReteriveDataMultiple("SELECT * FROM PRIFileSetup order by 1", "GET_ALL_USER");
        //  DS = DataTransform.ReteriveDataMultiple("SELECT * FROM PRIFileSetup WHERE ID='2'", "GET_ALL_USER");
        return DS;
    }

    public DataSet PRIUploadSample(string ID)
    {
        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];

        int index = 0;
        PR[index] = DataTransform.Oracle_Param("v_CorrBankID", OracleType.VarChar, ParameterDirection.Input, ID);
        index++;

        PR[index] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_PRIUploadSample", PR);
        return DS;
    }

    public void PRIDownloadMarking(string ID, string fileName)
    {
        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("v_CorrBankID", OracleType.VarChar, ParameterDirection.Input, ID);
        PR[1] = DataTransform.Oracle_Param("v_pri_filename", OracleType.VarChar, ParameterDirection.Input, fileName);
        DS = DataTransform.Oracle_GetDataSetSP("SP_PRIDownloadMarking", PR);
    }

    public void PRIUploader(string DraftID, string Reason, string FileName)
    {
        // DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_PRIUploader '" + DraftID + "','" + Reason + "','" + FileName + "'", "GET_ALL_USER");


        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[3];
        PR[0] = DataTransform.Oracle_Param("iv_DraftID", OracleType.VarChar, ParameterDirection.Input, DraftID);
        PR[1] = DataTransform.Oracle_Param("v_Reason", OracleType.VarChar, ParameterDirection.Input, Reason);
        PR[2] = DataTransform.Oracle_Param("v_FileName", OracleType.VarChar, ParameterDirection.Input, FileName);

        DS = DataTransform.Oracle_GetDataSetSP("SP_PRIUploader", PR);
        //return DS;







    }

    public DataSet PRIUploadFileCheck(string FileName)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_PRIUploadFileCheck '" + FileName + "'", "GET_ALL_USER");
        //return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("v_FN", OracleType.VarChar, ParameterDirection.Input, FileName);
        PR[1] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_PRIUploadFileCheck", PR);
        return DS;
    }

    public DataSet PRIUploadedFileList()
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_PRIUploadedFileList", "GET_ALL_USER");
        //return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[1];
        PR[0] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_PRIUploadedFileList", PR);
        return DS;

    }

    public DataSet Get_SPDS_CustomerInstrumentSetup_LOV(string INSTRUMENT_NAME, string ID)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_SPDS_CustomerInstrumentSetup_LOV '" + INSTRUMENT_NAME + "'," + ID, "GET_ALL_USER");
        //return DS;

        if (INSTRUMENT_NAME == "0")
        { INSTRUMENT_NAME = "%"; }


        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[3];
        PR[0] = DataTransform.Oracle_Param("v_INSTRUMENT_NAME", OracleType.VarChar, ParameterDirection.Input, INSTRUMENT_NAME.ToString());
        PR[1] = DataTransform.Oracle_Param("v_CUST_ID", OracleType.VarChar, ParameterDirection.Input, ID.ToString());


        PR[2] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_SPDS_CustInstMntSetup_LOV", PR);
        return DS;
    }

    public DataSet Get_SP_OfflineDownload(string ID)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_OfflineDownload " + ID, "GET_ALL_USER");
        //return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("v_ID", OracleType.VarChar, ParameterDirection.Input, ID.ToString());

        PR[1] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_OfflineDownload", PR);
        return DS;
    }

    public DataSet Get_SP_OfflineDownload_V11(string ID)
    {
        //  DataSet DS = new DataSet();
        //  DS = DataTransform.ReteriveDataMultiple("EXEC SP_OfflineDownload_V11 " + ID, "GET_ALL_USER");
        //  return DS;


        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("v_ID", OracleType.VarChar, ParameterDirection.Input, ID);
        PR[1] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_OfflineDownload_V11", PR);
        return DS;


    }

    public DataSet Get_SPDS_Bank_Customers()
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC RPS_SP_Bank_GetCustomers", "GET_ALL_USER");
        //return DS;


        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[1];
        PR[0] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("RPS_SP_Bank_GetCustomers", PR);
        return DS;


    }

    public DataSet Get_SPDS_PRODUCTMASTER_SD(string Isonline, string ServiceID, string ID)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SPDS_PRODUCTMASTER_SD '" + Isonline + "','" + ServiceID + "'," + ID + " ", "GET_ALL_USER");
        //return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[4];
        PR[0] = DataTransform.Oracle_Param("v_Isonline", OracleType.VarChar, ParameterDirection.Input, Isonline);
        PR[1] = DataTransform.Oracle_Param("v_ServiceID", OracleType.VarChar, ParameterDirection.Input, ServiceID);
        PR[2] = DataTransform.Oracle_Param("v_ID", OracleType.VarChar, ParameterDirection.Input, ID);


        PR[3] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SPDS_PRODUCTMASTER_SD", PR);
        return DS;



    }

    public DataSet Get_SPDS_UniversalUploadColumns()
    {
        //    DataSet DS = new DataSet();
        //    DS = DataTransform.ReteriveDataMultiple("EXEC SP_GetUniversalUploadColumns", "GET_ALL_USER");
        //    return DS;


        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[1];
        PR[0] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_GetUniversalUploadColumns", PR);
        return DS;
    }

    public string Get_SPDS_InstrumentFileSetup()
    {
        DataSet DS = new DataSet();
        DS = DataTransform.ReteriveDataMultiple("SELECT InstrumentFile FROM SPDS_InstrumentFileSetup", "GET_ALL_USER");
        return DS.Tables[0].Rows[0][0].ToString();
    }

    public void SP_SET_UPDATE_RPS_DRAFT_V11(string DraftID, string STrack, string StationarySeries, string Status, string UID, string UCODE, string FileName)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_SET_UPDATE_RPS_DRAFT_V11 " + DraftID + "," + STrack + "," + StationarySeries + "," + Status + "," + UID + ",'" + UCODE + "','" + FileName + "'", "GET_ALL_USER");

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[8];
        PR[0] = DataTransform.Oracle_Param("v_DraftID", OracleType.VarChar, ParameterDirection.Input, DraftID.ToString());
        PR[1] = DataTransform.Oracle_Param("v_STrack", OracleType.VarChar, ParameterDirection.Input, STrack.ToString());
        PR[2] = DataTransform.Oracle_Param("v_StationarySeries", OracleType.VarChar, ParameterDirection.Input, StationarySeries.ToString());
        PR[3] = DataTransform.Oracle_Param("v_Status", OracleType.VarChar, ParameterDirection.Input, Status.ToString());
        PR[4] = DataTransform.Oracle_Param("v_UID", OracleType.VarChar, ParameterDirection.Input, UID.ToString());
        PR[5] = DataTransform.Oracle_Param("v_UCODE", OracleType.VarChar, ParameterDirection.Input, UCODE.ToString());
        PR[6] = DataTransform.Oracle_Param("v_FileName", OracleType.VarChar, ParameterDirection.Input, FileName.ToString());

        PR[7] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_SET_UPDATE_RPS_DRAFT_V11", PR);
        //return DS;
    }

    public DataSet SP_OfflineDownload_V12(string ID)
    {
        //DataSet DS = new DataSet();
        // DS = DataTransform.ReteriveDataMultiple("EXEC SP_OfflineDownload_V12 " + ID, "GET_ALL_USER");
        // return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("v_ID", OracleType.VarChar, ParameterDirection.Input, ID);
        PR[1] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_OfflineDownload_V12", PR);
        return DS;
    }
    public DataSet Get_SPDS_SP_Customer_Balance_Get(string BankCode)
    {
        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("v_BankCode", OracleType.VarChar, ParameterDirection.Input, BankCode);
        PR[1] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("RPS_SP_CUST_BAL_SUM", PR);
        return DS;
    }
    public DataSet Get_SPDS_SP_UniversalUploadConfiguration_Get(string ConfigurationName)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SPDS_SP_UniversalUploadConfiguration_Get '" + ConfigurationName + "'", "GET_ALL_USER");
        //return DS;


        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("v_ConfigurationName", OracleType.VarChar, ParameterDirection.Input, ConfigurationName);
        PR[1] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SPDS_SP_UNIVConfiguration_Get", PR);
        return DS;
    }


    public DataSet Get_SPDS_SP_UniversalUpload_Add(
        int CustomerId,
        string TransactionRefNo, double CoverAmountUSD, double TransactionAmount, string RemitterAccountNo, string FirstName, string MiddleName,
        string LastName, string TelephoneNo, string Country, string BeneficiaryFirstName, string BeneficiaryMiddleName, string BeneficiaryLastName, string Address1,
        string Address2, string AccountNo, string City, string BeneficiaryTelephoneNo, string NICNo, string BeneficiaryZipCode, string UserID
               )
    {
        DataSet dsf = new DataSet();
        return dsf;
    }
    public DataSet Get_SPDS_SP_UniversalUpload_Add(OracleParameter[] PR
        /*int CustomerId,
        string TransactionRefNo, double CoverAmountUSD, double TransactionAmount, string RemitterAccountNo, string FirstName, string MiddleName,
        string LastName, string TelephoneNo, string Country, string BeneficiaryFirstName, string BeneficiaryMiddleName, string BeneficiaryLastName, string Address1,
        string Address2, string AccountNo, string City, string BeneficiaryTelephoneNo, string NICNo, string BeneficiaryZipCode, string UserID*/
                )
    {
        #region OLD cODE
        /*
        DataSet DS = new DataSet();
        DS = DataTransform.ReteriveDataMultiple("EXEC SPDS_SP_UniversalUpload_Add '" + TransactionRefNo + "'," + CoverAmountUSD + "," + TransactionAmount + ",'" + RemitterAccountNo + "','" +
                                    FirstName + "','" + MiddleName + "','" + LastName + "','" + TelephoneNo + "','" + Country + "','" + BeneficiaryFirstName + "','" + BeneficiaryMiddleName + "','" + BeneficiaryLastName + "','" +
                                    Address1 + "','" + Address2 + "','" + AccountNo + "','" + City + "','" + BeneficiaryTelephoneNo + "','" + NICNo + "','" + BeneficiaryZipCode + "'", "GET_ALL_USER");
        
        DS = DataTransform.ReteriveDataMultiple("EXEC SPDS_SP_UniversalUpload_Add " + CustomerId + ",0,0,0,0," + TransactionRefNo + "," + CoverAmountUSD + "," + TransactionAmount + ",0," + RemitterAccountNo + "," +
                                           FirstName + "," + MiddleName + "," + LastName + "," + TelephoneNo + "," + Country + "," + BeneficiaryFirstName + "," + BeneficiaryMiddleName + "," + BeneficiaryLastName + "," +
                                           Address1 + "," + Address2 + "," + AccountNo + "," + City + "," + BeneficiaryTelephoneNo + "," + NICNo + "," + BeneficiaryZipCode + ",'" + UserID + "','" + DateTime.Now + "','" + UserID + "','" + DateTime.Now + "',0,0,0", "GET_ALL_USER");
        return DS;
        */
        #endregion
        /*
        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[32];


        if (City == null) { City = ""; }

        PR[0] = DataTransform.Oracle_Param("V_PRINCIPLEBANKID", OracleType.Number, ParameterDirection.Input, CustomerId.ToString());
        PR[1] = DataTransform.Oracle_Param("V_INCOMINGBENEFICIARYID", OracleType.Number, ParameterDirection.Input, "0");
        PR[2] = DataTransform.Oracle_Param("v_incomingremittanceid", OracleType.Number, ParameterDirection.Input, "0");
        PR[3] = DataTransform.Oracle_Param("v_incomingremitterid", OracleType.Number, ParameterDirection.Input, "0");
        PR[4] = DataTransform.Oracle_Param("iv_incomingbatchheaderid", OracleType.Number, ParameterDirection.Input, "0");
        PR[5] = DataTransform.Oracle_Param("iv_transactionrefno", OracleType.VarChar, ParameterDirection.Input, TransactionRefNo.ToString());
        PR[6] = DataTransform.Oracle_Param("v_coveramountusd", OracleType.Number, ParameterDirection.Input, CoverAmountUSD);
        PR[7] = DataTransform.Oracle_Param("v_transactionamount", OracleType.Number, ParameterDirection.Input, TransactionAmount);
        PR[8] = DataTransform.Oracle_Param("v_remitterid", OracleType.Number, ParameterDirection.Input, "0");
        PR[9] = DataTransform.Oracle_Param("iv_remitteraccountno", OracleType.VarChar, ParameterDirection.Input, RemitterAccountNo.ToString());
        PR[10] = DataTransform.Oracle_Param("v_firstname", OracleType.VarChar, ParameterDirection.Input, FirstName.ToString());
        PR[11] = DataTransform.Oracle_Param("v_middlename", OracleType.VarChar, ParameterDirection.Input, MiddleName.ToString());
        PR[12] = DataTransform.Oracle_Param("v_lastname", OracleType.VarChar, ParameterDirection.Input, LastName.ToString());
        PR[13] = DataTransform.Oracle_Param("v_telephoneno", OracleType.VarChar, ParameterDirection.Input, TelephoneNo.ToString());
        PR[14] = DataTransform.Oracle_Param("v_country", OracleType.VarChar, ParameterDirection.Input, Country.ToString());
        PR[15] = DataTransform.Oracle_Param("v_beneficiaryfirstname", OracleType.VarChar, ParameterDirection.Input, BeneficiaryFirstName.ToString());
        PR[16] = DataTransform.Oracle_Param("v_beneficiarymiddlename", OracleType.VarChar, ParameterDirection.Input, BeneficiaryMiddleName.ToString());
        PR[17] = DataTransform.Oracle_Param("v_beneficiarylastname", OracleType.VarChar, ParameterDirection.Input, BeneficiaryLastName.ToString());
        PR[18] = DataTransform.Oracle_Param("v_address1", OracleType.VarChar, ParameterDirection.Input, Address1);
        PR[19] = DataTransform.Oracle_Param("v_address2", OracleType.VarChar, ParameterDirection.Input, Address2);
        PR[20] = DataTransform.Oracle_Param("iv_accountno", OracleType.VarChar, ParameterDirection.Input, AccountNo);
        PR[21] = DataTransform.Oracle_Param("v_city", OracleType.VarChar, ParameterDirection.Input, City.ToString());
        PR[22] = DataTransform.Oracle_Param("v_beneficiarytelephoneno", OracleType.VarChar, ParameterDirection.Input, BeneficiaryTelephoneNo);
        PR[23] = DataTransform.Oracle_Param("v_nicno", OracleType.VarChar, ParameterDirection.Input, NICNo);
        PR[24] = DataTransform.Oracle_Param("v_beneficiaryzipcode", OracleType.VarChar, ParameterDirection.Input, BeneficiaryZipCode);
        PR[25] = DataTransform.Oracle_Param("v_a_userid", OracleType.VarChar, ParameterDirection.Input, UserID);
        PR[26] = DataTransform.Oracle_Param("v_a_datetime", OracleType.DateTime, ParameterDirection.Input, DateTime.Now.ToString("dd-MMM-yyyy"));
        PR[27] = DataTransform.Oracle_Param("v_e_userid", OracleType.VarChar, ParameterDirection.Input, UserID);
        PR[28] = DataTransform.Oracle_Param("v_e_datetime", OracleType.DateTime, ParameterDirection.Input, DateTime.Now.ToString("dd-MMM-yyyy"));
        PR[29] = DataTransform.Oracle_Param("v_incomingbeneficiaryid1", OracleType.Number , ParameterDirection.Output, "");
        PR[30] = DataTransform.Oracle_Param("v_incomingremittanceid1", OracleType.Number, ParameterDirection.Output, "");
        PR[31] = DataTransform.Oracle_Param("v_incomingremitterid1", OracleType.Number, ParameterDirection.Output, "");

         */
        //spds_sp_universalupload_add
        DS = DataTransform.Oracle_GetDataSetSP("SPDS_SP_UniversalUpload_Add", PR);
        return DS;

    }
    public DataSet Get_SPDS_SP_CustomerBalanceUPD(OracleParameter[] PR)
    {
        DS = DataTransform.Oracle_GetDataSetSP("RPS_SP_CUST_BAL_UpDate", PR);
        return DS;
    }


    public DataSet Get_RPS_SP_CorrespondingBankFileData(int ID, int CorrespondingBankFileID, string CorrespondingBankUniqueId, string ProcessingDate, string DraftNo,
            DateTime DraftPaidDate, string BeneficiaryName, string Amount, string ProcessingRemarks, string BranchCode, string Charges,
            string Remarks, string Type, string TEZStatus, string TCSNo, string DispatchDate,
            string DeliveryDate, string RecievedBy, string A_UserId, DateTime A_DateTime, string E_UserId, DateTime E_DateTime)
    {
        DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC RPS_SP_CorrespondingBankFileData_Add " + ID + "," + CorrespondingBankFileID + ",'" + CorrespondingBankUniqueId + "','" + DraftPaidDate + "','" + DraftNo + "','" +
        //                            DraftPaidDate + "','" + BeneficiaryName + "'," + Amount + ",'" + ProcessingRemarks + "','" + BranchCode + "'," +
        //                            0 + ",'" + Remarks + "','" + Type + "','" + TEZStatus + "','" + TCSNo + "','" + DateTime.Now + "','" +
        //                            DateTime.Now + "','" + RecievedBy + "','" + A_UserId + "','" + A_DateTime + "','" + E_UserId + "','" + E_DateTime + "'", "GET_ALL_USER");
        OracleParameter[] PR = new OracleParameter[22];
        PR[0] = DataTransform.Oracle_Param("v_ID", OracleType.VarChar, ParameterDirection.Input, ID.ToString());
        PR[1] = DataTransform.Oracle_Param("v_CorrespondingBankFileID", OracleType.VarChar, ParameterDirection.Input, CorrespondingBankFileID.ToString());
        PR[2] = DataTransform.Oracle_Param("v_CorrespondingBankUniqueId", OracleType.VarChar, ParameterDirection.Input, CorrespondingBankUniqueId);
        PR[3] = DataTransform.Oracle_Param("v_ProcessingDate", OracleType.VarChar, ParameterDirection.Input, ProcessingDate);
        PR[4] = DataTransform.Oracle_Param("v_DraftNo", OracleType.VarChar, ParameterDirection.Input, DraftNo);
        PR[5] = DataTransform.Oracle_Param("v_DraftPaidDate", OracleType.VarChar, ParameterDirection.Input, DraftPaidDate.ToString());
        PR[6] = DataTransform.Oracle_Param("v_BeneficiaryName", OracleType.VarChar, ParameterDirection.Input, BeneficiaryName);
        PR[7] = DataTransform.Oracle_Param("v_Amount", OracleType.VarChar, ParameterDirection.Input, Amount.ToString());
        PR[8] = DataTransform.Oracle_Param("v_ProcessingRemarks", OracleType.VarChar, ParameterDirection.Input, ProcessingRemarks);
        PR[9] = DataTransform.Oracle_Param("v_BranchCode", OracleType.VarChar, ParameterDirection.Input, BranchCode);
        PR[10] = DataTransform.Oracle_Param("v_Charges", OracleType.VarChar, ParameterDirection.Input, Charges);
        PR[11] = DataTransform.Oracle_Param("v_Remarks", OracleType.VarChar, ParameterDirection.Input, Remarks);
        PR[12] = DataTransform.Oracle_Param("v_Type", OracleType.VarChar, ParameterDirection.Input, Type);
        PR[13] = DataTransform.Oracle_Param("v_TEZStatus", OracleType.VarChar, ParameterDirection.Input, TEZStatus);
        PR[14] = DataTransform.Oracle_Param("v_TCSNo", OracleType.VarChar, ParameterDirection.Input, TCSNo);
        PR[15] = DataTransform.Oracle_Param("v_DispatchDate", OracleType.VarChar, ParameterDirection.Input, DispatchDate);
        PR[16] = DataTransform.Oracle_Param("v_DeliveryDate", OracleType.VarChar, ParameterDirection.Input, DeliveryDate);
        PR[17] = DataTransform.Oracle_Param("v_RecievedBy", OracleType.VarChar, ParameterDirection.Input, RecievedBy);
        PR[18] = DataTransform.Oracle_Param("v_A_UserID", OracleType.VarChar, ParameterDirection.Input, A_UserId);
        PR[19] = DataTransform.Oracle_Param("v_A_DateTime", OracleType.VarChar, ParameterDirection.Input, A_DateTime.ToString());
        PR[20] = DataTransform.Oracle_Param("v_E_UserID", OracleType.VarChar, ParameterDirection.Input, E_UserId);
        PR[21] = DataTransform.Oracle_Param("v_E_DateTime", OracleType.VarChar, ParameterDirection.Input, E_DateTime.ToString());
        DataTransform.Oracle_GetDataSetSP_DML("RPS_SP_CorrBankFileData_Add", PR);

        //DS = DataTransform.ReteriveDataMultiple("EXEC RPS_SP_CorrBankFileData_Add " + ID + "," + CorrespondingBankFileID + ",'" + CorrespondingBankUniqueId + "','" + DraftPaidDate + "','" + DraftNo + "','" +
        //                          DraftPaidDate + "','" + BeneficiaryName + "'," + Amount + ",'" + ProcessingRemarks + "','" + BranchCode + "'," +
        //                        0 + ",'" + Remarks + "','" + Type + "','" + TEZStatus + "','" + TCSNo + "','" + DateTime.Now + "','" +
        //                      DateTime.Now + "','" + RecievedBy + "','" + A_UserId + "','" + A_DateTime + "','" + E_UserId + "','" + E_DateTime + "'", "GET_ALL_USER");


        return DS;
    }

    public DataSet Get_SPDS_SP_UniversalUploadConfiguration_GetAll(string Source, string ConfigurationName)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SPDS_SP_UniversalUploadConfiguration_GetAll '" + Source + "','" + ConfigurationName + "'", "GET_ALL_USER");
        //return DS;



        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[3];
        PR[0] = DataTransform.Oracle_Param("v_Source", OracleType.VarChar, ParameterDirection.Input, Source);
        PR[1] = DataTransform.Oracle_Param("v_ConfigurationName", OracleType.VarChar, ParameterDirection.Input, ConfigurationName);
        PR[2] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SPDS_SP_UNIVUploadConfigGetAll", PR);
        return DS;
    }

    public void SP_INSERT_SPDS_UniversalUploadCofigurationDetail(int id, int UniversalUploadID, string ColumnName, int Sequence, string A_userID, DateTime A_DateTime, string E_userID, DateTime E_DateTime)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_SET_INSERT_SPDS_UniversalUploadCofigurationDetail " + id + "," + UniversalUploadID + ",'" + ColumnName + "'," + Sequence + ",'" + A_userID + "','" + A_DateTime + "','" + E_userID + "','" + E_DateTime + "'", "GET_ALL_USER");


        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[8];
        PR[0] = DataTransform.Oracle_Param("v_id", OracleType.VarChar, ParameterDirection.Input, id.ToString());
        PR[1] = DataTransform.Oracle_Param("v_UniversalUploadID", OracleType.VarChar, ParameterDirection.Input, UniversalUploadID.ToString());
        PR[2] = DataTransform.Oracle_Param("v_ColumnName", OracleType.VarChar, ParameterDirection.Input, ColumnName);
        PR[3] = DataTransform.Oracle_Param("v_Sequence", OracleType.VarChar, ParameterDirection.Input, Sequence.ToString());
        PR[4] = DataTransform.Oracle_Param("v_A_userID", OracleType.VarChar, ParameterDirection.Input, A_userID);
        PR[5] = DataTransform.Oracle_Param("v_A_DateTime", OracleType.VarChar, ParameterDirection.Input, A_DateTime.ToString("dd-MMM-yyyy"));
        PR[6] = DataTransform.Oracle_Param("v_E_userID", OracleType.VarChar, ParameterDirection.Input, A_userID);
        PR[7] = DataTransform.Oracle_Param("v_E_DateTime", OracleType.VarChar, ParameterDirection.Input, E_DateTime.ToString("dd-MMM-yyyy"));

        //PR[8] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_INS_SPDS_UNIVUploadCofigDtl", PR);
        //return DS;
    }

    public DataSet Get_SPDS_SP_UniversalUploadCofigurationDetail_Get(string id)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_SPDS_UNIVUploadCofigDtl_Get '" + id + "'", "GET_ALL_USER");
        //return DS;


        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("v_ID", OracleType.VarChar, ParameterDirection.Input, id);
        PR[1] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_SPDS_UNIVUploadCofigDtl_Get", PR);
        return DS;

    }

    public DataSet Get_SPDS_SP_UniversalUploadCofigurationDetail_Delete(string id)
    {
        //    DataSet DS = new DataSet();
        //    DS = DataTransform.ReteriveDataMultiple("EXEC SP_SPDS_UniversalUploadCofigurationDetail_Delete '" + id + "'", "GET_ALL_USER");
        //    return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[1];
        PR[0] = DataTransform.Oracle_Param("v_ID", OracleType.VarChar, ParameterDirection.Input, id);
        //PR[1] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_SPDS_UNIVUploadCofigDtl_Del", PR);
        return DS;

    }

    public DataSet Get_SPDS_SP_UniversalUploadCofiguration_Maxid()
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SPDS_SP_UniversalUploadCofiguration_Maxid ", "GET_ALL_USER");
        //return DS;


        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[1];
        //PR[0] = DataTransform.Oracle_Param("v_ID", OracleType.VarChar, ParameterDirection.Input, id);
        PR[0] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SPDS_SP_UNIVUploadCofig_Maxid", PR);
        return DS;
    }

    public DataSet Get_RPS_SP_Branch_GetAllByParams(int BankID)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC RPS_SP_Branch_GetAllByParams " + BankID + " ", "GET_ALL_USER");
        //return DS;


        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("v_BankID", OracleType.VarChar, ParameterDirection.Input, BankID.ToString());

        PR[1] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("RPS_SP_Branch_GetAllByParams", PR);
        return DS;
    }

    public DataSet Get_CourierFileUpload(int CourierID, int CorrespondentID, string PODNo, string Status, string BeneficiaryMessage, DateTime DeliveryDate)
    {
        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[6];
        PR[0] = DataTransform.Oracle_Param("v_CourierID", OracleType.Number, ParameterDirection.Input, CourierID.ToString());
        PR[1] = DataTransform.Oracle_Param("iv_CorrespondingBankID", OracleType.Number, ParameterDirection.Input, CorrespondentID.ToString());
        PR[2] = DataTransform.Oracle_Param("v_PODNo", OracleType.VarChar, ParameterDirection.Input, PODNo.ToString());
        PR[3] = DataTransform.Oracle_Param("v_Status", OracleType.VarChar, ParameterDirection.Input, Status.ToString());
        PR[4] = DataTransform.Oracle_Param("v_BeneficiaryMessage", OracleType.VarChar, ParameterDirection.Input, BeneficiaryMessage);
        PR[5] = DataTransform.Oracle_Param("v_DeliveryDate", OracleType.DateTime, ParameterDirection.Input, DeliveryDate.ToString());
        DataTransform.Oracle_GetDataSetSP_DML("RPS_SP_POD_Upload", PR);

        //DS = DataTransform.ReteriveDataMultiple("EXEC RPS_SP_POD_Upload " + CourierID + "," + CorrespondentID + ",'" + PODNo + "','" + Status + "','" + BeneficiaryMessage + "','" + DeliveryDate + "'", "GET_ALL_USER");
        return DS;
    }

    public DataSet Get_SPDS_STATIONARY_MASTER_DP(string PARRID, string ID)
    {
        // DataSet DS = new DataSet();
        // DS = DataTransform.ReteriveDataMultiple("EXEC SPDS_STATIONARY_MASTER_DP " + PARRID + "," + ID + "", "GET_ALL_USER");
        // return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[3];
        PR[0] = DataTransform.Oracle_Param("v_PARRID", OracleType.VarChar, ParameterDirection.Input, PARRID);
        PR[1] = DataTransform.Oracle_Param("v_ID", OracleType.VarChar, ParameterDirection.Input, ID);

        PR[2] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SPDS_STATIONARY_MASTER_DP", PR);
        return DS;




    }

    public DataSet Get_SPDS_CourierPricing_Detail_DP_FLAT(int COURIERID)
    {
        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("v_CourierID", OracleType.VarChar, ParameterDirection.Input, COURIERID.ToString());
        PR[1] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SPDS_CourierPrice_Dtl_DP_FLAT", PR);


        //DS = DataTransform.ReteriveDataMultiple("EXEC SPDS_CourierPricing_Detail_DP_FLAT " + COURIERID + "", "GET_ALL_USER");
        return DS;
    }

    public DataSet Get_SPDS_DraftBulkCancellation_DP(int BatchID, int CustomerID, int ID)
    {
        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[4];
        PR[0] = DataTransform.Oracle_Param("v_BatchID", OracleType.VarChar, ParameterDirection.Input, BatchID.ToString());
        PR[1] = DataTransform.Oracle_Param("v_CustomerID", OracleType.VarChar, ParameterDirection.Input, CustomerID.ToString());
        PR[2] = DataTransform.Oracle_Param("v_ID", OracleType.VarChar, ParameterDirection.Input, ID.ToString());
        PR[3] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SPDS_DraftBulkCancellation_DP", PR);


        //DS = DataTransform.ReteriveDataMultiple("EXEC SPDS_DraftBulkCancellation_DP " + BatchID + "," + CustomerID + "," + ID + "", "GET_ALL_USER");
        return DS;
    }

    public DataSet GetAllZipCodes()
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_GetAllZipCodes ", "GET_ALL_USER");
        //return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[1];
        PR[0] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_GetAllZipCodes", PR);
        return DS;


    }

    public DataSet GetAllZipCodes_Corr(string CID, string MIN_ZIP, string MAX_ZIP, string CorrBankID)
    {
        // DataSet DS = new DataSet();
        // DS = DataTransform.ReteriveDataMultiple("EXEC SP_GetAllZipCodes_Corr " + CID + ",'" + MIN_ZIP + "','" + MAX_ZIP + "','" + CorrBankID + "'", "GET_ALL_USER");
        // return DS;



        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[5];
        PR[0] = DataTransform.Oracle_Param("v_CID", OracleType.Cursor, ParameterDirection.Output, "CID");
        PR[1] = DataTransform.Oracle_Param("v_MIN_ZIP", OracleType.Cursor, ParameterDirection.Output, "MIN_ZIP");
        PR[2] = DataTransform.Oracle_Param("v_MAX_ZIP", OracleType.Cursor, ParameterDirection.Output, "MAX_ZIP");
        PR[3] = DataTransform.Oracle_Param("v_CorrBankID", OracleType.Cursor, ParameterDirection.Output, "CorrBankID");
        PR[4] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");

        DS = DataTransform.Oracle_GetDataSetSP("SP_GetAllZipCodes_Corr", PR);
        return DS;




    }

    public DataSet GetAllZipCodes_Corrbank(string CID, string MIN_ZIP, string MAX_ZIP, string CorrBankID)
    {
        //DataSet DS = new DataSet();
        //  DS = DataTransform.ReteriveDataMultiple("EXEC SP_GetAllZipCodes_Corrbank " + CID + ",'" + MIN_ZIP + "','" + MAX_ZIP + "','" + CorrBankID + "'", "GET_ALL_USER");
        // return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[5];
        PR[0] = DataTransform.Oracle_Param("iv_CID", OracleType.Cursor, ParameterDirection.Output, "CID");
        PR[1] = DataTransform.Oracle_Param("v_MIN_ZIP", OracleType.Cursor, ParameterDirection.Output, "MIN_ZIP");
        PR[2] = DataTransform.Oracle_Param("v_MAX_ZIP", OracleType.Cursor, ParameterDirection.Output, "MAX_ZIP");
        PR[3] = DataTransform.Oracle_Param("v_CorrBankID", OracleType.Cursor, ParameterDirection.Output, "CorrBankID");
        PR[4] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");

        DS = DataTransform.Oracle_GetDataSetSP("SP_GetAllZipCodes_Corrbank", PR);
        return DS;


    }

    public DataSet Get_PrintLocationCheckZipCodes(int ZipCodeID)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_PrintLocationCheckZipCode " + ZipCodeID + "", "GET_ALL_USER");
        // return DS;


        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[5];

        PR[0] = DataTransform.Oracle_Param("v_ZipCodeID", OracleType.Cursor, ParameterDirection.Output, "ZipCodeID");
        PR[1] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");

        DS = DataTransform.Oracle_GetDataSetSP("SP_PrintLocationCheckZipCode", PR);
        return DS;




    }

    public DataSet Get_SP_ZIPCODE_CHECK(string MASTER_ZIP_CODE, string PRINT_AGENT_DETAIL_ID)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_ZIPCODE_CHECK '" + MASTER_ZIP_CODE + "','" + PRINT_AGENT_DETAIL_ID + "'", "GET_ALL_USER");
        //return DS;



        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("v_MASTER_ZIP_CODE", OracleType.VarChar, ParameterDirection.Input, MASTER_ZIP_CODE.ToString());
        PR[1] = DataTransform.Oracle_Param("v_PRINT_AGENT_DETAIL_ID", OracleType.VarChar, ParameterDirection.Input, PRINT_AGENT_DETAIL_ID.ToString());

        //PR[2] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_ZIPCODE_CHECK", PR);
        return DS;
    }

    public DataSet Get_SP_SPDS_CheckDepenOffsiteDwld()
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_SPDS_CheckDepenOffsiteDwld ", "GET_ALL_USER");
        //return DS;


        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[1];

        PR[0] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_SPDS_CheckDepenOffsiteDwld", PR);
        return DS;
    }

    public DataSet Get_SP_OfflineDownloadCheckStationary(string PrintAgentID)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_OfflineDownloadCheckStationary " + PrintAgentID + "", "GET_ALL_USER");
        //return DS;



        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("v_PrintAgentID", OracleType.VarChar, ParameterDirection.Input, PrintAgentID.ToString());


        PR[1] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_OfflineDnldCheckStationary", PR);
        return DS;
    }

    public DataSet Get_RPS_SP_MoneyGramRemittance_Authorize(string ID, string A_UserID, string A_DateTime)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC RPS_SP_MoneyGramRemittance_Authorize '" + ID + "','" + A_UserID + "','" + A_DateTime + "'", "GET_ALL_USER");
        //return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[4];
        PR[0] = DataTransform.Oracle_Param("v_ID", OracleType.VarChar, ParameterDirection.Input, ID.ToString());
        PR[1] = DataTransform.Oracle_Param("v_A_UserID", OracleType.VarChar, ParameterDirection.Input, A_UserID.ToString());
        PR[2] = DataTransform.Oracle_Param("v_A_DateTime", OracleType.VarChar, ParameterDirection.Input, A_DateTime.ToString());



        PR[3] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("RPS_SP_MGramRemittance_Auth", PR);
        return DS;
    }

    public void Get_spds_UniversalUploadFiles_INSERT(int ID, int PrincipleBankID, string FileName, string ConfigurationName, string ReceivedDateTime, int NoOfRecords, string Remarks, string A_UserID, string A_DateTime, string E_UserID, string E_DateTime)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC spds_UniversalUploadFiles_INSERT " + ID + "," + PrincipleBankID + ",'" + FileName + "','" + ConfigurationName + "','" + ReceivedDateTime + "','" + NoOfRecords + "','" + Remarks + "','" + A_UserID + "','" + A_DateTime + "','" + E_UserID + "','" + E_DateTime + "'", "GET_ALL_USER");

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[12];
        PR[0] = DataTransform.Oracle_Param("v_ID", OracleType.VarChar, ParameterDirection.Input, ID.ToString());
        PR[1] = DataTransform.Oracle_Param("v_PrincipleBankID", OracleType.VarChar, ParameterDirection.Input, PrincipleBankID.ToString());
        PR[2] = DataTransform.Oracle_Param("v_FileName", OracleType.VarChar, ParameterDirection.Input, FileName.ToString());
        PR[3] = DataTransform.Oracle_Param("v_ConfigurationName", OracleType.VarChar, ParameterDirection.Input, ConfigurationName.ToString());
        PR[4] = DataTransform.Oracle_Param("v_ReceivedDateTime", OracleType.VarChar, ParameterDirection.Input, ReceivedDateTime.ToString());
        PR[5] = DataTransform.Oracle_Param("v_NoOfRecords", OracleType.VarChar, ParameterDirection.Input, NoOfRecords.ToString());
        PR[6] = DataTransform.Oracle_Param("v_Remarks", OracleType.VarChar, ParameterDirection.Input, Remarks.ToString());
        PR[7] = DataTransform.Oracle_Param("v_A_UserID", OracleType.VarChar, ParameterDirection.Input, A_UserID.ToString());
        PR[8] = DataTransform.Oracle_Param("v_A_DateTime", OracleType.VarChar, ParameterDirection.Input, A_DateTime.ToString());
        PR[9] = DataTransform.Oracle_Param("v_E_UserID", OracleType.VarChar, ParameterDirection.Input, E_UserID.ToString());
        PR[10] = DataTransform.Oracle_Param("v_E_DateTime", OracleType.VarChar, ParameterDirection.Input, E_DateTime.ToString());
        PR[11] = DataTransform.Oracle_Param("v_return", OracleType.VarChar, ParameterDirection.Output, "");

        DS = DataTransform.Oracle_GetDataSetSP("SP_UniversalUploadFile_INSERT", PR);



    }

    public DataSet Get_spds_UniversalUploadFiles_DP(string FileName)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC spds_UniversalUploadFiles_DP '" + FileName + "'", "GET_ALL_USER");
        //return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("v_FileName", OracleType.VarChar, ParameterDirection.Input, FileName);
        PR[1] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("spds_UniversalUploadFiles_DP", PR);
        return DS;

    }

    public DataSet Get_SP_SPDS_CorrespondentBankPricing_ALL(string ID)
    {
        DataSet DS = new DataSet();
        DS = DataTransform.ReteriveDataMultiple("EXEC SP_SPDS_CorrespondentBankPricing_ALL " + ID + "", "GET_ALL_USER");
        return DS;
    }

    public DataSet Get_SP_SPDS_CorrespondentBankPricing_SPC(string ID)
    {
        DataSet DS = new DataSet();
        DS = DataTransform.ReteriveDataMultiple("EXEC SP_SPDS_CorrespondentBankPricing_SPC " + ID + "", "GET_ALL_USER");
        return DS;
    }

    public DataSet Get_SP_SPDS_INSERT_CorrespondentBankPricing(string ID, string CorrespondentBankID, string OfflineCharges, string OnlineCharges, string E_UserId)
    {
        DataSet DS = new DataSet();
        DS = DataTransform.ReteriveDataMultiple("EXEC SP_SPDS_INSERT_CorrespondentBankPricing " + ID + "," + CorrespondentBankID + "," + OfflineCharges + "," + OnlineCharges + ",'" + E_UserId + "'", "GET_ALL_USER");
        return DS;
    }

    public DataSet Get_SP_SPDS_UPDATE_CorrespondentBankPricing(string ID, string CorrespondentBankID, string OfflineCharges, string OnlineCharges, string E_UserId)
    {
        DataSet DS = new DataSet();
        DS = DataTransform.ReteriveDataMultiple("EXEC SP_SPDS_UPDATE_CorrespondentBankPricing " + ID + "," + CorrespondentBankID + "," + OfflineCharges + "," + OnlineCharges + ",'" + E_UserId + "'", "GET_ALL_USER");
        return DS;
    }

    public DataSet Get_SP_SPDS_CorrespondentBankPricing_DP(string CorrespondentBankID, string ID)
    {
        DataSet DS = new DataSet();
        DS = DataTransform.ReteriveDataMultiple("EXEC SP_SPDS_CorrespondentBankPricing_DP " + CorrespondentBankID + "," + ID + "", "GET_ALL_USER");
        return DS;
    }

    public DataSet Get_SP_SPDS_CheckSum(string CodeString)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_SPDS_CheckSum '" + CodeString + "'", "GET_ALL_USER");
        //return DS;



        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("v_CodeString", OracleType.VarChar, ParameterDirection.Input, CodeString.ToString());

        PR[1] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_SPDS_CheckSum", PR);
        return DS;
    }

    public DataSet Get_SP_SPDSOleConnection(string FilePath)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_SPDSOleConnection '" + FilePath + "'", "GET_ALL_USER");
        //return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("v_FilePath", OracleType.VarChar, ParameterDirection.Input, FilePath.ToString());

        PR[1] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_SPDSOleConnection", PR);
        return DS;
    }

    public void Get_File_Upload_Activity_INSERT(int @File_ID, string @File_Path, string @File_Name, string @File_Content, string @File_Size, string @File_Format)
    {
        DataSet DS = new DataSet();
        DS = DataTransform.ReteriveDataMultiple("EXEC File_Upload_Activity_INSERT " + @File_ID + ",'" + @File_Path + "','" + @File_Name + "'," + @File_Content + ",'" + @File_Size + "','" + @File_Format + "'", "GET_ALL_USER");
    }

    public DataSet Get_CURRENCY_RATE_AUTH(string TableName, string A_UserID, string A_DateTime)
    {
        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[3];
        PR[0] = DataTransform.Oracle_Param("v_TableName", OracleType.VarChar, ParameterDirection.Input, TableName);
        PR[1] = DataTransform.Oracle_Param("v_A_UserID", OracleType.VarChar, ParameterDirection.Input, A_UserID);
        PR[2] = DataTransform.Oracle_Param("v_A_DateTime", OracleType.VarChar, ParameterDirection.Input, A_DateTime);
        DataTransform.Oracle_GetDataSetSP_DML("CURRENCY_RATE_AUTH", PR);

        //DS = DataTransform.ReteriveDataMultiple("EXEC CURRENCY_RATE_AUTH '" + TableName + "','" + A_UserID + "','" + A_DateTime + "'", "GET_ALL_USER");
        return DS;
    }

    public DataSet Get_A2A_REJECTION_GETDRAFT(string RemitterRefNo)
    {
        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("v_RemittanceRefNo", OracleType.VarChar, ParameterDirection.Input, RemitterRefNo);
        PR[1] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("A2A_REJECTION_GETDRAFT", PR);


        //DS = DataTransform.ReteriveDataMultiple("EXEC A2A_REJECTION_GETDRAFT '" + RemitterRefNo + "'", "GET_ALL_USER");
        return DS;
    }

    public void Get_SPDS_SP_A2A_REJECTION_INSERT(int DraftID, string ATA_STATUS, string ATA_REMARKS, string RETURN_FILE_NAME)
    {
        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[3];
        PR[0] = DataTransform.Oracle_Param("v_DraftID", OracleType.VarChar, ParameterDirection.Input, DraftID.ToString());
        PR[1] = DataTransform.Oracle_Param("v_ATA_STATUS", OracleType.VarChar, ParameterDirection.Input, ATA_STATUS);
        PR[2] = DataTransform.Oracle_Param("v_ATA_REMARKS", OracleType.VarChar, ParameterDirection.Input, ATA_REMARKS);
        PR[2] = DataTransform.Oracle_Param("v_RETURN_FILE_NAME", OracleType.VarChar, ParameterDirection.Input, RETURN_FILE_NAME);
        DataTransform.Oracle_GetDataSetSP_DML("SPDS_SP_A2A_REJECTION_INSERT", PR);



        //DS = DataTransform.ReteriveDataMultiple("EXEC SPDS_SP_A2A_REJECTION_INSERT " + DraftID + ",'" + ATA_STATUS + "','" + ATA_REMARKS + "','" + RETURN_FILE_NAME + "'", "GET_ALL_USER");

    }

    public void Get_SPDS_SP_A2A_REJECTION_UPDATE(string RemitterRefNo)
    {
        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[1];
        PR[0] = DataTransform.Oracle_Param("v_RemittanceRefNoList", OracleType.VarChar, ParameterDirection.Input, RemitterRefNo);
        DataTransform.Oracle_GetDataSetSP_DML("SPDS_SP_A2A_REJECTION_UPDATE", PR);



        //DS = DataTransform.ReteriveDataMultiple("EXEC SPDS_SP_A2A_REJECTION_UPDATE '" + RemitterRefNo + "'", "GET_ALL_USER");
    }

    public DataSet Get_SPDS_SP_GETFILENAME(string ReturnFileName)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SPDS_SP_GETFILENAME '" + ReturnFileName + "'", "GET_ALL_USER");
        //return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("v_ReturnFileName", OracleType.VarChar, ParameterDirection.Input, ReturnFileName.ToString());

        PR[1] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SPDS_SP_GETFILENAME", PR);
        return DS;
    }

    public void SPDS_SP_BLOB_INSERT(string FileID, string FilePath, string FileName, byte[] FileContent, string FileSize, string FileFormat)
    {
        DataSet DS = new DataSet();
        DS = DataTransform.ReteriveDataMultiple("EXEC SPDS_SP_BLOB_INSERT " + FileID + ",'" + FilePath + "','" + FileName + "'," + FileContent + ",'" + FileSize + "','" + FileFormat + "'", "GET_ALL_USER");
    }

    public DataSet GetA2ARejectionDownload_GetAll()
    {
        // DataSet DS = new DataSet();
        // DS = DataTransform.ReteriveDataMultiple("EXEC SPDS_A2ARejectionDownload_GetAll", "GET_ALL_USER");
        // return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[1];
        PR[0] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SPDS_A2ARejectDownload_GetAll", PR);
        return DS;


    }

    public DataSet A2ARejectionDownload(string ID)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SPDS_SP_A2ADownloadRejection " + ID, "GET_ALL_USER");
        //return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("v_ID", OracleType.VarChar, ParameterDirection.Input, ID.ToString());

        PR[1] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SPDS_SP_A2ADownloadRejection", PR);
        return DS;
    }

    public void A2ADownloadRejectionMarking(string ID)
    {
        DataSet DS = new DataSet();
        DS = DataTransform.ReteriveDataMultiple("SPDS_SP_A2ADownloadRejectionMarking " + ID, "GET_ALL_USER");
    }

    public DataSet Get_DraftAssignmet_Summary()
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SPDS_SP_DraftAssignmet_Summary ", "GET_ALL_USER");
        //return DS;


        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[1];

        PR[0] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SPDS_SP_DraftAssignmet_Summary", PR);
        return DS;
    }

    public void PRIUploader_OB(int CustomerID, string Reason, string FileName, string UserID)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SPDS_SP_PRIUpload_OB " + CustomerID  + ",'" + Reason + "','" + FileName + "','" + UserID + "'", "GET_ALL_USER");


        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[4];
        //PR[0] = DataTransform.Oracle_Param("v_CustomerID", OracleType.VarChar, ParameterDirection.Input, CustomerID.ToString());
        PR[0] = DataTransform.Oracle_Param("v_CustomerID", OracleType.Number, ParameterDirection.Input, CustomerID);
        PR[1] = DataTransform.Oracle_Param("v_Reason", OracleType.VarChar, ParameterDirection.Input, Reason.ToString());
        PR[2] = DataTransform.Oracle_Param("v_FileName", OracleType.VarChar, ParameterDirection.Input, FileName.ToString());
        PR[3] = DataTransform.Oracle_Param("v_UserID", OracleType.VarChar, ParameterDirection.Input, UserID.ToString());
        //PR[4] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SPDS_SP_PRIUpload_OB", PR);

        //return DS;
    }

    public void PRIUploader_OB_Process(string FileName)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SPDS_SP_PRIUpload_Process '" + FileName + "'", "GET_ALL_USER");

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[1];
        PR[0] = DataTransform.Oracle_Param("v_FileName", OracleType.VarChar, ParameterDirection.Input, FileName.ToString());

        //PR[1] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SPDS_SP_PRIUpload_Process", PR);
        //return DS;
    }

    public DataSet PRIUploader_OB_FileCheck(string FileName)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SPDS_SP_PRIUploader_OB_FileCheck '" + FileName + "'", "GET_ALL_USER");
        //return DS;

        //DataSet DS = new DataSet();
        //OracleParameter[] PR = new OracleParameter[2];
        //PR[0] = DataTransform.Oracle_Param("v_FileName", OracleType.VarChar, ParameterDirection.Input, FileName.ToString());
        //PR[1] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");
        ////DS = DataTransform.Oracle_GetDataSetSP("SPDS_SP_PRIUploader_OB_FileCheck", PR);
        //DS = DataTransform.Oracle_GetDataSetSP("SP_PRIUploadFileCheck", PR);

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("v_FN", OracleType.VarChar, ParameterDirection.Input, FileName.ToString());
        PR[1] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        //DS = DataTransform.Oracle_GetDataSetSP("SPDS_SP_PRIUploader_OB_FileCheck", PR);
        DS = DataTransform.Oracle_GetDataSetSP("SP_PRIUploadFileCheck", PR);
        return DS;
    }

    public DataSet SP_GETDATA_DPAGE(String P_projectid)
    {
        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("P_projectid", OracleType.VarChar, ParameterDirection.Input, P_projectid);
        PR[1] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_GETDATA_DPAGE", PR);
        return DS;
    }

    public DataSet Get_Column_Lenght(string p_conf_def_id)
    {
        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("p_conf_def_id", OracleType.VarChar, ParameterDirection.Input, p_conf_def_id);
        PR[1] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("sp_get_file_column", PR);
        return DS;
    }


    /*WebService Methods*/
    #region"Reject"
    public DataSet GET_SP_REJECT_ALL(string code, string description)
    {
        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[3];
        PR[0] = DataTransform.Oracle_Param("v_code", OracleType.VarChar, ParameterDirection.Input, code);
        PR[1] = DataTransform.Oracle_Param("v_description", OracleType.VarChar, ParameterDirection.Input, description);
        PR[2] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("RPS_SP_REJECT_GETALL", PR);

        return DS;
    }

    public DataSet GET_SP_REJECT_BYCODE(string code)
    {
        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("p_code", OracleType.VarChar, ParameterDirection.Input, code);
        PR[1] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("RPS_SP_REJECT_GetByCode", PR);
        return DS;
    }

    public DataSet SP_REJECT_DP(string code, string id)
    {
        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[3];
        PR[0] = DataTransform.Oracle_Param("v_code", OracleType.VarChar, ParameterDirection.Input, code);
        PR[1] = DataTransform.Oracle_Param("v_id", OracleType.VarChar, ParameterDirection.Input, id);
        PR[2] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("RPS_SP_REJECT", PR);
        return DS;
    }
    #endregion

    #region BeneficairyType
    public DataSet GET_CMN_BENETYPE_ALL(string code, string description)
    {
        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[3];
        PR[0] = DataTransform.Oracle_Param("v_code", OracleType.VarChar, ParameterDirection.Input, code);
        PR[1] = DataTransform.Oracle_Param("v_description", OracleType.VarChar, ParameterDirection.Input, description);
        PR[2] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("RPS_SP_BENTYPE_GETALL", PR);

        return DS;
    }

    public DataSet GET_CMN_BENETYPE_BYCODE(string code)
    {

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("p_code", OracleType.VarChar, ParameterDirection.Input, code);
        PR[1] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("RPS_SP_BENTYPE_GETBYCODE", PR);
        return DS;
    }

    public DataSet SP_BENETYPE_DP(string code, string ID)
    {
        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[3];
        PR[0] = DataTransform.Oracle_Param("v_code", OracleType.VarChar, ParameterDirection.Input, code);
        PR[1] = DataTransform.Oracle_Param("v_id", OracleType.VarChar, ParameterDirection.Input, ID);
        PR[2] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("RPS_SP_BENTYPE", PR);
        return DS;
    }
    #endregion

    #region ServiceProvider
    public DataSet GET_CMN_PROVIDER_ALL()
    {
        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[1];
        PR[0] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("RPS_SP_SERVICE_GETALL", PR);

        return DS;
    }

    public DataSet GET_CMN_PROVIDER_BYCODE(string code)
    {
        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("p_code", OracleType.VarChar, ParameterDirection.Input, code);
        PR[1] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("RPS_SP_SERVICE_GETBYCODE", PR);
        return DS;
    }

    public DataSet SP_PROVIDER_DP(string code, string description)
    {
        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[3];
        PR[0] = DataTransform.Oracle_Param("v_code", OracleType.VarChar, ParameterDirection.Input, code);
        PR[1] = DataTransform.Oracle_Param("v_description", OracleType.VarChar, ParameterDirection.Input, description);
        PR[2] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("RPS_SP_PROVIDER", PR);
        return DS;
    }
    #endregion

    #region"Reason"
    public DataSet Get_CMN_REASON_ALL(string code, string description)
    {
        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[3];
        PR[0] = DataTransform.Oracle_Param("v_code", OracleType.VarChar, ParameterDirection.Input, code);
        PR[1] = DataTransform.Oracle_Param("v_description", OracleType.VarChar, ParameterDirection.Input, description);
        PR[2] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("RPS_SP_REASON_GETALL", PR);

        return DS;
    }

    public DataSet GET_SP_REASON_BYCODE(string code)
    {

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("p_code", OracleType.VarChar, ParameterDirection.Input, code);
        PR[1] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("RPS_SP_REASON_GETBYCODE", PR);
        return DS;
    }

    public DataSet SP_REASON_DP(string code, string id)
    {
        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[3];
        PR[0] = DataTransform.Oracle_Param("v_code", OracleType.VarChar, ParameterDirection.Input, code);
        PR[1] = DataTransform.Oracle_Param("v_id", OracleType.VarChar, ParameterDirection.Input, id);
        PR[2] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("RPS_SP_REASON", PR);
        return DS;
    }
    #endregion

    #region "CUSTOMER_BALANCE"
    public DataSet GET_SP_CUST_BAL_ALL(string COMPANY_CODE, string COMPANY_NAME)
    {
        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[3];

        PR[0] = DataTransform.Oracle_Param("P_COMPANY_CODE", OracleType.VarChar, ParameterDirection.Input, COMPANY_CODE);
        PR[1] = DataTransform.Oracle_Param("P_COMPANY_NAME", OracleType.VarChar, ParameterDirection.Input, COMPANY_NAME);
        PR[2] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("RPS_SP_CUST_BAL_GETALL", PR);

        return DS;
    }

    public DataSet GET_SP_CUST_BAL_BYCODE(string v_BankCode)
    {

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("v_BankCode", OracleType.VarChar, ParameterDirection.Input, v_BankCode);
        PR[1] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("RPS_SP_CUST_BAL_GETBYCODE", PR);
        return DS;
    }
    #endregion

    /////**************CustomerConfigLink***************
    #region
    public DataSet SP_CUST_CONF_LINK_GETALL(string COMPANY_CODE, string CONF_DEF_ID)
    {
        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[3];
        PR[0] = DataTransform.Oracle_Param("v_COMPANY_CODE", OracleType.VarChar, ParameterDirection.Input, COMPANY_CODE);
        PR[1] = DataTransform.Oracle_Param("v_CONF_DEF_ID", OracleType.VarChar, ParameterDirection.Input, CONF_DEF_ID);
        PR[2] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_CUST_CONF_LINK_GETALL", PR);
        return DS;
    }
    public DataSet SP_CUST_CONF_LINK_SPC(string COMPANY_CODE, string CONF_DEF_ID)
    {
        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[3];
        PR[0] = DataTransform.Oracle_Param("v_COMPANY_CODE", OracleType.VarChar, ParameterDirection.Input, COMPANY_CODE);
        PR[1] = DataTransform.Oracle_Param("v_CONF_DEF_ID", OracleType.VarChar, ParameterDirection.Input, CONF_DEF_ID);
        PR[2] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_CUST_CONF_LINK_GetByCode", PR);
        return DS;
    }
    public DataSet Get_CUST_CONF_LINK_GetByCode(string ID)
    {
        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("p_ID", OracleType.VarChar, ParameterDirection.Input, ID);
        //PR[1] = DataTransform.Oracle_Param("p_CONF_DEF_ID", OracleType.VarChar, ParameterDirection.Input, CONF_DEF_ID);
        PR[1] = DataTransform.Oracle_Param("cv_1", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_CUST_CONF_LINK_GetByCode", PR);
        if (DS.Tables[0].Rows.Count > 0)
        {
            HttpContext.Current.Session["COMCODE"] = DS.Tables[0].Rows[0]["company_code"].ToString();
            HttpContext.Current.Session["CONF_DEF"] = DS.Tables[0].Rows[0]["conf_def_id"].ToString();
        }
        return DS;
    }
    public DataSet Get_Company_setup_lov(string COMPANYCODE, string COMPANYNAME)
    {
        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[3];
        PR[0] = DataTransform.Oracle_Param("P_COMPANY_CODE", OracleType.VarChar, ParameterDirection.Input, COMPANYCODE);
        PR[1] = DataTransform.Oracle_Param("P_COMPANY_NAME", OracleType.VarChar, ParameterDirection.Input, COMPANYNAME);
        PR[2] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_COMPANY_SETUP_ALL", PR);
        return DS;
    }
    public DataSet Get_Company_setup_lov(string COMPANYCODE, string COMPANYNAME, string User_name)
    {
        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[4];
        PR[0] = DataTransform.Oracle_Param("P_COMPANY_CODE", OracleType.VarChar, ParameterDirection.Input, COMPANYCODE);
        PR[1] = DataTransform.Oracle_Param("P_COMPANY_NAME", OracleType.VarChar, ParameterDirection.Input, COMPANYNAME);
        PR[2] = DataTransform.Oracle_Param("P_USR_NAME", OracleType.VarChar, ParameterDirection.Input, User_name);
        PR[3] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_USER_COMPANY_DETAIL", PR);
        return DS;
    }

    public DataSet Get_CONFIG_DEF_MASTER_LOV(string P_Para_type, string Company_Code, string CONF_DEF_ID, string CONF_DEF_desc)
    {
        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[5];
        PR[0] = DataTransform.Oracle_Param("p_company_code", OracleType.VarChar, ParameterDirection.Input, Company_Code);
        PR[1] = DataTransform.Oracle_Param("P_CONF_DEF_ID", OracleType.VarChar, ParameterDirection.Input, CONF_DEF_ID);
        PR[2] = DataTransform.Oracle_Param("P_CONF_DEF_desc", OracleType.VarChar, ParameterDirection.Input, CONF_DEF_desc);
        PR[3] = DataTransform.Oracle_Param("P_Para_type", OracleType.VarChar, ParameterDirection.Input, P_Para_type);
        PR[4] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_CONFIG_DEF_MASTER_ALL", PR);
        return DS;

    }
    #endregion

    public DataSet Get_SP_Data_Segregation_fillgird(string P_company_code, string P_FILE_NAME)
    {
        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[3];
        PR[0] = DataTransform.Oracle_Param("P_company_code", OracleType.VarChar, ParameterDirection.Input, P_company_code);
        PR[1] = DataTransform.Oracle_Param("P_FILE_NAME", OracleType.VarChar, ParameterDirection.Input, P_FILE_NAME);
        PR[2] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_Data_Segregation", PR);
        return DS;
    }
    public DataSet Get_PS_SP_CorrBank_LOV(string Bank_Code, string Bank_Name)
    {
        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[3];
        PR[0] = DataTransform.Oracle_Param("v_BankCode", OracleType.VarChar, ParameterDirection.Input, Bank_Code);
        PR[1] = DataTransform.Oracle_Param("v_BankName", OracleType.VarChar, ParameterDirection.Input, Bank_Name);
        PR[2] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("PS_SP_CorrBank_LOV", PR);
        return DS;
    }

    public DataSet Get_PS_SP_Agent_LOV()
    {
        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        PR[1] = DataTransform.Oracle_Param("v_retval", OracleType.VarChar, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_COMPANY_LOV", PR);
        return DS;
    }
    public void Insertdata(string val)
    {
        DataSet DS = new DataSet();
        OracleParameter[] parm = new OracleParameter[1];
        parm[0] = new OracleParameter();
        parm[0] = DataTransform.Oracle_Param("p_val", OracleType.VarChar, ParameterDirection.Input, val);

        DataTransform.Oracle_GetDataSetSP_DML("sp_logData", parm);
    }
    public DataSet UniversalUploadDataBind(string CompanyCode, string filename)
    {
        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[10];
        PR[0] = DataTransform.Oracle_Param("P_company_code", OracleType.VarChar, ParameterDirection.Input, CompanyCode);
        PR[1] = DataTransform.Oracle_Param("P_FILE_NAME", OracleType.VarChar, ParameterDirection.Input, filename);
        PR[2] = DataTransform.Oracle_Param("P_Trans_type", OracleType.VarChar, ParameterDirection.Input, "");
        PR[3] = DataTransform.Oracle_Param("P_Rowid", OracleType.VarChar, ParameterDirection.Input, "");
        PR[4] = DataTransform.Oracle_Param("p_bank_code", OracleType.VarChar, ParameterDirection.Input, "");
        PR[5] = DataTransform.Oracle_Param("p_branch_code", OracleType.VarChar, ParameterDirection.Input, "");
        PR[6] = DataTransform.Oracle_Param("P_Userid", OracleType.VarChar, ParameterDirection.Input, "");
        PR[7] = DataTransform.Oracle_Param("P_type", OracleType.VarChar, ParameterDirection.Input, "15");
        PR[8] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        PR[9] = DataTransform.Oracle_Param("v_retval", OracleType.VarChar, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_Data_Segregation", PR);
        return DS;
    }
    public DataSet FileFormat(string ConfigDefID)
    {
        DataSet ds = new DataSet();
        string sql = "select  case when FILE_FORMAT = 1 then 'XLS' " +
        " when FILE_FORMAT = 2 then 'CSV' when FILE_FORMAT = 3 then 'TXT' end FILEFORMAT ,trim(nvl(S.FILESEPARATE,',')) " +
        " from config_def_master s where s.conf_def_id ='" + ConfigDefID + "' ";
        ds = DataTransform.Local_GetDataSet1(sql);
        return ds;
        //if (ds.Tables[0].Rows.Count > 0)
        //{
        //    return ds.Tables[0].Rows[0][0].ToString() + ";" + ds.Tables[0].Rows[0][1].ToString();
        //}
        //else
        //{
        //    return "";
        //}
    }
    public DataSet GetContactNoforSMS(string CompanyCode, string filename, string type)
    {
        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[4];
        PR[0] = DataTransform.Oracle_Param("P_company_code", OracleType.VarChar, ParameterDirection.Input, CompanyCode);
        PR[1] = DataTransform.Oracle_Param("P_FILE_NAME", OracleType.VarChar, ParameterDirection.Input, filename);
        PR[2] = DataTransform.Oracle_Param("P_type", OracleType.VarChar, ParameterDirection.Input, type);
        PR[3] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SEND_SMS", PR);
        return DS;
    }
    public DataSet GetIDPASSforSMS(string sql)
    {
        DataSet DS = new DataSet();
        DS = DataTransform.Local_GetDataSet1(sql);
        return DS;
    }
    public DataSet getSkipColumn(string p_conf_def_id)
    {
        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("p_conf_def_id", OracleType.VarChar, ParameterDirection.Input, p_conf_def_id);
        PR[1] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("sp_getSkipColumn", PR);
        return DS;
    }
    public DataSet GetFileSummary(string p_company_code, string p_file_name)
    {
        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[4];
        PR[0] = DataTransform.Oracle_Param("P_company_code", OracleType.VarChar, ParameterDirection.Input, p_company_code);
        PR[1] = DataTransform.Oracle_Param("P_FILE_NAME", OracleType.VarChar, ParameterDirection.Input, p_file_name);
        PR[2] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        PR[3] = DataTransform.Oracle_Param("DATA_RESULTSET1", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("sp_dataload_summary", PR);
        return DS;
    }
    public DataSet SP_COMPANY_BALANCE(string COMPANYCODE)
    {
        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("P_COMPANY_CODE", OracleType.VarChar, ParameterDirection.Input, COMPANYCODE);
        PR[1] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_COMPANY_BALANCE", PR);
        return DS;

    }
    public DataSet SP_GET_USERIFNO(string P_USR_ID)
    {
        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("P_USR_ID", OracleType.VarChar, ParameterDirection.Input, P_USR_ID);
        PR[1] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_GET_USERIFNO", PR);
        return DS;

    }
    public DataSet SP_GET_COMPANYNAME(string P_USR_ID)
    {
        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("P_USR_ID", OracleType.VarChar, ParameterDirection.Input, P_USR_ID);
        PR[1] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_GET_COMPANYNAME", PR);
        return DS;

    }
    public DataSet LOV_USERS_ALL(String P_USER_CODE, String P_USR_NAME, String P_REAL_NAME)
    {
        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[4];
        PR[0] = DataTransform.Oracle_Param("P_USER_CODE", OracleType.VarChar, ParameterDirection.Input, P_USER_CODE);
        PR[1] = DataTransform.Oracle_Param("P_USR_NAME", OracleType.VarChar, ParameterDirection.Input, P_USR_NAME);
        PR[2] = DataTransform.Oracle_Param("P_REAL_NAME", OracleType.VarChar, ParameterDirection.Input, P_REAL_NAME);
        PR[3] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_USERS_LOV", PR);
        return DS;
    }
    public DataSet LOV_FileName(string p_company_code)
    {
        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[3];
        PR[0] = DataTransform.Oracle_Param("p_company_code", OracleType.VarChar, ParameterDirection.Input, p_company_code);
        PR[1] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        PR[2] = DataTransform.Oracle_Param("v_retval", OracleType.VarChar, ParameterDirection.Input, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_Data_Segregation_LOV", PR);
        return DS;
    }
    public DataSet getfilename(String P_FILE_NAME)
    {
        DataSet DS = new DataSet();
        //MCBReportClass RptObj = new MCBReportClass();
        OracleParameter[] PR = new OracleParameter[2];

        PR[0] = DataTransform.Oracle_Param("P_FILE_NAME", OracleType.VarChar, ParameterDirection.Input, P_FILE_NAME);
        PR[1] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");


        DS = DataTransform.Oracle_GetDataSetSP("sp_filename_who", PR);
        return DS;


    }
    public DataSet LOV_REMITTERName(string FILENAME)
    {
        DataSet DS = new DataSet();
        //MCBReportClass RptObj = new MCBReportClass();
        OracleParameter[] PR = new OracleParameter[2];

        PR[0] = DataTransform.Oracle_Param("P_FILE_NAME", OracleType.VarChar, ParameterDirection.Input, FILENAME);
        PR[1] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");


        DS = DataTransform.Oracle_GetDataSetSP("sp_REMETTERNAME_LOV", PR);
        return DS;

    }
    public DataSet LOV_BENEADDRESS(string FILENAME)
    {
        DataSet DS = new DataSet();
        //MCBReportClass RptObj = new MCBReportClass();
        OracleParameter[] PR = new OracleParameter[2];

        PR[0] = DataTransform.Oracle_Param("P_FILE_NAME", OracleType.VarChar, ParameterDirection.Input, FILENAME);
        PR[1] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");


        DS = DataTransform.Oracle_GetDataSetSP("sp_BENEADDRESS_LOV", PR);
        return DS;

    }
    public DataSet GET_ALLCompanyName()
    {
        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[1];
        PR[0] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("GetCompanyName", PR);

        return DS;
    }

    public DataSet Get_SPDS_ProductMaster_AMatrix(string CustID)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_SPDS_ProductMaster_LOV '" + ProductCode + "','" + ProductName + "'", "GET_ALL_USER");
        //return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("p_cust_code", OracleType.VarChar, ParameterDirection.Input, CustID);
        PR[1] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("GET_PRODUCT_BYCUST", PR);
        return DS;
    }
    public DataSet Get_AuthorizationMatrix(string CompanyCode, string ProductCode, string Mode)
    {
        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[4];
        PR[0] = DataTransform.Oracle_Param("p_CompanyCode", OracleType.VarChar, ParameterDirection.Input, CompanyCode);
        PR[1] = DataTransform.Oracle_Param("p_ProductCode", OracleType.VarChar, ParameterDirection.Input, ProductCode);
        PR[2] = DataTransform.Oracle_Param("p_Mode", OracleType.VarChar, ParameterDirection.Input, Mode);
        PR[3] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("Get_authorizationmatrix", PR);
        return DS;
    }
    public DataSet Get_Company_CodebyUser(string P_User_CODE)
    {
        OracleParameter[] PR = new OracleParameter[2];
        PR[0] = DataTransform.Oracle_Param("P_User_CODE", OracleType.VarChar, ParameterDirection.Input, P_User_CODE);
        PR[1] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("get_company_codebyuser", PR);
        return DS;
    }
    public DataSet Get_SPDS_SignatorySetup_ALL(string ID, string SIGNATORY_NAME, string USR_NAME)
    {
        //DataSet DS = new DataSet();
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_SPDS_SignatorySetup_ALL '" + ID + "','" + SIGNATORY_NAME + "'", "GET_ALL_USER");
        //return DS;

        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[4];
        PR[0] = DataTransform.Oracle_Param("v_ID", OracleType.VarChar, ParameterDirection.Input, ID);
        PR[1] = DataTransform.Oracle_Param("v_SIGNATORY_NAME", OracleType.VarChar, ParameterDirection.Input, SIGNATORY_NAME);
        PR[2] = DataTransform.Oracle_Param("v_USR_NAME", OracleType.VarChar, ParameterDirection.Input, USR_NAME);
        PR[3] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("SP_SPDS_SignatorySetup_ALL", PR);
        return DS;
    }

    //public DataSet LOV_Company_USERS(string USER_CODE)
    //{
    //    DataSet DS = new DataSet();
    //    OracleParameter[] PR = new OracleParameter[2];
    //    PR[0] = DataTransform.Oracle_Param("P_USR_NAME", OracleType.VarChar, ParameterDirection.Input, USER_CODE);
    //    PR[1] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
    //    DS = DataTransform.Oracle_GetDataSetSP("Get_SP_CompUser_LOV", PR);
    //    return DS;
    //}
    public DataSet LOV_Company_USERS(string USER_CODE, string P_USER_SEARCH)
    {
        DataSet DS = new DataSet();
        OracleParameter[] PR = new OracleParameter[3];
        PR[0] = DataTransform.Oracle_Param("P_USR_NAME", OracleType.VarChar, ParameterDirection.Input, USER_CODE);
        PR[1] = DataTransform.Oracle_Param("P_USER_SEARCH", OracleType.VarChar, ParameterDirection.Input, P_USER_SEARCH);
        PR[2] = DataTransform.Oracle_Param("DATA_RESULTSET", OracleType.Cursor, ParameterDirection.Output, "");
        DS = DataTransform.Oracle_GetDataSetSP("Get_SP_CompUser_LOV", PR);
        return DS;
    }
    //<ibrahim> 12-02-2014
    public string InsertApplicationError(string vERRPAGENAME, string vERRMESSAGE, string vERRMETHOD, string vERRSTACKTRACE, string vERRONUSER)
    {
        string sreturn = "1";
        OracleParameter[] parms = new OracleParameter[5];
        parms[0] = DataTransform.Oracle_Param("vERRPAGENAME", OracleType.VarChar, ParameterDirection.Input, vERRPAGENAME);
        parms[1] = DataTransform.Oracle_Param("vERRMESSAGE", OracleType.VarChar, ParameterDirection.Input, vERRMESSAGE);
        parms[2] = DataTransform.Oracle_Param("vERRMETHOD", OracleType.VarChar, ParameterDirection.Input, vERRMETHOD);
        parms[3] = DataTransform.Oracle_Param("vERRSTACKTRACE", OracleType.VarChar, ParameterDirection.Input, vERRSTACKTRACE);
        parms[4] = DataTransform.Oracle_Param("vERRONUSER", OracleType.VarChar, ParameterDirection.Input, vERRONUSER);
        DataTransform.Oracle_GetDataSetSP_DML("SP_APPLICATION_ERROR", parms);
        return sreturn;
    }
}

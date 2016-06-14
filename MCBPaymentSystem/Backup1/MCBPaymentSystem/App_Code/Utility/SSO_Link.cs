using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

public class SSO_Link
{
	public SSO_Link()
	{
	
	}
}

public class Internal_DatabaseConnection_Util1
{
    private readonly string ConnectionString = Startup_Util.SSO_DB.ToString();
    private SqlConnection DBConnection;

    public Internal_DatabaseConnection_Util1()
    { ConnectionMaker(); }

    private void ConnectionMaker()
    {
        DBConnection = new SqlConnection(ConnectionString);
        DBConnection.Open();
    }

    public DataSet ReteriveDataMultiple(string QRY, string SN_Name)
    {
        try
        {
            SqlDataAdapter DATA_ADAPTER;
            DataSet DATA_DATASET;
            DATA_ADAPTER = new SqlDataAdapter(QRY, DBConnection);
            DATA_DATASET = new DataSet(SN_Name);
            DATA_ADAPTER.Fill(DATA_DATASET);
            DBConnection.Close();
            return DATA_DATASET;
        }

        catch (Exception ex)
        {
            DBConnection.Close();
            throw new Exception("Data Base Error: " + ex.Message); //+ " x " + QRY.ToString());
        }
    }
}

public class Internal_LOV_COLLECTION1
{
    Internal_DatabaseConnection_Util1 DataTransform = new Internal_DatabaseConnection_Util1();
    /*
    public DataSet Get_USER_ROLE_DETAIL_ALL(string USER_CODE)
    {
        DataSet DS = new DataSet();
        DS = DataTransform.ReteriveDataMultiple("EXEC SP_USER_ROLE_DETAIL_ALL " + USER_CODE, "GET_ALL_USER");
        return DS;
    }

    public DataSet ListProject()
    {
        DataSet DS = new DataSet();
        DS = DataTransform.ReteriveDataMultiple("SELECT PROJECT_ID, PROJECT_NAME + '(' +  PROJECT_TITLE +  ')'  FROM PROJECT_SETUP ", "Files");
        return DS;
    }

    public DataSet ListForm(string PROJECT_ID, string ROLE)
    {
        DataSet DS = new DataSet();
        DS = DataTransform.ReteriveDataMultiple("EXEC SP_GET_FORMS " + PROJECT_ID + ",'" + ROLE + "'", "Files");
        return DS;
    }

    public DataSet Get_USER_ROLE_DETAIL_RGS(string ROLE_CODE, String MENU_NAME)
    {
        DataSet DS = new DataSet();
        DS = DataTransform.ReteriveDataMultiple("EXEC SP_USER_ROLE_ADMIN_RIGHT " + ROLE_CODE + ",'" + MENU_NAME + "'", "GET_ALL_USER");
        return DS;
    }

    public DataSet GET_RIGHTS(string MID, string RID)
    {
        DataSet DS = new DataSet();
        DS = DataTransform.ReteriveDataMultiple("EXEC SP_GET_RIGHTS " + MID + "," + RID, "Files");
        return DS;
    }

    public DataSet SP_NODE_SPC(String PC_ID, String NODE_ID)
    {
        DataSet DS = new DataSet();
        DS = DataTransform.ReteriveDataMultiple("SELECT * FROM NODE_SETUP WHERE PC_ID=" + PC_ID + " AND P_NODE_ID=" + NODE_ID, "GET_ALL_USER");
        return DS;
    }

    public DataSet SP_FORM_ENC(String NID, string Role_ID)
    {
        DataSet DS = new DataSet();
        DS = DataTransform.ReteriveDataMultiple("EXEC SP_FORM_ENC " + NID + ",'" + Role_ID + "'", "GET_ALL_USER");
        return DS;
    }
    */
    
    public DataSet SP_LOGIN_STATUS(String P_UID, String P_STATUS)
    {
        DataSet DS = new DataSet();
        DS = DataTransform.ReteriveDataMultiple("EXEC SP_LOGIN_STATUS '" + P_UID + "','" + P_STATUS + "'", "GET_ALL_USER");
        return DS;
    }

}

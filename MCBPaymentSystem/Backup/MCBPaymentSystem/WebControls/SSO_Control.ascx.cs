using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Data.SqlClient;
using System.Data.OracleClient;


public partial class MasterPage_SSO_Control : System.Web.UI.UserControl
{   
    Internal_LOV_COLLECTION lov;
    Internal_LOV_COLLECTION NL;
    Internal_LOV_COLLECTION LOV;
    
    private string LOG_ROLE = "";
    private string LOG_CODE = "";
    public string PAGE_NAME = "";
    
    protected void Page_Load(object sender, EventArgs e)
    {
        //Internal_DatabaseConnection_Util DataTransform = new Internal_DatabaseConnection_Util();
    }

    public void GearUp(string Get_LOG_ROLE, string Get_LOG_CODE)
    {
        lov = new Internal_LOV_COLLECTION();
        NL = new Internal_LOV_COLLECTION();
        LOV = new Internal_LOV_COLLECTION();
        LOG_ROLE = Get_LOG_ROLE;
        LOG_CODE = Get_LOG_CODE;
        //Session["SSO_DB"].ToString();
        Session["LOG_ROLE"] = Get_LOG_ROLE.ToString();
        if (IsPostBack == false)
        {
            TreeNode TN1 = new TreeNode("Main Menu");
            TN1.Value = "";
            StartUp(TN1);
            TV1.Nodes.Add(Administration(TN1));
        }
    }


    public int LoginStatus(string UID)
    {
        Internal_LOV_COLLECTION L = new Internal_LOV_COLLECTION();        
        if (L.SP_IsLogin(UID).Tables[0].Rows[0][0].ToString() == "LOG-OUT")
        { return 0; }
        else
        { return 1; }
    }

    private TreeNode Administration(TreeNode TN)
    {
        TreeNode TN1 = new TreeNode("Administration");
        TN1.Value = "";

        DataSet DS = new DataSet();
        DS = lov.Get_USER_ROLE_DETAIL_ALL(LOG_ROLE);

        /*
        TreeNode TN_CHILD501 = new TreeNode("Back to Administration");
        TN_CHILD501.Value = "1";
        TN1.ChildNodes.Add(TN_CHILD501);
        */
        TreeNode TN_CHILD500 = new TreeNode("Log out");
        TN_CHILD500.Value = "1";
        TN1.ChildNodes.Add(TN_CHILD500);
        TN.ChildNodes.Add(TN1);
        return TN;
        
    }

    private void StartUp(TreeNode TN1)
    {
        DataSet DS = new DataSet();
        DS = lov.ListProject();
        for (int A = 0; A <= DS.Tables[0].Rows.Count - 1; A++)
        {            
            TreeNode PROJECTS = new TreeNode();
            PROJECTS.Text = DS.Tables[0].Rows[A][1].ToString();
            PROJECTS.Value = "";
            StartUP1("0", PROJECTS, DS.Tables[0].Rows[A][0].ToString());
            TN1.ChildNodes.Add(PROJECTS);
        }

    }
    
    private void StartUP1(String NID, TreeNode TN0, String Project_ID)
    {
        DataSet DS = new DataSet();
        DS = NL.SP_NODE_SPC(Project_ID, NID.ToString());
        for (int A = 0; A <= DS.Tables[0].Rows.Count - 1; A++)
        {
            TreeNode TR1 = new TreeNode(DS.Tables[0].Rows[A][3].ToString());
            TR1.Value = ""; 
            FormEnclosure(DS.Tables[0].Rows[A][1].ToString(), TR1);
            StartUP1(DS.Tables[0].Rows[A][1].ToString(), TR1, Project_ID);
            if (TR1.ChildNodes.Count > 0)
            { TN0.ChildNodes.Add(TR1); }
        }
    }
    
    private void FormEnclosure(String NID, TreeNode TR1)
    {
        DataSet DS = new DataSet();
        
        DS = NL.SP_FORM_ENC(NID, LOG_ROLE);
        
        for (int A = 0; A <= DS.Tables[0].Rows.Count - 1; A++)
        {
            TreeNode TR2 = new TreeNode(DS.Tables[0].Rows[A][3].ToString());
            //TR2.Value = DS.Tables[0].Rows[A][4].ToString() + "~" +  DS.Tables[0].Rows[A][5].ToString();
            TR2.Value = DS.Tables[0].Rows[A][4].ToString() + "~" +  DS.Tables[0].Rows[A][6].ToString();
            TR1.ChildNodes.Add(TR2);
        }
    }

    private void Child(string PROJECT_ID, TreeNode PROJECTS)
    {           
        DataSet DS = new DataSet();
        DS = lov.ListForm(PROJECT_ID, LOG_ROLE);
        for (int A = 0; A <= DS.Tables[0].Rows.Count - 1; A++)
        {
            TreeNode FORMS = new TreeNode();
            FORMS.Text = DS.Tables[0].Rows[A][1].ToString();
            FORMS.Value = DS.Tables[0].Rows[A][2].ToString();            
            PROJECTS.ChildNodes.Add(FORMS);
        }
    }
    
    public delegate void EventHandler(Object obj, EventArgs e);
    public event EventHandler CK;    
    
    protected void CK_IN()
    {
        if (CK != null)
        {CK(this, new EventArgs());}
    }

    

    protected void TV1_SelectedNodeChanged(object sender, EventArgs e)    
    {   
        if (TV1.SelectedNode.Value.ToString()=="1")
        {
            Internal_LOV_COLLECTION L = new Internal_LOV_COLLECTION();
            //L.SP_LOGIN_STATUS(LOG_CODE, "LOG-OUT");
            Session["CompleteInformation"] = "";
            //Response.Redirect("http://SW-ALI/Framework_Client/MasterPage/SystemLogin.aspx");
            Response.Redirect(Session["EXP_PAGE"].ToString());
        }
        else
        {            
            string RG_ENC = "";
            string s1 = "";
            string[] ARY;
            
            s1 = TV1.SelectedNode.Value.ToString();
            ARY=s1.Split('~');
            if (ARY.Length <= 1)
            {}
            else
            {
             //PAGE_NAME = ARY[1].ToString() + "-" + Session["LOG_ROLE"].ToString();
             //ARY[1] = lov.GET_RIGHTS(ARY[1].ToString(), LOG_ROLE).Tables[0].Rows[0][0].ToString();              

             ARY[1] = lov.GET_RIGHTS(ARY[1].ToString(), Session["LOG_ROLE"].ToString()).Tables[0].Rows[0][0].ToString();
             Int64 AB = Convert.ToInt64(DateTime.Now.Ticks.ToString()) + 300000000;
             RG_ENC=Startup_Util.EncryptPWD(RG_ENC= ARY[1] + "~" + AB.ToString());
             PAGE_NAME = ARY[0].ToString() + "?s1=" + RG_ENC.ToString();             
             LOV.SP_AUDIT_LOG_INSERT(Session["LOG_CODE"].ToString(), TV1.SelectedNode.Text, Startup_Util.UserPC, Startup_Util.UserIP, Startup_Util.UserMac);
             CK_IN();                                         
            }
        }
    }
}

public class Internal_DatabaseConnection_Util
{
    //private readonly string ConnectionString = Startup_Util.SSO_DB.ToString();

    public string ConnectionString = "Data Source=orcl;Persist Security Info=True;User ID=dbo_samba_spds_pre;Password=dbo_samba_spds_pre;Unicode=True";

   
    public OracleConnection DBConnection;

    public Internal_DatabaseConnection_Util()
    {
        //ConnectionString = Startup_Util.SSO_DB;        
        ConnectionMaker(); 
        ConnectionString = ConnectionString;
    }

    private void ConnectionMaker()
    {
        DBConnection = new OracleConnection(ConnectionString);
        DBConnection.Open();
    }
    
    public DataSet ReteriveDataMultiple(string QRY, string SN_Name)
     {
        try
        {
            
            OracleDataAdapter DATA_ADAPTER;
            DataSet DATA_DATASET;
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = DBConnection;
            //cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = QRY;
            DATA_ADAPTER = new OracleDataAdapter(QRY, DBConnection);
          //  DATA_ADAPTER = new OracleDataAdapter(QRY, DBConnection);
            DATA_ADAPTER = new OracleDataAdapter();
            DATA_ADAPTER.SelectCommand = cmd;
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

public class Internal_LOV_COLLECTION
{
    Internal_DatabaseConnection_Util DataTransform = new Internal_DatabaseConnection_Util();

    public DataSet Get_USER_ROLE_DETAIL_ALL(string USER_CODE)
    {
        DataSet DS = new DataSet();
        string SqlQueryRollDetail = " SELECT RD_ID,MENU_NAME,DECODE(INSERT_ALLOWED, '0', 'False', 'True') INSERT_ALLOWED,DECODE(DELETE_ALLOWED, '0', 'False', 'True') DELETE_ALLOWED,DECODE(UPDATE_ALLOWED, '0', 'False', 'True') UPDATE_ALLOWED, DECODE(QUERY_ALLOWED, '0', 'False', 'True') QUERY_ALLOWED,DECODE(AUTH_ALLOWED, '0', 'False', 'True') AUTH_ALLOWED FROM USER_ROLE_DETAIL WHERE ROLE_CODE =" + USER_CODE ;
        
        
        //DS = DataTransform.ReteriveDataMultiple("EXEC SP_USER_ROLE_DETAIL_ALL " + USER_CODE, "GET_ALL_USER");

        DS = DataTransform.ReteriveDataMultiple(SqlQueryRollDetail, "GET_ALL_USER");


        return DS;
    }

    public DataSet ListProject()
    {
        DataSet DS = new DataSet();
        DS = DataTransform.ReteriveDataMultiple("SELECT PROJECT_ID, PROJECT_NAME || '(' ||  PROJECT_TITLE ||  ')'  FROM PROJECT_SETUP ", "Files");
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
       // DS = DataTransform.ReteriveDataMultiple("EXEC SP_GET_RIGHTS " + MID + "," + RID, "Files");
        string SQLGETRIGHT = "SELECT INSERT_ALLOWED || DELETE_ALLOWED || UPDATE_ALLOWED || QUERY_ALLOWED || AUTH_ALLOWED  FROM ROLE_DETAIL WHERE MENU_CODE ='" + MID + "'  AND ROLE_CODE ='" +  RID + "'";

        DS = DataTransform.ReteriveDataMultiple(SQLGETRIGHT, "Files");

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
        string SqlQuery = "SELECT FL.FID,FL.PC_ID,FL.NID,FS.FORM_TITLE,'http://' || PS.MACHINE || '/' || PS.PROJECT_SITE_NAME ||FS.FULL_PATH || '/' || FS.FORM_NAME Site,''  RG,RD.MENU_CODE FROM FORM_LINK FL, FORM_SETUP FS, ROLE_DETAIL RD, PROJECT_SETUP PS WHERE FL.NID =" + NID + " AND FS.FORM_ID = FL.FID AND RD.MENU_CODE = FL.FID AND RD.ROLE_CODE = '" + Role_ID + "' AND RD.APP_CODE = PS.PROJECT_ID AND   RD.QUERY_ALLOWED = 1 ORDER BY FS.FORM_TITLE";

        

        DS = DataTransform.ReteriveDataMultiple(SqlQuery,"GET_ALL_USER");
        return DS;
    }

    public DataSet SP_LOGIN_STATUS(String P_UID, String P_STATUS)
    {
        DataSet DS = new DataSet();
        DS = DataTransform.ReteriveDataMultiple("EXEC SP_LOGIN_STATUS '" + P_UID + "','" + P_STATUS + "'", "GET_ALL_USER");
        return DS;
    }



    public DataSet SP_IsLogin(String P_UID)
    {
        DataSet DS = new DataSet();
        DS = DataTransform.ReteriveDataMultiple("SELECT STATUS FROM USERS WHERE USER_CODE=" + P_UID.ToString(), "GET_ALL_USER");
        return DS;
    }

    public DataSet SP_AUDIT_LOG_INSERT(string UID, string OBJECT, string PC_NAME, string IP, string MAC_ADDRESS)
    {
        DataSet DS = new DataSet();

        string SQLAUDIT_LOG_INSERT="INSERT INTO AUDIT_LOG ( USER_ID,ObjectName, PC_NAME, IP, MAC_ADDRESS ) VALUES (" + UID + " ,'" + OBJECT + "', '" + PC_NAME + "','" + IP + "','" + MAC_ADDRESS + "')" ;


        DS = DataTransform.ReteriveDataMultiple(SQLAUDIT_LOG_INSERT,"GET_ALL_USER");


       // DS = DataTransform.ReteriveDataMultiple("EXEC SP_AUDIT_LOG_INSERT " + UID + " ,'" + OBJECT + "','" + PC_NAME + "','" + IP + "','" + MAC_ADDRESS + "'", "GET_ALL_USER");
        return DS;
    }


}





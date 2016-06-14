<%@ WebHandler Language="C#" Class="ShowImage" %>

using System;
using System.Configuration;
using System.Web;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Data.OracleClient;

public class ShowImage : IHttpHandler 
{
    DatabaseConnection_Util DataTransform = new DatabaseConnection_Util();
    public void ProcessRequest(HttpContext context)
    {
        Int32 empno;
        if (context.Request.QueryString["id"] != null)
            empno = Convert.ToInt32(context.Request.QueryString["id"]);
        else
            throw new ArgumentException("No parameter specified");

        context.Response.ContentType = "image/jpeg";
        Stream strm = ShowEmpImage(empno);
        byte[] buffer = new byte[4096];
        int byteSeq=0; 
        if (strm != null)
        {
            byteSeq = strm.Read(buffer, 0, 4096);    
        }
        

        while (byteSeq > 0)
        {
            context.Response.OutputStream.Write(buffer, 0, byteSeq);
            byteSeq = strm.Read(buffer, 0, 4096);
        }
        //context.Response.BinaryWrite(buffer);
    }


    public Stream ShowEmpImage(int empno)
    {
        DataSet ds = new DataSet();
        string conn = DAL_EXP1.Utility.Startup_Util.DB_Route; //ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;            
        OracleConnection connection = new OracleConnection(conn);
        OracleCommand cmd = new OracleCommand();
        cmd.Parameters.Clear();
        cmd.Connection = connection;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "rps_sp_signatory_imgupload";
        OracleParameter[] parm = new OracleParameter[2];
        parm[0] = new OracleParameter("v_id", OracleType.VarChar, 2000);
        parm[0].Value = empno;

        parm[1] = new OracleParameter("DATA_RESULTSET", OracleType.Cursor, 2000);
        parm[1].Direction = ParameterDirection.Output;
        foreach (OracleParameter var in parm)
        {
            cmd.Parameters.Add(var);
        }
        cmd.Connection.Open();
        
        try
        {
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            da.Fill(ds);
            connection.Close();
            object img = "";
            if (ds.Tables[0].Rows.Count > 0)
            {
                img = ds.Tables[0].Rows[0][0];
            }
            return new MemoryStream((byte[])img);
        }
        catch
        {
            return null;
            
        }
        finally
        {
            connection.Close();
        }
        
    }


    public bool IsReusable
    {
        get
        {
            return false;
        }
    }



}
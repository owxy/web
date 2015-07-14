using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.OleDb;

public class DBHelper
{
    // public static string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["access"].ConnectionString;
    public static string connStr = System.Configuration.ConfigurationSettings.AppSettings["CONN"].ToString();

    public DBHelper()
    {
        //
        // TODO: �ڴ˴���ӹ��캯���߼�
        //
    }

    public DataSet GetDataSet(string sql)
    {
        OleDbConnection conn = new OleDbConnection(connStr);
        OleDbDataAdapter da = new OleDbDataAdapter(sql, conn);
        DataSet ds = new DataSet();
        da.Fill(ds);
        return ds;
    }

    public bool ExecSql(string sql)
    {
        bool IsSucceed = false;
        OleDbConnection conn = new OleDbConnection(connStr);
        conn.Open();
        OleDbCommand cmd = new OleDbCommand(sql, conn);
        try
        {
            cmd.ExecuteNonQuery();
            conn.Close();
            IsSucceed = true;
        }
        catch (Exception e)
        {
            throw e;
        }
        return IsSucceed;
    }

    public OleDbDataReader GetReader(string sqlStr)
    {
        OleDbDataReader dr = null;
        OleDbConnection conn = new OleDbConnection(connStr);
        OleDbCommand cmd = new OleDbCommand(sqlStr, conn);
        conn.Open();
        try
        {
            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }
        catch
        {
            conn.Close();
        }
        return dr;
    }

    public int GetExexScalar(string sqlStr)
    {
        int ret = 0;
        OleDbConnection conn = new OleDbConnection(connStr);
        OleDbCommand cmd = new OleDbCommand(sqlStr, conn);
        conn.Open();
        try
        {
            ret = (int)cmd.ExecuteScalar();
        }
        finally
        {
            conn.Close();
        }
        return ret;
    }

    public string GetExexScalarString(string sqlStr)
    {
        string ret = "";
        OleDbConnection conn = new OleDbConnection(connStr);
        OleDbCommand cmd = new OleDbCommand(sqlStr, conn);
        conn.Open();
        try
        {
            ret = (string)cmd.ExecuteScalar();
        }
        finally
        {
            conn.Close();
        }
        return ret;
    }
}

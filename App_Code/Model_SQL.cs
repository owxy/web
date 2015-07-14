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
using System.Net.Mail;

/// <summary>
/// Summary description for Model_SQL
/// </summary>
namespace WebTCF_SQL
{
    public class Model_SQL
    {
        public Model_SQL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #region can modify Para
       
        public static string SQL_Conn_String = System.Configuration.ConfigurationSettings.AppSettings["CONN"].ToString();
        public static string SQL_Login_String = System.Configuration.ConfigurationSettings.AppSettings["connectionStr"].ToString();
        public static int SQL_dataGrid_PageSize = Convert.ToInt32(ConfigurationManager.AppSettings["pageSize"]);
        public static int SQL_dataGrid_INSPageSize = Convert.ToInt32(ConfigurationManager.AppSettings["INSpageSize"]);
        public static string Email_Host = System.Configuration.ConfigurationSettings.AppSettings["EmailHost"];
        public static string Email_From = System.Configuration.ConfigurationSettings.AppSettings["EmailFrom"];
        public static string Email_password = System.Configuration.ConfigurationSettings.AppSettings["EmailPassword"];
        public static string Email_TO = System.Configuration.ConfigurationSettings.AppSettings["EmailTo"];
        public static string Email_CC = System.Configuration.ConfigurationSettings.AppSettings["EmailCC"];
   



        private static string SQL_Proc_LoginUser = "ProcTCFLoginUser";
   
        private static string GetSupplierName_SQL = "SELECT Factory.FactoryName  FROM  Factory  WHERE Factory.FactoryID =@SupGroupID";
          /// <summary>
        /// end

        #endregion

        public static SqlConnection GetConn()
        {
            SqlConnection myConn = new SqlConnection(SQL_Conn_String);
            return myConn;
        }

        public static SqlDataAdapter GetDa(string strTableSql)
        {
            SqlDataAdapter mySqlAdapter = new SqlDataAdapter(strTableSql, GetConn());
            return mySqlAdapter;
        }

        public static SqlDataReader GetDr(string strTableSql)
        {
            SqlCommand cmd = new SqlCommand(strTableSql, GetConn());
            cmd.CommandTimeout = 180;
            GetConn().Open();
            SqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }
        public static DataSet GetDataSet(string strSQL)
        {
            using (SqlConnection myConn = new SqlConnection(SQL_Conn_String))
            {
                SqlDataAdapter mySqlAdapter = new SqlDataAdapter(strSQL, myConn);
                DataSet myDs = new DataSet();
                mySqlAdapter.Fill(myDs);
                return myDs;
            }
        }

             public static DataSet GetProcLoginUser(string strGroupID)
        {
            using (SqlConnection myConn = new SqlConnection(SQL_Conn_String))
            {
                SqlDataAdapter mySqlAdapter = new SqlDataAdapter();

                SqlCommand mySelectCommand = new SqlCommand();
                mySelectCommand.CommandTimeout = 180;
                mySelectCommand.Connection = myConn;
                mySelectCommand.CommandText = SQL_Proc_LoginUser;
                mySelectCommand.CommandType = CommandType.StoredProcedure;
                mySelectCommand.Parameters.Add(new SqlParameter("@GroupID", SqlDbType.NVarChar));
                mySelectCommand.Parameters["@GroupID"].Value = strGroupID;

                DataSet myDs = new DataSet();
                mySqlAdapter.SelectCommand = mySelectCommand;
                mySqlAdapter.Fill(myDs);

                return myDs;
            }
        }
    

        public static DataSet GetSuppliersName(string GroupID)
        {
            using (SqlConnection myconn = new SqlConnection(SQL_Login_String))
            {
                SqlCommand cmd = new SqlCommand(GetSupplierName_SQL, myconn);
                cmd.CommandTimeout = 180;
                cmd.Parameters.Add(new SqlParameter("@SupGroupID", SqlDbType.NVarChar));
                cmd.Parameters["@SupGroupID"].Value = GroupID;
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                DataSet myds = new DataSet();
                da.Fill(myds);
                return myds;
            }
        }
      
     
        ///end

    }
}


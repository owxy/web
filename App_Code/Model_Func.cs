using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using WebTCF_SQL;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Model_Func
/// </summary>
namespace WebTCF_Func
{
    public class Model_Func
    {
        public Model_Func()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public static int Asc(string character)
        {
            if (character.Length == 1)
            {
                System.Text.ASCIIEncoding asciiEncoding = new System.Text.ASCIIEncoding();
                int intAsciiCode = (int)asciiEncoding.GetBytes(character)[0];
                return (intAsciiCode);
            }
            else
            {
                throw new Exception("Character is not valid.");
            }

        }
        public static string Chr(int asciiCode)
        {
            if (asciiCode >= 0 && asciiCode <= 255)
            {
                System.Text.ASCIIEncoding asciiEncoding = new System.Text.ASCIIEncoding();
                byte[] byteArray = new byte[] { (byte)asciiCode };
                string strCharacter = asciiEncoding.GetString(byteArray);
                return (strCharacter);
            }
            else
            {
                throw new Exception("ASCII Code is not valid.");
            }
        }


        public static string DCrypt(string strInput, int intParamer)
        {
            int intTmp, strLen;
            string strReturn;
            strReturn = "";
            strLen = strInput.Length;
            for (int i = 0; i < (strLen); i++)
            {
                intTmp = Asc(strInput.Substring(i, 1));
                intTmp = (intTmp ^ intParamer);
                strReturn = strReturn + Chr(intTmp);
            }
            return strReturn;

        }

        public static string ReplaceProductID(string strB)
        {
            string strA = "";
            strA = strB;
            strA.Replace("*", "-");
            strA.Replace("+", "-");
            strA.Replace("|", "-");
            strA.Replace("/", "-");
            strA.Replace("\\", "-");
            strA.Replace("#", "-");
            strA.Replace(".", "-");
            strA.Replace(",", "-");
            strA.Replace(":", "-");
            strA.Replace("?", "-");
            strA.Replace("'", "-");
            strA.Replace("\"", "-");
            strA.Replace("<", "-");
            strA.Replace(">", "-");
            return strA;
        }


        public static void Login(string userid, string pwd,string ip, int right, out string strDeptID, out string strGroupID, out int intResult, out int intLevel, out int intBrowselevel, out int intDownload, out int intUpload, out int intIsgroup, out string usertype)
        {
            using (SqlConnection myConn = new SqlConnection(Model_SQL.SQL_Login_String))
            {
                //	int intResult;
                //	int intLevel;
                //	string strDeptID;
                //	string strGroupID;
                myConn.Open();
                SqlCommand mySelectCommand = new SqlCommand();
                mySelectCommand.Connection = myConn;
                mySelectCommand.CommandText = "Proc_Web_TCF_Login5";
                mySelectCommand.CommandType = CommandType.StoredProcedure;
                mySelectCommand.Parameters.Clear();

                mySelectCommand.Parameters.Add(new SqlParameter("@UserID", SqlDbType.VarChar));
                mySelectCommand.Parameters.Add(new SqlParameter("@Password", SqlDbType.VarChar));
                mySelectCommand.Parameters.Add(new SqlParameter("@ip", SqlDbType.VarChar));
                mySelectCommand.Parameters.Add(new SqlParameter("@right", SqlDbType.Int));
                mySelectCommand.Parameters["@UserID"].Value = userid;
                mySelectCommand.Parameters["@Password"].Value = pwd;
                mySelectCommand.Parameters["@ip"].Value = ip;
                mySelectCommand.Parameters["@right"].Value = right;

                mySelectCommand.Parameters.Add(new SqlParameter("@Result", SqlDbType.Int));
                mySelectCommand.Parameters["@Result"].Direction = ParameterDirection.Output;
                mySelectCommand.Parameters.Add(new SqlParameter("@LeveL", SqlDbType.Int));
                mySelectCommand.Parameters["@LeveL"].Direction = ParameterDirection.Output;
                mySelectCommand.Parameters.Add(new SqlParameter("@DeptID", SqlDbType.VarChar, 50));
                mySelectCommand.Parameters["@DeptID"].Direction = ParameterDirection.Output;
                mySelectCommand.Parameters.Add(new SqlParameter("@GroupID", SqlDbType.VarChar, 50));
                mySelectCommand.Parameters["@GroupID"].Direction = ParameterDirection.Output;
                mySelectCommand.Parameters.Add(new SqlParameter("@browse_level", SqlDbType.Int));
                mySelectCommand.Parameters["@browse_level"].Direction = ParameterDirection.Output;
                mySelectCommand.Parameters.Add(new SqlParameter("@download", SqlDbType.Int));
                mySelectCommand.Parameters["@download"].Direction = ParameterDirection.Output;
                mySelectCommand.Parameters.Add(new SqlParameter("@upload", SqlDbType.Int));
                mySelectCommand.Parameters["@upload"].Direction = ParameterDirection.Output;
                mySelectCommand.Parameters.Add(new SqlParameter("@isgroup", SqlDbType.Int));
                mySelectCommand.Parameters["@isgroup"].Direction = ParameterDirection.Output;
                mySelectCommand.Parameters.Add(new SqlParameter("@GroupName", SqlDbType.VarChar, 50));
                mySelectCommand.Parameters["@GroupName"].Direction = ParameterDirection.Output;
                mySelectCommand.ExecuteNonQuery();
                intResult = (int)mySelectCommand.Parameters["@Result"].Value;
                intLevel = (int)mySelectCommand.Parameters["@LeveL"].Value;
                intBrowselevel = (int)mySelectCommand.Parameters["@browse_level"].Value;
                intDownload = (int)mySelectCommand.Parameters["@download"].Value;
                intUpload = (int)mySelectCommand.Parameters["@upload"].Value;
                intIsgroup = (int)mySelectCommand.Parameters["@isgroup"].Value;
                strDeptID = (string)mySelectCommand.Parameters["@DeptID"].Value.ToString();
                strGroupID = (string)mySelectCommand.Parameters["@GroupID"].Value.ToString();
                usertype = (string)mySelectCommand.Parameters["@GroupName"].Value.ToString();


            }

        }


    }
}


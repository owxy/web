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
using WebTCF_Func;
using System.Collections;
using System.Text.RegularExpressions;

public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Request.QueryString["ParameterI"] != null)
        {
           //string username =Model_Func.DCrypt(Request.QueryString["ParameterI"], 0105);
            //string password = Model_Func.DCrypt(Request.QueryString["ParameterII"], 0105);
            string username = Request.QueryString["ParameterI"];
            string password = Request.QueryString["ParameterII"];
              string Parameters =Request.QueryString["ParameterIII"];
            if (DateTime.Now.ToString("ddMMhh") != Parameters)
            {
                           Response.Redirect("TLogon.aspx");
            }
             else
            {
                int intResult = -1;
                int intLevel = 0;
                int intBrowselevel = 0;
                int intDownload = 0;
                int intUpload = 0;
                int intIsgroup = 0;
                string strDeptID = "";
                string strGroupID = "";
                string strUser = username;
                string Usertype = "";
                string ip;
                if (Context.Request.ServerVariables["HTTP_VIA"] != null)
                {
                    ip = Context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString();
                }
                else
                {
                    ip = Context.Request.ServerVariables["REMOTE_ADDR"].ToString();
                }
                Model_Func.Login(username, password, ip,1, out strDeptID, out strGroupID, out intResult, out intLevel, out intBrowselevel, out intDownload, out intUpload,out intIsgroup , out Usertype);

                int rtn = intResult;
                string usertype = Usertype;
                if (rtn == 1 && usertype.Trim().Equals("Customer"))
                {
                    string redirectUrl = "SeleMain.aspx";
                    if (redirectUrl == "")
                        Response.Redirect("TLogon.aspx");
                    else
                    {
                        Session["username"] = username;
                        Session["password"] = password;

                        Session["strUser"] = strUser;
                        Session["intResult"] = intResult;
                        Session["strDeptID"] = strDeptID;
                        Session["strGroupID"] = strGroupID;
                        Session["intLevel"] = intLevel;
                        Session["strProductID"] = "";
                        Session["strBarcode"] = "";
                        Session["strPONo"] = "";
                        Session["strFty"] = "";
                        if ((strGroupID.ToUpper() == "AERA") || (strGroupID.Trim() == "Zentrale Handelsgesellschaft-ZHG-mbH Offenburg"))
                            Session["strStatus"] = "ALL";
                        else
                            Session["strStatus"] = "In Progress";
                        Session["strSupplierID"] = "";
                        Session["intProjectID"] = "-1";
                        Session["intDownload"] = intDownload;
                        Session["intUpload"] = intUpload;
                        Session["intIsgroup"] = intIsgroup;
                        Session["intBrowselevel"] = intBrowselevel;
                        Session["intPageTCF_Curr"] = 1;
                        Session["intPageINS_Curr"] = 1;
                        FormsAuthentication.RedirectFromLoginPage(strUser, false);
                        Response.Redirect(redirectUrl);
                    }

                }
                else if (rtn == 1 && usertype.Trim().Equals("Supplier"))
                {
                    Session["strUser"] = strUser;
                    Session["intResult"] = intResult;
                    //Session["strDeptID"] = strDeptID;       
                    Session["strGroupID"] = strGroupID;
                    Session["intLevel"] = intLevel;
                    Session["strProductID"] = "";
                    Session["strBarcode"] = "";
                    Session["strPONo"] = "";
                    Session["strFty"] = "";
                    Session["strStatus"] = "ALL";
                    Session["strCustomerID"] = "";
                    Session["intProjectID"] = "-1";          // ProjectID 
                    Session["intBrowselevel"] = intBrowselevel;  ////*
                    Session["intPage_Curr"] = 1;
                    Session["intIsgroup"] = intIsgroup;
                    Session["Facid"] = strGroupID;
                    //Response.Write("Session['strUser']:"+Session["strUser"]+"<br/>");
                    //Response.Write("Session['intResult']:"+Session["intResult"]+"<br/>");
                    //Response.Write("Session['strDeptID']:"+Session["strDeptID"]+"<br/>");
                    //Response.Write("Session['strGroupID']:" + Session["strGroupID"] + "<br/>");
                    //Response.Write("Session['intLevel']:"+Session["intLevel"]+"<br/>");
                    //Response.Write("Session['strProductID']:"+Session["strProductID"]+"<br/>");
                    //Response.Write("Session['strStatus']:"+Session["strStatus"]+"<br/>");
                    //Response.Write("Session['strCustomerID']:"+Session["strCustomerID"]+"<br/>");
                    //Response.Write("Session['intProjectID']:"+Session["intProjectID"]+"<br/>");
                    //Response.Write("Session['intBrowselevel']:" + Session["intBrowselevel"] + "<br/>");
                    //Response.Write("Session['intPage_Curr']:" + Session["intPage_Curr"] + "<br/>");
                    FormsAuthentication.RedirectFromLoginPage(strUser, false);
                    Response.Redirect("Smian.aspx");
                }
            }
        }

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        int intResult = -1;
        int intLevel = 0;
        int intBrowselevel = 0;
        int intDownload = 0;
        int intUpload = 0;
        int intIsgroup = 0;
        string strDeptID = "";
        string strGroupID = "";
        string strUser = txtAccount.Value;
        string Usertype = "";
        string ip;
        int rtn = intResult;
        string usertype = Usertype;
        string username = "";
        string password = "";

        if (Context.Request.ServerVariables["HTTP_VIA"] != null)
        {
            ip = Context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString();
        }
        else
        {
            ip = Context.Request.ServerVariables["REMOTE_ADDR"].ToString();
        }
        if (!Regex.IsMatch(txtAccount.Value, @"^[a-zA-Z0-9-_]{2,30}$"))
        {
            rtn = -10;
        }
        if (!Regex.IsMatch(txtPassword.Value, @"^[a-zA-Z0-9]{5,12}$"))
        {
            rtn = -11;
         
        }
         if (Session["CheckCode"] != null)
            {
                string checkcode = Session["CheckCode"].ToString().ToLower() ;
                if (this.checkcodetxt.Value.ToLower().Trim()   == checkcode)
                {
                    Model_Func.Login(txtAccount.Value, txtPassword.Value, ip, 1, out strDeptID, out strGroupID, out intResult, out intLevel, out intBrowselevel, out intDownload, out intUpload, out intIsgroup, out Usertype);
                    rtn = intResult;
                    usertype = Usertype;
                }
                else
                {
                        rtn = -12;
                }
            }
    

   

        string parameterIII = DateTime.Now.ToString("ddHHmm");

        if (rtn == 1 && usertype.Trim().Equals("Customer"))
        {
        //    username = Model_Func.DCrypt(txtAccount.Value, 0105);
        //    password = Model_Func.DCrypt(txtPassword.Value, 0105);
            username = txtAccount.Value;
            password = txtPassword.Value;
            parameterIII = Model_Func.DCrypt(parameterIII, 0105);
            string redirectUrl = "SeleMain.aspx";
            if (redirectUrl == "")
                Response.Redirect("TLogon.aspx");
            else
            {
                Session["username"] = username;
                Session["password"] = password;

                Session["strUser"] = strUser;
                Session["intResult"] = intResult;
                Session["strDeptID"] = strDeptID;
                Session["strGroupID"] = strGroupID;
                Session["intLevel"] = intLevel;
                Session["strProductID"] = "";
                Session["strBarcode"] = "";
                Session["strPONo"] = "";
                Session["strFty"] = "";
                if ((strGroupID.ToUpper() == "AERA") || (strGroupID.Trim() == "Zentrale Handelsgesellschaft-ZHG-mbH Offenburg"))
                    Session["strStatus"] = "ALL";
                else
                    Session["strStatus"] = "In Progress";
                Session["strSupplierID"] = "";
                Session["intProjectID"] = "-1";
                Session["intDownload"] = intDownload;
                Session["intUpload"] = intUpload;
                Session["intIsgroup"] = intIsgroup;
                Session["intBrowselevel"] = intBrowselevel;
                Session["intPageTCF_Curr"] = 1;
                Session["intPageINS_Curr"] = 1;
                FormsAuthentication.RedirectFromLoginPage(strUser, false);
                Response.Redirect(redirectUrl);
            }

        }
        else if (rtn == 1 && usertype.Trim().Equals("Supplier"))
        {
            Session["strUser"] = strUser;            //用户名
            Session["intResult"] = intResult;        //登陆成功
            //Session["strDeptID"] = strDeptID;        //部门
            Session["strGroupID"] = strGroupID;      //CustomerID   or  SupplierID
            Session["intLevel"] = intLevel;          //权限
            Session["strProductID"] = "";            //产品ID
            Session["strBarcode"] = "";
            Session["strPONo"] = "";
            Session["strFty"] = "";
            Session["strStatus"] = "In Progress";    //状态
            Session["strCustomerID"] = "";          //客户ID
            Session["intProjectID"] = "-1";          // ProjectID 
            Session["intBrowselevel"] = intBrowselevel;  ////*
            Session["intPage_Curr"] = 1;
            Session["intIsgroup"] = intIsgroup;
            Session["Facid"] = strGroupID;
            //Response.Write("Session['strUser']:"+Session["strUser"]+"<br/>");
            //Response.Write("Session['intResult']:"+Session["intResult"]+"<br/>");
            //Response.Write("Session['strDeptID']:"+Session["strDeptID"]+"<br/>");
            //Response.Write("Session['strGroupID']:"+Session["strGroupID"]+"<br/>");
            //Response.Write("Session['intLevel']:"+Session["intLevel"]+"<br/>");
            //Response.Write("Session['strProductID']:"+Session["strProductID"]+"<br/>");
            //Response.Write("Session['strStatus']:"+Session["strStatus"]+"<br/>");
            //Response.Write("Session['strCustomerID']:"+Session["strCustomerID"]+"<br/>");
            //Response.Write("Session['intProjectID']:"+Session["intProjectID"]+"<br/>");
            //Response.Write("Session['intBrowselevel']:" + Session["intBrowselevel"] + "<br/>");
            //Response.Write("Session['intPage_Curr']:" + Session["intPage_Curr"] + "<br/>");
            FormsAuthentication.RedirectFromLoginPage(strUser, false);
            Response.Redirect("Smian.aspx");
        }
        else//error
        {
            switch (rtn)
            {
                case -1://user error
                    lblMessage.Text = "Invalid Username or your password is incorrect, please retry.";
                    break;
                case -2://pwd error
                    lblMessage.Text = "Invalid Username or your password is incorrect, please retry!";
                    break;
                case -3://accounts error
                    lblMessage.Text = "The account isn't active,please contact administrator!";
                    break;
                case -4://Right error
                    lblMessage.Text = "The account isn't Right,please contact administrator!";
                    break;
                case -8:
                    lblMessage.Text = "A total of 5 times, you have up to 2 times.";
                    break;
                case -9:
                    lblMessage.Text = "Your account has been locked, please login again an hour later.";
                    break;
                case -10:
                    lblMessage.Text = "Username irregular characters";
                    break;
                case -11:
                    lblMessage.Text = "Password irregular characters";
                    break;
                case -12:
                    lblMessage.Text = "Verify code error";
                    break;
                default:
                    lblMessage.Text = "Unknown Error,please contact administrator!";
                    break;
            }
        }
    }

}

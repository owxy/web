using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using WebTCF_SQL;
using WebTCF_Func;
using System.IO;

public partial class Main : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
  //      int ii = int.Parse(Session["intPageTCF_Curr"].ToString());
  //      int jj = int.Parse(Session["intPageINS_Curr"].ToString());
        if (Session["strGroupID"] == null)
        {
            Response.Redirect("~/TLogon-test.aspx");
        }
    
    
    }


}

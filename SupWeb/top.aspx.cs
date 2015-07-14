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

public partial class Web_top : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["strGroupID"] == null)
        {
            Response.Redirect("~/TLogon.aspx", true);
        }
        if (!this.IsPostBack)
        {
            DataSet ds = Model_SQL.GetSuppliersName(Session["strGroupID"].ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                string strCompany = ds.Tables[0].Rows[0][0].ToString();
                this.lblUser.Text = "[" + strCompany + "] - " + Session["strUser"].ToString() + "  ";
            }
            else
                lblUser.Text = Session["strUser"].ToString();

        }

    }

    protected void button1_Click(object sender, EventArgs e)
    {

        Session.Clear();
        FormsAuthentication.SignOut();
        //  Response.Redirect("../TLogon.aspx");
        Response.Write("<script type='text/javascript'>window.parent.location.href='../TLogon-test.aspx';</script>");

        Response.End();

    }
}

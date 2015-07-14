using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.ComponentModel;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using WebTCF_SQL;
using WebTCF_Func;
using System.IO;

public partial class Web_Main : System.Web.UI.Page
{
    protected void Page_Load(object sender, System.EventArgs e)
    {
        /*  if (Session["Beused"] == 0)
          {
              Session.Clear();
              FormsAuthentication.SignOut();
              Response.Write("<script>parent.window.location='../Login.aspx'</script>");
          }
          */
        if (Session["intResult"] == null)
        {
            Response.Redirect("~/TLogon-test.aspx", true);
        }
        int intResult = Convert.ToInt32(Session["intResult"].ToString());
        if (intResult > 0)
        {
        }
        else
        {
            //Response.Write("<script>alert('timeout');</script>");
            Response.Write("<script> parent.top.location='TLogon-test.aspx';</script>");
        }
        // Put user code to initialize the page here

        if (!this.IsPostBack)
        {

            //	this.dataGrid1.Items[0].Cells[0].Style.Add("width","60");


        }
    }

   



    #region Web Form Designer generated code
    override protected void OnInit(EventArgs e)
    {
        //
        // CODEGEN: This call is required by the ASP.NET Web Form Designer.
        //
        InitializeComponent();
        base.OnInit(e);
    }

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        // this.button1.Click += new System.EventHandler(this.button1_Click);
        this.Load += new System.EventHandler(this.Page_Load);
    }
}
#endregion

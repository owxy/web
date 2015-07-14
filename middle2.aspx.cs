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

public partial class middle2 : System.Web.UI.Page
{
   public  string username ="";
   public  string password = "";
   public  string pe3 = DateTime.Now.ToString("ddMMhh");

    protected void Page_Load(object sender, EventArgs e)
    {
        Response.AddHeader("P3P", "CP=CAO PSA OUR");
        username = Session["username"].ToString();
        password = Session["password"].ToString();

       this.btnTCF.Attributes.Add("onclick", "this.form.target = '_parent'");
        this.btnCportal.Attributes.Add("onclick", "this.form.target = '_parent'");
  //      this.btnTCF.Attributes.Add("onclick", "this.form.target = '_blank'");
  //      this.btnCportal.Attributes.Add("onclick", "this.form.target = '_blank'");
    this.imageButton1.Attributes.Add("onclick", "this.form.target = 'leftFrame'");

 //       if (Session["strGroupID"] == null)
 //       {
 //           Response.Redirect("~/TLogon.aspx", true);
 //       }
//        this.imageButton1.Attributes.Add("onclick", "this.form.target = 'leftFrame'");
        if (!this.IsPostBack)
        {
 //         HLINS.NavigateUrl = "http://cs.api-hk.com/WebCPortal2012/Tlogon.aspx?ParameterI=" + username + "&ParameterII=" + password + "&ParameterIII=" + pe3;
//          HLTCF.NavigateUrl = "http://cs.api-hk.com/WebTCF2015/TLogon.aspx?ParameterI=" + username + "&ParameterII=" + password + "&ParameterIII=" + pe3;

           setbind();

      }
 //       setbind();

    }
    private void setbind()
    {

        //DataGrid1.DataSource =dtTable;
        //DataGrid1.DataBind ();
        string strGroupID = Session["strGroupID"].ToString();
        string strDept = Session["strDeptID"].ToString();
        int intLevel = int.Parse(Session["intLevel"].ToString());
        if (int.Parse(Session["intIsgroup"].ToString()) != 0)
        {
            this.dropDownList2.DataSource = Model_SQL.GetProcSupplierGroup(strGroupID);
            this.dropDownList2.DataValueField = "FactoryID";
            this.dropDownList2.DataTextField = "FactoryName";
            this.dropDownList2.DataBind();
            this.dropDownList2.Items.Add(new ListItem("ALL Suppliers", ""));
        }
        else
        {
            this.dropDownList2.DataSource = Model_SQL.GetProcSupplierTCFINS(strGroupID, intLevel, strDept);
            this.dropDownList2.DataValueField = "FactoryID";
            this.dropDownList2.DataTextField = "FactoryName";
            this.dropDownList2.DataBind();
            this.dropDownList2.Items.Add(new ListItem("ALL Suppliers", ""));
        }
        
        this.dropDownList3.DataSource = Model_SQL.GetProcProject(strGroupID);
        this.dropDownList3.DataValueField = "ProjectID";
        this.dropDownList3.DataTextField = "ProjectName";
        this.dropDownList3.DataBind();
        this.dropDownList3.Items.Add(new ListItem("ALL Projects", "-1"));
        this.dropDownList3.Items.FindByText("ALL Projects").Selected = true;
        this.dropDownList2.Items.FindByText("ALL Suppliers").Selected = true;
        this.dropDownList1.Items.FindByValue(Session["strStatus"].ToString()).Selected = true;
    }

    protected void imageButton1_Click(object sender, EventArgs e)
    {
        int intProjectID = int.Parse(this.dropDownList3.SelectedValue);
        string strSupplierID = this.dropDownList2.SelectedValue;
        string strStatus = this.dropDownList1.SelectedValue;
        string strProductID = this.textBox1.Text;
        string strBarcode = this.textBox2.Text;
        string strPONo = "";
        string strFty ="";
        Session["strProductID"] = strProductID;
        Session["strBarcode"] = strBarcode;
        Session["strPONo"] = strPONo;
        Session["strFty"] = strFty;
        Session["strStatus"] = strStatus;
        Session["strSupplierID"] = strSupplierID;
        Session["intProjectID"] = intProjectID;
        Session["username"] = username;
        Session["password"] = password;

        Response.Write("<script language=javascript>window.parent.frames.mainFrame.location.href='Main.aspx'</script>");
    //      Response.Write("<script language=javascript>window.parent.frames.mainFrame.location.reload();</script>");
   //     Response.Write("<script language=javascript>window.parent.mainFramemain.location.href='Main.aspx'</script>");
        //     Response.Redirect("<script language=javascript>window.parent.mainFrame.location.href='Main.aspx'</script>");
        //Response.Write("test");

    }

    protected void btnCportal_Click(object sender, EventArgs e)
    {
    //    string redirectUrl = "/WebCPortal2012/Tlogon.aspx?ParameterI=" + username + "&ParameterII=" + password + "&ParameterIII=" + pe3;
        string redirectUrl = "http://cs.api-hk.com/demo02/Tlogon.aspx?ParameterI=" + username + "&ParameterII=" + password + "&ParameterIII=" + pe3+"&P4=309";
      //  Response.Redirect(redirectUrl,true );
        Response.Redirect(redirectUrl);
        Session.Clear();
        FormsAuthentication.SignOut();
        Response.End();
        //    Response.Write("<script>window.open('"+"http://cs.api-hk.com/WebCPortal2012/Tlogon.aspx?ParameterI=" + username + "&ParameterII=" + password + "&ParameterIII=" + pe3+"','_blank')</script>");
    }
    protected void btnTCF_Click(object sender, EventArgs e)
    {
        //   string redirectUrl = "/WebTCF2015/TLogon.aspx?ParameterI=" + username + "&ParameterII=" + password + "&ParameterIII=" + pe3;
        string redirectUrl = "http://cs.api-hk.com/demo01/TLogon.aspx?ParameterI=" + username + "&ParameterII=" + password + "&ParameterIII=" + pe3 + "&P4=309";
   Response.Redirect(redirectUrl );

   Session.Clear();
   FormsAuthentication.SignOut();
   Response.End();
   //     Response.Write("<script>window.open(redirectUrl,'_blank')</script>");
    //    Response.Write("<script>window.open('" + "http://cs.api-hk.com/WebTCF2015/Tlogon.aspx?ParameterI=" + username + "&ParameterII=" + password + "&ParameterIII=" + pe3 + "','_blank')</script>");
    }
   
}

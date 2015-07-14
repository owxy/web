<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="TLogon.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<script  type="text/javascript" src="templates/jquery.min.js"></script>
<script type="text/javascript">jQuery.noConflict();</script>
  <base  />
  <meta http-equiv="content-type" content="text/html; charset=utf-8" />
  <meta name="robots" content="index, follow" />
  <meta name="keywords" content="" />
  <meta name="description" content="" />  
  <title>API Web Login</title>
  <link href="../templates/infinity_default/favicon.ico" rel="shortcut icon" type="image/x-icon" />
  <link rel="stylesheet" href="templates/infinity_default/css/template_css.css" type="text/css" />
  <link rel="stylesheet" href="modules/mod_infinitymenu/tmpl/default/css/superfish.css" type="text/css" />
  <script type="text/javascript" src="../templates/infinity_default/js/mootools.js"></script>
  <script type="text/javascript" src="../templates/infinity_default/js/caption.js"></script>
  <script type="text/javascript" src="../modules/mod_infinitymenu/tmpl/default/js/hoverIntent.js"></script>
  <script type="text/javascript" src="../modules/mod_infinitymenu/tmpl/default/js/superfish.js"></script>
  <script type="text/javascript" src="../modules/mod_infinitymenu/tmpl/default/js/supersubs.js"></script>
  <script type="text/javascript" src="../templates/infinity_default/js/start.js"></script>
  <!--[if IE 7]><link type="text/css" rel="stylesheet" href="templates/infinity_default/css/ie7.css" media="screen" /><![endif]-->
<!--[if IE 8]><link type="text/css" rel="stylesheet" href="templates/infinity_default/css/ie8.css" media="screen" /><![endif]-->
 <script type="text/javascript">
        function f_refreshtype() {
            var Image1 = document.getElementById("img");
            if (Image1 != null) {
                Image1.src = Image1.src + "?";
            }
        } 
    </script>
</head>
<body class='inner' runat="server" id="body1" onmouseover="self.status='';return true" onmousedown="self.status='';return true" >
 <div class="bg-top">
 <div class="bg-footer">
 <div class="wrapper">
   <div id="header" style="left: 0px; top: 0px">
            	<div class="logo">		<div class="moduletable">
				<img src="templates/infinity_default/images/logo.png" alt="api" title="api" /></div>
	</div><a href="../default.htm"></a>
     <div class="clear"></div><div class='homepagelink' style="right: 224px; top: 112px"><a href="http://www.api-hk.com/"></a></div>
    </div>
    <div id="main-container">
    <h1 class="componentheading">
	Login</h1>
    <form id="form1" runat="server" class="form-validate">

<table cellpadding="0" cellspacing="0" border="0" width="100%">
	<tr align="left">
		<td style="width: 80px;height:30px;"><strong><label for="com_login_username">Username</label>:</strong></td>
  <td style="width:200px;"><input type="text" id="txtAccount" name="Name" style="width: 110px;" runat="server" class="inputbox required" size="30"/></td>
		<td><span class="tip-com_login_username"></span></td>
	</tr>
	<tr>
		<td style="height:30px;" align="left"><strong><label for="com_login_passwd">Password</label>:</strong></td>
    <td align="left"><input type="password"  id="txtPassword" name="password" style="width: 110px;" runat="server"  class="inputbox required" size="30" /></td>
		<td align="left"><span class="tip-com_login_passwd"></span></td>
	</tr>
	  <tr align="left">
		<td style="height:26px;"><strong><label for="com_login_passwd">Verify</label>:</strong></td>
		<td align="left"><input type="text" id="checkcodetxt"  style="width: 110px;" runat="server" class="inputbox required" size="30"/></td>
		<td align="left"><img src="CreateImage.aspx" id="img" onclick="f_refreshtype()" alt="click refresh" /></td>
	</tr>
		<tr align="left">
		<td style="height:34px;">&nbsp;</td>
	  <td colspan="2" style="height: 34px"><asp:Button  Text="login" ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" cssclass="button validate" />
          <asp:label id="lblMessage" runat="server"> </asp:label></td>
	</tr>
</table>
    </form>
    </div>
                <div id="footer">
            	<div class="footer-l">
                	<div class="footer-menu">		<div class="moduletable">
					<ul class="menu"><li class="item119"><a href="http://www.api-hk.com/en/home"><span>Home</span></a></li><li class="item23"><a href="http://www.api-hk.com/en/privacy-policy"><span>Privacy Policy</span></a></li><li class="item25"><a href="http://www.api-hk.com/en/site-map"><span>Site Map</span></a></li><li class="item32"><a href="http://www.api-hk.com/en/archived"><span>Archived</span></a></li><li class="item116"><a href="http://www.api-hk.com/en/terms-of-use" target="_blank"><span>Terms of Use</span></a></li></ul>		</div>
	</div>
                    <div class="clear"></div>
                    <div class="copyright">		<div class="moduletable">
					<p>Copyright <a href="TLogon.aspx" class="copy">&copy;</a> 2011 Asia Pacific Inspection Ltd. All Rights Reserved.</p>		</div>
	</div>
                </div>
            	<div class="footer-logo">		
			<div class="moduletable">
					<img src="templates/infinity_default/images/footer_logo.png" alt="api" title="api" /></div>
	</div>
                <div class="clear"></div>
            </div>
             </div>
</div>
</div>
</body>
</html>

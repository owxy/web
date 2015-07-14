<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="TTop.aspx.cs" Inherits="Web_TTop" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<script  type="text/javascript" src="../templates/jquery.min.js"></script>
<script type="text/javascript">jQuery.noConflict();</script>
  <base  />
  <meta http-equiv="content-type" content="text/html; charset=utf-8" />
  <meta name="robots" content="index, follow" />
  <meta name="keywords" content="" />
  <meta name="description" content="" />  
  <title>top</title>
  <link href="../templates/infinity_default/favicon.ico" rel="shortcut icon" type="image/x-icon" />
  <link rel="stylesheet" href="../templates/infinity_default/css/template_css.css" type="text/css" />
  <link rel="stylesheet" href="../modules/mod_infinitymenu/tmpl/default/css/superfish.css" type="text/css" />
  <script type="text/javascript" src="../templates/infinity_default/js/mootools.js"></script>
  <script type="text/javascript" src="../templates/infinity_default/js/caption.js"></script>
  <script type="text/javascript" src="../modules/mod_infinitymenu/tmpl/default/js/hoverIntent.js"></script>
  <script type="text/javascript" src="../modules/mod_infinitymenu/tmpl/default/js/superfish.js"></script>
  <script type="text/javascript" src="../modules/mod_infinitymenu/tmpl/default/js/supersubs.js"></script>
  <script type="text/javascript" src="../templates/infinity_default/js/start.js"></script>
  <!--[if IE 7]><link type="text/css" rel="stylesheet" href="templates/infinity_default/css/ie7.css" media="screen" /><![endif]-->
<!--[if IE 8]><link type="text/css" rel="stylesheet" href="templates/infinity_default/css/ie8.css" media="screen" /><![endif]-->
 <script  type="text/javascript" language="javascript">
     var t = null;
     var myDate = new Date();
    t = setTimeout(time,1000);
    function time()
    {
       clearTimeout(t);
       dt = new Date();
       var h=dt.getHours();
       var m=dt.getMinutes();
       var s=dt.getSeconds();
       var tp = document.getElementById("timePlace");
       result = dt.toLocaleDateString()+" "+dt.toLocaleTimeString();
       document.getElementById("timeShow").innerHTML =myDate.getFullYear()+"-"+(Number(myDate.getMonth())+1)+"-"+myDate.getDate()+"  "+h+":"+m+":"+s+"";
       t = setTimeout(time,1000);              
    } 
    </script>
</head>
<body class='inner' runat="server" id="body1" onmouseover="self.status='';return true" onmousedown="self.status='';return true" >
 <div class="bg-top">
   <div id="header" style="left: 4px; top: 0px; height: 77px;">
            	<div class="logo">		<div class="moduletable">
					<img src="../templates/infinity_default/images/logo.png" alt="api" title="api" style="height: 77px; width: 111px;" /></div>
	</div><a href="http://www.api-hk.com/en/home" target ="_blank"></a>
        <div class='homepagelink' style="right: 10px; top: 14px"><a href="http://www.api-hk.com/en/home"></a></div><div id="timeShow" style="top: 14px; right: 200px; position: absolute; font-size: x-small;
        font-family: Arial; color: Navy;"></div>
                    			<div class="moduletable">  
    <form id="form1" runat="server" class="form-validate">
    <asp:Label ID="lblUser" runat="server" ></asp:Label><a href="../TLogon.aspx" target="_top"  ></a><asp:Button ID="button1" runat="server" Text="Logout" cssclass="button validate"
                                OnClick="button1_Click" ></asp:Button><div class="clear"></div>
    </form>
      </div>
       </div></div>
</body>
</html>

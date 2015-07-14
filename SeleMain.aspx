<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SeleMain.aspx.cs" Inherits="SeleMain" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head>
    <title>API Web</title>
  </head>
<frameset rows="100,*,75" framespacing="0" frameborder="no" border="0">
		<frame name="header" src="Web/ttop.aspx" frameborder="no" noresize="noresize" scrolling="no">
		<frameset cols="*" framespacing="0" frameborder="no" border="0" id="FSet">
			<frame src="Web/Main.aspx"  name="mainFrame" id="mainFrame" frameborder="yes" noresize="noresize" scrolling="yes">	
		</frameset>		
		<frame name="footer" src="Web/bomt.aspx" frameborder="yes" noresize="noresize" scrolling="no">	
</frameset>
</html>

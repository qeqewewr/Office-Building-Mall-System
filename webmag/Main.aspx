<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Main.aspx.cs" Inherits="webmag_Main" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<frameset rows="80,*" cols="*" frameborder="NO" border="0" framespacing="0">
  <frame src="top.ASPX" name="topFrame" scrolling="NO" noresize >
  <frameset cols="185,*" frameborder="NO" border="0" framespacing="0">
    <frame src="left.ASPX" name="leftFrame" scrolling="yes" noresize>
    <frame src="" name="mainFrame">
  </frameset>
</frameset>
<noframes><body>
</body></noframes>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Top.aspx.cs" Inherits="webmag_Top" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
  
 <body background="images/bg.gif" style="background-repeat:repeat;   background-position: 0 -340px;height:80px;margin-top:0px;margin-left:0px;margin-bottom:0px; ">
    <div height="80px">
	<div style="float:left; "><img src="images/mag.gif" width="535" height="80px" /></div>
 	<div style="padding-top:50px;  float:right;"><span style="font-size:12px;font-weight:bold;color:#FFFFFF;">您好，<%=manager.userName%><font color="#ff0000"></font>，欢迎您的到来</span><span style="font-size:12px; font-weight:bold; color:#FFFFFF; padding-left:20px;"><a href="javascript:if(confirm('确定要退出系统吗？')){window.location.href='../webmag/logout.aspx';}" style="color:#FFFFFF " target="_top">退出系统</a>&nbsp;</span></div>
 </body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LoginStatePage.aspx.cs" Inherits="LoginStatePage" %>
<% if(username != null) {%>
<script>
	(function () {
		var username = "<%=username%>";
		$("#loginfo").html("您好，" + username + "！欢迎来到光大商城！ <a href='/User/logout.aspx'>[退出]</a>").closest("ul").append(" <li><a href='/User/Userhome.aspx'>我的光大</a></li>");
	})();
</script>

<%} %>

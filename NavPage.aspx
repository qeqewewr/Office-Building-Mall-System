<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NavPage.aspx.cs" Inherits="NavPage" %>
<ul>
<% for (int i = 0; i < list.Count; i++)
   { %>
   <li rel="<%=list[i].ID%>">

	<a href="/Goods/GoodsList.aspx?type=<%=list[i].ID%>&ptype=<%=list[i].ID %>"><%=list[i].typeName%></a>

    
   </li>


<%} %>
</ul>
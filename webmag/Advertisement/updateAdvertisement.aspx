<%@ Page Language="C#" AutoEventWireup="true" CodeFile="updateAdvertisement.aspx.cs" Inherits="webmag_Advertisement_updateAdvertisement" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
  <head id="Head1" runat="server">  
    <title></title>
	<meta http-equiv="pragma" content="no-cache"/>
	<meta http-equiv="cache-control" content="no-cache"/>
	<meta http-equiv="expires" content="0"/>    

     <link rel="stylesheet" type="text/css" href="../Styles/webmag.css"  />
    <link rel="stylesheet" type="text/css" href="../styles/uploadify.css" />
    <script language="javascript" src="../../js/jquery-1.4.3.min.js"></script>
    <script src="../scripts/swfobject.js"></script>
	<script src="../scripts/jquery.uploadify.v2.1.4.js"></script>
    <script language="javascript" src="../Scripts/webmag.js"></script>
    <script language="javascript" src="../Scripts/util.js"></script>
    </head>

  <body> 
   
    <div style="width: 100%">
        <div>
			<table class="resultTable">
				<caption style="text-align: left">
					&nbsp;&nbsp;&nbsp;&nbsp;广告位设置：&nbsp;&nbsp;              
				</caption>


				<tr class="topTitle" align="center">
					<td align="center">广告链接地址</td>
                   <%-- <input type="text" name="adPosition" id="adPosition" value="<%adPosition %>">--%>
                    <%if (adPosition != 3)
                      { %>
					<td align="center" colspan="2">广告图片</td>
                    <%} %>
                    <td align="center">备注</td>
                    <td align="center">广告出现顺序</td>
					<td align="center" >操 作</td>
				</tr> 
                <%for (int i = 0; i < advertisementList.Count; i++)
                  { %>
				            <form action="updateAdvertisement.aspx?id=<%= advertisementList[i].ID%>&sign=1" name="saveForm"
				id="saveForm" method="post" enctype="multipart/form-data" onsubmit="return verifySubmit();">
				        <tr onMouseOver="this.style.backgroundColor='#f3f3f3';return true;"
							onMouseOut="this.style.backgroundColor='';">
							<td title="连接地址">
                            <textarea id="Url" name="Url"
								style="width: 100%;height:100%;"><%= advertisementList[i].Url %></textarea>                          
                            </td> 
						<%if (adPosition != 3)
        {	%>
                      <td title="显示的图片" colspan="2">

                       <%
                            if (advertisementList[i].ImgUrl != null)
                            {%>

                        <%--<a href="<%=uploadpath %><%= attach[i].attachUrl%>" class="attatchHref"><%= attach[i].attachName%></a>--%>
                        已有图片名：<a href="<%=path %><%= advertisementList[i].ImgUrl%>" class="attatchHref"><%= advertisementList[i].ImgUrl%></a>
                        </br>
                      <%} %>      
                        更新图片：
			            <input id="ImgFile" name="ImgFile" type="file"  runat="server" onchange="f_file.value=this.value"/>


                        </td>
                        <%} %>

							<td title="<%= advertisementList[i].Description %>">

                            <textarea id="Description" name="Description"
								style="width: 100%; height:100%;"><%= advertisementList[i].Description %></textarea>   
                            </td>
                           <td title="选择显示次序">
 <%--                          --%>
                           <select name="adveOrder" id="adveOrder"/>
                        <%if(advertisementList[i].AdveOrder != 0){%>
                            <option value="<%=advertisementList[i].AdveOrder%>"><%=advertisementList[i].AdveOrder%></option>
                           <% for (int k = 1; k <=adNum; k++)
                          {
                            if(k != advertisementList[i].AdveOrder)
                          %>
                       <option value="<%=k%>"><%=k%></option>
                       
                       <% }}else{
                        for (int k = 1; k <=adNum; k++)
                          {%>
                          <option value="<%=k%>"><%=k%></option>
                          <%}} %>    
                        </select>							
							<td>
                            <input type="hidden" name="advType" id="advType" value="<%= advertisementList[i].AdveType %>" />
                                <input type="submit"
								value="设置" class="Btn" title="设置"/>
						    </td>
						</tr>
                        </form>
				<%} %>


               </table>



               </div>
            </div>
    
  </body>
</html>

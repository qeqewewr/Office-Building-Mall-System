<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ListClient.aspx.cs" Inherits="webmag_PrepaymentManage_ListClient" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">  
    
	<meta http-equiv="pragma" content="no-cache"/>
	<meta http-equiv="cache-control" content="no-cache"/>
	<meta http-equiv="expires" content="0"/>    

    <link rel="stylesheet" type="text/css" href="../Styles/webmag.css"  />
    <link rel="stylesheet" type="text/css" href="../facebox/facebox.css"/>	
    <script type="text/javascript" src="../Scripts/markupPage.js"></script>
    <script type="text/javascript" src="../Scripts/webmag.js"></script>
    <script type="text/javascript" src="../Scripts/jquery-1.4.1.min.js"></script>
    <script language="javascript" type="text/javascript" src="../facebox/facebox.js"></script>
    
        <script type="text/javascript">

            var global = {};
            jQuery(document).ready(function ($) {
                //$('a[rel=facebox]').facebox();
                $('a[rel=facebox]').click(function () {
                    var url = $(this).attr('href');
                    $.ajax({
                        url: url,
                        type: 'get',
                        cache: false,
                        success: function (d) {
                            $.facebox(d);
                        }
                    });
                    return false;
                });
            })


            function changeAction() {
                $("#action").val("search");
                $("#keyword").val($("#lookByName").val());
                //            $("#scope").val($("#searchScope").val());
            }

            $(function () {
                $("#search").focus();
            });



	</script>

  </head>
  
  <body> 
   
    <div style="width: 100%">
    <div class="queryArea"  style="width:100%">
    <%if (client == "1")
      {%>
            <form action="ListClient.aspx?pageno=1&client=1" name="searchForm"
				id="searchForm" method="post">
                <%}
      else if (client == "0")
      { %>


                  <form action="ListClient.aspx?pageno=1&client=0" name="searchForm"
				id="searchForm" method="post">

                <%} %>
                <input type="hidden" name="keyword" id="keyword" value="" />
                <input type="hidden" name="scope" id="scope" value="" />

				<fieldset>
					<legend style="color: #006699;"> 用户信息查询  </legend> 
					<span>用户名查询：<input type="text" name="lookByName" id="lookByName" title="请输入用户名"
						value="<%=keyword %>" 
						size="30" class="inputText"
						onfocus="$(this).css('border-color','#ff0000')"
						onblur="$(this).css('border-color','#006699')" /> 
                        <input id="search"
						type="submit" value=" " class="queryBtn" title="查询" onclick="changeAction()" /> </span>
				</fieldset>
                
			</form>
        </div>

        
        <div>
			<table class="resultTable">
				<caption style="text-align: left">
					&nbsp;&nbsp;&nbsp;&nbsp;用户信息列表：&nbsp;&nbsp;             
				</caption>


                <%  if (client == "0")
                    {%>
                        
                     <tr class="topTitle" align="center">
					<td align="center">用户名</td>
					<td align="center">注册时间</td>
                    <td align="center">可用余额</td>
                    <td align="center">预付款充值</td>
				</tr> 
                <form name="pageControlForm" id="pageControlForm" action="updateClient.aspx?page=<%= pageno %>" >
                <input type="hidden" name="comName" id="comName" value="<%=keyword %>" />
                <input type="hidden" name="cli" id="cli" value="0" />
                       <% for (int i = 0; i < customerList.Count; i++)
                        { %>
				        <tr onMouseOver="this.style.backgroundColor='#f3f3f3';return true;"
							onMouseOut="this.style.backgroundColor='';">
							
							<td title="<%= customerList[i].cusLoginName %>"><%= customerList[i].cusLoginName%></td> 
							<td title="<%= customerList[i].cusRegTime %>"><%= customerList[i].cusRegTime%></td>
                            <td title=""><a rel="facebox" href="viewfacebox.aspx?id=<%=customerList[i].ID %>&setSign=0"><strong>查看</strong></a></td>
							<td title="充值"> <a rel="facebox" href="cusFaceBox.aspx?id=<%=customerList[i].ID %>"><strong>充值</strong></a></td>
						</tr>
				<%}%>
                <tr>	
						<td colspan="4" id="pageControl"></td>
					</tr> 
                    </form>
                    <% }
                    else if (client == "1")
                   { %>
					<tr class="topTitle" align="center">
					<td align="center">公司名称</td>
					<td align="center">公司地址</td>
                    <td align="center">可用余额</td>
                    <td align="center">预付款充值</td>
				</tr> 
                 <form name="pageControlForm" id="pageControlForm" action="updateClient.aspx?page=<%= pageno %>">
                    <input type="hidden" name="comName" id="comName" value="<%=keyword %>" />
                    <input type="hidden" name="cli" id="cli" value="1" />
                  <%  for (int i = 0; i < lesseeList.Count; i++)
                        { %>

                

				        <tr onMouseOver="this.style.backgroundColor='#f3f3f3';return true;"
							onMouseOut="this.style.backgroundColor='';">
							
							<td title="<%= lesseeList[i].Name %>"><%= lesseeList[i].Name%></td> 
							<td title="<%= lesseeList[i].Address %>"><%= lesseeList[i].Address%></td>
                            <td title=""><a rel="facebox" href="viewfacebox.aspx?id=<%=lesseeList[i].ID %>&setSign=1"><strong>查看</strong></a></td>
							<td title="充值"> <a rel="facebox" href="facebox.aspx?id=<%=lesseeList[i].ID %>"><strong>充值</strong></a></td>

						</tr>
				<%}%>
                <tr>	
						<td colspan="4" id="pageControl"></td>
					</tr>
                </form>
                  <%  } %>



                    <tr>
					<td colspan="5" valign="middle">
						<!-- markupPage -->
						<table width="100%" border="0" cellpadding="0" cellspacing="0" id="Table1" >
							 
							<tr style="border:0px;">
								<td style="border:0px;">
									<span>[总数:<%=page.RowCount %>条]</span> <span>[每页:<%= page.PageSize %>条]</span> [页次:<span title="当前第<%= page.PageNo %>页" style="color:#FF0000"><%= page.PageNo %></span>/<%= page.PageCount %>]
								</td> 
								<td align="right"  style="border:0px;">
                                    <%if (page.PageNo == 1)
                                      { %>
                                        <font title="首页">首页</font> <font title="前一页">前一页</font>
                                    <%}
                                      else
                                      {%>
									        <a href="javascript:gotoPage(1)"><font title="首页">首页</font></a> <a href="javascript:gotoPage(<%= page.PrePage %>)"><font title="前一页">前一页</font></a>
									<%} %>
                                    <%if (page.PageNo == page.PageCount)
                                      { %>
                                            <font title="下一页">下一页</font> <font title="最后一页">最后一页</font>
                                    <%}
                                      else
                                      {%>
									        <a href="javascript:gotoPage(<%= page.NextPage %>)"><font title="下一页" >下一页</font></a> <a href="javascript:gotoPage(<%= page.PageCount %>)"><font title="最后一页">最后一页</font></a>

									<%} %>
		
									跳到
								<input type="text"  style="width:20px" name="pageno1" id="pageno1" value="<%= page.PageNo %>"   />
								页  <a href="javascript:testAndGotoPage(document.getElementById('pageno1').value,<%= page.PageNo %>,<%= page.PageCount %>)"><font title="GO">GO</font></a>
								</td>
								<%--<td style="width:15px;"></td> --%>
							</tr>
						</table> 
					</td>
				</tr>

               </table>
               </div>
            </div>
    
  </body>
</html>

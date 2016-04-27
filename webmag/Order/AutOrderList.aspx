<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AutOrderList.aspx.cs" Inherits="webmag_Order_AutOrderList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
 <head id="Head1" runat="server">  
    
	<meta http-equiv="pragma" content="no-cache"/>
	<meta http-equiv="cache-control" content="no-cache"/>
	<meta http-equiv="expires" content="0"/>    

    <link rel="stylesheet" type="text/css" href="../Styles/webmag.css"  />
    <script type="text/javascript" src="../Scripts/markupPage.js"></script>
    <script type="text/javascript" src="../Scripts/webmag.js"></script>
    <script type="text/javascript" src="../Scripts/jquery-1.4.1.min.js"></script>
    
        <script type="text/javascript">
//            function changeAction() {
//                $("#action").val("search");
//                $("#keyword").val($("#lookByName").val());
//                //            $("#scope").val($("#searchScope").val());
//            }


            function changeAction() {
                $("#action").val("search");
                $("#keyword").val($("#lookByName").val());
                $("#reName").val($("#reNamel").val());
                $("#scope").val($("#searchScope").val());
            }

            $(function () {
                $("#search").focus();
            });
	</script>

  </head>
  
  <body> 
   
    <div style="width: 100%">
    <div class="queryArea"  style="width:100%">
            <form action="AutOrderList.aspx?pageno=1" name="searchForm"
				id="searchForm" method="post">
                <input type="hidden" name="keyword" id="keyword" value="" />
                <input type="hidden" name="scope" id="scope" value="" />
                <input type="hidden" name="reName" id="reName" value="" />

				<fieldset>
					<legend style="color: #006699;"> 订单信息查询  </legend> 
					<span>订单编号：<input type="text" name="lookByName" id="lookByName" title="请输入订单编号"
						value="<%=keyword %>" 
						size="30" class="inputText"
						onfocus="$(this).css('border-color','#ff0000')"
						onblur="$(this).css('border-color','#006699')" /> 
                        收件人：
                        <select name="reNamel" id="reNamel">
                       <%-- <option>请选择收件人</option>--%>
                        <%for (int i = 0; i < reNameList.Count; i++)
                          {
                              if (reNameList[i] != null && reNameList[i] != "")
                              {%>
                                    <option ><%=reNameList[i]%></option>
                        <%}
                          } %>    
                        </select>
                        订单状态：
                        <select name="searchScope" id="searchScope" >
                            <option>全部</option> 
                            <option>用户购物车</option>
                            <option>等待确认</option>
                            <option>已确认（准备发货）</option>
                            <option>已发货</option>
                            <option>取消订单</option>
                            <option>交易不成功</option>
                            <option>交易成功</option>                                                              
                        </select>

                        <input id="search"
						type="submit" value=" " class="queryBtn" title="查询" onclick="changeAction()" /> </span>
				</fieldset>
                
			</form>
        </div>

        
        <div>
			<table class="resultTable">
				<caption style="text-align: left">
					&nbsp;&nbsp;&nbsp;&nbsp;订单信息列表：&nbsp;&nbsp;              
				</caption>


				<tr class="topTitle" align="center">
					<td align="center">订单编号</td>
					<td align="center">收货人</td>
                    <td align="center">下单时间</td>
                    <td align="center">订单状态</td>
					<td align="center" colspan="2">操 作</td>
				</tr> 

              <form name="pageControlForm" action="AutChangePage.aspx?page=<%= pageno %>" method="post"
				 id="pageControlForm" onsubmit="return checkDeleteSubmit('pageControlForm');"> 
                <input type="hidden" name="comName" id="comName" value="<%=keyword %>" />
                <input type="hidden" name="scope"  value="<%=scope %>" />
                <input type="hidden" name="reName" value="<%=reName %>" />
                <%for (int i = 0; i < orderList.Count; i++)
                  { %>
				
				        <tr onMouseOver="this.style.backgroundColor='#f3f3f3';return true;"
							onMouseOut="this.style.backgroundColor='';">
                            <td title="<%= orderList[i].orderNO %>"><%= orderList[i].orderNO %></td> 
							
							<td title="<%= orderList[i].Receiver %>" align="left"><%= orderList[i].Receiver%></td> 
							<td title="<%= orderList[i].payTime %>"><%= orderList[i].payTime%></td>
                            <td title="<%= orderList[i].orderStatus %>"><%= Constants.orderStatus(orderList[i].orderStatus)%></td>
							
							<td>
                            <%if (orderList[i].orderStatus != "0")
                              {%>
                                <input type="button"
								value="审核" title="审核" style="width:auto"
								onclick="window.location.href='CheckOrder.aspx?id=<%= orderList[i].ID%>&pageno=<%= pageno %>'">
                                <%} %>
                                <%if (orderList[i].orderStatus == "2")
                                  {%>
                                <input type="button"
								value="发货" title="发货" style="width:auto"
								onclick="window.location.href='SendGoods.aspx?id=<%= orderList[i].ID%>&pageno=<%= pageno %>'">
                                <%} %>
						    </td>
						</tr>
				<%} %>
					
					<tr>	
						<td colspan="6" id="pageControl"></td>
					</tr> 
                </form>


                    <tr>
					<td colspan="6" valign="middle">
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

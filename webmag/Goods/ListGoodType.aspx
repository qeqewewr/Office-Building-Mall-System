<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ListGoodType.aspx.cs" Inherits="webmag_Goods_ListGoodType" %>
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
            <form action="ListGoodType.aspx" name="searchForm"
				id="searchForm" method="post">  
				<fieldset>
					<legend style="color: #006699;"> 商品信息查询  </legend> 
					<span>类别查询：<input type="text" name="keyword" id="keyword" title="请输入类别名称"
						 value="<%= keyword %>" 
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
					&nbsp;&nbsp;&nbsp;&nbsp;商品类别信息列表：&nbsp;&nbsp;
                <span align="right">
                <%if (permissionList.Count>0)
                  {%>

                <input type="button" value="" class="addBtn" title="添加"
						onClick="window.location.href='AddGoodType.aspx'">
                        <% }%>
			    </span>
               
				</caption>


				<tr class="topTitle" align="center">
                    <td align="center">选 择</td>
                    <td align="center">序 号</td> 
                    <td align="center">类别名称</td>
					<td align="center">上级类别</td>
					<td align="center" colspan="2">操 作</td>
				</tr> 

              <form name="pageControlForm" action="DeleteGoodType.aspx" method="post"
				 id="pageControlForm" onsubmit="return checkDeleteSubmit('pageControlForm');"> 
                <input type="hidden" name="keyword" id="keyword" value="<%=keyword %>" />
                <%for (int i = 0; i<pageItems.Count; i++)
                  { %>
				
				        <tr onMouseOver="this.style.backgroundColor='#f3f3f3';return true;"
							onMouseOut="this.style.backgroundColor='';">
                           
							<td><input type="checkbox" name="selectDel"
								value="<%=pageItems[i].ID %>" onclick="isAllSelected(this,'sltAll','1')" />
							</td> 
                            <td>
                            <%= i + 1 %>
							</td> 
							<td title="<%= pageItems[i].typeName %>" align="left"><%= pageItems[i].typeName%></td> 
							<td ><%if (pageItems[i].parent != null && pageItems[i].parent > 0 && pageItems[i].parent!=55) { %><%= srv.GetModel(pageItems[i].parent).typeName%><%}  %></td>
							
							<td><input type="button" value="" 
								onclick="window.location.href='UpdateGoodType.aspx?id=<%= pageItems[i].ID%>&pageno=<%= pageno %>'"
								class="updateBtn" title="编辑"> 
                                <input type="button"
								value="" class="deleteBtn" title="删除"
								onclick="window.location.href='DeleteGoodType.aspx?id=<%= pageItems[i].ID%>&pageno=<%= pageno %>&keyword=<%=keyword %>'">
                                <input type="button"
								value="" class="viewBtn" title="查看"
								onclick="window.location.href='ViewGoodType.aspx?id=<%= pageItems[i].ID%>&pageno=<%= pageno %>'">
                                
						    </td>
						</tr>
				<%} %>
					
					<tr>	
						<td> 
							<input type="checkbox" id="sltAll" title="全选" alt="全选" name="sltAll"
								onclick="selectAll('pageControlForm','selectDel','sltAll')"> <input
								type="submit" class="deleteBtn" value="" title="删除全选"  />
                               
						</td>
						<td colspan="4" id="pageControl"></td>
					</tr> 
                </form>


                    <tr>
					<td colspan="5" valign="middle">
						<!-- markupPage -->
						<table width="100%" border="0" cellpadding="0" cellspacing="0" id="Table1" >
							 
							<tr style="border:0px;">
								<td style="border:0px;">
									<span>[总数:<%=form.getRowcount() %>条]</span> <span>[每页:<%= form.getPagesize() %>条]</span> [页次:<span title="当前第<%= form.getPageno() %>页" style="color:#FF0000"><%= form.getPageno()%></span>/<%= form.getPagecount()%>]
								</td> 
								<td align="right"  style="border:0px;">
                                    <%if (form.getPageno() == 1)
                                      { %>
                                        <font title="首页">首页</font> <font title="前一页">前一页</font>
                                    <%}
                                      else
                                      {%>
									        <a href="javascript:gotoPage(1)"><font title="首页">首页</font></a> <a href="javascript:gotoPage(<%= form.getPrepage()  %>)"><font title="前一页">前一页</font></a>
									<%} %>
                                    <%if (form.getPageno() == form.getPagecount())
                                      { %>
                                            <font title="下一页">下一页</font> <font title="最后一页">最后一页</font>
                                    <%}
                                      else
                                      {%>
									        <a href="javascript:gotoPage(<%= form.getNextpage() %>)"><font title="下一页" >下一页</font></a> <a href="javascript:gotoPage(<%= form.getPagecount() %>)"><font title="最后一页">最后一页</font></a>

									<%} %>
		
									跳到
								<input type="text"  style="width:20px" name="pageno1" id="pageno1" value="<%= form.getPageno() %>"   />
								页  <a href="javascript:testAndGotoPage(document.getElementById('pageno1').value,<%= form.getPageno() %>,<%= form.getPagecount()%>)"><font title="GO">GO</font></a>
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

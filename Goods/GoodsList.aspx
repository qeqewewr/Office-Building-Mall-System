<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GoodsList.aspx.cs" Inherits="Goods_GoodsList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
	<meta content="text/html; charset=gb2312" http-equiv="Content-Type">
	<link media="all" href="../css/base20100719.w.css" type="text/css" rel="stylesheet">
	<link media="all" href="../css/plist2-0813.css" type="text/css" rel="stylesheet">
	<script type="text/javascript" src="../js/jquery-1.4.3.min.js" ></script>
	<script type="text/javascript">


		$(function () {
			function showImg(index) {
				var adHeight = 240;
				$("#slide ul").stop(true, false).animate({ top: -adHeight * index }, 1000);
				$(".num span").removeClass("curr")
			.eq(index).addClass("curr");
			}
			var len = $(".num span").length;
			var index = 0;
			var adTimer;
			$(".num span").mouseover(function () {
				index = $(".num span").index(this);
				showImg(index);
			}).eq(0).mouseover();
			//滑入 停止动画，滑出开始动画.
			$('#slide').hover(function () {
				clearInterval(adTimer);
			}, function () {
				adTimer = setInterval(function () {
					showImg(index)
					index++;
					if (index == len) { index = 0; }
				}, 3000);
			})
		});
    </script>
	<title>办公打印</title>
</head>
<body id="computer">
	 <!--#include file="../top.aspx"-->
	<div class="w main">
		<div class="left">
			<div id="sortlist" class="m">
				<div class="mt">
					<h2><%=goodTypeName %></h2>
				</div>
				<div class="mc">
					<div class="item">
						<ul>
							<%for (int i = 0; i < goodsTypeList.Count; i++)
		 { %>
		 <li><a href="/Goods/GoodsList.aspx?type=<%=goodsTypeList[i].ID %>&ptype=<%=ptype%>"><%=goodsTypeList[i].typeName %></a></li>

							<%} %>
						
						</ul>
					</div>
				</div>
			</div>
		</div>
		<div class="middle"> 
			<div id="newpros" class="m plist">
				<div class="mt">
					<h2>商品列表</h2> 
				</div>
				
				<div id="madding-1" class="mc list-h">
					<ul class="tabcon">
                        <%for (int i = 0; i < list.Count; i++)
						  { %>
						<li>
							<div class="p-img">
								<a href="goodsDetail.aspx?id=<%=list[i].ID %>" target="_blank">
									<img width="150" height="150" app="image:product" alt="<%=upload %><%=list[i].goodName %>" src=<%=upload %><%= attachSrv.GetModelList(" attachType= "+list[i].goodType+" and moduleID= "+list[i].ID)[0].attachUrl%> />
								</a>
							</div>
							<div class="p-name">
							<a href="goodsDetail.aspx?id=<%=list[i].ID %>" title="<%=list[i].goodName %>" target="_blank">
							<%=list[i].goodName%>
							</a>
							</div>
							<div class="p-price">
							市场价：
							<strong>
							 <%=list[i].goodPrice%>
							</strong>
							</div>
						</li>
                           <%} %>
	                
					</ul> 
				</div>
			 <div class="pagin fr">
                    <%if (0 == cPage.getPageno() || 1 == cPage.getPageno())
                      { %>
                    <span class="prev-disabled">上一页<b></b></span><%} %>
                    <%else { %>
                         <a href="/cleaner/CleanerList.aspx?pageno=<%= cPage.getPageno()-1 %>&keyword=<%=keyword %>" class="prev">上一页</a><b></b> 
                    <%} %>
                    <%if (cPage.getPageno()-1>0 )
                      { %>
                        <a href="/cleaner/CleanerList.aspx?pageno=<%= cPage.getPageno()-1 %>&keyword=<%=keyword %>"
                        ><%= cPage.getPageno()-1%></a>
                      <%} %> 

                    <a href="/cleaner/CleanerList.aspx?pageno=<%= cPage.getPageno() %>&keyword=<%=keyword %>"
                        class="current"><%= cPage.getPageno()%></a>
                        <% if (cPage.getPagecount() - cPage.getPageno() >= 1 )
                          { %>
                             <span
                            class="text">…</span>
                       
                        <a href="/cleaner/CleanerList.aspx?pageno=<%= cPage.getPagecount() %>&keyword=<%=keyword %>"><%= cPage.getPagecount() %></a> <%} %> 
                        <% if (cPage.getPageno() < cPage.getPagecount())
                           { %>
                        <a href="/cleaner/CleanerList.aspx?pageno=<%= cPage.getPageno()+1 %>&keyword=<%=keyword %>"
                                class="next">下一页<b></b></a>
                                <%}
                           else
                           { %>
                           <span class="next-disabled">下一页<b></b></span>
                                <%} %>

                </div>  
			
			
			</div> 
		</div> 
		

		
		<span class="clr"></span>
	</div>

<!--页面底部 <div id="footer" class="w" clstag="homepage|keycount|homepage|37a">-->
<div id="footer" class="w">
  <div class="flinks"> <a target="_blank" href="#">关于我们</a> | <a target="_blank" href="#">联系我们</a> | <a target="_blank" href="#">人才招聘</a> </div>
  <div class="copyright"> <a>Copyright 2011-2011 上海光大物业 版权所有.</a> </div>
</div>
</body>
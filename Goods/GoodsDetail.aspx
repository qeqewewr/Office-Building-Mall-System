<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GoodsDetail.aspx.cs" Inherits="Goods_GoodsDetail" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
	<meta content="text/html; charset=gb2312" http-equiv="Content-Type">
	<link media="all" href="../css/base20100719.css" type="text/css" rel="stylesheet">
	<link media="all" href="../css/pshow20111107.css" type="text/css" rel="stylesheet">
	<script type="text/javascript" src="../js/jquery-1.2.6.pack.js" ></script>
	
<script type="text/javascript">
    $(document).ready(function () {
        show('content1');
    });  
</script>
<script>
    var show = function (id0) {
        var contents = $("div[name=content]");
        //alert(contents.length);
        //var name=name1.substring(0,name1.length-1);
        var id1 = "";
        $.each(contents, function () {
            id1 = $(this).attr("id");
            //alert(id1);
            $("div[id=" + id1 + "]").get(0).style.display = "none";
        });
        $("div[id=" + id0 + "]").get(0).style.display = "";
    }

    $(function () {
        $('#detail ul.tab').find("li").mouseover(function () {
            $(this).closest("ul").find("li").removeClass('curr');
            $(this).addClass('curr');
        });
    });

    var setAmount = {
        min: 1,
        max: 999,
        reg: function (x) {
            return new RegExp("^[1-9]\\d*$").test(x);
        },
        amount: function (obj, mode) {
            var x = $(obj).val();
            if (this.reg(x)) {
                if (mode) {
                    x++;
                } else {
                    x--;
                }
            } else {
                alert("请输入正确的数量！");
                $(obj).val(1);
                $(obj).focus();
            }
            return x;
        },
        reduce: function (obj) {
            var x = this.amount(obj, false);
            if (x >= this.min) {
                $(obj).val(x);
            } else {
                alert("商品数量最少为" + this.min);
                $(obj).val(1);
                $(obj).focus();
            }
        },
        add: function (obj) {
            var x = this.amount(obj, true);
            if (x <= this.max) {
                $(obj).val(x);
            } else {
                alert("商品数量最多为" + this.max);
                $(obj).val(999);
                $(obj).focus();
            }
        },
        modify: function (obj) {
            var x = $(obj).val();
            if (x < this.min || x > this.max || !this.reg(x)) {
                alert("请输入正确的数量！");
                $(obj).val(1);
                $(obj).focus();
            }
        }
    }
    /*function BuyUrl(wid)
    {
    var pcounts = $("#pamount").val();
    var patrn=/^[0-9]{1,4}$/;
    if (!patrn.exec(pcounts))
    {
    pcounts = 1;
    }
    else
    {
    if(pcounts<=0)
    pcounts = 1;
    if(pcounts>=1000)
    pcounts = 999;
    }
    $("#InitCartUrl").attr("href", "http://jd2008.360buy.com/purchase/InitCart.aspx?pid="+wid+"&pcount="+pcounts+"&ptype=1");
    }*/
</script> 
	<title><%= entity.goodName %> </title>
</head>
<body id="computer" class="root61">
	 <!--#include file="../top.aspx"--> 
	
	<div class="w">
		<div class="crumb">
			<a href="/Index.aspx">首页</a>
			&nbsp;&gt;&nbsp;
			<%if (exist.Count > 0)
	 { %>
			<% for (int i = exist.Count - 1; i >= 0; i--)
	  { 
			
			%>
				
						<a href="/Goods/GoodsList.aspx?type=<%=exist[i].ID %>&ptype=<%=TopType.ID %>"><%=exist[i].typeName%></a>
			 
			&nbsp;&gt;&nbsp;
			<%} %>
			<%} %>
		<!--	<a href="">办公用品</a>
			 
			&nbsp;&gt;&nbsp;
			-->
			<a href="#"><%= entity.goodName%></a>
		</div>
	</div>
	
	<div class="w main">
		<div class="right-extra">
			<div id="name">
				<h1>
				<%= entity.goodName %>
				<font id="advertiseWord" style="color:#ff0000"></font>
				</h1>
			</div>
			<div id="preview">
				<div id="spec-n1" class="jqzoom">
					<img width="350" height="350" jqimg="<%= upload%><%=attach[0].attachUrl %>" alt="<%=entity.goodName %>" src="<%= upload %><%=attach[0].attachUrl %>" >
				</div>
				<div id="spec-n5">
					<div id="spec-left" class="control"></div>
					<div id="spec-right" class="control"></div>
					<div id="spec-list">
                    <ul class="list-h"> 
                     <%for (int i = 0; i < attach.Count; i++)
                          { %>
					
						<li>
						<img width="50" height="50" name="<%=attach[i].attachUrl %>" alt="" src="<%= upload%><%=attach[i].attachUrl %>" onerror="this.src='../images/none/none_50.gif'" style="border: 1px solid rgb(204, 204, 204); padding: 2px;">
					 </li> <%} %>
					</ul> 
					</div>
				</div>
			</div>
			<form action="../user/InitCart.aspx" method="post" name="goods" >
			<ul id="summary">
				<li>
					<span>商品编号：<%=entity.goodNO %></span>
				</li>
								<li>
					<span>库存：<%=entity.goodStock %></span>
				</li>
				<li>
					<div class="fl">
					优&nbsp;惠&nbsp;价：
					<strong class="price" style="visibility: visible;">
					 <%=entity.goodPromotion %>
                     <input type="hidden" name="price" value="<%=entity.goodPromotion %>" />
                     <input type="hidden" name="gid" value="<%=entity.ID %>" />
					</strong>
					</div>
					 
				</li>
			</ul>
			<div id="choose" class="m">
				<dl class="amount">
					<dt>　我要买：</dt>
					<dd>
						<a class="reduce" href="javascript:void(0)" onclick="setAmount.reduce('#pamount')">-</a>
						<input id="pamount" name="quantity" type="text" onkeyup="setAmount.modify('#pamount')" value="1">
						<a class="add" href="javascript:void(0)" onclick="setAmount.add('#pamount')">+</a>
					</dd>
				</dl>
				<div class="btns">
					<a id="InitCartUrl" class="btn-append" clstag="shangpin|keycount|product|InitCartUrl" onclick="javascript:document.goods.submit();">添加到购物车</a>
					<span class="clr"></span>
				</div>
				<span class="clr"></span>
			</div>
            </form>
			<span class="clr"></span>
			<div id="detail" class="m">
				<ul class="tab">
					<li class="curr" onclick="show('content1');$('#detail li').removeClass('curr');this.className='curr'">
						商品介绍
						<span></span>
					</li>
					<li onclick="show('content2');$('#detail li').removeClass('curr');this.className='curr'">
						规格参数
						<span></span>
					</li>
				</ul>
				<div name="content" id="content1" style="display:none">
<!-- 				<div class="mc fore tabcon" name="content" id="content1" style="display:none">
 -->
					<ul id="i-detail">
						<li title="<%= entity.goodName %>">商品名称：<%= entity.goodName %></li>
						<li>
						生产厂家：
						<%= entity.goodManufacture %>
						</li>
						<li>商品产地：<%=entity.goodOrg %></li> 
					  <li>商品颜色：<%=entity.goodColor %></li> 
					</ul>
					<div class="content">
						<strong>详细内容：</strong>
                        <%= entity.goodMemo %>
					</div>
				</div>
				<!-- <div class="mc tabcon hide" name="content" id="content2" style="display:none"> -->
				<div name="content" id="content2" style="display:none">
					<table class="Ptable" width="100%" cellspacing="1" cellpadding="0" border="0">
						<tbody>

							<tr>
								<td class="tdTitle">品牌</td>
								<td><%=entity.goodBrand %></td>
							</tr>
							 
							<tr>
								<td class="tdTitle">毛重</td>
								<td><%=entity.goodKg %></td>
							</tr>
                            <tr>
								<td class="tdTitle">净重</td>
								<td><%=entity.goodNetKg %></td>
							</tr>
                            <tr>
								<td class="tdTitle">材质</td>
								<td><%=entity.goodMaterial %></td>
							</tr>
                            <tr>
								<td class="tdTitle">规格</td>
								<td><%=entity.goodSpecifications %></td>
							</tr>
							           <tr>
								<td class="tdTitle">尺寸</td>
								<td><%=entity.goodSize%></td>
							</tr>
						</tbody>
					</table>
				</div>
				 
			</div>
			
		</div>
		<div class="left" style="visibility: visible;">
			<div id="sortlist" class="m">
				<div class="mt">
					<h2>相关分类</h2>
				</div>
				<div class="mc">
					<ul>
					<% for (int i = 0; i < sameTypes.Count; i++)
		{ %>						<li>
							<a href="/Goods/GoodsList.aspx?type=<%=sameTypes[i].ID %>&ptype=<%=TopType.ID %>"><%=sameTypes[i].typeName %></a>
						</li>

					<%} %>
			
					</ul>
				</div>
			</div>
		<!--
			<div id="samekind" class="m">
				<div class="mt">
					<h2>同类品牌</h2>
				</div>
				<div class="mc">
					<ul>
						<li>
							<a title="佳能" href="">佳能</a>
						</li>
						<li>
							<a title="惠普" href="">惠普</a>
						</li>
					</ul>
				</div>
			</div>
			-->
		</div>
	</div>
	</div>
	<span class="clr"></span>

	
	<!--页面底部 <div id="footer" class="w" clstag="homepage|keycount|homepage|37a">-->
	<div id="footer" class="w">
  <div class="flinks"> <a target="_blank" href="#">关于我们</a> | <a target="_blank" href="#">联系我们</a> | <a target="_blank" href="#">人才招聘</a> </div>
  <div class="copyright"> <a>Copyright 2011-2011 上海光大物业 版权所有.</a> </div>
</div>
	<script type="text/javascript" src="../js/jdMarquee.js"></script>
</body>
</html>
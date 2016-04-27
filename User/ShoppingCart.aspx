<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ShoppingCart.aspx.cs" Inherits="User_ShoppingCart" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml"><head id="Head1"><title>
	我的购物车
</title>
<link href="../css/common.css" rel="stylesheet" type="text/css">
<link href="../css/shoppingcart.css" rel="stylesheet" type="text/css">
<link rel="stylesheet" type="text/css" href="../webmag/facebox/facebox.css"/>	
<script language="javascript" src="../Scripts/jquery-1.4.1.js"></script>
<script language="javascript" type="text/javascript" src="../webmag/facebox/facebox.js"></script>
<script language="javascript">
    jQuery(document).ready(function ($) {
        $('a[rel=facebox]').facebox();
    })

    function CancelSkuInPromSuit(id) {

        if (confirm("确定要删除此条商品吗？")) {
            window.location.href = "ClearCart.aspx?flag=o&cartid=" + id;
            return true;
        } 
       return true;
   }

   function clearCart() {
       if (confirm("确定要清空购物车吗？")) {
           window.location.href = "ClearCart.aspx?flag=all";
           return true;
       }
       return true;
   }

</script>
</head>
<body>
<div id="shortcut">
	<div class="w">
		<div class="collect"></div>
		<ul>
			<li id="loginfo" class="fore1">您好，<%=username%>！欢迎您来到光大商城！<a href="logout.aspx">[退出]</a></li>
			<li class="fore2"><a href="UserHome.aspx">我的光大</a></li> 
		</ul>
		<span class="clr"></span>
	</div>
</div>
<!--[if lte IE 6]>
<script type="text/javascript">$("#shortcut .sub").hoverForIE6();</script>
<![endif]-->



    <div class="Wrap_cart"> 
	<div class="Header_cart" id="Top1_order_step1">
		
		<ul id="Order_cart_S1" class="Order_cart">
			<li class="step1">1.我的购物车</li>
			<li class="step2">2.填写核对订单信息</li>
			<li class="step3">3.成功提交订单</li>
		</ul>
		
</div>







<div class="mycart_tip" id="Top1_FeeInfo">

<img src="../images/cart_001.gif" id="myCartTipImg">

</div>
	
	<div class="List_cart">
	<h2><strong>我挑选的商品</strong></h2>
	<div class="cart_table">
	
	<script type="text/javascript">
	    function showLoginWindowCart() {
	        //登录弹出
	        jdModelCallCenter.settings = { 'clstag1': "login|keycount|5|5", 'clstag2': "login|keycount|5|6", 'fn': function () { if (g('panelJCcart') != null) g('panelJCcart').style.display = 'none'; isLogin = true; } };
	        jdModelCallCenter.login();
	    }
	    if (!isLogin) {
	        g('panelJCcart').style.display = '';
	    }

	   
	</script>
	
	 <!--商品列表开始-->
    <div id="productList">
<table width="100%" cellspacing="0" cellpadding="0" id="CartTb" class="Table">
 <tbody><tr class="align_Center Thead">
    <td width="7%" style="height:30px">商品编号</td>
    <td>商品名称</td>
    <td>商品规格特征</td>
    <td width="14%">优惠价</td>
    <td width="9%">商品数量</td>
    <td width="9%">商品金额</td>
    <td width="7%">删除商品</td>
 </tr>

<tr class="cartSpliter"><td colspan="7"></td></tr>
<%for(int i=0;i<details.Count;i++){ %>
<tr class="align_Center suitPromItem">
   <td style="height:30px;"><%=gsrv.GetModel(details[i].goodID).goodNO %></td>
   <td class="align_Left"><div style="margin-left:18px"><span><a clstag="clickcart|keycount|shoppingcartpop|productnamelinklistcart" onclick="this.blur();" href="../goods/GoodsDetail.aspx?id=<%= details[i].goodID%>" target="_blank"><%=gsrv.GetModel(details[i].goodID).goodName %></a></span></div></td>
   <td><a rel="facebox" href="facebox.aspx?goodid=<%=details[i].goodID %>">点击查看详细</a></td>
   <td><span class="price">￥<%= details[i].goodPrice  %></span></td>
   <td>
<span><%= details[i].goodQuantity%></span>
</td>
   <td>
<span class="price">￥<%= details[i].goodQuantity * details[i].goodPrice%></span>
</td>
<td><a clstag="clickcart|keycount|shoppingcartpop|btndel318558" style="cursor:pointer;" onclick="CancelSkuInPromSuit('<%=details[i].ID %>')" >删除</a></td>

</tr>
<%amount=amount +  details[i].goodPrice * details[i].goodQuantity ;
  } %>

       
<tr style="display:none" class="align_Center suitPromTitle">
    <td width="10%" style="height:30px;">-</td>
    <td class="align_Left">
        
    </td>
    <td><span class="price">-</span></td>
    <td>-</td>
    <td>-</td>
    <td>-</td>
    <td>-</td>
</tr>

 <tr>
    <td style="height:30px" colspan="7" class="align_Right Tfoot"><%--重量总计：0.00kg&nbsp;&nbsp;&nbsp;原始金额：￥<%=amount%>元 - 返现：￥0.00元<br><span style="font-size:14px"><b>--%>商品总金额：<span id="cartBottom_price" class="price"><font color="#FF0000">￥<%=amount%></font></span>元</b></span></td>
 </tr>
</tbody></table>
</div>
   
    <script type="text/javascript">
    
    </script>
     <!--商品添加区开始-->
    
     
     
    
    <!--商品列表结束-->
		<ul style="margin-bottom:0px;" class="cart_op">
		    
		    
		    
		    <!--li class="li4"><a href="#none" onclick='this.blur();saveCart();' clstag='clickcart|keycount|shoppingcartpop|savecartlink'>寄存购物车</a></li-->
			
			<li class="li2"><a clstag="clickcart|keycount|shoppingcartpop|clearcartlink" onclick="clearCart()" href="#none">清空购物车</a></li>
			
			
			<li class="li3">
			<div id="submit_info">
			</div>
			<div style="text-align:right" id="submit_btn">
			
			<img alt="进入分期订单" style="cursor:pointer;border:none;display:none;" onclick="runOrderInfo_fq(this);" id="gotoOrderInfo_fq" src="http://www.360buy.com/purchase/skin/images/fqbtn.gif">
			
	        <a clstag="clickcart|keycount|shoppingcartpop|continueBuyBtn" href="../Index.aspx" id="continueBuyBtn">继续购物</a>
	       
	        <a clstag="clickcart|keycount|shoppingcartpop|gotoOrderInfo" href="shoppingcartselect.aspx" onclick="GoToOrder(this);return false;" id="gotoOrderInfo">去结算</a>
			
			</div>
			<div id="submit_error" style="padding-right:9px;text-align:right;border:#fff 1px solid;"></div>
			<input type="button" value="提交" onclick="runOrderInfo_server(this);" style="display:none" id="BtnRunOrder_server">
			
			</li>
		</ul>
		
		<!--[if !IE]>删除区<![endif]-->
		
		 
		<!--[if !IE]>延保商品<![endif]-->
		<br>
		<div id="ybPanel"></div>

		
		
		
	 </div>
	 <div class="round"><div class="lround"></div><div class="rround"></div></div>
	</div>
	
</div>





<div class="Footer_Nav" class="w">
  <div class="flinks"> <a target="_blank" href="#">关于我们</a> | <a target="_blank" href="#">联系我们</a> | <a target="_blank" href="#">人才招聘</a> </div>
  <div class="copyright"> <a>Copyright 2011-2011 上海光大物业 版权所有.</a> </div>
</div>
 
</body></html>
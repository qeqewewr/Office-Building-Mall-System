<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ShoppingCartSelect.aspx.cs" Inherits="User_ShoppingCartSelect" %> 

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml"><head id="Head1"><title>
	我的购物车
</title>
<link href="../css/common.css" rel="stylesheet" type="text/css">
<link href="../css/shoppingcart.css" rel="stylesheet" type="text/css">
<script language=javascript src="../Scripts/jquery-1.4.1.js"></script>
<script language="javascript">
    function verifySubmit() {

//        if ($.trim($("#receiver").val()) == "") {
//            alert("请填写收货人");
//            $("#receiver").focus();
//            return false;
//        } else if ($.trim($("#tel").val()) == "") {
//            alert("请填写收货人电话");
//            $("#tel").focus();
//            return false;
//        } else if ($.trim($("#addr").val()) == "") {
//            alert("请填写收货地址");
//            $("#addr").focus();
//            return false;
//        }


    
    }
</script>


</head>
<body>
<div id="shortcut">
	<div class="w">
		<%--<div class="collect"><b></b><a onclick="addToFavorite()" href="javascript:void(0)">收藏光大商城</a></div>--%>
		<ul>
			<li id="loginfo" class="fore1">下午好，<%=username%>！欢迎您来到光大商城！<a href="logout.aspx">[退出]</a></li>
			<li class="fore2"><a href="Userhome.aspx">我的光大</a></li> 
		</ul>
		<span class="clr"></span>
	</div>
</div>
<!--[if lte IE 6]>
<script type="text/javascript">$("#shortcut .sub").hoverForIE6();</script>
<![endif]-->



    <div class="Wrap_cart"> 
	<div class="Header_cart" id="Top1_order_step1">
		
		<ul id="Order_cart_S2" class="Order_cart">
			<li class="step1 s1complete" >1.我的购物车</li>
			<li class="step2">2.填写核对订单信息</li>
			<li class="step3">3.成功提交订单</li>
		</ul>
		
</div>







<%--<div class="mycart_tip" id="Top1_FeeInfo">

<img src="../images/cart_001.gif" id="myCartTipImg">

</div>--%>
	
	<div class="List_cart">
	<h2><strong>填写核对订单信息</strong></h2>
	<div class="cart_table">
	
	 
	
	 <!--商品列表开始-->
    <div id="productList">
<table width="100%" cellspacing="0" cellpadding="0" id="CartTb" class="Table">
<tbody>
  <tr class="align_Center Thead">
    <td width="15%" style="height:30px">商品编号</td>
    <td>商品名称</td>
    <td>优惠价</td>
    <td>商品数量</td> 
    <td>金额</td>
    <td>成交金额</td>
 </tr>


<tr class="cartSpliter"><td colspan="7"></td></tr>
<%for(int i=0;i<details.Count;i++){ %>
<tr class="align_Center suitPromItem">
   <td style="height:30px;"><%=gsrv.GetModel(details[i].goodID).goodNO %></td>
   <td class="align_Left"><div style="margin-left:18px"><span><a clstag="clickcart|keycount|shoppingcartpop|productnamelinklistcart" onclick="this.blur();" href="#" target="_blank"><%=gsrv.GetModel(details[i].goodID).goodName %></a></span></div></td>
   <td><span class="price">￥<%= details[i].goodPrice  %></span></td>

   <!--td></td-->
   <td>
<span><%=details[i].goodQuantity%></span>
</td> 
<td>
<span class="price">￥<%=details[i].goodQuantity * details[i].goodPrice%></span>
</td> 
<td>
<span class="price">￥<%=details[i].finalAmount%></span>
</td> 
</tr>
<%amount=amount +  details[i].finalAmount;
  } %>

       
<%--<tr style="display:none" class="align_Center suitPromTitle">
    <td width="10%" style="height:30px;">-</td>
    <td class="align_Left">
        
    </td>
    <td><span class="price">-</span></td>
    <td>-</td>
    <td>-</td>
    <td>-</td>
    <td>-</td>
</tr>--%>

 <tr>
    <td style="height:30px" colspan="7" class="align_Right Tfoot"><%--重量总计：0.00kg&nbsp;&nbsp;&nbsp;原始金额：￥<%=amount%>元 - 返现：￥0.00元<br><span style="font-size:14px"><b>--%>商品总金额：<span id="cartBottom_price" class="price">￥<%=amount%></span>元</b></span></td>
 </tr>
 <tr><td colspan="6" style="height:30px" class="Tfoot"><strong>默认收货地址</strong></td></tr>
<tr class="align_Center suitPromItem">

    <td >收货人：</td><td><%if (customer != null)
                        {%><%=customer.cusName%><%}
                        else
                        { %>
                        <%=lessee.Name%><%} %></td>

    <td>电话：</td><td><%if (customer != null)
                        {%><%=customer.cusTel %><%}
                        else
                        { %><%=lessee.OfficePhone %><%} %></td>
    <td >地址：</td><td><%if (customer != null)
                        {%><%=customer.cusAddr %><%}
                        else
                        { %><%=lessee.Address%><%} %></td>
 </tr>

 <form action="shoppingCartSubmit.aspx" method="post" onsubmit="return verifySubmit()">
 <tr>
 <td colspan="6" style="height:30px" class="Tfoot"><strong>更改收货信息：</strong></td>
 </tr>
 <tr suitPromItem>
    <td >收货人：</td>
    <td colspan="6"><input type =text name="revciver" id="receiver" style="width:300px;" /></td> 
 </tr>
  <tr suitPromItem>
    <td>收货电话：</td>
    <td colspan="6"><input type =text name="tel" id="tel" /></td> 
 </tr>
  <tr suitPromItem>
    <td>收货地址：</td>
    <td colspan="6"><input type =text name="addr" id="addr" style="width:300px;" /></td> 
 </tr>
<%-- <tr>
    <td>邮编：</td>
    <td colspan="6"><input type =text name="zip" id="zip"  /></td> 
 </tr>--%>
 <tr>
    <td>买家留言：</td>
    <td colspan="6"><textarea name="message" id="message" rows="3" cols="60"></textarea></td> 
 </tr>
  <tr>
    <td colspan="7" align="right">
    <strong>付款方式：</strong><input type="radio" name="paytype" value="1" checked="checked"/><strong>预付款</strong>
    <input type="radio" name="paytype" value="2"/><strong>货到付款</strong>
<%--    <strong>付款方式：</strong>
    <select >
                <option value="" selected>请选择支付方式</option>
                <option value="0">预付款</option>
                <option value="1">货到付款</option>
       </select>--%>


    </td> 
 </tr>

</tbody></table>
</div>
   
    <!--商品列表结束-->
		<ul style="margin-bottom:0px;" class="cart_op">
		    
		    
		    
		    <!--li class="li4"><a href="#none" onclick='this.blur();saveCart();' clstag='clickcart|keycount|shoppingcartpop|savecartlink'>寄存购物车</a></li-->
 
			
			<li class="li3">
			<div id="submit_info">
			</div>
			<div style="text-align:right" id="submit_btn">
			
			<img alt="进入分期订单" style="cursor:pointer;border:none;display:none;" onclick="runOrderInfo_fq(this);" id="gotoOrderInfo_fq" src="http://www.360buy.com/purchase/skin/images/fqbtn.gif">
			 
             <input id="submit" type="submit" value=" " onclick='submitOrder(this);' clstag="checkout|keycount|jiesuan|sumbit" style="margin-top:2px;border:none;cursor:pointer;width:160px;height:53px;background:url(http://www.360buy.com/purchase/skin/images/submit.jpg)"/> 
 
			
			</div>
			<div id="submit_error" style="padding-right:9px;text-align:right;border:#fff 1px solid;"></div>
		 
			 </form>
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
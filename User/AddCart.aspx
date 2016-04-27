<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddCart.aspx.cs" Inherits="User_AddCart" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml"><head><title>
	商品已成功加入购物车
</title>



  <link type="text/css" rel="stylesheet" href="../css/base20100719.w.css">
  <link type="text/css" rel="stylesheet" href="../css/cart.css">
<script src="../js/jquery-1.2.6.pack.js" type="text/javascript"></script>
<script src="../js/g.base.js" type="text/javascript"></script>

 
</head>
<body>
<div id="shortcut">
  <div class="w">
    <div class="collect"></div>
    <ul>
      <li id="loginfo" class="fore1"> 您好，<%=username %>！欢迎来到光大商城！ <span>  </li>
    
      <li> <a href="userhome.aspx">我的光大</a> </li>
    </ul>
    <span class="clr"></span> </div>
</div>
<!--[if lte IE 6]>
<script type="text/javascript">$("#shortcut .sub").hoverForIE6();</script>
<![endif]-->

<!--main start-->
<div class="w main">
	<div class="left">
		<div id="succeed" class="m">
			<div class="corner tl"></div>
			<div class="corner tr"></div>
			<div class="corner bl"></div>
			<div class="corner br"></div>
			<div class="success"><b>商品已成功加入购物车！</b><a class="btn-pay" href="shoppingcart.aspx" id="GotoShoppingCart">去结算</a><a class="btn-continue" href="../Index.aspx">继续购物</a></div>
			<div id="cart_yb"></div>
			
		</div><!--succeed end-->

		
		
		<!--promotion end-->
	</div><!--left end-->
	
		<div class="right-extra">
        <div id="mycart-detail" class="m">
<div class="total">
共<strong><%=count %></strong>件商品<br>
金额总计：<strong>￥<%=amount %></strong>
</div>


</div>
		</div><!--my-cart end-->

	 
	<span class="clr"></span>
</div><!--main end-->
















<div id="footer" class="w">
  <div class="flinks"> <a target="_blank" href="#">关于我们</a> | <a target="_blank" href="#">联系我们</a> | <a target="_blank" href="#">人才招聘</a> </div>
  <div class="copyright"> <a>Copyright 2011-2011 上海光大物业 版权所有.</a> </div>
</div>










<!-- Google Code for &#25105;&#30340;&#36141;&#29289;&#36710; Remarketing List -->




 
 
<!-- 埃森哲统计代码-->






</body></html>
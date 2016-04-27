<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OrderDetail.aspx.cs" Inherits="User_OrderDetail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1">
<title>订单详情-光大商城</title>
<meta http-equiv="Content-Type" content="text/html">
<link type="text/css" rel="stylesheet" href="../css/common20100719.css">
<link type="text/css" rel="stylesheet" href="../css/orderdetail.css">
<script type="text/javascript" src="../js/jquery-1.2.6.pack.js"></script>
<script type="text/javascript" src="../js/g.base.js"></script>
<script type="text/javascript" src="../js/JdHomeCommon.js"></script>
<style type="text/css">
#sc_drag_area_protector div {
	border-radius: 0px 0px;
	margin:0;
	/*max-width:100%;*/
  min-width: 1px;
}
#sc_drag_area {
	height:100px;
	left:150px;
	position: absolute;
	top:100px;
	width:250px;
	z-index: 9999;
}
#sc_drag_container {
	border: 1px solid #0000FF;
	cursor: move;
	height: 100%;
	margin: 0;
	overflow: hidden;
	padding: 0;
	position: relative;
	width: 100%;
	z-index:9997;
}
#sc_drag_area_protector {
	border-radius: 0px 0px;
	display: block;
	height:100%;
	left:0;
	top:0;
	position: absolute;
	width:100%;
	z-index:8500;
	margin: 0;
	min-width: 1px;
	overflow: hidden;
}
#sc_drag_size {
	background-color: rgba(44, 44, 44, 0.5);
	color:#ffffff;
	font-family: arial, san-serif;
	font-weight:bold;
	font-size:12px;
	height:18px;
	min-width:65px !important;
	left:12px;
	line-height:18px;
	position:absolute;
	padding-left:4px;
	padding-right:4px;
	text-align:center;
	top: -18px;
	z-index:9998;
}
#sc_drag_cancel, #sc_drag_crop {
	background-color: rgba(0, 0, 0, 0.5);
	cursor:pointer;
	color:#ffffff;
	font-size:12px;
	font-family: arial, san-serif;
	font-weight:bold;
	height:22px;
	line-height:22px;
	position:absolute;
	z-index:9998
}
#sc_drag_crop {
	bottom:-25px;
	text-align: center;
	right:10px;
	min-width: 30px !important;
	padding: 0 10px;
}
#sc_drag_cancel {
	bottom:-25px;
	text-align: center;
	right:70px;
	min-width: 30px !important;
	padding: 0 10px;
}
#sc_drag_shadow_top, #sc_drag_shadow_bottom, #sc_drag_shadow_left, #sc_drag_shadow_right {
	background-color: #000000;
	opacity: 0.5;
	position: absolute;
	z-index:7000;
	border: 0;
}
#sc_drag_shadow_top {
	left: 0;
	top: 0;
}
#sc_drag_shadow_bottom {
	bottom: 0;
	right: 0;
}
#sc_drag_shadow_left {
	bottom: 0;
	left: 0;
}
#sc_drag_shadow_right {
	right: 0;
	top: 0;
}
#sc_drag_north_east, #sc_drag_north_west, #sc_drag_south_east, #sc_drag_south_west {
	border:1px solid #FFFFFF;
	background-color: #0000FF;
	height: 5px;
	position: absolute;
	width: 5px;
	z-index:9998;
}
#sc_drag_north_east {
	cursor: ne-resize;
	right: -4px;
	top: -3px;
}
#sc_drag_north_west {
	cursor: nw-resize;
	left: -3px;
	top: -3px;
}
#sc_drag_south_east {
	bottom: -4px;
	cursor: se-resize;
	right: -4px;
}
#sc_drag_south_west {
	bottom: -4px;
	cursor: sw-resize;
	left: -3px;
}
.sc_tip_save_status {
	position :fixed;
	border-radius: 4px 4px;
	height: 30px;
	line-height: 30px;
	text-indent: 1em;
	width: 200px;
	background: #fff1a8;
	color: #000000;
	top:5px;
	left:45%;
	font-size: 12px;
}
.sc_tip_save_status a {
	text-decoration: underline;
	color: #2A5DB0;
}
</style>
<script>
	$(function () {
		$("#nav-extra").load("/NavPage.aspx", {}, function () {
			var params = GetUrlParms();
			var type = params["ptype"];
			$("#nav-extra li[rel=" + type + "]").addClass("curr");
		});
		$("#mycart-amount").load("/MyCart.aspx");
	});
</script>
</head>
<body myjd="_MYJD_ordercenter" screen_capture_injected="true">
<div id="shortcut">
  <div class="w">
<%--    <div class="collect"><b></b><a href="javascript:void(0)" onclick="addToFavorite()">收藏光大商城</a></div>--%>
    <ul>
      <li class="fore1" id="loginfo">下午好，<%=username %>！欢迎您来到光大商城！<a href="logout.aspx">[退出]</a></li>
      <li class="fore2"><a href="OrderList.aspx">我的订单</a></li>
      <li><a href="userhome.aspx">我的光大</a></li>

  
    </ul>
    <span class="clr"></span></div>
</div>
<!--[if lte IE 6]><script type="text/javascript">$("#shortcut .sub").hoverForIE6();</script><![endif]-->
<div class="w" id="header">
  <div id="logo"><a href="index.aspx"><img src="../images/logo.jpg" alt="光大商城" ></a></div>
  <div id="nav">
    <div id="nav-index" clstag="homepage|keycount|homepage|home"><a href="../index.apsx">首页</a></div>
    <div id="nav-extra">
     <!-- <ul>
        <li id="nav-pop" class="fore"> <a href="../Renovation/RenovationList.aspx">装修工程</a> <b></b> </li>
        <li id="nav-tuan"> <a href="../Renovation/RenovationList.aspx">保洁服务</a> </li>
        <li id="nav-auction"> <a href="../Cleaner/CleanerList.aspx">绿化租赁</a> </li>
        <li id="nav-read"> <a href="../delivery/deliveryList.aspx">快递服务</a> </li>
        <li id="nav-club"> <a href="../dinner/dinnerList.apsx">订餐服务</a> </li>
        <li id="nav-category"> <a href="../travel/travelList.apsx">商务旅行</a> </li>
		<li id="nav-category"> <a href="../wanter/waterList.aspx">饮水配送</a> </li>
      </ul>
	  -->
      <div class="corner"></div>
    </div>
  </div>
  <span class="clr"></span>
  <div id="o-search">
    <div class="allsort">
      <div class="mt"><strong><a href="../goods/goodsList.aspx">全部商品分类</a></strong>
        <div class="extra">&nbsp;</div>
      </div>
      <div class="mc" id="_JD_ALLSORT"></div>
    </div>
    <div id="search" class="form">
      <div id="i-search">
        <input type="text" id="key" value="" autocomplete="off" onkeydown="javascript:if(event.keyCode==13) search('key');">
        <ul id="tie" class="hide">
        </ul>
      </div>
      <input type="submit" value="搜&nbsp;索" id="btn-search" onclick="search('key');return false;">
    </div>
    
    <ul id="mycart">
      <li class="fore1" id="i-mycart"><a href="shoppingcart.aspx">购物车<b id="mycart-amount"></b></a>
        <div id="o-mycart-list" class="hide">
          <div id="mycart-list"></div>
        </div>
      </li>
      <li class="fore2"><a href="../ShoppingCart.aspx">去结算</a></li>
    </ul>
    <span class="clr"></span></div>
</div>
<div class="w">
  <div id="Position" class="margin_b6"><a href="../index.aspx">首页</a>&nbsp;&gt;&nbsp;>&nbsp;&gt;&nbsp;<a href="OrderList.aspx">订单中心</a>&nbsp;&gt;&nbsp;<span>订单：<%=order.orderNO %></span></div>
  <input id="orderid" value="117580757" type="hidden">
  <input id="ordercounty" value="3411" type="hidden">
  <input id="orderprovince" value="15" type="hidden">
  <input id="ordercity" value="1213" type="hidden">
  <input id="orderdatesubmit" value="2011-11-25 12:51:00" type="hidden">
  <div class="m" id="orderstate">
    <div class="mt"> <strong>订单号：<%=order.orderNO %>&nbsp;&nbsp;&nbsp;&nbsp;状态：<span class="ftx14"><%=Constants.orderStatus(order.orderStatus)%></span></strong>
   
    </div>
    <div class="mc"> </div>
  </div>
  <div class="m" id="ordertrack">
    <ul class="tab">
      <li class="curr" clstag="click|keycount|orderinfo|ordertrack">
        <h2> 订单信息</h2>
      </li> 
    </ul>
    <div class="clr"></div>
    <div class="mc tabcon"> 
    <div class="mc tabcon hide">
      <table cellpadding="0" cellspacing="0" width="100%">
        <tbody>
          
          <tr>
            <td> 商品金额：￥38.00 </td>
            <td> 运费金额：￥5.00 </td>
          </tr>
          <tr>
            <td> 优惠金额：￥11.00 </td>
            <td> 实际运费：￥5.00 </td>
          </tr>
          <tr>
            <td> 应支付金额：￥32.00 </td>
            <td> 交易余额：￥0.00 </td>
          </tr>
          <tr>
            <td></td>
            <td></td>
          </tr>
        </tbody>
      </table>
    </div>
    
  </div>
 
  <div class="m" id="orderinfo">
    <div class="mt"> <strong>订单信息</strong></div>
    <div class="mc">
      <dl class="fore">
        <dt>收货人信息</dt>
        <dd>
          <ul>
            <li>收&nbsp;货&nbsp;人：<%=order.Receiver %></li>
            <li>地&nbsp;&nbsp;&nbsp;&nbsp;址：<%=order.addr %></li>
            <li>联系电话：<%=order.Tel %></li>  
          </ul>
        </dd>
      </dl>

      <dl class="fore">
        <dt>收货信息</dt>
        <dd>
          <ul>
            <li>签&nbsp;收&nbsp;人：<%=order.signer %></li>
            <li>物&nbsp;&nbsp;&nbsp;&nbsp;流：<%=order.deliveryInfo %></li> 
          </ul>
        </dd>
      </dl>
       
      <!--普通订单-->
      <dl>
        <dt>商品清单</dt>
        <dd class="p-list">
          <table cellpadding="0" cellspacing="0" width="100%">
            <tbody>
              <tr>
                <th width="10%"> 商品编号 </th>
                <th width="47%"> 商品名称 </th>
                <th width="10%"> 优惠价 </th>
 <%--               <th width="8%"> 已优惠 </th>--%>
<%--                <th width="7%"> 赠送积分 </th>--%>
                <th width="7%"> 商品数量 </th>
                
              </tr>

              <%for (int i = 0; i < details.Count;i++ ) {  %>
              <tr>
                <td> <%= gsrv.GetModel(details[i].goodID).goodNO %> </td>
                <td><div class="al fl"> <a class="flk13" target="_blank" href="../Goods/goodsDetail.aspx?id=<%= details[i].goodID %>" clstag="click|keycount|orderinfo|product_name"> <%=gsrv.GetModel(details[i].goodID).goodName%> </a> </div>
                 </td>
                <td><span class="ftx04"> ￥<%=details[i].goodPrice%></span></td>
               <%-- <td><span class="ftx04"><%=(float.Parse(gsrv.GetModel(details[i].goodID).goodPrice.ToString() )- details[i].goodPrice )%></span></td>--%>
                <td> <%= details[i].goodQuantity %></td>
                <%--<td> 1 </td> --%>
              </tr>
              <%} %>
            </tbody>
          </table>
        </dd>
      </dl> 
    </div>
    <div class="total">
    <div>
    <span><strong>您的留言：</strong><%=order.message %></span>
    </div>
    <div>
    <span><strong>客服回复：</strong><%=order.reply %></span>
    </div>
    </div>
    <!--付款信息-->
    <div class="total">
      <ul>
        <li><span>商品总金额：</span>￥<%= amount %></li>  
        <!--货到付款或自提的，并且未出库 返价宝金额-->
      </ul> 
      <div class="extra"> 订单支付金额：<span class="ftx04"><b>￥<%= finalmomey%></b></span></div>
   
    </div>
  </div>

</script>
</div>


<div id="footer" class="w">
  <div class="flinks"> <a target="_blank" href="#">关于我们</a> | <a target="_blank" href="#">联系我们</a> | <a target="_blank" href="#">人才招聘</a> </div>
  <div class="copyright"> <a>Copyright 2011-2011 上海光大物业 版权所有.</a> </div>
</div>




<script type="text/javascript">
    //$("#ordertrack").jdTab();
    $("#ordertrack").jdTab({ event: "click" })
    </script>


</body>
</html>
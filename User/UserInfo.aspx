<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserInfo.aspx.cs" Inherits="User_UserInfo" %> 

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
        "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta content="text/html; charset=utf-8" http-equiv="Content-Type">
<link href="../css/base20100719.css" rel="stylesheet" type="text/css">
<link href="../css/user.base.css" rel="stylesheet" type="text/css">
<link href="../css/user.index.css" rel="stylesheet" type="text/css">
<script src="../js/jquery-1.2.6.pack.js" type="text/javascript"></script>
<script src="../js/g.base.js" type="text/javascript"></script>
<style type="text/css">
#headcolse {
	display: none;
}
#headcon {
	padding: 0;
	border: 6px solid #999;
}
</style>
<title>我的光大</title>
</head>
<body>
<div id="shortcut">
  <div class="w">
    <div class="collect"><b></b><a onclick="addToFavorite()" href="javascript:void(0)">收藏光大商城</a></div>
    
    <ul>
    
      <li id="loginfo" class="fore1">下午好，<%=customer.cusLoginName%><%= les.Name%>！欢迎您来到光大商城！<a href="logout.aspx">[退出]</a></li>
      
      <li class="fore2"><a href="OrderList.aspx">我的订单</a></li>
      <li><a href="Userhome.aspx">我的光大</a></li>
    </ul>
    <span class="clr"></span> </div>
</div>
<!--[if lte IE 6]><script type="text/javascript">$("#shortcut .sub").hoverForIE6();</script><![endif]-->
<div id="header" class="w">
  <div id="logo"><a href="#"><img alt="光大商城" src="../images/logo.jpg"></a></div>
  <div id="nav">
    <div id="nav-index"><a href="../INDEX.ASPX">首页</a></div>
    <div id="nav-extra">
      <ul>
        <li id="nav-pop" class="fore"> <a href="#">装修工程</a> <b></b> </li>
        <li id="nav-tuan"> <a href="../Cleaner/CleanerList.aspx">保洁服务</a> </li>
        <li id="nav-auction"> <a href="../Green/greenList.aspx">绿化租赁</a> </li>
        <li id="nav-read"> <a href="../Delivery/deliveryList.aspx">快递服务</a> </li>
        <li id="nav-club"> <a href="../dinner/dinnerList.aspx">订餐服务</a> </li>
        <li id="nav-category"> <a href="../travel/travelList.aspx">商务旅行</a> </li>
		<li id="nav-category"> <a href="../water/waterList.aspx">饮水配送</a> </li>
        <li id="nav-category"> <a href="../goods/GoodsList.aspx">办公用品</a> </li>
	 </ul>
      <div class="corner"></div>
    </div>
  </div>
  <span class="clr"></span>
  <div id="o-search">
    <div class="allsort">
      <div class="mt"><strong><a href="../goodsList.aspx">全部商品分类</a></strong>
        <div class="extra">&nbsp;</div>
      </div>
      <div id="_JD_ALLSORT" class="mc">
         
         
        <div class="extra"><a href="../goodsList.aspx">全部商品分类</a></div>
      </div>
    </div>
    <div class="form" id="search">
      <div id="i-search">
        <input type="text" onkeydown="javascript:if(event.keyCode==13) search('key');" autocomplete="off" value="" id="key">
        <ul class="hide" id="tie">
        </ul>
      </div>
      <input type="submit" onclick="search('key');return false;" id="btn-search" value="搜&nbsp;索">
    </div>
 
    <ul id="mycart">
      <li id="i-mycart" class="fore1"><a href="shoppingcart.aspx">购物车<b id="mycart-amount"></b></a>
        <div class="hide" id="o-mycart-list">
          <div id="mycart-list"></div>
        </div>
      </li>
      <li class="fore2"><a href="ShoppingCart.aspx">去结算</a></li>
    </ul>
    <span class="clr"></span></div>
</div>
<div class="w">
  <div class="crumb"><a href="../index.aspx">首页</a>&nbsp;&gt;&nbsp;<span>我的光大</span></div>
</div>
<div class="w main">
  <div class="right">
    <div id="userinfo" class="m m3">
       
      <!--user-->
      <div id="i-userinfo">
        <div class="username">
          <div id="userinfodisp" class="fl ftx-03"><strong><%=customer.cusName%></strong>,欢迎您！</div>
          <div id="jdTask" class="extra"></div>
        </div>
        <div class="account">
          <div class="member" id="memberInfo">
            <div clstag="click|keycount|myhome|currentclass" class="rank r1"><s></s><a href="#" target="_blank"><%=customerLevel%></a></div>
          </div>
        </div>
        <!--end-->
        <div id="remind">
          <div class="oinfo">
            <dl class="fore">
              <dt>订单提醒：</dt>
              <dd><span clstag="click|keycount|myhome|ordercount" id="orderCount"><a href="orderLIst.aspx?orderStatus=1" class="flk-03">待处理订单(0)</a></span></dd>
            </dl>
      <!--  
		<dl>
              <dt>消息：</dt>
              <dd><a href="#" clstag="click|keycount|myhome|messageCount" id="messageCountHref">提醒/通知：(<span id="messageCount">1</span>)</a></dd>
            </dl>
        -->
		</div>
          <div class="ainfo">
            <dl class="fore">
              <dt>账户余额：</dt>
              <dd><a class="flk-01" clstag="click|keycount|myhome|yue" href="UserInfo.aspx"><span id="divBalance"><strong class="ftx-03">￥0.00</strong></span></a></dd>
            </dl>
          </div>
        </div>
      </div>
    </div>
    <!--userinfo-->
    <!--reco-area-->
    <div class="clr"></div>
    <!--con-area-->
    <!--buy-area-->
    <div class="middle">
      <div class="m m2" id="atte-area"> </div>
    </div>
    <!--middle-->
    <div class="right-extra">
      <div id="prod-area" class="m m2"> </div>
    </div>
    <!--right-extra-->
    <div class="clr"></div>
  </div>
  <!--right-->
  <div class="left">
    <div id="my360buy" class="m">
      <div class="mt">
        <h2><a href="../index.aspx">我的光大</a></h2>
         
      </div>
      <div class="mc">
       <!--
	   <dl tag="1">
          <dt tag="1">订单中心<b></b></dt>
          <dd>
          
           
          </dd>
        </dl>
       -->
        <dl tag="2">
          <dt tag="2">账户中心<b></b></dt>
          <dd>
            <div id="_MYJD_personal" class="item"><a href="userInfo.aspx" tag="201">账户信息</a></div>
			  <div id="_MYJD_ordercenter" class="item"><a href="OrderList.aspx" tag="101">我的订单</a></div>
        <!--    <div id="_MYJD_balance" class="item"><a href="#" tag="202">账户余额</a></div>
            <div id="_MYJD_notes" class="item"><a href="#" tag="209">消费记录</a></div>
			-->
          </dd>
        </dl>
		
		
      </div>
    </div>
  </div>
  <!--left-->
  <div class="clr"></div>
</div>
 
<div id="footer" class="w">
  <div class="flinks"> <a target="_blank" href="#">关于我们</a> | <a target="_blank" href="#">联系我们</a> | <a target="_blank" href="#">人才招聘</a> </div>
  <div class="copyright"> <a>Copyright 2011-2011 上海光大物业 版权所有.</a> </div>
</div>
<script src="../js/jd.lib.js" type="text/javascript"></script>
<script src="../js/jdmenus.min.js" type="text/javascript"></script>
</body>
</html>

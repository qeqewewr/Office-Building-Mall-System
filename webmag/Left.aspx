<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Left.aspx.cs" Inherits="webmag_Left" %> 

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
 <html>
<head>
    <title>My JSP 'left.jsp' starting page</title>    
<style type="text/css">
<!--
*{margin:0;padding:0;border:0;}
body {
 font-size:12px;
}
#nav {
 width:166px;
 line-height: 20px;
 list-style-type: none;
 text-align:left;
}
#nav a {
 width: 121px;
 display: block;
 padding-left:45px;
 /*Width(一定要)，否则下面的Li会变形*/
}
#nav li {

 background-image:url(images/out.gif);
 float:left;
 BORDER-RIGHT: #8c8c8c 1px solid;
 BORDER-TOP: #dbfe99 1px solid;
 FONT-WEIGHT: bold;
 FONT-SIZE: 12px;
 PADDING-BOTTOM: 2px;
 BORDER-LEFT: #dbfe99 1px solid;
 CURSOR: hand;
 COLOR: black;
 PADDING-TOP: 4px;
 BORDER-BOTTOM: #8c8c8c 1px solid;
 
 /*float：left,本不应该设置，但由于在Firefox不能正常显示
 继承Nav的width,限制宽度，li自动向下延伸*/
}
#nav li a:hover{
 background-image:url(images/hover.gif); /*一级目录onMouseOver显示的背景色*/
}
#nav a:link  {
 color:#fff; text-decoration:none;
}
#nav a:visited  {
 color:#fff;text-decoration:none;
}
#nav a:hover  {
 background-image:url(images/hover.gif) no-repeat; /*一级目录onMouseOver显示的背景色*/
}
/*=========二级目录=========*/
#nav li ul {
 list-style:none;
 text-align:left;
 
}
#nav li ul li{ 
 BORDER-RIGHT: #cccccc 1px solid;
 BORDER-TOP: white 1px solid;
 FONT-SIZE: 12px;
 PADDING-BOTTOM: 2px;
 BORDER-LEFT: white 1px solid;
 CURSOR: hand;
 PADDING-TOP: 2px;
 BORDER-BOTTOM: #cccccc 1px solid;
 BACKGROUND-COLOR: #eeeeee; /*二级目录的背景色*/
 background-image:url();
}
#nav li ul a{
         padding-left:45px;
         width:119px;
		 background-image:url(images/submenu.gif);
 /* padding-left二级目录中文字向右移动，但Width必须重新设置=(总宽度-padding-left)*/
}
/*下面是二级目录的链接样式*/
#nav li ul a:link  {
 color:#666; text-decoration:none;
}
#nav li ul a:visited  {
color:#666;text-decoration:none;
}
#nav li ul li a:hover {
 
 text-decoration:none;
 font-weight:normal;
}
/* www.codefans.net */
#nav li:hover ul {
 left: auto;
}
#nav li.sfhover ul {
 left: auto;
}
#content {
 clear: left;
}
#nav ul.collapsed {
 display: none;
}
-->
#PARENT{
 width:165px; 
}
 

</style>
<script type="text/javascript" src="Scripts/jquery-1.4.1.min.js"></script>
<script type=text/javascript>
    var LastLeftID = "";
    function menuFix() {

        var obj1 = document.getElementById("nav");

        var obj = obj1.getElementsByTagName("li");

        for (var i = 0; i < obj.length; i++) {
            obj[i].onmouseover = function () {
                this.className += (this.className.length > 0 ? " " : "") + "sfhover";
            }
            obj[i].onMouseDown = function () {
                this.className += (this.className.length > 0 ? " " : "") + "sfhover";
            }
            obj[i].onMouseUp = function () {
                this.className += (this.className.length > 0 ? " " : "") + "sfhover";
            }
            obj[i].onmouseout = function () {
                this.className = this.className.replace(new RegExp("( ?|^)sfhover\\b"), "");
            }
        }
    }
    function DoMenu(emid) {
        var obj = document.getElementById(emid);
        obj.className = (obj.className.toLowerCase() == "expanded" ? "collapsed" : "expanded");
        if ((LastLeftID != "") && (emid != LastLeftID)) //关闭上一个Menu
        {
            document.getElementById(LastLeftID).className = "collapsed";
        }
        LastLeftID = emid;
    }
    function GetMenuID() {
        var MenuID = "";
        var _paramStr = new String(window.location.href);
        var _sharpPos = _paramStr.indexOf("#");

        if (_sharpPos >= 0 && _sharpPos < _paramStr.length - 1) {
            _paramStr = _paramStr.substring(_sharpPos + 1, _paramStr.length);
        }
        else {
            _paramStr = "";
        }

        if (_paramStr.length > 0) {
            var _paramArr = _paramStr.split("&");
            if (_paramArr.length > 0) {
                var _paramKeyVal = _paramArr[0].split("=");
                if (_paramKeyVal.length > 0) {
                    MenuID = _paramKeyVal[1];
                }
            }
        }

        if (MenuID != "") {
            DoMenu(MenuID)
        }
    }
    $(function(){
        GetMenuID(); //*function顺序要注意，否则在Firefox里GetMenuID()不起效果。
        menuFix();
    });
   
</script>
  </head>
  
  <body style="background-image:url(images/bg.gif);background-repeat:repeat-x;background-color: #BFE8EE; width:165px;">
   <div id="PARENT">
<ul id="nav">

<%--<li><a href="#Menu=agreements"  onclick="DoMenu('agreements')">商城协议</a>
     <ul id="agreements" class="collapsed">
     <li><a href="Agreements/AddAgreement.aspx" target="mainFrame">新增协议</a></li>
     <li><a href="Agreements/ListAgreements.aspx?pageno=1" target="mainFrame">协议列表</a></li> 
     </ul>
</li>

<li><a href="#Menu=advertisement"  onclick="DoMenu('advertisement')">广告设置</a>
     <ul id="advertisement" class="collapsed">
     <li><a href="Advertisement/SetAdvertisement.aspx" target="mainFrame">首页广告设置</a></li>
     </ul>
</li>--%>

<%--<li><a href="#Menu=cleaner"  onclick="DoMenu('cleaner')">保洁服务</a>
     <ul id="cleaner" class="collapsed">
     <li><a href="Cleaner/AddCleaner.aspx" target="mainFrame">新增服务</a></li>
     <li><a href="Cleaner/ListCleaner.aspx?pageno=1" target="mainFrame">服务列表</a></li>  
     </ul>
</li>

<li><a href="#Menu=travel"  onclick="DoMenu('travel')">商务旅游</a>
     <ul id="travel" class="collapsed">
     <li><a href="Travel/AddTravel.aspx" target="mainFrame">新增旅游</a></li>
     <li><a href="Travel/ListTravel.aspx?pageno=1" target="mainFrame">旅游列表</a></li>  
     </ul>
</li>

<li><a href="#Menu=delivery"  onclick="DoMenu('delivery')">快递服务</a>
     <ul id="delivery" class="collapsed">
     <li><a href="Delivery/AddDelivery.aspx" target="mainFrame">新增快递</a></li>
     <li><a href="Delivery/ListDelivery.aspx?pageno=1" target="mainFrame">快递列表</a></li>  
     </ul>
</li>

<li><a href="#Menu=reservation"  onclick="DoMenu('reservation')">订餐服务</a>
     <ul id="reservation" class="collapsed">
     <li><a href="Reservation/AddReservation.aspx" target="mainFrame">新增餐饮</a></li>
     <li><a href="Reservation/ListReservation.aspx?pageno=1" target="mainFrame">餐饮列表</a></li>  
     </ul>
</li>
<li><a href="#Menu=drinking"  onclick="DoMenu('drinking')">饮水配送</a>
     <ul id="drinking" class="collapsed">
     <li><a href="Drinking/AddDrinking.aspx" target="mainFrame">新增配送中心</a></li>
     <li><a href="Drinking/ListDrinking.aspx?pageno=1" target="mainFrame">配送中心列表</a></li>  
     </ul>
</li>

<li><a href="#Menu=greenleasing"  onclick="DoMenu('greenleasing')">绿化租赁</a>
     <ul id="greenleasing" class="collapsed">
     <li><a href="GreenLeasing/AddGreenLeasing.aspx" target="mainFrame">新增绿化租赁</a></li>
     <li><a href="GreenLeasing/ListGreenLeasing.aspx?pageno=1" target="mainFrame">绿化租赁列表</a></li>  
     </ul>
</li>--%>

<%--<li><a href="#Menu=goods"  onclick="DoMenu('goods')">商品管理</a>
     <ul id="goods" class="collapsed">
     <li><a href="Goods/AddGoods.aspx" target="mainFrame">新增商品</a></li>
     <li><a href="Goods/ListGoods.aspx" target="mainFrame">商品列表</a></li>
     <li><a href="Goods/AddGoodType.aspx" target="mainFrame">新增商品类别</a></li>
     <li><a href="Goods/ListGoodType.aspx" target="mainFrame">商品类别列表</a></li> 
     </ul>
</li>
<li><a href="#Menu=order"  onclick="DoMenu('order')">订单管理</a>
     <ul id="order" class="collapsed">
     <li><a href="Order/AutOrderList.aspx?pageno=1" target="mainFrame">订单审核</a></li>
     <li><a href="Order/ListOrder.aspx?pageno=1" target="mainFrame">订单查看</a></li>
     </ul>
</li>
<li><a href="#Menu=customer"  onclick="DoMenu('customer')">用户管理</a>
     <ul id="customer" class="collapsed">
     <li><a href="CustomerManage/ListCustomer.aspx?pageno=1" target="mainFrame">个人用户列表</a></li>
     </ul>
</li>
<li><a href="#Menu=prepayment"  onclick="DoMenu('prepayment')">预付款管理</a>
     <ul id="prepayment" class="collapsed">
     <li><a href="PrepaymentManage/ListClient.aspx?pageno=1&client=1" target="mainFrame">企业列表</a></li>
     <li><a href="PrepaymentManage/ListClient.aspx?pageno=1&client=0" target="mainFrame">个人用户列表</a></li>
     </ul>
</li>

<li><a href="#Menu=permission"  onclick="DoMenu('permission')">权限管理</a>
     <ul id="permission" class="collapsed">
     <li><a href="PermissionManage/ListPermission.aspx?pageno=1" target="mainFrame">修改员工权限</a></li>
     </ul>
</li>--%>


<%
    for (int i = 0; i < bigFunctionList.Count; i++)
    {%>
    <li>
        <a href="#Menu=<%=bigFunctionList[i].Code%>"  onclick="DoMenu('<%=bigFunctionList[i].Code%>')"><%=bigFunctionList[i].FullName%></a>
        <ul id="<%=bigFunctionList[i].Code%>" class="collapsed">
        <%for (int j = 0; j < functionList.Count; j++)
          {
              if(functionList[j].ParentID == bigFunctionList[i].ID)
              {%>
                  <li><a href="<%=functionList[j].NavigateUrl%>" target="mainFrame"><%=functionList[j].FullName%></a></li>
             <% }
          }%>
        </ul> 
     </li>
   <% }%>

   <li><a href="#Menu=account"  onclick="DoMenu('account')">账户设置</a>
     <ul id="account" class="collapsed">
     <%--<li><a href="PasswordManage/updateName.aspx?mark=0" target="mainFrame">用户名修改</a></li>--%>
     <li><a href="PasswordManage/updatePassword.aspx?mark=1" target="mainFrame">密码修改</a></li>
     </ul>
</li>

</ul>
</div>
  </body>
</html>

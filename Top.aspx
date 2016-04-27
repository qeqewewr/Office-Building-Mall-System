<%--<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Top.aspx.cs" Inherits="Top" %>--%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
    <link href="css/index.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="js/jquery-1.4.3.min.js"></script>
    <script type="text/javascript" src="js/jcarousellite_1.0.1.js"></script>
	<script>
		function GetUrlParms() {
			var args = new Object();
			var query = location.search.substring(1);
			//获取查询串   
			var pairs = query.split("&");
			//在逗号处断开   
			for (var i = 0; i < pairs.length; i++) {
				var pos = pairs[i].indexOf('=');
				//查找name=value   
				if (pos == -1) continue;
				//如果没有找到就跳过   
				var argname = pairs[i].substring(0, pos);
				//提取name   
				var value = pairs[i].substring(pos + 1);
				//提取value   
				args[argname] = unescape(value);
				//存为属性   
			}
			return args;
		}

		$(function () {
			$("#_JD_ALLSORT").load("/GoodTypePage.aspx", {}, function () {

				$("#_JD_ALLSORT div.item").mouseover(function () {

					$("#_JD_ALLSORT div.item").removeClass('hover');

					if ($(this).attr("finish") == "0") {
						var pid = $(this).attr("pid");
						//	console.log(pid);
						$(this).find("dd").load("/GoodTypePage.aspx?pid=" + pid);
						$(this).attr('finish', '1');
					}
					if ($(this).find("em").length > 0)
						$(this).addClass('hover');

				}).mouseout(function () {
					$(this).removeClass('hover');
				});



				var height = $("#_JD_ALLSORT").innerHeight();
				$("#sales").css("marginTop", height);
			});

			$("#nav-extra").load("/NavPage.aspx", {}, function () {
				var params = GetUrlParms();
				var type = params["ptype"];
				$("#nav-extra li[rel=" + type + "]").addClass("curr");
			});

			$("#loginState").load('/LoginStatePage.aspx');
			$("#mycart-amount").load('/MyCart.aspx');

});

function search(obj) {
    var key = $.trim($("#" + obj).val());
    window.open("/goods/goodsList.aspx?keyword=" + key, "search", "top=0,left=0, toolbar=yes,menubar=yes, scrollbars=yes, resizable=yes,location=yes, status=yes");
}


	</script>
</head>
<body>
    <!--页面头-->
	<div  style="display:none" id="loginState"></div>
    <div id="shortcut">
        <div class="w">
            <div class="collect">
            <!--    <b></b><a href="javascript:void(0)" onclick="addToFavorite()">收藏光大商城</a>   -->
            </div>
            <ul>
                <li id="loginfo" class="fore1">
					您好，欢迎来到光大商城！ <span><a href="/User/Login.aspx">[请登录]</a>
                    ，新用户？ <a class="link-regist" href="/user/Register.aspx">[免费注册]</a> </span>
					
					</li>
      
            <!--    <li><a href="/user/userhome.aspx">我的光大</a> </li>   -->
            </ul>
            <span class="clr"></span>
        </div>
    </div>
    <!--主体头-->
    <div id="header" class="w">
        <div id="logo">
            <a href="http://localhost:8011/Index/IndexPage.aspx">
                <img src="/images/logo.jpg" alt="光大商城" />
            </a>
        </div>
        <div id="nav">
            <div id="nav-index">
                <a href="/index.aspx">首页</a>
            </div>
            <div id="nav-extra">

          
            </div>
        </div>
        
        <span class="clr"></span>
        <div id="o-search">
            <div class="allsort">
                <div class="mt">
                   <!-- <strong><a href="/goods/allSort.aspx">全部商品分类</a> </strong>  -->
                    <strong><a href="#">全部商品分类</a> </strong>
                    <!-- <div class="extra">&nbsp;</div> -->
                </div>
                <div id="_JD_ALLSORT" class="mc" clstag="homepage|keycount|homepage|06b" load="2">
		
			 
			    </div>
            </div>
            <div id="search" class="form">
                <div id="i-search">
                    <input id="key" type="text" autocomplete="off" onkeydown="javascript:if(event.keyCode==13) search('key');">
                    <ul id="tie" class="hide">
                    </ul>
                </div>
                <input id="btn-search" type="submit" value="搜 索" onclick="search('key');return false;">
            </div>

            <ul id="mycart">
                <li id="i-mycart" class="fore1" load="true"><a href="/user/ShoppingCart.aspx">
                    购物车 <b id="mycart-amount">0</b> 件 </a>
                    <div id="o-mycart-list" class="hide" style="display: none;">
                    </div>
                </li>
                <li class="fore2"><a href="/user/ShoppingCart.aspx">去结算</a>
                </li>
            </ul>
            <span class="clr"></span>
        </div>
    </div>
</body>
</html>


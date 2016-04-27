<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Fee.aspx.cs" Inherits="Fee" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>光大物业电子商城</title>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
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
<!--主体内容-->
   <!--页面头-->
    <div  style="display:none" id="loginState"></div>
    <div id="shortcut">
        <div class="w">
            <div class="collect">
            <!--    <b></b><a href="javascript:void(0)" onclick="addToFavorite()">收藏光大商城</a>   -->
            </div>
            <ul>
                <li id="loginfo" class="fore1">
					您好，欢迎来到物盟商城！ <span><a href="User/Login.aspx">[请登录]</a>
                    ，新用户？ <a class="link-regist" href="user/Register.aspx">[免费注册]</a> </span>
					
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
                <img src="images/logo.jpg" alt="物盟商城" />
            </a>
        </div>
        <div id="nav">
            <div id="nav-index">
                <a href="index.aspx">首页</a>
            </div>
            <div id="nav-extra">

          
            </div>
        </div>
        
        <span class="clr"></span>
        <div id="o-search">
            <div class="allsort">
                <div class="mt">
                   <!-- <strong><a href="/goods/allSort.aspx">全部商品分类</a> </strong>  -->
                    <strong><a href="goods/goodsList.aspx">全部商品分类</a> </strong>
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
                <li id="i-mycart" class="fore1" load="true"><a href="user/ShoppingCart.aspx">
                    购物车 <b id="mycart-amount">0</b> 件 </a>
                    <div id="o-mycart-list" class="hide" style="display: none;">
                    </div>
                </li>
                <li class="fore2"><a href="user/ShoppingCart.aspx">去结算</a>
                </li>
            </ul>
            <span class="clr"></span>
        </div>
    </div>
    <div class="w">
       <div class="crumb"><a href="index.aspx">首页</a>&nbsp;&gt;&nbsp;<span>我的光大</span></div>
    </div>
    <div class="w main">
    <div class="left">
             <div id="my360buy" class="m">
                   <div class="mt">
                        <h2><a href="index.aspx">我的光大</a></h2>
                   </div>
                   <div class="mc" id="accountCenter">
                        <dl tag="1">
                          <dt tag="1"><a href="User/UserHome.aspx">我的光大</a><b></b></dt>
                          <dd>
                            <div id="_MYJD_ordercenter" class="item"><a href="User/OrderList.aspx" tag="101">我的订单</a></div>
                            <div id="_MYJD_notes" class="item"><a href="User/ConsumeOrder.aspx" tag="209">消费记录</a></div>
			                <div id="_MYJD_changepwd" class="item"><a href="User/ChangePwd.aspx" tag="209">修改密码</a></div>
                          </dd>
                        </dl>
                     </div>
                </div>
            </div>
        </div>
      <%--  <div class="right-extra">
                    <h2>你当前的欠费情况如下：</h2>
            <form id="form1" runat="server">
                <div>
                    <asp:GridView ID="GridView1" runat="server" DataKeyNames="ID" onselectedindexchanged="GridView1_SelectedIndexChanged" 
                            Height="132px" Width="737px">
                        <Columns>
                            <asp:TemplateField></asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
                <div align="center">
                <asp:Button ID="btn" runat="server" Text="确认缴费"/>
                </div>
            </form>
        </div>   
        <div class="clr"></div>  --%>
<!--main-->

        <div id="footer" class="w">
        <div class="flinks"> <a target="_blank" href="#">关于我们</a> | <a target="_blank" href="#">联系我们</a> | <a target="_blank" href="#">人才招聘</a> </div>
        <div class="copyright"> <a>Copyright 2011-2011 上海光大物业 版权所有.</a> </div>
    </div>
</body>
</html>
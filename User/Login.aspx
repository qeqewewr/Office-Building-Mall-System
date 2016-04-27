<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="User_Login" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns:xn="http://www.renren.com/2009/xnml" xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">


<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7">
<meta http-equiv="pragma" content="no-cache">
<meta http-equiv="Cache-Control" content="no-cache, must-revalidate">
<meta http-equiv="expires" content="0">
<title>登录光大商城</title>

<link rel="stylesheet" type="text/css" href="../css/login.css" media="all" />

<script type="text/javascript" src="../js/jquery-1.2.6.pack.js"></script>

<script type="text/javascript" src="../js/g.base.js"></script> 
    <script type="text/javascript" src="../js/jquery-1.4.3.min.js"></script> 
    <script type="text/javascript"  >
    function verifySubmit(){
        if($.trim($("#loginname").val()) == ""){
            alert("对不起，请输入登录帐号！");
            $("#loginname").focus();
            return false;
        }else if($.trim($("#loginpwd").val()) == ""){
            alert("对不起，请输入登录密码！");
            $("#loginpwd").focus();
            return false;
        }
        return true;
    }
    </script> 
</head>
<body>
<div id="shortcut"><%--<div class="w"><div class="collect"><b></b><a href="javascript:void(0)" onclick="addToFavorite()">收藏光大商城</a></div>--%><ul><li class="fore1" id="loginfo">您好，欢迎来到光大商城！新用户？<a href="register.aspx" class="link-regist">[个人用户注册]</a></li><li class="fore2"></li></ul><span class="clr"></span></div></div><!--[if lte IE 6]><script type="text/javascript">$("#shortcut .sub").hoverForIE6();</script><![endif]-->
<div class="w" id="logo">
	<div><a href="../index.aspx"><img src="../images/logo.jpg" alt="光大商城" ></a></div>
</div>

<div class="w" id="entry">
	<div class="mt">
		<h2>用户登录</h2>
		<b></b>
	</div>
     
	<div class="mc" style="padding-top: 20px;">		
		<div class="form">
        <form action="verifyLogin.aspx" method="post" onsubmit="return verifySubmit()" />
            <div class="item">
				<span class="label">用户类型：</span>
				<div class="fl">
					<select name="loginType">
                        <option value="1">企业用户</option>
                        <option value="2">个人用户</option>
                    </select>
					<label id="Label1" class="blank invisible"></label>
					<span class="clr"></span>
					<label class="null" id="Label2"></label>
				</div>
			</div>
			<div class="item">
				<span class="label">用户名：</span>
				<div class="fl">
					<input sta="0" id="loginname" name="loginname" class="text" tabindex="1" value="" type="text">
					<label id="loginname_succeed" class="blank invisible"></label>
					<span class="clr"></span>
					<label class="null" id="loginname_error"></label>
				</div>
			</div>
			<div class="item">
				<span class="label">密码：</span>
				<div class="fl">
					<input id="loginpwd" name="loginpwd" class="text" tabindex="2" type="password">
					<label id="loginpwd_succeed" class="blank invisible"></label>
					<label><a href="#" class="flk13">忘记密码?</a></label>
					<span class="clr"></span>
					<label id="loginpwd_error"></label>
				</div>
			</div>
			<div class="item hide" id="o-authcode">
				<span class="label">验证码：</span>
				<div class="fl">
					<input value="" id="authcode" name="authcode" class="text text-1" tabindex="6" type="text">
					<label class="img">
                    <img id="JD_Verification1" ver_colorofnoisepoint="#888888" onclick="this.src='JDVerification.aspx?&amp;uid=87e2fb42-bfa9-41a6-80a8-4e66b4db9d98&amp;yys='+new Date().getTime()" src="jdverification.aspx" alt="" style="cursor: pointer; width: 100px; height: 26px;">
					</label>
					<label class="ftx23">&nbsp;看不清？<a href="javascript:void(0)" onclick="verc()" class="flk13">换一张</a></label>
					<label id="authcode_succeed" class="blank invisible"></label>
					<span class="clr"></span>
					<label id="authcode_error"></label>
				</div>
			</div>
			<div class="item" id="autoentry">
				<span class="label">&nbsp;</span>
				<div class="fl">
					<label class="mar"><input class="checkbox" checked="checked" id="chkRememberUsername" name="chkRememberUsername" type="checkbox">
					记住用户名</label>
					<label><input class="checkbox" id="chkRememberMe" name="chkRememberMe" type="checkbox">
					自动登录</label>
				</div>
			</div>
			<div class="item">
				<span class="label">&nbsp;</span>
				
				<input class="btn-img btn-entry"  value="登录"  type="submit">
			</div>
			
            </form>
			
		</div>
		<!--[if !ie]>form end<![endif]-->

	
		<!--[if !ie]>guide end<![endif]-->
			
			
		
		<span class="clr"></span>
			
	</div>
	<!--[if !ie]>mc end<![endif]-->

</div>
<!--[if !ie]>regist end<![endif]-->


<div id="footer" class="w">
  <div class="flinks"> <a target="_blank" href="#">关于我们</a> | <a target="_blank" href="#">联系我们</a> | <a target="_blank" href="#">人才招聘</a> </div>
  <div class="copyright"> <a>Copyright 2011-2011 上海光大物业 版权所有.</a> </div>
</div>


</form>




</body>
</html>

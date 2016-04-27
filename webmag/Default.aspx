<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="webmag_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
<style>
body{ margin:auto 0px;
background:url(images/bg.gif); 
background-repeat:repeat;
margin-top:150px; 
}
span{ font-size:12px;font-weight:bold;color:#006699;}
#copyright{font-size:12px; margin-top:-35px;}
</style>
<script src="Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
<script language="javascript"> 
   function checkLogin() {
        if ($.trim($("#username").val()) == "") {
            alert("用户名不能为空，请输入用户名！");
            $("#username").focus();
            return false;
        } else if ($.trim($("#password").val()) == "") {
            alert("密码不能为空，请输入密码！");
            $("#password").focus();
            return false;
        } else if ($.trim($("#yzm").val()) == "") {
            alert("验证码不能为空，请输入验证码！");
            $("#password").focus();
            return false;
        }
        return true;
    }
    /**
	* 更改验证码
	**/
    function change() {
        var url = "VerifyCode.aspx?d=" + Math.random();
        $("#yzmImg").attr("src", url);
    }
   
</script>
  </head>    
  <body>
     
     <center>	<div id="login" style="width:705px;height:330px; background-image:url(images/loginbg.jpg); margin:auto 0;">
		<div id="" style="padding-left:300px; padding-top:65px;">
			<form name="loginForm" action="login.aspx" method="post" id="loginForm" onSubmit="return checkLogin();">
				 
				<br><br>
				<span>用户名：</span><input type="text" class="text" name="username" id="username" size="15" style="border: 1px solid rgb(0, 102, 153); width: 122px;"> 
				<br><br>
				<span>密　码：</span><input type="password" class="password" name="password" id="password" size="17" maxlength="15" style="border:1px solid #006699; width: 122px;" />
				<br><br>
				<span>验证码：</span><input type="text" class="text" name="yzm" id="yzm" size="3" maxlength="5" style="border:1px solid #006699; width:50px;"/> &nbsp;&nbsp;<img src="VerifyCode.aspx" width="60px" id="yzmImg" style="cursor:hand;" onclick="change()" title="看不清请单击刷新验证码" >
				<br><br>				
				<input type="submit" value=" " name="submit" style="border:0px solid #006699; background-image:url(images/btn1.gif); cursor:hand;height:25px; width:61px; " />&nbsp;&nbsp;<input type="reset" value=" " name="reset" style="border:0px solid #006699; background-image:url(images/btn2.gif); height:25px; width:61px; cursor:hand; " />
			</form>
		</div>
		
	</div>
	
	</center>
    
  </body>
</html>

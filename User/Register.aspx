<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="User_Register" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <meta http-equiv="pragma" content="no-cache">
    <meta http-equiv="Cache-Control" content="no-cache,must-revalidate">
    <title>注册-个人用户</title>
    <link type="text/css" rel="stylesheet" href="../css/regist.css" />

    <link type="text/css" rel="stylesheet" href="../css/regist.personal.css" />
    <script language="javascript" src="../js/jquery-1.4.3.min.js"></script>
    <script type="text/javascript" src="../js/g.base.js"></script>
    <script type="text/javascript" >
        function change() {
            var url = "../webmag/VerifyCode.aspx?d=" + Math.random();
            $("#JD_Verification1").attr("src", url);
        }

        function verifySubmit() {
            if ($.trim($("#username").val()) == "") {
                alert("用户名不能为空！");
                $("#username").focus();
                return false;
            } else if ($.trim($("#pwd").val()) == "") {
                alert("密码不能为空！");
                $("#pwd").focus();
                return false;
               } else if ($.trim($("#pwd").val()).length < 6 || $.trim($("#pwd").val()).length > 16) {
               	alert("密码长度必须在6-16位之间！");
               	$("#pwd").focus();
               	return false;		
			
			} else if ($.trim($("#pwd2").val()) == "") {
                alert("确认密码不能为空！");
                $("#pwd").focus();
                return false;
            } else if ($.trim($("#realName").val()) == "") {
                alert("真实姓名不能为空！");
                $("#Contact").focus();
                return false;
            } else if ($.trim($("#mail").val()) == "") {
                alert("邮箱不能为空！");
                $("#mail").focus();
                return false;
            }else if ($.trim($("#custel").val()) == "") {
                alert("联系电话不能为空！");
                $("#mail").focus();
                return false;
            } else if ($.trim($("#addr").val()) == "") {
                alert("联系地址不能为空！");
                $("#addr").focus();
                return false;
            } else if ($.trim($("#authcode").val()) == "") {
                alert("验证码不能为空！");
                $("#authcode").focus();
                return false;
            }

            if ($.trim($("#pwd").val()) != $.trim($("#pwd2").val())) {
                alert("对不起，设置密码和确认密码不一致！");
                $("#pwd2").focus();
                return false;
            }

            return true;
        }

        function verifyExist() {

            $.ajax({ 
                url: "AjaxCustomerExist.aspx",
                data: "username=" + $.trim($("#username").val()),
                type: "post",
                success: function (d) {
                    if (d == "error") {
                        alert("对不起，已经存在该用户名！");
                        $("#username").focus();
                        return;
                    }  
                }
            }); 

        }


    </script>

</head>
<body>
    <div id="shortcut"><div class="w"><div class="collect"></div><ul><li class="fore1"id="loginfo">您好！欢迎来到光大商城！<span><a href="./login.aspx">[请登录]</a></span></li>
    
 
 </ul><span class="clr"></span></div></div>
 <!--[if lte IE 6]><script type="text/javascript">$("#shortcut .sub").hoverForIE6();</script><![endif]-->

    <div class="w" id="logo">
        <div>
            <a href="../Index.aspx">
                <img  alt="光大商城" src="../images/logo.jpg"></a></div>
    </div>
    <div class="w" id="regist">
        <div class="mt">
            <h2>
                注册新用户</h2>

            <b></b> <span>我已经注册，现在就&nbsp;<a href="login.aspx" class="flk13">登录</a></span>
        </div>
        <div class="mc">
            <ul class="tab">
                <li class="curr">个人用户</li>
              <!--  <li class="line"><a href="registcompany.aspx">企业用户</a></li>

                <li><a href="registschool.aspx">校园用户</a></li>  -->
            </ul>
            <form id="formpersonal" method="POST" onsubmit="return verifySubmit();" action="regCustomer.aspx" >
            <div class="form">
    
                <div class="item">
                    <span class="label"><b class="ftx04">*</b>用户名：</span>
                    <div class="fl">
                        <input type="text" id="username" name="username" class="text" tabindex="1" onblur="verifyExist()" /> 
                    </div>
                </div>
                <div id="o-password">
                    <div class="item"> 
                        <span class="label"><b class="ftx04">*</b>设置密码：</span>
                        <div class="fl">
                            <input type="password" id="pwd" name="pwd" class="text" tabindex="2" />
                            <label id="pwd_succeed" class="blank">
                            </label>
                            <input type="checkbox" class="checkbox" id="viewpwd" />
                            <label class="ftx23" for="viewpwd">
                                显示密码字符</label>

                            <span class="clr"></span>
                            <label class="hide" id="pwdstrength">
                                <span class="fl">安全程度：</span><b></b></label>
                            <label id="pwd_error">
                            </label>
                        </div>
                    </div>
                    <div class="item">

                        <span class="label"><b class="ftx04">*</b>确认密码：</span>
                        <div class="fl">
                            <input type="password" id="pwd2" name="pwd2" class="text" tabindex="3" /> 
                        </div>
                    </div>
                </div>
                <div class="item">
                    <span class="label"><b class="ftx04">*</b>邮箱：</span>
                    <div class="fl">
                        <input type="text" id="mail" name="mail" class="text" tabindex="4" />
                        <label id="mail_succeed" class="blank"> 
                        </label>
                         <span class="clr"></span>
                        <label id="mail_error">
                        </label>
                    </div>

                </div>
                <div class="item">
                    <span class="label"><b class="ftx04">*</b>真实姓名：</span>
                    <div class="fl">
                        <input type="text" id="realName" name="realName" class="text" tabindex="5" />
                        <label id="Label1" class="blank">

                        </label>
                         <span class="clr"></span>
                        <label id="Label2">
                        </label>
                    </div> 
                </div>
                <div class="item">
                    <span class="label"><b class="ftx04"></b>工作单位：</span>
                    <div class="fl">
                        <input type="text" id="cusUnit" name="cusUnit" class="text" tabindex="6" />
                        <label id="Label3" class="blank">

                        </label>
                         <span class="clr"></span>
                        <label id="Label4">
                        </label>
                    </div> 
                </div>
                 <div class="item">
                    <span class="label"><b class="ftx04">*</b>联系电话：</span>
                    <div class="fl">
                        <input type="text" id="custel" name="custel" class="text" tabindex="7" />
                        <label id="Label5" class="blank"> 

                        </label>
                         <span class="clr"></span>
                        <label id="Label6">
                        </label>
                    </div> 
                </div>
                <div class="item">
                    <span class="label"><b class="ftx04">*</b>联系地址：</span>
                    <div class="fl">
                        <input type="text" id="addr" name="addr" class="text" tabindex="8" />
                        <label id="Label7" class="blank"> 

                        </label>
                         <span class="clr"></span>
                        <label id="Label8">
                        </label>
                    </div> 
                </div>
                 <div class="item">
                    <span class="label"><b class="ftx04"></b>备注：</span>
                    <div class="fl">
                        <textarea name="memo" cols="35" rows="5">
                        
                        </textarea>
                        <label id="Label9" class="blank"> 

                        </label>
                         <span class="clr"></span>
                        <label id="Label10">
                        </label>
                    </div> 
                </div>

                <div class="item">
                    <span class="label"><b class="ftx04">*</b>验证码：</span>
                    <div class="fl">
                        <input type="text" id="authcode" name="authcode" class="text text-1" tabindex="6"
                            autocomplete="off" maxlength="6" />

                        <label class="img">
                            <img id="JD_Verification1" Ver_ColorOfNoisePoint="#888888" OnClick="change()" src="../webmag/VerifyCode.aspx" alt="" style="cursor:pointer;width:100px;height:26px;" />
                        </label>
                        <label class="ftx23">
                            &nbsp;看不清？<a href="javascript:change()" onclick="change()" class="flk13">换一张</a></label>
                        <label id="authcode_succeed" class="blank invisible">
                        </label>
                        <span class="clr"></span>

                        <label id="authcode_error">
                        </label>
                    </div>
                </div>
                <div class="item">
                    <span class="label">&nbsp;</span>
                    <input type="submit" class="btn-img btn-regist"  value="同意以下协议，提交"
                        tabindex="8" />
                </div>
            </div>

            </form>
            <!--[if !ie]>form end<![endif]-->
           <%-- <div id="protocol-con">--%>

                    <%=loginAgreement.Detail%> 
        </div>
        <!--[if !ie]>mc end<![endif]-->
    </div>
    <!--[if !ie]>regist end<![endif]-->
    <script src="hello.aspx?para=loginfo" type="text/javascript"></script>
<div id="footer" class="w">
  <div class="flinks"> <a target="_blank" href="#">关于我们</a> | <a target="_blank" href="#">联系我们</a> | <a target="_blank" href="#">人才招聘</a> </div>
  <div class="copyright"> <a>Copyright 2011-2011 上海光大物业 版权所有.</a> </div>
</div>

<br>
		Copyright&copy;2004-<span id="_y"></span><script type="text/javascript">		                                             document.getElementById("_y").innerHTML = new Date().getFullYear();</script>&nbsp;&nbsp;光大商城&nbsp;版权所有</div>

</div>

    <script type="text/javascript" src="../js/Validate.js"></script>

    <script type="text/javascript" src="../js/jdValidate.personal.js"></script>

    


</body>
</html>

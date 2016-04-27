<%@ Page Language="C#" AutoEventWireup="true" CodeFile="updatePassword.aspx.cs" Inherits="webmag_PasswordManage_updatePassword" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="../Styles/webmag.css" />
    <script language="javascript" src="../../js/jquery-1.4.3.min.js"></script>
    <script language="javascript" src="../Scripts/webmag.js"></script>
    <script language="javascript" src="../Scripts/util.js"></script>
    <script>
        function verifySubmit() {
            if ($.trim($("#pwd1").val()) == "") {
                alert("设定新密码不能为空！");
                $("#pwd1").focus();
                return false;
            } else if ($.trim($("#pwd2").val()) == "") {
                alert("确认新密码不能为空！");
                $("#pwd2").focus();
                return false;
            } else if ($.trim($("#pwd1").val()) != $.trim($("#pwd2").val())) {
                alert("密码不一致！");
                return false;
            }

            return true;
        }
    </script>
</head>
<body>
    <form action="SavePassword.aspx?mark=1" method="post" id="example" onsubmit="return verifySubmit();">
            <table width="90%" class="pawTable" cellpadding="0"
					cellspacing="0" style="border-collapse: collapse;"> 
                    <tr>
                <td width="100%" align="center" height="70">
                    <font color="#FF0000">当前用户：</font>
                    <font color="#000080"><%=manager.userName%></font>
                </td>
                </tr>
                <tr>
                <td width="100%" align="center" height="30">
                    <font color="#FF0000">更改登录密码：</font>
                </td>
                </tr>
                <tr>
                <td width="100%" align="center" height="30">
                    设定新密码：
                    <input id="pwd1" type="password" style=" width:140px;" maxlength="18" size="18" name="pwd1" />
                </td>
                </tr>
                                <tr>
                <td width="100%" align="center" height="30">
                    确认新密码：
                    <input id="pwd2" type="password" style=" width:140px;" maxlength="18" size="18" name="pwd2" />
                </td>
                </tr>
                <tr>
						<td width="100%" align="center" height="30" class="buttonGroup">
							<input type="submit" name="updatepwdBtn" value=" " id="updatepwdBtn"
								class="updatepwdBtn"/>
							<input type="reset" name="resetBtn" value=" " id="resetBtn"
								class="resetBtn"/>
						</td>
					</tr>
           </table>
    </form>
</body>
</html>

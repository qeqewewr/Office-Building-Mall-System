<%@ Page Language="C#" AutoEventWireup="true" CodeFile="updateName.aspx.cs" Inherits="webmag_PasswordManage_updateName" %>

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
            if ($.trim($("#username").val()) == "") {
                alert("设定新用户名不能为空！");
                $("#username").focus();
                return false;
            } 
            return true;
        }
    </script>
</head>
<body>
    <form action="SavePassword.aspx?mark=0" method="post" id="example" onsubmit="return verifySubmit();">
            <table width="90%" class="nameTable" cellpadding="0"
					cellspacing="0" style="border-collapse: collapse;"> 
                    <tr>
                <td width="100%" align="center" height="70">
                    <font color="#FF0000">当前用户：</font>
                    <font color="#000080"><%=manager.userName%></font>
                </td>
                </tr>
                <tr>
                <td width="100%" align="center" height="30">
                    <font color="#FF0000"><strong>更改用户名</strong></font>
                </td>
                </tr>
                <tr>
                <td width="100%" align="center" height="30">
                    设定新用户名：
                    <input id="username" type="text" style=" width:140px;" maxlength="18" size="18" name="username" />
                </td>
                <tr>
						<td width="100%" align="center" height="30" class="buttonGroup">
							<input type="submit" name="saveBtn" value=" " id="saveBtn"
								class="saveBtn"/>
							<input type="reset" name="resetBtn" value=" " id="resetBtn"
								class="resetBtn"/>
						</td>
					</tr>
           </table>
    </form>
</body>
</html>

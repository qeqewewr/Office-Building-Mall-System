<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChangePwd.aspx.cs" Inherits="User_ChangePwd" %>
<div class="right">
    <div id="userinfo" class="m m3">
       
      <!--user-->
      <div id="i-userinfo">
	          <div class="username">
          <div id="userinfodisp" class="fl ftx-03"><strong><%if (customer != null)
                                           {%><%=customer.cusName%><%}
                                           else if (lee != null)
                                           {%><%= lee.Name%><%} %></strong></div>
        </div>
	  	<form action="ChangePwd.aspx" method="post" id="changepwd">
			<p>
			<span>原密码</span><br />	<input type="password" name=oldpwd />
			</p>
						<p>
			<span>新密码</span><br />		<input type="password" name=pwd1 />
			</p>
						<p>
			<span>再次输入新密码</span><br />		<input type="password" name=pwd2 />
			</p>
			<input type="submit" value="提交" />
	</form>
	  </div>
	  </div>

</div>
<script>
	$("#changepwd").submit(function () {
		var url = $(this).attr('action');
		$.post(url, $(this).serialize(), function (d) {
			if (d == 'success') {
				alert('修改成功,下次请用新密码登陆');

			} else if (d == "unlogin") {
				alert('未登陆，请重新登陆');
				window.location.href = "login.aspx";
			} else {
				alert(d);
			}
		});
		return false;
	});
</script>
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="cusFaceBox.aspx.cs" Inherits="webmag_PrepaymentManage_cusFaceBox" %>
        <form id="form1234" runat="server" action="cusFaceBox.aspx" method="post">
    <div>
       <input type="hidden"  value="<%=customer.ID%>" name="customerid" id="customerid"/>
           请输入充值金额：<input type="text"  value="0" name="permoney" id="permoney"/>元
    </div>
        <div style="text-align:center;">
							<input type="submit" name="saveNews" value=" " id="saveNews"
								class="saveBtn"/>
							<input type="reset" name="reset" value=" " id="reset"
								class="resetBtn"/>
      </div>
    </form>
     <script type="text/javascript">
      $("#form1234").submit(function () {
            var $form = $(this);
            var url = $form.attr("action") + "?random=" + (new Date()).valueOf();
            var data = $form.serialize();

            $.ajax({
                url: url,
                cache: false,
                data: data,
                type: 'post',
                success: function (d) {
                    if (d == "SUCCESS")
                        alert("提交成功");
                    else if (d == "ERROR")
                        alert("提交失败");

                    jQuery.facebox.close();
                }
            });
            return false;
        });
</script>
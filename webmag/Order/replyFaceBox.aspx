<%@ Page Language="C#" AutoEventWireup="true" CodeFile="replyFaceBox.aspx.cs" Inherits="webmag_Order_replyFaceBox" %>
    <form id="form1234" runat="server" action="replyFaceBox.aspx" method="post">
    <div>
    <input type="hidden"  value="<%=order.ID%>" name="orderid" id="orderid"/>
    <textarea id="reply" name="reply" cols="100" rows="8"
								style="width: 100%; height: 300px;"><%=order.reply%></textarea>
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
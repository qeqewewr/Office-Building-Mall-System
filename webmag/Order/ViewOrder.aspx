<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewOrder.aspx.cs" Inherits="webmag_Order_ViewOrder" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
  <head id="Head1" runat="server">  
    
	<meta http-equiv="pragma" content="no-cache"/>
	<meta http-equiv="cache-control" content="no-cache"/>
	<meta http-equiv="expires" content="0"/>    

    <link rel="stylesheet" type="text/css" href="../Styles/webmag.css"  />
    <script type="text/javascript" src="../Scripts/markupPage.js"></script>
    <script type="text/javascript" src="../Scripts/webmag.js"></script>
    <script type="text/javascript" src="../Scripts/jquery-1.4.1.min.js"></script>
	<link rel="stylesheet" type="text/css" href="../facebox/facebox.css"/>	
    <script language="javascript" type="text/javascript" src="../facebox/facebox.js"></script>
<script type="text/javascript">
    jQuery(document).ready(function ($) {
        $('a[rel=facebox]').facebox();
    })
    function verifySubmit() {
        if (confirm("确定保存？")) {
            return true;
        } else {
            return false;
        }
        return true;
    }

    </script>






  </head>
<body>
<form action="doView.aspx?id=<%=order.ID%>&pageno=<%= pageno %>" method="post" id="example" onsubmit="return verifySubmit();">
    <div>
      <table width="100%" class="addTable" cellpadding="0"
					cellspacing="0" style="border-collapse: collapse;"> 
                <caption>					
					查看订单信息界面
				</caption>
       </table>
    </div>
 <fieldset>
		<legend style="color: #006699;"> 订单基本信息  </legend> 
        <table width="100%" class="addTable" cellpadding="0" cellspacing="0" style="border-collapse: collapse;"> 
        <tr>
            <td class="leftTitle">订单编号</td><td><%=order.orderNO %></td>
            <td class="leftTitle">下单时间</td><td><%=order.payTime %></td>
            <td class="leftTitle">当前订单状态</td><td><%=orderStatus%></td>
        </tr>
        <tr >
            <td class="leftTitle">账户余额</td>
         <%if (userType == "1")
        {%>

            <td><%=lessee.WarrantMon%></td>
        <%}
        else { %>
            <td><%=customer.cusMoney%></td>

        <% }%>

            <td class="leftTitle">订单备注</td>
            <td colspan="4"><%=order.Memo %></td>
        </tr>
        </table>
	</fieldset>

         <fieldset>
		<legend style="color: #006699;"> 购买者基本信息  </legend> 
        <table width="100%" class="addTable" cellpadding="0" cellspacing="0" style="border-collapse: collapse;"> 
      <%if (userType == "1")
        {%>
        <tr>
            <td class="leftTitle">购买者类型</td><td>企业</td>
            <td class="leftTitle">名称</td><td colspan="4"><%=lessee.Name%></td>
            <%--<td class="leftTitle">可用金额</td><td><%=lessee.WarrantMon%></td>--%>
        </tr>
        <%}
        else { %>

         <tr>
            <td class="leftTitle">购买者类型</td><td>个人</td>
            <td class="leftTitle">名称</td><td><%=customer.cusName%></td>
           <td class="leftTitle">积分</td><td><%=customer.cusPoint%></td>
        </tr>


       <% }%>

 
        </table>
	</fieldset>

    <fieldset>
		<legend style="color: #006699;"> 订单商品信息  </legend> 
        <table class="resultTable">
        <tr>
        <td colspan="8" style="text-align: right;">
        <a rel="facebox" href="viewReply.aspx?id=<%=order.ID %>"><strong>订单留言回复详情</strong></a>
        </td>
        </tr>
        <tr class="topTitle" align="center">
            <td align="center">商品编号</td>
			<td align="center">商品名</td>
			<td align="center">商品单价</td>
            <td align="center">商品数量</td>
            <td align="center">商品金额</td>
            <td align="center">付款方式</td>
			<td align="center">成交金额</td>
		</tr> 
        <%for (int i = 0; i < orderDetailList.Count; i++)
        {  goods = goodsService.GetModel(orderDetailList[i].goodID);
              %>
           <tr onMouseOver="this.style.backgroundColor='#f3f3f3';return true;"
							onMouseOut="this.style.backgroundColor='';">
           <% if(goods != null){%>
            <td title="<%= goods.goodNO %>"><%= goods.goodNO%></td> 
			<td title="<%= goods.goodName %>"><%= goods.goodName%></td> 				
			<td title="<%= orderDetailList[i].goodPrice %>" align="left"><%=orderDetailList[i].goodPrice%></td> 
            <td title="<%= orderDetailList[i].goodQuantity %>"><%=orderDetailList[i].goodQuantity%></td>
            <td title="<%= orderDetailList[i].goodPrice * orderDetailList[i].goodQuantity%>"><%=orderDetailList[i].goodPrice * orderDetailList[i].goodQuantity%></td>
            <td title="<%= order.payType %>"><%=Constants.payType(order.payType)%></td>

            <td title="<%= orderDetailList[i].finalAmount%>">
            <%=orderDetailList[i].finalAmount%>
            </td>			
           <% }	%>
			</tr>
        <%}%>
        <tr class="topTitle" align="center">
        <td colspan="8" style="text-align: right;"><strong>成交总金额：<%= finalAmount %>元</strong></td>
        </tr>
        </table>

		</fieldset>

      <fieldset>
		<legend style="color: #006699;"> 默认收货信息  </legend> 
        <table width="100%" class="addTable" cellpadding="0" cellspacing="0" style="border-collapse: collapse;"> 
        <%if (userType == "1")
        {%>
         <tr>
            <td class="leftTitle">公司名</td>
            <td><%=lessee.Name%></td>
        </tr>
        <tr>
            <td class="leftTitle">地址</td>
            <td><%=lessee.Address%></td>
        </tr>
        <tr>
            <td class="leftTitle">电话</td>
            <td><%=lessee.OfficePhone%></td>
        </tr>
        <%}
        else { %>
        <tr>
            <td class="leftTitle">姓名</td>
            <td><%=customer.cusName %></td>
        </tr>
        <tr>
            <td class="leftTitle">地址</td>
            <td><%=customer.cusAddr %></td>
        </tr>
        <tr>
            <td class="leftTitle">电话</td>
            <td><%=customer.cusTel %></td>
        </tr>

        <% }%>

        </table>

		</fieldset>


     <fieldset>
		<legend style="color: #006699;"> 收货人新信息  </legend> 
        <table width="100%" class="addTable" cellpadding="0" cellspacing="0" style="border-collapse: collapse;"> 
         <tr>
            <td class="leftTitle">收货人</td>
            <td><%=order.Receiver %></td>
        </tr>
        <tr>
            <td class="leftTitle">地址</td>
            <td><%=order.addr %></td>
        </tr>
        <tr>
            <td class="leftTitle">手机号码</td>
            <td><%=order.Tel %></td>
        </tr>

        </table>

		</fieldset>
             <fieldset>
		<legend style="color: #006699;"> 发货 </legend> 
        <table width="100%" class="addTable" cellpadding="0" cellspacing="0" style="border-collapse: collapse;"> 
         <tr>
            <td class="leftTitle">发货信息</td>
            <td>
            <textarea id="deliveryInfo" name="deliveryInfo"
								style="width: 100%; height: 150px;"><%=order.deliveryInfo%></textarea>
            </td>
            <td class="leftTitle">签收人</td>
            <td>

            <textarea id="signer" name="signer"
								style="width: 100%; height: 150px;"><%=order.signer %></textarea>


            <%--<input type="text" name="signer"  id="signer" value="<%=order.signer %>" style="width:auto; border-width:0; text-align:left;"/>--%>
            </td>
        </tr>
        </table>

		</fieldset>

<div style="text-align:center;">
           <%if (order.orderStatus == "1" || order.orderStatus == "2" || order.orderStatus == "3")
             {%>
            <input type="radio" name='rad' value="1" /> <strong>收到款，交易成功</strong>
            <input type="radio" name='rad' value="2" /><strong>未收到款，交易不成功</strong>
            <input type="radio" name='rad' value="3" /> <strong>货物已收到，账户扣款</strong>
            <input type="radio" name='rad' value="4" /><strong>退货，账户不扣款</strong>
            <%}
             else if (order.state == 1)
             { %>
             <input type="radio" name='rad' value="1" checked  disabled/> <strong>收到款，交易成功</strong>
            <input type="radio" name='rad' value="2" disabled/><strong>未收到款，交易不成功</strong>
            <input type="radio" name='rad' value="3" disabled/> <strong>货物已收到，账户扣款</strong>
            <input type="radio" name='rad' value="4" disabled/><strong>退货，账户不扣款</strong>
            <% } else if (order.state == 2)
             { %>
             <input type="radio" name='rad' value="1"disable/> <strong>收到款，交易成功</strong>
            <input type="radio" name='rad' value="2"  checked disabled/><strong>未收到款，交易不成功</strong>
            <input type="radio" name='rad' value="3" disabled/> <strong>货物已收到，账户扣款</strong>
            <input type="radio" name='rad' value="4" disabled/><strong>退货，账户不扣款</strong>
            <% } else if (order.state == 3)
             { %>
             <input type="radio" name='rad' value="1" disabled/> <strong>收到款，交易成功</strong>
            <input type="radio" name='rad' value="2" disabled/><strong>未收到款，交易不成功</strong>
            <input type="radio" name='rad' value="3" checked disabled/> <strong>货物已收到，账户扣款</strong>
            <input type="radio" name='rad' value="4" disabled/><strong>退货，账户不扣款</strong>
            <% }
             else if (order.state == 4)
             { %>
             <input type="radio" name='rad' value="1" disabled/> <strong>收到款，交易成功</strong>
            <input type="radio" name='rad' value="2" disabled/><strong>未收到款，交易不成功</strong>
            <input type="radio" name='rad' value="3" disabled/> <strong>货物已收到，账户扣款</strong>
            <input type="radio" name='rad' value="4" checked disabled/><strong>退货，账户不扣款</strong>
            <% }
             else if (order.orderStatus =="4")
             { %>
            <input type="radio" name='rad' value="1" disabled/> <strong>收到款，交易成功</strong>
            <input type="radio" name='rad' value="2" disabled/><strong>未收到款，交易不成功</strong>
            <input type="radio" name='rad' value="3" disabled/> <strong>货物已收到，账户扣款</strong>
            <input type="radio" name='rad' value="4" disabled/><strong>退货，账户不扣款</strong>

             <%} else{%>
             <input type="radio" name='rad' value="1" disabled/> <strong>收到款，交易成功</strong>
            <input type="radio" name='rad' value="2" disabled/><strong>未收到款，交易不成功</strong>
            <input type="radio" name='rad' value="3" disabled/> <strong>货物已收到，账户扣款</strong>
            <input type="radio" name='rad' value="4" disabled/><strong>退货，账户不扣款</strong>

             <%}%>
</div>


<%--        <table width="100%" class="addTable" cellpadding="0"
					cellspacing="0" style="border-collapse: collapse;">
                	<tr>
						<td colspan="4" class="buttonGroup">--%>
                        <div style="text-align:center;">
                        <%if (order.orderStatus != "0")
                          { %>
                        
							<input type="submit" name="saveNews" value=" " id="saveNews"
								class="saveBtn"/>
							<input type="reset" name="reset" value=" " id="reset"
								class="resetBtn"/>
                                <%} %>
							<input type="button" name="back" value=" " id="back"
								class="backBtn" onClick="javascript:history.back(-1);"/>
                        </div>
<%--						</td>
					</tr>
            </table>
--%>
</from>
</body>
</html>

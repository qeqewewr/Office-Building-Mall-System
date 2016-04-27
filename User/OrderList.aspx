<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OrderList.aspx.cs" Inherits="User_OrderList" %>
  <div class="right">
  <div class="tb-void tb-line">
                <table width="100%" cellspacing="0" cellpadding="0">
                    <tbody><tr>
                        <th>订单编号</th>
                        <th>收货人</th> 
                        <th>下单时间</th>
						<th>付款方式</th>
						 <th>订单状态</th>
						<th>订单金额</th>
						<th>成交金额</th>
                       
                        <th>操作</th>
                    </tr>
                        <% for (int i = 0; i < list.Count; i++)
                           {
							   orders = orderS.GetModelList("OrderID="+list[i].ID);
							   float p1=0.0f, p2=0.0f;
							   for (int j = 0; j < orders.Count; j++)
							   {
								   p1 += orders[j].goodPrice * orders[j].goodQuantity;
								   p2 += orders[j].finalAmount;
							   }
							   %>
                          <tr>
                          <td><a href="OrderDetail.aspx?id=<%=list[i].ID %>" target="_blank"><%= list[i].orderNO %></a></td>
                          
                          <td><%= list[i].Receiver %></td> 
                          <td><span class="ftx-03"><%=list[i].payTime %></span></td>
						  <td><span class="ftx-03"><%=Constants.payType(list[i].payType)%></span></td>
                          <td><span class="ftx-03"><%=Constants.orderStatus(list[i].orderStatus) %></span></td>

						   <td><span class="ftx-03"><%=p1 %></span></td>
						    <td><span class="ftx-03"><%=p2 %></span></td>

                          <td class="order-doi"><a clstag="click|keycount|orderinfo|order_check" href="orderDetail.aspx?id=<%=list[i].ID %>" target="_blank">查看</a>
<%--                          <%if (list[i].orderStatus == "1" || list[i].orderStatus == "2")
                            {%>

                          <a clstag="click|keycount|orderinfo|order_check" href="orderDetail.aspx?id=<%=list[i].ID %>" target="_blank">删除</a>
                          <%} %>--%>



                          </td>
                          </tr>
                          <%} %>
                       				  
                </tbody></table>
            </div>
   



    <div class="clr"></div>
  </div>

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ConsumeOrder.aspx.cs" Inherits="User_ConsumeOrder" %>
  <div class="right">
  <div class="tb-void tb-line">
                <table width="100%" cellspacing="0" cellpadding="0">
                    <tbody><tr>
                        <th >订单编号</th>
                        <th>收货人</th> 
                        <th>下单时间</th>
            
                        <th>支付金额</th>
                        <th>操作</th>
                    </tr>
                        <% for (int i = 0; i < list.Count; i++)
                           { %>
                          <tr>
                          <td><a href="OrderDetail.aspx?id=<%=list[i].ID %>" target="_blank"><%= list[i].orderNO %></a></td>
                          
                          <td><%= list[i].Receiver %></td> 
                          <td><span class="ftx-03"><%=list[i].payTime %></span></td>
                       
                          <td class="order-doi"><%=finalAmount%></td>
                          <td class="order-doi"><a clstag="click|keycount|orderinfo|order_check" href="orderDetail.aspx?id=<%=list[i].ID %>" target="_blank">查看</a></td>
                          </tr>
                          <%} %>
                       				  
                </tbody></table>
            </div>
   



    <div class="clr"></div>
  </div>

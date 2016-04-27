<%@ Page Language="C#" AutoEventWireup="true" CodeFile="viewReply.aspx.cs" Inherits="webmag_Order_viewReply" %>
    
    <div>
    <textarea id="message" name="message" cols="100" rows="8"
								style="width: 100%; height: 150px;">客户留言：<%=message%></textarea>
    </div>
    
   <div>
   <textarea id="reply" name="reply" cols="100" rows="8"
								style="width: 100%; height: 150px;">客服回复：<%=reply%></textarea>
   </div>

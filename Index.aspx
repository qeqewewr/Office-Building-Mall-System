<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="Index" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>�����ҵ�����̳�</title>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312">
    <link href="../Styles/f11.css" rel="stylesheet" type="text/css"/>
</head>

<body id="index">
    <!--ҳ��ͷ-->
    <!--#include file="top.aspx"-->
<script type="text/javascript">
    $(function () {

        function showImg(index) {
            var adHeight = 120;
            $("#slide ul").stop(true, false).animate({ top: -adHeight * index }, 1000);
            $(".num span").removeClass("curr")
			.eq(index).addClass("curr");
        }

        var len = $(".num span").length;
        var index = 0;
        var adTimer;
        $(".num span").mouseover(function () {
            index = $(".num span").index(this);
            showImg(index);
        }).eq(0).mouseover();
        //���� ֹͣ������������ʼ����.
        $('#slide').hover(function () {
            clearInterval(adTimer);
        }, function () {
            adTimer = setInterval(function () {
                showImg(index)
                index++;
                if (index == len) { index = 0; }
            }, 3000);
        });
        $('#slide').trigger('mouseout');
		/*
		
        $("#newpros div.mc").jCarouselLite({
            auto: 3000,
            speed: 1000,
            vertical: false,
			visible: 4
		});
		*/
		$('#madding ul.tab').find("li").mouseover(function () {
			$(this).closest("ul").find("li").removeClass('curr');
			$(this).addClass('curr');
			var index = $("#madding ul.tab li").index($(this));
			$("#madding-1 div.tabcon").hide().eq(index).show();
		});	




    });
</script>   
   <!--��������-->
    <div class="w main">
        <div class="right-extra">
            <div class="middle">
                <div id="slide" class="m" style="position: relative;">
                    <ul style="position: absolute; top: 0px; left: 0pt;">
                    <%for (int k = 0; k < adverListTop.Count; k++)
                      { %>

                      <li><%--<a target="_blank" href="<%=adverListTop[k].Url %>">--%>
                            <img width="766" height="120" src="<% =advupload%><%=adverListTop[k].ImgUrl%>"/>
                       <%-- </a>--%></li>


                    <%} %>

                       <%-- <li><a target="_blank" href="#">
                            <img width="766" height="120" src="images/1.jpg">
                        </a></li>
                        <li><a target="_blank" href="#">
                            <img width="766" height="120" src="images/2.jpg">
                        </a></li>
                        <li><a target="_blank" href="#">
                            <img width="766" height="120" src="images/3.jpg">
                        </a></li>
                        <li><a target="_blank" href="#">
                            <img width="766" height="120" src="images/4.gif">
                        </a></li>
                        <li><a target="_blank" href="#">
                            <img width="766" height="120" src="images/5.jpg">
                        </a></li>--%>
                    </ul>
                    <div class="num">
                        <span class="curr"><a target="_blank" href="#">1</a> </span><span class=""><a target="_blank"
                            href="#">2</a> </span><span class=""><a target="_blank" href="#">3</a> </span>
                        <span class=""><a target="_blank" href="#">4</a> </span><span class=""><a target="_blank"
                            href="#">5</a> </span>
                    </div>
                </div>
                <div id="madding" class="m">
                    <div class="mt">
                        <h2>������Ʒ</h2>
                        <div class="extra">
                        </div>
                    </div>
                    <div id="madding-1" class="mc list-h">

                        <div style="display: block;" class="tabcon list-h hide" clstag="homepage|keycount|homepage|crazy-1">
                            <% for (int i = 0; i < lastestgood.Count; i++)
                               {
                                   imgList = attachSrv.GetModelList("attachType =" + lastestgood[i].goodType + " and moduleID = " + lastestgood[i].ID.ToString());%>
                            <dl>
                                <dt class="p-img">
								<a target="_blank" href="Goods/GoodsDetail.aspx?id=<%=lastestgood[i].ID %>">
                                <%if (attachSrv.GetModelList(" attachType=" + lastestgood[i].goodType + " and moduleID= " + lastestgood[i].ID).Count != 0)
                                  { %>
                                    <img width="160" height="160" src="<%=upload %><%=attachSrv.GetModelList(" attachType="+lastestgood[i].goodType+" and moduleID= "+lastestgood[i].ID)[0].attachUrl%>"
                                        alt="<%= lastestgood[i].goodName %>" title="<%= lastestgood[i].goodName %>" />
                                <%}
                                  else
                                  {%>
                                    <img width="160" height="160" src="images/no-img_mid_.jpg"
                                        alt="<%= lastestgood[i].goodName %>" title="<%= lastestgood[i].goodName %>" />
                               <%} %>
                                        </a>
							 <div class="p-price">
                                         �Żݼۣ�<strong style="color:White">��<%=lastestgood[i].goodPromotion%></strong>   </div> 
                                </dt>
                                <dd class="p-name">
                                    <a target="_blank" href="GreenLeasing/GreenLeasingDetail.aspx?id=<%= lastestgood[i].ID %>"><%=lastestgood[i].goodName%></a>
								
									
									</dd></dl>
                            <%}%> 
                        </div>



                        <div style="display: none;" class="tabcon list-h hide" clstag="homepage|keycount|homepage|crazy-2">
                            <dl>
                                <dt class="p-img"><a target="_blank" href="#">
                                    <img width="130" height="130" src="images/70262685-837b-4e14-8524-a49392336aef.jpg"
                                        alt="ֱ��70Ԫ������������������ת������C57*08003" title="ֱ��70Ԫ������������������ת������C57*08003"></a><div class="p-price">
                                            ��599.00</div>
                                </dt>
                                <dd class="p-name">
                                    <a target="_blank" href="#">ֱ��70Ԫ������������������ת������C57*08003</a></dd></dl>
                            <dl>
                                <dt class="p-img"><a target="_blank" href="#">
                                    <img width="130" height="130" src="images/70262685-837b-4e14-8524-a49392336aef.jpg"
                                        alt="������г�ֵʵ��װ��������˿����ݻ����޴�ϴ����װ��������550ml+ϴ��¶550ml��" title="������г�ֵʵ��װ��������˿����ݻ����޴�ϴ����װ��������550ml+ϴ��¶550ml��"></a><div
                                            class="p-price">
                                            ��129.00</div>
                                </dt>
                                <dd class="p-name">
                                    <a target="_blank" href="#">������г�ֵʵ��װ��������˿����ݻ����޴�ϴ����װ��������550ml+ϴ��¶550ml��</a></dd></dl>
                            <dl>
                                <dt class="p-img"><a target="_blank" href="#">
                                    <img width="130" height="130" src="images/70262685-837b-4e14-8524-a49392336aef.jpg"
                                        alt="Jack Wolfskin��ʽ��ɽЬ/Զ��Ь4003151" title="Jack Wolfskin��ʽ��ɽЬ/Զ��Ь4003151"></a><div
                                            class="p-price">
                                            ��459.00</div>
                                </dt>
                                <dd class="p-name">
                                    <a target="_blank" href="#">Jack Wolfskin��ʽ��ɽЬ/Զ��Ь4003151</a></dd></dl>
                        </div>

                        <div style="display: none;" class="tabcon list-h hide" clstag="homepage|keycount|homepage|crazy-3">
                            <dl>
                                <dt class="p-img"><a target="_blank" href="#">
                                    <img width="130" height="130" src="images/70262685-837b-4e14-8524-a49392336aef.jpg"
                                        alt="BeKizͯҼ�ⶡ��ϵ�����޼Ӻ�п� ������ذ� ����ֱ��210 ����ӵ��" title="BeKizͯҼ�ⶡ��ϵ�����޼Ӻ�п� ������ذ� ����ֱ��210 ����ӵ��"></a><div
                                            class="p-price">
                                            ��99.00</div>
                                </dt>
                                <dd class="p-name">
                                    <a target="_blank" href="#">BeKizͯҼ�ⶡ��ϵ�����޼Ӻ�п�
                                        ������ذ� ����ֱ��210 ����ӵ��</a></dd></dl>
                            <dl>
                                <dt class="p-img"><a target="_blank" href="#">
                                    <img width="130" height="130" src="images/70262685-837b-4e14-8524-a49392336aef.jpg"
                                        alt="S5660 ֱ��100Ԫ����ȡ�ֻ����Ż�ȯ�������ټ�50Ԫ��800MHZ CPU ��Android ����ϵͳ��" title="S5660 ֱ��100Ԫ����ȡ�ֻ����Ż�ȯ�������ټ�50Ԫ��800MHZ CPU ��Android ����ϵͳ��"></a><div
                                            class="p-price">
                                            ��1399.00</div>
                                </dt>
                                <dd class="p-name">
                                    <a target="_blank" href="#">S5660 ֱ��100Ԫ����ȡ�ֻ����Ż�ȯ�������ټ�50Ԫ��800MHZ
                                        CPU ��Android ����ϵͳ��</a></dd></dl>
                            <dl>
                                <dt class="p-img"><a target="_blank" href="#">
                                    <img width="130" height="130" src="http://img10.360buyimg.com/n3/4362/fdec1067-77c5-4ec2-b10a-db0e7b74b7a6.jpg"
                                        alt="ȫ�������׷� �����ճ�����Folio i5-2467M 4G SSD��̬128G W7���������� ������飡" title="ȫ�������׷� �����ճ�����Folio i5-2467M 4G SSD��̬128G W7���������� ������飡"></a><div
                                            class="p-price">
                                            ��7999.00</div>
                                </dt>
                                <dd class="p-name">
                                    <a target="_blank" href="#">ȫ�������׷� �����ճ�����Folio
                                        i5-2467M 4G SSD��̬128G W7���������� ������飡</a></dd></dl>
                        </div>
                        <div style="display: none;" class="tabcon list-h hide" clstag="homepage|keycount|homepage|crazy-4">
                            <dl>
                                <dt class="p-img"><a target="_blank" href="#">
                                    <img width="130" height="130" src="images/70262685-837b-4e14-8524-a49392336aef.jpg"
                                        alt="��˶A53XI243SV����������,7200תӲ��,��2G�ڴ�,USB3.0����,����ԭװ��������!" title="��˶A53XI243SV����������,7200תӲ��,��2G�ڴ�,USB3.0����,����ԭװ��������!"></a><div
                                            class="p-price">
                                            ��4599.00</div>
                                </dt>
                                <dd class="p-name">
                                    <a target="_blank" href="#">��˶A53XI243SV����������,7200תӲ��,��2G�ڴ�,USB3.0����,����ԭװ��������!</a></dd></dl>
                            <dl>
                                <dt class="p-img"><a target="_blank" href="#">
                                    <img width="130" height="130" src="images/70262685-837b-4e14-8524-a49392336aef.jpg"
                                        alt="��ɱ����hold��ס����������ת˲��ʧ������GF2W���ظ���˫��ͷ�׻�" title="��ɱ����hold��ס����������ת˲��ʧ������GF2W���ظ���˫��ͷ�׻�"></a><div
                                            class="p-price">
                                            ��3888.00</div>
                                </dt>
                                <dd class="p-name">
                                    <a target="_blank" href="#">��ɱ����hold��ס����������ת˲��ʧ������GF2W���ظ���˫��ͷ�׻�</a></dd></dl>
                            <dl>
                                <dt class="p-img"><a target="_blank" href="#">
                                    <img width="130" height="130" src="images/70262685-837b-4e14-8524-a49392336aef.jpg"
                                        alt="�ֿ���2011ȫ�´���ר����ѧ���ᣨԤ��A�棩��CD+ů�����±�+�ؿ���" title="�ֿ���2011ȫ�´���ר����ѧ���ᣨԤ��A�棩��CD+ů�����±�+�ؿ���"></a><div
                                            class="p-price">
                                            ��89.00</div>
                                </dt>
                                <dd class="p-name">
                                    <a target="_blank" href="#">�ֿ���2011ȫ�´���ר����ѧ���ᣨԤ��A�棩��CD+ů�����±�+�ؿ���</a></dd></dl>
                        </div>
                    </div>
					
                </div>
          
          
          
          
          
          
          
          
            </div>
            <div class="right">
                <div id="report" class="m">
				
                <%if (adverListRight != null)
                      {%>
                     <%for (int t = 0; t < adverListRight.Count; t++)
                       { %>
                  <div class="m da211x130">
                <%--<a target="_blank" href="<%=adverListRight[t].Url %>">--%>
                    <img width="211" height="180" src="<% =advupload%><%=adverListRight[t].ImgUrl%>" app="image:poster" alt="">
               <%-- </a>--%>
            </div>

                    <%}
                      }%>
				</div>
            </div>
        </div>
        <div class="left">
            <div id="sales" class="m">
          <!--
		   <div class="friend_link_head">
            <a><strong>��������</strong></a>
           </div>
          -->
		  	   <div class="mt">
            <h2 style=" visibility:visible">��������</h2>
			<div class="extra">
                        </div>
           </div>
		   <div class="friend_link_body">
           <ul>
                
                <%if (adverListLink != null)
                  {for (int m = 0; m < adverListLink.Count; m++)
                       { %>
                       <li>
                       <a target="_blank" href="<%=adverListLink[m].Url%>"><%=adverListLink[m].Description%></a>
                       </li>

                       <%}
                  }%>
                </ul>
           </div>
                <div style="text-align:center">
                
                    <ul> 
                    <%if (adverListLeftTop != null)
                      {%>
                     <%for (int n = 0; n < adverListLeftTop.Count; n++)
                       { %>
                      <li>
                      <div class="p-img"><%--<a target="_blank" href="<%=adverListLeftTop[n].Url %>">--%>
                            <img width="209" height="79" src="<% =advupload%><%=adverListLeftTop[n].ImgUrl%>" alt="">
                       <%-- </a>--%>
                        </div>
                        

                        <%if (adverListLeftTop[n].Description != null && adverListLeftTop[n].Description != "")
                          {%>
  
                         <div class="p-name"><%--<a target="_blank" href="<%=adverListLeftTop[n].Url %>">--%><%=adverListLeftTop[n].Description%><%--</a>--%></div>
                        <%} %>

                        </li>
                    <%}
                      }%>
                    </ul>
                </div>
            </div>
        </div>
        <div class="right-extra">

		         

            <div class="middle" style="width:983px;">
	
			 	<%
				for(int j=0;j<goodTypeList.Count;j++) {

					goods = getGoodsByType(goodTypeList[j].ID);
					if(goods.Count == 0) continue;
				%>
		
			    <div class="m goodblock" clstag="homepage|keycount|homepage|newpros">
                    <div class="mt"> 
						<h2><%=goodTypeList[j].typeName %></h2>
                        <div class="extra">
                            <a href="Goods/GoodsList.aspx?type=<%=goodTypeList[j].ID%>&ptype=<%=goodTypeList[j].ID%>">����&gt;&gt;</a>
                        </div>
                    </div>
                    <div class="mc list-h" style="width:970px">
                        <ul>
                        
                        	<%
								
                        		for(int i=0;i<goods.Count;i++){
                        	%>
                            <li>
                                <div class="p-img">
                                    <a href="goods/GoodsDetail.aspx?id=<%=goods[i].ID%>" target="_blank">
                                    <%if (attachSrv.GetModelList(" attachType=" + goods[i].goodType + " and moduleID= " + goods[i].ID).Count > 0)
                                      {%>
                                         <img width="100" height="100" alt="<%= goods[i].goodName%>" src="<%=upload %><%= attachSrv.GetModelList(" attachType="+goods[i].goodType+" and moduleID= "+goods[i].ID)[0].attachUrl%>"></a>
                                         <% }%>
                                        
                                
                                </div>
                                   
                                <div class="p-price"> <a href="goods/GoodsDetail.aspx?id=<%=goods[i].ID%>" title="<%= goods[i].goodName%>"
                                        target="_blank"><%= goods[i].goodName%></a><br />
                                    �Żݼۣ�<strong >��<%=goods[i].goodPromotion%></strong></div>
                            </li>
                            <%}%> 
                        </ul>
                        </div>
                    </div>


           <% }%>
		   
		   
		   
		    </div>
   
   
   
   
        </div>
        <span class="clr"></span>
   
    <div id="footer" class="w">
       
        <div class="copyright">
            <a>Copyright 2011-2013 �Ϻ������ҵ ��Ȩ����.</a>
        </div>
    </div>
</body>
</html>

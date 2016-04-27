/********************  购物车列表 ********************************/

//设置后端的Server页面
var pageLinkUrl="";
var ajaxUrl="ajaxServer/ForShoppingCart.aspx";
var OrderInfoUrl='orderinfo.aspx';
var isLogin=false;
var OtherSiteUrl="http://jd2008.360buy.com/purchaseservice/";
//+g('store_provinces').value
//显示购物车列表
function ShowShoppingCart()
{
   setAjax_runCode("action=ShowShoppingCart&provinceId=0","showProductListHtml(backValue);");
}
function CalcCart()
{
  setAjax_runCode("action=CalcCart&provinceId=0","showProductListHtml(backValue);");
}
//显示提示
function showAlert_shoppingCart(message,obj)
{
   alert(message);
}
//显示删除确认提示
//function showRemoveTip(pos,sucFunc)
//{
//   
//}
//显示变更数量提示
function showChangeSucTip(pos,changeStr)
{
   closeWindow();
   pos.Top=pos.Top-84;
   pos.Left=pos.Left-(204-pos.Width)/2;
   var tipHtml="<div id='changeSucTip'><div id='tipContent'><div id='tipTitle'>"+changeStr+"数量修改成功！<br />商品金额为：<span id='priceSpan'>"+g('cartBottom_price').innerHTML+"</span>元<br /><a href='javascript:closeWindow()'>关闭</a></div></div></div>";

   showMessageBox(tipHtml,pos,204);
   var mWin=g('mesWindow');
   var isGrow=true;
   if(isIe){
   //
   try{
   //obj.filters.alpha.opacity=90;
   mWin.style.filter='alpha(opacty=90)';
   }catch(e){isGrow=false;}
   }
    else{mWin.style.opacity=0.9;}
   if(isGrow){setTimeout(function(){setGrowHidden(mWin,3,10);},4000);}
   else{setTimeout(function(){closeWindow();},4000);}
}

//重置商品展现HTML
function showProductListHtml(backValue)
{
   //刷新库存信息
   //showStockInfo();
   g('productList').innerHTML=backValue;
   if(openSuitList.length>0)
   {
      var openSuit=openSuitList.split('}');
      for(var i=0;i<openSuit.length-1;i++)
      {
         setSuitShow(openSuit[i].replace('{',''));
      }
   }
   //购物显示后处理
   DoOnAfterBuildCart();
}
function DoOnAfterBuildCart()
{
  
   //服务器请求
   //setAjax_runCode("action=DoOnAfterBuildCart","DoOnAfterBuildCart_Callback(backValue);");
   
    setAjaxBaseByUrl(OtherSiteUrl,"GET","action=DoOnAfterBuildCart",null,false,null,null,"DoOnAfterBuildCart_Callback(backValue);","");
   
   //加载满返满赠提示信息
   showshoppingcartSuitError('');
   DoOnAfterBuildCart_Freight();
   afterCartShow();
   try
   {  
      $(".aboutprice").hoverForIE6({current:"aboutprice-hover"});
      $(".member-price").hoverForIE6();
      log('shoppingcartpop', 'Listcart');
   }catch(e){}
}
function afterCartShow(){}

function DoOnAfterBuildCart_Freight()
{
   if(g('freightTip')!=null){
   var price=parseInt(g('cartBottom_price').innerHTML.replace(/,/g,'').replace('￥','').replace('?',''));
   if((price>0 && price<100) || (price>300 && price<400))
   {
      var freight=0;
      if(price>0 && price<100)freight=100-price;
      else if(price>300 && price<400)freight=400-price;
      g('freightTip').innerHTML="再购买<font color='red'>￥"+freight+"</font>元商品,即可在";
   }else g('freightTip').innerHTML='';
   }
}
function DoOnAfterBuildCart_Callback(jsonObj)
{
   jsonObj=eval("("+jsonObj+")");
   if(jsonObj!=null){
      for(pName in jsonObj)
      {
         try{
            eval("DoOnAfterBuildCart_Callback_"+pName+"('"+jsonObj[pName]+"');");
         }catch(e){}
      }
   }
}
function DoOnAfterBuildCart_Callback_StockError(obj)
{
   var cartObj=g('CartTb');
   var errorStr=''; 
   for(var i=1;i<cartObj.rows.length-1;i++)
   {
      if(cartObj.rows[i].cells[0].innerHTML!='' && obj.indexOf(cartObj.rows[i].cells[0].innerHTML)>-1)
      {
         cartObj.rows[i].style.backgroundColor="#FFECEC";
         errorStr+="<br />"+(cartObj.rows[i].cells[1].childNodes.length>1?(cartObj.rows[i].cells[1].childNodes.length>2?cartObj.rows[i].cells[1].childNodes[1].innerHTML+" 或附件（赠品）":cartObj.rows[i].cells[1].childNodes[1].innerHTML):cartObj.rows[i].cells[1].childNodes[0].innerHTML)+" 暂时缺货或库存不足，无法购买，您可以 ";
         errorStr+=cartObj.rows[i].cells[cartObj.rows[i].cells.length-1].innerHTML.replace('删除','点此删除该商品');
         errorStr+=" 并继续结算其它商品；";
      }
   }
   if(errorStr.length>0)
      g('stockErrorPanel').innerHTML="<div class='shoppingTip'>抱歉，以下商品缺货或库存不足，请删除或更改数量："+errorStr+"</div>";
   else if(g('stockErrorPanel').innerHTML!='')
   {
     g('stockErrorPanel').innerHTML='';
   }
   if(cartObj.rows.length>0)
   {
     log('newcart','wuhuo');
   }
}


var isHaveAjaxServer=false;
function changeTxtOnFocus(obj)
{
   isHaveAjaxServer=true;
}
//添加商品到购物车
function AddProductOnEdit(obj)
{
    //检测输入是否为数字
    var skuId=g('addSkuId').value;
    var skuNum=g('addSkuNum').value;
   if(!checknumber(skuId) || !checknumber(skuNum))
   {showAlert_shoppingCart("您输入的格式不正确！",obj);g('addSkuId').value='';return;}
   
   //判断为0的情况
   if(parseInt(skuNum)==0)
   {
      showAlert_shoppingCart("您输入的数量不正确！",obj);
      return;
   }
   setAjax_runCodeAndBtn("action=AddProduct&productId="+skuId+"&productCount="+skuNum,obj,"ShowShoppingCart();EventOnSkuChange();");

}
//更改商品数量
function changeProductCount(productId,obj)
{
   if(obj.value==obj.nextSibling.value){isHaveAjaxServer=false;return;}
   //检测输入是否为数字
   if(!checknumber(obj.value)){isHaveAjaxServer=false;showAlert_shoppingCart("您输入的格式不正确！",obj);obj.value=obj.nextSibling.value;return;}
   
   //判断为0的情况
   if(parseInt(obj.value)==0)
   {
      removeProductOnShoppingCart(productId,obj);
      return;
   }
   
   setAjaxBase("GET","action=changeProductCount&productId="+productId+"&productCount="+obj.value+"&provinceId=0",null,false,obj,null,"var pos=new getPos(curBtn);showProductListHtml(backValue);showChangeSucTip(pos,'商品');","isHaveAjaxServer=false;");

}
//更改延保产品数量
function changeYBCount(ybId,rSkuId,mainNum,obj)
{
   //检测输入是否为数字
   var myReg=/\d+/;
   if(!checknumber(obj.value)){showAlert_shoppingCart("您输入的格式不正确！",obj);obj.value=obj.nextSibling.value;return;}
   
   //判断为0的情况
   if(parseInt(obj.value)==0)
   {
      removeYBProduct(ybId,rSkuId,obj);
      return;
   }
   if(parseInt(obj.value)>mainNum)
   {
      alert('修改失败，延保商品的数量不能大于主商品的数量！');
      obj.value=obj.nextSibling.value;
      return;
     }
    setAjaxBase("GET","action=changeYBCount&productId="+ybId+"&rSkuId="+rSkuId+"&num="+obj.value+"&provinceId=0",null,false,obj,null,"var pos=new getPos(curBtn);showProductListHtml(backValue);showChangeSucTip(pos,'商品');","curBtn.value=curBtn.nextSibling.value;isHaveAjaxServer=false;");
}
//更改延保产品数量
function changeYBCountForSuit(ybId,rSuitId,obj)
{
   //检测输入是否为数字
   var myReg=/\d+/;
   if(!checknumber(obj.value)){showAlert_shoppingCart("您输入的格式不正确！",obj);obj.value=obj.nextSibling.value;return;}
   
   //判断为0的情况
   if(parseInt(obj.value)==0)
   {
      removeYBProductForSuit(ybId,rSuitId,obj)
      return;
   }
    setAjaxBase("GET","action=changeYBCountForSuit&productId="+ybId+"&rSuitId="+rSuitId+"&num="+obj.value+"&provinceId=0",null,false,obj,null,"var pos=new getPos(curBtn);showProductListHtml(backValue);showChangeSucTip(pos,'商品');","curBtn.value=curBtn.nextSibling.value;isHaveAjaxServer=false;");
}

//删除购物车中的商品
function removeProductOnShoppingCart(productId,obj)
{
   if(confirm('确定不购买该商品？'))
   {
     setDelSku(obj,productId);
     setAjaxBase("GET","action=removeProductOnShoppingCart&productId="+productId+"&provinceId=0",null,false,obj,null,"showProductListHtml(backValue);setDelSkuShow();EventOnSkuChange();","isHaveAjaxServer=false;");
     try
     {
        log( 7,1, productId );
     }catch(e){}       
   }else{isHaveAjaxServer=false;}
}
//删除延保商品
function removeYBProduct(productId,rSkuId,obj)
{
   if(confirm('确定不购买该延保商品？'))
   {
      setAjaxBase("GET","action=removeYBProduct&productId="+productId+"&rSkuId="+rSkuId+"&provinceId=0",null,false,obj,null,"showProductListHtml(backValue);","isHaveAjaxServer=false;");
   }else{isHaveAjaxServer=false;}
}
//删除延保商品FOR套装
function removeYBProductForSuit(productId,rSuitId,obj)
{
   if(confirm('确定不购买该延保商品？'))
   {
      setAjaxBase("GET","action=removeYBForSuit&productId="+productId+"&rSuitId="+rSuitId+"&provinceId=0",null,false,obj,null,"showProductListHtml(backValue);","isHaveAjaxServer=false;");
   }else{isHaveAjaxServer=false;}
}
var openSuitList="";
//控制套装显示
function setSuitShow(suitId)
{
   if(g('suit_'+suitId)==null){return;}
   if(g('suit_'+suitId).style.display=='none')
   {
      if(openSuitList.indexOf('{'+suitId+'}')<0)
      {
         openSuitList+='{'+suitId+'}';
      }
      g('suit_'+suitId).style.display='';
      g('suitA_'+suitId).innerHTML='[收起套装商品]';
      g('suitImg_'+suitId).src='skin/images/bag_close.gif';
   }else{
      openSuitList=openSuitList.replace('{'+suitId+'}','');
      g('suit_'+suitId).style.display='none';
      g('suitA_'+suitId).innerHTML='[查看套装商品]';
      g('suitImg_'+suitId).src='skin/images/bag_open.gif';
   }
}
//更改套装数量
function changeSuitCount(suitId,obj)
{
   if(obj.value==obj.nextSibling.value){isHaveAjaxServer=false;return;}
   //检测输入是否为数字
   if(!checknumber(obj.value)){isHaveAjaxServer=false;showAlert_shoppingCart("您输入的格式不正确！",obj);obj.value=obj.nextSibling.value;return;}
   
   //判断为0的情况
   if(parseInt(obj.value)==0)
   {
      removeSuitOnShoppingCart(suitId,obj);
      return;
   }
   setAjaxBase("GET","action=changeSuitCount&suitId="+suitId+"&suitCount="+obj.value+"&provinceId=0",null,false,obj,null,"var pos=new getPos(curBtn);showProductListHtml(backValue);showChangeSucTip(pos,'套装');","isHaveAjaxServer=false;");

   
}
//删除套装
function removeSuitOnShoppingCart(suitId,obj)
{
   if(confirm('确定不购买该套装？'))
   {
      setAjaxBase("GET","action=removeSuitOnShoppingCart&suitId="+suitId+"&provinceId=0",null,false,obj,null,"showProductListHtml(backValue);EventOnSkuChange();","isHaveAjaxServer=false;");
   }else{isHaveAjaxServer=false;}
}
//删除套装中的一个商品
function removeProductInSuit(suitId,productId,obj)
{
   if(confirm('确定取消该商品？'))
   {
      setAjax_runCodeAndBtn("action=removeProductInSuit&suitId="+suitId+"&productId="+productId+"&provinceId=0",obj,"showProductListHtml(backValue);");
   }
}
//更改赠品数量
function changeGiftCount(giftId,obj)
{
  if(obj.value==obj.nextSibling.value){isHaveAjaxServer=false;return;}
   //检测输入是否为数字
   var myReg=/\d+/;
   if(!checknumber(obj.value)){isHaveAjaxServer=false;showAlert_shoppingCart("您输入的格式不正确！",obj);obj.value=obj.nextSibling.value;return;}
   
   //判断为0的情况
   if(parseInt(obj.value)==0)
   {
      removeGiftOnShoppingCart(giftId,obj);
      return;
   }
   setAjaxBase("GET","action=changeGiftCount&giftId="+giftId+"&giftCount="+obj.value+"&provinceId=0",null,false,obj,null,"var pos=new getPos(curBtn);showProductListHtml(backValue);showChangeSucTip(pos,'商品');","isHaveAjaxServer=false;");
}
//删除赠品
function removeGiftOnShoppingCart(giftId,obj)
{
   if(confirm('确定不购买该商品？'))
   {
     setDelSku(obj,giftId);
     setAjaxBase("GET","action=removeGiftOnShoppingCart&giftId="+giftId+"&provinceId=0",null,false,obj,null,"showProductListHtml(backValue);setDelSkuShow();EventOnSkuChange();","isHaveAjaxServer=false;");
   }
}
//清空购物车
function clearCart()
{
   if(confirm('确定清空购物车吗？'))
   {
      setAjax_runCode("action=clearCart","showProductListHtml(backValue);EventOnSkuChange();");
   }
}
//暂存购物车
function saveCart()
{
       if(!isLogin)
       {
          //登录弹出
          jdModelCallCenter.settings={'clstag1':"login|keycount|5|5",'clstag2':"login|keycount|5|6",'fn':function(){setAjax_runCode("action=saveCart","alert('购物车中的商品已成功寄存！');");if(g('panelJCcart')!=null)g('panelJCcart').style.display='none';isLogin=true;}};
          jdModelCallCenter.login();
       }
       else
       {
          setAjax_runCode("action=saveCart","alert('购物车中的商品已成功寄存！');");
       }
  
}
function GetStoreCart()
{
       if(!isLogin)
       {
          //登录弹出
          jdModelCallCenter.settings={'clstag1':"login|keycount|5|5",'clstag2':"login|keycount|5|6",'fn':function(){setAjax_runCode("action=GetStoreCart","if(backValue='ok'){alert('购物车之前寄存的商品已成功取出！');ShowShoppingCart();}");if(g('panelJCcart')!=null)g('panelJCcart').style.display='none';isLogin=true;}};
          jdModelCallCenter.login();
       }
       else
       {
           setAjax_runCode("action=GetStoreCart","if(backValue='ok'){alert('购物车之前寄存的商品已成功取出！');ShowShoppingCart();}");
       }
  
}
//刷新库存
function showStockInfo()
{
  var runCode="if(g('stockErrorPanel').innerHTML==''){g('stockErrorPanel').style.display='none'}else{g('stockErrorPanel').style.display=''}";
  setAjax_getResAndRunCode("action=showStockInfo","stockErrorPanel",runCode);
}


//进入订单详细页
function GoToOrder(obj)
{
  try
  {
       if(!isLogin)
       {
          //登录弹出
          // OrderInfoUrl += "?regsuc=cart";
          jdModelCallCenter.settings={'url':OrderInfoUrl,'clstag1':"login|keycount|5|5",'clstag2':"login|keycount|5|6",'fn':function(){jdModelCallCenter.autoLocation(this.url);}};
          jdModelCallCenter.login();
       }
       else
       {
            g('submit_info').style.display='';
            g('submit_info').innerHTML="<span class='submitSuccess'>正在转向订单信息填写页面，请稍候！</span>";
            g('submit_btn').style.display='none';
            window.location=OrderInfoUrl;
       }
       
   }
   catch(e)
   {
       window.location=OrderInfoUrl;
   }
}

var orderInfoType=0;//0:正常 1:分期
function runOrderInfo(obj)
{
   g('submit_info').style.display='';
   g('submit_info').innerHTML="<span class='submitSuccess'>正在转向订单信息填写页面，请稍候！</span>";
   g('submit_btn').style.display='none';
   orderInfoType=0;
   if(isHaveAjaxServer){setOnclick(obj)}
   else{g('BtnRunOrder_server').click();}
}
function runOrderInfo_fq(obj)
{
   g('submit_info').style.display='';
   g('submit_info').innerHTML="<span class='submitSuccess'>正在转向分期订单信息填写页面，请稍候！</span>";
   g('submit_btn').style.display='none';
   orderInfoType=1;
   if(isHaveAjaxServer){setOnclick(obj)}
   else{g('BtnRunOrder_server').click();}
}
var waitTime=0;
function setOnclick()
{
   if(isHaveAjaxServer){
      if(waitTime>120){waitTime=0;g('BtnRunOrder_server').click(); }
      else{waitTime++;setTimeout("setOnclick()",10);}
   }
   else{g('BtnRunOrder_server').click();}
}

//进入订单填写页
function runOrderInfo_server(obj)
{
  g("submit_error").innerHTML='';
  var actionType="";
  if(orderInfoType==0){
      actionType="runOrderInfo";
  }
  if(orderInfoType==1){
      actionType="runOrderInfo_fq";
  }
  setAjax_runCodeAndBtn("action="+actionType,obj,"setCartSubmitRes(backValue)");
 }
function setCartSubmitRes(bakValue)
{
   clearWaitInfo();
   
   if(bakValue.indexOf('submitError_')==0)
   {
      g('submit_btn').style.display='';
      g('submit_info').innerHTML='';
      g('submit_info').style.display='none';
      showAlert(bakValue.substr(12),g("submit_error"),"");
      //刷库存
      showStockInfo();
      
   }
   if(bakValue.indexOf('url_')==0)
   {
      var urlStr=bakValue.substr(4);
      urlStr=urlStr.split('@@');
      window.location=urlStr[1];
   }
}

function GetBISkuForCart()
{
   var runCode="if(backValue!=''){g('sbox_1').style.display='';g('BIcart').innerHTML=backValue;}";
   setAjax_runCode("action=GetBISkuForCart",runCode);
}

//添加商品到购物车
function AddProduct(productId,productCount,obj)
{
   setAjax_runCode("action=AddProduct&productId="+productId+"&productCount="+productCount,"ShowShoppingCart();EventOnSkuChange();");
   SetCartBuyCount(productId);
}


//BI相关
function setCartBILinkCount(skuId)
{
   try{
       
           var js=document.createElement('script');
           js.type='text/javascript';
           js.src='http://counter.360buy.com/aclk.aspx?key=cartLink_'+skuId;
           //js.charset='UTF-8';
           document.getElementsByTagName('head')[0].appendChild(js);
           
   }catch(e){}
}
function setCartBILinkImgCount(skuId)
{
   try{
           var js=document.createElement('script');
           js.type='text/javascript';
           js.src='http://counter.360buy.com/aclk.aspx?key=cartImgLink_'+skuId;
           //js.charset='UTF-8';
           document.getElementsByTagName('head')[0].appendChild(js);
   }catch(e){}
}
function SetCartBuyCount(skuId)
{
   try{
           var js=document.createElement('script');
           js.type='text/javascript';
           js.src='http://counter.360buy.com/aclk.aspx?key=cartBuyLink_'+skuId;
           //js.charset='UTF-8';
           document.getElementsByTagName('head')[0].appendChild(js);
   }catch(e){}
}
function DeledSku()
{
   this.Id='';
   this.Name='';
   this.Price='';
   this.Num='';
}
var delSku=null;
var reAddSku=null;
function setDelSku(obj,skuId)
{
   try{
       delSku=new DeledSku();
       var trObj=obj.parentNode.parentNode;
       
       delSku.Id=trObj.cells[0].innerHTML;
       delSku.Name=trObj.cells[1].childNodes[1].innerHTML;
       delSku.Price=trObj.cells[2].innerHTML;
       delSku.Num=document.getElementsByName('hidChange'+skuId)[0].value;
   }catch(e){}
   
}
function setDelSkuShow()
{
  try{
       if(g('divDeledSku')==null)return;
       if(delSku!=null && delSku.Id!='')
       {
          var dHtml="<table class='delItem'><tr>";
          dHtml+="<td style='width:70px'>"+delSku.Id+"</td>";
          dHtml+="<td style='text-align:left'>"+delSku.Name+"</td>";
          dHtml+="<td style='width:150px'>"+delSku.Price+"</td>";
          dHtml+="<td style='width:125px'>"+delSku.Num+"</td>";//onclick=\"SaveFavorite('"+delSku.Id+"')\"
          dHtml+="<td style='width:100px'><a href='#none' onclick=\"AddProduct('"+delSku.Id+"','"+delSku.Num+"',this);reAddedSku('delSku"+delSku.Id+"');\" clstag='clickcart|keycount|shoppingcartpop|reAddedSku'>重新购买</a> | <a href='#none' onclick=\"SaveConcern('"+delSku.Id+"')\" clstag='clickcart|keycount|shoppingcartpop|SaveFavorite'>关注</a></td>";
          dHtml+="</tr></table>";
          
          if(g('divDeledSku').childNodes.length>0)
          {
             dHtml="<div class='delSplit'></div>"+dHtml;
          }
          g('divDeledSku').innerHTML+="<div class='delItem' id='delSku"+delSku.Id+"'>"+dHtml+"</div>";
          
       }
       if(g('divDeledSku').childNodes.length>0)
       {
          g('DeledSkuInfo').style.display=''
       }
       delSku=null;
   }catch(e){}
}
function reAddedSku(reAddDivId)
{
  try{
       g('divDeledSku').removeChild(g(reAddDivId));
       if(g('divDeledSku').childNodes.length==0)
       {
          g('DeledSkuInfo').style.display='none';
       }else{
         if(g('divDeledSku').childNodes[0].childNodes.length==2)
         {
            g('divDeledSku').childNodes[0].removeChild(g('divDeledSku').childNodes[0].childNodes[0]);
         }
       }
   }catch(e){}
}
function SaveFavorite(skuId)
{
  try{
   var js=document.createElement('script');
   js.type='text/javascript';
   js.src=ajaxUrl+"?action=SaveFavorite&url="+escape('http://jd2008.360buy.com/homeservice.aspx?callback=SaveFavorite_callback&method=SaveFavorite&productId='+skuId);
   //js.charset='UTF-8';
   //document.write(js.src);
   document.getElementsByTagName('head')[0].appendChild(js);
   }catch(e){}
   
}
function SaveFavorite_callback(result)
{
   if (result.SaveFavorite != null)
	{
		alert('收藏成功！');
		setFavInfo()
	}
}
function changeBar(type,skuId,obj,skuType)
{
    var txtC=null;
    var change=0;
    if(type=='+')
    {
      txtC=obj.previousSibling.previousSibling;
      change=1;
    }
    if(type=='-')
    {
      txtC=obj.nextSibling;
      change=-1;
    }
    var num=parseInt(txtC.value);
    if(num+change<0)
    {
       alert('您输入的数字已经超出的最小值');
       return;
    }
    txtC.value=num+change;
    //txtC.focus();
    if(skuType=='sku')changeProductCount(skuId,txtC);
    else if(skuType=='gift')changeGiftCount(skuId,txtC);
    else if(skuType=='suit')changeSuitCount(skuId,txtC);
    else if(skuType=='skuInSuit')
    {
      var pinfo=skuId.split('_');
      changeSkuInSuitCount(pinfo[0],pinfo[1],txtC);
    }
    
}
//收藏
function setFavInfo()
{
//    try{
//       if(g('myPin').innerHTML!='')
//       {
//           g('collection').style.display='';
//           getFavInfo();
//       }
//       }catch(e){}
}
//得到收藏夹信息
function getFavInfo()
{
   setAjax_getResAndRunCode("action=getFavInfo","favSkuInfo","try{log('shoppingcartpop', 'collection');}catch(e){}GetStockList();");
   //setAjax_getRes("action=getFavInfo","favSkuInfo");
   //alert('l');
   //setAjax("GET","action=getFavInfo",null,false,obj,"favSkuInfo","GetStockList();");
}
function DelFav(skuId,obj)
{
   setAjax("GET","action=DelFav&skuId="+skuId,null,false,obj,"favSkuInfo","GetStockList();")
}
//显示延保信息
//function getCartYbInfo()
//{
//   setAjax_getResAndRunCode("action=ShowYbInfo","ybPanel","try{if(g('ybPanel').innerHTML!=''){log('shoppingcartpop','ybPanel');}}catch(e){}");
//}
function getCartYbInfo()
{
   setAjaxBaseByUrl(OtherSiteUrl,"GET","action=ShowYbInfo",null,false,null,"ybPanel","try{if(g('ybPanel').innerHTML!=''){log('shoppingcartpop','ybPanel');}}catch(e){}","");
}
//添加延保到购物车
function AddYBsku(ybId,num,rWid,rSuit)
{
   setAjax_runCode("action=AddYBsku&ybId="+ybId+"&num="+num+"&rWid="+rWid+"&rSuit="+((rSuit=="")?'0':rSuit),"if(backValue=='ok')ShowShoppingCart();");
}
//显示暂存降价
function getCartPromo()
{
  if(g('myPin')!=null && g('myPin').innerHTML!='')
  {
      setAjaxBaseByUrl(OtherSiteUrl,"GET","action=getCartPromoInfo",null,false,null,null,"if(backValue!='')g('cartPromoPanel').innerHTML=backValue;","");
  }
}
//购物车中的商品(不是数量)发生变化时
function EventOnSkuChange()
{
  //延保
  getCartYbInfo();
  //收藏夹降价提示
  getCartPromo();
}




//---------------------贺卡--------------------
function Card_show(skuId,message,fun)
{
    var cardTest=new Card();
    cardTest.Fun="Card_ReBuildCard('change')";
    cardTest.Url=null;
    cardTest.Show();
}
function Card_ReBuildCard(type)
{
  setAjax_runCode("action=ReBuildCard&atype="+type,"ShowShoppingCart();");
}
function Card_Add()
{
    var cardTest=new Card();
    cardTest.Fun="Card_ReBuildCard('add')";
    cardTest.Url=null;
    cardTest.Show();
}
//---------------------以旧换新--------------------
function TradeIn_Apply(skuId)
{
   if(confirm('确认要申请以旧换新吗？'))
      setAjax_runCode("action=TradeIn_Apply&SkuId="+skuId,"TradeIn_Apply_Callback(backValue);");
}
function TradeIn_Apply_Callback(result)
{
   if(result=='NoLogin')
   {
      //登录
      if(confirm('此业务需登录后才能申请，现在去登录？'))
      {
           ToLogin();
      }
   }
   else if(result=='NoConfig')
   {
       alert('抱歉,此商品目前无法申请‘以旧换新’业务！');
   }
   else if(result=='ok')
   {
       alert('申请成功！您将享受到‘以旧换新’的优惠！');
       CalcCart();
   }
}


//-----------------------促销--------------------------

function ShowGiftsSelectPanel(obj,promId)
{
   var pos=new getPos(obj);
    var html="<div class='giftselect' id='GiftsSelectPanel'>";
   html+="<div style='text-align:center;padding:10px 0 10px 0;'>请稍等，正在为您读取赠品列表...</div>";
   html+="</div>";
   showMessageBoxBase(html,pos,500,'selectGiftP');
   setAjax_runCode("action=GetGiftSelect&promId="+promId,"ShowGiftsSelectPanel_callback(backValue);");
}
function ShowGiftsSelectPanel_callback(jsonStr)
{
  var obj=eval("("+jsonStr+")");
  var panel=g('GiftsSelectPanel');
  var html="";
  if(obj.CanSelect.length==0)
  {
     html="没有可供选择的赠品。。。";
  }else{
     html="请选择您想要的赠品：<div style='overflow:auto;height:190px;'><table style='width:98%'>";
    for(var i=0;i<obj.CanSelect.length;i++)
    {
        html+="<tr>";
        html+="<td style='width:30px;padding-left:5px;'><input type='radio' name='canselectItem' value='"+obj.CanSelect[i].Id+"' /></td>";
        html+="<td style='width:65px'><a href='http://www.360buy.com/product/"+obj.CanSelect[i].Id+".html' target='_blank'><img src='http://img10.360buyimg.com/n4/"+obj.CanSelect[i].ImgUrl+"' /></td>";
        html+="<td><a href='http://www.360buy.com/product/"+obj.CanSelect[i].Id+".html'  target='_blank'>" + obj.CanSelect[i].Name + "</a></td>";
        html+="<td style='width:80px;padding-left:3px;'>价值:<font color='red'>" + +obj.CanSelect[i].Price + "</font>元</td>";
        html+="</tr>";
    }
    html+="</table></div>";
  }
  html+="<div style='text-align:center;padding:5px 0 10px 0'><input type='button' value='确 定' onclick=\"AddGiftToSuit('"+obj.PromId+"');\" />&nbsp;<input type='button' value='关 闭' onclick=\"closeWindowBase('selectGiftP');\" /></div>";
  
  panel.innerHTML=html;
}
function AddGiftToSuit(promId)
{
    var items=document.getElementsByName('canselectItem');
    var idStr='';
    for(var i=0;i<items.length;i++)
    {
        if(items[i].checked)
           idStr+=items[i].value+":1,";
    }
    if(idStr==''){
       alert('请选择您想要的赠品！');
       return;
    }
    idStr=idStr.substring(0,idStr.length-1);
    setAjax_runCode("action=AddGiftToSuit&promId="+promId+"&pids="+idStr,"AddGiftToSuit_callback(backValue);");
}
function AddGiftToSuit_callback(obj)
{
   if(obj=="ok")
   {
      closeWindowBase('selectGiftP');
      ShowShoppingCart();
   }
}
function changeSkuInSuitCount(suitId,skuId,obj)
{
   if(obj.value==obj.nextSibling.value){isHaveAjaxServer=false;return;}
   //检测输入是否为数字
   if(!checknumber(obj.value)){isHaveAjaxServer=false;showAlert_shoppingCart("您输入的格式不正确！",obj);obj.value=obj.nextSibling.value;return;}
   
   //判断为0的情况
   if(parseInt(obj.value)==0)
   {
      removeProductInSuit(suitId,skuId,obj);
      return;
   }
   setAjaxBase("GET","action=changeSkuInSuitCount&suitId="+suitId+"&skuId="+skuId+"&num="+obj.value+"&provinceId=0",null,false,obj,null,"var pos=new getPos(curBtn);showProductListHtml(backValue);showChangeSucTip(pos,'商品');","isHaveAjaxServer=false;");

}
function removeGiftInPromSuit(suitId,skuId,obj)
{
   setAjaxBase("GET","action=removeGiftInPromSuit&suitId="+suitId+"&skuId="+skuId+"&provinceId=0",null,false,obj,null,"showProductListHtml(backValue);","isHaveAjaxServer=false;");
}
function CancelSkuInPromSuit(suitId,skuId,obj)
{
   setAjaxBase("GET","action=CancelSkuInPromSuit&suitId="+suitId+"&skuId="+skuId+"&provinceId=0",null,false,obj,null,"showProductListHtml(backValue);","isHaveAjaxServer=false;");
}






function memberPrice(){
	$.extend(jdModelCallCenter.settings,{
		clstag1:0,
		clstag2:0,
		url:location.href,
		fn:function(){
			jdModelCallCenter.autoLocation(this.url);
		}
	});
	jdModelCallCenter.settings.fn();
}


function showshoppingcartSuitError(backvalue)
{
    if(backvalue.indexOf('error_')==-1)
    {
        setAjaxBaseByUrl(OtherSiteUrl,"GET","action=showshoppingcartSuitError",null,false,null,null,"showshoppingcartSuitError_callback(backValue);","");
    }
}

function showshoppingcartSuitError_callback(backValue)
{
   var errorStr='';
   if(backValue!='' && backValue.indexOf('error_')==-1)
   {
       var skuList = backValue.split(',');
       for(var i=0;i<skuList.length;i++)
       {
          errorStr += "<a target='_blank' href='http://www.360buy.com/product/"+skuList[i]+".html' onclick='this.blur();'>" + skuList[i] + "</a>;";
       }
   }
   if(errorStr.length>0)
      g('adviceSuitSkuRemovePanel').innerHTML="<div class='shoppingTip'>抱歉：由于以下商品正在参加满减促销 "+errorStr+"<br/>只能支持先款结算，如需要自提或货到付款，请删除商品并继续结算其它商品。</div>";
   else if(g('adviceSuitSkuRemovePanel').innerHTML!='')
   {
     g('adviceSuitSkuRemovePanel').innerHTML='';
   }
}

function setConcern()
{
    try{
       if(g('myPin').innerHTML!='')
       {
            //关闭购物车下方关注显示
           //g('collection').style.display='';
           //以后添加获取关注
       }
       }catch(e){}
}

function SaveConcern(skuId)
{
  try{
     if(g('myPin').innerHTML!='')
     {
       $.ajax({
        type: "GET",
        url: "http://t.360buy.com/regard/follow.action",
        data: "goodId="+skuId,
        dataType:"jsonp",
        success: function(result){
            if(result.code=="success"||result.code=="E004")
                alert("关注成功！");
            else
                alert("关注失败！");
        },
        error:function(result){
            alert("关注失败！");
        }
       }); 
     }
     else
     {
        alert( "您还没有登录系统，目前无法使用此功能!" );
     }
   }catch(e){}   
}


//筛选库房
function changeStore(obj)
{
    setAjaxBase("GET","action=changeStore&provinceId="+obj.value,null,false,obj,null,"showProductListHtml(backValue);","isHaveAjaxServer=false;");
}

function selectAllSku(obj)
{
    var cartObj=g('CartTb'); 
    if(cartObj.rows.length>1)
    {
        setAjaxBase("GET","action=selectAllSku&isSelected="+((obj.checked)?"1":"0")+"&provinceId=0",null,false,obj,null,"showProductListHtml(backValue);","isHaveAjaxServer=false;");
    }
}

function selectSkuInPormSuit(suitId,skuId,obj)
{
    var cartObj=g('CartTb'); 
    if(cartObj.rows.length>1)
    {
        setAjaxBase("GET","action=selectSkuInPormSuit&suitId="+suitId+"&skuId="+skuId+"&isSelected="+((obj.checked)?"1":"0")+"&provinceId=0",null,false,obj,null,"showProductListHtml(backValue);","isHaveAjaxServer=false;");
    }
}

function selectSuitOnShoppingCart(suitId,obj)
{
    var cartObj=g('CartTb'); 
    if(cartObj.rows.length>1)
    {
        setAjaxBase("GET","action=selectSuitOnShoppingCart&suitId="+suitId+"&isSelected="+((obj.checked)?"1":"0")+"&provinceId=0",null,false,obj,null,"showProductListHtml(backValue);","isHaveAjaxServer=false;");
    }
}

function selectGiftOnShoppingCart(giftId,obj)
{
    var cartObj=g('CartTb'); 
    if(cartObj.rows.length>1)
    {
        setAjaxBase("GET","action=selectGiftOnShoppingCart&giftId="+giftId+"&isSelected="+((obj.checked)?"1":"0")+"&provinceId=0",null,false,obj,null,"showProductListHtml(backValue);","isHaveAjaxServer=false;");
    }
}

function selectProductOnShoppingCart(skuId,obj)
{
    var cartObj=g('CartTb'); 
    if(cartObj.rows.length>1)
    {
        setAjaxBase("GET","action=selectProductOnShoppingCart&skuId="+skuId+"&isSelected="+((obj.checked)?"1":"0")+"&provinceId=0",null,false,obj,null,"showProductListHtml(backValue);","isHaveAjaxServer=false;");
    }
}

function ProductNotify(productId,key,opType,callback) {
    var send="SendNotify("+productId+",\""+key+"\","+opType+")";
	$.jdThickBox({
		type: "text",
		title: "删除商品",
		width: 280,
		height: 150,
		source: "<div class='form' id='form1'><p>您确定删除本商品吗？</p><div class='item'><div class='fl'><input name='' id='notifyck"+opType+"' type='checkbox' value='' class='check' /><label for='notifyck"+opType+"'>商品到货时，请以下方邮件告知我</label></div><div class='clr'></div><div><div class='item'><div class='fl'><input type='text' id='txtEmail"+opType+"' class='text' value='填写您的EMAIL' class='text' onblur=\"if(this.value==''||this.value=='填写您的EMAIL'){this.value='填写您的EMAIL';this.style.color='#cccccc'}\" onfocus=\"if(this.value=='填写您的EMAIL'){this.value='';};this.style.color='#000000';\"/></div><div class='clr'></div></div><div class='item'><div class='fl'><a href='#none' onclick='"+callback+";"+send+";jdThickBoxclose();' class='btn_storage'><s></s>确定</a><a href='#none' onclick='jdThickBoxclose();' class='btn_storage'><s></s>取消</a></div><div class='clr'></div></div></div>",
		_autoReposi: true
	});
}
function PriceNotify(productId,key,opType,callback) {
    var send="SendNotify("+productId+",\""+key+"\","+opType+")";
	$.jdThickBox({
		type: "text",
		title: "删除商品",
		width: 300,
		height: 150,
		source: "<div class='form' id='form2'><p>确定不购买此商品？</p><div class='item'><div class='fl'><input name='' id='notifyck"+opType+"' type='checkbox' value='' class='check' /><label for='notifyck"+opType+"'>商品降价时，请以下方邮件告知我：</label></div><div class='clr'></div><div><div class='item'><div class='fl'><input type='text' id='txtEmail"+opType+"' class='text' value='填写您的EMAIL' class='text' onblur=\"if(this.value==''||this.value=='填写您的EMAIL'){this.value='填写您的EMAIL';this.style.color='#cccccc'}\" onfocus=\"if(this.value=='填写您的EMAIL'){this.value='';};this.style.color='#000000';\"/></div><div class='clr'></div></div><div class='item'><div class='fl'><a href='#none' onclick='"+callback+";"+send+";jdThickBoxclose();' class='btn_storage'><s></s>确定</a><a href='#none' onclick='jdThickBoxclose();' class='btn_storage'><s></s>取消</a></div><div class='clr'></div></div></div>",
		_autoReposi: true
	});
}

function showNotify(productId,opType,key,callback)
{
    if(opType=="1")
    {
       PriceNotify(productId,key,opType,callback);
    }
    else if(opType=="2")
    {
        ProductNotify(productId,key,opType,callback);
    }
}
 
function SendNotify(productId,key,opType)
{
   try
  {
   if(g('notifyck'+opType).checked)
   {
       var email=g('txtEmail'+opType).value;
       if(check_email(email))
       {
          jQuery.ajax({
            type: "get",
            dataType : "jsonp",   
            url:"http://notify.home.360buy.com/addNotifyInterface.action?callback=?",
            data: {
                skuid: productId,
                type:opType,
                email:escape(email),
                key:key,
                userSource:"2"
            },
            success: function(jsons) {    
            }
        });
       }
   }
   }
   catch(e){}
}

function check_email(email)
{  
   if(email){
   var myReg=/(^\s*)\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*(\s*$)/;
   if(!myReg.test(email)){return false;}
   return true;
   }
   return false;
}

function setCheckBoxDisable()
{
  var nodes = document.getElementsByTagName("input");
  if(nodes.length>0){
     for(var i=0;i<nodes.length;i++){ 
        if(nodes[i].type=="checkbox"){
            nodes[i].disabled="disabled";
        }
    }
  }
}
// JScript 文件
//验证email
function isEmail(obj){
    var pattern = /^\w+((-\w+)|(\.\w+))*\@[A-Za-z0-9]+((\.|-)[A-Za-z0-9]+)*\.[A-Za-z0-9]+$/;
    if (pattern.test(obj.value)) {
        return true;
    }else{
       alert("对不起，请输入正确格式的E-mail！");
       $(obj).val("");   
       return false;
    }
 

}

//验证电话号码
function isTelephone(obj) {

    //var pattern = /^([0-9]{3,4}\-[1-9]{1}[0-9]{6,7})+(\-[0-9]{1,4})?$/;
    var pattern = /^([1-9]{1}[0-9]{6,7})+(\-[0-9]{1,4})?$/;
    if (pattern.test(obj.value)) {
        return true;
    }else{
       alert("对不起，请输入正确格式的电话号码！");
       $(obj).val("");
       //obj.value = ''; 
       return false;
    }
}

//验证电话号码
function isFax(obj) {

    var pattern = /^([1-9]{1}[0-9]{6,7})+(\-[0-9]{1,4})?$/;
    if (pattern.test(obj.value)) {
        return true;
    } else {
        alert("对不起，请输入正确格式的传真号！");
        $(obj).val("");
        //obj.value = ''; 
        return false;
    }
}

//验证手机号码
function isMobilePhone(obj){
    var pattern = /^(1[3,5,8]{1}[0-9]{9})|([0-9]{3,4}\-[2-9]{1}[0-9]{6,7})$/;
     
    if(pattern.test(obj.value)){
        return true;
    }else{
        alert("对不起，请输入正确格式的手机号码！");
        $(obj).val("");  
        return false;
    }
}

//数字或者字母一起验证
function isNumOrLetter(param){
    var pattern = /(^[A-Za-z0-9]{3,20}$)/;
    if(pattern.test(param)){
        return true;
    }else{
        return false;
    }
}

//打开新窗口
function OW(URL,TYPE,SC,iW,iH,TOP,LEFT,R,S,T,TB)
{
	var sF="dependent=yes,resizable=no,toolbar=no,status=no,directories=no,menubar=no,";
	

	sF+="scrollbars="+(SC?SC:"NO")+",";
	
	if (TYPE=="full"){
		sF+=" Width=1010,";
		sF+=" Height=750,";
		sF+=" Top=0,";
		sF+=" Left=0,";
		window.open(URL, "_blank", sF, false);
		return;
	}
	
	
	if (TYPE=="modal"){
		sF ="resizable:no; status:no; scroll:yes;";
		if(iW!=undefined && iH!=undefined){
			sF+=" dialogWidth="+iW+"px;";
			sF+=" dialogHeight="+iH+"px;";
		}
		else{
			sF+=" dialogWidth=800px;";
			sF+=" dialogHeight=570px;";
		}
	
			if(parent.length<2){
				sF+="dialogTop:"+(parseInt(parent.dialogTop)+25)+"px;";					
				sF+="dialogLeft:"+(parseInt(parent.dialogLeft)+25)+"px;";
				}
		
		var alpha = '?';
		var _URL = URL;
		var unique = (new Date()).getTime();
		//如果没有参数		
		if (_URL.indexOf(alpha) == -1){
			_URL+= "?time="+unique;
		}
		else
		{
		//如果带有参数，含有‘?’
			_URL+= "&time="+unique;
		}
		//alert(_URL.indexOf(alpha));alert(_URL);
		return window.showModalDialog(_URL,window,sF);
	}
	else if (TYPE=="modeless"){
		
		sF ="resizable:no; status:no; scroll:yes;";
		sF+=" dialogWidth:800px;";
		sF+=" dialogHeight:570px;";
			if(parent.length<2){
				sF+="dialogTop:"+(parseInt(parent.dialogTop)+25)+"px;";					
				sF+="dialogLeft:"+(parseInt(parent.dialogLeft)+25)+"px;";
				}
		
		var alpha = '?';
		var _URL = URL;
		var unique = (new Date()).getTime();
		//如果没有参数		
		if (_URL.indexOf(alpha) == -1){
			_URL+= "?time="+unique;
		}
		else
		{
		//如果带有参数，含有??
			_URL+= "&time="+unique;
		}
		//alert(_URL.indexOf(alpha));alert(_URL);
		return window.showModelessDialog(_URL,window,sF);
	}	
	else
	{
		if(iW!=undefined && iH!=undefined){
			sF+=" Width="+iW+",";
			sF+=" Height="+iH+",";
		}
		else{
			sF+=" Width=800,";
			sF+=" Height=570,";
		}
		if(window.opener==null || window.opener==undefined){
		    if(TOP==undefined){
		     sF+=" Top=0px,";
		    }else{
		     sF+=" Top=50px,";
		    }
			
			sF+=" Left=50px,";
		}else{
			sF+="Top="+(parseInt(window.screenTop)+20)+"px,";					
			sF+="Left="+(parseInt(window.screenLeft)+30)+"px,";
		}		
		sF+=" scrollbars=yes,"
		window.open(URL, "_blank", sF, false);
	
	}
}

//控制文本狂只能输入数字
function numEnter(obj){
    var pattern = /^\d+(\.?\d*)?$/;
    var org = $(obj).val();
    
    if(!pattern.test($(obj).val())){
        alert('输入框中含有非法字符,只能输入数字');
        $(obj).val("");
        return false;
    }else{
       if(org.substring(0,1)=="0" && org.substring(1,2) != "."){
             $(obj).val(org.substring(1));
       }
    }
}
 




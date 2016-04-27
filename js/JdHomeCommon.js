//例如：2003-12-05
function strShortDateTime(str) {
    var r = str.match(/^(\d{1,4})(-|\/)(\d{1,2})\2(\d{1,2})$/);
    if (r == null) return false;
    var d = new Date(r[1], r[3] - 1, r[4]);
    return (d.getFullYear() == r[1] && (d.getMonth() + 1) == r[3] && d.getDate() == r[4]);
}

//长时间，形如 (2003-12-05 13:04:06)
function strLongDateTime(str) {
    var reg = /^(\d{1,4})(-|\/)(\d{1,2})\2(\d{1,2}) (\d{1,2}):(\d{1,2}):(\d{1,2})$/;
    var r = str.match(reg);
    if (r == null) return false;
    var d = new Date(r[1], r[3] - 1, r[4], r[5], r[6], r[7]);
    return (d.getFullYear() == r[1] && (d.getMonth() + 1) == r[3] && d.getDate() == r[4] && d.getHours() == r[5] && d.getMinutes() == r[6] && d.getSeconds() == r[7]);
}

//短时间，形如 (13:04:06)
function isLongTime(str) {
    var a = str.match(/^(\d{1,2})(:)?(\d{1,2})\2(\d{1,2})$/);
    if (a == null) { alert('输入的参数不是时间格式'); return false; }
    if (a[1] > 24 || a[3] > 60 || a[4] > 60) {
        alert("时间格式不对");
        return false
    }
    return true;
}


//验证是否为数字
function isNumber(oNum) {
    if (!oNum) return false;
    var strP = /^\d+(\.\d+)?$/;
    if (!strP.test(oNum)) return false;
    try {
        if (parseFloat(oNum) != oNum) return false;
    }
    catch (ex) {
        return false;
    }
    return true;
}

//验证是否为金额
function isDigit(s) { var patrn = /^-?\d+\.{0,}\d{0,}$/; if (!patrn.exec(s)) { return false } else { return true } }


//验证是否为空
function isNull(str) {
    var result = false;
    str = lrTrim(str);
    if (str.length == 0) {
        result = true;
    }
    return result;
}

//通过id获取当前对象
function g(objId) {
    return document.getElementById(objId);
}
//去除左右边空格
function lTrim(str) {
    if (str.charAt(0) == " ") {
        //如果字串左边第一个字符为空格 
        str = str.slice(1); //将空格从字串中去掉 
        //这一句也可改成 str = str.substring(1, str.length); 
        str = lTrim(str);    //递归调用 
    }
    return str;
}
//rTrim()去掉字串右边的空格 
function rTrim(str) {
    var iLength;
    iLength = str.length;
    if (str.charAt(iLength - 1) == " ") {
        //如果字串右边第一个字符为空格 
        str = str.slice(0, iLength - 1); //将空格从字串中去掉 
        //这一句也可改成 str = str.substring(0, iLength - 1); 
        str = rTrim(str);    //递归调用 
    }
    return str;
}
//trim() 去掉字串两边的空格 
function lrTrim(str) {
    return lTrim(rTrim(str));
}
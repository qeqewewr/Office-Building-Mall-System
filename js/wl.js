//Cookies操作//---------------------------------------------------------------
function setCookie(name, value, date)//两个参数，一个是cookie的名子，一个是值
{
    var Days = date;
    var exp = new Date();    //new Date("December 31, 9998");
    exp.setTime(exp.getTime() + Days * 24 * 60 * 60 * 1000);
    document.cookie = name + "=" + escape(value) + ";expires=" + exp.toGMTString() + ";path=/;domain=.360buy.com";
}
function getCookie(name)//读取cookies函数
{
    var arr = document.cookie.match(new RegExp("(^| )" + name + "=([^;]*)(;|$)"));
    if (arr != null) return unescape(arr[2]); return null;
}
function readPinCookie(name)//读取cookies函数
{
    var arr = document.cookie.match(new RegExp("(^| )" + name + "=([^;]*)(;|$)"));
    if (arr != null) return arr[2]; return null;
}
function WritepinCookie(name, value, date) {
    var Days = date;
    var exp = new Date(); //new Date("December 31, 9998");
    exp.setTime(exp.getTime() + Days * 24 * 60 * 60 * 1000);
    document.cookie = name + "=" + value + ";expires=" + exp.toGMTString() + ";path=/;domain=.360buy.com";
}
//seClick('SEO', 'XT316', '402653')
function seClick(type, Kword, sku) {
    name = "seWids" + type;
    reWids = getCookie(name);
    if (reWids != null) {
        reWids = reWids.toString();
        var pos = reWids.indexOf(sku);
        if (pos < 0) {
            reWids = reWids + "," + sku;
        }
    }
    else {
        reWids = sku;
    }
    setCookie(name, reWids, 1);
    //记录点击次数
    log(2, 2, Kword, sku)
}
reCookieCube = "reWidsCube";
function reClickCube(type2, sku) {
    var reWidsClubCookies = eval('(' + getCookie(reCookieCube) + ')');
    if (reWidsClubCookies == null || reWidsClubCookies == '') {
        reWidsClubCookies = new Object();
    }
    if (reWidsClubCookies[type2] == null) {
        reWidsClubCookies[type2] = '';
    }
    var pos = reWidsClubCookies[type2].indexOf(sku);
    if (pos < 0) {
        reWidsClubCookies[type2] = reWidsClubCookies[type2] + "," + sku;
    }

    setCookie(reCookieCube, $.toJSON(reWidsClubCookies), 1);

    log(3, type2, sku);
}

//需要解析的reClick2的cookies,逗号分隔
reCookieNames = "reWidsClub,reWidsThirdRec,reWidsAttRec,reWidsOCRec,reWidsSORec";
reCookieCubeNames = "reWidsCube";
clstag_list = "";
var loguri = "http://csc.360buy.com/log.ashx?type1=$type1$&type2=$type2$&data=$data$&pin=$pin$&referrer=$referrer$&jinfo=$jinfo$&callback=?";
callback1 = function(data) {
    ;
}
log = function(type1, type2, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10) {
    var data = '';
    for (i = 2; i < arguments.length; i++) {
        data = data + arguments[i] + '|||';
    }
    var url = loguri.replace(/\$type1\$/, escape(type1));
    url = url.replace(/\$type2\$/, escape(type2));
    url = url.replace(/\$data\$/, escape(data));
    url = url.replace(/\$pin\$/, escape(decodeURIComponent(readPinCookie("pin"))));
    url = url.replace(/\$referrer\$/, escape(document.referrer));
    url = url.replace(/\$jinfo\$/, escape(''));
    $.getJSON(
            url,
            callback1
        );
}
//mark
mark = function(sku, type) {
    log(1, type, sku);
}
//页面点击截获
document.onclick = function funClick(e) {
    e = e || event;
    var tag = e.srcElement || e.target;
    var clstag = $(tag).attr('clstag');
    while (!clstag) {
        tag = tag.parentNode;
        if (!tag) {
            break;
        }
        if (tag.nodeName == 'BODY') {
            break;
        }
        clstag = $(tag).attr('clstag');
    }
    if (clstag) {
        var temp = clstag.split('|');
        var page = temp[0];
        var key = temp[1];
        var type1 = temp[2];
        var type2 = temp[3];
        switch (key) {
            case "keycount": 	//所有keycount的记录
                log(type1, type2, "keycount");
                break;
        }
    }
}
/////////////////////////////////////////////////////////////////////
var SucInfoMethod = {
    Init: function() {
        this.orderDetailMap = new HashMap();
        var ods = SucInfo_OrderDetail.split(",");
        for (var i = 0; i < ods.length; i++) {
            var values = ods[i].split(":");
            this.orderDetailMap.Set(values[0], values[1]);
            this.sku = values[0];
        }
    },
    GetSkuNum: function(sku) {
        return this.orderDetailMap.Get(sku);
    },
    Contains: function(sku) {
        return this.orderDetailMap.Contains(sku);
    },
    GetDefaultSku: function() {
        return this.sku;
    }
}

function loginfo(CartWare, rtype, name) { var strs = CartWare.split(','); var AllRecommendCookies = ""; var AllPrice = 0; var r = Math.floor(Math.random() * 35); for (var i = 0; i < strs.length; i++) { if (strs[i] != '' && strs[i].indexOf('#', 0) > 0) { var reWid = strs[i].split('#'); if (SucInfoMethod.Contains(reWid[0])) { AllPrice = Number(AllPrice) + Number(reWid[1]) * Number(SucInfoMethod.GetSkuNum(reWid[0])); AllRecommendCookies += reWid[0] + ","; log('4', name + rtype, SucInfo_OrderId, SucInfo_OrderType, SucInfo_OrderDetail, reWid[0], SucInfoMethod.GetSkuNum(reWid[0])); } } else if (strs[i] != '' && strs[i].indexOf('#', 0) < 0) { var reWid = strs[i]; if (SucInfoMethod.Contains(reWid)) { AllRecommendCookies += reWid + ","; log('4', name + rtype, SucInfo_OrderId, SucInfo_OrderType, SucInfo_OrderDetail, reWid, SucInfoMethod.GetSkuNum(reWid)); } } } if (AllRecommendCookies.length > 0) { log('4', '1', SucInfo_OrderId, SucInfo_OrderType, SucInfo_OrderDetail, AllRecommendCookies, AllPrice); } else if (r == 30) { log('4', name + rtype, SucInfo_OrderId, SucInfo_OrderType, SucInfo_OrderDetail, SucInfoMethod.GetDefaultSku(), SucInfoMethod.GetSkuNum(SucInfoMethod.GetDefaultSku())); } }
//页面载入
function funLoad() {
    var locationpathname = this.location.pathname.toLowerCase();
    var locationhostname = this.location.hostname.toLowerCase();
    if (readPinCookie('pin') != null && readPinCookie('pin').length > 0) {
        WritepinCookie('rpin', readPinCookie('pin'), 3);
    } //下单结果页的记录
    if (locationpathname.indexOf('succeed_', 0) >= 0) {
        //初始化订单成功页
        SucInfoMethod.Init();
        //原推荐下单统析(原cookie解析)
        var RecommendStr = "1:2:3:4:5:1a:1b:BR1:BR2:BR3:BR4:BR5:DDR:GR1:GR2:GR3:GR4:VR1:VR2:VR3:VR4:VR5:NR:CR1:CR2:CR3:SR1:SR2:SR3:SR4:Indiv&Simi:Indiv&OthC:Indiv&AllC";
        var RecommendStrSplit = RecommendStr.split(":");
        for (var i = 0; i < RecommendStrSplit.length; i++) {
            if (getCookie("reWids" + RecommendStrSplit[i]) != null && getCookie("reWids" + RecommendStrSplit[i]) != "") {
                loginfo(getCookie("reWids" + RecommendStrSplit[i]), RecommendStrSplit[i], "R");
            }
        }
        //首页下单统计
        var HomePageOrder = "p000:p100";
        var HomePageOrderSplit = HomePageOrder.split(":");
        for (var i = 0; i < HomePageOrderSplit.length; i++) {
            if (getCookie(HomePageOrderSplit[i]) != null && getCookie(HomePageOrderSplit[i]) != "") {
                log('HomePageOrder', HomePageOrderSplit[i]);
            }
        }
        //reClick2的推荐下单cookie解析
        var cookieNames = reCookieNames.split(',');
        for (var i = 0; i < cookieNames.length; i++) {
            var reWidsClubCookies = eval('(' + getCookie(cookieNames[i]) + ')');
            for (var k in reWidsClubCookies) {
                if (reWidsClubCookies[k] != '') {
                    loginfo(reWidsClubCookies[k], k.toString(), "R");
                }
            }
        }
        //reClickCube的推荐下单cookie解析
        var cookieCubes = reCookieCubeNames.split(',');
        for (var i = 0; i < cookieCubes.length; i++) {
            var reWidsClubCookies = eval('(' + getCookie(cookieCubes[i]) + ')');
            for (var k in reWidsClubCookies) {
                if (reWidsClubCookies[k] != '') {
                    loginfo(reWidsClubCookies[k], k.toString(), "Cube");
                }
            }
        }
        //搜索的下单cookie解析
        var searchStr = "SEO";
        var searchStrSplit = searchStr.split(":");
        for (var i = 0; i < searchStrSplit.length; i++) {
            if (getCookie("seWids" + searchStrSplit[i]) != null && getCookie("seWids" + searchStrSplit[i]) != "") {
                loginfo(getCookie("seWids" + searchStrSplit[i]), searchStrSplit[i], "S");
            }
        }


        log('7', '2', SucInfo_OrderId, SucInfo_OrderType, SucInfo_OrderDetail);
    }
    else if (locationpathname.indexOf('shoppingcart', 0) >= 0) {
        log('R2&Page', 'Show');
    }
    else if (locationpathname.indexOf('user_home', 0) >= 0) {
        log('R3&Page', 'Show');
    }
    else if (locationpathname.indexOf('initcart.aspx', 0) >= 0) {
        log('R4R5&Page', 'Show');
    }
    else if (locationpathname.indexOf('orderlist.aspx', 0) >= 0) {
        log('DDR&Page', 'Show');
    }
    else if (locationhostname == 'home.360buy.com') {
        if (locationpathname == '/') {
            log('R3&Page', 'Show');
        }
    }
}
function Clublog() {
    var locationpathname = this.location.pathname.toLowerCase();
    var locationhostname = this.location.hostname.toLowerCase();
    if (locationhostname == 'i.360buy.com') {
        if (locationpathname == '/user/info') {
            log('i', 'userinfo');
        }
        else if (locationpathname == '/user/userinfo/more.html') {
            log('i', 'userinfomore');
        }
    }
    else if (locationhostname.indexOf('t.360buy.com', 0) == 0) {
        if (locationpathname == '/') {
            log('t', 'homepage');
        }
        else if (/^\/[0-9]*$/.test(locationpathname)) {
            log("t", "individual");
        }
        else if (locationpathname == '/profile') {
            log('t', 'profile');
        }
        else if (locationpathname.indexOf('/search/', 0) == 0) {
            log('t', 'search');
        }
        else if (locationpathname == '/favorite') {
            log('t', 'favorite');
        }
        else if (locationpathname.indexOf('/follow/', 0) == 0) {
            log("t", "follow");
        }
        else if (locationpathname.indexOf('/fans/', 0) == 0) {
            log("t", "fans");
        }
        else if (locationpathname.indexOf('/blacklist/', 0) == 0) {
            log("t", "blacklist");
        }
        else if (locationpathname == '/reply') {
            log('t', 'reply');
        }
        else if (locationpathname == '/promotional') {
            log('t', 'promotional');
        }
        else if (locationpathname == '/home/follow/feed') {
            log('t', 'homefollowfeed');
        }
        else if (locationpathname == '/home/follow') {
            log('t', 'homefollow');
        }
    }
}

//加载页面时间统计
(function() {if (typeof jdpts != "object") {return}if (jdpts._cls) {log(jdpts._cls.split(".")[0], jdpts._cls.split(".")[1])}jdpts._allows = ["a1", "b5", "b6", "b7", "b8", "b9", "b10", "b11", "b12", "b13", "b14", "d1", "c1"];if (!jdpts._allows || jdpts._allows.length < 1) {return}jdpts._ct = new Date().getTime();jdpts._checkBrowser = function() {var browser = {name: "unknow",version: "0"},ua = navigator.userAgent.toLowerCase(),browserRegExp = {ie: /msie[ ]([\w.]+)/,firefox: /firefox[ |\/]([\w.]+)/,chrome: /chrome[ |\/]([\w.]+)/,safari: /version[ |\/]([\w.]+)[ ]safari/,opera: /opera[ |\/]([\w.]+)/};for (var i in browserRegExp) {var match = browserRegExp[i].exec(ua);if (match) {browser.name = i;browser.version = match[1];break}}this._b = browser.name};jdpts._checkBrowser();jdpts._track = function() {for (var i = 0; i < jdpts._allows.length; i++) {if (jdpts._p == jdpts._allows[i]) {var t1 = (jdpts._ct - jdpts._st),t2 = new Date().getTime() - jdpts._st;log("Page", "LoadTime", jdpts._p, jdpts._b, t1, t2)}}};	function addLoadListener(fn){if (typeof window.addEventListener != 'undefined'){window.addEventListener('load', fn, false);}else if (typeof document.addEventListener != 'undefined'){document.addEventListener('load', fn, false);}else if (typeof window.attachEvent != 'undefined'){window.attachEvent('onload', fn);}else{var oldfn = window.onload;if (typeof window.onload != 'function'){window.onload = fn;}else{window.onload = function(){oldfn();fn();}}}}addLoadListener(jdpts._track);})();
(function($) {
    var escapeable = /["\\\x00-\x1f\x7f-\x9f]/g,
		meta = {
		    '\b': '\\b',
		    '\t': '\\t',
		    '\n': '\\n',
		    '\f': '\\f',
		    '\r': '\\r',
		    '"': '\\"',
		    '\\': '\\\\'
		};
    $.toJSON = typeof JSON === 'object' && JSON.stringify ? JSON.stringify : function(o) {
        if (o === null) {
            return 'null';
        }
        var type = typeof o;
        if (type === 'undefined') {
            return undefined;
        }
        if (type === 'number' || type === 'boolean') {
            return '' + o;
        }
        if (type === 'string') {
            return $.quoteString(o);
        }
        if (type === 'object') {
            if (typeof o.toJSON === 'function') {
                return $.toJSON(o.toJSON());
            }
            if (o.constructor === Date) {
                var month = o.getUTCMonth() + 1,
					day = o.getUTCDate(),
					year = o.getUTCFullYear(),
					hours = o.getUTCHours(),
					minutes = o.getUTCMinutes(),
					seconds = o.getUTCSeconds(),
					milli = o.getUTCMilliseconds();
                if (month < 10) {
                    month = '0' + month;
                }
                if (day < 10) {
                    day = '0' + day;
                }
                if (hours < 10) {
                    hours = '0' + hours;
                }
                if (minutes < 10) {
                    minutes = '0' + minutes;
                }
                if (seconds < 10) {
                    seconds = '0' + seconds;
                }
                if (milli < 100) {
                    milli = '0' + milli;
                }
                if (milli < 10) {
                    milli = '0' + milli;
                }
                return '"' + year + '-' + month + '-' + day + 'T' +
					hours + ':' + minutes + ':' + seconds +
					'.' + milli + 'Z"';
            }
            if (o.constructor === Array) {
                var ret = [];
                for (var i = 0; i < o.length; i++) {
                    ret.push($.toJSON(o[i]) || 'null');
                }
                return '[' + ret.join(',') + ']';
            }
            var name,
				val,
				pairs = [];
            for (var k in o) {
                type = typeof k;
                if (type === 'number') {
                    name = '"' + k + '"';
                } else if (type === 'string') {
                    name = $.quoteString(k);
                } else {
                    // Keys must be numerical or string. Skip others
                    continue;
                }
                type = typeof o[k];
                if (type === 'function' || type === 'undefined') {
                    continue;
                }
                val = $.toJSON(o[k]);
                pairs.push(name + ':' + val);
            }
            return '{' + pairs.join(',') + '}';
        }
    };
    $.evalJSON = typeof JSON === 'object' && JSON.parse
		? JSON.parse
		: function(src) {
		    return eval('(' + src + ')');
		};
    $.secureEvalJSON = typeof JSON === 'object' && JSON.parse
		? JSON.parse
		: function(src) {

		    var filtered =
			src
			.replace(/\\["\\\/bfnrtu]/g, '@')
			.replace(/"[^"\\\n\r]*"|true|false|null|-?\d+(?:\.\d*)?(?:[eE][+\-]?\d+)?/g, ']')
			.replace(/(?:^|:|,)(?:\s*\[)+/g, '');

		    if (/^[\],:{}\s]*$/.test(filtered)) {
		        return eval('(' + src + ')');
		    } else {
		        throw new SyntaxError('Error parsing JSON, source is not valid.');
		    }
		};
    $.quoteString = function(string) {
        if (string.match(escapeable)) {
            return '"' + string.replace(escapeable, function(a) {
                var c = meta[a];
                if (typeof c === 'string') {
                    return c;
                }
                c = a.charCodeAt();
                return '\\u00' + Math.floor(c / 16).toString(16) + (c % 16).toString(16);
            }) + '"';
        }
        return '"' + string + '"';
    };
})(jQuery);
//分类
(function() {
    function HashMap() {
        this.values = new Object();
    }
    HashMap.prototype.Set = function(key, value) { this.values[key] = value; }
    HashMap.prototype.Get = function(key) { return this.values[key] }
    HashMap.prototype.Contains = function(key) { return this.values.hasOwnProperty(key) }
    HashMap.prototype.Remove = function(key) { delete this.values[key]; }

    function SortedHashMap(IComparer, IGetKey) {
        this.IComparer = IComparer;
        this.IGetKey = IGetKey;
        this.a = new Array();
        this.h = new HashMap();
    }
    SortedHashMap.prototype.Add = function(key, value) {
        if (this.ContainsKey(key)) {
            this.Remove(key);
        }
        this.a.push(value);
        this.a.sort(this.IComparer);
        for (var i = 0; i < this.a.length; i++) {
            var key = this.IGetKey(this.a[i]);
            this.h.Set(key, i);
        }
    }
    SortedHashMap.prototype.Get = function(key) {
        return this.a[this.h.Get(key)];
    }
    SortedHashMap.prototype.Count = function() {
        return this.a.length;
    }
    SortedHashMap.prototype.Remove = function(key) {
        if (!this.h.Contains(key))
            return;
        var index = this.h.Get(key);
        this.a.splice(index, 1);
        this.h.Remove(key);
    }
    SortedHashMap.prototype.ContainsKey = function(key) {
        return this.h.Contains(key);
    }
    SortedHashMap.prototype.Clear = function() {
        this.a = new Array();
        this.h = new HashMap();
    }
    SortedHashMap.prototype.GetJson = function() {
        //return JSON.stringify(this.a)
        return $.toJSON(this.a);
    }

    function ThirdType(thirdType, sku, value) {
        this.t = thirdType;
        this.v = 5;
        this.s = 0;
        if (arguments.length > 1) {
            this.s = sku;
        }
        if (arguments.length > 2) {
            this.v = value;
        }
    }
    ThirdType.prototype.Increase = function() { this.v = this.v + 1; }
    ThirdType.prototype.Decrease = function() { this.v = this.v - 1; }
    ThirdType.prototype.SetSku = function(sku) { this.s = sku; }

    Ttracker = {
        IComparer: function(a, b) { return b.v - a.v; },
        IGetKey: function(a) { return a.t; },
        trace: function() {
            var crumb = $(".crumb a");
            if (crumb.length < 4) return;
            var thref = $(crumb[3]).attr('href')
            if (thref == '' || thref == undefined) return;
            var tb = thref.lastIndexOf('/'), te = thref.lastIndexOf('.'), tts = thref.substring(tb + 1, te);
            var ttss = tts.split('-'), tt = '';
            if (ttss.length == 3)
                tt = ttss[2];
            else if (ttss.length == 2)
                tt = ttss[0]
            var ttx = Number(tt);
            if (ttx.toString() == "NaN" || ttx == 0) return;
            var wid = $('#name').length > 0 ? $('#name').attr('PshowSkuid') : '';
            var sortmap = new SortedHashMap(this.IComparer, this.IGetKey), maps = Ttracker.util.Vv("typewid");
            if (maps) {
                try {
                    var maplist = eval('(' + maps + ')');
                    $.each(maplist, function(i, map) {
                        if (map.t !== tt)
                            map.v -= 1;
                        sortmap.Add(map.t, map);
                    });
                }
                catch (e) {
                    Ttracker.util.Wv('typewid', '', 63072E6);
                }
            }
            if (!sortmap.ContainsKey(tt)) {
                sortmap.Add(tt, new ThirdType(tt, wid));
            } else {
                var curtt = sortmap.Get(tt);
                curtt.s = wid === '' ? curtt.s : wid;
                curtt.v += 2;
            }
            if (sortmap.Count() > 10) {
                var del = sortmap.a[sortmap.Count() - 1];
                sortmap.Remove(del.t);
            }
            Ttracker.util.Wv('typewid', sortmap.GetJson(), 63072E6);
        }
    };
    Ttracker.util = {
        Wv: function(n, v, t) {
            n = n + "=" + v + "; path=/; ";
            t && (n += "expires=" + (new Date((new Date).getTime() + t)).toGMTString() + "; ");
            n += "domain=.360buy.com;";
            document.cookie = n
        },
        Vv: function(n) {
            for (var b = [], c = document.cookie.split(";"), n = RegExp("^\\s*" + n + "=\\s*(.*?)\\s*$"), d = 0; d < c.length; d++) {
                var e = c[d]['match'](n);
                e && b.push(e[1])
            }
            return b[0];
        }
    };
    Ttracker.trace();
})();
//GA统计
(function(){var Z=window,ak=document,ax=escape,Q=void 0,M="push",E="join",I="split",P="length",v="indexOf",m="prototype",G="toLowerCase";var ao={};ao.uri=function(){};ao.uri[m]={getParameter:function(p,l){var s=new RegExp("(?:^|&|[?])"+l+"=([^&]*)");var g=s.exec(p);return g?ax(g[1]):""}};ao.util={Wv:function(s,g,p,l){s=s+"="+g+"; path=/; ";l&&(s+="expires="+(new Date((new Date).getTime()+l)).toGMTString()+"; ");p&&(s+="domain="+p+";");ak.cookie=s},Vv:function(t){for(var g=[],s=ak.cookie[I](";"),t=RegExp("^\\s*"+t+"=\\s*(.*?)\\s*$"),p=0;p<s[P];p++){var l=s[p]["match"](t);l&&g[M](l[1])}return g}};var aB=0;function af(g){return(g?"_":"")+aB++}var ah=af(),ab=af(),ae=af(),H=af(),d=af(),aD=af(),U=af(),al=af(),ac=af(),ag=af(),av=af(),au=af(),aA=af(),aI=af(),X=af(),S=af(),A=af(),w=af(),J=af(),aw=af(),n=af(),z=af(),i=af(),a=af(),aG=af(),at=af(),N=af(),aF=af(),aE=af(),e=af(),aq=af(),c=af(),am=af();var aH=function(){var p={};this.set=function(t,s){p[t]=s},this.get=function(s){return p[s]!==Q?p[s]:null},this.m=function(t){var s=this.get(t);var C=s==Q||s===""?0:s*1;p[t]=C+1};this.set(ah,"UA-J2011-1");this.set(H,".360buy.com");this.set(ae,k());this.set(d,Math.round((new Date).getTime()/1000));this.set(aD,63072000000);this.set(U,15768000000);this.set(al,1800000);this.set(aI,R());var g=Y();this.set(X,g.name);this.set(S,g.version);this.set(A,F());var l=aC();this.set(w,l.D);this.set(J,l.C);this.set(aw,l.language);this.set(n,l.javaEnabled);this.set(z,l.characterSet);this.set(aE,aj)};var aj="google:q,baidu:wd,yahoo:p,yahoo:q,live:q,msn:q,bing:q,aol:query,aol:q,daum:q,eniro:search_word,naver:query,pchome:q,images.google:q,lycos:query,ask:q,netscape:query,cnn:query,about:terms,mamma:q,voila:rdata,virgilio:qs,alice:qs,yandex:text,najdi:q,seznam:q,search:q,wp:szukaj,onet:qt,szukacz:q,yam:k,kvasir:q,ozu:q,terra:query,rambler:query".split(","),aK=function(){return Math.round((new Date).getTime()/1000)},u=function(){return Math.round(Math.random()*2147483647)},V=function(){return u()^ai()&2147483647},k=function(){return T(ak.domain)},aC=function(){var l={},g=Z.navigator,p=Z.screen;l.D=p?p.width+"x"+p.height:"-";l.C=p?p.colorDepth+"-bit":"-";l.language=(g&&(g.language||g.browserLanguage)||"-")[G]();l.javaEnabled=g&&g.javaEnabled()?1:0;l.characterSet=ak.characterSet||ak.charset||"-";return l},R=function(){var y,t,s;t="ShockwaveFlash";if((b=(b=window.navigator)?b.plugins:Q)&&b[P]>0){for(y=0;y<b[P]&&!s;y++){t=b[y],t.name[v]("Shockwave Flash")>-1&&(s=t.description[I]("Shockwave Flash ")[1])}}else{t=t+"."+t;try{y=new ActiveXObject(t+".7"),s=y.GetVariable("$version")}catch(p){}if(!s){try{y=new ActiveXObject(t+".6"),s="WIN 6,0,21,0",y.AllowScriptAccess="always",s=y.GetVariable("$version")}catch(l){}}if(!s){try{y=new ActiveXObject(t),s=y.GetVariable("$version")}catch(g){}}s&&(s=s[I](" ")[1][I](","),s=s[0]+"."+s[1]+" r"+s[2])}b=s?s:"-";return b},an=function(g){return Q==g||"-"==g||""==g},T=function(l){var g=1,s=0,p;if(!an(l)){g=0;for(p=l[P]-1;p>=0;p--){s=l.charCodeAt(p),g=(g<<6&268435455)+s+(s<<14),s=g&266338304,g=s!=0?g^s>>21:g}}return g},ai=function(){var p=aC();for(var l=p,g=Z.navigator,l=g.appName+g.version+l.language+g.platform+g.userAgent+l.javaEnabled+l.D+l.C+(ak.cookie?ak.cookie:"")+(ak.referrer?ak.referrer:""),g=l.length,s=Z.history.length;s>0;){l+=s--^g++}return T(l)},Y=function(){var g={name:"other",version:"0"},s=navigator.userAgent.toLowerCase();browserRegExp={se360:/360se/,ie:/msie[ ]([\w.]+)/,firefox:/firefox[|\/]([\w.]+)/,chrome:/chrome[|\/]([\w.]+)/,safari:/version[|\/]([\w.]+)[ ]safari/,opera:/opera[|\/]([\w.]+)/};for(var p in browserRegExp){var l=browserRegExp[p].exec(s);if(l){g.name=p;g.version=l[1]||1;break}}return g},F=function(){var g=/(win|mac|linux|sunos|solaris|iphone|android|ipod|ipad|nokia)/.exec(navigator.platform.toLowerCase());return g==null?"other":g[0]},az=function(l){l.set(ac,ak.location.hostname);l.set(ag,ak.title);l.set(av,ak.location.pathname);l.set(au,ak.referrer);l.set(aA,ak.location.href);var C=ao.util.Vv("__jda"),s=C[P]>0?C[0][I]("."):null;l.set(ab,s?s[1]:V());l.set(i,s?s[2]:l.get(d));l.set(a,s?s[3]:l.get(d));l.set(aG,s?s[4]:l.get(d));l.set(at,s?s[5]*1:1);var t=ao.util.Vv("__jdv"),g=t[P]>0?t[0][I]("|"):null;l.set(e,g?g[1]:"direct");l.set(aq,g?g[2]:"-");l.set(c,g?g[3]:"none");l.set(am,g?g[4]:"-");var y=ao.util.Vv("__jdb"),p=y[P]>0?y[0][I]("."):null;l.set(N,p?p[1]*1:0);l.set(aF,p?p[2]:l.get(ab)+"|"+l.get(at));return !0},ay=function(aS){var t=new ao.uri(),p=ak.location.href,C=ak.referrer,aP=ak.domain,y=t.getParameter(p,"utm_source"),s=[],W=aS.get(e),O=aS.get(aq),L=aS.get(c),D=aS.get(am),aT=ao.util.Vv("__jdc")[P]==0?false:true,g=ao.util.Vv("__jdb")[P]==0?false:true;if(y){var l=t.getParameter(p,"utm_campaign"),aR=t.getParameter(p,"utm_medium"),aa=t.getParameter(p,"utm_term");s[M](y),s[M](l||"-"),s[M](aR||"-"),s[M](aa||"not set")}else{if(C!=""&&C[I]("/")[2][v](aP)<0){for(var aQ=false,aL=aS.get(aE),aM=0;aM<aL.length;aM++){var aO=aL[aM][I](":");if(C[v](aO[0][G]())>-1){var aN=unescape(aO[1][G]()),K=t.getParameter(C,aN);s[M](aO[0]),s[M]("-"),s[M]("organic"),s[M](ax(K)||"not set");aQ=true;break}}if(!aQ){s[M](/([\w-]+\.)+\w*/.exec(C)[0]),s[M]("-"),s[M]("referral"),s[M]("-")}}}if(s[P]>0&&(s[0]!=W||s[1]!=O||s[2]!=L||s[3]!=D)){aS.set(e,s[0]||"direct");aS.set(aq,s[1]||"-");aS.set(c,s[2]||"none");aS.set(am,s[3]||"-");ap(aS)}else{if(!aT||!g){ap(aS)}else{h(aS)}}},j=function(l,g){var p=g.split(".");l.set(i,p[2]*1);l.set(a,p[4]*1);l.set(aG,aK());l.m(at);l.set(aF,p[1]+"|"+l.get(at));l.set(N,1)},B=function(l){var g=l.get(d);l.set(ab,V());l.set(i,g);l.set(a,g);l.set(aG,g);l.set(at,1);l.set(aF,l.get(ab)+"|"+l.get(at));l.set(N,1)},r=function(l){var g=l.get(ab),y=l.get(i),t=l.get(a),s=l.get(aG),p=l.get(at)==null?1:l.get(at);return[l.get(ae),g!=Q?g:"-",y||"-",t||"-",s||"-",p][E](".")},h=function(g){g.m(N)},f=function(g){return[g.get(ae),g.get(N)==null?1:g.get(N),g.get(aF),g.get(aG)][E](".")},x=function(g){return[g.get(ae),g.get(e)==null?ak.domain:g.get(e),g.get(aq)==null?"(direct)":g.get(aq),g.get(c)==null?"direct":g.get(c),g.get(am)==null?"-":g.get(am)][E]("|")},ap=function(g){var l=ao.util.Vv("__jda");l.length==0?B(g):j(g,l[0])};var q=new aH(),ar=function(){this.a={};this.add=function(g,l){this.a[g]=l};this.get=function(g){return this.a[g]};this.toString=function(){return this.a[E]("&")}},ad=function(l,g){function s(y,t){t&&p[M](y+"="+t+";")}var p=[];s("__jda",r(l));s("__jdv",x(l));g.add("jdcc",p[E]("+"))},o=function(l,g){g.add("jdac",l.get(ah)),g.add("jduid",l.get(ab)),g.add("jdsid",l.get(aF)),g.add("jdje",l.get(n)),g.add("jdsc",l.get(J)),g.add("jdsr",l.get(w)),g.add("jdul",l.get(aw)),g.add("jdcs",l.get(z)),g.add("jddt",ax(l.get(ag))||"-"),g.add("jdmr",ax(l.get(au))),g.add("jdhn",l.get(ac)||"-"),g.add("jdfl",l.get(aI)),g.add("jdos",l.get(A)),g.add("jdbr",l.get(X)),g.add("jdbv",l.get(S)),g.add("jdwb",l.get(i)),g.add("jdxb",l.get(a)),g.add("jdyb",l.get(aG)),g.add("jdzb",l.get(at)),g.add("jdcb",l.get(N)),g.add("jdusc",l.get(e)||"direct"),g.add("jducp",l.get(aq)||"-"),g.add("jdumd",l.get(c)||"-"),g.add("jduct",l.get(am)||"-")},aJ=function(){az(q)&&ay(q);var l=new ar();o(q,l);var g=q.get(H)==null?ak.domain:q.get(H);ao.util.Wv("__jda",r(q),g,q.get(aD));ao.util.Wv("__jdb",f(q),g,q.get(al));ao.util.Wv("__jdc",q.get(ae),g);ao.util.Wv("__jdz","",g,-q.get(U));ao.util.Wv("__jdv",x(q),g,q.get(U));return l.a};ao.tracker={aloading:function(){var s="http://csc.360buy.com/log.ashx?type1=J&type2=A&data=&pin=$pin$&referrer=$referrer$&jinfo=$jinfo$&callback=?";var p=aJ(),t=p&&p.jdac+"||"+p.jdje+"||"+p.jdsc+"||"+p.jdsr+"||"+p.jdul+"||"+p.jdcs+"||"+ax(p.jddt)+"||"+p.jdhn+"||"+p.jdfl+"||"+p.jdos+"||"+p.jdbr+"||"+p.jdbv+"||"+p.jdwb+"||"+p.jdxb+"||"+p.jdyb+"||"+p.jdzb+"||"+p.jdcb+"||"+p.jdusc+"||"+p.jducp+"||"+p.jdumd+"||"+p.jduct,l=ao.util.Vv("pin");var g=s.replace(/\$pin\$/,ax(l[P]>0?l[0]:"-"));g=g.replace(/\$referrer\$/,ax(p.jdmr)||"-");g=g.replace(/\$jinfo\$/,t);$.getJSON(g,function(){})}};ao.tracker.aloading()})();
//HashMap//---------------------------------------------------------------
function HashMap() {
    this.values = new Object();
}
HashMap.prototype.Set = function(key, value) { this.values[key] = value; }
HashMap.prototype.Get = function(key) { return this.values[key] }
HashMap.prototype.Contains = function(key) { return this.Get(key) == null ? false : true }
HashMap.prototype.Remove = function(key) { delete this.values[key] }
//---------------------------------------------------------------
funLoad();
Clublog();
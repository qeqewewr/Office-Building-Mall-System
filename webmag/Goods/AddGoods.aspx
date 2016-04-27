<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddGoods.aspx.cs" Inherits="webmag_Goods_AddGoods" %>
 
 <!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
    <link rel="stylesheet" type="text/css" href="../Styles/webmag.css"  />
    <link rel="stylesheet" href="../kindeditor/themes/default/default.css" />
	<link rel="stylesheet" href="../kindeditor/plugins/code/prettify.css" />
    <link rel="stylesheet" type="text/css" href="../styles/uploadify.css" />
	<script charset="utf-8" src="../kindeditor/kindeditor.js"></script>
	<script charset="utf-8" src="../kindeditor/lang/zh_CN.js"></script>
	<script charset="utf-8" src="../kindeditor/plugins/code/prettify.js"></script>
    <script language="javascript" src="../../js/jquery-1.4.3.min.js"></script>
    <script src="../scripts/swfobject.js"></script>
	<script src="../scripts/jquery.uploadify.v2.1.4.js"></script>
    <script language="javascript" src="../Scripts/webmag.js"></script>
    <script language="javascript" src="../Scripts/util.js"></script>
    <script language=javascript type="text/javascript">
        $(function () {

            KindEditor.ready(function (K) {
                var editor1 = K.create('#goodMemo', {
                    cssPath: '../kindeditor/plugins/code/prettify.css',
                    uploadJson: '../kindeditor/asp.net/upload_json.ashx',
                    fileManagerJson: '../kindeditor/asp.net/file_manager_json.ashx',
                    allowFileManager: true,
                    afterCreate: function () {
                        var self = this;
                        K.ctrl(document, 13, function () {
                            self.sync();
                            K('form[name=example]')[0].submit();
                        });
                        K.ctrl(self.edit.doc, 13, function () {
                            self.sync();
                            K('form[name=example]')[0].submit();
                        });
                    }
                });
                prettyPrint();
            });

             $('#fileUpload').uploadify({
	            'uploader': '../images/uploadify.swf',
	            'script': '../uploadFileHandler.ashx',
	            // 'script': 'SaveTravel.aspx.cs',
	            'cancelImg': '../images/cancel.png',
	            'folder': '../attachment',
	            'multi': true,
	            'queueID': 'custom-queue',
	            'removeCompleted': false,
	            'onComplete': function (event, queueID, fileObj, serverData, data) {
	                var spans = "";
	                var str = fileObj.name + "#" + serverData;
	                spans += "<input type='hidden' name='ufile' value='" + str + "'>";
	                $("#fileUpload" + queueID).append(spans);
	                thisPage = false;
	            },
	            'sizeLimit': 10737418240,
	            'onCancel': function (event, ID, fileObj, data) {
	                var id = ID;
	                if (fileObj == null) {
	                    if (confirm("确定要删除该附件吗?")) {
	                        $("input[name='ufile']").each(function () {
	                            var s = $(this).val();
	                            var seperator = s.indexOf("#");
	                            var url = s.substring(seperator + 1);
	                            var pid = $(this).parent().attr('id');
	                            if (pid == "fileUpload" + id) {
	                                $.ajax({
	                                    type: "post",
	                                    url: "../deleteFileHandler.ashx",
	                                    data: "op=delete&url=" + url,
	                                    error: function (XMLHttpRequest) { alert(XMLHttpRequest.status); },
	                                    success: function (data) {
	                                        var fadeSpeed = 250;
	                                        jQuery("#fileUpload" + ID).fadeOut(fadeSpeed, function () { jQuery("#fileUpload" + ID).remove() });
	                                    }
	                                });
	                                return false;
	                            }
	                        });
	                    }
	                }
	            }
	        });

	    });
         

        function verifySubmit() {
            if ($.trim($("#goodName").val()) == "") {
                alert("商品名称不能为空！");
                $("#goodName").focus();
                return false;
            }

            if ($.trim($("#goodNO").val()) == "") {
                alert("商品货号不能为空！");
                $("#goodNO").focus();
                return false;
            }

//            if ($.trim($("#goodNO").val()) == "") {
//                alert("商品货号不能为空！");
//                $("#goodNO").focus();
//                return false;
//            }

            if ($.trim($("#goodPrice").val()) == "") {
                alert("商品市场价格不能为空！");
                $("#goodPrice").focus();
                return false;
            }
            if ($.trim($("#goodPromotion").val()) == "") {
                alert("商品优惠价格不能为空！");
                $("#goodPromotion").focus();
                return false;
            }  
            

            return true;
        }


    </script>

</head>
<body>
    
    <div>
        <form action="SaveGoods.aspx?action=add" method="post" id="example" onsubmit="return verifySubmit();">
        <table width="100%" class="addTable" cellpadding="0" cellspacing="0" style="border-collapse: collapse;">
            <caption>
                新增商品信息
            </caption>
            <tr>
                <td class="leftTitle">
                    <font color="#cc0033">*</font>商品名称
                </td>
                <td>
                    <input type="text" name="goodName" id="goodName"  />
                </td>
                <td class="leftTitle">
                    <font color="#cc0033">*</font>商品货号
                </td>
                <td colspan="3">
                    <input type="text" name="goodNO" id="goodNO"  />
                </td>
            </tr> 
            <tr>
                <td class="leftTitle">
                    <font color="#cc0033"></font>商品类型
                </td>
                <td colspan="3"> 
                     <select id="goodType" name="goodType"> 
                         <% for(int i=0;i< exist.Count;i++){ %>
                                <option value="<%= exist[i].ID %>" ><%=exist[i].typeName %></option>                                
                            <%} %>
                        </select>
                </td> 
            </tr>
            <tr>
                <td class="leftTitle">
                    <font color="#cc0033"></font>品牌
                </td>
                <td colspan="3"> 
                    <input type="text" name="goodBrand" id="goodBrand"  />
                </td> 
            </tr>
            <tr>
                <td class="leftTitle">
                    <font color="#cc0033"></font>生产商
                </td>
                <td colspan="3"> 
                    <input type="text" name="goodManufacture" id="goodManufacture"  />
                </td> 
            </tr>
            <tr>
                <td class="leftTitle">
                    产地
                </td>
                <td colspan="3"> 
                    <input type="text" name="goodOrg" id="goodOrg"  />
                </td> 
            </tr>
            <tr>
                <td class="leftTitle">
                   毛重
                </td>
                <td> 
                    <input type="text" name="goodKg" id="goodKg"  />
                </td> 
                <td class="leftTitle">
                   净重
                </td>
                <td> 
                    <input type="text" name="goodNetKg" id="goodNetKg"  />
                </td>
            </tr>
            <tr>
                <td class="leftTitle">
                   颜色
                </td>
                <td> 
                    <input type="text" name="goodColor" id="goodColor"  />
                </td> 
                <td class="leftTitle">
                   尺寸
                </td>
                <td> 
                    <input type="text" name="goodSize" id="goodSize"  />
                </td>
            </tr>
            <tr>
                <td class="leftTitle">
                   规格
                </td>
                <td> 
                    <input type="text" name="goodSpecifications" id="goodSpecifications"  />
                </td> 
                <td class="leftTitle">
                   材质
                </td>
                <td> 
                    <input type="text" name="goodMaterial" id="goodMaterial"  />
                </td>
            </tr>
            <tr>
                <td class="leftTitle">
                   <font color="#cc0033">*</font>市场价
                </td>
                <td> 
                    <input type="text" name="goodPrice" id="goodPrice" onChange="isNumValue(this)" />
                </td> 
                <td class="leftTitle">
                   <font color="#cc0033">*</font>光大价
                </td>
                <td> 
                    <input type="text" name="goodPromotion" id="goodPromotion"  onChange="isNumValue(this)"  />
                </td>
            </tr>
            <tr>
                <td class="leftTitle">
                   推荐商品
                </td>
                <td> 
                    <input type="checkbox" name="goodRecommand" id="goodRecommand"  />
                </td> 
                <td class="leftTitle">
                   库存数
                </td>
                <td> 
                     <input type="text" name="goodStock" id="goodStock"  onChange="isNumValue(this)" />
                </td>
            </tr>
            

            <tr>
                <td class="leftTitle">
                    详细介绍
                </td>
                <td colspan="3">
                     <textarea id="goodMemo" name="goodMemo" cols="100" rows="8"
								style="width: 100%; height: 600px; visibility: hidden;"></textarea>
                </td>
<%--                <td colspan="3">
                     <textarea id="goodMemo" name="goodMemo"
								style="width: 100%; height: 200px; visibility: hidden;"></textarea>
                </td>--%>
            </tr> 
             <tr>
                    <td class="leftTitle">上传图片</td>
                     <td colspan="3">
						<fieldset
							style="border: 1px solid #CDCDCD; padding: 8px; padding-bottom: 0px; margin: 8px 0">
							<div id="custom-queue">

                            </div>
							<div id="fileUpload">
								You have a problem with your javascript
							</div>
							<a href="javascript:$('#fileUpload').uploadifyUpload()">开始上传</a>
							<p></p>
						</fieldset> 
                    </td> 
                </tr>
            <tr>
                <td colspan="4" class="buttonGroup">
                    <input type="submit" name="saveNews" value=" " id="saveNews" class="saveBtn" />
                    <input type="reset" name="reset" value=" " id="reset" class="resetBtn" />
                    <input type="button" name="back" value=" " id="back" class="backBtn" onclick="javascript:history.back(-1);" />
                </td>
            </tr>
        </table>
        </form>
    </div>
</body>
</html>

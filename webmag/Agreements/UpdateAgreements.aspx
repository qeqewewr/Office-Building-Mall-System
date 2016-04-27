<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UpdateAgreements.aspx.cs" Inherits="webmag_Agreements_UpdateAgreements" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
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
	<script language="javascript">

	    $(function () {
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



	    KindEditor.ready(function (K) {
	        var editor1 = K.create('#Detail', {
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
	    $(function () {

	    });

	    function delUpload(attchID) {
	        if (confirm("确定要删除该附件?")) {
	            $.ajax({
	                type: "post",
	                url: "../deleteFileHandler.ashx",
	                data: "op=delete&attid=" + attchID,
	                success: function (data) {
	                    var fadeSpeed = 250;
	                    jQuery("#fileUpload" + attchID).fadeOut(fadeSpeed, function () { jQuery("#fileUpload" + attchID).remove() });
	                }
	            });
	        }
	    }

	    function verifySubmit() {
	        if ($.trim($("#Name").val()) == "") {
	            alert("协议名称不能为空！");
	            $("#Name").focus();
	            return false;
	        } else if ($.trim($("#Detail").val()) == "") {
	            alert("协议内容不能为空！");
	            $("#Detail").focus();
	            return false;
	        }

	        return true;
	    }
	</script>
    <link rel="stylesheet" type="text/css" href="../Styles/webmag.css"  />
</head>
<body>
   

    <div>
        <form action="doUpdateAgreements.aspx?id=<%=agreement.ID%>&pageno=<%= pageno %>" method="post" id="example" onsubmit="return verifySubmit();">
            <table width="100%" class="addTable" cellpadding="0"
					cellspacing="0" style="border-collapse: collapse;"> 
                <caption>					
					修改商城协议界面
				</caption>
                <tr>
                    <td class="leftTitle"><font color="#cc0033">*</font>协议名称</td>
                    <td colspan="3"><input type="text" name="Name"  id="Name" style="width:50%;" value="<%=agreement.Name%>"/></td>
                </tr> 
         
                <tr>
                
                    <td class="leftTitle">协议内容</td>
                    <td colspan="3">
                            <textarea id="Detail" name="Detail"  cols="100" rows="8"
						style="width: 100%; height: 300px; visibility: hidden;" onclick="return memo_onclick()">
                                <%=agreement.Detail%>
                             </textarea>
                    </td> 

                </tr>
                 <tr>
                    <td class="leftTitle">上传文档</td>
                    <td colspan="3">
                     <fieldset
							style="border: 1px solid #CDCDCD; padding: 8px; padding-bottom: 0px; margin: 8px 0">
							<div id="custom-queue">
                                <%for (int i = 0; i < attach.Count; i++)
                                  { %>
                                <div class="uploadifyQueueItem completed"										id="fileUpload<%= attach[i].ID%>">										<div class="cancel">											<a href="javascript:delUpload(<%=attach[i].ID %>)"> <img													border="0" src="../images/cancel.png"></a>										</div>										<span class="fileName"><a href="<%=uploadpath %><%= attach[i].attachUrl%>" class="attatchHref"><%= attach[i].attachName%></a></span>										<span class="percentage"> - Completed</span>								</div>
                                <%} %> 
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
							<input type="submit" name="saveNews" value=" " id="saveNews"
								class="saveBtn"/>
							<input type="reset" name="reset" value=" " id="reset"
								class="resetBtn"/>
							<input type="button" name="back" value=" " id="back"
								class="backBtn" onClick="javascript:history.back(-1);"/>
						</td>
					</tr>
            </table>
        </form>
    </div>
</body>
</html>

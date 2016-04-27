<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewAgreements.aspx.cs" Inherits="webmag_Agreements_ViewAgreements" %>

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
	<script>
	    KindEditor.ready(function (K) {
	        var editor1 = K.create('#Detail', {
	            cssPath: '../kindeditor/plugins/code/prettify.css',
	            uploadJson: '../kindeditor/asp.net/upload_json.ashx',
	            fileManagerJson: '../kindeditor/asp.net/file_manager_json.ashx',
	            readonlyMode: true,
	            //	            allowFileManager: true,
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
	        //prettyPrint();
	    });
	</script>
    <link rel="stylesheet" type="text/css" href="../Styles/webmag.css"  />
</head>
<body>
   

    <div>
            <table width="100%" class="addTable" cellpadding="0"
					cellspacing="0" style="border-collapse: collapse;"> 
                <caption>					
					查看商城协议界面
				</caption>
                <tr>
                    <td class="leftTitle">协议名称</td>
                    <td colspan="3"><input type="text" name="Name"  id="Name" style="width:50%;" value="<%=agreement.Name%>" readonly="readonly"/></td>
                </tr> 
           
                <tr>
                
                    <td class="leftTitle">协议内容</td>
                    <td colspan="3">
                        <textarea id="Detail" name="Detail" rows="8"
								style="width: 99%; height: 300px;" onclick="return Detail_onclick()">
                                <%=agreement.Detail%>
                             </textarea>
                    </td> 

                </tr>
                 <tr>
                    <td class="leftTitle">附件</td>
                    <td colspan="3">
                     <%--<input type="text" name="ImageLink"  id="ImageLink" value="<%=cleaner.ImageLink%>"/>--%>
                     <fieldset
							style="border: 1px solid #CDCDCD; padding: 8px; padding-bottom: 0px; margin: 8px 0">
							<div id="custom-queue">
                                <%for (int i = 0; i < attach.Count; i++)
                                  { %>
                                <div class="uploadifyQueueItem completed"										id="fileUpload<%= attach[i].ID%>">										<%--<div class="cancel">											<a href="javascript:delUpload(<%=attach[i].ID %>)"> <img													border="0" src="../images/cancel.png"></a>										</div>--%>										<span class="fileName"><a href="<%=uploadpath %><%= attach[i].attachUrl%>" class="attatchHref" ><%= attach[i].attachName%></a></span>										<span class="percentage"> - Completed</span>								</div>
                                <%} %> 
                            </div>
							<%--<div id="fileUpload">
								You have a problem with your javascript
							</div>
							<a href="javascript:$('#fileUpload').uploadifyUpload()">开始上传</a> 
							<p></p>--%>
						</fieldset>
                    </td> 
                </tr>

                	<tr>
						<td colspan="4" class="buttonGroup">
							<%--<input type="submit" name="saveNews" value=" " id="saveNews"
								class="saveBtn"/>
							<input type="reset" name="reset" value=" " id="reset"
								class="resetBtn"/>--%>
							<input type="button" name="back" value=" " id="back"
								class="backBtn" onClick="javascript:history.back(-1);"/>
						</td>
					</tr>

            </table>
    </div>
   

</body>
</html>

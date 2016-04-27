<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SetAdvertisement.aspx.cs" Inherits="webmag_Advertisement_SetAdvertisement" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="../Styles/webmag.css"  />
		
    <script language="javascript" src="../../js/jquery-1.4.3.min.js"></script>
    <script language="javascript" type="text/javascript"></script>
    <script language="javascript" src="../Scripts/util.js"></script>
<script>

        function verifySubmit() {
            if ($.trim($("#AdNum").val()) == "") {
                alert("广告数目不能为空！");
                $("#AdNum").focus();
                return false;
            }

            if (confirm("确定设置吗？")) {
                return true;
            } else {
                return false;
            }
            return true;
        }

    </script>
</head>
<body>
   

    <div>
        <form action="updateAdvertisement.aspx?sign=0" method="post" id="example" onsubmit="return verifySubmit();">
            <table width="100%" class="addTable" cellpadding="0"
					cellspacing="0" style="border-collapse: collapse;"> 
                <caption>					
					首页广告设置初始信息界面
				</caption>
                <tr>
                    <td class="leftTitle" width="150">首页广告位置</td>
                    <td colspan="3">
                    <input type="radio" name='ad' value="1" checked/> <strong>顶部中央</strong>
                    <input type="radio" name='ad' value="2" /> <strong>左</strong>
                    <input type="radio" name='ad' value="4" /> <strong>右</strong>
                    <input type="radio" name='ad' value="3" /> <strong>外部网站超链接</strong>
                                     
                    </td>
                </tr> 
                <tr>
                    <td class="leftTitle">该位置广告数目</td>
                    <td colspan="3">
                    <input type="text" name="AdNum"  id="AdNum" style="width:100px;" onchange="numEnter(this)"/>
                     </td>
                </tr>

                	<tr>
						<td colspan="4" class="buttonGroup">
							<input type="submit" name="saveNews" value=" " id="saveNews"
								class="saveBtn">
							<input type="reset" name="reset" value=" " id="reset"
								class="resetBtn">
							<input type="button" name="back" value=" " id="back"
								class="backBtn" onClick="javascript:history.back(-1);">
						</td>
					</tr>

            </table>
        </form>
    </div>
   

</body>
</html>


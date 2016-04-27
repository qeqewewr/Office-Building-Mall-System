<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UpdateGoodType.aspx.cs" Inherits="webmag_Goods_UpdateGoodType" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
    <link rel="stylesheet" type="text/css" href="../Styles/webmag.css" />
    <script language="javascript" src="../../js/jquery-1.4.3.min.js"></script>
    <script language="javascript" src="../Scripts/webmag.js"></script>
    <script language="javascript" src="../Scripts/util.js"></script>
   	<link rel="StyleSheet" href="../styles/dtree.css" type="text/css" />
	<script type="text/javascript" src="../scripts/dtree.js"></script>
    <script language=javascript type="text/javascript">
        $(function () {

        });

        function verifySubmit() {
            if ($.trim($("#goodType").val()) == "") {
                alert("类别名称不能为空！");
                $("#goodType").focus();
                return false;
            }

            return true;
        }


    </script>

</head>
<body>
    
    <div>
        <form action="SaveGoodType.aspx?action=edit&id=<%=goodType.ID %>" method="post" id="example" onsubmit="return verifySubmit();">
        <table width="100%" class="addTable" cellpadding="0" cellspacing="0" style="border-collapse: collapse;">
            <caption>
                新增商品类别
            </caption>
            <tr>
                <td class="leftTitle">
                    <font color="#cc0033">*</font>商品类别
                </td>
                <td colspan="3">
                    <input type="text" name="goodType" id="goodType" value="<%=goodType.typeName %>" />
                </td>
            </tr>
             <tr>
                <td class="leftTitle">
                    上级类别
                </td>
                <td colspan="3">
                    <select name="parent">
                           <option></option>
                           <% for(int i=0;i< exist.Count;i++){ %>
                                <option value="<%= exist[i].ID %>#<%=exist[i].Tlevel %>" <%if(goodType.parent==exist[i].ID) {%>selected<%} %>  ><%=exist[i].typeName %></option>                                
                            <%} %>
                     </select>
                     
                </td>
            </tr>
            <tr>
                <td class="leftTitle">
                    备注
                </td>
                <td colspan="3">
                    <textarea name="memo" cols="25" rows="3"><%=goodType.memo %></textarea>
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


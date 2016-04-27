<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewCustomer.aspx.cs" Inherits="webmag_CustomerManage_ViewCustomer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="../Styles/webmag.css"  />
	<script language="javascript" src="../Scripts/webmag.js"></script>	
</head>
<body>
   

    <div>
            <table width="100%" class="addTable" cellpadding="0"
					cellspacing="0" style="border-collapse: collapse;"> 
                <caption>					
					查看用户信息界面
				</caption>
                <tr>
                    <td class="leftTitle" >用户名</td>
                    <td><input type="text" name="cusName"  id="cusName" value="<%=customer.cusName%>" readonly="readonly"/></td>
                    <td class="leftTitle" >用户登入名</td>
                    <td><input type="text" name="cusLoginName"  id="cusLoginName" value="<%=customer.cusLoginName%>" readonly="readonly"/></td>
                </tr> 
                <tr>
                    <td class="leftTitle">密码</td>
                    <td><input type="password" name="cusPassword" size="21"  id="cusPassword" value="<%=customer.cusPassword%>" readonly="readonly"/></td> 
                    <td class="leftTitle">注册时间</td>
                    <td><input type="text" name="cusRegTime"  id="cusRegTime" value="<%=customer.cusRegTime%>" readonly="readonly"/></td> 
                </tr>
<%--                <tr>
                    <td class="leftTitle">用户等级</td>
                    <td><input type="text" name="cusLevel"  id="cusLevel" value="<%=customer.cusLevel%>" readonly="readonly"/></td>
                    <td class="leftTitle">用户积分</td>
                    <td><input type="text" name="cusPoint"  id="cusPoint" value="<%=customer.cusPoint%>" readonly="readonly"/></td> 
                </tr>--%>
                <tr>
                    <td class="leftTitle">用户邮箱</td>
                    <td><input type="text" name="cusEmail"  id="cusEmail" value="<%=customer.cusEmail%>" readonly="readonly"/></td>
                    <td class="leftTitle">用户单位</td>
                    <td><input type="text" name="cusUnit"  id="cusUnit" value="<%=customer.cusUnit%>" readonly="readonly"/></td>
                </tr>
                <tr>
                    <td class="leftTitle">用户电话</td>
                    <td><input type="text" name="cusTel"  id="cusTel" value="<%=customer.cusTel%>" readonly="readonly"/> </td>
                    <td class="leftTitle">用户住址</td>
                    <td><input type="text" name="cusAddr"  id="cusAddr" value="<%=customer.cusAddr%>" readonly="readonly"/></td>
                </tr>
                
                 <tr>
                    <td class="leftTitle">备注</td>
                    <td colspan="3">
                        <textarea id="cusMemo" name="cusMemo"
								style="width: 100%; height: 300px; visibility: hidden;"><%=customer.cusMemo%></textarea>
                    </td> 
                </tr>
                	<tr>
						<td colspan="4" class="buttonGroup">
							<input type="button" name="back" value=" " id="back"
								class="backBtn" onClick="javascript:history.back(-1);">
						</td>
					</tr>

            </table>
    </div>
   

</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddStaff.aspx.cs" Inherits="webmag_Staff_AddStaff" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <link rel="stylesheet" type="text/css" href="../Styles/webmag.css"  />
		
</head>
<body>
   

    <div>
        <form action="SaveStaff.aspx?action=add">
            <table width="100%" class="addTable" cellpadding="0"
					cellspacing="0" style="border-collapse: collapse;"> 
                <caption>					
					新增员工界面
				</caption>
                <tr>
                    <td class="leftTitle" width="150">姓名</td>
                    <td><input type="text" name="name"  id="name" /></td>
                    <td  class="leftTitle">性别</td>
                    <td><select name="gender"><option value="男">男</option><option value="女">女</option></select></td>
                </tr> 
                <tr>
                    <td class="leftTitle">身份证号</td>
                    <td colspan="3"><input type="text" name="IDNumber"  id="IDNumber" style="width:300px;" /></td> 
                </tr>
                <tr>
                    <td class="leftTitle">出生年月</td>
                    <td><input type="text" name="birth"  id="birth" /> <img src="../Images/cal.gif" /> </td>
                    <td class="leftTitle">学历</td>
                    <td><select name="education">
                        <option value="博士">博士</option>
                        <option value="硕士">硕士</option>
                        <option value="本科">本科</option>
                        <option value="专科">专科</option>
                        <option value="高中">高中</option>
                        <option value="中专">中专</option>
                        <option value="初中">初中</option>
                        <option value="小学">小学</option>
                        </select>
                    </td>
                </tr>
                <tr>
                    <td class="leftTitle">入职时间</td>
                    <td><input type="text" name="enterDate"  id="enterDate" /> <img src="../Images/cal.gif" id="enterDateImg" /> </td>
                    <td class="leftTitle">离职时间</td>
                    <td><input type="text" name="leaveDate"  id="leaveDate" /> <img src="../Images/cal.gif" id="leaveDateImg" /></td>
                </tr>
                <tr>
                    <td class="leftTitle">办公室电话</td>
                    <td><input type="text" name="officeTel"  id="officeTel" /></td>
                    <td class="leftTitle">手机</td>
                    <td><input type="text" name="mobile"  id="mobile" /></td>
                </tr>
                <tr>
                    <td class="leftTitle">家庭电话</td>
                    <td><input type="text" name="homeTel"  id="homeTel" /></td>
                    <td class="leftTitle">家庭住址</td>
                    <td><input type="text" name="address"  id="address" style="width:300px;" /></td>
                </tr>
                 <tr>
                    <td class="leftTitle">备注</td>
                    <td colspan="3">
                        <textarea id="memo" name="memo" cols="100" rows="8"
								style="width: 100%; height: 300px; visibility: hidden;"></textarea>
                    </td> 
                </tr>

                	<tr>
						<td colspan="4" class="buttonGroup">
							<input type="button" name="saveNews" value=" " id="saveNews"
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

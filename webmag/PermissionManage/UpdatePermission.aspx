<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UpdatePermission.aspx.cs" Inherits="webmag_PermissionManage_UpdatePermission" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="../Styles/webmag.css"  />
		
    <script language="javascript" src="../../js/jquery-1.4.3.min.js"></script>
    <script language="javascript" type="text/javascript">
// <![CDATA[

        function memo_onclick() {
            
        }

// ]]>

        function verifySubmit() {
            if (confirm("确定要更新员工的权限吗？")) {
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
        <form action="doUpdatePermission.aspx?managerid=<%=manager.ID%>&pageno=<%= pageno %>" method="post" id="example" onsubmit="return verifySubmit();">
            <table width="100%" class="addTable" cellpadding="0"
					cellspacing="0" style="border-collapse: collapse;"> 
                <caption>					
					管理员权限信息界面
				</caption>
                <tr>
                    <td class="leftTitle" width="150">管理员信息</td>
                    <td colspan="3">用户名：<input type="text" name="Name"  id="Name" style="width:100px;" value="<%=manager.userName%>" />
                    <%--工号：<input type="text" name="EmployeID"  id="EmployeID" style="width:100px;" value="<%=employe.EmployeID%>" />--%>
                    </td>
                </tr> 
                <tr>
                    <td class="leftTitle">管理员功能权限</td>
                    <td colspan="3">
                    <%for (int i = 0; i < allFunctionList.Count; i++)
                      {
                        if (allFunctionList[i].ParentID != 0)
                        {

                            if (functionList.Count > 0)
                            {

                                for (int j = 0; j < functionList.Count; j++)
                                {

                                    if (allFunctionList[i].ID == functionList[j].ID)
                                    { %>
                                    
                                      <input type="checkbox" value="<%=allFunctionList[i].ID%>" name="all" checked><%=allFunctionList[i].FullName%>

                                      <%  j = functionList.Count;
                                      }
                                    if (j + 1 == functionList.Count)
                                    {%>
                                      <input type="checkbox"  name="all" value="<%=allFunctionList[i].ID%>"><%=allFunctionList[i].FullName%>
                                      <%}
                                }
                            }
                            else 
                            {%>
                                <input type="checkbox"  name="all" value="<%=allFunctionList[i].ID%>"><%=allFunctionList[i].FullName%>
                            <%}                             
                        }
                        else{
                            if(i != 0)
                            {%>
                                </br>
                            <%}%>
                                <%=allFunctionList[i].FullName%>:
                                
                       <%  }
                  }%>


  <%--                  <td colspan="3">
                    <%for (int i = 0; i < allFunctionList.Count; i++)
                      {
                          if (allFunctionList[i].ParentID != 0)
                          {
                              if (functionList.Count > 0)
                              {

                                  for (int j = 0; j < functionList.Count; j++)
                                  {

                                      if (allFunctionList[i].ID == functionList[j].ID)
                                      { 
                                    %>
                                      <input type="checkbox" value="<%=allFunctionList[i].ID%>" name="all" checked><%=allFunctionList[i].FullName%>
                                      <%if ((i + 1) % 3 == 0)
                                        {%>
                                            </br> 
                                        <%}
                                        // break;
                                        j = functionList.Count;
                                      }
                                      if (j + 1 == functionList.Count)
                                      {%>
                                      <input type="checkbox"  name="all" value="<%=allFunctionList[i].ID%>"><%=allFunctionList[i].FullName%>
                                      <%if ((i + 1) % 3 == 0)
                                        {%>
                                                </br> 
                                        <%}
                                      }
                                  }
                              }
                              else 
                              { %>
                                  <input type="checkbox"  name="all" value="<%=allFunctionList[i].ID%>"><%=allFunctionList[i].FullName%>
                                  <%if ((i + 1) % 3 == 0)
                                        {%>
                                                </br> 
                                        <%}

                              }
                          }
                          else
                          {%>
                              <%=allFunctionList[i].FullName%>:
                            <% if ((i + 1) % 3 == 0)
                                {%>
                                        </br>
                                 <%}
                           }
                      }%>
                    </td> --%>
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

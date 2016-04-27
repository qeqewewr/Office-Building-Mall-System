<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ListStaff.aspx.cs" Inherits="webmag_Staff_ListStaff" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
   <div class="queryArea" width="100%">
			<form action="newsJump?op=tolist_search" name="searchForm"
				id="searchForm" onSubmit="return searchCheck();" method="post">
				<fieldset>
					<legend style="color: #006699;"> 员工信息查询 </legend>

					<span>关键字：<input type="text" name="key" id="key"
						value=""
						size="30" class="inputText"
						onfocus="$(this).css('border-color','#ff0000')"
						onblur="$(this).css('border-color','#006699')" /> &nbsp;&nbsp;<input
						type="submit" value=" " class="queryBtn" title="查询员工信息" /> </span>
				</fieldset>
			</form>
	</div>

    <div>	
			<table class="resultTable">
				<caption style="text-align: left">
					&nbsp;&nbsp;&nbsp;&nbsp;最新动态查询列表 <span align="right"><input
						type="button" value=" " class="addBtn" title="新增最新动态"
						onClick="window.location.href='newsJump?op=toadd'">
					</span>
				</caption>
				<tr class="topTitle">
					<td>选 择</td>
					<td>编 号</td>
					<td>姓 名</td>
					<td>岗 位</td>
					<td>入职时间</td> 
					<td colspan="3">操 作</td>
				</tr>
                <form name="myform" action="newsMag?op=deleteAll" method="post"
					onsubmit="return checkSubmit(1)">

                <tr onMouseOver="this.style.backgroundColor='#f3f3f3';return true;"
								onMouseOut="this.style.backgroundColor='';">
                    <td><input type="checkbox" name="selectDel"
									value="" onclick="isAllSelected(this,'sltAll','1')" />
					</td>
                    <td>1</td>
                    <td title="${news.title }" align="left"></td>
                    <td title="${news.author}">1</td>
					<td title="${news.editor}">1</td>
					<td>1</td>

                    
                </tr>    

                </form>
</body>
</html>

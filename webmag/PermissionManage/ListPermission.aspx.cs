using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.surfkj.small.BLL.PermissionManage;
using com.surfkj.small.Model.PermissionManage;
using com.surfkj.small.BLL;
using com.surfkj.small.Model;
using com.surfkj.small.Common;

public partial class webmag_PermissionManage_ListPermission : System.Web.UI.Page
{
    private ManagerService service;
    public List<Manager> managerList;

    public pageForm page = new pageForm();
    public string pageno;//页码
    public string keyword;//查询关键字

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["opuser"] == null)
        {
            Response.Write("<script language=javascript>window.location='../../Default.aspx';</script>");
        }
        else
        {
            service = new ManagerService();
            pageno = Request["pageno"].Trim();
            //pageno = "1";
            if (Request["keyword"] != "" && Request["keyword"] != null)
            {

                keyword = Request["keyword"].Trim();
                page.PageSize = 10;
                page.RowCount = service.GetInqueryNum("userName", keyword);
                page.PageNo = int.Parse(pageno);
                int a = page.RowCount % page.PageSize;
                if (a == 0)
                {
                    if (page.RowCount == 0)
                        page.PageCount = 1;
                    else
                        page.PageCount = page.RowCount / page.PageSize;
                }
                else
                    page.PageCount = page.RowCount / page.PageSize + 1;

                managerList = service.ListLookManager(page.PageNo, page.PageSize, "userName", keyword);
            }
            else
            {
                page.RowCount = service.GetTotalRecordNum();
                page.PageSize = 10; //每页的条数
                page.PageNo = int.Parse(pageno);
                int a = page.RowCount % page.PageSize;
                if (a == 0)
                {
                    if (page.RowCount == 0)
                        page.PageCount = 1;
                    else
                        page.PageCount = page.RowCount / page.PageSize;
                }
                else
                    page.PageCount = page.RowCount / page.PageSize + 1;

                managerList = service.ListPageManager(page.PageNo, page.PageSize);
            }
        }

    }
}
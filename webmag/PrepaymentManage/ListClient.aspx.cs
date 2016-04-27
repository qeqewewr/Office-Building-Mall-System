using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.surfkj.small.user.BLL;
using com.surfkj.small.user.Model;
using com.surfkj.small.Common;
using com.surfkj.small.BLL.Lessee;
using com.surfkj.small.Model;

public partial class webmag_PrepaymentManage_ListClient : System.Web.UI.Page
{
    private CustomerService service;
    public List<Customer> customerList;
    private LesseeService leservice;
    public List<Lessee> lesseeList;

    public pageForm page = new pageForm();
    public string pageno;//页码
    public string keyword;//查询关键字
    public string client;
    public string setSign;
    private string id;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["opuser"] == null)
        {
            Response.Write("<script language=javascript>window.location='../../Default.aspx';</script>");
        }
        else
        {
                 pageno = Request["pageno"].Trim();
                if (Request["client"] != null && Request["client"] == "1")//返回企业列表
                {
                    client = Request["client"];
                    leservice = new LesseeService();
                    if (Request["keyword"] != "" && Request["keyword"] != null)
                    {

                        keyword = Request["keyword"].Trim();
                        page.PageSize = 10;
                        page.RowCount = leservice.GetInqueryNum("Name", keyword);
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

                        lesseeList = leservice.ListLookLessee(page.PageNo, page.PageSize, "Name", keyword);
                    }
                    else
                    {
                        page.RowCount = leservice.GetTotalRecordNum();
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

                        lesseeList = leservice.ListPageLessee(page.PageNo, page.PageSize);
                    }

                }
                else if (Request["client"] != null && Request["client"] == "0")
                {
                    client = Request["client"];
                    service = new CustomerService();
                    if (Request["keyword"] != "" && Request["keyword"] != null)
                    {

                        keyword = Request["keyword"].Trim();
                        page.PageSize = 10;
                        page.RowCount = service.GetInqueryNum("cusLoginName", keyword);
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

                        customerList = service.ListLookCustomer(page.PageNo, page.PageSize, "cusLoginName", keyword);
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

                        customerList = service.ListPageCustomer(page.PageNo, page.PageSize);
                    }
                } 
            }
        }
}
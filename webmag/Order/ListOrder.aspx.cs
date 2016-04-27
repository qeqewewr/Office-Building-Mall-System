using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.surfkj.small.Model;
using com.surfkj.small.order.Model;
using com.surfkj.small.BLL.OrderDetail;
using com.surfkj.small.BLL.Lessee;
using com.surfkj.small.goods.BLL;
using com.surfkj.small.goods.Model;
using com.surfkj.small.user.Model;
using com.surfkj.small.user.BLL;
using com.surfkj.small.order.BLL;
using com.surfkj.small.Common;

public partial class webmag_Order_ListOrder : System.Web.UI.Page
{
       public pageForm page = new pageForm();
    public string pageno;//页码
    public string keyword;//查询关键字
    private OrderService orderService = new OrderService();
    public List<Order> orderList;
    public List<string> reNameList = new List<string>();
    public string scope;
    public string reName;
   // public float totalFinalMoney = 0;
    public OrderDetailService orderDetailService = new OrderDetailService();
    public List<OrderDetail> orderDetailList = new List<OrderDetail>();

    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Session["opuser"] == null)
        //{
        //    Response.Write("<script language=javascript>window.location='../../Default.aspx';</script>");
        //}
        //else
        //{       

                        //scope = Request["scope"].Trim();
                //reName = Request["reName"].Trim();
                if (Request["scope"] == "全部" || Request["scope"] == "" || Request["scope"] == null)
                {
                    scope = "";
                }
                if (Request["reName"] == "请选择收件人" || Request["reName"] == "" || Request["reName"] == null)
                {
                    reName = "";
                }
               // else
                //{
                if (scope != "")
                {
                    scope = Request["scope"].Trim();
                    if (scope == "用户购物车")
                        scope = "0";
                    else if (scope == "等待确认")
                        scope = "1";
                    else if (scope == "已确认（准备发货）")
                        scope = "2";
                    else if (scope == "已发货")
                        scope = "3";
                    else if (scope == "取消订单")
                        scope = "4";
                    else if (scope == "交易不成功")
                        scope = "5";
                    else if (scope == "交易成功")
                        scope = "6";
                }
                if (reName != "")
                {
                    reName = Request["reName"].Trim();
                }
                List<Order> orderTempList = new List<Order>();
                orderTempList = orderService.GetModelList("");
                reNameList.Add("请选择收件人");
                for (int i = 0; i < orderTempList.Count; i++)
                {
                    if (orderTempList[i].Receiver != "" && orderTempList[i].Receiver!=null)
                    reNameList.Add(orderTempList[i].Receiver);
                }


                //}


           pageno = Request["pageno"].Trim();
               // pageno = "1";
            if (Request["keyword"] != "" && Request["keyword"] != null)
            {
                keyword = Request["keyword"].Trim();


                page.PageSize = 10;


                page.PageNo = int.Parse(pageno);
                if (scope != "" && reName != "")
                {
                    page.RowCount = orderService.GetOrderInquery(reName, keyword, scope).Count;
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
                    orderList = orderService.ListLookOrder2(page.PageNo, page.PageSize, reName, keyword, scope);
                }
                else if (scope != "" && reName == "")
                {
                    page.RowCount = orderService.GetOrderInquery2(keyword, scope).Count;
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
                    orderList = orderService.ListLookOrder3(page.PageNo, page.PageSize, page.RowCount, keyword, scope);
                }
                else if (scope == "" && reName != "")
                {
                    page.RowCount = orderService.GetOrderInquery3(reName, keyword).Count;
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
                    orderList = orderService.ListLookOrder4(page.PageNo, page.PageSize, page.RowCount, reName, keyword);
                }
                else
                {
                    page.RowCount = orderService.GetInqueryNum("orderNO", keyword);
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
                    orderList = orderService.ListLookOrder(page.PageNo, page.PageSize, "orderNO", keyword);
                }
               
            }
            else
            {   
                page.PageSize = 10; //每页的条数
                page.PageNo = int.Parse(pageno);

                if (scope != "" && reName != "")
                {
                    page.RowCount = orderService.GetOrderInquery4(reName, scope).Count;

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

                    orderList = orderService.ListLookOrder5(page.PageNo, page.PageSize, page.RowCount, reName, scope);
                }
                else if (scope != "" && reName == "")
                {
                    page.RowCount = orderService.GetOrderInquery5(scope).Count;

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

                    orderList = orderService.ListLookOrder6(page.PageNo, page.PageSize, page.RowCount, scope);
                }
                else if (scope == "" && reName != "")
                {
                    page.RowCount = orderService.GetOrderInquery6(reName).Count;

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

                    orderList = orderService.ListLookOrder7(page.PageNo, page.PageSize, page.RowCount, reName);
                }
                else
                {
                    page.RowCount = orderService.GetTotalRecordNum();

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

                    orderList = orderService.ListPageOrder(page.PageNo, page.PageSize);
                }  
            }
        //}
    }
}
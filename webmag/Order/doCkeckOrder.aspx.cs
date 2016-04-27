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

public partial class webmag_Order_doCkeckOrder : System.Web.UI.Page
{
    public string id;//订单ID
    public string pageno;
    public Order order;
    // public OrderDetail orderDetail;
    public List<OrderDetail> orderDetailList;
    // public List<Goods> goodsList;
    public Goods goods;
    private OrderService orderService;
    private OrderDetailService orderDetailService;
    public GoodsService goodsService;
    public LesseeService lesseeService;
    public Lessee lessee = new Lessee();
    public Customer customer = new Customer();
    private CustomerService customerService;
    public string userType = "";
    private string result;
    private int customerID;
    private float totalPrice=0;
    private float origMoney = 0;
    private bool flag = true;
    private string origStatus;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["opuser"] == null)
        {
            Response.Write("<script language=javascript>window.location='../../Default.aspx';</script>");
        }
        else
        {
            orderService = new OrderService();
            orderDetailService = new OrderDetailService();
            lesseeService = new LesseeService();
            customerService = new CustomerService();
            id = Request["id"].Trim();
            pageno = Request["pageno"].Trim();
            result = Request.Form["dis"];
            order = orderService.GetModel(int.Parse(id));
            origStatus = order.orderStatus;//order原来状态
            //获得订单明细列表
            orderDetailList = orderDetailService.GetModelList("OrderID = " + int.Parse(id));
            order.Memo = Request["Memo"].Trim();
            if (result != null)
            {
                //更改订单状态
                if (result == "确认订单")
                {
                    order.orderStatus = "2";
                }
                else if (result == "取消订单")
                {
                    order.orderStatus = "4";
                }
                
            }
            flag = orderService.Update(order);

            for (int i = 0; i < orderDetailList.Count; i++) {
                if (Request.Form["newFinal" + i] != null)
                {
                    orderDetailList[i].finalAmount = float.Parse(Request.Form["newFinal" + i]);
                    orderDetailService.Update(orderDetailList[i]);
                }
            }

            Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('保存成功!');location.href=('AutOrderList.aspx?pageno=" + pageno + "');</script>");

            ////更改金额
            //if (flag == true)
            //{
            //    userType = order.customerType;
            //    if (result == "已结清")
            //    {
            //        //userType = order.customerType;
            //        customerID = order.customer;
            //        for (int i = 0; i < orderDetailList.Count; i++)
            //        {
            //            float temp = orderDetailList[i].goodPrice * orderDetailList[i].goodQuantity;
            //            totalPrice = totalPrice + temp;
            //        }
            //        if (userType == "1")//企业
            //        {
            //            lessee = lesseeService.GetModel(customerID);
            //            lessee.WarrantMon = lessee.WarrantMon + totalPrice;
            //            flag = lesseeService.Update(lessee);
            //            while (flag == false)
            //            {
            //                order.orderStatus = "未结清";
            //                flag = orderService.Update(order);
            //                if (flag == true)
            //                {
            //                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('保存失败!');history.go(-1);</script>");
            //                }
            //            }

            //            Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('保存成功!');location.href=('AutOrderList.aspx?pageno=" + pageno + "');</script>");
            //        }
            //        else
            //        {
            //            customer = customerService.GetModel(customerID);
            //            customer.cusPoint = customer.cusPoint + (int)totalPrice;
            //            flag = customerService.Update(customer);
            //            while (flag == false)
            //            {
            //                order.orderStatus = "未结清";
            //                flag = orderService.Update(order);
            //                if (flag == true)
            //                {
            //                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('保存失败!');history.go(-1);</script>");
            //                }
            //            }

            //            Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('保存成功!');location.href=('AutOrderList.aspx?pageno=" + pageno + "');</script>");
            //        }
            //    }
            //    else
            //    {
            //        Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>location.href=('AutOrderList.aspx?pageno=" + pageno + "');</script>");
            //    }

            //}
            //else
            //{
            //    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('保存失败或订单已结清!');history.go(-1);</script>");
            //}
        }

    }
}
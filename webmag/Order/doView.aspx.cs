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

public partial class webmag_Order_doView : System.Web.UI.Page
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
    private float totalPrice = 0;
    private float origMoney = 0;
    private bool flag = true;
    private string origStatus;
    private string signer;
    private string deliveryInfo;

    protected void Page_Load(object sender, EventArgs e)
    {
        orderService = new OrderService();
        orderDetailService = new OrderDetailService();
        lesseeService = new LesseeService();
        customerService = new CustomerService();
        id = Request["id"].Trim();
        pageno = Request["pageno"].Trim();
        result = Request.Form["rad"];
        signer = Request.Form["signer"];
        deliveryInfo = Request["deliveryInfo"];
        order = orderService.GetModel(int.Parse(id));
        orderDetailList = orderDetailService.GetModelList("OrderID = " + int.Parse(id));
        origStatus = order.orderStatus;//order原来状态

        if (result != null)
        {
            if (order.payType == 1 && result == "3") //预付款
            {
                userType = order.customerType;
                customerID = order.customer;
                //需付的成交金额
                for (int i = 0; i < orderDetailList.Count; i++)
                {
                    float temp = orderDetailList[i].finalAmount;
                    totalPrice = totalPrice + temp;
                }

                if (userType == "1")//企业
                {
                    lessee = lesseeService.GetModel(customerID);
                    lessee.WarrantMon = lessee.WarrantMon - totalPrice;
                    flag = lesseeService.Update(lessee);
                    while (flag == false)
                    {
                        order.orderStatus = origStatus;
                        order.signer = signer;
                        order.deliveryInfo = deliveryInfo;
                        flag = orderService.Update(order);
                        if (flag == true)
                        {
                            Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('付款失败!');history.go(-1);</script>");
                        }
                    }
                    order.orderStatus = "6";
                    order.signer = signer;
                    order.deliveryInfo = deliveryInfo;
                    order.state = 3;
                    flag = orderService.Update(order);
                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('付款成功!');location.href=('ListOrder.aspx?pageno=" + pageno + "');</script>");
                }
                else if (userType == "2")//个人
                {
                    customer = customerService.GetModel(customerID);
                    customer.cusMoney = customer.cusMoney - totalPrice;
                    flag = customerService.Update(customer);
                    while (flag == false)
                    {
                        order.orderStatus = origStatus;
                        order.signer = signer;
                        order.deliveryInfo = deliveryInfo;
                        flag = orderService.Update(order);
                        if (flag == true)
                        {
                            Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('付款失败!');history.go(-1);</script>");
                        }
                    }
                    order.orderStatus = "6";
                    order.signer = signer;
                    order.deliveryInfo = deliveryInfo;
                    order.state = 3;
                    flag = orderService.Update(order);
                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('付款成功!');location.href=('ListOrder.aspx?pageno=" + pageno + "');</script>");
                }
            }
            else
            {

                if (result == "2")
                {
                    order.orderStatus = "5";
                    order.state = 2;
                }

                if (result == "4")
                {
                    order.orderStatus = "5";
                    order.state = 4;
                }
                if (result == "1")
                {
                    order.orderStatus = "6";
                    order.state = 1;
                }

                order.signer = signer;
                order.deliveryInfo = deliveryInfo;
                flag = orderService.Update(order);
                if (flag == false)
                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('保存失败!');history.go(-1);</script>");
                else
                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('保存成功!');location.href=('ListOrder.aspx?pageno=" + pageno + "');</script>");
            }
        }
        else
        {
            order.signer = signer;
            order.deliveryInfo = deliveryInfo;
            flag = orderService.Update(order);
            if (flag == false)
                Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('保存失败!');history.go(-1);</script>");
            else
                Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('保存成功!');location.href=('ListOrder.aspx?pageno=" + pageno + "');</script>");
        }
    }
}
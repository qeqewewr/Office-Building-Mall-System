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

public partial class webmag_Order_CheckOrder : System.Web.UI.Page
{
    public string id;
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
    public float finalAmount = 0;
    public string orderStatus = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["opuser"] == null)
        {
            Response.Write("<script language=javascript>window.location='../../Default.aspx';</script>");
        }
        else
        {
            id = Request["id"];
            pageno = Request["pageno"].Trim();
            orderService = new OrderService();
            orderDetailService = new OrderDetailService();
            goodsService = new GoodsService();
            customerService = new CustomerService();
            lesseeService = new LesseeService();
            // goodsList = new List<Goods>();

            //获得选中订单
            order = orderService.GetModel(int.Parse(id));
            orderStatus = Constants.orderStatus(order.orderStatus);
            userType = order.customerType;
            if (userType.Equals("1"))//租户
            {
                int lesseeID = order.customer;
                lessee = lesseeService.GetModel(lesseeID);

            }
            else//customer
            {
                int customerID = order.customer;
                //获得购买者信息
                customer = customerService.GetModel(customerID);
            }


            //获得订单明细列表
            orderDetailList = orderDetailService.GetModelList("OrderID = " + int.Parse(id));
            //获得属于该订单的所有商品的成交价
            for (int i = 0; i < orderDetailList.Count; i++)
            {
                finalAmount = finalAmount + orderDetailList[i].finalAmount;
            }
        }
    }
}
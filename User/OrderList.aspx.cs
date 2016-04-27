using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls; 
using com.surfkj.small.goods.Model;
using com.surfkj.small.goods.BLL;
using com.surfkj.small.user.Model;
using com.surfkj.small.order.Model;
using com.surfkj.small.Model;
using com.surfkj.small.order.BLL;
using com.surfkj.small.BLL.OrderDetail;

public partial class User_OrderList : System.Web.UI.Page
{
    public string username = "3";
    public List<Order> list = new List<Order>();
	public List<OrderDetail> orders = new List<OrderDetail>();
	public OrderDetailService orderS = new OrderDetailService();
    public GoodsService gsrv = new GoodsService();
    public Customer customer = new Customer();

    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["customer"] != null)
        {
            customer = (Customer)Session["customer"];

            OrderService srv = new OrderService();
            string str = "";
            if (Request["orderStatus"] != null && Request["orderStatus"] != "")
            {
				str += " orderStatus = '" + Request["orderStatus"] + "' and ";
            }
            str += " customerType='2' and orderStatus<>'0' and customer=" + customer.ID;
            list = srv.GetModelList(str);

            username = customer.cusLoginName;

        }
        else if (Session["lee"] != null)
        {
             Lessee lessee = (Lessee)Session["lee"]; 

            OrderService srv = new OrderService();
            string str = "";
            if (Request["orderStatus"] != null && Request["orderStatus"] != "")
            {
                str += " orderStatus = '"+Request["orderStatus"]+"' and ";
            }
            str += " customerType='1' and orderStatus<>'0' and customer=" + lessee.ID;
            list = srv.GetModelList(str);

            username = lessee.Name;
        }
        else {
            Response.Write("<script language='javascript'>alert('对不起，请登录系统！');window.location.href='login.aspx';</script>");
        }
        



    }
}
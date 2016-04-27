using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.surfkj.small.user.Model;
using com.surfkj.small.goods.Model;
using com.surfkj.small.Model;
using com.surfkj.small.BLL.OrderDetail;
using com.surfkj.small.goods.BLL;
using com.surfkj.small.order.BLL;
using com.surfkj.small.order.Model;

public partial class User_ShoppingCartSelect : System.Web.UI.Page
{
    public string username = "";
    public float amount = 0;
    public Customer customer;
    public Lessee lessee;
    public List<Order> orders = new List<Order>();
    public List<Goods> goods = new List<Goods>();
    public List<OrderDetail> details = new List<OrderDetail>();
    public OrderDetailService dsrv = new OrderDetailService();
    public GoodsService gsrv = new GoodsService();
    public OrderService osrv = new OrderService();


    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["customer"] != null)
        {
            customer = new Customer();
            customer = (Customer)Session["customer"];
            orders = osrv.GetModelList(" OrderStatus='0' and customer= " + customer.ID + " and customerType='2' ");

            for (int i = 0; i < orders.Count; i++)
            {
                details.AddRange(dsrv.GetModelList(" orderID= " + orders[i].ID));
            }
            username = customer.cusName;
        }
        else if (Session["lee"] != null)
        {
            lessee = new Lessee();
            lessee = (Lessee)Session["lee"];
            orders = osrv.GetModelList(" OrderStatus='0' and customer= " + lessee.ID + " and customerType='1' ");

            for (int i = 0; i < orders.Count; i++)
            {
                details.AddRange(dsrv.GetModelList(" orderID= " + orders[i].ID));
            }
            username = lessee.Name;
        }
    }
}
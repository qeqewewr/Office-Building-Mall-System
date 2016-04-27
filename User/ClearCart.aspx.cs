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


public partial class User_ClearCart : System.Web.UI.Page
{

    public Customer customer = new Customer();
    public Lessee lee = new Lessee();
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
             
            customer = (Customer)Session["customer"];
            orders = osrv.GetModelList(" OrderStatus='0' and customer= " + customer.ID + " and customerType='2' "); 

            if (orders.Count > 0)
            {    
                List<OrderDetail> details = new List<OrderDetail>();
                details = dsrv.GetModelList(" orderID="+orders[0].ID);

                if (Request["flag"] == "all")
                {

                    for (int i = 0; i < details.Count; i++)
                    {
                        dsrv.Delete(details[i].ID);
                    }
                    osrv.Delete(orders[0].ID);
                }
                else {
                    dsrv.Delete(int.Parse(Request["cartid"]));
                }
            }

            Response.Write("<script language='javascript'>alert('购物车清除成功！');window.location.href='shoppingCart.aspx';</script>");

        }
        else if (Session["lee"] != null)
        {
            lee = (Lessee)Session["lee"];
            orders = osrv.GetModelList(" OrderStatus='0' and customer= " + lee.ID + " and customerType='1' ");

            if (orders.Count > 0)
            {
                List<OrderDetail> details = new List<OrderDetail>();
                details = dsrv.GetModelList(" orderID=" + orders[0].ID);

                if (Request["flag"] == "all")
                {

                    for (int i = 0; i < details.Count; i++)
                    {
                        dsrv.Delete(details[i].ID);
                    }
                    osrv.Delete(orders[0].ID);
                }
                else
                {
                    dsrv.Delete(int.Parse(Request["cartid"]));
                }
            }

            Response.Write("<script language='javascript'>alert('购物车清除成功！');window.location.href='shoppingCart.aspx';</script>");
        }



    }
}
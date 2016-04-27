using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.surfkj.small.order.BLL;
using com.surfkj.small.order.Model;
using com.surfkj.small.goods.BLL;
using com.surfkj.small.Model;
using com.surfkj.small.BLL.OrderDetail;
using com.surfkj.small.user.Model;

public partial class User_OrderDetail : System.Web.UI.Page
{
    public string username; 
    public float amount = 0;
    public List<Order> list = new List<Order>();
    public GoodsService gsrv = new GoodsService();
    public OrderService osrv = new OrderService();
    public Order order = new Order();
    public OrderDetail detail = new OrderDetail();
    public OrderDetailService dsrv = new OrderDetailService();
    public List<OrderDetail> details = new List<OrderDetail>();
    public float finalmomey = 0;

    protected void Page_Load(object sender, EventArgs e)
    {

         if (Session["customer"] != null)
        {
            Customer customer = (Customer)Session["customer"];
            username = customer.cusLoginName;
            order = osrv.GetModel(int.Parse(Request["ID"]));
            details = dsrv.GetModelList(" orderID=" + Request["ID"]);

            for (int i = 0; i < details.Count; i++)
            {
                amount = amount + details[i].goodPrice * details[i].goodQuantity;
                finalmomey = finalmomey + details[i].finalAmount;
            }
              }
        else if (Session["lee"] != null)
         {
             Lessee lessee = (Lessee)Session["lee"];
             username = lessee.Name;
            order = osrv.GetModel(int.Parse(Request["ID"]));
             details = dsrv.GetModelList(" orderID=" + Request["ID"]);

             for (int i = 0; i < details.Count; i++)
             {
                 amount = amount + details[i].goodPrice * details[i].goodQuantity;
                 finalmomey = finalmomey + details[i].finalAmount;
             }
         }
         else
         {
             Response.Write("<script language='javascript'>alert('对不起，请重新登录系统！');window.location.href('login.aspx');</script>");
         }
        

       

    }
}
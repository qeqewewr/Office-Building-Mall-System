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

public partial class User_InitCart : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        GoodsService srv = new GoodsService();
        Goods goods = srv.GetModel(int.Parse(Request["gid"]));
        OrderService osrv = new OrderService();
        OrderService gsrv = new OrderService();
        Order order = new Order();
        int flag = 0;
        if (Session["lee"] == null && Session["customer"] == null) {
            Response.Write("<script language='javascript'>alert('请先登录系统！');window.location.href('login.aspx');</script>");

        } else { 
        if (Session["lee"]!= null)
        {
            order.customerType = "1";//租户
            order.customer = ((Lessee)Session["lee"]).ID;

            if (osrv.GetModelList(" orderStatus='0' and customerType='1' and customer= " + order.customer).Count > 0)
            {
                order = osrv.GetModelList(" orderStatus='0' and customerType='1'  and customer= " + order.customer)[0];
            }
           
        }
        else if (Session["customer"] != null)
        {
            order.customerType = "2";
            order.customer = ((Customer)Session["customer"]).ID;

            if (osrv.GetModelList(" orderStatus='0' and customerType='2' and customer= " + order.customer ).Count > 0)
            {
                order = osrv.GetModelList(" orderStatus='0' and customerType='2'  and customer= " + order.customer)[0];
            } 
        }

        if (order.orderNO == null || order.orderNO == "")
        {

            order.orderNO = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString();

            order.orderStatus = Constants.CARTORDER;

            order.payTime = DateTime.Now;

            if (Session["customer"] != null)
                order.customerType = Constants.CUSTOMRTYPE;
            if (Session["lee"] != null)
                order.customerType = Constants.ENTERPRISETYPE;

            flag = gsrv.Add(order);
        }
        else {
            flag = order.ID;
        }
         
       

        OrderDetail detail = new OrderDetail();   
        detail.OrderID = flag;
        detail.goodID = int.Parse(Request["gid"]);
        detail.goodPrice = float.Parse(Request.Form["price"]);
        detail.goodQuantity = int.Parse(Request.Form["quantity"]);
        detail.finalAmount = float.Parse(Request.Form["price"]) * int.Parse(Request.Form["quantity"]);
        OrderDetailService dsrv = new OrderDetailService();
        int flag2 = dsrv.Add(detail);

        Response.Write("<script language='javascript'>window.location.href='AddCart.aspx?orderid=" + flag + "';</script>");


        }

    }
}
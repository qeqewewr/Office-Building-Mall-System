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


public partial class User_shoppingcartSubmit : System.Web.UI.Page
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

            if (orders.Count > 0) {
                orders[0].orderStatus = Constants.WAITCHECK;
                if (Request["revciver"] == null || Request["revciver"] == "" || Request["tel"] == null || Request["tel"] == "" || Request["addr"] == null || Request["addr"] == "")
                {
                    orders[0].Receiver = customer.cusName;
                    orders[0].Tel = customer.cusTel;
                    orders[0].addr = customer.cusAddr;
                }
                else
                {

                    orders[0].Receiver = Request["revciver"];
                    orders[0].Tel = Request["tel"];
                    orders[0].addr = Request["addr"];
                }
               // orders[0].zip = Request["zip"];
                orders[0].message = Request["message"];

                orders[0].payType =int.Parse(Request["paytype"]);
                osrv.Update(orders[0]);
            }

            Response.Write("<script language='javascript'>alert('订单提交成功！');window.location.href='userhome.aspx';</script>");

        }
        else if (Session["lee"] != null) {
            lee = (Lessee)Session["lee"];
            orders = osrv.GetModelList(" OrderStatus='0' and customer= " + lee.ID + " and customerType='1' ");

            if (orders.Count > 0)
            {
                orders[0].orderStatus = Constants.WAITCHECK;
                if (Request["revciver"] == null || Request["revciver"] == "" || Request["tel"] == null || Request["tel"] == "" || Request["addr"] == null || Request["addr"] == "")
                {
                    orders[0].Receiver = lee.Name;
                    orders[0].Tel = lee.OfficePhone;
                    orders[0].addr = lee.Address;
                }
                else
                {
                    
                    orders[0].Receiver = Request["revciver"];
                    orders[0].Tel = Request["tel"];
                    orders[0].addr = Request["addr"];
                }
                //orders[0].Receiver = Request["revciver"];
                //orders[0].Tel = Request["tel"];
                //orders[0].addr = Request["addr"];
                //orders[0].zip = Request["zip"];
                orders[0].message = Request["message"];

                orders[0].payType = int.Parse(Request["paytype"]);

                osrv.Update(orders[0]);
            }

            Response.Write("<script language='javascript'>alert('订单提交成功！');window.location.href='userhome.aspx';</script>");

        }
        else {
            Response.Write("<script language='javascript'>alert('对不起，请登录系统！');window.location.href='login.aspx';</script>");
        }








    }
}
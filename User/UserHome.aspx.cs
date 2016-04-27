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

public partial class User_UserHome : System.Web.UI.Page
{

    public Customer customer;
    public Lessee lee;
	public List<Order> list1 = new List<Order>();
	public List<Order> list2 = new List<Order>();
	public List<Order> list3 = new List<Order>();
	public List<Order> list4 = new List<Order>();
	public OrderService srv = new OrderService();

    protected void Page_Load(object sender, EventArgs e)
    {
           

            if (Session["customer"] != null)
            { 
               
                if (Session["lee"] != null)
                {
                    Session["lee"] = null;
                }
                customer = (Customer)Session["customer"];
				list1 = srv.GetModelList("customer=" + customer.ID + " and customerType=2 and orderStatus='1'");
				list2 = srv.GetModelList("customer=" + customer.ID + " and customerType=2 and orderStatus='2'");
				list3 = srv.GetModelList("customer=" + customer.ID + " and customerType=2 and orderStatus='3'");
				list4 = srv.GetModelList("customer=" + customer.ID + " and customerType=2 and orderStatus='4'");
				//Response.Write(customer.cusPassword);
            }
            else if (Session["lee"] != null)
            {
                if (Session["customer"] != null)
                {
                    Session["customer"] = null;
                }
                lee = (Lessee)Session["lee"];
				list1 = srv.GetModelList("customer=" + lee.ID + " and customerType=1 and orderStatus='1'");
				list2 = srv.GetModelList("customer=" + lee.ID + " and customerType=1 and orderStatus='2'");
				list3 = srv.GetModelList("customer=" + lee.ID + " and customerType=1 and orderStatus='3'");
                //customerLevel = "注册用户";
				//Response.Write(lee.Password);
            }
            else
            {
                Response.Write("<script language='javascript'>alert('对不起，请登录系统！');window.location.href='login.aspx';</script>");
            }
     



        

       
    }
}
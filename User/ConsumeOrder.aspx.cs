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

public partial class User_ConsumeOrder : System.Web.UI.Page
{
	public string username = "";
	public List<Order> list = new List<Order>();
    public List<OrderDetail> detialList = new List<OrderDetail>();
	public GoodsService gsrv = new GoodsService();
	public Customer customer = new Customer();
	public Lessee lessee = new Lessee();
    public float finalAmount = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
		if (Session["customer"] != null)
		{
			customer = (Customer)Session["customer"];

			OrderService srv = new OrderService();
            OrderDetailService dser = new OrderDetailService();
			string str = "";
			if (Request["orderStatus"] != null && Request["orderStatus"] != "")
			{
				str += " orderStatus = '1' and ";
			}
			str += " customerType='2' and customer=" + customer.ID + " and orderStatus=6";
			list = srv.GetModelList(str);

            for (int i = 0; i < list.Count; i++)
            {
                detialList = dser.GetModelList("OrderID = " + list[i].ID);
                if (detialList != null && detialList.Count > 0)
                {
                    for (int j = 0; j < detialList.Count; j++)
                    {
                        finalAmount = finalAmount + detialList[j].finalAmount;
                    }
                }
 
            }

                username = customer.cusLoginName;

		}
		else if (Session["lee"] != null)
		{
			lessee = (Lessee)Session["lee"];

			OrderService srv = new OrderService();
            OrderDetailService dser = new OrderDetailService();
			string str = "";
			if (Request["orderStatus"] != null && Request["orderStatus"] != "")
			{
				str += " orderStatus = '1' and ";
			}
			str += " customerType='1' and customer=" + lessee.ID + " and orderStatus=6";
			list = srv.GetModelList(str);
            for (int i = 0; i < list.Count; i++)
            {
                detialList = dser.GetModelList("OrderID = " + list[i].ID);
                if (detialList != null && detialList.Count > 0)
                {
                    for (int j = 0; j < detialList.Count; j++)
                    {
                        finalAmount = finalAmount + detialList[j].finalAmount;
                    }
                }

            }
			username = lessee.Name;
		}
		else
		{
			Response.Write("<script language='javascript'>alert('对不起，请登录系统！');window.location.href='login.aspx';</script>");
		}
    }
}
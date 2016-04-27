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

public partial class MyCart : System.Web.UI.Page
{
	private List<Order> orderList;
	private OrderService orderService;
	private OrderDetailService orderDetailService;
	private List<OrderDetail> orderDetailList;
    private Customer customer;
    private Lessee lessee;
	public 	float goodsNum = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
		if (Session["customer"] != null)
		{
            customer = ((Customer)Session["customer"]);
			orderService = new OrderService();
			orderList = orderService.GetModelList("customerType = '2' and orderStatus = '0' and customer = '" +customer.ID+ "'");

			if (orderList != null && orderList.Count > 0)
			{
				orderDetailService = new OrderDetailService();
				orderDetailList = new List<OrderDetail>();
				for (int i = 0; i < orderList.Count; i++)
				{
					orderDetailList = orderDetailService.GetModelList("OrderID = " + orderList[i].ID);

					for (int j = 0; j < orderDetailList.Count; j++)
					{
						goodsNum = goodsNum + orderDetailList[j].goodQuantity;
					}


				}
			}



		}
		else if (Session["lee"] != null)
		{
            lessee = ((Lessee)Session["lee"]);
			orderService = new OrderService();
            orderList = orderService.GetModelList("customerType = '1' and orderStatus = '0' and customer = '" + lessee.ID + "'");

			if (orderList != null && orderList.Count > 0)
			{
				orderDetailService = new OrderDetailService();
				orderDetailList = new List<OrderDetail>();
				for (int i = 0; i < orderList.Count; i++)
				{
					orderDetailList = orderDetailService.GetModelList("OrderID = " + orderList[i].ID);

					for (int j = 0; j < orderDetailList.Count; j++)
					{
						goodsNum = goodsNum + orderDetailList[j].goodQuantity;
					}


				}
			}
		}
    }
}
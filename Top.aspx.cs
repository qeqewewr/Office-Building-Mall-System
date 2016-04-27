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
using com.surfkj.small.Common;

public partial class Top : System.Web.UI.Page
{
	public string username = "";
    private List<Order> orderList;
    private OrderService orderService;
    private OrderDetailService orderDetailService;
    private List<OrderDetail> orderDetailList;
    //public float goodsNum = 0;
	//public List<GoodType> goodTypeList;
	//private GoodTypeService goodTypeService;
	protected void Page_Load(object sender, EventArgs e)
	{
		//goodTypeService = new GoodTypeService();
		//goodTypeList = new List<GoodType>();
		//goodTypeList = goodTypeService.GetModelList("parent = 0");

		if (Session["customer"] != null)
		{
			username = ((Customer)Session["customer"]).cusName;
            orderService = new OrderService();
            orderList = orderService.GetModelList("customerType = '2' and orderStatus = '0'");
            
            if (orderList != null && orderList.Count > 0)
            {
                Constants.goodsNum = 0;
                orderDetailService = new OrderDetailService();
                orderDetailList = new List<OrderDetail>();
                for (int i = 0; i < orderList.Count; i++)
                {
                    orderDetailList = orderDetailService.GetModelList("OrderID = " + orderList[i].ID);

                    for(int j = 0;j<orderDetailList.Count;j++)
                    {
                        Constants.goodsNum = Constants.goodsNum + orderDetailList[j].goodQuantity;
                    }

                    
                }
            }



		}
		else if (Session["lee"] != null)
		{
			username = ((Lessee)Session["lee"]).Name;
		}



	}
}
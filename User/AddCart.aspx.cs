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



public partial class User_AddCart : System.Web.UI.Page
{
    public string username = "";
    public float amount = 0;
    public int count = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        OrderService srv = new OrderService();
        OrderDetailService dsrv = new OrderDetailService();
        if (Session["customer"] != null)
        {
            Customer customer = (Customer)Session["customer"];
            username = customer.cusName;
            List<Order> orderList = srv.GetModelList(" orderStatus='0' and customer = " + customer.ID + " and customerType='2' ");

           

            for (int i = 0; i < orderList.Count; i++)
            {
                //Response.Write("<script language='javascript'>alert('111111');</script>");
                List<OrderDetail> detailList = dsrv.GetModelList(" orderID= " + orderList[i].ID);
                for (int j = 0; j < detailList.Count; j++)
                { 
                    amount = amount + detailList[j].goodPrice * detailList[j].goodQuantity;
					count = count + (int)detailList[j].goodQuantity;
                }
            }
        }
        else if (Session["lee"] != null)
        {
            Lessee customer = (Lessee)Session["lee"];
            username = customer.Name;
            List<Order> orderList = srv.GetModelList(" orderStatus='0' and customer = " + customer.ID + " and customerType='1' ");


            for (int i = 0; i < orderList.Count; i++)
            {

                List<OrderDetail> detailList = dsrv.GetModelList(" orderID= " + orderList[i].ID);
                for (int j = 0; j < detailList.Count; j++)
                { 
                    amount = amount + detailList[j].goodPrice * detailList[j].goodQuantity;
					count = count + (int)detailList[j].goodQuantity;
                }
            }
        
        }
    }
}
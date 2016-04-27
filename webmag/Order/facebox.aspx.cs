using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.surfkj.small.order.Model;
using com.surfkj.small.order.BLL;

public partial class webmag_Order_facebox : System.Web.UI.Page
{
    public string detail = "";
    public string id;
    private Order order;
    private OrderService service;
    protected void Page_Load(object sender, EventArgs e)
    {
        id = Request["id"];
       // flag = Request["flag"];
        service = new OrderService();
        order = service.GetModel(int.Parse(id));
        detail = order.message;
         
    }
}
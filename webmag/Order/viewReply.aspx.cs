using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.surfkj.small.order.Model;
using com.surfkj.small.order.BLL;

public partial class webmag_Order_viewReply : System.Web.UI.Page
{
    public string message = "";
    public string reply = "";
    public string id;
    private Order order;
    private OrderService service;
    protected void Page_Load(object sender, EventArgs e)
    {
        id = Request["id"];
        service = new OrderService();
        order = service.GetModel(int.Parse(id));
        message = order.message;
        reply = order.reply;

    }
}
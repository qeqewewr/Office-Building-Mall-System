using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.surfkj.small.order.Model;
using com.surfkj.small.order.BLL;

public partial class webmag_Order_replyFaceBox : System.Web.UI.Page
{
    public string detail = "";
    public string id;
    public Order order;
    private OrderService service;
    private bool flag = false;
    protected void Page_Load(object sender, EventArgs e)
    {   
        service = new OrderService();

        if (Request.HttpMethod == "GET")
        {
                id = Request["id"];
                order = service.GetModel(int.Parse(id));
            
        }
        else if(Request.HttpMethod == "POST")
        {
            detail = Request["reply"].ToString();
            id = Request["orderid"].Trim();
            order = service.GetModel(int.Parse(id));
            order.reply = detail;
            flag = service.Update(order);
            if (flag == true)
            {
                Response.Write("SUCCESS");
            }
            else
            {
                Response.Write("ERROR");
            }
            Response.End();
        }


    }
}
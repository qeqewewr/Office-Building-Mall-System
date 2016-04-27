using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.surfkj.small.order.BLL;
using com.surfkj.small.order.Model;


public partial class webmag_Order_SendGoods : System.Web.UI.Page
{
    private string id;
    private string pageno;
    private Order order;
    private OrderService orderService;
    private bool flag;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["opuser"] == null)
        {
            Response.Write("<script language=javascript>window.location='../../Default.aspx';</script>");
        }
        else
        {
            id = Request["id"];
            pageno = Request["pageno"].Trim();
            orderService = new OrderService();
            //获得选中订单
            order = orderService.GetModel(int.Parse(id));
            order.orderStatus = "3";
            flag = orderService.Update(order);

            if(flag == true)
                Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('已发货!');location.href=('AutOrderList.aspx?pageno=" + pageno + "');</script>");
            else
                Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('发货失败!');history.go(-1);</script>");

        }
    }
}
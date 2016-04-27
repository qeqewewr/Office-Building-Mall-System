using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.surfkj.small.user.BLL;
using com.surfkj.small.user.Model;
using com.surfkj.small.order.Model;
using com.surfkj.small.order.BLL;

public partial class webmag_CustomerManage_DeleteCustomer : System.Web.UI.Page
{
    protected int pageno;
    protected int size;
    private string id;
    public bool flag = true;
    protected List<Customer> customerList;
    private CustomerService service;
   // private Customer customer;
    public string keyword;
    private OrderService orderService = new OrderService();
    public List<Order> orderList;

    protected void Page_Load(object sender, EventArgs e)
    {


        if (Session["opuser"] == null)
        {
            //Response.Redirect("../Default.aspx");
            Response.Write("<script language=javascript>window.location='../../Default.aspx';</script>");
        }
        else
        {
            service = new CustomerService();
            string ids = Request["selectDel"];
            size = 10;
            //查询关键字
            keyword = Request["comName"];

            if (Request.Form["pageno"] != null)
            {
                pageno = int.Parse(Request["pageno"]);
                Response.Redirect("ListCustomer.aspx?pageno=" + pageno + "&keyword=" + keyword);
            }
            else
            {
                //删除单条记录
                if (Request["id"] != null)
                {   
                    pageno = int.Parse(Request["page"]);
                    id = Request["id"];
                    //判断是否有订单存在
                    orderList = orderService.GetModelList("customer = " + int.Parse(id));
                    if (orderList.Count > 0)
                    {
                        Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('该用户有订单存在不能删除!');history.go(-1);</script>");
                    }
                    else
                    { 
                        flag = service.Delete(int.Parse(id));
                        RedirectPage();
                    }
                }//删除多条记录
                else if (ids != null)
                {
                    pageno = int.Parse(Request["page"]);

                    char[] c = { ','};
                    string[] idArray = ids.Split(c);
                    for (int i = 0; i < idArray.Length; i++)
                    {
                        //判断是否有订单存在
                        orderList = orderService.GetModelList("customer = " + int.Parse(idArray[i]));
                        if (orderList.Count > 0)
                        {
                            Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('用户有订单存在不能删除!');;history.go(-1);</script>");
                            flag = false;
                            //continue;
                        }
                        else
                        {
                            flag = service.Delete(int.Parse(idArray[i]));//
                            if (flag == false) break;
                        }
                    }
                    RedirectPage();

                        //判断是否有订单存在
                    //    orderList = orderService.GetModelList("customer = " + int.Parse(id));
                    //if (orderList.Count > 0)
                    //{
                    //    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('该用户有订单存在不能删除!');history.go(-1);</script>");
                    //}
                    //else
                    //{ 
                    //    flag = service.DeleteList(ids);
                    //    RedirectPage();
                    //} 
                }
                else if (ids == null)
                {
                    Response.Redirect("ListCustomer.aspx?pageno=1");
                }

            }
        }

    }

    private void RedirectPage()
    {
        int pagecount;
        int rowcount = service.GetTotalRecordNum();
        int a = rowcount % size;
        if (a == 0)
        {
            if (rowcount == 0)
                pagecount = 1;
            else
                pagecount = rowcount / size;
        }
        else
        {
            pagecount = rowcount / size + 1;
        }

        if (pageno > pagecount) pageno--;

        if (flag == true)
        {

            Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('删除成功!');location.href=('ListCustomer.aspx?pageno=" + pageno + "');</script>");
        }
        else
        {
            Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('删除失败!');history.go(-1);</script>");

        }


    }
}
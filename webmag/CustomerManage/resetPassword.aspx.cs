using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.surfkj.small.user.BLL;
using com.surfkj.small.user.Model;


public partial class webmag_CustomerManage_resetPassword : System.Web.UI.Page
{
    private CustomerService service;
    private Customer customer;
    private string id;
    private int pageno;
    private bool flag = false;
    private int size = 10;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["opuser"] == null)
        {
            Response.Write("<script language=javascript>window.location='../../Default.aspx';</script>");
        }
        else
        {
            service = new CustomerService();
            id = Request["id"].Trim();
            pageno = int.Parse(Request["pageno"]);

            customer = service.GetModel(int.Parse(id));
            if (customer != null)
            {
                customer.cusPassword = "123";
                flag = service.Update(customer);
                RedirectPage();

            }
            else
            {
                Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('不存在该用户!');history.go(-1);</script>");
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

            Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('密码重置成功!');location.href=('ListCustomer.aspx?pageno=" + pageno + "');</script>");
        }
        else
        {
            Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('密码重置失败!');history.go(-1);</script>");

        }
    }
}
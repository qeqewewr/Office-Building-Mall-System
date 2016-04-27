using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.surfkj.small.user.Model;
using com.surfkj.small.user.BLL;
using com.surfkj.small.Model;
public partial class User_UserInfo : System.Web.UI.Page
{
    public Customer customer = new Customer();
    public Lessee les = new Lessee();
    public string customerLevel = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        CustomerService srv = new CustomerService();

        if (Session["customer"] != null)
        {
            customer = (Customer)Session["customer"];
            if (customer.cusLevel == "1")
                customerLevel = "注册用户";
            else if (customer.cusLevel == "2")
                customerLevel = "高级会员用户";
            else if (customer.cusLevel == "3")
                customerLevel = "白银用户";
            else if (customer.cusLevel == "4")
                customerLevel = "白金用户";
            else if (customer.cusLevel == "5")
                customerLevel = "黄金用户";
        }
        else if (Session["lee"] != null)
        {
            les = (Lessee)Session["lee"];
            customerLevel = "注册用户";
        }
        else
        {
            Response.Write("<script language='javascript'>alert('对不起，请登录系统！');window.location.href('login.aspx');</script>");
        }
    }
}
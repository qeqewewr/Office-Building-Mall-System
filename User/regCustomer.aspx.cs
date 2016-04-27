using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.surfkj.small.user.Model;
using com.surfkj.small.user.BLL;

public partial class webmag_Customer_regCustomer : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string username = Request["username"];
        string pwd = Request["pwd"];
        string mail = Request["mail"];
        string realName = Request["realName"];
        string cusUnit = Request["cusUnit"];
        string custel = Request["custel"];
        string addr = Request["addr"];
        string memo = Request["memo"];
        string authcode = Request["authcode"];

        Customer customer = new Customer();
        customer.cusAddr = addr;
        customer.cusEmail = mail;
        customer.cusLevel = "1";
        customer.cusLoginName = username;
        customer.cusMemo = memo;
        customer.cusName = realName;
        customer.cusPassword = pwd;
        customer.cusPoint = 0;
        customer.cusRegTime = DateTime.Now;
        customer.cusTel = custel;
        customer.cusUnit = cusUnit;

        CustomerService srv = new CustomerService();

        int flag = srv.Add(customer);
        if (flag > 0) {
            Session["customer"] = customer;
            Response.Write("<script language='javascript'>alert('注册成功！');window.location.href='UserHome.aspx?userid="+flag+"';</script>");
        }



    }
}
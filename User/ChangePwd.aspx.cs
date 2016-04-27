using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.surfkj.small.goods.Model;
using com.surfkj.small.goods.BLL;
using com.surfkj.small.user.Model;
using com.surfkj.small.order.Model;
using com.surfkj.small.Model;
using com.surfkj.small.order.BLL;
using com.surfkj.small.BLL.OrderDetail;
using com.surfkj.small.user.BLL;
using com.surfkj.small.BLL.Lessee;

public partial class User_ChangePwd : System.Web.UI.Page
{
	
	public Customer customer;
	public Lessee lee;
	public OrderService srv = new OrderService();
    protected void Page_Load(object sender, EventArgs e)
    {
		if (Request.HttpMethod == "POST")
		{
			if (Session["customer"] != null)
			{

				if (Session["lee"] != null)
				{
					Session["lee"] = null;
				}
				customer = (Customer)Session["customer"];
				if (customer.cusPassword != Request["oldpwd"].ToString().Trim())
				{
					Response.Write("原密码错误，请重新输入");
					Response.End();
				}
				if (Request["pwd1"].ToString().Trim() != Request["pwd2"].ToString().Trim())
				{
					Response.Write("两次新密码输入不相同，请重新输入");
					Response.End(); 
				}
				if (Request["pwd1"].ToString().Trim().Length <4 )
				{
					Response.Write("新密码长度不能小于三位");
					Response.End();
				}
				customer.cusPassword = Request["pwd1"].ToString().Trim();
				if ((new CustomerService()).Update(customer))
				{
					Response.Write("success");
				}
				else
				{
					Response.Write("修改失败， 请重试");
				}
				Response.End();
			}
			else if (Session["lee"] != null)
			{

				if (Session["customer"] != null)
				{
					Session["customer"] = null;
				}
				lee = (Lessee)Session["lee"];
				if (lee.Password != Request["oldpwd"].ToString().Trim())
				{
					Response.Write("原密码错误，请重新输入");
					Response.End();
				}
				if (Request["pwd1"].ToString().Trim() != Request["pwd2"].ToString().Trim())
				{
					Response.Write("两次新密码输入不相同，请重新输入");
					Response.End();
				}
				if (Request["pwd1"].ToString().Trim().Length < 4)
				{
					Response.Write("新密码长度不能小于三位");
					Response.End();
				}
				lee.Password = Request["pwd1"].ToString().Trim();
				if ((new LesseeService()).Update(lee))
				{
					Response.Write("success");
				}
				else
				{
					Response.Write("修改失败， 请重试");
				}
				Response.End();
				//customerLevel = "注册用户";
			}
			else
			{
				Response.Write("unlogin");
			}
			Response.End();
		}

		if (Session["customer"] != null)
		{
			
			if (Session["lee"] != null)
			{
				Session["lee"] = null;
			}
			customer = (Customer)Session["customer"];
			//Response.Write(customer.cusPassword);
		}
		else if (Session["lee"] != null)
		{
			if (Session["customer"] != null)
			{
				Session["customer"] = null;
			}
			lee = (Lessee)Session["lee"];
			//Response.Write(lee.Password);
			//customerLevel = "注册用户";
		}
		else
		{
			Response.Write("<script language='javascript'>alert('对不起，请登录系统！');window.location.href='login.aspx';</script>");
		}
    }
}
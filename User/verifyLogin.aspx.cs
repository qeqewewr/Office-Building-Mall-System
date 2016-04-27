using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.surfkj.small.user.BLL;
using com.surfkj.small.user.Model;
using com.surfkj.small.BLL.Lessee;
using com.surfkj.small.Model;

public partial class User_verifyLogin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string usertype = Request.Form["loginType"];
        string username = Request.Form["loginname"].Trim(); 
        string pass = Request.Form["loginpwd"].Trim();
        if (usertype == "1")
        {
            // Response.Write("<script language='javascript'>alert('企业用户暂未开放');window.location.href='Login.aspx';</script>");
            LesseeService srv = new LesseeService();
            Lessee lee = srv.verifyLogin(username, pass);
            if (lee == null)
            {
                Response.Write("<script language='javascript'>alert('对不起，登录失败！');window.location.href='Login.aspx';</script>");
            }
            else
            {
                if (Session["customer"] != null)
                {
                    Session["customer"] = null;
                }
                Session["lee"] = lee;
                Response.Write("<script language='javascript'>window.location.href='UserHome.aspx';</script>");
            }

	   

        }
        else if (usertype == "2")
        {
            CustomerService srv = new CustomerService();
            Customer customer = srv.verifyLogin(username, pass);
            if (customer == null)
            {
                Response.Write("<script language='javascript'>alert('对不起，登录失败！');window.location.href='Login.aspx';</script>");
            }
            else
            {
                if (Session["lee"] != null)
                {
                    Session["lee"] = null;
                }
                Session["customer"] = customer;
                Response.Write("<script language='javascript'>window.location.href='UserHome.aspx';</script>");
            }

        }
        else
        {
            Response.Write("<script language='javascript'>alert('对不起！');</script>");
        }

    }
}
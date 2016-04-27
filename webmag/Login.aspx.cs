using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.surfkj.small.BLL;
using com.surfkj.small.Model;

public partial class webmag_Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.HttpMethod == "POST")
        {
            ManagerService service = new ManagerService();
            string username = Request.Form["username"].Trim();
            string password = Request.Form["password"].Trim();
            string yzm = Request.Form["yzm"].Trim();

            if (Request.Cookies["CheckCode"].Value.Trim().ToString().ToLower() != yzm.ToLower())
            {
                Response.Write("<script language='javascript'>alert('对不起，您输入的验证码错误！');window.location.href='default.aspx';</script>");
            }

            Manager manager = service.verifyLogin(username, password);
            if (manager == null)
            {
                Response.Write("<script language='javascript'>alert('对不起，用户名密码错误！');window.location.href='default.aspx';</script>");

            }
            else
            {
                Session["opuser"] = manager;
                Response.Write("<script language='javascript'>window.location.href='main.aspx';</script>");
            }
        }
        else
        {
            if (Session["opuser"] == null)
            {
                Response.Redirect("Default.aspx");
            }
            else
            {
                Response.Redirect("Main.aspx");
            }

        }
        /*
              if (Session["opuser"] == null)
              {
                  Response.Redirect("Default.aspx");
              }
              else
              {
                  EmployeService service = new EmployeService();
                  string username = Request.Form["username"].Trim();
                  string password = Request.Form["password"].Trim();
                  string yzm = Request.Form["yzm"].Trim();

                  if (Request.Cookies["CheckCode"].Value.Trim().ToString() != yzm)
                  {
                      Response.Write("<script language='javascript'>alert('对不起，您输入的验证码错误！');window.location.href('default.aspx');</script>");
                  }

                  Employe employe = service.verifyLogin(username, password);
                  if (employe == null)
                  {
                      Response.Write("<script language='javascript'>alert('对不起，用户名密码错误！');window.location.href('default.aspx');</script>");

                  }
                  else
                  {
                      Session["opuser"] = employe;
                      Response.Write("<script language='javascript'>window.location.href='main.aspx';</script>");
                  }
              }
   
              */
    }
}
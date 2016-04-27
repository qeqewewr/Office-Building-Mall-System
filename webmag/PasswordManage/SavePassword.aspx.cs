using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.surfkj.small.Model;
using com.surfkj.small.BLL;

public partial class webmag_PasswordManage_SavePassword : System.Web.UI.Page
{
    public Manager manager;
    private string password;
    private string username;
    private ManagerService service;
    private bool flag;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["opuser"] == null)
        {
            Response.Write("<script language=javascript>window.location='../../Default.aspx';</script>");
        }
        else
        {
            service = new ManagerService();
            manager = (Manager)Session["opuser"];
            flag = false;
            if (Request["mark"] != null && Request["mark"] == "1")
            {
                password = Request["pwd1"];
                manager.passWord = password;
                flag = service.Update(manager);
                if (flag == true)
                {
                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('设置成功!');location.href=('updatePassword.aspx');</script>");
                    
                }
                else
                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('设置失败!');history.go(-1);</script>");
               
            }
            else if (Request["mark"] != null && Request["mark"] == "0")
            {
                username = Request["username"];
                manager.userName = username;
                flag = service.Update(manager);
                if (flag == true)
                {
                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('设置成功!下次登录时请用新用户名!');location.href=('updateName.aspx');</script>");
                    
                }
                else
                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('设置失败!');history.go(-1);</script>");
            }

           

        }
    }
}
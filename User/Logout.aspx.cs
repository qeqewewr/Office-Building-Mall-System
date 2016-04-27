using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_Logout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["customer"] != null)
        {
            Session["customer"] = null;
        }
        else if (Session["lee"] != null)
        {
            Session["lee"] = null;
        }

        Response.Write("<script language='javascript'>alert('注销成功！');window.location.href='/Index.aspx';</script>");


        
    }
}
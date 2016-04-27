using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class webmag_Order_AutChangePage : System.Web.UI.Page
{
    protected int pageno;
    protected int size;
    public string keyword;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["opuser"] == null)
        {
            Response.Write("<script language=javascript>window.location='../../Default.aspx';</script>");
        }
        else
        {
            size = 10;
            //查询关键字
            keyword = Request["comName"];


            if (Request.Form["pageno"] != null)
            {
                pageno = int.Parse(Request["pageno"]);
                Response.Redirect("AutOrderList.aspx?pageno=" + pageno + "&keyword=" + keyword);
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class webmag_Advertisement_ChangePage : System.Web.UI.Page
{
    protected int pageno;
    protected int size;

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
            if (Request.Form["pageno"] != null)
            {
                pageno = int.Parse(Request["pageno"]);
                Response.Redirect("SaveAdvertisement.aspx?pageno=" + pageno);
            }
        }
    }
}
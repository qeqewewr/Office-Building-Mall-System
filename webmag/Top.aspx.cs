using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.surfkj.small.Model;

public partial class webmag_Top : System.Web.UI.Page
{
    public Manager manager;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["opuser"] == null)
        {
            //Response.Redirect("Default.aspx");
			Response.Write("<script language=javascript>window.location='Default.aspx';</script>");
        }
        else {

            manager = (Manager)Session["opuser"];
        }
        
    }
}
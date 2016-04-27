using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class webmag_logout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["opuser"] = null;
        //Response.Redirect("Default.aspx");
		Response.Write("<script language=javascript>window.location='Default.aspx';</script>");
    }
}
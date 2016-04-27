using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class webmag_Main : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["opuser"] == null)
        {
            //Response.Redirect("Default.aspx");
			Response.Write("<script language=javascript>window.location='Default.aspx';</script>");
        }
    }
}
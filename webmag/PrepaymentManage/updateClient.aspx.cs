using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class webmag_PrepaymentManage_updateClient : System.Web.UI.Page
{
    protected int pageno;
    protected int size;
    public string keyword;
    public string client;

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

            if (Request["pageno"] != null && Request["cli"] != null)
            {
                pageno = int.Parse(Request["pageno"]);
                client = Request["cli"];
                Response.Redirect("ListClient.aspx?pageno=" + pageno + "&keyword=" + keyword + "&client=" + client);
            }
            //else if (Request["cli"] == null)
            //{
            //    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('!@@@S');history.go(-1);</script>");
            //}
            //else 
            //{
            //    pageno = int.Parse(Request["pageno"]);
            //    client = Request["cli"];
            //    Response.Write(client);
            //    Response.Write(pageno);
            //   // Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('<%%>');history.go(-1);</script>");
            //}
        }
    }
}
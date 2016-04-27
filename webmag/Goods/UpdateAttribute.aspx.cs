using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.surfkj.small.goods.BLL;
using com.surfkj.small.goods.Model;

public partial class webmag_Goods_UpdateAttribute : System.Web.UI.Page
{
    public GoodAtrribute attribute = new GoodAtrribute();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["opuser"] == null)
        {
            Response.Redirect("../../Default.aspx");
        }
        else
        {
            List<GoodAtrribute> pageItems = new List<GoodAtrribute>();
            GoodAtrributeService srv = new GoodAtrributeService();


            attribute = srv.GetModel(int.Parse(Request["id"]));
        }
     
    }
}
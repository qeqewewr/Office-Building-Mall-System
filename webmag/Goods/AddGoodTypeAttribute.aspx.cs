using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.surfkj.small.goods.BLL;
using com.surfkj.small.goods.Model;
public partial class webmag_Goods_AddGoodTypeAttribute : System.Web.UI.Page
{

    public GoodType goodType = new GoodType();
    public GoodTypeService srv = new GoodTypeService();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["opuser"] == null)
        {
            Response.Redirect("../../Default.aspx");
        }
        else
        {
            int id = int.Parse(Request["id"]);
            int pageno = int.Parse(Request["pageno"]);
            goodType = srv.GetModel(int.Parse(Request["id"]));
        }
    }




    
}
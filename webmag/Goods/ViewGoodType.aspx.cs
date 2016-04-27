using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.surfkj.small.goods.BLL;
using com.surfkj.small.goods.Model;

public partial class webmag_Goods_ViewGoodType : System.Web.UI.Page
{
    public GoodType goodType = new GoodType();
    public GoodTypeService srv = new GoodTypeService();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["opuser"] == null)
        {
            Response.Write("<script language=javascript>window.location='../../Default.aspx';</script>");
        }
        else
        {
            goodType = srv.GetModel(int.Parse(Request["id"]));
        }
    }
}
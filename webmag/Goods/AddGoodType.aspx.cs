using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.surfkj.small.goods.Model;
using com.surfkj.small.goods.BLL;

public partial class webmag_Goods_AddGoodType : System.Web.UI.Page
{
    public List<GoodType> exist = new List<GoodType>();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["opuser"] == null)
        {
            Response.Write("<script language=javascript>window.location='../../Default.aspx';</script>");
        }
        else
        {
            GoodTypeService srv = new GoodTypeService();

            exist = srv.GetList(" 1=1");
        }



    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.surfkj.small.goods.BLL;
using com.surfkj.small.goods.Model;

public partial class User_facebox : System.Web.UI.Page
{
    public string detail = "";
    public string id;
    private Goods goods;
    private GoodsService service;
    protected void Page_Load(object sender, EventArgs e)
    {
        id = Request["goodid"];
        // flag = Request["flag"];
        service = new GoodsService();
        goods = service.GetModel(int.Parse(id));
        detail = goods.goodMemo;

    }
}
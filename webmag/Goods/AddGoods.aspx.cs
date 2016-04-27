using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.surfkj.small.goods.Model;
using com.surfkj.small.goods.BLL;

public partial class webmag_Goods_AddGoods : System.Web.UI.Page
{
    private List<GoodType> temp = new List<GoodType>();
    public List<GoodType> exist = new List<GoodType>();
    GoodTypeService srv = new GoodTypeService();
     
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["opuser"] == null)
        {
            Response.Write("<script language=javascript>window.location='../../Default.aspx';</script>");
        }
        else
        {
            temp = srv.GetList(" 1=1");//获取所有的分类
            for (int i = 0; i < temp.Count; i++)//获取叶子
            {   int tempid = temp[i].ID;
                bool sign = true;
                for (int j = 0; j < temp.Count;j++ )
                {
                    if (temp[j].parent == tempid)
                    {
                        sign = false;
                        break;
                    }
                }
                if (sign == true)
                {
                    exist.Add(temp[i]);
                }

            }
        }
        
    }
}
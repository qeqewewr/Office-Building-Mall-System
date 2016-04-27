using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.surfkj.small.goods.Model;
using com.surfkj.small.goods.BLL;
using com.surfkj.small.Model;
using com.surfkj.small.BLL;

public partial class webmag_Goods_UpdateGoods : System.Web.UI.Page
{
    public List<GoodType> exist = new List<GoodType>();
    private List<GoodType> temp = new List<GoodType>();
    GoodTypeService srv = new GoodTypeService();
    GoodsService gsrv = new GoodsService();
    public GoodType goodType = new GoodType();
    public Goods entity = new Goods();
    public List<ImgAttachment> attach = new List<ImgAttachment>();
    public string uploadpath = HttpContext.Current.Request.ApplicationPath;

    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["opuser"] == null)
        {
            Response.Write("<script language=javascript>window.location='../../Default.aspx';</script>");
        }
        else
        {
            ImgAttachmentService msrv = new ImgAttachmentService();


           // exist = srv.GetList(" 1=1");
            //处理分类
            temp = srv.GetList(" 1=1");//获取所有的分类
            for (int i = 0; i < temp.Count; i++)//获取叶子
            {
                int tempid = temp[i].ID;
                bool sign = true;
                for (int j = 0; j < temp.Count; j++)
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


            goodType = srv.GetModel(int.Parse(Request["id"]));

            entity = gsrv.GetModel(int.Parse(Request["id"]));

            attach = msrv.GetModelList(" moduleID=" + Request["id"] + " and attachType = " + entity.goodType);
            uploadpath = uploadpath + "webmag/attachment/";
        }
    }
}
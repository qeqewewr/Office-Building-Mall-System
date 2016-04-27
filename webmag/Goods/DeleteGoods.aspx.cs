using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.surfkj.small.goods.BLL;
using com.surfkj.small.Model;
using com.surfkj.small.BLL;
using com.surfkj.small.BLL.OrderDetail;


public partial class webmag_Goods_DeleteGoods : System.Web.UI.Page
{
    public GoodsService srv = new GoodsService();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["opuser"] == null)
        {
            Response.Write("<script language=javascript>window.location.href='../../Default.aspx';</script>");
        }
        else
        {
            string keyword = "";
            string goodType = "";
            int pageno = 1;
            string url = "ListGoods.aspx?pageno=";

            List<ImgAttachment> img = new List<ImgAttachment>();
            ImgAttachmentService imgService = new ImgAttachmentService();
            List<OrderDetail> detailList = new List<OrderDetail>();
            OrderDetailService detailService = new OrderDetailService();
            if (Request["id"] != null)
            {
                detailList = detailService.GetModelList(" goodID= " + int.Parse(Request["id"]));
                if (detailList.Count == 0)
                {
                    img = imgService.GetModelList(" moduleID= " + int.Parse(Request["id"]));
                    for (int i = 0; i < img.Count; i++)
                    {
                        imgService.Delete(img[i].ID);
                    }
                    srv.Delete(int.Parse(Request["id"]));
                }
                else
                {
                    Response.Write("<script language='javascript'>alert('对不起，该商品存在订单，不能删除！');window.location.href='ListGoods.aspx';</script>");
                }
            }

            if (Request["selectDel"] != null)
            {
                img = imgService.GetModelList(" moduleID in (" + Request["selectDel"] + ")");
                detailList = detailService.GetModelList(" goodID in (" + Request["selectDel"] + ")");
                if (detailList.Count == 0)
                {
                    for (int i = 0; i < img.Count; i++)
                    {
                        imgService.Delete(img[i].ID);
                    }
                    string ids = Request["selectDel"];
                    srv.DeleteList(ids);
                }
                else
                {
                    Response.Write("<script language='javascript'>alert('对不起，有商品存在订单，不能删除！');window.location.href='ListGoods.aspx';</script>");
                }
            }

            if (Request["pageno"] != null)
            {
                pageno = int.Parse(Request["pageno"]);
            }

            url = url + pageno;

            if (Request["keyword"] != null)
            {
                keyword = Request["keyword"].Trim();
                url = url + "&keyword=" + keyword;
            }

            if (Request["goodType"] != null)
            {
                goodType = Request["goodType"].Trim();
                url = url + "&goodType=" + goodType;
            }

            Response.Redirect(url);
        }
    }
}
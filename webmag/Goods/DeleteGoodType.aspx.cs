using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.surfkj.small.goods.BLL;
using com.surfkj.small.goods.Model;

using System.Collections;
public partial class webmag_Goods_DeleteGoodType : System.Web.UI.Page
{
     
    public GoodTypeService srv = new GoodTypeService(); 
	   public GoodsService gsrv = new GoodsService();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["opuser"] == null)
        {
            Response.Write("<script language=javascript>window.location='../../Default.aspx';</script>");
        }
        else
        {
            string keyword = "";
            int pageno = 1;
            string url = "ListGoodType.aspx?pageno=";

            if (Request["id"] != null)
            {
				List<GoodType> list =   srv.GetModelList(" parent="+int.Parse(Request["id"])); 
				List<Goods> list1 =  gsrv.GetModelList(" goodType="+int.Parse(Request["id"])); 
				
				
				if(list1.Count ==0 && list.Count==0){
					srv.Delete(int.Parse(Request["id"]));
				}else{
				Response.Write("<script language='javascript'>alert('对不起，该类存在商品或者小类，不能删除！');window.location.href='ListGoodType.aspx';</script>");
				}
                
            }

            if (Request["selectDel"] != null)
            {
                List<GoodType> list = srv.GetModelList(" parent in(" + Request["selectDel"] + ")");

                List<Goods> list1 = gsrv.GetModelList(" goodType in(" + Request["selectDel"] + ")");
                if (list1.Count == 0 && list.Count == 0)
                {
                    string ids = Request["selectDel"];
                    srv.DeleteList(ids);
                }
                else
                {
                    Response.Write("<script language='javascript'>alert('对不起，有类别存在商品或者小类，不能删除！');window.location.href='ListGoodType.aspx';</script>");
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


            //Response.Redirect(url);
			Response.Write("<script language=javascript>window.location='"+url+"';</script>");



        }

    }
}
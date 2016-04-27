using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.surfkj.small.BLL;
using com.surfkj.small.Model;
using com.surfkj.small.goods.BLL;
using com.surfkj.small.goods.Model;
public partial class Goods_GoodsDetail : System.Web.UI.Page
{
    public string upload = HttpContext.Current.Request.ApplicationPath + "webmag/attachment/";
    public List<GoodType> exist = new List<GoodType>();
	public List<GoodType> sameTypes = new List<GoodType>();
    GoodTypeService srv = new GoodTypeService();
    GoodsService gsrv = new GoodsService();
    public GoodType goodType = new GoodType();
    public Goods entity = new Goods();
    public List<ImgAttachment> attach = new List<ImgAttachment>();
	public GoodType TopType = new GoodType();

    protected void Page_Load(object sender, EventArgs e)
    {


        ImgAttachmentService msrv = new ImgAttachmentService();
        //exist = srv.GetList(" 1=1");
        //goodType = srv.GetModel(int.Parse(Request["id"]));
		
        entity = gsrv.GetModel(int.Parse(Request["id"]));
	//	Response.Write(entity.goodType+"<br />");
		exist = getTypes(entity.goodType);
		if (exist.Count > 0)
			TopType = exist[exist.Count - 1];
		sameTypes = getSameTypes(entity.goodType);
		//Response.Write(exist.Count);
        attach = msrv.GetModelList(" moduleID=" + Request["id"] + " and attachType = "+entity.goodType);
    }

	public List<GoodType> getTypes(int typeid)
	{
		List<GoodType> types = new List<GoodType>();
		GoodType type = srv.GetModel(typeid);
		types.Add(type);
		int parent = type.parent;
		while (parent > 0)
		{
			type = srv.GetModel(parent);
			types.Add(type);
			parent = type.parent;
		}
		return types;
	}

	public List<GoodType> getSameTypes(int typeid)
	{
		GoodType type = srv.GetModel(typeid);
		List<GoodType> types = srv.GetModelList("parent="+type.parent);
		return types;
	}
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.surfkj.small.goods.Model;
using com.surfkj.small.goods.BLL;
using com.surfkj.small.BLL;

public partial class Goods_GoodsList : System.Web.UI.Page
{
	public string upload = HttpContext.Current.Request.ApplicationPath + "webmag/attachment/";
	public CPageForm cPage = new CPageForm();
	public List<Goods> list = new List<Goods>();
	public string pageno;//页码
	public string keyword;//查询关键字

	public ImgAttachmentService attachSrv = new ImgAttachmentService();

	public string goodTypeName;

	public GoodType goodType;

	public int ptype;

	public List<GoodType> goodsTypeList = new List<GoodType>();

	public GoodTypeService gts = new GoodTypeService();

	protected void Page_Load(object sender, EventArgs e)
	{
		int type;
		/*
		if (Request["type"] == null)
			type = 5;
		else
			type = int.Parse(Request["type"]);

		GoodType = gts.GetModel(type);
		*/


		GoodsService service = new GoodsService();



		if (Request["pageno"] != null)
		{
			pageno = Request["pageno"].Trim();
		}
		else
		{
			pageno = "1";
		}


		if (Request["keyword"] != "" && Request["keyword"] != null)
		{

			keyword = Request["keyword"].Trim();
			cPage.setPagesize(16);
			cPage.setRowcount(service.GetInqueryNum("goodName", keyword));
			cPage.setPageno(int.Parse(pageno));
			int a = cPage.getRowcount() % cPage.getPagesize();
			if (a == 0)
			{
				if (cPage.getRowcount() == 0)
					cPage.setRowcount(1);
				else
					cPage.setPagecount(cPage.getRowcount() / cPage.getPagesize());
			}
			else
				cPage.setPagecount(cPage.getRowcount() / cPage.getPagesize() + 1);

			list = service.ListLookGoods(cPage.getPageno(), cPage.getPagesize(), "goodName", keyword);
		}
		else if (Request["type"] != null && Request["type"].ToString().Trim() != "")
		{
			ptype = int.Parse(Request["ptype"]);
			type = int.Parse(Request["type"]);

			goodType = gts.GetModel(type);
			goodTypeName = goodType.typeName;

			cPage.setRowcount(service.GetTotalRecordNum());
			cPage.setPagesize(16);
			cPage.setPageno(int.Parse(pageno));
			string where = goodsCondition(type);
			list = service.ListPageGoods(cPage.getPageno(), cPage.getPagesize(),where);
			goodsTypeList = gts.GetList("parent="+type);
			//list = service.ListPageGoods(cPage.getPageno(), cPage.getPagesize());
		}
	}

	public string goodsCondition(int typeid)
	{
		string where = "goodType in(";
		string IDs = "";
		IDs += typeid;
		List<GoodType> goods = gts.GetModelList("parent=" + typeid);
		Stack<GoodType> goodstypes = new Stack<GoodType>();
		for (int i = 0; i < goods.Count; i++) goodstypes.Push(goods[i]);

		while (goodstypes.Count > 0)
		{
			GoodType goodstype = goodstypes.Pop();
			IDs += "," + goodstype.ID;

			List<GoodType> goods2 = gts.GetModelList("parent=" + goodstype.ID);
			for (int j = 0; j < goods2.Count; j++) goodstypes.Push(goods2[j]);
		}

		where += IDs + ")";
		return where;
	}

	public string goodsTypeCondition(int typeid)
	{
		string where = "ID in(";
		string IDs = "";
		//IDs += typeid;
		List<GoodType> goods = gts.GetModelList("parent=" + typeid);
		Stack<GoodType> goodstypes = new Stack<GoodType>();
		for (int i = 0; i < goods.Count; i++) goodstypes.Push(goods[i]);

		while (goodstypes.Count > 0)
		{
			GoodType goodstype = goodstypes.Pop();
			IDs += "," + goodstype.ID;

			List<GoodType> goods2 = gts.GetModelList("parent=" + goodstype.ID);
			for (int j = 0; j < goods2.Count; j++) goodstypes.Push(goods2[j]);
		}
		if (IDs.Length > 0)
		{
			IDs = IDs.Substring(1);
			where += IDs + ")";
			return where;
		}
		else
		{
			return " 1=1";
		}

	}
}
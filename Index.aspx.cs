using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.surfkj.small.goods.Model;
using com.surfkj.small.goods.BLL;
using com.surfkj.small.BLL;
using com.surfkj.small.Model;
using com.surfkj.small.Model.Advertisement;
using com.surfkj.small.BLL.Advertisement;

public partial class Index : System.Web.UI.Page
{ 
    //public List<GreenLeasing> greenLeasingList = new List<GreenLeasing>();

    //public GreenLeasingService Gservice = new GreenLeasingService();
    public string upload = HttpContext.Current.Request.ApplicationPath + "webmag/attachment/";
    public string advupload = HttpContext.Current.Request.ApplicationPath + "webmag/tt/";
	public List<Goods> goods = new List<Goods>();
	public ImgAttachmentService attachSrv = new ImgAttachmentService();
	public List<ImgAttachment> imgList = new List<ImgAttachment>();

    public List<Advertisement> adverListTop = new List<Advertisement>();
    public List<Advertisement> adverListLeftTop = new List<Advertisement>();
    public List<Advertisement> adverListRight = new List<Advertisement>();
    public List<Advertisement> adverListLink = new List<Advertisement>();
    private AdvertisementService adverService = new AdvertisementService();
	  
    //public TravelService tservice = new TravelService();
    //public List<Travel> travelList = new List<Travel>();


	public GoodsService service = new GoodsService();
	public List<Goods> lastestgood;
	public List<Goods> goodslist;

	private GoodTypeService goodTypeService;
	public List<GoodType> goodTypeList;

	

    protected void Page_Load(object sender, EventArgs e)
    {
		
	//	goods = service.GetList(10," state=0 "," id desc ");
		lastestgood = service.GetList(3,"1=1","id desc");

        //greenLeasingList=  Gservice.GetList(3," 1=1 "," id desc ");
        //travelList = tservice.GetList(4," 1=1 "," id desc ");

		goodTypeService = new GoodTypeService();
		goodTypeList = new List<GoodType>();
		goodTypeList = goodTypeService.GetModelList("parent = 0");

        adverListTop = adverService.GetModelList("AdveType = 1 and State = 1 order by AdveOrder");
        adverListLeftTop = adverService.GetModelList("AdveType = 2 and State = 1 order by AdveOrder");
        adverListRight = adverService.GetModelList("AdveType = 4 and State = 1 order by AdveOrder");
        adverListLink = adverService.GetModelList("AdveType = 3 and State = 1 order by AdveOrder");
    }

	public List<Goods> getGoodsByType(int typeid)
	{
		string where = "goodType in(";
		string IDs = "";
		IDs += typeid;
		List<GoodType> goods = goodTypeService.GetModelList("parent=" + typeid);
		Stack<GoodType> goodstypes = new Stack<GoodType>();
		for (int i = 0; i < goods.Count; i++) goodstypes.Push(goods[i]);

		while (goodstypes.Count > 0)
		{
			GoodType goodstype = goodstypes.Pop();
			IDs += "," + goodstype.ID;

			List<GoodType> goods2 = goodTypeService.GetModelList("parent=" + goodstype.ID);
			for (int j = 0; j < goods2.Count; j++) goodstypes.Push(goods2[j]);
		}

		where += IDs + ")";
		//return service.GetModelList(where);
		return service.GetList(5,where," id desc ");
	}
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.surfkj.small.user.Model;
using com.surfkj.small.goods.Model;
using com.surfkj.small.Model;
using com.surfkj.small.BLL.OrderDetail;
using com.surfkj.small.goods.BLL;
using com.surfkj.small.order.BLL;
using com.surfkj.small.order.Model;

public partial class GoodTypePage : System.Web.UI.Page
{
	public List<GoodType> goodTypeList;
	private GoodTypeService goodTypeService = new GoodTypeService();
	public int pid;

    protected void Page_Load(object sender, EventArgs e)
    {
		if(Request["pid"] == null)
			pid = 0;
		else
			pid = int.Parse(Request["pid"]);
		goodTypeList = goodTypeService.GetModelList("parent="+pid);
    }
}
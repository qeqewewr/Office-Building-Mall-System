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

public partial class NavPage : System.Web.UI.Page
{
	public List<GoodType> list;

	public GoodTypeService gts = new GoodTypeService();

	protected void Page_Load(object sender, EventArgs e)
	{
		list = gts.GetList("parent=0");
	}
}
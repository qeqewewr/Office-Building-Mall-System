using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.surfkj.small.goods.BLL;
using com.surfkj.small.goods.Model;
using System.Collections;
public partial class webmag_Goods_ListGoodAttribute : System.Web.UI.Page
{
    public List<GoodAtrribute> pageItems = new List<GoodAtrribute>();
    public int pageno = 1;
    public int pagesize = 0;
    public CPageForm form = new CPageForm();
    public string keyword = "";
    public GoodAtrributeService srv = new GoodAtrributeService();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["opuser"] == null)
        {
            Response.Redirect("../../Default.aspx");
        }
        else
        {

            pagesize = form.getPagesize();


            if (Request["pageno"] != null)
            {
                pageno = int.Parse(Request["pageno"]);
            }

            if (Request["keyword"] != null)
            {
                keyword = Request["keyword"].Trim();
                pageItems = srv.ListLookGoodsAttributes(pageno, form.getPagesize(), "AttributeName", Request["keyword"].Trim());
                if (pageItems.Count == 0 && pageno != 1)
                {
                    form.setPageno(pageno - 1);
                    pageItems = srv.ListLookGoodsAttributes(pageno - 1, form.getPagesize(), "AttributeName", Request["keyword"].Trim());
                }
                form.setRowcount(srv.GetInqueryNum("AttributeName", keyword));
            }
            else
            {
                pageItems = srv.ListPageGoodAttributes(pageno, form.getPagesize());
                if (pageItems.Count == 0 && pageno != 1)
                {
                    form.setPageno(pageno - 1);
                    pageItems = srv.ListPageGoodAttributes(pageno - 1, form.getPagesize());
                }
                form.setRowcount(srv.GetTotalRecordNum());


            }


            form.setPageno(pageno);
            form.setPageitems(new ArrayList());
            form.getPageitems().AddRange(pageItems);
        }
    }
}
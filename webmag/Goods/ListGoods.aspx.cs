using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.surfkj.small.goods.BLL;
using com.surfkj.small.goods.Model;
using System.Collections;
using com.surfkj.small.Model.PermissionManage;
using com.surfkj.small.BLL.PermissionManage;
using com.surfkj.small.Model;
using com.surfkj.small.BLL;
public partial class webmag_Goods_ListGoods : System.Web.UI.Page
{
    public string keyword = "";
    public List<GoodType> exist = new List<GoodType>();
    public List<Goods> pageItems = new List<Goods>();
    public GoodTypeService srv = new GoodTypeService();
    public GoodsService gsrv = new GoodsService();
    public int pageno = 1;
    public int pagesize = 0;
    public CPageForm form = new CPageForm();
    public string goodType = "";
    public Manager manager;
    public List<Permission> permissionList;
    private PermissionService permissionService;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["opuser"] == null)
        {
            Response.Write("<script language=javascript>window.location='../../Default.aspx';</script>");
        }
        else
        {
            manager = (Manager)Session["opuser"];
            permissionService = new PermissionService();
            permissionList = permissionService.GetModelList("StaffID = " + manager.ID + "and FunctionID = 30");

            exist = srv.GetList(" 1=1");

            pagesize = form.getPagesize();


            if (Request["pageno"] != null)
            {
                pageno = int.Parse(Request["pageno"]);
            }

            if (Request["keyword"] != null)
            {
                keyword = Request["keyword"].Trim();
                goodType = Request["goodType"].Trim();
                if (Request["goodType"] == "")
                {
                    pageItems = gsrv.ListLookGoods(pageno, form.getPagesize(), "goodName", Request["keyword"].Trim());
                    if (pageItems.Count == 0 && pageno != 1)
                    {
                        form.setPageno(pageno - 1);
                        pageItems = gsrv.ListLookGoods(pageno - 1, form.getPagesize(), "goodName", Request["keyword"].Trim());
                    }
                    form.setRowcount(gsrv.GetInqueryNum("goodName", keyword));

                }
                else
                {
                    pageItems = gsrv.ListLookGoods(pageno, form.getPagesize(), "goodType", Request["goodType"].Trim(), "goodName", Request["keyword"].Trim());
                    if (pageItems.Count == 0 && pageno != 1)
                    {
                        form.setPageno(pageno - 1);
                        pageItems = gsrv.ListLookGoods(pageno, form.getPagesize(), "goodType", Request["goodType"].Trim(), "goodName", Request["keyword"].Trim());
                    }
                    form.setRowcount(gsrv.GetInqueryNum("goodType", Request["goodType"].Trim(), "goodName", keyword));
                }
            }
            else
            {
                pageItems = gsrv.ListPageGoods(pageno, form.getPagesize());
                if (pageItems.Count == 0 && pageno != 1)
                {
                    form.setPageno(pageno - 1);
                    pageItems = gsrv.ListPageGoods(pageno - 1, form.getPagesize());
                }
                form.setRowcount(gsrv.GetTotalRecordNum());
            }

            form.setPageno(pageno);
            form.setPageitems(new ArrayList());
            form.getPageitems().AddRange(pageItems);
        }
         
    }
}
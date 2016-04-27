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

public partial class webmag_Goods_ListGoodType : System.Web.UI.Page
{
    public List<GoodType> pageItems = new List<GoodType>();
    public int pageno = 1;
    public int pagesize = 0;
    public CPageForm form = new CPageForm();
    public string keyword = "";
    public GoodTypeService srv = new GoodTypeService();
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
            permissionList = permissionService.GetModelList("StaffID = " + manager.ID + "and FunctionID = 32");
            pagesize = form.getPagesize();


            if (Request["pageno"] != null)
            {
                pageno = int.Parse(Request["pageno"]);
            }

            if (Request["keyword"] != null)
            {
                keyword = Request["keyword"].Trim();
                pageItems = srv.ListLookGoodType(pageno, form.getPagesize(), "typeName", Request["keyword"].Trim());
                if (pageItems.Count == 0 && pageno != 1)
                {
                    form.setPageno(pageno - 1);
                    pageItems = srv.ListLookGoodType(pageno - 1, form.getPagesize(), "typeName", Request["keyword"].Trim());
                }
                form.setRowcount(srv.GetInqueryNum("typeName", keyword));
            }
            else
            {
                pageItems = srv.ListPageGoodType(pageno, form.getPagesize());
                if (pageItems.Count == 0 && pageno != 1)
                {
                    form.setPageno(pageno - 1);
                    pageItems = srv.ListPageGoodType(pageno - 1, form.getPagesize()); ;
                }
                form.setRowcount(srv.GetTotalRecordNum());


            }


            form.setPageno(pageno);
            form.setPageitems(new ArrayList());
            form.getPageitems().AddRange(pageItems);


        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.surfkj.small.Model;
using com.surfkj.small.BLL;
using com.surfkj.small.Common;
using com.surfkj.small.Model.PermissionManage;
using com.surfkj.small.BLL.PermissionManage;

public partial class webmag_Agreements_ListAgreements : System.Web.UI.Page
{
    public Agreements cleaner = new Agreements();
    public AgreementsService service = new AgreementsService();
    public List<Agreements> agreementsList = new List<Agreements>();
    public pageForm page = new pageForm();
    public string pageno;//页码
    public string keyword;//查询关键字
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
            permissionList = permissionService.GetModelList("StaffID = " + manager.ID + "and FunctionID = 43");

            pageno = Request["pageno"].Trim();
            if (Request["keyword"] != "" && Request["keyword"] != null)
            {

                keyword = Request["keyword"].Trim();
                page.PageSize = 10;
                page.RowCount = service.GetInqueryNum("Name", keyword);
                page.PageNo = int.Parse(pageno);
                int a = page.RowCount % page.PageSize;
                if (a == 0)
                {
                    if (page.RowCount == 0)
                        page.PageCount = 1;
                    else
                        page.PageCount = page.RowCount / page.PageSize;
                }
                else
                    page.PageCount = page.RowCount / page.PageSize + 1;

                agreementsList = service.ListLookAgreements(page.PageNo, page.PageSize, "Name", keyword);
            }
            else
            {
                page.RowCount = service.GetTotalRecordNum();
                page.PageSize = 10; //每页的条数
                page.PageNo = int.Parse(pageno);
                int a = page.RowCount % page.PageSize;
                if (a == 0)
                {
                    if (page.RowCount == 0)
                        page.PageCount = 1;
                    else
                        page.PageCount = page.RowCount / page.PageSize;
                }
                else
                    page.PageCount = page.RowCount / page.PageSize + 1;

                agreementsList = service.ListPageAgreements(page.PageNo, page.PageSize);
            }
        }

    }
}
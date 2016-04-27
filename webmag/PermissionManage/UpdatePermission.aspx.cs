using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.surfkj.small.BLL.PermissionManage;
using com.surfkj.small.Model.PermissionManage;
using com.surfkj.small.BLL;
using com.surfkj.small.Model;

public partial class webmag_PermissionManage_UpdatePermission : System.Web.UI.Page
{
    private string managerid;
    public Manager manager;
    private ManagerService manService;
    private PermissionService perService;
    private List<Permission> permissionList;
    public List<AllFunction> functionList = new List<AllFunction>();
    public List<AllFunction> allFunctionList;
    public AllFunction function;
    public AllFunctionService funcService;
    public string pageno;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["opuser"] == null)
        {
            Response.Write("<script language=javascript>window.location='../../Default.aspx';</script>");
        }
        else
        {
            pageno = Request["pageno"];
            managerid = Request["id"].Trim();
            manService = new ManagerService();
            perService = new PermissionService();
            funcService = new AllFunctionService();
            manager = manService.GetModel(int.Parse(managerid));
            permissionList = perService.GetModelList("StaffID = " + int.Parse(managerid));
            allFunctionList = funcService.GetModelList("");
            //获得该员工的权限
            if (permissionList != null)
            {
                for (int i = 0; i < permissionList.Count; i++)
                {
                    function = funcService.GetModel(permissionList[i].FunctionID);
                    functionList.Add(function);
                }
            }
        }
    }
}
using System;
using System.Collections.Generic;
 
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.surfkj.small.BLL.PermissionManage;
using com.surfkj.small.Model.PermissionManage;
using com.surfkj.small.Model;
using com.surfkj.small.BLL;

public partial class webmag_Left : System.Web.UI.Page
{
    private Manager manager;
    private List<Permission> permissionList = new List<Permission>();
    public List<AllFunction> functionList = new List<AllFunction>();
    private ManagerService manService;
    private PermissionService perService;
    private AllFunction function;
    private AllFunctionService funcService;
    public List<AllFunction> bigFunctionList = new List<AllFunction>();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["opuser"] == null)
        {
            //Response.Redirect("Default.aspx");
			Response.Write("<script language=javascript>window.location='Default.aspx';</script>");
        }
        else
        {


            manager = (Manager)Session["opuser"];

            perService = new PermissionService();
            funcService = new AllFunctionService();
            //大模块列表
            bigFunctionList = funcService.GetModelList("ParentID is Null");
            permissionList = perService.GetModelList("StaffID = " + manager.ID);
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
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

public partial class webmag_PermissionManage_doUpdatePermission : System.Web.UI.Page
{
    private string managerid;
    public Manager manager;
    private ManagerService manService;
    private PermissionService perService;
    private List<Permission> permissionList;
    private Permission permission;
    private bool flag = true;
    private int nflag;
   // public List<AllFunction> functionList = new List<AllFunction>();
   // public List<AllFunction> allFunctionList;
    //private AllFunction function;
   // private AllFunctionService funcService;
    public string pageno;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["opuser"] == null)
        {
            Response.Write("<script language=javascript>window.location='../../Default.aspx';</script>");
        }
        else
        {
            managerid = Request["managerid"].Trim();
            pageno = Request["pageno"].Trim();
            manService = new ManagerService();
            perService = new PermissionService();
            // funcService = new AllFunctionService();
            manager = manService.GetModel(int.Parse(managerid));
            //  allFunctionList = funcService.GetModelList("");
            //获得该员工原有的权限
            permissionList = perService.GetModelList("StaffID = " + int.Parse(managerid));



            //删除该员工原有的所有权限
            if (permissionList != null)
            {
                for (int k = 0; k < permissionList.Count; k++)
                {
                    flag = perService.Delete(permissionList[k].ID);
                    if (flag == false)
                    {
                        Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('分配失败!');history.go(-1);</script>");
                    }
                }
            }

            ////重新分配权限
            char[] a = { ',' };
            string checkboxValue = Request.Form["all"];
            if (checkboxValue != null)
            {
                string[] functionsId = checkboxValue.Split(a);

                //重新分配

                for (int i = 0; i < functionsId.Length; i++)
                {
                    permission = new Permission();
                    permission.StaffID = int.Parse(managerid);
                    permission.FunctionID = int.Parse(functionsId[i]);
                    nflag = perService.Add(permission);
                    if (nflag <= 0)
                    {
                        Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('分配失败!');history.go(-1);</script>");
                    }
                }
            }

            Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('分配成功!');location.href=('ListPermission.aspx?pageno=" + pageno + "');</script>");
        }
    }
}
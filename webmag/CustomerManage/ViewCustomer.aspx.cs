using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.surfkj.small.user.BLL;
using com.surfkj.small.user.Model;

public partial class webmag_CustomerManage_ViewCustomer : System.Web.UI.Page
{
    private CustomerService service;
    public Customer customer;
    private string id;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["opuser"] == null)
        {
            Response.Write("<script language=javascript>window.location='../../Default.aspx';</script>");
        }
        else
        {
            service = new CustomerService();
            id = Request["id"].Trim();

            customer = service.GetModel(int.Parse(id));
        }
    }
}
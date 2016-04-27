using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.surfkj.small.user.BLL;
using com.surfkj.small.user.Model;
using com.surfkj.small.Common;
using com.surfkj.small.BLL.Lessee;
using com.surfkj.small.Model;

public partial class webmag_PrepaymentManage_cusFaceBox : System.Web.UI.Page
{
    public string permoney = "";
    public string id;
    public Customer customer;
    private CustomerService service;
    private bool flag = false;
    protected void Page_Load(object sender, EventArgs e)
    {
        service = new CustomerService();

        if (Request.HttpMethod == "GET")
        {
            id = Request["id"];
            customer = service.GetModel(int.Parse(id));

        }
        else if (Request.HttpMethod == "POST")
        {
            permoney = Request["permoney"].ToString();
            id = Request["customerid"].Trim();
            customer = service.GetModel(int.Parse(id));
            customer.cusMoney = float.Parse(permoney) + customer.cusMoney;
            flag = service.Update(customer);
            if (flag == true)
            {
                Response.Write("SUCCESS");
            }
            else
            {
                Response.Write("ERROR");
            }
            Response.End();
        }

    }
}
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

public partial class webmag_PrepaymentManage_viewfacebox : System.Web.UI.Page
{   public float detail = 0;
    public string id;
    private Lessee lessee;
    private LesseeService leservice;
    private Customer customer;
    private CustomerService service;
    protected void Page_Load(object sender, EventArgs e)
    {

            id = Request["id"];

            if (Request["setSign"] == "1")
            {
                leservice = new LesseeService();
                lessee = leservice.GetModel(int.Parse(id));
                detail = lessee.WarrantMon;
            }
            else if (Request["setSign"] == "0")
            {
                service = new CustomerService();
                customer = service.GetModel(int.Parse(id));
                detail = customer.cusMoney;
            }
         

    }
}
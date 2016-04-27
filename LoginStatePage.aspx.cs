using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.surfkj.small.user.BLL;
using com.surfkj.small.user.Model;
using com.surfkj.small.BLL.Lessee;
using com.surfkj.small.Model;

public partial class LoginStatePage : System.Web.UI.Page
{
	public Customer customer = new Customer();
	public Lessee lee = new Lessee();
	public string username = null;
    protected void Page_Load(object sender, EventArgs e)
    {
		if (Session["lee"] != null)
		{
			lee = (Lessee)Session["lee"];
			username = lee.Name;
		}
		else if (Session["customer"] != null)
		{
			customer = (Customer)Session["customer"];
			username = customer.cusName;
		}
		else
		{

		}

    }
}
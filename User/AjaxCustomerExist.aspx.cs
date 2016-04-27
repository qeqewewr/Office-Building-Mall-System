using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using com.surfkj.small.user.BLL;
using com.surfkj.small.user.Model;

public partial class User_AjaxCustomerExist : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string username = Request["username"].Trim().ToUpper();

        CustomerService srv = new CustomerService();
        List<Customer> customers = srv.GetModelList(" cusLoginName = '"+username+"'");

		string data = "";
		if (customers.Count == 0)
			data = "success";
		else
			data = "error";
		Response.Write(data);		/*        XmlDocument doc = new XmlDocument();                string returnText = "";        Response.ContentType = "application/xml";        Response.HeaderEncoding = System.Text.Encoding.UTF8;        returnText += "<?xml version=\"1.0\" encoding=\"utf-8\"?>";        returnText += "<r><mess>" + f + "</mess></r>";               doc.LoadXml(returnText);        Response.Write(returnText);		*/
    }

    

}
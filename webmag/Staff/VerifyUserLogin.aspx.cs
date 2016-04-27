using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class webmag_Staff_VerifyUserLogin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        string loginUser = Request.Form["username"].Trim();
        string password = Request.Form["password"].Trim();
        string yzm = Request.Cookies[""].Value.ToString();


    }
}
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class webmag_Default : System.Web.UI.Page
{
        public string path ;
    protected void Page_Load(object sender, EventArgs e)
    {

        path = string.Format("获取当前应用程序的根目录路径: {0}", Server.HtmlEncode(Request.ApplicationPath)); 

    }
}
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


public partial class webmag_PrepaymentManage_facebox : System.Web.UI.Page
{
    public string permoney = "";
    public string id;
    public Lessee lessee;
    private LesseeService leservice;
    private bool flag = false;
    protected void Page_Load(object sender, EventArgs e)
    {

            leservice = new LesseeService();

            if (Request.HttpMethod == "GET")
            {
                id = Request["id"];
                lessee = leservice.GetModel(int.Parse(id));

            }
            else if (Request.HttpMethod == "POST")
            {
                permoney = Request["permoney"].ToString();
                id = Request["lesseeid"].Trim();
                lessee = leservice.GetModel(int.Parse(id));
                lessee.WarrantMon = float.Parse(permoney) + lessee.WarrantMon;
                flag = leservice.Update(lessee);
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
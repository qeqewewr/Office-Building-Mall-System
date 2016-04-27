using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.surfkj.small.goods.BLL;
public partial class webmag_Goods_DeleteGoodAttribute : System.Web.UI.Page
{
    public GoodAtrributeService srv = new GoodAtrributeService(); 
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["opuser"] == null)
        {
            Response.Redirect("../../Default.aspx");
        }
        else
        {
            string keyword = "";
            int pageno = 1;
            string url = "ListGoodAttribute.aspx?pageno=";

            if (Request["id"] != null)
            {
                srv.Delete(int.Parse(Request["id"]));
            }

            if (Request["selectDel"] != null)
            {
                string ids = Request["selectDel"];
                srv.DeleteList(ids);
            }

            if (Request["pageno"] != null)
            {
                pageno = int.Parse(Request["pageno"]);
            }

            url = url + pageno;


            if (Request["keyword"] != null)
            {
                keyword = Request["keyword"].Trim();
                url = url + "&keyword=" + keyword;
            }


            Response.Redirect(url);
        }
    }
}
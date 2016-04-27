using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.surfkj.small.goods.BLL;
using com.surfkj.small.goods.Model;

public partial class webmag_Goods_SaveAttribute : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["opuser"] == null)
        {
            Response.Write("<script language=javascript>window.location='../../Default.aspx';</script>");
        }
        else
        {
            GoodAtrributeService srv = new GoodAtrributeService();
            if (Request["action"].ToString() == "add")
            {
                GoodAtrribute attribute = new GoodAtrribute();
                string attributeName = Request.Form["attributeName"].Trim();
                attribute.AttributeName = attributeName;
                srv.Add(attribute);

                Response.Write("<script language='javascript'>alert('添加成功！');window.location.href('ListGoodAttribute.aspx');</script>");

            }
            else if (Request["action"].ToString() == "edit")
            {
                GoodAtrribute attribute = new GoodAtrribute();
                string attributeName = Request.Form["attributeName"].Trim();
                attribute.AttributeName = attributeName;
                attribute.ID = int.Parse(Request["id"]);
                srv.Update(attribute);

                Response.Write("<script language='javascript'>alert('更新成功！');window.location.href('ListGoodAttribute.aspx');</script>");

            }
        }


    }
}
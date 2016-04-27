using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.surfkj.small.goods.BLL;
using com.surfkj.small.goods.Model;

public partial class webmag_Goods_SaveGoodType : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["opuser"] == null)
        {
            Response.Write("<script language=javascript>window.location='../../Default.aspx';</script>");
        }
        else
        {
            GoodTypeService srv = new GoodTypeService();
            if (Request["action"].ToString() == "add")
            {
                GoodType type = new GoodType();
                string goodType = Request.Form["goodType"].Trim();
                type.typeName = goodType;
                if (Request["parent"].ToString() != "")
                {
                    string parentText = Request["parent"];
                    char[] sep = { '#' };
                    string[] parent = parentText.Split(sep);

                    type.parent = int.Parse(parent[0]);
                    type.Tlevel = (int.Parse(parent[1]) + 1).ToString();
                }
                else
                {
                    type.Tlevel = "1";
                }
            
                type.memo = Request["memo"].Trim();

                srv.Add(type);

                Response.Write("<script language='javascript'>alert('添加成功！');window.location.href='ListGoodType.aspx';</script>");

            }
            else if (Request["action"].ToString() == "edit")
            {
                GoodType type = new GoodType();
                string goodType = Request.Form["goodType"].Trim();
                type.typeName = goodType;

                if (Request["parent"].ToString() != "")
                {
                    string parentText = Request["parent"];
                    char[] sep = { '#' };
                    string[] parent = parentText.Split(sep);

                    type.parent = int.Parse(parent[0]);
                    type.Tlevel = (int.Parse(parent[1]) + 1).ToString();
                }
                else
                {
                    type.Tlevel = "1";
                }

                type.memo = Request["memo"].Trim();
                type.ID = int.Parse(Request["id"]);
                srv.Update(type);

                Response.Write("<script language='javascript'>alert('更新成功！');window.location.href='ListGoodType.aspx';</script>");

            }
        }





    }
}
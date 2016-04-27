using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.surfkj.small.goods.BLL;
using com.surfkj.small.goods.Model;
using com.surfkj.small.Model;
using com.surfkj.small.BLL;
public partial class webmag_Goods_SaveGoods : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["opuser"] == null)
        {
            Response.Write("<script language=javascript>window.location='../../Default.aspx';</script>");
        }
        else
        {
            GoodsService srv = new GoodsService();
            List<ImgAttachment> img = new List<ImgAttachment>();
            ImgAttachmentService imgService = new ImgAttachmentService();
            if (Request["action"].ToString() == "add")
            {
                Goods entity = new Goods();
                string goodName = Request.Form["goodName"].Trim();
                entity.goodName = goodName;
                string goodNO = Request.Form["goodNO"].Trim();
                entity.goodNO = goodNO;
                string goodType = Request.Form["goodType"].Trim();
                entity.goodType = int.Parse(goodType);
                string goodBrand = Request.Form["goodBrand"].Trim();
                entity.goodBrand = goodBrand;
                string goodManufacture = Request.Form["goodManufacture"].Trim();
                entity.goodManufacture = goodManufacture;
                string goodOrg = Request.Form["goodOrg"].Trim();
                entity.goodOrg = goodOrg;
                string goodKg = Request.Form["goodKg"].Trim();
                entity.goodKg = goodKg;
                string goodNetKg = Request.Form["goodNetKg"].Trim();
                entity.goodNetKg = goodNetKg;
                string goodColor = Request.Form["goodColor"].Trim();
                entity.goodColor = goodColor;
                string goodSize = Request.Form["goodSize"].Trim();
                entity.goodSize = goodSize;
                string goodSpecifications = Request.Form["goodSpecifications"].Trim();
                entity.goodSpecifications = goodSpecifications;
                string goodMaterial = Request.Form["goodMaterial"].Trim();
                entity.goodMaterial = goodMaterial;
                string goodPrice = Request.Form["goodPrice"].Trim();

                entity.goodPrice = decimal.Parse(goodPrice);
                string goodPromotion = Request.Form["goodPromotion"].Trim();
                if (goodPromotion != "")
                    entity.goodPromotion = decimal.Parse(goodPromotion);
                if (Request.Form["goodRecommand"] != null)
                {
                    string goodRecommand = Request.Form["goodRecommand"].Trim();
                    entity.goodRecommand = goodRecommand;
                }

                string goodStock = Request.Form["goodStock"].Trim();
                if (goodStock != "")
                    entity.goodStock = int.Parse(goodStock);
                string goodMemo = Request.Form["goodMemo"].Trim();
                entity.goodMemo = goodMemo;

                int flag = srv.Add(entity);

                string uploadpath = AppDomain.CurrentDomain.BaseDirectory;
                uploadpath = uploadpath + "\\webmag\\attachment\\";

                string args = Request["ufile"];
                if (args != null)
                {
                    char[] sep = { ',' };
                    string[] fileArray = args.Split(sep);
                    for (int i = 0; i < fileArray.Length; i++)
                    {
                        char[] c = { '#' };
                        string fileNameArray = fileArray[i].Split(c)[0];
                        ImgAttachment imgAttach = new ImgAttachment();
                        imgAttach.attachName = fileNameArray;
                        imgAttach.addDate = DateTime.Now;
                        imgAttach.attachUrl = fileArray[i].Split(c)[1];
                        imgAttach.attachType = int.Parse(Request.Form["goodType"].Trim());
                        if (flag >= 0)
                        {
                            imgAttach.moduleID = flag.ToString();
                            int m = imgService.Add(imgAttach);

                        }
                        else
                        {
                            Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('保存失败!');history.go(-1);</script>");
                        }
                    }
                }


                Response.Write("<script language='javascript'>alert('添加成功！');window.location.href('ListGoods.aspx');</script>");

            }
            else if (Request["action"].ToString() == "edit")
            {

                Goods entity = srv.GetModel(int.Parse(Request["id"]));
                string goodName = Request.Form["goodName"].Trim();
                entity.goodName = goodName;
                string goodNO = Request.Form["goodNO"].Trim();
                entity.goodNO = goodNO;
                string goodType = Request.Form["goodType"].Trim();
                entity.goodType = int.Parse(goodType);
                string goodBrand = Request.Form["goodBrand"].Trim();
                entity.goodBrand = goodBrand;
                string goodManufacture = Request.Form["goodManufacture"].Trim();
                entity.goodManufacture = goodManufacture;
                string goodOrg = Request.Form["goodOrg"].Trim();
                entity.goodOrg = goodOrg;
                string goodKg = Request.Form["goodKg"].Trim();
                entity.goodKg = goodKg;
                string goodNetKg = Request.Form["goodNetKg"].Trim();
                entity.goodNetKg = goodNetKg;
                string goodColor = Request.Form["goodColor"].Trim();
                entity.goodColor = goodColor;
                string goodSize = Request.Form["goodSize"].Trim();
                entity.goodSize = goodSize;
                string goodSpecifications = Request.Form["goodSpecifications"].Trim();
                entity.goodSpecifications = goodSpecifications;
                string goodMaterial = Request.Form["goodMaterial"].Trim();
                entity.goodMaterial = goodMaterial;
                string goodPrice = Request.Form["goodPrice"].Trim();

                entity.goodPrice = decimal.Parse(goodPrice);
                string goodPromotion = Request.Form["goodPromotion"].Trim();
                if (goodPromotion != "")
                    entity.goodPromotion = decimal.Parse(goodPromotion);
                if (Request.Form["goodRecommand"] != null)
                {
                    string goodRecommand = Request.Form["goodRecommand"].Trim();
                    entity.goodRecommand = goodRecommand;
                }
                string goodStock = Request.Form["goodStock"].Trim();
                if (goodStock != "")
                    entity.goodStock = int.Parse(goodStock);
                string goodMemo = Request.Form["goodMemo"].Trim();
                entity.goodMemo = goodMemo;

                bool flag = srv.Update(entity);

                string uploadpath = AppDomain.CurrentDomain.BaseDirectory;
                uploadpath = uploadpath + "\\webmag\\attachment\\";
                string args = Request["ufile"];
                if (args != null)
                {
                    char[] sep = { ',' };
                    string[] fileArray = args.Split(sep);
                    for (int i = 0; i < fileArray.Length; i++)
                    {
                        char[] c = { '#' };
                        string fileNameArray = fileArray[i].Split(c)[0];
                        ImgAttachment imgAttach = new ImgAttachment();
                        imgAttach.attachName = fileNameArray;
                        imgAttach.addDate = DateTime.Now;
                        imgAttach.attachUrl = fileArray[i].Split(c)[1];
                        imgAttach.attachType = int.Parse(Request.Form["goodType"].Trim());
                        if (flag == true)
                        {
                            imgAttach.moduleID = entity.ID.ToString();
                            int m = imgService.Add(imgAttach);

                        }
                        else
                        {
                            Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('保存失败!');history.go(-1);</script>");
                        }
                    }
                }



                Response.Write("<script language='javascript'>alert('更新成功！');window.location.href('ListGoods.aspx');</script>");

            }
        }


    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.surfkj.small.Model;
using com.surfkj.small.BLL;

public partial class webmag_Agreements_DeleteAgreements : System.Web.UI.Page
{
    protected int pageno;
    protected int size;
    private string id;
    public bool flag;
    public bool aflag = true;
    protected List<Agreements> agreementsList;
    protected List<ImgAttachment> attList;
    private ImgAttachmentService attService;
    private AgreementsService service;
    //private Agreements agreement;
    public string keyword;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["opuser"] == null)
        {
            //Response.Redirect("../Main.aspx");
            Response.Write("<script language=javascript>window.location='../../Default.aspx';</script>");
        }
        else
        { 
         service = new AgreementsService();
         attService = new ImgAttachmentService();
        string ids = Request["selectDel"];
        size = 10;
        //查询关键字
        keyword = Request["comName"];
        string uploadpath = AppDomain.CurrentDomain.BaseDirectory;
         uploadpath = uploadpath + "webmag\\attachment\\";

        if (Request.Form["pageno"] != null)
        { 
            pageno = int.Parse(Request["pageno"]);
            Response.Redirect("ListAgreements.aspx?pageno=" + pageno+"&keyword="+keyword);
        }
        else { 
            //删除单条记录
                    if(Request["id"] != null)
                    {
                        pageno = int.Parse(Request["page"]);
           // pageno = 1;
                        id = Request["id"];
                        //id = "10";
                        attList = attService.GetModelList("moduleID = " + id + " and attachType = 9");
                        if (attList != null)
                        {
                            for (int i = 0; i < attList.Count; i++)
                            {

                                aflag = attService.Delete(attList[i].ID);
                                if (aflag == true)
                                {
                                    if (attList[i] != null)
                                    {
                                        uploadpath = uploadpath + attList[i].attachUrl;
                                        System.IO.File.Delete(uploadpath);

                                    }
                                }
                                if (aflag == false)
                                    break;
                            }
                        }

                        if (aflag == true)
                        {
                            flag = service.Delete(int.Parse(id));
                        }
                        else
                        {
                            flag = false;
                        }

                        RedirectPage();
                    }//删除多条记录
                    else if (ids != null)
                    {


                        pageno = int.Parse(Request["page"]);
                        char[] c = { ',' };
                        string[] idArray = ids.Split(c);
                        for (int i = 0; i < idArray.Length; i++)
                        {
                            attList = attService.GetModelList("moduleID = " + idArray[i] + " and attachType = 9");
                            if (attList != null && aflag == true)
                            {
                                for (int j = 0; j < attList.Count; j++)
                                {
                                    aflag = attService.Delete(attList[j].ID);
                                    if (aflag == true)
                                    {
                                        if (attList[j] != null)
                                        {
                                            uploadpath = AppDomain.CurrentDomain.BaseDirectory;
                                            uploadpath = uploadpath + "webmag\\attachment\\";
                                            uploadpath = uploadpath + attList[j].attachUrl;
                                            System.IO.File.Delete(uploadpath);
                                        }
                                    }
                                    if (aflag == false)
                                        break;
                                }
                            }
                        }
                        if (aflag == true)
                        {
                            flag = service.DeleteList(ids);
                        }
                        else
                        {
                            flag = false;
                        }
                        RedirectPage();
                    }else if (ids == null)
                    {
                        Response.Redirect("ListAgreements.aspx?pageno=1");
                    }

        }

        }
         
        
    }

        private void RedirectPage()
        {
            int pagecount;
            int rowcount = service.GetTotalRecordNum();
            int a = rowcount % size;
            if (a == 0)
            {
                if (rowcount == 0)
                    pagecount = 1;
                else
                    pagecount = rowcount / size;
            }
            else
            {
                pagecount = rowcount / size + 1;
            }

            if (pageno > pagecount) pageno--;

            if (flag == true )
            {

                Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('删除成功!');location.href=('ListAgreements.aspx?pageno=" + pageno + "');</script>");
            }
            else
            {
                Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('删除失败!');history.go(-1);</script>");

            }

        }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.surfkj.small.Model;
using com.surfkj.small.BLL;

public partial class webmag_Agreements_doUpdateAgreements : System.Web.UI.Page
{
    private AgreementsService service;
    private Agreements agreement;
    private List<ImgAttachment> img = new List<ImgAttachment>();
    private ImgAttachmentService imgService = new ImgAttachmentService();
    private string ID;
    private string name;
    private string detail;
    private DateTime updatetime;

    public string pageno;
    public bool flag;
    private int m;

    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["opuser"] == null)
        {
            //Response.Redirect("../Default.aspx");
            Response.Write("<script language=javascript>window.location='../../Default.aspx';</script>");
        }
        else
        {
            service = new AgreementsService();
            ID = Request["id"];
            pageno = Request["pageno"].Trim();
            agreement = service.GetModel(int.Parse(ID));

            name = Request.Form["Name"].Trim();
            detail = Request.Form["Detail"].Trim();
            updatetime = DateTime.Now;

            agreement.Name = name;
            agreement.Detail = detail;
            agreement.UpdateTime = updatetime;

            flag = service.Update(agreement);

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
                    imgAttach.attachType = 9;
                    if (flag == true)
                    {
                        imgAttach.moduleID = agreement.ID.ToString();
                        m = imgService.Add(imgAttach);

                    }
                    else
                    {
                        Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('保存失败!');history.go(-1);</script>");
                    }

                }

                if (m > 0)
                {
                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('保存成功!');location.href=('ListAgreements.aspx?pageno=" + pageno + "');</script>");

                }
                else
                {
                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('图片保存失败!');location.href=('UpdateAgreements.aspx?id" + agreement.ID + "&pageno=1');</script>");

                }
            }
            else
            {
                if (flag == true)
                {
                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('保存成功!');location.href=('ListAgreements.aspx?pageno=" + pageno + "');</script>");
                }
                else
                {
                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('保存失败!');history.go(-1);</script>");
                }
            }
        }
    }
}
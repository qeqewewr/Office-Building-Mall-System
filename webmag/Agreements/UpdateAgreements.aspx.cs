using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.surfkj.small.Model;
using com.surfkj.small.BLL;

public partial class webmag_Agreements_UpdateAgreements : System.Web.UI.Page
{
    private string id;
    private AgreementsService service;
    public string pageno;
    public Agreements agreement;
    public List<ImgAttachment> attach = new List<ImgAttachment>();
    public string uploadpath = HttpContext.Current.Request.ApplicationPath;

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
            id = Request["id"];
            pageno = Request["pageno"];
            agreement = service.GetModel(int.Parse(id));

            ImgAttachmentService srv = new ImgAttachmentService();
            attach = srv.GetModelList(" moduleID=" + id + " and attachType = 9");
            uploadpath = uploadpath + "webmag/attachment/";
        }
    }
}
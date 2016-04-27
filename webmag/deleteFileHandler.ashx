<%@ WebHandler Language="C#" Class="deleteFileHandler" %>

using System;
using System.Web;
using com.surfkj.small.BLL;
using com.surfkj.small.Model;

public class deleteFileHandler : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        if (HttpContext.Current.Request["attid"] != null)
        {
            string attchID = HttpContext.Current.Request["attid"];

            ImgAttachmentService service = new ImgAttachmentService();
            ImgAttachment img = service.GetModel(int.Parse(attchID));
           // string path = HttpContext.Current.Request.ApplicationPath+"/webmag/attachment/"+img.attachUrl;
            string path = HttpContext.Current.Server.MapPath(context.Request["folder"]) + "\\attachment\\" + img.attachUrl;
            System.IO.File.Delete(path);
            bool flag = service.Delete(int.Parse(attchID));
        }
        else 
        {
            string url = HttpContext.Current.Request["url"];
            string path = HttpContext.Current.Server.MapPath(context.Request["folder"]) + "\\attachment\\" + url;
            System.IO.File.Delete(path);
        }
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}
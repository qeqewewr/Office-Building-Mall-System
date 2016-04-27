using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.surfkj.small.Model.Advertisement;
using com.surfkj.small.BLL.Advertisement;
using com.surfkj.small.BLL.AdvAttachment;
using com.surfkj.small.Model.AdvAttachment;


public partial class webmag_Advertisement_updateAdvertisement : System.Web.UI.Page
{
    public int adNum=0;
    public int adPosition=0;
    private AdvertisementService service;
    private List<Advertisement> tempList;
    private  List<int>idArray;
    public  List<Advertisement> advertisementList;
    private AdvAttachment advAtt;
    private AdvAttachmentService advService;
    public string uploadpath;
    public string path;
   // public string fileName;
   // public string pageno;//页码
    protected void Page_Load(object sender, EventArgs e)
    {
       // pageno = "1";
        idArray = new List<int>();
        service = new AdvertisementService();
        advertisementList = new List<Advertisement>();
        path = HttpContext.Current.Request.ApplicationPath + "webmag/tt/";
        uploadpath = AppDomain.CurrentDomain.BaseDirectory;
        uploadpath = uploadpath + "\\webmag\\tt\\"; 

        if (Request["sign"] == "0")
        {
            adNum = int.Parse(Request["adNum"]);
            adPosition = int.Parse(Request["ad"]);
            tempList = service.GetModelList("AdveType = " + adPosition);



            //重置State(使用状态)为0
            for (int j = 0; j < tempList.Count; j++)
            {
                tempList[j].State = 0;
                service.Update(tempList[j]);
            }


            if (tempList != null && tempList.Count >= adNum)
            {
                advertisementList = service.GetTopModelList(adNum, "AdveType = " + adPosition, "UpdateTime");
                for (int n = 0; n < advertisementList.Count; n++)
                {
                    advertisementList[n].State = 1;
                    service.Update(advertisementList[n]);
                }

            }
            else if (tempList != null && tempList.Count < adNum)
            {

                int num = adNum - tempList.Count;
                for (int i = 0; i < num; i++)
                {
                    Advertisement advertisement = new Advertisement();
                    advertisement.AdveType = adPosition;
                    advertisement.UpdateTime = DateTime.Now;
                    service.Add(advertisement);
                }
                advertisementList = service.GetTopModelList(adNum, "AdveType = " + adPosition, "UpdateTime");
                for (int n = 0; n < advertisementList.Count; n++)
                {
                    advertisementList[n].State = 1;
                    service.Update(advertisementList[n]);
                }
            }
            else if (tempList == null)
            {
                for (int i = 0; i < adNum; i++)
                {
                    Advertisement advertisement = new Advertisement();
                    advertisement.AdveType = adPosition;
                    advertisement.UpdateTime = DateTime.Now;
                    service.Add(advertisement);
                }
                advertisementList = service.GetTopModelList(adNum, "AdveType = " + adPosition, "UpdateTime");
                for (int n = 0; n < advertisementList.Count; n++)
                {
                    advertisementList[n].State = 1;
                    service.Update(advertisementList[n]);
                }

            }

        }
        else if (Request["sign"] == "1")
        {
            adPosition = int.Parse(Request["advType"]);
                Advertisement advertisement = new Advertisement();
                string id;
                string url;
                //string imgUrl;
                string description;
                string adveOrder;
                bool flag;
                string advType;

                
                id = Request["id"];
                url = Request["Url"];
               // imgUrl = Request["ImgUrl"];
                description = Request["Description"];
                adveOrder = Request["adveOrder"];
                advType = Request["advType"];
                flag = false;

                advertisement = service.GetModel(int.Parse(id));
                advertisement.Url = url;
               // advertisement.ImgUrl = imgUrl;
                advertisement.Description = description;
                advertisement.AdveOrder = int.Parse(adveOrder);
                advertisement.State = 1;//启用标志
                advertisement.UpdateTime = DateTime.Now;

                advService = new AdvAttachmentService();
                if (advService.GetModelList("advID = " + int.Parse(id)).Count > 0)
                {
                    //advAtt = advService.GetModelList("advID = " + int.Parse(id))[0];
                    System.IO.File.Delete(uploadpath + advService.GetModelList("advID = " + int.Parse(id))[0].attachUrl);
                    advService.Delete(advService.GetModelList("advID = " + int.Parse(id))[0].ID);
                    advertisement.ImgUrl = null;
                    service.Update(advertisement);

                }
                if (advType != "3")
                {

                    //处理上传的图片文件
                    if (Request.Files[0] != null && Request.Files[0].FileName != "")
                    {
                        string imgName = "";
                        string imgType = "";


                        advAtt = new AdvAttachment();

                        HttpPostedFile imgFile = Request.Files[0];
                        char[] separtor = { '\\' };
                        string[] spotArray = imgFile.FileName.Split(separtor);
                        for (int j = 0; j < spotArray.Length; j++)
                        {
                            imgName = spotArray[j];
                        }

                        char[] a = { '.' };
                        string[] spot = imgName.Split(a);
                        imgType = spot[1];


                        System.Random random = new Random(Global.GetSeed());
                        string newFileName = System.DateTime.Now.ToString().Replace("/", "").Replace("-", "").Replace(":", "").Replace(" ", "") + random.Next(10000).ToString();

                        imgFile.SaveAs(uploadpath + newFileName + "." + imgType);


                        advAtt.addDate = DateTime.Now;
                        advAtt.attachName = imgName;//原来的文件名
                        advAtt.attachUrl = newFileName + "." + imgType;//现在的文件名
                        advAtt.advID = advertisement.ID;
                        advAtt.attachType = advertisement.AdveType;
                        advService.Add(advAtt);
                        advertisement.ImgUrl = newFileName + "." + imgType;

                    }
                }
                flag = service.Update(advertisement);

                if (flag == true)
                {

                    advertisementList = service.GetModelList("AdveType = " + advType + "and State = 1");
                    adNum = advertisementList.Count;
                    advertisementList = service.GetTopModelList(adNum, "AdveType = " + advType + "and State = 1", "UpdateTime");

                    //Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('设置成功!');location.href=('updateAdvertisement.aspx?sign=2');</script>");
                }
                else {
                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('设置失败!');history.go(-1);</script>");
                }

        }
        //else if (Request["sign"] == "2")
        //{
        //    advertisementList = service.GetModelList("AdveType = " + adPosition + "And State = 1");
        //}
        
    }
}